ALTER TABLE [tpdm].[AccreditationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_AccreditationStatusDescriptor_Descriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[AidTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AidTypeDescriptor_Descriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[ApplicantProfile] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfile_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfile_CitizenshipStatusDescriptor]
ON [tpdm].[ApplicantProfile] ([CitizenshipStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfile] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfile_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfile_GenderDescriptor]
ON [tpdm].[ApplicantProfile] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfile] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfile_LevelOfEducationDescriptor] FOREIGN KEY ([HighestCompletedLevelOfEducationDescriptorId])
REFERENCES [edfi].[LevelOfEducationDescriptor] ([LevelOfEducationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfile_LevelOfEducationDescriptor]
ON [tpdm].[ApplicantProfile] ([HighestCompletedLevelOfEducationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfile] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfile_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfile_SexDescriptor]
ON [tpdm].[ApplicantProfile] ([SexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileAddress_AddressTypeDescriptor]
ON [tpdm].[ApplicantProfileAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddress_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileAddress_ApplicantProfile]
ON [tpdm].[ApplicantProfileAddress] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileAddress_LocaleDescriptor]
ON [tpdm].[ApplicantProfileAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileAddress_StateAbbreviationDescriptor]
ON [tpdm].[ApplicantProfileAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddressPeriod_ApplicantProfileAddress] FOREIGN KEY ([AddressTypeDescriptorId], [ApplicantProfileIdentifier], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [tpdm].[ApplicantProfileAddress] ([AddressTypeDescriptorId], [ApplicantProfileIdentifier], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileAddressPeriod_ApplicantProfileAddress]
ON [tpdm].[ApplicantProfileAddressPeriod] ([AddressTypeDescriptorId] ASC, [ApplicantProfileIdentifier] ASC, [City] ASC, [PostalCode] ASC, [StateAbbreviationDescriptorId] ASC, [StreetNumberName] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileApplicantCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileApplicantCharacteristic_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileApplicantCharacteristic_ApplicantProfile]
ON [tpdm].[ApplicantProfileApplicantCharacteristic] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileApplicantCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileApplicantCharacteristic_StudentCharacteristicDescriptor] FOREIGN KEY ([StudentCharacteristicDescriptorId])
REFERENCES [edfi].[StudentCharacteristicDescriptor] ([StudentCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileApplicantCharacteristic_StudentCharacteristicDescriptor]
ON [tpdm].[ApplicantProfileApplicantCharacteristic] ([StudentCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileBackgroundCheck_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileBackgroundCheck_ApplicantProfile]
ON [tpdm].[ApplicantProfileBackgroundCheck] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [tpdm].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [tpdm].[ApplicantProfileBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [tpdm].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [tpdm].[ApplicantProfileBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisability_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileDisability_ApplicantProfile]
ON [tpdm].[ApplicantProfileDisability] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileDisability_DisabilityDescriptor]
ON [tpdm].[ApplicantProfileDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [tpdm].[ApplicantProfileDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisabilityDesignation_ApplicantProfileDisability] FOREIGN KEY ([ApplicantProfileIdentifier], [DisabilityDescriptorId])
REFERENCES [tpdm].[ApplicantProfileDisability] ([ApplicantProfileIdentifier], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileDisabilityDesignation_ApplicantProfileDisability]
ON [tpdm].[ApplicantProfileDisabilityDesignation] ([ApplicantProfileIdentifier] ASC, [DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileDisabilityDesignation_DisabilityDesignationDescriptor]
ON [tpdm].[ApplicantProfileDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileEducatorPreparationProgramName] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileEducatorPreparationProgramName_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileEducatorPreparationProgramName_ApplicantProfile]
ON [tpdm].[ApplicantProfileEducatorPreparationProgramName] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileElectronicMail_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileElectronicMail_ApplicantProfile]
ON [tpdm].[ApplicantProfileElectronicMail] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileElectronicMail_ElectronicMailTypeDescriptor]
ON [tpdm].[ApplicantProfileElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileGradePointAverage_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileGradePointAverage_ApplicantProfile]
ON [tpdm].[ApplicantProfileGradePointAverage] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileGradePointAverage_GradePointAverageTypeDescriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[GradePointAverageTypeDescriptor] ([GradePointAverageTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileGradePointAverage_GradePointAverageTypeDescriptor]
ON [tpdm].[ApplicantProfileGradePointAverage] ([GradePointAverageTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileHighlyQualifiedAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileHighlyQualifiedAcademicSubject_AcademicSubjectDescriptor]
ON [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileHighlyQualifiedAcademicSubject_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileHighlyQualifiedAcademicSubject_ApplicantProfile]
ON [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileIdentificationDocument_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileIdentificationDocument_ApplicantProfile]
ON [tpdm].[ApplicantProfileIdentificationDocument] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileIdentificationDocument_CountryDescriptor]
ON [tpdm].[ApplicantProfileIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[ApplicantProfileIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[ApplicantProfileIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileInternationalAddress_AddressTypeDescriptor]
ON [tpdm].[ApplicantProfileInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileInternationalAddress_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileInternationalAddress_ApplicantProfile]
ON [tpdm].[ApplicantProfileInternationalAddress] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileInternationalAddress_CountryDescriptor]
ON [tpdm].[ApplicantProfileInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileLanguage] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileLanguage_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileLanguage_ApplicantProfile]
ON [tpdm].[ApplicantProfileLanguage] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileLanguage] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileLanguage_LanguageDescriptor]
ON [tpdm].[ApplicantProfileLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileLanguageUse_ApplicantProfileLanguage] FOREIGN KEY ([ApplicantProfileIdentifier], [LanguageDescriptorId])
REFERENCES [tpdm].[ApplicantProfileLanguage] ([ApplicantProfileIdentifier], [LanguageDescriptorId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileLanguageUse_ApplicantProfileLanguage]
ON [tpdm].[ApplicantProfileLanguageUse] ([ApplicantProfileIdentifier] ASC, [LanguageDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileLanguageUse_LanguageUseDescriptor]
ON [tpdm].[ApplicantProfileLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfilePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfilePersonalIdentificationDocument_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfilePersonalIdentificationDocument_ApplicantProfile]
ON [tpdm].[ApplicantProfilePersonalIdentificationDocument] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfilePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfilePersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfilePersonalIdentificationDocument_CountryDescriptor]
ON [tpdm].[ApplicantProfilePersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfilePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfilePersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfilePersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[ApplicantProfilePersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfilePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfilePersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfilePersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[ApplicantProfilePersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileRace] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileRace_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileRace_ApplicantProfile]
ON [tpdm].[ApplicantProfileRace] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileRace] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileRace_RaceDescriptor]
ON [tpdm].[ApplicantProfileRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileTelephone] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileTelephone_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileTelephone_ApplicantProfile]
ON [tpdm].[ApplicantProfileTelephone] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileTelephone] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileTelephone_TelephoneNumberTypeDescriptor]
ON [tpdm].[ApplicantProfileTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileVisa] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileVisa_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileVisa_ApplicantProfile]
ON [tpdm].[ApplicantProfileVisa] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicantProfileVisa] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileVisa_VisaDescriptor]
ON [tpdm].[ApplicantProfileVisa] ([VisaDescriptorId] ASC)
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

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [tpdm].[ApplicantProfile] ([ApplicantProfileIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_Application_ApplicantProfile]
ON [tpdm].[Application] ([ApplicantProfileIdentifier] ASC)
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

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_Application_OpenStaffPosition]
ON [tpdm].[Application] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
GO

