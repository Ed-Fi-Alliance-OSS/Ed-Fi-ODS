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
COMMENT ON COLUMN sample.BusRoute.BusRouteDirection IS 'The direction of the bus route.';
COMMENT ON COLUMN sample.BusRoute.Daily IS 'An indication as to whether the bus route operates every weekday.';
COMMENT ON COLUMN sample.BusRoute.OperatingCost IS 'The approximate annual cost for the bus route.';
COMMENT ON COLUMN sample.BusRoute.StartDate IS 'The date the bus route became operational.';
COMMENT ON COLUMN sample.BusRoute.WeeklyMileage IS 'The approximate weekly mileage for the bus route.';
COMMENT ON COLUMN sample.BusRoute.ExpectedTransitTime IS 'The approximate amount of time, in minutes, for the bus route operation each day.';
COMMENT ON COLUMN sample.BusRoute.OptimalCapacity IS 'The percentage of seats filled under optimal conditions.';
COMMENT ON COLUMN sample.BusRoute.HoursPerWeek IS 'The number of hours per week in which the bus route is operational.';
COMMENT ON COLUMN sample.BusRoute.BusRouteDuration IS 'The number of minutes per week in which the bus route is operational.';
COMMENT ON COLUMN sample.BusRoute.DisabilityDescriptorId IS 'The disability served by the bus route, if applicable.';
COMMENT ON COLUMN sample.BusRoute.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.BusRoute.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.BusRoute.StaffClassificationDescriptorId IS 'The titles of employment, official status, or rank of education staff.';
COMMENT ON COLUMN sample.BusRoute.BeginDate IS 'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the education organization.';

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
COMMENT ON COLUMN sample.BusRouteProgram.ProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
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
COMMENT ON COLUMN sample.BusRouteTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN sample.BusRouteTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN sample.BusRouteTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [sample].[FavoriteBookCategoryDescriptor] --
COMMENT ON TABLE sample.FavoriteBookCategoryDescriptor IS 'The category of an individual''s favorite book.';
COMMENT ON COLUMN sample.FavoriteBookCategoryDescriptor.FavoriteBookCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [sample].[MembershipTypeDescriptor] --
COMMENT ON TABLE sample.MembershipTypeDescriptor IS 'Membership Type identifies whether a school has primary responsibility for managing a specific student''s curriculum or not.';
COMMENT ON COLUMN sample.MembershipTypeDescriptor.MembershipTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [sample].[ParentAddressExtension] --
COMMENT ON TABLE sample.ParentAddressExtension IS 'Additional details on the parent''s address.';
COMMENT ON COLUMN sample.ParentAddressExtension.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.ParentAddressExtension.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.ParentAddressExtension.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.ParentAddressExtension.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.ParentAddressExtension.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.ParentAddressExtension.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.ParentAddressExtension.Complex IS 'The apartment or housing complex name.';
COMMENT ON COLUMN sample.ParentAddressExtension.OnBusRoute IS 'An indicator if the address is on a bus route.';

-- Extended Properties [sample].[ParentAddressSchoolDistrict] --
COMMENT ON TABLE sample.ParentAddressSchoolDistrict IS 'The school district in which the address is located.';
COMMENT ON COLUMN sample.ParentAddressSchoolDistrict.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.ParentAddressSchoolDistrict.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.ParentAddressSchoolDistrict.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.ParentAddressSchoolDistrict.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.ParentAddressSchoolDistrict.SchoolDistrict IS 'The school district in which the address is located.';
COMMENT ON COLUMN sample.ParentAddressSchoolDistrict.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.ParentAddressSchoolDistrict.StreetNumberName IS 'The street number and street name or post office box number of an address.';

-- Extended Properties [sample].[ParentAddressTerm] --
COMMENT ON TABLE sample.ParentAddressTerm IS 'Terms applicable to this address.';
COMMENT ON COLUMN sample.ParentAddressTerm.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.ParentAddressTerm.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.ParentAddressTerm.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.ParentAddressTerm.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.ParentAddressTerm.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.ParentAddressTerm.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.ParentAddressTerm.TermDescriptorId IS 'Terms applicable to this address.';

