-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [sample].[ArtMediumDescriptor] --
COMMENT ON TABLE sample.ArtMediumDescriptor IS 'Art medium used in a section or program (i.e. paint, pencils, clay, etc.).';
COMMENT ON COLUMN sample.ArtMediumDescriptor.ArtMediumDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [sample].[Bus] --
COMMENT ON TABLE sample.Bus IS 'This is an example of a new domain entity.';
COMMENT ON COLUMN sample.Bus.BusId IS 'The unique identifier for the bus.';

-- Extended Properties [sample].[BusRoute] --
COMMENT ON TABLE sample.BusRoute IS 'This is an example of a new domain entity.';
COMMENT ON COLUMN sample.BusRoute.BusId IS 'The unique identifier for the bus assigned to the bus route.';
COMMENT ON COLUMN sample.BusRoute.BusRouteNumber IS 'A unique identifier for the bus route.';
COMMENT ON COLUMN sample.BusRoute.BeginDate IS 'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the education organization.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.BusRoute.BusRouteDirection IS 'The direction of the bus route.';
COMMENT ON COLUMN sample.BusRoute.BusRouteDuration IS 'The number of minutes per week in which the bus route is operational.';
COMMENT ON COLUMN sample.BusRoute.Daily IS 'An indication as to whether the bus route operates every weekday.';
COMMENT ON COLUMN sample.BusRoute.DisabilityDescriptorId IS 'The disability served by the bus route, if applicable.';
COMMENT ON COLUMN sample.BusRoute.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.BusRoute.ExpectedTransitTime IS 'The approximate amount of time, in minutes, for the bus route operation each day.';
COMMENT ON COLUMN sample.BusRoute.HoursPerWeek IS 'The number of hours per week in which the bus route is operational.';
COMMENT ON COLUMN sample.BusRoute.OperatingCost IS 'The approximate annual cost for the bus route.';
COMMENT ON COLUMN sample.BusRoute.OptimalCapacity IS 'The percentage of seats filled under optimal conditions.';
COMMENT ON COLUMN sample.BusRoute.StaffClassificationDescriptorId IS 'The titles of employment, official status, or rank of education staff.';
COMMENT ON COLUMN sample.BusRoute.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.BusRoute.StartDate IS 'The date the bus route became operational.';
COMMENT ON COLUMN sample.BusRoute.WeeklyMileage IS 'The approximate weekly mileage for the bus route.';

-- Extended Properties [sample].[BusRouteBusYear] --
COMMENT ON TABLE sample.BusRouteBusYear IS 'The years in which the bus route has been in active.';
COMMENT ON COLUMN sample.BusRouteBusYear.BusId IS 'The unique identifier for the bus assigned to the bus route.';
COMMENT ON COLUMN sample.BusRouteBusYear.BusRouteNumber IS 'A unique identifier for the bus route.';
COMMENT ON COLUMN sample.BusRouteBusYear.BusYear IS 'The years in which the bus route has been in active.';

-- Extended Properties [sample].[BusRouteProgram] --
COMMENT ON TABLE sample.BusRouteProgram IS 'Programs served by the bus route.';
COMMENT ON COLUMN sample.BusRouteProgram.BusId IS 'The unique identifier for the bus assigned to the bus route.';
COMMENT ON COLUMN sample.BusRouteProgram.BusRouteNumber IS 'A unique identifier for the bus route.';
COMMENT ON COLUMN sample.BusRouteProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.BusRouteProgram.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.BusRouteProgram.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [sample].[BusRouteServiceAreaPostalCode] --
COMMENT ON TABLE sample.BusRouteServiceAreaPostalCode IS 'The postal codes served by the bus route.';
COMMENT ON COLUMN sample.BusRouteServiceAreaPostalCode.BusId IS 'The unique identifier for the bus assigned to the bus route.';
COMMENT ON COLUMN sample.BusRouteServiceAreaPostalCode.BusRouteNumber IS 'A unique identifier for the bus route.';
COMMENT ON COLUMN sample.BusRouteServiceAreaPostalCode.ServiceAreaPostalCode IS 'The postal codes served by the bus route.';

