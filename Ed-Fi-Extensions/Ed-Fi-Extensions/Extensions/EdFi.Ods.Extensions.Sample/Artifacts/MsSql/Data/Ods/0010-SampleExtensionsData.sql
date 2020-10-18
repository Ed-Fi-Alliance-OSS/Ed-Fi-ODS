-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @grandBendElementarySchoolId INT;
SELECT @grandBendElementarySchoolId = SchoolId
    FROM edfi.School
    WHERE SchoolId = 255901107

DECLARE @staff207230Usi INT;
SELECT @staff207230Usi = StaffUSI
    FROM edfi.Staff
    WHERE StaffUniqueId = '207230'

DECLARE @staff207219Usi INT;
SELECT @staff207219Usi = StaffUSI
    FROM edfi.Staff
    WHERE StaffUniqueId = '207219'

DECLARE @parent777777Usi INT;
SELECT @parent777777Usi = ParentUSI
    FROM edfi.Parent
    WHERE ParentUniqueId = '777777'

DECLARE @parent778025Usi INT;
SELECT @parent778025Usi = ParentUSI
    FROM edfi.Parent
    WHERE ParentUniqueId = '778025'

DECLARE @student604854Usi INT;
SELECT @student604854Usi = StudentUSI
    FROM edfi.Student
    WHERE StudentUniqueId = '604854'

DECLARE @student605614Usi INT;
SELECT @student605614Usi = StudentUSI
    FROM edfi.Student
    WHERE StudentUniqueId = '605614'

-- Sanity check to make sure some data exists, otherwise skip the script
IF (@grandBendElementarySchoolId IS NULL OR @student604854Usi IS NULL OR @student605614Usi IS NULL) RETURN

-- Verify all required source data is available in the core namespace
DECLARE @educationContentIdentifier NVARCHAR(225);
SELECT @educationContentIdentifier = ContentIdentifier
    FROM edfi.EducationContent

DECLARE @bilingualProgramEducationOrganizationId INT;
DECLARE @bilingualProgramProgramName NVARCHAR(60);
DECLARE @bilingualProgramProgramTypeDescriptorId INT;
SELECT @bilingualProgramEducationOrganizationId = EducationOrganizationId,
    @bilingualProgramProgramName = ProgramName,
    @bilingualProgramProgramTypeDescriptorId = ProgramTypeDescriptorId
    FROM edfi.Program
    WHERE ProgramName = 'Bilingual'

DECLARE @graduationPlanEducationOrganizationId INT;
DECLARE @graduationPlanTypeDescriptorId INT;
DECLARE @graduationPlanGraduationSchoolYear SMALLINT;
SELECT @graduationPlanEducationOrganizationId = EducationOrganizationId,
    @graduationPlanTypeDescriptorId = GraduationPlanTypeDescriptorId,
    @graduationPlanGraduationSchoolYear = GraduationSchoolYear
    FROM edfi.GraduationPlan
    WHERE EducationOrganizationId = @grandBendElementarySchoolId

DECLARE @student604854SPABeginDate DATETIME2;
DECLARE @student604854SPAEducationOrganizationId INT;
DECLARE @student604854SPAProgramEducationOrganizationId INT;
DECLARE @student604854SPAProgramName NVARCHAR(60);
DECLARE @student604854SPAProgramTypeDescriptorId INT;
SELECT @student604854SPABeginDate = BeginDate,
    @student604854SPAEducationOrganizationId = EducationOrganizationId,
    @student604854SPAProgramEducationOrganizationId = ProgramEducationOrganizationId,
    @student604854SPAProgramName = ProgramName,
    @student604854SPAProgramTypeDescriptorId = ProgramTypeDescriptorId
    FROM edfi.StudentProgramAssociation
    WHERE StudentUSI = @student604854Usi

DECLARE @staff207219EmploymentEducationOrganizationId INT;
DECLARE @staff207219EmploymentStatusDescriptorId INT;
DECLARE @staff207219EmploymentHireDate DATE;
DECLARE @staff207219EmploymentStaffUSI INT;
SELECT @staff207219EmploymentEducationOrganizationId = EducationOrganizationId,
    @staff207219EmploymentStatusDescriptorId = EmploymentStatusDescriptorId,
    @staff207219EmploymentHireDate = HireDate,
    @staff207219EmploymentStaffUSI = StaffUSI
    FROM edfi.StaffEducationOrganizationEmploymentAssociation
    WHERE StaffUSI = @staff207219Usi

