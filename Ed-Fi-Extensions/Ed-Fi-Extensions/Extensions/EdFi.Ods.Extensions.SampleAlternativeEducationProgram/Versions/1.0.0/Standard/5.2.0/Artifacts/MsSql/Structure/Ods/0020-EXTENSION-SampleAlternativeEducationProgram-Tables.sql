-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table [samplealternativeeducationprogram].[AlternativeEducationEligibilityReasonDescriptor] --
CREATE TABLE [samplealternativeeducationprogram].[AlternativeEducationEligibilityReasonDescriptor] (
    [AlternativeEducationEligibilityReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [AlternativeEducationEligibilityReasonDescriptor_PK] PRIMARY KEY CLUSTERED (
        [AlternativeEducationEligibilityReasonDescriptorId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociation] --
CREATE TABLE [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociation] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [AlternativeEducationEligibilityReasonDescriptorId] [INT] NOT NULL,
    CONSTRAINT [StudentAlternativeEducationProgramAssociation_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Table [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociationMeetingTime] --
CREATE TABLE [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociationMeetingTime] (
    [BeginDate] [DATE] NOT NULL,
    [EducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramEducationOrganizationId] [BIGINT] NOT NULL,
    [ProgramName] [NVARCHAR](60) NOT NULL,
    [ProgramTypeDescriptorId] [INT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EndTime] [TIME](7) NOT NULL,
    [StartTime] [TIME](7) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    CONSTRAINT [StudentAlternativeEducationProgramAssociationMeetingTime_PK] PRIMARY KEY CLUSTERED (
        [BeginDate] ASC,
        [EducationOrganizationId] ASC,
        [ProgramEducationOrganizationId] ASC,
        [ProgramName] ASC,
        [ProgramTypeDescriptorId] ASC,
        [StudentUSI] ASC,
        [EndTime] ASC,
        [StartTime] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociationMeetingTime] ADD CONSTRAINT [StudentAlternativeEducationProgramAssociationMeetingTime_DF_CreateDate] DEFAULT (getutcdate()) FOR [CreateDate]
GO

