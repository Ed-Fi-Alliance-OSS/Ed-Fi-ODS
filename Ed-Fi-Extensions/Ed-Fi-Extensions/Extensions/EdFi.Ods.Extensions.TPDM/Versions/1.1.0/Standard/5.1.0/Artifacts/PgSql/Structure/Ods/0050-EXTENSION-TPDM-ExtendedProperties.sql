-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [tpdm].[AccreditationStatusDescriptor] --
COMMENT ON TABLE tpdm.AccreditationStatusDescriptor IS 'Accreditation Status for a Teacher Preparation Provider.';
COMMENT ON COLUMN tpdm.AccreditationStatusDescriptor.AccreditationStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[AidTypeDescriptor] --
COMMENT ON TABLE tpdm.AidTypeDescriptor IS 'This descriptor defines the classification of financial aid awarded to a person for the academic term/year.';
COMMENT ON COLUMN tpdm.AidTypeDescriptor.AidTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Candidate] --
COMMENT ON TABLE tpdm.Candidate IS 'A candidate is both a person enrolled in a educator preparation program and a candidate to become an educator.';
COMMENT ON COLUMN tpdm.Candidate.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.Candidate.BirthCity IS 'The city the student was born in.';
COMMENT ON COLUMN tpdm.Candidate.BirthCountryDescriptorId IS 'The country in which an individual is born. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN tpdm.Candidate.BirthDate IS 'The month, day, and year on which an individual was born.';
COMMENT ON COLUMN tpdm.Candidate.BirthInternationalProvince IS 'For students born outside of the U.S., the Province or jurisdiction in which an individual is born.';
COMMENT ON COLUMN tpdm.Candidate.BirthSexDescriptorId IS 'A person''s sex at birth.';
COMMENT ON COLUMN tpdm.Candidate.BirthStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.';
COMMENT ON COLUMN tpdm.Candidate.DateEnteredUS IS 'For students born outside of the U.S., the date the student entered the U.S.';
COMMENT ON COLUMN tpdm.Candidate.DisplacementStatus IS 'Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.';
COMMENT ON COLUMN tpdm.Candidate.EconomicDisadvantaged IS 'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.';
COMMENT ON COLUMN tpdm.Candidate.EnglishLanguageExamDescriptorId IS 'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).';
COMMENT ON COLUMN tpdm.Candidate.FirstGenerationStudent IS 'Indicator of whether individual is a first generation college student.';
COMMENT ON COLUMN tpdm.Candidate.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.Candidate.GenderDescriptorId IS 'The gender of the candidate.';
COMMENT ON COLUMN tpdm.Candidate.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN tpdm.Candidate.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."';
COMMENT ON COLUMN tpdm.Candidate.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.Candidate.LimitedEnglishProficiencyDescriptorId IS 'An indication that the student has been identified as limited English proficient by the Language Proficiency Assessment Committee (LPAC), or English proficient.';
COMMENT ON COLUMN tpdm.Candidate.MaidenName IS 'The individual''s maiden name.';
COMMENT ON COLUMN tpdm.Candidate.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.Candidate.MultipleBirthStatus IS 'Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)';
COMMENT ON COLUMN tpdm.Candidate.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the individual.';
COMMENT ON COLUMN tpdm.Candidate.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.Candidate.PreferredFirstName IS 'The first name the individual prefers, if different from their legal first name';
COMMENT ON COLUMN tpdm.Candidate.PreferredLastSurname IS 'The last name the individual prefers, if different from their legal last name';
COMMENT ON COLUMN tpdm.Candidate.SexDescriptorId IS 'The sex of the candidate.';
COMMENT ON COLUMN tpdm.Candidate.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[CandidateAddress] --
COMMENT ON TABLE tpdm.CandidateAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN tpdm.CandidateAddress.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.CandidateAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.CandidateAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.CandidateAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN tpdm.CandidateAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN tpdm.CandidateAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN tpdm.CandidateAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN tpdm.CandidateAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.CandidateAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';
COMMENT ON COLUMN tpdm.CandidateAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.CandidateAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in which an address is located.';