DECLARE @staff207230AssignmentBeginDate DATE;
DECLARE @staff207230AssignmentEducationOrganizationId INT;
DECLARE @staff207230AssignmentStaffClassificationDescriptorId INT;
DECLARE @staff207230AssignmentStaffUsi INT;
SELECT @staff207230AssignmentBeginDate = BeginDate,
    @staff207230AssignmentEducationOrganizationId = EducationOrganizationId,
    @staff207230AssignmentStaffClassificationDescriptorId = StaffClassificationDescriptorId,
    @staff207230AssignmentStaffUsi = StaffUSI
    FROM edfi.StaffEducationOrganizationAssignmentAssociation
    WHERE StaffUSI = @staff207230Usi

DECLARE @academicSubjectDescriptorId INT;
SELECT @academicSubjectDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.AcademicSubjectDescriptor asd
    ON d.DescriptorId = asd.AcademicSubjectDescriptorId

DECLARE @achievementCategoryDescriptorId INT;
SELECT @achievementCategoryDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.AchievementCategoryDescriptor acd
    ON d.DescriptorId = acd.AchievementCategoryDescriptorId

DECLARE @addressTypeDescriptorId INT;
SELECT @addressTypeDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.AddressTypeDescriptor atd
    ON d.DescriptorId = atd.AddressTypeDescriptorId

DECLARE @careerPathwayDescriptorId INT;
SELECT @careerPathwayDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.CareerPathwayDescriptor cpd
    ON d.DescriptorId = cpd.CareerPathwayDescriptorId

DECLARE @credentialFieldDescriptorId INT;
SELECT @credentialFieldDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.CredentialFieldDescriptor cfd
    ON d.DescriptorId = cfd.CredentialFieldDescriptorId

DECLARE @disciplineDescriptorId INT;
SELECT @disciplineDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.DisciplineDescriptor dd
    ON d.DescriptorId = dd.DisciplineDescriptorId

DECLARE @disabilityDescriptorId INT;
SELECT @disabilityDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.DisabilityDescriptor dd
    ON d.DescriptorId = dd.DisabilityDescriptorId

DECLARE @telephoneNumberTypeDescriptor INT;
SELECT @telephoneNumberTypeDescriptor = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.TelephoneNumberTypeDescriptor tntd
    ON d.DescriptorId = tntd.TelephoneNumberTypeDescriptorId

DECLARE @serviceDescriptorId INT;
SELECT @serviceDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.ServiceDescriptor sd
    ON d.DescriptorId = sd.ServiceDescriptorId

DECLARE @stateAbbreviationDescriptorId INT;
SELECT @stateAbbreviationDescriptorId = DescriptorId
    FROM edfi.Descriptor d
    INNER JOIN edfi.StateAbbreviationDescriptor sad
    ON d.DescriptorId = sad.StateAbbreviationDescriptorId

-- Create new descriptor values
DECLARE @artMediumDescriptorId INT;
INSERT INTO edfi.Descriptor (Namespace, CodeValue, ShortDescription, Description)
    VALUES ('uri://ed-fi.org/ArtMediumDescriptor', 'Art Medium', 'Art Medium', 'Art Medium')
SELECT @artMediumDescriptorId = DescriptorId
    FROM edfi.Descriptor WHERE Namespace = 'uri://ed-fi.org/ArtMediumDescriptor' AND CodeValue = 'Art Medium'
INSERT INTO sample.ArtMediumDescriptor VALUES (@artMediumDescriptorId)

DECLARE @membershipTypeDescriptorId INT;
INSERT INTO edfi.Descriptor (Namespace, CodeValue, ShortDescription, Description)
    VALUES ('uri://ed-fi.org/MembershipTypeDescriptor', 'Membership Type', 'Membership Type', 'Membership Type')
SELECT @membershipTypeDescriptorId = DescriptorId
    FROM edfi.Descriptor WHERE Namespace = 'uri://ed-fi.org/MembershipTypeDescriptor' AND CodeValue = 'Membership Type'