-- Extended Properties [sample].[ParentAuthor] --
COMMENT ON TABLE sample.ParentAuthor IS 'The parent''s favorite authors.';
COMMENT ON COLUMN sample.ParentAuthor.Author IS 'The parent''s favorite authors.';
COMMENT ON COLUMN sample.ParentAuthor.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';

-- Extended Properties [sample].[ParentCeilingHeight] --
COMMENT ON TABLE sample.ParentCeilingHeight IS 'The height of the ceiling in the rooms of the parent''s home.';
COMMENT ON COLUMN sample.ParentCeilingHeight.CeilingHeight IS 'The height of the ceiling in the rooms of the parent''s home.';
COMMENT ON COLUMN sample.ParentCeilingHeight.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';

-- Extended Properties [sample].[ParentCTEProgram] --
COMMENT ON TABLE sample.ParentCTEProgram IS 'A CTE program the parent has completed.';
COMMENT ON COLUMN sample.ParentCTEProgram.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.ParentCTEProgram.CareerPathwayDescriptorId IS 'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.';
COMMENT ON COLUMN sample.ParentCTEProgram.CIPCode IS 'Number and description of the CIP Code associated with the student''s CTEProgram.';
COMMENT ON COLUMN sample.ParentCTEProgram.PrimaryCTEProgramIndicator IS 'A boolean indicator of whether this CTEProgram, is the student''s primary CTEProgram.';
COMMENT ON COLUMN sample.ParentCTEProgram.CTEProgramCompletionIndicator IS 'A boolean indicator of whether the Student has completed the CTEProgram.';

-- Extended Properties [sample].[ParentEducationContent] --
COMMENT ON TABLE sample.ParentEducationContent IS 'Education content to which the parent has been referred.';
COMMENT ON COLUMN sample.ParentEducationContent.ContentIdentifier IS 'A unique identifier for the EducationContent.';
COMMENT ON COLUMN sample.ParentEducationContent.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';

-- Extended Properties [sample].[ParentExtension] --
COMMENT ON TABLE sample.ParentExtension IS '';
COMMENT ON COLUMN sample.ParentExtension.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.ParentExtension.IsSportsFan IS 'An indication as to whether the parent is a sports fan.';
COMMENT ON COLUMN sample.ParentExtension.CoffeeSpend IS 'How much the parent spends on coffee in a week.';
COMMENT ON COLUMN sample.ParentExtension.GraduationDate IS 'The date the parent graduated high school.';
COMMENT ON COLUMN sample.ParentExtension.AverageCarLineWait IS 'The time spent per day waiting in the car line.';
COMMENT ON COLUMN sample.ParentExtension.LuckyNumber IS 'The parent''s lucky number.';
COMMENT ON COLUMN sample.ParentExtension.RainCertainty IS 'The percent likelihood that it will rain when the parent volunteers to chaperone a field trip.';
COMMENT ON COLUMN sample.ParentExtension.PreferredWakeUpTime IS 'The time the parent would prefer to wake up in the morning.';
COMMENT ON COLUMN sample.ParentExtension.BecameParent IS 'The year in which the parent first became a parent.';
COMMENT ON COLUMN sample.ParentExtension.GPA IS 'The parent''s high school GPA.';
COMMENT ON COLUMN sample.ParentExtension.Duration IS 'The amount of time the parent spends reading to his/her children at bedtime.';
COMMENT ON COLUMN sample.ParentExtension.CredentialFieldDescriptorId IS 'The field in which the parent holds a credential.';

-- Extended Properties [sample].[ParentFavoriteBookTitle] --
COMMENT ON TABLE sample.ParentFavoriteBookTitle IS 'The title of the parent''s favorite book.';
COMMENT ON COLUMN sample.ParentFavoriteBookTitle.FavoriteBookTitle IS 'The title of the parent''s favorite book.';
COMMENT ON COLUMN sample.ParentFavoriteBookTitle.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';

