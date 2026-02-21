-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [samplealternativeeducationprogram].[AlternativeEducationEligibilityReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_AlternativeEducationEligibilityReasonDescriptor_Descriptor] FOREIGN KEY ([AlternativeEducationEligibilityReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAlternativeEducationProgramAssociation_AlternativeEducationEligibilityReasonDescriptor] FOREIGN KEY ([AlternativeEducationEligibilityReasonDescriptorId])
REFERENCES [samplealternativeeducationprogram].[AlternativeEducationEligibilityReasonDescriptor] ([AlternativeEducationEligibilityReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAlternativeEducationProgramAssociation_AlternativeEducationEligibilityReasonDescriptor]
ON [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociation] ([AlternativeEducationEligibilityReasonDescriptorId] ASC)
GO

ALTER TABLE [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAlternativeEducationProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociationMeetingTime] WITH CHECK ADD CONSTRAINT [FK_StudentAlternativeEducationProgramAssociationMeetingTime_StudentAlternativeEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [samplealternativeeducationprogram].[StudentAlternativeEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