INSERT INTO sample.MembershipTypeDescriptor VALUES (@membershipTypeDescriptorId)

DECLARE @favoriteBookCategoryDescriptorId INT;
INSERT INTO edfi.Descriptor (Namespace, CodeValue, ShortDescription, Description)
    VALUES ('uri://ed-fi.org/FavoriteBookCategoryDescriptor', 'Non-Fiction', 'Non-Fiction', 'Non-Fiction')
SELECT @favoriteBookCategoryDescriptorId = DescriptorId
    FROM edfi.Descriptor WHERE Namespace = 'uri://ed-fi.org/FavoriteBookCategoryDescriptor' AND CodeValue = 'Non-Fiction'
INSERT INTO sample.FavoriteBookCategoryDescriptor VALUES (@favoriteBookCategoryDescriptorId)

-- Create extension records to prevent dropped records due to extension requirements



INSERT INTO sample.StaffExtension
    (StaffUSI
    , FirstPetOwnedDate)
SELECT
    StaffUSI
    , NULL
FROM edfi.Staff
WHERE NOT EXISTS
    (SELECT StaffUSI
    FROM sample.StaffExtension se
    WHERE StaffUSI = se.StaffUsi)

INSERT INTO sample.ParentExtension
    (ParentUSI
    , IsSportsFan
    , CoffeeSpend
    , GraduationDate
    , AverageCarLineWait
    , LuckyNumber
    , RainCertainty
    , PreferredWakeUpTime
    , BecameParent
    , GPA
    , Duration)
SELECT
    ParentUSI
    , 0
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
FROM edfi.Parent
WHERE NOT EXISTS
    (SELECT ParentUSI
    FROM sample.ParentExtension pe
    WHERE ParentUSI = pe.ParentUSI)

INSERT INTO sample.ParentFavoriteBookTitle
    (ParentUSI
    , FavoriteBookTitle)
SELECT
    ParentUSI
    , 'Green Eggs and Ham'
FROM edfi.Parent

INSERT INTO sample.ParentAddressExtension
    (AddressTypeDescriptorId
    , City
    , ParentUSI
    , PostalCode
    , StateAbbreviationDescriptorId
    , StreetNumberName
    , OnBusRoute)
SELECT
    AddressTypeDescriptorId
    , City
    , ParentUSI
    , PostalCode
    , StateAbbreviationDescriptorId
    , StreetNumberName
    , 0
FROM edfi.ParentAddress
WHERE NOT EXISTS
    (SELECT ParentUSI
    FROM sample.ParentAddressExtension pae
    WHERE AddressTypeDescriptorId = pae.AddressTypeDescriptorId
    AND City = pae.City
    AND ParentUSI = pae.ParentUSI
    AND PostalCode = pae.PostalCode
    AND StateAbbreviationDescriptorId = pae.StateAbbreviationDescriptorId)


INSERT INTO sample.ParentAddressSchoolDistrict
    (AddressTypeDescriptorId
    , City
    , ParentUSI
    , PostalCode
    , SchoolDistrict
    , StateAbbreviationDescriptorId
    , StreetNumberName)
SELECT
    AddressTypeDescriptorId
    , City
    , ParentUSI
    , PostalCode
    , 'Original School District'
    , StateAbbreviationDescriptorId
    , StreetNumberName
FROM sample.ParentAddressExtension

INSERT INTO sample.ParentTeacherConference
    (ParentUSI
    , [DayOfWeek]
    , StartTime
    , EndTime)
SELECT
    ParentUSI
    ,'Monday'
    , '12:00:00'
    , '12:00:00'
FROM sample.ParentExtension

INSERT INTO sample.StudentParentAssociationExtension
    (ParentUSI
    , StudentUSI
    , BedtimeReader
    , PriorContactRestrictions
    , BookBudget
    , ReadGreenEggsAndHamDate
    , ReadingTimeSpent
    , BooksBorrowed
    , BedtimeReadingRate
    , LibraryTime
    , LibraryVisits
    , StudentRead
    , LibraryDuration
    , EducationOrganizationId
    , InterventionStudyIdentificationCode)
