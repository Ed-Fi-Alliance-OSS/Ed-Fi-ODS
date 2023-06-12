-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table sample.ArtMediumDescriptor --
CREATE TABLE sample.ArtMediumDescriptor (
    ArtMediumDescriptorId INT NOT NULL,
    CONSTRAINT ArtMediumDescriptor_PK PRIMARY KEY (ArtMediumDescriptorId)
); 

-- Table sample.Bus --
CREATE TABLE sample.Bus (
    BusId VARCHAR(60) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Bus_PK PRIMARY KEY (BusId)
); 
ALTER TABLE sample.Bus ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE sample.Bus ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE sample.Bus ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table sample.BusRoute --
CREATE TABLE sample.BusRoute (
    BusId VARCHAR(60) NOT NULL,
    BusRouteNumber INT NOT NULL,
    BusRouteDirection VARCHAR(15) NOT NULL,
    Daily BOOLEAN NULL,
    OperatingCost MONEY NOT NULL,
    StartDate DATE NULL,
    WeeklyMileage DECIMAL(5, 2) NULL,
    ExpectedTransitTime VARCHAR(30) NOT NULL,
    OptimalCapacity DECIMAL(5, 4) NULL,
    HoursPerWeek DECIMAL(5, 2) NOT NULL,
    BusRouteDuration INT NULL,
    DisabilityDescriptorId INT NULL,
    StaffUSI INT NULL,
    EducationOrganizationId INT NULL,
    StaffClassificationDescriptorId INT NULL,
    BeginDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT BusRoute_PK PRIMARY KEY (BusId, BusRouteNumber)
); 
ALTER TABLE sample.BusRoute ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE sample.BusRoute ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE sample.BusRoute ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table sample.BusRouteBusYear --
CREATE TABLE sample.BusRouteBusYear (
    BusId VARCHAR(60) NOT NULL,
    BusRouteNumber INT NOT NULL,
    BusYear SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BusRouteBusYear_PK PRIMARY KEY (BusId, BusRouteNumber, BusYear)
); 
ALTER TABLE sample.BusRouteBusYear ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.BusRouteProgram --
CREATE TABLE sample.BusRouteProgram (
    BusId VARCHAR(60) NOT NULL,
    BusRouteNumber INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BusRouteProgram_PK PRIMARY KEY (BusId, BusRouteNumber, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
); 
ALTER TABLE sample.BusRouteProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.BusRouteServiceAreaPostalCode --
CREATE TABLE sample.BusRouteServiceAreaPostalCode (
    BusId VARCHAR(60) NOT NULL,
    BusRouteNumber INT NOT NULL,
    ServiceAreaPostalCode VARCHAR(17) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BusRouteServiceAreaPostalCode_PK PRIMARY KEY (BusId, BusRouteNumber, ServiceAreaPostalCode)
); 
ALTER TABLE sample.BusRouteServiceAreaPostalCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.BusRouteStartTime --
CREATE TABLE sample.BusRouteStartTime (
    BusId VARCHAR(60) NOT NULL,
    BusRouteNumber INT NOT NULL,
    StartTime TIME NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BusRouteStartTime_PK PRIMARY KEY (BusId, BusRouteNumber, StartTime)
); 
ALTER TABLE sample.BusRouteStartTime ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.BusRouteTelephone --
CREATE TABLE sample.BusRouteTelephone (
    BusId VARCHAR(60) NOT NULL,
    BusRouteNumber INT NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BusRouteTelephone_PK PRIMARY KEY (BusId, BusRouteNumber, TelephoneNumber, TelephoneNumberTypeDescriptorId)
); 
ALTER TABLE sample.BusRouteTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.FavoriteBookCategoryDescriptor --
CREATE TABLE sample.FavoriteBookCategoryDescriptor (
    FavoriteBookCategoryDescriptorId INT NOT NULL,
    CONSTRAINT FavoriteBookCategoryDescriptor_PK PRIMARY KEY (FavoriteBookCategoryDescriptorId)
); 

-- Table sample.MembershipTypeDescriptor --
CREATE TABLE sample.MembershipTypeDescriptor (
    MembershipTypeDescriptorId INT NOT NULL,
    CONSTRAINT MembershipTypeDescriptor_PK PRIMARY KEY (MembershipTypeDescriptorId)
); 

-- Table sample.ParentAddressExtension --
CREATE TABLE sample.ParentAddressExtension (
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    ParentUSI INT NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    Complex VARCHAR(255) NULL,
    OnBusRoute BOOLEAN NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentAddressExtension_PK PRIMARY KEY (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
); 
ALTER TABLE sample.ParentAddressExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentAddressSchoolDistrict --
CREATE TABLE sample.ParentAddressSchoolDistrict (
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    ParentUSI INT NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    SchoolDistrict VARCHAR(250) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentAddressSchoolDistrict_PK PRIMARY KEY (AddressTypeDescriptorId, City, ParentUSI, PostalCode, SchoolDistrict, StateAbbreviationDescriptorId, StreetNumberName)
); 
ALTER TABLE sample.ParentAddressSchoolDistrict ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentAddressTerm --
CREATE TABLE sample.ParentAddressTerm (
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    ParentUSI INT NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentAddressTerm_PK PRIMARY KEY (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, TermDescriptorId)
); 
ALTER TABLE sample.ParentAddressTerm ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentAuthor --
CREATE TABLE sample.ParentAuthor (
    Author VARCHAR(100) NOT NULL,
    ParentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentAuthor_PK PRIMARY KEY (Author, ParentUSI)
); 
ALTER TABLE sample.ParentAuthor ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentCeilingHeight --
CREATE TABLE sample.ParentCeilingHeight (
    CeilingHeight DECIMAL(5, 1) NOT NULL,
    ParentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentCeilingHeight_PK PRIMARY KEY (CeilingHeight, ParentUSI)
); 
ALTER TABLE sample.ParentCeilingHeight ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentCTEProgram --
CREATE TABLE sample.ParentCTEProgram (
    ParentUSI INT NOT NULL,
    CareerPathwayDescriptorId INT NOT NULL,
    CIPCode VARCHAR(120) NULL,
    PrimaryCTEProgramIndicator BOOLEAN NULL,
    CTEProgramCompletionIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentCTEProgram_PK PRIMARY KEY (ParentUSI)
); 
ALTER TABLE sample.ParentCTEProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentEducationContent --
CREATE TABLE sample.ParentEducationContent (
    ContentIdentifier VARCHAR(225) NOT NULL,
    ParentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentEducationContent_PK PRIMARY KEY (ContentIdentifier, ParentUSI)
); 
ALTER TABLE sample.ParentEducationContent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentExtension --
CREATE TABLE sample.ParentExtension (
    ParentUSI INT NOT NULL,
    IsSportsFan BOOLEAN NOT NULL,
    CoffeeSpend MONEY NULL,
    GraduationDate DATE NULL,
    AverageCarLineWait VARCHAR(30) NULL,
    LuckyNumber INT NULL,
    RainCertainty DECIMAL(5, 4) NULL,
    PreferredWakeUpTime TIME NULL,
    BecameParent SMALLINT NULL,
    GPA DECIMAL(18, 4) NULL,
    Duration INT NULL,
    CredentialFieldDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentExtension_PK PRIMARY KEY (ParentUSI)
); 
ALTER TABLE sample.ParentExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentFavoriteBookTitle --
CREATE TABLE sample.ParentFavoriteBookTitle (
    FavoriteBookTitle VARCHAR(100) NOT NULL,
    ParentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentFavoriteBookTitle_PK PRIMARY KEY (FavoriteBookTitle, ParentUSI)
); 
ALTER TABLE sample.ParentFavoriteBookTitle ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentStudentProgramAssociation --
CREATE TABLE sample.ParentStudentProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ParentUSI INT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentStudentProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ParentUSI, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
); 
ALTER TABLE sample.ParentStudentProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.ParentTeacherConference --
CREATE TABLE sample.ParentTeacherConference (
    ParentUSI INT NOT NULL,
    DayOfWeek VARCHAR(10) NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentTeacherConference_PK PRIMARY KEY (ParentUSI)
); 
ALTER TABLE sample.ParentTeacherConference ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.SchoolCTEProgram --
CREATE TABLE sample.SchoolCTEProgram (
    SchoolId INT NOT NULL,
    CareerPathwayDescriptorId INT NOT NULL,
    CIPCode VARCHAR(120) NULL,
    PrimaryCTEProgramIndicator BOOLEAN NULL,
    CTEProgramCompletionIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SchoolCTEProgram_PK PRIMARY KEY (SchoolId)
); 
ALTER TABLE sample.SchoolCTEProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.SchoolDirectlyOwnedBus --
CREATE TABLE sample.SchoolDirectlyOwnedBus (
    DirectlyOwnedBusId VARCHAR(60) NOT NULL,
    SchoolId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SchoolDirectlyOwnedBus_PK PRIMARY KEY (DirectlyOwnedBusId, SchoolId)
); 
ALTER TABLE sample.SchoolDirectlyOwnedBus ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.SchoolExtension --
CREATE TABLE sample.SchoolExtension (
    SchoolId INT NOT NULL,
    IsExemplary BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SchoolExtension_PK PRIMARY KEY (SchoolId)
); 
ALTER TABLE sample.SchoolExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StaffExtension --
CREATE TABLE sample.StaffExtension (
    StaffUSI INT NOT NULL,
    FirstPetOwnedDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffExtension_PK PRIMARY KEY (StaffUSI)
); 
ALTER TABLE sample.StaffExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StaffPet --
CREATE TABLE sample.StaffPet (
    PetName VARCHAR(20) NOT NULL,
    StaffUSI INT NOT NULL,
    IsFixed BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffPet_PK PRIMARY KEY (PetName, StaffUSI)
); 
ALTER TABLE sample.StaffPet ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StaffPetPreference --
CREATE TABLE sample.StaffPetPreference (
    StaffUSI INT NOT NULL,
    MinimumWeight INT NOT NULL,
    MaximumWeight INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffPetPreference_PK PRIMARY KEY (StaffUSI)
); 
ALTER TABLE sample.StaffPetPreference ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentAquaticPet --
CREATE TABLE sample.StudentAquaticPet (
    MimimumTankVolume INT NOT NULL,
    PetName VARCHAR(20) NOT NULL,
    StudentUSI INT NOT NULL,
    IsFixed BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAquaticPet_PK PRIMARY KEY (MimimumTankVolume, PetName, StudentUSI)
); 
ALTER TABLE sample.StudentAquaticPet ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentArtProgramAssociation --
CREATE TABLE sample.StudentArtProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    IdentificationCode VARCHAR(60) NULL,
    ExhibitDate DATE NULL,
    ProgramFees MONEY NULL,
    NumberOfDaysInAttendance DECIMAL(18, 4) NULL,
    HoursPerDay DECIMAL(5, 2) NULL,
    PrivateArtProgram BOOLEAN NOT NULL,
    KilnReservation TIME NULL,
    KilnReservationLength VARCHAR(30) NULL,
    ArtPieces INT NULL,
    PortfolioPieces INT NULL,
    MasteredMediums DECIMAL(5, 4) NULL,
    CONSTRAINT StudentArtProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
); 

