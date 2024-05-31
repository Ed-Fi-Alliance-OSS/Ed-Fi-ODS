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