SELECT
    ParentUSI
    , StudentUSI
    , 0
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
    , NULL
FROM edfi.StudentParentAssociation
WHERE NOT EXISTS
    (SELECT
        ParentUSI
        , StudentUSI
    FROM sample.StudentParentAssociationExtension spa
    WHERE ParentUSI = spa.ParentUSI
    AND StudentUSI = spa.StudentUSI)

INSERT INTO sample.StudentParentAssociationFavoriteBookTitle
    (ParentUSI
    , StudentUSI
    , FavoriteBookTitle)
SELECT
    ParentUSI
    , StudentUSI
    , 'Green Eggs and Ham'
FROM edfi.StudentParentAssociation

INSERT INTO sample.StudentSchoolAssociationExtension
    (EntryDate
    , SchoolId
    , StudentUSI
    , MembershipTypeDescriptorId)
SELECT
    EntryDate
    , SchoolId
    , StudentUSI
    , NULL
FROM edfi.StudentSchoolAssociation
WHERE NOT EXISTS
    (SELECT
        EntryDate
        , SchoolId
        , StudentUSI
    FROM sample.StudentSchoolAssociationExtension ssae
    WHERE EntryDate = ssae.EntryDate
    AND SchoolId = ssae.SchoolId
    AND StudentUSI = ssae.StudentUSI)

INSERT INTO sample.StudentEducationOrganizationAssociationAddressExtension
    (AddressTypeDescriptorId
    , City
    , EducationOrganizationId
    , PostalCode
    , StateAbbreviationDescriptorId
    , StreetNumberName
    , StudentUSI
    , Complex
    , OnBusRoute)
SELECT
    AddressTypeDescriptorId
    , City
    , EducationOrganizationId
    , PostalCode
    , StateAbbreviationDescriptorId
    , StreetNumberName
    , StudentUSI
    , NULL
    , 0
FROM edfi.StudentEducationOrganizationAssociationAddress
WHERE NOT EXISTS
    (SELECT EntryDate, SchoolId, StudentUSI
    FROM sample.StudentSchoolAssociationExtension ssae
    WHERE EntryDate = ssae.EntryDate
    AND SchoolId = ssae.SchoolId
    AND StudentUSI = ssae.StudentUSI)

INSERT INTO sample.StudentEducationOrganizationAssociationAddressSchoolDistrict
    (AddressTypeDescriptorId
    , City
    , EducationOrganizationId
    , PostalCode
    , StateAbbreviationDescriptorId
    , StreetNumberName
    , StudentUSI
    , SchoolDistrict)
SELECT
    AddressTypeDescriptorId
    , City
    , EducationOrganizationId
    , PostalCode
    , StateAbbreviationDescriptorId
    , StreetNumberName
    , StudentUSI
    , 'Test District'
FROM sample.StudentEducationOrganizationAssociationAddressExtension

-- Create sample data for new Bus domain entity
INSERT INTO sample.Bus
    (BusId)
VALUES
    ('602')

INSERT INTO sample.StudentCTEProgramAssociationExtension
    (BeginDate
    , EducationOrganizationId
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI
    , AnalysisCompleted
    , AnalysisDate)
SELECT
    BeginDate
    , EducationOrganizationId
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI
    , NULL
    , NULL
FROM edfi.StudentCTEProgramAssociation
WHERE NOT EXISTS
    (SELECT
        BeginDate
        , EducationOrganizationId
        , ProgramEducationOrganizationId
        , ProgramName
        , ProgramTypeDescriptorId
        , StudentUSI
    FROM sample.StudentCTEProgramAssociationExtension scteopae
    WHERE BeginDate = scteopae.BeginDate
    AND EducationOrganizationId = scteopae.EducationOrganizationId
    AND ProgramEducationOrganizationId = scteopae.ProgramEducationOrganizationId
    AND ProgramName = scteopae.ProgramName
    AND ProgramTypeDescriptorId = scteopae.ProgramTypeDescriptorId
    AND StudentUSI = scteopae.StudentUSI)