-- Extended Properties [sample].[BusRouteStartTime] --
COMMENT ON TABLE sample.BusRouteStartTime IS 'The time the bus route begins.';
COMMENT ON COLUMN sample.BusRouteStartTime.BusId IS 'The unique identifier for the bus assigned to the bus route.';
COMMENT ON COLUMN sample.BusRouteStartTime.BusRouteNumber IS 'A unique identifier for the bus route.';
COMMENT ON COLUMN sample.BusRouteStartTime.StartTime IS 'The time the bus route begins.';

-- Extended Properties [sample].[BusRouteTelephone] --
COMMENT ON TABLE sample.BusRouteTelephone IS 'Telephone numbers at which dispatchers may be reached for this bus route.';
COMMENT ON COLUMN sample.BusRouteTelephone.BusId IS 'The unique identifier for the bus assigned to the bus route.';
COMMENT ON COLUMN sample.BusRouteTelephone.BusRouteNumber IS 'A unique identifier for the bus route.';
COMMENT ON COLUMN sample.BusRouteTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN sample.BusRouteTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN sample.BusRouteTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';
COMMENT ON COLUMN sample.BusRouteTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN sample.BusRouteTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';

-- Extended Properties [sample].[ContactAddressExtension] --
COMMENT ON TABLE sample.ContactAddressExtension IS 'Additional details on the contact''s address.';
COMMENT ON COLUMN sample.ContactAddressExtension.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactAddressExtension.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.ContactAddressExtension.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.ContactAddressExtension.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.ContactAddressExtension.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.ContactAddressExtension.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.ContactAddressExtension.Complex IS 'The apartment or housing complex name.';
COMMENT ON COLUMN sample.ContactAddressExtension.OnBusRoute IS 'An indicator if the address is on a bus route.';

-- Extended Properties [sample].[ContactAddressSchoolDistrict] --
COMMENT ON TABLE sample.ContactAddressSchoolDistrict IS 'The school district in which the address is located.';
COMMENT ON COLUMN sample.ContactAddressSchoolDistrict.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactAddressSchoolDistrict.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.ContactAddressSchoolDistrict.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.ContactAddressSchoolDistrict.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.ContactAddressSchoolDistrict.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.ContactAddressSchoolDistrict.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.ContactAddressSchoolDistrict.SchoolDistrict IS 'The school district in which the address is located.';

-- Extended Properties [sample].[ContactAddressTerm] --
COMMENT ON TABLE sample.ContactAddressTerm IS 'Terms applicable to this address.';
COMMENT ON COLUMN sample.ContactAddressTerm.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactAddressTerm.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.ContactAddressTerm.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.ContactAddressTerm.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.ContactAddressTerm.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.ContactAddressTerm.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.ContactAddressTerm.TermDescriptorId IS 'Terms applicable to this address.';

-- Extended Properties [sample].[ContactAuthor] --
COMMENT ON TABLE sample.ContactAuthor IS 'The contact''s favorite authors.';
COMMENT ON COLUMN sample.ContactAuthor.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactAuthor.Author IS 'The contact''s favorite authors.';

-- Extended Properties [sample].[ContactCeilingHeight] --
COMMENT ON TABLE sample.ContactCeilingHeight IS 'The height of the ceiling in the rooms of the contact''s home.';
COMMENT ON COLUMN sample.ContactCeilingHeight.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactCeilingHeight.CeilingHeight IS 'The height of the ceiling in the rooms of the contact''s home.';

-- Extended Properties [sample].[ContactCTEProgramService] --
COMMENT ON TABLE sample.ContactCTEProgramService IS 'A CTE program the contact has completed.';
COMMENT ON COLUMN sample.ContactCTEProgramService.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactCTEProgramService.CIPCode IS 'Number and description of the CIP code associated with the student''s CTE program.';
COMMENT ON COLUMN sample.ContactCTEProgramService.CTEProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the CTE program.';
COMMENT ON COLUMN sample.ContactCTEProgramService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN sample.ContactCTEProgramService.ServiceBeginDate IS 'First date the student was in this option for the current school year.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.ContactCTEProgramService.ServiceEndDate IS 'Last date the student was in this option for the current school year.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';

-- Extended Properties [sample].[ContactEducationContent] --
COMMENT ON TABLE sample.ContactEducationContent IS 'Education content to which the contact has been referred.';
COMMENT ON COLUMN sample.ContactEducationContent.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactEducationContent.ContentIdentifier IS 'A unique identifier for the education content.';

