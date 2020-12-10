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

-- Table [tpdm].[AnonymizedStudent] --
CREATE TABLE [tpdm].[AnonymizedStudent] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [ValueTypeDescriptorId] [INT] NULL,
    [SexDescriptorId] [INT] NULL,
    [GenderDescriptorId] [INT] NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [GradeLevelDescriptorId] [INT] NULL,
    [Section504Enrollment] [BIT] NULL,
    [ELLEnrollment] [BIT] NULL,
    [ESLEnrollment] [BIT] NULL,
    [SPEDEnrollment] [BIT] NULL,
    [TitleIEnrollment] [BIT] NULL,
    [AtriskIndicator] [BIT] NULL,
    [Mobility] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudent_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudent] ADD CONSTRAINT [AnonymizedStudent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudent] ADD CONSTRAINT [AnonymizedStudent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudent] ADD CONSTRAINT [AnonymizedStudent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[AnonymizedStudentAcademicRecord] --
CREATE TABLE [tpdm].[AnonymizedStudentAcademicRecord] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [FactAsOfDate] [DATE] NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [SessionGradePointAverage] [DECIMAL](18, 4) NULL,
    [CumulativeGradePointAverage] [DECIMAL](18, 4) NULL,
    [GPAMax] [DECIMAL](18, 4) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudentAcademicRecord_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [FactAsOfDate] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAcademicRecord] ADD CONSTRAINT [AnonymizedStudentAcademicRecord_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAcademicRecord] ADD CONSTRAINT [AnonymizedStudentAcademicRecord_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAcademicRecord] ADD CONSTRAINT [AnonymizedStudentAcademicRecord_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[AnonymizedStudentAssessment] --
CREATE TABLE [tpdm].[AnonymizedStudentAssessment] (
    [AdministrationDate] [DATE] NOT NULL,
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TakenSchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NULL,
    [AssessmentTitle] [NVARCHAR](100) NULL,
    [AssessmentCategoryDescriptorId] [INT] NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [GradeLevelDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudentAssessment_PK] PRIMARY KEY CLUSTERED (
        [AdministrationDate] ASC,
        [AnonymizedStudentIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC,
        [TakenSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessment] ADD CONSTRAINT [AnonymizedStudentAssessment_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessment] ADD CONSTRAINT [AnonymizedStudentAssessment_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessment] ADD CONSTRAINT [AnonymizedStudentAssessment_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[AnonymizedStudentAssessmentCourseAssociation] --
CREATE TABLE [tpdm].[AnonymizedStudentAssessmentCourseAssociation] (
    [AdministrationDate] [DATE] NOT NULL,
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TakenSchoolYear] [SMALLINT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudentAssessmentCourseAssociation_PK] PRIMARY KEY CLUSTERED (
        [AdministrationDate] ASC,
        [AnonymizedStudentIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC,
        [TakenSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessmentCourseAssociation] ADD CONSTRAINT [AnonymizedStudentAssessmentCourseAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessmentCourseAssociation] ADD CONSTRAINT [AnonymizedStudentAssessmentCourseAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessmentCourseAssociation] ADD CONSTRAINT [AnonymizedStudentAssessmentCourseAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] --
CREATE TABLE [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] (
    [AdministrationDate] [DATE] NOT NULL,
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TakenSchoolYear] [SMALLINT] NOT NULL,
    [PerformanceLevelMet] [BIT] NOT NULL,
    [PerformanceLevelDescriptorId] [INT] NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AnonymizedStudentAssessmentPerformanceLevel_PK] PRIMARY KEY CLUSTERED (
        [AdministrationDate] ASC,
        [AnonymizedStudentIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC,
        [TakenSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] ADD CONSTRAINT [AnonymizedStudentAssessmentPerformanceLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[AnonymizedStudentAssessmentScoreResult] --
CREATE TABLE [tpdm].[AnonymizedStudentAssessmentScoreResult] (
    [AdministrationDate] [DATE] NOT NULL,
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TakenSchoolYear] [SMALLINT] NOT NULL,
    [Result] [NVARCHAR](35) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AnonymizedStudentAssessmentScoreResult_PK] PRIMARY KEY CLUSTERED (
        [AdministrationDate] ASC,
        [AnonymizedStudentIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC,
        [TakenSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessmentScoreResult] ADD CONSTRAINT [AnonymizedStudentAssessmentScoreResult_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[AnonymizedStudentAssessmentSectionAssociation] --
CREATE TABLE [tpdm].[AnonymizedStudentAssessmentSectionAssociation] (
    [AdministrationDate] [DATE] NOT NULL,
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [AssessmentIdentifier] [NVARCHAR](60) NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [TakenSchoolYear] [SMALLINT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudentAssessmentSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [AdministrationDate] ASC,
        [AnonymizedStudentIdentifier] ASC,
        [AssessmentIdentifier] ASC,
        [FactsAsOfDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [TakenSchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessmentSectionAssociation] ADD CONSTRAINT [AnonymizedStudentAssessmentSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessmentSectionAssociation] ADD CONSTRAINT [AnonymizedStudentAssessmentSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudentAssessmentSectionAssociation] ADD CONSTRAINT [AnonymizedStudentAssessmentSectionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[AnonymizedStudentCourseAssociation] --
CREATE TABLE [tpdm].[AnonymizedStudentCourseAssociation] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudentCourseAssociation_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [BeginDate] ASC,
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentCourseAssociation] ADD CONSTRAINT [AnonymizedStudentCourseAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudentCourseAssociation] ADD CONSTRAINT [AnonymizedStudentCourseAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudentCourseAssociation] ADD CONSTRAINT [AnonymizedStudentCourseAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[AnonymizedStudentCourseTranscript] --
CREATE TABLE [tpdm].[AnonymizedStudentCourseTranscript] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [FactAsOfDate] [DATE] NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [FinalLetterGradeEarned] [NVARCHAR](20) NULL,
    [FinalNumericGradeEarned] [DECIMAL](9, 2) NULL,
    [CourseRepeatCodeDescriptorId] [INT] NULL,
    [CourseTitle] [NVARCHAR](60) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudentCourseTranscript_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [FactAsOfDate] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentCourseTranscript] ADD CONSTRAINT [AnonymizedStudentCourseTranscript_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudentCourseTranscript] ADD CONSTRAINT [AnonymizedStudentCourseTranscript_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudentCourseTranscript] ADD CONSTRAINT [AnonymizedStudentCourseTranscript_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[AnonymizedStudentDisability] --
CREATE TABLE [tpdm].[AnonymizedStudentDisability] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AnonymizedStudentDisability_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [DisabilityDescriptorId] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentDisability] ADD CONSTRAINT [AnonymizedStudentDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[AnonymizedStudentDisabilityDesignation] --
CREATE TABLE [tpdm].[AnonymizedStudentDisabilityDesignation] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AnonymizedStudentDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentDisabilityDesignation] ADD CONSTRAINT [AnonymizedStudentDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[AnonymizedStudentEducationOrganizationAssociation] --
CREATE TABLE [tpdm].[AnonymizedStudentEducationOrganizationAssociation] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudentEducationOrganizationAssociation_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [FactsAsOfDate] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentEducationOrganizationAssociation] ADD CONSTRAINT [AnonymizedStudentEducationOrganizationAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudentEducationOrganizationAssociation] ADD CONSTRAINT [AnonymizedStudentEducationOrganizationAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudentEducationOrganizationAssociation] ADD CONSTRAINT [AnonymizedStudentEducationOrganizationAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[AnonymizedStudentLanguage] --
CREATE TABLE [tpdm].[AnonymizedStudentLanguage] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AnonymizedStudentLanguage_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [FactsAsOfDate] ASC,
        [LanguageDescriptorId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentLanguage] ADD CONSTRAINT [AnonymizedStudentLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[AnonymizedStudentLanguageUse] --
CREATE TABLE [tpdm].[AnonymizedStudentLanguageUse] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AnonymizedStudentLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [FactsAsOfDate] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentLanguageUse] ADD CONSTRAINT [AnonymizedStudentLanguageUse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[AnonymizedStudentRace] --
CREATE TABLE [tpdm].[AnonymizedStudentRace] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [AnonymizedStudentRace_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [FactsAsOfDate] ASC,
        [RaceDescriptorId] ASC,
        [SchoolYear] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentRace] ADD CONSTRAINT [AnonymizedStudentRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[AnonymizedStudentSectionAssociation] --
CREATE TABLE [tpdm].[AnonymizedStudentSectionAssociation] (
    [AnonymizedStudentIdentifier] [NVARCHAR](60) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [FactsAsOfDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [AnonymizedStudentSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [AnonymizedStudentIdentifier] ASC,
        [BeginDate] ASC,
        [FactsAsOfDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[AnonymizedStudentSectionAssociation] ADD CONSTRAINT [AnonymizedStudentSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[AnonymizedStudentSectionAssociation] ADD CONSTRAINT [AnonymizedStudentSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[AnonymizedStudentSectionAssociation] ADD CONSTRAINT [AnonymizedStudentSectionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[Applicant] --
CREATE TABLE [tpdm].[Applicant] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
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
    [LoginId] [NVARCHAR](60) NULL,
    [GenderDescriptorId] [INT] NULL,
    [EconomicDisadvantaged] [BIT] NULL,
    [FirstGenerationStudent] [BIT] NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Applicant_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[Applicant] ADD CONSTRAINT [Applicant_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[Applicant] ADD CONSTRAINT [Applicant_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[Applicant] ADD CONSTRAINT [Applicant_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[ApplicantAddress] --
CREATE TABLE [tpdm].[ApplicantAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
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
    CONSTRAINT [ApplicantAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [ApplicantIdentifier] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantAddress] ADD CONSTRAINT [ApplicantAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantAddressPeriod] --
CREATE TABLE [tpdm].[ApplicantAddressPeriod] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [ApplicantIdentifier] ASC,
        [BeginDate] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantAddressPeriod] ADD CONSTRAINT [ApplicantAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantAid] --
CREATE TABLE [tpdm].[ApplicantAid] (
    [AidTypeDescriptorId] [INT] NOT NULL,
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [AidConditionDescription] [NVARCHAR](1024) NULL,
    [AidAmount] [MONEY] NULL,
    [PellGrantRecipient] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantAid_PK] PRIMARY KEY CLUSTERED (
        [AidTypeDescriptorId] ASC,
        [ApplicantIdentifier] ASC,
        [BeginDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantAid] ADD CONSTRAINT [ApplicantAid_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantBackgroundCheck] --
CREATE TABLE [tpdm].[ApplicantBackgroundCheck] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [BackgroundCheckTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantBackgroundCheck] ADD CONSTRAINT [ApplicantBackgroundCheck_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantCharacteristic] --
CREATE TABLE [tpdm].[ApplicantCharacteristic] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [StudentCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantCharacteristic] ADD CONSTRAINT [ApplicantCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantDisability] --
CREATE TABLE [tpdm].[ApplicantDisability] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantDisability_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [DisabilityDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantDisability] ADD CONSTRAINT [ApplicantDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantDisabilityDesignation] --
CREATE TABLE [tpdm].[ApplicantDisabilityDesignation] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantDisabilityDesignation] ADD CONSTRAINT [ApplicantDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantElectronicMail] --
CREATE TABLE [tpdm].[ApplicantElectronicMail] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantElectronicMail] ADD CONSTRAINT [ApplicantElectronicMail_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantIdentificationDocument] --
CREATE TABLE [tpdm].[ApplicantIdentificationDocument] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantIdentificationDocument] ADD CONSTRAINT [ApplicantIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantInternationalAddress] --
CREATE TABLE [tpdm].[ApplicantInternationalAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
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
    CONSTRAINT [ApplicantInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [ApplicantIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantInternationalAddress] ADD CONSTRAINT [ApplicantInternationalAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantLanguage] --
CREATE TABLE [tpdm].[ApplicantLanguage] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantLanguage_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [LanguageDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantLanguage] ADD CONSTRAINT [ApplicantLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantLanguageUse] --
CREATE TABLE [tpdm].[ApplicantLanguageUse] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantLanguageUse] ADD CONSTRAINT [ApplicantLanguageUse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantPersonalIdentificationDocument] --
CREATE TABLE [tpdm].[ApplicantPersonalIdentificationDocument] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantPersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantPersonalIdentificationDocument] ADD CONSTRAINT [ApplicantPersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantProspectAssociation] --
CREATE TABLE [tpdm].[ApplicantProspectAssociation] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [ApplicantProspectAssociation_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantProspectAssociation] ADD CONSTRAINT [ApplicantProspectAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[ApplicantProspectAssociation] ADD CONSTRAINT [ApplicantProspectAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[ApplicantProspectAssociation] ADD CONSTRAINT [ApplicantProspectAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[ApplicantRace] --
CREATE TABLE [tpdm].[ApplicantRace] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantRace_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantRace] ADD CONSTRAINT [ApplicantRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantStaffIdentificationCode] --
CREATE TABLE [tpdm].[ApplicantStaffIdentificationCode] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [StaffIdentificationSystemDescriptorId] [INT] NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantStaffIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [StaffIdentificationSystemDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantStaffIdentificationCode] ADD CONSTRAINT [ApplicantStaffIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantTelephone] --
CREATE TABLE [tpdm].[ApplicantTelephone] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantTelephone_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantTelephone] ADD CONSTRAINT [ApplicantTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicantVisa] --
CREATE TABLE [tpdm].[ApplicantVisa] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicantVisa_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicantVisa] ADD CONSTRAINT [ApplicantVisa_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[Application] --
CREATE TABLE [tpdm].[Application] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
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
    [HighestCompletedLevelOfEducationDescriptorId] [INT] NULL,
    [YearsOfPriorProfessionalExperience] [DECIMAL](5, 2) NULL,
    [YearsOfPriorTeachingExperience] [DECIMAL](5, 2) NULL,
    [HighlyQualifiedTeacher] [BIT] NULL,
    [HighlyQualifiedAcademicSubjectDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Application_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
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
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
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
        [ApplicantIdentifier] ASC,
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

-- Table [tpdm].[ApplicationGradePointAverage] --
CREATE TABLE [tpdm].[ApplicationGradePointAverage] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    [IsCumulative] [BIT] NULL,
    [GradePointAverageValue] [DECIMAL](18, 4) NOT NULL,
    [MaxGradePointAverageValue] [DECIMAL](18, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicationGradePointAverage_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [ApplicationIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [GradePointAverageTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicationGradePointAverage] ADD CONSTRAINT [ApplicationGradePointAverage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicationOpenStaffPosition] --
CREATE TABLE [tpdm].[ApplicationOpenStaffPosition] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicationOpenStaffPosition_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [ApplicationIdentifier] ASC,
        [EducationOrganizationId] ASC,
        [RequisitionNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ApplicationOpenStaffPosition] ADD CONSTRAINT [ApplicationOpenStaffPosition_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ApplicationScoreResult] --
CREATE TABLE [tpdm].[ApplicationScoreResult] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [AssessmentReportingMethodDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [Result] [NVARCHAR](35) NOT NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicationScoreResult_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
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
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [ApplicationIdentifier] [NVARCHAR](20) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ApplicationTerm_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
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

-- Table [tpdm].[CompleterAsStaffAssociation] --
CREATE TABLE [tpdm].[CompleterAsStaffAssociation] (
    [StaffUSI] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [CompleterAsStaffAssociation_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[CompleterAsStaffAssociation] ADD CONSTRAINT [CompleterAsStaffAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[CompleterAsStaffAssociation] ADD CONSTRAINT [CompleterAsStaffAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[CompleterAsStaffAssociation] ADD CONSTRAINT [CompleterAsStaffAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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

-- Table [tpdm].[EmploymentEvent] --
CREATE TABLE [tpdm].[EmploymentEvent] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EmploymentEventTypeDescriptorId] [INT] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [HireDate] [DATE] NULL,
    [EarlyHire] [BIT] NULL,
    [InternalExternalHireDescriptorId] [INT] NULL,
    [MutualConsent] [BIT] NULL,
    [RestrictedChoice] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EmploymentEvent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EmploymentEventTypeDescriptorId] ASC,
        [RequisitionNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EmploymentEvent] ADD CONSTRAINT [EmploymentEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[EmploymentEvent] ADD CONSTRAINT [EmploymentEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[EmploymentEvent] ADD CONSTRAINT [EmploymentEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EmploymentEventTypeDescriptor] --
CREATE TABLE [tpdm].[EmploymentEventTypeDescriptor] (
    [EmploymentEventTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EmploymentEventTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EmploymentEventTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[EmploymentSeparationEvent] --
CREATE TABLE [tpdm].[EmploymentSeparationEvent] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EmploymentSeparationDate] [DATE] NOT NULL,
    [RequisitionNumber] [NVARCHAR](20) NOT NULL,
    [EmploymentSeparationTypeDescriptorId] [INT] NOT NULL,
    [EmploymentSeparationEnteredDate] [DATE] NULL,
    [EmploymentSeparationReasonDescriptorId] [INT] NULL,
    [RemainingInDistrict] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [EmploymentSeparationEvent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EmploymentSeparationDate] ASC,
        [RequisitionNumber] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[EmploymentSeparationEvent] ADD CONSTRAINT [EmploymentSeparationEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[EmploymentSeparationEvent] ADD CONSTRAINT [EmploymentSeparationEvent_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[EmploymentSeparationEvent] ADD CONSTRAINT [EmploymentSeparationEvent_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[EmploymentSeparationReasonDescriptor] --
CREATE TABLE [tpdm].[EmploymentSeparationReasonDescriptor] (
    [EmploymentSeparationReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EmploymentSeparationReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EmploymentSeparationReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[EmploymentSeparationTypeDescriptor] --
CREATE TABLE [tpdm].[EmploymentSeparationTypeDescriptor] (
    [EmploymentSeparationTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [EmploymentSeparationTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [EmploymentSeparationTypeDescriptorId] ASC
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

-- Table [tpdm].[FieldworkExperienceSchool] --
CREATE TABLE [tpdm].[FieldworkExperienceSchool] (
    [BeginDate] [DATE] NOT NULL,
    [FieldworkIdentifier] [NVARCHAR](64) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [FieldworkExperienceSchool_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [FieldworkIdentifier] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[FieldworkExperienceSchool] ADD CONSTRAINT [FieldworkExperienceSchool_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [tpdm].[InternalExternalHireDescriptor] --
CREATE TABLE [tpdm].[InternalExternalHireDescriptor] (
    [InternalExternalHireDescriptorId] [INT] NOT NULL,
    CONSTRAINT [InternalExternalHireDescriptor_PK] PRIMARY KEY CLUSTERED (
        [InternalExternalHireDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[LevelOfDegreeAwardedDescriptor] --
CREATE TABLE [tpdm].[LevelOfDegreeAwardedDescriptor] (
    [LevelOfDegreeAwardedDescriptorId] [INT] NOT NULL,
    CONSTRAINT [LevelOfDegreeAwardedDescriptor_PK] PRIMARY KEY CLUSTERED (
        [LevelOfDegreeAwardedDescriptorId] ASC
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
    [FullTimeEquivalency] [DECIMAL](3, 2) NULL,
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

-- Table [tpdm].[Prospect] --
CREATE TABLE [tpdm].[Prospect] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [MaidenName] [NVARCHAR](75) NULL,
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [Applied] [BIT] NULL,
    [HispanicLatinoEthnicity] [BIT] NULL,
    [Met] [BIT] NULL,
    [Notes] [NVARCHAR](255) NULL,
    [PreScreeningRating] [INT] NULL,
    [Referral] [BIT] NULL,
    [ReferredBy] [NVARCHAR](50) NULL,
    [SexDescriptorId] [INT] NULL,
    [SocialMediaUserName] [NVARCHAR](50) NULL,
    [SocialMediaNetworkName] [NVARCHAR](50) NULL,
    [GenderDescriptorId] [INT] NULL,
    [EconomicDisadvantaged] [BIT] NULL,
    [FirstGenerationStudent] [BIT] NULL,
    [ProspectTypeDescriptorId] [INT] NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Prospect_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[Prospect] ADD CONSTRAINT [Prospect_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[Prospect] ADD CONSTRAINT [Prospect_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[Prospect] ADD CONSTRAINT [Prospect_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[ProspectAid] --
CREATE TABLE [tpdm].[ProspectAid] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [AidConditionDescription] [NVARCHAR](1024) NULL,
    [AidTypeDescriptorId] [INT] NOT NULL,
    [AidAmount] [MONEY] NULL,
    [PellGrantRecipient] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectAid_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectAid] ADD CONSTRAINT [ProspectAid_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectCurrentPosition] --
CREATE TABLE [tpdm].[ProspectCurrentPosition] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [Location] [NVARCHAR](75) NOT NULL,
    [PositionTitle] [NVARCHAR](100) NOT NULL,
    [AcademicSubjectDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectCurrentPosition_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectCurrentPosition] ADD CONSTRAINT [ProspectCurrentPosition_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectCurrentPositionGradeLevel] --
CREATE TABLE [tpdm].[ProspectCurrentPositionGradeLevel] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectCurrentPositionGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradeLevelDescriptorId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectCurrentPositionGradeLevel] ADD CONSTRAINT [ProspectCurrentPositionGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectDisability] --
CREATE TABLE [tpdm].[ProspectDisability] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectDisability_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectDisability] ADD CONSTRAINT [ProspectDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectDisabilityDesignation] --
CREATE TABLE [tpdm].[ProspectDisabilityDesignation] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectDisabilityDesignation] ADD CONSTRAINT [ProspectDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectPersonalIdentificationDocument] --
CREATE TABLE [tpdm].[ProspectPersonalIdentificationDocument] (
    [EducationOrganizationId] [INT] NOT NULL,
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectPersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectPersonalIdentificationDocument] ADD CONSTRAINT [ProspectPersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectQualifications] --
CREATE TABLE [tpdm].[ProspectQualifications] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [Eligible] [BIT] NOT NULL,
    [CapacityToServe] [BIT] NULL,
    [YearsOfServiceCurrentPlacement] [DECIMAL](5, 2) NULL,
    [YearsOfServiceTotal] [DECIMAL](5, 2) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectQualifications_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectQualifications] ADD CONSTRAINT [ProspectQualifications_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectRace] --
CREATE TABLE [tpdm].[ProspectRace] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [RaceDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectRace_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC,
        [RaceDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectRace] ADD CONSTRAINT [ProspectRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectRecruitmentEvent] --
CREATE TABLE [tpdm].[ProspectRecruitmentEvent] (
    [EducationOrganizationId] [INT] NOT NULL,
    [EventDate] [DATE] NOT NULL,
    [EventTitle] [NVARCHAR](50) NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectRecruitmentEvent_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [EventDate] ASC,
        [EventTitle] ASC,
        [ProspectIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectRecruitmentEvent] ADD CONSTRAINT [ProspectRecruitmentEvent_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectTelephone] --
CREATE TABLE [tpdm].[ProspectTelephone] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectTelephone_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectTelephone] ADD CONSTRAINT [ProspectTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectTouchpoint] --
CREATE TABLE [tpdm].[ProspectTouchpoint] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [TouchpointContent] [NVARCHAR](255) NOT NULL,
    [TouchpointDate] [DATE] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [ProspectTouchpoint_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC,
        [TouchpointContent] ASC,
        [TouchpointDate] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[ProspectTouchpoint] ADD CONSTRAINT [ProspectTouchpoint_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[ProspectTypeDescriptor] --
CREATE TABLE [tpdm].[ProspectTypeDescriptor] (
    [ProspectTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ProspectTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ProspectTypeDescriptorId] ASC
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

-- Table [tpdm].[StaffApplicantAssociation] --
CREATE TABLE [tpdm].[StaffApplicantAssociation] (
    [ApplicantIdentifier] [NVARCHAR](32) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffApplicantAssociation_PK] PRIMARY KEY CLUSTERED (
        [ApplicantIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffApplicantAssociation] ADD CONSTRAINT [StaffApplicantAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[StaffApplicantAssociation] ADD CONSTRAINT [StaffApplicantAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[StaffApplicantAssociation] ADD CONSTRAINT [StaffApplicantAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[StaffBackgroundCheck] --
CREATE TABLE [tpdm].[StaffBackgroundCheck] (
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [BackgroundCheckTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffBackgroundCheck] ADD CONSTRAINT [StaffBackgroundCheck_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
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

-- Table [tpdm].[StaffExtension] --
CREATE TABLE [tpdm].[StaffExtension] (
    [StaffUSI] [INT] NOT NULL,
    [ProbationCompleteDate] [DATE] NULL,
    [Tenured] [BIT] NULL,
    [GenderDescriptorId] [INT] NULL,
    [TenureTrack] [BIT] NULL,
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

-- Table [tpdm].[StaffProspectAssociation] --
CREATE TABLE [tpdm].[StaffProspectAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProspectIdentifier] [NVARCHAR](32) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffProspectAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProspectIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffProspectAssociation] ADD CONSTRAINT [StaffProspectAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[StaffProspectAssociation] ADD CONSTRAINT [StaffProspectAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[StaffProspectAssociation] ADD CONSTRAINT [StaffProspectAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[StaffSalary] --
CREATE TABLE [tpdm].[StaffSalary] (
    [StaffUSI] [INT] NOT NULL,
    [SalaryMinRange] [INT] NULL,
    [SalaryMaxRange] [INT] NULL,
    [SalaryTypeDescriptorId] [INT] NULL,
    [SalaryAmount] [MONEY] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffSalary_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffSalary] ADD CONSTRAINT [StaffSalary_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffSeniority] --
CREATE TABLE [tpdm].[StaffSeniority] (
    [CredentialFieldDescriptorId] [INT] NOT NULL,
    [NameOfInstitution] [NVARCHAR](75) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [YearsExperience] [DECIMAL](5, 2) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffSeniority_PK] PRIMARY KEY CLUSTERED (
        [CredentialFieldDescriptorId] ASC,
        [NameOfInstitution] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffSeniority] ADD CONSTRAINT [StaffSeniority_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffStudentGrowthMeasure] --
CREATE TABLE [tpdm].[StaffStudentGrowthMeasure] (
    [FactAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StaffStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [StudentGrowthMeasureDate] [DATE] NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [StudentGrowthTypeDescriptorId] [INT] NULL,
    [StudentGrowthTargetScore] [INT] NULL,
    [StudentGrowthActualScore] [INT] NOT NULL,
    [StudentGrowthMet] [BIT] NOT NULL,
    [StudentGrowthNCount] [INT] NULL,
    [StandardError] [DECIMAL](5, 4) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffStudentGrowthMeasure_PK] PRIMARY KEY CLUSTERED (
        [FactAsOfDate] ASC,
        [SchoolYear] ASC,
        [StaffStudentGrowthMeasureIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasure] ADD CONSTRAINT [StaffStudentGrowthMeasure_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasure] ADD CONSTRAINT [StaffStudentGrowthMeasure_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasure] ADD CONSTRAINT [StaffStudentGrowthMeasure_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[StaffStudentGrowthMeasureAcademicSubject] --
CREATE TABLE [tpdm].[StaffStudentGrowthMeasureAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [FactAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StaffStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffStudentGrowthMeasureAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [FactAsOfDate] ASC,
        [SchoolYear] ASC,
        [StaffStudentGrowthMeasureIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureAcademicSubject] ADD CONSTRAINT [StaffStudentGrowthMeasureAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffStudentGrowthMeasureCourseAssociation] --
CREATE TABLE [tpdm].[StaffStudentGrowthMeasureCourseAssociation] (
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [FactAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StaffStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffStudentGrowthMeasureCourseAssociation_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [FactAsOfDate] ASC,
        [SchoolYear] ASC,
        [StaffStudentGrowthMeasureIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureCourseAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureCourseAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureCourseAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureCourseAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureCourseAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureCourseAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] --
CREATE TABLE [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [FactAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StaffStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffStudentGrowthMeasureEducationOrganizationAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [FactAsOfDate] ASC,
        [SchoolYear] ASC,
        [StaffStudentGrowthMeasureIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureEducationOrganizationAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureEducationOrganizationAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureEducationOrganizationAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[StaffStudentGrowthMeasureGradeLevel] --
CREATE TABLE [tpdm].[StaffStudentGrowthMeasureGradeLevel] (
    [FactAsOfDate] [DATE] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [StaffStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffStudentGrowthMeasureGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [FactAsOfDate] ASC,
        [GradeLevelDescriptorId] ASC,
        [SchoolYear] ASC,
        [StaffStudentGrowthMeasureIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureGradeLevel] ADD CONSTRAINT [StaffStudentGrowthMeasureGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffStudentGrowthMeasureSectionAssociation] --
CREATE TABLE [tpdm].[StaffStudentGrowthMeasureSectionAssociation] (
    [FactAsOfDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [StaffStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffStudentGrowthMeasureSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [FactAsOfDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [StaffStudentGrowthMeasureIdentifier] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureSectionAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureSectionAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[StaffStudentGrowthMeasureSectionAssociation] ADD CONSTRAINT [StaffStudentGrowthMeasureSectionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[StaffTeacherEducatorResearch] --
CREATE TABLE [tpdm].[StaffTeacherEducatorResearch] (
    [StaffUSI] [INT] NOT NULL,
    [ResearchExperienceDate] [DATE] NOT NULL,
    [ResearchExperienceTitle] [NVARCHAR](60) NULL,
    [ResearchExperienceDescription] [NVARCHAR](1024) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StaffTeacherEducatorResearch_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffTeacherEducatorResearch] ADD CONSTRAINT [StaffTeacherEducatorResearch_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[StaffTeacherPreparationProviderProgramAssociation] --
CREATE TABLE [tpdm].[StaffTeacherPreparationProviderProgramAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StaffUSI] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [StudentRecordAccess] [BIT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StaffTeacherPreparationProviderProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StaffUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[StaffTeacherPreparationProviderProgramAssociation] ADD CONSTRAINT [StaffTeacherPreparationProviderProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[StaffTeacherPreparationProviderProgramAssociation] ADD CONSTRAINT [StaffTeacherPreparationProviderProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[StaffTeacherPreparationProviderProgramAssociation] ADD CONSTRAINT [StaffTeacherPreparationProviderProgramAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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

-- Table [tpdm].[StudentGrowthTypeDescriptor] --
CREATE TABLE [tpdm].[StudentGrowthTypeDescriptor] (
    [StudentGrowthTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StudentGrowthTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [StudentGrowthTypeDescriptorId] ASC
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

-- Table [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] --
CREATE TABLE [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveyResponseTeacherCandidateTargetAssociation_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] ADD CONSTRAINT [SurveyResponseTeacherCandidateTargetAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] ADD CONSTRAINT [SurveyResponseTeacherCandidateTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] ADD CONSTRAINT [SurveyResponseTeacherCandidateTargetAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
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

-- Table [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] --
CREATE TABLE [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] (
    [Namespace] [NVARCHAR](255) NOT NULL,
    [SurveyIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveyResponseIdentifier] [NVARCHAR](60) NOT NULL,
    [SurveySectionTitle] [NVARCHAR](255) NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [SurveySectionResponseTeacherCandidateTargetAssociation_PK] PRIMARY KEY CLUSTERED (
        [Namespace] ASC,
        [SurveyIdentifier] ASC,
        [SurveyResponseIdentifier] ASC,
        [SurveySectionTitle] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] ADD CONSTRAINT [SurveySectionResponseTeacherCandidateTargetAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] ADD CONSTRAINT [SurveySectionResponseTeacherCandidateTargetAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] ADD CONSTRAINT [SurveySectionResponseTeacherCandidateTargetAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidate] --
CREATE TABLE [tpdm].[TeacherCandidate] (
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
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
    [StudentUSI] [INT] NOT NULL,
    [PersonId] [NVARCHAR](32) NULL,
    [SourceSystemDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidate_PK] PRIMARY KEY CLUSTERED (
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidate] ADD CONSTRAINT [TeacherCandidate_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidate] ADD CONSTRAINT [TeacherCandidate_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidate] ADD CONSTRAINT [TeacherCandidate_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateAcademicRecord] --
CREATE TABLE [tpdm].[TeacherCandidateAcademicRecord] (
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
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
    [ContentGradePointAverage] [DECIMAL](18, 4) NULL,
    [ContentGradePointEarned] [DECIMAL](18, 4) NULL,
    [ProgramGatewayDescriptorId] [INT] NOT NULL,
    [TPPDegreeTypeDescriptorId] [INT] NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidateAcademicRecord_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] ADD CONSTRAINT [TeacherCandidateAcademicRecord_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] ADD CONSTRAINT [TeacherCandidateAcademicRecord_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] ADD CONSTRAINT [TeacherCandidateAcademicRecord_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] --
CREATE TABLE [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] (
    [AcademicHonorCategoryDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [HonorDescription] [NVARCHAR](80) NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
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
    CONSTRAINT [TeacherCandidateAcademicRecordAcademicHonor_PK] PRIMARY KEY CLUSTERED (
        [AcademicHonorCategoryDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [HonorDescription] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] ADD CONSTRAINT [TeacherCandidateAcademicRecordAcademicHonor_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateAcademicRecordClassRanking] --
CREATE TABLE [tpdm].[TeacherCandidateAcademicRecordClassRanking] (
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [ClassRank] [INT] NOT NULL,
    [TotalNumberInClass] [INT] NOT NULL,
    [PercentageRanking] [INT] NULL,
    [ClassRankingDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateAcademicRecordClassRanking_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordClassRanking] ADD CONSTRAINT [TeacherCandidateAcademicRecordClassRanking_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateAcademicRecordDiploma] --
CREATE TABLE [tpdm].[TeacherCandidateAcademicRecordDiploma] (
    [DiplomaAwardDate] [DATE] NOT NULL,
    [DiplomaTypeDescriptorId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
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
    CONSTRAINT [TeacherCandidateAcademicRecordDiploma_PK] PRIMARY KEY CLUSTERED (
        [DiplomaAwardDate] ASC,
        [DiplomaTypeDescriptorId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordDiploma] ADD CONSTRAINT [TeacherCandidateAcademicRecordDiploma_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] --
CREATE TABLE [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] (
    [EducationOrganizationId] [INT] NOT NULL,
    [GradePointAverageTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [IsCumulative] [BIT] NULL,
    [GradePointAverageValue] [DECIMAL](18, 4) NOT NULL,
    [MaxGradePointAverageValue] [DECIMAL](18, 4) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateAcademicRecordGradePointAverage_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [GradePointAverageTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] ADD CONSTRAINT [TeacherCandidateAcademicRecordGradePointAverage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateAcademicRecordRecognition] --
CREATE TABLE [tpdm].[TeacherCandidateAcademicRecordRecognition] (
    [EducationOrganizationId] [INT] NOT NULL,
    [RecognitionTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
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
    CONSTRAINT [TeacherCandidateAcademicRecordRecognition_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [RecognitionTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordRecognition] ADD CONSTRAINT [TeacherCandidateAcademicRecordRecognition_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateAddress] --
CREATE TABLE [tpdm].[TeacherCandidateAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
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
    CONSTRAINT [TeacherCandidateAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAddress] ADD CONSTRAINT [TeacherCandidateAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateAddressPeriod] --
CREATE TABLE [tpdm].[TeacherCandidateAddressPeriod] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [City] [NVARCHAR](30) NOT NULL,
    [PostalCode] [NVARCHAR](17) NOT NULL,
    [StateAbbreviationDescriptorId] [INT] NOT NULL,
    [StreetNumberName] [NVARCHAR](150) NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateAddressPeriod_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [City] ASC,
        [PostalCode] ASC,
        [StateAbbreviationDescriptorId] ASC,
        [StreetNumberName] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAddressPeriod] ADD CONSTRAINT [TeacherCandidateAddressPeriod_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateAid] --
CREATE TABLE [tpdm].[TeacherCandidateAid] (
    [AidTypeDescriptorId] [INT] NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EndDate] [DATE] NULL,
    [AidConditionDescription] [NVARCHAR](1024) NULL,
    [AidAmount] [MONEY] NULL,
    [PellGrantRecipient] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateAid_PK] PRIMARY KEY CLUSTERED (
        [AidTypeDescriptorId] ASC,
        [BeginDate] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateAid] ADD CONSTRAINT [TeacherCandidateAid_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateBackgroundCheck] --
CREATE TABLE [tpdm].[TeacherCandidateBackgroundCheck] (
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [BackgroundCheckTypeDescriptorId] [INT] NOT NULL,
    [BackgroundCheckRequestedDate] [DATE] NOT NULL,
    [BackgroundCheckStatusDescriptorId] [INT] NULL,
    [BackgroundCheckCompletedDate] [DATE] NULL,
    [Fingerprint] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateBackgroundCheck_PK] PRIMARY KEY CLUSTERED (
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateBackgroundCheck] ADD CONSTRAINT [TeacherCandidateBackgroundCheck_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateCharacteristic] --
CREATE TABLE [tpdm].[TeacherCandidateCharacteristic] (
    [StudentCharacteristicDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateCharacteristic_PK] PRIMARY KEY CLUSTERED (
        [StudentCharacteristicDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateCharacteristic] ADD CONSTRAINT [TeacherCandidateCharacteristic_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateCharacteristicDescriptor] --
CREATE TABLE [tpdm].[TeacherCandidateCharacteristicDescriptor] (
    [TeacherCandidateCharacteristicDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TeacherCandidateCharacteristicDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TeacherCandidateCharacteristicDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[TeacherCandidateCohortYear] --
CREATE TABLE [tpdm].[TeacherCandidateCohortYear] (
    [CohortYearTypeDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateCohortYear_PK] PRIMARY KEY CLUSTERED (
        [CohortYearTypeDescriptorId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateCohortYear] ADD CONSTRAINT [TeacherCandidateCohortYear_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateCourseTranscript] --
CREATE TABLE [tpdm].[TeacherCandidateCourseTranscript] (
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [AttemptedCredits] [DECIMAL](9, 3) NULL,
    [AttemptedCreditTypeDescriptorId] [INT] NULL,
    [AttemptedCreditConversion] [DECIMAL](9, 2) NULL,
    [EarnedCredits] [DECIMAL](9, 3) NOT NULL,
    [EarnedCreditTypeDescriptorId] [INT] NULL,
    [EarnedCreditConversion] [DECIMAL](9, 2) NULL,
    [WhenTakenGradeLevelDescriptorId] [INT] NULL,
    [MethodCreditEarnedDescriptorId] [INT] NULL,
    [FinalLetterGradeEarned] [NVARCHAR](20) NULL,
    [FinalNumericGradeEarned] [DECIMAL](9, 2) NULL,
    [CourseRepeatCodeDescriptorId] [INT] NULL,
    [SchoolId] [INT] NULL,
    [CourseTitle] [NVARCHAR](60) NULL,
    [AlternativeCourseTitle] [NVARCHAR](60) NULL,
    [AlternativeCourseCode] [NVARCHAR](60) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidateCourseTranscript_PK] PRIMARY KEY CLUSTERED (
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] ADD CONSTRAINT [TeacherCandidateCourseTranscript_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] ADD CONSTRAINT [TeacherCandidateCourseTranscript_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] ADD CONSTRAINT [TeacherCandidateCourseTranscript_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] --
CREATE TABLE [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] (
    [AdditionalCreditTypeDescriptorId] [INT] NOT NULL,
    [CourseAttemptResultDescriptorId] [INT] NOT NULL,
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [CourseEducationOrganizationId] [INT] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TermDescriptorId] [INT] NOT NULL,
    [Credits] [DECIMAL](9, 3) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateCourseTranscriptEarnedAdditionalCredits_PK] PRIMARY KEY CLUSTERED (
        [AdditionalCreditTypeDescriptorId] ASC,
        [CourseAttemptResultDescriptorId] ASC,
        [CourseCode] ASC,
        [CourseEducationOrganizationId] ASC,
        [EducationOrganizationId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TermDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] ADD CONSTRAINT [TeacherCandidateCourseTranscriptEarnedAdditionalCredits_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateDegreeSpecialization] --
CREATE TABLE [tpdm].[TeacherCandidateDegreeSpecialization] (
    [BeginDate] [DATE] NOT NULL,
    [MajorSpecialization] [NVARCHAR](75) NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [MinorSpecialization] [NVARCHAR](75) NULL,
    [EndDate] [DATE] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateDegreeSpecialization_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [MajorSpecialization] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateDegreeSpecialization] ADD CONSTRAINT [TeacherCandidateDegreeSpecialization_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateDisability] --
CREATE TABLE [tpdm].[TeacherCandidateDisability] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [DisabilityDiagnosis] [NVARCHAR](80) NULL,
    [OrderOfDisability] [INT] NULL,
    [DisabilityDeterminationSourceTypeDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateDisability_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateDisability] ADD CONSTRAINT [TeacherCandidateDisability_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateDisabilityDesignation] --
CREATE TABLE [tpdm].[TeacherCandidateDisabilityDesignation] (
    [DisabilityDescriptorId] [INT] NOT NULL,
    [DisabilityDesignationDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateDisabilityDesignation_PK] PRIMARY KEY CLUSTERED (
        [DisabilityDescriptorId] ASC,
        [DisabilityDesignationDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateDisabilityDesignation] ADD CONSTRAINT [TeacherCandidateDisabilityDesignation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateElectronicMail] --
CREATE TABLE [tpdm].[TeacherCandidateElectronicMail] (
    [ElectronicMailAddress] [NVARCHAR](128) NOT NULL,
    [ElectronicMailTypeDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [PrimaryEmailAddressIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateElectronicMail_PK] PRIMARY KEY CLUSTERED (
        [ElectronicMailAddress] ASC,
        [ElectronicMailTypeDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateElectronicMail] ADD CONSTRAINT [TeacherCandidateElectronicMail_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateIdentificationCode] --
CREATE TABLE [tpdm].[TeacherCandidateIdentificationCode] (
    [AssigningOrganizationIdentificationCode] [NVARCHAR](60) NOT NULL,
    [StudentIdentificationSystemDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IdentificationCode] [NVARCHAR](60) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateIdentificationCode_PK] PRIMARY KEY CLUSTERED (
        [AssigningOrganizationIdentificationCode] ASC,
        [StudentIdentificationSystemDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateIdentificationCode] ADD CONSTRAINT [TeacherCandidateIdentificationCode_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateIdentificationDocument] --
CREATE TABLE [tpdm].[TeacherCandidateIdentificationDocument] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateIdentificationDocument] ADD CONSTRAINT [TeacherCandidateIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateIndicator] --
CREATE TABLE [tpdm].[TeacherCandidateIndicator] (
    [IndicatorName] [NVARCHAR](200) NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [IndicatorGroup] [NVARCHAR](200) NULL,
    [Indicator] [NVARCHAR](35) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [DesignatedBy] [NVARCHAR](60) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateIndicator_PK] PRIMARY KEY CLUSTERED (
        [IndicatorName] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateIndicator] ADD CONSTRAINT [TeacherCandidateIndicator_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateInternationalAddress] --
CREATE TABLE [tpdm].[TeacherCandidateInternationalAddress] (
    [AddressTypeDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
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
    CONSTRAINT [TeacherCandidateInternationalAddress_PK] PRIMARY KEY CLUSTERED (
        [AddressTypeDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateInternationalAddress] ADD CONSTRAINT [TeacherCandidateInternationalAddress_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateLanguage] --
CREATE TABLE [tpdm].[TeacherCandidateLanguage] (
    [LanguageDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateLanguage_PK] PRIMARY KEY CLUSTERED (
        [LanguageDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateLanguage] ADD CONSTRAINT [TeacherCandidateLanguage_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateLanguageUse] --
CREATE TABLE [tpdm].[TeacherCandidateLanguageUse] (
    [LanguageDescriptorId] [INT] NOT NULL,
    [LanguageUseDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateLanguageUse_PK] PRIMARY KEY CLUSTERED (
        [LanguageDescriptorId] ASC,
        [LanguageUseDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateLanguageUse] ADD CONSTRAINT [TeacherCandidateLanguageUse_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateOtherName] --
CREATE TABLE [tpdm].[TeacherCandidateOtherName] (
    [OtherNameTypeDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [PersonalTitlePrefix] [NVARCHAR](30) NULL,
    [FirstName] [NVARCHAR](75) NOT NULL,
    [MiddleName] [NVARCHAR](75) NULL,
    [LastSurname] [NVARCHAR](75) NOT NULL,
    [GenerationCodeSuffix] [NVARCHAR](10) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateOtherName_PK] PRIMARY KEY CLUSTERED (
        [OtherNameTypeDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateOtherName] ADD CONSTRAINT [TeacherCandidateOtherName_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidatePersonalIdentificationDocument] --
CREATE TABLE [tpdm].[TeacherCandidatePersonalIdentificationDocument] (
    [IdentificationDocumentUseDescriptorId] [INT] NOT NULL,
    [PersonalInformationVerificationDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [DocumentTitle] [NVARCHAR](60) NULL,
    [DocumentExpirationDate] [DATE] NULL,
    [IssuerDocumentIdentificationCode] [NVARCHAR](60) NULL,
    [IssuerName] [NVARCHAR](150) NULL,
    [IssuerCountryDescriptorId] [INT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidatePersonalIdentificationDocument_PK] PRIMARY KEY CLUSTERED (
        [IdentificationDocumentUseDescriptorId] ASC,
        [PersonalInformationVerificationDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidatePersonalIdentificationDocument] ADD CONSTRAINT [TeacherCandidatePersonalIdentificationDocument_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateRace] --
CREATE TABLE [tpdm].[TeacherCandidateRace] (
    [RaceDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateRace_PK] PRIMARY KEY CLUSTERED (
        [RaceDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateRace] ADD CONSTRAINT [TeacherCandidateRace_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateStaffAssociation] --
CREATE TABLE [tpdm].[TeacherCandidateStaffAssociation] (
    [StaffUSI] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [BeginDate] [DATE] NOT NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidateStaffAssociation_PK] PRIMARY KEY CLUSTERED (
        [StaffUSI] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateStaffAssociation] ADD CONSTRAINT [TeacherCandidateStaffAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidateStaffAssociation] ADD CONSTRAINT [TeacherCandidateStaffAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidateStaffAssociation] ADD CONSTRAINT [TeacherCandidateStaffAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateStudentGrowthMeasure] --
CREATE TABLE [tpdm].[TeacherCandidateStudentGrowthMeasure] (
    [FactAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TeacherCandidateStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [StudentGrowthMeasureDate] [DATE] NULL,
    [ResultDatatypeTypeDescriptorId] [INT] NULL,
    [StudentGrowthTypeDescriptorId] [INT] NULL,
    [StudentGrowthTargetScore] [INT] NULL,
    [StudentGrowthActualScore] [INT] NOT NULL,
    [StudentGrowthMet] [BIT] NOT NULL,
    [StudentGrowthNCount] [INT] NULL,
    [StandardError] [DECIMAL](5, 4) NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidateStudentGrowthMeasure_PK] PRIMARY KEY CLUSTERED (
        [FactAsOfDate] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TeacherCandidateStudentGrowthMeasureIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasure] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasure_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasure] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasure_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasure] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasure_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] --
CREATE TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [FactAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TeacherCandidateStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateStudentGrowthMeasureAcademicSubject_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [FactAsOfDate] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TeacherCandidateStudentGrowthMeasureIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureAcademicSubject_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] --
CREATE TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] (
    [CourseCode] [NVARCHAR](60) NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [FactAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TeacherCandidateStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidateStudentGrowthMeasureCourseAssociation_PK] PRIMARY KEY CLUSTERED (
        [CourseCode] ASC,
        [EducationOrganizationId] ASC,
        [FactAsOfDate] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TeacherCandidateStudentGrowthMeasureIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureCourseAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureCourseAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureCourseAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] --
CREATE TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] (
    [EducationOrganizationId] [INT] NOT NULL,
    [FactAsOfDate] [DATE] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TeacherCandidateStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_PK] PRIMARY KEY CLUSTERED (
        [EducationOrganizationId] ASC,
        [FactAsOfDate] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TeacherCandidateStudentGrowthMeasureIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] --
CREATE TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] (
    [FactAsOfDate] [DATE] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TeacherCandidateStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateStudentGrowthMeasureGradeLevel_PK] PRIMARY KEY CLUSTERED (
        [FactAsOfDate] ASC,
        [GradeLevelDescriptorId] ASC,
        [SchoolYear] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TeacherCandidateStudentGrowthMeasureIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureGradeLevel_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] --
CREATE TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] (
    [FactAsOfDate] [DATE] NOT NULL,
    [LocalCourseCode] [NVARCHAR](60) NOT NULL,
    [SchoolId] [INT] NOT NULL,
    [SchoolYear] [SMALLINT] NOT NULL,
    [SectionIdentifier] [NVARCHAR](255) NOT NULL,
    [SessionName] [NVARCHAR](60) NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TeacherCandidateStudentGrowthMeasureIdentifier] [NVARCHAR](64) NOT NULL,
    [BeginDate] [DATE] NULL,
    [EndDate] [DATE] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidateStudentGrowthMeasureSectionAssociation_PK] PRIMARY KEY CLUSTERED (
        [FactAsOfDate] ASC,
        [LocalCourseCode] ASC,
        [SchoolId] ASC,
        [SchoolYear] ASC,
        [SectionIdentifier] ASC,
        [SessionName] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TeacherCandidateStudentGrowthMeasureIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureSectionAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureSectionAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] ADD CONSTRAINT [TeacherCandidateStudentGrowthMeasureSectionAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] --
CREATE TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [INT] NOT NULL,
    [ProgramName] [NVARCHAR](255) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [EndDate] [DATE] NULL,
    [ReasonExitedDescriptorId] [INT] NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [TeacherCandidateTeacherPreparationProviderProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] ADD CONSTRAINT [TeacherCandidateTeacherPreparationProviderProgramAssociation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] ADD CONSTRAINT [TeacherCandidateTeacherPreparationProviderProgramAssociation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] ADD CONSTRAINT [TeacherCandidateTeacherPreparationProviderProgramAssociation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO

-- Table [tpdm].[TeacherCandidateTelephone] --
CREATE TABLE [tpdm].[TeacherCandidateTelephone] (
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TelephoneNumber] [NVARCHAR](24) NOT NULL,
    [TelephoneNumberTypeDescriptorId] [INT] NOT NULL,
    [OrderOfPriority] [INT] NULL,
    [TextMessageCapabilityIndicator] [BIT] NULL,
    [DoNotPublishIndicator] [BIT] NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateTelephone_PK] PRIMARY KEY CLUSTERED (
        [TeacherCandidateIdentifier] ASC,
        [TelephoneNumber] ASC,
        [TelephoneNumberTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateTelephone] ADD CONSTRAINT [TeacherCandidateTelephone_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateTPPProgramDegree] --
CREATE TABLE [tpdm].[TeacherCandidateTPPProgramDegree] (
    [AcademicSubjectDescriptorId] [INT] NOT NULL,
    [GradeLevelDescriptorId] [INT] NOT NULL,
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [TPPDegreeTypeDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateTPPProgramDegree_PK] PRIMARY KEY CLUSTERED (
        [AcademicSubjectDescriptorId] ASC,
        [GradeLevelDescriptorId] ASC,
        [TeacherCandidateIdentifier] ASC,
        [TPPDegreeTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateTPPProgramDegree] ADD CONSTRAINT [TeacherCandidateTPPProgramDegree_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TeacherCandidateVisa] --
CREATE TABLE [tpdm].[TeacherCandidateVisa] (
    [TeacherCandidateIdentifier] [NVARCHAR](32) NOT NULL,
    [VisaDescriptorId] [INT] NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [TeacherCandidateVisa_PK] PRIMARY KEY CLUSTERED (
        [TeacherCandidateIdentifier] ASC,
        [VisaDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [tpdm].[TeacherCandidateVisa] ADD CONSTRAINT [TeacherCandidateVisa_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO

-- Table [tpdm].[TPPDegreeTypeDescriptor] --
CREATE TABLE [tpdm].[TPPDegreeTypeDescriptor] (
    [TPPDegreeTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TPPDegreeTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TPPDegreeTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[TPPProgramPathwayDescriptor] --
CREATE TABLE [tpdm].[TPPProgramPathwayDescriptor] (
    [TPPProgramPathwayDescriptorId] [INT] NOT NULL,
    CONSTRAINT [TPPProgramPathwayDescriptor_PK] PRIMARY KEY CLUSTERED (
        [TPPProgramPathwayDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[ValueTypeDescriptor] --
CREATE TABLE [tpdm].[ValueTypeDescriptor] (
    [ValueTypeDescriptorId] [INT] NOT NULL,
    CONSTRAINT [ValueTypeDescriptor_PK] PRIMARY KEY CLUSTERED (
        [ValueTypeDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [tpdm].[WithdrawReasonDescriptor] --
CREATE TABLE [tpdm].[WithdrawReasonDescriptor] (
    [WithdrawReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [WithdrawReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [WithdrawReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