-- Extended Properties [tpdm].[CandidateAddressPeriod] --
COMMENT ON TABLE tpdm.CandidateAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [tpdm].[CandidateDisability] --
COMMENT ON TABLE tpdm.CandidateDisability IS 'The disability condition(s) that best describes an individual''s impairment.';
COMMENT ON COLUMN tpdm.CandidateDisability.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateDisability.DisabilityDescriptorId IS 'A disability category that describes a individual''s impairment.';
COMMENT ON COLUMN tpdm.CandidateDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';
COMMENT ON COLUMN tpdm.CandidateDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN tpdm.CandidateDisability.OrderOfDisability IS 'The order by severity of individual''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';

-- Extended Properties [tpdm].[CandidateDisabilityDesignation] --
COMMENT ON TABLE tpdm.CandidateDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.CandidateDisabilityDesignation.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a individual''s impairment.';
COMMENT ON COLUMN tpdm.CandidateDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociation] --
COMMENT ON TABLE tpdm.CandidateEducatorPreparationProgramAssociation IS 'Information about the association between the Teacher Candidate and the EducatorPreparationProgram';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.BeginDate IS 'The begin date for the association.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.EndDate IS 'The end date for the association.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.EPPProgramPathwayDescriptorId IS 'The program pathway the candidate is following; for example: Residency, Internship, Traditional';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.ReasonExitedDescriptorId IS 'Reason exited for the association.';

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] --
COMMENT ON TABLE tpdm.CandidateEducatorPreparationProgramAssociationCohortYear IS 'The type and year of a cohort the student belongs to as determined by the year that student entered a specific grade.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear.BeginDate IS 'The begin date for the association.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear.CohortYearTypeDescriptorId IS 'The type of cohort year (9th grade, graduation).';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear.SchoolYear IS 'The school year associated with the cohort; for example, the intended school year of graduation.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear.TermDescriptorId IS 'The term associated with the cohort year; for example, the intended term of graduation.';

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4] --
COMMENT ON TABLE tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4 IS 'Information around the area(s) of specialization for an individual.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4.BeginDate IS 'The begin date for the association.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4.MajorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4.EndDate IS 'The month, day, and year on which the Teacher Candidate exited the declared specialization.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4.MinorSpecialization IS 'The minor area for a degree or area of specialization for a certificate.';

-- Extended Properties [tpdm].[CandidateElectronicMail] --
COMMENT ON TABLE tpdm.CandidateElectronicMail IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.ElectronicMailAddress IS 'The electronic mail (e-mail) address listed for an individual or organization.';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.ElectronicMailTypeDescriptorId IS 'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.DoNotPublishIndicator IS 'An indication that the electronic email address should not be published.';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.PrimaryEmailAddressIndicator IS 'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.';

-- Extended Properties [tpdm].[CandidateLanguage] --
COMMENT ON TABLE tpdm.CandidateLanguage IS 'The language(s) the individual uses to communicate.';
COMMENT ON COLUMN tpdm.CandidateLanguage.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';

-- Extended Properties [tpdm].[CandidateLanguageUse] --
COMMENT ON TABLE tpdm.CandidateLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN tpdm.CandidateLanguageUse.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN tpdm.CandidateLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';

-- Extended Properties [tpdm].[CandidateOtherName] --
COMMENT ON TABLE tpdm.CandidateOtherName IS 'Other names (e.g., alias, nickname, previous legal name) associated with a person.';
COMMENT ON COLUMN tpdm.CandidateOtherName.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateOtherName.OtherNameTypeDescriptorId IS 'The types of alternate names for an individual.';
COMMENT ON COLUMN tpdm.CandidateOtherName.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.CandidateOtherName.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN tpdm.CandidateOtherName.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.CandidateOtherName.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.CandidateOtherName.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the individual.';