-- Extended Properties [sample].[ContactExtension] --
COMMENT ON TABLE sample.ContactExtension IS '';
COMMENT ON COLUMN sample.ContactExtension.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactExtension.AverageCarLineWait IS 'The time spent per day waiting in the car line.';
COMMENT ON COLUMN sample.ContactExtension.BecameParent IS 'The year in which the contact first became a contact.';
COMMENT ON COLUMN sample.ContactExtension.CoffeeSpend IS 'How much the contact spends on coffee in a week.';
COMMENT ON COLUMN sample.ContactExtension.CredentialFieldDescriptorId IS 'The field in which the contact holds a credential.';
COMMENT ON COLUMN sample.ContactExtension.Duration IS 'The amount of time the contact spends reading to his/her children at bedtime.';
COMMENT ON COLUMN sample.ContactExtension.GPA IS 'The contact''s high school GPA.';
COMMENT ON COLUMN sample.ContactExtension.GraduationDate IS 'The date the contact graduated high school.';
COMMENT ON COLUMN sample.ContactExtension.IsSportsFan IS 'An indication as to whether the contact is a sports fan.';
COMMENT ON COLUMN sample.ContactExtension.LuckyNumber IS 'The contact''s lucky number.';
COMMENT ON COLUMN sample.ContactExtension.PreferredWakeUpTime IS 'The time the contact would prefer to wake up in the morning.';
COMMENT ON COLUMN sample.ContactExtension.RainCertainty IS 'The percent likelihood that it will rain when the contact volunteers to chaperone a field trip.';

-- Extended Properties [sample].[ContactFavoriteBookTitle] --
COMMENT ON TABLE sample.ContactFavoriteBookTitle IS 'The title of the contact''s favorite book.';
COMMENT ON COLUMN sample.ContactFavoriteBookTitle.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactFavoriteBookTitle.FavoriteBookTitle IS 'The title of the contact''s favorite book.';

-- Extended Properties [sample].[ContactStudentProgramAssociation] --
COMMENT ON TABLE sample.ContactStudentProgramAssociation IS 'Programs the contact''s child or children are enrolled in for which the contact provides volunteer services.';
COMMENT ON COLUMN sample.ContactStudentProgramAssociation.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactStudentProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.ContactStudentProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.ContactStudentProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.ContactStudentProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.ContactStudentProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.ContactStudentProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[ContactTeacherConference] --
COMMENT ON TABLE sample.ContactTeacherConference IS 'The contact''s preferred day of the week and time for contact-teacher conferences.';
COMMENT ON COLUMN sample.ContactTeacherConference.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.ContactTeacherConference.DayOfWeek IS 'The day of the week the parent prefers to meet for parent-teacher conferences.';
COMMENT ON COLUMN sample.ContactTeacherConference.EndTime IS 'The end time the parent prefers to meet for parent-teacher conferences.';
COMMENT ON COLUMN sample.ContactTeacherConference.StartTime IS 'The start time the parent prefers to meet for parent-teacher conferences.';

-- Extended Properties [sample].[FavoriteBookCategoryDescriptor] --
COMMENT ON TABLE sample.FavoriteBookCategoryDescriptor IS 'The category of an individual''s favorite book.';
COMMENT ON COLUMN sample.FavoriteBookCategoryDescriptor.FavoriteBookCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [sample].[MembershipTypeDescriptor] --
COMMENT ON TABLE sample.MembershipTypeDescriptor IS 'Membership Type identifies whether a school has primary responsibility for managing a specific student''s curriculum or not.';
COMMENT ON COLUMN sample.MembershipTypeDescriptor.MembershipTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [sample].[SchoolCTEProgramService] --
COMMENT ON TABLE sample.SchoolCTEProgramService IS 'A CTE program the school is known for.';
COMMENT ON COLUMN sample.SchoolCTEProgramService.SchoolId IS 'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';
COMMENT ON COLUMN sample.SchoolCTEProgramService.CIPCode IS 'Number and description of the CIP code associated with the student''s CTE program.';
COMMENT ON COLUMN sample.SchoolCTEProgramService.CTEProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the CTE program.';
COMMENT ON COLUMN sample.SchoolCTEProgramService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN sample.SchoolCTEProgramService.ServiceBeginDate IS 'First date the student was in this option for the current school year.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.SchoolCTEProgramService.ServiceEndDate IS 'Last date the student was in this option for the current school year.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';

