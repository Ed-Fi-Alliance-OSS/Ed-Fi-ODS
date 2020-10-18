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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The direction of the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'BusRouteDirection'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the bus route operates every weekday.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'Daily'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The approximate annual cost for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'OperatingCost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the bus route became operational.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The approximate weekly mileage for the bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'WeeklyMileage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The approximate amount of time, in minutes, for the bus route operation each day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'ExpectedTransitTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of seats filled under optimal conditions.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'OptimalCapacity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of hours per week in which the bus route is operational.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'HoursPerWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of minutes per week in which the bus route is operational.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'BusRouteDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability served by the bus route, if applicable.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The titles of employment, official status, or rank of education staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'StaffClassificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the LEA.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRoute', @level2type=N'COLUMN', @level2name=N'BeginDate'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteProgram', @level2type=N'COLUMN', @level2name=N'ProgramName'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'BusRouteTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
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

-- Extended Properties [sample].[ParentAddressExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional details on the parent''s address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The apartment or housing complex name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension', @level2type=N'COLUMN', @level2name=N'Complex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator if the address is on a bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressExtension', @level2type=N'COLUMN', @level2name=N'OnBusRoute'
GO

-- Extended Properties [sample].[ParentAddressSchoolDistrict] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school district in which the address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressSchoolDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school district in which the address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'SchoolDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO

-- Extended Properties [sample].[ParentAddressTerm] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terms applicable to this address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressTerm', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressTerm', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressTerm', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressTerm', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressTerm', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressTerm', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terms applicable to this address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAddressTerm', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [sample].[ParentAuthor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The parent''s favorite authors.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAuthor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The parent''s favorite authors.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAuthor', @level2type=N'COLUMN', @level2name=N'Author'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentAuthor', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO

-- Extended Properties [sample].[ParentCeilingHeight] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The height of the ceiling in the rooms of the parent''s home.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCeilingHeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The height of the ceiling in the rooms of the parent''s home.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCeilingHeight', @level2type=N'COLUMN', @level2name=N'CeilingHeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCeilingHeight', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO

-- Extended Properties [sample].[ParentCTEProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A CTE program the parent has completed.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCTEProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCTEProgram', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCTEProgram', @level2type=N'COLUMN', @level2name=N'CareerPathwayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number and description of the CIP Code associated with the student''s CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCTEProgram', @level2type=N'COLUMN', @level2name=N'CIPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether this CTEProgram, is the student''s primary CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCTEProgram', @level2type=N'COLUMN', @level2name=N'PrimaryCTEProgramIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether the Student has completed the CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentCTEProgram', @level2type=N'COLUMN', @level2name=N'CTEProgramCompletionIndicator'
GO

-- Extended Properties [sample].[ParentEducationContent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Education content to which the parent has been referred.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentEducationContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier for the EducationContent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentEducationContent', @level2type=N'COLUMN', @level2name=N'ContentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentEducationContent', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO

-- Extended Properties [sample].[ParentExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the parent is a sports fan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'IsSportsFan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'How much the parent spends on coffee in a week.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'CoffeeSpend'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the parent graduated high school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'GraduationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time spent per day waiting in the car line.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'AverageCarLineWait'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The parent''s lucky number.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'LuckyNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent likelihood that it will rain when the parent volunteers to chaperone a field trip.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'RainCertainty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time the parent would prefer to wake up in the morning.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'PreferredWakeUpTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the parent first became a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'BecameParent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The parent''s high school GPA.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'GPA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of time the parent spends reading to his/her children at bedtime.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The field in which the parent holds a credential.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentExtension', @level2type=N'COLUMN', @level2name=N'CredentialFieldDescriptorId'
GO

-- Extended Properties [sample].[ParentFavoriteBookTitle] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the parent''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentFavoriteBookTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the parent''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'FavoriteBookTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO

-- Extended Properties [sample].[ParentStudentProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Programs the parent''s child or children are enrolled in for which the parent provides volunteer services.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentStudentProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentStudentProgramAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[ParentTeacherConference] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The parent''s preferred day of the week and time for parent-teacher conferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentTeacherConference'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentTeacherConference', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day of the week the parent prefers to meet for parent-teacher conferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentTeacherConference', @level2type=N'COLUMN', @level2name=N'DayOfWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The start time the parent prefers to meet for parent-teacher conferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentTeacherConference', @level2type=N'COLUMN', @level2name=N'StartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end time the parent prefers to meet for parent-teacher conferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'ParentTeacherConference', @level2type=N'COLUMN', @level2name=N'EndTime'
GO

-- Extended Properties [sample].[SchoolCTEProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A CTE program the school is known for.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'CareerPathwayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number and description of the CIP Code associated with the student''s CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'CIPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether this CTEProgram, is the student''s primary CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'PrimaryCTEProgramIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether the Student has completed the CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolCTEProgram', @level2type=N'COLUMN', @level2name=N'CTEProgramCompletionIndicator'
GO

-- Extended Properties [sample].[SchoolDirectlyOwnedBus] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buses owned by the School directly.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolDirectlyOwnedBus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the bus.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolDirectlyOwnedBus', @level2type=N'COLUMN', @level2name=N'DirectlyOwnedBusId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'SchoolDirectlyOwnedBus', @level2type=N'COLUMN', @level2name=N'SchoolId'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The pet''s name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPet', @level2type=N'COLUMN', @level2name=N'PetName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPet', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the pet has been spayed/neutered.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPet', @level2type=N'COLUMN', @level2name=N'IsFixed'
GO

-- Extended Properties [sample].[StaffPetPreference] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about the staff member''s pet preferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPetPreference'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPetPreference', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred minimum weight of a household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPetPreference', @level2type=N'COLUMN', @level2name=N'MinimumWeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred maximum weight of a household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StaffPetPreference', @level2type=N'COLUMN', @level2name=N'MaximumWeight'
GO

-- Extended Properties [sample].[StudentAquaticPet] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about aquatic pets in the student''s household', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum tank volume this aquatic pet requires.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet', @level2type=N'COLUMN', @level2name=N'MimimumTankVolume'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The pet''s name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet', @level2type=N'COLUMN', @level2name=N'PetName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentAquaticPet', @level2type=N'COLUMN', @level2name=N'StudentUSI'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identification code used to identify the student''s artwork produced in the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'IdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Start date for the program''s art exhibit to display the student''s work.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ExhibitDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Required program fees to purchase materials for the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramFees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number of days the student is in attendance at the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'NumberOfDaysInAttendance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of hours a student spends in the program each school day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'HoursPerDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the student participated in art education at a private agency or institution.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'PrivateArtProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s reserved time for use of the kiln.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'KilnReservation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of clock minutes dedicated to the student''s kiln reservation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'KilnReservationLength'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of art pieces completed by the student during the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'ArtPieces'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of pieces in the student''s portfolio.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'PortfolioPieces'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Percentage of the mediums taught in the program which the student mastered.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociation', @level2type=N'COLUMN', @level2name=N'MasteredMediums'
GO

-- Extended Properties [sample].[StudentArtProgramAssociationArtMedium] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The art mediums used in the program (i.e., paint, pencils, clay, etc.).', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The art mediums used in the program (i.e., paint, pencils, clay, etc.).', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'ArtMediumDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationArtMedium', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentArtProgramAssociationPortfolioYears] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The of year(s) of work included in the student''s portfolio.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The of year(s) of work included in the student''s portfolio.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'PortfolioYears'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'ProgramEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationPortfolioYears', @level2type=N'COLUMN', @level2name=N'StudentUSI'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the Service being provided to the student by the Program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ServiceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True if service is a primary service.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'PrimaryIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'First date the Student was in this option for the current school year.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ServiceBeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last date the Student was in this option for the current school year.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationService', @level2type=N'COLUMN', @level2name=N'ServiceEndDate'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The art style(s) exhibited by the student in the program.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentArtProgramAssociationStyle', @level2type=N'COLUMN', @level2name=N'Style'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentCTEProgramAssociationExtension', @level2type=N'COLUMN', @level2name=N'ProgramName'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The apartment or housing complex name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'Complex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator if the address is on a bus route.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressExtension', @level2type=N'COLUMN', @level2name=N'OnBusRoute'
GO

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressSchoolDistrict] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school district in which the address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school district in which the address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'SchoolDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressSchoolDistrict', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressTerm] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terms applicable to this address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terms applicable to this address.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationAddressTerm', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [sample].[StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time period of student need.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The characteristic designated for the Student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'StudentCharacteristicDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the parent characteristic is a primary student need.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'PrimaryStudentNeedIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [sample].[StudentFavoriteBook] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBook'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBook', @level2type=N'COLUMN', @level2name=N'FavoriteBookCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBook', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBook', @level2type=N'COLUMN', @level2name=N'BookTitle'
GO

-- Extended Properties [sample].[StudentFavoriteBookArtMedium] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ArtMediumDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'FavoriteBookCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is documentation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentFavoriteBookArtMedium', @level2type=N'COLUMN', @level2name=N'ArtPieces'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is an example of a new Association.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the plan went into effect.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'EffectiveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the plan is active.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'IsActivePlan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any fees the student must resolve prior to graduation, such as library fines and overdue lunch accounts.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'GraduationFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The GPA the student is working toward.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'TargetGPA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of years remaining prior to graduation as of when the plan became effective.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'HighSchoolDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of time the student must attend to graduate, relative to a full-time student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'RequiredAttendance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time of day for the commencement ceremony.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'CommencementTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of hours per week the student will attend to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'HoursPerWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationAcademicSubject] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s favorite academic subjects.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s favorite academic subjects.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationAcademicSubject', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationCareerPathwayCode] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code representing the student''s intended career pathway after graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code representing the student''s intended career pathway after graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'CareerPathwayCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCareerPathwayCode', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationCTEProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The career and technical program in which the student participates.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'CareerPathwayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number and description of the CIP Code associated with the student''s CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'CIPCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether this CTEProgram, is the student''s primary CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'PrimaryCTEProgramIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A boolean indicator of whether the Student has completed the CTEProgram.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationCTEProgram', @level2type=N'COLUMN', @level2name=N'CTEProgramCompletionIndicator'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationDescription] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDescription', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationDesignatedBy] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The entity governing this graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The entity governing this graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationDesignatedBy', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationIndustryCredential] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Industry-recognized credentials the student will have earned at graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Industry-recognized credentials the student will have earned at graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'IndustryCredential'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationIndustryCredential', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationStudentParentAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent responsible for graduation plan.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentParentAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentParentAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentParentAssociation', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentParentAssociation', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentParentAssociation', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationStudentParentAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentGraduationPlanAssociationYearsAttended] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of years the student will have attended high school by the time of graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of years the student will have attended high school by the time of graduation.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentGraduationPlanAssociationYearsAttended', @level2type=N'COLUMN', @level2name=N'YearsAttended'
GO

-- Extended Properties [sample].[StudentParentAssociationDiscipline] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of action used to discipline the student preferred by the parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationDiscipline'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of action used to discipline the student preferred by the parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationDiscipline', @level2type=N'COLUMN', @level2name=N'DisciplineDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationDiscipline', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationDiscipline', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentParentAssociationExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Previous restrictions for student and/or teacher contact with the individual (e.g., the student may not be picked up by the individual).', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'PriorContactRestrictions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the parent regularly reads to the student before bed.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'BedtimeReader'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The parent''s estimated monthly budget dedicated to books for the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'BookBudget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which the parent first read the student Green Eggs and Ham by Dr. Seuss.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'ReadGreenEggsAndHamDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of time the parent spends reading to the student each day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'ReadingTimeSpent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of books the parent has borrowed on behalf of the student to date.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'BooksBorrowed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average number of pages the parent reads with the student each day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'BedtimeReadingRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The student''s regularly scheduled library time during the school day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'LibraryTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of visits a student is allowed to the library in a single school day.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'LibraryVisits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the student''s reading habits are being recorded.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'StudentRead'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual or estimated number of clock minutes for a given library visit.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'LibraryDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to an intervention study.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationExtension', @level2type=N'COLUMN', @level2name=N'InterventionStudyIdentificationCode'
GO

-- Extended Properties [sample].[StudentParentAssociationFavoriteBookTitle] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the student''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationFavoriteBookTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the student''s favorite book.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'FavoriteBookTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationFavoriteBookTitle', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentParentAssociationHoursPerWeek] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of hours per week a student and parent dedicates to reading.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationHoursPerWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of hours per week a student and parent dedicates to reading.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationHoursPerWeek', @level2type=N'COLUMN', @level2name=N'HoursPerWeek'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationHoursPerWeek', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationHoursPerWeek', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentParentAssociationPagesRead] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of pages the parent has read the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationPagesRead'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of pages the parent has read the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationPagesRead', @level2type=N'COLUMN', @level2name=N'PagesRead'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationPagesRead', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationPagesRead', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentParentAssociationStaffEducationOrganizationEmploymentAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A reference to the staff member and education organization assigned to help track the student''s reading abilities with the parent''s involvement.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationStaffEducationOrganizationEmploymentAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'EmploymentStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was hired for a position.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationStaffEducationOrganizationEmploymentAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [sample].[StudentParentAssociationTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred telephone number for contact if the person is listed as an emergency contact for the student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a parent.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationTelephone', @level2type=N'COLUMN', @level2name=N'ParentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationTelephone', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentParentAssociationTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [sample].[StudentPet] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about pets in the student''s household.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The pet''s name.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPet', @level2type=N'COLUMN', @level2name=N'PetName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPet', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication as to whether the pet has been spayed/neutered.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPet', @level2type=N'COLUMN', @level2name=N'IsFixed'
GO

-- Extended Properties [sample].[StudentPetPreference] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details about the student''s pet preferences.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPetPreference'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPetPreference', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred minimum weight of a household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPetPreference', @level2type=N'COLUMN', @level2name=N'MinimumWeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The preferred maximum weight of a household pet.', @level0type=N'SCHEMA', @level0name=N'sample', @level1type=N'TABLE', @level1name=N'StudentPetPreference', @level2type=N'COLUMN', @level2name=N'MaximumWeight'
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