-- Create sample data for new BusRoute domain entity
INSERT INTO sample.BusRoute
    (BusId
    , BusRouteNumber
    , BusRouteDirection
    , Daily
    , OperatingCost
    , StartDate
    , WeeklyMileage
    , ExpectedTransitTime
    , OptimalCapacity
    , HoursPerWeek
    , BusRouteDuration
    , DisabilityDescriptorId
    , StaffUSI
    , EducationOrganizationId
    , StaffClassificationDescriptorId
    , BeginDate)
VALUES
    ('602', 102, 'Northbound', 1, $10000.00, '2010-05-29', 375.33, '57', 9.75, 60.5, 3630, @disabilityDescriptorId, @staff207230AssignmentStaffUsi, @staff207230AssignmentEducationOrganizationId, @staff207230AssignmentStaffClassificationDescriptorId, @staff207230AssignmentBeginDate)

INSERT INTO sample.BusRouteBusYear
    (BusId
    , BusRouteNumber
    , BusYear)
VALUES
    ('602', 102, 2018)
    , ('602', 102, 2017)
    , ('602', 102, 2016)
    , ('602', 102, 2015)
    , ('602', 102, 2014)
    , ('602', 102, 2013)
    , ('602', 102, 2012)
    , ('602', 102, 2011)
    , ('602', 102, 2010)

INSERT INTO sample.BusRouteProgram
    (BusId
    , BusRouteNumber
    , EducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId)
VALUES ('602', 102, @bilingualProgramEducationOrganizationId, @bilingualProgramProgramName, @bilingualProgramProgramTypeDescriptorId)

INSERT INTO sample.BusRouteServiceAreaPostalCode
    (BusId
    , BusRouteNumber
    , ServiceAreaPostalCode)
VALUES ('602', 102, '78705')

INSERT INTO sample.BusRouteStartTime
    (BusId
    , BusRouteNumber
    , StartTime)
VALUES ('602', 102, '13:01:01.1234567')

INSERT INTO sample.BusRouteTelephone
    (BusId
    , BusRouteNumber
    , TelephoneNumberTypeDescriptorId
    , TelephoneNumber
    , OrderOfPriority
    , TextMessageCapabilityIndicator
    , DoNotPublishIndicator)
VALUES ('602', 102, @telephoneNumberTypeDescriptor, '555-123-4567', 1, 1, 0)

-- Add extension data for a particular school
UPDATE sample.SchoolExtension
SET IsExemplary = 1
WHERE SchoolId = @grandBendElementarySchoolId

INSERT INTO sample.SchoolCTEProgram
    (SchoolId
    , CareerPathwayDescriptorId
    , CIPCode
    , PrimaryCTEProgramIndicator
    , CTEProgramCompletionIndicator)
VALUES (@grandBendElementarySchoolId, @careerPathwayDescriptorId, '13.0301', 0, 1)

INSERT INTO sample.SchoolDirectlyOwnedBus
    (SchoolId
    , DirectlyOwnedBusId)
VALUES (@grandBendElementarySchoolId, '602')

--- Add extension data for a particular Parent
UPDATE sample.ParentExtension
SET IsSportsFan = 1
    , CoffeeSpend = 15.50
    , GraduationDate = '1976-04-30'
    , AverageCarLineWait = '20'
    , LuckyNumber = 13
    , RainCertainty = 5.75
    , PreferredWakeUpTime = '07:00:00'
    , BecameParent = 1983
    , GPA = 3.5
    , Duration = 25
WHERE ParentUSI = @parent777777Usi

UPDATE sample.ParentTeacherConference
SET [DayOfWeek] = 'Thursday',
    EndTime = '13:00:00'
WHERE ParentUSI = @parent777777Usi

INSERT INTO edfi.ParentAddress
    (AddressTypeDescriptorId
    , ParentUSI
    , StreetNumberName
    , City
    , StateAbbreviationDescriptorId
    , PostalCode)
VALUES (@addressTypeDescriptorId, @parent777777Usi, '123 ABC Street', 'Springfield', @stateAbbreviationDescriptorId, '1111111')

INSERT INTO sample.ParentAuthor
    (Author
    , ParentUSI)
VALUES ('SampleAuthor', @parent777777Usi)

INSERT INTO sample.ParentCeilingHeight
    (CeilingHeight
    , ParentUSI)
