-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [sample].[ArtMediumDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art medium used in a section or program (i.e. paint, pencils, clay, etc.).', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ArtMediumDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ArtMediumDescriptor', @level2type=N'COLUMN', @level2name=N'ArtMediumDescriptorId'
GO

-- Extended Properties [sample].[Bus] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is an example of a new domain entity.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'Bus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'Bus', @level2type=N'COLUMN', @level2name=N'BusId'
GO

-- Extended Properties [sample].[BusRoute] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is an example of a new domain entity.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus assigned to the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'BusId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'BusRouteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The direction of the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'BusRouteDirection'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of minutes per week in which the bus route is operational.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'BusRouteDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the bus route operates every weekday.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'Daily'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability served by the bus route, if applicable.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The approximate amount of time, in minutes, for the bus route operation each day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'ExpectedTransitTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of hours per week in which the bus route is operational.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'HoursPerWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The approximate annual cost for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'OperatingCost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of seats filled under optimal conditions.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'OptimalCapacity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The titles of employment, official status, or rank of education staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'StaffClassificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the bus route became operational.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The approximate weekly mileage for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'WeeklyMileage'
GO

-- Extended Properties [sample].[BusRouteBusYear] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The years in which the bus route has been in active.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteBusYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus assigned to the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteBusYear', @level2type=N'COLUMN', @level2name=N'BusId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteBusYear', @level2type=N'COLUMN', @level2name=N'BusRouteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The years in which the bus route has been in active.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteBusYear', @level2type=N'COLUMN', @level2name=N'BusYear'
GO

-- Extended Properties [sample].[BusRouteProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Programs served by the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus assigned to the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteProgram', @level2type=N'COLUMN', @level2name=N'BusId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteProgram', @level2type=N'COLUMN', @level2name=N'BusRouteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteProgram', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteProgram', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteProgram', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO

-- Extended Properties [sample].[BusRouteServiceAreaPostalCode] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The postal codes served by the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteServiceAreaPostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus assigned to the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteServiceAreaPostalCode', @level2type=N'COLUMN', @level2name=N'BusId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteServiceAreaPostalCode', @level2type=N'COLUMN', @level2name=N'BusRouteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The postal codes served by the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteServiceAreaPostalCode', @level2type=N'COLUMN', @level2name=N'ServiceAreaPostalCode'
GO

-- Extended Properties [sample].[BusRouteStartTime] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time the bus route begins.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteStartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus assigned to the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteStartTime', @level2type=N'COLUMN', @level2name=N'BusId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteStartTime', @level2type=N'COLUMN', @level2name=N'BusRouteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time the bus route begins.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteStartTime', @level2type=N'COLUMN', @level2name=N'StartTime'
GO

-- Extended Properties [sample].[BusRouteTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone numbers at which dispatchers may be reached for this bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus assigned to the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'BusId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'BusRouteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO

-- Extended Properties [sample].[ContactAddressExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional details on the contact''s address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The apartment or housing complex name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension', @level2type=N'COLUMN', @level2name=N'Complex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator if the address is on a bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressExtension', @level2type=N'COLUMN', @level2name=N'OnBusRoute'
GO

-- Extended Properties [sample].[ContactAddressSchoolDistrict] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school district in which the address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressSchoolDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school district in which the address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'SchoolDistrict'
GO

-- Extended Properties [sample].[ContactAddressTerm] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terms applicable to this address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressTerm', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressTerm', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressTerm', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressTerm', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressTerm', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressTerm', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terms applicable to this address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAddressTerm', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [sample].[ContactAuthor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The contact''s favorite authors.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAuthor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAuthor', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The contact''s favorite authors.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactAuthor', @level2type=N'COLUMN', @level2name=N'Author'
GO

-- Extended Properties [sample].[ContactCeilingHeight] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The height of the ceiling in the rooms of the contact''s home.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCeilingHeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCeilingHeight', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The height of the ceiling in the rooms of the contact''s home.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCeilingHeight', @level2type=N'COLUMN', @level2name=N'CeilingHeight'
GO

-- Extended Properties [sample].[ContactCTEProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A CTE program the contact has completed.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCTEProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCTEProgram', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCTEProgram', @level2type=N'COLUMN', @level2name=N'CareerPathwayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number and description of the CIP code associated with the student''s CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCTEProgram', @level2type=N'COLUMN', @level2name=N'CIPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether the student has completed the CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCTEProgram', @level2type=N'COLUMN', @level2name=N'CTEProgramCompletionIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether this CTE program is the student''s primary CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactCTEProgram', @level2type=N'COLUMN', @level2name=N'PrimaryCTEProgramIndicator'
GO

-- Extended Properties [sample].[ContactEducationContent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Education content to which the contact has been referred.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactEducationContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactEducationContent', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for the education content.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactEducationContent', @level2type=N'COLUMN', @level2name=N'ContentIdentifier'
GO

-- Extended Properties [sample].[ContactExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time spent per day waiting in the car line.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'AverageCarLineWait'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the contact first became a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'BecameParent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'How much the contact spends on coffee in a week.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'CoffeeSpend'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The field in which the contact holds a credential.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'CredentialFieldDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of time the contact spends reading to his/her children at bedtime.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The contact''s high school GPA.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'GPA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the contact graduated high school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'GraduationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the contact is a sports fan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'IsSportsFan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The contact''s lucky number.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'LuckyNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time the contact would prefer to wake up in the morning.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'PreferredWakeUpTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent likelihood that it will rain when the contact volunteers to chaperone a field trip.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactExtension', @level2type=N'COLUMN', @level2name=N'RainCertainty'
GO

-- Extended Properties [sample].[ContactFavoriteBookTitle] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the contact''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactFavoriteBookTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the contact''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'FavoriteBookTitle'
GO

-- Extended Properties [sample].[ContactStudentProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Programs the contact''s child or children are enrolled in for which the contact provides volunteer services.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactStudentProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[ContactTeacherConference] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The contact''s preferred day of the week and time for contact-teacher conferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactTeacherConference'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactTeacherConference', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day of the week the parent prefers to meet for parent-teacher conferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactTeacherConference', @level2type=N'COLUMN', @level2name=N'DayOfWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end time the parent prefers to meet for parent-teacher conferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactTeacherConference', @level2type=N'COLUMN', @level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The start time the parent prefers to meet for parent-teacher conferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ContactTeacherConference', @level2type=N'COLUMN', @level2name=N'StartTime'
GO

-- Extended Properties [sample].[FavoriteBookCategoryDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of an individual''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'FavoriteBookCategoryDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'FavoriteBookCategoryDescriptor', @level2type=N'COLUMN', @level2name=N'FavoriteBookCategoryDescriptorId'
GO

-- Extended Properties [sample].[MembershipTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Membership Type identifies whether a school has primary responsibility for managing a specific student''s curriculum or not.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'MembershipTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'MembershipTypeDescriptor', @level2type=N'COLUMN', @level2name=N'MembershipTypeDescriptorId'
GO

-- Extended Properties [sample].[SchoolCTEProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A CTE program the school is known for.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'CareerPathwayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number and description of the CIP code associated with the student''s CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'CIPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether the student has completed the CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'CTEProgramCompletionIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether this CTE program is the student''s primary CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'PrimaryCTEProgramIndicator'
GO

-- Extended Properties [sample].[SchoolDirectlyOwnedBus] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buses owned by the School directly.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolDirectlyOwnedBus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolDirectlyOwnedBus', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolDirectlyOwnedBus', @level2type=N'COLUMN', @level2name=N'DirectlyOwnedBusId'
GO

-- Extended Properties [sample].[SchoolExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the school is exemplary.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'IsExemplary'
GO

-- Extended Properties [sample].[StaffExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the staff member adopted the first household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'FirstPetOwnedDate'
GO

-- Extended Properties [sample].[StaffPet] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about pets in the staff member''s household.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPet', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The pet''s name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPet', @level2type=N'COLUMN', @level2name=N'PetName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the pet has been spayed/neutered.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPet', @level2type=N'COLUMN', @level2name=N'IsFixed'
GO

-- Extended Properties [sample].[StaffPetPreference] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about the staff member''s pet preferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPetPreference'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPetPreference', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred maximum weight of a household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPetPreference', @level2type=N'COLUMN', @level2name=N'MaximumWeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred minimum weight of a household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPetPreference', @level2type=N'COLUMN', @level2name=N'MinimumWeight'
GO

-- Extended Properties [sample].[StudentAquaticPet] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about aquatic pets in the student''s household', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum tank volume this aquatic pet requires.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet', @level2type=N'COLUMN', @level2name=N'MimimumTankVolume'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The pet''s name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet', @level2type=N'COLUMN', @level2name=N'PetName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the pet has been spayed/neutered.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet', @level2type=N'COLUMN', @level2name=N'IsFixed'
GO

-- Extended Properties [sample].[StudentArtProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is an example of a subclass of an association.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of art pieces completed by the student during the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ArtPieces'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Start date for the program''s art exhibit to display the student''s work.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ExhibitDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of hours a student spends in the program each school day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'HoursPerDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identification code used to identify the student''s artwork produced in the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'IdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s reserved time for use of the kiln.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'KilnReservation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of clock minutes dedicated to the student''s kiln reservation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'KilnReservationLength'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Percentage of the mediums taught in the program which the student mastered.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'MasteredMediums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number of days the student is in attendance at the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'NumberOfDaysInAttendance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of pieces in the student''s portfolio.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'PortfolioPieces'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the student participated in art education at a private agency or institution.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'PrivateArtProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Required program fees to purchase materials for the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramFees'
GO

-- Extended Properties [sample].[StudentArtProgramAssociationArtMedium] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The art mediums used in the program (i.e., paint, pencils, clay, etc.).', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The art mediums used in the program (i.e., paint, pencils, clay, etc.).', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'ArtMediumDescriptorId'
GO

-- Extended Properties [sample].[StudentArtProgramAssociationFavoriteBook] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s favorite art book. Used to test support for Common fields in extension subclasses of EdFi.GeneralStudentProgramAssociation, EdFi.EducationOrganization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook', @level2type=N'COLUMN', @level2name=N'BookTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBook', @level2type=N'COLUMN', @level2name=N'FavoriteBookCategoryDescriptorId'
GO

-- Extended Properties [sample].[StudentArtProgramAssociationFavoriteBookArtMedium] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ArtMediumDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ArtPieces'
GO

-- Extended Properties [sample].[StudentArtProgramAssociationPortfolioYears] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The of year(s) of work included in the student''s portfolio.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The of year(s) of work included in the student''s portfolio.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'PortfolioYears'
GO

-- Extended Properties [sample].[StudentArtProgramAssociationService] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the Service(s) being provided to the Student by the Program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the service being provided to the student by the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ServiceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True if service is a primary service.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'PrimaryIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'First date the student was in this option for the current school year.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ServiceBeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last date the student was in this option for the current school year.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ServiceEndDate'
GO

-- Extended Properties [sample].[StudentArtProgramAssociationStyle] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The art style(s) exhibited by the student in the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The art style(s) exhibited by the student in the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'Style'
GO

-- Extended Properties [sample].[StudentContactAssociationDiscipline] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of action used to discipline the student preferred by the contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationDiscipline'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationDiscipline', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationDiscipline', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of action used to discipline the student preferred by the contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationDiscipline', @level2type=N'COLUMN', @level2name=N'DisciplineDescriptorId'
GO

-- Extended Properties [sample].[StudentContactAssociationExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the contact regularly reads to the student before bed.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'BedtimeReader'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average number of pages the contact reads with the student each day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'BedtimeReadingRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The contact''s estimated monthly budget dedicated to books for the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'BookBudget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of books the contact has borrowed on behalf of the student to date.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'BooksBorrowed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to an intervention study.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'InterventionStudyIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual or estimated number of clock minutes for a given library visit.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'LibraryDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s regularly scheduled library time during the school day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'LibraryTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of visits a student is allowed to the library in a single school day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'LibraryVisits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Previous restrictions for student and/or teacher contact with the individual (e.g., the student may not be picked up by the individual).', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'PriorContactRestrictions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which the contact first read the student Green Eggs and Ham by Dr. Seuss.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'ReadGreenEggsAndHamDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of time the contact spends reading to the student each day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'ReadingTimeSpent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the student''s reading habits are being recorded.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationExtension', @level2type=N'COLUMN', @level2name=N'StudentRead'
GO

-- Extended Properties [sample].[StudentContactAssociationFavoriteBookTitle] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the student''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationFavoriteBookTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the student''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'FavoriteBookTitle'
GO

-- Extended Properties [sample].[StudentContactAssociationHoursPerWeek] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of hours per week a student and contact dedicates to reading.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationHoursPerWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationHoursPerWeek', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationHoursPerWeek', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of hours per week a student and contact dedicates to reading.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationHoursPerWeek', @level2type=N'COLUMN', @level2name=N'HoursPerWeek'
GO

-- Extended Properties [sample].[StudentContactAssociationPagesRead] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of pages the contact has read the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationPagesRead'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationPagesRead', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationPagesRead', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of pages the contact has read the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationPagesRead', @level2type=N'COLUMN', @level2name=N'PagesRead'
GO

-- Extended Properties [sample].[StudentContactAssociationStaffEducationOrganizationEmploymentAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A reference to the staff member and education organization assigned to help track the student''s reading abilities with the contact''s involvement.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationStaffEducationOrganizationEmploymentAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of employment or contract.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'EmploymentStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was hired for a position.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [sample].[StudentContactAssociationTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred telephone number for contact if the person is listed as an emergency contact for the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationTelephone', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationTelephone', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentContactAssociationTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO

-- Extended Properties [sample].[StudentCTEProgramAssociationExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identification code used to identify the student''s artwork produced in the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'AnalysisCompleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time the CTEProgram analysis was completed.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'AnalysisDate'
GO

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The apartment or housing complex name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'Complex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator if the address is on a bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'OnBusRoute'
GO

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressSchoolDistrict] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school district in which the address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school district in which the address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'SchoolDistrict'
GO

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressTerm] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terms applicable to this address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terms applicable to this address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [sample].[StudentEducationOrganizationAssociationExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationExtension', @level2type=N'COLUMN', @level2name=N'FavoriteProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationExtension', @level2type=N'COLUMN', @level2name=N'FavoriteProgramTypeDescriptorId'
GO

-- Extended Properties [sample].[StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time period of student need.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The characteristic designated for the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'StudentCharacteristicDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the parent characteristic is a primary student need.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'PrimaryStudentNeedIndicator'
GO

-- Extended Properties [sample].[StudentFavoriteBook] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBook'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBook', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBook', @level2type=N'COLUMN', @level2name=N'FavoriteBookCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBook', @level2type=N'COLUMN', @level2name=N'BookTitle'
GO

-- Extended Properties [sample].[StudentFavoriteBookArtMedium] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'FavoriteBookCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ArtMediumDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ArtPieces'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is an example of a new Association.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time of day for the commencement ceremony.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'CommencementTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the plan went into effect.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'EffectiveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any fees the student must resolve prior to graduation, such as library fines and overdue lunch accounts.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'GraduationFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of years remaining prior to graduation as of when the plan became effective.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'HighSchoolDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of hours per week the student will attend to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'HoursPerWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the plan is active.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'IsActivePlan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of time the student must attend to graduate, relative to a full-time student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'RequiredAttendance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The GPA the student is working toward.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'TargetGPA'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationAcademicSubject] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s favorite academic subjects.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s favorite academic subjects.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationCareerPathwayCode] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code representing the student''s intended career pathway after graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code representing the student''s intended career pathway after graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'CareerPathwayCode'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationCTEProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The career and technical program in which the student participates.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'CareerPathwayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number and description of the CIP code associated with the student''s CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'CIPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether the student has completed the CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'CTEProgramCompletionIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether this CTE program is the student''s primary CTE program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'PrimaryCTEProgramIndicator'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationDescription] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'Description'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationDesignatedBy] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The entity governing this graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The entity governing this graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationIndustryCredential] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Industry-recognized credentials the student will have earned at graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Industry-recognized credentials the student will have earned at graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'IndustryCredential'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationStudentContactAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact responsible for graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentContactAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentContactAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentContactAssociation', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentContactAssociation', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentContactAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a contact.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentContactAssociation', @level2type=N'COLUMN', @level2name=N'ContactUSI'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationYearsAttended] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of years the student will have attended high school by the time of graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of years the student will have attended high school by the time of graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'YearsAttended'
GO

-- Extended Properties [sample].[StudentPet] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about pets in the student''s household.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPet', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The pet''s name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPet', @level2type=N'COLUMN', @level2name=N'PetName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the pet has been spayed/neutered.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPet', @level2type=N'COLUMN', @level2name=N'IsFixed'
GO

-- Extended Properties [sample].[StudentPetPreference] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about the student''s pet preferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPetPreference'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPetPreference', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred maximum weight of a household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPetPreference', @level2type=N'COLUMN', @level2name=N'MaximumWeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred minimum weight of a household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPetPreference', @level2type=N'COLUMN', @level2name=N'MinimumWeight'
GO

-- Extended Properties [sample].[StudentSchoolAssociationExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociationExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual enters and begins to receive instructional services in a school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociationExtension', @level2type=N'COLUMN', @level2name=N'EntryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociationExtension', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociationExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Membership Type identifies whether a school has primary responsibility for managing a specific student''s curriculum or not.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociationExtension', @level2type=N'COLUMN', @level2name=N'MembershipTypeDescriptorId'
GO

-- Extended Properties [sample].[StudentSectionAssociationRelatedGeneralStudentProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Programs which this student is participating in that is supported by this coursework.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the student''s entry or assignment to the section.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'RelatedBeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'RelatedEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'RelatedProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'RelatedProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentSectionAssociationRelatedGeneralStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'RelatedProgramTypeDescriptorId'
GO