-- Extended Properties [tpdm].[CandidatePersonalIdentificationDocument] --
COMMENT ON TABLE tpdm.CandidatePersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';

-- Extended Properties [tpdm].[CandidateRace] --
COMMENT ON TABLE tpdm.CandidateRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.CandidateRace.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.';

-- Extended Properties [tpdm].[CandidateTelephone] --
COMMENT ON TABLE tpdm.CandidateTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN tpdm.CandidateTelephone.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN tpdm.CandidateTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN tpdm.CandidateTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';
COMMENT ON COLUMN tpdm.CandidateTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN tpdm.CandidateTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';

-- Extended Properties [tpdm].[CertificationRouteDescriptor] --
COMMENT ON TABLE tpdm.CertificationRouteDescriptor IS 'The process, program, or pathway used to obtain a certification.';
COMMENT ON COLUMN tpdm.CertificationRouteDescriptor.CertificationRouteDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CoteachingStyleObservedDescriptor] --
COMMENT ON TABLE tpdm.CoteachingStyleObservedDescriptor IS 'A type of co-teaching observed as part of the performance evaluation.';
COMMENT ON COLUMN tpdm.CoteachingStyleObservedDescriptor.CoteachingStyleObservedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CredentialExtension] --
COMMENT ON TABLE tpdm.CredentialExtension IS '';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN tpdm.CredentialExtension.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN tpdm.CredentialExtension.BoardCertificationIndicator IS 'Indicator that the credential was granted under the authority of a national Board Certification.';
COMMENT ON COLUMN tpdm.CredentialExtension.CertificationRouteDescriptorId IS 'The process, program, or pathway used to obtain certification.';
COMMENT ON COLUMN tpdm.CredentialExtension.CertificationTitle IS 'The title of the certification obtained by the educator.';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialStatusDate IS 'The month, day, and year on which the credential status was effective.';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialStatusDescriptorId IS 'The current status of the credential (e.g., active, suspended, etc.).';
COMMENT ON COLUMN tpdm.CredentialExtension.EducatorRoleDescriptorId IS 'The specific roles or positions within an organization that the credential is intended to authorize (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.';
COMMENT ON COLUMN tpdm.CredentialExtension.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.CredentialExtension.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[CredentialStatusDescriptor] --
COMMENT ON TABLE tpdm.CredentialStatusDescriptor IS 'The current status of the credential.';
COMMENT ON COLUMN tpdm.CredentialStatusDescriptor.CredentialStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CredentialStudentAcademicRecord] --
COMMENT ON TABLE tpdm.CredentialStudentAcademicRecord IS 'Reference to the person''s Student Academic Records for the school(s) with which the Credential is associated.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[EducatorPreparationProgram] --
COMMENT ON TABLE tpdm.EducatorPreparationProgram IS 'The Educator Preparation Program is designed to prepare students to become licensed educators.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.AccreditationStatusDescriptorId IS 'The current accreditation status of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.ProgramId IS 'A unique number or alphanumeric code assigned to a program by a school, school system, a state, or other agency or entity.';

-- Extended Properties [tpdm].[EducatorPreparationProgramGradeLevel] --
COMMENT ON TABLE tpdm.EducatorPreparationProgramGradeLevel IS 'The grade levels served at the EPP Program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramGradeLevel.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramGradeLevel.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramGradeLevel.GradeLevelDescriptorId IS 'The grade levels served at the EPP Program.';