VALUES (10.2, @parent777777Usi)

INSERT INTO sample.ParentCTEProgram
    (ParentUSI
    , CareerPathwayDescriptorId
    , CIPCode
    , PrimaryCTEProgramIndicator
    , CTEProgramCompletionIndicator)
VALUES (@parent777777Usi, @careerPathwayDescriptorId, '13.0301', 0, 1)

INSERT INTO sample.ParentEducationContent
    (ContentIdentifier
    , ParentUSI)
VALUES (@educationContentIdentifier, @parent777777Usi)

INSERT INTO sample.ParentStudentProgramAssociation
    (BeginDate
    , EducationOrganizationId
    , ParentUSI
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI)
VALUES (@student604854SPABeginDate, @student604854SPAEducationOrganizationId, @parent777777Usi, @student604854SPAProgramEducationOrganizationId, @student604854SPAProgramName, @student604854SPAProgramTypeDescriptorId, @student604854Usi)

--- Add extension data for a particular Staff member
UPDATE sample.StaffExtension
SET FirstPetOwnedDate = '2013-04-15'
WHERE StaffUSI = @staff207219Usi

INSERT INTO sample.StaffPet
    (PetName
    , StaffUSI
    , IsFixed)
VALUES ('Sparky', @staff207219Usi, 1)

INSERT INTO sample.StaffPetPreference
    (StaffUSI
    , MinimumWeight
    , MaximumWeight)
VALUES (@staff207219Usi, 1, 50)

--- Add extension data for a particular Student
INSERT INTO sample.StudentPet
    (PetName
    , StudentUSI
    , IsFixed)
VALUES ('Bingo', @student604854Usi, 0)

INSERT INTO sample.StudentPetPreference
    (StudentUSI
    , MinimumWeight
    , MaximumWeight)
VALUES (@student604854Usi, 1, 35)

INSERT INTO sample.StudentAquaticPet
    (PetName
    , StudentUSI
    , IsFixed
    , MimimumTankVolume)
VALUES ('Nemo', @student604854Usi, NULL, 20)

INSERT INTO sample.StudentAquaticPet
    (PetName
    , StudentUSI
    , IsFixed
    , MimimumTankVolume)
VALUES ('Dory', @student604854Usi, NULL, 100)

--- Create sample data for new StudentArtProgram subclass
DECLARE @studentArtProgramAssociationStudentUsi INT;
DECLARE @studentArtProgramAssociationBeginDate DATETIME2;
DECLARE @studentArtProgramAssociationEducationOrganizationId INT;
DECLARE @studentArtProgramAssociationProgramEducationOrganizationId INT;
DECLARE @studentArtProgramAssociationProgramName NVARCHAR(60);
DECLARE @studentArtProgramAssocationProgramTypeDescriptorId INT;
SET @studentArtProgramAssociationStudentUsi = @student605614Usi;
SET @studentArtProgramAssociationBeginDate = '2018-08-20';
SET @studentArtProgramAssociationEducationOrganizationId = @grandBendElementarySchoolId;
SET @studentArtProgramAssociationProgramEducationOrganizationId = @bilingualProgramEducationOrganizationId;
SET @studentArtProgramAssociationProgramName = @bilingualProgramProgramName;
SET @studentArtProgramAssocationProgramTypeDescriptorId = @bilingualProgramProgramTypeDescriptorId;

INSERT INTO edfi.GeneralStudentProgramAssociation
    (BeginDate
    , EducationOrganizationId
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI
    , Discriminator)
VALUES (@studentArtProgramAssociationBeginDate, @studentArtProgramAssociationEducationOrganizationId, @studentArtProgramAssociationProgramEducationOrganizationId, @studentArtProgramAssociationProgramName, @studentArtProgramAssocationProgramTypeDescriptorId, @studentArtProgramAssociationStudentUsi, 'sample.StudentArtProgramAssociation')

INSERT INTO sample.StudentArtProgramAssociation
    (BeginDate
    , EducationOrganizationId
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI
    , IdentificationCode
    , ExhibitDate
    , ProgramFees
    , NumberOfDaysInAttendance
    , HoursPerDay
    , PrivateArtProgram
    , KilnReservation
    , KilnReservationLength
    , ArtPieces
    , PortfolioPieces
    , MasteredMediums)
