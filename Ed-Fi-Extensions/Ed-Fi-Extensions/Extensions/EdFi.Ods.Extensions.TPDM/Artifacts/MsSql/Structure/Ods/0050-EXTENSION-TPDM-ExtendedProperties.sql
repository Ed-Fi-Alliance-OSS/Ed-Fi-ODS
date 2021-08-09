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

-- Extended Properties [tpdm].[ApplicantProfile] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The profile of the person making an application', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s maiden name.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'MaidenName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'SexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'BirthDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'HispanicLatinoEthnicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of whether or not the person is a U.S. citizen.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'CitizenshipStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'EconomicDisadvantaged'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether individual is a first generation college student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'FirstGenerationStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The extent of formal instruction an individual has received (e.g., the highest grade in school completed or its equivalent or the highest degree received).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'HighestCompletedLevelOfEducationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years that an individual has previously held a similar professional position in one or more education institutions.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'YearsOfPriorProfessionalExperience'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years that an individual has previously held a teaching position in one or more education institutions.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'YearsOfPriorTeachingExperience'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfile', @level2type=N'COLUMN', @level2name=N'HighlyQualifiedTeacher'
GO

-- Extended Properties [tpdm].[ApplicantProfileAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The apartment, room, or suite number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'ApartmentRoomSuiteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of the building on the site, if more than one building shares the same address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'BuildingSiteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'NameOfCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'CountyFIPSCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The congressional district in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'CongressionalDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddress', @level2type=N'COLUMN', @level2name=N'LocaleDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProfileAddressPeriod] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileAddressPeriod', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[ApplicantProfileApplicantCharacteristic] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects important characteristics of the applicant''s home situation:
      Displaced Homemaker, Immigrant, Migratory, Military Parent, Pregnant Teen, Single Parent, and Unaccompanied Youth.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileApplicantCharacteristic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The characteristic designated for the Student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'StudentCharacteristicDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the characteristic was designated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the characteristic was removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person, organization, or department that designated the characteristic.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO

-- Extended Properties [tpdm].[ApplicantProfileBackgroundCheck] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Applicant background check history and disposition.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileBackgroundCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileBackgroundCheck', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of background check (e.g., online, criminal, employment).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was requested.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckRequestedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckCompletedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person has or has not completed a fingerprint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileBackgroundCheck', @level2type=N'COLUMN', @level2name=N'Fingerprint'
GO

-- Extended Properties [tpdm].[ApplicantProfileDisability] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability condition(s) that best describes an individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisability', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the disability diagnosis.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDiagnosis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisability', @level2type=N'COLUMN', @level2name=N'OrderOfDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source that provided the disability determination.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDeterminationSourceTypeDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProfileDisabilityDesignation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisabilityDesignation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDesignationDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProfileEducatorPreparationProgramName] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Teacher Preparation Program(s) completed by the teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileEducatorPreparationProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileEducatorPreparationProgramName', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Teacher Preparation Program(s) completed by the teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileEducatorPreparationProgramName', @level2type=N'COLUMN', @level2name=N'EducatorPreparationProgramName'
GO

-- Extended Properties [tpdm].[ApplicantProfileElectronicMail] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileElectronicMail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileElectronicMail', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The electronic mail (e-mail) address listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileElectronicMail', @level2type=N'COLUMN', @level2name=N'ElectronicMailAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileElectronicMail', @level2type=N'COLUMN', @level2name=N'ElectronicMailTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileElectronicMail', @level2type=N'COLUMN', @level2name=N'PrimaryEmailAddressIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic email address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileElectronicMail', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[ApplicantProfileGradePointAverage] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data that provides information on a measure of average performance in a group of courses taken by an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileGradePointAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileGradePointAverage', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The system used for calculating the grade point average for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileGradePointAverage', @level2type=N'COLUMN', @level2name=N'GradePointAverageTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether or not the Grade Point Average value is cumulative.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileGradePointAverage', @level2type=N'COLUMN', @level2name=N'IsCumulative'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the grade points earned divided by the number of credits attempted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileGradePointAverage', @level2type=N'COLUMN', @level2name=N'GradePointAverageValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum value for the grade point average.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileGradePointAverage', @level2type=N'COLUMN', @level2name=N'MaxGradePointAverageValue'
GO

-- Extended Properties [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject(s) in which the staff is deemed to be "highly qualified".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileHighlyQualifiedAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject(s) in which the staff is deemed to be "highly qualified".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileHighlyQualifiedAcademicSubject', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileHighlyQualifiedAcademicSubject', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO

-- Extended Properties [tpdm].[ApplicantProfileIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Describe the documentation of citizenship.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProfileInternationalAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an international address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The second line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The third line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fourth line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'CountryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first date the address is valid. For physical addresses, the date the person moved to that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last date the address is valid. For physical addresses, this would be the date the person moved from that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileInternationalAddress', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[ApplicantProfileLanguage] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The language(s) the individual uses to communicate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileLanguage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileLanguage', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileLanguage', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProfileLanguageUse] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileLanguageUse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileLanguageUse', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageUseDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProfilePersonalIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfilePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProfileRace] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileRace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileRace', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileRace', @level2type=N'COLUMN', @level2name=N'RaceDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProfileTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The 10-digit telephone number, including the area code, for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileTelephone', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[ApplicantProfileVisa] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of a non-US citizen''s Visa type.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileVisa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileVisa', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of a non-US citizen''s Visa type.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProfileVisa', @level2type=N'COLUMN', @level2name=N'VisaDescriptorId'
GO

-- Extended Properties [tpdm].[Application] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An application for employment or acceptance.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for a candidate or open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year the application was submitted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the current status of the application (e.g., received, phone screen, interview, awaiting decision, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicationStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator as to whether the applicant is a current employee of the school district.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'CurrentEmployee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject for which the application is made.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of acceptance, if offered.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'AcceptedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Specifies the source for the application (e.g., Job fair, website, referral).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicationSourceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date applicant was first contacted after submitting application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'FirstContactDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The high need academic subject for the application, if any.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HighNeedsAcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the current status of the application for hire (e.g., applied, recommended, rejected, exited, offered, hired).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HireStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source for the application (e.g.,job fair, website, referral, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HiringSourceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the application was withdrawn by the applicant.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'WithdrawDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reason applicant withdrew application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'WithdrawReasonDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO

-- Extended Properties [tpdm].[ApplicationEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The life cycle events associated with an application (phone screen, review, interview, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of application event (e.g., added to pool, phone screen, interview, sample lesson).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicationEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for a candidate or open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the application event, or begin date if an interval.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sequence number of the application events. This is used to discriminate between mutiple events of the same type in the same day.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'SequenceNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date of the event, if an interval.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'EventEndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application evaluation score, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicationEvaluationScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The recommendation, result or conclusion of the application event (e.g., Continue, exit, recommend for hire).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicationEventResultDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier for a school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the term of a session during the school year (e.g., Fall Semester).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationEventResultDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the recommendation, result or conclusion of the application event (e.g., Continue, exit, recommend for hire).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEventResultDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEventResultDescriptor', @level2type=N'COLUMN', @level2name=N'ApplicationEventResultDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the description of application event (e.g., added to pool, phone screen, interview, sample lesson).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'ApplicationEventTypeDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationRecruitmentEventAttendance] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The recuitment event(s) associated with the Application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationRecruitmentEventAttendance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationRecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for a candidate or open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationRecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationRecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationRecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationRecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationRecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO

-- Extended Properties [tpdm].[ApplicationScoreResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A meaningful score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for a candidate or open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'AssessmentReportingMethodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'Result'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationSourceDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the source for the application (e.g., Job fair, website, referral).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationSourceDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationSourceDescriptor', @level2type=N'COLUMN', @level2name=N'ApplicationSourceDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the current status of the application (e.g., received, phone screen, interview, awaiting decision, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationStatusDescriptor', @level2type=N'COLUMN', @level2name=N'ApplicationStatusDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationTerm] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The intended term of enrollment for which the application is being submitted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for a candidate or open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The intended term of enrollment for which the application is being submitted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[AssessmentExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AssessmentExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to an assessment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AssessmentExtension', @level2type=N'COLUMN', @level2name=N'AssessmentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Assessment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AssessmentExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway an assessment may be associated with for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AssessmentExtension', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO

-- Extended Properties [tpdm].[BackgroundCheckStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor holds the  status of the background check (e.g., pending, under investigation, offense(s) found, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'BackgroundCheckStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'BackgroundCheckStatusDescriptor', @level2type=N'COLUMN', @level2name=N'BackgroundCheckStatusDescriptorId'
GO

-- Extended Properties [tpdm].[BackgroundCheckTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the classification of the background check a person receives.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'BackgroundCheckTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'BackgroundCheckTypeDescriptor', @level2type=N'COLUMN', @level2name=N'BackgroundCheckTypeDescriptorId'
GO

-- Extended Properties [tpdm].[Candidate] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A candidate is a person is enrolled in a educator preparation program and is a candidate to become an educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s maiden name.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'MaidenName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'SexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The city the student was born in.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For students born outside of the U.S., the Province or jurisdiction in which an individual is born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthInternationalProvince'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The country in which an individual is born. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthCountryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For students born outside of the U.S., the date the student entered the U.S.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'DateEnteredUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'MultipleBirthStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender at birth.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'BirthSexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Locator for the student photo.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'ProfileThumbnail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'HispanicLatinoEthnicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Previous definition of Ethnicity combining Hispanic/Latino and race: 1 - American Indian or Alaskan Native 2 - Asian or Pacific Islander 3 - Black, not of Hispanic origin 4 - Hispanic 5 - White, not of Hispanic origin.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'OldEthnicityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of whether or not the person is a U.S. citizen.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'CitizenshipStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'EconomicDisadvantaged'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the student has been identified as limited English proficient by the Language Proficiency Assessment Committee (LPAC), or English proficient.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'LimitedEnglishProficiencyDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'DisplacementStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The login ID for the user; used for security access control interface.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'LoginId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The tuition for a person''s participation in a program, service. or course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'TuitionCost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'EnglishLanguageExamDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The career previous for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'PreviousCareerDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether a candidate has completed the educator preparation program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'ProgramComplete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether individual is a first generation college student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'FirstGenerationStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for a candidate or open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for entrance into a program or an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Candidate', @level2type=N'COLUMN', @level2name=N'ApplicantProfileIdentifier'
GO

-- Extended Properties [tpdm].[CandidateAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'NameOfCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'CountyFIPSCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The congressional district in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'CongressionalDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddress', @level2type=N'COLUMN', @level2name=N'LocaleDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateAddressPeriod] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[CandidateAid] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents the financial aid a person is awarded.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The classification of financial aid awarded to a person for the academic term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAid', @level2type=N'COLUMN', @level2name=N'AidTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was designated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAid', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAid', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAid', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the condition (e.g., placement in a high need school) under which the aid was given.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAid', @level2type=N'COLUMN', @level2name=N'AidConditionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of financial aid awarded to a person for the term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAid', @level2type=N'COLUMN', @level2name=N'AidAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates a person who receives Pell Grant aid.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateAid', @level2type=N'COLUMN', @level2name=N'PellGrantRecipient'
GO

-- Extended Properties [tpdm].[CandidateBackgroundCheck] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Applicant background check history and disposition.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateBackgroundCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of background check (e.g., online, criminal, employment).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was requested.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckRequestedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckCompletedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person has or has not completed a fingerprint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'Fingerprint'
GO

-- Extended Properties [tpdm].[CandidateCharacteristic] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects important characteristics of the candidate (e.g, immigrant, first generation graduate, economically disadvantaged)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCharacteristic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The characteristic designated for the candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'CandidateCharacteristicDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the characteristic was designated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the characteristic was removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person, organization, or department that designated the characteristic.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO

-- Extended Properties [tpdm].[CandidateCharacteristicDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects important charactersitics of the candidate (e.g, immigrant, first generation graduate, economically disadvantaged)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCharacteristicDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCharacteristicDescriptor', @level2type=N'COLUMN', @level2name=N'CandidateCharacteristicDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateCohortYear] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type and year of a cohort (e.g., 9th grade) the student belongs to as determined by the year that student entered a specific grade.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCohortYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCohortYear', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of cohort year (9th grade, graduation).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCohortYear', @level2type=N'COLUMN', @level2name=N'CohortYearTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the  school year for the Cohort.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateCohortYear', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO

-- Extended Properties [tpdm].[CandidateDegreeSpecialization] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information around the area(s) of specialization for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDegreeSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the Teacher Candidate first declared specialization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The major area for a degree or area of specialization for a certificate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'MajorSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The major area for a degree or area of specialization for a certificate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'MinorSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the Teacher Candidate exited the declared specialization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[CandidateDisability] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability condition(s) that best describes an individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the disability diagnosis.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDiagnosis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'OrderOfDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source that provided the disability determination.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDeterminationSourceTypeDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateDisabilityDesignation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisabilityDesignation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDesignationDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the association between the Teacher Candidate and the EducatorPreparationProgram', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The begin date for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reason exited for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ReasonExitedDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code for describing the program pathway, for example: Residency, Internship, Traditional', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EPPProgramPathwayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The major area for a degree or area of specialization for a certificate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'MajorSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The major area for a degree or area of specialization for a certificate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'MinorSpecialization'
GO

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicator] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator(s) or metric(s) computed for the candidate in the EPP.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The begin date for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name for a group of indicators.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'IndicatorGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the indicator or metric.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'IndicatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the indicator or metric.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'Indicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person, organization, or department that designated the program association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicator', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time periods for which the indicator was effective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEducatorPreparationProgramAssociationCandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'EndDate'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'PrimaryEmailAddressIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic email address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[CandidateEPPProgramDegree] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details of the degree.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEPPProgramDegree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a degree.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEPPProgramDegree', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEPPProgramDegree', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code for describing the degree type that a candidate accomplishes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEPPProgramDegree', @level2type=N'COLUMN', @level2name=N'EPPDegreeTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade level associated with the degree plan for the candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateEPPProgramDegree', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateIdentificationCode] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The organization code or name assigning the StudentIdentificationCode.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationCode', @level2type=N'COLUMN', @level2name=N'AssigningOrganizationIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationCode', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to a person by a school, school system, a state, or other agency or entity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationCode', @level2type=N'COLUMN', @level2name=N'IdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationCode', @level2type=N'COLUMN', @level2name=N'StudentIdentificationSystemDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Describe the documentation of citizenship.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateIndicator] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator(s) or metric(s) computed for the candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicator', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the indicator or metric.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicator', @level2type=N'COLUMN', @level2name=N'IndicatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name for a group of indicators.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicator', @level2type=N'COLUMN', @level2name=N'IndicatorGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the indicator or metric.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicator', @level2type=N'COLUMN', @level2name=N'Indicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person, organization, or department that designated the program association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicator', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO

-- Extended Properties [tpdm].[CandidateIndicatorPeriod] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time periods for which the indicator was effective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicatorPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the indicator or metric.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'IndicatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateIndicatorPeriod', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[CandidateInternationalAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an international address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The second line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The third line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fourth line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'CountryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first date the address is valid. For physical addresses, the date the person moved to that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last date the address is valid. For physical addresses, this would be the date the person moved from that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'EndDate'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The types of alternate names for a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'OtherNameTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateOtherName', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateRace] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRace', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRace', @level2type=N'COLUMN', @level2name=N'RaceDescriptorId'
GO

-- Extended Properties [tpdm].[CandidateRelationshipToStaffAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This describes a relationship between a (current) candidate and a staff person, typically at a K12 partnering district in the role of a mentor teacher, coordinating teacher, supervising principal, etc. It could also describe the relationship between a (current) candidate and a university staff member, i.e., field placement supervisor, advisor, etc. This is a relationship between two different people', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRelationshipToStaffAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRelationshipToStaffAssociation', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRelationshipToStaffAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Defines the staff relationship to the candidate (e.g., supervising principal, mentor, coordinating teacher, etc. )', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRelationshipToStaffAssociation', @level2type=N'COLUMN', @level2name=N'StaffToCandidateRelationshipDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the candidate is associated to the staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRelationshipToStaffAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the candidate stops association with the staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateRelationshipToStaffAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[CandidateVisa] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of a non-US citizen''s Visa type.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateVisa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateVisa', @level2type=N'COLUMN', @level2name=N'CandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of a non-US citizen''s Visa type.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CandidateVisa', @level2type=N'COLUMN', @level2name=N'VisaDescriptorId'
GO

-- Extended Properties [tpdm].[Certification] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An offering by an official granting authority of a certification or license that qualifies persons to perform specific job functions, such as full fill a teaching assignment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The level (e.g., Elementary, Secondary) or category (administrative, specialist) of the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The field of certification (e.g., Mathematics, Music).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationFieldDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The standard, law or policy defining the certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationStandardDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum level of degree, if any, required for Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'MinimumDegreeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The role authorized by the Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'EducatorRoleDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of students the Section is offered and tailored to; for example: Bilingual students, Remedial education students, Gifted and talented students, Career and Technical Education students, Special education students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'PopulationServedDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The setting authorized by the Certification in which a child receives education and related services; for example: Classroom, Virtual, Vocational.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'InstructionalSettingDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year, month and day on which the Certification is offered.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'EffectiveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the Certification offering is expected to end.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[CertificationCertificationExam] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Certification Eams required for the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamNamespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam', @level2type=N'COLUMN', @level2name=N'Namespace'
GO

-- Extended Properties [tpdm].[CertificationExam] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An examination required by one or more Certifications.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type or category of Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year, month and day on which the CertificationExam is offered.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'EffectiveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the CertificationExam offering is expected to end.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[CertificationExamResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s result from taking a Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year, month and day on which the CertificationExam is taken.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of the person''s attempt for the Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'AttemptNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The score result for the Certification Exam attempt.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the person passed the Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamPassIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the Certification Exam attempt.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamStatusDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationExamStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamStatusDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationExamStatusDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationExamTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of certification exam that was taken.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamTypeDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationExamTypeDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationFieldDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The field of certification for the credential (e.g., Mathematics, Music).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationFieldDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationFieldDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationFieldDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade level(s) certified for teaching.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationGradeLevel', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade level(s) certified for teaching.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationGradeLevel', @level2type=N'COLUMN', @level2name=N'Namespace'
GO

-- Extended Properties [tpdm].[CertificationLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The level (e.g., Elementary, Secondary) or category (administrative, specialist) of the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationLevelDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationLevelDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationRoute] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program ,or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRoute'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRoute', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program ,or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRoute', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRoute', @level2type=N'COLUMN', @level2name=N'Namespace'
GO

-- Extended Properties [tpdm].[CertificationRouteDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program ,or pathway used to obtain a certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRouteDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRouteDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationStandardDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The standard, law or policy defining the certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationStandardDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationStandardDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationStandardDescriptorId'
GO

-- Extended Properties [tpdm].[CoteachingStyleObservedDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A type of co-teaching observed as part of the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CoteachingStyleObservedDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CoteachingStyleObservedDescriptor', @level2type=N'COLUMN', @level2name=N'CoteachingStyleObservedDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An event associated with a person''s Credential (e.g, suspension, revocation, or renewal).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year, month and day of the Credential Event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'CredentialEventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of event associated with a person''s Credential (e.g, suspension, revocation, or renewal).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'CredentialEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'CredentialIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'StateOfIssueStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reason for the credential event, or any other descriptive text.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'CredentialEventReason'
GO

-- Extended Properties [tpdm].[CredentialEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of event associated with a person''s Credential (e.g, suspension, revocation, or renewal).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'CredentialEventTypeDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'StateOfIssueStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the certification obtained by the educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CertificationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program, or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the credential was granted under the authority of a national Board Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'BoardCertificationIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The most recent status of the credential (e.g., active, suspended, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the credential status was effective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialStatusDate'
GO

-- Extended Properties [tpdm].[CredentialStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The most recent status of the credential (e.g., active, suspended, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStatusDescriptor', @level2type=N'COLUMN', @level2name=N'CredentialStatusDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialStudentAcademicRecord] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reference to the person''s Student Academic Records for the school(s) with which the Credential is associated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'CredentialIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'StateOfIssueStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[DegreeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum level of degree, if any, required for Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'DegreeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'DegreeDescriptor', @level2type=N'COLUMN', @level2name=N'DegreeDescriptorId'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to a program by a school, school system, a state, or other agency or entity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of educator prep program (e.g., college, alternative, TFA, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'EducatorPreparationProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current accreditation status of the Educator Preparation Program (e.g., active, pending, revoked,...).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'AccreditationStatusDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorPreparationProgramGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels served at the EPP Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels served at the EPP Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorPreparationProgramTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of educator prep program (e.g., college, alternative, TFA, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramTypeDescriptor', @level2type=N'COLUMN', @level2name=N'EducatorPreparationProgramTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorRoleDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The role authorized by the Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorRoleDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorRoleDescriptor', @level2type=N'COLUMN', @level2name=N'EducatorRoleDescriptorId'
GO

-- Extended Properties [tpdm].[EnglishLanguageExamDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EnglishLanguageExamDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EnglishLanguageExamDescriptor', @level2type=N'COLUMN', @level2name=N'EnglishLanguageExamDescriptorId'
GO

-- Extended Properties [tpdm].[EPPDegreeTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details of the degree.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EPPDegreeTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EPPDegreeTypeDescriptor', @level2type=N'COLUMN', @level2name=N'EPPDegreeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EPPProgramPathwayDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code for describing the program pathway, for example: Residency, Internship, Traditional', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EPPProgramPathwayDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EPPProgramPathwayDescriptor', @level2type=N'COLUMN', @level2name=N'EPPProgramPathwayDescriptorId'
GO

-- Extended Properties [tpdm].[Evaluation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An evaluation instrument appled to evaluate an educator.  The evaluation could be internally developed, or could be an industry recognized instrument such as TTESS or Marzano.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sort order of this Evaluation Element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'SortOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation element. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationElementRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Area(s) identified for person to refine or improve as part of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'AreaOfRefinement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Area(s) identified for reinforcement or positive feedback as part of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'AreaOfReinforcement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'Comments'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO

-- Extended Properties [tpdm].[EvaluationElementRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevelDescriptor'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationObjective] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A subcomponent of an Evaluation, a specific educator Objective or domain of performance that is being evaluated.  ', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sort order of this Evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'SortOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation Objective. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation Objective (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'ObjectiveRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO

-- Extended Properties [tpdm].[EvaluationObjectiveRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationPeriodDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationPeriodDescriptor'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO

-- Extended Properties [tpdm].[EvaluationRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO

-- Extended Properties [tpdm].[EvaluationRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevelDescriptor'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRatingReviewer] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person(s) that conducted the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the person administering the performance meausre received training on how to conduct performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'ReceivedTrainingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
GO

-- Extended Properties [tpdm].[EvaluationTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationTypeDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[FederalLocaleCodeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the federal locale code applicable to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FederalLocaleCodeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FederalLocaleCodeDescriptor', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO

-- Extended Properties [tpdm].[FieldworkExperience] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The information regarding a postsecondary instructional course in a particular field of study that typically involves a prescribed number or instruction periods or meetings for enrolled students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff first starts fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the fieldwork experience', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'FieldworkIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of fieldwork being executed by a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'FieldworkTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of hours completed during the fieldwork experience.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'HoursCompleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff ends fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the program gateway that is associated with continuation in a program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO

-- Extended Properties [tpdm].[FieldworkExperienceCoteaching] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The act of two teachers (teacher candidate and cooperating teacher) working together with groups of students; sharing the planning, organization, delivery, and assessment of instruction, as well as the physical space.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff first starts fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the fieldwork experience', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'FieldworkIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the teacher candidate first starts co-teaching.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'CoteachingBeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the teacher candidate stopped co-teaching.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'CoteachingEndDate'
GO

-- Extended Properties [tpdm].[FieldworkExperienceSectionAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Associates fieldwork with a section', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff first starts fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the fieldwork experience', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'FieldworkIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [tpdm].[FieldworkTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of fieldwork being executed by a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkTypeDescriptor', @level2type=N'COLUMN', @level2name=N'FieldworkTypeDescriptorId'
GO

-- Extended Properties [tpdm].[FundingSourceDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the funding source (e.g., federal, district).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FundingSourceDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FundingSourceDescriptor', @level2type=N'COLUMN', @level2name=N'FundingSourceDescriptorId'
GO

-- Extended Properties [tpdm].[GenderDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with with a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GenderDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GenderDescriptor', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO

-- Extended Properties [tpdm].[Goal] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Goal for performance improvement assigned to an educator associated with an Evaluation Element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the goal was assigned.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'AssignmentDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the goal.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'GoalTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the goal (e.g., management, instruction).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'GoalTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the goal.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'GoalDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the goal is due or expected to be completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'DueDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the goal was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'CompletedIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the goal was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'CompletedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the goal or its completion to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'Comments'
GO

-- Extended Properties [tpdm].[GoalTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the goal (e.g., management, instruction).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GoalTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GoalTypeDescriptor', @level2type=N'COLUMN', @level2name=N'GoalTypeDescriptorId'
GO

-- Extended Properties [tpdm].[GraduationPlanRequiredCertification] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or reference to the certifiation(s) required for graduation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the Certification required for Graduation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'CertificationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program ,or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO

-- Extended Properties [tpdm].[HireStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the current status of the application for hire (e.g., applied, recommended, rejected, exited, offered, hired).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'HireStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'HireStatusDescriptor', @level2type=N'COLUMN', @level2name=N'HireStatusDescriptorId'
GO

-- Extended Properties [tpdm].[HiringSourceDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the source for the application (e.g.,job fair, website, referral, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'HiringSourceDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'HiringSourceDescriptor', @level2type=N'COLUMN', @level2name=N'HiringSourceDescriptorId'
GO

-- Extended Properties [tpdm].[InstructionalSettingDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The setting authorized by the Certification in which a child receives education and related services; for example: Classroom, Virtual, Vocational.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'InstructionalSettingDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'InstructionalSettingDescriptor', @level2type=N'COLUMN', @level2name=N'InstructionalSettingDescriptorId'
GO

-- Extended Properties [tpdm].[LengthOfContractDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The length of contract (e.g., 12 month, 9 month, summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LengthOfContractDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LengthOfContractDescriptor', @level2type=N'COLUMN', @level2name=N'LengthOfContractDescriptorId'
GO

-- Extended Properties [tpdm].[LocalEducationAgencyExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LocalEducationAgencyExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a local education agency.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LocalEducationAgencyExtension', @level2type=N'COLUMN', @level2name=N'LocalEducationAgencyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The federal locale code associated with an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LocalEducationAgencyExtension', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO

-- Extended Properties [tpdm].[ObjectiveRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ObjectiveRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ObjectiveRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'ObjectiveRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[OpenStaffPositionEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects milestones like vacancy approved, vacancy posted, date onboarded, processing date, orientation date, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date of the open staff position event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects milestones like vacancy approved, vacancy posted, date onboarded, processing date, orientation date, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the status of the milestone (e.g., pending, completed, cancelled).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionEventStatusDescriptorId'
GO

-- Extended Properties [tpdm].[OpenStaffPositionEventStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the status of the milestone (e.g., pending, completed, cancelled).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEventStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEventStatusDescriptor', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionEventStatusDescriptorId'
GO

-- Extended Properties [tpdm].[OpenStaffPositionEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the milestones like vacancy approved, vacancy posted, date onboarded. processing date, orientation date  etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionEventTypeDescriptorId'
GO

-- Extended Properties [tpdm].[OpenStaffPositionExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year for which the OpenStaffPosition is seeking to fill.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ratio between the hours of work expected in a position and the hours of work normally expected in a full-time position in the same setting.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'FullTimeEquivalency'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reason for the open staff position (e.g., new position, replacement, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionReasonDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the OpenStaffPosition is currently Active.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum salary or wage a person is paid before deductions (excluding differentials) but including annuities.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'MaxSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum salary or wage a person is paid before deductions (excluding differentials) but including annuities.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'MinSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The funding source for open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'FundingSourceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator as to whether the OpenStaffPosition is filling a high-need subject area designated as a teacher shortage that may be eligible for special grants, aid or compensation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'HighNeedAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the position to be filled.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'PositionControlNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first term for the Session during the school year for which the OpenStaffPosition is seeking to fill.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Including salary, the fully loaded cost budgeted for this teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'TotalBudgeted'
GO

-- Extended Properties [tpdm].[OpenStaffPositionReasonDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the reason for the open staff position (e.g., new position, replacement, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionReasonDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionReasonDescriptor', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionReasonDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A performance evaluation of an educator, typically regularly scheduled and uniformly applied, comporsed of one or more Evaluations.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels involved with the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels involved with the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationProgramGateway] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway that may be associated for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway that may be associated for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The summary rating for a Performance Evaluation across all Evaluation instruments for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of whether the performance evaluation was announced or not.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'Announced'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A type of co-teaching observed as part of the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'CoteachingStyleObservedDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual or estimated number of clock minutes during which the performance evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the performance evaluation was to be conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ScheduleDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of the the time at which the performance evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualTime'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewer] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person(s) that conducted the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the person administering the performance meausre received training on how to conduct performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'ReceivedTrainingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationTypeDescriptor', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[PostSecondaryInstitutionExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PostSecondaryInstitutionExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ID of the post secondary institution.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PostSecondaryInstitutionExtension', @level2type=N'COLUMN', @level2name=N'PostSecondaryInstitutionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The federal locale code associated with an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PostSecondaryInstitutionExtension', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO

-- Extended Properties [tpdm].[PreviousCareerDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the previous career of an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PreviousCareerDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PreviousCareerDescriptor', @level2type=N'COLUMN', @level2name=N'PreviousCareerDescriptorId'
GO

-- Extended Properties [tpdm].[ProfessionalDevelopmentEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about a professional development event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the event, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or name for a professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing an organization that is offering a specific professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentOfferedByDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of total hours the professional development contains.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'TotalHours'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether a teacher candidate is active in a professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'Required'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether or not a professional development event is comprised of multiple sessions or not.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'MultipleSession'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reported reason for a teacher candidate''s professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentReason'
GO

-- Extended Properties [tpdm].[ProfessionalDevelopmentEventAttendance] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This event entity represents the recording of whether a staff is in attendance for professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date for this attendance event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'AttendanceDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the event, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or name for a professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing the attendance event, for example:
       Present
       Unexcused absence
       Excused absence
       Tardy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'AttendanceEventCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reported reason for a teacher candidate''s absence.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'AttendanceEventReason'
GO

-- Extended Properties [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the organization that a professional development is offered by.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentOfferedByDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentOfferedByDescriptor', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentOfferedByDescriptorId'
GO

-- Extended Properties [tpdm].[ProgramGatewayDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway that may be associated for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProgramGatewayDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProgramGatewayDescriptor', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO

-- Extended Properties [tpdm].[QuantitativeMeasure] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A quantitative measure of educator performance associated with an Evaluation Element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the quantitative measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the quantitative measure (e.g., achievement, growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureDatatypeDescriptorId'
GO

-- Extended Properties [tpdm].[QuantitativeMeasureDatatypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureDatatypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureDatatypeDescriptor', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureDatatypeDescriptorId'
GO

-- Extended Properties [tpdm].[QuantitativeMeasureScore] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The score or value for a Quantitative Measure achieved by an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the quantitative measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The score value for the quantitive measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'ScoreValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The standard error for the quantitative measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'StandardError'
GO

-- Extended Properties [tpdm].[QuantitativeMeasureTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the quantitative measure (e.g., achievement, growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureTypeDescriptor', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureTypeDescriptorId'
GO

-- Extended Properties [tpdm].[RecruitmentEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Events associated with the recruitment process.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The long description of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'RecruitmentEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The location of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventLocation'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendance] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prospect for employment or acceptance that has not yet made formal application that has attended recruitment event, such as a  job fair or university recruiting visit.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the prospect applied for a position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'Applied'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'ElectronicMailAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'HispanicLatinoEthnicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator whether the person was met by a representative of the education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'Met'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s maiden name.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'MaidenName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional notes about the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating initially assigned to the prospect prior to an official screening.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'PreScreeningRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of prospect, such as EPP Applicant, Hire, or Mentor Teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the prospect was a referral.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'Referral'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person making the referral.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'ReferredBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'SexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The social media network name (e.g., LinkedIn, Twitter, etc.) associated with the SocialMediaUserName.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'SocialMediaNetworkName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The user name of the person on social media.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendance', @level2type=N'COLUMN', @level2name=N'SocialMediaUserName'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendanceCurrentPosition] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current position of the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition', @level2type=N'COLUMN', @level2name=N'NameOfInstitution'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The location, typically City and State, for the institution.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition', @level2type=N'COLUMN', @level2name=N'Location'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive name of an individual''s position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition', @level2type=N'COLUMN', @level2name=N'PositionTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject the staff person''s assignment to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPosition', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of grade levels for which the individual''s assignment is responsible.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPositionGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPositionGradeLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPositionGradeLevel', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPositionGradeLevel', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of grade levels for which the individual''s assignment is responsible.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPositionGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceCurrentPositionGradeLevel', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendanceDisability] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability condition(s) that best describes an individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the disability diagnosis.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDiagnosis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability', @level2type=N'COLUMN', @level2name=N'OrderOfDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source that provided the disability determination.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDeterminationSourceTypeDescriptorId'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisabilityDesignation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDesignationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendancePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendanceRace] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRace', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRace', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRace', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRace', @level2type=N'COLUMN', @level2name=N'RaceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRace', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The qualifications of a prospective educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether the prospect is eligible for the position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications', @level2type=N'COLUMN', @level2name=N'Eligible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether or not a prospect mentor teacher has capacity to serve.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications', @level2type=N'COLUMN', @level2name=N'CapacityToServe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years of service at the current school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications', @level2type=N'COLUMN', @level2name=N'YearsOfServiceCurrentPlacement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years of service as a teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceRecruitmentEventAttendeeQualifications', @level2type=N'COLUMN', @level2name=N'YearsOfServiceTotal'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendanceTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The 10-digit telephone number, including the area code, for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendanceTouchpoint] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Content associated with different touchpoints with the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTouchpoint'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTouchpoint', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTouchpoint', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTouchpoint', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the attendee to a recuitment event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTouchpoint', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The content associated with or an artifact from the touchpoint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTouchpoint', @level2type=N'COLUMN', @level2name=N'TouchpointContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the touchpoint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendanceTouchpoint', @level2type=N'COLUMN', @level2name=N'TouchpointDate'
GO

-- Extended Properties [tpdm].[RecruitmentEventAttendeeTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of prospect, such as TPP Applicant, Hire, or Mentor Teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendeeTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventAttendeeTypeDescriptor', @level2type=N'COLUMN', @level2name=N'RecruitmentEventAttendeeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[RecruitmentEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'RecruitmentEventTypeDescriptorId'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating achieved for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'RubricRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'RubricRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The criterion description for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'CriterionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'DimensionOrder'
GO

-- Extended Properties [tpdm].[RubricRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'RubricRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[SalaryTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of salary that a staff member is receiving.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SalaryTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SalaryTypeDescriptor', @level2type=N'COLUMN', @level2name=N'SalaryTypeDescriptorId'
GO

-- Extended Properties [tpdm].[SchoolExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The federal locale code associated with an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ID of the post secondary institution.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'PostSecondaryInstitutionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether a school is identified as an improving school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'ImprovingSchool'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Accreditation Status for a Education Preparation Provider.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'AccreditationStatusDescriptorId'
GO

-- Extended Properties [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The titles of employment, official status, or rank of education staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'StaffClassificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years that an individual has previously held a teaching position in one or more education institutions.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'YearsOfExperienceAtCurrentEducationOrganization'
GO

-- Extended Properties [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Staff background check history and disposition.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of background check (e.g., online, criminal, employment).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'EmploymentStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was hired for a position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was requested.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckRequestedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckCompletedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person has or has not completed a fingerprint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationBackgroundCheck', @level2type=N'COLUMN', @level2name=N'Fingerprint'
GO

-- Extended Properties [tpdm].[StaffEducationOrganizationEmploymentAssociationExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension', @level2type=N'COLUMN', @level2name=N'EmploymentStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was hired for a position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension', @level2type=N'COLUMN', @level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the probation period ended or is scheduled to end.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension', @level2type=N'COLUMN', @level2name=N'ProbationCompleteDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The length of contract (e.g., 12 month, 9 month, summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension', @level2type=N'COLUMN', @level2name=N'LengthOfContractDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the staff is on track for tenure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension', @level2type=N'COLUMN', @level2name=N'TenureTrack'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the staff member is tenured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationExtension', @level2type=N'COLUMN', @level2name=N'Tenured'
GO

-- Extended Properties [tpdm].[StaffEducationOrganizationEmploymentAssociationSalary] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information regarding the salary of a staff member.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary', @level2type=N'COLUMN', @level2name=N'EmploymentStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was hired for a position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary', @level2type=N'COLUMN', @level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum salary range for a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary', @level2type=N'COLUMN', @level2name=N'SalaryMinRange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum salary range for a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary', @level2type=N'COLUMN', @level2name=N'SalaryMaxRange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of salary that a staff member is receiving.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary', @level2type=N'COLUMN', @level2name=N'SalaryTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The salary of a staff member.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSalary', @level2type=N'COLUMN', @level2name=N'SalaryAmount'
GO

-- Extended Properties [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Entries of job experience contributing to computations of seniority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSeniority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The field of the credential being applied.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSeniority', @level2type=N'COLUMN', @level2name=N'CredentialFieldDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSeniority', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSeniority', @level2type=N'COLUMN', @level2name=N'EmploymentStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was hired for a position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSeniority', @level2type=N'COLUMN', @level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the education organization worked.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSeniority', @level2type=N'COLUMN', @level2name=N'NameOfInstitution'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSeniority', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of years of experience.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationEmploymentAssociationSeniority', @level2type=N'COLUMN', @level2name=N'YearsExperience'
GO

-- Extended Properties [tpdm].[StaffEducatorPreparationProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Educator Preparation Program(s) completed by the teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [tpdm].[StaffEducatorPreparationProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This association indicates the EducatorPreparationProgram associated with a Staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Start date for the association of staff to this program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'End date for the association of staff to this program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the staff completed the EducatorPreparationProgram.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorPreparationProgramAssociation', @level2type=N'COLUMN', @level2name=N'Completer'
GO

-- Extended Properties [tpdm].[StaffEducatorResearch] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Educator preparation provider faculty that instruct teacher candidates in content area or pedagogy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorResearch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorResearch', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the start or effective date of a staff member''s teacher educator position for an Education Organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorResearch', @level2type=N'COLUMN', @level2name=N'ResearchExperienceDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the research experience.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorResearch', @level2type=N'COLUMN', @level2name=N'ResearchExperienceTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the research experience.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducatorResearch', @level2type=N'COLUMN', @level2name=N'ResearchExperienceDescription'
GO

-- Extended Properties [tpdm].[StaffExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO

-- Extended Properties [tpdm].[StaffHighlyQualifiedAcademicSubject] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject(s) in which the staff is deemed to be "highly qualified".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffHighlyQualifiedAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject(s) in which the staff is deemed to be "highly qualified".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffHighlyQualifiedAcademicSubject', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffHighlyQualifiedAcademicSubject', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [tpdm].[StaffToCandidateRelationshipDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Defines the staff relationship to the candidate (e.g., supervising principal, mentor, coordinating teacher, etc. )', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffToCandidateRelationshipDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffToCandidateRelationshipDescriptor', @level2type=N'COLUMN', @level2name=N'StaffToCandidateRelationshipDescriptorId'
GO

-- Extended Properties [tpdm].[StateEducationAgencyExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StateEducationAgencyExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a state education agency.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StateEducationAgencyExtension', @level2type=N'COLUMN', @level2name=N'StateEducationAgencyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The federal locale code associated with an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StateEducationAgencyExtension', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO

-- Extended Properties [tpdm].[StudentGradebookEntryExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the Student''s entry or assignment to the Section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the assignment, homework, or assessment was assigned or executed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'DateAssigned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the activity to be recorded in the GradebookEntry.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'GradebookEntryTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date that the assignment was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'DateCompleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indication of whether the assignment was passed or not.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'AssignmentPassed'
GO

-- Extended Properties [tpdm].[SurveyResponseExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier of the survey typically from the survey application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyResponseIdentifier'
GO

-- Extended Properties [tpdm].[SurveySectionAggregateResponse] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The aggregate or average score across the surveying population for a survey section being used for performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or label for the survey section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'SurveySectionTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The score value for the aggregate survey section response.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'ScoreValue'
GO

-- Extended Properties [tpdm].[SurveySectionExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or label for the survey section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'SurveySectionTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO

-- Extended Properties [tpdm].[SurveySectionResponsePersonTargetAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This association provides information about the survey section and the person the survey section is about.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponsePersonTargetAssociation', @level2type=N'COLUMN', @level2name=N'Namespace'
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

-- Extended Properties [tpdm].[WithdrawReasonDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the reason applicant withdrew application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'WithdrawReasonDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'WithdrawReasonDescriptor', @level2type=N'COLUMN', @level2name=N'WithdrawReasonDescriptorId'
GO

