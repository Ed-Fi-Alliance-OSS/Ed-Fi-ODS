-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE tpdm.AccreditationStatusDescriptor ADD CONSTRAINT FK_69de81_Descriptor FOREIGN KEY (AccreditationStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.AidTypeDescriptor ADD CONSTRAINT FK_d6106a_Descriptor FOREIGN KEY (AidTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicantProfile ADD CONSTRAINT FK_c322dc_CitizenshipStatusDescriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.CitizenshipStatusDescriptor (CitizenshipStatusDescriptorId)
;

CREATE INDEX FK_c322dc_CitizenshipStatusDescriptor
ON tpdm.ApplicantProfile (CitizenshipStatusDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfile ADD CONSTRAINT FK_c322dc_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_c322dc_GenderDescriptor
ON tpdm.ApplicantProfile (GenderDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfile ADD CONSTRAINT FK_c322dc_LevelOfEducationDescriptor FOREIGN KEY (HighestCompletedLevelOfEducationDescriptorId)
REFERENCES edfi.LevelOfEducationDescriptor (LevelOfEducationDescriptorId)
;

CREATE INDEX FK_c322dc_LevelOfEducationDescriptor
ON tpdm.ApplicantProfile (HighestCompletedLevelOfEducationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfile ADD CONSTRAINT FK_c322dc_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_c322dc_SexDescriptor
ON tpdm.ApplicantProfile (SexDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileAddress ADD CONSTRAINT FK_7af948_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_7af948_AddressTypeDescriptor
ON tpdm.ApplicantProfileAddress (AddressTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileAddress ADD CONSTRAINT FK_7af948_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_7af948_ApplicantProfile
ON tpdm.ApplicantProfileAddress (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileAddress ADD CONSTRAINT FK_7af948_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_7af948_LocaleDescriptor
ON tpdm.ApplicantProfileAddress (LocaleDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileAddress ADD CONSTRAINT FK_7af948_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_7af948_StateAbbreviationDescriptor
ON tpdm.ApplicantProfileAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileAddressPeriod ADD CONSTRAINT FK_83971f_ApplicantProfileAddress FOREIGN KEY (AddressTypeDescriptorId, ApplicantProfileIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES tpdm.ApplicantProfileAddress (AddressTypeDescriptorId, ApplicantProfileIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

CREATE INDEX FK_83971f_ApplicantProfileAddress
ON tpdm.ApplicantProfileAddressPeriod (AddressTypeDescriptorId ASC, ApplicantProfileIdentifier ASC, City ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC);

ALTER TABLE tpdm.ApplicantProfileApplicantCharacteristic ADD CONSTRAINT FK_3e8f88_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_3e8f88_ApplicantProfile
ON tpdm.ApplicantProfileApplicantCharacteristic (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileApplicantCharacteristic ADD CONSTRAINT FK_3e8f88_StudentCharacteristicDescriptor FOREIGN KEY (StudentCharacteristicDescriptorId)
REFERENCES edfi.StudentCharacteristicDescriptor (StudentCharacteristicDescriptorId)
;

CREATE INDEX FK_3e8f88_StudentCharacteristicDescriptor
ON tpdm.ApplicantProfileApplicantCharacteristic (StudentCharacteristicDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileBackgroundCheck ADD CONSTRAINT FK_c12c91_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_c12c91_ApplicantProfile
ON tpdm.ApplicantProfileBackgroundCheck (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileBackgroundCheck ADD CONSTRAINT FK_c12c91_BackgroundCheckStatusDescriptor FOREIGN KEY (BackgroundCheckStatusDescriptorId)
REFERENCES tpdm.BackgroundCheckStatusDescriptor (BackgroundCheckStatusDescriptorId)
;

CREATE INDEX FK_c12c91_BackgroundCheckStatusDescriptor
ON tpdm.ApplicantProfileBackgroundCheck (BackgroundCheckStatusDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileBackgroundCheck ADD CONSTRAINT FK_c12c91_BackgroundCheckTypeDescriptor FOREIGN KEY (BackgroundCheckTypeDescriptorId)
REFERENCES tpdm.BackgroundCheckTypeDescriptor (BackgroundCheckTypeDescriptorId)
;

CREATE INDEX FK_c12c91_BackgroundCheckTypeDescriptor
ON tpdm.ApplicantProfileBackgroundCheck (BackgroundCheckTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileDisability ADD CONSTRAINT FK_9f1481_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_9f1481_ApplicantProfile
ON tpdm.ApplicantProfileDisability (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileDisability ADD CONSTRAINT FK_9f1481_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_9f1481_DisabilityDescriptor
ON tpdm.ApplicantProfileDisability (DisabilityDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileDisability ADD CONSTRAINT FK_9f1481_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_9f1481_DisabilityDeterminationSourceTypeDescriptor
ON tpdm.ApplicantProfileDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileDisabilityDesignation ADD CONSTRAINT FK_a57780_ApplicantProfileDisability FOREIGN KEY (ApplicantProfileIdentifier, DisabilityDescriptorId)
REFERENCES tpdm.ApplicantProfileDisability (ApplicantProfileIdentifier, DisabilityDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_a57780_ApplicantProfileDisability
ON tpdm.ApplicantProfileDisabilityDesignation (ApplicantProfileIdentifier ASC, DisabilityDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileDisabilityDesignation ADD CONSTRAINT FK_a57780_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_a57780_DisabilityDesignationDescriptor
ON tpdm.ApplicantProfileDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileEducatorPreparationProgramName ADD CONSTRAINT FK_2e2a2a_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_2e2a2a_ApplicantProfile
ON tpdm.ApplicantProfileEducatorPreparationProgramName (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileElectronicMail ADD CONSTRAINT FK_0f7454_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_0f7454_ApplicantProfile
ON tpdm.ApplicantProfileElectronicMail (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileElectronicMail ADD CONSTRAINT FK_0f7454_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

CREATE INDEX FK_0f7454_ElectronicMailTypeDescriptor
ON tpdm.ApplicantProfileElectronicMail (ElectronicMailTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileGradePointAverage ADD CONSTRAINT FK_31c3d0_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_31c3d0_ApplicantProfile
ON tpdm.ApplicantProfileGradePointAverage (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileGradePointAverage ADD CONSTRAINT FK_31c3d0_GradePointAverageTypeDescriptor FOREIGN KEY (GradePointAverageTypeDescriptorId)
REFERENCES edfi.GradePointAverageTypeDescriptor (GradePointAverageTypeDescriptorId)
;

CREATE INDEX FK_31c3d0_GradePointAverageTypeDescriptor
ON tpdm.ApplicantProfileGradePointAverage (GradePointAverageTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileHighlyQualifiedAcademicSubject ADD CONSTRAINT FK_d11f34_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_d11f34_AcademicSubjectDescriptor
ON tpdm.ApplicantProfileHighlyQualifiedAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileHighlyQualifiedAcademicSubject ADD CONSTRAINT FK_d11f34_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_d11f34_ApplicantProfile
ON tpdm.ApplicantProfileHighlyQualifiedAcademicSubject (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileIdentificationDocument ADD CONSTRAINT FK_eccd2d_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_eccd2d_ApplicantProfile
ON tpdm.ApplicantProfileIdentificationDocument (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileIdentificationDocument ADD CONSTRAINT FK_eccd2d_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_eccd2d_CountryDescriptor
ON tpdm.ApplicantProfileIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileIdentificationDocument ADD CONSTRAINT FK_eccd2d_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_eccd2d_IdentificationDocumentUseDescriptor
ON tpdm.ApplicantProfileIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileIdentificationDocument ADD CONSTRAINT FK_eccd2d_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_eccd2d_PersonalInformationVerificationDescriptor
ON tpdm.ApplicantProfileIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileInternationalAddress ADD CONSTRAINT FK_b40017_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_b40017_AddressTypeDescriptor
ON tpdm.ApplicantProfileInternationalAddress (AddressTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileInternationalAddress ADD CONSTRAINT FK_b40017_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_b40017_ApplicantProfile
ON tpdm.ApplicantProfileInternationalAddress (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileInternationalAddress ADD CONSTRAINT FK_b40017_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_b40017_CountryDescriptor
ON tpdm.ApplicantProfileInternationalAddress (CountryDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileLanguage ADD CONSTRAINT FK_49fbc6_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_49fbc6_ApplicantProfile
ON tpdm.ApplicantProfileLanguage (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileLanguage ADD CONSTRAINT FK_49fbc6_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_49fbc6_LanguageDescriptor
ON tpdm.ApplicantProfileLanguage (LanguageDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileLanguageUse ADD CONSTRAINT FK_f657b9_ApplicantProfileLanguage FOREIGN KEY (ApplicantProfileIdentifier, LanguageDescriptorId)
REFERENCES tpdm.ApplicantProfileLanguage (ApplicantProfileIdentifier, LanguageDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_f657b9_ApplicantProfileLanguage
ON tpdm.ApplicantProfileLanguageUse (ApplicantProfileIdentifier ASC, LanguageDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileLanguageUse ADD CONSTRAINT FK_f657b9_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_f657b9_LanguageUseDescriptor
ON tpdm.ApplicantProfileLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfilePersonalIdentificationDocument ADD CONSTRAINT FK_b8f850_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_b8f850_ApplicantProfile
ON tpdm.ApplicantProfilePersonalIdentificationDocument (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfilePersonalIdentificationDocument ADD CONSTRAINT FK_b8f850_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_b8f850_CountryDescriptor
ON tpdm.ApplicantProfilePersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfilePersonalIdentificationDocument ADD CONSTRAINT FK_b8f850_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_b8f850_IdentificationDocumentUseDescriptor
ON tpdm.ApplicantProfilePersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfilePersonalIdentificationDocument ADD CONSTRAINT FK_b8f850_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_b8f850_PersonalInformationVerificationDescriptor
ON tpdm.ApplicantProfilePersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileRace ADD CONSTRAINT FK_60d6ef_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_60d6ef_ApplicantProfile
ON tpdm.ApplicantProfileRace (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileRace ADD CONSTRAINT FK_60d6ef_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_60d6ef_RaceDescriptor
ON tpdm.ApplicantProfileRace (RaceDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileTelephone ADD CONSTRAINT FK_fd399f_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_fd399f_ApplicantProfile
ON tpdm.ApplicantProfileTelephone (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileTelephone ADD CONSTRAINT FK_fd399f_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_fd399f_TelephoneNumberTypeDescriptor
ON tpdm.ApplicantProfileTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProfileVisa ADD CONSTRAINT FK_3c449f_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_3c449f_ApplicantProfile
ON tpdm.ApplicantProfileVisa (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.ApplicantProfileVisa ADD CONSTRAINT FK_3c449f_VisaDescriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.VisaDescriptor (VisaDescriptorId)
;

CREATE INDEX FK_3c449f_VisaDescriptor
ON tpdm.ApplicantProfileVisa (VisaDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_e7ad52_AcademicSubjectDescriptor
ON tpdm.Application (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_AcademicSubjectDescriptor1 FOREIGN KEY (HighNeedsAcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_e7ad52_AcademicSubjectDescriptor1
ON tpdm.Application (HighNeedsAcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_ApplicantProfile FOREIGN KEY (ApplicantProfileIdentifier)
REFERENCES tpdm.ApplicantProfile (ApplicantProfileIdentifier)
;

CREATE INDEX FK_e7ad52_ApplicantProfile
ON tpdm.Application (ApplicantProfileIdentifier ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_ApplicationSourceDescriptor FOREIGN KEY (ApplicationSourceDescriptorId)
REFERENCES tpdm.ApplicationSourceDescriptor (ApplicationSourceDescriptorId)
;

CREATE INDEX FK_e7ad52_ApplicationSourceDescriptor
ON tpdm.Application (ApplicationSourceDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_ApplicationStatusDescriptor FOREIGN KEY (ApplicationStatusDescriptorId)
REFERENCES tpdm.ApplicationStatusDescriptor (ApplicationStatusDescriptorId)
;

CREATE INDEX FK_e7ad52_ApplicationStatusDescriptor
ON tpdm.Application (ApplicationStatusDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_e7ad52_EducationOrganization
ON tpdm.Application (EducationOrganizationId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_HireStatusDescriptor FOREIGN KEY (HireStatusDescriptorId)
REFERENCES tpdm.HireStatusDescriptor (HireStatusDescriptorId)
;

CREATE INDEX FK_e7ad52_HireStatusDescriptor
ON tpdm.Application (HireStatusDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_HiringSourceDescriptor FOREIGN KEY (HiringSourceDescriptorId)
REFERENCES tpdm.HiringSourceDescriptor (HiringSourceDescriptorId)
;

CREATE INDEX FK_e7ad52_HiringSourceDescriptor
ON tpdm.Application (HiringSourceDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
;

CREATE INDEX FK_e7ad52_OpenStaffPosition
ON tpdm.Application (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_WithdrawReasonDescriptor FOREIGN KEY (WithdrawReasonDescriptorId)
REFERENCES tpdm.WithdrawReasonDescriptor (WithdrawReasonDescriptorId)
;

CREATE INDEX FK_e7ad52_WithdrawReasonDescriptor
ON tpdm.Application (WithdrawReasonDescriptorId ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_Application FOREIGN KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
;

CREATE INDEX FK_143de6_Application
ON tpdm.ApplicationEvent (ApplicantProfileIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_ApplicationEventResultDescriptor FOREIGN KEY (ApplicationEventResultDescriptorId)
REFERENCES tpdm.ApplicationEventResultDescriptor (ApplicationEventResultDescriptorId)
;

CREATE INDEX FK_143de6_ApplicationEventResultDescriptor
ON tpdm.ApplicationEvent (ApplicationEventResultDescriptorId ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_ApplicationEventTypeDescriptor FOREIGN KEY (ApplicationEventTypeDescriptorId)
REFERENCES tpdm.ApplicationEventTypeDescriptor (ApplicationEventTypeDescriptorId)
;

CREATE INDEX FK_143de6_ApplicationEventTypeDescriptor
ON tpdm.ApplicationEvent (ApplicationEventTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_143de6_SchoolYearType
ON tpdm.ApplicationEvent (SchoolYear ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_143de6_TermDescriptor
ON tpdm.ApplicationEvent (TermDescriptorId ASC);

ALTER TABLE tpdm.ApplicationEventResultDescriptor ADD CONSTRAINT FK_3ade4b_Descriptor FOREIGN KEY (ApplicationEventResultDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicationEventTypeDescriptor ADD CONSTRAINT FK_07ba8e_Descriptor FOREIGN KEY (ApplicationEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicationRecruitmentEventAttendance ADD CONSTRAINT FK_ac3201_Application FOREIGN KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_ac3201_Application
ON tpdm.ApplicationRecruitmentEventAttendance (ApplicantProfileIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationRecruitmentEventAttendance ADD CONSTRAINT FK_ac3201_RecruitmentEventAttendance FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendance (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
;

CREATE INDEX FK_ac3201_RecruitmentEventAttendance
ON tpdm.ApplicationRecruitmentEventAttendance (EducationOrganizationId ASC, EventDate ASC, EventTitle ASC, RecruitmentEventAttendeeIdentifier ASC);

ALTER TABLE tpdm.ApplicationScoreResult ADD CONSTRAINT FK_876029_Application FOREIGN KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_876029_Application
ON tpdm.ApplicationScoreResult (ApplicantProfileIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationScoreResult ADD CONSTRAINT FK_876029_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_876029_AssessmentReportingMethodDescriptor
ON tpdm.ApplicationScoreResult (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE tpdm.ApplicationScoreResult ADD CONSTRAINT FK_876029_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_876029_ResultDatatypeTypeDescriptor
ON tpdm.ApplicationScoreResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicationSourceDescriptor ADD CONSTRAINT FK_bbb2ec_Descriptor FOREIGN KEY (ApplicationSourceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicationStatusDescriptor ADD CONSTRAINT FK_268ed8_Descriptor FOREIGN KEY (ApplicationStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicationTerm ADD CONSTRAINT FK_dff24c_Application FOREIGN KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_dff24c_Application
ON tpdm.ApplicationTerm (ApplicantProfileIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationTerm ADD CONSTRAINT FK_dff24c_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_dff24c_TermDescriptor
ON tpdm.ApplicationTerm (TermDescriptorId ASC);

ALTER TABLE tpdm.AssessmentExtension ADD CONSTRAINT FK_75a008_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE tpdm.AssessmentExtension ADD CONSTRAINT FK_75a008_ProgramGatewayDescriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES tpdm.ProgramGatewayDescriptor (ProgramGatewayDescriptorId)
;

CREATE INDEX FK_75a008_ProgramGatewayDescriptor
ON tpdm.AssessmentExtension (ProgramGatewayDescriptorId ASC);

ALTER TABLE tpdm.BackgroundCheckStatusDescriptor ADD CONSTRAINT FK_00ba96_Descriptor FOREIGN KEY (BackgroundCheckStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.BackgroundCheckTypeDescriptor ADD CONSTRAINT FK_ed9c02_Descriptor FOREIGN KEY (BackgroundCheckTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_Application FOREIGN KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
;

CREATE INDEX FK_b2452d_Application
ON tpdm.Candidate (ApplicantProfileIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_CitizenshipStatusDescriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.CitizenshipStatusDescriptor (CitizenshipStatusDescriptorId)
;

CREATE INDEX FK_b2452d_CitizenshipStatusDescriptor
ON tpdm.Candidate (CitizenshipStatusDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_CountryDescriptor FOREIGN KEY (BirthCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_b2452d_CountryDescriptor
ON tpdm.Candidate (BirthCountryDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_EnglishLanguageExamDescriptor FOREIGN KEY (EnglishLanguageExamDescriptorId)
REFERENCES tpdm.EnglishLanguageExamDescriptor (EnglishLanguageExamDescriptorId)
;

CREATE INDEX FK_b2452d_EnglishLanguageExamDescriptor
ON tpdm.Candidate (EnglishLanguageExamDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_b2452d_GenderDescriptor
ON tpdm.Candidate (GenderDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_LimitedEnglishProficiencyDescriptor FOREIGN KEY (LimitedEnglishProficiencyDescriptorId)
REFERENCES edfi.LimitedEnglishProficiencyDescriptor (LimitedEnglishProficiencyDescriptorId)
;

CREATE INDEX FK_b2452d_LimitedEnglishProficiencyDescriptor
ON tpdm.Candidate (LimitedEnglishProficiencyDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_OldEthnicityDescriptor FOREIGN KEY (OldEthnicityDescriptorId)
REFERENCES edfi.OldEthnicityDescriptor (OldEthnicityDescriptorId)
;

CREATE INDEX FK_b2452d_OldEthnicityDescriptor
ON tpdm.Candidate (OldEthnicityDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_b2452d_Person
ON tpdm.Candidate (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_PreviousCareerDescriptor FOREIGN KEY (PreviousCareerDescriptorId)
REFERENCES tpdm.PreviousCareerDescriptor (PreviousCareerDescriptorId)
;

CREATE INDEX FK_b2452d_PreviousCareerDescriptor
ON tpdm.Candidate (PreviousCareerDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_b2452d_SexDescriptor
ON tpdm.Candidate (SexDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_SexDescriptor1 FOREIGN KEY (BirthSexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_b2452d_SexDescriptor1
ON tpdm.Candidate (BirthSexDescriptorId ASC);

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_StateAbbreviationDescriptor FOREIGN KEY (BirthStateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_b2452d_StateAbbreviationDescriptor
ON tpdm.Candidate (BirthStateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.CandidateAddress ADD CONSTRAINT FK_160329_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_160329_AddressTypeDescriptor
ON tpdm.CandidateAddress (AddressTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateAddress ADD CONSTRAINT FK_160329_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_160329_Candidate
ON tpdm.CandidateAddress (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateAddress ADD CONSTRAINT FK_160329_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_160329_LocaleDescriptor
ON tpdm.CandidateAddress (LocaleDescriptorId ASC);

ALTER TABLE tpdm.CandidateAddress ADD CONSTRAINT FK_160329_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_160329_StateAbbreviationDescriptor
ON tpdm.CandidateAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.CandidateAddressPeriod ADD CONSTRAINT FK_17e793_CandidateAddress FOREIGN KEY (AddressTypeDescriptorId, CandidateIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES tpdm.CandidateAddress (AddressTypeDescriptorId, CandidateIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

CREATE INDEX FK_17e793_CandidateAddress
ON tpdm.CandidateAddressPeriod (AddressTypeDescriptorId ASC, CandidateIdentifier ASC, City ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC);

ALTER TABLE tpdm.CandidateAid ADD CONSTRAINT FK_a0a9d5_AidTypeDescriptor FOREIGN KEY (AidTypeDescriptorId)
REFERENCES tpdm.AidTypeDescriptor (AidTypeDescriptorId)
;

CREATE INDEX FK_a0a9d5_AidTypeDescriptor
ON tpdm.CandidateAid (AidTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateAid ADD CONSTRAINT FK_a0a9d5_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_a0a9d5_Candidate
ON tpdm.CandidateAid (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateBackgroundCheck ADD CONSTRAINT FK_b13a17_BackgroundCheckStatusDescriptor FOREIGN KEY (BackgroundCheckStatusDescriptorId)
REFERENCES tpdm.BackgroundCheckStatusDescriptor (BackgroundCheckStatusDescriptorId)
;

CREATE INDEX FK_b13a17_BackgroundCheckStatusDescriptor
ON tpdm.CandidateBackgroundCheck (BackgroundCheckStatusDescriptorId ASC);

ALTER TABLE tpdm.CandidateBackgroundCheck ADD CONSTRAINT FK_b13a17_BackgroundCheckTypeDescriptor FOREIGN KEY (BackgroundCheckTypeDescriptorId)
REFERENCES tpdm.BackgroundCheckTypeDescriptor (BackgroundCheckTypeDescriptorId)
;

CREATE INDEX FK_b13a17_BackgroundCheckTypeDescriptor
ON tpdm.CandidateBackgroundCheck (BackgroundCheckTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateBackgroundCheck ADD CONSTRAINT FK_b13a17_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateCharacteristic ADD CONSTRAINT FK_8f75c4_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_8f75c4_Candidate
ON tpdm.CandidateCharacteristic (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateCharacteristic ADD CONSTRAINT FK_8f75c4_CandidateCharacteristicDescriptor FOREIGN KEY (CandidateCharacteristicDescriptorId)
REFERENCES tpdm.CandidateCharacteristicDescriptor (CandidateCharacteristicDescriptorId)
;

CREATE INDEX FK_8f75c4_CandidateCharacteristicDescriptor
ON tpdm.CandidateCharacteristic (CandidateCharacteristicDescriptorId ASC);

ALTER TABLE tpdm.CandidateCharacteristicDescriptor ADD CONSTRAINT FK_8cef5b_Descriptor FOREIGN KEY (CandidateCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateCohortYear ADD CONSTRAINT FK_106e8f_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_106e8f_Candidate
ON tpdm.CandidateCohortYear (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateCohortYear ADD CONSTRAINT FK_106e8f_CohortYearTypeDescriptor FOREIGN KEY (CohortYearTypeDescriptorId)
REFERENCES edfi.CohortYearTypeDescriptor (CohortYearTypeDescriptorId)
;

CREATE INDEX FK_106e8f_CohortYearTypeDescriptor
ON tpdm.CandidateCohortYear (CohortYearTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateCohortYear ADD CONSTRAINT FK_106e8f_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_106e8f_SchoolYearType
ON tpdm.CandidateCohortYear (SchoolYear ASC);

ALTER TABLE tpdm.CandidateDegreeSpecialization ADD CONSTRAINT FK_e0eaf2_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_e0eaf2_Candidate
ON tpdm.CandidateDegreeSpecialization (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateDisability ADD CONSTRAINT FK_236ee4_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_236ee4_Candidate
ON tpdm.CandidateDisability (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateDisability ADD CONSTRAINT FK_236ee4_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_236ee4_DisabilityDescriptor
ON tpdm.CandidateDisability (DisabilityDescriptorId ASC);

ALTER TABLE tpdm.CandidateDisability ADD CONSTRAINT FK_236ee4_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_236ee4_DisabilityDeterminationSourceTypeDescriptor
ON tpdm.CandidateDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateDisabilityDesignation ADD CONSTRAINT FK_6edb1d_CandidateDisability FOREIGN KEY (CandidateIdentifier, DisabilityDescriptorId)
REFERENCES tpdm.CandidateDisability (CandidateIdentifier, DisabilityDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_6edb1d_CandidateDisability
ON tpdm.CandidateDisabilityDesignation (CandidateIdentifier ASC, DisabilityDescriptorId ASC);

ALTER TABLE tpdm.CandidateDisabilityDesignation ADD CONSTRAINT FK_6edb1d_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_6edb1d_DisabilityDesignationDescriptor
ON tpdm.CandidateDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ADD CONSTRAINT FK_fc61b2_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
;

CREATE INDEX FK_fc61b2_Candidate
ON tpdm.CandidateEducatorPreparationProgramAssociation (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ADD CONSTRAINT FK_fc61b2_EducatorPreparationProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.EducatorPreparationProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_fc61b2_EducatorPreparationProgram
ON tpdm.CandidateEducatorPreparationProgramAssociation (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ADD CONSTRAINT FK_fc61b2_EPPProgramPathwayDescriptor FOREIGN KEY (EPPProgramPathwayDescriptorId)
REFERENCES tpdm.EPPProgramPathwayDescriptor (EPPProgramPathwayDescriptorId)
;

CREATE INDEX FK_fc61b2_EPPProgramPathwayDescriptor
ON tpdm.CandidateEducatorPreparationProgramAssociation (EPPProgramPathwayDescriptorId ASC);

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ADD CONSTRAINT FK_fc61b2_ReasonExitedDescriptor FOREIGN KEY (ReasonExitedDescriptorId)
REFERENCES edfi.ReasonExitedDescriptor (ReasonExitedDescriptorId)
;

CREATE INDEX FK_fc61b2_ReasonExitedDescriptor
ON tpdm.CandidateEducatorPreparationProgramAssociation (ReasonExitedDescriptorId ASC);

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b ADD CONSTRAINT FK_0d7c2b_CandidateEducatorPreparationProgramAssociation FOREIGN KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.CandidateEducatorPreparationProgramAssociation (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14 ADD CONSTRAINT FK_fc4f14_CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b FOREIGN KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateElectronicMail ADD CONSTRAINT FK_c5124f_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_c5124f_Candidate
ON tpdm.CandidateElectronicMail (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateElectronicMail ADD CONSTRAINT FK_c5124f_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

CREATE INDEX FK_c5124f_ElectronicMailTypeDescriptor
ON tpdm.CandidateElectronicMail (ElectronicMailTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateEPPProgramDegree ADD CONSTRAINT FK_0a4645_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_0a4645_AcademicSubjectDescriptor
ON tpdm.CandidateEPPProgramDegree (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.CandidateEPPProgramDegree ADD CONSTRAINT FK_0a4645_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_0a4645_Candidate
ON tpdm.CandidateEPPProgramDegree (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateEPPProgramDegree ADD CONSTRAINT FK_0a4645_EPPDegreeTypeDescriptor FOREIGN KEY (EPPDegreeTypeDescriptorId)
REFERENCES tpdm.EPPDegreeTypeDescriptor (EPPDegreeTypeDescriptorId)
;

CREATE INDEX FK_0a4645_EPPDegreeTypeDescriptor
ON tpdm.CandidateEPPProgramDegree (EPPDegreeTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateEPPProgramDegree ADD CONSTRAINT FK_0a4645_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_0a4645_GradeLevelDescriptor
ON tpdm.CandidateEPPProgramDegree (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.CandidateIdentificationCode ADD CONSTRAINT FK_2881a4_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_2881a4_Candidate
ON tpdm.CandidateIdentificationCode (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateIdentificationCode ADD CONSTRAINT FK_2881a4_StudentIdentificationSystemDescriptor FOREIGN KEY (StudentIdentificationSystemDescriptorId)
REFERENCES edfi.StudentIdentificationSystemDescriptor (StudentIdentificationSystemDescriptorId)
;

CREATE INDEX FK_2881a4_StudentIdentificationSystemDescriptor
ON tpdm.CandidateIdentificationCode (StudentIdentificationSystemDescriptorId ASC);

ALTER TABLE tpdm.CandidateIdentificationDocument ADD CONSTRAINT FK_99d8ee_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_99d8ee_Candidate
ON tpdm.CandidateIdentificationDocument (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateIdentificationDocument ADD CONSTRAINT FK_99d8ee_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_99d8ee_CountryDescriptor
ON tpdm.CandidateIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.CandidateIdentificationDocument ADD CONSTRAINT FK_99d8ee_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_99d8ee_IdentificationDocumentUseDescriptor
ON tpdm.CandidateIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.CandidateIdentificationDocument ADD CONSTRAINT FK_99d8ee_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_99d8ee_PersonalInformationVerificationDescriptor
ON tpdm.CandidateIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.CandidateIndicator ADD CONSTRAINT FK_80ece3_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_80ece3_Candidate
ON tpdm.CandidateIndicator (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateIndicatorPeriod ADD CONSTRAINT FK_9fac2f_CandidateIndicator FOREIGN KEY (CandidateIdentifier, IndicatorName)
REFERENCES tpdm.CandidateIndicator (CandidateIdentifier, IndicatorName)
ON DELETE CASCADE
;

CREATE INDEX FK_9fac2f_CandidateIndicator
ON tpdm.CandidateIndicatorPeriod (CandidateIdentifier ASC, IndicatorName ASC);

ALTER TABLE tpdm.CandidateInternationalAddress ADD CONSTRAINT FK_344bbc_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_344bbc_AddressTypeDescriptor
ON tpdm.CandidateInternationalAddress (AddressTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateInternationalAddress ADD CONSTRAINT FK_344bbc_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_344bbc_Candidate
ON tpdm.CandidateInternationalAddress (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateInternationalAddress ADD CONSTRAINT FK_344bbc_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_344bbc_CountryDescriptor
ON tpdm.CandidateInternationalAddress (CountryDescriptorId ASC);

ALTER TABLE tpdm.CandidateLanguage ADD CONSTRAINT FK_e5239b_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_e5239b_Candidate
ON tpdm.CandidateLanguage (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateLanguage ADD CONSTRAINT FK_e5239b_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_e5239b_LanguageDescriptor
ON tpdm.CandidateLanguage (LanguageDescriptorId ASC);

ALTER TABLE tpdm.CandidateLanguageUse ADD CONSTRAINT FK_3f00b1_CandidateLanguage FOREIGN KEY (CandidateIdentifier, LanguageDescriptorId)
REFERENCES tpdm.CandidateLanguage (CandidateIdentifier, LanguageDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_3f00b1_CandidateLanguage
ON tpdm.CandidateLanguageUse (CandidateIdentifier ASC, LanguageDescriptorId ASC);

ALTER TABLE tpdm.CandidateLanguageUse ADD CONSTRAINT FK_3f00b1_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_3f00b1_LanguageUseDescriptor
ON tpdm.CandidateLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE tpdm.CandidateOtherName ADD CONSTRAINT FK_4521bb_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_4521bb_Candidate
ON tpdm.CandidateOtherName (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateOtherName ADD CONSTRAINT FK_4521bb_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

CREATE INDEX FK_4521bb_OtherNameTypeDescriptor
ON tpdm.CandidateOtherName (OtherNameTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidatePersonalIdentificationDocument ADD CONSTRAINT FK_93a227_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_93a227_Candidate
ON tpdm.CandidatePersonalIdentificationDocument (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidatePersonalIdentificationDocument ADD CONSTRAINT FK_93a227_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_93a227_CountryDescriptor
ON tpdm.CandidatePersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.CandidatePersonalIdentificationDocument ADD CONSTRAINT FK_93a227_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_93a227_IdentificationDocumentUseDescriptor
ON tpdm.CandidatePersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.CandidatePersonalIdentificationDocument ADD CONSTRAINT FK_93a227_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_93a227_PersonalInformationVerificationDescriptor
ON tpdm.CandidatePersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.CandidateRace ADD CONSTRAINT FK_6aa942_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_6aa942_Candidate
ON tpdm.CandidateRace (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateRace ADD CONSTRAINT FK_6aa942_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_6aa942_RaceDescriptor
ON tpdm.CandidateRace (RaceDescriptorId ASC);

ALTER TABLE tpdm.CandidateRelationshipToStaffAssociation ADD CONSTRAINT FK_610f76_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
;

CREATE INDEX FK_610f76_Candidate
ON tpdm.CandidateRelationshipToStaffAssociation (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateRelationshipToStaffAssociation ADD CONSTRAINT FK_610f76_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_610f76_Staff
ON tpdm.CandidateRelationshipToStaffAssociation (StaffUSI ASC);

ALTER TABLE tpdm.CandidateRelationshipToStaffAssociation ADD CONSTRAINT FK_610f76_StaffToCandidateRelationshipDescriptor FOREIGN KEY (StaffToCandidateRelationshipDescriptorId)
REFERENCES tpdm.StaffToCandidateRelationshipDescriptor (StaffToCandidateRelationshipDescriptorId)
;

CREATE INDEX FK_610f76_StaffToCandidateRelationshipDescriptor
ON tpdm.CandidateRelationshipToStaffAssociation (StaffToCandidateRelationshipDescriptorId ASC);

ALTER TABLE tpdm.CandidateTelephone ADD CONSTRAINT FK_09c531_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_09c531_Candidate
ON tpdm.CandidateTelephone (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateTelephone ADD CONSTRAINT FK_09c531_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_09c531_TelephoneNumberTypeDescriptor
ON tpdm.CandidateTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateVisa ADD CONSTRAINT FK_29ab86_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_29ab86_Candidate
ON tpdm.CandidateVisa (CandidateIdentifier ASC);

ALTER TABLE tpdm.CandidateVisa ADD CONSTRAINT FK_29ab86_VisaDescriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.VisaDescriptor (VisaDescriptorId)
;

CREATE INDEX FK_29ab86_VisaDescriptor
ON tpdm.CandidateVisa (VisaDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_CertificationFieldDescriptor FOREIGN KEY (CertificationFieldDescriptorId)
REFERENCES tpdm.CertificationFieldDescriptor (CertificationFieldDescriptorId)
;

CREATE INDEX FK_86846f_CertificationFieldDescriptor
ON tpdm.Certification (CertificationFieldDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_CertificationLevelDescriptor FOREIGN KEY (CertificationLevelDescriptorId)
REFERENCES tpdm.CertificationLevelDescriptor (CertificationLevelDescriptorId)
;

CREATE INDEX FK_86846f_CertificationLevelDescriptor
ON tpdm.Certification (CertificationLevelDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_CertificationStandardDescriptor FOREIGN KEY (CertificationStandardDescriptorId)
REFERENCES tpdm.CertificationStandardDescriptor (CertificationStandardDescriptorId)
;

CREATE INDEX FK_86846f_CertificationStandardDescriptor
ON tpdm.Certification (CertificationStandardDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_DegreeDescriptor FOREIGN KEY (MinimumDegreeDescriptorId)
REFERENCES tpdm.DegreeDescriptor (DegreeDescriptorId)
;

CREATE INDEX FK_86846f_DegreeDescriptor
ON tpdm.Certification (MinimumDegreeDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_86846f_EducationOrganization
ON tpdm.Certification (EducationOrganizationId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_EducatorRoleDescriptor FOREIGN KEY (EducatorRoleDescriptorId)
REFERENCES tpdm.EducatorRoleDescriptor (EducatorRoleDescriptorId)
;

CREATE INDEX FK_86846f_EducatorRoleDescriptor
ON tpdm.Certification (EducatorRoleDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_InstructionalSettingDescriptor FOREIGN KEY (InstructionalSettingDescriptorId)
REFERENCES tpdm.InstructionalSettingDescriptor (InstructionalSettingDescriptorId)
;

CREATE INDEX FK_86846f_InstructionalSettingDescriptor
ON tpdm.Certification (InstructionalSettingDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

CREATE INDEX FK_86846f_PopulationServedDescriptor
ON tpdm.Certification (PopulationServedDescriptorId ASC);

ALTER TABLE tpdm.CertificationCertificationExam ADD CONSTRAINT FK_947c8f_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_947c8f_Certification
ON tpdm.CertificationCertificationExam (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CertificationCertificationExam ADD CONSTRAINT FK_947c8f_CertificationExam FOREIGN KEY (CertificationExamIdentifier, CertificationExamNamespace)
REFERENCES tpdm.CertificationExam (CertificationExamIdentifier, Namespace)
;

CREATE INDEX FK_947c8f_CertificationExam
ON tpdm.CertificationCertificationExam (CertificationExamIdentifier ASC, CertificationExamNamespace ASC);

ALTER TABLE tpdm.CertificationExam ADD CONSTRAINT FK_cb139c_CertificationExamTypeDescriptor FOREIGN KEY (CertificationExamTypeDescriptorId)
REFERENCES tpdm.CertificationExamTypeDescriptor (CertificationExamTypeDescriptorId)
;

CREATE INDEX FK_cb139c_CertificationExamTypeDescriptor
ON tpdm.CertificationExam (CertificationExamTypeDescriptorId ASC);

ALTER TABLE tpdm.CertificationExam ADD CONSTRAINT FK_cb139c_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_cb139c_EducationOrganization
ON tpdm.CertificationExam (EducationOrganizationId ASC);

ALTER TABLE tpdm.CertificationExamResult ADD CONSTRAINT FK_aed83e_CertificationExam FOREIGN KEY (CertificationExamIdentifier, Namespace)
REFERENCES tpdm.CertificationExam (CertificationExamIdentifier, Namespace)
;

CREATE INDEX FK_aed83e_CertificationExam
ON tpdm.CertificationExamResult (CertificationExamIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CertificationExamResult ADD CONSTRAINT FK_aed83e_CertificationExamStatusDescriptor FOREIGN KEY (CertificationExamStatusDescriptorId)
REFERENCES tpdm.CertificationExamStatusDescriptor (CertificationExamStatusDescriptorId)
;

CREATE INDEX FK_aed83e_CertificationExamStatusDescriptor
ON tpdm.CertificationExamResult (CertificationExamStatusDescriptorId ASC);

ALTER TABLE tpdm.CertificationExamResult ADD CONSTRAINT FK_aed83e_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_aed83e_Person
ON tpdm.CertificationExamResult (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.CertificationExamStatusDescriptor ADD CONSTRAINT FK_ffe8b6_Descriptor FOREIGN KEY (CertificationExamStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationExamTypeDescriptor ADD CONSTRAINT FK_9ccf0f_Descriptor FOREIGN KEY (CertificationExamTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationFieldDescriptor ADD CONSTRAINT FK_bc9385_Descriptor FOREIGN KEY (CertificationFieldDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationGradeLevel ADD CONSTRAINT FK_809d74_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_809d74_Certification
ON tpdm.CertificationGradeLevel (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CertificationGradeLevel ADD CONSTRAINT FK_809d74_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_809d74_GradeLevelDescriptor
ON tpdm.CertificationGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.CertificationLevelDescriptor ADD CONSTRAINT FK_6bfe73_Descriptor FOREIGN KEY (CertificationLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationRoute ADD CONSTRAINT FK_62187e_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_62187e_Certification
ON tpdm.CertificationRoute (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CertificationRoute ADD CONSTRAINT FK_62187e_CertificationRouteDescriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES tpdm.CertificationRouteDescriptor (CertificationRouteDescriptorId)
;

CREATE INDEX FK_62187e_CertificationRouteDescriptor
ON tpdm.CertificationRoute (CertificationRouteDescriptorId ASC);

ALTER TABLE tpdm.CertificationRouteDescriptor ADD CONSTRAINT FK_40b601_Descriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationStandardDescriptor ADD CONSTRAINT FK_e0bae9_Descriptor FOREIGN KEY (CertificationStandardDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CoteachingStyleObservedDescriptor ADD CONSTRAINT FK_932c9a_Descriptor FOREIGN KEY (CoteachingStyleObservedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CredentialEvent ADD CONSTRAINT FK_3d6d96_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
;

CREATE INDEX FK_3d6d96_Credential
ON tpdm.CredentialEvent (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.CredentialEvent ADD CONSTRAINT FK_3d6d96_CredentialEventTypeDescriptor FOREIGN KEY (CredentialEventTypeDescriptorId)
REFERENCES tpdm.CredentialEventTypeDescriptor (CredentialEventTypeDescriptorId)
;

CREATE INDEX FK_3d6d96_CredentialEventTypeDescriptor
ON tpdm.CredentialEvent (CredentialEventTypeDescriptorId ASC);

ALTER TABLE tpdm.CredentialEventTypeDescriptor ADD CONSTRAINT FK_c57419_Descriptor FOREIGN KEY (CredentialEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
;

CREATE INDEX FK_6fae52_Certification
ON tpdm.CredentialExtension (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_CertificationRouteDescriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES tpdm.CertificationRouteDescriptor (CertificationRouteDescriptorId)
;

CREATE INDEX FK_6fae52_CertificationRouteDescriptor
ON tpdm.CredentialExtension (CertificationRouteDescriptorId ASC);

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_CredentialStatusDescriptor FOREIGN KEY (CredentialStatusDescriptorId)
REFERENCES tpdm.CredentialStatusDescriptor (CredentialStatusDescriptorId)
;

CREATE INDEX FK_6fae52_CredentialStatusDescriptor
ON tpdm.CredentialExtension (CredentialStatusDescriptorId ASC);

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_6fae52_Person
ON tpdm.CredentialExtension (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.CredentialStatusDescriptor ADD CONSTRAINT FK_91080a_Descriptor FOREIGN KEY (CredentialStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CredentialStudentAcademicRecord ADD CONSTRAINT FK_73e151_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_73e151_Credential
ON tpdm.CredentialStudentAcademicRecord (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.CredentialStudentAcademicRecord ADD CONSTRAINT FK_73e151_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
;

CREATE INDEX FK_73e151_StudentAcademicRecord
ON tpdm.CredentialStudentAcademicRecord (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.DegreeDescriptor ADD CONSTRAINT FK_0700f5_Descriptor FOREIGN KEY (DegreeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EducatorPreparationProgram ADD CONSTRAINT FK_195935_AccreditationStatusDescriptor FOREIGN KEY (AccreditationStatusDescriptorId)
REFERENCES tpdm.AccreditationStatusDescriptor (AccreditationStatusDescriptorId)
;

CREATE INDEX FK_195935_AccreditationStatusDescriptor
ON tpdm.EducatorPreparationProgram (AccreditationStatusDescriptorId ASC);

ALTER TABLE tpdm.EducatorPreparationProgram ADD CONSTRAINT FK_195935_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_195935_EducationOrganization
ON tpdm.EducatorPreparationProgram (EducationOrganizationId ASC);

ALTER TABLE tpdm.EducatorPreparationProgram ADD CONSTRAINT FK_195935_EducatorPreparationProgramTypeDescriptor FOREIGN KEY (EducatorPreparationProgramTypeDescriptorId)
REFERENCES tpdm.EducatorPreparationProgramTypeDescriptor (EducatorPreparationProgramTypeDescriptorId)
;

CREATE INDEX FK_195935_EducatorPreparationProgramTypeDescriptor
ON tpdm.EducatorPreparationProgram (EducatorPreparationProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.EducatorPreparationProgram ADD CONSTRAINT FK_195935_ProgramTypeDescriptor FOREIGN KEY (ProgramTypeDescriptorId)
REFERENCES edfi.ProgramTypeDescriptor (ProgramTypeDescriptorId)
;

CREATE INDEX FK_195935_ProgramTypeDescriptor
ON tpdm.EducatorPreparationProgram (ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.EducatorPreparationProgramGradeLevel ADD CONSTRAINT FK_d3a222_EducatorPreparationProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.EducatorPreparationProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_d3a222_EducatorPreparationProgram
ON tpdm.EducatorPreparationProgramGradeLevel (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.EducatorPreparationProgramGradeLevel ADD CONSTRAINT FK_d3a222_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_d3a222_GradeLevelDescriptor
ON tpdm.EducatorPreparationProgramGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.EducatorPreparationProgramTypeDescriptor ADD CONSTRAINT FK_1a08e2_Descriptor FOREIGN KEY (EducatorPreparationProgramTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EducatorRoleDescriptor ADD CONSTRAINT FK_bc8b94_Descriptor FOREIGN KEY (EducatorRoleDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EnglishLanguageExamDescriptor ADD CONSTRAINT FK_76d6e8_Descriptor FOREIGN KEY (EnglishLanguageExamDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EPPDegreeTypeDescriptor ADD CONSTRAINT FK_3d1445_Descriptor FOREIGN KEY (EPPDegreeTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EPPProgramPathwayDescriptor ADD CONSTRAINT FK_cde665_Descriptor FOREIGN KEY (EPPProgramPathwayDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.Evaluation ADD CONSTRAINT FK_163e44_EvaluationTypeDescriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES tpdm.EvaluationTypeDescriptor (EvaluationTypeDescriptorId)
;

CREATE INDEX FK_163e44_EvaluationTypeDescriptor
ON tpdm.Evaluation (EvaluationTypeDescriptorId ASC);

ALTER TABLE tpdm.Evaluation ADD CONSTRAINT FK_163e44_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_163e44_PerformanceEvaluation
ON tpdm.Evaluation (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElement ADD CONSTRAINT FK_e53186_EvaluationObjective FOREIGN KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationObjective (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_e53186_EvaluationObjective
ON tpdm.EvaluationElement (EducationOrganizationId ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElement ADD CONSTRAINT FK_e53186_EvaluationTypeDescriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES tpdm.EvaluationTypeDescriptor (EvaluationTypeDescriptorId)
;

CREATE INDEX FK_e53186_EvaluationTypeDescriptor
ON tpdm.EvaluationElement (EvaluationTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRating ADD CONSTRAINT FK_4479ea_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_4479ea_EvaluationElement
ON tpdm.EvaluationElementRating (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRating ADD CONSTRAINT FK_4479ea_EvaluationElementRatingLevelDescriptor FOREIGN KEY (EvaluationElementRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationElementRatingLevelDescriptor (EvaluationElementRatingLevelDescriptorId)
;

CREATE INDEX FK_4479ea_EvaluationElementRatingLevelDescriptor
ON tpdm.EvaluationElementRating (EvaluationElementRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRating ADD CONSTRAINT FK_4479ea_EvaluationObjectiveRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationObjectiveRating (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_4479ea_EvaluationObjectiveRating
ON tpdm.EvaluationElementRating (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRatingLevel ADD CONSTRAINT FK_afbeb2_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_afbeb2_EvaluationElement
ON tpdm.EvaluationElementRatingLevel (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRatingLevel ADD CONSTRAINT FK_afbeb2_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_afbeb2_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationElementRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRatingLevelDescriptor ADD CONSTRAINT FK_86df6c_Descriptor FOREIGN KEY (EvaluationElementRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationElementRatingResult ADD CONSTRAINT FK_c5877a_EvaluationElementRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationElementRating (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_c5877a_EvaluationElementRating
ON tpdm.EvaluationElementRatingResult (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRatingResult ADD CONSTRAINT FK_c5877a_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_c5877a_ResultDatatypeTypeDescriptor
ON tpdm.EvaluationElementRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjective ADD CONSTRAINT FK_d4565d_Evaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.Evaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_d4565d_Evaluation
ON tpdm.EvaluationObjective (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjective ADD CONSTRAINT FK_d4565d_EvaluationTypeDescriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES tpdm.EvaluationTypeDescriptor (EvaluationTypeDescriptorId)
;

CREATE INDEX FK_d4565d_EvaluationTypeDescriptor
ON tpdm.EvaluationObjective (EvaluationTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRating ADD CONSTRAINT FK_7ae19d_EvaluationObjective FOREIGN KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationObjective (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_7ae19d_EvaluationObjective
ON tpdm.EvaluationObjectiveRating (EducationOrganizationId ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRating ADD CONSTRAINT FK_7ae19d_EvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRating (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_7ae19d_EvaluationRating
ON tpdm.EvaluationObjectiveRating (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRating ADD CONSTRAINT FK_7ae19d_ObjectiveRatingLevelDescriptor FOREIGN KEY (ObjectiveRatingLevelDescriptorId)
REFERENCES tpdm.ObjectiveRatingLevelDescriptor (ObjectiveRatingLevelDescriptorId)
;

CREATE INDEX FK_7ae19d_ObjectiveRatingLevelDescriptor
ON tpdm.EvaluationObjectiveRating (ObjectiveRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingLevel ADD CONSTRAINT FK_1d984c_EvaluationObjective FOREIGN KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationObjective (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_1d984c_EvaluationObjective
ON tpdm.EvaluationObjectiveRatingLevel (EducationOrganizationId ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingLevel ADD CONSTRAINT FK_1d984c_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_1d984c_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationObjectiveRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingResult ADD CONSTRAINT FK_beeccb_EvaluationObjectiveRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationObjectiveRating (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_beeccb_EvaluationObjectiveRating
ON tpdm.EvaluationObjectiveRatingResult (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingResult ADD CONSTRAINT FK_beeccb_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_beeccb_ResultDatatypeTypeDescriptor
ON tpdm.EvaluationObjectiveRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationPeriodDescriptor ADD CONSTRAINT FK_83ff2a_Descriptor FOREIGN KEY (EvaluationPeriodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_Evaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.Evaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_bfaa20_Evaluation
ON tpdm.EvaluationRating (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_bfaa20_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationRating (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_PerformanceEvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRating (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_bfaa20_PerformanceEvaluationRating
ON tpdm.EvaluationRating (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_bfaa20_Section
ON tpdm.EvaluationRating (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE tpdm.EvaluationRatingLevel ADD CONSTRAINT FK_7052f8_Evaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.Evaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_7052f8_Evaluation
ON tpdm.EvaluationRatingLevel (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingLevel ADD CONSTRAINT FK_7052f8_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_7052f8_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingLevelDescriptor ADD CONSTRAINT FK_5fb2ad_Descriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationRatingResult ADD CONSTRAINT FK_268283_EvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRating (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_268283_EvaluationRating
ON tpdm.EvaluationRatingResult (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingResult ADD CONSTRAINT FK_268283_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_268283_ResultDatatypeTypeDescriptor
ON tpdm.EvaluationRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingReviewer ADD CONSTRAINT FK_2d29eb_EvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRating (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_2d29eb_EvaluationRating
ON tpdm.EvaluationRatingReviewer (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingReviewer ADD CONSTRAINT FK_2d29eb_Person FOREIGN KEY (ReviewerPersonId, ReviewerSourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_2d29eb_Person
ON tpdm.EvaluationRatingReviewer (ReviewerPersonId ASC, ReviewerSourceSystemDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingReviewerReceivedTraining ADD CONSTRAINT FK_608112_EvaluationRatingReviewer FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRatingReviewer (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationTypeDescriptor ADD CONSTRAINT FK_67cd19_Descriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FederalLocaleCodeDescriptor ADD CONSTRAINT FK_cec0ca_Descriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FieldworkExperience ADD CONSTRAINT FK_fd30bb_EducatorPreparationProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.EducatorPreparationProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_fd30bb_EducatorPreparationProgram
ON tpdm.FieldworkExperience (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.FieldworkExperience ADD CONSTRAINT FK_fd30bb_FieldworkTypeDescriptor FOREIGN KEY (FieldworkTypeDescriptorId)
REFERENCES tpdm.FieldworkTypeDescriptor (FieldworkTypeDescriptorId)
;

CREATE INDEX FK_fd30bb_FieldworkTypeDescriptor
ON tpdm.FieldworkExperience (FieldworkTypeDescriptorId ASC);

ALTER TABLE tpdm.FieldworkExperience ADD CONSTRAINT FK_fd30bb_ProgramGatewayDescriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES tpdm.ProgramGatewayDescriptor (ProgramGatewayDescriptorId)
;

CREATE INDEX FK_fd30bb_ProgramGatewayDescriptor
ON tpdm.FieldworkExperience (ProgramGatewayDescriptorId ASC);

ALTER TABLE tpdm.FieldworkExperience ADD CONSTRAINT FK_fd30bb_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_fd30bb_School
ON tpdm.FieldworkExperience (SchoolId ASC);

ALTER TABLE tpdm.FieldworkExperience ADD CONSTRAINT FK_fd30bb_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_fd30bb_Student
ON tpdm.FieldworkExperience (StudentUSI ASC);

ALTER TABLE tpdm.FieldworkExperienceCoteaching ADD CONSTRAINT FK_1a4745_FieldworkExperience FOREIGN KEY (BeginDate, FieldworkIdentifier, StudentUSI)
REFERENCES tpdm.FieldworkExperience (BeginDate, FieldworkIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FieldworkExperienceSectionAssociation ADD CONSTRAINT FK_b2abcd_FieldworkExperience FOREIGN KEY (BeginDate, FieldworkIdentifier, StudentUSI)
REFERENCES tpdm.FieldworkExperience (BeginDate, FieldworkIdentifier, StudentUSI)
;

CREATE INDEX FK_b2abcd_FieldworkExperience
ON tpdm.FieldworkExperienceSectionAssociation (BeginDate ASC, FieldworkIdentifier ASC, StudentUSI ASC);

ALTER TABLE tpdm.FieldworkExperienceSectionAssociation ADD CONSTRAINT FK_b2abcd_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_b2abcd_Section
ON tpdm.FieldworkExperienceSectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE tpdm.FieldworkTypeDescriptor ADD CONSTRAINT FK_a16a29_Descriptor FOREIGN KEY (FieldworkTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FundingSourceDescriptor ADD CONSTRAINT FK_3ecd1a_Descriptor FOREIGN KEY (FundingSourceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.GenderDescriptor ADD CONSTRAINT FK_554e4f_Descriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.Goal ADD CONSTRAINT FK_cdbf69_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_cdbf69_EvaluationElement
ON tpdm.Goal (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.Goal ADD CONSTRAINT FK_cdbf69_GoalTypeDescriptor FOREIGN KEY (GoalTypeDescriptorId)
REFERENCES tpdm.GoalTypeDescriptor (GoalTypeDescriptorId)
;

CREATE INDEX FK_cdbf69_GoalTypeDescriptor
ON tpdm.Goal (GoalTypeDescriptorId ASC);

ALTER TABLE tpdm.Goal ADD CONSTRAINT FK_cdbf69_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_cdbf69_Person
ON tpdm.Goal (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.GoalTypeDescriptor ADD CONSTRAINT FK_403c02_Descriptor FOREIGN KEY (GoalTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.GraduationPlanRequiredCertification ADD CONSTRAINT FK_bd70a1_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
;

CREATE INDEX FK_bd70a1_Certification
ON tpdm.GraduationPlanRequiredCertification (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.GraduationPlanRequiredCertification ADD CONSTRAINT FK_bd70a1_CertificationRouteDescriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES tpdm.CertificationRouteDescriptor (CertificationRouteDescriptorId)
;

CREATE INDEX FK_bd70a1_CertificationRouteDescriptor
ON tpdm.GraduationPlanRequiredCertification (CertificationRouteDescriptorId ASC);

ALTER TABLE tpdm.GraduationPlanRequiredCertification ADD CONSTRAINT FK_bd70a1_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_bd70a1_GraduationPlan
ON tpdm.GraduationPlanRequiredCertification (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE tpdm.HireStatusDescriptor ADD CONSTRAINT FK_f84919_Descriptor FOREIGN KEY (HireStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.HiringSourceDescriptor ADD CONSTRAINT FK_7d10e3_Descriptor FOREIGN KEY (HiringSourceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.InstructionalSettingDescriptor ADD CONSTRAINT FK_d9876b_Descriptor FOREIGN KEY (InstructionalSettingDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.LengthOfContractDescriptor ADD CONSTRAINT FK_0777f9_Descriptor FOREIGN KEY (LengthOfContractDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.LocalEducationAgencyExtension ADD CONSTRAINT FK_bf6aa4_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_bf6aa4_FederalLocaleCodeDescriptor
ON tpdm.LocalEducationAgencyExtension (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.LocalEducationAgencyExtension ADD CONSTRAINT FK_bf6aa4_LocalEducationAgency FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ObjectiveRatingLevelDescriptor ADD CONSTRAINT FK_d49b1f_Descriptor FOREIGN KEY (ObjectiveRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.OpenStaffPositionEvent ADD CONSTRAINT FK_e809b0_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
;

CREATE INDEX FK_e809b0_OpenStaffPosition
ON tpdm.OpenStaffPositionEvent (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE tpdm.OpenStaffPositionEvent ADD CONSTRAINT FK_e809b0_OpenStaffPositionEventStatusDescriptor FOREIGN KEY (OpenStaffPositionEventStatusDescriptorId)
REFERENCES tpdm.OpenStaffPositionEventStatusDescriptor (OpenStaffPositionEventStatusDescriptorId)
;

CREATE INDEX FK_e809b0_OpenStaffPositionEventStatusDescriptor
ON tpdm.OpenStaffPositionEvent (OpenStaffPositionEventStatusDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionEvent ADD CONSTRAINT FK_e809b0_OpenStaffPositionEventTypeDescriptor FOREIGN KEY (OpenStaffPositionEventTypeDescriptorId)
REFERENCES tpdm.OpenStaffPositionEventTypeDescriptor (OpenStaffPositionEventTypeDescriptorId)
;

CREATE INDEX FK_e809b0_OpenStaffPositionEventTypeDescriptor
ON tpdm.OpenStaffPositionEvent (OpenStaffPositionEventTypeDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionEventStatusDescriptor ADD CONSTRAINT FK_1910c5_Descriptor FOREIGN KEY (OpenStaffPositionEventStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.OpenStaffPositionEventTypeDescriptor ADD CONSTRAINT FK_f48cc2_Descriptor FOREIGN KEY (OpenStaffPositionEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_FundingSourceDescriptor FOREIGN KEY (FundingSourceDescriptorId)
REFERENCES tpdm.FundingSourceDescriptor (FundingSourceDescriptorId)
;

CREATE INDEX FK_892567_FundingSourceDescriptor
ON tpdm.OpenStaffPositionExtension (FundingSourceDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
ON DELETE CASCADE
;

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_OpenStaffPositionReasonDescriptor FOREIGN KEY (OpenStaffPositionReasonDescriptorId)
REFERENCES tpdm.OpenStaffPositionReasonDescriptor (OpenStaffPositionReasonDescriptorId)
;

CREATE INDEX FK_892567_OpenStaffPositionReasonDescriptor
ON tpdm.OpenStaffPositionExtension (OpenStaffPositionReasonDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_892567_SchoolYearType
ON tpdm.OpenStaffPositionExtension (SchoolYear ASC);

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_892567_TermDescriptor
ON tpdm.OpenStaffPositionExtension (TermDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionReasonDescriptor ADD CONSTRAINT FK_80ebb8_Descriptor FOREIGN KEY (OpenStaffPositionReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_15d685_AcademicSubjectDescriptor
ON tpdm.PerformanceEvaluation (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_15d685_EducationOrganization
ON tpdm.PerformanceEvaluation (EducationOrganizationId ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_EvaluationPeriodDescriptor FOREIGN KEY (EvaluationPeriodDescriptorId)
REFERENCES tpdm.EvaluationPeriodDescriptor (EvaluationPeriodDescriptorId)
;

CREATE INDEX FK_15d685_EvaluationPeriodDescriptor
ON tpdm.PerformanceEvaluation (EvaluationPeriodDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_PerformanceEvaluationTypeDescriptor FOREIGN KEY (PerformanceEvaluationTypeDescriptorId)
REFERENCES tpdm.PerformanceEvaluationTypeDescriptor (PerformanceEvaluationTypeDescriptorId)
;

CREATE INDEX FK_15d685_PerformanceEvaluationTypeDescriptor
ON tpdm.PerformanceEvaluation (PerformanceEvaluationTypeDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_15d685_SchoolYearType
ON tpdm.PerformanceEvaluation (SchoolYear ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_15d685_TermDescriptor
ON tpdm.PerformanceEvaluation (TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationGradeLevel ADD CONSTRAINT FK_5b9d31_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_5b9d31_GradeLevelDescriptor
ON tpdm.PerformanceEvaluationGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationGradeLevel ADD CONSTRAINT FK_5b9d31_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_5b9d31_PerformanceEvaluation
ON tpdm.PerformanceEvaluationGradeLevel (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationProgramGateway ADD CONSTRAINT FK_611be2_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_611be2_PerformanceEvaluation
ON tpdm.PerformanceEvaluationProgramGateway (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationProgramGateway ADD CONSTRAINT FK_611be2_ProgramGatewayDescriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES tpdm.ProgramGatewayDescriptor (ProgramGatewayDescriptorId)
;

CREATE INDEX FK_611be2_ProgramGatewayDescriptor
ON tpdm.PerformanceEvaluationProgramGateway (ProgramGatewayDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRating ADD CONSTRAINT FK_759abe_CoteachingStyleObservedDescriptor FOREIGN KEY (CoteachingStyleObservedDescriptorId)
REFERENCES tpdm.CoteachingStyleObservedDescriptor (CoteachingStyleObservedDescriptorId)
;

CREATE INDEX FK_759abe_CoteachingStyleObservedDescriptor
ON tpdm.PerformanceEvaluationRating (CoteachingStyleObservedDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRating ADD CONSTRAINT FK_759abe_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_759abe_PerformanceEvaluation
ON tpdm.PerformanceEvaluationRating (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRating ADD CONSTRAINT FK_759abe_PerformanceEvaluationRatingLevelDescriptor FOREIGN KEY (PerformanceEvaluationRatingLevelDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRatingLevelDescriptor (PerformanceEvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_759abe_PerformanceEvaluationRatingLevelDescriptor
ON tpdm.PerformanceEvaluationRating (PerformanceEvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRating ADD CONSTRAINT FK_759abe_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_759abe_Person
ON tpdm.PerformanceEvaluationRating (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingLevel ADD CONSTRAINT FK_90ed3d_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_90ed3d_EvaluationRatingLevelDescriptor
ON tpdm.PerformanceEvaluationRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingLevel ADD CONSTRAINT FK_90ed3d_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_90ed3d_PerformanceEvaluation
ON tpdm.PerformanceEvaluationRatingLevel (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingLevelDescriptor ADD CONSTRAINT FK_ed7e01_Descriptor FOREIGN KEY (PerformanceEvaluationRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluationRatingResult ADD CONSTRAINT FK_863fa4_PerformanceEvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRating (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_863fa4_PerformanceEvaluationRating
ON tpdm.PerformanceEvaluationRatingResult (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingResult ADD CONSTRAINT FK_863fa4_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_863fa4_ResultDatatypeTypeDescriptor
ON tpdm.PerformanceEvaluationRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewer ADD CONSTRAINT FK_477526_PerformanceEvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRating (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_477526_PerformanceEvaluationRating
ON tpdm.PerformanceEvaluationRatingReviewer (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewer ADD CONSTRAINT FK_477526_Person FOREIGN KEY (ReviewerPersonId, ReviewerSourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_477526_Person
ON tpdm.PerformanceEvaluationRatingReviewer (ReviewerPersonId ASC, ReviewerSourceSystemDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewerReceivedTraining ADD CONSTRAINT FK_6e6517_PerformanceEvaluationRatingReviewer FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRatingReviewer (EducationOrganizationId, EvaluationPeriodDescriptorId, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluationTypeDescriptor ADD CONSTRAINT FK_2ba831_Descriptor FOREIGN KEY (PerformanceEvaluationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PostSecondaryInstitutionExtension ADD CONSTRAINT FK_bd2efc_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_bd2efc_FederalLocaleCodeDescriptor
ON tpdm.PostSecondaryInstitutionExtension (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.PostSecondaryInstitutionExtension ADD CONSTRAINT FK_bd2efc_PostSecondaryInstitution FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.PostSecondaryInstitution (PostSecondaryInstitutionId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PreviousCareerDescriptor ADD CONSTRAINT FK_29798f_Descriptor FOREIGN KEY (PreviousCareerDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ProfessionalDevelopmentEvent ADD CONSTRAINT FK_8c4ca1_ProfessionalDevelopmentOfferedByDescriptor FOREIGN KEY (ProfessionalDevelopmentOfferedByDescriptorId)
REFERENCES tpdm.ProfessionalDevelopmentOfferedByDescriptor (ProfessionalDevelopmentOfferedByDescriptorId)
;

CREATE INDEX FK_8c4ca1_ProfessionalDevelopmentOfferedByDescriptor
ON tpdm.ProfessionalDevelopmentEvent (ProfessionalDevelopmentOfferedByDescriptorId ASC);

ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ADD CONSTRAINT FK_22e412_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

CREATE INDEX FK_22e412_AttendanceEventCategoryDescriptor
ON tpdm.ProfessionalDevelopmentEventAttendance (AttendanceEventCategoryDescriptorId ASC);

ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ADD CONSTRAINT FK_22e412_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_22e412_Person
ON tpdm.ProfessionalDevelopmentEventAttendance (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ADD CONSTRAINT FK_22e412_ProfessionalDevelopmentEvent FOREIGN KEY (Namespace, ProfessionalDevelopmentTitle)
REFERENCES tpdm.ProfessionalDevelopmentEvent (Namespace, ProfessionalDevelopmentTitle)
;

CREATE INDEX FK_22e412_ProfessionalDevelopmentEvent
ON tpdm.ProfessionalDevelopmentEventAttendance (Namespace ASC, ProfessionalDevelopmentTitle ASC);

ALTER TABLE tpdm.ProfessionalDevelopmentOfferedByDescriptor ADD CONSTRAINT FK_b58d9b_Descriptor FOREIGN KEY (ProfessionalDevelopmentOfferedByDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ProgramGatewayDescriptor ADD CONSTRAINT FK_d0ca9b_Descriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.QuantitativeMeasure ADD CONSTRAINT FK_8b89fe_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_8b89fe_EvaluationElement
ON tpdm.QuantitativeMeasure (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasure ADD CONSTRAINT FK_8b89fe_QuantitativeMeasureDatatypeDescriptor FOREIGN KEY (QuantitativeMeasureDatatypeDescriptorId)
REFERENCES tpdm.QuantitativeMeasureDatatypeDescriptor (QuantitativeMeasureDatatypeDescriptorId)
;

CREATE INDEX FK_8b89fe_QuantitativeMeasureDatatypeDescriptor
ON tpdm.QuantitativeMeasure (QuantitativeMeasureDatatypeDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasure ADD CONSTRAINT FK_8b89fe_QuantitativeMeasureTypeDescriptor FOREIGN KEY (QuantitativeMeasureTypeDescriptorId)
REFERENCES tpdm.QuantitativeMeasureTypeDescriptor (QuantitativeMeasureTypeDescriptorId)
;

CREATE INDEX FK_8b89fe_QuantitativeMeasureTypeDescriptor
ON tpdm.QuantitativeMeasure (QuantitativeMeasureTypeDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasureDatatypeDescriptor ADD CONSTRAINT FK_1d0f9c_Descriptor FOREIGN KEY (QuantitativeMeasureDatatypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.QuantitativeMeasureScore ADD CONSTRAINT FK_e61067_EvaluationElementRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationElementRating (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_e61067_EvaluationElementRating
ON tpdm.QuantitativeMeasureScore (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasureScore ADD CONSTRAINT FK_e61067_QuantitativeMeasure FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId)
REFERENCES tpdm.QuantitativeMeasure (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_e61067_QuantitativeMeasure
ON tpdm.QuantitativeMeasureScore (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, QuantitativeMeasureIdentifier ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasureTypeDescriptor ADD CONSTRAINT FK_9f49f2_Descriptor FOREIGN KEY (QuantitativeMeasureTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.RecruitmentEvent ADD CONSTRAINT FK_6232e8_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_6232e8_EducationOrganization
ON tpdm.RecruitmentEvent (EducationOrganizationId ASC);

ALTER TABLE tpdm.RecruitmentEvent ADD CONSTRAINT FK_6232e8_RecruitmentEventTypeDescriptor FOREIGN KEY (RecruitmentEventTypeDescriptorId)
REFERENCES tpdm.RecruitmentEventTypeDescriptor (RecruitmentEventTypeDescriptorId)
;

CREATE INDEX FK_6232e8_RecruitmentEventTypeDescriptor
ON tpdm.RecruitmentEvent (RecruitmentEventTypeDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendance ADD CONSTRAINT FK_fca83b_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_fca83b_GenderDescriptor
ON tpdm.RecruitmentEventAttendance (GenderDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendance ADD CONSTRAINT FK_fca83b_RecruitmentEvent FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle)
REFERENCES tpdm.RecruitmentEvent (EducationOrganizationId, EventDate, EventTitle)
;

CREATE INDEX FK_fca83b_RecruitmentEvent
ON tpdm.RecruitmentEventAttendance (EducationOrganizationId ASC, EventDate ASC, EventTitle ASC);

ALTER TABLE tpdm.RecruitmentEventAttendance ADD CONSTRAINT FK_fca83b_RecruitmentEventAttendeeTypeDescriptor FOREIGN KEY (RecruitmentEventAttendeeTypeDescriptorId)
REFERENCES tpdm.RecruitmentEventAttendeeTypeDescriptor (RecruitmentEventAttendeeTypeDescriptorId)
;

CREATE INDEX FK_fca83b_RecruitmentEventAttendeeTypeDescriptor
ON tpdm.RecruitmentEventAttendance (RecruitmentEventAttendeeTypeDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendance ADD CONSTRAINT FK_fca83b_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_fca83b_SexDescriptor
ON tpdm.RecruitmentEventAttendance (SexDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceCurrentPosition ADD CONSTRAINT FK_36c0ac_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_36c0ac_AcademicSubjectDescriptor
ON tpdm.RecruitmentEventAttendanceCurrentPosition (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceCurrentPosition ADD CONSTRAINT FK_36c0ac_RecruitmentEventAttendance FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendance (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel ADD CONSTRAINT FK_730b7b_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_730b7b_GradeLevelDescriptor
ON tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel ADD CONSTRAINT FK_730b7b_RecruitmentEventAttendanceCurrentPosition FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendanceCurrentPosition (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_730b7b_RecruitmentEventAttendanceCurrentPosition
ON tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel (EducationOrganizationId ASC, EventDate ASC, EventTitle ASC, RecruitmentEventAttendeeIdentifier ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceDisability ADD CONSTRAINT FK_fc1560_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_fc1560_DisabilityDescriptor
ON tpdm.RecruitmentEventAttendanceDisability (DisabilityDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceDisability ADD CONSTRAINT FK_fc1560_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_fc1560_DisabilityDeterminationSourceTypeDescriptor
ON tpdm.RecruitmentEventAttendanceDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceDisability ADD CONSTRAINT FK_fc1560_RecruitmentEventAttendance FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendance (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_fc1560_RecruitmentEventAttendance
ON tpdm.RecruitmentEventAttendanceDisability (EducationOrganizationId ASC, EventDate ASC, EventTitle ASC, RecruitmentEventAttendeeIdentifier ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceDisabilityDesignation ADD CONSTRAINT FK_144c1f_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_144c1f_DisabilityDesignationDescriptor
ON tpdm.RecruitmentEventAttendanceDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceDisabilityDesignation ADD CONSTRAINT FK_144c1f_RecruitmentEventAttendanceDisability FOREIGN KEY (DisabilityDescriptorId, EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendanceDisability (DisabilityDescriptorId, EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_144c1f_RecruitmentEventAttendanceDisability
ON tpdm.RecruitmentEventAttendanceDisabilityDesignation (DisabilityDescriptorId ASC, EducationOrganizationId ASC, EventDate ASC, EventTitle ASC, RecruitmentEventAttendeeIdentifier ASC);

ALTER TABLE tpdm.RecruitmentEventAttendancePersonalIdentificationDocument ADD CONSTRAINT FK_eb5391_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_eb5391_CountryDescriptor
ON tpdm.RecruitmentEventAttendancePersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendancePersonalIdentificationDocument ADD CONSTRAINT FK_eb5391_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_eb5391_IdentificationDocumentUseDescriptor
ON tpdm.RecruitmentEventAttendancePersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendancePersonalIdentificationDocument ADD CONSTRAINT FK_eb5391_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_eb5391_PersonalInformationVerificationDescriptor
ON tpdm.RecruitmentEventAttendancePersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendancePersonalIdentificationDocument ADD CONSTRAINT FK_eb5391_RecruitmentEventAttendance FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendance (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_eb5391_RecruitmentEventAttendance
ON tpdm.RecruitmentEventAttendancePersonalIdentificationDocument (EducationOrganizationId ASC, EventDate ASC, EventTitle ASC, RecruitmentEventAttendeeIdentifier ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceRace ADD CONSTRAINT FK_06b5d8_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_06b5d8_RaceDescriptor
ON tpdm.RecruitmentEventAttendanceRace (RaceDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceRace ADD CONSTRAINT FK_06b5d8_RecruitmentEventAttendance FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendance (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_06b5d8_RecruitmentEventAttendance
ON tpdm.RecruitmentEventAttendanceRace (EducationOrganizationId ASC, EventDate ASC, EventTitle ASC, RecruitmentEventAttendeeIdentifier ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7 ADD CONSTRAINT FK_82dbb7_RecruitmentEventAttendance FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendance (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.RecruitmentEventAttendanceTelephone ADD CONSTRAINT FK_8dd3cb_RecruitmentEventAttendance FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendance (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_8dd3cb_RecruitmentEventAttendance
ON tpdm.RecruitmentEventAttendanceTelephone (EducationOrganizationId ASC, EventDate ASC, EventTitle ASC, RecruitmentEventAttendeeIdentifier ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceTelephone ADD CONSTRAINT FK_8dd3cb_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_8dd3cb_TelephoneNumberTypeDescriptor
ON tpdm.RecruitmentEventAttendanceTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventAttendanceTouchpoint ADD CONSTRAINT FK_a73c59_RecruitmentEventAttendance FOREIGN KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
REFERENCES tpdm.RecruitmentEventAttendance (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_a73c59_RecruitmentEventAttendance
ON tpdm.RecruitmentEventAttendanceTouchpoint (EducationOrganizationId ASC, EventDate ASC, EventTitle ASC, RecruitmentEventAttendeeIdentifier ASC);

ALTER TABLE tpdm.RecruitmentEventAttendeeTypeDescriptor ADD CONSTRAINT FK_39024b_Descriptor FOREIGN KEY (RecruitmentEventAttendeeTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.RecruitmentEventTypeDescriptor ADD CONSTRAINT FK_4075e3_Descriptor FOREIGN KEY (RecruitmentEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.RubricDimension ADD CONSTRAINT FK_643c81_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_643c81_EvaluationElement
ON tpdm.RubricDimension (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.RubricDimension ADD CONSTRAINT FK_643c81_RubricRatingLevelDescriptor FOREIGN KEY (RubricRatingLevelDescriptorId)
REFERENCES tpdm.RubricRatingLevelDescriptor (RubricRatingLevelDescriptorId)
;

CREATE INDEX FK_643c81_RubricRatingLevelDescriptor
ON tpdm.RubricDimension (RubricRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.RubricRatingLevelDescriptor ADD CONSTRAINT FK_f24609_Descriptor FOREIGN KEY (RubricRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SalaryTypeDescriptor ADD CONSTRAINT FK_9bdb03_Descriptor FOREIGN KEY (SalaryTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_AccreditationStatusDescriptor FOREIGN KEY (AccreditationStatusDescriptorId)
REFERENCES tpdm.AccreditationStatusDescriptor (AccreditationStatusDescriptorId)
;

CREATE INDEX FK_2199be_AccreditationStatusDescriptor
ON tpdm.SchoolExtension (AccreditationStatusDescriptorId ASC);

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_2199be_FederalLocaleCodeDescriptor
ON tpdm.SchoolExtension (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_PostSecondaryInstitution FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.PostSecondaryInstitution (PostSecondaryInstitutionId)
;

CREATE INDEX FK_2199be_PostSecondaryInstitution
ON tpdm.SchoolExtension (PostSecondaryInstitutionId ASC);

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffEducationOrganizationAssignmentAssociationExtension ADD CONSTRAINT FK_6ea356_StaffEducationOrganizationAssignmentAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationAssignmentAssociation (BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck ADD CONSTRAINT FK_b66085_BackgroundCheckStatusDescriptor FOREIGN KEY (BackgroundCheckStatusDescriptorId)
REFERENCES tpdm.BackgroundCheckStatusDescriptor (BackgroundCheckStatusDescriptorId)
;

CREATE INDEX FK_b66085_BackgroundCheckStatusDescriptor
ON tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck (BackgroundCheckStatusDescriptorId ASC);

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck ADD CONSTRAINT FK_b66085_BackgroundCheckTypeDescriptor FOREIGN KEY (BackgroundCheckTypeDescriptorId)
REFERENCES tpdm.BackgroundCheckTypeDescriptor (BackgroundCheckTypeDescriptorId)
;

CREATE INDEX FK_b66085_BackgroundCheckTypeDescriptor
ON tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck (BackgroundCheckTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck ADD CONSTRAINT FK_b66085_StaffEducationOrganizationEmploymentAssociation FOREIGN KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationEmploymentAssociation (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b66085_StaffEducationOrganizationEmploymentAssociation
ON tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck (EducationOrganizationId ASC, EmploymentStatusDescriptorId ASC, HireDate ASC, StaffUSI ASC);

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationExtension ADD CONSTRAINT FK_ec4394_LengthOfContractDescriptor FOREIGN KEY (LengthOfContractDescriptorId)
REFERENCES tpdm.LengthOfContractDescriptor (LengthOfContractDescriptorId)
;

CREATE INDEX FK_ec4394_LengthOfContractDescriptor
ON tpdm.StaffEducationOrganizationEmploymentAssociationExtension (LengthOfContractDescriptorId ASC);

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationExtension ADD CONSTRAINT FK_ec4394_StaffEducationOrganizationEmploymentAssociation FOREIGN KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationEmploymentAssociation (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSalary ADD CONSTRAINT FK_745d71_SalaryTypeDescriptor FOREIGN KEY (SalaryTypeDescriptorId)
REFERENCES tpdm.SalaryTypeDescriptor (SalaryTypeDescriptorId)
;

CREATE INDEX FK_745d71_SalaryTypeDescriptor
ON tpdm.StaffEducationOrganizationEmploymentAssociationSalary (SalaryTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSalary ADD CONSTRAINT FK_745d71_StaffEducationOrganizationEmploymentAssociation FOREIGN KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationEmploymentAssociation (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSeniority ADD CONSTRAINT FK_e937c7_CredentialFieldDescriptor FOREIGN KEY (CredentialFieldDescriptorId)
REFERENCES edfi.CredentialFieldDescriptor (CredentialFieldDescriptorId)
;

CREATE INDEX FK_e937c7_CredentialFieldDescriptor
ON tpdm.StaffEducationOrganizationEmploymentAssociationSeniority (CredentialFieldDescriptorId ASC);

ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSeniority ADD CONSTRAINT FK_e937c7_StaffEducationOrganizationEmploymentAssociation FOREIGN KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationEmploymentAssociation (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_e937c7_StaffEducationOrganizationEmploymentAssociation
ON tpdm.StaffEducationOrganizationEmploymentAssociationSeniority (EducationOrganizationId ASC, EmploymentStatusDescriptorId ASC, HireDate ASC, StaffUSI ASC);

ALTER TABLE tpdm.StaffEducatorPreparationProgram ADD CONSTRAINT FK_35a7ad_EducatorPreparationProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.EducatorPreparationProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_35a7ad_EducatorPreparationProgram
ON tpdm.StaffEducatorPreparationProgram (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffEducatorPreparationProgram ADD CONSTRAINT FK_35a7ad_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_35a7ad_Staff
ON tpdm.StaffEducatorPreparationProgram (StaffUSI ASC);

ALTER TABLE tpdm.StaffEducatorPreparationProgramAssociation ADD CONSTRAINT FK_2c9294_EducatorPreparationProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.EducatorPreparationProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_2c9294_EducatorPreparationProgram
ON tpdm.StaffEducatorPreparationProgramAssociation (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffEducatorPreparationProgramAssociation ADD CONSTRAINT FK_2c9294_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_2c9294_Staff
ON tpdm.StaffEducatorPreparationProgramAssociation (StaffUSI ASC);

ALTER TABLE tpdm.StaffEducatorResearch ADD CONSTRAINT FK_18b56d_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffExtension ADD CONSTRAINT FK_d7b81a_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_d7b81a_GenderDescriptor
ON tpdm.StaffExtension (GenderDescriptorId ASC);

ALTER TABLE tpdm.StaffExtension ADD CONSTRAINT FK_d7b81a_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
;

CREATE INDEX FK_d7b81a_OpenStaffPosition
ON tpdm.StaffExtension (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE tpdm.StaffExtension ADD CONSTRAINT FK_d7b81a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffHighlyQualifiedAcademicSubject ADD CONSTRAINT FK_37449d_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_37449d_AcademicSubjectDescriptor
ON tpdm.StaffHighlyQualifiedAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.StaffHighlyQualifiedAcademicSubject ADD CONSTRAINT FK_37449d_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_37449d_Staff
ON tpdm.StaffHighlyQualifiedAcademicSubject (StaffUSI ASC);

ALTER TABLE tpdm.StaffToCandidateRelationshipDescriptor ADD CONSTRAINT FK_6c9615_Descriptor FOREIGN KEY (StaffToCandidateRelationshipDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StateEducationAgencyExtension ADD CONSTRAINT FK_31f08a_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_31f08a_FederalLocaleCodeDescriptor
ON tpdm.StateEducationAgencyExtension (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.StateEducationAgencyExtension ADD CONSTRAINT FK_31f08a_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StudentGradebookEntryExtension ADD CONSTRAINT FK_c1d2f5_StudentGradebookEntry FOREIGN KEY (BeginDate, DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentGradebookEntry (BeginDate, DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE tpdm.SurveyResponseExtension ADD CONSTRAINT FK_fa906d_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_fa906d_Person
ON tpdm.SurveyResponseExtension (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.SurveyResponseExtension ADD CONSTRAINT FK_fa906d_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ADD CONSTRAINT FK_520027_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_520027_Person
ON tpdm.SurveyResponsePersonTargetAssociation (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ADD CONSTRAINT FK_520027_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

CREATE INDEX FK_520027_SurveyResponse
ON tpdm.SurveyResponsePersonTargetAssociation (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE tpdm.SurveySectionAggregateResponse ADD CONSTRAINT FK_f37ae9_EvaluationElementRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationElementRating (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_f37ae9_EvaluationElementRating
ON tpdm.SurveySectionAggregateResponse (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.SurveySectionAggregateResponse ADD CONSTRAINT FK_f37ae9_SurveySection FOREIGN KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySection (Namespace, SurveyIdentifier, SurveySectionTitle)
;

CREATE INDEX FK_f37ae9_SurveySection
ON tpdm.SurveySectionAggregateResponse (Namespace ASC, SurveyIdentifier ASC, SurveySectionTitle ASC);

ALTER TABLE tpdm.SurveySectionExtension ADD CONSTRAINT FK_a1b07d_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_a1b07d_EvaluationElement
ON tpdm.SurveySectionExtension (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.SurveySectionExtension ADD CONSTRAINT FK_a1b07d_SurveySection FOREIGN KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySection (Namespace, SurveyIdentifier, SurveySectionTitle)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ADD CONSTRAINT FK_e21e4b_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_e21e4b_Person
ON tpdm.SurveySectionResponsePersonTargetAssociation (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ADD CONSTRAINT FK_e21e4b_SurveySectionResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySectionResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
;

CREATE INDEX FK_e21e4b_SurveySectionResponse
ON tpdm.SurveySectionResponsePersonTargetAssociation (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC, SurveySectionTitle ASC);

ALTER TABLE tpdm.WithdrawReasonDescriptor ADD CONSTRAINT FK_8936a1_Descriptor FOREIGN KEY (WithdrawReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