VALUES (@studentArtProgramAssociationBeginDate, @studentArtProgramAssociationEducationOrganizationId, @studentArtProgramAssociationProgramEducationOrganizationId, @studentArtProgramAssociationProgramName, @studentArtProgramAssocationProgramTypeDescriptorId, @studentArtProgramAssociationStudentUsi, '1234', '2018-12-16', 40.00, 30, 1, 0, '12:15:00', '60', 15, 32, 2.5)

INSERT INTO sample.StudentArtProgramAssociationArtMedium
    (BeginDate
    , EducationOrganizationId
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI
    , ArtMediumDescriptorId)
VALUES (@studentArtProgramAssociationBeginDate, @studentArtProgramAssociationEducationOrganizationId, @studentArtProgramAssociationProgramEducationOrganizationId, @studentArtProgramAssociationProgramName, @studentArtProgramAssocationProgramTypeDescriptorId, @studentArtProgramAssociationStudentUsi, @artMediumDescriptorId)

INSERT INTO sample.StudentArtProgramAssociationPortfolioYears
    (BeginDate
    , EducationOrganizationId
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI
    , PortfolioYears)
VALUES (@studentArtProgramAssociationBeginDate, @studentArtProgramAssociationEducationOrganizationId, @studentArtProgramAssociationProgramEducationOrganizationId, @studentArtProgramAssociationProgramName, @studentArtProgramAssocationProgramTypeDescriptorId, @studentArtProgramAssociationStudentUsi, 2017)
    , (@studentArtProgramAssociationBeginDate, @studentArtProgramAssociationEducationOrganizationId, @studentArtProgramAssociationProgramEducationOrganizationId, @studentArtProgramAssociationProgramName, @studentArtProgramAssocationProgramTypeDescriptorId, @studentArtProgramAssociationStudentUsi, 2018)

INSERT INTO sample.StudentArtProgramAssociationService
    (BeginDate
    , EducationOrganizationId
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI
    , ServiceDescriptorId
    , PrimaryIndicator
    , ServiceBeginDate)
VALUES (@studentArtProgramAssociationBeginDate, @studentArtProgramAssociationEducationOrganizationId, @studentArtProgramAssociationProgramEducationOrganizationId, @studentArtProgramAssociationProgramName, @studentArtProgramAssocationProgramTypeDescriptorId, @studentArtProgramAssociationStudentUsi, @serviceDescriptorId, 1, '2018-09-03')

INSERT INTO sample.StudentArtProgramAssociationStyle
    (BeginDate
    , EducationOrganizationId
    , ProgramEducationOrganizationId
    , ProgramName
    , ProgramTypeDescriptorId
    , StudentUSI
    , Style)
VALUES (@studentArtProgramAssociationBeginDate, @studentArtProgramAssociationEducationOrganizationId, @studentArtProgramAssociationProgramEducationOrganizationId, @studentArtProgramAssociationProgramName, @studentArtProgramAssocationProgramTypeDescriptorId, @studentArtProgramAssociationStudentUsi, 'Post Modern')

--- Create sample data for new StudentGraduationPlanAssociation
INSERT INTO sample.StudentGraduationPlanAssociation
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , EffectiveDate
    , IsActivePlan
    , GraduationFee
    , TargetGPA
    , HighSchoolDuration
    , RequiredAttendance
    , CommencementTime
    , HoursPerWeek
    , StaffUSI)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, '2018-08-05', 1, 50.00, 3.75, '2', 0.95, '14:00:00', 30, @staff207219Usi)

INSERT INTO sample.StudentGraduationPlanAssociationAcademicSubject
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , AcademicSubjectDescriptorId)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, @academicSubjectDescriptorId)

INSERT INTO sample.StudentGraduationPlanAssociationStudentParentAssociation
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , ParentUSI)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, @parent778025Usi)

INSERT INTO sample.StudentGraduationPlanAssociationCareerPathwayCode
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , CareerPathwayCode)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, 15)

