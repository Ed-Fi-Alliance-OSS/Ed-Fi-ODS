ALTER TABLE [samplestudenttranscript].[InstitutionControlDescriptor] WITH CHECK ADD CONSTRAINT [FK_InstitutionControlDescriptor_Descriptor] FOREIGN KEY ([InstitutionControlDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [samplestudenttranscript].[InstitutionLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_InstitutionLevelDescriptor_Descriptor] FOREIGN KEY ([InstitutionLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryOrganization_InstitutionControlDescriptor] FOREIGN KEY ([InstitutionControlDescriptorId])
REFERENCES [samplestudenttranscript].[InstitutionControlDescriptor] ([InstitutionControlDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PostSecondaryOrganization_InstitutionControlDescriptor]
ON [samplestudenttranscript].[PostSecondaryOrganization] ([InstitutionControlDescriptorId] ASC)
GO

ALTER TABLE [samplestudenttranscript].[PostSecondaryOrganization] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryOrganization_InstitutionLevelDescriptor] FOREIGN KEY ([InstitutionLevelDescriptorId])
REFERENCES [samplestudenttranscript].[InstitutionLevelDescriptor] ([InstitutionLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PostSecondaryOrganization_InstitutionLevelDescriptor]
ON [samplestudenttranscript].[PostSecondaryOrganization] ([InstitutionLevelDescriptorId] ASC)
GO

ALTER TABLE [samplestudenttranscript].[SpecialEducationGraduationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_SpecialEducationGraduationStatusDescriptor_Descriptor] FOREIGN KEY ([SpecialEducationGraduationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [samplestudenttranscript].[StudentAcademicRecordClassRankingExtension] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordClassRankingExtension_SpecialEducationGraduationStatusDescriptor] FOREIGN KEY ([SpecialEducationGraduationStatusDescriptorId])
REFERENCES [samplestudenttranscript].[SpecialEducationGraduationStatusDescriptor] ([SpecialEducationGraduationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordClassRankingExtension_SpecialEducationGraduationStatusDescriptor]
ON [samplestudenttranscript].[StudentAcademicRecordClassRankingExtension] ([SpecialEducationGraduationStatusDescriptorId] ASC)
GO

ALTER TABLE [samplestudenttranscript].[StudentAcademicRecordClassRankingExtension] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordClassRankingExtension_StudentAcademicRecordClassRanking] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecordClassRanking] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [samplestudenttranscript].[StudentAcademicRecordExtension] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordExtension_PostSecondaryOrganization] FOREIGN KEY ([NameOfInstitution])
REFERENCES [samplestudenttranscript].[PostSecondaryOrganization] ([NameOfInstitution])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordExtension_PostSecondaryOrganization]
ON [samplestudenttranscript].[StudentAcademicRecordExtension] ([NameOfInstitution] ASC)
GO

ALTER TABLE [samplestudenttranscript].[StudentAcademicRecordExtension] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordExtension_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [samplestudenttranscript].[StudentAcademicRecordExtension] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordExtension_SubmissionCertificationDescriptor] FOREIGN KEY ([SubmissionCertificationDescriptorId])
REFERENCES [samplestudenttranscript].[SubmissionCertificationDescriptor] ([SubmissionCertificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordExtension_SubmissionCertificationDescriptor]
ON [samplestudenttranscript].[StudentAcademicRecordExtension] ([SubmissionCertificationDescriptorId] ASC)
GO

ALTER TABLE [samplestudenttranscript].[SubmissionCertificationDescriptor] WITH CHECK ADD CONSTRAINT [FK_SubmissionCertificationDescriptor_Descriptor] FOREIGN KEY ([SubmissionCertificationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

