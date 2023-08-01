-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [tpdm].[AccreditationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_AccreditationStatusDescriptor_Descriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[AidTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AidTypeDescriptor_Descriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_CountryDescriptor] FOREIGN KEY ([BirthCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_CountryDescriptor]
ON [tpdm].[Candidate] ([BirthCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_EnglishLanguageExamDescriptor] FOREIGN KEY ([EnglishLanguageExamDescriptorId])
REFERENCES [tpdm].[EnglishLanguageExamDescriptor] ([EnglishLanguageExamDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_EnglishLanguageExamDescriptor]
ON [tpdm].[Candidate] ([EnglishLanguageExamDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_GenderDescriptor]
ON [tpdm].[Candidate] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_LimitedEnglishProficiencyDescriptor] FOREIGN KEY ([LimitedEnglishProficiencyDescriptorId])
REFERENCES [edfi].[LimitedEnglishProficiencyDescriptor] ([LimitedEnglishProficiencyDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_LimitedEnglishProficiencyDescriptor]
ON [tpdm].[Candidate] ([LimitedEnglishProficiencyDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_Person]
ON [tpdm].[Candidate] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_SexDescriptor]
ON [tpdm].[Candidate] ([SexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_SexDescriptor1] FOREIGN KEY ([BirthSexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_SexDescriptor1]
ON [tpdm].[Candidate] ([BirthSexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_StateAbbreviationDescriptor] FOREIGN KEY ([BirthStateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_StateAbbreviationDescriptor]
ON [tpdm].[Candidate] ([BirthStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAddress_AddressTypeDescriptor]
ON [tpdm].[CandidateAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateAddress_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAddress_LocaleDescriptor]
ON [tpdm].[CandidateAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAddress_StateAbbreviationDescriptor]
ON [tpdm].[CandidateAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_CandidateAddressPeriod_CandidateAddress] FOREIGN KEY ([CandidateIdentifier], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [tpdm].[CandidateAddress] ([CandidateIdentifier], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateDisability] WITH CHECK ADD CONSTRAINT [FK_CandidateDisability_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateDisability] WITH CHECK ADD CONSTRAINT [FK_CandidateDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateDisability_DisabilityDescriptor]
ON [tpdm].[CandidateDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateDisability] WITH CHECK ADD CONSTRAINT [FK_CandidateDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [tpdm].[CandidateDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_CandidateDisabilityDesignation_CandidateDisability] FOREIGN KEY ([CandidateIdentifier], [DisabilityDescriptorId])
REFERENCES [tpdm].[CandidateDisability] ([CandidateIdentifier], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_CandidateDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateDisabilityDesignation_DisabilityDesignationDescriptor]
ON [tpdm].[CandidateDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_Candidate]
ON [tpdm].[CandidateEducatorPreparationProgramAssociation] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_EducatorPreparationProgram]
ON [tpdm].[CandidateEducatorPreparationProgramAssociation] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_EPPProgramPathwayDescriptor] FOREIGN KEY ([EPPProgramPathwayDescriptorId])
REFERENCES [tpdm].[EPPProgramPathwayDescriptor] ([EPPProgramPathwayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_EPPProgramPathwayDescriptor]
ON [tpdm].[CandidateEducatorPreparationProgramAssociation] ([EPPProgramPathwayDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_ReasonExitedDescriptor] FOREIGN KEY ([ReasonExitedDescriptorId])
REFERENCES [edfi].[ReasonExitedDescriptor] ([ReasonExitedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_ReasonExitedDescriptor]
ON [tpdm].[CandidateEducatorPreparationProgramAssociation] ([ReasonExitedDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCohortYear_CandidateEducatorPreparationProgramAssociation] FOREIGN KEY ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[CandidateEducatorPreparationProgramAssociation] ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCohortYear_CohortYearTypeDescriptor] FOREIGN KEY ([CohortYearTypeDescriptorId])
REFERENCES [edfi].[CohortYearTypeDescriptor] ([CohortYearTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociationCohortYear_CohortYearTypeDescriptor]
ON [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] ([CohortYearTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCohortYear_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociationCohortYear_SchoolYearType]
ON [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCohortYear_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociationCohortYear_TermDescriptor]
ON [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] ([TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationDegreeSpecialization_CandidateEducatorPreparationProgramAssociation] FOREIGN KEY ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[CandidateEducatorPreparationProgramAssociation] ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateElectronicMail] WITH CHECK ADD CONSTRAINT [FK_CandidateElectronicMail_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateElectronicMail] WITH CHECK ADD CONSTRAINT [FK_CandidateElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateElectronicMail_ElectronicMailTypeDescriptor]
ON [tpdm].[CandidateElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateLanguage] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguage_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateLanguage] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateLanguage_LanguageDescriptor]
ON [tpdm].[CandidateLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateLanguageUse] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguageUse_CandidateLanguage] FOREIGN KEY ([CandidateIdentifier], [LanguageDescriptorId])
REFERENCES [tpdm].[CandidateLanguage] ([CandidateIdentifier], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateLanguageUse] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateLanguageUse_LanguageUseDescriptor]
ON [tpdm].[CandidateLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateOtherName] WITH CHECK ADD CONSTRAINT [FK_CandidateOtherName_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateOtherName] WITH CHECK ADD CONSTRAINT [FK_CandidateOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateOtherName_OtherNameTypeDescriptor]
ON [tpdm].[CandidateOtherName] ([OtherNameTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidatePersonalIdentificationDocument_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidatePersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidatePersonalIdentificationDocument_CountryDescriptor]
ON [tpdm].[CandidatePersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidatePersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidatePersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[CandidatePersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidatePersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidatePersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[CandidatePersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateRace] WITH CHECK ADD CONSTRAINT [FK_CandidateRace_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateRace] WITH CHECK ADD CONSTRAINT [FK_CandidateRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateRace_RaceDescriptor]
ON [tpdm].[CandidateRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateTelephone] WITH CHECK ADD CONSTRAINT [FK_CandidateTelephone_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateTelephone] WITH CHECK ADD CONSTRAINT [FK_CandidateTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateTelephone_TelephoneNumberTypeDescriptor]
ON [tpdm].[CandidateTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CertificationRouteDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationRouteDescriptor_Descriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CoteachingStyleObservedDescriptor] WITH CHECK ADD CONSTRAINT [FK_CoteachingStyleObservedDescriptor_Descriptor] FOREIGN KEY ([CoteachingStyleObservedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
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

ALTER TABLE [tpdm].[CredentialExtension] WITH CHECK ADD CONSTRAINT [FK_CredentialExtension_EducatorRoleDescriptor] FOREIGN KEY ([EducatorRoleDescriptorId])
REFERENCES [tpdm].[EducatorRoleDescriptor] ([EducatorRoleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialExtension_EducatorRoleDescriptor]
ON [tpdm].[CredentialExtension] ([EducatorRoleDescriptorId] ASC)
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

ALTER TABLE [tpdm].[CredentialStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_CredentialStudentAcademicRecord_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialStudentAcademicRecord_StudentAcademicRecord]
ON [tpdm].[CredentialStudentAcademicRecord] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [StudentUSI] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgram_AccreditationStatusDescriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [tpdm].[AccreditationStatusDescriptor] ([AccreditationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgram_AccreditationStatusDescriptor]
ON [tpdm].[EducatorPreparationProgram] ([AccreditationStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgram_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgram_EducationOrganization]
ON [tpdm].[EducatorPreparationProgram] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[EducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgram_ProgramTypeDescriptor] FOREIGN KEY ([ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramTypeDescriptor] ([ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgram_ProgramTypeDescriptor]
ON [tpdm].[EducatorPreparationProgram] ([ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EducatorPreparationProgramGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgramGradeLevel_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EducatorPreparationProgramGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgramGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgramGradeLevel_GradeLevelDescriptor]
ON [tpdm].[EducatorPreparationProgramGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EducatorRoleDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducatorRoleDescriptor_Descriptor] FOREIGN KEY ([EducatorRoleDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EnglishLanguageExamDescriptor] WITH CHECK ADD CONSTRAINT [FK_EnglishLanguageExamDescriptor_Descriptor] FOREIGN KEY ([EnglishLanguageExamDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EPPProgramPathwayDescriptor] WITH CHECK ADD CONSTRAINT [FK_EPPProgramPathwayDescriptor_Descriptor] FOREIGN KEY ([EPPProgramPathwayDescriptorId])
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

ALTER TABLE [tpdm].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_EvaluationRatingStatusDescriptor] FOREIGN KEY ([EvaluationRatingStatusDescriptorId])
REFERENCES [tpdm].[EvaluationRatingStatusDescriptor] ([EvaluationRatingStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_EvaluationRatingStatusDescriptor]
ON [tpdm].[EvaluationRating] ([EvaluationRatingStatusDescriptorId] ASC)
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

ALTER TABLE [tpdm].[EvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewer_Person] FOREIGN KEY ([ReviewerPersonId], [ReviewerSourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingReviewer_Person]
ON [tpdm].[EvaluationRatingReviewer] ([ReviewerPersonId] ASC, [ReviewerSourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EvaluationRatingReviewerReceivedTraining] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewerReceivedTraining_EvaluationRatingReviewer] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId], [FirstName], [LastSurname])
REFERENCES [tpdm].[EvaluationRatingReviewer] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId], [FirstName], [LastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EvaluationRatingStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingStatusDescriptor_Descriptor] FOREIGN KEY ([EvaluationRatingStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[FinancialAid] WITH CHECK ADD CONSTRAINT [FK_FinancialAid_AidTypeDescriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [tpdm].[AidTypeDescriptor] ([AidTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FinancialAid_AidTypeDescriptor]
ON [tpdm].[FinancialAid] ([AidTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[FinancialAid] WITH CHECK ADD CONSTRAINT [FK_FinancialAid_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_FinancialAid_Student]
ON [tpdm].[FinancialAid] ([StudentUSI] ASC)
GO

ALTER TABLE [tpdm].[GenderDescriptor] WITH CHECK ADD CONSTRAINT [FK_GenderDescriptor_Descriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ObjectiveRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_ObjectiveRatingLevelDescriptor_Descriptor] FOREIGN KEY ([ObjectiveRatingLevelDescriptorId])
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

ALTER TABLE [tpdm].[PerformanceEvaluationRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingLevelDescriptor_Descriptor] FOREIGN KEY ([PerformanceEvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingResult_PerformanceEvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [tpdm].[PerformanceEvaluationRating] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
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

ALTER TABLE [tpdm].[PerformanceEvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewer_Person] FOREIGN KEY ([ReviewerPersonId], [ReviewerSourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingReviewer_Person]
ON [tpdm].[PerformanceEvaluationRatingReviewer] ([ReviewerPersonId] ASC, [ReviewerSourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewerReceivedTraining_PerformanceEvaluationRatingReviewer] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId], [FirstName], [LastSurname])
REFERENCES [tpdm].[PerformanceEvaluationRatingReviewer] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId], [FirstName], [LastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[PerformanceEvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([PerformanceEvaluationTypeDescriptorId])
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

ALTER TABLE [tpdm].[SchoolExtension] WITH CHECK ADD CONSTRAINT [FK_SchoolExtension_PostSecondaryInstitution] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[PostSecondaryInstitution] ([PostSecondaryInstitutionId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolExtension_PostSecondaryInstitution]
ON [tpdm].[SchoolExtension] ([PostSecondaryInstitutionId] ASC)
GO

ALTER TABLE [tpdm].[SchoolExtension] WITH CHECK ADD CONSTRAINT [FK_SchoolExtension_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[SurveyResponseExtension] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseExtension_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponseExtension_Person]
ON [tpdm].[SurveyResponseExtension] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[SurveyResponseExtension] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseExtension_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponsePersonTargetAssociation_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponsePersonTargetAssociation_Person]
ON [tpdm].[SurveyResponsePersonTargetAssociation] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[SurveyResponsePersonTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponsePersonTargetAssociation_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponsePersonTargetAssociation_SurveyResponse]
ON [tpdm].[SurveyResponsePersonTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC)
GO

ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponsePersonTargetAssociation_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponsePersonTargetAssociation_Person]
ON [tpdm].[SurveySectionResponsePersonTargetAssociation] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[SurveySectionResponsePersonTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponsePersonTargetAssociation_SurveySectionResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySectionResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponsePersonTargetAssociation_SurveySectionResponse]
ON [tpdm].[SurveySectionResponsePersonTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC, [SurveySectionTitle] ASC)
GO