-- Extended Properties [sample].[ParentStudentProgramAssociation] --
COMMENT ON TABLE sample.ParentStudentProgramAssociation IS 'Programs the parent''s child or children are enrolled in for which the parent provides volunteer services.';
COMMENT ON COLUMN sample.ParentStudentProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN sample.ParentStudentProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.ParentStudentProgramAssociation.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.ParentStudentProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.ParentStudentProgramAssociation.ProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.ParentStudentProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.ParentStudentProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[ParentTeacherConference] --
COMMENT ON TABLE sample.ParentTeacherConference IS 'The parent''s preferred day of the week and time for parent-teacher conferences.';
COMMENT ON COLUMN sample.ParentTeacherConference.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.ParentTeacherConference.DayOfWeek IS 'The day of the week the parent prefers to meet for parent-teacher conferences.';
COMMENT ON COLUMN sample.ParentTeacherConference.StartTime IS 'The start time the parent prefers to meet for parent-teacher conferences.';
COMMENT ON COLUMN sample.ParentTeacherConference.EndTime IS 'The end time the parent prefers to meet for parent-teacher conferences.';

-- Extended Properties [sample].[SchoolCTEProgram] --
COMMENT ON TABLE sample.SchoolCTEProgram IS 'A CTE program the school is known for.';
COMMENT ON COLUMN sample.SchoolCTEProgram.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN sample.SchoolCTEProgram.CareerPathwayDescriptorId IS 'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.';
COMMENT ON COLUMN sample.SchoolCTEProgram.CIPCode IS 'Number and description of the CIP Code associated with the student''s CTEProgram.';
COMMENT ON COLUMN sample.SchoolCTEProgram.PrimaryCTEProgramIndicator IS 'A boolean indicator of whether this CTEProgram, is the student''s primary CTEProgram.';
COMMENT ON COLUMN sample.SchoolCTEProgram.CTEProgramCompletionIndicator IS 'A boolean indicator of whether the Student has completed the CTEProgram.';

-- Extended Properties [sample].[SchoolDirectlyOwnedBus] --
COMMENT ON TABLE sample.SchoolDirectlyOwnedBus IS 'Buses owned by the School directly.';
COMMENT ON COLUMN sample.SchoolDirectlyOwnedBus.DirectlyOwnedBusId IS 'The unique identifier for the bus.';
COMMENT ON COLUMN sample.SchoolDirectlyOwnedBus.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [sample].[SchoolExtension] --
COMMENT ON TABLE sample.SchoolExtension IS '';
COMMENT ON COLUMN sample.SchoolExtension.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN sample.SchoolExtension.IsExemplary IS 'An indication as to whether the school is exemplary.';

-- Extended Properties [sample].[StaffExtension] --
COMMENT ON TABLE sample.StaffExtension IS '';
COMMENT ON COLUMN sample.StaffExtension.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.StaffExtension.FirstPetOwnedDate IS 'The date the staff member adopted the first household pet.';

-- Extended Properties [sample].[StaffPet] --
COMMENT ON TABLE sample.StaffPet IS 'Details about pets in the staff member''s household.';
COMMENT ON COLUMN sample.StaffPet.PetName IS 'The pet''s name.';
COMMENT ON COLUMN sample.StaffPet.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.StaffPet.IsFixed IS 'An indication as to whether the pet has been spayed/neutered.';

-- Extended Properties [sample].[StaffPetPreference] --
COMMENT ON TABLE sample.StaffPetPreference IS 'Details about the staff member''s pet preferences.';
COMMENT ON COLUMN sample.StaffPetPreference.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.StaffPetPreference.MinimumWeight IS 'The preferred minimum weight of a household pet.';
COMMENT ON COLUMN sample.StaffPetPreference.MaximumWeight IS 'The preferred maximum weight of a household pet.';

-- Extended Properties [sample].[StudentAquaticPet] --
COMMENT ON TABLE sample.StudentAquaticPet IS 'Details about aquatic pets in the student''s household';
COMMENT ON COLUMN sample.StudentAquaticPet.MimimumTankVolume IS 'The minimum tank volume this aquatic pet requires.';
COMMENT ON COLUMN sample.StudentAquaticPet.PetName IS 'The pet''s name.';
COMMENT ON COLUMN sample.StudentAquaticPet.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentAquaticPet.IsFixed IS 'An indication as to whether the pet has been spayed/neutered.';