-- Extended Properties [tpdm].[EducatorRoleDescriptor] --
COMMENT ON TABLE tpdm.EducatorRoleDescriptor IS 'The role authorized by the Credential or Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.';
COMMENT ON COLUMN tpdm.EducatorRoleDescriptor.EducatorRoleDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EnglishLanguageExamDescriptor] --
COMMENT ON TABLE tpdm.EnglishLanguageExamDescriptor IS 'Indicates that a person passed, failed, or did not take an English Language assessment.';
COMMENT ON COLUMN tpdm.EnglishLanguageExamDescriptor.EnglishLanguageExamDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EPPProgramPathwayDescriptor] --
COMMENT ON TABLE tpdm.EPPProgramPathwayDescriptor IS 'The description of the program pathway, for example: Residency, Internship, Traditional';
COMMENT ON COLUMN tpdm.EPPProgramPathwayDescriptor.EPPProgramPathwayDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Evaluation] --
COMMENT ON TABLE tpdm.Evaluation IS 'An evaluation instrument appled to evaluate an educator.  The evaluation could be internally developed, or could be an industry recognized instrument such as TTESS or Marzano.';
COMMENT ON COLUMN tpdm.Evaluation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.Evaluation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.Evaluation.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationDescription IS 'The long description of the Evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationTypeDescriptorId IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';
COMMENT ON COLUMN tpdm.Evaluation.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges. Most commonly a percentage scale (1-100)';
COMMENT ON COLUMN tpdm.Evaluation.MaxRating IS 'The maximum summary numerical rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.MinRating IS 'The minimum summary numerical rating or score for the evaluation. If omitted, assumed to be 0.0.';

-- Extended Properties [tpdm].[EvaluationElement] --
COMMENT ON TABLE tpdm.EvaluationElement IS 'The lowest-level Elements or criterion of performance being evaluated by rubric, quantitative measure, or aggregate survey response.';
COMMENT ON COLUMN tpdm.EvaluationElement.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElement.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElement.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElement.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElement.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationTypeDescriptorId IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';
COMMENT ON COLUMN tpdm.EvaluationElement.MaxRating IS 'The maximum summary numerical rating or score for the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElement.MinRating IS 'The minimum summary numerical rating or score for the evaluation element. If omitted, assumed to be 0.0.';
COMMENT ON COLUMN tpdm.EvaluationElement.SortOrder IS 'The sort order of this Evaluation Element.';

-- Extended Properties [tpdm].[EvaluationElementRating] --
COMMENT ON TABLE tpdm.EvaluationElementRating IS 'The lowest-level rating for an Evaluation Element for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.AreaOfRefinement IS 'Area identified for person to refine or improve as part of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.AreaOfReinforcement IS 'Area identified for reinforcement or positive feedback as part of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.Comments IS 'Any comments about the performance evaluation to be captured.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationElementRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.Feedback IS 'Feedback provided to the evaluated person.';