INSERT INTO sample.StudentGraduationPlanAssociationCTEProgram
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , CareerPathwayDescriptorId
    , CIPCode
    , PrimaryCTEProgramIndicator
    , CTEProgramCompletionIndicator)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, @careerPathwayDescriptorId, '13.0301', 1, 1)

INSERT INTO sample.StudentGraduationPlanAssociationDescription
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , Description)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, 'Recommended graduation plan with additional requirement of 3.75 GPA')

INSERT INTO sample.StudentGraduationPlanAssociationDesignatedBy
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , DesignatedBy)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, 'State of Texas')

INSERT INTO sample.StudentGraduationPlanAssociationIndustryCredential
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , IndustryCredential)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, 'CTE Certificate')

INSERT INTO sample.StudentGraduationPlanAssociationYearsAttended
    (EducationOrganizationId
    , GraduationPlanTypeDescriptorId
    , GraduationSchoolYear
    , StudentUSI
    , YearsAttended)
VALUES (@graduationPlanEducationOrganizationId, @graduationPlanTypeDescriptorId, @graduationPlanGraduationSchoolYear, @student604854Usi, 2017)

--- Add extension data for a particular StudentParentAssociation
UPDATE sample.StudentParentAssociationExtension
SET PriorContactRestrictions = 'No Pickup'
    , BedtimeReader = 1
    , BookBudget = 25.00
    , ReadGreenEggsAndHamDate = '2015-11-02'
    , ReadingTimeSpent = '30'
    , BooksBorrowed = 5
    , BedtimeReadingRate = 8.5
    , LibraryTime = '10:30:00'
    , LibraryVisits = 2
    , StudentRead = 2018
    , LibraryDuration = 45
    , EducationOrganizationId = 255901
WHERE ParentUSI = @parent777777Usi AND StudentUSI = @student605614Usi

INSERT INTO sample.StudentParentAssociationDiscipline
    (ParentUSI
    , StudentUSI
    , DisciplineDescriptorId)
VALUES (@parent777777Usi, @student605614Usi, @disciplineDescriptorId)

INSERT INTO sample.StudentParentAssociationHoursPerWeek
    (ParentUSI
    , StudentUSI
    , HoursPerWeek)
VALUES (@parent777777Usi, @student605614Usi, 14.5)

INSERT INTO sample.StudentParentAssociationPagesRead
    (ParentUSI
    , StudentUSI
    , PagesRead)
VALUES (@parent777777Usi, @student605614Usi, 567.8)

INSERT INTO sample.StudentParentAssociationStaffEducationOrganizationEmploymentAssociation
    (ParentUSI
    , StudentUSI
    , EducationOrganizationId
    , EmploymentStatusDescriptorId
    , HireDate
    , StaffUSI)
VALUES (@parent777777Usi, @student605614Usi, @staff207219EmploymentEducationOrganizationId, @staff207219EmploymentStatusDescriptorId, @staff207219EmploymentHireDate, @staff207219EmploymentStaffUSI)

INSERT INTO sample.StudentParentAssociationTelephone
    (ParentUSI
    , StudentUSI
    , TelephoneNumber
    , TelephoneNumberTypeDescriptorId
    , OrderOfPriority
    , TextMessageCapabilityIndicator
    , DoNotPublishIndicator)
VALUES (@parent777777Usi, @student605614Usi, '123-555-4567', @telephoneNumberTypeDescriptor, 1, 1, 0)

--- Add extension data to a particular StudentSchoolAssociation
UPDATE sample.StudentSchoolAssociationExtension
SET MembershipTypeDescriptorId = @membershipTypeDescriptorId
WHERE StudentUSI = @student604854Usi AND SchoolId = @grandBendElementarySchoolId

INSERT INTO sample.StudentFavoriteBook
           (FavoriteBookCategoryDescriptorId
           , StudentUSI
           , BookTitle)
     VALUES
           (@favoriteBookCategoryDescriptorId
           ,@student604854Usi
           ,'The Mindset')

INSERT INTO sample.StudentFavoriteBookArtMedium
           (ArtMediumDescriptorId
           , FavoriteBookCategoryDescriptorId
           , StudentUSI
           , ArtPieces)
     VALUES
           (@artMediumDescriptorId
           ,@favoriteBookCategoryDescriptorId
           ,@student604854Usi
           ,1)