-- Extended Properties [sample].[StudentArtProgramAssociation] --
COMMENT ON TABLE sample.StudentArtProgramAssociation IS 'This is an example of a subclass of an association.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.IdentificationCode IS 'A unique identification code used to identify the student''s artwork produced in the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ExhibitDate IS 'Start date for the program''s art exhibit to display the student''s work.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ProgramFees IS 'Required program fees to purchase materials for the student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.NumberOfDaysInAttendance IS 'Number of days the student is in attendance at the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.HoursPerDay IS 'The number of hours a student spends in the program each school day.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.PrivateArtProgram IS 'Indicator that the student participated in art education at a private agency or institution.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.KilnReservation IS 'The student''s reserved time for use of the kiln.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.KilnReservationLength IS 'The number of clock minutes dedicated to the student''s kiln reservation.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.ArtPieces IS 'The total number of art pieces completed by the student during the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.PortfolioPieces IS 'The total number of pieces in the student''s portfolio.';
COMMENT ON COLUMN sample.StudentArtProgramAssociation.MasteredMediums IS 'Percentage of the mediums taught in the program which the student mastered.';

-- Extended Properties [sample].[StudentArtProgramAssociationArtMedium] --
COMMENT ON TABLE sample.StudentArtProgramAssociationArtMedium IS 'The art mediums used in the program (i.e., paint, pencils, clay, etc.).';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.ArtMediumDescriptorId IS 'The art mediums used in the program (i.e., paint, pencils, clay, etc.).';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.ProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationArtMedium.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentArtProgramAssociationPortfolioYears] --
COMMENT ON TABLE sample.StudentArtProgramAssociationPortfolioYears IS 'The of year(s) of work included in the student''s portfolio.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.PortfolioYears IS 'The of year(s) of work included in the student''s portfolio.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.ProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationPortfolioYears.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentArtProgramAssociationService] --
COMMENT ON TABLE sample.StudentArtProgramAssociationService IS 'Indicates the Service(s) being provided to the Student by the Program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ServiceDescriptorId IS 'Indicates the Service being provided to the student by the Program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ServiceBeginDate IS 'First date the Student was in this option for the current school year.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationService.ServiceEndDate IS 'Last date the Student was in this option for the current school year.';

-- Extended Properties [sample].[StudentArtProgramAssociationStyle] --
COMMENT ON TABLE sample.StudentArtProgramAssociationStyle IS 'The art style(s) exhibited by the student in the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.ProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentArtProgramAssociationStyle.Style IS 'The art style(s) exhibited by the student in the program.';

-- Extended Properties [sample].[StudentCTEProgramAssociationExtension] --
COMMENT ON TABLE sample.StudentCTEProgramAssociationExtension IS '';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.ProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.AnalysisCompleted IS 'A unique identification code used to identify the student''s artwork produced in the program.';
COMMENT ON COLUMN sample.StudentCTEProgramAssociationExtension.AnalysisDate IS 'The date and time the CTEProgram analysis was completed.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressExtension] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationAddressExtension IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.Complex IS 'The apartment or housing complex name.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressExtension.OnBusRoute IS 'An indicator if the address is on a bus route.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressSchoolDistrict] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationAddressSchoolDistrict IS 'The school district in which the address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.SchoolDistrict IS 'The school district in which the address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressSchoolDistrict.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationAddressTerm] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationAddressTerm IS 'Terms applicable to this address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationAddressTerm.TermDescriptorId IS 'Terms applicable to this address.';

-- Extended Properties [sample].[StudentEducationOrganizationAssociationStudentCharacteri_17d152] --
COMMENT ON TABLE sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152 IS 'The time period of student need.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.StudentCharacteristicDescriptorId IS 'The characteristic designated for the Student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.PrimaryStudentNeedIndicator IS 'Indicates the parent characteristic is a primary student need.';
COMMENT ON COLUMN sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [sample].[StudentFavoriteBook] --
COMMENT ON TABLE sample.StudentFavoriteBook IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBook.FavoriteBookCategoryDescriptorId IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBook.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentFavoriteBook.BookTitle IS 'This is documentation.';

-- Extended Properties [sample].[StudentFavoriteBookArtMedium] --
COMMENT ON TABLE sample.StudentFavoriteBookArtMedium IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBookArtMedium.ArtMediumDescriptorId IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBookArtMedium.FavoriteBookCategoryDescriptorId IS 'This is documentation.';
COMMENT ON COLUMN sample.StudentFavoriteBookArtMedium.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentFavoriteBookArtMedium.ArtPieces IS 'This is documentation.';