-- Extended Properties [sample].[SchoolDirectlyOwnedBus] --
COMMENT ON TABLE sample.SchoolDirectlyOwnedBus IS 'Buses owned by the School directly.';
COMMENT ON COLUMN sample.SchoolDirectlyOwnedBus.SchoolId IS 'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';
COMMENT ON COLUMN sample.SchoolDirectlyOwnedBus.DirectlyOwnedBusId IS 'The unique identifier for the bus.';

-- Extended Properties [sample].[SchoolExtension] --
COMMENT ON TABLE sample.SchoolExtension IS '';
COMMENT ON COLUMN sample.SchoolExtension.SchoolId IS 'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';
COMMENT ON COLUMN sample.SchoolExtension.IsExemplary IS 'An indication as to whether the school is exemplary.';

-- Extended Properties [sample].[StaffExtension] --
COMMENT ON TABLE sample.StaffExtension IS '';
COMMENT ON COLUMN sample.StaffExtension.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.StaffExtension.FirstPetOwnedDate IS 'The date the staff member adopted the first household pet.';

-- Extended Properties [sample].[StaffPet] --
COMMENT ON TABLE sample.StaffPet IS 'Details about pets in the staff member''s household.';
COMMENT ON COLUMN sample.StaffPet.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.StaffPet.PetName IS 'The pet''s name.';
COMMENT ON COLUMN sample.StaffPet.IsFixed IS 'An indication as to whether the pet has been spayed/neutered.';

-- Extended Properties [sample].[StaffPetPreference] --
COMMENT ON TABLE sample.StaffPetPreference IS 'Details about the staff member''s pet preferences.';
COMMENT ON COLUMN sample.StaffPetPreference.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.StaffPetPreference.MaximumWeight IS 'The preferred maximum weight of a household pet.';
COMMENT ON COLUMN sample.StaffPetPreference.MinimumWeight IS 'The preferred minimum weight of a household pet.';

-- Extended Properties [sample].[StudentAquaticPet] --
COMMENT ON TABLE sample.StudentAquaticPet IS 'Details about aquatic pets in the student''s household';
COMMENT ON COLUMN sample.StudentAquaticPet.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentAquaticPet.MimimumTankVolume IS 'The minimum tank volume this aquatic pet requires.';
COMMENT ON COLUMN sample.StudentAquaticPet.PetName IS 'The pet''s name.';
COMMENT ON COLUMN sample.StudentAquaticPet.IsFixed IS 'An indication as to whether the pet has been spayed/neutered.';

-- Extended Properties [sample].[StudentArtProgramAssociation] --
COMMENT ON TABLE sample.StudentArtProgramAssociation IS 'This is an example of a subclass of an association.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ArtPieces IS 'The total number of art pieces completed by the student during the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ExhibitDate IS 'Start date for the program''s art exhibit to display the student''s work.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.HoursPerDay IS 'The number of hours a student spends in the program each school day.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.IdentificationCode IS 'A unique identification code used to identify the student''s artwork produced in the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.KilnReservation IS 'The student''s reserved time for use of the kiln.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.KilnReservationLength IS 'The number of clock minutes dedicated to the student''s kiln reservation.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.MasteredMediums IS 'Percentage of the mediums taught in the program which the student mastered.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.NumberOfDaysInAttendance IS 'Number of days the student is in attendance at the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.PortfolioPieces IS 'The total number of pieces in the student''s portfolio.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.PrivateArtProgram IS 'Indicator that the student participated in art education at a private agency or institution.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ProgramFees IS 'Required program fees to purchase materials for the student.';

-- Extended Properties [sample].[StudentArtProgramAssociationArtMedium] --
COMMENT ON TABLE sample.StudentArtProgramAssociationArtMedium IS 'The art mediums used in the program (i.e., paint, pencils, clay, etc.).';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.ArtMediumDescriptorId IS 'The art mediums used in the program (i.e., paint, pencils, clay, etc.).';

