-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [edfi].[AbsenceEventCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AbsenceEventCategoryDescriptor_Descriptor] FOREIGN KEY ([AbsenceEventCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AcademicHonorCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AcademicHonorCategoryDescriptor_Descriptor] FOREIGN KEY ([AcademicHonorCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AcademicSubjectDescriptor] WITH CHECK ADD CONSTRAINT [FK_AcademicSubjectDescriptor_Descriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AcademicWeek] WITH CHECK ADD CONSTRAINT [FK_AcademicWeek_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[AccommodationDescriptor] WITH CHECK ADD CONSTRAINT [FK_AccommodationDescriptor_Descriptor] FOREIGN KEY ([AccommodationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AccountabilityRating] WITH CHECK ADD CONSTRAINT [FK_AccountabilityRating_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[AccountabilityRating] WITH CHECK ADD CONSTRAINT [FK_AccountabilityRating_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_AccountabilityRating_SchoolYearType]
ON [edfi].[AccountabilityRating] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[AccountTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AccountTypeDescriptor_Descriptor] FOREIGN KEY ([AccountTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AccreditationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_AccreditationStatusDescriptor_Descriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AchievementCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AchievementCategoryDescriptor_Descriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AdditionalCreditTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AdditionalCreditTypeDescriptor_Descriptor] FOREIGN KEY ([AdditionalCreditTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AddressTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AddressTypeDescriptor_Descriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AdministrationEnvironmentDescriptor] WITH CHECK ADD CONSTRAINT [FK_AdministrationEnvironmentDescriptor_Descriptor] FOREIGN KEY ([AdministrationEnvironmentDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AdministrativeFundingControlDescriptor] WITH CHECK ADD CONSTRAINT [FK_AdministrativeFundingControlDescriptor_Descriptor] FOREIGN KEY ([AdministrativeFundingControlDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AidTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_AidTypeDescriptor_Descriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AncestryEthnicOriginDescriptor] WITH CHECK ADD CONSTRAINT [FK_AncestryEthnicOriginDescriptor_Descriptor] FOREIGN KEY ([AncestryEthnicOriginDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfile] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfile_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfile_CitizenshipStatusDescriptor]
ON [edfi].[ApplicantProfile] ([CitizenshipStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfile] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfile_LevelOfEducationDescriptor] FOREIGN KEY ([HighestCompletedLevelOfEducationDescriptorId])
REFERENCES [edfi].[LevelOfEducationDescriptor] ([LevelOfEducationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfile_LevelOfEducationDescriptor]
ON [edfi].[ApplicantProfile] ([HighestCompletedLevelOfEducationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfile] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfile_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfile_SexDescriptor]
ON [edfi].[ApplicantProfile] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileAddress_AddressTypeDescriptor]
ON [edfi].[ApplicantProfileAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddress_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileAddress_LocaleDescriptor]
ON [edfi].[ApplicantProfileAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileAddress_StateAbbreviationDescriptor]
ON [edfi].[ApplicantProfileAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileAddressPeriod_ApplicantProfileAddress] FOREIGN KEY ([ApplicantProfileIdentifier], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[ApplicantProfileAddress] ([ApplicantProfileIdentifier], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileApplicantCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileApplicantCharacteristic_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileApplicantCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileApplicantCharacteristic_StudentCharacteristicDescriptor] FOREIGN KEY ([StudentCharacteristicDescriptorId])
REFERENCES [edfi].[StudentCharacteristicDescriptor] ([StudentCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileApplicantCharacteristic_StudentCharacteristicDescriptor]
ON [edfi].[ApplicantProfileApplicantCharacteristic] ([StudentCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileBackgroundCheck_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [edfi].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [edfi].[ApplicantProfileBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [edfi].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [edfi].[ApplicantProfileBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisability_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileDisability_DisabilityDescriptor]
ON [edfi].[ApplicantProfileDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileDisability] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [edfi].[ApplicantProfileDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisabilityDesignation_ApplicantProfileDisability] FOREIGN KEY ([ApplicantProfileIdentifier], [DisabilityDescriptorId])
REFERENCES [edfi].[ApplicantProfileDisability] ([ApplicantProfileIdentifier], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileDisabilityDesignation_DisabilityDesignationDescriptor]
ON [edfi].[ApplicantProfileDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileEducatorPreparationProgramName] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileEducatorPreparationProgramName_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileElectronicMail_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileElectronicMail_ElectronicMailTypeDescriptor]
ON [edfi].[ApplicantProfileElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileGradePointAverage_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileGradePointAverage_GradePointAverageTypeDescriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[GradePointAverageTypeDescriptor] ([GradePointAverageTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileGradePointAverage_GradePointAverageTypeDescriptor]
ON [edfi].[ApplicantProfileGradePointAverage] ([GradePointAverageTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileHighlyQualifiedAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileHighlyQualifiedAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileHighlyQualifiedAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[ApplicantProfileHighlyQualifiedAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileHighlyQualifiedAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileHighlyQualifiedAcademicSubject_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileIdentificationDocument_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileIdentificationDocument_CountryDescriptor]
ON [edfi].[ApplicantProfileIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[ApplicantProfileIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[ApplicantProfileIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileInternationalAddress_AddressTypeDescriptor]
ON [edfi].[ApplicantProfileInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileInternationalAddress_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileInternationalAddress_CountryDescriptor]
ON [edfi].[ApplicantProfileInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileLanguage] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileLanguage_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileLanguage] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileLanguage_LanguageDescriptor]
ON [edfi].[ApplicantProfileLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileLanguageUse_ApplicantProfileLanguage] FOREIGN KEY ([ApplicantProfileIdentifier], [LanguageDescriptorId])
REFERENCES [edfi].[ApplicantProfileLanguage] ([ApplicantProfileIdentifier], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileLanguageUse_LanguageUseDescriptor]
ON [edfi].[ApplicantProfileLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfilePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfilePersonalIdentificationDocument_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfilePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfilePersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfilePersonalIdentificationDocument_CountryDescriptor]
ON [edfi].[ApplicantProfilePersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfilePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfilePersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfilePersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[ApplicantProfilePersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfilePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfilePersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfilePersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[ApplicantProfilePersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileRace] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileRace_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileRace] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileRace_RaceDescriptor]
ON [edfi].[ApplicantProfileRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileTelephone] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileTelephone_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileTelephone] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileTelephone_TelephoneNumberTypeDescriptor]
ON [edfi].[ApplicantProfileTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicantProfileVisa] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileVisa_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicantProfileVisa] WITH CHECK ADD CONSTRAINT [FK_ApplicantProfileVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicantProfileVisa_VisaDescriptor]
ON [edfi].[ApplicantProfileVisa] ([VisaDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_AcademicSubjectDescriptor]
ON [edfi].[Application] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_AcademicSubjectDescriptor1] FOREIGN KEY ([HighNeedsAcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_AcademicSubjectDescriptor1]
ON [edfi].[Application] ([HighNeedsAcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_ApplicantProfile] FOREIGN KEY ([ApplicantProfileIdentifier])
REFERENCES [edfi].[ApplicantProfile] ([ApplicantProfileIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_Application_ApplicantProfile]
ON [edfi].[Application] ([ApplicantProfileIdentifier] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_ApplicationSourceDescriptor] FOREIGN KEY ([ApplicationSourceDescriptorId])
REFERENCES [edfi].[ApplicationSourceDescriptor] ([ApplicationSourceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_ApplicationSourceDescriptor]
ON [edfi].[Application] ([ApplicationSourceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_ApplicationStatusDescriptor] FOREIGN KEY ([ApplicationStatusDescriptorId])
REFERENCES [edfi].[ApplicationStatusDescriptor] ([ApplicationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_ApplicationStatusDescriptor]
ON [edfi].[Application] ([ApplicationStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_HireStatusDescriptor] FOREIGN KEY ([HireStatusDescriptorId])
REFERENCES [edfi].[HireStatusDescriptor] ([HireStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_HireStatusDescriptor]
ON [edfi].[Application] ([HireStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_HiringSourceDescriptor] FOREIGN KEY ([HiringSourceDescriptorId])
REFERENCES [edfi].[HiringSourceDescriptor] ([HiringSourceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_HiringSourceDescriptor]
ON [edfi].[Application] ([HiringSourceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_Application_OpenStaffPosition]
ON [edfi].[Application] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
GO

ALTER TABLE [edfi].[Application] WITH CHECK ADD CONSTRAINT [FK_Application_WithdrawReasonDescriptor] FOREIGN KEY ([WithdrawReasonDescriptorId])
REFERENCES [edfi].[WithdrawReasonDescriptor] ([WithdrawReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Application_WithdrawReasonDescriptor]
ON [edfi].[Application] ([WithdrawReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_Application]
ON [edfi].[ApplicationEvent] ([ApplicantProfileIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_ApplicationEventResultDescriptor] FOREIGN KEY ([ApplicationEventResultDescriptorId])
REFERENCES [edfi].[ApplicationEventResultDescriptor] ([ApplicationEventResultDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_ApplicationEventResultDescriptor]
ON [edfi].[ApplicationEvent] ([ApplicationEventResultDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_ApplicationEventTypeDescriptor] FOREIGN KEY ([ApplicationEventTypeDescriptorId])
REFERENCES [edfi].[ApplicationEventTypeDescriptor] ([ApplicationEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_ApplicationEventTypeDescriptor]
ON [edfi].[ApplicationEvent] ([ApplicationEventTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_SchoolYearType]
ON [edfi].[ApplicationEvent] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[ApplicationEvent] WITH CHECK ADD CONSTRAINT [FK_ApplicationEvent_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationEvent_TermDescriptor]
ON [edfi].[ApplicationEvent] ([TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicationEventResultDescriptor] WITH CHECK ADD CONSTRAINT [FK_ApplicationEventResultDescriptor_Descriptor] FOREIGN KEY ([ApplicationEventResultDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicationEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ApplicationEventTypeDescriptor_Descriptor] FOREIGN KEY ([ApplicationEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicationRecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ApplicationRecruitmentEventAttendance_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicationRecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ApplicationRecruitmentEventAttendance_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationRecruitmentEventAttendance_RecruitmentEventAttendance]
ON [edfi].[ApplicationRecruitmentEventAttendance] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC, [RecruitmentEventAttendeeIdentifier] ASC)
GO

ALTER TABLE [edfi].[ApplicationScoreResult] WITH CHECK ADD CONSTRAINT [FK_ApplicationScoreResult_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicationScoreResult] WITH CHECK ADD CONSTRAINT [FK_ApplicationScoreResult_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationScoreResult_AssessmentReportingMethodDescriptor]
ON [edfi].[ApplicationScoreResult] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicationScoreResult] WITH CHECK ADD CONSTRAINT [FK_ApplicationScoreResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationScoreResult_ResultDatatypeTypeDescriptor]
ON [edfi].[ApplicationScoreResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ApplicationSourceDescriptor] WITH CHECK ADD CONSTRAINT [FK_ApplicationSourceDescriptor_Descriptor] FOREIGN KEY ([ApplicationSourceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_ApplicationStatusDescriptor_Descriptor] FOREIGN KEY ([ApplicationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicationTerm] WITH CHECK ADD CONSTRAINT [FK_ApplicationTerm_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ApplicationTerm] WITH CHECK ADD CONSTRAINT [FK_ApplicationTerm_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ApplicationTerm_TermDescriptor]
ON [edfi].[ApplicationTerm] ([TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Assessment] WITH CHECK ADD CONSTRAINT [FK_Assessment_AssessmentCategoryDescriptor] FOREIGN KEY ([AssessmentCategoryDescriptorId])
REFERENCES [edfi].[AssessmentCategoryDescriptor] ([AssessmentCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Assessment_AssessmentCategoryDescriptor]
ON [edfi].[Assessment] ([AssessmentCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Assessment] WITH CHECK ADD CONSTRAINT [FK_Assessment_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[AssessmentAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_AssessmentAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[AssessmentAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_AssessmentAcademicSubject_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentAdministration] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministration_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentAdministration_Assessment]
ON [edfi].[AssessmentAdministration] ([AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[AssessmentAdministration] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministration_EducationOrganization] FOREIGN KEY ([AssigningEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentAdministration_EducationOrganization]
ON [edfi].[AssessmentAdministration] ([AssigningEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[AssessmentAdministrationAssessmentBatteryPart] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministrationAssessmentBatteryPart_AssessmentAdministration] FOREIGN KEY ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace])
REFERENCES [edfi].[AssessmentAdministration] ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentAdministrationAssessmentBatteryPart] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministrationAssessmentBatteryPart_AssessmentBatteryPart] FOREIGN KEY ([AssessmentBatteryPartName], [AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[AssessmentBatteryPart] ([AssessmentBatteryPartName], [AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentAdministrationAssessmentBatteryPart_AssessmentBatteryPart]
ON [edfi].[AssessmentAdministrationAssessmentBatteryPart] ([AssessmentBatteryPartName] ASC, [AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[AssessmentAdministrationParticipation] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministrationParticipation_AssessmentAdministration] FOREIGN KEY ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace])
REFERENCES [edfi].[AssessmentAdministration] ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentAdministrationParticipation_AssessmentAdministration]
ON [edfi].[AssessmentAdministrationParticipation] ([AdministrationIdentifier] ASC, [AssessmentIdentifier] ASC, [AssigningEducationOrganizationId] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[AssessmentAdministrationParticipation] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministrationParticipation_EducationOrganization] FOREIGN KEY ([ParticipatingEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentAdministrationParticipation_EducationOrganization]
ON [edfi].[AssessmentAdministrationParticipation] ([ParticipatingEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[AssessmentAdministrationParticipationAdministrationPointOfContact] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministrationParticipationAdministrationPointOfContact_AssessmentAdministrationParticipation] FOREIGN KEY ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace], [ParticipatingEducationOrganizationId])
REFERENCES [edfi].[AssessmentAdministrationParticipation] ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace], [ParticipatingEducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentAdministrationParticipationAdministrationPointOfContact] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministrationParticipationAdministrationPointOfContact_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentAdministrationParticipationAdministrationPointOfContact_EducationOrganization]
ON [edfi].[AssessmentAdministrationParticipationAdministrationPointOfContact] ([EducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[AssessmentAdministrationPeriod] WITH CHECK ADD CONSTRAINT [FK_AssessmentAdministrationPeriod_AssessmentAdministration] FOREIGN KEY ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace])
REFERENCES [edfi].[AssessmentAdministration] ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentAssessedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentAssessedGradeLevel_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentAssessedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentAssessedGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentAssessedGradeLevel_GradeLevelDescriptor]
ON [edfi].[AssessmentAssessedGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentBatteryPart] WITH CHECK ADD CONSTRAINT [FK_AssessmentBatteryPart_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentBatteryPart_Assessment]
ON [edfi].[AssessmentBatteryPart] ([AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[AssessmentBatteryPartObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_AssessmentBatteryPartObjectiveAssessment_AssessmentBatteryPart] FOREIGN KEY ([AssessmentBatteryPartName], [AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[AssessmentBatteryPart] ([AssessmentBatteryPartName], [AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentBatteryPartObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_AssessmentBatteryPartObjectiveAssessment_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentBatteryPartObjectiveAssessment_ObjectiveAssessment]
ON [edfi].[AssessmentBatteryPartObjectiveAssessment] ([AssessmentIdentifier] ASC, [IdentificationCode] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[AssessmentCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentCategoryDescriptor_Descriptor] FOREIGN KEY ([AssessmentCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentContentStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentContentStandard_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentContentStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentContentStandard_EducationOrganization] FOREIGN KEY ([MandatingEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentContentStandard_EducationOrganization]
ON [edfi].[AssessmentContentStandard] ([MandatingEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[AssessmentContentStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentContentStandard_PublicationStatusDescriptor] FOREIGN KEY ([PublicationStatusDescriptorId])
REFERENCES [edfi].[PublicationStatusDescriptor] ([PublicationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentContentStandard_PublicationStatusDescriptor]
ON [edfi].[AssessmentContentStandard] ([PublicationStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentContentStandardAuthor] WITH CHECK ADD CONSTRAINT [FK_AssessmentContentStandardAuthor_AssessmentContentStandard] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[AssessmentContentStandard] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_AssessmentIdentificationCode_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_AssessmentIdentificationCode_AssessmentIdentificationSystemDescriptor] FOREIGN KEY ([AssessmentIdentificationSystemDescriptorId])
REFERENCES [edfi].[AssessmentIdentificationSystemDescriptor] ([AssessmentIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentIdentificationCode_AssessmentIdentificationSystemDescriptor]
ON [edfi].[AssessmentIdentificationCode] ([AssessmentIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([AssessmentIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentItem] WITH CHECK ADD CONSTRAINT [FK_AssessmentItem_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentItem_Assessment]
ON [edfi].[AssessmentItem] ([AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[AssessmentItem] WITH CHECK ADD CONSTRAINT [FK_AssessmentItem_AssessmentItemCategoryDescriptor] FOREIGN KEY ([AssessmentItemCategoryDescriptorId])
REFERENCES [edfi].[AssessmentItemCategoryDescriptor] ([AssessmentItemCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentItem_AssessmentItemCategoryDescriptor]
ON [edfi].[AssessmentItem] ([AssessmentItemCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentItemCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemCategoryDescriptor_Descriptor] FOREIGN KEY ([AssessmentItemCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentItemLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemLearningStandard_AssessmentItem] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[AssessmentItem] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentItemLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentItemLearningStandard_LearningStandard]
ON [edfi].[AssessmentItemLearningStandard] ([LearningStandardId] ASC)
GO

ALTER TABLE [edfi].[AssessmentItemPossibleResponse] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemPossibleResponse_AssessmentItem] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[AssessmentItem] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentItemResultDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentItemResultDescriptor_Descriptor] FOREIGN KEY ([AssessmentItemResultDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentLanguage] WITH CHECK ADD CONSTRAINT [FK_AssessmentLanguage_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentLanguage] WITH CHECK ADD CONSTRAINT [FK_AssessmentLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentLanguage_LanguageDescriptor]
ON [edfi].[AssessmentLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentPerformanceLevel_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentPerformanceLevel_AssessmentReportingMethodDescriptor]
ON [edfi].[AssessmentPerformanceLevel] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentPerformanceLevel_PerformanceLevelDescriptor]
ON [edfi].[AssessmentPerformanceLevel] ([PerformanceLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_AssessmentPerformanceLevel_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentPerformanceLevel_ResultDatatypeTypeDescriptor]
ON [edfi].[AssessmentPerformanceLevel] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentPeriod] WITH CHECK ADD CONSTRAINT [FK_AssessmentPeriod_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentPeriod] WITH CHECK ADD CONSTRAINT [FK_AssessmentPeriod_AssessmentPeriodDescriptor] FOREIGN KEY ([AssessmentPeriodDescriptorId])
REFERENCES [edfi].[AssessmentPeriodDescriptor] ([AssessmentPeriodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentPeriod_AssessmentPeriodDescriptor]
ON [edfi].[AssessmentPeriod] ([AssessmentPeriodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentPeriodDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentPeriodDescriptor_Descriptor] FOREIGN KEY ([AssessmentPeriodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentPlatformType] WITH CHECK ADD CONSTRAINT [FK_AssessmentPlatformType_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentPlatformType] WITH CHECK ADD CONSTRAINT [FK_AssessmentPlatformType_PlatformTypeDescriptor] FOREIGN KEY ([PlatformTypeDescriptorId])
REFERENCES [edfi].[PlatformTypeDescriptor] ([PlatformTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentPlatformType_PlatformTypeDescriptor]
ON [edfi].[AssessmentPlatformType] ([PlatformTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentProgram] WITH CHECK ADD CONSTRAINT [FK_AssessmentProgram_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentProgram] WITH CHECK ADD CONSTRAINT [FK_AssessmentProgram_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentProgram_Program]
ON [edfi].[AssessmentProgram] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentReportingMethodDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssessmentReportingMethodDescriptor_Descriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentScore] WITH CHECK ADD CONSTRAINT [FK_AssessmentScore_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentScore] WITH CHECK ADD CONSTRAINT [FK_AssessmentScore_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentScore_AssessmentReportingMethodDescriptor]
ON [edfi].[AssessmentScore] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentScore] WITH CHECK ADD CONSTRAINT [FK_AssessmentScore_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentScore_ResultDatatypeTypeDescriptor]
ON [edfi].[AssessmentScore] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandard_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentScoreRangeLearningStandard_Assessment]
ON [edfi].[AssessmentScoreRangeLearningStandard] ([AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandard_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentScoreRangeLearningStandard_AssessmentReportingMethodDescriptor]
ON [edfi].[AssessmentScoreRangeLearningStandard] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandard_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentScoreRangeLearningStandard_ObjectiveAssessment]
ON [edfi].[AssessmentScoreRangeLearningStandard] ([AssessmentIdentifier] ASC, [IdentificationCode] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandardLearningStandard_AssessmentScoreRangeLearningStandard] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [ScoreRangeId])
REFERENCES [edfi].[AssessmentScoreRangeLearningStandard] ([AssessmentIdentifier], [Namespace], [ScoreRangeId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] WITH CHECK ADD CONSTRAINT [FK_AssessmentScoreRangeLearningStandardLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentScoreRangeLearningStandardLearningStandard_LearningStandard]
ON [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] ([LearningStandardId] ASC)
GO

ALTER TABLE [edfi].[AssessmentSection] WITH CHECK ADD CONSTRAINT [FK_AssessmentSection_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AssessmentSection] WITH CHECK ADD CONSTRAINT [FK_AssessmentSection_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_AssessmentSection_Section]
ON [edfi].[AssessmentSection] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[AssignmentLateStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_AssignmentLateStatusDescriptor_Descriptor] FOREIGN KEY ([AssignmentLateStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AttemptStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_AttemptStatusDescriptor_Descriptor] FOREIGN KEY ([AttemptStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[AttendanceEventCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_AttendanceEventCategoryDescriptor_Descriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BackgroundCheckStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_BackgroundCheckStatusDescriptor_Descriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BackgroundCheckTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_BackgroundCheckTypeDescriptor_Descriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BalanceSheetDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_BalanceSheetDimensionReportingTag_BalanceSheetDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[BalanceSheetDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BalanceSheetDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_BalanceSheetDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_BalanceSheetDimensionReportingTag_ReportingTagDescriptor]
ON [edfi].[BalanceSheetDimensionReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[BarrierToInternetAccessInResidenceDescriptor] WITH CHECK ADD CONSTRAINT [FK_BarrierToInternetAccessInResidenceDescriptor_Descriptor] FOREIGN KEY ([BarrierToInternetAccessInResidenceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BehaviorDescriptor] WITH CHECK ADD CONSTRAINT [FK_BehaviorDescriptor_Descriptor] FOREIGN KEY ([BehaviorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BellSchedule] WITH CHECK ADD CONSTRAINT [FK_BellSchedule_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[BellScheduleClassPeriod] WITH CHECK ADD CONSTRAINT [FK_BellScheduleClassPeriod_BellSchedule] FOREIGN KEY ([BellScheduleName], [SchoolId])
REFERENCES [edfi].[BellSchedule] ([BellScheduleName], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BellScheduleClassPeriod] WITH CHECK ADD CONSTRAINT [FK_BellScheduleClassPeriod_ClassPeriod] FOREIGN KEY ([ClassPeriodName], [SchoolId])
REFERENCES [edfi].[ClassPeriod] ([ClassPeriodName], [SchoolId])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_BellScheduleClassPeriod_ClassPeriod]
ON [edfi].[BellScheduleClassPeriod] ([ClassPeriodName] ASC, [SchoolId] ASC)
GO

ALTER TABLE [edfi].[BellScheduleDate] WITH CHECK ADD CONSTRAINT [FK_BellScheduleDate_BellSchedule] FOREIGN KEY ([BellScheduleName], [SchoolId])
REFERENCES [edfi].[BellSchedule] ([BellScheduleName], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BellScheduleGradeLevel] WITH CHECK ADD CONSTRAINT [FK_BellScheduleGradeLevel_BellSchedule] FOREIGN KEY ([BellScheduleName], [SchoolId])
REFERENCES [edfi].[BellSchedule] ([BellScheduleName], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[BellScheduleGradeLevel] WITH CHECK ADD CONSTRAINT [FK_BellScheduleGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_BellScheduleGradeLevel_GradeLevelDescriptor]
ON [edfi].[BellScheduleGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[BusRouteDescriptor] WITH CHECK ADD CONSTRAINT [FK_BusRouteDescriptor_Descriptor] FOREIGN KEY ([BusRouteDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Calendar] WITH CHECK ADD CONSTRAINT [FK_Calendar_CalendarTypeDescriptor] FOREIGN KEY ([CalendarTypeDescriptorId])
REFERENCES [edfi].[CalendarTypeDescriptor] ([CalendarTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Calendar_CalendarTypeDescriptor]
ON [edfi].[Calendar] ([CalendarTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Calendar] WITH CHECK ADD CONSTRAINT [FK_Calendar_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[Calendar] WITH CHECK ADD CONSTRAINT [FK_Calendar_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_Calendar_SchoolYearType]
ON [edfi].[Calendar] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[CalendarDate] WITH CHECK ADD CONSTRAINT [FK_CalendarDate_Calendar] FOREIGN KEY ([CalendarCode], [SchoolId], [SchoolYear])
REFERENCES [edfi].[Calendar] ([CalendarCode], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_CalendarDate_Calendar]
ON [edfi].[CalendarDate] ([CalendarCode] ASC, [SchoolId] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [edfi].[CalendarDateCalendarEvent] WITH CHECK ADD CONSTRAINT [FK_CalendarDateCalendarEvent_CalendarDate] FOREIGN KEY ([CalendarCode], [Date], [SchoolId], [SchoolYear])
REFERENCES [edfi].[CalendarDate] ([CalendarCode], [Date], [SchoolId], [SchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CalendarDateCalendarEvent] WITH CHECK ADD CONSTRAINT [FK_CalendarDateCalendarEvent_CalendarEventDescriptor] FOREIGN KEY ([CalendarEventDescriptorId])
REFERENCES [edfi].[CalendarEventDescriptor] ([CalendarEventDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CalendarDateCalendarEvent_CalendarEventDescriptor]
ON [edfi].[CalendarDateCalendarEvent] ([CalendarEventDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CalendarEventDescriptor] WITH CHECK ADD CONSTRAINT [FK_CalendarEventDescriptor_Descriptor] FOREIGN KEY ([CalendarEventDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CalendarGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CalendarGradeLevel_Calendar] FOREIGN KEY ([CalendarCode], [SchoolId], [SchoolYear])
REFERENCES [edfi].[Calendar] ([CalendarCode], [SchoolId], [SchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CalendarGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CalendarGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CalendarGradeLevel_GradeLevelDescriptor]
ON [edfi].[CalendarGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CalendarTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CalendarTypeDescriptor_Descriptor] FOREIGN KEY ([CalendarTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_CitizenshipStatusDescriptor]
ON [edfi].[Candidate] ([CitizenshipStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_CountryDescriptor] FOREIGN KEY ([BirthCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_CountryDescriptor]
ON [edfi].[Candidate] ([BirthCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_EnglishLanguageExamDescriptor] FOREIGN KEY ([EnglishLanguageExamDescriptorId])
REFERENCES [edfi].[EnglishLanguageExamDescriptor] ([EnglishLanguageExamDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_EnglishLanguageExamDescriptor]
ON [edfi].[Candidate] ([EnglishLanguageExamDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_LimitedEnglishProficiencyDescriptor] FOREIGN KEY ([LimitedEnglishProficiencyDescriptorId])
REFERENCES [edfi].[LimitedEnglishProficiencyDescriptor] ([LimitedEnglishProficiencyDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_LimitedEnglishProficiencyDescriptor]
ON [edfi].[Candidate] ([LimitedEnglishProficiencyDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_Person]
ON [edfi].[Candidate] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_PreviousCareerDescriptor] FOREIGN KEY ([PreviousCareerDescriptorId])
REFERENCES [edfi].[PreviousCareerDescriptor] ([PreviousCareerDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_PreviousCareerDescriptor]
ON [edfi].[Candidate] ([PreviousCareerDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_SexDescriptor]
ON [edfi].[Candidate] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_SexDescriptor1] FOREIGN KEY ([BirthSexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_SexDescriptor1]
ON [edfi].[Candidate] ([BirthSexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Candidate] WITH CHECK ADD CONSTRAINT [FK_Candidate_StateAbbreviationDescriptor] FOREIGN KEY ([BirthStateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Candidate_StateAbbreviationDescriptor]
ON [edfi].[Candidate] ([BirthStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAddress_AddressTypeDescriptor]
ON [edfi].[CandidateAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateAddress_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAddress_LocaleDescriptor]
ON [edfi].[CandidateAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateAddress_StateAbbreviationDescriptor]
ON [edfi].[CandidateAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_CandidateAddressPeriod_CandidateAddress] FOREIGN KEY ([CandidateIdentifier], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[CandidateAddress] ([CandidateIdentifier], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_CandidateBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [edfi].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [edfi].[CandidateBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_CandidateBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [edfi].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [edfi].[CandidateBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_CandidateBackgroundCheck_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CandidateCharacteristic_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CandidateCharacteristic_CandidateCharacteristicDescriptor] FOREIGN KEY ([CandidateCharacteristicDescriptorId])
REFERENCES [edfi].[CandidateCharacteristicDescriptor] ([CandidateCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateCharacteristic_CandidateCharacteristicDescriptor]
ON [edfi].[CandidateCharacteristic] ([CandidateCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_CandidateCharacteristicDescriptor_Descriptor] FOREIGN KEY ([CandidateCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateDisability] WITH CHECK ADD CONSTRAINT [FK_CandidateDisability_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateDisability] WITH CHECK ADD CONSTRAINT [FK_CandidateDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateDisability_DisabilityDescriptor]
ON [edfi].[CandidateDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateDisability] WITH CHECK ADD CONSTRAINT [FK_CandidateDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [edfi].[CandidateDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_CandidateDisabilityDesignation_CandidateDisability] FOREIGN KEY ([CandidateIdentifier], [DisabilityDescriptorId])
REFERENCES [edfi].[CandidateDisability] ([CandidateIdentifier], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_CandidateDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateDisabilityDesignation_DisabilityDesignationDescriptor]
ON [edfi].[CandidateDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_Application] FOREIGN KEY ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Application] ([ApplicantProfileIdentifier], [ApplicationIdentifier], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_Application]
ON [edfi].[CandidateEducatorPreparationProgramAssociation] ([ApplicantProfileIdentifier] ASC, [ApplicationIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_Candidate]
ON [edfi].[CandidateEducatorPreparationProgramAssociation] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_EducatorPreparationProgram]
ON [edfi].[CandidateEducatorPreparationProgramAssociation] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_EPPProgramPathwayDescriptor] FOREIGN KEY ([EPPProgramPathwayDescriptorId])
REFERENCES [edfi].[EPPProgramPathwayDescriptor] ([EPPProgramPathwayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_EPPProgramPathwayDescriptor]
ON [edfi].[CandidateEducatorPreparationProgramAssociation] ([EPPProgramPathwayDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociation_ReasonExitedDescriptor] FOREIGN KEY ([ReasonExitedDescriptorId])
REFERENCES [edfi].[ReasonExitedDescriptor] ([ReasonExitedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociation_ReasonExitedDescriptor]
ON [edfi].[CandidateEducatorPreparationProgramAssociation] ([ReasonExitedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCandidateIndicator_CandidateEducatorPreparationProgramAssociation] FOREIGN KEY ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[CandidateEducatorPreparationProgramAssociation] ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCohortYear_CandidateEducatorPreparationProgramAssociation] FOREIGN KEY ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[CandidateEducatorPreparationProgramAssociation] ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCohortYear_CohortYearTypeDescriptor] FOREIGN KEY ([CohortYearTypeDescriptorId])
REFERENCES [edfi].[CohortYearTypeDescriptor] ([CohortYearTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociationCohortYear_CohortYearTypeDescriptor]
ON [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] ([CohortYearTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCohortYear_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociationCohortYear_SchoolYearType]
ON [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationCohortYear_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEducatorPreparationProgramAssociationCohortYear_TermDescriptor]
ON [edfi].[CandidateEducatorPreparationProgramAssociationCohortYear] ([TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] WITH CHECK ADD CONSTRAINT [FK_CandidateEducatorPreparationProgramAssociationDegreeSpecialization_CandidateEducatorPreparationProgramAssociation] FOREIGN KEY ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[CandidateEducatorPreparationProgramAssociation] ([BeginDate], [CandidateIdentifier], [EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateElectronicMail] WITH CHECK ADD CONSTRAINT [FK_CandidateElectronicMail_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateElectronicMail] WITH CHECK ADD CONSTRAINT [FK_CandidateElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateElectronicMail_ElectronicMailTypeDescriptor]
ON [edfi].[CandidateElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_CandidateEPPProgramDegree_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEPPProgramDegree_AcademicSubjectDescriptor]
ON [edfi].[CandidateEPPProgramDegree] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_CandidateEPPProgramDegree_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateEPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_CandidateEPPProgramDegree_EPPDegreeTypeDescriptor] FOREIGN KEY ([EPPDegreeTypeDescriptorId])
REFERENCES [edfi].[EPPDegreeTypeDescriptor] ([EPPDegreeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEPPProgramDegree_EPPDegreeTypeDescriptor]
ON [edfi].[CandidateEPPProgramDegree] ([EPPDegreeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateEPPProgramDegree] WITH CHECK ADD CONSTRAINT [FK_CandidateEPPProgramDegree_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateEPPProgramDegree_GradeLevelDescriptor]
ON [edfi].[CandidateEPPProgramDegree] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationCode_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationCode_Candidate]
ON [edfi].[CandidateIdentificationCode] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [edfi].[CandidateIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationCode_CandidateIdentificationSystemDescriptor] FOREIGN KEY ([CandidateIdentificationSystemDescriptorId])
REFERENCES [edfi].[CandidateIdentificationSystemDescriptor] ([CandidateIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationCode_CandidateIdentificationSystemDescriptor]
ON [edfi].[CandidateIdentificationCode] ([CandidateIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationCode_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationDocument_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationDocument_CountryDescriptor]
ON [edfi].[CandidateIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[CandidateIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[CandidateIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_CandidateIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([CandidateIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateIndicator] WITH CHECK ADD CONSTRAINT [FK_CandidateIndicator_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateInternationalAddress_AddressTypeDescriptor]
ON [edfi].[CandidateInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateInternationalAddress_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_CandidateInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateInternationalAddress_CountryDescriptor]
ON [edfi].[CandidateInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateLanguage] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguage_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateLanguage] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateLanguage_LanguageDescriptor]
ON [edfi].[CandidateLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateLanguageUse] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguageUse_CandidateLanguage] FOREIGN KEY ([CandidateIdentifier], [LanguageDescriptorId])
REFERENCES [edfi].[CandidateLanguage] ([CandidateIdentifier], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateLanguageUse] WITH CHECK ADD CONSTRAINT [FK_CandidateLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateLanguageUse_LanguageUseDescriptor]
ON [edfi].[CandidateLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateOtherName] WITH CHECK ADD CONSTRAINT [FK_CandidateOtherName_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateOtherName] WITH CHECK ADD CONSTRAINT [FK_CandidateOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateOtherName_OtherNameTypeDescriptor]
ON [edfi].[CandidateOtherName] ([OtherNameTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidatePersonalIdentificationDocument_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidatePersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidatePersonalIdentificationDocument_CountryDescriptor]
ON [edfi].[CandidatePersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidatePersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidatePersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[CandidatePersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidatePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_CandidatePersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidatePersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[CandidatePersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateRace] WITH CHECK ADD CONSTRAINT [FK_CandidateRace_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateRace] WITH CHECK ADD CONSTRAINT [FK_CandidateRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateRace_RaceDescriptor]
ON [edfi].[CandidateRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateRelationshipToStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateRelationshipToStaffAssociation_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateRelationshipToStaffAssociation_Candidate]
ON [edfi].[CandidateRelationshipToStaffAssociation] ([CandidateIdentifier] ASC)
GO

ALTER TABLE [edfi].[CandidateRelationshipToStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateRelationshipToStaffAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[CandidateRelationshipToStaffAssociation] WITH CHECK ADD CONSTRAINT [FK_CandidateRelationshipToStaffAssociation_StaffToCandidateRelationshipDescriptor] FOREIGN KEY ([StaffToCandidateRelationshipDescriptorId])
REFERENCES [edfi].[StaffToCandidateRelationshipDescriptor] ([StaffToCandidateRelationshipDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateRelationshipToStaffAssociation_StaffToCandidateRelationshipDescriptor]
ON [edfi].[CandidateRelationshipToStaffAssociation] ([StaffToCandidateRelationshipDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateTelephone] WITH CHECK ADD CONSTRAINT [FK_CandidateTelephone_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateTelephone] WITH CHECK ADD CONSTRAINT [FK_CandidateTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateTelephone_TelephoneNumberTypeDescriptor]
ON [edfi].[CandidateTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CandidateVisa] WITH CHECK ADD CONSTRAINT [FK_CandidateVisa_Candidate] FOREIGN KEY ([CandidateIdentifier])
REFERENCES [edfi].[Candidate] ([CandidateIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CandidateVisa] WITH CHECK ADD CONSTRAINT [FK_CandidateVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CandidateVisa_VisaDescriptor]
ON [edfi].[CandidateVisa] ([VisaDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CareerPathwayDescriptor] WITH CHECK ADD CONSTRAINT [FK_CareerPathwayDescriptor_Descriptor] FOREIGN KEY ([CareerPathwayDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_CertificationFieldDescriptor] FOREIGN KEY ([CertificationFieldDescriptorId])
REFERENCES [edfi].[CertificationFieldDescriptor] ([CertificationFieldDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_CertificationFieldDescriptor]
ON [edfi].[Certification] ([CertificationFieldDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_CertificationLevelDescriptor] FOREIGN KEY ([CertificationLevelDescriptorId])
REFERENCES [edfi].[CertificationLevelDescriptor] ([CertificationLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_CertificationLevelDescriptor]
ON [edfi].[Certification] ([CertificationLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_CertificationStandardDescriptor] FOREIGN KEY ([CertificationStandardDescriptorId])
REFERENCES [edfi].[CertificationStandardDescriptor] ([CertificationStandardDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_CertificationStandardDescriptor]
ON [edfi].[Certification] ([CertificationStandardDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_DegreeDescriptor] FOREIGN KEY ([MinimumDegreeDescriptorId])
REFERENCES [edfi].[DegreeDescriptor] ([DegreeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_DegreeDescriptor]
ON [edfi].[Certification] ([MinimumDegreeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_EducatorRoleDescriptor] FOREIGN KEY ([EducatorRoleDescriptorId])
REFERENCES [edfi].[EducatorRoleDescriptor] ([EducatorRoleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_EducatorRoleDescriptor]
ON [edfi].[Certification] ([EducatorRoleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_InstructionalSettingDescriptor] FOREIGN KEY ([InstructionalSettingDescriptorId])
REFERENCES [edfi].[InstructionalSettingDescriptor] ([InstructionalSettingDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_InstructionalSettingDescriptor]
ON [edfi].[Certification] ([InstructionalSettingDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Certification] WITH CHECK ADD CONSTRAINT [FK_Certification_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Certification_PopulationServedDescriptor]
ON [edfi].[Certification] ([PopulationServedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CertificationCertificationExam] WITH CHECK ADD CONSTRAINT [FK_CertificationCertificationExam_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [edfi].[Certification] ([CertificationIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CertificationCertificationExam] WITH CHECK ADD CONSTRAINT [FK_CertificationCertificationExam_CertificationExam] FOREIGN KEY ([CertificationExamIdentifier], [CertificationExamNamespace])
REFERENCES [edfi].[CertificationExam] ([CertificationExamIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationCertificationExam_CertificationExam]
ON [edfi].[CertificationCertificationExam] ([CertificationExamIdentifier] ASC, [CertificationExamNamespace] ASC)
GO

ALTER TABLE [edfi].[CertificationExam] WITH CHECK ADD CONSTRAINT [FK_CertificationExam_CertificationExamTypeDescriptor] FOREIGN KEY ([CertificationExamTypeDescriptorId])
REFERENCES [edfi].[CertificationExamTypeDescriptor] ([CertificationExamTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExam_CertificationExamTypeDescriptor]
ON [edfi].[CertificationExam] ([CertificationExamTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CertificationExam] WITH CHECK ADD CONSTRAINT [FK_CertificationExam_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CertificationExamResult] WITH CHECK ADD CONSTRAINT [FK_CertificationExamResult_CertificationExam] FOREIGN KEY ([CertificationExamIdentifier], [Namespace])
REFERENCES [edfi].[CertificationExam] ([CertificationExamIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExamResult_CertificationExam]
ON [edfi].[CertificationExamResult] ([CertificationExamIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[CertificationExamResult] WITH CHECK ADD CONSTRAINT [FK_CertificationExamResult_CertificationExamStatusDescriptor] FOREIGN KEY ([CertificationExamStatusDescriptorId])
REFERENCES [edfi].[CertificationExamStatusDescriptor] ([CertificationExamStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExamResult_CertificationExamStatusDescriptor]
ON [edfi].[CertificationExamResult] ([CertificationExamStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CertificationExamResult] WITH CHECK ADD CONSTRAINT [FK_CertificationExamResult_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExamResult_Person]
ON [edfi].[CertificationExamResult] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CertificationExamResult] WITH CHECK ADD CONSTRAINT [FK_CertificationExamResult_StudentAssessment] FOREIGN KEY ([CertificationExamAssessmentIdentifier], [CertificationExamNamespace], [CertificationExamStudentAssessmentIdentifier], [CertificationExamStudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationExamResult_StudentAssessment]
ON [edfi].[CertificationExamResult] ([CertificationExamAssessmentIdentifier] ASC, [CertificationExamNamespace] ASC, [CertificationExamStudentAssessmentIdentifier] ASC, [CertificationExamStudentUSI] ASC)
GO

ALTER TABLE [edfi].[CertificationExamStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationExamStatusDescriptor_Descriptor] FOREIGN KEY ([CertificationExamStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CertificationExamTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationExamTypeDescriptor_Descriptor] FOREIGN KEY ([CertificationExamTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CertificationFieldDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationFieldDescriptor_Descriptor] FOREIGN KEY ([CertificationFieldDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CertificationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CertificationGradeLevel_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [edfi].[Certification] ([CertificationIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CertificationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CertificationGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationGradeLevel_GradeLevelDescriptor]
ON [edfi].[CertificationGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CertificationLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationLevelDescriptor_Descriptor] FOREIGN KEY ([CertificationLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CertificationRoute] WITH CHECK ADD CONSTRAINT [FK_CertificationRoute_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [edfi].[Certification] ([CertificationIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CertificationRoute] WITH CHECK ADD CONSTRAINT [FK_CertificationRoute_CertificationRouteDescriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [edfi].[CertificationRouteDescriptor] ([CertificationRouteDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CertificationRoute_CertificationRouteDescriptor]
ON [edfi].[CertificationRoute] ([CertificationRouteDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CertificationRouteDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationRouteDescriptor_Descriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CertificationStandardDescriptor] WITH CHECK ADD CONSTRAINT [FK_CertificationStandardDescriptor_Descriptor] FOREIGN KEY ([CertificationStandardDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CharterApprovalAgencyTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CharterApprovalAgencyTypeDescriptor_Descriptor] FOREIGN KEY ([CharterApprovalAgencyTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CharterStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_CharterStatusDescriptor_Descriptor] FOREIGN KEY ([CharterStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_AccountTypeDescriptor] FOREIGN KEY ([AccountTypeDescriptorId])
REFERENCES [edfi].[AccountTypeDescriptor] ([AccountTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_AccountTypeDescriptor]
ON [edfi].[ChartOfAccount] ([AccountTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_BalanceSheetDimension] FOREIGN KEY ([BalanceSheetCode], [FiscalYear])
REFERENCES [edfi].[BalanceSheetDimension] ([Code], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_BalanceSheetDimension]
ON [edfi].[ChartOfAccount] ([BalanceSheetCode] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_FunctionDimension] FOREIGN KEY ([FunctionCode], [FiscalYear])
REFERENCES [edfi].[FunctionDimension] ([Code], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_FunctionDimension]
ON [edfi].[ChartOfAccount] ([FunctionCode] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_FundDimension] FOREIGN KEY ([FundCode], [FiscalYear])
REFERENCES [edfi].[FundDimension] ([Code], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_FundDimension]
ON [edfi].[ChartOfAccount] ([FundCode] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_ObjectDimension] FOREIGN KEY ([ObjectCode], [FiscalYear])
REFERENCES [edfi].[ObjectDimension] ([Code], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_ObjectDimension]
ON [edfi].[ChartOfAccount] ([ObjectCode] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_OperationalUnitDimension] FOREIGN KEY ([OperationalUnitCode], [FiscalYear])
REFERENCES [edfi].[OperationalUnitDimension] ([Code], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_OperationalUnitDimension]
ON [edfi].[ChartOfAccount] ([OperationalUnitCode] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_ProgramDimension] FOREIGN KEY ([ProgramCode], [FiscalYear])
REFERENCES [edfi].[ProgramDimension] ([Code], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_ProgramDimension]
ON [edfi].[ChartOfAccount] ([ProgramCode] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_ProjectDimension] FOREIGN KEY ([ProjectCode], [FiscalYear])
REFERENCES [edfi].[ProjectDimension] ([Code], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_ProjectDimension]
ON [edfi].[ChartOfAccount] ([ProjectCode] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccount] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccount_SourceDimension] FOREIGN KEY ([SourceCode], [FiscalYear])
REFERENCES [edfi].[SourceDimension] ([Code], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccount_SourceDimension]
ON [edfi].[ChartOfAccount] ([SourceCode] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[ChartOfAccountReportingTag] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccountReportingTag_ChartOfAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[ChartOfAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ChartOfAccountReportingTag] WITH CHECK ADD CONSTRAINT [FK_ChartOfAccountReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ChartOfAccountReportingTag_ReportingTagDescriptor]
ON [edfi].[ChartOfAccountReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CitizenshipStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_CitizenshipStatusDescriptor_Descriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ClassPeriod] WITH CHECK ADD CONSTRAINT [FK_ClassPeriod_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[ClassPeriodMeetingTime] WITH CHECK ADD CONSTRAINT [FK_ClassPeriodMeetingTime_ClassPeriod] FOREIGN KEY ([ClassPeriodName], [SchoolId])
REFERENCES [edfi].[ClassPeriod] ([ClassPeriodName], [SchoolId])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[ClassroomPositionDescriptor] WITH CHECK ADD CONSTRAINT [FK_ClassroomPositionDescriptor_Descriptor] FOREIGN KEY ([ClassroomPositionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Cohort] WITH CHECK ADD CONSTRAINT [FK_Cohort_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Cohort_AcademicSubjectDescriptor]
ON [edfi].[Cohort] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Cohort] WITH CHECK ADD CONSTRAINT [FK_Cohort_CohortScopeDescriptor] FOREIGN KEY ([CohortScopeDescriptorId])
REFERENCES [edfi].[CohortScopeDescriptor] ([CohortScopeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Cohort_CohortScopeDescriptor]
ON [edfi].[Cohort] ([CohortScopeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Cohort] WITH CHECK ADD CONSTRAINT [FK_Cohort_CohortTypeDescriptor] FOREIGN KEY ([CohortTypeDescriptorId])
REFERENCES [edfi].[CohortTypeDescriptor] ([CohortTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Cohort_CohortTypeDescriptor]
ON [edfi].[Cohort] ([CohortTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Cohort] WITH CHECK ADD CONSTRAINT [FK_Cohort_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CohortProgram] WITH CHECK ADD CONSTRAINT [FK_CohortProgram_Cohort] FOREIGN KEY ([CohortIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Cohort] ([CohortIdentifier], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CohortProgram] WITH CHECK ADD CONSTRAINT [FK_CohortProgram_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CohortProgram_Program]
ON [edfi].[CohortProgram] ([ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CohortScopeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CohortScopeDescriptor_Descriptor] FOREIGN KEY ([CohortScopeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CohortTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CohortTypeDescriptor_Descriptor] FOREIGN KEY ([CohortTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CohortYearTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CohortYearTypeDescriptor_Descriptor] FOREIGN KEY ([CohortYearTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CommunityOrganization] WITH CHECK ADD CONSTRAINT [FK_CommunityOrganization_EducationOrganization] FOREIGN KEY ([CommunityOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_CommunityOrganization] FOREIGN KEY ([CommunityOrganizationId])
REFERENCES [edfi].[CommunityOrganization] ([CommunityOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_CommunityProvider_CommunityOrganization]
ON [edfi].[CommunityProvider] ([CommunityOrganizationId] ASC)
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_EducationOrganization] FOREIGN KEY ([CommunityProviderId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_ProviderCategoryDescriptor] FOREIGN KEY ([ProviderCategoryDescriptorId])
REFERENCES [edfi].[ProviderCategoryDescriptor] ([ProviderCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CommunityProvider_ProviderCategoryDescriptor]
ON [edfi].[CommunityProvider] ([ProviderCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_ProviderProfitabilityDescriptor] FOREIGN KEY ([ProviderProfitabilityDescriptorId])
REFERENCES [edfi].[ProviderProfitabilityDescriptor] ([ProviderProfitabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CommunityProvider_ProviderProfitabilityDescriptor]
ON [edfi].[CommunityProvider] ([ProviderProfitabilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CommunityProvider] WITH CHECK ADD CONSTRAINT [FK_CommunityProvider_ProviderStatusDescriptor] FOREIGN KEY ([ProviderStatusDescriptorId])
REFERENCES [edfi].[ProviderStatusDescriptor] ([ProviderStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CommunityProvider_ProviderStatusDescriptor]
ON [edfi].[CommunityProvider] ([ProviderStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CommunityProviderLicense] WITH CHECK ADD CONSTRAINT [FK_CommunityProviderLicense_CommunityProvider] FOREIGN KEY ([CommunityProviderId])
REFERENCES [edfi].[CommunityProvider] ([CommunityProviderId])
GO

ALTER TABLE [edfi].[CommunityProviderLicense] WITH CHECK ADD CONSTRAINT [FK_CommunityProviderLicense_LicenseStatusDescriptor] FOREIGN KEY ([LicenseStatusDescriptorId])
REFERENCES [edfi].[LicenseStatusDescriptor] ([LicenseStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CommunityProviderLicense_LicenseStatusDescriptor]
ON [edfi].[CommunityProviderLicense] ([LicenseStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CommunityProviderLicense] WITH CHECK ADD CONSTRAINT [FK_CommunityProviderLicense_LicenseTypeDescriptor] FOREIGN KEY ([LicenseTypeDescriptorId])
REFERENCES [edfi].[LicenseTypeDescriptor] ([LicenseTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CommunityProviderLicense_LicenseTypeDescriptor]
ON [edfi].[CommunityProviderLicense] ([LicenseTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CompetencyLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_CompetencyLevelDescriptor_Descriptor] FOREIGN KEY ([CompetencyLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_CompetencyObjective_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_CompetencyObjective_GradeLevelDescriptor] FOREIGN KEY ([ObjectiveGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CompetencyObjective_GradeLevelDescriptor]
ON [edfi].[CompetencyObjective] ([ObjectiveGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Contact] WITH CHECK ADD CONSTRAINT [FK_Contact_LevelOfEducationDescriptor] FOREIGN KEY ([HighestCompletedLevelOfEducationDescriptorId])
REFERENCES [edfi].[LevelOfEducationDescriptor] ([LevelOfEducationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Contact_LevelOfEducationDescriptor]
ON [edfi].[Contact] ([HighestCompletedLevelOfEducationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Contact] WITH CHECK ADD CONSTRAINT [FK_Contact_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Contact_Person]
ON [edfi].[Contact] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Contact] WITH CHECK ADD CONSTRAINT [FK_Contact_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Contact_SexDescriptor]
ON [edfi].[Contact] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactAddress_AddressTypeDescriptor]
ON [edfi].[ContactAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactAddress_LocaleDescriptor]
ON [edfi].[ContactAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactAddress_StateAbbreviationDescriptor]
ON [edfi].[ContactAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_ContactAddressPeriod_ContactAddress] FOREIGN KEY ([ContactUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[ContactAddress] ([ContactUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ContactElectronicMail_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactElectronicMail] WITH CHECK ADD CONSTRAINT [FK_ContactElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactElectronicMail_ElectronicMailTypeDescriptor]
ON [edfi].[ContactElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_ContactIdentificationCode_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
GO

ALTER TABLE [edfi].[ContactIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_ContactIdentificationCode_ContactIdentificationSystemDescriptor] FOREIGN KEY ([ContactIdentificationSystemDescriptorId])
REFERENCES [edfi].[ContactIdentificationSystemDescriptor] ([ContactIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactIdentificationCode_ContactIdentificationSystemDescriptor]
ON [edfi].[ContactIdentificationCode] ([ContactIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_ContactIdentificationCode_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[ContactIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_ContactIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([ContactIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ContactInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactInternationalAddress_AddressTypeDescriptor]
ON [edfi].[ContactInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ContactInternationalAddress_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_ContactInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactInternationalAddress_CountryDescriptor]
ON [edfi].[ContactInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactLanguage] WITH CHECK ADD CONSTRAINT [FK_ContactLanguage_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactLanguage] WITH CHECK ADD CONSTRAINT [FK_ContactLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactLanguage_LanguageDescriptor]
ON [edfi].[ContactLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ContactLanguageUse_ContactLanguage] FOREIGN KEY ([ContactUSI], [LanguageDescriptorId])
REFERENCES [edfi].[ContactLanguage] ([ContactUSI], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactLanguageUse] WITH CHECK ADD CONSTRAINT [FK_ContactLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactLanguageUse_LanguageUseDescriptor]
ON [edfi].[ContactLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactOtherName] WITH CHECK ADD CONSTRAINT [FK_ContactOtherName_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactOtherName] WITH CHECK ADD CONSTRAINT [FK_ContactOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactOtherName_OtherNameTypeDescriptor]
ON [edfi].[ContactOtherName] ([OtherNameTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ContactPersonalIdentificationDocument_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ContactPersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactPersonalIdentificationDocument_CountryDescriptor]
ON [edfi].[ContactPersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ContactPersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactPersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[ContactPersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_ContactPersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactPersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[ContactPersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactTelephone] WITH CHECK ADD CONSTRAINT [FK_ContactTelephone_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContactTelephone] WITH CHECK ADD CONSTRAINT [FK_ContactTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ContactTelephone_TelephoneNumberTypeDescriptor]
ON [edfi].[ContactTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ContactTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ContactTypeDescriptor_Descriptor] FOREIGN KEY ([ContactTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContentClassDescriptor] WITH CHECK ADD CONSTRAINT [FK_ContentClassDescriptor_Descriptor] FOREIGN KEY ([ContentClassDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ContinuationOfServicesReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_ContinuationOfServicesReasonDescriptor_Descriptor] FOREIGN KEY ([ContinuationOfServicesReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CostRateDescriptor] WITH CHECK ADD CONSTRAINT [FK_CostRateDescriptor_Descriptor] FOREIGN KEY ([CostRateDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CoteachingStyleObservedDescriptor] WITH CHECK ADD CONSTRAINT [FK_CoteachingStyleObservedDescriptor_Descriptor] FOREIGN KEY ([CoteachingStyleObservedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CountryDescriptor] WITH CHECK ADD CONSTRAINT [FK_CountryDescriptor_Descriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CareerPathwayDescriptor] FOREIGN KEY ([CareerPathwayDescriptorId])
REFERENCES [edfi].[CareerPathwayDescriptor] ([CareerPathwayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Course_CareerPathwayDescriptor]
ON [edfi].[Course] ([CareerPathwayDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CourseDefinedByDescriptor] FOREIGN KEY ([CourseDefinedByDescriptorId])
REFERENCES [edfi].[CourseDefinedByDescriptor] ([CourseDefinedByDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Course_CourseDefinedByDescriptor]
ON [edfi].[Course] ([CourseDefinedByDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CourseGPAApplicabilityDescriptor] FOREIGN KEY ([CourseGPAApplicabilityDescriptorId])
REFERENCES [edfi].[CourseGPAApplicabilityDescriptor] ([CourseGPAApplicabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Course_CourseGPAApplicabilityDescriptor]
ON [edfi].[Course] ([CourseGPAApplicabilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CreditTypeDescriptor] FOREIGN KEY ([MinimumAvailableCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Course_CreditTypeDescriptor]
ON [edfi].[Course] ([MinimumAvailableCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_CreditTypeDescriptor1] FOREIGN KEY ([MaximumAvailableCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Course_CreditTypeDescriptor1]
ON [edfi].[Course] ([MaximumAvailableCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Course] WITH CHECK ADD CONSTRAINT [FK_Course_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[CourseAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CourseAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[CourseAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CourseAcademicSubject_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseAttemptResultDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseAttemptResultDescriptor_Descriptor] FOREIGN KEY ([CourseAttemptResultDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseCompetencyLevel] WITH CHECK ADD CONSTRAINT [FK_CourseCompetencyLevel_CompetencyLevelDescriptor] FOREIGN KEY ([CompetencyLevelDescriptorId])
REFERENCES [edfi].[CompetencyLevelDescriptor] ([CompetencyLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseCompetencyLevel_CompetencyLevelDescriptor]
ON [edfi].[CourseCompetencyLevel] ([CompetencyLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseCompetencyLevel] WITH CHECK ADD CONSTRAINT [FK_CourseCompetencyLevel_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseDefinedByDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseDefinedByDescriptor_Descriptor] FOREIGN KEY ([CourseDefinedByDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseGPAApplicabilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseGPAApplicabilityDescriptor_Descriptor] FOREIGN KEY ([CourseGPAApplicabilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CourseIdentificationCode_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CourseIdentificationCode_CourseIdentificationSystemDescriptor] FOREIGN KEY ([CourseIdentificationSystemDescriptorId])
REFERENCES [edfi].[CourseIdentificationSystemDescriptor] ([CourseIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseIdentificationCode_CourseIdentificationSystemDescriptor]
ON [edfi].[CourseIdentificationCode] ([CourseIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([CourseIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseLearningStandard] WITH CHECK ADD CONSTRAINT [FK_CourseLearningStandard_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseLearningStandard] WITH CHECK ADD CONSTRAINT [FK_CourseLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseLearningStandard_LearningStandard]
ON [edfi].[CourseLearningStandard] ([LearningStandardId] ASC)
GO

ALTER TABLE [edfi].[CourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CourseLevelCharacteristic_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CourseLevelCharacteristic_CourseLevelCharacteristicDescriptor] FOREIGN KEY ([CourseLevelCharacteristicDescriptorId])
REFERENCES [edfi].[CourseLevelCharacteristicDescriptor] ([CourseLevelCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseLevelCharacteristic_CourseLevelCharacteristicDescriptor]
ON [edfi].[CourseLevelCharacteristic] ([CourseLevelCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseLevelCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseLevelCharacteristicDescriptor_Descriptor] FOREIGN KEY ([CourseLevelCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CourseOfferedGradeLevel_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CourseOfferedGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseOfferedGradeLevel_GradeLevelDescriptor]
ON [edfi].[CourseOfferedGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseOffering] WITH CHECK ADD CONSTRAINT [FK_CourseOffering_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseOffering_Course]
ON [edfi].[CourseOffering] ([CourseCode] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[CourseOffering] WITH CHECK ADD CONSTRAINT [FK_CourseOffering_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[CourseOffering] WITH CHECK ADD CONSTRAINT [FK_CourseOffering_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CourseOffering_Session]
ON [edfi].[CourseOffering] ([SchoolId] ASC, [SchoolYear] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingCourseLevelCharacteristic_CourseLevelCharacteristicDescriptor] FOREIGN KEY ([CourseLevelCharacteristicDescriptorId])
REFERENCES [edfi].[CourseLevelCharacteristicDescriptor] ([CourseLevelCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseOfferingCourseLevelCharacteristic_CourseLevelCharacteristicDescriptor]
ON [edfi].[CourseOfferingCourseLevelCharacteristic] ([CourseLevelCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingCourseLevelCharacteristic_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingCurriculumUsed_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingCurriculumUsed_CurriculumUsedDescriptor] FOREIGN KEY ([CurriculumUsedDescriptorId])
REFERENCES [edfi].[CurriculumUsedDescriptor] ([CurriculumUsedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseOfferingCurriculumUsed_CurriculumUsedDescriptor]
ON [edfi].[CourseOfferingCurriculumUsed] ([CurriculumUsedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseOfferingOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingOfferedGradeLevel_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[CourseOfferingOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CourseOfferingOfferedGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseOfferingOfferedGradeLevel_GradeLevelDescriptor]
ON [edfi].[CourseOfferingOfferedGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseRepeatCodeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CourseRepeatCodeDescriptor_Descriptor] FOREIGN KEY ([CourseRepeatCodeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_Course] FOREIGN KEY ([CourseCode], [CourseEducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_Course]
ON [edfi].[CourseTranscript] ([CourseCode] ASC, [CourseEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_CourseAttemptResultDescriptor] FOREIGN KEY ([CourseAttemptResultDescriptorId])
REFERENCES [edfi].[CourseAttemptResultDescriptor] ([CourseAttemptResultDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_CourseAttemptResultDescriptor]
ON [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_CourseRepeatCodeDescriptor] FOREIGN KEY ([CourseRepeatCodeDescriptorId])
REFERENCES [edfi].[CourseRepeatCodeDescriptor] ([CourseRepeatCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_CourseRepeatCodeDescriptor]
ON [edfi].[CourseTranscript] ([CourseRepeatCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_CreditTypeDescriptor] FOREIGN KEY ([AttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_CreditTypeDescriptor]
ON [edfi].[CourseTranscript] ([AttemptedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_CreditTypeDescriptor1] FOREIGN KEY ([EarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_CreditTypeDescriptor1]
ON [edfi].[CourseTranscript] ([EarnedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_EducationOrganization] FOREIGN KEY ([ExternalEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_EducationOrganization]
ON [edfi].[CourseTranscript] ([ExternalEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_GradeLevelDescriptor] FOREIGN KEY ([WhenTakenGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_GradeLevelDescriptor]
ON [edfi].[CourseTranscript] ([WhenTakenGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_MethodCreditEarnedDescriptor] FOREIGN KEY ([MethodCreditEarnedDescriptorId])
REFERENCES [edfi].[MethodCreditEarnedDescriptor] ([MethodCreditEarnedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_MethodCreditEarnedDescriptor]
ON [edfi].[CourseTranscript] ([MethodCreditEarnedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_Staff] FOREIGN KEY ([ResponsibleTeacherStaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_Staff]
ON [edfi].[CourseTranscript] ([ResponsibleTeacherStaffUSI] ASC)
GO

ALTER TABLE [edfi].[CourseTranscript] WITH CHECK ADD CONSTRAINT [FK_CourseTranscript_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscript_StudentAcademicRecord]
ON [edfi].[CourseTranscript] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [StudentUSI] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscriptAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscriptAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[CourseTranscriptAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscriptAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptAcademicSubject_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptAlternativeCourseIdentificationCode_CourseIdentificationSystemDescriptor] FOREIGN KEY ([CourseIdentificationSystemDescriptorId])
REFERENCES [edfi].[CourseIdentificationSystemDescriptor] ([CourseIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscriptAlternativeCourseIdentificationCode_CourseIdentificationSystemDescriptor]
ON [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] ([CourseIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptAlternativeCourseIdentificationCode_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptCourseProgram] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptCourseProgram_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptCourseProgram] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptCourseProgram_Program] FOREIGN KEY ([CourseEducationOrganizationId], [CourseProgramName], [CourseProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscriptCourseProgram_Program]
ON [edfi].[CourseTranscriptCourseProgram] ([CourseEducationOrganizationId] ASC, [CourseProgramName] ASC, [CourseProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscriptCreditCategory] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptCreditCategory_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptCreditCategory] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptCreditCategory_CreditCategoryDescriptor] FOREIGN KEY ([CreditCategoryDescriptorId])
REFERENCES [edfi].[CreditCategoryDescriptor] ([CreditCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscriptCreditCategory_CreditCategoryDescriptor]
ON [edfi].[CourseTranscriptCreditCategory] ([CreditCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscriptEarnedAdditionalCredits] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptEarnedAdditionalCredits_AdditionalCreditTypeDescriptor] FOREIGN KEY ([AdditionalCreditTypeDescriptorId])
REFERENCES [edfi].[AdditionalCreditTypeDescriptor] ([AdditionalCreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscriptEarnedAdditionalCredits_AdditionalCreditTypeDescriptor]
ON [edfi].[CourseTranscriptEarnedAdditionalCredits] ([AdditionalCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscriptEarnedAdditionalCredits] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptEarnedAdditionalCredits_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptPartialCourseTranscriptAwards] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptPartialCourseTranscriptAwards_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptPartialCourseTranscriptAwards] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptPartialCourseTranscriptAwards_MethodCreditEarnedDescriptor] FOREIGN KEY ([MethodCreditEarnedDescriptorId])
REFERENCES [edfi].[MethodCreditEarnedDescriptor] ([MethodCreditEarnedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscriptPartialCourseTranscriptAwards_MethodCreditEarnedDescriptor]
ON [edfi].[CourseTranscriptPartialCourseTranscriptAwards] ([MethodCreditEarnedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CourseTranscriptSection] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptSection_CourseTranscript] FOREIGN KEY ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[CourseTranscript] ([CourseAttemptResultDescriptorId], [CourseCode], [CourseEducationOrganizationId], [EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CourseTranscriptSection] WITH CHECK ADD CONSTRAINT [FK_CourseTranscriptSection_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_CourseTranscriptSection_Section]
ON [edfi].[CourseTranscriptSection] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_Certification] FOREIGN KEY ([CertificationIdentifier], [CertificationNamespace])
REFERENCES [edfi].[Certification] ([CertificationIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_Certification]
ON [edfi].[Credential] ([CertificationIdentifier] ASC, [CertificationNamespace] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_CertificationRouteDescriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [edfi].[CertificationRouteDescriptor] ([CertificationRouteDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_CertificationRouteDescriptor]
ON [edfi].[Credential] ([CertificationRouteDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_CredentialFieldDescriptor] FOREIGN KEY ([CredentialFieldDescriptorId])
REFERENCES [edfi].[CredentialFieldDescriptor] ([CredentialFieldDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_CredentialFieldDescriptor]
ON [edfi].[Credential] ([CredentialFieldDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_CredentialStatusDescriptor] FOREIGN KEY ([CredentialStatusDescriptorId])
REFERENCES [edfi].[CredentialStatusDescriptor] ([CredentialStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_CredentialStatusDescriptor]
ON [edfi].[Credential] ([CredentialStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_CredentialTypeDescriptor] FOREIGN KEY ([CredentialTypeDescriptorId])
REFERENCES [edfi].[CredentialTypeDescriptor] ([CredentialTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_CredentialTypeDescriptor]
ON [edfi].[Credential] ([CredentialTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_EducatorRoleDescriptor] FOREIGN KEY ([EducatorRoleDescriptorId])
REFERENCES [edfi].[EducatorRoleDescriptor] ([EducatorRoleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_EducatorRoleDescriptor]
ON [edfi].[Credential] ([EducatorRoleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_Person]
ON [edfi].[Credential] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_StateAbbreviationDescriptor] FOREIGN KEY ([StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_StateAbbreviationDescriptor]
ON [edfi].[Credential] ([StateOfIssueStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_TeachingCredentialBasisDescriptor] FOREIGN KEY ([TeachingCredentialBasisDescriptorId])
REFERENCES [edfi].[TeachingCredentialBasisDescriptor] ([TeachingCredentialBasisDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_TeachingCredentialBasisDescriptor]
ON [edfi].[Credential] ([TeachingCredentialBasisDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Credential] WITH CHECK ADD CONSTRAINT [FK_Credential_TeachingCredentialDescriptor] FOREIGN KEY ([TeachingCredentialDescriptorId])
REFERENCES [edfi].[TeachingCredentialDescriptor] ([TeachingCredentialDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Credential_TeachingCredentialDescriptor]
ON [edfi].[Credential] ([TeachingCredentialDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CredentialAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CredentialAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[CredentialAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CredentialAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_CredentialAcademicSubject_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialEndorsement] WITH CHECK ADD CONSTRAINT [FK_CredentialEndorsement_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialEvent] WITH CHECK ADD CONSTRAINT [FK_CredentialEvent_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialEvent_Credential]
ON [edfi].[CredentialEvent] ([CredentialIdentifier] ASC, [StateOfIssueStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CredentialEvent] WITH CHECK ADD CONSTRAINT [FK_CredentialEvent_CredentialEventTypeDescriptor] FOREIGN KEY ([CredentialEventTypeDescriptorId])
REFERENCES [edfi].[CredentialEventTypeDescriptor] ([CredentialEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialEvent_CredentialEventTypeDescriptor]
ON [edfi].[CredentialEvent] ([CredentialEventTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CredentialEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CredentialEventTypeDescriptor_Descriptor] FOREIGN KEY ([CredentialEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialFieldDescriptor] WITH CHECK ADD CONSTRAINT [FK_CredentialFieldDescriptor_Descriptor] FOREIGN KEY ([CredentialFieldDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CredentialGradeLevel_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialGradeLevel] WITH CHECK ADD CONSTRAINT [FK_CredentialGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialGradeLevel_GradeLevelDescriptor]
ON [edfi].[CredentialGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CredentialStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_CredentialStatusDescriptor_Descriptor] FOREIGN KEY ([CredentialStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_CredentialStudentAcademicRecord_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CredentialStudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_CredentialStudentAcademicRecord_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CredentialStudentAcademicRecord_StudentAcademicRecord]
ON [edfi].[CredentialStudentAcademicRecord] ([EducationOrganizationId] ASC, [SchoolYear] ASC, [StudentUSI] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CredentialTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CredentialTypeDescriptor_Descriptor] FOREIGN KEY ([CredentialTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CreditCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_CreditCategoryDescriptor_Descriptor] FOREIGN KEY ([CreditCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CreditTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CreditTypeDescriptor_Descriptor] FOREIGN KEY ([CreditTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CrisisEvent] WITH CHECK ADD CONSTRAINT [FK_CrisisEvent_CrisisTypeDescriptor] FOREIGN KEY ([CrisisTypeDescriptorId])
REFERENCES [edfi].[CrisisTypeDescriptor] ([CrisisTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_CrisisEvent_CrisisTypeDescriptor]
ON [edfi].[CrisisEvent] ([CrisisTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[CrisisTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_CrisisTypeDescriptor_Descriptor] FOREIGN KEY ([CrisisTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CTEProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_CTEProgramServiceDescriptor_Descriptor] FOREIGN KEY ([CTEProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[CurriculumUsedDescriptor] WITH CHECK ADD CONSTRAINT [FK_CurriculumUsedDescriptor_Descriptor] FOREIGN KEY ([CurriculumUsedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DegreeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DegreeDescriptor_Descriptor] FOREIGN KEY ([DegreeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DeliveryMethodDescriptor] WITH CHECK ADD CONSTRAINT [FK_DeliveryMethodDescriptor_Descriptor] FOREIGN KEY ([DeliveryMethodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DescriptorMappingModelEntity] WITH CHECK ADD CONSTRAINT [FK_DescriptorMappingModelEntity_DescriptorMapping] FOREIGN KEY ([MappedNamespace], [MappedValue], [Namespace], [Value])
REFERENCES [edfi].[DescriptorMapping] ([MappedNamespace], [MappedValue], [Namespace], [Value])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DescriptorMappingModelEntity] WITH CHECK ADD CONSTRAINT [FK_DescriptorMappingModelEntity_ModelEntityDescriptor] FOREIGN KEY ([ModelEntityDescriptorId])
REFERENCES [edfi].[ModelEntityDescriptor] ([ModelEntityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_DescriptorMappingModelEntity_ModelEntityDescriptor]
ON [edfi].[DescriptorMappingModelEntity] ([ModelEntityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[DiagnosisDescriptor] WITH CHECK ADD CONSTRAINT [FK_DiagnosisDescriptor_Descriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DiplomaLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_DiplomaLevelDescriptor_Descriptor] FOREIGN KEY ([DiplomaLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DiplomaTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DiplomaTypeDescriptor_Descriptor] FOREIGN KEY ([DiplomaTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisabilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisabilityDescriptor_Descriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisabilityDesignationDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisabilityDesignationDescriptor_Descriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisabilityDeterminationSourceTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisabilityDeterminationSourceTypeDescriptor_Descriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineAction] WITH CHECK ADD CONSTRAINT [FK_DisciplineAction_DisciplineActionLengthDifferenceReasonDescriptor] FOREIGN KEY ([DisciplineActionLengthDifferenceReasonDescriptorId])
REFERENCES [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] ([DisciplineActionLengthDifferenceReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineAction_DisciplineActionLengthDifferenceReasonDescriptor]
ON [edfi].[DisciplineAction] ([DisciplineActionLengthDifferenceReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[DisciplineAction] WITH CHECK ADD CONSTRAINT [FK_DisciplineAction_School] FOREIGN KEY ([AssignmentSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineAction_School]
ON [edfi].[DisciplineAction] ([AssignmentSchoolId] ASC)
GO

ALTER TABLE [edfi].[DisciplineAction] WITH CHECK ADD CONSTRAINT [FK_DisciplineAction_School1] FOREIGN KEY ([ResponsibilitySchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineAction_School1]
ON [edfi].[DisciplineAction] ([ResponsibilitySchoolId] ASC)
GO

ALTER TABLE [edfi].[DisciplineAction] WITH CHECK ADD CONSTRAINT [FK_DisciplineAction_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[DisciplineActionDiscipline] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionDiscipline_DisciplineAction] FOREIGN KEY ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
REFERENCES [edfi].[DisciplineAction] ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineActionDiscipline] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionDiscipline_DisciplineDescriptor] FOREIGN KEY ([DisciplineDescriptorId])
REFERENCES [edfi].[DisciplineDescriptor] ([DisciplineDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineActionDiscipline_DisciplineDescriptor]
ON [edfi].[DisciplineActionDiscipline] ([DisciplineDescriptorId] ASC)
GO

ALTER TABLE [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionLengthDifferenceReasonDescriptor_Descriptor] FOREIGN KEY ([DisciplineActionLengthDifferenceReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineActionStaff] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionStaff_DisciplineAction] FOREIGN KEY ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
REFERENCES [edfi].[DisciplineAction] ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineActionStaff] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionStaff_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineActionStaff_Staff]
ON [edfi].[DisciplineActionStaff] ([StaffUSI] ASC)
GO

ALTER TABLE [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionStudentDisciplineIncidentBehaviorAssociation_DisciplineAction] FOREIGN KEY ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
REFERENCES [edfi].[DisciplineAction] ([DisciplineActionIdentifier], [DisciplineDate], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_DisciplineActionStudentDisciplineIncidentBehaviorAssociation_StudentDisciplineIncidentBehaviorAssociation] FOREIGN KEY ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentDisciplineIncidentBehaviorAssociation] ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineActionStudentDisciplineIncidentBehaviorAssociation_StudentDisciplineIncidentBehaviorAssociation]
ON [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] ([BehaviorDescriptorId] ASC, [IncidentIdentifier] ASC, [SchoolId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[DisciplineDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisciplineDescriptor_Descriptor] FOREIGN KEY ([DisciplineDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncident] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncident_IncidentLocationDescriptor] FOREIGN KEY ([IncidentLocationDescriptorId])
REFERENCES [edfi].[IncidentLocationDescriptor] ([IncidentLocationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineIncident_IncidentLocationDescriptor]
ON [edfi].[DisciplineIncident] ([IncidentLocationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[DisciplineIncident] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncident_ReporterDescriptionDescriptor] FOREIGN KEY ([ReporterDescriptionDescriptorId])
REFERENCES [edfi].[ReporterDescriptionDescriptor] ([ReporterDescriptionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineIncident_ReporterDescriptionDescriptor]
ON [edfi].[DisciplineIncident] ([ReporterDescriptionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[DisciplineIncident] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncident_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[DisciplineIncidentBehavior] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentBehavior_BehaviorDescriptor] FOREIGN KEY ([BehaviorDescriptorId])
REFERENCES [edfi].[BehaviorDescriptor] ([BehaviorDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineIncidentBehavior_BehaviorDescriptor]
ON [edfi].[DisciplineIncidentBehavior] ([BehaviorDescriptorId] ASC)
GO

ALTER TABLE [edfi].[DisciplineIncidentBehavior] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentBehavior_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncidentExternalParticipant] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentExternalParticipant_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncidentExternalParticipant] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentExternalParticipant_DisciplineIncidentParticipationCodeDescriptor] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[DisciplineIncidentParticipationCodeDescriptor] ([DisciplineIncidentParticipationCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineIncidentExternalParticipant_DisciplineIncidentParticipationCodeDescriptor]
ON [edfi].[DisciplineIncidentExternalParticipant] ([DisciplineIncidentParticipationCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[DisciplineIncidentParticipationCodeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentParticipationCodeDescriptor_Descriptor] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncidentWeapon] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentWeapon_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DisciplineIncidentWeapon] WITH CHECK ADD CONSTRAINT [FK_DisciplineIncidentWeapon_WeaponDescriptor] FOREIGN KEY ([WeaponDescriptorId])
REFERENCES [edfi].[WeaponDescriptor] ([WeaponDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_DisciplineIncidentWeapon_WeaponDescriptor]
ON [edfi].[DisciplineIncidentWeapon] ([WeaponDescriptorId] ASC)
GO

ALTER TABLE [edfi].[DisplacedStudentStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_DisplacedStudentStatusDescriptor_Descriptor] FOREIGN KEY ([DisplacedStudentStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DualCreditInstitutionDescriptor] WITH CHECK ADD CONSTRAINT [FK_DualCreditInstitutionDescriptor_Descriptor] FOREIGN KEY ([DualCreditInstitutionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[DualCreditTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_DualCreditTypeDescriptor_Descriptor] FOREIGN KEY ([DualCreditTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EconomicDisadvantageDescriptor] WITH CHECK ADD CONSTRAINT [FK_EconomicDisadvantageDescriptor_Descriptor] FOREIGN KEY ([EconomicDisadvantageDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationalEnvironmentDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationalEnvironmentDescriptor_Descriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContent_ContentClassDescriptor] FOREIGN KEY ([ContentClassDescriptorId])
REFERENCES [edfi].[ContentClassDescriptor] ([ContentClassDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationContent_ContentClassDescriptor]
ON [edfi].[EducationContent] ([ContentClassDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContent_CostRateDescriptor] FOREIGN KEY ([CostRateDescriptorId])
REFERENCES [edfi].[CostRateDescriptor] ([CostRateDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationContent_CostRateDescriptor]
ON [edfi].[EducationContent] ([CostRateDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContent_InteractivityStyleDescriptor] FOREIGN KEY ([InteractivityStyleDescriptorId])
REFERENCES [edfi].[InteractivityStyleDescriptor] ([InteractivityStyleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationContent_InteractivityStyleDescriptor]
ON [edfi].[EducationContent] ([InteractivityStyleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContent_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationContent_LearningStandard]
ON [edfi].[EducationContent] ([LearningStandardId] ASC)
GO

ALTER TABLE [edfi].[EducationContentAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducationContentAppropriateGradeLevel_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducationContentAppropriateGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationContentAppropriateGradeLevel_GradeLevelDescriptor]
ON [edfi].[EducationContentAppropriateGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationContentAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_EducationContentAppropriateSex_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_EducationContentAppropriateSex_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationContentAppropriateSex_SexDescriptor]
ON [edfi].[EducationContentAppropriateSex] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationContentAuthor] WITH CHECK ADD CONSTRAINT [FK_EducationContentAuthor_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentDerivativeSourceEducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContentDerivativeSourceEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentDerivativeSourceEducationContent] WITH CHECK ADD CONSTRAINT [FK_EducationContentDerivativeSourceEducationContent_EducationContent1] FOREIGN KEY ([DerivativeSourceContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_EducationContentDerivativeSourceEducationContent_EducationContent1]
ON [edfi].[EducationContentDerivativeSourceEducationContent] ([DerivativeSourceContentIdentifier] ASC)
GO

ALTER TABLE [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] WITH CHECK ADD CONSTRAINT [FK_EducationContentDerivativeSourceLearningResourceMetadataURI_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentDerivativeSourceURI] WITH CHECK ADD CONSTRAINT [FK_EducationContentDerivativeSourceURI_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentLanguage] WITH CHECK ADD CONSTRAINT [FK_EducationContentLanguage_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationContentLanguage] WITH CHECK ADD CONSTRAINT [FK_EducationContentLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationContentLanguage_LanguageDescriptor]
ON [edfi].[EducationContentLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganization] WITH CHECK ADD CONSTRAINT [FK_EducationOrganization_OperationalStatusDescriptor] FOREIGN KEY ([OperationalStatusDescriptorId])
REFERENCES [edfi].[OperationalStatusDescriptor] ([OperationalStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganization_OperationalStatusDescriptor]
ON [edfi].[EducationOrganization] ([OperationalStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationAddress_AddressTypeDescriptor]
ON [edfi].[EducationOrganizationAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddress_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationAddress_LocaleDescriptor]
ON [edfi].[EducationOrganizationAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationAddress_StateAbbreviationDescriptor]
ON [edfi].[EducationOrganizationAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAddressPeriod_EducationOrganizationAddress] FOREIGN KEY ([EducationOrganizationId], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[EducationOrganizationAddress] ([EducationOrganizationId], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationAssociationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationAssociationTypeDescriptor_Descriptor] FOREIGN KEY ([EducationOrganizationAssociationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationCategory] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationCategory_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationCategory] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationCategory_EducationOrganizationCategoryDescriptor] FOREIGN KEY ([EducationOrganizationCategoryDescriptorId])
REFERENCES [edfi].[EducationOrganizationCategoryDescriptor] ([EducationOrganizationCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationCategory_EducationOrganizationCategoryDescriptor]
ON [edfi].[EducationOrganizationCategory] ([EducationOrganizationCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationCategoryDescriptor_Descriptor] FOREIGN KEY ([EducationOrganizationCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIdentificationCode_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[EducationOrganizationIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIdentificationCode_EducationOrganizationIdentificationSystemDescriptor] FOREIGN KEY ([EducationOrganizationIdentificationSystemDescriptorId])
REFERENCES [edfi].[EducationOrganizationIdentificationSystemDescriptor] ([EducationOrganizationIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationIdentificationCode_EducationOrganizationIdentificationSystemDescriptor]
ON [edfi].[EducationOrganizationIdentificationCode] ([EducationOrganizationIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([EducationOrganizationIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationIndicator] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicator_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationIndicator] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicator_IndicatorDescriptor] FOREIGN KEY ([IndicatorDescriptorId])
REFERENCES [edfi].[IndicatorDescriptor] ([IndicatorDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationIndicator_IndicatorDescriptor]
ON [edfi].[EducationOrganizationIndicator] ([IndicatorDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationIndicator] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicator_IndicatorGroupDescriptor] FOREIGN KEY ([IndicatorGroupDescriptorId])
REFERENCES [edfi].[IndicatorGroupDescriptor] ([IndicatorGroupDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationIndicator_IndicatorGroupDescriptor]
ON [edfi].[EducationOrganizationIndicator] ([IndicatorGroupDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationIndicator] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicator_IndicatorLevelDescriptor] FOREIGN KEY ([IndicatorLevelDescriptorId])
REFERENCES [edfi].[IndicatorLevelDescriptor] ([IndicatorLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationIndicator_IndicatorLevelDescriptor]
ON [edfi].[EducationOrganizationIndicator] ([IndicatorLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationIndicatorPeriod] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationIndicatorPeriod_EducationOrganizationIndicator] FOREIGN KEY ([EducationOrganizationId], [IndicatorDescriptorId])
REFERENCES [edfi].[EducationOrganizationIndicator] ([EducationOrganizationId], [IndicatorDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationInstitutionTelephone] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInstitutionTelephone_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationInstitutionTelephone] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInstitutionTelephone_InstitutionTelephoneNumberTypeDescriptor] FOREIGN KEY ([InstitutionTelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[InstitutionTelephoneNumberTypeDescriptor] ([InstitutionTelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationInstitutionTelephone_InstitutionTelephoneNumberTypeDescriptor]
ON [edfi].[EducationOrganizationInstitutionTelephone] ([InstitutionTelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationInternationalAddress_AddressTypeDescriptor]
ON [edfi].[EducationOrganizationInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationInternationalAddress_CountryDescriptor]
ON [edfi].[EducationOrganizationInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInternationalAddress_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInterventionPrescriptionAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationInterventionPrescriptionAssociation_InterventionPrescription] FOREIGN KEY ([InterventionPrescriptionEducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationInterventionPrescriptionAssociation_InterventionPrescription]
ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ([InterventionPrescriptionEducationOrganizationId] ASC, [InterventionPrescriptionIdentificationCode] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationNetwork] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationNetwork_EducationOrganization] FOREIGN KEY ([EducationOrganizationNetworkId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationOrganizationNetwork] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationNetwork_NetworkPurposeDescriptor] FOREIGN KEY ([NetworkPurposeDescriptorId])
REFERENCES [edfi].[NetworkPurposeDescriptor] ([NetworkPurposeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationNetwork_NetworkPurposeDescriptor]
ON [edfi].[EducationOrganizationNetwork] ([NetworkPurposeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationNetworkAssociation_EducationOrganization] FOREIGN KEY ([MemberEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationNetworkAssociation_EducationOrganization]
ON [edfi].[EducationOrganizationNetworkAssociation] ([MemberEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationNetworkAssociation_EducationOrganizationNetwork] FOREIGN KEY ([EducationOrganizationNetworkId])
REFERENCES [edfi].[EducationOrganizationNetwork] ([EducationOrganizationNetworkId])
GO

ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationPeerAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] WITH CHECK ADD CONSTRAINT [FK_EducationOrganizationPeerAssociation_EducationOrganization1] FOREIGN KEY ([PeerEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationOrganizationPeerAssociation_EducationOrganization1]
ON [edfi].[EducationOrganizationPeerAssociation] ([PeerEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[EducationPlanDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducationPlanDescriptor_Descriptor] FOREIGN KEY ([EducationPlanDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationServiceCenter] WITH CHECK ADD CONSTRAINT [FK_EducationServiceCenter_EducationOrganization] FOREIGN KEY ([EducationServiceCenterId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducationServiceCenter] WITH CHECK ADD CONSTRAINT [FK_EducationServiceCenter_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
GO

CREATE NONCLUSTERED INDEX [FK_EducationServiceCenter_StateEducationAgency]
ON [edfi].[EducationServiceCenter] ([StateEducationAgencyId] ASC)
GO

ALTER TABLE [edfi].[EducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgram_AccreditationStatusDescriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [edfi].[AccreditationStatusDescriptor] ([AccreditationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgram_AccreditationStatusDescriptor]
ON [edfi].[EducatorPreparationProgram] ([AccreditationStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgram_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[EducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgram_ProgramTypeDescriptor] FOREIGN KEY ([ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramTypeDescriptor] ([ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgram_ProgramTypeDescriptor]
ON [edfi].[EducatorPreparationProgram] ([ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducatorPreparationProgramGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgramGradeLevel_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EducatorPreparationProgramGradeLevel] WITH CHECK ADD CONSTRAINT [FK_EducatorPreparationProgramGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EducatorPreparationProgramGradeLevel_GradeLevelDescriptor]
ON [edfi].[EducatorPreparationProgramGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EducatorRoleDescriptor] WITH CHECK ADD CONSTRAINT [FK_EducatorRoleDescriptor_Descriptor] FOREIGN KEY ([EducatorRoleDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ElectronicMailTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ElectronicMailTypeDescriptor_Descriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EligibilityDelayReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_EligibilityDelayReasonDescriptor_Descriptor] FOREIGN KEY ([EligibilityDelayReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EligibilityEvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EligibilityEvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([EligibilityEvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EmploymentStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_EmploymentStatusDescriptor_Descriptor] FOREIGN KEY ([EmploymentStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EnglishLanguageExamDescriptor] WITH CHECK ADD CONSTRAINT [FK_EnglishLanguageExamDescriptor_Descriptor] FOREIGN KEY ([EnglishLanguageExamDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EnrollmentTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EnrollmentTypeDescriptor_Descriptor] FOREIGN KEY ([EnrollmentTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EntryGradeLevelReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_EntryGradeLevelReasonDescriptor_Descriptor] FOREIGN KEY ([EntryGradeLevelReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EntryTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EntryTypeDescriptor_Descriptor] FOREIGN KEY ([EntryTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EPPDegreeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EPPDegreeTypeDescriptor_Descriptor] FOREIGN KEY ([EPPDegreeTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EPPProgramPathwayDescriptor] WITH CHECK ADD CONSTRAINT [FK_EPPProgramPathwayDescriptor_Descriptor] FOREIGN KEY ([EPPProgramPathwayDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Evaluation] WITH CHECK ADD CONSTRAINT [FK_Evaluation_EvaluationTypeDescriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [edfi].[EvaluationTypeDescriptor] ([EvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Evaluation_EvaluationTypeDescriptor]
ON [edfi].[Evaluation] ([EvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Evaluation] WITH CHECK ADD CONSTRAINT [FK_Evaluation_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Evaluation_PerformanceEvaluation]
ON [edfi].[Evaluation] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationDelayReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationDelayReasonDescriptor_Descriptor] FOREIGN KEY ([EvaluationDelayReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationElement] WITH CHECK ADD CONSTRAINT [FK_EvaluationElement_EvaluationObjective] FOREIGN KEY ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationObjective] ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElement_EvaluationObjective]
ON [edfi].[EvaluationElement] ([EducationOrganizationId] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationElement] WITH CHECK ADD CONSTRAINT [FK_EvaluationElement_EvaluationTypeDescriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [edfi].[EvaluationTypeDescriptor] ([EvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElement_EvaluationTypeDescriptor]
ON [edfi].[EvaluationElement] ([EvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationElementRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRating_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRating_EvaluationElement]
ON [edfi].[EvaluationElementRating] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationElementRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRating_EvaluationElementRatingLevelDescriptor] FOREIGN KEY ([EvaluationElementRatingLevelDescriptorId])
REFERENCES [edfi].[EvaluationElementRatingLevelDescriptor] ([EvaluationElementRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRating_EvaluationElementRatingLevelDescriptor]
ON [edfi].[EvaluationElementRating] ([EvaluationElementRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationElementRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRating_EvaluationObjectiveRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[EvaluationObjectiveRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRating_EvaluationObjectiveRating]
ON [edfi].[EvaluationElementRating] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationElementRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingLevel_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationElementRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingLevel_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRatingLevel_EvaluationRatingLevelDescriptor]
ON [edfi].[EvaluationElementRatingLevel] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationElementRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingLevelDescriptor_Descriptor] FOREIGN KEY ([EvaluationElementRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationElementRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingResult_EvaluationElementRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElementRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationElementRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationElementRatingResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationElementRatingResult_ResultDatatypeTypeDescriptor]
ON [edfi].[EvaluationElementRatingResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjective_Evaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[Evaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjective_Evaluation]
ON [edfi].[EvaluationObjective] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjective_EvaluationTypeDescriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [edfi].[EvaluationTypeDescriptor] ([EvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjective_EvaluationTypeDescriptor]
ON [edfi].[EvaluationObjective] ([EvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationObjectiveRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRating_EvaluationObjective] FOREIGN KEY ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationObjective] ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRating_EvaluationObjective]
ON [edfi].[EvaluationObjectiveRating] ([EducationOrganizationId] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationObjectiveRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRating_EvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[EvaluationRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRating_EvaluationRating]
ON [edfi].[EvaluationObjectiveRating] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationObjectiveRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRating_ObjectiveRatingLevelDescriptor] FOREIGN KEY ([ObjectiveRatingLevelDescriptorId])
REFERENCES [edfi].[ObjectiveRatingLevelDescriptor] ([ObjectiveRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRating_ObjectiveRatingLevelDescriptor]
ON [edfi].[EvaluationObjectiveRating] ([ObjectiveRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationObjectiveRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRatingLevel_EvaluationObjective] FOREIGN KEY ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationObjective] ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationObjectiveRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRatingLevel_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRatingLevel_EvaluationRatingLevelDescriptor]
ON [edfi].[EvaluationObjectiveRatingLevel] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationObjectiveRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRatingResult_EvaluationObjectiveRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[EvaluationObjectiveRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationObjectiveRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationObjectiveRatingResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationObjectiveRatingResult_ResultDatatypeTypeDescriptor]
ON [edfi].[EvaluationObjectiveRatingResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationPeriodDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationPeriodDescriptor_Descriptor] FOREIGN KEY ([EvaluationPeriodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_Evaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[Evaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_Evaluation]
ON [edfi].[EvaluationRating] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_EvaluationRatingLevelDescriptor]
ON [edfi].[EvaluationRating] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_EvaluationRatingStatusDescriptor] FOREIGN KEY ([EvaluationRatingStatusDescriptorId])
REFERENCES [edfi].[EvaluationRatingStatusDescriptor] ([EvaluationRatingStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_EvaluationRatingStatusDescriptor]
ON [edfi].[EvaluationRating] ([EvaluationRatingStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_PerformanceEvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[PerformanceEvaluationRating] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_PerformanceEvaluationRating]
ON [edfi].[EvaluationRating] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationRating] WITH CHECK ADD CONSTRAINT [FK_EvaluationRating_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRating_Section]
ON [edfi].[EvaluationRating] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[EvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingLevel_Evaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[Evaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingLevel_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingLevel_EvaluationRatingLevelDescriptor]
ON [edfi].[EvaluationRatingLevel] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingLevelDescriptor_Descriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingResult_EvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[EvaluationRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingResult_ResultDatatypeTypeDescriptor]
ON [edfi].[EvaluationRatingResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewer_EvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[EvaluationRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewer_Person] FOREIGN KEY ([ReviewerPersonId], [ReviewerSourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRatingReviewer_Person]
ON [edfi].[EvaluationRatingReviewer] ([ReviewerPersonId] ASC, [ReviewerSourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationRatingReviewerReceivedTraining] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingReviewerReceivedTraining_EvaluationRatingReviewer] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId], [FirstName], [LastSurname])
REFERENCES [edfi].[EvaluationRatingReviewer] ([EducationOrganizationId], [EvaluationDate], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId], [FirstName], [LastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationRatingStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationRatingStatusDescriptor_Descriptor] FOREIGN KEY ([EvaluationRatingStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EvaluationRubricDimension] WITH CHECK ADD CONSTRAINT [FK_EvaluationRubricDimension_ProgramEvaluationElement] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationElement] ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRubricDimension_ProgramEvaluationElement]
ON [edfi].[EvaluationRubricDimension] ([ProgramEducationOrganizationId] ASC, [ProgramEvaluationElementTitle] ASC, [ProgramEvaluationPeriodDescriptorId] ASC, [ProgramEvaluationTitle] ASC, [ProgramEvaluationTypeDescriptorId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationRubricDimension] WITH CHECK ADD CONSTRAINT [FK_EvaluationRubricDimension_RatingLevelDescriptor] FOREIGN KEY ([EvaluationRubricRatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_EvaluationRubricDimension_RatingLevelDescriptor]
ON [edfi].[EvaluationRubricDimension] ([EvaluationRubricRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[EvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_EvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([EvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[EventCircumstanceDescriptor] WITH CHECK ADD CONSTRAINT [FK_EventCircumstanceDescriptor_Descriptor] FOREIGN KEY ([EventCircumstanceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ExitWithdrawTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ExitWithdrawTypeDescriptor_Descriptor] FOREIGN KEY ([ExitWithdrawTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FederalLocaleCodeDescriptor] WITH CHECK ADD CONSTRAINT [FK_FederalLocaleCodeDescriptor_Descriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FeederSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_FeederSchoolAssociation_School] FOREIGN KEY ([FeederSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_FeederSchoolAssociation_School]
ON [edfi].[FeederSchoolAssociation] ([FeederSchoolId] ASC)
GO

ALTER TABLE [edfi].[FeederSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_FeederSchoolAssociation_School1] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperience_EducatorPreparationProgram]
ON [edfi].[FieldworkExperience] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_FieldworkTypeDescriptor] FOREIGN KEY ([FieldworkTypeDescriptorId])
REFERENCES [edfi].[FieldworkTypeDescriptor] ([FieldworkTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperience_FieldworkTypeDescriptor]
ON [edfi].[FieldworkExperience] ([FieldworkTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[FieldworkExperience] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperience_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[FieldworkExperienceCoteaching] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperienceCoteaching_FieldworkExperience] FOREIGN KEY ([BeginDate], [FieldworkIdentifier], [StudentUSI])
REFERENCES [edfi].[FieldworkExperience] ([BeginDate], [FieldworkIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FieldworkExperienceSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperienceSectionAssociation_FieldworkExperience] FOREIGN KEY ([BeginDate], [FieldworkIdentifier], [StudentUSI])
REFERENCES [edfi].[FieldworkExperience] ([BeginDate], [FieldworkIdentifier], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperienceSectionAssociation_FieldworkExperience]
ON [edfi].[FieldworkExperienceSectionAssociation] ([BeginDate] ASC, [FieldworkIdentifier] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[FieldworkExperienceSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_FieldworkExperienceSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_FieldworkExperienceSectionAssociation_Section]
ON [edfi].[FieldworkExperienceSectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[FieldworkTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_FieldworkTypeDescriptor_Descriptor] FOREIGN KEY ([FieldworkTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FinancialAid] WITH CHECK ADD CONSTRAINT [FK_FinancialAid_AidTypeDescriptor] FOREIGN KEY ([AidTypeDescriptorId])
REFERENCES [edfi].[AidTypeDescriptor] ([AidTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FinancialAid_AidTypeDescriptor]
ON [edfi].[FinancialAid] ([AidTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[FinancialAid] WITH CHECK ADD CONSTRAINT [FK_FinancialAid_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[FinancialCollectionDescriptor] WITH CHECK ADD CONSTRAINT [FK_FinancialCollectionDescriptor_Descriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FunctionDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_FunctionDimensionReportingTag_FunctionDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[FunctionDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FunctionDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_FunctionDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FunctionDimensionReportingTag_ReportingTagDescriptor]
ON [edfi].[FunctionDimensionReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[FundDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_FundDimensionReportingTag_FundDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[FundDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[FundDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_FundDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_FundDimensionReportingTag_ReportingTagDescriptor]
ON [edfi].[FundDimensionReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[FundingSourceDescriptor] WITH CHECK ADD CONSTRAINT [FK_FundingSourceDescriptor_Descriptor] FOREIGN KEY ([FundingSourceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociation_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GeneralStudentProgramAssociation_Program]
ON [edfi].[GeneralStudentProgramAssociation] ([ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociation_ReasonExitedDescriptor] FOREIGN KEY ([ReasonExitedDescriptorId])
REFERENCES [edfi].[ReasonExitedDescriptor] ([ReasonExitedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GeneralStudentProgramAssociation_ReasonExitedDescriptor]
ON [edfi].[GeneralStudentProgramAssociation] ([ReasonExitedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociationProgramParticipationStatus_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] WITH CHECK ADD CONSTRAINT [FK_GeneralStudentProgramAssociationProgramParticipationStatus_ParticipationStatusDescriptor] FOREIGN KEY ([ParticipationStatusDescriptorId])
REFERENCES [edfi].[ParticipationStatusDescriptor] ([ParticipationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GeneralStudentProgramAssociationProgramParticipationStatus_ParticipationStatusDescriptor]
ON [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] ([ParticipationStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Goal] WITH CHECK ADD CONSTRAINT [FK_Goal_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Goal_EvaluationElement]
ON [edfi].[Goal] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Goal] WITH CHECK ADD CONSTRAINT [FK_Goal_EvaluationObjective] FOREIGN KEY ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationObjective] ([EducationOrganizationId], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Goal_EvaluationObjective]
ON [edfi].[Goal] ([EducationOrganizationId] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Goal] WITH CHECK ADD CONSTRAINT [FK_Goal_Goal] FOREIGN KEY ([ParentAssignmentDate], [ParentGoalTitle], [ParentPersonId], [ParentSourceSystemDescriptorId])
REFERENCES [edfi].[Goal] ([AssignmentDate], [GoalTitle], [PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Goal_Goal]
ON [edfi].[Goal] ([ParentAssignmentDate] ASC, [ParentGoalTitle] ASC, [ParentPersonId] ASC, [ParentSourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Goal] WITH CHECK ADD CONSTRAINT [FK_Goal_GoalTypeDescriptor] FOREIGN KEY ([GoalTypeDescriptorId])
REFERENCES [edfi].[GoalTypeDescriptor] ([GoalTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Goal_GoalTypeDescriptor]
ON [edfi].[Goal] ([GoalTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Goal] WITH CHECK ADD CONSTRAINT [FK_Goal_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Goal_Person]
ON [edfi].[Goal] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GoalTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GoalTypeDescriptor_Descriptor] FOREIGN KEY ([GoalTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Grade] WITH CHECK ADD CONSTRAINT [FK_Grade_GradeTypeDescriptor] FOREIGN KEY ([GradeTypeDescriptorId])
REFERENCES [edfi].[GradeTypeDescriptor] ([GradeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Grade_GradeTypeDescriptor]
ON [edfi].[Grade] ([GradeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Grade] WITH CHECK ADD CONSTRAINT [FK_Grade_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodName], [SchoolId], [GradingPeriodSchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [GradingPeriodName], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_Grade_GradingPeriod]
ON [edfi].[Grade] ([GradingPeriodDescriptorId] ASC, [GradingPeriodName] ASC, [SchoolId] ASC, [GradingPeriodSchoolYear] ASC)
GO

ALTER TABLE [edfi].[Grade] WITH CHECK ADD CONSTRAINT [FK_Grade_PerformanceBaseConversionDescriptor] FOREIGN KEY ([PerformanceBaseConversionDescriptorId])
REFERENCES [edfi].[PerformanceBaseConversionDescriptor] ([PerformanceBaseConversionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Grade_PerformanceBaseConversionDescriptor]
ON [edfi].[Grade] ([PerformanceBaseConversionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Grade] WITH CHECK ADD CONSTRAINT [FK_Grade_StudentSectionAssociation] FOREIGN KEY ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentSectionAssociation] ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_Grade_StudentSectionAssociation]
ON [edfi].[Grade] ([BeginDate] ASC, [LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[GradebookEntry] WITH CHECK ADD CONSTRAINT [FK_GradebookEntry_GradebookEntryTypeDescriptor] FOREIGN KEY ([GradebookEntryTypeDescriptorId])
REFERENCES [edfi].[GradebookEntryTypeDescriptor] ([GradebookEntryTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GradebookEntry_GradebookEntryTypeDescriptor]
ON [edfi].[GradebookEntry] ([GradebookEntryTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GradebookEntry] WITH CHECK ADD CONSTRAINT [FK_GradebookEntry_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodName], [SchoolId], [SchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [GradingPeriodName], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_GradebookEntry_GradingPeriod]
ON [edfi].[GradebookEntry] ([GradingPeriodDescriptorId] ASC, [GradingPeriodName] ASC, [SchoolId] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [edfi].[GradebookEntry] WITH CHECK ADD CONSTRAINT [FK_GradebookEntry_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_GradebookEntry_Section]
ON [edfi].[GradebookEntry] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[GradebookEntryLearningStandard] WITH CHECK ADD CONSTRAINT [FK_GradebookEntryLearningStandard_GradebookEntry] FOREIGN KEY ([GradebookEntryIdentifier], [Namespace])
REFERENCES [edfi].[GradebookEntry] ([GradebookEntryIdentifier], [Namespace])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[GradebookEntryLearningStandard] WITH CHECK ADD CONSTRAINT [FK_GradebookEntryLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_GradebookEntryLearningStandard_LearningStandard]
ON [edfi].[GradebookEntryLearningStandard] ([LearningStandardId] ASC)
GO

ALTER TABLE [edfi].[GradebookEntryTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradebookEntryTypeDescriptor_Descriptor] FOREIGN KEY ([GradebookEntryTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GradeLearningStandardGrade] WITH CHECK ADD CONSTRAINT [FK_GradeLearningStandardGrade_Grade] FOREIGN KEY ([BeginDate], [GradeTypeDescriptorId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolYear], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[Grade] ([BeginDate], [GradeTypeDescriptorId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolYear], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[GradeLearningStandardGrade] WITH CHECK ADD CONSTRAINT [FK_GradeLearningStandardGrade_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_GradeLearningStandardGrade_LearningStandard]
ON [edfi].[GradeLearningStandardGrade] ([LearningStandardId] ASC)
GO

ALTER TABLE [edfi].[GradeLearningStandardGrade] WITH CHECK ADD CONSTRAINT [FK_GradeLearningStandardGrade_PerformanceBaseConversionDescriptor] FOREIGN KEY ([PerformanceBaseConversionDescriptorId])
REFERENCES [edfi].[PerformanceBaseConversionDescriptor] ([PerformanceBaseConversionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GradeLearningStandardGrade_PerformanceBaseConversionDescriptor]
ON [edfi].[GradeLearningStandardGrade] ([PerformanceBaseConversionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GradeLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradeLevelDescriptor_Descriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GradePointAverageTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradePointAverageTypeDescriptor_Descriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GradeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradeTypeDescriptor_Descriptor] FOREIGN KEY ([GradeTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GradingPeriod] WITH CHECK ADD CONSTRAINT [FK_GradingPeriod_GradingPeriodDescriptor] FOREIGN KEY ([GradingPeriodDescriptorId])
REFERENCES [edfi].[GradingPeriodDescriptor] ([GradingPeriodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GradingPeriod_GradingPeriodDescriptor]
ON [edfi].[GradingPeriod] ([GradingPeriodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GradingPeriod] WITH CHECK ADD CONSTRAINT [FK_GradingPeriod_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[GradingPeriod] WITH CHECK ADD CONSTRAINT [FK_GradingPeriod_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_GradingPeriod_SchoolYearType]
ON [edfi].[GradingPeriod] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[GradingPeriodDescriptor] WITH CHECK ADD CONSTRAINT [FK_GradingPeriodDescriptor_Descriptor] FOREIGN KEY ([GradingPeriodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlan] WITH CHECK ADD CONSTRAINT [FK_GraduationPlan_CreditTypeDescriptor] FOREIGN KEY ([TotalRequiredCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlan_CreditTypeDescriptor]
ON [edfi].[GraduationPlan] ([TotalRequiredCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlan] WITH CHECK ADD CONSTRAINT [FK_GraduationPlan_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[GraduationPlan] WITH CHECK ADD CONSTRAINT [FK_GraduationPlan_GraduationPlanTypeDescriptor] FOREIGN KEY ([GraduationPlanTypeDescriptorId])
REFERENCES [edfi].[GraduationPlanTypeDescriptor] ([GraduationPlanTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlan_GraduationPlanTypeDescriptor]
ON [edfi].[GraduationPlan] ([GraduationPlanTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlan] WITH CHECK ADD CONSTRAINT [FK_GraduationPlan_SchoolYearType] FOREIGN KEY ([GraduationSchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlan_SchoolYearType]
ON [edfi].[GraduationPlan] ([GraduationSchoolYear] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourse_CreditTypeDescriptor] FOREIGN KEY ([CreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanCreditsByCourse_CreditTypeDescriptor]
ON [edfi].[GraduationPlanCreditsByCourse] ([CreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourse_GradeLevelDescriptor] FOREIGN KEY ([WhenTakenGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanCreditsByCourse_GradeLevelDescriptor]
ON [edfi].[GraduationPlanCreditsByCourse] ([WhenTakenGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourse_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourseCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourseCourse_Course] FOREIGN KEY ([CourseCode], [CourseEducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanCreditsByCourseCourse_Course]
ON [edfi].[GraduationPlanCreditsByCourseCourse] ([CourseCode] ASC, [CourseEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCourseCourse] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCourseCourse_GraduationPlanCreditsByCourse] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [CourseSetName])
REFERENCES [edfi].[GraduationPlanCreditsByCourse] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [CourseSetName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCreditCategory] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCreditCategory_CreditCategoryDescriptor] FOREIGN KEY ([CreditCategoryDescriptorId])
REFERENCES [edfi].[CreditCategoryDescriptor] ([CreditCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanCreditsByCreditCategory_CreditCategoryDescriptor]
ON [edfi].[GraduationPlanCreditsByCreditCategory] ([CreditCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCreditCategory] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCreditCategory_CreditTypeDescriptor] FOREIGN KEY ([CreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanCreditsByCreditCategory_CreditTypeDescriptor]
ON [edfi].[GraduationPlanCreditsByCreditCategory] ([CreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanCreditsByCreditCategory] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsByCreditCategory_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsBySubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanCreditsBySubject_AcademicSubjectDescriptor]
ON [edfi].[GraduationPlanCreditsBySubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsBySubject_CreditTypeDescriptor] FOREIGN KEY ([CreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanCreditsBySubject_CreditTypeDescriptor]
ON [edfi].[GraduationPlanCreditsBySubject] ([CreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanCreditsBySubject_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessment] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessment_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredAssessment_Assessment]
ON [edfi].[GraduationPlanRequiredAssessment] ([AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessment] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessment_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor]
ON [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentPerformanceLevel_GraduationPlanRequiredAssessment] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[GraduationPlanRequiredAssessment] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredAssessmentPerformanceLevel_PerformanceLevelDescriptor]
ON [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] ([PerformanceLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentPerformanceLevel_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredAssessmentPerformanceLevel_ResultDatatypeTypeDescriptor]
ON [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentScore_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredAssessmentScore_AssessmentReportingMethodDescriptor]
ON [edfi].[GraduationPlanRequiredAssessmentScore] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentScore_GraduationPlanRequiredAssessment] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[GraduationPlanRequiredAssessment] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [AssessmentIdentifier], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanRequiredAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredAssessmentScore_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredAssessmentScore_ResultDatatypeTypeDescriptor]
ON [edfi].[GraduationPlanRequiredAssessmentScore] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanRequiredCertification] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredCertification_Certification] FOREIGN KEY ([CertificationIdentifier], [Namespace])
REFERENCES [edfi].[Certification] ([CertificationIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredCertification_Certification]
ON [edfi].[GraduationPlanRequiredCertification] ([CertificationIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanRequiredCertification] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredCertification_CertificationRouteDescriptor] FOREIGN KEY ([CertificationRouteDescriptorId])
REFERENCES [edfi].[CertificationRouteDescriptor] ([CertificationRouteDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_GraduationPlanRequiredCertification_CertificationRouteDescriptor]
ON [edfi].[GraduationPlanRequiredCertification] ([CertificationRouteDescriptorId] ASC)
GO

ALTER TABLE [edfi].[GraduationPlanRequiredCertification] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanRequiredCertification_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GraduationPlanTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_GraduationPlanTypeDescriptor_Descriptor] FOREIGN KEY ([GraduationPlanTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[GunFreeSchoolsActReportingStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_GunFreeSchoolsActReportingStatusDescriptor_Descriptor] FOREIGN KEY ([GunFreeSchoolsActReportingStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[HireStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_HireStatusDescriptor_Descriptor] FOREIGN KEY ([HireStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[HiringSourceDescriptor] WITH CHECK ADD CONSTRAINT [FK_HiringSourceDescriptor_Descriptor] FOREIGN KEY ([HiringSourceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] WITH CHECK ADD CONSTRAINT [FK_HomelessPrimaryNighttimeResidenceDescriptor_Descriptor] FOREIGN KEY ([HomelessPrimaryNighttimeResidenceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[HomelessProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_HomelessProgramServiceDescriptor_Descriptor] FOREIGN KEY ([HomelessProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IDEAPartDescriptor] WITH CHECK ADD CONSTRAINT [FK_IDEAPartDescriptor_Descriptor] FOREIGN KEY ([IDEAPartDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IdentificationDocumentUseDescriptor] WITH CHECK ADD CONSTRAINT [FK_IdentificationDocumentUseDescriptor_Descriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ImmunizationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ImmunizationTypeDescriptor_Descriptor] FOREIGN KEY ([ImmunizationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IncidentLocationDescriptor] WITH CHECK ADD CONSTRAINT [FK_IncidentLocationDescriptor_Descriptor] FOREIGN KEY ([IncidentLocationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IndicatorDescriptor] WITH CHECK ADD CONSTRAINT [FK_IndicatorDescriptor_Descriptor] FOREIGN KEY ([IndicatorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IndicatorGroupDescriptor] WITH CHECK ADD CONSTRAINT [FK_IndicatorGroupDescriptor_Descriptor] FOREIGN KEY ([IndicatorGroupDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[IndicatorLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_IndicatorLevelDescriptor_Descriptor] FOREIGN KEY ([IndicatorLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InstitutionTelephoneNumberTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_InstitutionTelephoneNumberTypeDescriptor_Descriptor] FOREIGN KEY ([InstitutionTelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InstructionalSettingDescriptor] WITH CHECK ADD CONSTRAINT [FK_InstructionalSettingDescriptor_Descriptor] FOREIGN KEY ([InstructionalSettingDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InteractivityStyleDescriptor] WITH CHECK ADD CONSTRAINT [FK_InteractivityStyleDescriptor_Descriptor] FOREIGN KEY ([InteractivityStyleDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InternetAccessDescriptor] WITH CHECK ADD CONSTRAINT [FK_InternetAccessDescriptor_Descriptor] FOREIGN KEY ([InternetAccessDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InternetAccessTypeInResidenceDescriptor] WITH CHECK ADD CONSTRAINT [FK_InternetAccessTypeInResidenceDescriptor_Descriptor] FOREIGN KEY ([InternetAccessTypeInResidenceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InternetPerformanceInResidenceDescriptor] WITH CHECK ADD CONSTRAINT [FK_InternetPerformanceInResidenceDescriptor_Descriptor] FOREIGN KEY ([InternetPerformanceInResidenceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Intervention] WITH CHECK ADD CONSTRAINT [FK_Intervention_DeliveryMethodDescriptor] FOREIGN KEY ([DeliveryMethodDescriptorId])
REFERENCES [edfi].[DeliveryMethodDescriptor] ([DeliveryMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Intervention_DeliveryMethodDescriptor]
ON [edfi].[Intervention] ([DeliveryMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Intervention] WITH CHECK ADD CONSTRAINT [FK_Intervention_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Intervention] WITH CHECK ADD CONSTRAINT [FK_Intervention_InterventionClassDescriptor] FOREIGN KEY ([InterventionClassDescriptorId])
REFERENCES [edfi].[InterventionClassDescriptor] ([InterventionClassDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Intervention_InterventionClassDescriptor]
ON [edfi].[Intervention] ([InterventionClassDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionAppropriateGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionAppropriateGradeLevel_GradeLevelDescriptor]
ON [edfi].[InterventionAppropriateGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionAppropriateGradeLevel_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionAppropriateSex_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionAppropriateSex_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionAppropriateSex_SexDescriptor]
ON [edfi].[InterventionAppropriateSex] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionClassDescriptor] WITH CHECK ADD CONSTRAINT [FK_InterventionClassDescriptor_Descriptor] FOREIGN KEY ([InterventionClassDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionDiagnosis] WITH CHECK ADD CONSTRAINT [FK_InterventionDiagnosis_DiagnosisDescriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[DiagnosisDescriptor] ([DiagnosisDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionDiagnosis_DiagnosisDescriptor]
ON [edfi].[InterventionDiagnosis] ([DiagnosisDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionDiagnosis] WITH CHECK ADD CONSTRAINT [FK_InterventionDiagnosis_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionEducationContent_EducationContent]
ON [edfi].[InterventionEducationContent] ([ContentIdentifier] ASC)
GO

ALTER TABLE [edfi].[InterventionEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionEducationContent_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionEffectivenessRatingDescriptor] WITH CHECK ADD CONSTRAINT [FK_InterventionEffectivenessRatingDescriptor_Descriptor] FOREIGN KEY ([InterventionEffectivenessRatingDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionInterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionInterventionPrescription_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionInterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionInterventionPrescription_InterventionPrescription] FOREIGN KEY ([InterventionPrescriptionEducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionInterventionPrescription_InterventionPrescription]
ON [edfi].[InterventionInterventionPrescription] ([InterventionPrescriptionEducationOrganizationId] ASC, [InterventionPrescriptionIdentificationCode] ASC)
GO

ALTER TABLE [edfi].[InterventionLearningResourceMetadataURI] WITH CHECK ADD CONSTRAINT [FK_InterventionLearningResourceMetadataURI_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionMeetingTime] WITH CHECK ADD CONSTRAINT [FK_InterventionMeetingTime_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionPopulationServed_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionPopulationServed_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionPopulationServed_PopulationServedDescriptor]
ON [edfi].[InterventionPopulationServed] ([PopulationServedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescription_DeliveryMethodDescriptor] FOREIGN KEY ([DeliveryMethodDescriptorId])
REFERENCES [edfi].[DeliveryMethodDescriptor] ([DeliveryMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionPrescription_DeliveryMethodDescriptor]
ON [edfi].[InterventionPrescription] ([DeliveryMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescription_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[InterventionPrescription] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescription_InterventionClassDescriptor] FOREIGN KEY ([InterventionClassDescriptorId])
REFERENCES [edfi].[InterventionClassDescriptor] ([InterventionClassDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionPrescription_InterventionClassDescriptor]
ON [edfi].[InterventionPrescription] ([InterventionClassDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionAppropriateGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionPrescriptionAppropriateGradeLevel_GradeLevelDescriptor]
ON [edfi].[InterventionPrescriptionAppropriateGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionAppropriateGradeLevel_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionAppropriateSex_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionAppropriateSex_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionPrescriptionAppropriateSex_SexDescriptor]
ON [edfi].[InterventionPrescriptionAppropriateSex] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionPrescriptionDiagnosis] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionDiagnosis_DiagnosisDescriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[DiagnosisDescriptor] ([DiagnosisDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionPrescriptionDiagnosis_DiagnosisDescriptor]
ON [edfi].[InterventionPrescriptionDiagnosis] ([DiagnosisDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionPrescriptionDiagnosis] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionDiagnosis_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionPrescriptionEducationContent_EducationContent]
ON [edfi].[InterventionPrescriptionEducationContent] ([ContentIdentifier] ASC)
GO

ALTER TABLE [edfi].[InterventionPrescriptionEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionEducationContent_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionLearningResourceMetadataURI] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionLearningResourceMetadataURI_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionPopulationServed_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionPrescriptionPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionPopulationServed_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionPrescriptionPopulationServed_PopulationServedDescriptor]
ON [edfi].[InterventionPrescriptionPopulationServed] ([PopulationServedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionPrescriptionURI] WITH CHECK ADD CONSTRAINT [FK_InterventionPrescriptionURI_InterventionPrescription] FOREIGN KEY ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStaff] WITH CHECK ADD CONSTRAINT [FK_InterventionStaff_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStaff] WITH CHECK ADD CONSTRAINT [FK_InterventionStaff_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStaff_Staff]
ON [edfi].[InterventionStaff] ([StaffUSI] ASC)
GO

ALTER TABLE [edfi].[InterventionStudy] WITH CHECK ADD CONSTRAINT [FK_InterventionStudy_DeliveryMethodDescriptor] FOREIGN KEY ([DeliveryMethodDescriptorId])
REFERENCES [edfi].[DeliveryMethodDescriptor] ([DeliveryMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudy_DeliveryMethodDescriptor]
ON [edfi].[InterventionStudy] ([DeliveryMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudy] WITH CHECK ADD CONSTRAINT [FK_InterventionStudy_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[InterventionStudy] WITH CHECK ADD CONSTRAINT [FK_InterventionStudy_InterventionClassDescriptor] FOREIGN KEY ([InterventionClassDescriptorId])
REFERENCES [edfi].[InterventionClassDescriptor] ([InterventionClassDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudy_InterventionClassDescriptor]
ON [edfi].[InterventionStudy] ([InterventionClassDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudy] WITH CHECK ADD CONSTRAINT [FK_InterventionStudy_InterventionPrescription] FOREIGN KEY ([InterventionPrescriptionEducationOrganizationId], [InterventionPrescriptionIdentificationCode])
REFERENCES [edfi].[InterventionPrescription] ([EducationOrganizationId], [InterventionPrescriptionIdentificationCode])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudy_InterventionPrescription]
ON [edfi].[InterventionStudy] ([InterventionPrescriptionEducationOrganizationId] ASC, [InterventionPrescriptionIdentificationCode] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyAppropriateGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyAppropriateGradeLevel_GradeLevelDescriptor]
ON [edfi].[InterventionStudyAppropriateGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyAppropriateGradeLevel] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyAppropriateGradeLevel_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyAppropriateSex_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyAppropriateSex] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyAppropriateSex_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyAppropriateSex_SexDescriptor]
ON [edfi].[InterventionStudyAppropriateSex] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyEducationContent_EducationContent]
ON [edfi].[InterventionStudyEducationContent] ([ContentIdentifier] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyEducationContent] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyEducationContent_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_DiagnosisDescriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[DiagnosisDescriptor] ([DiagnosisDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyInterventionEffectiveness_DiagnosisDescriptor]
ON [edfi].[InterventionStudyInterventionEffectiveness] ([DiagnosisDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyInterventionEffectiveness_GradeLevelDescriptor]
ON [edfi].[InterventionStudyInterventionEffectiveness] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_InterventionEffectivenessRatingDescriptor] FOREIGN KEY ([InterventionEffectivenessRatingDescriptorId])
REFERENCES [edfi].[InterventionEffectivenessRatingDescriptor] ([InterventionEffectivenessRatingDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyInterventionEffectiveness_InterventionEffectivenessRatingDescriptor]
ON [edfi].[InterventionStudyInterventionEffectiveness] ([InterventionEffectivenessRatingDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyInterventionEffectiveness_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyInterventionEffectiveness_PopulationServedDescriptor]
ON [edfi].[InterventionStudyInterventionEffectiveness] ([PopulationServedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyLearningResourceMetadataURI] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyLearningResourceMetadataURI_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyPopulationServed_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyPopulationServed] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyPopulationServed_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyPopulationServed_PopulationServedDescriptor]
ON [edfi].[InterventionStudyPopulationServed] ([PopulationServedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyStateAbbreviation] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyStateAbbreviation_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionStudyStateAbbreviation] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyStateAbbreviation_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_InterventionStudyStateAbbreviation_StateAbbreviationDescriptor]
ON [edfi].[InterventionStudyStateAbbreviation] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[InterventionStudyURI] WITH CHECK ADD CONSTRAINT [FK_InterventionStudyURI_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[InterventionURI] WITH CHECK ADD CONSTRAINT [FK_InterventionURI_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LanguageDescriptor] WITH CHECK ADD CONSTRAINT [FK_LanguageDescriptor_Descriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LanguageInstructionProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_LanguageInstructionProgramServiceDescriptor_Descriptor] FOREIGN KEY ([LanguageInstructionProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LanguageUseDescriptor] WITH CHECK ADD CONSTRAINT [FK_LanguageUseDescriptor_Descriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandard_LearningStandard] FOREIGN KEY ([ParentLearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandard_LearningStandard]
ON [edfi].[LearningStandard] ([ParentLearningStandardId] ASC)
GO

ALTER TABLE [edfi].[LearningStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandard_LearningStandardCategoryDescriptor] FOREIGN KEY ([LearningStandardCategoryDescriptorId])
REFERENCES [edfi].[LearningStandardCategoryDescriptor] ([LearningStandardCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandard_LearningStandardCategoryDescriptor]
ON [edfi].[LearningStandard] ([LearningStandardCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LearningStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandard_LearningStandardScopeDescriptor] FOREIGN KEY ([LearningStandardScopeDescriptorId])
REFERENCES [edfi].[LearningStandardScopeDescriptor] ([LearningStandardScopeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandard_LearningStandardScopeDescriptor]
ON [edfi].[LearningStandard] ([LearningStandardScopeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LearningStandardAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_LearningStandardAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandardAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[LearningStandardAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LearningStandardAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_LearningStandardAcademicSubject_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_LearningStandardCategoryDescriptor_Descriptor] FOREIGN KEY ([LearningStandardCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardContentStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandardContentStandard_EducationOrganization] FOREIGN KEY ([MandatingEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandardContentStandard_EducationOrganization]
ON [edfi].[LearningStandardContentStandard] ([MandatingEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[LearningStandardContentStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandardContentStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardContentStandard] WITH CHECK ADD CONSTRAINT [FK_LearningStandardContentStandard_PublicationStatusDescriptor] FOREIGN KEY ([PublicationStatusDescriptorId])
REFERENCES [edfi].[PublicationStatusDescriptor] ([PublicationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandardContentStandard_PublicationStatusDescriptor]
ON [edfi].[LearningStandardContentStandard] ([PublicationStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LearningStandardContentStandardAuthor] WITH CHECK ADD CONSTRAINT [FK_LearningStandardContentStandardAuthor_LearningStandardContentStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandardContentStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] WITH CHECK ADD CONSTRAINT [FK_LearningStandardEquivalenceAssociation_LearningStandard] FOREIGN KEY ([SourceLearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandardEquivalenceAssociation_LearningStandard]
ON [edfi].[LearningStandardEquivalenceAssociation] ([SourceLearningStandardId] ASC)
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] WITH CHECK ADD CONSTRAINT [FK_LearningStandardEquivalenceAssociation_LearningStandard1] FOREIGN KEY ([TargetLearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandardEquivalenceAssociation_LearningStandard1]
ON [edfi].[LearningStandardEquivalenceAssociation] ([TargetLearningStandardId] ASC)
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] WITH CHECK ADD CONSTRAINT [FK_LearningStandardEquivalenceAssociation_LearningStandardEquivalenceStrengthDescriptor] FOREIGN KEY ([LearningStandardEquivalenceStrengthDescriptorId])
REFERENCES [edfi].[LearningStandardEquivalenceStrengthDescriptor] ([LearningStandardEquivalenceStrengthDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandardEquivalenceAssociation_LearningStandardEquivalenceStrengthDescriptor]
ON [edfi].[LearningStandardEquivalenceAssociation] ([LearningStandardEquivalenceStrengthDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceStrengthDescriptor] WITH CHECK ADD CONSTRAINT [FK_LearningStandardEquivalenceStrengthDescriptor_Descriptor] FOREIGN KEY ([LearningStandardEquivalenceStrengthDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardGradeLevel] WITH CHECK ADD CONSTRAINT [FK_LearningStandardGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LearningStandardGradeLevel_GradeLevelDescriptor]
ON [edfi].[LearningStandardGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LearningStandardGradeLevel] WITH CHECK ADD CONSTRAINT [FK_LearningStandardGradeLevel_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_LearningStandardIdentificationCode_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LearningStandardScopeDescriptor] WITH CHECK ADD CONSTRAINT [FK_LearningStandardScopeDescriptor_Descriptor] FOREIGN KEY ([LearningStandardScopeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LengthOfContractDescriptor] WITH CHECK ADD CONSTRAINT [FK_LengthOfContractDescriptor_Descriptor] FOREIGN KEY ([LengthOfContractDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LevelOfEducationDescriptor] WITH CHECK ADD CONSTRAINT [FK_LevelOfEducationDescriptor_Descriptor] FOREIGN KEY ([LevelOfEducationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LicenseStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_LicenseStatusDescriptor_Descriptor] FOREIGN KEY ([LicenseStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LicenseTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_LicenseTypeDescriptor_Descriptor] FOREIGN KEY ([LicenseTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LimitedEnglishProficiencyDescriptor] WITH CHECK ADD CONSTRAINT [FK_LimitedEnglishProficiencyDescriptor_Descriptor] FOREIGN KEY ([LimitedEnglishProficiencyDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalAccount] WITH CHECK ADD CONSTRAINT [FK_LocalAccount_ChartOfAccount] FOREIGN KEY ([ChartOfAccountIdentifier], [ChartOfAccountEducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[ChartOfAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_LocalAccount_ChartOfAccount]
ON [edfi].[LocalAccount] ([ChartOfAccountIdentifier] ASC, [ChartOfAccountEducationOrganizationId] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[LocalAccount] WITH CHECK ADD CONSTRAINT [FK_LocalAccount_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[LocalAccountReportingTag] WITH CHECK ADD CONSTRAINT [FK_LocalAccountReportingTag_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalAccountReportingTag] WITH CHECK ADD CONSTRAINT [FK_LocalAccountReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalAccountReportingTag_ReportingTagDescriptor]
ON [edfi].[LocalAccountReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalActual] WITH CHECK ADD CONSTRAINT [FK_LocalActual_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalActual_FinancialCollectionDescriptor]
ON [edfi].[LocalActual] ([FinancialCollectionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalActual] WITH CHECK ADD CONSTRAINT [FK_LocalActual_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_LocalActual_LocalAccount]
ON [edfi].[LocalActual] ([AccountIdentifier] ASC, [EducationOrganizationId] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[LocalBudget] WITH CHECK ADD CONSTRAINT [FK_LocalBudget_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalBudget_FinancialCollectionDescriptor]
ON [edfi].[LocalBudget] ([FinancialCollectionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalBudget] WITH CHECK ADD CONSTRAINT [FK_LocalBudget_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_LocalBudget_LocalAccount]
ON [edfi].[LocalBudget] ([AccountIdentifier] ASC, [EducationOrganizationId] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[LocalContractedStaff] WITH CHECK ADD CONSTRAINT [FK_LocalContractedStaff_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalContractedStaff_FinancialCollectionDescriptor]
ON [edfi].[LocalContractedStaff] ([FinancialCollectionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalContractedStaff] WITH CHECK ADD CONSTRAINT [FK_LocalContractedStaff_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_LocalContractedStaff_LocalAccount]
ON [edfi].[LocalContractedStaff] ([AccountIdentifier] ASC, [EducationOrganizationId] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[LocalContractedStaff] WITH CHECK ADD CONSTRAINT [FK_LocalContractedStaff_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[LocaleDescriptor] WITH CHECK ADD CONSTRAINT [FK_LocaleDescriptor_Descriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_CharterStatusDescriptor] FOREIGN KEY ([CharterStatusDescriptorId])
REFERENCES [edfi].[CharterStatusDescriptor] ([CharterStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgency_CharterStatusDescriptor]
ON [edfi].[LocalEducationAgency] ([CharterStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_EducationOrganization] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_EducationServiceCenter] FOREIGN KEY ([EducationServiceCenterId])
REFERENCES [edfi].[EducationServiceCenter] ([EducationServiceCenterId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgency_EducationServiceCenter]
ON [edfi].[LocalEducationAgency] ([EducationServiceCenterId] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [edfi].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgency_FederalLocaleCodeDescriptor]
ON [edfi].[LocalEducationAgency] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_LocalEducationAgency] FOREIGN KEY ([ParentLocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgency_LocalEducationAgency]
ON [edfi].[LocalEducationAgency] ([ParentLocalEducationAgencyId] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_LocalEducationAgencyCategoryDescriptor] FOREIGN KEY ([LocalEducationAgencyCategoryDescriptorId])
REFERENCES [edfi].[LocalEducationAgencyCategoryDescriptor] ([LocalEducationAgencyCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgency_LocalEducationAgencyCategoryDescriptor]
ON [edfi].[LocalEducationAgency] ([LocalEducationAgencyCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgency] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgency_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgency_StateEducationAgency]
ON [edfi].[LocalEducationAgency] ([StateEducationAgencyId] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyAccountability_GunFreeSchoolsActReportingStatusDescriptor] FOREIGN KEY ([GunFreeSchoolsActReportingStatusDescriptorId])
REFERENCES [edfi].[GunFreeSchoolsActReportingStatusDescriptor] ([GunFreeSchoolsActReportingStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgencyAccountability_GunFreeSchoolsActReportingStatusDescriptor]
ON [edfi].[LocalEducationAgencyAccountability] ([GunFreeSchoolsActReportingStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyAccountability_LocalEducationAgency] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyAccountability_SchoolChoiceImplementStatusDescriptor] FOREIGN KEY ([SchoolChoiceImplementStatusDescriptorId])
REFERENCES [edfi].[SchoolChoiceImplementStatusDescriptor] ([SchoolChoiceImplementStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgencyAccountability_SchoolChoiceImplementStatusDescriptor]
ON [edfi].[LocalEducationAgencyAccountability] ([SchoolChoiceImplementStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyAccountability_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEducationAgencyAccountability_SchoolYearType]
ON [edfi].[LocalEducationAgencyAccountability] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[LocalEducationAgencyCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyCategoryDescriptor_Descriptor] FOREIGN KEY ([LocalEducationAgencyCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEducationAgencyFederalFunds] WITH CHECK ADD CONSTRAINT [FK_LocalEducationAgencyFederalFunds_LocalEducationAgency] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[LocalEncumbrance] WITH CHECK ADD CONSTRAINT [FK_LocalEncumbrance_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEncumbrance_FinancialCollectionDescriptor]
ON [edfi].[LocalEncumbrance] ([FinancialCollectionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalEncumbrance] WITH CHECK ADD CONSTRAINT [FK_LocalEncumbrance_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_LocalEncumbrance_LocalAccount]
ON [edfi].[LocalEncumbrance] ([AccountIdentifier] ASC, [EducationOrganizationId] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[LocalPayroll] WITH CHECK ADD CONSTRAINT [FK_LocalPayroll_FinancialCollectionDescriptor] FOREIGN KEY ([FinancialCollectionDescriptorId])
REFERENCES [edfi].[FinancialCollectionDescriptor] ([FinancialCollectionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_LocalPayroll_FinancialCollectionDescriptor]
ON [edfi].[LocalPayroll] ([FinancialCollectionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[LocalPayroll] WITH CHECK ADD CONSTRAINT [FK_LocalPayroll_LocalAccount] FOREIGN KEY ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
REFERENCES [edfi].[LocalAccount] ([AccountIdentifier], [EducationOrganizationId], [FiscalYear])
GO

CREATE NONCLUSTERED INDEX [FK_LocalPayroll_LocalAccount]
ON [edfi].[LocalPayroll] ([AccountIdentifier] ASC, [EducationOrganizationId] ASC, [FiscalYear] ASC)
GO

ALTER TABLE [edfi].[LocalPayroll] WITH CHECK ADD CONSTRAINT [FK_LocalPayroll_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[Location] WITH CHECK ADD CONSTRAINT [FK_Location_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] WITH CHECK ADD CONSTRAINT [FK_MagnetSpecialProgramEmphasisSchoolDescriptor_Descriptor] FOREIGN KEY ([MagnetSpecialProgramEmphasisSchoolDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[MediumOfInstructionDescriptor] WITH CHECK ADD CONSTRAINT [FK_MediumOfInstructionDescriptor_Descriptor] FOREIGN KEY ([MediumOfInstructionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[MethodCreditEarnedDescriptor] WITH CHECK ADD CONSTRAINT [FK_MethodCreditEarnedDescriptor_Descriptor] FOREIGN KEY ([MethodCreditEarnedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[MigrantEducationProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_MigrantEducationProgramServiceDescriptor_Descriptor] FOREIGN KEY ([MigrantEducationProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ModelEntityDescriptor] WITH CHECK ADD CONSTRAINT [FK_ModelEntityDescriptor_Descriptor] FOREIGN KEY ([ModelEntityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[MonitoredDescriptor] WITH CHECK ADD CONSTRAINT [FK_MonitoredDescriptor_Descriptor] FOREIGN KEY ([MonitoredDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[NeglectedOrDelinquentProgramDescriptor] WITH CHECK ADD CONSTRAINT [FK_NeglectedOrDelinquentProgramDescriptor_Descriptor] FOREIGN KEY ([NeglectedOrDelinquentProgramDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_NeglectedOrDelinquentProgramServiceDescriptor_Descriptor] FOREIGN KEY ([NeglectedOrDelinquentProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[NetworkPurposeDescriptor] WITH CHECK ADD CONSTRAINT [FK_NetworkPurposeDescriptor_Descriptor] FOREIGN KEY ([NetworkPurposeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[NonMedicalImmunizationExemptionDescriptor] WITH CHECK ADD CONSTRAINT [FK_NonMedicalImmunizationExemptionDescriptor_Descriptor] FOREIGN KEY ([NonMedicalImmunizationExemptionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ObjectDimensionReportingTag_ObjectDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[ObjectDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ObjectDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectDimensionReportingTag_ReportingTagDescriptor]
ON [edfi].[ObjectDimensionReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessment_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessment_AcademicSubjectDescriptor]
ON [edfi].[ObjectiveAssessment] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessment_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessment_Assessment]
ON [edfi].[ObjectiveAssessment] ([AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessment_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [ParentIdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessment_ObjectiveAssessment]
ON [edfi].[ObjectiveAssessment] ([AssessmentIdentifier] ASC, [ParentIdentificationCode] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessmentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentAssessmentItem_AssessmentItem] FOREIGN KEY ([AssessmentIdentifier], [AssessmentItemIdentificationCode], [Namespace])
REFERENCES [edfi].[AssessmentItem] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessmentAssessmentItem_AssessmentItem]
ON [edfi].[ObjectiveAssessmentAssessmentItem] ([AssessmentIdentifier] ASC, [AssessmentItemIdentificationCode] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessmentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentAssessmentItem_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectiveAssessmentLearningStandard] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessmentLearningStandard_LearningStandard]
ON [edfi].[ObjectiveAssessmentLearningStandard] ([LearningStandardId] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessmentLearningStandard] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentLearningStandard_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor]
ON [edfi].[ObjectiveAssessmentPerformanceLevel] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentPerformanceLevel_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessmentPerformanceLevel_PerformanceLevelDescriptor]
ON [edfi].[ObjectiveAssessmentPerformanceLevel] ([PerformanceLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentPerformanceLevel_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessmentPerformanceLevel_ResultDatatypeTypeDescriptor]
ON [edfi].[ObjectiveAssessmentPerformanceLevel] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentScore_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessmentScore_AssessmentReportingMethodDescriptor]
ON [edfi].[ObjectiveAssessmentScore] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ObjectiveAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentScore_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ObjectiveAssessmentScore] WITH CHECK ADD CONSTRAINT [FK_ObjectiveAssessmentScore_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ObjectiveAssessmentScore_ResultDatatypeTypeDescriptor]
ON [edfi].[ObjectiveAssessmentScore] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ObjectiveRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_ObjectiveRatingLevelDescriptor_Descriptor] FOREIGN KEY ([ObjectiveRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_EmploymentStatusDescriptor] FOREIGN KEY ([EmploymentStatusDescriptorId])
REFERENCES [edfi].[EmploymentStatusDescriptor] ([EmploymentStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPosition_EmploymentStatusDescriptor]
ON [edfi].[OpenStaffPosition] ([EmploymentStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_FundingSourceDescriptor] FOREIGN KEY ([FundingSourceDescriptorId])
REFERENCES [edfi].[FundingSourceDescriptor] ([FundingSourceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPosition_FundingSourceDescriptor]
ON [edfi].[OpenStaffPosition] ([FundingSourceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_OpenStaffPositionReasonDescriptor] FOREIGN KEY ([OpenStaffPositionReasonDescriptorId])
REFERENCES [edfi].[OpenStaffPositionReasonDescriptor] ([OpenStaffPositionReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPosition_OpenStaffPositionReasonDescriptor]
ON [edfi].[OpenStaffPosition] ([OpenStaffPositionReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_PostingResultDescriptor] FOREIGN KEY ([PostingResultDescriptorId])
REFERENCES [edfi].[PostingResultDescriptor] ([PostingResultDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPosition_PostingResultDescriptor]
ON [edfi].[OpenStaffPosition] ([PostingResultDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_ProgramAssignmentDescriptor] FOREIGN KEY ([ProgramAssignmentDescriptorId])
REFERENCES [edfi].[ProgramAssignmentDescriptor] ([ProgramAssignmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPosition_ProgramAssignmentDescriptor]
ON [edfi].[OpenStaffPosition] ([ProgramAssignmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPosition_SchoolYearType]
ON [edfi].[OpenStaffPosition] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_StaffClassificationDescriptor] FOREIGN KEY ([StaffClassificationDescriptorId])
REFERENCES [edfi].[StaffClassificationDescriptor] ([StaffClassificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPosition_StaffClassificationDescriptor]
ON [edfi].[OpenStaffPosition] ([StaffClassificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPosition] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPosition_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPosition_TermDescriptor]
ON [edfi].[OpenStaffPosition] ([TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPositionAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[OpenStaffPositionAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPositionAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionAcademicSubject_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OpenStaffPositionEvent] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEvent_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionEvent_OpenStaffPosition]
ON [edfi].[OpenStaffPositionEvent] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPositionEvent] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEvent_OpenStaffPositionEventStatusDescriptor] FOREIGN KEY ([OpenStaffPositionEventStatusDescriptorId])
REFERENCES [edfi].[OpenStaffPositionEventStatusDescriptor] ([OpenStaffPositionEventStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionEvent_OpenStaffPositionEventStatusDescriptor]
ON [edfi].[OpenStaffPositionEvent] ([OpenStaffPositionEventStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPositionEvent] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEvent_OpenStaffPositionEventTypeDescriptor] FOREIGN KEY ([OpenStaffPositionEventTypeDescriptorId])
REFERENCES [edfi].[OpenStaffPositionEventTypeDescriptor] ([OpenStaffPositionEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionEvent_OpenStaffPositionEventTypeDescriptor]
ON [edfi].[OpenStaffPositionEvent] ([OpenStaffPositionEventTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPositionEventStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEventStatusDescriptor_Descriptor] FOREIGN KEY ([OpenStaffPositionEventStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OpenStaffPositionEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionEventTypeDescriptor_Descriptor] FOREIGN KEY ([OpenStaffPositionEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionInstructionalGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OpenStaffPositionInstructionalGradeLevel_GradeLevelDescriptor]
ON [edfi].[OpenStaffPositionInstructionalGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionInstructionalGradeLevel_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OpenStaffPositionReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_OpenStaffPositionReasonDescriptor_Descriptor] FOREIGN KEY ([OpenStaffPositionReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OperationalStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_OperationalStatusDescriptor_Descriptor] FOREIGN KEY ([OperationalStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OperationalUnitDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_OperationalUnitDimensionReportingTag_OperationalUnitDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[OperationalUnitDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OperationalUnitDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_OperationalUnitDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OperationalUnitDimensionReportingTag_ReportingTagDescriptor]
ON [edfi].[OperationalUnitDimensionReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OrganizationDepartment] WITH CHECK ADD CONSTRAINT [FK_OrganizationDepartment_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_OrganizationDepartment_AcademicSubjectDescriptor]
ON [edfi].[OrganizationDepartment] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[OrganizationDepartment] WITH CHECK ADD CONSTRAINT [FK_OrganizationDepartment_EducationOrganization] FOREIGN KEY ([OrganizationDepartmentId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[OrganizationDepartment] WITH CHECK ADD CONSTRAINT [FK_OrganizationDepartment_EducationOrganization1] FOREIGN KEY ([ParentEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_OrganizationDepartment_EducationOrganization1]
ON [edfi].[OrganizationDepartment] ([ParentEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[OtherNameTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_OtherNameTypeDescriptor_Descriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ParticipationDescriptor] WITH CHECK ADD CONSTRAINT [FK_ParticipationDescriptor_Descriptor] FOREIGN KEY ([ParticipationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ParticipationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_ParticipationStatusDescriptor_Descriptor] FOREIGN KEY ([ParticipationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Path] WITH CHECK ADD CONSTRAINT [FK_Path_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Path] WITH CHECK ADD CONSTRAINT [FK_Path_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_Path_GraduationPlan]
ON [edfi].[Path] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC)
GO

ALTER TABLE [edfi].[PathMilestone] WITH CHECK ADD CONSTRAINT [FK_PathMilestone_PathMilestoneTypeDescriptor] FOREIGN KEY ([PathMilestoneTypeDescriptorId])
REFERENCES [edfi].[PathMilestoneTypeDescriptor] ([PathMilestoneTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PathMilestone_PathMilestoneTypeDescriptor]
ON [edfi].[PathMilestone] ([PathMilestoneTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PathMilestoneStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_PathMilestoneStatusDescriptor_Descriptor] FOREIGN KEY ([PathMilestoneStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PathMilestoneTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_PathMilestoneTypeDescriptor_Descriptor] FOREIGN KEY ([PathMilestoneTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PathPhase] WITH CHECK ADD CONSTRAINT [FK_PathPhase_Path] FOREIGN KEY ([EducationOrganizationId], [PathName])
REFERENCES [edfi].[Path] ([EducationOrganizationId], [PathName])
GO

CREATE NONCLUSTERED INDEX [FK_PathPhase_Path]
ON [edfi].[PathPhase] ([EducationOrganizationId] ASC, [PathName] ASC)
GO

ALTER TABLE [edfi].[PathPhasePathMilestone] WITH CHECK ADD CONSTRAINT [FK_PathPhasePathMilestone_PathMilestone] FOREIGN KEY ([PathMilestoneName], [PathMilestoneTypeDescriptorId])
REFERENCES [edfi].[PathMilestone] ([PathMilestoneName], [PathMilestoneTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PathPhasePathMilestone_PathMilestone]
ON [edfi].[PathPhasePathMilestone] ([PathMilestoneName] ASC, [PathMilestoneTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PathPhasePathMilestone] WITH CHECK ADD CONSTRAINT [FK_PathPhasePathMilestone_PathPhase] FOREIGN KEY ([EducationOrganizationId], [PathName], [PathPhaseName])
REFERENCES [edfi].[PathPhase] ([EducationOrganizationId], [PathName], [PathPhaseName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PathPhaseStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_PathPhaseStatusDescriptor_Descriptor] FOREIGN KEY ([PathPhaseStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceBaseConversionDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceBaseConversionDescriptor_Descriptor] FOREIGN KEY ([PerformanceBaseConversionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_AcademicSubjectDescriptor]
ON [edfi].[PerformanceEvaluation] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_EvaluationPeriodDescriptor] FOREIGN KEY ([EvaluationPeriodDescriptorId])
REFERENCES [edfi].[EvaluationPeriodDescriptor] ([EvaluationPeriodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_EvaluationPeriodDescriptor]
ON [edfi].[PerformanceEvaluation] ([EvaluationPeriodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_PerformanceEvaluationTypeDescriptor] FOREIGN KEY ([PerformanceEvaluationTypeDescriptorId])
REFERENCES [edfi].[PerformanceEvaluationTypeDescriptor] ([PerformanceEvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_PerformanceEvaluationTypeDescriptor]
ON [edfi].[PerformanceEvaluation] ([PerformanceEvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_SchoolYearType]
ON [edfi].[PerformanceEvaluation] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluation] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluation_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluation_TermDescriptor]
ON [edfi].[PerformanceEvaluation] ([TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationGradeLevel_GradeLevelDescriptor]
ON [edfi].[PerformanceEvaluationGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationGradeLevel_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceEvaluationRating] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRating_CoteachingStyleObservedDescriptor] FOREIGN KEY ([CoteachingStyleObservedDescriptorId])
REFERENCES [edfi].[CoteachingStyleObservedDescriptor] ([CoteachingStyleObservedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRating_CoteachingStyleObservedDescriptor]
ON [edfi].[PerformanceEvaluationRating] ([CoteachingStyleObservedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationRating] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRating_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRating_PerformanceEvaluation]
ON [edfi].[PerformanceEvaluationRating] ([EducationOrganizationId] ASC, [EvaluationPeriodDescriptorId] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationRating] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRating_PerformanceEvaluationRatingLevelDescriptor] FOREIGN KEY ([PerformanceEvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[PerformanceEvaluationRatingLevelDescriptor] ([PerformanceEvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRating_PerformanceEvaluationRatingLevelDescriptor]
ON [edfi].[PerformanceEvaluationRating] ([PerformanceEvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationRating] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRating_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRating_Person]
ON [edfi].[PerformanceEvaluationRating] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingLevel_EvaluationRatingLevelDescriptor] FOREIGN KEY ([EvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[EvaluationRatingLevelDescriptor] ([EvaluationRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingLevel_EvaluationRatingLevelDescriptor]
ON [edfi].[PerformanceEvaluationRatingLevel] ([EvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationRatingLevel] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingLevel_PerformanceEvaluation] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[PerformanceEvaluation] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceEvaluationRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingLevelDescriptor_Descriptor] FOREIGN KEY ([PerformanceEvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceEvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingResult_PerformanceEvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[PerformanceEvaluationRating] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceEvaluationRatingResult] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingResult_ResultDatatypeTypeDescriptor]
ON [edfi].[PerformanceEvaluationRatingResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewer_PerformanceEvaluationRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[PerformanceEvaluationRating] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceEvaluationRatingReviewer] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewer_Person] FOREIGN KEY ([ReviewerPersonId], [ReviewerSourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PerformanceEvaluationRatingReviewer_Person]
ON [edfi].[PerformanceEvaluationRatingReviewer] ([ReviewerPersonId] ASC, [ReviewerSourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PerformanceEvaluationRatingReviewerReceivedTraining] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationRatingReviewerReceivedTraining_PerformanceEvaluationRatingReviewer] FOREIGN KEY ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId], [FirstName], [LastSurname])
REFERENCES [edfi].[PerformanceEvaluationRatingReviewer] ([EducationOrganizationId], [EvaluationPeriodDescriptorId], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId], [FirstName], [LastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceEvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceEvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([PerformanceEvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PerformanceLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_PerformanceLevelDescriptor_Descriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Person] WITH CHECK ADD CONSTRAINT [FK_Person_SourceSystemDescriptor] FOREIGN KEY ([SourceSystemDescriptorId])
REFERENCES [edfi].[SourceSystemDescriptor] ([SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Person_SourceSystemDescriptor]
ON [edfi].[Person] ([SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PersonalInformationVerificationDescriptor] WITH CHECK ADD CONSTRAINT [FK_PersonalInformationVerificationDescriptor_Descriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PlatformTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_PlatformTypeDescriptor_Descriptor] FOREIGN KEY ([PlatformTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PopulationServedDescriptor] WITH CHECK ADD CONSTRAINT [FK_PopulationServedDescriptor_Descriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostingResultDescriptor] WITH CHECK ADD CONSTRAINT [FK_PostingResultDescriptor_Descriptor] FOREIGN KEY ([PostingResultDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostSecondaryEvent] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryEvent_PostSecondaryEventCategoryDescriptor] FOREIGN KEY ([PostSecondaryEventCategoryDescriptorId])
REFERENCES [edfi].[PostSecondaryEventCategoryDescriptor] ([PostSecondaryEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PostSecondaryEvent_PostSecondaryEventCategoryDescriptor]
ON [edfi].[PostSecondaryEvent] ([PostSecondaryEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PostSecondaryEvent] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryEvent_PostSecondaryInstitution] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[PostSecondaryInstitution] ([PostSecondaryInstitutionId])
GO

ALTER TABLE [edfi].[PostSecondaryEvent] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[PostSecondaryEventCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryEventCategoryDescriptor_Descriptor] FOREIGN KEY ([PostSecondaryEventCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostSecondaryInstitution] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitution_AdministrativeFundingControlDescriptor] FOREIGN KEY ([AdministrativeFundingControlDescriptorId])
REFERENCES [edfi].[AdministrativeFundingControlDescriptor] ([AdministrativeFundingControlDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PostSecondaryInstitution_AdministrativeFundingControlDescriptor]
ON [edfi].[PostSecondaryInstitution] ([AdministrativeFundingControlDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PostSecondaryInstitution] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitution_EducationOrganization] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostSecondaryInstitution] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitution_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [edfi].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PostSecondaryInstitution_FederalLocaleCodeDescriptor]
ON [edfi].[PostSecondaryInstitution] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PostSecondaryInstitution] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitution_PostSecondaryInstitutionLevelDescriptor] FOREIGN KEY ([PostSecondaryInstitutionLevelDescriptorId])
REFERENCES [edfi].[PostSecondaryInstitutionLevelDescriptor] ([PostSecondaryInstitutionLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PostSecondaryInstitution_PostSecondaryInstitutionLevelDescriptor]
ON [edfi].[PostSecondaryInstitution] ([PostSecondaryInstitutionLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PostSecondaryInstitutionLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitutionLevelDescriptor_Descriptor] FOREIGN KEY ([PostSecondaryInstitutionLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PostSecondaryInstitutionMediumOfInstruction] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitutionMediumOfInstruction_MediumOfInstructionDescriptor] FOREIGN KEY ([MediumOfInstructionDescriptorId])
REFERENCES [edfi].[MediumOfInstructionDescriptor] ([MediumOfInstructionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_PostSecondaryInstitutionMediumOfInstruction_MediumOfInstructionDescriptor]
ON [edfi].[PostSecondaryInstitutionMediumOfInstruction] ([MediumOfInstructionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[PostSecondaryInstitutionMediumOfInstruction] WITH CHECK ADD CONSTRAINT [FK_PostSecondaryInstitutionMediumOfInstruction_PostSecondaryInstitution] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[PostSecondaryInstitution] ([PostSecondaryInstitutionId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PreviousCareerDescriptor] WITH CHECK ADD CONSTRAINT [FK_PreviousCareerDescriptor_Descriptor] FOREIGN KEY ([PreviousCareerDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceAccessDescriptor] WITH CHECK ADD CONSTRAINT [FK_PrimaryLearningDeviceAccessDescriptor_Descriptor] FOREIGN KEY ([PrimaryLearningDeviceAccessDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] WITH CHECK ADD CONSTRAINT [FK_PrimaryLearningDeviceAwayFromSchoolDescriptor_Descriptor] FOREIGN KEY ([PrimaryLearningDeviceAwayFromSchoolDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceProviderDescriptor] WITH CHECK ADD CONSTRAINT [FK_PrimaryLearningDeviceProviderDescriptor_Descriptor] FOREIGN KEY ([PrimaryLearningDeviceProviderDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProfessionalDevelopmentEvent] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentEvent_ProfessionalDevelopmentOfferedByDescriptor] FOREIGN KEY ([ProfessionalDevelopmentOfferedByDescriptorId])
REFERENCES [edfi].[ProfessionalDevelopmentOfferedByDescriptor] ([ProfessionalDevelopmentOfferedByDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProfessionalDevelopmentEvent_ProfessionalDevelopmentOfferedByDescriptor]
ON [edfi].[ProfessionalDevelopmentEvent] ([ProfessionalDevelopmentOfferedByDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProfessionalDevelopmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentEventAttendance_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProfessionalDevelopmentEventAttendance_AttendanceEventCategoryDescriptor]
ON [edfi].[ProfessionalDevelopmentEventAttendance] ([AttendanceEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProfessionalDevelopmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentEventAttendance_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProfessionalDevelopmentEventAttendance_Person]
ON [edfi].[ProfessionalDevelopmentEventAttendance] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProfessionalDevelopmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentEventAttendance_ProfessionalDevelopmentEvent] FOREIGN KEY ([Namespace], [ProfessionalDevelopmentTitle])
REFERENCES [edfi].[ProfessionalDevelopmentEvent] ([Namespace], [ProfessionalDevelopmentTitle])
GO

CREATE NONCLUSTERED INDEX [FK_ProfessionalDevelopmentEventAttendance_ProfessionalDevelopmentEvent]
ON [edfi].[ProfessionalDevelopmentEventAttendance] ([Namespace] ASC, [ProfessionalDevelopmentTitle] ASC)
GO

ALTER TABLE [edfi].[ProfessionalDevelopmentOfferedByDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProfessionalDevelopmentOfferedByDescriptor_Descriptor] FOREIGN KEY ([ProfessionalDevelopmentOfferedByDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProficiencyDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProficiencyDescriptor_Descriptor] FOREIGN KEY ([ProficiencyDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Program] WITH CHECK ADD CONSTRAINT [FK_Program_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Program] WITH CHECK ADD CONSTRAINT [FK_Program_ProgramTypeDescriptor] FOREIGN KEY ([ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramTypeDescriptor] ([ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Program_ProgramTypeDescriptor]
ON [edfi].[Program] ([ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramAssignmentDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramAssignmentDescriptor_Descriptor] FOREIGN KEY ([ProgramAssignmentDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ProgramCharacteristic_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramCharacteristic] WITH CHECK ADD CONSTRAINT [FK_ProgramCharacteristic_ProgramCharacteristicDescriptor] FOREIGN KEY ([ProgramCharacteristicDescriptorId])
REFERENCES [edfi].[ProgramCharacteristicDescriptor] ([ProgramCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramCharacteristic_ProgramCharacteristicDescriptor]
ON [edfi].[ProgramCharacteristic] ([ProgramCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramCharacteristicDescriptor_Descriptor] FOREIGN KEY ([ProgramCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ProgramDimensionReportingTag_ProgramDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[ProgramDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ProgramDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramDimensionReportingTag_ReportingTagDescriptor]
ON [edfi].[ProgramDimensionReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluation_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluation_Program]
ON [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluation_ProgramEvaluationPeriodDescriptor] FOREIGN KEY ([ProgramEvaluationPeriodDescriptorId])
REFERENCES [edfi].[ProgramEvaluationPeriodDescriptor] ([ProgramEvaluationPeriodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluation_ProgramEvaluationPeriodDescriptor]
ON [edfi].[ProgramEvaluation] ([ProgramEvaluationPeriodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluation_ProgramEvaluationTypeDescriptor] FOREIGN KEY ([ProgramEvaluationTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationTypeDescriptor] ([ProgramEvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluation_ProgramEvaluationTypeDescriptor]
ON [edfi].[ProgramEvaluation] ([ProgramEvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationElement_ProgramEvaluation] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluationElement_ProgramEvaluation]
ON [edfi].[ProgramEvaluationElement] ([ProgramEducationOrganizationId] ASC, [ProgramEvaluationPeriodDescriptorId] ASC, [ProgramEvaluationTitle] ASC, [ProgramEvaluationTypeDescriptorId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationElement_ProgramEvaluationObjective] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationObjective] ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluationElement_ProgramEvaluationObjective]
ON [edfi].[ProgramEvaluationElement] ([ProgramEducationOrganizationId] ASC, [ProgramEvaluationObjectiveTitle] ASC, [ProgramEvaluationPeriodDescriptorId] ASC, [ProgramEvaluationTitle] ASC, [ProgramEvaluationTypeDescriptorId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluationElementProgramEvaluationLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationElementProgramEvaluationLevel_ProgramEvaluationElement] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationElement] ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramEvaluationElementProgramEvaluationLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationElementProgramEvaluationLevel_RatingLevelDescriptor] FOREIGN KEY ([RatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluationElementProgramEvaluationLevel_RatingLevelDescriptor]
ON [edfi].[ProgramEvaluationElementProgramEvaluationLevel] ([RatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluationLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationLevel_ProgramEvaluation] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramEvaluationLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationLevel_RatingLevelDescriptor] FOREIGN KEY ([RatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluationLevel_RatingLevelDescriptor]
ON [edfi].[ProgramEvaluationLevel] ([RatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationObjective_ProgramEvaluation] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluationObjective_ProgramEvaluation]
ON [edfi].[ProgramEvaluationObjective] ([ProgramEducationOrganizationId] ASC, [ProgramEvaluationPeriodDescriptorId] ASC, [ProgramEvaluationTitle] ASC, [ProgramEvaluationTypeDescriptorId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluationObjectiveProgramEvaluationLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationObjectiveProgramEvaluationLevel_ProgramEvaluationObjective] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationObjective] ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramEvaluationObjectiveProgramEvaluationLevel] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationObjectiveProgramEvaluationLevel_RatingLevelDescriptor] FOREIGN KEY ([RatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramEvaluationObjectiveProgramEvaluationLevel_RatingLevelDescriptor]
ON [edfi].[ProgramEvaluationObjectiveProgramEvaluationLevel] ([RatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramEvaluationPeriodDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationPeriodDescriptor_Descriptor] FOREIGN KEY ([ProgramEvaluationPeriodDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramEvaluationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramEvaluationTypeDescriptor_Descriptor] FOREIGN KEY ([ProgramEvaluationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramLearningStandard] WITH CHECK ADD CONSTRAINT [FK_ProgramLearningStandard_LearningStandard] FOREIGN KEY ([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramLearningStandard_LearningStandard]
ON [edfi].[ProgramLearningStandard] ([LearningStandardId] ASC)
GO

ALTER TABLE [edfi].[ProgramLearningStandard] WITH CHECK ADD CONSTRAINT [FK_ProgramLearningStandard_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramSponsor] WITH CHECK ADD CONSTRAINT [FK_ProgramSponsor_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramSponsor] WITH CHECK ADD CONSTRAINT [FK_ProgramSponsor_ProgramSponsorDescriptor] FOREIGN KEY ([ProgramSponsorDescriptorId])
REFERENCES [edfi].[ProgramSponsorDescriptor] ([ProgramSponsorDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProgramSponsor_ProgramSponsorDescriptor]
ON [edfi].[ProgramSponsor] ([ProgramSponsorDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProgramSponsorDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramSponsorDescriptor_Descriptor] FOREIGN KEY ([ProgramSponsorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgramTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgramTypeDescriptor_Descriptor] FOREIGN KEY ([ProgramTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgressDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgressDescriptor_Descriptor] FOREIGN KEY ([ProgressDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProgressLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProgressLevelDescriptor_Descriptor] FOREIGN KEY ([ProgressLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProjectDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ProjectDimensionReportingTag_ProjectDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[ProjectDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProjectDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_ProjectDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ProjectDimensionReportingTag_ReportingTagDescriptor]
ON [edfi].[ProjectDimensionReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ProviderCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProviderCategoryDescriptor_Descriptor] FOREIGN KEY ([ProviderCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProviderProfitabilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProviderProfitabilityDescriptor_Descriptor] FOREIGN KEY ([ProviderProfitabilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ProviderStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_ProviderStatusDescriptor_Descriptor] FOREIGN KEY ([ProviderStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[PublicationStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_PublicationStatusDescriptor_Descriptor] FOREIGN KEY ([PublicationStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[QuantitativeMeasure] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasure_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasure_EvaluationElement]
ON [edfi].[QuantitativeMeasure] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[QuantitativeMeasure] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasure_QuantitativeMeasureDatatypeDescriptor] FOREIGN KEY ([QuantitativeMeasureDatatypeDescriptorId])
REFERENCES [edfi].[QuantitativeMeasureDatatypeDescriptor] ([QuantitativeMeasureDatatypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasure_QuantitativeMeasureDatatypeDescriptor]
ON [edfi].[QuantitativeMeasure] ([QuantitativeMeasureDatatypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[QuantitativeMeasure] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasure_QuantitativeMeasureTypeDescriptor] FOREIGN KEY ([QuantitativeMeasureTypeDescriptorId])
REFERENCES [edfi].[QuantitativeMeasureTypeDescriptor] ([QuantitativeMeasureTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasure_QuantitativeMeasureTypeDescriptor]
ON [edfi].[QuantitativeMeasure] ([QuantitativeMeasureTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[QuantitativeMeasureDatatypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasureDatatypeDescriptor_Descriptor] FOREIGN KEY ([QuantitativeMeasureDatatypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[QuantitativeMeasureScore] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasureScore_EvaluationElementRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElementRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasureScore_EvaluationElementRating]
ON [edfi].[QuantitativeMeasureScore] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[QuantitativeMeasureScore] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasureScore_QuantitativeMeasure] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [QuantitativeMeasureIdentifier], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[QuantitativeMeasure] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [QuantitativeMeasureIdentifier], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_QuantitativeMeasureScore_QuantitativeMeasure]
ON [edfi].[QuantitativeMeasureScore] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [QuantitativeMeasureIdentifier] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[QuantitativeMeasureTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_QuantitativeMeasureTypeDescriptor_Descriptor] FOREIGN KEY ([QuantitativeMeasureTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[QuestionFormDescriptor] WITH CHECK ADD CONSTRAINT [FK_QuestionFormDescriptor_Descriptor] FOREIGN KEY ([QuestionFormDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RaceDescriptor] WITH CHECK ADD CONSTRAINT [FK_RaceDescriptor_Descriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_RatingLevelDescriptor_Descriptor] FOREIGN KEY ([RatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReasonExitedDescriptor] WITH CHECK ADD CONSTRAINT [FK_ReasonExitedDescriptor_Descriptor] FOREIGN KEY ([ReasonExitedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReasonNotTestedDescriptor] WITH CHECK ADD CONSTRAINT [FK_ReasonNotTestedDescriptor_Descriptor] FOREIGN KEY ([ReasonNotTestedDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecognitionTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_RecognitionTypeDescriptor_Descriptor] FOREIGN KEY ([RecognitionTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEvent] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEvent_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[RecruitmentEvent] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEvent_RecruitmentEventTypeDescriptor] FOREIGN KEY ([RecruitmentEventTypeDescriptorId])
REFERENCES [edfi].[RecruitmentEventTypeDescriptor] ([RecruitmentEventTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEvent_RecruitmentEventTypeDescriptor]
ON [edfi].[RecruitmentEvent] ([RecruitmentEventTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendance_RecruitmentEvent] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle])
REFERENCES [edfi].[RecruitmentEvent] ([EducationOrganizationId], [EventDate], [EventTitle])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendance_RecruitmentEvent]
ON [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId] ASC, [EventDate] ASC, [EventTitle] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendance_RecruitmentEventAttendeeTypeDescriptor] FOREIGN KEY ([RecruitmentEventAttendeeTypeDescriptorId])
REFERENCES [edfi].[RecruitmentEventAttendeeTypeDescriptor] ([RecruitmentEventAttendeeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendance_RecruitmentEventAttendeeTypeDescriptor]
ON [edfi].[RecruitmentEventAttendance] ([RecruitmentEventAttendeeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendance] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendance_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendance_SexDescriptor]
ON [edfi].[RecruitmentEventAttendance] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceCurrentPosition] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceCurrentPosition_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceCurrentPosition_AcademicSubjectDescriptor]
ON [edfi].[RecruitmentEventAttendanceCurrentPosition] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceCurrentPosition] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceCurrentPosition_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceCurrentPositionGradeLevel] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceCurrentPositionGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceCurrentPositionGradeLevel_GradeLevelDescriptor]
ON [edfi].[RecruitmentEventAttendanceCurrentPositionGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceCurrentPositionGradeLevel] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceCurrentPositionGradeLevel_RecruitmentEventAttendanceCurrentPosition] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendanceCurrentPosition] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceDisability] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceDisability_DisabilityDescriptor]
ON [edfi].[RecruitmentEventAttendanceDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceDisability] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [edfi].[RecruitmentEventAttendanceDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceDisability] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisability_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceDisabilityDesignation_DisabilityDesignationDescriptor]
ON [edfi].[RecruitmentEventAttendanceDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceDisabilityDesignation_RecruitmentEventAttendanceDisability] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier], [DisabilityDescriptorId])
REFERENCES [edfi].[RecruitmentEventAttendanceDisability] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendancePersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendancePersonalIdentificationDocument_CountryDescriptor]
ON [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendancePersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendancePersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendancePersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendancePersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendancePersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendancePersonalIdentificationDocument_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceRace] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceRace_RaceDescriptor]
ON [edfi].[RecruitmentEventAttendanceRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceRace] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceRace_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceTelephone] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceTelephone_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceTelephone] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RecruitmentEventAttendanceTelephone_TelephoneNumberTypeDescriptor]
ON [edfi].[RecruitmentEventAttendanceTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RecruitmentEventAttendanceTouchpoint] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendanceTouchpoint_RecruitmentEventAttendance] FOREIGN KEY ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
REFERENCES [edfi].[RecruitmentEventAttendance] ([EducationOrganizationId], [EventDate], [EventTitle], [RecruitmentEventAttendeeIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventAttendeeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventAttendeeTypeDescriptor_Descriptor] FOREIGN KEY ([RecruitmentEventAttendeeTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RecruitmentEventTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_RecruitmentEventTypeDescriptor_Descriptor] FOREIGN KEY ([RecruitmentEventTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RelationDescriptor] WITH CHECK ADD CONSTRAINT [FK_RelationDescriptor_Descriptor] FOREIGN KEY ([RelationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RepeatIdentifierDescriptor] WITH CHECK ADD CONSTRAINT [FK_RepeatIdentifierDescriptor_Descriptor] FOREIGN KEY ([RepeatIdentifierDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportCard] WITH CHECK ADD CONSTRAINT [FK_ReportCard_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[ReportCard] WITH CHECK ADD CONSTRAINT [FK_ReportCard_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [GradingPeriodName], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_ReportCard_GradingPeriod]
ON [edfi].[ReportCard] ([GradingPeriodDescriptorId] ASC, [GradingPeriodName] ASC, [GradingPeriodSchoolId] ASC, [GradingPeriodSchoolYear] ASC)
GO

ALTER TABLE [edfi].[ReportCard] WITH CHECK ADD CONSTRAINT [FK_ReportCard_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[ReportCardGrade] WITH CHECK ADD CONSTRAINT [FK_ReportCardGrade_Grade] FOREIGN KEY ([BeginDate], [GradeTypeDescriptorId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolYear], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[Grade] ([BeginDate], [GradeTypeDescriptorId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolYear], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ReportCardGrade_Grade]
ON [edfi].[ReportCardGrade] ([BeginDate] ASC, [GradeTypeDescriptorId] ASC, [GradingPeriodDescriptorId] ASC, [GradingPeriodName] ASC, [GradingPeriodSchoolYear] ASC, [LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[ReportCardGrade] WITH CHECK ADD CONSTRAINT [FK_ReportCardGrade_ReportCard] FOREIGN KEY ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
REFERENCES [edfi].[ReportCard] ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportCardGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ReportCardGradePointAverage_GradePointAverageTypeDescriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[GradePointAverageTypeDescriptor] ([GradePointAverageTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ReportCardGradePointAverage_GradePointAverageTypeDescriptor]
ON [edfi].[ReportCardGradePointAverage] ([GradePointAverageTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[ReportCardGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_ReportCardGradePointAverage_ReportCard] FOREIGN KEY ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
REFERENCES [edfi].[ReportCard] ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportCardStudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_ReportCardStudentCompetencyObjective_ReportCard] FOREIGN KEY ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
REFERENCES [edfi].[ReportCard] ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportCardStudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_ReportCardStudentCompetencyObjective_StudentCompetencyObjective] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCompetencyObjective] ([GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_ReportCardStudentCompetencyObjective_StudentCompetencyObjective]
ON [edfi].[ReportCardStudentCompetencyObjective] ([GradingPeriodDescriptorId] ASC, [GradingPeriodName] ASC, [GradingPeriodSchoolId] ASC, [GradingPeriodSchoolYear] ASC, [ObjectiveEducationOrganizationId] ASC, [Objective] ASC, [ObjectiveGradeLevelDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[ReporterDescriptionDescriptor] WITH CHECK ADD CONSTRAINT [FK_ReporterDescriptionDescriptor_Descriptor] FOREIGN KEY ([ReporterDescriptionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ReportingTagDescriptor] WITH CHECK ADD CONSTRAINT [FK_ReportingTagDescriptor_Descriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ResidencyStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_ResidencyStatusDescriptor_Descriptor] FOREIGN KEY ([ResidencyStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ResponseIndicatorDescriptor] WITH CHECK ADD CONSTRAINT [FK_ResponseIndicatorDescriptor_Descriptor] FOREIGN KEY ([ResponseIndicatorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ResponsibilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_ResponsibilityDescriptor_Descriptor] FOREIGN KEY ([ResponsibilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RestraintEvent] WITH CHECK ADD CONSTRAINT [FK_RestraintEvent_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_RestraintEvent_DisciplineIncident]
ON [edfi].[RestraintEvent] ([IncidentIdentifier] ASC, [SchoolId] ASC)
GO

ALTER TABLE [edfi].[RestraintEvent] WITH CHECK ADD CONSTRAINT [FK_RestraintEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RestraintEvent_EducationalEnvironmentDescriptor]
ON [edfi].[RestraintEvent] ([EducationalEnvironmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RestraintEvent] WITH CHECK ADD CONSTRAINT [FK_RestraintEvent_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[RestraintEvent] WITH CHECK ADD CONSTRAINT [FK_RestraintEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[RestraintEventProgram] WITH CHECK ADD CONSTRAINT [FK_RestraintEventProgram_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RestraintEventProgram_Program]
ON [edfi].[RestraintEventProgram] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RestraintEventProgram] WITH CHECK ADD CONSTRAINT [FK_RestraintEventProgram_RestraintEvent] FOREIGN KEY ([RestraintEventIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[RestraintEvent] ([RestraintEventIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RestraintEventReason] WITH CHECK ADD CONSTRAINT [FK_RestraintEventReason_RestraintEvent] FOREIGN KEY ([RestraintEventIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[RestraintEvent] ([RestraintEventIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RestraintEventReason] WITH CHECK ADD CONSTRAINT [FK_RestraintEventReason_RestraintEventReasonDescriptor] FOREIGN KEY ([RestraintEventReasonDescriptorId])
REFERENCES [edfi].[RestraintEventReasonDescriptor] ([RestraintEventReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RestraintEventReason_RestraintEventReasonDescriptor]
ON [edfi].[RestraintEventReason] ([RestraintEventReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RestraintEventReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_RestraintEventReasonDescriptor_Descriptor] FOREIGN KEY ([RestraintEventReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ResultDatatypeTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_ResultDatatypeTypeDescriptor_Descriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RetestIndicatorDescriptor] WITH CHECK ADD CONSTRAINT [FK_RetestIndicatorDescriptor_Descriptor] FOREIGN KEY ([RetestIndicatorDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[RubricDimension] WITH CHECK ADD CONSTRAINT [FK_RubricDimension_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RubricDimension_EvaluationElement]
ON [edfi].[RubricDimension] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RubricDimension] WITH CHECK ADD CONSTRAINT [FK_RubricDimension_RubricRatingLevelDescriptor] FOREIGN KEY ([RubricRatingLevelDescriptorId])
REFERENCES [edfi].[RubricRatingLevelDescriptor] ([RubricRatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_RubricDimension_RubricRatingLevelDescriptor]
ON [edfi].[RubricDimension] ([RubricRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[RubricRatingLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_RubricRatingLevelDescriptor_Descriptor] FOREIGN KEY ([RubricRatingLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SalaryTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_SalaryTypeDescriptor_Descriptor] FOREIGN KEY ([SalaryTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_AccreditationStatusDescriptor] FOREIGN KEY ([AccreditationStatusDescriptorId])
REFERENCES [edfi].[AccreditationStatusDescriptor] ([AccreditationStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_AccreditationStatusDescriptor]
ON [edfi].[School] ([AccreditationStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_AdministrativeFundingControlDescriptor] FOREIGN KEY ([AdministrativeFundingControlDescriptorId])
REFERENCES [edfi].[AdministrativeFundingControlDescriptor] ([AdministrativeFundingControlDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_AdministrativeFundingControlDescriptor]
ON [edfi].[School] ([AdministrativeFundingControlDescriptorId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_CharterApprovalAgencyTypeDescriptor] FOREIGN KEY ([CharterApprovalAgencyTypeDescriptorId])
REFERENCES [edfi].[CharterApprovalAgencyTypeDescriptor] ([CharterApprovalAgencyTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_CharterApprovalAgencyTypeDescriptor]
ON [edfi].[School] ([CharterApprovalAgencyTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_CharterStatusDescriptor] FOREIGN KEY ([CharterStatusDescriptorId])
REFERENCES [edfi].[CharterStatusDescriptor] ([CharterStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_CharterStatusDescriptor]
ON [edfi].[School] ([CharterStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_EducationOrganization] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [edfi].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_FederalLocaleCodeDescriptor]
ON [edfi].[School] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_InternetAccessDescriptor] FOREIGN KEY ([InternetAccessDescriptorId])
REFERENCES [edfi].[InternetAccessDescriptor] ([InternetAccessDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_InternetAccessDescriptor]
ON [edfi].[School] ([InternetAccessDescriptorId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_LocalEducationAgency] FOREIGN KEY ([LocalEducationAgencyId])
REFERENCES [edfi].[LocalEducationAgency] ([LocalEducationAgencyId])
GO

CREATE NONCLUSTERED INDEX [FK_School_LocalEducationAgency]
ON [edfi].[School] ([LocalEducationAgencyId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_MagnetSpecialProgramEmphasisSchoolDescriptor] FOREIGN KEY ([MagnetSpecialProgramEmphasisSchoolDescriptorId])
REFERENCES [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] ([MagnetSpecialProgramEmphasisSchoolDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_MagnetSpecialProgramEmphasisSchoolDescriptor]
ON [edfi].[School] ([MagnetSpecialProgramEmphasisSchoolDescriptorId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_PostSecondaryInstitution] FOREIGN KEY ([PostSecondaryInstitutionId])
REFERENCES [edfi].[PostSecondaryInstitution] ([PostSecondaryInstitutionId])
GO

CREATE NONCLUSTERED INDEX [FK_School_PostSecondaryInstitution]
ON [edfi].[School] ([PostSecondaryInstitutionId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_SchoolTypeDescriptor] FOREIGN KEY ([SchoolTypeDescriptorId])
REFERENCES [edfi].[SchoolTypeDescriptor] ([SchoolTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_SchoolTypeDescriptor]
ON [edfi].[School] ([SchoolTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_SchoolYearType] FOREIGN KEY ([CharterApprovalSchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_School_SchoolYearType]
ON [edfi].[School] ([CharterApprovalSchoolYear] ASC)
GO

ALTER TABLE [edfi].[School] WITH CHECK ADD CONSTRAINT [FK_School_TitleIPartASchoolDesignationDescriptor] FOREIGN KEY ([TitleIPartASchoolDesignationDescriptorId])
REFERENCES [edfi].[TitleIPartASchoolDesignationDescriptor] ([TitleIPartASchoolDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_School_TitleIPartASchoolDesignationDescriptor]
ON [edfi].[School] ([TitleIPartASchoolDesignationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SchoolCategory] WITH CHECK ADD CONSTRAINT [FK_SchoolCategory_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolCategory] WITH CHECK ADD CONSTRAINT [FK_SchoolCategory_SchoolCategoryDescriptor] FOREIGN KEY ([SchoolCategoryDescriptorId])
REFERENCES [edfi].[SchoolCategoryDescriptor] ([SchoolCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolCategory_SchoolCategoryDescriptor]
ON [edfi].[SchoolCategory] ([SchoolCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SchoolCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolCategoryDescriptor_Descriptor] FOREIGN KEY ([SchoolCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolChoiceBasisDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolChoiceBasisDescriptor_Descriptor] FOREIGN KEY ([SchoolChoiceBasisDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolChoiceImplementStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolChoiceImplementStatusDescriptor_Descriptor] FOREIGN KEY ([SchoolChoiceImplementStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolFoodServiceProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolFoodServiceProgramServiceDescriptor_Descriptor] FOREIGN KEY ([SchoolFoodServiceProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolGradeLevel] WITH CHECK ADD CONSTRAINT [FK_SchoolGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolGradeLevel_GradeLevelDescriptor]
ON [edfi].[SchoolGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SchoolGradeLevel] WITH CHECK ADD CONSTRAINT [FK_SchoolGradeLevel_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SchoolTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_SchoolTypeDescriptor_Descriptor] FOREIGN KEY ([SchoolTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_Section_CourseOffering]
ON [edfi].[Section] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_CreditTypeDescriptor] FOREIGN KEY ([AvailableCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Section_CreditTypeDescriptor]
ON [edfi].[Section] ([AvailableCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Section_EducationalEnvironmentDescriptor]
ON [edfi].[Section] ([EducationalEnvironmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_LanguageDescriptor] FOREIGN KEY ([InstructionLanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Section_LanguageDescriptor]
ON [edfi].[Section] ([InstructionLanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_Location] FOREIGN KEY ([LocationClassroomIdentificationCode], [LocationSchoolId])
REFERENCES [edfi].[Location] ([ClassroomIdentificationCode], [SchoolId])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_Section_Location]
ON [edfi].[Section] ([LocationClassroomIdentificationCode] ASC, [LocationSchoolId] ASC)
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_MediumOfInstructionDescriptor] FOREIGN KEY ([MediumOfInstructionDescriptorId])
REFERENCES [edfi].[MediumOfInstructionDescriptor] ([MediumOfInstructionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Section_MediumOfInstructionDescriptor]
ON [edfi].[Section] ([MediumOfInstructionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Section_PopulationServedDescriptor]
ON [edfi].[Section] ([PopulationServedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_School] FOREIGN KEY ([LocationSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_Section_School]
ON [edfi].[Section] ([LocationSchoolId] ASC)
GO

ALTER TABLE [edfi].[Section] WITH CHECK ADD CONSTRAINT [FK_Section_SectionTypeDescriptor] FOREIGN KEY ([SectionTypeDescriptorId])
REFERENCES [edfi].[SectionTypeDescriptor] ([SectionTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Section_SectionTypeDescriptor]
ON [edfi].[Section] ([SectionTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Section504DisabilityDescriptor] WITH CHECK ADD CONSTRAINT [FK_Section504DisabilityDescriptor_Descriptor] FOREIGN KEY ([Section504DisabilityDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] WITH CHECK ADD CONSTRAINT [FK_SectionAttendanceTakenEvent_CalendarDate] FOREIGN KEY ([CalendarCode], [Date], [SchoolId], [SchoolYear])
REFERENCES [edfi].[CalendarDate] ([CalendarCode], [Date], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_SectionAttendanceTakenEvent_CalendarDate]
ON [edfi].[SectionAttendanceTakenEvent] ([CalendarCode] ASC, [Date] ASC, [SchoolId] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] WITH CHECK ADD CONSTRAINT [FK_SectionAttendanceTakenEvent_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_SectionAttendanceTakenEvent_Section]
ON [edfi].[SectionAttendanceTakenEvent] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] WITH CHECK ADD CONSTRAINT [FK_SectionAttendanceTakenEvent_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[SectionCharacteristic] WITH CHECK ADD CONSTRAINT [FK_SectionCharacteristic_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionCharacteristic] WITH CHECK ADD CONSTRAINT [FK_SectionCharacteristic_SectionCharacteristicDescriptor] FOREIGN KEY ([SectionCharacteristicDescriptorId])
REFERENCES [edfi].[SectionCharacteristicDescriptor] ([SectionCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SectionCharacteristic_SectionCharacteristicDescriptor]
ON [edfi].[SectionCharacteristic] ([SectionCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SectionCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_SectionCharacteristicDescriptor_Descriptor] FOREIGN KEY ([SectionCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SectionClassPeriod] WITH CHECK ADD CONSTRAINT [FK_SectionClassPeriod_ClassPeriod] FOREIGN KEY ([ClassPeriodName], [SchoolId])
REFERENCES [edfi].[ClassPeriod] ([ClassPeriodName], [SchoolId])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_SectionClassPeriod_ClassPeriod]
ON [edfi].[SectionClassPeriod] ([ClassPeriodName] ASC, [SchoolId] ASC)
GO

ALTER TABLE [edfi].[SectionClassPeriod] WITH CHECK ADD CONSTRAINT [FK_SectionClassPeriod_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionCourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_SectionCourseLevelCharacteristic_CourseLevelCharacteristicDescriptor] FOREIGN KEY ([CourseLevelCharacteristicDescriptorId])
REFERENCES [edfi].[CourseLevelCharacteristicDescriptor] ([CourseLevelCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SectionCourseLevelCharacteristic_CourseLevelCharacteristicDescriptor]
ON [edfi].[SectionCourseLevelCharacteristic] ([CourseLevelCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SectionCourseLevelCharacteristic] WITH CHECK ADD CONSTRAINT [FK_SectionCourseLevelCharacteristic_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_SectionOfferedGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SectionOfferedGradeLevel_GradeLevelDescriptor]
ON [edfi].[SectionOfferedGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SectionOfferedGradeLevel] WITH CHECK ADD CONSTRAINT [FK_SectionOfferedGradeLevel_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionProgram] WITH CHECK ADD CONSTRAINT [FK_SectionProgram_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SectionProgram_Program]
ON [edfi].[SectionProgram] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SectionProgram] WITH CHECK ADD CONSTRAINT [FK_SectionProgram_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SectionTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_SectionTypeDescriptor_Descriptor] FOREIGN KEY ([SectionTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SeparationDescriptor] WITH CHECK ADD CONSTRAINT [FK_SeparationDescriptor_Descriptor] FOREIGN KEY ([SeparationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SeparationReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_SeparationReasonDescriptor_Descriptor] FOREIGN KEY ([SeparationReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[ServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_ServiceDescriptor_Descriptor] FOREIGN KEY ([ServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Session] WITH CHECK ADD CONSTRAINT [FK_Session_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[Session] WITH CHECK ADD CONSTRAINT [FK_Session_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_Session_SchoolYearType]
ON [edfi].[Session] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[Session] WITH CHECK ADD CONSTRAINT [FK_Session_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Session_TermDescriptor]
ON [edfi].[Session] ([TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SessionAcademicWeek] WITH CHECK ADD CONSTRAINT [FK_SessionAcademicWeek_AcademicWeek] FOREIGN KEY ([SchoolId], [WeekIdentifier])
REFERENCES [edfi].[AcademicWeek] ([SchoolId], [WeekIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SessionAcademicWeek_AcademicWeek]
ON [edfi].[SessionAcademicWeek] ([SchoolId] ASC, [WeekIdentifier] ASC)
GO

ALTER TABLE [edfi].[SessionAcademicWeek] WITH CHECK ADD CONSTRAINT [FK_SessionAcademicWeek_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SessionGradingPeriod] WITH CHECK ADD CONSTRAINT [FK_SessionGradingPeriod_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodName], [SchoolId], [SchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [GradingPeriodName], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_SessionGradingPeriod_GradingPeriod]
ON [edfi].[SessionGradingPeriod] ([GradingPeriodDescriptorId] ASC, [GradingPeriodName] ASC, [SchoolId] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [edfi].[SessionGradingPeriod] WITH CHECK ADD CONSTRAINT [FK_SessionGradingPeriod_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[SexDescriptor] WITH CHECK ADD CONSTRAINT [FK_SexDescriptor_Descriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SourceDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_SourceDimensionReportingTag_ReportingTagDescriptor] FOREIGN KEY ([ReportingTagDescriptorId])
REFERENCES [edfi].[ReportingTagDescriptor] ([ReportingTagDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SourceDimensionReportingTag_ReportingTagDescriptor]
ON [edfi].[SourceDimensionReportingTag] ([ReportingTagDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SourceDimensionReportingTag] WITH CHECK ADD CONSTRAINT [FK_SourceDimensionReportingTag_SourceDimension] FOREIGN KEY ([Code], [FiscalYear])
REFERENCES [edfi].[SourceDimension] ([Code], [FiscalYear])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SourceSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_SourceSystemDescriptor_Descriptor] FOREIGN KEY ([SourceSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SpecialEducationExitReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_SpecialEducationExitReasonDescriptor_Descriptor] FOREIGN KEY ([SpecialEducationExitReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SpecialEducationProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_SpecialEducationProgramServiceDescriptor_Descriptor] FOREIGN KEY ([SpecialEducationProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SpecialEducationSettingDescriptor] WITH CHECK ADD CONSTRAINT [FK_SpecialEducationSettingDescriptor_Descriptor] FOREIGN KEY ([SpecialEducationSettingDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Staff] WITH CHECK ADD CONSTRAINT [FK_Staff_LevelOfEducationDescriptor] FOREIGN KEY ([HighestCompletedLevelOfEducationDescriptorId])
REFERENCES [edfi].[LevelOfEducationDescriptor] ([LevelOfEducationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Staff_LevelOfEducationDescriptor]
ON [edfi].[Staff] ([HighestCompletedLevelOfEducationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Staff] WITH CHECK ADD CONSTRAINT [FK_Staff_OpenStaffPosition] FOREIGN KEY ([EducationOrganizationId], [RequisitionNumber])
REFERENCES [edfi].[OpenStaffPosition] ([EducationOrganizationId], [RequisitionNumber])
GO

CREATE NONCLUSTERED INDEX [FK_Staff_OpenStaffPosition]
ON [edfi].[Staff] ([EducationOrganizationId] ASC, [RequisitionNumber] ASC)
GO

ALTER TABLE [edfi].[Staff] WITH CHECK ADD CONSTRAINT [FK_Staff_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Staff_Person]
ON [edfi].[Staff] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffAbsenceEvent] WITH CHECK ADD CONSTRAINT [FK_StaffAbsenceEvent_AbsenceEventCategoryDescriptor] FOREIGN KEY ([AbsenceEventCategoryDescriptorId])
REFERENCES [edfi].[AbsenceEventCategoryDescriptor] ([AbsenceEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffAbsenceEvent_AbsenceEventCategoryDescriptor]
ON [edfi].[StaffAbsenceEvent] ([AbsenceEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffAbsenceEvent] WITH CHECK ADD CONSTRAINT [FK_StaffAbsenceEvent_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffClassificationDescriptor] WITH CHECK ADD CONSTRAINT [FK_StaffClassificationDescriptor_Descriptor] FOREIGN KEY ([StaffClassificationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffCohortAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffCohortAssociation_Cohort] FOREIGN KEY ([CohortIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Cohort] ([CohortIdentifier], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffCohortAssociation_Cohort]
ON [edfi].[StaffCohortAssociation] ([CohortIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[StaffCohortAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffCohortAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffCredential] WITH CHECK ADD CONSTRAINT [FK_StaffCredential_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffCredential_Credential]
ON [edfi].[StaffCredential] ([CredentialIdentifier] ASC, [StateOfIssueStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffCredential] WITH CHECK ADD CONSTRAINT [FK_StaffCredential_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDemographic] WITH CHECK ADD CONSTRAINT [FK_StaffDemographic_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographic_CitizenshipStatusDescriptor]
ON [edfi].[StaffDemographic] ([CitizenshipStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographic] WITH CHECK ADD CONSTRAINT [FK_StaffDemographic_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffDemographic] WITH CHECK ADD CONSTRAINT [FK_StaffDemographic_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographic_SexDescriptor]
ON [edfi].[StaffDemographic] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographic] WITH CHECK ADD CONSTRAINT [FK_StaffDemographic_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffDemographicAncestryEthnicOrigin] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicAncestryEthnicOrigin_AncestryEthnicOriginDescriptor] FOREIGN KEY ([AncestryEthnicOriginDescriptorId])
REFERENCES [edfi].[AncestryEthnicOriginDescriptor] ([AncestryEthnicOriginDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicAncestryEthnicOrigin_AncestryEthnicOriginDescriptor]
ON [edfi].[StaffDemographicAncestryEthnicOrigin] ([AncestryEthnicOriginDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographicAncestryEthnicOrigin] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicAncestryEthnicOrigin_StaffDemographic] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDemographic] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDemographicIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicIdentificationDocument_CountryDescriptor]
ON [edfi].[StaffDemographicIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographicIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[StaffDemographicIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographicIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[StaffDemographicIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographicIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicIdentificationDocument_StaffDemographic] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDemographic] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDemographicLanguage] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicLanguage_LanguageDescriptor]
ON [edfi].[StaffDemographicLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographicLanguage] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicLanguage_StaffDemographic] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDemographic] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDemographicLanguageUse] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicLanguageUse_LanguageUseDescriptor]
ON [edfi].[StaffDemographicLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographicLanguageUse] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicLanguageUse_StaffDemographicLanguage] FOREIGN KEY ([EducationOrganizationId], [StaffUSI], [LanguageDescriptorId])
REFERENCES [edfi].[StaffDemographicLanguage] ([EducationOrganizationId], [StaffUSI], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDemographicRace] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicRace_RaceDescriptor]
ON [edfi].[StaffDemographicRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographicRace] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicRace_StaffDemographic] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDemographic] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDemographicTribalAffiliation] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicTribalAffiliation_StaffDemographic] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDemographic] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDemographicTribalAffiliation] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicTribalAffiliation_TribalAffiliationDescriptor] FOREIGN KEY ([TribalAffiliationDescriptorId])
REFERENCES [edfi].[TribalAffiliationDescriptor] ([TribalAffiliationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicTribalAffiliation_TribalAffiliationDescriptor]
ON [edfi].[StaffDemographicTribalAffiliation] ([TribalAffiliationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDemographicVisa] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicVisa_StaffDemographic] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDemographic] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDemographicVisa] WITH CHECK ADD CONSTRAINT [FK_StaffDemographicVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDemographicVisa_VisaDescriptor]
ON [edfi].[StaffDemographicVisa] ([VisaDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDirectory] WITH CHECK ADD CONSTRAINT [FK_StaffDirectory_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffDirectory] WITH CHECK ADD CONSTRAINT [FK_StaffDirectory_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffDirectoryAddress] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDirectoryAddress_AddressTypeDescriptor]
ON [edfi].[StaffDirectoryAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDirectoryAddress] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDirectoryAddress_LocaleDescriptor]
ON [edfi].[StaffDirectoryAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDirectoryAddress] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryAddress_StaffDirectory] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDirectory] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDirectoryAddress] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDirectoryAddress_StateAbbreviationDescriptor]
ON [edfi].[StaffDirectoryAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDirectoryAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryAddressPeriod_StaffDirectoryAddress] FOREIGN KEY ([EducationOrganizationId], [StaffUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[StaffDirectoryAddress] ([EducationOrganizationId], [StaffUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDirectoryElectronicMail] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDirectoryElectronicMail_ElectronicMailTypeDescriptor]
ON [edfi].[StaffDirectoryElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDirectoryElectronicMail] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryElectronicMail_StaffDirectory] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDirectory] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDirectoryInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDirectoryInternationalAddress_AddressTypeDescriptor]
ON [edfi].[StaffDirectoryInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDirectoryInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDirectoryInternationalAddress_CountryDescriptor]
ON [edfi].[StaffDirectoryInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDirectoryInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryInternationalAddress_StaffDirectory] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDirectory] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDirectoryTelephone] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryTelephone_StaffDirectory] FOREIGN KEY ([EducationOrganizationId], [StaffUSI])
REFERENCES [edfi].[StaffDirectory] ([EducationOrganizationId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffDirectoryTelephone] WITH CHECK ADD CONSTRAINT [FK_StaffDirectoryTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDirectoryTelephone_TelephoneNumberTypeDescriptor]
ON [edfi].[StaffDirectoryTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffDisciplineIncidentAssociation_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDisciplineIncidentAssociation_DisciplineIncident]
ON [edfi].[StaffDisciplineIncidentAssociation] ([IncidentIdentifier] ASC, [SchoolId] ASC)
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffDisciplineIncidentAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescriptor] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[DisciplineIncidentParticipationCodeDescriptor] ([DisciplineIncidentParticipationCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescriptor]
ON [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] ([DisciplineIncidentParticipationCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StaffDisciplineIncidentAssociationDisciplineIncidentParticipationCode_StaffDisciplineIncidentAssociation] FOREIGN KEY ([IncidentIdentifier], [SchoolId], [StaffUSI])
REFERENCES [edfi].[StaffDisciplineIncidentAssociation] ([IncidentIdentifier], [SchoolId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationAssignmentAssociation_Credential]
ON [edfi].[StaffEducationOrganizationAssignmentAssociation] ([CredentialIdentifier] ASC, [StateOfIssueStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_StaffClassificationDescriptor] FOREIGN KEY ([StaffClassificationDescriptorId])
REFERENCES [edfi].[StaffClassificationDescriptor] ([StaffClassificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationAssignmentAssociation_StaffClassificationDescriptor]
ON [edfi].[StaffEducationOrganizationAssignmentAssociation] ([StaffClassificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationAssignmentAssociation_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EmploymentEducationOrganizationId], [EmploymentStatusDescriptorId], [EmploymentHireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationAssignmentAssociation_StaffEducationOrganizationEmploymentAssociation]
ON [edfi].[StaffEducationOrganizationAssignmentAssociation] ([EmploymentEducationOrganizationId] ASC, [EmploymentStatusDescriptorId] ASC, [EmploymentHireDate] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_Credential] FOREIGN KEY ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
REFERENCES [edfi].[Credential] ([CredentialIdentifier], [StateOfIssueStateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociation_Credential]
ON [edfi].[StaffEducationOrganizationEmploymentAssociation] ([CredentialIdentifier] ASC, [StateOfIssueStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_EmploymentStatusDescriptor] FOREIGN KEY ([EmploymentStatusDescriptorId])
REFERENCES [edfi].[EmploymentStatusDescriptor] ([EmploymentStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociation_EmploymentStatusDescriptor]
ON [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EmploymentStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_LengthOfContractDescriptor] FOREIGN KEY ([LengthOfContractDescriptorId])
REFERENCES [edfi].[LengthOfContractDescriptor] ([LengthOfContractDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociation_LengthOfContractDescriptor]
ON [edfi].[StaffEducationOrganizationEmploymentAssociation] ([LengthOfContractDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_SeparationDescriptor] FOREIGN KEY ([SeparationDescriptorId])
REFERENCES [edfi].[SeparationDescriptor] ([SeparationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociation_SeparationDescriptor]
ON [edfi].[StaffEducationOrganizationEmploymentAssociation] ([SeparationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_SeparationReasonDescriptor] FOREIGN KEY ([SeparationReasonDescriptorId])
REFERENCES [edfi].[SeparationReasonDescriptor] ([SeparationReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociation_SeparationReasonDescriptor]
ON [edfi].[StaffEducationOrganizationEmploymentAssociation] ([SeparationReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_BackgroundCheckStatusDescriptor] FOREIGN KEY ([BackgroundCheckStatusDescriptorId])
REFERENCES [edfi].[BackgroundCheckStatusDescriptor] ([BackgroundCheckStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_BackgroundCheckStatusDescriptor]
ON [edfi].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] ([BackgroundCheckStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_BackgroundCheckTypeDescriptor] FOREIGN KEY ([BackgroundCheckTypeDescriptorId])
REFERENCES [edfi].[BackgroundCheckTypeDescriptor] ([BackgroundCheckTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_BackgroundCheckTypeDescriptor]
ON [edfi].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] ([BackgroundCheckTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationBackgroundCheck_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationSalary] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationSalary_SalaryTypeDescriptor] FOREIGN KEY ([SalaryTypeDescriptorId])
REFERENCES [edfi].[SalaryTypeDescriptor] ([SalaryTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationSalary_SalaryTypeDescriptor]
ON [edfi].[StaffEducationOrganizationEmploymentAssociationSalary] ([SalaryTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationSalary] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationSalary_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationSeniority] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationSeniority_CredentialFieldDescriptor] FOREIGN KEY ([CredentialFieldDescriptorId])
REFERENCES [edfi].[CredentialFieldDescriptor] ([CredentialFieldDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducationOrganizationEmploymentAssociationSeniority_CredentialFieldDescriptor]
ON [edfi].[StaffEducationOrganizationEmploymentAssociationSeniority] ([CredentialFieldDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociationSeniority] WITH CHECK ADD CONSTRAINT [FK_StaffEducationOrganizationEmploymentAssociationSeniority_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorPreparationProgram_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducatorPreparationProgram_EducatorPreparationProgram]
ON [edfi].[StaffEducatorPreparationProgram] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducatorPreparationProgram] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorPreparationProgram_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorPreparationProgramAssociation_EducatorPreparationProgram] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[EducatorPreparationProgram] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffEducatorPreparationProgramAssociation_EducatorPreparationProgram]
ON [edfi].[StaffEducatorPreparationProgramAssociation] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffEducatorPreparationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorPreparationProgramAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffEducatorResearch] WITH CHECK ADD CONSTRAINT [FK_StaffEducatorResearch_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffHighlyQualifiedAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffHighlyQualifiedAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffHighlyQualifiedAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[StaffHighlyQualifiedAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffHighlyQualifiedAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffHighlyQualifiedAcademicSubject_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationCode_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StaffIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationCode_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationCode_StaffIdentificationSystemDescriptor] FOREIGN KEY ([StaffIdentificationSystemDescriptorId])
REFERENCES [edfi].[StaffIdentificationSystemDescriptor] ([StaffIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffIdentificationCode_StaffIdentificationSystemDescriptor]
ON [edfi].[StaffIdentificationCode] ([StaffIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_StaffIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([StaffIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffLeave] WITH CHECK ADD CONSTRAINT [FK_StaffLeave_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffLeave] WITH CHECK ADD CONSTRAINT [FK_StaffLeave_StaffLeaveEventCategoryDescriptor] FOREIGN KEY ([StaffLeaveEventCategoryDescriptorId])
REFERENCES [edfi].[StaffLeaveEventCategoryDescriptor] ([StaffLeaveEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffLeave_StaffLeaveEventCategoryDescriptor]
ON [edfi].[StaffLeave] ([StaffLeaveEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffLeaveEventCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_StaffLeaveEventCategoryDescriptor_Descriptor] FOREIGN KEY ([StaffLeaveEventCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffOtherName] WITH CHECK ADD CONSTRAINT [FK_StaffOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffOtherName_OtherNameTypeDescriptor]
ON [edfi].[StaffOtherName] ([OtherNameTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffOtherName] WITH CHECK ADD CONSTRAINT [FK_StaffOtherName_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffPersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffPersonalIdentificationDocument_CountryDescriptor]
ON [edfi].[StaffPersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffPersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffPersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[StaffPersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffPersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffPersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[StaffPersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StaffPersonalIdentificationDocument_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffProgramAssociation_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffProgramAssociation_Program]
ON [edfi].[StaffProgramAssociation] ([ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffProgramAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffRecognition] WITH CHECK ADD CONSTRAINT [FK_StaffRecognition_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffRecognition_AchievementCategoryDescriptor]
ON [edfi].[StaffRecognition] ([AchievementCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffRecognition] WITH CHECK ADD CONSTRAINT [FK_StaffRecognition_RecognitionTypeDescriptor] FOREIGN KEY ([RecognitionTypeDescriptorId])
REFERENCES [edfi].[RecognitionTypeDescriptor] ([RecognitionTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffRecognition_RecognitionTypeDescriptor]
ON [edfi].[StaffRecognition] ([RecognitionTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffRecognition] WITH CHECK ADD CONSTRAINT [FK_StaffRecognition_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_Calendar] FOREIGN KEY ([CalendarCode], [SchoolId], [SchoolYear])
REFERENCES [edfi].[Calendar] ([CalendarCode], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StaffSchoolAssociation_Calendar]
ON [edfi].[StaffSchoolAssociation] ([CalendarCode] ASC, [SchoolId] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_ProgramAssignmentDescriptor] FOREIGN KEY ([ProgramAssignmentDescriptorId])
REFERENCES [edfi].[ProgramAssignmentDescriptor] ([ProgramAssignmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffSchoolAssociation_ProgramAssignmentDescriptor]
ON [edfi].[StaffSchoolAssociation] ([ProgramAssignmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StaffSchoolAssociation_SchoolYearType]
ON [edfi].[StaffSchoolAssociation] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffSchoolAssociationAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociationAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffSchoolAssociationAcademicSubject_AcademicSubjectDescriptor]
ON [edfi].[StaffSchoolAssociationAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffSchoolAssociationAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociationAcademicSubject_StaffSchoolAssociation] FOREIGN KEY ([ProgramAssignmentDescriptorId], [SchoolId], [StaffUSI])
REFERENCES [edfi].[StaffSchoolAssociation] ([ProgramAssignmentDescriptorId], [SchoolId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffSchoolAssociationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociationGradeLevel_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffSchoolAssociationGradeLevel_GradeLevelDescriptor]
ON [edfi].[StaffSchoolAssociationGradeLevel] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffSchoolAssociationGradeLevel] WITH CHECK ADD CONSTRAINT [FK_StaffSchoolAssociationGradeLevel_StaffSchoolAssociation] FOREIGN KEY ([ProgramAssignmentDescriptorId], [SchoolId], [StaffUSI])
REFERENCES [edfi].[StaffSchoolAssociation] ([ProgramAssignmentDescriptorId], [SchoolId], [StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StaffSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSectionAssociation_ClassroomPositionDescriptor] FOREIGN KEY ([ClassroomPositionDescriptorId])
REFERENCES [edfi].[ClassroomPositionDescriptor] ([ClassroomPositionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StaffSectionAssociation_ClassroomPositionDescriptor]
ON [edfi].[StaffSectionAssociation] ([ClassroomPositionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StaffSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffSectionAssociation_Section]
ON [edfi].[StaffSectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[StaffSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffSectionAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[StaffToCandidateRelationshipDescriptor] WITH CHECK ADD CONSTRAINT [FK_StaffToCandidateRelationshipDescriptor_Descriptor] FOREIGN KEY ([StaffToCandidateRelationshipDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StateAbbreviationDescriptor] WITH CHECK ADD CONSTRAINT [FK_StateAbbreviationDescriptor_Descriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StateEducationAgency] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgency_EducationOrganization] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StateEducationAgency] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgency_FederalLocaleCodeDescriptor] FOREIGN KEY ([FederalLocaleCodeDescriptorId])
REFERENCES [edfi].[FederalLocaleCodeDescriptor] ([FederalLocaleCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StateEducationAgency_FederalLocaleCodeDescriptor]
ON [edfi].[StateEducationAgency] ([FederalLocaleCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StateEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgencyAccountability_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StateEducationAgencyAccountability_SchoolYearType]
ON [edfi].[StateEducationAgencyAccountability] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StateEducationAgencyAccountability] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgencyAccountability_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StateEducationAgencyFederalFunds] WITH CHECK ADD CONSTRAINT [FK_StateEducationAgencyFederalFunds_StateEducationAgency] FOREIGN KEY ([StateEducationAgencyId])
REFERENCES [edfi].[StateEducationAgency] ([StateEducationAgencyId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_CountryDescriptor] FOREIGN KEY ([BirthCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Student_CountryDescriptor]
ON [edfi].[Student] ([BirthCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Student_Person]
ON [edfi].[Student] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_SexDescriptor] FOREIGN KEY ([BirthSexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Student_SexDescriptor]
ON [edfi].[Student] ([BirthSexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_StateAbbreviationDescriptor] FOREIGN KEY ([BirthStateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Student_StateAbbreviationDescriptor]
ON [edfi].[Student] ([BirthStateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_CreditTypeDescriptor] FOREIGN KEY ([CumulativeEarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecord_CreditTypeDescriptor]
ON [edfi].[StudentAcademicRecord] ([CumulativeEarnedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_CreditTypeDescriptor1] FOREIGN KEY ([CumulativeAttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecord_CreditTypeDescriptor1]
ON [edfi].[StudentAcademicRecord] ([CumulativeAttemptedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_CreditTypeDescriptor2] FOREIGN KEY ([SessionEarnedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecord_CreditTypeDescriptor2]
ON [edfi].[StudentAcademicRecord] ([SessionEarnedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_CreditTypeDescriptor3] FOREIGN KEY ([SessionAttemptedCreditTypeDescriptorId])
REFERENCES [edfi].[CreditTypeDescriptor] ([CreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecord_CreditTypeDescriptor3]
ON [edfi].[StudentAcademicRecord] ([SessionAttemptedCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecord_SchoolYearType]
ON [edfi].[StudentAcademicRecord] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentAcademicRecord] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecord_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecord_TermDescriptor]
ON [edfi].[StudentAcademicRecord] ([TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordAcademicHonor_AcademicHonorCategoryDescriptor] FOREIGN KEY ([AcademicHonorCategoryDescriptorId])
REFERENCES [edfi].[AcademicHonorCategoryDescriptor] ([AcademicHonorCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordAcademicHonor_AcademicHonorCategoryDescriptor]
ON [edfi].[StudentAcademicRecordAcademicHonor] ([AcademicHonorCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordAcademicHonor_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordAcademicHonor_AchievementCategoryDescriptor]
ON [edfi].[StudentAcademicRecordAcademicHonor] ([AchievementCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordAcademicHonor_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordClassRanking] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordClassRanking_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordDiploma_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordDiploma_AchievementCategoryDescriptor]
ON [edfi].[StudentAcademicRecordDiploma] ([AchievementCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordDiploma_DiplomaLevelDescriptor] FOREIGN KEY ([DiplomaLevelDescriptorId])
REFERENCES [edfi].[DiplomaLevelDescriptor] ([DiplomaLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordDiploma_DiplomaLevelDescriptor]
ON [edfi].[StudentAcademicRecordDiploma] ([DiplomaLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordDiploma_DiplomaTypeDescriptor] FOREIGN KEY ([DiplomaTypeDescriptorId])
REFERENCES [edfi].[DiplomaTypeDescriptor] ([DiplomaTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordDiploma_DiplomaTypeDescriptor]
ON [edfi].[StudentAcademicRecordDiploma] ([DiplomaTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordDiploma_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordGradePointAverage_GradePointAverageTypeDescriptor] FOREIGN KEY ([GradePointAverageTypeDescriptorId])
REFERENCES [edfi].[GradePointAverageTypeDescriptor] ([GradePointAverageTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordGradePointAverage_GradePointAverageTypeDescriptor]
ON [edfi].[StudentAcademicRecordGradePointAverage] ([GradePointAverageTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordGradePointAverage] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordGradePointAverage_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordRecognition_AchievementCategoryDescriptor] FOREIGN KEY ([AchievementCategoryDescriptorId])
REFERENCES [edfi].[AchievementCategoryDescriptor] ([AchievementCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordRecognition_AchievementCategoryDescriptor]
ON [edfi].[StudentAcademicRecordRecognition] ([AchievementCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordRecognition_RecognitionTypeDescriptor] FOREIGN KEY ([RecognitionTypeDescriptorId])
REFERENCES [edfi].[RecognitionTypeDescriptor] ([RecognitionTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordRecognition_RecognitionTypeDescriptor]
ON [edfi].[StudentAcademicRecordRecognition] ([RecognitionTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordRecognition] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordRecognition_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAcademicRecordReportCard] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordReportCard_ReportCard] FOREIGN KEY ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
REFERENCES [edfi].[ReportCard] ([EducationOrganizationId], [GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAcademicRecordReportCard_ReportCard]
ON [edfi].[StudentAcademicRecordReportCard] ([EducationOrganizationId] ASC, [GradingPeriodDescriptorId] ASC, [GradingPeriodName] ASC, [GradingPeriodSchoolId] ASC, [GradingPeriodSchoolYear] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentAcademicRecordReportCard] WITH CHECK ADD CONSTRAINT [FK_StudentAcademicRecordReportCard_StudentAcademicRecord] FOREIGN KEY ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
REFERENCES [edfi].[StudentAcademicRecord] ([EducationOrganizationId], [SchoolYear], [StudentUSI], [TermDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_AdministrationEnvironmentDescriptor] FOREIGN KEY ([AdministrationEnvironmentDescriptorId])
REFERENCES [edfi].[AdministrationEnvironmentDescriptor] ([AdministrationEnvironmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_AdministrationEnvironmentDescriptor]
ON [edfi].[StudentAssessment] ([AdministrationEnvironmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_Assessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[Assessment] ([AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_Assessment]
ON [edfi].[StudentAssessment] ([AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_EventCircumstanceDescriptor] FOREIGN KEY ([EventCircumstanceDescriptorId])
REFERENCES [edfi].[EventCircumstanceDescriptor] ([EventCircumstanceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_EventCircumstanceDescriptor]
ON [edfi].[StudentAssessment] ([EventCircumstanceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_GradeLevelDescriptor] FOREIGN KEY ([WhenAssessedGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_GradeLevelDescriptor]
ON [edfi].[StudentAssessment] ([WhenAssessedGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_LanguageDescriptor] FOREIGN KEY ([AdministrationLanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_LanguageDescriptor]
ON [edfi].[StudentAssessment] ([AdministrationLanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_PlatformTypeDescriptor] FOREIGN KEY ([PlatformTypeDescriptorId])
REFERENCES [edfi].[PlatformTypeDescriptor] ([PlatformTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_PlatformTypeDescriptor]
ON [edfi].[StudentAssessment] ([PlatformTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_ReasonNotTestedDescriptor] FOREIGN KEY ([ReasonNotTestedDescriptorId])
REFERENCES [edfi].[ReasonNotTestedDescriptor] ([ReasonNotTestedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_ReasonNotTestedDescriptor]
ON [edfi].[StudentAssessment] ([ReasonNotTestedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_RetestIndicatorDescriptor] FOREIGN KEY ([RetestIndicatorDescriptorId])
REFERENCES [edfi].[RetestIndicatorDescriptor] ([RetestIndicatorDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_RetestIndicatorDescriptor]
ON [edfi].[StudentAssessment] ([RetestIndicatorDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_School] FOREIGN KEY ([ReportedSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_School]
ON [edfi].[StudentAssessment] ([ReportedSchoolId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessment_SchoolYearType]
ON [edfi].[StudentAssessment] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessment_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentAssessmentAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentAccommodation_AccommodationDescriptor] FOREIGN KEY ([AccommodationDescriptorId])
REFERENCES [edfi].[AccommodationDescriptor] ([AccommodationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentAccommodation_AccommodationDescriptor]
ON [edfi].[StudentAssessmentAccommodation] ([AccommodationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentAccommodation_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentEducationOrganizationAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationAssociationTypeDescriptor] FOREIGN KEY ([EducationOrganizationAssociationTypeDescriptorId])
REFERENCES [edfi].[EducationOrganizationAssociationTypeDescriptor] ([EducationOrganizationAssociationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentEducationOrganizationAssociation_EducationOrganizationAssociationTypeDescriptor]
ON [edfi].[StudentAssessmentEducationOrganizationAssociation] ([EducationOrganizationAssociationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentEducationOrganizationAssociation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentEducationOrganizationAssociation_SchoolYearType]
ON [edfi].[StudentAssessmentEducationOrganizationAssociation] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentEducationOrganizationAssociation_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentEducationOrganizationAssociation_StudentAssessment]
ON [edfi].[StudentAssessmentEducationOrganizationAssociation] ([AssessmentIdentifier] ASC, [Namespace] ASC, [StudentAssessmentIdentifier] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentItem_AssessmentItem] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[AssessmentItem] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentItem_AssessmentItem]
ON [edfi].[StudentAssessmentItem] ([AssessmentIdentifier] ASC, [IdentificationCode] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentItem_AssessmentItemResultDescriptor] FOREIGN KEY ([AssessmentItemResultDescriptorId])
REFERENCES [edfi].[AssessmentItemResultDescriptor] ([AssessmentItemResultDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentItem_AssessmentItemResultDescriptor]
ON [edfi].[StudentAssessmentItem] ([AssessmentItemResultDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentItem_ResponseIndicatorDescriptor] FOREIGN KEY ([ResponseIndicatorDescriptorId])
REFERENCES [edfi].[ResponseIndicatorDescriptor] ([ResponseIndicatorDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentItem_ResponseIndicatorDescriptor]
ON [edfi].[StudentAssessmentItem] ([ResponseIndicatorDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentItem] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentItem_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor]
ON [edfi].[StudentAssessmentPerformanceLevel] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentPerformanceLevel_PerformanceLevelDescriptor]
ON [edfi].[StudentAssessmentPerformanceLevel] ([PerformanceLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPerformanceLevel_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPeriod_AssessmentPeriodDescriptor] FOREIGN KEY ([AssessmentPeriodDescriptorId])
REFERENCES [edfi].[AssessmentPeriodDescriptor] ([AssessmentPeriodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentPeriod_AssessmentPeriodDescriptor]
ON [edfi].[StudentAssessmentPeriod] ([AssessmentPeriodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentPeriod_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentRegistration] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistration_AssessmentAdministration] FOREIGN KEY ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace])
REFERENCES [edfi].[AssessmentAdministration] ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistration_AssessmentAdministration]
ON [edfi].[StudentAssessmentRegistration] ([AdministrationIdentifier] ASC, [AssessmentIdentifier] ASC, [AssigningEducationOrganizationId] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistration] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistration_EducationOrganization] FOREIGN KEY ([ReportingEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistration_EducationOrganization]
ON [edfi].[StudentAssessmentRegistration] ([ReportingEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistration] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistration_EducationOrganization1] FOREIGN KEY ([TestingEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistration_EducationOrganization1]
ON [edfi].[StudentAssessmentRegistration] ([TestingEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistration] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistration_GradeLevelDescriptor] FOREIGN KEY ([AssessmentGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistration_GradeLevelDescriptor]
ON [edfi].[StudentAssessmentRegistration] ([AssessmentGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistration] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistration_PlatformTypeDescriptor] FOREIGN KEY ([PlatformTypeDescriptorId])
REFERENCES [edfi].[PlatformTypeDescriptor] ([PlatformTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistration_PlatformTypeDescriptor]
ON [edfi].[StudentAssessmentRegistration] ([PlatformTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistration] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistration_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistration_StudentDemographic]
ON [edfi].[StudentAssessmentRegistration] ([EducationOrganizationId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistration] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistration_StudentEducationOrganizationAssessmentAccommodation] FOREIGN KEY ([ScheduledEducationOrganizationId], [ScheduledStudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssessmentAccommodation] ([EducationOrganizationId], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistration_StudentEducationOrganizationAssessmentAccommodation]
ON [edfi].[StudentAssessmentRegistration] ([ScheduledEducationOrganizationId] ASC, [ScheduledStudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistration] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistration_StudentSchoolAssociation] FOREIGN KEY ([EntryDate], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentSchoolAssociation] ([EntryDate], [SchoolId], [StudentUSI])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistration_StudentSchoolAssociation]
ON [edfi].[StudentAssessmentRegistration] ([EntryDate] ASC, [SchoolId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistrationAssessmentAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistrationAssessmentAccommodation_AccommodationDescriptor] FOREIGN KEY ([AccommodationDescriptorId])
REFERENCES [edfi].[AccommodationDescriptor] ([AccommodationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistrationAssessmentAccommodation_AccommodationDescriptor]
ON [edfi].[StudentAssessmentRegistrationAssessmentAccommodation] ([AccommodationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistrationAssessmentAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistrationAssessmentAccommodation_StudentAssessmentRegistration] FOREIGN KEY ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [EducationOrganizationId], [Namespace], [StudentUSI])
REFERENCES [edfi].[StudentAssessmentRegistration] ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [EducationOrganizationId], [Namespace], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentRegistrationAssessmentCustomization] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistrationAssessmentCustomization_StudentAssessmentRegistration] FOREIGN KEY ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [EducationOrganizationId], [Namespace], [StudentUSI])
REFERENCES [edfi].[StudentAssessmentRegistration] ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [EducationOrganizationId], [Namespace], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistrationBatteryPartAssociation_AssessmentBatteryPart] FOREIGN KEY ([AssessmentBatteryPartName], [AssessmentIdentifier], [Namespace])
REFERENCES [edfi].[AssessmentBatteryPart] ([AssessmentBatteryPartName], [AssessmentIdentifier], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistrationBatteryPartAssociation_AssessmentBatteryPart]
ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] ([AssessmentBatteryPartName] ASC, [AssessmentIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistrationBatteryPartAssociation_StudentAssessmentRegistration] FOREIGN KEY ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [EducationOrganizationId], [Namespace], [StudentUSI])
REFERENCES [edfi].[StudentAssessmentRegistration] ([AdministrationIdentifier], [AssessmentIdentifier], [AssigningEducationOrganizationId], [EducationOrganizationId], [Namespace], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistrationBatteryPartAssociation_StudentAssessmentRegistration]
ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] ([AdministrationIdentifier] ASC, [AssessmentIdentifier] ASC, [AssigningEducationOrganizationId] ASC, [EducationOrganizationId] ASC, [Namespace] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociationAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistrationBatteryPartAssociationAccommodation_AccommodationDescriptor] FOREIGN KEY ([AccommodationDescriptorId])
REFERENCES [edfi].[AccommodationDescriptor] ([AccommodationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentRegistrationBatteryPartAssociationAccommodation_AccommodationDescriptor]
ON [edfi].[StudentAssessmentRegistrationBatteryPartAssociationAccommodation] ([AccommodationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentRegistrationBatteryPartAssociationAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentRegistrationBatteryPartAssociationAccommodation_StudentAssessmentRegistrationBatteryPartAssociation] FOREIGN KEY ([AdministrationIdentifier], [AssessmentBatteryPartName], [AssessmentIdentifier], [AssigningEducationOrganizationId], [EducationOrganizationId], [Namespace], [StudentUSI])
REFERENCES [edfi].[StudentAssessmentRegistrationBatteryPartAssociation] ([AdministrationIdentifier], [AssessmentBatteryPartName], [AssessmentIdentifier], [AssigningEducationOrganizationId], [EducationOrganizationId], [Namespace], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentScoreResult_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentScoreResult_AssessmentReportingMethodDescriptor]
ON [edfi].[StudentAssessmentScoreResult] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentScoreResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentScoreResult_ResultDatatypeTypeDescriptor]
ON [edfi].[StudentAssessmentScoreResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentScoreResult_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessment_ObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [IdentificationCode], [Namespace])
REFERENCES [edfi].[ObjectiveAssessment] ([AssessmentIdentifier], [IdentificationCode], [Namespace])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentStudentObjectiveAssessment_ObjectiveAssessment]
ON [edfi].[StudentAssessmentStudentObjectiveAssessment] ([AssessmentIdentifier] ASC, [IdentificationCode] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessment_StudentAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
REFERENCES [edfi].[StudentAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_AssessmentReportingMethodDescriptor]
ON [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_PerformanceLevelDescriptor] FOREIGN KEY ([PerformanceLevelDescriptorId])
REFERENCES [edfi].[PerformanceLevelDescriptor] ([PerformanceLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_PerformanceLevelDescriptor]
ON [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] ([PerformanceLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_StudentAssessmentStudentObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI], [IdentificationCode])
REFERENCES [edfi].[StudentAssessmentStudentObjectiveAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI], [IdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentScoreResult_AssessmentReportingMethodDescriptor] FOREIGN KEY ([AssessmentReportingMethodDescriptorId])
REFERENCES [edfi].[AssessmentReportingMethodDescriptor] ([AssessmentReportingMethodDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentStudentObjectiveAssessmentScoreResult_AssessmentReportingMethodDescriptor]
ON [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] ([AssessmentReportingMethodDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentScoreResult_ResultDatatypeTypeDescriptor] FOREIGN KEY ([ResultDatatypeTypeDescriptorId])
REFERENCES [edfi].[ResultDatatypeTypeDescriptor] ([ResultDatatypeTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentAssessmentStudentObjectiveAssessmentScoreResult_ResultDatatypeTypeDescriptor]
ON [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] ([ResultDatatypeTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] WITH CHECK ADD CONSTRAINT [FK_StudentAssessmentStudentObjectiveAssessmentScoreResult_StudentAssessmentStudentObjectiveAssessment] FOREIGN KEY ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI], [IdentificationCode])
REFERENCES [edfi].[StudentAssessmentStudentObjectiveAssessment] ([AssessmentIdentifier], [Namespace], [StudentAssessmentIdentifier], [StudentUSI], [IdentificationCode])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCharacteristicDescriptor] WITH CHECK ADD CONSTRAINT [FK_StudentCharacteristicDescriptor_Descriptor] FOREIGN KEY ([StudentCharacteristicDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCohortAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCohortAssociation_Cohort] FOREIGN KEY ([CohortIdentifier], [EducationOrganizationId])
REFERENCES [edfi].[Cohort] ([CohortIdentifier], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentCohortAssociation_Cohort]
ON [edfi].[StudentCohortAssociation] ([CohortIdentifier] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[StudentCohortAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCohortAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentCohortAssociationSection] WITH CHECK ADD CONSTRAINT [FK_StudentCohortAssociationSection_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentCohortAssociationSection_Section]
ON [edfi].[StudentCohortAssociationSection] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[StudentCohortAssociationSection] WITH CHECK ADD CONSTRAINT [FK_StudentCohortAssociationSection_StudentCohortAssociation] FOREIGN KEY ([BeginDate], [CohortIdentifier], [EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentCohortAssociation] ([BeginDate], [CohortIdentifier], [EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjective_CompetencyLevelDescriptor] FOREIGN KEY ([CompetencyLevelDescriptorId])
REFERENCES [edfi].[CompetencyLevelDescriptor] ([CompetencyLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentCompetencyObjective_CompetencyLevelDescriptor]
ON [edfi].[StudentCompetencyObjective] ([CompetencyLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjective_CompetencyObjective] FOREIGN KEY ([ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId])
REFERENCES [edfi].[CompetencyObjective] ([EducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentCompetencyObjective_CompetencyObjective]
ON [edfi].[StudentCompetencyObjective] ([ObjectiveEducationOrganizationId] ASC, [Objective] ASC, [ObjectiveGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjective_GradingPeriod] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear])
REFERENCES [edfi].[GradingPeriod] ([GradingPeriodDescriptorId], [GradingPeriodName], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentCompetencyObjective_GradingPeriod]
ON [edfi].[StudentCompetencyObjective] ([GradingPeriodDescriptorId] ASC, [GradingPeriodName] ASC, [GradingPeriodSchoolId] ASC, [GradingPeriodSchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjective_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjectiveGeneralStudentProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentCompetencyObjectiveGeneralStudentProgramAssociation_GeneralStudentProgramAssociation]
ON [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] ([BeginDate] ASC, [EducationOrganizationId] ASC, [ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjectiveGeneralStudentProgramAssociation_StudentCompetencyObjective] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCompetencyObjective] ([GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjectiveStudentSectionAssociation_StudentCompetencyObjective] FOREIGN KEY ([GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCompetencyObjective] ([GradingPeriodDescriptorId], [GradingPeriodName], [GradingPeriodSchoolId], [GradingPeriodSchoolYear], [ObjectiveEducationOrganizationId], [Objective], [ObjectiveGradeLevelDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCompetencyObjectiveStudentSectionAssociation_StudentSectionAssociation] FOREIGN KEY ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentSectionAssociation] ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentCompetencyObjectiveStudentSectionAssociation_StudentSectionAssociation]
ON [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] ([BeginDate] ASC, [LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentContactAssociation_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentContactAssociation_Contact]
ON [edfi].[StudentContactAssociation] ([ContactUSI] ASC)
GO

ALTER TABLE [edfi].[StudentContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentContactAssociation_RelationDescriptor] FOREIGN KEY ([RelationDescriptorId])
REFERENCES [edfi].[RelationDescriptor] ([RelationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentContactAssociation_RelationDescriptor]
ON [edfi].[StudentContactAssociation] ([RelationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentContactAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentContactAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentContactAssociation_Student]
ON [edfi].[StudentContactAssociation] ([StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociation_TechnicalSkillsAssessmentDescriptor] FOREIGN KEY ([TechnicalSkillsAssessmentDescriptorId])
REFERENCES [edfi].[TechnicalSkillsAssessmentDescriptor] ([TechnicalSkillsAssessmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentCTEProgramAssociation_TechnicalSkillsAssessmentDescriptor]
ON [edfi].[StudentCTEProgramAssociation] ([TechnicalSkillsAssessmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociationCTEProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociationCTEProgramService_CTEProgramServiceDescriptor] FOREIGN KEY ([CTEProgramServiceDescriptorId])
REFERENCES [edfi].[CTEProgramServiceDescriptor] ([CTEProgramServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentCTEProgramAssociationCTEProgramService_CTEProgramServiceDescriptor]
ON [edfi].[StudentCTEProgramAssociationCTEProgramService] ([CTEProgramServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociationCTEProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociationCTEProgramService_StudentCTEProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCTEProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographic_CitizenshipStatusDescriptor] FOREIGN KEY ([CitizenshipStatusDescriptorId])
REFERENCES [edfi].[CitizenshipStatusDescriptor] ([CitizenshipStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographic_CitizenshipStatusDescriptor]
ON [edfi].[StudentDemographic] ([CitizenshipStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographic_EconomicDisadvantageDescriptor] FOREIGN KEY ([EconomicDisadvantageDescriptorId])
REFERENCES [edfi].[EconomicDisadvantageDescriptor] ([EconomicDisadvantageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographic_EconomicDisadvantageDescriptor]
ON [edfi].[StudentDemographic] ([EconomicDisadvantageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographic_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentDemographic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographic_LimitedEnglishProficiencyDescriptor] FOREIGN KEY ([LimitedEnglishProficiencyDescriptorId])
REFERENCES [edfi].[LimitedEnglishProficiencyDescriptor] ([LimitedEnglishProficiencyDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographic_LimitedEnglishProficiencyDescriptor]
ON [edfi].[StudentDemographic] ([LimitedEnglishProficiencyDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographic_SexDescriptor] FOREIGN KEY ([SexDescriptorId])
REFERENCES [edfi].[SexDescriptor] ([SexDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographic_SexDescriptor]
ON [edfi].[StudentDemographic] ([SexDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographic_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentDemographic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographic_SupporterMilitaryConnectionDescriptor] FOREIGN KEY ([SupporterMilitaryConnectionDescriptorId])
REFERENCES [edfi].[SupporterMilitaryConnectionDescriptor] ([SupporterMilitaryConnectionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographic_SupporterMilitaryConnectionDescriptor]
ON [edfi].[StudentDemographic] ([SupporterMilitaryConnectionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicAncestryEthnicOrigin] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicAncestryEthnicOrigin_AncestryEthnicOriginDescriptor] FOREIGN KEY ([AncestryEthnicOriginDescriptorId])
REFERENCES [edfi].[AncestryEthnicOriginDescriptor] ([AncestryEthnicOriginDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicAncestryEthnicOrigin_AncestryEthnicOriginDescriptor]
ON [edfi].[StudentDemographicAncestryEthnicOrigin] ([AncestryEthnicOriginDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicAncestryEthnicOrigin] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicAncestryEthnicOrigin_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicDisability] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicDisability_DisabilityDescriptor]
ON [edfi].[StudentDemographicDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicDisability] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [edfi].[StudentDemographicDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicDisability] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicDisability_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicDisabilityDesignation_DisabilityDesignationDescriptor]
ON [edfi].[StudentDemographicDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicDisabilityDesignation_StudentDemographicDisability] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [DisabilityDescriptorId])
REFERENCES [edfi].[StudentDemographicDisability] ([EducationOrganizationId], [StudentUSI], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicIdentificationDocument_CountryDescriptor]
ON [edfi].[StudentDemographicIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[StudentDemographicIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[StudentDemographicIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicIdentificationDocument_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicLanguage] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicLanguage_LanguageDescriptor] FOREIGN KEY ([LanguageDescriptorId])
REFERENCES [edfi].[LanguageDescriptor] ([LanguageDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicLanguage_LanguageDescriptor]
ON [edfi].[StudentDemographicLanguage] ([LanguageDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicLanguage] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicLanguage_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicLanguageUse] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicLanguageUse_LanguageUseDescriptor] FOREIGN KEY ([LanguageUseDescriptorId])
REFERENCES [edfi].[LanguageUseDescriptor] ([LanguageUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicLanguageUse_LanguageUseDescriptor]
ON [edfi].[StudentDemographicLanguageUse] ([LanguageUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicLanguageUse] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicLanguageUse_StudentDemographicLanguage] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [LanguageDescriptorId])
REFERENCES [edfi].[StudentDemographicLanguage] ([EducationOrganizationId], [StudentUSI], [LanguageDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicRace] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicRace_RaceDescriptor] FOREIGN KEY ([RaceDescriptorId])
REFERENCES [edfi].[RaceDescriptor] ([RaceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicRace_RaceDescriptor]
ON [edfi].[StudentDemographicRace] ([RaceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicRace] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicRace_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicStudentCharacteristic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicStudentCharacteristic_StudentCharacteristicDescriptor] FOREIGN KEY ([StudentCharacteristicDescriptorId])
REFERENCES [edfi].[StudentCharacteristicDescriptor] ([StudentCharacteristicDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicStudentCharacteristic_StudentCharacteristicDescriptor]
ON [edfi].[StudentDemographicStudentCharacteristic] ([StudentCharacteristicDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicStudentCharacteristic] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicStudentCharacteristic_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicStudentCharacteristicPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicStudentCharacteristicPeriod_StudentDemographicStudentCharacteristic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [StudentCharacteristicDescriptorId])
REFERENCES [edfi].[StudentDemographicStudentCharacteristic] ([EducationOrganizationId], [StudentUSI], [StudentCharacteristicDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicTribalAffiliation] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicTribalAffiliation_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicTribalAffiliation] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicTribalAffiliation_TribalAffiliationDescriptor] FOREIGN KEY ([TribalAffiliationDescriptorId])
REFERENCES [edfi].[TribalAffiliationDescriptor] ([TribalAffiliationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicTribalAffiliation_TribalAffiliationDescriptor]
ON [edfi].[StudentDemographicTribalAffiliation] ([TribalAffiliationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDemographicVisa] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicVisa_StudentDemographic] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDemographic] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDemographicVisa] WITH CHECK ADD CONSTRAINT [FK_StudentDemographicVisa_VisaDescriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[VisaDescriptor] ([VisaDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDemographicVisa_VisaDescriptor]
ON [edfi].[StudentDemographicVisa] ([VisaDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDirectory] WITH CHECK ADD CONSTRAINT [FK_StudentDirectory_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentDirectory] WITH CHECK ADD CONSTRAINT [FK_StudentDirectory_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentDirectoryAddress] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDirectoryAddress_AddressTypeDescriptor]
ON [edfi].[StudentDirectoryAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDirectoryAddress] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryAddress_LocaleDescriptor] FOREIGN KEY ([LocaleDescriptorId])
REFERENCES [edfi].[LocaleDescriptor] ([LocaleDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDirectoryAddress_LocaleDescriptor]
ON [edfi].[StudentDirectoryAddress] ([LocaleDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDirectoryAddress] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryAddress_StateAbbreviationDescriptor] FOREIGN KEY ([StateAbbreviationDescriptorId])
REFERENCES [edfi].[StateAbbreviationDescriptor] ([StateAbbreviationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDirectoryAddress_StateAbbreviationDescriptor]
ON [edfi].[StudentDirectoryAddress] ([StateAbbreviationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDirectoryAddress] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryAddress_StudentDirectory] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDirectory] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDirectoryAddressPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryAddressPeriod_StudentDirectoryAddress] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[StudentDirectoryAddress] ([EducationOrganizationId], [StudentUSI], [AddressTypeDescriptorId], [City], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDirectoryElectronicMail] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryElectronicMail_ElectronicMailTypeDescriptor] FOREIGN KEY ([ElectronicMailTypeDescriptorId])
REFERENCES [edfi].[ElectronicMailTypeDescriptor] ([ElectronicMailTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDirectoryElectronicMail_ElectronicMailTypeDescriptor]
ON [edfi].[StudentDirectoryElectronicMail] ([ElectronicMailTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDirectoryElectronicMail] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryElectronicMail_StudentDirectory] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDirectory] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDirectoryInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryInternationalAddress_AddressTypeDescriptor] FOREIGN KEY ([AddressTypeDescriptorId])
REFERENCES [edfi].[AddressTypeDescriptor] ([AddressTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDirectoryInternationalAddress_AddressTypeDescriptor]
ON [edfi].[StudentDirectoryInternationalAddress] ([AddressTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDirectoryInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryInternationalAddress_CountryDescriptor] FOREIGN KEY ([CountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDirectoryInternationalAddress_CountryDescriptor]
ON [edfi].[StudentDirectoryInternationalAddress] ([CountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDirectoryInternationalAddress] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryInternationalAddress_StudentDirectory] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDirectory] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDirectoryTelephone] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryTelephone_StudentDirectory] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentDirectory] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDirectoryTelephone] WITH CHECK ADD CONSTRAINT [FK_StudentDirectoryTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDirectoryTelephone_TelephoneNumberTypeDescriptor]
ON [edfi].[StudentDirectoryTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociation_BehaviorDescriptor] FOREIGN KEY ([BehaviorDescriptorId])
REFERENCES [edfi].[BehaviorDescriptor] ([BehaviorDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDisciplineIncidentBehaviorAssociation_BehaviorDescriptor]
ON [edfi].[StudentDisciplineIncidentBehaviorAssociation] ([BehaviorDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociation_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDisciplineIncidentBehaviorAssociation_DisciplineIncident]
ON [edfi].[StudentDisciplineIncidentBehaviorAssociation] ([IncidentIdentifier] ASC, [SchoolId] ASC)
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescriptor] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[DisciplineIncidentParticipationCodeDescriptor] ([DisciplineIncidentParticipationCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescriptor]
ON [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] ([DisciplineIncidentParticipationCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociationDisciplineIncidentParticipationCode_StudentDisciplineIncidentBehaviorAssociation] FOREIGN KEY ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentDisciplineIncidentBehaviorAssociation] ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationWeapon] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociationWeapon_StudentDisciplineIncidentBehaviorAssociation] FOREIGN KEY ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentDisciplineIncidentBehaviorAssociation] ([BehaviorDescriptorId], [IncidentIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociationWeapon] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentBehaviorAssociationWeapon_WeaponDescriptor] FOREIGN KEY ([WeaponDescriptorId])
REFERENCES [edfi].[WeaponDescriptor] ([WeaponDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDisciplineIncidentBehaviorAssociationWeapon_WeaponDescriptor]
ON [edfi].[StudentDisciplineIncidentBehaviorAssociationWeapon] ([WeaponDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentNonOffenderAssociation_DisciplineIncident] FOREIGN KEY ([IncidentIdentifier], [SchoolId])
REFERENCES [edfi].[DisciplineIncident] ([IncidentIdentifier], [SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDisciplineIncidentNonOffenderAssociation_DisciplineIncident]
ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ([IncidentIdentifier] ASC, [SchoolId] ASC)
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentNonOffenderAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescrip] FOREIGN KEY ([DisciplineIncidentParticipationCodeDescriptorId])
REFERENCES [edfi].[DisciplineIncidentParticipationCodeDescriptor] ([DisciplineIncidentParticipationCodeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_DisciplineIncidentParticipationCodeDescrip]
ON [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] ([DisciplineIncidentParticipationCodeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode] WITH CHECK ADD CONSTRAINT [FK_StudentDisciplineIncidentNonOffenderAssociationDisciplineIncidentParticipationCode_StudentDisciplineIncidentNonOffenderAssoci] FOREIGN KEY ([IncidentIdentifier], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ([IncidentIdentifier], [SchoolId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssessmentAccommodation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssessmentAccommodation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation_AccommodationDescriptor] FOREIGN KEY ([AccommodationDescriptorId])
REFERENCES [edfi].[AccommodationDescriptor] ([AccommodationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation_AccommodationDescriptor]
ON [edfi].[StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation] ([AccommodationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssessmentAccommodationGeneralAccommodation_StudentEducationOrganizationAssessmentAccommodation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssessmentAccommodation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_BarrierToInternetAccessInResidenceDescriptor] FOREIGN KEY ([BarrierToInternetAccessInResidenceDescriptorId])
REFERENCES [edfi].[BarrierToInternetAccessInResidenceDescriptor] ([BarrierToInternetAccessInResidenceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociation_BarrierToInternetAccessInResidenceDescriptor]
ON [edfi].[StudentEducationOrganizationAssociation] ([BarrierToInternetAccessInResidenceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_InternetAccessTypeInResidenceDescriptor] FOREIGN KEY ([InternetAccessTypeInResidenceDescriptorId])
REFERENCES [edfi].[InternetAccessTypeInResidenceDescriptor] ([InternetAccessTypeInResidenceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociation_InternetAccessTypeInResidenceDescriptor]
ON [edfi].[StudentEducationOrganizationAssociation] ([InternetAccessTypeInResidenceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_InternetPerformanceInResidenceDescriptor] FOREIGN KEY ([InternetPerformanceInResidenceDescriptorId])
REFERENCES [edfi].[InternetPerformanceInResidenceDescriptor] ([InternetPerformanceInResidenceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociation_InternetPerformanceInResidenceDescriptor]
ON [edfi].[StudentEducationOrganizationAssociation] ([InternetPerformanceInResidenceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceAccessDescriptor] FOREIGN KEY ([PrimaryLearningDeviceAccessDescriptorId])
REFERENCES [edfi].[PrimaryLearningDeviceAccessDescriptor] ([PrimaryLearningDeviceAccessDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceAccessDescriptor]
ON [edfi].[StudentEducationOrganizationAssociation] ([PrimaryLearningDeviceAccessDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceAwayFromSchoolDescriptor] FOREIGN KEY ([PrimaryLearningDeviceAwayFromSchoolDescriptorId])
REFERENCES [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] ([PrimaryLearningDeviceAwayFromSchoolDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceAwayFromSchoolDescriptor]
ON [edfi].[StudentEducationOrganizationAssociation] ([PrimaryLearningDeviceAwayFromSchoolDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceProviderDescriptor] FOREIGN KEY ([PrimaryLearningDeviceProviderDescriptorId])
REFERENCES [edfi].[PrimaryLearningDeviceProviderDescriptor] ([PrimaryLearningDeviceProviderDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociation_PrimaryLearningDeviceProviderDescriptor]
ON [edfi].[StudentEducationOrganizationAssociation] ([PrimaryLearningDeviceProviderDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationCohortYear_CohortYearTypeDescriptor] FOREIGN KEY ([CohortYearTypeDescriptorId])
REFERENCES [edfi].[CohortYearTypeDescriptor] ([CohortYearTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationCohortYear_CohortYearTypeDescriptor]
ON [edfi].[StudentEducationOrganizationAssociationCohortYear] ([CohortYearTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationCohortYear_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationCohortYear_SchoolYearType]
ON [edfi].[StudentEducationOrganizationAssociationCohortYear] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationCohortYear_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationCohortYear] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationCohortYear_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationCohortYear_TermDescriptor]
ON [edfi].[StudentEducationOrganizationAssociationCohortYear] ([TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisplacedStudent] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationDisplacedStudent_CrisisEvent] FOREIGN KEY ([CrisisEventName])
REFERENCES [edfi].[CrisisEvent] ([CrisisEventName])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationDisplacedStudent_CrisisEvent]
ON [edfi].[StudentEducationOrganizationAssociationDisplacedStudent] ([CrisisEventName] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisplacedStudent] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationDisplacedStudent_DisplacedStudentStatusDescriptor] FOREIGN KEY ([DisplacedStudentStatusDescriptorId])
REFERENCES [edfi].[DisplacedStudentStatusDescriptor] ([DisplacedStudentStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationDisplacedStudent_DisplacedStudentStatusDescriptor]
ON [edfi].[StudentEducationOrganizationAssociationDisplacedStudent] ([DisplacedStudentStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationDisplacedStudent] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationDisplacedStudent_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicator] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentIndicator_StudentEducationOrganizationAssociation] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociation] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentIndicatorPeriod_StudentEducationOrganizationAssociationStudentIndicator] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [IndicatorName])
REFERENCES [edfi].[StudentEducationOrganizationAssociationStudentIndicator] ([EducationOrganizationId], [StudentUSI], [IndicatorName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationResponsibilityAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationResponsibilityAssociation_ResponsibilityDescriptor] FOREIGN KEY ([ResponsibilityDescriptorId])
REFERENCES [edfi].[ResponsibilityDescriptor] ([ResponsibilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationResponsibilityAssociation_ResponsibilityDescriptor]
ON [edfi].[StudentEducationOrganizationResponsibilityAssociation] ([ResponsibilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationResponsibilityAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_AssignmentLateStatusDescriptor] FOREIGN KEY ([AssignmentLateStatusDescriptorId])
REFERENCES [edfi].[AssignmentLateStatusDescriptor] ([AssignmentLateStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGradebookEntry_AssignmentLateStatusDescriptor]
ON [edfi].[StudentGradebookEntry] ([AssignmentLateStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_CompetencyLevelDescriptor] FOREIGN KEY ([CompetencyLevelDescriptorId])
REFERENCES [edfi].[CompetencyLevelDescriptor] ([CompetencyLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGradebookEntry_CompetencyLevelDescriptor]
ON [edfi].[StudentGradebookEntry] ([CompetencyLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_GradebookEntry] FOREIGN KEY ([GradebookEntryIdentifier], [Namespace])
REFERENCES [edfi].[GradebookEntry] ([GradebookEntryIdentifier], [Namespace])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentGradebookEntry_GradebookEntry]
ON [edfi].[StudentGradebookEntry] ([GradebookEntryIdentifier] ASC, [Namespace] ASC)
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentGradebookEntry] WITH CHECK ADD CONSTRAINT [FK_StudentGradebookEntry_SubmissionStatusDescriptor] FOREIGN KEY ([SubmissionStatusDescriptorId])
REFERENCES [edfi].[SubmissionStatusDescriptor] ([SubmissionStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGradebookEntry_SubmissionStatusDescriptor]
ON [edfi].[StudentGradebookEntry] ([SubmissionStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentHealth] WITH CHECK ADD CONSTRAINT [FK_StudentHealth_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentHealth] WITH CHECK ADD CONSTRAINT [FK_StudentHealth_NonMedicalImmunizationExemptionDescriptor] FOREIGN KEY ([NonMedicalImmunizationExemptionDescriptorId])
REFERENCES [edfi].[NonMedicalImmunizationExemptionDescriptor] ([NonMedicalImmunizationExemptionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentHealth_NonMedicalImmunizationExemptionDescriptor]
ON [edfi].[StudentHealth] ([NonMedicalImmunizationExemptionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentHealth] WITH CHECK ADD CONSTRAINT [FK_StudentHealth_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentHealthAdditionalImmunization] WITH CHECK ADD CONSTRAINT [FK_StudentHealthAdditionalImmunization_StudentHealth] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentHealth] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentHealthAdditionalImmunizationDate] WITH CHECK ADD CONSTRAINT [FK_StudentHealthAdditionalImmunizationDate_StudentHealthAdditionalImmunization] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [ImmunizationName])
REFERENCES [edfi].[StudentHealthAdditionalImmunization] ([EducationOrganizationId], [StudentUSI], [ImmunizationName])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentHealthRequiredImmunization] WITH CHECK ADD CONSTRAINT [FK_StudentHealthRequiredImmunization_ImmunizationTypeDescriptor] FOREIGN KEY ([ImmunizationTypeDescriptorId])
REFERENCES [edfi].[ImmunizationTypeDescriptor] ([ImmunizationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentHealthRequiredImmunization_ImmunizationTypeDescriptor]
ON [edfi].[StudentHealthRequiredImmunization] ([ImmunizationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentHealthRequiredImmunization] WITH CHECK ADD CONSTRAINT [FK_StudentHealthRequiredImmunization_StudentHealth] FOREIGN KEY ([EducationOrganizationId], [StudentUSI])
REFERENCES [edfi].[StudentHealth] ([EducationOrganizationId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentHealthRequiredImmunizationDate] WITH CHECK ADD CONSTRAINT [FK_StudentHealthRequiredImmunizationDate_StudentHealthRequiredImmunization] FOREIGN KEY ([EducationOrganizationId], [StudentUSI], [ImmunizationTypeDescriptorId])
REFERENCES [edfi].[StudentHealthRequiredImmunization] ([EducationOrganizationId], [StudentUSI], [ImmunizationTypeDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentHomelessProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentHomelessProgramAssociation_HomelessPrimaryNighttimeResidenceDescriptor] FOREIGN KEY ([HomelessPrimaryNighttimeResidenceDescriptorId])
REFERENCES [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] ([HomelessPrimaryNighttimeResidenceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentHomelessProgramAssociation_HomelessPrimaryNighttimeResidenceDescriptor]
ON [edfi].[StudentHomelessProgramAssociation] ([HomelessPrimaryNighttimeResidenceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociationHomelessProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentHomelessProgramAssociationHomelessProgramService_HomelessProgramServiceDescriptor] FOREIGN KEY ([HomelessProgramServiceDescriptorId])
REFERENCES [edfi].[HomelessProgramServiceDescriptor] ([HomelessProgramServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentHomelessProgramAssociationHomelessProgramService_HomelessProgramServiceDescriptor]
ON [edfi].[StudentHomelessProgramAssociationHomelessProgramService] ([HomelessProgramServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociationHomelessProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentHomelessProgramAssociationHomelessProgramService_StudentHomelessProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentHomelessProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationCode_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationCode_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentIdentificationCode] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationCode_StudentIdentificationSystemDescriptor] FOREIGN KEY ([StudentIdentificationSystemDescriptorId])
REFERENCES [edfi].[StudentIdentificationSystemDescriptor] ([StudentIdentificationSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentIdentificationCode_StudentIdentificationSystemDescriptor]
ON [edfi].[StudentIdentificationCode] ([StudentIdentificationSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentIdentificationSystemDescriptor] WITH CHECK ADD CONSTRAINT [FK_StudentIdentificationSystemDescriptor_Descriptor] FOREIGN KEY ([StudentIdentificationSystemDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentInterventionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociation_Cohort] FOREIGN KEY ([CohortIdentifier], [CohortEducationOrganizationId])
REFERENCES [edfi].[Cohort] ([CohortIdentifier], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAssociation_Cohort]
ON [edfi].[StudentInterventionAssociation] ([CohortIdentifier] ASC, [CohortEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociation_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAssociation_Intervention]
ON [edfi].[StudentInterventionAssociation] ([EducationOrganizationId] ASC, [InterventionIdentificationCode] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_DiagnosisDescriptor] FOREIGN KEY ([DiagnosisDescriptorId])
REFERENCES [edfi].[DiagnosisDescriptor] ([DiagnosisDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAssociationInterventionEffectiveness_DiagnosisDescriptor]
ON [edfi].[StudentInterventionAssociationInterventionEffectiveness] ([DiagnosisDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_GradeLevelDescriptor] FOREIGN KEY ([GradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAssociationInterventionEffectiveness_GradeLevelDescriptor]
ON [edfi].[StudentInterventionAssociationInterventionEffectiveness] ([GradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_InterventionEffectivenessRatingDescriptor] FOREIGN KEY ([InterventionEffectivenessRatingDescriptorId])
REFERENCES [edfi].[InterventionEffectivenessRatingDescriptor] ([InterventionEffectivenessRatingDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAssociationInterventionEffectiveness_InterventionEffectivenessRatingDescriptor]
ON [edfi].[StudentInterventionAssociationInterventionEffectiveness] ([InterventionEffectivenessRatingDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_PopulationServedDescriptor] FOREIGN KEY ([PopulationServedDescriptorId])
REFERENCES [edfi].[PopulationServedDescriptor] ([PopulationServedDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAssociationInterventionEffectiveness_PopulationServedDescriptor]
ON [edfi].[StudentInterventionAssociationInterventionEffectiveness] ([PopulationServedDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAssociationInterventionEffectiveness_StudentInterventionAssociation] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode], [StudentUSI])
REFERENCES [edfi].[StudentInterventionAssociation] ([EducationOrganizationId], [InterventionIdentificationCode], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAttendanceEvent_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAttendanceEvent_AttendanceEventCategoryDescriptor]
ON [edfi].[StudentInterventionAttendanceEvent] ([AttendanceEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAttendanceEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAttendanceEvent_EducationalEnvironmentDescriptor]
ON [edfi].[StudentInterventionAttendanceEvent] ([EducationalEnvironmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAttendanceEvent_Intervention] FOREIGN KEY ([EducationOrganizationId], [InterventionIdentificationCode])
REFERENCES [edfi].[Intervention] ([EducationOrganizationId], [InterventionIdentificationCode])
GO

CREATE NONCLUSTERED INDEX [FK_StudentInterventionAttendanceEvent_Intervention]
ON [edfi].[StudentInterventionAttendanceEvent] ([EducationOrganizationId] ASC, [InterventionIdentificationCode] ASC)
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentInterventionAttendanceEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_MonitoredDescriptor] FOREIGN KEY ([MonitoredDescriptorId])
REFERENCES [edfi].[MonitoredDescriptor] ([MonitoredDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_MonitoredDescriptor]
ON [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] ([MonitoredDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ParticipationDescriptor] FOREIGN KEY ([ParticipationDescriptorId])
REFERENCES [edfi].[ParticipationDescriptor] ([ParticipationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ParticipationDescriptor]
ON [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] ([ParticipationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ProficiencyDescriptor] FOREIGN KEY ([ProficiencyDescriptorId])
REFERENCES [edfi].[ProficiencyDescriptor] ([ProficiencyDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ProficiencyDescriptor]
ON [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] ([ProficiencyDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ProgressDescriptor] FOREIGN KEY ([ProgressDescriptorId])
REFERENCES [edfi].[ProgressDescriptor] ([ProgressDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_ProgressDescriptor]
ON [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] ([ProgressDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_SchoolYearType]
ON [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationEnglishLanguageProficiencyAssessment_StudentLanguageInstructionProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentLanguageInstructionProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_LanguageInstructionProgramServiceDescriptor] FOREIGN KEY ([LanguageInstructionProgramServiceDescriptorId])
REFERENCES [edfi].[LanguageInstructionProgramServiceDescriptor] ([LanguageInstructionProgramServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_LanguageInstructionProgramServiceDescriptor]
ON [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] ([LanguageInstructionProgramServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentLanguageInstructionProgramAssociationLanguageInstructionProgramService_StudentLanguageInstructionProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentLanguageInstructionProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentMigrantEducationProgramAssociation_ContinuationOfServicesReasonDescriptor] FOREIGN KEY ([ContinuationOfServicesReasonDescriptorId])
REFERENCES [edfi].[ContinuationOfServicesReasonDescriptor] ([ContinuationOfServicesReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentMigrantEducationProgramAssociation_ContinuationOfServicesReasonDescriptor]
ON [edfi].[StudentMigrantEducationProgramAssociation] ([ContinuationOfServicesReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentMigrantEducationProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentMigrantEducationProgramAssociationMigrantEducationProgramService_MigrantEducationProgramServiceDescriptor] FOREIGN KEY ([MigrantEducationProgramServiceDescriptorId])
REFERENCES [edfi].[MigrantEducationProgramServiceDescriptor] ([MigrantEducationProgramServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentMigrantEducationProgramAssociationMigrantEducationProgramService_MigrantEducationProgramServiceDescriptor]
ON [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] ([MigrantEducationProgramServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociationMigrantEducationProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentMigrantEducationProgramAssociationMigrantEducationProgramService_StudentMigrantEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentMigrantEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociation_NeglectedOrDelinquentProgramDescriptor] FOREIGN KEY ([NeglectedOrDelinquentProgramDescriptorId])
REFERENCES [edfi].[NeglectedOrDelinquentProgramDescriptor] ([NeglectedOrDelinquentProgramDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentNeglectedOrDelinquentProgramAssociation_NeglectedOrDelinquentProgramDescriptor]
ON [edfi].[StudentNeglectedOrDelinquentProgramAssociation] ([NeglectedOrDelinquentProgramDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociation_ProgressLevelDescriptor] FOREIGN KEY ([ELAProgressLevelDescriptorId])
REFERENCES [edfi].[ProgressLevelDescriptor] ([ProgressLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentNeglectedOrDelinquentProgramAssociation_ProgressLevelDescriptor]
ON [edfi].[StudentNeglectedOrDelinquentProgramAssociation] ([ELAProgressLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociation_ProgressLevelDescriptor1] FOREIGN KEY ([MathematicsProgressLevelDescriptorId])
REFERENCES [edfi].[ProgressLevelDescriptor] ([ProgressLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentNeglectedOrDelinquentProgramAssociation_ProgressLevelDescriptor1]
ON [edfi].[StudentNeglectedOrDelinquentProgramAssociation] ([MathematicsProgressLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_NeglectedOrDelinquentProgramServiceDescript] FOREIGN KEY ([NeglectedOrDelinquentProgramServiceDescriptorId])
REFERENCES [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] ([NeglectedOrDelinquentProgramServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_NeglectedOrDelinquentProgramServiceDescript]
ON [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] ([NeglectedOrDelinquentProgramServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentNeglectedOrDelinquentProgramAssociationNeglectedOrDelinquentProgramService_StudentNeglectedOrDelinquentProgramAssociat] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentNeglectedOrDelinquentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentOtherName] WITH CHECK ADD CONSTRAINT [FK_StudentOtherName_OtherNameTypeDescriptor] FOREIGN KEY ([OtherNameTypeDescriptorId])
REFERENCES [edfi].[OtherNameTypeDescriptor] ([OtherNameTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentOtherName_OtherNameTypeDescriptor]
ON [edfi].[StudentOtherName] ([OtherNameTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentOtherName] WITH CHECK ADD CONSTRAINT [FK_StudentOtherName_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentPath] WITH CHECK ADD CONSTRAINT [FK_StudentPath_Path] FOREIGN KEY ([EducationOrganizationId], [PathName])
REFERENCES [edfi].[Path] ([EducationOrganizationId], [PathName])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPath_Path]
ON [edfi].[StudentPath] ([EducationOrganizationId] ASC, [PathName] ASC)
GO

ALTER TABLE [edfi].[StudentPath] WITH CHECK ADD CONSTRAINT [FK_StudentPath_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentPathMilestoneStatus] WITH CHECK ADD CONSTRAINT [FK_StudentPathMilestoneStatus_PathMilestone] FOREIGN KEY ([PathMilestoneName], [PathMilestoneTypeDescriptorId])
REFERENCES [edfi].[PathMilestone] ([PathMilestoneName], [PathMilestoneTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPathMilestoneStatus_PathMilestone]
ON [edfi].[StudentPathMilestoneStatus] ([PathMilestoneName] ASC, [PathMilestoneTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentPathMilestoneStatus] WITH CHECK ADD CONSTRAINT [FK_StudentPathMilestoneStatus_PathPhase] FOREIGN KEY ([EducationOrganizationId], [PathName], [PathPhaseName])
REFERENCES [edfi].[PathPhase] ([EducationOrganizationId], [PathName], [PathPhaseName])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPathMilestoneStatus_PathPhase]
ON [edfi].[StudentPathMilestoneStatus] ([EducationOrganizationId] ASC, [PathName] ASC, [PathPhaseName] ASC)
GO

ALTER TABLE [edfi].[StudentPathMilestoneStatus] WITH CHECK ADD CONSTRAINT [FK_StudentPathMilestoneStatus_StudentPath] FOREIGN KEY ([EducationOrganizationId], [PathName], [StudentUSI])
REFERENCES [edfi].[StudentPath] ([EducationOrganizationId], [PathName], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPathMilestoneStatus_StudentPath]
ON [edfi].[StudentPathMilestoneStatus] ([EducationOrganizationId] ASC, [PathName] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentPathMilestoneStatusEvent] WITH CHECK ADD CONSTRAINT [FK_StudentPathMilestoneStatusEvent_PathMilestoneStatusDescriptor] FOREIGN KEY ([PathMilestoneStatusDescriptorId])
REFERENCES [edfi].[PathMilestoneStatusDescriptor] ([PathMilestoneStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPathMilestoneStatusEvent_PathMilestoneStatusDescriptor]
ON [edfi].[StudentPathMilestoneStatusEvent] ([PathMilestoneStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentPathMilestoneStatusEvent] WITH CHECK ADD CONSTRAINT [FK_StudentPathMilestoneStatusEvent_StudentPathMilestoneStatus] FOREIGN KEY ([EducationOrganizationId], [PathMilestoneName], [PathMilestoneTypeDescriptorId], [PathName], [StudentUSI])
REFERENCES [edfi].[StudentPathMilestoneStatus] ([EducationOrganizationId], [PathMilestoneName], [PathMilestoneTypeDescriptorId], [PathName], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentPathPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentPathPeriod_StudentPath] FOREIGN KEY ([EducationOrganizationId], [PathName], [StudentUSI])
REFERENCES [edfi].[StudentPath] ([EducationOrganizationId], [PathName], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentPathPhaseStatus] WITH CHECK ADD CONSTRAINT [FK_StudentPathPhaseStatus_PathPhase] FOREIGN KEY ([EducationOrganizationId], [PathName], [PathPhaseName])
REFERENCES [edfi].[PathPhase] ([EducationOrganizationId], [PathName], [PathPhaseName])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPathPhaseStatus_PathPhase]
ON [edfi].[StudentPathPhaseStatus] ([EducationOrganizationId] ASC, [PathName] ASC, [PathPhaseName] ASC)
GO

ALTER TABLE [edfi].[StudentPathPhaseStatus] WITH CHECK ADD CONSTRAINT [FK_StudentPathPhaseStatus_StudentPath] FOREIGN KEY ([EducationOrganizationId], [PathName], [StudentUSI])
REFERENCES [edfi].[StudentPath] ([EducationOrganizationId], [PathName], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPathPhaseStatus_StudentPath]
ON [edfi].[StudentPathPhaseStatus] ([EducationOrganizationId] ASC, [PathName] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentPathPhaseStatusEvent] WITH CHECK ADD CONSTRAINT [FK_StudentPathPhaseStatusEvent_PathPhaseStatusDescriptor] FOREIGN KEY ([PathPhaseStatusDescriptorId])
REFERENCES [edfi].[PathPhaseStatusDescriptor] ([PathPhaseStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPathPhaseStatusEvent_PathPhaseStatusDescriptor]
ON [edfi].[StudentPathPhaseStatusEvent] ([PathPhaseStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentPathPhaseStatusEvent] WITH CHECK ADD CONSTRAINT [FK_StudentPathPhaseStatusEvent_StudentPathPhaseStatus] FOREIGN KEY ([EducationOrganizationId], [PathName], [PathPhaseName], [StudentUSI])
REFERENCES [edfi].[StudentPathPhaseStatus] ([EducationOrganizationId], [PathName], [PathPhaseName], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentPathPhaseStatusPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentPathPhaseStatusPeriod_StudentPathPhaseStatus] FOREIGN KEY ([EducationOrganizationId], [PathName], [PathPhaseName], [StudentUSI])
REFERENCES [edfi].[StudentPathPhaseStatus] ([EducationOrganizationId], [PathName], [PathPhaseName], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentPersonalIdentificationDocument_CountryDescriptor] FOREIGN KEY ([IssuerCountryDescriptorId])
REFERENCES [edfi].[CountryDescriptor] ([CountryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPersonalIdentificationDocument_CountryDescriptor]
ON [edfi].[StudentPersonalIdentificationDocument] ([IssuerCountryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentPersonalIdentificationDocument_IdentificationDocumentUseDescriptor] FOREIGN KEY ([IdentificationDocumentUseDescriptorId])
REFERENCES [edfi].[IdentificationDocumentUseDescriptor] ([IdentificationDocumentUseDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPersonalIdentificationDocument_IdentificationDocumentUseDescriptor]
ON [edfi].[StudentPersonalIdentificationDocument] ([IdentificationDocumentUseDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentPersonalIdentificationDocument_PersonalInformationVerificationDescriptor] FOREIGN KEY ([PersonalInformationVerificationDescriptorId])
REFERENCES [edfi].[PersonalInformationVerificationDescriptor] ([PersonalInformationVerificationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentPersonalIdentificationDocument_PersonalInformationVerificationDescriptor]
ON [edfi].[StudentPersonalIdentificationDocument] ([PersonalInformationVerificationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentPersonalIdentificationDocument] WITH CHECK ADD CONSTRAINT [FK_StudentPersonalIdentificationDocument_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramAssociationService] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAssociationService_ServiceDescriptor] FOREIGN KEY ([ServiceDescriptorId])
REFERENCES [edfi].[ServiceDescriptor] ([ServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramAssociationService_ServiceDescriptor]
ON [edfi].[StudentProgramAssociationService] ([ServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramAssociationService] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAssociationService_StudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramAttendanceEvent_AttendanceEventCategoryDescriptor]
ON [edfi].[StudentProgramAttendanceEvent] ([AttendanceEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramAttendanceEvent_EducationalEnvironmentDescriptor]
ON [edfi].[StudentProgramAttendanceEvent] ([EducationalEnvironmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramAttendanceEvent_Program]
ON [edfi].[StudentProgramAttendanceEvent] ([ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentProgramAttendanceEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_ProgramEvaluation] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluation] ([ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramEvaluation_ProgramEvaluation]
ON [edfi].[StudentProgramEvaluation] ([ProgramEducationOrganizationId] ASC, [ProgramEvaluationPeriodDescriptorId] ASC, [ProgramEvaluationTitle] ASC, [ProgramEvaluationTypeDescriptorId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_RatingLevelDescriptor] FOREIGN KEY ([SummaryEvaluationRatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramEvaluation_RatingLevelDescriptor]
ON [edfi].[StudentProgramEvaluation] ([SummaryEvaluationRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_Staff] FOREIGN KEY ([StaffEvaluatorStaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramEvaluation_Staff]
ON [edfi].[StudentProgramEvaluation] ([StaffEvaluatorStaffUSI] ASC)
GO

ALTER TABLE [edfi].[StudentProgramEvaluation] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramEvaluation_Student]
ON [edfi].[StudentProgramEvaluation] ([StudentUSI] ASC)
GO

ALTER TABLE [edfi].[StudentProgramEvaluationExternalEvaluator] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationExternalEvaluator_StudentProgramEvaluation] FOREIGN KEY ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramEvaluation] ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationElement_ProgramEvaluationElement] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationElement] ([ProgramEducationOrganizationId], [ProgramEvaluationElementTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramEvaluationStudentEvaluationElement_ProgramEvaluationElement]
ON [edfi].[StudentProgramEvaluationStudentEvaluationElement] ([ProgramEducationOrganizationId] ASC, [ProgramEvaluationElementTitle] ASC, [ProgramEvaluationPeriodDescriptorId] ASC, [ProgramEvaluationTitle] ASC, [ProgramEvaluationTypeDescriptorId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationElement_RatingLevelDescriptor] FOREIGN KEY ([EvaluationElementRatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramEvaluationStudentEvaluationElement_RatingLevelDescriptor]
ON [edfi].[StudentProgramEvaluationStudentEvaluationElement] ([EvaluationElementRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationElement] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationElement_StudentProgramEvaluation] FOREIGN KEY ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramEvaluation] ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationObjective_ProgramEvaluationObjective] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[ProgramEvaluationObjective] ([ProgramEducationOrganizationId], [ProgramEvaluationObjectiveTitle], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramEvaluationStudentEvaluationObjective_ProgramEvaluationObjective]
ON [edfi].[StudentProgramEvaluationStudentEvaluationObjective] ([ProgramEducationOrganizationId] ASC, [ProgramEvaluationObjectiveTitle] ASC, [ProgramEvaluationPeriodDescriptorId] ASC, [ProgramEvaluationTitle] ASC, [ProgramEvaluationTypeDescriptorId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationObjective_RatingLevelDescriptor] FOREIGN KEY ([EvaluationObjectiveRatingLevelDescriptorId])
REFERENCES [edfi].[RatingLevelDescriptor] ([RatingLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentProgramEvaluationStudentEvaluationObjective_RatingLevelDescriptor]
ON [edfi].[StudentProgramEvaluationStudentEvaluationObjective] ([EvaluationObjectiveRatingLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentProgramEvaluationStudentEvaluationObjective] WITH CHECK ADD CONSTRAINT [FK_StudentProgramEvaluationStudentEvaluationObjective_StudentProgramEvaluation] FOREIGN KEY ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramEvaluation] ([EvaluationDate], [ProgramEducationOrganizationId], [ProgramEvaluationPeriodDescriptorId], [ProgramEvaluationTitle], [ProgramEvaluationTypeDescriptorId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_Calendar] FOREIGN KEY ([CalendarCode], [SchoolId], [SchoolYear])
REFERENCES [edfi].[Calendar] ([CalendarCode], [SchoolId], [SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_Calendar]
ON [edfi].[StudentSchoolAssociation] ([CalendarCode] ASC, [SchoolId] ASC, [SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_EnrollmentTypeDescriptor] FOREIGN KEY ([EnrollmentTypeDescriptorId])
REFERENCES [edfi].[EnrollmentTypeDescriptor] ([EnrollmentTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_EnrollmentTypeDescriptor]
ON [edfi].[StudentSchoolAssociation] ([EnrollmentTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_EntryGradeLevelReasonDescriptor] FOREIGN KEY ([EntryGradeLevelReasonDescriptorId])
REFERENCES [edfi].[EntryGradeLevelReasonDescriptor] ([EntryGradeLevelReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_EntryGradeLevelReasonDescriptor]
ON [edfi].[StudentSchoolAssociation] ([EntryGradeLevelReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_EntryTypeDescriptor] FOREIGN KEY ([EntryTypeDescriptorId])
REFERENCES [edfi].[EntryTypeDescriptor] ([EntryTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_EntryTypeDescriptor]
ON [edfi].[StudentSchoolAssociation] ([EntryTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_ExitWithdrawTypeDescriptor] FOREIGN KEY ([ExitWithdrawTypeDescriptorId])
REFERENCES [edfi].[ExitWithdrawTypeDescriptor] ([ExitWithdrawTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_ExitWithdrawTypeDescriptor]
ON [edfi].[StudentSchoolAssociation] ([ExitWithdrawTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_GradeLevelDescriptor] FOREIGN KEY ([EntryGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_GradeLevelDescriptor]
ON [edfi].[StudentSchoolAssociation] ([EntryGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_GradeLevelDescriptor1] FOREIGN KEY ([NextYearGradeLevelDescriptorId])
REFERENCES [edfi].[GradeLevelDescriptor] ([GradeLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_GradeLevelDescriptor1]
ON [edfi].[StudentSchoolAssociation] ([NextYearGradeLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_GraduationPlan]
ON [edfi].[StudentSchoolAssociation] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_ResidencyStatusDescriptor] FOREIGN KEY ([ResidencyStatusDescriptorId])
REFERENCES [edfi].[ResidencyStatusDescriptor] ([ResidencyStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_ResidencyStatusDescriptor]
ON [edfi].[StudentSchoolAssociation] ([ResidencyStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_School1] FOREIGN KEY ([NextYearSchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_School1]
ON [edfi].[StudentSchoolAssociation] ([NextYearSchoolId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_SchoolChoiceBasisDescriptor] FOREIGN KEY ([SchoolChoiceBasisDescriptorId])
REFERENCES [edfi].[SchoolChoiceBasisDescriptor] ([SchoolChoiceBasisDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_SchoolChoiceBasisDescriptor]
ON [edfi].[StudentSchoolAssociation] ([SchoolChoiceBasisDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_SchoolYearType]
ON [edfi].[StudentSchoolAssociation] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_SchoolYearType1] FOREIGN KEY ([ClassOfSchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_SchoolYearType1]
ON [edfi].[StudentSchoolAssociation] ([ClassOfSchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationAlternativeGraduationPlan_GraduationPlan] FOREIGN KEY ([AlternativeEducationOrganizationId], [AlternativeGraduationPlanTypeDescriptorId], [AlternativeGraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociationAlternativeGraduationPlan_GraduationPlan]
ON [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] ([AlternativeEducationOrganizationId] ASC, [AlternativeGraduationPlanTypeDescriptorId] ASC, [AlternativeGraduationSchoolYear] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationAlternativeGraduationPlan_StudentSchoolAssociation] FOREIGN KEY ([EntryDate], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentSchoolAssociation] ([EntryDate], [SchoolId], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolAssociationEducationPlan] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationEducationPlan_EducationPlanDescriptor] FOREIGN KEY ([EducationPlanDescriptorId])
REFERENCES [edfi].[EducationPlanDescriptor] ([EducationPlanDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociationEducationPlan_EducationPlanDescriptor]
ON [edfi].[StudentSchoolAssociationEducationPlan] ([EducationPlanDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAssociationEducationPlan] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationEducationPlan_StudentSchoolAssociation] FOREIGN KEY ([EntryDate], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentSchoolAssociation] ([EntryDate], [SchoolId], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAttendanceEvent_AttendanceEventCategoryDescriptor]
ON [edfi].[StudentSchoolAttendanceEvent] ([AttendanceEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAttendanceEvent_EducationalEnvironmentDescriptor]
ON [edfi].[StudentSchoolAttendanceEvent] ([EducationalEnvironmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAttendanceEvent_Session]
ON [edfi].[StudentSchoolAttendanceEvent] ([SchoolId] ASC, [SchoolYear] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolFoodServiceProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService_SchoolFoodServiceProgramServiceDescriptor] FOREIGN KEY ([SchoolFoodServiceProgramServiceDescriptorId])
REFERENCES [edfi].[SchoolFoodServiceProgramServiceDescriptor] ([SchoolFoodServiceProgramServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService_SchoolFoodServiceProgramServiceDescriptor]
ON [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] ([SchoolFoodServiceProgramServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService_StudentSchoolFoodServiceProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentSchoolFoodServiceProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSection504ProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSection504ProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSection504ProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSection504ProgramAssociation_Section504DisabilityDescriptor] FOREIGN KEY ([Section504DisabilityDescriptorId])
REFERENCES [edfi].[Section504DisabilityDescriptor] ([Section504DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSection504ProgramAssociation_Section504DisabilityDescriptor]
ON [edfi].[StudentSection504ProgramAssociation] ([Section504DisabilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_AttemptStatusDescriptor] FOREIGN KEY ([AttemptStatusDescriptorId])
REFERENCES [edfi].[AttemptStatusDescriptor] ([AttemptStatusDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociation_AttemptStatusDescriptor]
ON [edfi].[StudentSectionAssociation] ([AttemptStatusDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_DualCreditInstitutionDescriptor] FOREIGN KEY ([DualCreditInstitutionDescriptorId])
REFERENCES [edfi].[DualCreditInstitutionDescriptor] ([DualCreditInstitutionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociation_DualCreditInstitutionDescriptor]
ON [edfi].[StudentSectionAssociation] ([DualCreditInstitutionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_DualCreditTypeDescriptor] FOREIGN KEY ([DualCreditTypeDescriptorId])
REFERENCES [edfi].[DualCreditTypeDescriptor] ([DualCreditTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociation_DualCreditTypeDescriptor]
ON [edfi].[StudentSectionAssociation] ([DualCreditTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_EducationOrganization] FOREIGN KEY ([DualCreditEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociation_EducationOrganization]
ON [edfi].[StudentSectionAssociation] ([DualCreditEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_RepeatIdentifierDescriptor] FOREIGN KEY ([RepeatIdentifierDescriptorId])
REFERENCES [edfi].[RepeatIdentifierDescriptor] ([RepeatIdentifierDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociation_RepeatIdentifierDescriptor]
ON [edfi].[StudentSectionAssociation] ([RepeatIdentifierDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociation_Section]
ON [edfi].[StudentSectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentSectionAssociationProgram] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociationProgram_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociationProgram_Program]
ON [edfi].[StudentSectionAssociationProgram] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAssociationProgram] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociationProgram_StudentSectionAssociation] FOREIGN KEY ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentSectionAssociation] ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEvent_AttendanceEventCategoryDescriptor] FOREIGN KEY ([AttendanceEventCategoryDescriptorId])
REFERENCES [edfi].[AttendanceEventCategoryDescriptor] ([AttendanceEventCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAttendanceEvent_AttendanceEventCategoryDescriptor]
ON [edfi].[StudentSectionAttendanceEvent] ([AttendanceEventCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEvent_EducationalEnvironmentDescriptor] FOREIGN KEY ([EducationalEnvironmentDescriptorId])
REFERENCES [edfi].[EducationalEnvironmentDescriptor] ([EducationalEnvironmentDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAttendanceEvent_EducationalEnvironmentDescriptor]
ON [edfi].[StudentSectionAttendanceEvent] ([EducationalEnvironmentDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEvent_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAttendanceEvent_Section]
ON [edfi].[StudentSectionAttendanceEvent] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEvent_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEventClassPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEventClassPeriod_ClassPeriod] FOREIGN KEY ([ClassPeriodName], [SchoolId])
REFERENCES [edfi].[ClassPeriod] ([ClassPeriodName], [SchoolId])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAttendanceEventClassPeriod_ClassPeriod]
ON [edfi].[StudentSectionAttendanceEventClassPeriod] ([ClassPeriodName] ASC, [SchoolId] ASC)
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEventClassPeriod] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAttendanceEventClassPeriod_StudentSectionAttendanceEvent] FOREIGN KEY ([AttendanceEventCategoryDescriptorId], [EventDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentSectionAttendanceEvent] ([AttendanceEventCategoryDescriptorId], [EventDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociation_SpecialEducationExitReasonDescriptor] FOREIGN KEY ([SpecialEducationExitReasonDescriptorId])
REFERENCES [edfi].[SpecialEducationExitReasonDescriptor] ([SpecialEducationExitReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramAssociation_SpecialEducationExitReasonDescriptor]
ON [edfi].[StudentSpecialEducationProgramAssociation] ([SpecialEducationExitReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociation_SpecialEducationSettingDescriptor] FOREIGN KEY ([SpecialEducationSettingDescriptorId])
REFERENCES [edfi].[SpecialEducationSettingDescriptor] ([SpecialEducationSettingDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramAssociation_SpecialEducationSettingDescriptor]
ON [edfi].[StudentSpecialEducationProgramAssociation] ([SpecialEducationSettingDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisability_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramAssociationDisability_DisabilityDescriptor]
ON [edfi].[StudentSpecialEducationProgramAssociationDisability] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisability_DisabilityDeterminationSourceTypeDescriptor] FOREIGN KEY ([DisabilityDeterminationSourceTypeDescriptorId])
REFERENCES [edfi].[DisabilityDeterminationSourceTypeDescriptor] ([DisabilityDeterminationSourceTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramAssociationDisability_DisabilityDeterminationSourceTypeDescriptor]
ON [edfi].[StudentSpecialEducationProgramAssociationDisability] ([DisabilityDeterminationSourceTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisability] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisability_StudentSpecialEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisabilityDesignation_DisabilityDesignationDescriptor] FOREIGN KEY ([DisabilityDesignationDescriptorId])
REFERENCES [edfi].[DisabilityDesignationDescriptor] ([DisabilityDesignationDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramAssociationDisabilityDesignation_DisabilityDesignationDescriptor]
ON [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] ([DisabilityDesignationDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationDisabilityDesignation_StudentSpecialEducationProgramAssociationDisability] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI], [DisabilityDescriptorId])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociationDisability] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI], [DisabilityDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationServiceProvider_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramAssociationServiceProvider_Staff]
ON [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] ([StaffUSI] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationServiceProvider_StudentSpecialEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramService_SpecialEducationProgramServiceDescriptor] FOREIGN KEY ([SpecialEducationProgramServiceDescriptorId])
REFERENCES [edfi].[SpecialEducationProgramServiceDescriptor] ([SpecialEducationProgramServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramService_SpecialEducationProgramServiceDescriptor]
ON [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] ([SpecialEducationProgramServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramService_StudentSpecialEducationProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_Staff]
ON [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] ([StaffUSI] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramAssociationSpecialEducationProgramServiceProvider_StudentSpecialEducationProgramAssociationSpec] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI], [SpecialEducationProgramServiceDescriptorId])
REFERENCES [edfi].[StudentSpecialEducationProgramAssociationSpecialEducationProgramService] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI], [SpecialEducationProgramServiceDescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_EligibilityDelayReasonDescriptor] FOREIGN KEY ([EligibilityDelayReasonDescriptorId])
REFERENCES [edfi].[EligibilityDelayReasonDescriptor] ([EligibilityDelayReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramEligibilityAssociation_EligibilityDelayReasonDescriptor]
ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation] ([EligibilityDelayReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_EligibilityEvaluationTypeDescriptor] FOREIGN KEY ([EligibilityEvaluationTypeDescriptorId])
REFERENCES [edfi].[EligibilityEvaluationTypeDescriptor] ([EligibilityEvaluationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramEligibilityAssociation_EligibilityEvaluationTypeDescriptor]
ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation] ([EligibilityEvaluationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_EvaluationDelayReasonDescriptor] FOREIGN KEY ([EvaluationDelayReasonDescriptorId])
REFERENCES [edfi].[EvaluationDelayReasonDescriptor] ([EvaluationDelayReasonDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramEligibilityAssociation_EvaluationDelayReasonDescriptor]
ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation] ([EvaluationDelayReasonDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_IDEAPartDescriptor] FOREIGN KEY ([IDEAPartDescriptorId])
REFERENCES [edfi].[IDEAPartDescriptor] ([IDEAPartDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramEligibilityAssociation_IDEAPartDescriptor]
ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation] ([IDEAPartDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_Program] FOREIGN KEY ([ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSpecialEducationProgramEligibilityAssociation_Program]
ON [edfi].[StudentSpecialEducationProgramEligibilityAssociation] ([ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramEligibilityAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSpecialEducationProgramEligibilityAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentTitleIPartAProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentTitleIPartAProgramAssociation_TitleIPartAParticipantDescriptor] FOREIGN KEY ([TitleIPartAParticipantDescriptorId])
REFERENCES [edfi].[TitleIPartAParticipantDescriptor] ([TitleIPartAParticipantDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTitleIPartAProgramAssociation_TitleIPartAParticipantDescriptor]
ON [edfi].[StudentTitleIPartAProgramAssociation] ([TitleIPartAParticipantDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentTitleIPartAProgramAssociationTitleIPartAProgramService_StudentTitleIPartAProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentTitleIPartAProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] WITH CHECK ADD CONSTRAINT [FK_StudentTitleIPartAProgramAssociationTitleIPartAProgramService_TitleIPartAProgramServiceDescriptor] FOREIGN KEY ([TitleIPartAProgramServiceDescriptorId])
REFERENCES [edfi].[TitleIPartAProgramServiceDescriptor] ([TitleIPartAProgramServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTitleIPartAProgramAssociationTitleIPartAProgramService_TitleIPartAProgramServiceDescriptor]
ON [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] ([TitleIPartAProgramServiceDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentTransportation] WITH CHECK ADD CONSTRAINT [FK_StudentTransportation_EducationOrganization] FOREIGN KEY ([TransportationEducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTransportation_EducationOrganization]
ON [edfi].[StudentTransportation] ([TransportationEducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[StudentTransportation] WITH CHECK ADD CONSTRAINT [FK_StudentTransportation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [edfi].[StudentTransportation] WITH CHECK ADD CONSTRAINT [FK_StudentTransportation_TransportationPublicExpenseEligibilityTypeDescriptor] FOREIGN KEY ([TransportationPublicExpenseEligibilityTypeDescriptorId])
REFERENCES [edfi].[TransportationPublicExpenseEligibilityTypeDescriptor] ([TransportationPublicExpenseEligibilityTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTransportation_TransportationPublicExpenseEligibilityTypeDescriptor]
ON [edfi].[StudentTransportation] ([TransportationPublicExpenseEligibilityTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentTransportation] WITH CHECK ADD CONSTRAINT [FK_StudentTransportation_TransportationTypeDescriptor] FOREIGN KEY ([TransportationTypeDescriptorId])
REFERENCES [edfi].[TransportationTypeDescriptor] ([TransportationTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTransportation_TransportationTypeDescriptor]
ON [edfi].[StudentTransportation] ([TransportationTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentTransportationStudentBusDetails] WITH CHECK ADD CONSTRAINT [FK_StudentTransportationStudentBusDetails_BusRouteDescriptor] FOREIGN KEY ([BusRouteDescriptorId])
REFERENCES [edfi].[BusRouteDescriptor] ([BusRouteDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTransportationStudentBusDetails_BusRouteDescriptor]
ON [edfi].[StudentTransportationStudentBusDetails] ([BusRouteDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentTransportationStudentBusDetails] WITH CHECK ADD CONSTRAINT [FK_StudentTransportationStudentBusDetails_StudentTransportation] FOREIGN KEY ([StudentUSI], [TransportationEducationOrganizationId])
REFERENCES [edfi].[StudentTransportation] ([StudentUSI], [TransportationEducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentTransportationStudentBusDetailsTravelDayofWeek] WITH CHECK ADD CONSTRAINT [FK_StudentTransportationStudentBusDetailsTravelDayofWeek_StudentTransportationStudentBusDetails] FOREIGN KEY ([StudentUSI], [TransportationEducationOrganizationId])
REFERENCES [edfi].[StudentTransportationStudentBusDetails] ([StudentUSI], [TransportationEducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentTransportationStudentBusDetailsTravelDayofWeek] WITH CHECK ADD CONSTRAINT [FK_StudentTransportationStudentBusDetailsTravelDayofWeek_TravelDayofWeekDescriptor] FOREIGN KEY ([TravelDayofWeekDescriptorId])
REFERENCES [edfi].[TravelDayofWeekDescriptor] ([TravelDayofWeekDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTransportationStudentBusDetailsTravelDayofWeek_TravelDayofWeekDescriptor]
ON [edfi].[StudentTransportationStudentBusDetailsTravelDayofWeek] ([TravelDayofWeekDescriptorId] ASC)
GO

ALTER TABLE [edfi].[StudentTransportationStudentBusDetailsTravelDirection] WITH CHECK ADD CONSTRAINT [FK_StudentTransportationStudentBusDetailsTravelDirection_StudentTransportationStudentBusDetails] FOREIGN KEY ([StudentUSI], [TransportationEducationOrganizationId])
REFERENCES [edfi].[StudentTransportationStudentBusDetails] ([StudentUSI], [TransportationEducationOrganizationId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[StudentTransportationStudentBusDetailsTravelDirection] WITH CHECK ADD CONSTRAINT [FK_StudentTransportationStudentBusDetailsTravelDirection_TravelDirectionDescriptor] FOREIGN KEY ([TravelDirectionDescriptorId])
REFERENCES [edfi].[TravelDirectionDescriptor] ([TravelDirectionDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTransportationStudentBusDetailsTravelDirection_TravelDirectionDescriptor]
ON [edfi].[StudentTransportationStudentBusDetailsTravelDirection] ([TravelDirectionDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SubmissionStatusDescriptor] WITH CHECK ADD CONSTRAINT [FK_SubmissionStatusDescriptor_Descriptor] FOREIGN KEY ([SubmissionStatusDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SupporterMilitaryConnectionDescriptor] WITH CHECK ADD CONSTRAINT [FK_SupporterMilitaryConnectionDescriptor_Descriptor] FOREIGN KEY ([SupporterMilitaryConnectionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[Survey] WITH CHECK ADD CONSTRAINT [FK_Survey_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[Survey] WITH CHECK ADD CONSTRAINT [FK_Survey_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [edfi].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_Survey_SchoolYearType]
ON [edfi].[Survey] ([SchoolYear] ASC)
GO

ALTER TABLE [edfi].[Survey] WITH CHECK ADD CONSTRAINT [FK_Survey_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName])
REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_Survey_Session]
ON [edfi].[Survey] ([SchoolId] ASC, [SchoolYear] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[Survey] WITH CHECK ADD CONSTRAINT [FK_Survey_SurveyCategoryDescriptor] FOREIGN KEY ([SurveyCategoryDescriptorId])
REFERENCES [edfi].[SurveyCategoryDescriptor] ([SurveyCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_Survey_SurveyCategoryDescriptor]
ON [edfi].[Survey] ([SurveyCategoryDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveyCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_SurveyCategoryDescriptor_Descriptor] FOREIGN KEY ([SurveyCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyCourseAssociation_Course] FOREIGN KEY ([CourseCode], [EducationOrganizationId])
REFERENCES [edfi].[Course] ([CourseCode], [EducationOrganizationId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyCourseAssociation_Course]
ON [edfi].[SurveyCourseAssociation] ([CourseCode] ASC, [EducationOrganizationId] ASC)
GO

ALTER TABLE [edfi].[SurveyCourseAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyCourseAssociation_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyCourseAssociation_Survey]
ON [edfi].[SurveyCourseAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyLevelDescriptor] WITH CHECK ADD CONSTRAINT [FK_SurveyLevelDescriptor_Descriptor] FOREIGN KEY ([SurveyLevelDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyProgramAssociation_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyProgramAssociation_Program]
ON [edfi].[SurveyProgramAssociation] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveyProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyProgramAssociation_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyProgramAssociation_Survey]
ON [edfi].[SurveyProgramAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyQuestion] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestion_QuestionFormDescriptor] FOREIGN KEY ([QuestionFormDescriptorId])
REFERENCES [edfi].[QuestionFormDescriptor] ([QuestionFormDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyQuestion_QuestionFormDescriptor]
ON [edfi].[SurveyQuestion] ([QuestionFormDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveyQuestion] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestion_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyQuestion_Survey]
ON [edfi].[SurveyQuestion] ([Namespace] ASC, [SurveyIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyQuestion] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestion_SurveySection] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySection] ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyQuestion_SurveySection]
ON [edfi].[SurveyQuestion] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveySectionTitle] ASC)
GO

ALTER TABLE [edfi].[SurveyQuestionMatrix] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionMatrix_SurveyQuestion] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier])
REFERENCES [edfi].[SurveyQuestion] ([Namespace], [QuestionCode], [SurveyIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyQuestionResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponse_SurveyQuestion] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier])
REFERENCES [edfi].[SurveyQuestion] ([Namespace], [QuestionCode], [SurveyIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyQuestionResponse_SurveyQuestion]
ON [edfi].[SurveyQuestionResponse] ([Namespace] ASC, [QuestionCode] ASC, [SurveyIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyQuestionResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponse_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyQuestionResponse_SurveyResponse]
ON [edfi].[SurveyQuestionResponse] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyQuestionResponseChoice] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponseChoice_SurveyQuestion] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier])
REFERENCES [edfi].[SurveyQuestion] ([Namespace], [QuestionCode], [SurveyIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponseSurveyQuestionMatrixElementResponse_SurveyQuestionResponse] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyQuestionResponse] ([Namespace], [QuestionCode], [SurveyIdentifier], [SurveyResponseIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyQuestionResponseValue] WITH CHECK ADD CONSTRAINT [FK_SurveyQuestionResponseValue_SurveyQuestionResponse] FOREIGN KEY ([Namespace], [QuestionCode], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyQuestionResponse] ([Namespace], [QuestionCode], [SurveyIdentifier], [SurveyResponseIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Contact] FOREIGN KEY ([ContactUSI])
REFERENCES [edfi].[Contact] ([ContactUSI])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponse_Contact]
ON [edfi].[SurveyResponse] ([ContactUSI] ASC)
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponse_Person]
ON [edfi].[SurveyResponse] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponse_Staff]
ON [edfi].[SurveyResponse] ([StaffUSI] ASC)
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponse_Student]
ON [edfi].[SurveyResponse] ([StudentUSI] ASC)
GO

ALTER TABLE [edfi].[SurveyResponse] WITH CHECK ADD CONSTRAINT [FK_SurveyResponse_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponse_Survey]
ON [edfi].[SurveyResponse] ([Namespace] ASC, [SurveyIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseEducationOrganizationTargetAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseEducationOrganizationTargetAssociation_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponseEducationOrganizationTargetAssociation_SurveyResponse]
ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyResponsePersonTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponsePersonTargetAssociation_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponsePersonTargetAssociation_Person]
ON [edfi].[SurveyResponsePersonTargetAssociation] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveyResponsePersonTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponsePersonTargetAssociation_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponsePersonTargetAssociation_SurveyResponse]
ON [edfi].[SurveyResponsePersonTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseStaffTargetAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseStaffTargetAssociation_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponseStaffTargetAssociation_SurveyResponse]
ON [edfi].[SurveyResponseStaffTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveyResponseSurveyLevel] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseSurveyLevel_SurveyLevelDescriptor] FOREIGN KEY ([SurveyLevelDescriptorId])
REFERENCES [edfi].[SurveyLevelDescriptor] ([SurveyLevelDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveyResponseSurveyLevel_SurveyLevelDescriptor]
ON [edfi].[SurveyResponseSurveyLevel] ([SurveyLevelDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveyResponseSurveyLevel] WITH CHECK ADD CONSTRAINT [FK_SurveyResponseSurveyLevel_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[SurveySection] WITH CHECK ADD CONSTRAINT [FK_SurveySection_EvaluationElement] FOREIGN KEY ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElement] ([EducationOrganizationId], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [SchoolYear], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySection_EvaluationElement]
ON [edfi].[SurveySection] ([EducationOrganizationId] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [SchoolYear] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveySection] WITH CHECK ADD CONSTRAINT [FK_SurveySection_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySection_Survey]
ON [edfi].[SurveySection] ([Namespace] ASC, [SurveyIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveySectionAggregateResponse] WITH CHECK ADD CONSTRAINT [FK_SurveySectionAggregateResponse_EvaluationElementRating] FOREIGN KEY ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
REFERENCES [edfi].[EvaluationElementRating] ([EducationOrganizationId], [EvaluationDate], [EvaluationElementTitle], [EvaluationObjectiveTitle], [EvaluationPeriodDescriptorId], [EvaluationTitle], [PerformanceEvaluationTitle], [PerformanceEvaluationTypeDescriptorId], [PersonId], [SchoolYear], [SourceSystemDescriptorId], [TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionAggregateResponse_EvaluationElementRating]
ON [edfi].[SurveySectionAggregateResponse] ([EducationOrganizationId] ASC, [EvaluationDate] ASC, [EvaluationElementTitle] ASC, [EvaluationObjectiveTitle] ASC, [EvaluationPeriodDescriptorId] ASC, [EvaluationTitle] ASC, [PerformanceEvaluationTitle] ASC, [PerformanceEvaluationTypeDescriptorId] ASC, [PersonId] ASC, [SchoolYear] ASC, [SourceSystemDescriptorId] ASC, [TermDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveySectionAggregateResponse] WITH CHECK ADD CONSTRAINT [FK_SurveySectionAggregateResponse_SurveySection] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySection] ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionAggregateResponse_SurveySection]
ON [edfi].[SurveySectionAggregateResponse] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveySectionTitle] ASC)
GO

ALTER TABLE [edfi].[SurveySectionAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionAssociation_Section] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
REFERENCES [edfi].[Section] ([LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionAssociation_Section]
ON [edfi].[SurveySectionAssociation] ([LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC)
GO

ALTER TABLE [edfi].[SurveySectionAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionAssociation_Survey] FOREIGN KEY ([Namespace], [SurveyIdentifier])
REFERENCES [edfi].[Survey] ([Namespace], [SurveyIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionAssociation_Survey]
ON [edfi].[SurveySectionAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveySectionResponse] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponse_SurveyResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
REFERENCES [edfi].[SurveyResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponse_SurveyResponse]
ON [edfi].[SurveySectionResponse] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC)
GO

ALTER TABLE [edfi].[SurveySectionResponse] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponse_SurveySection] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySection] ([Namespace], [SurveyIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponse_SurveySection]
ON [edfi].[SurveySectionResponse] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveySectionTitle] ASC)
GO

ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseEducationOrganizationTargetAssociation_EducationOrganization] FOREIGN KEY ([EducationOrganizationId])
REFERENCES [edfi].[EducationOrganization] ([EducationOrganizationId])
GO

ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseEducationOrganizationTargetAssociation_SurveySectionResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySectionResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponseEducationOrganizationTargetAssociation_SurveySectionResponse]
ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC, [SurveySectionTitle] ASC)
GO

ALTER TABLE [edfi].[SurveySectionResponsePersonTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponsePersonTargetAssociation_Person] FOREIGN KEY ([PersonId], [SourceSystemDescriptorId])
REFERENCES [edfi].[Person] ([PersonId], [SourceSystemDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponsePersonTargetAssociation_Person]
ON [edfi].[SurveySectionResponsePersonTargetAssociation] ([PersonId] ASC, [SourceSystemDescriptorId] ASC)
GO

ALTER TABLE [edfi].[SurveySectionResponsePersonTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponsePersonTargetAssociation_SurveySectionResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySectionResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponsePersonTargetAssociation_SurveySectionResponse]
ON [edfi].[SurveySectionResponsePersonTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC, [SurveySectionTitle] ASC)
GO

ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseStaffTargetAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] WITH CHECK ADD CONSTRAINT [FK_SurveySectionResponseStaffTargetAssociation_SurveySectionResponse] FOREIGN KEY ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
REFERENCES [edfi].[SurveySectionResponse] ([Namespace], [SurveyIdentifier], [SurveyResponseIdentifier], [SurveySectionTitle])
GO

CREATE NONCLUSTERED INDEX [FK_SurveySectionResponseStaffTargetAssociation_SurveySectionResponse]
ON [edfi].[SurveySectionResponseStaffTargetAssociation] ([Namespace] ASC, [SurveyIdentifier] ASC, [SurveyResponseIdentifier] ASC, [SurveySectionTitle] ASC)
GO

ALTER TABLE [edfi].[TeachingCredentialBasisDescriptor] WITH CHECK ADD CONSTRAINT [FK_TeachingCredentialBasisDescriptor_Descriptor] FOREIGN KEY ([TeachingCredentialBasisDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TeachingCredentialDescriptor] WITH CHECK ADD CONSTRAINT [FK_TeachingCredentialDescriptor_Descriptor] FOREIGN KEY ([TeachingCredentialDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TechnicalSkillsAssessmentDescriptor] WITH CHECK ADD CONSTRAINT [FK_TechnicalSkillsAssessmentDescriptor_Descriptor] FOREIGN KEY ([TechnicalSkillsAssessmentDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TelephoneNumberTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_TelephoneNumberTypeDescriptor_Descriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TermDescriptor] WITH CHECK ADD CONSTRAINT [FK_TermDescriptor_Descriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TitleIPartAParticipantDescriptor] WITH CHECK ADD CONSTRAINT [FK_TitleIPartAParticipantDescriptor_Descriptor] FOREIGN KEY ([TitleIPartAParticipantDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TitleIPartAProgramServiceDescriptor] WITH CHECK ADD CONSTRAINT [FK_TitleIPartAProgramServiceDescriptor_Descriptor] FOREIGN KEY ([TitleIPartAProgramServiceDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TitleIPartASchoolDesignationDescriptor] WITH CHECK ADD CONSTRAINT [FK_TitleIPartASchoolDesignationDescriptor_Descriptor] FOREIGN KEY ([TitleIPartASchoolDesignationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TransportationPublicExpenseEligibilityTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_TransportationPublicExpenseEligibilityTypeDescriptor_Descriptor] FOREIGN KEY ([TransportationPublicExpenseEligibilityTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TransportationTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_TransportationTypeDescriptor_Descriptor] FOREIGN KEY ([TransportationTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TravelDayofWeekDescriptor] WITH CHECK ADD CONSTRAINT [FK_TravelDayofWeekDescriptor_Descriptor] FOREIGN KEY ([TravelDayofWeekDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TravelDirectionDescriptor] WITH CHECK ADD CONSTRAINT [FK_TravelDirectionDescriptor_Descriptor] FOREIGN KEY ([TravelDirectionDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[TribalAffiliationDescriptor] WITH CHECK ADD CONSTRAINT [FK_TribalAffiliationDescriptor_Descriptor] FOREIGN KEY ([TribalAffiliationDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[VisaDescriptor] WITH CHECK ADD CONSTRAINT [FK_VisaDescriptor_Descriptor] FOREIGN KEY ([VisaDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[WeaponDescriptor] WITH CHECK ADD CONSTRAINT [FK_WeaponDescriptor_Descriptor] FOREIGN KEY ([WeaponDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [edfi].[WithdrawReasonDescriptor] WITH CHECK ADD CONSTRAINT [FK_WithdrawReasonDescriptor_Descriptor] FOREIGN KEY ([WithdrawReasonDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

