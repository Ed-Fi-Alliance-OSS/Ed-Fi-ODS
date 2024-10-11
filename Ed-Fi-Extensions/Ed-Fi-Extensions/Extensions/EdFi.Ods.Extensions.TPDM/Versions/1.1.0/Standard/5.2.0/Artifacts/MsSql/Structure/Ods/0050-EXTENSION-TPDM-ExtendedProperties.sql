-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [tpdm].[AccreditationStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Accreditation Status for a Teacher Preparation Provider.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AccreditationStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AccreditationStatusDescriptor', @level2type=N'COLUMN', @level2name=N'AccreditationStatusDescriptorId'
GO

-- Extended Properties [tpdm].[AidTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the classification of financial aid awarded to a person for the academic term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AidTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AidTypeDescriptor', @level2type=N'COLUMN', @level2name=N'AidTypeDescriptorId'
GO

-- Extended Properties [tpdm].[Candidate] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A candidate is both a person enrolled in a educator preparation program and a candidate to become an educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The city the student was born in.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The country in which an individual is born. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthCountryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For students born outside of the U.S., the Province or jurisdiction in which an individual is born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthInternationalProvince'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s sex at birth.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthSexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For students born outside of the U.S., the date the student entered the U.S.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'DateEnteredUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'DisplacementStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'EconomicDisadvantaged'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'EnglishLanguageExamDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether individual is a first generation college student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'FirstGenerationStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender of the candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'HispanicLatinoEthnicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the student has been identified as limited English proficient by the Language Proficiency Assessment Committee (LPAC), or English proficient.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'LimitedEnglishProficiencyDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The individual''s maiden name.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'MaidenName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'MultipleBirthStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first name the individual prefers, if different from their legal first name', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'PreferredFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last name the individual prefers, if different from their legal last name', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'PreferredLastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sex of the candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'SexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The apartment, room, or suite number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'ApartmentRoomSuiteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of the building on the site, if more than one building shares the same address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'BuildingSiteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The congressional district in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'CongressionalDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'CountyFIPSCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'LocaleDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county, parish, borough, or comparable unit (within a state) in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'NameOfCounty'
GO

-- Extended Properties [tpdm].[CandidateAddressPeriod] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[CandidateDisability] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability condition(s) that best describes an individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source that provided the disability determination.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDeterminationSourceTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the disability diagnosis.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDiagnosis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order by severity of individual''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'OrderOfDisability'
GO

-- Extended Properties [tpdm].[CandidateDisabilityDesignation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisabilityDesignation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDesignationDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the association between the Teacher Candidate and the EducatorPreparationProgram', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The begin date for the association.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The program pathway the candidate is following; for example: Residency, Internship, Traditional', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EPPProgramPathwayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reason exited for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ReasonExitedDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociationCohortYear] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type and year of a cohort the student belongs to as determined by the year that student entered a specific grade.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The begin date for the association.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of cohort year (9th grade, graduation).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear', @level2type=N'COLUMN', @level2name=N'CohortYearTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year associated with the cohort; for example, the intended school year of graduation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term associated with the cohort year; for example, the intended term of graduation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCohortYear', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociationDegreeSpecialization] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information around the area(s) of specialization for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The begin date for the association.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The major area for a degree or area of specialization for a certificate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'MajorSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the Teacher Candidate exited the declared specialization.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minor area for a degree or area of specialization for a certificate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'MinorSpecialization'
GO

-- Extended Properties [tpdm].[CandidateElectronicMail] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateElectronicMail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The electronic mail (e-mail) address listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'ElectronicMailAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'ElectronicMailTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic email address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'PrimaryEmailAddressIndicator'
GO

-- Extended Properties [tpdm].[CandidateLanguage] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The language(s) the individual uses to communicate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateLanguage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateLanguage', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateLanguage', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateLanguageUse] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateLanguageUse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateLanguageUse', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageUseDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateOtherName] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Other names (e.g., alias, nickname, previous legal name) associated with a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The types of alternate names for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'OtherNameTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO

-- Extended Properties [tpdm].[CandidatePersonalIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO

-- Extended Properties [tpdm].[CandidateRace] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRace', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRace', @level2type=N'COLUMN', @level2name=N'RaceDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The 10-digit telephone number, including the area code, for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO

-- Extended Properties [tpdm].[CertificationRouteDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program, or pathway used to obtain a certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRouteDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRouteDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO

-- Extended Properties [tpdm].[CoteachingStyleObservedDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A type of co-teaching observed as part of the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CoteachingStyleObservedDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CoteachingStyleObservedDescriptor', @level2type=N'COLUMN', @level2name=N'CoteachingStyleObservedDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'StateOfIssueStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the credential was granted under the authority of a national Board Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'BoardCertificationIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program, or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the certification obtained by the educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CertificationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the credential status was effective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialStatusDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current status of the credential (e.g., active, suspended, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The specific roles or positions within an organization that the credential is intended to authorize (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'EducatorRoleDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current status of the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStatusDescriptor', @level2type=N'COLUMN', @level2name=N'CredentialStatusDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialStudentAcademicRecord] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reference to the person''s Student Academic Records for the school(s) with which the Credential is associated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'CredentialIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'StateOfIssueStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorPreparationProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Educator Preparation Program is designed to prepare students to become licensed educators.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current accreditation status of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'AccreditationStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to a program by a school, school system, a state, or other agency or entity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramId'
GO

-- Extended Properties [tpdm].[EducatorPreparationProgramGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels served at the EPP Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels served at the EPP Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorRoleDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The role authorized by the Credential or Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorRoleDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorRoleDescriptor', @level2type=N'COLUMN', @level2name=N'EducatorRoleDescriptorId'
GO

-- Extended Properties [tpdm].[EnglishLanguageExamDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person passed, failed, or did not take an English Language assessment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EnglishLanguageExamDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EnglishLanguageExamDescriptor', @level2type=N'COLUMN', @level2name=N'EnglishLanguageExamDescriptorId'
GO

-- Extended Properties [tpdm].[EPPProgramPathwayDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the program pathway, for example: Residency, Internship, Traditional', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EPPProgramPathwayDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EPPProgramPathwayDescriptor', @level2type=N'COLUMN', @level2name=N'EPPProgramPathwayDescriptorId'
GO

-- Extended Properties [tpdm].[Evaluation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An evaluation instrument appled to evaluate an educator.  The evaluation could be internally developed, or could be an industry recognized instrument such as TTESS or Marzano.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The long description of the Evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges. Most commonly a percentage scale (1-100)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'MinRating'
GO

-- Extended Properties [tpdm].[EvaluationElement] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The lowest-level Elements or criterion of performance being evaluated by rubric, quantitative measure, or aggregate survey response.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation element. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sort order of this Evaluation Element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'SortOrder'
GO

-- Extended Properties [tpdm].[EvaluationElementRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The lowest-level rating for an Evaluation Element for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Area identified for person to refine or improve as part of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'AreaOfRefinement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Area identified for reinforcement or positive feedback as part of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'AreaOfReinforcement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationElementRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feedback provided to the evaluated person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'Feedback'
GO

-- Extended Properties [tpdm].[EvaluationElementRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO

-- Extended Properties [tpdm].[EvaluationElementRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rating levels for Evaluation Elements.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationElementRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationElementRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationObjective] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A subcomponent of an Evaluation, a specific educator Objective or domain of performance that is being evaluated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The long description of the Evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation Objective (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation Objective. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sort order of this Evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'SortOrder'
GO

-- Extended Properties [tpdm].[EvaluationObjectiveRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating for the component Evaluation Objective for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'ObjectiveRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationObjectiveRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO

-- Extended Properties [tpdm].[EvaluationObjectiveRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationPeriodDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationPeriodDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationPeriodDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The summary weighting for the Evaluation instrument for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual or estimated number of clock minutes during which the evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Status of the poerformance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationRatingStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SessionName'
GO

-- Extended Properties [tpdm].[EvaluationRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO

-- Extended Properties [tpdm].[EvaluationRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rating levels for Evaluations.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRatingReviewer] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person(s) that conducted the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'ReviewerPersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'ReviewerSourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRatingReviewerReceivedTraining] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges. Most commonly a percentage scale (1-100)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the person administering the performance meausre received training on how to conduct performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'ReceivedTrainingDate'
GO

-- Extended Properties [tpdm].[EvaluationRatingStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Represents the status of a Evaluation Rating.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingStatusDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationRatingStatusDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationTypeDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[FinancialAid] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents the financial aid a person is awarded.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FinancialAid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The classification of financial aid awarded to a person for the academic term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FinancialAid', @level2type=N'COLUMN', @level2name=N'AidTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was designated.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FinancialAid', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FinancialAid', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of financial aid awarded to a person for the term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FinancialAid', @level2type=N'COLUMN', @level2name=N'AidAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the condition (e.g., placement in a high need school) under which the aid was given.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FinancialAid', @level2type=N'COLUMN', @level2name=N'AidConditionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was removed.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FinancialAid', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates a person who receives Pell Grant aid.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FinancialAid', @level2type=N'COLUMN', @level2name=N'PellGrantRecipient'
GO

-- Extended Properties [tpdm].[GenderDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GenderDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GenderDescriptor', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO

-- Extended Properties [tpdm].[ObjectiveRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rating levels for Evaluation Objectives.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ObjectiveRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ObjectiveRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'ObjectiveRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A performance evaluation of an educator, typically regularly scheduled and uniformly applied, composed of one or more Evaluations.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the content or subject area of a performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The long description of the Performance Evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationDescription'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels involved with the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels involved with the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The summary rating for a Performance Evaluation across all Evaluation instruments for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the performance evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual or estimated number of clock minutes during which the performance evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of the the time at which the performance evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of whether the performance evaluation was announced or not.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'Announced'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A type of co-teaching observed as part of the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'CoteachingStyleObservedDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the performance evaluation was scheduled.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ScheduleDate'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rating levels for Performance Evaluations.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewer] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person(s) that conducted the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'ReviewerPersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'ReviewerSourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges. Most commonly a percentage scale (1-100)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the person administering the performance meausre received training on how to conduct performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'ReceivedTrainingDate'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted (e.g., walkthrough, summative).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationTypeDescriptor', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[RubricDimension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The cells of a rubric, consisting of a qualitative decription, definition, or exemplar with the associated rubric rating and rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating achieved for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'RubricRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The criterion description for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'CriterionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'DimensionOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'RubricRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[RubricRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rating levels for Rubric Dimensions.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'RubricRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[SchoolExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ID of the post secondary institution. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'PostSecondaryInstitutionId'
GO

-- Extended Properties [tpdm].[SurveyResponseExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier of the survey typically from the survey application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'SurveyResponseIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[SurveyResponsePersonTargetAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The association provides information about the survey being taken and who the survey is about.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier of the survey typically from the survey application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyResponseIdentifier'
GO

-- Extended Properties [tpdm].[SurveySectionResponsePersonTargetAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This association provides information about the survey section and the person the survey section is about.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier of the survey typically from the survey application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyResponseIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or label for the survey section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveySectionTitle'
GO