-- Extended Properties [sample].[StudentArtProgramAssociationFavoriteBook] --
COMMENT ON TABLE sample.StudentArtProgramAssociationFavoriteBook IS 'The student''s favorite art book. Used to test support for Common fields in extension subclasses of EdFi.GeneralStudentProgramAssociation, EdFi.EducationOrganization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBook.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBook.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBook.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBook.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBook.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBook.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBook.BookTitle IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBook.FavoriteBookCategoryDescriptorId IS 'This is documentation.';

-- Extended Properties [sample].[StudentArtProgramAssociationFavoriteBookArtMedium] --
COMMENT ON TABLE sample.StudentArtProgramAssociationFavoriteBookArtMedium IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBookArtMedium.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBookArtMedium.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBookArtMedium.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBookArtMedium.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBookArtMedium.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBookArtMedium.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBookArtMedium.ArtMediumDescriptorId IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationFavoriteBookArtMedium.ArtPieces IS 'This is documentation.';

-- Extended Properties [sample].[StudentArtProgramAssociationPortfolioYears] --
COMMENT ON TABLE sample.StudentArtProgramAssociationPortfolioYears IS 'The of year(s) of work included in the student''s portfolio.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.PortfolioYears IS 'The of year(s) of work included in the student''s portfolio.';

-- Extended Properties [sample].[StudentArtProgramAssociationService] --
COMMENT ON TABLE sample.StudentArtProgramAssociationService IS 'Indicates the Service(s) being provided to the Student by the Program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ServiceDescriptorId IS 'Indicates the service being provided to the student by the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ServiceBeginDate IS 'First date the student was in this option for the current school year.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ServiceEndDate IS 'Last date the student was in this option for the current school year.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';

-- Extended Properties [sample].[StudentArtProgramAssociationStyle] --
COMMENT ON TABLE sample.StudentArtProgramAssociationStyle IS 'The art style(s) exhibited by the student in the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.Style IS 'The art style(s) exhibited by the student in the program.';

-- Extended Properties [sample].[StudentContactAssociationDiscipline] --
COMMENT ON TABLE sample.StudentContactAssociationDiscipline IS 'The type of action used to discipline the student preferred by the contact.';
COMMENT ON COLUMN sample.StudentContactAssociationDiscipline.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.StudentContactAssociationDiscipline.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentContactAssociationDiscipline.DisciplineDescriptorId IS 'The type of action used to discipline the student preferred by the contact.';

-- Extended Properties [sample].[StudentContactAssociationExtension] --
COMMENT ON TABLE sample.StudentContactAssociationExtension IS '';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.BedtimeReader IS 'An indication as to whether the contact regularly reads to the student before bed.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.BedtimeReadingRate IS 'The average number of pages the contact reads with the student each day.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.BookBudget IS 'The contact''s estimated monthly budget dedicated to books for the student.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.BooksBorrowed IS 'The total number of books the contact has borrowed on behalf of the student to date.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.LibraryDuration IS 'The actual or estimated number of clock minutes for a given library visit.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.LibraryTime IS 'The student''s regularly scheduled library time during the school day.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.LibraryVisits IS 'Total number of visits a student is allowed to the library in a single school day.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.PriorContactRestrictions IS 'Previous restrictions for student and/or teacher contact with the individual (e.g., the student may not be picked up by the individual).';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.ReadGreenEggsAndHamDate IS 'Date on which the contact first read the student Green Eggs and Ham by Dr. Seuss.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.ReadingTimeSpent IS 'The amount of time the contact spends reading to the student each day.';
COMMENT ON COLUMN sample.StudentContactAssociationExtension.StudentRead IS 'The year in which the student''s reading habits are being recorded.';

-- Extended Properties [sample].[StudentContactAssociationFavoriteBookTitle] --
COMMENT ON TABLE sample.StudentContactAssociationFavoriteBookTitle IS 'The title of the student''s favorite book.';
COMMENT ON COLUMN sample.StudentContactAssociationFavoriteBookTitle.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.StudentContactAssociationFavoriteBookTitle.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentContactAssociationFavoriteBookTitle.FavoriteBookTitle IS 'The title of the student''s favorite book.';