-- Extended Properties [tpdm].[EvaluationElementRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationElementRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationElementRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.EvaluationElementRatingLevelDescriptor IS 'Rating levels for Evaluation Elements.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevelDescriptor.EvaluationElementRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationElementRatingResult] --
COMMENT ON TABLE tpdm.EvaluationElementRatingResult IS 'The numerical summary rating or score for the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result.';

-- Extended Properties [tpdm].[EvaluationObjective] --
COMMENT ON TABLE tpdm.EvaluationObjective IS 'A subcomponent of an Evaluation, a specific educator Objective or domain of performance that is being evaluated.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjective.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjective.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjective.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjective.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationObjectiveDescription IS 'The long description of the Evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationTypeDescriptorId IS 'The type of the evaluation Objective (e.g., observation, principal, peer, student survey, student growth).';
COMMENT ON COLUMN tpdm.EvaluationObjective.MaxRating IS 'The maximum summary numerical rating or score for the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.MinRating IS 'The minimum summary numerical rating or score for the evaluation Objective. If omitted, assumed to be 0.0.';
COMMENT ON COLUMN tpdm.EvaluationObjective.SortOrder IS 'The sort order of this Evaluation Objective.';

-- Extended Properties [tpdm].[EvaluationObjectiveRating] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRating IS 'The rating for the component Evaluation Objective for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.Comments IS 'Any comments about the performance evaluation to be captured.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.ObjectiveRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';

-- Extended Properties [tpdm].[EvaluationObjectiveRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationObjectiveRatingResult] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRatingResult IS 'The numerical summary rating or score for the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result.';

-- Extended Properties [tpdm].[EvaluationPeriodDescriptor] --
COMMENT ON TABLE tpdm.EvaluationPeriodDescriptor IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationPeriodDescriptor.EvaluationPeriodDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationRating] --
COMMENT ON TABLE tpdm.EvaluationRating IS 'The summary weighting for the Evaluation instrument for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationRatingStatusDescriptorId IS 'The Status of the poerformance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.EvaluationRating.SchoolId IS 'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';
COMMENT ON COLUMN tpdm.EvaluationRating.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.EvaluationRating.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [tpdm].[EvaluationRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.EvaluationRatingLevelDescriptor IS 'Rating levels for Evaluations.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevelDescriptor.EvaluationRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationRatingResult] --
COMMENT ON TABLE tpdm.EvaluationRatingResult IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result.';

-- Extended Properties [tpdm].[EvaluationRatingReviewer] --
COMMENT ON TABLE tpdm.EvaluationRatingReviewer IS 'The person(s) that conducted the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.ReviewerPersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.ReviewerSourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[EvaluationRatingReviewerReceivedTraining] --
COMMENT ON TABLE tpdm.EvaluationRatingReviewerReceivedTraining IS 'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges. Most commonly a percentage scale (1-100)';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.ReceivedTrainingDate IS 'The date on which the person administering the performance meausre received training on how to conduct performance measures.';

-- Extended Properties [tpdm].[EvaluationRatingStatusDescriptor] --
COMMENT ON TABLE tpdm.EvaluationRatingStatusDescriptor IS 'Represents the status of a Evaluation Rating.';
COMMENT ON COLUMN tpdm.EvaluationRatingStatusDescriptor.EvaluationRatingStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationTypeDescriptor] --
COMMENT ON TABLE tpdm.EvaluationTypeDescriptor IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';
COMMENT ON COLUMN tpdm.EvaluationTypeDescriptor.EvaluationTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[FinancialAid] --
COMMENT ON TABLE tpdm.FinancialAid IS 'This entity represents the financial aid a person is awarded.';
COMMENT ON COLUMN tpdm.FinancialAid.AidTypeDescriptorId IS 'The classification of financial aid awarded to a person for the academic term/year.';
COMMENT ON COLUMN tpdm.FinancialAid.BeginDate IS 'The date the award was designated.';
COMMENT ON COLUMN tpdm.FinancialAid.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.FinancialAid.AidAmount IS 'The amount of financial aid awarded to a person for the term/year.';
COMMENT ON COLUMN tpdm.FinancialAid.AidConditionDescription IS 'The description of the condition (e.g., placement in a high need school) under which the aid was given.';
COMMENT ON COLUMN tpdm.FinancialAid.EndDate IS 'The date the award was removed.';
COMMENT ON COLUMN tpdm.FinancialAid.PellGrantRecipient IS 'Indicates a person who receives Pell Grant aid.';

-- Extended Properties [tpdm].[GenderDescriptor] --
COMMENT ON TABLE tpdm.GenderDescriptor IS 'A person''s gender.';
COMMENT ON COLUMN tpdm.GenderDescriptor.GenderDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ObjectiveRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.ObjectiveRatingLevelDescriptor IS 'Rating levels for Evaluation Objectives.';
COMMENT ON COLUMN tpdm.ObjectiveRatingLevelDescriptor.ObjectiveRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[PerformanceEvaluation] --
COMMENT ON TABLE tpdm.PerformanceEvaluation IS 'A performance evaluation of an educator, typically regularly scheduled and uniformly applied, composed of one or more Evaluations.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.AcademicSubjectDescriptorId IS 'The description of the content or subject area of a performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.PerformanceEvaluationDescription IS 'The long description of the Performance Evaluation.';