-- Extended Properties [sample].[StudentGraduationPlanAssociation] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociation IS 'This is an example of a new Association.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.EffectiveDate IS 'The date the plan went into effect.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.IsActivePlan IS 'An indication as to whether the plan is active.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.GraduationFee IS 'Any fees the student must resolve prior to graduation, such as library fines and overdue lunch accounts.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.TargetGPA IS 'The GPA the student is working toward.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.HighSchoolDuration IS 'The number of years remaining prior to graduation as of when the plan became effective.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.RequiredAttendance IS 'The percentage of time the student must attend to graduate, relative to a full-time student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.CommencementTime IS 'The time of day for the commencement ceremony.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.HoursPerWeek IS 'The number of hours per week the student will attend to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationAcademicSubject] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationAcademicSubject IS 'The student''s favorite academic subjects.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.AcademicSubjectDescriptorId IS 'The student''s favorite academic subjects.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationAcademicSubject.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationCareerPathwayCode] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationCareerPathwayCode IS 'The code representing the student''s intended career pathway after graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.CareerPathwayCode IS 'The code representing the student''s intended career pathway after graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCareerPathwayCode.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationCTEProgram] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationCTEProgram IS 'The career and technical program in which the student participates.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgram.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgram.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgram.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgram.CareerPathwayDescriptorId IS 'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgram.CIPCode IS 'Number and description of the CIP Code associated with the student''s CTEProgram.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgram.PrimaryCTEProgramIndicator IS 'A boolean indicator of whether this CTEProgram, is the student''s primary CTEProgram.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationCTEProgram.CTEProgramCompletionIndicator IS 'A boolean indicator of whether the Student has completed the CTEProgram.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationDescription] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationDescription IS 'A description of the graduation plan.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.Description IS 'A description of the graduation plan.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDescription.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationDesignatedBy] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationDesignatedBy IS 'The entity governing this graduation plan.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.DesignatedBy IS 'The entity governing this graduation plan.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationDesignatedBy.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationIndustryCredential] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationIndustryCredential IS 'Industry-recognized credentials the student will have earned at graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.IndustryCredential IS 'Industry-recognized credentials the student will have earned at graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationIndustryCredential.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationStudentParentAssociation] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationStudentParentAssociation IS 'Parent responsible for graduation plan.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentParentAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentParentAssociation.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentParentAssociation.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentParentAssociation.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationStudentParentAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentGraduationPlanAssociationYearsAttended] --
COMMENT ON TABLE sample.StudentGraduationPlanAssociationYearsAttended IS 'The number of years the student will have attended high school by the time of graduation.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentGraduationPlanAssociationYearsAttended.YearsAttended IS 'The number of years the student will have attended high school by the time of graduation.';

-- Extended Properties [sample].[StudentParentAssociationDiscipline] --
COMMENT ON TABLE sample.StudentParentAssociationDiscipline IS 'The type of action used to discipline the student preferred by the parent.';
COMMENT ON COLUMN sample.StudentParentAssociationDiscipline.DisciplineDescriptorId IS 'The type of action used to discipline the student preferred by the parent.';
COMMENT ON COLUMN sample.StudentParentAssociationDiscipline.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.StudentParentAssociationDiscipline.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentParentAssociationExtension] --
COMMENT ON TABLE sample.StudentParentAssociationExtension IS '';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.PriorContactRestrictions IS 'Previous restrictions for student and/or teacher contact with the individual (e.g., the student may not be picked up by the individual).';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.BedtimeReader IS 'An indication as to whether the parent regularly reads to the student before bed.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.BookBudget IS 'The parent''s estimated monthly budget dedicated to books for the student.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.ReadGreenEggsAndHamDate IS 'Date on which the parent first read the student Green Eggs and Ham by Dr. Seuss.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.ReadingTimeSpent IS 'The amount of time the parent spends reading to the student each day.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.BooksBorrowed IS 'The total number of books the parent has borrowed on behalf of the student to date.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.BedtimeReadingRate IS 'The average number of pages the parent reads with the student each day.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.LibraryTime IS 'The student''s regularly scheduled library time during the school day.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.LibraryVisits IS 'Total number of visits a student is allowed to the library in a single school day.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.StudentRead IS 'The year in which the student''s reading habits are being recorded.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.LibraryDuration IS 'The actual or estimated number of clock minutes for a given library visit.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentParentAssociationExtension.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';