ALTER TABLE [tpdm].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_WithdrawReasonDescriptor] FOREIGN KEY ([WithdrawReasonDescriptorId])
REFERENCES [tpdm].[WithdrawReasonDescriptor] ([WithdrawReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_WithdrawReasonDescriptor]
ON [tpdm].[Application] ([WithdrawReasonDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_Application]
ON [tpdm].[ApplicationEvent] ([ApplicantProfileIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
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

ALTER TABLE [tpdm].[ApplicationRecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ApplicationRecruitmentEventAttendance_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationRecruitmentEventAttendance_Application]
ON [tpdm].[ApplicationRecruitmentEventAttendance] ([ApplicantProfileIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[ApplicationRecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ApplicationRecruitmentEventAttendance_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationRecruitmentEventAttendance_RecruitmentEventAttendance]
ON [tpdm].[ApplicationRecruitmentEventAttendance] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [tpdm].[ApplicationScoreResult] WITH CHECK ADD CONSTRAINT [FK_ApplicationScoreResult_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationScoreResult_Application]
ON [tpdm].[ApplicationScoreResult] ([ApplicantProfileIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
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

ALTER TABLE [tpdm].[ApplicationTerm] WITH CHECK ADD CONSTRAINT [FK_ApplicationTerm_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationTerm_Application]
ON [tpdm].[ApplicationTerm] ([ApplicantProfileIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
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

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [tpdm].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_Application]
ON [tpdm].[Candidate] ([ApplicantProfileIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_CitizenshipStatusDescriptor]
ON [tpdm].[Candidate] ([CitizenshipStatusDescriptorId] ASC)
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

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_OldEthnicityDescriptor] FOREIGN KEY ([OldEthnicityDescriptorId])
REFERENCES [edfi].[OldEthnicityDescriptor] ([OldEthnicityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_OldEthnicityDescriptor]
ON [tpdm].[Candidate] ([OldEthnicityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_Person]
ON [tpdm].[Candidate] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_PreviousCareerDescriptor] FOREIGN KEY ([PreviousCareerDescriptorId])
REFERENCES [tpdm].[PreviousCareerDescriptor] ([PreviousCareerDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_PreviousCareerDescriptor]
ON [tpdm].[Candidate] ([PreviousCareerDescriptorId] ASC)
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

CREATE NONCLUSTERED INDEX [FK_CandidateAddress_Candidate]
ON [tpdm].[CandidateAddress] ([CandidateIdentifier] ASC)
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

ALTER TABLE [tpdm].[CandidateAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_CandidateAddressPeriod_CandidateAddress] FOREIGN KEY ([AddressTypeDescriptorId], [CandidateIdentifier], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [tpdm].[CandidateAddress] ([AddressTypeDescriptorId], [CandidateIdentifier], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAddressPeriod_CandidateAddress]
ON [tpdm].[CandidateAddressPeriod] ([AddressTypeDescriptorId] ASC, [CandidateIdentifier] ASC, [City] ASC, [PostalCode] ASC, [StateAbbreviationDescriptorId] ASC, [StreetNumberName] ASC)
GO

ALTER TABLE [tpdm].[CandidateAid] WITH CHECK ADD CONSTRAINT [FK_CandidateAid_AidTypeDescriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [tpdm].[AidTypeDescriptor] ([AidTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAid_AidTypeDescriptor]
ON [tpdm].[CandidateAid] ([AidTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateAid] WITH CHECK ADD CONSTRAINT [FK_CandidateAid_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAid_Candidate]
ON [tpdm].[CandidateAid] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_CandidateBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [tpdm].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [tpdm].[CandidateBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_CandidateBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [tpdm].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [tpdm].[CandidateBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_CandidateBackgroundCheck_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CandidateCharacteristic_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateCharacteristic_Candidate]
ON [tpdm].[CandidateCharacteristic] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CandidateCharacteristic_CandidateCharacteristicDescriptor] FOREIGN KEY ([CandidateCharacteristicDescriptorId])
REFERENCES [tpdm].[CandidateCharacteristicDescriptor] ([CandidateCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateCharacteristic_CandidateCharacteristicDescriptor]
ON [tpdm].[CandidateCharacteristic] ([CandidateCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_CandidateCharacteristicDescriptor_Descriptor] FOREIGN KEY ([CandidateCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateCohortYear_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateCohortYear_Candidate]
ON [tpdm].[CandidateCohortYear] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateCohortYear_CohortYearTypeDescriptor] FOREIGN KEY ([CohortYearTypeDescriptorId])
REFERENCES [edfi].[CohortYearTypeDescriptor] ([CohortYearTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateCohortYear_CohortYearTypeDescriptor]
ON [tpdm].[CandidateCohortYear] ([CohortYearTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateCohortYear_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateCohortYear_SchoolYearType]
ON [tpdm].[CandidateCohortYear] ([SchoolYear] ASC)
GO

ALTER TABLE [tpdm].[CandidateDegreeSpecialization] WITH CHECK ADD CONSTRAINT [FK_CandidateDegreeSpecialization_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateDegreeSpecialization_Candidate]
ON [tpdm].[CandidateDegreeSpecialization] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateDisability] WITH CHECK ADD CONSTRAINT [FK_CandidateDisability_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateDisability_Candidate]
ON [tpdm].[CandidateDisability] ([CandidateIdentifier] ASC)
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

CREATE NONCLUSTERED INDEX [FK_CandidateDisabilityDesignation_CandidateDisability]
ON [tpdm].[CandidateDisabilityDesignation] ([CandidateIdentifier] ASC, [DisabilityDescriptorId] ASC)
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

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCandidateIndicator_CandidateEducatorPreparationProgramAssociation] FOREIGN KEY ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[CandidateEducatorPreparationProgramAssociation] ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod_CandidateEducatorPreparationProgramAssociationCandidat] FOREIGN KEY ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[CandidateElectronicMail] WITH CHECK ADD CONSTRAINT [FK_CandidateElectronicMail_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateElectronicMail_Candidate]
ON [tpdm].[CandidateElectronicMail] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateElectronicMail] WITH CHECK ADD CONSTRAINT [FK_CandidateElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateElectronicMail_ElectronicMailTypeDescriptor]
ON [tpdm].[CandidateElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_CandidateEPPProgramDegree_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEPPProgramDegree_AcademicSubjectDescriptor]
ON [tpdm].[CandidateEPPProgramDegree] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_CandidateEPPProgramDegree_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEPPProgramDegree_Candidate]
ON [tpdm].[CandidateEPPProgramDegree] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateEPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_CandidateEPPProgramDegree_EPPDegreeTypeDescriptor] FOREIGN KEY ([EPPDegreeTypeDescriptorId])
REFERENCES [tpdm].[EPPDegreeTypeDescriptor] ([EPPDegreeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEPPProgramDegree_EPPDegreeTypeDescriptor]
ON [tpdm].[CandidateEPPProgramDegree] ([EPPDegreeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateEPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_CandidateEPPProgramDegree_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEPPProgramDegree_GradeLevelDescriptor]
ON [tpdm].[CandidateEPPProgramDegree] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationCode_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationCode_Candidate]
ON [tpdm].[CandidateIdentificationCode] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationCode_StudentIdentificationSystemDescriptor] FOREIGN KEY ([StudentIdentificationSystemDescriptorId])
REFERENCES [edfi].[StudentIdentificationSystemDescriptor] ([StudentIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationCode_StudentIdentificationSystemDescriptor]
ON [tpdm].[CandidateIdentificationCode] ([StudentIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationDocument_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationDocument_Candidate]
ON [tpdm].[CandidateIdentificationDocument] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationDocument_CountryDescriptor]
ON [tpdm].[CandidateIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[CandidateIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[CandidateIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateIndicator] WITH CHECK ADD CONSTRAINT [FK_CandidateIndicator_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIndicator_Candidate]
ON [tpdm].[CandidateIndicator] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateIndicatorPeriod] WITH CHECK ADD CONSTRAINT [FK_CandidateIndicatorPeriod_CandidateIndicator] FOREIGN KEY ([CandidateIdentifier], [IndicatorName])
REFERENCES [tpdm].[CandidateIndicator] ([CandidateIdentifier], [IndicatorName])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIndicatorPeriod_CandidateIndicator]
ON [tpdm].[CandidateIndicatorPeriod] ([CandidateIdentifier] ASC, [IndicatorName] ASC)
GO

ALTER TABLE [tpdm].[CandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateInternationalAddress_AddressTypeDescriptor]
ON [tpdm].[CandidateInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateInternationalAddress_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateInternationalAddress_Candidate]
ON [tpdm].[CandidateInternationalAddress] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateInternationalAddress_CountryDescriptor]
ON [tpdm].[CandidateInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateLanguage] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguage_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateLanguage_Candidate]
ON [tpdm].[CandidateLanguage] ([CandidateIdentifier] ASC)
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

CREATE NONCLUSTERED INDEX [FK_CandidateLanguageUse_CandidateLanguage]
ON [tpdm].[CandidateLanguageUse] ([CandidateIdentifier] ASC, [LanguageDescriptorId] ASC)
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

CREATE NONCLUSTERED INDEX [FK_CandidateOtherName_Candidate]
ON [tpdm].[CandidateOtherName] ([CandidateIdentifier] ASC)
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

CREATE NONCLUSTERED INDEX [FK_CandidatePersonalIdentificationDocument_Candidate]
ON [tpdm].[CandidatePersonalIdentificationDocument] ([CandidateIdentifier] ASC)
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

CREATE NONCLUSTERED INDEX [FK_CandidateRace_Candidate]
ON [tpdm].[CandidateRace] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateRace] WITH CHECK ADD CONSTRAINT [FK_CandidateRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateRace_RaceDescriptor]
ON [tpdm].[CandidateRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateRelationshipToStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateRelationshipToStaffAssociation_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateRelationshipToStaffAssociation_Candidate]
ON [tpdm].[CandidateRelationshipToStaffAssociation] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateRelationshipToStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateRelationshipToStaffAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateRelationshipToStaffAssociation_Staff]
ON [tpdm].[CandidateRelationshipToStaffAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[CandidateRelationshipToStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateRelationshipToStaffAssociation_StaffToCandidateRelationshipDescriptor] FOREIGN KEY ([StaffToCandidateRelationshipDescriptorId])
REFERENCES [tpdm].[StaffToCandidateRelationshipDescriptor] ([StaffToCandidateRelationshipDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateRelationshipToStaffAssociation_StaffToCandidateRelationshipDescriptor]
ON [tpdm].[CandidateRelationshipToStaffAssociation] ([StaffToCandidateRelationshipDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateTelephone] WITH CHECK ADD CONSTRAINT [FK_CandidateTelephone_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateTelephone_Candidate]
ON [tpdm].[CandidateTelephone] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateTelephone] WITH CHECK ADD CONSTRAINT [FK_CandidateTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateTelephone_TelephoneNumberTypeDescriptor]
ON [tpdm].[CandidateTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[CandidateVisa] WITH CHECK ADD CONSTRAINT [FK_CandidateVisa_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [tpdm].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CandidateVisa_Candidate]
ON [tpdm].[CandidateVisa] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [tpdm].[CandidateVisa] WITH CHECK ADD CONSTRAINT [FK_CandidateVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateVisa_VisaDescriptor]
ON [tpdm].[CandidateVisa] ([VisaDescriptorId] ASC)
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

ALTER TABLE [tpdm].[EducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgram_EducatorPreparationProgramTypeDescriptor] FOREIGN KEY ([EducatorPreparationProgramTypeDescriptorId])
REFERENCES [tpdm].[EducatorPreparationProgramTypeDescriptor] ([EducatorPreparationProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgram_EducatorPreparationProgramTypeDescriptor]
ON [tpdm].[EducatorPreparationProgram] ([EducatorPreparationProgramTypeDescriptorId] ASC)
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

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgramGradeLevel_EducatorPreparationProgram]
ON [tpdm].[EducatorPreparationProgramGradeLevel] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EducatorPreparationProgramGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgramGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgramGradeLevel_GradeLevelDescriptor]
ON [tpdm].[EducatorPreparationProgramGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[EducatorPreparationProgramTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgramTypeDescriptor_Descriptor] FOREIGN KEY ([EducatorPreparationProgramTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EducatorRoleDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducatorRoleDescriptor_Descriptor] FOREIGN KEY ([EducatorRoleDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EnglishLanguageExamDescriptor] WITH CHECK ADD CONSTRAINT [FK_EnglishLanguageExamDescriptor_Descriptor] FOREIGN KEY ([EnglishLanguageExamDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[EPPDegreeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EPPDegreeTypeDescriptor_Descriptor] FOREIGN KEY ([EPPDegreeTypeDescriptorId])
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

ALTER TABLE [tpdm].[EvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewer_Person] FOREIGN KEY ([ReviewerPersonId], [ReviewerSourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingReviewer_Person]
ON [tpdm].[EvaluationRatingReviewer] ([ReviewerPersonId] ASC, [ReviewerSourceSystemDescriptorId] ASC)
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

ALTER TABLE [tpdm].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperience_EducatorPreparationProgram]
ON [tpdm].[FieldworkExperience] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
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

ALTER TABLE [tpdm].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperience_School]
ON [tpdm].[FieldworkExperience] ([SchoolId] ASC)
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

ALTER TABLE [tpdm].[LengthOfContractDescriptor] WITH CHECK ADD CONSTRAINT [FK_LengthOfContractDescriptor_Descriptor] FOREIGN KEY ([LengthOfContractDescriptorId])
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

ALTER TABLE [tpdm].[PerformanceEvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewer_Person] FOREIGN KEY ([ReviewerPersonId], [ReviewerSourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingReviewer_Person]
ON [tpdm].[PerformanceEvaluationRatingReviewer] ([ReviewerPersonId] ASC, [ReviewerSourceSystemDescriptorId] ASC)
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

ALTER TABLE [tpdm].[RecruitmentEvent] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEvent_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEvent_EducationOrganization]
ON [tpdm].[RecruitmentEvent] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEvent] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEvent_RecruitmentEventTypeDescriptor] FOREIGN KEY ([RecruitmentEventTypeDescriptorId])
REFERENCES [tpdm].[RecruitmentEventTypeDescriptor] ([RecruitmentEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEvent_RecruitmentEventTypeDescriptor]
ON [tpdm].[RecruitmentEvent] ([RecruitmentEventTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendance_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendance_GenderDescriptor]
ON [tpdm].[RecruitmentEventAttendance] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendance_RecruitmentEvent] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle])
REFERENCES [tpdm].[RecruitmentEvent] ([EducationOrganizationId], [EventDate], [EventTitle])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendance_RecruitmentEvent]
ON [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendance_RecruitmentEventAttendeeTypeDescriptor] FOREIGN KEY ([RecruitmentEventAttendeeTypeDescriptorId])
REFERENCES [tpdm].[RecruitmentEventAttendeeTypeDescriptor] ([RecruitmentEventAttendeeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendance_RecruitmentEventAttendeeTypeDescriptor]
ON [tpdm].[RecruitmentEventAttendance] ([RecruitmentEventAttendeeTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendance_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendance_SexDescriptor]
ON [tpdm].[RecruitmentEventAttendance] ([SexDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceCurrentPosition] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceCurrentPosition_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceCurrentPosition_AcademicSubjectDescriptor]
ON [tpdm].[RecruitmentEventAttendanceCurrentPosition] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceCurrentPosition] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceCurrentPosition_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceCurrentPositionGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceCurrentPositionGradeLevel_GradeLevelDescriptor]
ON [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceCurrentPositionGradeLevel_RecruitmentEventAttendanceCurrentPosition] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendanceCurrentPosition] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceCurrentPositionGradeLevel_RecruitmentEventAttendanceCurrentPosition]
ON [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceDisability] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceDisability_DisabilityDescriptor]
ON [tpdm].[RecruitmentEventAttendanceDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceDisability] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [tpdm].[RecruitmentEventAttendanceDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceDisability] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisability_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceDisability_RecruitmentEventAttendance]
ON [tpdm].[RecruitmentEventAttendanceDisability] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceDisabilityDesignation_DisabilityDesignationDescriptor]
ON [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisabilityDesignation_RecruitmentEventAttendanceDisability] FOREIGN KEY ([DisabilityDescriptorId], [EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendanceDisability] ([DisabilityDescriptorId], [EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceDisabilityDesignation_RecruitmentEventAttendanceDisability]
ON [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] ([DisabilityDescriptorId] ASC, [EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendancePersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendancePersonalIdentificationDocument_CountryDescriptor]
ON [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendancePersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendancePersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendancePersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendancePersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendancePersonalIdentificationDocument_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendancePersonalIdentificationDocument_RecruitmentEventAttendance]
ON [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceRace] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceRace_RaceDescriptor]
ON [tpdm].[RecruitmentEventAttendanceRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceRace] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceRace_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceRace_RecruitmentEventAttendance]
ON [tpdm].[RecruitmentEventAttendanceRace] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceTelephone] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceTelephone_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceTelephone_RecruitmentEventAttendance]
ON [tpdm].[RecruitmentEventAttendanceTelephone] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceTelephone] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceTelephone_TelephoneNumberTypeDescriptor]
ON [tpdm].[RecruitmentEventAttendanceTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendanceTouchpoint] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceTouchpoint_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [tpdm].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceTouchpoint_RecruitmentEventAttendance]
ON [tpdm].[RecruitmentEventAttendanceTouchpoint] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [tpdm].[RecruitmentEventAttendeeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendeeTypeDescriptor_Descriptor] FOREIGN KEY ([RecruitmentEventAttendeeTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
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

ALTER TABLE [tpdm].[SchoolExtension] WITH CHECK ADD CONSTRAINT [FK_SchoolExtension_AccreditationStatusDescriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [tpdm].[AccreditationStatusDescriptor] ([AccreditationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolExtension_AccreditationStatusDescriptor]
ON [tpdm].[SchoolExtension] ([AccreditationStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[SchoolExtension] WITH CHECK ADD CONSTRAINT [FK_SchoolExtension_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [tpdm].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolExtension_FederalLocaleCodeDescriptor]
ON [tpdm].[SchoolExtension] ([FederalLocaleCodeDescriptorId] ASC)
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

ALTER TABLE [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociationExtension_StaffEducationOrganizationAssignmentAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [StaffClassificationDescriptorId], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationAssignmentAssociation] ([BeginDate], [EducationOrganizationId], [StaffClassificationDescriptorId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [tpdm].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [tpdm].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_StaffEducationOrganizationEmploymentAssociation]
ON [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] ([EducationOrganizationId] ASC, [EmploymentStatusDescriptorId] ASC, [HireDate] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationExtension_LengthOfContractDescriptor] FOREIGN KEY ([LengthOfContractDescriptorId])
REFERENCES [tpdm].[LengthOfContractDescriptor] ([LengthOfContractDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationExtension_LengthOfContractDescriptor]
ON [tpdm].[StaffEducationOrganizationEmploymentAssociationExtension] ([LengthOfContractDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationExtension_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationSalary] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationSalary_SalaryTypeDescriptor] FOREIGN KEY ([SalaryTypeDescriptorId])
REFERENCES [tpdm].[SalaryTypeDescriptor] ([SalaryTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationSalary_SalaryTypeDescriptor]
ON [tpdm].[StaffEducationOrganizationEmploymentAssociationSalary] ([SalaryTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationSalary] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationSalary_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationSeniority_CredentialFieldDescriptor] FOREIGN KEY ([CredentialFieldDescriptorId])
REFERENCES [edfi].[CredentialFieldDescriptor] ([CredentialFieldDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationSeniority_CredentialFieldDescriptor]
ON [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] ([CredentialFieldDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationSeniority_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationSeniority_StaffEducationOrganizationEmploymentAssociation]
ON [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] ([EducationOrganizationId] ASC, [EmploymentStatusDescriptorId] ASC, [HireDate] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffEducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorPreparationProgram_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducatorPreparationProgram_EducatorPreparationProgram]
ON [tpdm].[StaffEducatorPreparationProgram] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffEducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorPreparationProgram_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducatorPreparationProgram_Staff]
ON [tpdm].[StaffEducatorPreparationProgram] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorPreparationProgramAssociation_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [tpdm].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducatorPreparationProgramAssociation_EducatorPreparationProgram]
ON [tpdm].[StaffEducatorPreparationProgramAssociation] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorPreparationProgramAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducatorPreparationProgramAssociation_Staff]
ON [tpdm].[StaffEducatorPreparationProgramAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [tpdm].[StaffEducatorResearch] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorResearch_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [tpdm].[StaffExtension] WITH CHECK ADD CONSTRAINT [FK_StaffExtension_GenderDescriptor] FOREIGN KEY ([GenderDescriptorId])
REFERENCES [tpdm].[GenderDescriptor] ([GenderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffExtension_GenderDescriptor]
ON [tpdm].[StaffExtension] ([GenderDescriptorId] ASC)
GO

ALTER TABLE [tpdm].[StaffExtension] WITH CHECK ADD CONSTRAINT [FK_StaffExtension_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_StaffExtension_OpenStaffPosition]
ON [tpdm].[StaffExtension] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
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

ALTER TABLE [tpdm].[StaffToCandidateRelationshipDescriptor] WITH CHECK ADD CONSTRAINT [FK_StaffToCandidateRelationshipDescriptor_Descriptor] FOREIGN KEY ([StaffToCandidateRelationshipDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
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

ALTER TABLE [tpdm].[WithdrawReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_WithdrawReasonDescriptor_Descriptor] FOREIGN KEY ([WithdrawReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

