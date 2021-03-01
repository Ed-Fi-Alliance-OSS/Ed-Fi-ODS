ALTER TABLE [tpdm].[AccreditationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_AccreditationStatusDescriptor_Descriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[AidTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AidTypeDescriptor_Descriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[AnonymizedStudent] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudent_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudent_GenderDescriptor]
ON [tpdm].[AnonymizedStudent] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudent] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudent_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudent_GradeLevelDescriptor]
ON [tpdm].[AnonymizedStudent] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudent] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudent_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudent_SchoolYearType]
ON [tpdm].[AnonymizedStudent] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudent] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudent_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudent_SexDescriptor]
ON [tpdm].[AnonymizedStudent] ([SexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudent] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudent_ValueTypeDescriptor] FOREIGN KEY ([ValueTypeDescriptorId])
REFERENCES [tpdm].[ValueTypeDescriptor] ([ValueTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudent_ValueTypeDescriptor]
ON [tpdm].[AnonymizedStudent] ([ValueTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAcademicRecord_AnonymizedStudent] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudent] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAcademicRecord_AnonymizedStudent]
ON [tpdm].[AnonymizedStudentAcademicRecord] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAcademicRecord_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAcademicRecord_EducationOrganization]
ON [tpdm].[AnonymizedStudentAcademicRecord] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAcademicRecord_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAcademicRecord_SchoolYearType]
ON [tpdm].[AnonymizedStudentAcademicRecord] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAcademicRecord_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAcademicRecord_TermDescriptor]
ON [tpdm].[AnonymizedStudentAcademicRecord] ([TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessment] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessment_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessment_AcademicSubjectDescriptor]
ON [tpdm].[AnonymizedStudentAssessment] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessment] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessment_AnonymizedStudent] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudent] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessment_AnonymizedStudent]
ON [tpdm].[AnonymizedStudentAssessment] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessment] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessment_AssessmentCategoryDescriptor] FOREIGN KEY ([AssessmentCategoryDescriptorId])
REFERENCES [edfi].[AssessmentCategoryDescriptor] ([AssessmentCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessment_AssessmentCategoryDescriptor]
ON [tpdm].[AnonymizedStudentAssessment] ([AssessmentCategoryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessment] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessment_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessment_GradeLevelDescriptor]
ON [tpdm].[AnonymizedStudentAssessment] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessment] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessment_SchoolYearType] FOREIGN KEY ([TakenSchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessment_SchoolYearType]
ON [tpdm].[AnonymizedStudentAssessment] ([TakenSchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessment] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessment_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessment_TermDescriptor]
ON [tpdm].[AnonymizedStudentAssessment] ([TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentCourseAssociation_AnonymizedStudentAssessment] FOREIGN KEY ([AdministrationDate], [AnonymizedStudentIdentifier], [AssessmentIdentifier], [FactsAsOfDate], [SchoolYear], [TakenSchoolYear])
REFERENCES [tpdm].[AnonymizedStudentAssessment] ([AdministrationDate], [AnonymizedStudentIdentifier], [AssessmentIdentifier], [FactsAsOfDate], [SchoolYear], [TakenSchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessmentCourseAssociation_AnonymizedStudentAssessment]
ON [tpdm].[AnonymizedStudentAssessmentCourseAssociation] ([AdministrationDate] ASC, [AnonymizedStudentIdentifier] ASC, [AssessmentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC, [TakenSchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentCourseAssociation_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessmentCourseAssociation_Course]
ON [tpdm].[AnonymizedStudentAssessmentCourseAssociation] ([CourseCode] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentPerformanceLevel_AnonymizedStudentAssessment] FOREIGN KEY ([AdministrationDate], [AnonymizedStudentIdentifier], [AssessmentIdentifier], [FactsAsOfDate], [SchoolYear], [TakenSchoolYear])
REFERENCES [tpdm].[AnonymizedStudentAssessment] ([AdministrationDate], [AnonymizedStudentIdentifier], [AssessmentIdentifier], [FactsAsOfDate], [SchoolYear], [TakenSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor]
ON [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessmentPerformanceLevel_PerformanceLevelDescriptor]
ON [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] ([PerformanceLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentScoreResult_AnonymizedStudentAssessment] FOREIGN KEY ([AdministrationDate], [AnonymizedStudentIdentifier], [AssessmentIdentifier], [FactsAsOfDate], [SchoolYear], [TakenSchoolYear])
REFERENCES [tpdm].[AnonymizedStudentAssessment] ([AdministrationDate], [AnonymizedStudentIdentifier], [AssessmentIdentifier], [FactsAsOfDate], [SchoolYear], [TakenSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentScoreResult_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessmentScoreResult_AssessmentReportingMethodDescriptor]
ON [tpdm].[AnonymizedStudentAssessmentScoreResult] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentScoreResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessmentScoreResult_ResultDatatypeTypeDescriptor]
ON [tpdm].[AnonymizedStudentAssessmentScoreResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentSectionAssociation_AnonymizedStudentAssessment] FOREIGN KEY ([AdministrationDate], [AnonymizedStudentIdentifier], [AssessmentIdentifier], [FactsAsOfDate], [SchoolYear], [TakenSchoolYear])
REFERENCES [tpdm].[AnonymizedStudentAssessment] ([AdministrationDate], [AnonymizedStudentIdentifier], [AssessmentIdentifier], [FactsAsOfDate], [SchoolYear], [TakenSchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessmentSectionAssociation_AnonymizedStudentAssessment]
ON [tpdm].[AnonymizedStudentAssessmentSectionAssociation] ([AdministrationDate] ASC, [AnonymizedStudentIdentifier] ASC, [AssessmentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC, [TakenSchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentAssessmentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentAssessmentSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentAssessmentSectionAssociation_Section]
ON [tpdm].[AnonymizedStudentAssessmentSectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentCourseAssociation_AnonymizedStudent] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudent] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentCourseAssociation_AnonymizedStudent]
ON [tpdm].[AnonymizedStudentCourseAssociation] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentCourseAssociation_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentCourseAssociation_Course]
ON [tpdm].[AnonymizedStudentCourseAssociation] ([CourseCode] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentCourseTranscript_AnonymizedStudentAcademicRecord] FOREIGN KEY ([AnonymizedStudentIdentifier], [EducationOrganizationId], [FactAsOfDate], [FactsAsOfDate], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[AnonymizedStudentAcademicRecord] ([AnonymizedStudentIdentifier], [EducationOrganizationId], [FactAsOfDate], [FactsAsOfDate], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentCourseTranscript_AnonymizedStudentAcademicRecord]
ON [tpdm].[AnonymizedStudentCourseTranscript] ([AnonymizedStudentIdentifier] ASC, [EducationOrganizationId] ASC, [FactAsOfDate] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentCourseTranscript_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentCourseTranscript_Course]
ON [tpdm].[AnonymizedStudentCourseTranscript] ([CourseCode] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentCourseTranscript_CourseRepeatCodeDescriptor] FOREIGN KEY ([CourseRepeatCodeDescriptorId])
REFERENCES [edfi].[CourseRepeatCodeDescriptor] ([CourseRepeatCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentCourseTranscript_CourseRepeatCodeDescriptor]
ON [tpdm].[AnonymizedStudentCourseTranscript] ([CourseRepeatCodeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentDisability] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentDisability_AnonymizedStudent] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudent] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentDisability_AnonymizedStudent]
ON [tpdm].[AnonymizedStudentDisability] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentDisability] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentDisability_DisabilityDescriptor]
ON [tpdm].[AnonymizedStudentDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentDisability] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [tpdm].[AnonymizedStudentDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentDisabilityDesignation_AnonymizedStudentDisability] FOREIGN KEY ([AnonymizedStudentIdentifier], [DisabilityDescriptorId], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudentDisability] ([AnonymizedStudentIdentifier], [DisabilityDescriptorId], [FactsAsOfDate], [SchoolYear])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentDisabilityDesignation_AnonymizedStudentDisability]
ON [tpdm].[AnonymizedStudentDisabilityDesignation] ([AnonymizedStudentIdentifier] ASC, [DisabilityDescriptorId] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentDisabilityDesignation_DisabilityDesignationDescriptor]
ON [tpdm].[AnonymizedStudentDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentEducationOrganizationAssociation_AnonymizedStudent] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudent] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentEducationOrganizationAssociation_AnonymizedStudent]
ON [tpdm].[AnonymizedStudentEducationOrganizationAssociation] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentEducationOrganizationAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentEducationOrganizationAssociation_EducationOrganization]
ON [tpdm].[AnonymizedStudentEducationOrganizationAssociation] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentLanguage] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentLanguage_AnonymizedStudent] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudent] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentLanguage_AnonymizedStudent]
ON [tpdm].[AnonymizedStudentLanguage] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentLanguage] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentLanguage_LanguageDescriptor]
ON [tpdm].[AnonymizedStudentLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentLanguageUse] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentLanguageUse_AnonymizedStudentLanguage] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [LanguageDescriptorId], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudentLanguage] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [LanguageDescriptorId], [SchoolYear])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentLanguageUse_AnonymizedStudentLanguage]
ON [tpdm].[AnonymizedStudentLanguageUse] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [LanguageDescriptorId] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentLanguageUse] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentLanguageUse_LanguageUseDescriptor]
ON [tpdm].[AnonymizedStudentLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentRace] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentRace_AnonymizedStudent] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudent] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentRace_AnonymizedStudent]
ON [tpdm].[AnonymizedStudentRace] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentRace] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentRace_RaceDescriptor]
ON [tpdm].[AnonymizedStudentRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentSectionAssociation_AnonymizedStudent] FOREIGN KEY ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
REFERENCES [tpdm].[AnonymizedStudent] ([AnonymizedStudentIdentifier], [FactsAsOfDate], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentSectionAssociation_AnonymizedStudent]
ON [tpdm].[AnonymizedStudentSectionAssociation] ([AnonymizedStudentIdentifier] ASC, [FactsAsOfDate] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[AnonymizedStudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_AnonymizedStudentSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_AnonymizedStudentSectionAssociation_Section]
ON [tpdm].[AnonymizedStudentSectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [tpdm].[Applicant] WITH CHECK ADD CONSTRAINT [FK_Applicant_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Applicant_CitizenshipStatusDescriptor]
ON [tpdm].[Applicant] ([CitizenshipStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Applicant] WITH CHECK ADD CONSTRAINT [FK_Applicant_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Applicant_GenderDescriptor]
ON [tpdm].[Applicant] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Applicant] WITH CHECK ADD CONSTRAINT [FK_Applicant_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Applicant_Person]
ON [tpdm].[Applicant] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Applicant] WITH CHECK ADD CONSTRAINT [FK_Applicant_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Applicant_SexDescriptor]
ON [tpdm].[Applicant] ([SexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Applicant] WITH CHECK ADD CONSTRAINT [FK_Applicant_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_Applicant_TeacherCandidate]
ON [tpdm].[Applicant] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantAddress_AddressTypeDescriptor]
ON [tpdm].[ApplicantAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantAddress_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantAddress_Applicant]
ON [tpdm].[ApplicantAddress] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantAddress_LocaleDescriptor]
ON [tpdm].[ApplicantAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantAddress_StateAbbreviationDescriptor]
ON [tpdm].[ApplicantAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_ApplicantAddressPeriod_ApplicantAddress] FOREIGN KEY ([AddressTypeDescriptorId], [ApplicantIdentifier], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [tpdm].[ApplicantAddress] ([AddressTypeDescriptorId], [ApplicantIdentifier], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantAddressPeriod_ApplicantAddress]
ON [tpdm].[ApplicantAddressPeriod] ([AddressTypeDescriptorId] ASC, [ApplicantIdentifier] ASC, [City] ASC, [PostalCode] ASC, [StateAbbreviationDescriptorId] ASC, [StreetNumberName] ASC)
GO

ALTER TABLE [tpdm].[ApplicantAid] WITH CHECK ADD CONSTRAINT [FK_ApplicantAid_AidTypeDescriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [tpdm].[AidTypeDescriptor] ([AidTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantAid_AidTypeDescriptor]
ON [tpdm].[ApplicantAid] ([AidTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantAid] WITH CHECK ADD CONSTRAINT [FK_ApplicantAid_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantAid_Applicant]
ON [tpdm].[ApplicantAid] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantBackgroundCheck_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantBackgroundCheck_Applicant]
ON [tpdm].[ApplicantBackgroundCheck] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [tpdm].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [tpdm].[ApplicantBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [tpdm].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [tpdm].[ApplicantBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ApplicantCharacteristic_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantCharacteristic_Applicant]
ON [tpdm].[ApplicantCharacteristic] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ApplicantCharacteristic_StudentCharacteristicDescriptor] FOREIGN KEY ([StudentCharacteristicDescriptorId])
REFERENCES [edfi].[StudentCharacteristicDescriptor] ([StudentCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantCharacteristic_StudentCharacteristicDescriptor]
ON [tpdm].[ApplicantCharacteristic] ([StudentCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantDisability_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantDisability_Applicant]
ON [tpdm].[ApplicantDisability] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantDisability_DisabilityDescriptor]
ON [tpdm].[ApplicantDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [tpdm].[ApplicantDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_ApplicantDisabilityDesignation_ApplicantDisability] FOREIGN KEY ([ApplicantIdentifier], [DisabilityDescriptorId])
REFERENCES [tpdm].[ApplicantDisability] ([ApplicantIdentifier], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantDisabilityDesignation_ApplicantDisability]
ON [tpdm].[ApplicantDisabilityDesignation] ([ApplicantIdentifier] ASC, [DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_ApplicantDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantDisabilityDesignation_DisabilityDesignationDescriptor]
ON [tpdm].[ApplicantDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ApplicantElectronicMail_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantElectronicMail_Applicant]
ON [tpdm].[ApplicantElectronicMail] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ApplicantElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantElectronicMail_ElectronicMailTypeDescriptor]
ON [tpdm].[ApplicantElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantIdentificationDocument_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantIdentificationDocument_Applicant]
ON [tpdm].[ApplicantIdentificationDocument] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantIdentificationDocument_CountryDescriptor]
ON [tpdm].[ApplicantIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[ApplicantIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[ApplicantIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantInternationalAddress_AddressTypeDescriptor]
ON [tpdm].[ApplicantInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantInternationalAddress_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantInternationalAddress_Applicant]
ON [tpdm].[ApplicantInternationalAddress] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantInternationalAddress_CountryDescriptor]
ON [tpdm].[ApplicantInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantLanguage] WITH CHECK ADD CONSTRAINT [FK_ApplicantLanguage_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantLanguage_Applicant]
ON [tpdm].[ApplicantLanguage] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantLanguage] WITH CHECK ADD CONSTRAINT [FK_ApplicantLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantLanguage_LanguageDescriptor]
ON [tpdm].[ApplicantLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ApplicantLanguageUse_ApplicantLanguage] FOREIGN KEY ([ApplicantIdentifier], [LanguageDescriptorId])
REFERENCES [tpdm].[ApplicantLanguage] ([ApplicantIdentifier], [LanguageDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantLanguageUse_ApplicantLanguage]
ON [tpdm].[ApplicantLanguageUse] ([ApplicantIdentifier] ASC, [LanguageDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ApplicantLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantLanguageUse_LanguageUseDescriptor]
ON [tpdm].[ApplicantLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantPersonalIdentificationDocument_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantPersonalIdentificationDocument_Applicant]
ON [tpdm].[ApplicantPersonalIdentificationDocument] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantPersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantPersonalIdentificationDocument_CountryDescriptor]
ON [tpdm].[ApplicantPersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantPersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantPersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[ApplicantPersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantPersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantPersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[ApplicantPersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProspectAssociation] WITH CHECK ADD CONSTRAINT [FK_ApplicantProspectAssociation_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProspectAssociation_Applicant]
ON [tpdm].[ApplicantProspectAssociation] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProspectAssociation] WITH CHECK ADD CONSTRAINT [FK_ApplicantProspectAssociation_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProspectAssociation_Prospect]
ON [tpdm].[ApplicantProspectAssociation] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantRace] WITH CHECK ADD CONSTRAINT [FK_ApplicantRace_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantRace_Applicant]
ON [tpdm].[ApplicantRace] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantRace] WITH CHECK ADD CONSTRAINT [FK_ApplicantRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantRace_RaceDescriptor]
ON [tpdm].[ApplicantRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantStaffIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_ApplicantStaffIdentificationCode_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantStaffIdentificationCode_Applicant]
ON [tpdm].[ApplicantStaffIdentificationCode] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantStaffIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_ApplicantStaffIdentificationCode_StaffIdentificationSystemDescriptor] FOREIGN KEY ([StaffIdentificationSystemDescriptorId])
REFERENCES [edfi].[StaffIdentificationSystemDescriptor] ([StaffIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantStaffIdentificationCode_StaffIdentificationSystemDescriptor]
ON [tpdm].[ApplicantStaffIdentificationCode] ([StaffIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantTeacherPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_ApplicantTeacherPreparationProgram_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantTeacherPreparationProgram_Applicant]
ON [tpdm].[ApplicantTeacherPreparationProgram] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantTeacherPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_ApplicantTeacherPreparationProgram_LevelOfDegreeAwardedDescriptor] FOREIGN KEY ([LevelOfDegreeAwardedDescriptorId])
REFERENCES [tpdm].[LevelOfDegreeAwardedDescriptor] ([LevelOfDegreeAwardedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantTeacherPreparationProgram_LevelOfDegreeAwardedDescriptor]
ON [tpdm].[ApplicantTeacherPreparationProgram] ([LevelOfDegreeAwardedDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantTeacherPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_ApplicantTeacherPreparationProgram_TeacherPreparationProgramTypeDescriptor] FOREIGN KEY ([TeacherPreparationProgramTypeDescriptorId])
REFERENCES [tpdm].[TeacherPreparationProgramTypeDescriptor] ([TeacherPreparationProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantTeacherPreparationProgram_TeacherPreparationProgramTypeDescriptor]
ON [tpdm].[ApplicantTeacherPreparationProgram] ([TeacherPreparationProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantTelephone] WITH CHECK ADD CONSTRAINT [FK_ApplicantTelephone_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantTelephone_Applicant]
ON [tpdm].[ApplicantTelephone] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantTelephone] WITH CHECK ADD CONSTRAINT [FK_ApplicantTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantTelephone_TelephoneNumberTypeDescriptor]
ON [tpdm].[ApplicantTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantVisa] WITH CHECK ADD CONSTRAINT [FK_ApplicantVisa_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantVisa_Applicant]
ON [tpdm].[ApplicantVisa] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantVisa] WITH CHECK ADD CONSTRAINT [FK_ApplicantVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantVisa_VisaDescriptor]
ON [tpdm].[ApplicantVisa] ([VisaDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_AcademicSubjectDescriptor]
ON [tpdm].[Application] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_AcademicSubjectDescriptor1] FOREIGN KEY ([HighNeedsAcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_AcademicSubjectDescriptor1]
ON [tpdm].[Application] ([HighNeedsAcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_AcademicSubjectDescriptor2] FOREIGN KEY ([HighlyQualifiedAcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_AcademicSubjectDescriptor2]
ON [tpdm].[Application] ([HighlyQualifiedAcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_Application_Applicant]
ON [tpdm].[Application] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_ApplicationSourceDescriptor] FOREIGN KEY ([ApplicationSourceDescriptorId])
REFERENCES [tpdm].[ApplicationSourceDescriptor] ([ApplicationSourceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_ApplicationSourceDescriptor]
ON [tpdm].[Application] ([ApplicationSourceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_ApplicationStatusDescriptor] FOREIGN KEY ([ApplicationStatusDescriptorId])
REFERENCES [tpdm].[ApplicationStatusDescriptor] ([ApplicationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_ApplicationStatusDescriptor]
ON [tpdm].[Application] ([ApplicationStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_EducationOrganization]
ON [tpdm].[Application] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_HireStatusDescriptor] FOREIGN KEY ([HireStatusDescriptorId])
REFERENCES [tpdm].[HireStatusDescriptor] ([HireStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_HireStatusDescriptor]
ON [tpdm].[Application] ([HireStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_HiringSourceDescriptor] FOREIGN KEY ([HiringSourceDescriptorId])
REFERENCES [tpdm].[HiringSourceDescriptor] ([HiringSourceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_HiringSourceDescriptor]
ON [tpdm].[Application] ([HiringSourceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_LevelOfEducationDescriptor] FOREIGN KEY ([HighestCompletedLevelOfEducationDescriptorId])
REFERENCES [edfi].[LevelOfEducationDescriptor] ([LevelOfEducationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_LevelOfEducationDescriptor]
ON [tpdm].[Application] ([HighestCompletedLevelOfEducationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_WithdrawReasonDescriptor] FOREIGN KEY ([WithdrawReasonDescriptorId])
REFERENCES [tpdm].[WithdrawReasonDescriptor] ([WithdrawReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_WithdrawReasonDescriptor]
ON [tpdm].[Application] ([WithdrawReasonDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_Application] FOREIGN KEY ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_Application]
ON [tpdm].[ApplicationEvent] ([ApplicantIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_ApplicationEventResultDescriptor] FOREIGN KEY ([ApplicationEventResultDescriptorId])
REFERENCES [tpdm].[ApplicationEventResultDescriptor] ([ApplicationEventResultDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_ApplicationEventResultDescriptor]
ON [tpdm].[ApplicationEvent] ([ApplicationEventResultDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_ApplicationEventTypeDescriptor] FOREIGN KEY ([ApplicationEventTypeDescriptorId])
REFERENCES [tpdm].[ApplicationEventTypeDescriptor] ([ApplicationEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_ApplicationEventTypeDescriptor]
ON [tpdm].[ApplicationEvent] ([ApplicationEventTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_SchoolYearType]
ON [tpdm].[ApplicationEvent] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_TermDescriptor]
ON [tpdm].[ApplicationEvent] ([TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationEventResultDescriptor] WITH CHECK ADD CONSTRAINT [FK_ApplicationEventResultDescriptor_Descriptor] FOREIGN KEY ([ApplicationEventResultDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ApplicationEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ApplicationEventTypeDescriptor_Descriptor] FOREIGN KEY ([ApplicationEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ApplicationGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ApplicationGradePointAverage_Application] FOREIGN KEY ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationGradePointAverage_Application]
ON [tpdm].[ApplicationGradePointAverage] ([ApplicantIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ApplicationGradePointAverage_GradePointAverageTypeDescriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[GradePointAverageTypeDescriptor] ([GradePointAverageTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationGradePointAverage_GradePointAverageTypeDescriptor]
ON [tpdm].[ApplicationGradePointAverage] ([GradePointAverageTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationOpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_ApplicationOpenStaffPosition_Application] FOREIGN KEY ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationOpenStaffPosition_Application]
ON [tpdm].[ApplicationOpenStaffPosition] ([ApplicantIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationOpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_ApplicationOpenStaffPosition_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationOpenStaffPosition_OpenStaffPosition]
ON [tpdm].[ApplicationOpenStaffPosition] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
GO

ALTER TABLE [tpdm].[ApplicationScoreResult] WITH CHECK ADD CONSTRAINT [FK_ApplicationScoreResult_Application] FOREIGN KEY ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationScoreResult_Application]
ON [tpdm].[ApplicationScoreResult] ([ApplicantIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationScoreResult] WITH CHECK ADD CONSTRAINT [FK_ApplicationScoreResult_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationScoreResult_AssessmentReportingMethodDescriptor]
ON [tpdm].[ApplicationScoreResult] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationScoreResult] WITH CHECK ADD CONSTRAINT [FK_ApplicationScoreResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationScoreResult_ResultDatatypeTypeDescriptor]
ON [tpdm].[ApplicationScoreResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationSourceDescriptor] WITH CHECK ADD CONSTRAINT [FK_ApplicationSourceDescriptor_Descriptor] FOREIGN KEY ([ApplicationSourceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ApplicationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_ApplicationStatusDescriptor_Descriptor] FOREIGN KEY ([ApplicationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ApplicationTerm] WITH CHECK ADD CONSTRAINT [FK_ApplicationTerm_Application] FOREIGN KEY ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationTerm_Application]
ON [tpdm].[ApplicationTerm] ([ApplicantIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationTerm] WITH CHECK ADD CONSTRAINT [FK_ApplicationTerm_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationTerm_TermDescriptor]
ON [tpdm].[ApplicationTerm] ([TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[AssessmentExtension] WITH CHECK ADD CONSTRAINT [FK_AssessmentExtension_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[AssessmentExtension] WITH CHECK ADD CONSTRAINT [FK_AssessmentExtension_ProgramGatewayDescriptor] FOREIGN KEY ([ProgramGatewayDescriptorId])
REFERENCES [tpdm].[ProgramGatewayDescriptor] ([ProgramGatewayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentExtension_ProgramGatewayDescriptor]
ON [tpdm].[AssessmentExtension] ([ProgramGatewayDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[BackgroundCheckStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_BackgroundCheckStatusDescriptor_Descriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[BackgroundCheckTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_BackgroundCheckTypeDescriptor_Descriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_CertificationFieldDescriptor] FOREIGN KEY ([CertificationFieldDescriptorId])
REFERENCES [tpdm].[CertificationFieldDescriptor] ([CertificationFieldDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_CertificationFieldDescriptor]
ON [tpdm].[Certification] ([CertificationFieldDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_CertificationLevelDescriptor] FOREIGN KEY ([CertificationLevelDescriptorId])
REFERENCES [tpdm].[CertificationLevelDescriptor] ([CertificationLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_CertificationLevelDescriptor]
ON [tpdm].[Certification] ([CertificationLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_CertificationStandardDescriptor] FOREIGN KEY ([CertificationStandardDescriptorId])
REFERENCES [tpdm].[CertificationStandardDescriptor] ([CertificationStandardDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_CertificationStandardDescriptor]
ON [tpdm].[Certification] ([CertificationStandardDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_DegreeDescriptor] FOREIGN KEY ([MinimumDegreeDescriptorId])
REFERENCES [tpdm].[DegreeDescriptor] ([DegreeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_DegreeDescriptor]
ON [tpdm].[Certification] ([MinimumDegreeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_EducationOrganization]
ON [tpdm].[Certification] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_EducatorRoleDescriptor] FOREIGN KEY ([EducatorRoleDescriptorId])
REFERENCES [tpdm].[EducatorRoleDescriptor] ([EducatorRoleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_EducatorRoleDescriptor]
ON [tpdm].[Certification] ([EducatorRoleDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_InstructionalSettingDescriptor] FOREIGN KEY ([InstructionalSettingDescriptorId])
REFERENCES [tpdm].[InstructionalSettingDescriptor] ([InstructionalSettingDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_InstructionalSettingDescriptor]
ON [tpdm].[Certification] ([InstructionalSettingDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_PopulationServedDescriptor]
ON [tpdm].[Certification] ([PopulationServedDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CertificationCertificationExam] WITH CHECK ADD CONSTRAINT [FK_CertificationCertificationExam_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [tpdm].[Certification] ([CertificationIdentifier], [Namespace])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CertificationCertificationExam_Certification]
ON [tpdm].[CertificationCertificationExam] ([CertificationIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [tpdm].[CertificationCertificationExam] WITH CHECK ADD CONSTRAINT [FK_CertificationCertificationExam_CertificationExam] FOREIGN KEY ([CertificationExamIdentifier], [CertificationExamNamespace])
REFERENCES [tpdm].[CertificationExam] ([CertificationExamIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationCertificationExam_CertificationExam]
ON [tpdm].[CertificationCertificationExam] ([CertificationExamIdentifier] ASC, [CertificationExamNamespace] ASC)
GO

ALTER TABLE [tpdm].[CertificationExam] WITH CHECK ADD CONSTRAINT [FK_CertificationExam_CertificationExamTypeDescriptor] FOREIGN KEY ([CertificationExamTypeDescriptorId])
REFERENCES [tpdm].[CertificationExamTypeDescriptor] ([CertificationExamTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExam_CertificationExamTypeDescriptor]
ON [tpdm].[CertificationExam] ([CertificationExamTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CertificationExam] WITH CHECK ADD CONSTRAINT [FK_CertificationExam_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExam_EducationOrganization]
ON [tpdm].[CertificationExam] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[CertificationExamResult] WITH CHECK ADD CONSTRAINT [FK_CertificationExamResult_CertificationExam] FOREIGN KEY ([CertificationExamIdentifier], [Namespace])
REFERENCES [tpdm].[CertificationExam] ([CertificationExamIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExamResult_CertificationExam]
ON [tpdm].[CertificationExamResult] ([CertificationExamIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [tpdm].[CertificationExamResult] WITH CHECK ADD CONSTRAINT [FK_CertificationExamResult_CertificationExamStatusDescriptor] FOREIGN KEY ([CertificationExamStatusDescriptorId])
REFERENCES [tpdm].[CertificationExamStatusDescriptor] ([CertificationExamStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExamResult_CertificationExamStatusDescriptor]
ON [tpdm].[CertificationExamResult] ([CertificationExamStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CertificationExamResult] WITH CHECK ADD CONSTRAINT [FK_CertificationExamResult_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExamResult_Person]
ON [tpdm].[CertificationExamResult] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CertificationExamStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationExamStatusDescriptor_Descriptor] FOREIGN KEY ([CertificationExamStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CertificationExamTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationExamTypeDescriptor_Descriptor] FOREIGN KEY ([CertificationExamTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CertificationFieldDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationFieldDescriptor_Descriptor] FOREIGN KEY ([CertificationFieldDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CertificationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CertificationGradeLevel_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [tpdm].[Certification] ([CertificationIdentifier], [Namespace])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CertificationGradeLevel_Certification]
ON [tpdm].[CertificationGradeLevel] ([CertificationIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [tpdm].[CertificationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CertificationGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationGradeLevel_GradeLevelDescriptor]
ON [tpdm].[CertificationGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CertificationLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationLevelDescriptor_Descriptor] FOREIGN KEY ([CertificationLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CertificationRoute] WITH CHECK ADD CONSTRAINT [FK_CertificationRoute_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [tpdm].[Certification] ([CertificationIdentifier], [Namespace])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CertificationRoute_Certification]
ON [tpdm].[CertificationRoute] ([CertificationIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [tpdm].[CertificationRoute] WITH CHECK ADD CONSTRAINT [FK_CertificationRoute_CertificationRouteDescriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [tpdm].[CertificationRouteDescriptor] ([CertificationRouteDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationRoute_CertificationRouteDescriptor]
ON [tpdm].[CertificationRoute] ([CertificationRouteDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CertificationRouteDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationRouteDescriptor_Descriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CertificationStandardDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationStandardDescriptor_Descriptor] FOREIGN KEY ([CertificationStandardDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CompleterAsStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_CompleterAsStaffAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_CompleterAsStaffAssociation_Staff]
ON [tpdm].[CompleterAsStaffAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[CompleterAsStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_CompleterAsStaffAssociation_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_CompleterAsStaffAssociation_TeacherCandidate]
ON [tpdm].[CompleterAsStaffAssociation] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CoteachingStyleObservedDescriptor] WITH CHECK ADD CONSTRAINT [FK_CoteachingStyleObservedDescriptor_Descriptor] FOREIGN KEY ([CoteachingStyleObservedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CredentialEvent] WITH CHECK ADD CONSTRAINT [FK_CredentialEvent_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialEvent_Credential]
ON [tpdm].[CredentialEvent] ([CredentialIdentifier] ASC, [StateOfIssueStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CredentialEvent] WITH CHECK ADD CONSTRAINT [FK_CredentialEvent_CredentialEventTypeDescriptor] FOREIGN KEY ([CredentialEventTypeDescriptorId])
REFERENCES [tpdm].[CredentialEventTypeDescriptor] ([CredentialEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialEvent_CredentialEventTypeDescriptor]
ON [tpdm].[CredentialEvent] ([CredentialEventTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CredentialEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CredentialEventTypeDescriptor_Descriptor] FOREIGN KEY ([CredentialEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CredentialExtension] WITH CHECK ADD CONSTRAINT [FK_CredentialExtension_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [tpdm].[Certification] ([CertificationIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialExtension_Certification]
ON [tpdm].[CredentialExtension] ([CertificationIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [tpdm].[CredentialExtension] WITH CHECK ADD CONSTRAINT [FK_CredentialExtension_CertificationRouteDescriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [tpdm].[CertificationRouteDescriptor] ([CertificationRouteDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialExtension_CertificationRouteDescriptor]
ON [tpdm].[CredentialExtension] ([CertificationRouteDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CredentialExtension] WITH CHECK ADD CONSTRAINT [FK_CredentialExtension_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CredentialExtension] WITH CHECK ADD CONSTRAINT [FK_CredentialExtension_CredentialStatusDescriptor] FOREIGN KEY ([CredentialStatusDescriptorId])
REFERENCES [tpdm].[CredentialStatusDescriptor] ([CredentialStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialExtension_CredentialStatusDescriptor]
ON [tpdm].[CredentialExtension] ([CredentialStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CredentialExtension] WITH CHECK ADD CONSTRAINT [FK_CredentialExtension_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialExtension_Person]
ON [tpdm].[CredentialExtension] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CredentialStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_CredentialStatusDescriptor_Descriptor] FOREIGN KEY ([CredentialStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CredentialStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_CredentialStudentAcademicRecord_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CredentialStudentAcademicRecord_Credential]
ON [tpdm].[CredentialStudentAcademicRecord] ([CredentialIdentifier] ASC, [StateOfIssueStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CredentialStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_CredentialStudentAcademicRecord_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialStudentAcademicRecord_StudentAcademicRecord]
ON [tpdm].[CredentialStudentAcademicRecord] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [StudentUSI] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[DegreeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DegreeDescriptor_Descriptor] FOREIGN KEY ([DegreeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EducatorRoleDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducatorRoleDescriptor_Descriptor] FOREIGN KEY ([EducatorRoleDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EmploymentEvent] WITH CHECK ADD CONSTRAINT [FK_EmploymentEvent_EmploymentEventTypeDescriptor] FOREIGN KEY ([EmploymentEventTypeDescriptorId])
REFERENCES [tpdm].[EmploymentEventTypeDescriptor] ([EmploymentEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EmploymentEvent_EmploymentEventTypeDescriptor]
ON [tpdm].[EmploymentEvent] ([EmploymentEventTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EmploymentEvent] WITH CHECK ADD CONSTRAINT [FK_EmploymentEvent_InternalExternalHireDescriptor] FOREIGN KEY ([InternalExternalHireDescriptorId])
REFERENCES [tpdm].[InternalExternalHireDescriptor] ([InternalExternalHireDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EmploymentEvent_InternalExternalHireDescriptor]
ON [tpdm].[EmploymentEvent] ([InternalExternalHireDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EmploymentEvent] WITH CHECK ADD CONSTRAINT [FK_EmploymentEvent_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_EmploymentEvent_OpenStaffPosition]
ON [tpdm].[EmploymentEvent] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
GO

ALTER TABLE [tpdm].[EmploymentEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EmploymentEventTypeDescriptor_Descriptor] FOREIGN KEY ([EmploymentEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EmploymentSeparationEvent] WITH CHECK ADD CONSTRAINT [FK_EmploymentSeparationEvent_EmploymentSeparationReasonDescriptor] FOREIGN KEY ([EmploymentSeparationReasonDescriptorId])
REFERENCES [tpdm].[EmploymentSeparationReasonDescriptor] ([EmploymentSeparationReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EmploymentSeparationEvent_EmploymentSeparationReasonDescriptor]
ON [tpdm].[EmploymentSeparationEvent] ([EmploymentSeparationReasonDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EmploymentSeparationEvent] WITH CHECK ADD CONSTRAINT [FK_EmploymentSeparationEvent_EmploymentSeparationTypeDescriptor] FOREIGN KEY ([EmploymentSeparationTypeDescriptorId])
REFERENCES [tpdm].[EmploymentSeparationTypeDescriptor] ([EmploymentSeparationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EmploymentSeparationEvent_EmploymentSeparationTypeDescriptor]
ON [tpdm].[EmploymentSeparationEvent] ([EmploymentSeparationTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EmploymentSeparationEvent] WITH CHECK ADD CONSTRAINT [FK_EmploymentSeparationEvent_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_EmploymentSeparationEvent_OpenStaffPosition]
ON [tpdm].[EmploymentSeparationEvent] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
GO

ALTER TABLE [tpdm].[EmploymentSeparationReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_EmploymentSeparationReasonDescriptor_Descriptor] FOREIGN KEY ([EmploymentSeparationReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EmploymentSeparationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EmploymentSeparationTypeDescriptor_Descriptor] FOREIGN KEY ([EmploymentSeparationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EnglishLanguageExamDescriptor] WITH CHECK ADD CONSTRAINT [FK_EnglishLanguageExamDescriptor_Descriptor] FOREIGN KEY ([EnglishLanguageExamDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[Evaluation] WITH CHECK ADD CONSTRAINT [FK_Evaluation_EvaluationTypeDescriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [tpdm].[EvaluationTypeDescriptor] ([EvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Evaluation_EvaluationTypeDescriptor]
ON [tpdm].[Evaluation] ([EvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Evaluation] WITH CHECK ADD CONSTRAINT [FK_Evaluation_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Evaluation_PerformanceEvaluation]
ON [tpdm].[Evaluation] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElement] WITH CHECK ADD CONSTRAINT [FK_EvaluationElement_EvaluationObjective] FOREIGN KEY ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationObjective] ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElement_EvaluationObjective]
ON [tpdm].[EvaluationElement] ([EducationOrganizationId] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElement] WITH CHECK ADD CONSTRAINT [FK_EvaluationElement_EvaluationTypeDescriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [tpdm].[EvaluationTypeDescriptor] ([EvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElement_EvaluationTypeDescriptor]
ON [tpdm].[EvaluationElement] ([EvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElementRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRating_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRating_EvaluationElement]
ON [tpdm].[EvaluationElementRating] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElementRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRating_EvaluationElementRatingLevelDescriptor] FOREIGN KEY ([EvaluationElementRatingLevelDescriptorId])
REFERENCES [tpdm].[EvaluationElementRatingLevelDescriptor] ([EvaluationElementRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRating_EvaluationElementRatingLevelDescriptor]
ON [tpdm].[EvaluationElementRating] ([EvaluationElementRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElementRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRating_EvaluationObjectiveRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationObjectiveRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRating_EvaluationObjectiveRating]
ON [tpdm].[EvaluationElementRating] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElementRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingLevel_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRatingLevel_EvaluationElement]
ON [tpdm].[EvaluationElementRatingLevel] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElementRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingLevel_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [tpdm].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRatingLevel_EvaluationRatingLevelDescriptor]
ON [tpdm].[EvaluationElementRatingLevel] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElementRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingLevelDescriptor_Descriptor] FOREIGN KEY ([EvaluationElementRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EvaluationElementRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingResult_EvaluationElementRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElementRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRatingResult_EvaluationElementRating]
ON [tpdm].[EvaluationElementRatingResult] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationElementRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRatingResult_ResultDatatypeTypeDescriptor]
ON [tpdm].[EvaluationElementRatingResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjective_Evaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[Evaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjective_Evaluation]
ON [tpdm].[EvaluationObjective] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjective_EvaluationTypeDescriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [tpdm].[EvaluationTypeDescriptor] ([EvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjective_EvaluationTypeDescriptor]
ON [tpdm].[EvaluationObjective] ([EvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRating_EvaluationObjective] FOREIGN KEY ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationObjective] ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRating_EvaluationObjective]
ON [tpdm].[EvaluationObjectiveRating] ([EducationOrganizationId] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRating_EvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRating_EvaluationRating]
ON [tpdm].[EvaluationObjectiveRating] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRating_ObjectiveRatingLevelDescriptor] FOREIGN KEY ([ObjectiveRatingLevelDescriptorId])
REFERENCES [tpdm].[ObjectiveRatingLevelDescriptor] ([ObjectiveRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRating_ObjectiveRatingLevelDescriptor]
ON [tpdm].[EvaluationObjectiveRating] ([ObjectiveRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRatingLevel_EvaluationObjective] FOREIGN KEY ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationObjective] ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRatingLevel_EvaluationObjective]
ON [tpdm].[EvaluationObjectiveRatingLevel] ([EducationOrganizationId] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRatingLevel_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [tpdm].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRatingLevel_EvaluationRatingLevelDescriptor]
ON [tpdm].[EvaluationObjectiveRatingLevel] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRatingResult_EvaluationObjectiveRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationObjectiveRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRatingResult_EvaluationObjectiveRating]
ON [tpdm].[EvaluationObjectiveRatingResult] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationObjectiveRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRatingResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRatingResult_ResultDatatypeTypeDescriptor]
ON [tpdm].[EvaluationObjectiveRatingResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationPeriodDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationPeriodDescriptor_Descriptor] FOREIGN KEY ([EvaluationPeriodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_Evaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[Evaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_Evaluation]
ON [tpdm].[EvaluationRating] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [tpdm].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_EvaluationRatingLevelDescriptor]
ON [tpdm].[EvaluationRating] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_PerformanceEvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluationRating] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_PerformanceEvaluationRating]
ON [tpdm].[EvaluationRating] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_Section]
ON [tpdm].[EvaluationRating] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingLevel_Evaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[Evaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingLevel_Evaluation]
ON [tpdm].[EvaluationRatingLevel] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingLevel_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [tpdm].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingLevel_EvaluationRatingLevelDescriptor]
ON [tpdm].[EvaluationRatingLevel] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingLevelDescriptor_Descriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingResult_EvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingResult_EvaluationRating]
ON [tpdm].[EvaluationRatingResult] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingResult_ResultDatatypeTypeDescriptor]
ON [tpdm].[EvaluationRatingResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewer_EvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingReviewer_EvaluationRating]
ON [tpdm].[EvaluationRatingReviewer] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewer_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingReviewer_Person]
ON [tpdm].[EvaluationRatingReviewer] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRatingReviewerReceivedTraining] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewerReceivedTraining_EvaluationRatingReviewer] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [FirstName], [LastSurname], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationRatingReviewer] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [FirstName], [LastSurname], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[FederalLocaleCodeDescriptor] WITH CHECK ADD CONSTRAINT [FK_FederalLocaleCodeDescriptor_Descriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_FieldworkTypeDescriptor] FOREIGN KEY ([FieldworkTypeDescriptorId])
REFERENCES [tpdm].[FieldworkTypeDescriptor] ([FieldworkTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperience_FieldworkTypeDescriptor]
ON [tpdm].[FieldworkExperience] ([FieldworkTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_ProgramGatewayDescriptor] FOREIGN KEY ([ProgramGatewayDescriptorId])
REFERENCES [tpdm].[ProgramGatewayDescriptor] ([ProgramGatewayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperience_ProgramGatewayDescriptor]
ON [tpdm].[FieldworkExperience] ([ProgramGatewayDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperience_Student]
ON [tpdm].[FieldworkExperience] ([StudentUSI] ASC)
GO

ALTER TABLE [tpdm].[FieldworkExperienceCoteaching] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperienceCoteaching_FieldworkExperience] FOREIGN KEY ([BeginDate], [FieldworkIdentifier], [StudentUSI])
REFERENCES [tpdm].[FieldworkExperience] ([BeginDate], [FieldworkIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[FieldworkExperienceSchool] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperienceSchool_FieldworkExperience] FOREIGN KEY ([BeginDate], [FieldworkIdentifier], [StudentUSI])
REFERENCES [tpdm].[FieldworkExperience] ([BeginDate], [FieldworkIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperienceSchool_FieldworkExperience]
ON [tpdm].[FieldworkExperienceSchool] ([BeginDate] ASC, [FieldworkIdentifier] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [tpdm].[FieldworkExperienceSchool] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperienceSchool_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperienceSchool_School]
ON [tpdm].[FieldworkExperienceSchool] ([SchoolId] ASC)
GO

ALTER TABLE [tpdm].[FieldworkExperienceSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperienceSectionAssociation_FieldworkExperience] FOREIGN KEY ([BeginDate], [FieldworkIdentifier], [StudentUSI])
REFERENCES [tpdm].[FieldworkExperience] ([BeginDate], [FieldworkIdentifier], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperienceSectionAssociation_FieldworkExperience]
ON [tpdm].[FieldworkExperienceSectionAssociation] ([BeginDate] ASC, [FieldworkIdentifier] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [tpdm].[FieldworkExperienceSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperienceSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperienceSectionAssociation_Section]
ON [tpdm].[FieldworkExperienceSectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [tpdm].[FieldworkTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_FieldworkTypeDescriptor_Descriptor] FOREIGN KEY ([FieldworkTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[FundingSourceDescriptor] WITH CHECK ADD CONSTRAINT [FK_FundingSourceDescriptor_Descriptor] FOREIGN KEY ([FundingSourceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[GenderDescriptor] WITH CHECK ADD CONSTRAINT [FK_GenderDescriptor_Descriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[Goal] WITH CHECK ADD CONSTRAINT [FK_Goal_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Goal_EvaluationElement]
ON [tpdm].[Goal] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Goal] WITH CHECK ADD CONSTRAINT [FK_Goal_GoalTypeDescriptor] FOREIGN KEY ([GoalTypeDescriptorId])
REFERENCES [tpdm].[GoalTypeDescriptor] ([GoalTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Goal_GoalTypeDescriptor]
ON [tpdm].[Goal] ([GoalTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Goal] WITH CHECK ADD CONSTRAINT [FK_Goal_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Goal_Person]
ON [tpdm].[Goal] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[GoalTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GoalTypeDescriptor_Descriptor] FOREIGN KEY ([GoalTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[GraduationPlanRequiredCertification] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredCertification_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [tpdm].[Certification] ([CertificationIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredCertification_Certification]
ON [tpdm].[GraduationPlanRequiredCertification] ([CertificationIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [tpdm].[GraduationPlanRequiredCertification] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredCertification_CertificationRouteDescriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [tpdm].[CertificationRouteDescriptor] ([CertificationRouteDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredCertification_CertificationRouteDescriptor]
ON [tpdm].[GraduationPlanRequiredCertification] ([CertificationRouteDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[GraduationPlanRequiredCertification] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredCertification_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredCertification_GraduationPlan]
ON [tpdm].[GraduationPlanRequiredCertification] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC)
GO

ALTER TABLE [tpdm].[HireStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_HireStatusDescriptor_Descriptor] FOREIGN KEY ([HireStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[HiringSourceDescriptor] WITH CHECK ADD CONSTRAINT [FK_HiringSourceDescriptor_Descriptor] FOREIGN KEY ([HiringSourceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[InstructionalSettingDescriptor] WITH CHECK ADD CONSTRAINT [FK_InstructionalSettingDescriptor_Descriptor] FOREIGN KEY ([InstructionalSettingDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[InternalExternalHireDescriptor] WITH CHECK ADD CONSTRAINT [FK_InternalExternalHireDescriptor_Descriptor] FOREIGN KEY ([InternalExternalHireDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[LevelOfDegreeAwardedDescriptor] WITH CHECK ADD CONSTRAINT [FK_LevelOfDegreeAwardedDescriptor_Descriptor] FOREIGN KEY ([LevelOfDegreeAwardedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[LocalEducationAgencyExtension] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyExtension_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [tpdm].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgencyExtension_FederalLocaleCodeDescriptor]
ON [tpdm].[LocalEducationAgencyExtension] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[LocalEducationAgencyExtension] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyExtension_LocalEducationAgency] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ObjectiveRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_ObjectiveRatingLevelDescriptor_Descriptor] FOREIGN KEY ([ObjectiveRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[OpenStaffPositionEvent] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEvent_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionEvent_OpenStaffPosition]
ON [tpdm].[OpenStaffPositionEvent] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
GO

ALTER TABLE [tpdm].[OpenStaffPositionEvent] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEvent_OpenStaffPositionEventStatusDescriptor] FOREIGN KEY ([OpenStaffPositionEventStatusDescriptorId])
REFERENCES [tpdm].[OpenStaffPositionEventStatusDescriptor] ([OpenStaffPositionEventStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionEvent_OpenStaffPositionEventStatusDescriptor]
ON [tpdm].[OpenStaffPositionEvent] ([OpenStaffPositionEventStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[OpenStaffPositionEvent] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEvent_OpenStaffPositionEventTypeDescriptor] FOREIGN KEY ([OpenStaffPositionEventTypeDescriptorId])
REFERENCES [tpdm].[OpenStaffPositionEventTypeDescriptor] ([OpenStaffPositionEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionEvent_OpenStaffPositionEventTypeDescriptor]
ON [tpdm].[OpenStaffPositionEvent] ([OpenStaffPositionEventTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[OpenStaffPositionEventStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEventStatusDescriptor_Descriptor] FOREIGN KEY ([OpenStaffPositionEventStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[OpenStaffPositionEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEventTypeDescriptor_Descriptor] FOREIGN KEY ([OpenStaffPositionEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[OpenStaffPositionExtension] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionExtension_FundingSourceDescriptor] FOREIGN KEY ([FundingSourceDescriptorId])
REFERENCES [tpdm].[FundingSourceDescriptor] ([FundingSourceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionExtension_FundingSourceDescriptor]
ON [tpdm].[OpenStaffPositionExtension] ([FundingSourceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[OpenStaffPositionExtension] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionExtension_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[OpenStaffPositionExtension] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionExtension_OpenStaffPositionReasonDescriptor] FOREIGN KEY ([OpenStaffPositionReasonDescriptorId])
REFERENCES [tpdm].[OpenStaffPositionReasonDescriptor] ([OpenStaffPositionReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionExtension_OpenStaffPositionReasonDescriptor]
ON [tpdm].[OpenStaffPositionExtension] ([OpenStaffPositionReasonDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[OpenStaffPositionExtension] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionExtension_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionExtension_SchoolYearType]
ON [tpdm].[OpenStaffPositionExtension] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[OpenStaffPositionExtension] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionExtension_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionExtension_TermDescriptor]
ON [tpdm].[OpenStaffPositionExtension] ([TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[OpenStaffPositionReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionReasonDescriptor_Descriptor] FOREIGN KEY ([OpenStaffPositionReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_AcademicSubjectDescriptor]
ON [tpdm].[PerformanceEvaluation] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_EducationOrganization]
ON [tpdm].[PerformanceEvaluation] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_EvaluationPeriodDescriptor] FOREIGN KEY ([EvaluationPeriodDescriptorId])
REFERENCES [tpdm].[EvaluationPeriodDescriptor] ([EvaluationPeriodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_EvaluationPeriodDescriptor]
ON [tpdm].[PerformanceEvaluation] ([EvaluationPeriodDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_PerformanceEvaluationTypeDescriptor] FOREIGN KEY ([PerformanceEvaluationTypeDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluationTypeDescriptor] ([PerformanceEvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_PerformanceEvaluationTypeDescriptor]
ON [tpdm].[PerformanceEvaluation] ([PerformanceEvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_SchoolYearType]
ON [tpdm].[PerformanceEvaluation] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_TermDescriptor]
ON [tpdm].[PerformanceEvaluation] ([TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationGradeLevel_GradeLevelDescriptor]
ON [tpdm].[PerformanceEvaluationGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationGradeLevel_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationGradeLevel_PerformanceEvaluation]
ON [tpdm].[PerformanceEvaluationGradeLevel] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationProgramGateway] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationProgramGateway_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationProgramGateway_PerformanceEvaluation]
ON [tpdm].[PerformanceEvaluationProgramGateway] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationProgramGateway] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationProgramGateway_ProgramGatewayDescriptor] FOREIGN KEY ([ProgramGatewayDescriptorId])
REFERENCES [tpdm].[ProgramGatewayDescriptor] ([ProgramGatewayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationProgramGateway_ProgramGatewayDescriptor]
ON [tpdm].[PerformanceEvaluationProgramGateway] ([ProgramGatewayDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRating] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRating_CoteachingStyleObservedDescriptor] FOREIGN KEY ([CoteachingStyleObservedDescriptorId])
REFERENCES [tpdm].[CoteachingStyleObservedDescriptor] ([CoteachingStyleObservedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRating_CoteachingStyleObservedDescriptor]
ON [tpdm].[PerformanceEvaluationRating] ([CoteachingStyleObservedDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRating] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRating_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRating_PerformanceEvaluation]
ON [tpdm].[PerformanceEvaluationRating] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRating] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRating_PerformanceEvaluationRatingLevelDescriptor] FOREIGN KEY ([PerformanceEvaluationRatingLevelDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluationRatingLevelDescriptor] ([PerformanceEvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRating_PerformanceEvaluationRatingLevelDescriptor]
ON [tpdm].[PerformanceEvaluationRating] ([PerformanceEvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRating] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRating_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRating_Person]
ON [tpdm].[PerformanceEvaluationRating] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingLevel_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [tpdm].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingLevel_EvaluationRatingLevelDescriptor]
ON [tpdm].[PerformanceEvaluationRatingLevel] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingLevel_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingLevel_PerformanceEvaluation]
ON [tpdm].[PerformanceEvaluationRatingLevel] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingLevelDescriptor_Descriptor] FOREIGN KEY ([PerformanceEvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingResult_PerformanceEvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluationRating] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingResult_PerformanceEvaluationRating]
ON [tpdm].[PerformanceEvaluationRatingResult] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingResult_ResultDatatypeTypeDescriptor]
ON [tpdm].[PerformanceEvaluationRatingResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewer_PerformanceEvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluationRating] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingReviewer_PerformanceEvaluationRating]
ON [tpdm].[PerformanceEvaluationRatingReviewer] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewer_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingReviewer_Person]
ON [tpdm].[PerformanceEvaluationRatingReviewer] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewerReceivedTraining_PerformanceEvaluationRatingReviewer] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [FirstName], [LastSurname], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluationRatingReviewer] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [FirstName], [LastSurname], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[PerformanceEvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([PerformanceEvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[PostSecondaryInstitutionExtension] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitutionExtension_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [tpdm].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PostSecondaryInstitutionExtension_FederalLocaleCodeDescriptor]
ON [tpdm].[PostSecondaryInstitutionExtension] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PostSecondaryInstitutionExtension] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitutionExtension_PostSecondaryInstitution] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[PostSecondaryInstitution] ([PostSecondaryInstitutionId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[PreviousCareerDescriptor] WITH CHECK ADD CONSTRAINT [FK_PreviousCareerDescriptor_Descriptor] FOREIGN KEY ([PreviousCareerDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ProfessionalDevelopmentEvent] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentEvent_ProfessionalDevelopmentOfferedByDescriptor] FOREIGN KEY ([ProfessionalDevelopmentOfferedByDescriptorId])
REFERENCES [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] ([ProfessionalDevelopmentOfferedByDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProfessionalDevelopmentEvent_ProfessionalDevelopmentOfferedByDescriptor]
ON [tpdm].[ProfessionalDevelopmentEvent] ([ProfessionalDevelopmentOfferedByDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentEventAttendance_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProfessionalDevelopmentEventAttendance_AttendanceEventCategoryDescriptor]
ON [tpdm].[ProfessionalDevelopmentEventAttendance] ([AttendanceEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentEventAttendance_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProfessionalDevelopmentEventAttendance_Person]
ON [tpdm].[ProfessionalDevelopmentEventAttendance] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProfessionalDevelopmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentEventAttendance_ProfessionalDevelopmentEvent] FOREIGN KEY ([Namespace], [ProfessionalDevelopmentTitle])
REFERENCES [tpdm].[ProfessionalDevelopmentEvent] ([Namespace], [ProfessionalDevelopmentTitle])
GO

CREATE NONCLUSTERED INDEX [FK_ProfessionalDevelopmentEventAttendance_ProfessionalDevelopmentEvent]
ON [tpdm].[ProfessionalDevelopmentEventAttendance] ([Namespace] ASC, [ProfessionalDevelopmentTitle] ASC)
GO

ALTER TABLE [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentOfferedByDescriptor_Descriptor] FOREIGN KEY ([ProfessionalDevelopmentOfferedByDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ProgramGatewayDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramGatewayDescriptor_Descriptor] FOREIGN KEY ([ProgramGatewayDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[Prospect] WITH CHECK ADD CONSTRAINT [FK_Prospect_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_Prospect_EducationOrganization]
ON [tpdm].[Prospect] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[Prospect] WITH CHECK ADD CONSTRAINT [FK_Prospect_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Prospect_GenderDescriptor]
ON [tpdm].[Prospect] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Prospect] WITH CHECK ADD CONSTRAINT [FK_Prospect_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Prospect_Person]
ON [tpdm].[Prospect] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Prospect] WITH CHECK ADD CONSTRAINT [FK_Prospect_ProspectTypeDescriptor] FOREIGN KEY ([ProspectTypeDescriptorId])
REFERENCES [tpdm].[ProspectTypeDescriptor] ([ProspectTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Prospect_ProspectTypeDescriptor]
ON [tpdm].[Prospect] ([ProspectTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Prospect] WITH CHECK ADD CONSTRAINT [FK_Prospect_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Prospect_SexDescriptor]
ON [tpdm].[Prospect] ([SexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Prospect] WITH CHECK ADD CONSTRAINT [FK_Prospect_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_Prospect_TeacherCandidate]
ON [tpdm].[Prospect] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectAid] WITH CHECK ADD CONSTRAINT [FK_ProspectAid_AidTypeDescriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [tpdm].[AidTypeDescriptor] ([AidTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectAid_AidTypeDescriptor]
ON [tpdm].[ProspectAid] ([AidTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectAid] WITH CHECK ADD CONSTRAINT [FK_ProspectAid_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ProspectCurrentPosition] WITH CHECK ADD CONSTRAINT [FK_ProspectCurrentPosition_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectCurrentPosition_AcademicSubjectDescriptor]
ON [tpdm].[ProspectCurrentPosition] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectCurrentPosition] WITH CHECK ADD CONSTRAINT [FK_ProspectCurrentPosition_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ProspectCurrentPositionGradeLevel] WITH CHECK ADD CONSTRAINT [FK_ProspectCurrentPositionGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectCurrentPositionGradeLevel_GradeLevelDescriptor]
ON [tpdm].[ProspectCurrentPositionGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectCurrentPositionGradeLevel] WITH CHECK ADD CONSTRAINT [FK_ProspectCurrentPositionGradeLevel_ProspectCurrentPosition] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[ProspectCurrentPosition] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ProspectCurrentPositionGradeLevel_ProspectCurrentPosition]
ON [tpdm].[ProspectCurrentPositionGradeLevel] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectDisability] WITH CHECK ADD CONSTRAINT [FK_ProspectDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectDisability_DisabilityDescriptor]
ON [tpdm].[ProspectDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectDisability] WITH CHECK ADD CONSTRAINT [FK_ProspectDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [tpdm].[ProspectDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectDisability] WITH CHECK ADD CONSTRAINT [FK_ProspectDisability_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ProspectDisability_Prospect]
ON [tpdm].[ProspectDisability] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_ProspectDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectDisabilityDesignation_DisabilityDesignationDescriptor]
ON [tpdm].[ProspectDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_ProspectDisabilityDesignation_ProspectDisability] FOREIGN KEY ([DisabilityDescriptorId], [EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[ProspectDisability] ([DisabilityDescriptorId], [EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ProspectDisabilityDesignation_ProspectDisability]
ON [tpdm].[ProspectDisabilityDesignation] ([DisabilityDescriptorId] ASC, [EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ProspectPersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectPersonalIdentificationDocument_CountryDescriptor]
ON [tpdm].[ProspectPersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ProspectPersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectPersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[ProspectPersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ProspectPersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectPersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[ProspectPersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ProspectPersonalIdentificationDocument_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ProspectPersonalIdentificationDocument_Prospect]
ON [tpdm].[ProspectPersonalIdentificationDocument] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectQualifications] WITH CHECK ADD CONSTRAINT [FK_ProspectQualifications_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ProspectRace] WITH CHECK ADD CONSTRAINT [FK_ProspectRace_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ProspectRace_Prospect]
ON [tpdm].[ProspectRace] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectRace] WITH CHECK ADD CONSTRAINT [FK_ProspectRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectRace_RaceDescriptor]
ON [tpdm].[ProspectRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectRecruitmentEvent] WITH CHECK ADD CONSTRAINT [FK_ProspectRecruitmentEvent_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ProspectRecruitmentEvent_Prospect]
ON [tpdm].[ProspectRecruitmentEvent] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectRecruitmentEvent] WITH CHECK ADD CONSTRAINT [FK_ProspectRecruitmentEvent_RecruitmentEvent] FOREIGN KEY ([EventDate], [EventTitle])
REFERENCES [tpdm].[RecruitmentEvent] ([EventDate], [EventTitle])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectRecruitmentEvent_RecruitmentEvent]
ON [tpdm].[ProspectRecruitmentEvent] ([EventDate] ASC, [EventTitle] ASC)
GO

ALTER TABLE [tpdm].[ProspectTelephone] WITH CHECK ADD CONSTRAINT [FK_ProspectTelephone_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ProspectTelephone_Prospect]
ON [tpdm].[ProspectTelephone] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectTelephone] WITH CHECK ADD CONSTRAINT [FK_ProspectTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProspectTelephone_TelephoneNumberTypeDescriptor]
ON [tpdm].[ProspectTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ProspectTouchpoint] WITH CHECK ADD CONSTRAINT [FK_ProspectTouchpoint_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ProspectTouchpoint_Prospect]
ON [tpdm].[ProspectTouchpoint] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ProspectTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProspectTypeDescriptor_Descriptor] FOREIGN KEY ([ProspectTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[QuantitativeMeasure] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasure_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasure_EvaluationElement]
ON [tpdm].[QuantitativeMeasure] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[QuantitativeMeasure] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasure_QuantitativeMeasureDatatypeDescriptor] FOREIGN KEY ([QuantitativeMeasureDatatypeDescriptorId])
REFERENCES [tpdm].[QuantitativeMeasureDatatypeDescriptor] ([QuantitativeMeasureDatatypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasure_QuantitativeMeasureDatatypeDescriptor]
ON [tpdm].[QuantitativeMeasure] ([QuantitativeMeasureDatatypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[QuantitativeMeasure] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasure_QuantitativeMeasureTypeDescriptor] FOREIGN KEY ([QuantitativeMeasureTypeDescriptorId])
REFERENCES [tpdm].[QuantitativeMeasureTypeDescriptor] ([QuantitativeMeasureTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasure_QuantitativeMeasureTypeDescriptor]
ON [tpdm].[QuantitativeMeasure] ([QuantitativeMeasureTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[QuantitativeMeasureDatatypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasureDatatypeDescriptor_Descriptor] FOREIGN KEY ([QuantitativeMeasureDatatypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[QuantitativeMeasureScore] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasureScore_EvaluationElementRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElementRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasureScore_EvaluationElementRating]
ON [tpdm].[QuantitativeMeasureScore] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[QuantitativeMeasureScore] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasureScore_QuantitativeMeasure] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [QuantitativeMeasureIdentifier], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[QuantitativeMeasure] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [QuantitativeMeasureIdentifier], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasureScore_QuantitativeMeasure]
ON [tpdm].[QuantitativeMeasureScore] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [QuantitativeMeasureIdentifier] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[QuantitativeMeasureTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasureTypeDescriptor_Descriptor] FOREIGN KEY ([QuantitativeMeasureTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[RecruitmentEvent] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEvent_RecruitmentEventTypeDescriptor] FOREIGN KEY ([RecruitmentEventTypeDescriptorId])
REFERENCES [tpdm].[RecruitmentEventTypeDescriptor] ([RecruitmentEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEvent_RecruitmentEventTypeDescriptor]
ON [tpdm].[RecruitmentEvent] ([RecruitmentEventTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventTypeDescriptor_Descriptor] FOREIGN KEY ([RecruitmentEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[RubricDimension] WITH CHECK ADD CONSTRAINT [FK_RubricDimension_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RubricDimension_EvaluationElement]
ON [tpdm].[RubricDimension] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RubricDimension] WITH CHECK ADD CONSTRAINT [FK_RubricDimension_RubricRatingLevelDescriptor] FOREIGN KEY ([RubricRatingLevelDescriptorId])
REFERENCES [tpdm].[RubricRatingLevelDescriptor] ([RubricRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RubricDimension_RubricRatingLevelDescriptor]
ON [tpdm].[RubricDimension] ([RubricRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RubricRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_RubricRatingLevelDescriptor_Descriptor] FOREIGN KEY ([RubricRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[SalaryTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_SalaryTypeDescriptor_Descriptor] FOREIGN KEY ([SalaryTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[SchoolExtension] WITH CHECK ADD CONSTRAINT [FK_SchoolExtension_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [tpdm].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolExtension_FederalLocaleCodeDescriptor]
ON [tpdm].[SchoolExtension] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[SchoolExtension] WITH CHECK ADD CONSTRAINT [FK_SchoolExtension_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[SchoolExtension] WITH CHECK ADD CONSTRAINT [FK_SchoolExtension_SchoolStatusDescriptor] FOREIGN KEY ([SchoolStatusDescriptorId])
REFERENCES [tpdm].[SchoolStatusDescriptor] ([SchoolStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolExtension_SchoolStatusDescriptor]
ON [tpdm].[SchoolExtension] ([SchoolStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[SchoolStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolStatusDescriptor_Descriptor] FOREIGN KEY ([SchoolStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffApplicantAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffApplicantAssociation_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_StaffApplicantAssociation_Applicant]
ON [tpdm].[StaffApplicantAssociation] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[StaffApplicantAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffApplicantAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffApplicantAssociation_Staff]
ON [tpdm].[StaffApplicantAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [tpdm].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [tpdm].[StaffBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [tpdm].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [tpdm].[StaffBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffBackgroundCheck_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffBackgroundCheck_Staff]
ON [tpdm].[StaffBackgroundCheck] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociationExtension_StaffEducationOrganizationAssignmentAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [StaffClassificationDescriptorId], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationAssignmentAssociation] ([BeginDate], [EducationOrganizationId], [StaffClassificationDescriptorId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffExtension] WITH CHECK ADD CONSTRAINT [FK_StaffExtension_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffExtension_GenderDescriptor]
ON [tpdm].[StaffExtension] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffExtension] WITH CHECK ADD CONSTRAINT [FK_StaffExtension_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffHighlyQualifiedAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffHighlyQualifiedAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffHighlyQualifiedAcademicSubject_AcademicSubjectDescriptor]
ON [tpdm].[StaffHighlyQualifiedAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffHighlyQualifiedAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffHighlyQualifiedAcademicSubject_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffHighlyQualifiedAcademicSubject_Staff]
ON [tpdm].[StaffHighlyQualifiedAcademicSubject] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffProspectAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffProspectAssociation_Prospect] FOREIGN KEY ([EducationOrganizationId], [ProspectIdentifier])
REFERENCES [tpdm].[Prospect] ([EducationOrganizationId], [ProspectIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_StaffProspectAssociation_Prospect]
ON [tpdm].[StaffProspectAssociation] ([EducationOrganizationId] ASC, [ProspectIdentifier] ASC)
GO

ALTER TABLE [tpdm].[StaffProspectAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffProspectAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffProspectAssociation_Staff]
ON [tpdm].[StaffProspectAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffSalary] WITH CHECK ADD CONSTRAINT [FK_StaffSalary_SalaryTypeDescriptor] FOREIGN KEY ([SalaryTypeDescriptorId])
REFERENCES [tpdm].[SalaryTypeDescriptor] ([SalaryTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffSalary_SalaryTypeDescriptor]
ON [tpdm].[StaffSalary] ([SalaryTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffSalary] WITH CHECK ADD CONSTRAINT [FK_StaffSalary_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffSeniority] WITH CHECK ADD CONSTRAINT [FK_StaffSeniority_CredentialFieldDescriptor] FOREIGN KEY ([CredentialFieldDescriptorId])
REFERENCES [edfi].[CredentialFieldDescriptor] ([CredentialFieldDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffSeniority_CredentialFieldDescriptor]
ON [tpdm].[StaffSeniority] ([CredentialFieldDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffSeniority] WITH CHECK ADD CONSTRAINT [FK_StaffSeniority_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffSeniority_Staff]
ON [tpdm].[StaffSeniority] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasure] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasure_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasure_ResultDatatypeTypeDescriptor]
ON [tpdm].[StaffStudentGrowthMeasure] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasure] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasure_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasure_SchoolYearType]
ON [tpdm].[StaffStudentGrowthMeasure] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasure] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasure_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasure_Staff]
ON [tpdm].[StaffStudentGrowthMeasure] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasure] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasure_StudentGrowthTypeDescriptor] FOREIGN KEY ([StudentGrowthTypeDescriptorId])
REFERENCES [tpdm].[StudentGrowthTypeDescriptor] ([StudentGrowthTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasure_StudentGrowthTypeDescriptor]
ON [tpdm].[StaffStudentGrowthMeasure] ([StudentGrowthTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureAcademicSubject_AcademicSubjectDescriptor]
ON [tpdm].[StaffStudentGrowthMeasureAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureAcademicSubject_StaffStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
REFERENCES [tpdm].[StaffStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureAcademicSubject_StaffStudentGrowthMeasure]
ON [tpdm].[StaffStudentGrowthMeasureAcademicSubject] ([FactAsOfDate] ASC, [SchoolYear] ASC, [StaffStudentGrowthMeasureIdentifier] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureCourseAssociation_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureCourseAssociation_Course]
ON [tpdm].[StaffStudentGrowthMeasureCourseAssociation] ([CourseCode] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureCourseAssociation_StaffStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
REFERENCES [tpdm].[StaffStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureCourseAssociation_StaffStudentGrowthMeasure]
ON [tpdm].[StaffStudentGrowthMeasureCourseAssociation] ([FactAsOfDate] ASC, [SchoolYear] ASC, [StaffStudentGrowthMeasureIdentifier] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureEducationOrganizationAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureEducationOrganizationAssociation_EducationOrganization]
ON [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureEducationOrganizationAssociation_StaffStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
REFERENCES [tpdm].[StaffStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureEducationOrganizationAssociation_StaffStudentGrowthMeasure]
ON [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] ([FactAsOfDate] ASC, [SchoolYear] ASC, [StaffStudentGrowthMeasureIdentifier] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureGradeLevel] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureGradeLevel_GradeLevelDescriptor]
ON [tpdm].[StaffStudentGrowthMeasureGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureGradeLevel] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureGradeLevel_StaffStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
REFERENCES [tpdm].[StaffStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureGradeLevel_StaffStudentGrowthMeasure]
ON [tpdm].[StaffStudentGrowthMeasureGradeLevel] ([FactAsOfDate] ASC, [SchoolYear] ASC, [StaffStudentGrowthMeasureIdentifier] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureSectionAssociation_Section]
ON [tpdm].[StaffStudentGrowthMeasureSectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [tpdm].[StaffStudentGrowthMeasureSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentGrowthMeasureSectionAssociation_StaffStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
REFERENCES [tpdm].[StaffStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [StaffStudentGrowthMeasureIdentifier], [StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentGrowthMeasureSectionAssociation_StaffStudentGrowthMeasure]
ON [tpdm].[StaffStudentGrowthMeasureSectionAssociation] ([FactAsOfDate] ASC, [SchoolYear] ASC, [StaffStudentGrowthMeasureIdentifier] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherEducatorResearch] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherEducatorResearch_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProgram_LevelOfDegreeAwardedDescriptor] FOREIGN KEY ([LevelOfDegreeAwardedDescriptorId])
REFERENCES [tpdm].[LevelOfDegreeAwardedDescriptor] ([LevelOfDegreeAwardedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProgram_LevelOfDegreeAwardedDescriptor]
ON [tpdm].[StaffTeacherPreparationProgram] ([LevelOfDegreeAwardedDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProgram_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProgram_Staff]
ON [tpdm].[StaffTeacherPreparationProgram] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProgram_TeacherPreparationProgramTypeDescriptor] FOREIGN KEY ([TeacherPreparationProgramTypeDescriptorId])
REFERENCES [tpdm].[TeacherPreparationProgramTypeDescriptor] ([TeacherPreparationProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProgram_TeacherPreparationProgramTypeDescriptor]
ON [tpdm].[StaffTeacherPreparationProgram] ([TeacherPreparationProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderAssociation_ProgramAssignmentDescriptor] FOREIGN KEY ([ProgramAssignmentDescriptorId])
REFERENCES [edfi].[ProgramAssignmentDescriptor] ([ProgramAssignmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderAssociation_ProgramAssignmentDescriptor]
ON [tpdm].[StaffTeacherPreparationProviderAssociation] ([ProgramAssignmentDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderAssociation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderAssociation_SchoolYearType]
ON [tpdm].[StaffTeacherPreparationProviderAssociation] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderAssociation_Staff]
ON [tpdm].[StaffTeacherPreparationProviderAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderAssociation_TeacherPreparationProvider] FOREIGN KEY ([TeacherPreparationProviderId])
REFERENCES [tpdm].[TeacherPreparationProvider] ([TeacherPreparationProviderId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderAssociation_TeacherPreparationProvider]
ON [tpdm].[StaffTeacherPreparationProviderAssociation] ([TeacherPreparationProviderId] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderAssociationAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderAssociationAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderAssociationAcademicSubject_AcademicSubjectDescriptor]
ON [tpdm].[StaffTeacherPreparationProviderAssociationAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderAssociationAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderAssociationAcademicSubject_StaffTeacherPreparationProviderAssociation] FOREIGN KEY ([StaffUSI], [TeacherPreparationProviderId])
REFERENCES [tpdm].[StaffTeacherPreparationProviderAssociation] ([StaffUSI], [TeacherPreparationProviderId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderAssociationAcademicSubject_StaffTeacherPreparationProviderAssociation]
ON [tpdm].[StaffTeacherPreparationProviderAssociationAcademicSubject] ([StaffUSI] ASC, [TeacherPreparationProviderId] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderAssociationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderAssociationGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderAssociationGradeLevel_GradeLevelDescriptor]
ON [tpdm].[StaffTeacherPreparationProviderAssociationGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderAssociationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderAssociationGradeLevel_StaffTeacherPreparationProviderAssociation] FOREIGN KEY ([StaffUSI], [TeacherPreparationProviderId])
REFERENCES [tpdm].[StaffTeacherPreparationProviderAssociation] ([StaffUSI], [TeacherPreparationProviderId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderAssociationGradeLevel_StaffTeacherPreparationProviderAssociation]
ON [tpdm].[StaffTeacherPreparationProviderAssociationGradeLevel] ([StaffUSI] ASC, [TeacherPreparationProviderId] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderProgramAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderProgramAssociation_Staff]
ON [tpdm].[StaffTeacherPreparationProviderProgramAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffTeacherPreparationProviderProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffTeacherPreparationProviderProgramAssociation_TeacherPreparationProviderProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[TeacherPreparationProviderProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffTeacherPreparationProviderProgramAssociation_TeacherPreparationProviderProgram]
ON [tpdm].[StaffTeacherPreparationProviderProgramAssociation] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StateEducationAgencyExtension] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgencyExtension_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [tpdm].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StateEducationAgencyExtension_FederalLocaleCodeDescriptor]
ON [tpdm].[StateEducationAgencyExtension] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StateEducationAgencyExtension] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgencyExtension_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StudentGradebookEntryExtension] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntryExtension_StudentGradebookEntry] FOREIGN KEY ([BeginDate], [DateAssigned], [GradebookEntryTitle], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentGradebookEntry] ([BeginDate], [DateAssigned], [GradebookEntryTitle], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [tpdm].[StudentGrowthTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_StudentGrowthTypeDescriptor_Descriptor] FOREIGN KEY ([StudentGrowthTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[SurveyResponseExtension] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseExtension_Applicant] FOREIGN KEY ([ApplicantIdentifier])
REFERENCES [tpdm].[Applicant] ([ApplicantIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponseExtension_Applicant]
ON [tpdm].[SurveyResponseExtension] ([ApplicantIdentifier] ASC)
GO

ALTER TABLE [tpdm].[SurveyResponseExtension] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseExtension_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[SurveyResponseExtension] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseExtension_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponseExtension_TeacherCandidate]
ON [tpdm].[SurveyResponseExtension] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseTeacherCandidateTargetAssociation_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponseTeacherCandidateTargetAssociation_SurveyResponse]
ON [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC)
GO

ALTER TABLE [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseTeacherCandidateTargetAssociation_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponseTeacherCandidateTargetAssociation_TeacherCandidate]
ON [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[SurveySectionAggregateResponse] WITH CHECK ADD CONSTRAINT [FK_SurveySectionAggregateResponse_EvaluationElementRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElementRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionAggregateResponse_EvaluationElementRating]
ON [tpdm].[SurveySectionAggregateResponse] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[SurveySectionAggregateResponse] WITH CHECK ADD CONSTRAINT [FK_SurveySectionAggregateResponse_SurveySection] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySection] ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionAggregateResponse_SurveySection]
ON [tpdm].[SurveySectionAggregateResponse] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveySectionTitle] ASC)
GO

ALTER TABLE [tpdm].[SurveySectionExtension] WITH CHECK ADD CONSTRAINT [FK_SurveySectionExtension_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [tpdm].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionExtension_EvaluationElement]
ON [tpdm].[SurveySectionExtension] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[SurveySectionExtension] WITH CHECK ADD CONSTRAINT [FK_SurveySectionExtension_SurveySection] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySection] ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseTeacherCandidateTargetAssociation_SurveySectionResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySectionResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponseTeacherCandidateTargetAssociation_SurveySectionResponse]
ON [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC, [SurveySectionTitle] ASC)
GO

ALTER TABLE [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseTeacherCandidateTargetAssociation_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponseTeacherCandidateTargetAssociation_TeacherCandidate]
ON [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_CitizenshipStatusDescriptor]
ON [tpdm].[TeacherCandidate] ([CitizenshipStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_CountryDescriptor] FOREIGN KEY ([BirthCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_CountryDescriptor]
ON [tpdm].[TeacherCandidate] ([BirthCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_EnglishLanguageExamDescriptor] FOREIGN KEY ([EnglishLanguageExamDescriptorId])
REFERENCES [tpdm].[EnglishLanguageExamDescriptor] ([EnglishLanguageExamDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_EnglishLanguageExamDescriptor]
ON [tpdm].[TeacherCandidate] ([EnglishLanguageExamDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_GenderDescriptor]
ON [tpdm].[TeacherCandidate] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_LimitedEnglishProficiencyDescriptor] FOREIGN KEY ([LimitedEnglishProficiencyDescriptorId])
REFERENCES [edfi].[LimitedEnglishProficiencyDescriptor] ([LimitedEnglishProficiencyDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_LimitedEnglishProficiencyDescriptor]
ON [tpdm].[TeacherCandidate] ([LimitedEnglishProficiencyDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_OldEthnicityDescriptor] FOREIGN KEY ([OldEthnicityDescriptorId])
REFERENCES [edfi].[OldEthnicityDescriptor] ([OldEthnicityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_OldEthnicityDescriptor]
ON [tpdm].[TeacherCandidate] ([OldEthnicityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_Person]
ON [tpdm].[TeacherCandidate] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_PreviousCareerDescriptor] FOREIGN KEY ([PreviousCareerDescriptorId])
REFERENCES [tpdm].[PreviousCareerDescriptor] ([PreviousCareerDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_PreviousCareerDescriptor]
ON [tpdm].[TeacherCandidate] ([PreviousCareerDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_SexDescriptor]
ON [tpdm].[TeacherCandidate] ([SexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_SexDescriptor1] FOREIGN KEY ([BirthSexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_SexDescriptor1]
ON [tpdm].[TeacherCandidate] ([BirthSexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_StateAbbreviationDescriptor] FOREIGN KEY ([BirthStateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_StateAbbreviationDescriptor]
ON [tpdm].[TeacherCandidate] ([BirthStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidate] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidate_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidate_Student]
ON [tpdm].[TeacherCandidate] ([StudentUSI] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_CreditTypeDescriptor] FOREIGN KEY ([CumulativeEarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_CreditTypeDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecord] ([CumulativeEarnedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_CreditTypeDescriptor1] FOREIGN KEY ([CumulativeAttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_CreditTypeDescriptor1]
ON [tpdm].[TeacherCandidateAcademicRecord] ([CumulativeAttemptedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_CreditTypeDescriptor2] FOREIGN KEY ([SessionEarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_CreditTypeDescriptor2]
ON [tpdm].[TeacherCandidateAcademicRecord] ([SessionEarnedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_CreditTypeDescriptor3] FOREIGN KEY ([SessionAttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_CreditTypeDescriptor3]
ON [tpdm].[TeacherCandidateAcademicRecord] ([SessionAttemptedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_EducationOrganization]
ON [tpdm].[TeacherCandidateAcademicRecord] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_ProgramGatewayDescriptor] FOREIGN KEY ([ProgramGatewayDescriptorId])
REFERENCES [tpdm].[ProgramGatewayDescriptor] ([ProgramGatewayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_ProgramGatewayDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecord] ([ProgramGatewayDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_SchoolYearType]
ON [tpdm].[TeacherCandidateAcademicRecord] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_TeacherCandidate]
ON [tpdm].[TeacherCandidateAcademicRecord] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_TermDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecord] ([TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecord_TPPDegreeTypeDescriptor] FOREIGN KEY ([TPPDegreeTypeDescriptorId])
REFERENCES [tpdm].[TPPDegreeTypeDescriptor] ([TPPDegreeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecord_TPPDegreeTypeDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecord] ([TPPDegreeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordAcademicHonor_AcademicHonorCategoryDescriptor] FOREIGN KEY ([AcademicHonorCategoryDescriptorId])
REFERENCES [edfi].[AcademicHonorCategoryDescriptor] ([AcademicHonorCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordAcademicHonor_AcademicHonorCategoryDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] ([AcademicHonorCategoryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordAcademicHonor_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordAcademicHonor_AchievementCategoryDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] ([AchievementCategoryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordAcademicHonor_TeacherCandidateAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
REFERENCES [tpdm].[TeacherCandidateAcademicRecord] ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordAcademicHonor_TeacherCandidateAcademicRecord]
ON [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordClassRanking] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordClassRanking_TeacherCandidateAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
REFERENCES [tpdm].[TeacherCandidateAcademicRecord] ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordDiploma_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordDiploma_AchievementCategoryDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecordDiploma] ([AchievementCategoryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordDiploma_DiplomaLevelDescriptor] FOREIGN KEY ([DiplomaLevelDescriptorId])
REFERENCES [edfi].[DiplomaLevelDescriptor] ([DiplomaLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordDiploma_DiplomaLevelDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecordDiploma] ([DiplomaLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordDiploma_DiplomaTypeDescriptor] FOREIGN KEY ([DiplomaTypeDescriptorId])
REFERENCES [edfi].[DiplomaTypeDescriptor] ([DiplomaTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordDiploma_DiplomaTypeDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecordDiploma] ([DiplomaTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordDiploma_TeacherCandidateAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
REFERENCES [tpdm].[TeacherCandidateAcademicRecord] ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordDiploma_TeacherCandidateAcademicRecord]
ON [tpdm].[TeacherCandidateAcademicRecordDiploma] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordGradePointAverage_GradePointAverageTypeDescriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[GradePointAverageTypeDescriptor] ([GradePointAverageTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordGradePointAverage_GradePointAverageTypeDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] ([GradePointAverageTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordGradePointAverage_TeacherCandidateAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
REFERENCES [tpdm].[TeacherCandidateAcademicRecord] ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordGradePointAverage_TeacherCandidateAcademicRecord]
ON [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordRecognition_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordRecognition_AchievementCategoryDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecordRecognition] ([AchievementCategoryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordRecognition_RecognitionTypeDescriptor] FOREIGN KEY ([RecognitionTypeDescriptorId])
REFERENCES [edfi].[RecognitionTypeDescriptor] ([RecognitionTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordRecognition_RecognitionTypeDescriptor]
ON [tpdm].[TeacherCandidateAcademicRecordRecognition] ([RecognitionTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAcademicRecordRecognition_TeacherCandidateAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
REFERENCES [tpdm].[TeacherCandidateAcademicRecord] ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAcademicRecordRecognition_TeacherCandidateAcademicRecord]
ON [tpdm].[TeacherCandidateAcademicRecordRecognition] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAddress] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAddress_AddressTypeDescriptor]
ON [tpdm].[TeacherCandidateAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAddress] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAddress_LocaleDescriptor]
ON [tpdm].[TeacherCandidateAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAddress] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAddress_StateAbbreviationDescriptor]
ON [tpdm].[TeacherCandidateAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAddress] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAddress_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAddress_TeacherCandidate]
ON [tpdm].[TeacherCandidateAddress] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAddressPeriod_TeacherCandidateAddress] FOREIGN KEY ([AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName], [TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidateAddress] ([AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName], [TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAddressPeriod_TeacherCandidateAddress]
ON [tpdm].[TeacherCandidateAddressPeriod] ([AddressTypeDescriptorId] ASC, [City] ASC, [PostalCode] ASC, [StateAbbreviationDescriptorId] ASC, [StreetNumberName] ASC, [TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAid] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAid_AidTypeDescriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [tpdm].[AidTypeDescriptor] ([AidTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAid_AidTypeDescriptor]
ON [tpdm].[TeacherCandidateAid] ([AidTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateAid] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateAid_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateAid_TeacherCandidate]
ON [tpdm].[TeacherCandidateAid] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [tpdm].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [tpdm].[TeacherCandidateBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [tpdm].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [tpdm].[TeacherCandidateBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateBackgroundCheck_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[TeacherCandidateCharacteristic] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCharacteristic_StudentCharacteristicDescriptor] FOREIGN KEY ([StudentCharacteristicDescriptorId])
REFERENCES [edfi].[StudentCharacteristicDescriptor] ([StudentCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCharacteristic_StudentCharacteristicDescriptor]
ON [tpdm].[TeacherCandidateCharacteristic] ([StudentCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCharacteristic] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCharacteristic_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCharacteristic_TeacherCandidate]
ON [tpdm].[TeacherCandidateCharacteristic] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCharacteristicDescriptor_Descriptor] FOREIGN KEY ([TeacherCandidateCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[TeacherCandidateCohortYear] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCohortYear_CohortYearTypeDescriptor] FOREIGN KEY ([CohortYearTypeDescriptorId])
REFERENCES [edfi].[CohortYearTypeDescriptor] ([CohortYearTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCohortYear_CohortYearTypeDescriptor]
ON [tpdm].[TeacherCandidateCohortYear] ([CohortYearTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCohortYear] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCohortYear_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCohortYear_SchoolYearType]
ON [tpdm].[TeacherCandidateCohortYear] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCohortYear] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCohortYear_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCohortYear_TeacherCandidate]
ON [tpdm].[TeacherCandidateCohortYear] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_Course] FOREIGN KEY ([CourseCode], [CourseEducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_Course]
ON [tpdm].[TeacherCandidateCourseTranscript] ([CourseCode] ASC, [CourseEducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_CourseAttemptResultDescriptor] FOREIGN KEY ([CourseAttemptResultDescriptorId])
REFERENCES [edfi].[CourseAttemptResultDescriptor] ([CourseAttemptResultDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_CourseAttemptResultDescriptor]
ON [tpdm].[TeacherCandidateCourseTranscript] ([CourseAttemptResultDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_CourseRepeatCodeDescriptor] FOREIGN KEY ([CourseRepeatCodeDescriptorId])
REFERENCES [edfi].[CourseRepeatCodeDescriptor] ([CourseRepeatCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_CourseRepeatCodeDescriptor]
ON [tpdm].[TeacherCandidateCourseTranscript] ([CourseRepeatCodeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_CreditTypeDescriptor] FOREIGN KEY ([AttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_CreditTypeDescriptor]
ON [tpdm].[TeacherCandidateCourseTranscript] ([AttemptedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_CreditTypeDescriptor1] FOREIGN KEY ([EarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_CreditTypeDescriptor1]
ON [tpdm].[TeacherCandidateCourseTranscript] ([EarnedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_GradeLevelDescriptor] FOREIGN KEY ([WhenTakenGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_GradeLevelDescriptor]
ON [tpdm].[TeacherCandidateCourseTranscript] ([WhenTakenGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_MethodCreditEarnedDescriptor] FOREIGN KEY ([MethodCreditEarnedDescriptorId])
REFERENCES [edfi].[MethodCreditEarnedDescriptor] ([MethodCreditEarnedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_MethodCreditEarnedDescriptor]
ON [tpdm].[TeacherCandidateCourseTranscript] ([MethodCreditEarnedDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_School]
ON [tpdm].[TeacherCandidateCourseTranscript] ([SchoolId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscript] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscript_TeacherCandidateAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
REFERENCES [tpdm].[TeacherCandidateAcademicRecord] ([EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscript_TeacherCandidateAcademicRecord]
ON [tpdm].[TeacherCandidateCourseTranscript] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscriptEarnedAdditionalCredits_AdditionalCreditTypeDescriptor] FOREIGN KEY ([AdditionalCreditTypeDescriptorId])
REFERENCES [edfi].[AdditionalCreditTypeDescriptor] ([AdditionalCreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscriptEarnedAdditionalCredits_AdditionalCreditTypeDescriptor]
ON [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] ([AdditionalCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateCourseTranscriptEarnedAdditionalCredits_TeacherCandidateCourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
REFERENCES [tpdm].[TeacherCandidateCourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [TeacherCandidateIdentifier], [TermDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateCourseTranscriptEarnedAdditionalCredits_TeacherCandidateCourseTranscript]
ON [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] ([CourseAttemptResultDescriptorId] ASC, [CourseCode] ASC, [CourseEducationOrganizationId] ASC, [EducationOrganizationId] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateDegreeSpecialization] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateDegreeSpecialization_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateDegreeSpecialization_TeacherCandidate]
ON [tpdm].[TeacherCandidateDegreeSpecialization] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateDisability] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateDisability_DisabilityDescriptor]
ON [tpdm].[TeacherCandidateDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateDisability] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [tpdm].[TeacherCandidateDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateDisability] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateDisability_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateDisability_TeacherCandidate]
ON [tpdm].[TeacherCandidateDisability] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateDisabilityDesignation_DisabilityDesignationDescriptor]
ON [tpdm].[TeacherCandidateDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateDisabilityDesignation_TeacherCandidateDisability] FOREIGN KEY ([DisabilityDescriptorId], [TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidateDisability] ([DisabilityDescriptorId], [TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateDisabilityDesignation_TeacherCandidateDisability]
ON [tpdm].[TeacherCandidateDisabilityDesignation] ([DisabilityDescriptorId] ASC, [TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateElectronicMail] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateElectronicMail_ElectronicMailTypeDescriptor]
ON [tpdm].[TeacherCandidateElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateElectronicMail] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateElectronicMail_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateElectronicMail_TeacherCandidate]
ON [tpdm].[TeacherCandidateElectronicMail] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateIdentificationCode_StudentIdentificationSystemDescriptor] FOREIGN KEY ([StudentIdentificationSystemDescriptorId])
REFERENCES [edfi].[StudentIdentificationSystemDescriptor] ([StudentIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateIdentificationCode_StudentIdentificationSystemDescriptor]
ON [tpdm].[TeacherCandidateIdentificationCode] ([StudentIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateIdentificationCode_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateIdentificationCode_TeacherCandidate]
ON [tpdm].[TeacherCandidateIdentificationCode] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateIdentificationDocument_CountryDescriptor]
ON [tpdm].[TeacherCandidateIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[TeacherCandidateIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[TeacherCandidateIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateIdentificationDocument_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateIdentificationDocument_TeacherCandidate]
ON [tpdm].[TeacherCandidateIdentificationDocument] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateIndicator] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateIndicator_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateIndicator_TeacherCandidate]
ON [tpdm].[TeacherCandidateIndicator] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateInternationalAddress_AddressTypeDescriptor]
ON [tpdm].[TeacherCandidateInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateInternationalAddress_CountryDescriptor]
ON [tpdm].[TeacherCandidateInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateInternationalAddress_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateInternationalAddress_TeacherCandidate]
ON [tpdm].[TeacherCandidateInternationalAddress] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateLanguage] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateLanguage_LanguageDescriptor]
ON [tpdm].[TeacherCandidateLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateLanguage] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateLanguage_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateLanguage_TeacherCandidate]
ON [tpdm].[TeacherCandidateLanguage] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateLanguageUse] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateLanguageUse_LanguageUseDescriptor]
ON [tpdm].[TeacherCandidateLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateLanguageUse] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateLanguageUse_TeacherCandidateLanguage] FOREIGN KEY ([LanguageDescriptorId], [TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidateLanguage] ([LanguageDescriptorId], [TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateLanguageUse_TeacherCandidateLanguage]
ON [tpdm].[TeacherCandidateLanguageUse] ([LanguageDescriptorId] ASC, [TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateOtherName] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateOtherName_OtherNameTypeDescriptor]
ON [tpdm].[TeacherCandidateOtherName] ([OtherNameTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateOtherName] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateOtherName_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateOtherName_TeacherCandidate]
ON [tpdm].[TeacherCandidateOtherName] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidatePersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidatePersonalIdentificationDocument_CountryDescriptor]
ON [tpdm].[TeacherCandidatePersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidatePersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidatePersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[TeacherCandidatePersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidatePersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidatePersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[TeacherCandidatePersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidatePersonalIdentificationDocument_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidatePersonalIdentificationDocument_TeacherCandidate]
ON [tpdm].[TeacherCandidatePersonalIdentificationDocument] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateRace] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateRace_RaceDescriptor]
ON [tpdm].[TeacherCandidateRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateRace] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateRace_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateRace_TeacherCandidate]
ON [tpdm].[TeacherCandidateRace] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStaffAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStaffAssociation_Staff]
ON [tpdm].[TeacherCandidateStaffAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStaffAssociation_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStaffAssociation_TeacherCandidate]
ON [tpdm].[TeacherCandidateStaffAssociation] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasure] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasure_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasure_ResultDatatypeTypeDescriptor]
ON [tpdm].[TeacherCandidateStudentGrowthMeasure] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasure] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasure_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasure_SchoolYearType]
ON [tpdm].[TeacherCandidateStudentGrowthMeasure] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasure] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasure_StudentGrowthTypeDescriptor] FOREIGN KEY ([StudentGrowthTypeDescriptorId])
REFERENCES [tpdm].[StudentGrowthTypeDescriptor] ([StudentGrowthTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasure_StudentGrowthTypeDescriptor]
ON [tpdm].[TeacherCandidateStudentGrowthMeasure] ([StudentGrowthTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasure] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasure_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasure_TeacherCandidate]
ON [tpdm].[TeacherCandidateStudentGrowthMeasure] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureAcademicSubject_AcademicSubjectDescriptor]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureAcademicSubject_TeacherCandidateStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
REFERENCES [tpdm].[TeacherCandidateStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureAcademicSubject_TeacherCandidateStudentGrowthMeasure]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] ([FactAsOfDate] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TeacherCandidateStudentGrowthMeasureIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureCourseAssociation_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureCourseAssociation_Course]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] ([CourseCode] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureCourseAssociation_TeacherCandidateStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
REFERENCES [tpdm].[TeacherCandidateStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureCourseAssociation_TeacherCandidateStudentGrowthMeasure]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] ([FactAsOfDate] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TeacherCandidateStudentGrowthMeasureIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_EducationOrganization]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_TeacherCandidateStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
REFERENCES [tpdm].[TeacherCandidateStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation_TeacherCandidateStudentGrowthMeasure]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] ([FactAsOfDate] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TeacherCandidateStudentGrowthMeasureIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureGradeLevel_GradeLevelDescriptor]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureGradeLevel_TeacherCandidateStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
REFERENCES [tpdm].[TeacherCandidateStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureGradeLevel_TeacherCandidateStudentGrowthMeasure]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] ([FactAsOfDate] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TeacherCandidateStudentGrowthMeasureIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureSectionAssociation_Section]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateStudentGrowthMeasureSectionAssociation_TeacherCandidateStudentGrowthMeasure] FOREIGN KEY ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
REFERENCES [tpdm].[TeacherCandidateStudentGrowthMeasure] ([FactAsOfDate], [SchoolYear], [TeacherCandidateIdentifier], [TeacherCandidateStudentGrowthMeasureIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateStudentGrowthMeasureSectionAssociation_TeacherCandidateStudentGrowthMeasure]
ON [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] ([FactAsOfDate] ASC, [SchoolYear] ASC, [TeacherCandidateIdentifier] ASC, [TeacherCandidateStudentGrowthMeasureIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderAssociation_EntryTypeDescriptor] FOREIGN KEY ([EntryTypeDescriptorId])
REFERENCES [edfi].[EntryTypeDescriptor] ([EntryTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderAssociation_EntryTypeDescriptor]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] ([EntryTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderAssociation_ExitWithdrawTypeDescriptor] FOREIGN KEY ([ExitWithdrawTypeDescriptorId])
REFERENCES [edfi].[ExitWithdrawTypeDescriptor] ([ExitWithdrawTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderAssociation_ExitWithdrawTypeDescriptor]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] ([ExitWithdrawTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderAssociation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderAssociation_SchoolYearType]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderAssociation_SchoolYearType1] FOREIGN KEY ([ClassOfSchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderAssociation_SchoolYearType1]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] ([ClassOfSchoolYear] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderAssociation_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderAssociation_TeacherCandidate]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderAssociation_TeacherPreparationProvider] FOREIGN KEY ([TeacherPreparationProviderId])
REFERENCES [tpdm].[TeacherPreparationProvider] ([TeacherPreparationProviderId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderAssociation_TeacherPreparationProvider]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] ([TeacherPreparationProviderId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderProgramAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderProgramAssociation_EducationOrganization]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderProgramAssociation_ReasonExitedDescriptor] FOREIGN KEY ([ReasonExitedDescriptorId])
REFERENCES [edfi].[ReasonExitedDescriptor] ([ReasonExitedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderProgramAssociation_ReasonExitedDescriptor]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] ([ReasonExitedDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderProgramAssociation_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderProgramAssociation_TeacherCandidate]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTeacherPreparationProviderProgramAssociation_TeacherPreparationProviderProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[TeacherPreparationProviderProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTeacherPreparationProviderProgramAssociation_TeacherPreparationProviderProgram]
ON [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTelephone] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTelephone_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTelephone_TeacherCandidate]
ON [tpdm].[TeacherCandidateTelephone] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTelephone] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTelephone_TelephoneNumberTypeDescriptor]
ON [tpdm].[TeacherCandidateTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTPPProgramDegree_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTPPProgramDegree_AcademicSubjectDescriptor]
ON [tpdm].[TeacherCandidateTPPProgramDegree] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTPPProgramDegree_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTPPProgramDegree_GradeLevelDescriptor]
ON [tpdm].[TeacherCandidateTPPProgramDegree] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTPPProgramDegree_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTPPProgramDegree_TeacherCandidate]
ON [tpdm].[TeacherCandidateTPPProgramDegree] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateTPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateTPPProgramDegree_TPPDegreeTypeDescriptor] FOREIGN KEY ([TPPDegreeTypeDescriptorId])
REFERENCES [tpdm].[TPPDegreeTypeDescriptor] ([TPPDegreeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateTPPProgramDegree_TPPDegreeTypeDescriptor]
ON [tpdm].[TeacherCandidateTPPProgramDegree] ([TPPDegreeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateVisa] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateVisa_TeacherCandidate] FOREIGN KEY ([TeacherCandidateIdentifier])
REFERENCES [tpdm].[TeacherCandidate] ([TeacherCandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateVisa_TeacherCandidate]
ON [tpdm].[TeacherCandidateVisa] ([TeacherCandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[TeacherCandidateVisa] WITH CHECK ADD CONSTRAINT [FK_TeacherCandidateVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherCandidateVisa_VisaDescriptor]
ON [tpdm].[TeacherCandidateVisa] ([VisaDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProgramTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProgramTypeDescriptor_Descriptor] FOREIGN KEY ([TeacherPreparationProgramTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[TeacherPreparationProvider] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProvider_AccreditationStatusDescriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [tpdm].[AccreditationStatusDescriptor] ([AccreditationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProvider_AccreditationStatusDescriptor]
ON [tpdm].[TeacherPreparationProvider] ([AccreditationStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProvider] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProvider_EducationOrganization] FOREIGN KEY ([TeacherPreparationProviderId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[TeacherPreparationProvider] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProvider_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [tpdm].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProvider_FederalLocaleCodeDescriptor]
ON [tpdm].[TeacherPreparationProvider] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProvider] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProvider_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProvider_School]
ON [tpdm].[TeacherPreparationProvider] ([SchoolId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProvider] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProvider_University] FOREIGN KEY ([UniversityId])
REFERENCES [tpdm].[University] ([UniversityId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProvider_University]
ON [tpdm].[TeacherPreparationProvider] ([UniversityId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProviderProgram] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProviderProgram_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProviderProgram_EducationOrganization]
ON [tpdm].[TeacherPreparationProviderProgram] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProviderProgram] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProviderProgram_ProgramTypeDescriptor] FOREIGN KEY ([ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramTypeDescriptor] ([ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProviderProgram_ProgramTypeDescriptor]
ON [tpdm].[TeacherPreparationProviderProgram] ([ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProviderProgram] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProviderProgram_TeacherPreparationProgramTypeDescriptor] FOREIGN KEY ([TeacherPreparationProgramTypeDescriptorId])
REFERENCES [tpdm].[TeacherPreparationProgramTypeDescriptor] ([TeacherPreparationProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProviderProgram_TeacherPreparationProgramTypeDescriptor]
ON [tpdm].[TeacherPreparationProviderProgram] ([TeacherPreparationProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProviderProgram] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProviderProgram_TPPProgramPathwayDescriptor] FOREIGN KEY ([TPPProgramPathwayDescriptorId])
REFERENCES [tpdm].[TPPProgramPathwayDescriptor] ([TPPProgramPathwayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProviderProgram_TPPProgramPathwayDescriptor]
ON [tpdm].[TeacherPreparationProviderProgram] ([TPPProgramPathwayDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProviderProgramGradeLevel] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProviderProgramGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProviderProgramGradeLevel_GradeLevelDescriptor]
ON [tpdm].[TeacherPreparationProviderProgramGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TeacherPreparationProviderProgramGradeLevel] WITH CHECK ADD CONSTRAINT [FK_TeacherPreparationProviderProgramGradeLevel_TeacherPreparationProviderProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[TeacherPreparationProviderProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_TeacherPreparationProviderProgramGradeLevel_TeacherPreparationProviderProgram]
ON [tpdm].[TeacherPreparationProviderProgramGradeLevel] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[TPPDegreeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_TPPDegreeTypeDescriptor_Descriptor] FOREIGN KEY ([TPPDegreeTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[TPPProgramPathwayDescriptor] WITH CHECK ADD CONSTRAINT [FK_TPPProgramPathwayDescriptor_Descriptor] FOREIGN KEY ([TPPProgramPathwayDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[University] WITH CHECK ADD CONSTRAINT [FK_University_EducationOrganization] FOREIGN KEY ([UniversityId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[University] WITH CHECK ADD CONSTRAINT [FK_University_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [tpdm].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_University_FederalLocaleCodeDescriptor]
ON [tpdm].[University] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[University] WITH CHECK ADD CONSTRAINT [FK_University_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_University_School]
ON [tpdm].[University] ([SchoolId] ASC)
GO

ALTER TABLE [tpdm].[ValueTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ValueTypeDescriptor_Descriptor] FOREIGN KEY ([ValueTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[WithdrawReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_WithdrawReasonDescriptor_Descriptor] FOREIGN KEY ([WithdrawReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

