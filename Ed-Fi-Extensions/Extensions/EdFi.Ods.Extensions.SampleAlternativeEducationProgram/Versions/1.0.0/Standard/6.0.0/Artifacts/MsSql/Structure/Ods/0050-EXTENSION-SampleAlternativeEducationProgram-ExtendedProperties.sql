-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [samplealternativeeducationprogram].[AlternativeEducationEligibilityReasonDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor describes the reason a student is eligible for an Alternative Education Program', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'AlternativeEducationEligibilityReasonDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'AlternativeEducationEligibilityReasonDescriptor', @level2type=N'COLUMN', @level2name=N'AlternativeEducationEligibilityReasonDescriptorId'
GO

-- Extended Properties [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This association represents Students in an Alternative Education Program.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reason the student is eligible for the program.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociation', @level2type=N'COLUMN', @level2name=N'AlternativeEducationEligibilityReasonDescriptorId'
GO

-- Extended Properties [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociationMeetingTime] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The times at which this Alternative Education Program is scheduled to meet.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of the time of day the meeting time ends.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime', @level2type=N'COLUMN', @level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of the time of day the meeting time begins.', @level0type=N'SCHEMA', @level0name=N'samplealternativeeducationprogram', @level1type=N'TABLE', @level1name=N'StudentAlternativeEducationProgramAssociationMeetingTime', @level2type=N'COLUMN', @level2name=N'StartTime'
GO

