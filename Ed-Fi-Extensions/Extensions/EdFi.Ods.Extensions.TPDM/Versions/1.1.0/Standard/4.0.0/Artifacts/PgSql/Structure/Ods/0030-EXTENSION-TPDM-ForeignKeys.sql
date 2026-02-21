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

ALTER TABLE tpdm.Candidate ADD CONSTRAINT FK_b2452d_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_b2452d_Person
ON tpdm.Candidate (PersonId ASC, SourceSystemDescriptorId ASC);

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

ALTER TABLE tpdm.CandidateAddressPeriod ADD CONSTRAINT FK_17e793_CandidateAddress FOREIGN KEY (CandidateIdentifier, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES tpdm.CandidateAddress (CandidateIdentifier, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateDisability ADD CONSTRAINT FK_236ee4_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

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

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationCohortYear ADD CONSTRAINT FK_620d03_CandidateEducatorPreparationProgramAssociation FOREIGN KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.CandidateEducatorPreparationProgramAssociation (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationCohortYear ADD CONSTRAINT FK_620d03_CohortYearTypeDescriptor FOREIGN KEY (CohortYearTypeDescriptorId)
REFERENCES edfi.CohortYearTypeDescriptor (CohortYearTypeDescriptorId)
;

CREATE INDEX FK_620d03_CohortYearTypeDescriptor
ON tpdm.CandidateEducatorPreparationProgramAssociationCohortYear (CohortYearTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationCohortYear ADD CONSTRAINT FK_620d03_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_620d03_SchoolYearType
ON tpdm.CandidateEducatorPreparationProgramAssociationCohortYear (SchoolYear ASC);

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationCohortYear ADD CONSTRAINT FK_620d03_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_620d03_TermDescriptor
ON tpdm.CandidateEducatorPreparationProgramAssociationCohortYear (TermDescriptorId ASC);

ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4 ADD CONSTRAINT FK_2501c4_CandidateEducatorPreparationProgramAssociation FOREIGN KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.CandidateEducatorPreparationProgramAssociation (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateElectronicMail ADD CONSTRAINT FK_c5124f_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateElectronicMail ADD CONSTRAINT FK_c5124f_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

CREATE INDEX FK_c5124f_ElectronicMailTypeDescriptor
ON tpdm.CandidateElectronicMail (ElectronicMailTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidateLanguage ADD CONSTRAINT FK_e5239b_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateLanguage ADD CONSTRAINT FK_e5239b_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_e5239b_LanguageDescriptor
ON tpdm.CandidateLanguage (LanguageDescriptorId ASC);

ALTER TABLE tpdm.CandidateLanguageUse ADD CONSTRAINT FK_3f00b1_CandidateLanguage FOREIGN KEY (CandidateIdentifier, LanguageDescriptorId)
REFERENCES tpdm.CandidateLanguage (CandidateIdentifier, LanguageDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateLanguageUse ADD CONSTRAINT FK_3f00b1_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_3f00b1_LanguageUseDescriptor
ON tpdm.CandidateLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE tpdm.CandidateOtherName ADD CONSTRAINT FK_4521bb_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateOtherName ADD CONSTRAINT FK_4521bb_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

CREATE INDEX FK_4521bb_OtherNameTypeDescriptor
ON tpdm.CandidateOtherName (OtherNameTypeDescriptorId ASC);

ALTER TABLE tpdm.CandidatePersonalIdentificationDocument ADD CONSTRAINT FK_93a227_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

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

ALTER TABLE tpdm.CandidateRace ADD CONSTRAINT FK_6aa942_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_6aa942_RaceDescriptor
ON tpdm.CandidateRace (RaceDescriptorId ASC);

ALTER TABLE tpdm.CandidateTelephone ADD CONSTRAINT FK_09c531_Candidate FOREIGN KEY (CandidateIdentifier)
REFERENCES tpdm.Candidate (CandidateIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CandidateTelephone ADD CONSTRAINT FK_09c531_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_09c531_TelephoneNumberTypeDescriptor
ON tpdm.CandidateTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE tpdm.CertificationRouteDescriptor ADD CONSTRAINT FK_40b601_Descriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CoteachingStyleObservedDescriptor ADD CONSTRAINT FK_932c9a_Descriptor FOREIGN KEY (CoteachingStyleObservedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

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

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_EducatorRoleDescriptor FOREIGN KEY (EducatorRoleDescriptorId)
REFERENCES tpdm.EducatorRoleDescriptor (EducatorRoleDescriptorId)
;

CREATE INDEX FK_6fae52_EducatorRoleDescriptor
ON tpdm.CredentialExtension (EducatorRoleDescriptorId ASC);

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

ALTER TABLE tpdm.CredentialStudentAcademicRecord ADD CONSTRAINT FK_73e151_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
;

CREATE INDEX FK_73e151_StudentAcademicRecord
ON tpdm.CredentialStudentAcademicRecord (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EducatorPreparationProgram ADD CONSTRAINT FK_195935_AccreditationStatusDescriptor FOREIGN KEY (AccreditationStatusDescriptorId)
REFERENCES tpdm.AccreditationStatusDescriptor (AccreditationStatusDescriptorId)
;

CREATE INDEX FK_195935_AccreditationStatusDescriptor
ON tpdm.EducatorPreparationProgram (AccreditationStatusDescriptorId ASC);

ALTER TABLE tpdm.EducatorPreparationProgram ADD CONSTRAINT FK_195935_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

ALTER TABLE tpdm.EducatorPreparationProgram ADD CONSTRAINT FK_195935_ProgramTypeDescriptor FOREIGN KEY (ProgramTypeDescriptorId)
REFERENCES edfi.ProgramTypeDescriptor (ProgramTypeDescriptorId)
;

CREATE INDEX FK_195935_ProgramTypeDescriptor
ON tpdm.EducatorPreparationProgram (ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.EducatorPreparationProgramGradeLevel ADD CONSTRAINT FK_d3a222_EducatorPreparationProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.EducatorPreparationProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EducatorPreparationProgramGradeLevel ADD CONSTRAINT FK_d3a222_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_d3a222_GradeLevelDescriptor
ON tpdm.EducatorPreparationProgramGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.EducatorRoleDescriptor ADD CONSTRAINT FK_bc8b94_Descriptor FOREIGN KEY (EducatorRoleDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EnglishLanguageExamDescriptor ADD CONSTRAINT FK_76d6e8_Descriptor FOREIGN KEY (EnglishLanguageExamDescriptorId)
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

ALTER TABLE tpdm.EvaluationObjectiveRatingLevel ADD CONSTRAINT FK_1d984c_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_1d984c_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationObjectiveRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingResult ADD CONSTRAINT FK_beeccb_EvaluationObjectiveRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationObjectiveRating (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

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

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_EvaluationRatingStatusDescriptor FOREIGN KEY (EvaluationRatingStatusDescriptorId)
REFERENCES tpdm.EvaluationRatingStatusDescriptor (EvaluationRatingStatusDescriptorId)
;

CREATE INDEX FK_bfaa20_EvaluationRatingStatusDescriptor
ON tpdm.EvaluationRating (EvaluationRatingStatusDescriptorId ASC);

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

ALTER TABLE tpdm.EvaluationRatingResult ADD CONSTRAINT FK_268283_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_268283_ResultDatatypeTypeDescriptor
ON tpdm.EvaluationRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingReviewer ADD CONSTRAINT FK_2d29eb_EvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRating (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationRatingReviewer ADD CONSTRAINT FK_2d29eb_Person FOREIGN KEY (ReviewerPersonId, ReviewerSourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_2d29eb_Person
ON tpdm.EvaluationRatingReviewer (ReviewerPersonId ASC, ReviewerSourceSystemDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingReviewerReceivedTraining ADD CONSTRAINT FK_608112_EvaluationRatingReviewer FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, FirstName, LastSurname)
REFERENCES tpdm.EvaluationRatingReviewer (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, FirstName, LastSurname)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationRatingStatusDescriptor ADD CONSTRAINT FK_4b53ea_Descriptor FOREIGN KEY (EvaluationRatingStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationTypeDescriptor ADD CONSTRAINT FK_67cd19_Descriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FinancialAid ADD CONSTRAINT FK_a465f2_AidTypeDescriptor FOREIGN KEY (AidTypeDescriptorId)
REFERENCES tpdm.AidTypeDescriptor (AidTypeDescriptorId)
;

CREATE INDEX FK_a465f2_AidTypeDescriptor
ON tpdm.FinancialAid (AidTypeDescriptorId ASC);

ALTER TABLE tpdm.FinancialAid ADD CONSTRAINT FK_a465f2_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

ALTER TABLE tpdm.GenderDescriptor ADD CONSTRAINT FK_554e4f_Descriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ObjectiveRatingLevelDescriptor ADD CONSTRAINT FK_d49b1f_Descriptor FOREIGN KEY (ObjectiveRatingLevelDescriptorId)
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

ALTER TABLE tpdm.PerformanceEvaluationRatingLevelDescriptor ADD CONSTRAINT FK_ed7e01_Descriptor FOREIGN KEY (PerformanceEvaluationRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluationRatingResult ADD CONSTRAINT FK_863fa4_PerformanceEvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRating (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluationRatingResult ADD CONSTRAINT FK_863fa4_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_863fa4_ResultDatatypeTypeDescriptor
ON tpdm.PerformanceEvaluationRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewer ADD CONSTRAINT FK_477526_PerformanceEvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRating (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewer ADD CONSTRAINT FK_477526_Person FOREIGN KEY (ReviewerPersonId, ReviewerSourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_477526_Person
ON tpdm.PerformanceEvaluationRatingReviewer (ReviewerPersonId ASC, ReviewerSourceSystemDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewerReceivedTraining ADD CONSTRAINT FK_6e6517_PerformanceEvaluationRatingReviewer FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, FirstName, LastSurname)
REFERENCES tpdm.PerformanceEvaluationRatingReviewer (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, FirstName, LastSurname)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluationTypeDescriptor ADD CONSTRAINT FK_2ba831_Descriptor FOREIGN KEY (PerformanceEvaluationTypeDescriptorId)
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

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_PostSecondaryInstitution FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.PostSecondaryInstitution (PostSecondaryInstitutionId)
;

CREATE INDEX FK_2199be_PostSecondaryInstitution
ON tpdm.SchoolExtension (PostSecondaryInstitutionId ASC);

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
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

