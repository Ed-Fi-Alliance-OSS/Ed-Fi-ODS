-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [samplealternativeeducationprogram].[AlternativeEducationEligibilityReasonDescriptor] --
COMMENT ON TABLE samplealternativeeducationprogram.AlternativeEducationEligibilityReasonDescriptor IS 'This descriptor describes the reason a student is eligible for an Alternative Education Program';
COMMENT ON COLUMN samplealternativeeducationprogram.AlternativeEducationEligibilityReasonDescriptor.AlternativeEducationEligibilityReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociation] --
COMMENT ON TABLE samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation IS 'This association represents Students in an Alternative Education Program.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation.AlternativeEducationEligibilityReasonDescriptorId IS 'The reason the student is eligible for the program.';

-- Extended Properties [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociationMeetingTime] --
COMMENT ON TABLE samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime IS 'The times at which this Alternative Education Program is scheduled to meet.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime.EndTime IS 'An indication of the time of day the meeting time ends.';
COMMENT ON COLUMN samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime.StartTime IS 'An indication of the time of day the meeting time begins.';