-- Extended Properties [sample].[StudentParentAssociationFavoriteBookTitle] --
COMMENT ON TABLE sample.StudentParentAssociationFavoriteBookTitle IS 'The title of the student''s favorite book.';
COMMENT ON COLUMN sample.StudentParentAssociationFavoriteBookTitle.FavoriteBookTitle IS 'The title of the student''s favorite book.';
COMMENT ON COLUMN sample.StudentParentAssociationFavoriteBookTitle.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.StudentParentAssociationFavoriteBookTitle.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentParentAssociationHoursPerWeek] --
COMMENT ON TABLE sample.StudentParentAssociationHoursPerWeek IS 'Total number of hours per week a student and parent dedicates to reading.';
COMMENT ON COLUMN sample.StudentParentAssociationHoursPerWeek.HoursPerWeek IS 'Total number of hours per week a student and parent dedicates to reading.';
COMMENT ON COLUMN sample.StudentParentAssociationHoursPerWeek.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.StudentParentAssociationHoursPerWeek.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentParentAssociationPagesRead] --
COMMENT ON TABLE sample.StudentParentAssociationPagesRead IS 'Total number of pages the parent has read the student.';
COMMENT ON COLUMN sample.StudentParentAssociationPagesRead.PagesRead IS 'Total number of pages the parent has read the student.';
COMMENT ON COLUMN sample.StudentParentAssociationPagesRead.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.StudentParentAssociationPagesRead.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c] --
COMMENT ON TABLE sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c IS 'A reference to the staff member and education organization assigned to help track the student''s reading abilities with the parent''s involvement.';
COMMENT ON COLUMN sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...';
COMMENT ON COLUMN sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c.HireDate IS 'The month, day, and year on which an individual was hired for a position.';
COMMENT ON COLUMN sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [sample].[StudentParentAssociationTelephone] --
COMMENT ON TABLE sample.StudentParentAssociationTelephone IS 'The preferred telephone number for contact if the person is listed as an emergency contact for the student.';
COMMENT ON COLUMN sample.StudentParentAssociationTelephone.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN sample.StudentParentAssociationTelephone.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentParentAssociationTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN sample.StudentParentAssociationTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN sample.StudentParentAssociationTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN sample.StudentParentAssociationTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN sample.StudentParentAssociationTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [sample].[StudentPet] --
COMMENT ON TABLE sample.StudentPet IS 'Details about pets in the student''s household.';
COMMENT ON COLUMN sample.StudentPet.PetName IS 'The pet''s name.';
COMMENT ON COLUMN sample.StudentPet.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentPet.IsFixed IS 'An indication as to whether the pet has been spayed/neutered.';

-- Extended Properties [sample].[StudentPetPreference] --
COMMENT ON TABLE sample.StudentPetPreference IS 'Details about the student''s pet preferences.';
COMMENT ON COLUMN sample.StudentPetPreference.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentPetPreference.MinimumWeight IS 'The preferred minimum weight of a household pet.';
COMMENT ON COLUMN sample.StudentPetPreference.MaximumWeight IS 'The preferred maximum weight of a household pet.';

-- Extended Properties [sample].[StudentSchoolAssociationExtension] --
COMMENT ON TABLE sample.StudentSchoolAssociationExtension IS '';
COMMENT ON COLUMN sample.StudentSchoolAssociationExtension.EntryDate IS 'The month, day, and year on which an individual enters and begins to receive instructional services in a school.';
COMMENT ON COLUMN sample.StudentSchoolAssociationExtension.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN sample.StudentSchoolAssociationExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN sample.StudentSchoolAssociationExtension.MembershipTypeDescriptorId IS 'Membership Type identifies whether a school has primary responsibility for managing a specific student''s curriculum or not.';

-- Extended Properties [sample].[StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02] --
COMMENT ON TABLE sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 IS 'Programs which this student is participating in that is supported by this coursework.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.BeginDate IS 'Month, day, and year of the Student''s entry or assignment to the Section.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedBeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedProgramName IS 'The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.RelatedProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