-- Extended Properties [tpdm].[PerformanceEvaluationGradeLevel] --
COMMENT ON TABLE tpdm.PerformanceEvaluationGradeLevel IS 'The grade levels involved with the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.GradeLevelDescriptorId IS 'The grade levels involved with the performance evaluation.';

-- Extended Properties [tpdm].[PerformanceEvaluationRating] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRating IS 'The summary rating for a Performance Evaluation across all Evaluation instruments for an individual educator.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualDate IS 'The month, day, and year on which the performance evaluation was conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualDuration IS 'The actual or estimated number of clock minutes during which the performance evaluation was conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualTime IS 'An indication of the the time at which the performance evaluation was conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.Announced IS 'An indicator of whether the performance evaluation was announced or not.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.Comments IS 'Any comments about the performance evaluation to be captured.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.CoteachingStyleObservedDescriptorId IS 'A type of co-teaching observed as part of the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ScheduleDate IS 'The month, day, and year on which the performance evaluation was scheduled.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevel] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingLevelDescriptor IS 'Rating levels for Performance Evaluations.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevelDescriptor.PerformanceEvaluationRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingResult] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingResult IS 'The numerical summary rating or score for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewer] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingReviewer IS 'The person(s) that conducted the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.ReviewerPersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.ReviewerSourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingReviewerReceivedTraining IS 'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges. Most commonly a percentage scale (1-100)';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.ReceivedTrainingDate IS 'The date on which the person administering the performance meausre received training on how to conduct performance measures.';

-- Extended Properties [tpdm].[PerformanceEvaluationTypeDescriptor] --
COMMENT ON TABLE tpdm.PerformanceEvaluationTypeDescriptor IS 'The type of performance evaluation conducted (e.g., walkthrough, summative).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationTypeDescriptor.PerformanceEvaluationTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[RubricDimension] --
COMMENT ON TABLE tpdm.RubricDimension IS 'The cells of a rubric, consisting of a qualitative decription, definition, or exemplar with the associated rubric rating and rating level.';
COMMENT ON COLUMN tpdm.RubricDimension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationPeriodDescriptorId IS 'The period for the evaluation.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.RubricDimension.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.RubricDimension.PerformanceEvaluationTypeDescriptorId IS 'The type of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.RubricDimension.RubricRating IS 'The rating achieved for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.RubricDimension.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.RubricDimension.CriterionDescription IS 'The criterion description for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.DimensionOrder IS 'The order for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.RubricRatingLevelDescriptorId IS 'The rating level achieved for the rubric dimension.';

-- Extended Properties [tpdm].[RubricRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.RubricRatingLevelDescriptor IS 'Rating levels for Rubric Dimensions.';
COMMENT ON COLUMN tpdm.RubricRatingLevelDescriptor.RubricRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[SchoolExtension] --
COMMENT ON TABLE tpdm.SchoolExtension IS '';
COMMENT ON COLUMN tpdm.SchoolExtension.SchoolId IS 'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';
COMMENT ON COLUMN tpdm.SchoolExtension.PostSecondaryInstitutionId IS 'The ID of the post secondary institution. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';

-- Extended Properties [tpdm].[SurveyResponseExtension] --
COMMENT ON TABLE tpdm.SurveyResponseExtension IS '';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[SurveyResponsePersonTargetAssociation] --
COMMENT ON TABLE tpdm.SurveyResponsePersonTargetAssociation IS 'The association provides information about the survey being taken and who the survey is about.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';

-- Extended Properties [tpdm].[SurveySectionResponsePersonTargetAssociation] --
COMMENT ON TABLE tpdm.SurveySectionResponsePersonTargetAssociation IS 'This association provides information about the survey section and the person the survey section is about.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.SurveySectionTitle IS 'The title or label for the survey section.';