-- Table sample.StudentArtProgramAssociationArtMedium --
CREATE TABLE sample.StudentArtProgramAssociationArtMedium (
    ArtMediumDescriptorId INT NOT NULL,
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentArtProgramAssociationArtMedium_PK PRIMARY KEY (ArtMediumDescriptorId, BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
); 
ALTER TABLE sample.StudentArtProgramAssociationArtMedium ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentArtProgramAssociationPortfolioYears --
CREATE TABLE sample.StudentArtProgramAssociationPortfolioYears (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    PortfolioYears SMALLINT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentArtProgramAssociationPortfolioYears_PK PRIMARY KEY (BeginDate, EducationOrganizationId, PortfolioYears, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
); 
ALTER TABLE sample.StudentArtProgramAssociationPortfolioYears ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentArtProgramAssociationService --
CREATE TABLE sample.StudentArtProgramAssociationService (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ServiceDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentArtProgramAssociationService_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, ServiceDescriptorId, StudentUSI)
); 
ALTER TABLE sample.StudentArtProgramAssociationService ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentArtProgramAssociationStyle --
CREATE TABLE sample.StudentArtProgramAssociationStyle (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    Style VARCHAR(50) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentArtProgramAssociationStyle_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Style)
); 
ALTER TABLE sample.StudentArtProgramAssociationStyle ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentCTEProgramAssociationExtension --
CREATE TABLE sample.StudentCTEProgramAssociationExtension (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramEducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    AnalysisCompleted BOOLEAN NULL,
    AnalysisDate TIMESTAMP NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentCTEProgramAssociationExtension_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
); 
ALTER TABLE sample.StudentCTEProgramAssociationExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentEducationOrganizationAssociationAddressExtension --
CREATE TABLE sample.StudentEducationOrganizationAssociationAddressExtension (
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    StudentUSI INT NOT NULL,
    Complex VARCHAR(255) NULL,
    OnBusRoute BOOLEAN NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationAddressExtension_PK PRIMARY KEY (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
); 
ALTER TABLE sample.StudentEducationOrganizationAssociationAddressExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentEducationOrganizationAssociationAddressSchoolDistrict --
CREATE TABLE sample.StudentEducationOrganizationAssociationAddressSchoolDistrict (
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    SchoolDistrict VARCHAR(250) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationAddressSchoolDistrict_PK PRIMARY KEY (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, SchoolDistrict, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
); 
ALTER TABLE sample.StudentEducationOrganizationAssociationAddressSchoolDistrict ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentEducationOrganizationAssociationAddressTerm --
CREATE TABLE sample.StudentEducationOrganizationAssociationAddressTerm (
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationAddressTerm_PK PRIMARY KEY (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI, TermDescriptorId)
); 
ALTER TABLE sample.StudentEducationOrganizationAssociationAddressTerm ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152 --
CREATE TABLE sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152 (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    StudentCharacteristicDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    PrimaryStudentNeedIndicator BOOLEAN NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationStudentChar_17d152_PK PRIMARY KEY (BeginDate, EducationOrganizationId, StudentCharacteristicDescriptorId, StudentUSI)
); 
ALTER TABLE sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152 ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentFavoriteBook --
CREATE TABLE sample.StudentFavoriteBook (
    FavoriteBookCategoryDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    BookTitle VARCHAR(200) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentFavoriteBook_PK PRIMARY KEY (FavoriteBookCategoryDescriptorId, StudentUSI)
); 
ALTER TABLE sample.StudentFavoriteBook ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentFavoriteBookArtMedium --
CREATE TABLE sample.StudentFavoriteBookArtMedium (
    ArtMediumDescriptorId INT NOT NULL,
    FavoriteBookCategoryDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ArtPieces INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentFavoriteBookArtMedium_PK PRIMARY KEY (ArtMediumDescriptorId, FavoriteBookCategoryDescriptorId, StudentUSI)
); 
ALTER TABLE sample.StudentFavoriteBookArtMedium ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociation --
CREATE TABLE sample.StudentGraduationPlanAssociation (
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    EffectiveDate DATE NOT NULL,
    IsActivePlan BOOLEAN NULL,
    GraduationFee MONEY NULL,
    TargetGPA DECIMAL(18, 4) NOT NULL,
    HighSchoolDuration VARCHAR(30) NULL,
    RequiredAttendance DECIMAL(5, 4) NULL,
    CommencementTime TIME NULL,
    HoursPerWeek DECIMAL(5, 2) NOT NULL,
    StaffUSI INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociation_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
); 
ALTER TABLE sample.StudentGraduationPlanAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE sample.StudentGraduationPlanAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE sample.StudentGraduationPlanAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociationAcademicSubject --
CREATE TABLE sample.StudentGraduationPlanAssociationAcademicSubject (
    AcademicSubjectDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociationAcademicSubject_PK PRIMARY KEY (AcademicSubjectDescriptorId, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
); 
ALTER TABLE sample.StudentGraduationPlanAssociationAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociationCareerPathwayCode --
CREATE TABLE sample.StudentGraduationPlanAssociationCareerPathwayCode (
    CareerPathwayCode INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociationCareerPathwayCode_PK PRIMARY KEY (CareerPathwayCode, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
); 
ALTER TABLE sample.StudentGraduationPlanAssociationCareerPathwayCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociationCTEProgram --
CREATE TABLE sample.StudentGraduationPlanAssociationCTEProgram (
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    CareerPathwayDescriptorId INT NOT NULL,
    CIPCode VARCHAR(120) NULL,
    PrimaryCTEProgramIndicator BOOLEAN NULL,
    CTEProgramCompletionIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociationCTEProgram_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
); 
ALTER TABLE sample.StudentGraduationPlanAssociationCTEProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociationDescription --
CREATE TABLE sample.StudentGraduationPlanAssociationDescription (
    Description VARCHAR(1024) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociationDescription_PK PRIMARY KEY (Description, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
); 
ALTER TABLE sample.StudentGraduationPlanAssociationDescription ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociationDesignatedBy --
CREATE TABLE sample.StudentGraduationPlanAssociationDesignatedBy (
    DesignatedBy VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociationDesignatedBy_PK PRIMARY KEY (DesignatedBy, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
); 
ALTER TABLE sample.StudentGraduationPlanAssociationDesignatedBy ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociationIndustryCredential --
CREATE TABLE sample.StudentGraduationPlanAssociationIndustryCredential (
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    IndustryCredential VARCHAR(100) NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociationIndustryCredential_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, IndustryCredential, StudentUSI)
); 
ALTER TABLE sample.StudentGraduationPlanAssociationIndustryCredential ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociationStudentParentAssociation --
CREATE TABLE sample.StudentGraduationPlanAssociationStudentParentAssociation (
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    ParentUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociationStudentParentAssociation_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, ParentUSI, StudentUSI)
); 
ALTER TABLE sample.StudentGraduationPlanAssociationStudentParentAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentGraduationPlanAssociationYearsAttended --
CREATE TABLE sample.StudentGraduationPlanAssociationYearsAttended (
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    YearsAttended SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGraduationPlanAssociationYearsAttended_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI, YearsAttended)
); 
ALTER TABLE sample.StudentGraduationPlanAssociationYearsAttended ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentParentAssociationDiscipline --
CREATE TABLE sample.StudentParentAssociationDiscipline (
    DisciplineDescriptorId INT NOT NULL,
    ParentUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentParentAssociationDiscipline_PK PRIMARY KEY (DisciplineDescriptorId, ParentUSI, StudentUSI)
); 
ALTER TABLE sample.StudentParentAssociationDiscipline ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentParentAssociationExtension --
CREATE TABLE sample.StudentParentAssociationExtension (
    ParentUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    PriorContactRestrictions VARCHAR(250) NULL,
    BedtimeReader BOOLEAN NOT NULL,
    BookBudget MONEY NULL,
    ReadGreenEggsAndHamDate DATE NULL,
    ReadingTimeSpent VARCHAR(30) NULL,
    BooksBorrowed INT NULL,
    BedtimeReadingRate DECIMAL(5, 4) NULL,
    LibraryTime TIME NULL,
    LibraryVisits SMALLINT NULL,
    StudentRead SMALLINT NULL,
    LibraryDuration INT NULL,
    EducationOrganizationId INT NULL,
    InterventionStudyIdentificationCode VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentParentAssociationExtension_PK PRIMARY KEY (ParentUSI, StudentUSI)
); 
ALTER TABLE sample.StudentParentAssociationExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentParentAssociationFavoriteBookTitle --
CREATE TABLE sample.StudentParentAssociationFavoriteBookTitle (
    FavoriteBookTitle VARCHAR(100) NOT NULL,
    ParentUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentParentAssociationFavoriteBookTitle_PK PRIMARY KEY (FavoriteBookTitle, ParentUSI, StudentUSI)
); 
ALTER TABLE sample.StudentParentAssociationFavoriteBookTitle ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentParentAssociationHoursPerWeek --
CREATE TABLE sample.StudentParentAssociationHoursPerWeek (
    HoursPerWeek DECIMAL(5, 2) NOT NULL,
    ParentUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentParentAssociationHoursPerWeek_PK PRIMARY KEY (HoursPerWeek, ParentUSI, StudentUSI)
); 
ALTER TABLE sample.StudentParentAssociationHoursPerWeek ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentParentAssociationPagesRead --
CREATE TABLE sample.StudentParentAssociationPagesRead (
    PagesRead DECIMAL(18, 2) NOT NULL,
    ParentUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentParentAssociationPagesRead_PK PRIMARY KEY (PagesRead, ParentUSI, StudentUSI)
); 
ALTER TABLE sample.StudentParentAssociationPagesRead ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c --
CREATE TABLE sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c (
    EducationOrganizationId INT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    ParentUSI INT NOT NULL,
    StaffUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentParentAssociationStaffEducationOrganization_c4af0c_PK PRIMARY KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, ParentUSI, StaffUSI, StudentUSI)
); 
ALTER TABLE sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentParentAssociationTelephone --
CREATE TABLE sample.StudentParentAssociationTelephone (
    ParentUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentParentAssociationTelephone_PK PRIMARY KEY (ParentUSI, StudentUSI)
); 
ALTER TABLE sample.StudentParentAssociationTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentPet --
CREATE TABLE sample.StudentPet (
    PetName VARCHAR(20) NOT NULL,
    StudentUSI INT NOT NULL,
    IsFixed BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentPet_PK PRIMARY KEY (PetName, StudentUSI)
); 
ALTER TABLE sample.StudentPet ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentPetPreference --
CREATE TABLE sample.StudentPetPreference (
    StudentUSI INT NOT NULL,
    MinimumWeight INT NOT NULL,
    MaximumWeight INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentPetPreference_PK PRIMARY KEY (StudentUSI)
); 
ALTER TABLE sample.StudentPetPreference ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentSchoolAssociationExtension --
CREATE TABLE sample.StudentSchoolAssociationExtension (
    EntryDate DATE NOT NULL,
    SchoolId INT NOT NULL,
    StudentUSI INT NOT NULL,
    MembershipTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSchoolAssociationExtension_PK PRIMARY KEY (EntryDate, SchoolId, StudentUSI)
); 
ALTER TABLE sample.StudentSchoolAssociationExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 --
CREATE TABLE sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 (
    BeginDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    RelatedBeginDate DATE NOT NULL,
    RelatedEducationOrganizationId INT NOT NULL,
    RelatedProgramEducationOrganizationId INT NOT NULL,
    RelatedProgramName VARCHAR(60) NOT NULL,
    RelatedProgramTypeDescriptorId INT NOT NULL,
    SchoolId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSectionAssociationRelatedGeneralStudentProg_c72e02_PK PRIMARY KEY (BeginDate, LocalCourseCode, RelatedBeginDate, RelatedEducationOrganizationId, RelatedProgramEducationOrganizationId, RelatedProgramName, RelatedProgramTypeDescriptorId, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
); 
ALTER TABLE sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