-- Extended Properties [sample].[StudentContactAssociationHoursPerWeek] --
COMMENT ON TABLE sample.StudentContactAssociationHoursPerWeek IS 'Total number of hours per week a student and contact dedicates to reading.';
COMMENT ON COLUMN sample.StudentContactAssociationHoursPerWeek.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.StudentContactAssociationHoursPerWeek.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentContactAssociationHoursPerWeek.HoursPerWeek IS 'Total number of hours per week a student and contact dedicates to reading.';

-- Extended Properties [sample].[StudentContactAssociationPagesRead] --
COMMENT ON TABLE sample.StudentContactAssociationPagesRead IS 'Total number of pages the contact has read the student.';
COMMENT ON COLUMN sample.StudentContactAssociationPagesRead.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.StudentContactAssociationPagesRead.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentContactAssociationPagesRead.PagesRead IS 'Total number of pages the contact has read the student.';

-- Extended Properties [sample].[StudentContactAssociationStaffEducationOrganizationEmplo_a92b1d] --
COMMENT ON TABLE sample.StudentContactAssociationStaffEducationOrganizationEmplo_a92b1d IS 'A reference to the staff member and education organization assigned to help track the student''s reading abilities with the contact''s involvement.';
COMMENT ON COLUMN sample.StudentContactAssociationStaffEducationOrganizationEmplo_a92b1d.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.StudentContactAssociationStaffEducationOrganizationEmplo_a92b1d.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentContactAssociationStaffEducationOrganizationEmplo_a92b1d.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentContactAssociationStaffEducationOrganizationEmplo_a92b1d.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract.';
COMMENT ON COLUMN sample.StudentContactAssociationStaffEducationOrganizationEmplo_a92b1d.HireDate IS 'The month, day, and year on which an individual was hired for a position.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentContactAssociationStaffEducationOrganizationEmplo_a92b1d.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [sample].[StudentContactAssociationTelephone] --
COMMENT ON TABLE sample.StudentContactAssociationTelephone IS 'The preferred telephone number for contact if the person is listed as an emergency contact for the student.';
COMMENT ON COLUMN sample.StudentContactAssociationTelephone.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';
COMMENT ON COLUMN sample.StudentContactAssociationTelephone.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentContactAssociationTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';
COMMENT ON COLUMN sample.StudentContactAssociationTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN sample.StudentContactAssociationTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN sample.StudentContactAssociationTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN sample.StudentContactAssociationTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';

-- Extended Properties [sample].[StudentCTEProgramAssociationExtension] --
COMMENT ON TABLE sample.StudentCTEProgramAssociationExtension IS '';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.AnalysisCompleted IS 'A unique identification code used to identify the student''s artwork produced in the program.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.AnalysisDate IS 'The date and time the CTEProgram analysis was completed.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressExtension] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationAddressExtension IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.Complex IS 'The apartment or housing complex name.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.OnBusRoute IS 'An indicator if the address is on a bus route.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressSchoolDistrict] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationAddressSchoolDistrict IS 'The school district in which the address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.SchoolDistrict IS 'The school district in which the address is located.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressTerm] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationAddressTerm IS 'Terms applicable to this address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.TermDescriptorId IS 'Terms applicable to this address.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationExtension] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationExtension IS '';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationExtension.FavoriteProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationExtension.FavoriteProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationStudentCharacteri_17d152] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152 IS 'The time period of student need.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.StudentCharacteristicDescriptorId IS 'The characteristic designated for the student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.EndDate IS 'The month, day, and year for the end of the period.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.PrimaryStudentNeedIndicator IS 'Indicates the parent characteristic is a primary student need.';

-- Extended Properties [sample].[StudentFavoriteBook] --
COMMENT ON TABLE sample.StudentFavoriteBook IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBook.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentFavoriteBook.FavoriteBookCategoryDescriptorId IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBook.BookTitle IS 'This is documentation.';

-- Extended Properties [sample].[StudentFavoriteBookArtMedium] --
COMMENT ON TABLE sample.StudentFavoriteBookArtMedium IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBookArtMedium.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentFavoriteBookArtMedium.FavoriteBookCategoryDescriptorId IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBookArtMedium.ArtMediumDescriptorId IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBookArtMedium.ArtPieces IS 'This is documentation.';

-- Extended Properties [sample].[StudentGraduationPlanAssociation] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociation IS 'This is an example of a new Association.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.CommencementTime IS 'The time of day for the commencement ceremony.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.EffectiveDate IS 'The date the plan went into effect.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.GraduationFee IS 'Any fees the student must resolve prior to graduation, such as library fines and overdue lunch accounts.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.HighSchoolDuration IS 'The number of years remaining prior to graduation as of when the plan became effective.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.HoursPerWeek IS 'The number of hours per week the student will attend to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.IsActivePlan IS 'An indication as to whether the plan is active.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.RequiredAttendance IS 'The percentage of time the student must attend to graduate, relative to a full-time student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.TargetGPA IS 'The GPA the student is working toward.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationAcademicSubject] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationAcademicSubject IS 'The student''s favorite academic subjects.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.AcademicSubjectDescriptorId IS 'The student''s favorite academic subjects.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationCareerPathwayCode] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationCareerPathwayCode IS 'The code representing the student''s intended career pathway after graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.CareerPathwayCode IS 'The code representing the student''s intended career pathway after graduation.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationCTEProgramService] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationCTEProgramService IS 'The career and technical program in which the student participates.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.CIPCode IS 'Number and description of the CIP code associated with the student''s CTE program.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.CTEProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the CTE program.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.ServiceBeginDate IS 'First date the student was in this option for the current school year.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgramService.ServiceEndDate IS 'Last date the student was in this option for the current school year.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationDescription] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationDescription IS 'A description of the graduation plan.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.Description IS 'A description of the graduation plan.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationDesignatedBy] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationDesignatedBy IS 'The entity governing this graduation plan.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.DesignatedBy IS 'The entity governing this graduation plan.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationIndustryCredential] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationIndustryCredential IS 'Industry-recognized credentials the student will have earned at graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.IndustryCredential IS 'Industry-recognized credentials the student will have earned at graduation.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationStudentContactAssociation] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationStudentContactAssociation IS 'Contact responsible for graduation plan.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentContactAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentContactAssociation.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentContactAssociation.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentContactAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentContactAssociation.ContactUSI IS 'A unique alphanumeric code assigned to a contact.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationYearsAttended] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationYearsAttended IS 'The number of years the student will have attended high school by the time of graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.YearsAttended IS 'The number of years the student will have attended high school by the time of graduation.';

-- Extended Properties [sample].[StudentPet] --
COMMENT ON TABLE sample.StudentPet IS 'Details about pets in the student''s household.';
COMMENT ON COLUMN sample.StudentPet.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentPet.PetName IS 'The pet''s name.';
COMMENT ON COLUMN sample.StudentPet.IsFixed IS 'An indication as to whether the pet has been spayed/neutered.';

-- Extended Properties [sample].[StudentPetPreference] --
COMMENT ON TABLE sample.StudentPetPreference IS 'Details about the student''s pet preferences.';
COMMENT ON COLUMN sample.StudentPetPreference.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentPetPreference.MaximumWeight IS 'The preferred maximum weight of a household pet.';
COMMENT ON COLUMN sample.StudentPetPreference.MinimumWeight IS 'The preferred minimum weight of a household pet.';

-- Extended Properties [sample].[StudentSchoolAssociationExtension] --
COMMENT ON TABLE sample.StudentSchoolAssociationExtension IS '';
COMMENT ON COLUMN sample.StudentSchoolAssociationExtension.EntryDate IS 'The month, day, and year on which an individual enters and begins to receive instructional services in a school for each school year. The EntryDate value should be the date the student enrolled, or when the student''s enrollment materially changed, such as with a grade promotion.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentSchoolAssociationExtension.SchoolId IS 'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';
COMMENT ON COLUMN sample.StudentSchoolAssociationExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentSchoolAssociationExtension.MembershipTypeDescriptorId IS 'Membership Type identifies whether a school has primary responsibility for managing a specific student''s curriculum or not.';

-- Extended Properties [sample].[StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02] --
COMMENT ON TABLE sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 IS 'Programs which this student is participating in that is supported by this coursework.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.BeginDate IS 'Month, day, and year of the student''s entry or assignment to the section.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.SchoolId IS 'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedBeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedProgramTypeDescriptorId IS 'The type of program.';

