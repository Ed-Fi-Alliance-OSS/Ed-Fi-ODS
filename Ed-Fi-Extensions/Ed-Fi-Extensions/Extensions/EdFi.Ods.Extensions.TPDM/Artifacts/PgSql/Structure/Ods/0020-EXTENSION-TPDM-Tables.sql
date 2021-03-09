-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table tpdm.AccreditationStatusDescriptor --
CREATE TABLE tpdm.AccreditationStatusDescriptor (
    AccreditationStatusDescriptorId INT NOT NULL,
    CONSTRAINT AccreditationStatusDescriptor_PK PRIMARY KEY (AccreditationStatusDescriptorId)
); 

-- Table tpdm.AidTypeDescriptor --
CREATE TABLE tpdm.AidTypeDescriptor (
    AidTypeDescriptorId INT NOT NULL,
    CONSTRAINT AidTypeDescriptor_PK PRIMARY KEY (AidTypeDescriptorId)
); 

-- Table tpdm.ApplicantProfile --
CREATE TABLE tpdm.ApplicantProfile (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    FirstName VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    MaidenName VARCHAR(75) NULL,
    SexDescriptorId INT NULL,
    BirthDate DATE NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    CitizenshipStatusDescriptorId INT NULL,
    GenderDescriptorId INT NULL,
    EconomicDisadvantaged BOOLEAN NULL,
    FirstGenerationStudent BOOLEAN NULL,
    HighestCompletedLevelOfEducationDescriptorId INT NULL,
    YearsOfPriorProfessionalExperience DECIMAL(5, 2) NULL,
    YearsOfPriorTeachingExperience DECIMAL(5, 2) NULL,
    HighlyQualifiedTeacher BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ApplicantProfile_PK PRIMARY KEY (ApplicantProfileIdentifier)
); 
ALTER TABLE tpdm.ApplicantProfile ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.ApplicantProfile ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.ApplicantProfile ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileAddress --
CREATE TABLE tpdm.ApplicantProfileAddress (
    AddressTypeDescriptorId INT NOT NULL,
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    LocaleDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileAddress_PK PRIMARY KEY (AddressTypeDescriptorId, ApplicantProfileIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
); 
ALTER TABLE tpdm.ApplicantProfileAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileAddressPeriod --
CREATE TABLE tpdm.ApplicantProfileAddressPeriod (
    AddressTypeDescriptorId INT NOT NULL,
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    BeginDate DATE NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileAddressPeriod_PK PRIMARY KEY (AddressTypeDescriptorId, ApplicantProfileIdentifier, BeginDate, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
); 
ALTER TABLE tpdm.ApplicantProfileAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileApplicantCharacteristic --
CREATE TABLE tpdm.ApplicantProfileApplicantCharacteristic (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    StudentCharacteristicDescriptorId INT NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    DesignatedBy VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileApplicantCharacteristic_PK PRIMARY KEY (ApplicantProfileIdentifier, StudentCharacteristicDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileApplicantCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileBackgroundCheck --
CREATE TABLE tpdm.ApplicantProfileBackgroundCheck (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileBackgroundCheck_PK PRIMARY KEY (ApplicantProfileIdentifier, BackgroundCheckTypeDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileDisability --
CREATE TABLE tpdm.ApplicantProfileDisability (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileDisability_PK PRIMARY KEY (ApplicantProfileIdentifier, DisabilityDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileDisabilityDesignation --
CREATE TABLE tpdm.ApplicantProfileDisabilityDesignation (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileDisabilityDesignation_PK PRIMARY KEY (ApplicantProfileIdentifier, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileEducatorPreparationProgramName --
CREATE TABLE tpdm.ApplicantProfileEducatorPreparationProgramName (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    EducatorPreparationProgramName VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileEducatorPreparationProgramName_PK PRIMARY KEY (ApplicantProfileIdentifier, EducatorPreparationProgramName)
); 
ALTER TABLE tpdm.ApplicantProfileEducatorPreparationProgramName ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileElectronicMail --
CREATE TABLE tpdm.ApplicantProfileElectronicMail (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileElectronicMail_PK PRIMARY KEY (ApplicantProfileIdentifier, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileGradePointAverage --
CREATE TABLE tpdm.ApplicantProfileGradePointAverage (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    GradePointAverageTypeDescriptorId INT NOT NULL,
    IsCumulative BOOLEAN NULL,
    GradePointAverageValue DECIMAL(18, 4) NOT NULL,
    MaxGradePointAverageValue DECIMAL(18, 4) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileGradePointAverage_PK PRIMARY KEY (ApplicantProfileIdentifier, GradePointAverageTypeDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileGradePointAverage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileHighlyQualifiedAcademicSubject --
CREATE TABLE tpdm.ApplicantProfileHighlyQualifiedAcademicSubject (
    AcademicSubjectDescriptorId INT NOT NULL,
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileHighlyQualifiedAcademicSubject_PK PRIMARY KEY (AcademicSubjectDescriptorId, ApplicantProfileIdentifier)
); 
ALTER TABLE tpdm.ApplicantProfileHighlyQualifiedAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileIdentificationDocument --
CREATE TABLE tpdm.ApplicantProfileIdentificationDocument (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileIdentificationDocument_PK PRIMARY KEY (ApplicantProfileIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileInternationalAddress --
CREATE TABLE tpdm.ApplicantProfileInternationalAddress (
    AddressTypeDescriptorId INT NOT NULL,
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    CountryDescriptorId INT NOT NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileInternationalAddress_PK PRIMARY KEY (AddressTypeDescriptorId, ApplicantProfileIdentifier)
); 
ALTER TABLE tpdm.ApplicantProfileInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileLanguage --
CREATE TABLE tpdm.ApplicantProfileLanguage (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileLanguage_PK PRIMARY KEY (ApplicantProfileIdentifier, LanguageDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileLanguageUse --
CREATE TABLE tpdm.ApplicantProfileLanguageUse (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileLanguageUse_PK PRIMARY KEY (ApplicantProfileIdentifier, LanguageDescriptorId, LanguageUseDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfilePersonalIdentificationDocument --
CREATE TABLE tpdm.ApplicantProfilePersonalIdentificationDocument (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfilePersonalIdentificationDocument_PK PRIMARY KEY (ApplicantProfileIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfilePersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileRace --
CREATE TABLE tpdm.ApplicantProfileRace (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileRace_PK PRIMARY KEY (ApplicantProfileIdentifier, RaceDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileTelephone --
CREATE TABLE tpdm.ApplicantProfileTelephone (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileTelephone_PK PRIMARY KEY (ApplicantProfileIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProfileVisa --
CREATE TABLE tpdm.ApplicantProfileVisa (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileVisa_PK PRIMARY KEY (ApplicantProfileIdentifier, VisaDescriptorId)
); 
ALTER TABLE tpdm.ApplicantProfileVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.Application --
CREATE TABLE tpdm.Application (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ApplicationDate DATE NOT NULL,
    ApplicationStatusDescriptorId INT NOT NULL,
    CurrentEmployee BOOLEAN NULL,
    AcademicSubjectDescriptorId INT NULL,
    AcceptedDate DATE NULL,
    ApplicationSourceDescriptorId INT NULL,
    FirstContactDate DATE NULL,
    HighNeedsAcademicSubjectDescriptorId INT NULL,
    HireStatusDescriptorId INT NULL,
    HiringSourceDescriptorId INT NULL,
    WithdrawDate DATE NULL,
    WithdrawReasonDescriptorId INT NULL,
    RequisitionNumber VARCHAR(20) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Application_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
); 
ALTER TABLE tpdm.Application ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.Application ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.Application ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicationEvent --
CREATE TABLE tpdm.ApplicationEvent (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationEventTypeDescriptorId INT NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    SequenceNumber INT NOT NULL,
    EventEndDate DATE NULL,
    ApplicationEvaluationScore DECIMAL(36, 18) NULL,
    ApplicationEventResultDescriptorId INT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ApplicationEvent_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationEventTypeDescriptorId, ApplicationIdentifier, EducationOrganizationId, EventDate, SequenceNumber)
); 
ALTER TABLE tpdm.ApplicationEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.ApplicationEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.ApplicationEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicationEventResultDescriptor --
CREATE TABLE tpdm.ApplicationEventResultDescriptor (
    ApplicationEventResultDescriptorId INT NOT NULL,
    CONSTRAINT ApplicationEventResultDescriptor_PK PRIMARY KEY (ApplicationEventResultDescriptorId)
); 

-- Table tpdm.ApplicationEventTypeDescriptor --
CREATE TABLE tpdm.ApplicationEventTypeDescriptor (
    ApplicationEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT ApplicationEventTypeDescriptor_PK PRIMARY KEY (ApplicationEventTypeDescriptorId)
); 

-- Table tpdm.ApplicationRecruitmentEventAttendance --
CREATE TABLE tpdm.ApplicationRecruitmentEventAttendance (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationRecruitmentEventAttendance_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.ApplicationRecruitmentEventAttendance ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicationScoreResult --
CREATE TABLE tpdm.ApplicationScoreResult (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    Result VARCHAR(35) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationScoreResult_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationIdentifier, AssessmentReportingMethodDescriptorId, EducationOrganizationId)
); 
ALTER TABLE tpdm.ApplicationScoreResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicationSourceDescriptor --
CREATE TABLE tpdm.ApplicationSourceDescriptor (
    ApplicationSourceDescriptorId INT NOT NULL,
    CONSTRAINT ApplicationSourceDescriptor_PK PRIMARY KEY (ApplicationSourceDescriptorId)
); 

-- Table tpdm.ApplicationStatusDescriptor --
CREATE TABLE tpdm.ApplicationStatusDescriptor (
    ApplicationStatusDescriptorId INT NOT NULL,
    CONSTRAINT ApplicationStatusDescriptor_PK PRIMARY KEY (ApplicationStatusDescriptorId)
); 

-- Table tpdm.ApplicationTerm --
CREATE TABLE tpdm.ApplicationTerm (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationTerm_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId, TermDescriptorId)
); 
ALTER TABLE tpdm.ApplicationTerm ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.AssessmentExtension --
CREATE TABLE tpdm.AssessmentExtension (
    AssessmentIdentifier VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    ProgramGatewayDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentExtension_PK PRIMARY KEY (AssessmentIdentifier, Namespace)
); 
ALTER TABLE tpdm.AssessmentExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.BackgroundCheckStatusDescriptor --
CREATE TABLE tpdm.BackgroundCheckStatusDescriptor (
    BackgroundCheckStatusDescriptorId INT NOT NULL,
    CONSTRAINT BackgroundCheckStatusDescriptor_PK PRIMARY KEY (BackgroundCheckStatusDescriptorId)
); 

-- Table tpdm.BackgroundCheckTypeDescriptor --
CREATE TABLE tpdm.BackgroundCheckTypeDescriptor (
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    CONSTRAINT BackgroundCheckTypeDescriptor_PK PRIMARY KEY (BackgroundCheckTypeDescriptorId)
); 

-- Table tpdm.Candidate --
CREATE TABLE tpdm.Candidate (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    FirstName VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    MaidenName VARCHAR(75) NULL,
    SexDescriptorId INT NOT NULL,
    BirthDate DATE NOT NULL,
    BirthCity VARCHAR(30) NULL,
    BirthStateAbbreviationDescriptorId INT NULL,
    BirthInternationalProvince VARCHAR(150) NULL,
    BirthCountryDescriptorId INT NULL,
    DateEnteredUS DATE NULL,
    MultipleBirthStatus BOOLEAN NULL,
    BirthSexDescriptorId INT NULL,
    ProfileThumbnail VARCHAR(255) NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    OldEthnicityDescriptorId INT NULL,
    CitizenshipStatusDescriptorId INT NULL,
    EconomicDisadvantaged BOOLEAN NULL,
    LimitedEnglishProficiencyDescriptorId INT NULL,
    DisplacementStatus VARCHAR(30) NULL,
    LoginId VARCHAR(60) NULL,
    GenderDescriptorId INT NULL,
    TuitionCost MONEY NULL,
    EnglishLanguageExamDescriptorId INT NULL,
    PreviousCareerDescriptorId INT NULL,
    ProgramComplete BOOLEAN NULL,
    FirstGenerationStudent BOOLEAN NULL,
    PersonId VARCHAR(32) NULL,
    SourceSystemDescriptorId INT NULL,
    ApplicationIdentifier VARCHAR(20) NULL,
    EducationOrganizationId INT NULL,
    ApplicantProfileIdentifier VARCHAR(32) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Candidate_PK PRIMARY KEY (CandidateIdentifier)
); 
ALTER TABLE tpdm.Candidate ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.Candidate ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.Candidate ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateAddress --
CREATE TABLE tpdm.CandidateAddress (
    AddressTypeDescriptorId INT NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    LocaleDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateAddress_PK PRIMARY KEY (AddressTypeDescriptorId, CandidateIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
); 
ALTER TABLE tpdm.CandidateAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateAddressPeriod --
CREATE TABLE tpdm.CandidateAddressPeriod (
    AddressTypeDescriptorId INT NOT NULL,
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateAddressPeriod_PK PRIMARY KEY (AddressTypeDescriptorId, BeginDate, CandidateIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
); 
ALTER TABLE tpdm.CandidateAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateAid --
CREATE TABLE tpdm.CandidateAid (
    AidTypeDescriptorId INT NOT NULL,
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EndDate DATE NULL,
    AidConditionDescription VARCHAR(1024) NULL,
    AidAmount MONEY NULL,
    PellGrantRecipient BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateAid_PK PRIMARY KEY (AidTypeDescriptorId, BeginDate, CandidateIdentifier)
); 
ALTER TABLE tpdm.CandidateAid ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateBackgroundCheck --
CREATE TABLE tpdm.CandidateBackgroundCheck (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateBackgroundCheck_PK PRIMARY KEY (CandidateIdentifier)
); 
ALTER TABLE tpdm.CandidateBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateCharacteristic --
CREATE TABLE tpdm.CandidateCharacteristic (
    CandidateCharacteristicDescriptorId INT NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    DesignatedBy VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateCharacteristic_PK PRIMARY KEY (CandidateCharacteristicDescriptorId, CandidateIdentifier)
); 
ALTER TABLE tpdm.CandidateCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateCharacteristicDescriptor --
CREATE TABLE tpdm.CandidateCharacteristicDescriptor (
    CandidateCharacteristicDescriptorId INT NOT NULL,
    CONSTRAINT CandidateCharacteristicDescriptor_PK PRIMARY KEY (CandidateCharacteristicDescriptorId)
); 

-- Table tpdm.CandidateCohortYear --
CREATE TABLE tpdm.CandidateCohortYear (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    CohortYearTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateCohortYear_PK PRIMARY KEY (CandidateIdentifier, CohortYearTypeDescriptorId, SchoolYear)
); 
ALTER TABLE tpdm.CandidateCohortYear ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateDegreeSpecialization --
CREATE TABLE tpdm.CandidateDegreeSpecialization (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    MajorSpecialization VARCHAR(75) NOT NULL,
    MinorSpecialization VARCHAR(75) NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateDegreeSpecialization_PK PRIMARY KEY (BeginDate, CandidateIdentifier, MajorSpecialization)
); 
ALTER TABLE tpdm.CandidateDegreeSpecialization ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateDisability --
CREATE TABLE tpdm.CandidateDisability (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateDisability_PK PRIMARY KEY (CandidateIdentifier, DisabilityDescriptorId)
); 
ALTER TABLE tpdm.CandidateDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateDisabilityDesignation --
CREATE TABLE tpdm.CandidateDisabilityDesignation (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateDisabilityDesignation_PK PRIMARY KEY (CandidateIdentifier, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
); 
ALTER TABLE tpdm.CandidateDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateEducatorPreparationProgramAssociation --
CREATE TABLE tpdm.CandidateEducatorPreparationProgramAssociation (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    ReasonExitedDescriptorId INT NULL,
    EPPProgramPathwayDescriptorId INT NULL,
    MajorSpecialization VARCHAR(75) NULL,
    MinorSpecialization VARCHAR(75) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CandidateEducatorPreparationProgramAssociation_PK PRIMARY KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
); 
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b --
CREATE TABLE tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    IndicatorGroup VARCHAR(200) NULL,
    IndicatorName VARCHAR(200) NOT NULL,
    Indicator VARCHAR(60) NOT NULL,
    DesignatedBy VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateEducatorPreparationProgramAssociationCand_0d7c2b_PK PRIMARY KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
); 
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14 --
CREATE TABLE tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14 (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateEducatorPreparationProgramAssociationCand_fc4f14_PK PRIMARY KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
); 
ALTER TABLE tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14 ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateElectronicMail --
CREATE TABLE tpdm.CandidateElectronicMail (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateElectronicMail_PK PRIMARY KEY (CandidateIdentifier, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
); 
ALTER TABLE tpdm.CandidateElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateEPPProgramDegree --
CREATE TABLE tpdm.CandidateEPPProgramDegree (
    AcademicSubjectDescriptorId INT NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EPPDegreeTypeDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateEPPProgramDegree_PK PRIMARY KEY (AcademicSubjectDescriptorId, CandidateIdentifier, EPPDegreeTypeDescriptorId, GradeLevelDescriptorId)
); 
ALTER TABLE tpdm.CandidateEPPProgramDegree ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateIdentificationCode --
CREATE TABLE tpdm.CandidateIdentificationCode (
    AssigningOrganizationIdentificationCode VARCHAR(60) NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    IdentificationCode VARCHAR(60) NOT NULL,
    StudentIdentificationSystemDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateIdentificationCode_PK PRIMARY KEY (AssigningOrganizationIdentificationCode, CandidateIdentifier, IdentificationCode, StudentIdentificationSystemDescriptorId)
); 
ALTER TABLE tpdm.CandidateIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateIdentificationDocument --
CREATE TABLE tpdm.CandidateIdentificationDocument (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateIdentificationDocument_PK PRIMARY KEY (CandidateIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
); 
ALTER TABLE tpdm.CandidateIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateIndicator --
CREATE TABLE tpdm.CandidateIndicator (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    IndicatorName VARCHAR(200) NOT NULL,
    IndicatorGroup VARCHAR(200) NULL,
    Indicator VARCHAR(60) NOT NULL,
    DesignatedBy VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateIndicator_PK PRIMARY KEY (CandidateIdentifier, IndicatorName)
); 
ALTER TABLE tpdm.CandidateIndicator ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateIndicatorPeriod --
CREATE TABLE tpdm.CandidateIndicatorPeriod (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    IndicatorName VARCHAR(200) NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateIndicatorPeriod_PK PRIMARY KEY (BeginDate, CandidateIdentifier, IndicatorName)
); 
ALTER TABLE tpdm.CandidateIndicatorPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateInternationalAddress --
CREATE TABLE tpdm.CandidateInternationalAddress (
    AddressTypeDescriptorId INT NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    CountryDescriptorId INT NOT NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateInternationalAddress_PK PRIMARY KEY (AddressTypeDescriptorId, CandidateIdentifier)
); 
ALTER TABLE tpdm.CandidateInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateLanguage --
CREATE TABLE tpdm.CandidateLanguage (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateLanguage_PK PRIMARY KEY (CandidateIdentifier, LanguageDescriptorId)
); 
ALTER TABLE tpdm.CandidateLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateLanguageUse --
CREATE TABLE tpdm.CandidateLanguageUse (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateLanguageUse_PK PRIMARY KEY (CandidateIdentifier, LanguageDescriptorId, LanguageUseDescriptorId)
); 
ALTER TABLE tpdm.CandidateLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateOtherName --
CREATE TABLE tpdm.CandidateOtherName (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    OtherNameTypeDescriptorId INT NOT NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    FirstName VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateOtherName_PK PRIMARY KEY (CandidateIdentifier, OtherNameTypeDescriptorId)
); 
ALTER TABLE tpdm.CandidateOtherName ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidatePersonalIdentificationDocument --
CREATE TABLE tpdm.CandidatePersonalIdentificationDocument (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidatePersonalIdentificationDocument_PK PRIMARY KEY (CandidateIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
); 
ALTER TABLE tpdm.CandidatePersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateRace --
CREATE TABLE tpdm.CandidateRace (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateRace_PK PRIMARY KEY (CandidateIdentifier, RaceDescriptorId)
); 
ALTER TABLE tpdm.CandidateRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateRelationshipToStaffAssociation --
CREATE TABLE tpdm.CandidateRelationshipToStaffAssociation (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    StaffUSI INT NOT NULL,
    StaffToCandidateRelationshipDescriptorId INT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CandidateRelationshipToStaffAssociation_PK PRIMARY KEY (CandidateIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.CandidateRelationshipToStaffAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.CandidateRelationshipToStaffAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.CandidateRelationshipToStaffAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateTelephone --
CREATE TABLE tpdm.CandidateTelephone (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateTelephone_PK PRIMARY KEY (CandidateIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
); 
ALTER TABLE tpdm.CandidateTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CandidateVisa --
CREATE TABLE tpdm.CandidateVisa (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateVisa_PK PRIMARY KEY (CandidateIdentifier, VisaDescriptorId)
); 
ALTER TABLE tpdm.CandidateVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.Certification --
CREATE TABLE tpdm.Certification (
    CertificationIdentifier VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CertificationTitle VARCHAR(64) NOT NULL,
    EducationOrganizationId INT NULL,
    CertificationLevelDescriptorId INT NULL,
    CertificationFieldDescriptorId INT NULL,
    CertificationStandardDescriptorId INT NULL,
    MinimumDegreeDescriptorId INT NULL,
    EducatorRoleDescriptorId INT NULL,
    PopulationServedDescriptorId INT NULL,
    InstructionalSettingDescriptorId INT NULL,
    EffectiveDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Certification_PK PRIMARY KEY (CertificationIdentifier, Namespace)
); 
ALTER TABLE tpdm.Certification ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.Certification ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.Certification ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.CertificationCertificationExam --
CREATE TABLE tpdm.CertificationCertificationExam (
    CertificationExamIdentifier VARCHAR(60) NOT NULL,
    CertificationExamNamespace VARCHAR(255) NOT NULL,
    CertificationIdentifier VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CertificationCertificationExam_PK PRIMARY KEY (CertificationExamIdentifier, CertificationExamNamespace, CertificationIdentifier, Namespace)
); 
ALTER TABLE tpdm.CertificationCertificationExam ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CertificationExam --
CREATE TABLE tpdm.CertificationExam (
    CertificationExamIdentifier VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CertificationExamTitle VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NULL,
    CertificationExamTypeDescriptorId INT NULL,
    EffectiveDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CertificationExam_PK PRIMARY KEY (CertificationExamIdentifier, Namespace)
); 
ALTER TABLE tpdm.CertificationExam ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.CertificationExam ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.CertificationExam ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.CertificationExamResult --
CREATE TABLE tpdm.CertificationExamResult (
    CertificationExamDate DATE NOT NULL,
    CertificationExamIdentifier VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    AttemptNumber INT NULL,
    CertificationExamScore DECIMAL(6, 3) NULL,
    CertificationExamPassIndicator BOOLEAN NULL,
    CertificationExamStatusDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CertificationExamResult_PK PRIMARY KEY (CertificationExamDate, CertificationExamIdentifier, Namespace, PersonId, SourceSystemDescriptorId)
); 
ALTER TABLE tpdm.CertificationExamResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.CertificationExamResult ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.CertificationExamResult ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.CertificationExamStatusDescriptor --
CREATE TABLE tpdm.CertificationExamStatusDescriptor (
    CertificationExamStatusDescriptorId INT NOT NULL,
    CONSTRAINT CertificationExamStatusDescriptor_PK PRIMARY KEY (CertificationExamStatusDescriptorId)
); 

-- Table tpdm.CertificationExamTypeDescriptor --
CREATE TABLE tpdm.CertificationExamTypeDescriptor (
    CertificationExamTypeDescriptorId INT NOT NULL,
    CONSTRAINT CertificationExamTypeDescriptor_PK PRIMARY KEY (CertificationExamTypeDescriptorId)
); 

-- Table tpdm.CertificationFieldDescriptor --
CREATE TABLE tpdm.CertificationFieldDescriptor (
    CertificationFieldDescriptorId INT NOT NULL,
    CONSTRAINT CertificationFieldDescriptor_PK PRIMARY KEY (CertificationFieldDescriptorId)
); 

-- Table tpdm.CertificationGradeLevel --
CREATE TABLE tpdm.CertificationGradeLevel (
    CertificationIdentifier VARCHAR(60) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CertificationGradeLevel_PK PRIMARY KEY (CertificationIdentifier, GradeLevelDescriptorId, Namespace)
); 
ALTER TABLE tpdm.CertificationGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CertificationLevelDescriptor --
CREATE TABLE tpdm.CertificationLevelDescriptor (
    CertificationLevelDescriptorId INT NOT NULL,
    CONSTRAINT CertificationLevelDescriptor_PK PRIMARY KEY (CertificationLevelDescriptorId)
); 

-- Table tpdm.CertificationRoute --
CREATE TABLE tpdm.CertificationRoute (
    CertificationIdentifier VARCHAR(60) NOT NULL,
    CertificationRouteDescriptorId INT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CertificationRoute_PK PRIMARY KEY (CertificationIdentifier, CertificationRouteDescriptorId, Namespace)
); 
ALTER TABLE tpdm.CertificationRoute ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CertificationRouteDescriptor --
CREATE TABLE tpdm.CertificationRouteDescriptor (
    CertificationRouteDescriptorId INT NOT NULL,
    CONSTRAINT CertificationRouteDescriptor_PK PRIMARY KEY (CertificationRouteDescriptorId)
); 

-- Table tpdm.CertificationStandardDescriptor --
CREATE TABLE tpdm.CertificationStandardDescriptor (
    CertificationStandardDescriptorId INT NOT NULL,
    CONSTRAINT CertificationStandardDescriptor_PK PRIMARY KEY (CertificationStandardDescriptorId)
); 

-- Table tpdm.CoteachingStyleObservedDescriptor --
CREATE TABLE tpdm.CoteachingStyleObservedDescriptor (
    CoteachingStyleObservedDescriptorId INT NOT NULL,
    CONSTRAINT CoteachingStyleObservedDescriptor_PK PRIMARY KEY (CoteachingStyleObservedDescriptorId)
); 

-- Table tpdm.CredentialEvent --
CREATE TABLE tpdm.CredentialEvent (
    CredentialEventDate DATE NOT NULL,
    CredentialEventTypeDescriptorId INT NOT NULL,
    CredentialIdentifier VARCHAR(60) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    CredentialEventReason VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CredentialEvent_PK PRIMARY KEY (CredentialEventDate, CredentialEventTypeDescriptorId, CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
); 
ALTER TABLE tpdm.CredentialEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.CredentialEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.CredentialEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.CredentialEventTypeDescriptor --
CREATE TABLE tpdm.CredentialEventTypeDescriptor (
    CredentialEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT CredentialEventTypeDescriptor_PK PRIMARY KEY (CredentialEventTypeDescriptorId)
); 

-- Table tpdm.CredentialExtension --
CREATE TABLE tpdm.CredentialExtension (
    CredentialIdentifier VARCHAR(60) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    CertificationTitle VARCHAR(64) NOT NULL,
    CertificationIdentifier VARCHAR(60) NULL,
    Namespace VARCHAR(255) NULL,
    CertificationRouteDescriptorId INT NULL,
    BoardCertificationIndicator BOOLEAN NULL,
    CredentialStatusDescriptorId INT NULL,
    CredentialStatusDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CredentialExtension_PK PRIMARY KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
); 
ALTER TABLE tpdm.CredentialExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.CredentialStatusDescriptor --
CREATE TABLE tpdm.CredentialStatusDescriptor (
    CredentialStatusDescriptorId INT NOT NULL,
    CONSTRAINT CredentialStatusDescriptor_PK PRIMARY KEY (CredentialStatusDescriptorId)
); 

-- Table tpdm.CredentialStudentAcademicRecord --
CREATE TABLE tpdm.CredentialStudentAcademicRecord (
    CredentialIdentifier VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CredentialStudentAcademicRecord_PK PRIMARY KEY (CredentialIdentifier, EducationOrganizationId, SchoolYear, StateOfIssueStateAbbreviationDescriptorId, StudentUSI, TermDescriptorId)
); 
ALTER TABLE tpdm.CredentialStudentAcademicRecord ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.DegreeDescriptor --
CREATE TABLE tpdm.DegreeDescriptor (
    DegreeDescriptorId INT NOT NULL,
    CONSTRAINT DegreeDescriptor_PK PRIMARY KEY (DegreeDescriptorId)
); 

-- Table tpdm.EducatorPreparationProgram --
CREATE TABLE tpdm.EducatorPreparationProgram (
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ProgramId VARCHAR(20) NULL,
    EducatorPreparationProgramTypeDescriptorId INT NULL,
    AccreditationStatusDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EducatorPreparationProgram_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
); 
ALTER TABLE tpdm.EducatorPreparationProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.EducatorPreparationProgram ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.EducatorPreparationProgram ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EducatorPreparationProgramGradeLevel --
CREATE TABLE tpdm.EducatorPreparationProgramGradeLevel (
    EducationOrganizationId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducatorPreparationProgramGradeLevel_PK PRIMARY KEY (EducationOrganizationId, GradeLevelDescriptorId, ProgramName, ProgramTypeDescriptorId)
); 
ALTER TABLE tpdm.EducatorPreparationProgramGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EducatorPreparationProgramTypeDescriptor --
CREATE TABLE tpdm.EducatorPreparationProgramTypeDescriptor (
    EducatorPreparationProgramTypeDescriptorId INT NOT NULL,
    CONSTRAINT EducatorPreparationProgramTypeDescriptor_PK PRIMARY KEY (EducatorPreparationProgramTypeDescriptorId)
); 

-- Table tpdm.EducatorRoleDescriptor --
CREATE TABLE tpdm.EducatorRoleDescriptor (
    EducatorRoleDescriptorId INT NOT NULL,
    CONSTRAINT EducatorRoleDescriptor_PK PRIMARY KEY (EducatorRoleDescriptorId)
); 

-- Table tpdm.EnglishLanguageExamDescriptor --
CREATE TABLE tpdm.EnglishLanguageExamDescriptor (
    EnglishLanguageExamDescriptorId INT NOT NULL,
    CONSTRAINT EnglishLanguageExamDescriptor_PK PRIMARY KEY (EnglishLanguageExamDescriptorId)
); 

-- Table tpdm.EPPDegreeTypeDescriptor --
CREATE TABLE tpdm.EPPDegreeTypeDescriptor (
    EPPDegreeTypeDescriptorId INT NOT NULL,
    CONSTRAINT EPPDegreeTypeDescriptor_PK PRIMARY KEY (EPPDegreeTypeDescriptorId)
); 

-- Table tpdm.EPPProgramPathwayDescriptor --
CREATE TABLE tpdm.EPPProgramPathwayDescriptor (
    EPPProgramPathwayDescriptorId INT NOT NULL,
    CONSTRAINT EPPProgramPathwayDescriptor_PK PRIMARY KEY (EPPProgramPathwayDescriptorId)
); 

-- Table tpdm.Evaluation --
CREATE TABLE tpdm.Evaluation (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    MinRating DECIMAL(6, 3) NULL,
    MaxRating DECIMAL(6, 3) NULL,
    EvaluationTypeDescriptorId INT NULL,
    InterRaterReliabilityScore INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Evaluation_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.Evaluation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.Evaluation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.Evaluation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationElement --
CREATE TABLE tpdm.EvaluationElement (
    EducationOrganizationId INT NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    SortOrder INT NULL,
    MinRating DECIMAL(6, 3) NULL,
    MaxRating DECIMAL(6, 3) NULL,
    EvaluationTypeDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationElement_PK PRIMARY KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationElement ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.EvaluationElement ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.EvaluationElement ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationElementRating --
CREATE TABLE tpdm.EvaluationElementRating (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationElementRatingLevelDescriptorId INT NULL,
    AreaOfRefinement VARCHAR(1024) NULL,
    AreaOfReinforcement VARCHAR(1024) NULL,
    Comments VARCHAR(1024) NULL,
    Feedback VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationElementRating_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationElementRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.EvaluationElementRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.EvaluationElementRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationElementRatingLevel --
CREATE TABLE tpdm.EvaluationElementRatingLevel (
    EducationOrganizationId INT NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    MinRating DECIMAL(6, 3) NULL,
    MaxRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationElementRatingLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationRatingLevelDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationElementRatingLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationElementRatingLevelDescriptor --
CREATE TABLE tpdm.EvaluationElementRatingLevelDescriptor (
    EvaluationElementRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationElementRatingLevelDescriptor_PK PRIMARY KEY (EvaluationElementRatingLevelDescriptorId)
); 

-- Table tpdm.EvaluationElementRatingResult --
CREATE TABLE tpdm.EvaluationElementRatingResult (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    Rating DECIMAL(6, 3) NOT NULL,
    RatingResultTitle VARCHAR(50) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationElementRatingResult_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, Rating, RatingResultTitle, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationElementRatingResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationObjective --
CREATE TABLE tpdm.EvaluationObjective (
    EducationOrganizationId INT NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    SortOrder INT NULL,
    MinRating DECIMAL(6, 3) NULL,
    MaxRating DECIMAL(6, 3) NULL,
    EvaluationTypeDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationObjective_PK PRIMARY KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationObjective ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.EvaluationObjective ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.EvaluationObjective ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationObjectiveRating --
CREATE TABLE tpdm.EvaluationObjectiveRating (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ObjectiveRatingLevelDescriptorId INT NULL,
    Comments VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationObjectiveRating_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationObjectiveRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.EvaluationObjectiveRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.EvaluationObjectiveRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationObjectiveRatingLevel --
CREATE TABLE tpdm.EvaluationObjectiveRatingLevel (
    EducationOrganizationId INT NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    MinRating DECIMAL(6, 3) NULL,
    MaxRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationObjectiveRatingLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationRatingLevelDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationObjectiveRatingLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationObjectiveRatingResult --
CREATE TABLE tpdm.EvaluationObjectiveRatingResult (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    Rating DECIMAL(6, 3) NOT NULL,
    RatingResultTitle VARCHAR(50) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationObjectiveRatingResult_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, Rating, RatingResultTitle, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationObjectiveRatingResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationPeriodDescriptor --
CREATE TABLE tpdm.EvaluationPeriodDescriptor (
    EvaluationPeriodDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationPeriodDescriptor_PK PRIMARY KEY (EvaluationPeriodDescriptorId)
); 

-- Table tpdm.EvaluationRating --
CREATE TABLE tpdm.EvaluationRating (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NULL,
    SectionIdentifier VARCHAR(255) NULL,
    LocalCourseCode VARCHAR(60) NULL,
    SessionName VARCHAR(60) NULL,
    SchoolId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationRating_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.EvaluationRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.EvaluationRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationRatingLevel --
CREATE TABLE tpdm.EvaluationRatingLevel (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    MinRating DECIMAL(6, 3) NULL,
    MaxRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationRatingLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationRatingLevelDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationRatingLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationRatingLevelDescriptor --
CREATE TABLE tpdm.EvaluationRatingLevelDescriptor (
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationRatingLevelDescriptor_PK PRIMARY KEY (EvaluationRatingLevelDescriptorId)
); 

-- Table tpdm.EvaluationRatingResult --
CREATE TABLE tpdm.EvaluationRatingResult (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    Rating DECIMAL(6, 3) NOT NULL,
    RatingResultTitle VARCHAR(50) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationRatingResult_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, Rating, RatingResultTitle, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationRatingResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationRatingReviewer --
CREATE TABLE tpdm.EvaluationRatingReviewer (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ReviewerPersonId VARCHAR(32) NULL,
    ReviewerSourceSystemDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationRatingReviewer_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationRatingReviewer ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationRatingReviewerReceivedTraining --
CREATE TABLE tpdm.EvaluationRatingReviewerReceivedTraining (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ReceivedTrainingDate DATE NULL,
    InterRaterReliabilityScore INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationRatingReviewerReceivedTraining_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.EvaluationRatingReviewerReceivedTraining ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.EvaluationTypeDescriptor --
CREATE TABLE tpdm.EvaluationTypeDescriptor (
    EvaluationTypeDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationTypeDescriptor_PK PRIMARY KEY (EvaluationTypeDescriptorId)
); 

-- Table tpdm.FederalLocaleCodeDescriptor --
CREATE TABLE tpdm.FederalLocaleCodeDescriptor (
    FederalLocaleCodeDescriptorId INT NOT NULL,
    CONSTRAINT FederalLocaleCodeDescriptor_PK PRIMARY KEY (FederalLocaleCodeDescriptorId)
); 

-- Table tpdm.FieldworkExperience --
CREATE TABLE tpdm.FieldworkExperience (
    BeginDate DATE NOT NULL,
    FieldworkIdentifier VARCHAR(64) NOT NULL,
    StudentUSI INT NOT NULL,
    SchoolId INT NULL,
    EducationOrganizationId INT NULL,
    ProgramName VARCHAR(255) NULL,
    ProgramTypeDescriptorId INT NULL,
    FieldworkTypeDescriptorId INT NOT NULL,
    HoursCompleted DECIMAL(5, 2) NULL,
    EndDate DATE NULL,
    ProgramGatewayDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT FieldworkExperience_PK PRIMARY KEY (BeginDate, FieldworkIdentifier, StudentUSI)
); 
ALTER TABLE tpdm.FieldworkExperience ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.FieldworkExperience ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.FieldworkExperience ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.FieldworkExperienceCoteaching --
CREATE TABLE tpdm.FieldworkExperienceCoteaching (
    BeginDate DATE NOT NULL,
    FieldworkIdentifier VARCHAR(64) NOT NULL,
    StudentUSI INT NOT NULL,
    CoteachingBeginDate DATE NOT NULL,
    CoteachingEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT FieldworkExperienceCoteaching_PK PRIMARY KEY (BeginDate, FieldworkIdentifier, StudentUSI)
); 
ALTER TABLE tpdm.FieldworkExperienceCoteaching ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.FieldworkExperienceSectionAssociation --
CREATE TABLE tpdm.FieldworkExperienceSectionAssociation (
    BeginDate DATE NOT NULL,
    FieldworkIdentifier VARCHAR(64) NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT FieldworkExperienceSectionAssociation_PK PRIMARY KEY (BeginDate, FieldworkIdentifier, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
); 
ALTER TABLE tpdm.FieldworkExperienceSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.FieldworkExperienceSectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.FieldworkExperienceSectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.FieldworkTypeDescriptor --
CREATE TABLE tpdm.FieldworkTypeDescriptor (
    FieldworkTypeDescriptorId INT NOT NULL,
    CONSTRAINT FieldworkTypeDescriptor_PK PRIMARY KEY (FieldworkTypeDescriptorId)
); 

-- Table tpdm.FundingSourceDescriptor --
CREATE TABLE tpdm.FundingSourceDescriptor (
    FundingSourceDescriptorId INT NOT NULL,
    CONSTRAINT FundingSourceDescriptor_PK PRIMARY KEY (FundingSourceDescriptorId)
); 

-- Table tpdm.GenderDescriptor --
CREATE TABLE tpdm.GenderDescriptor (
    GenderDescriptorId INT NOT NULL,
    CONSTRAINT GenderDescriptor_PK PRIMARY KEY (GenderDescriptorId)
); 

-- Table tpdm.Goal --
CREATE TABLE tpdm.Goal (
    AssignmentDate DATE NOT NULL,
    GoalTitle VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NULL,
    TermDescriptorId INT NULL,
    PerformanceEvaluationTypeDescriptorId INT NULL,
    SchoolYear SMALLINT NULL,
    EvaluationPeriodDescriptorId INT NULL,
    EducationOrganizationId INT NULL,
    EvaluationTitle VARCHAR(50) NULL,
    EvaluationObjectiveTitle VARCHAR(50) NULL,
    EvaluationElementTitle VARCHAR(255) NULL,
    GoalTypeDescriptorId INT NULL,
    GoalDescription VARCHAR(1024) NULL,
    DueDate DATE NULL,
    CompletedIndicator BOOLEAN NULL,
    CompletedDate DATE NULL,
    Comments VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Goal_PK PRIMARY KEY (AssignmentDate, GoalTitle, PersonId, SourceSystemDescriptorId)
); 
ALTER TABLE tpdm.Goal ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.Goal ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.Goal ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.GoalTypeDescriptor --
CREATE TABLE tpdm.GoalTypeDescriptor (
    GoalTypeDescriptorId INT NOT NULL,
    CONSTRAINT GoalTypeDescriptor_PK PRIMARY KEY (GoalTypeDescriptorId)
); 

-- Table tpdm.GraduationPlanRequiredCertification --
CREATE TABLE tpdm.GraduationPlanRequiredCertification (
    CertificationTitle VARCHAR(64) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    CertificationIdentifier VARCHAR(60) NULL,
    Namespace VARCHAR(255) NULL,
    CertificationRouteDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanRequiredCertification_PK PRIMARY KEY (CertificationTitle, EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
); 
ALTER TABLE tpdm.GraduationPlanRequiredCertification ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.HireStatusDescriptor --
CREATE TABLE tpdm.HireStatusDescriptor (
    HireStatusDescriptorId INT NOT NULL,
    CONSTRAINT HireStatusDescriptor_PK PRIMARY KEY (HireStatusDescriptorId)
); 

-- Table tpdm.HiringSourceDescriptor --
CREATE TABLE tpdm.HiringSourceDescriptor (
    HiringSourceDescriptorId INT NOT NULL,
    CONSTRAINT HiringSourceDescriptor_PK PRIMARY KEY (HiringSourceDescriptorId)
); 

-- Table tpdm.InstructionalSettingDescriptor --
CREATE TABLE tpdm.InstructionalSettingDescriptor (
    InstructionalSettingDescriptorId INT NOT NULL,
    CONSTRAINT InstructionalSettingDescriptor_PK PRIMARY KEY (InstructionalSettingDescriptorId)
); 

-- Table tpdm.LengthOfContractDescriptor --
CREATE TABLE tpdm.LengthOfContractDescriptor (
    LengthOfContractDescriptorId INT NOT NULL,
    CONSTRAINT LengthOfContractDescriptor_PK PRIMARY KEY (LengthOfContractDescriptorId)
); 

-- Table tpdm.LocalEducationAgencyExtension --
CREATE TABLE tpdm.LocalEducationAgencyExtension (
    LocalEducationAgencyId INT NOT NULL,
    FederalLocaleCodeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LocalEducationAgencyExtension_PK PRIMARY KEY (LocalEducationAgencyId)
); 
ALTER TABLE tpdm.LocalEducationAgencyExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ObjectiveRatingLevelDescriptor --
CREATE TABLE tpdm.ObjectiveRatingLevelDescriptor (
    ObjectiveRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT ObjectiveRatingLevelDescriptor_PK PRIMARY KEY (ObjectiveRatingLevelDescriptorId)
); 

-- Table tpdm.OpenStaffPositionEvent --
CREATE TABLE tpdm.OpenStaffPositionEvent (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    OpenStaffPositionEventTypeDescriptorId INT NOT NULL,
    RequisitionNumber VARCHAR(20) NOT NULL,
    OpenStaffPositionEventStatusDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT OpenStaffPositionEvent_PK PRIMARY KEY (EducationOrganizationId, EventDate, OpenStaffPositionEventTypeDescriptorId, RequisitionNumber)
); 
ALTER TABLE tpdm.OpenStaffPositionEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.OpenStaffPositionEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.OpenStaffPositionEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.OpenStaffPositionEventStatusDescriptor --
CREATE TABLE tpdm.OpenStaffPositionEventStatusDescriptor (
    OpenStaffPositionEventStatusDescriptorId INT NOT NULL,
    CONSTRAINT OpenStaffPositionEventStatusDescriptor_PK PRIMARY KEY (OpenStaffPositionEventStatusDescriptorId)
); 

-- Table tpdm.OpenStaffPositionEventTypeDescriptor --
CREATE TABLE tpdm.OpenStaffPositionEventTypeDescriptor (
    OpenStaffPositionEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT OpenStaffPositionEventTypeDescriptor_PK PRIMARY KEY (OpenStaffPositionEventTypeDescriptorId)
); 

-- Table tpdm.OpenStaffPositionExtension --
CREATE TABLE tpdm.OpenStaffPositionExtension (
    EducationOrganizationId INT NOT NULL,
    RequisitionNumber VARCHAR(20) NOT NULL,
    SchoolYear SMALLINT NULL,
    FullTimeEquivalency DECIMAL(3, 2) NULL,
    OpenStaffPositionReasonDescriptorId INT NULL,
    IsActive BOOLEAN NULL,
    MaxSalary DECIMAL(9, 2) NULL,
    MinSalary DECIMAL(9, 2) NULL,
    FundingSourceDescriptorId INT NULL,
    HighNeedAcademicSubject BOOLEAN NULL,
    PositionControlNumber VARCHAR(20) NULL,
    TermDescriptorId INT NULL,
    TotalBudgeted DECIMAL(9, 2) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT OpenStaffPositionExtension_PK PRIMARY KEY (EducationOrganizationId, RequisitionNumber)
); 
ALTER TABLE tpdm.OpenStaffPositionExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.OpenStaffPositionReasonDescriptor --
CREATE TABLE tpdm.OpenStaffPositionReasonDescriptor (
    OpenStaffPositionReasonDescriptorId INT NOT NULL,
    CONSTRAINT OpenStaffPositionReasonDescriptor_PK PRIMARY KEY (OpenStaffPositionReasonDescriptorId)
); 

-- Table tpdm.PerformanceEvaluation --
CREATE TABLE tpdm.PerformanceEvaluation (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT PerformanceEvaluation_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.PerformanceEvaluation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.PerformanceEvaluation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.PerformanceEvaluation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.PerformanceEvaluationGradeLevel --
CREATE TABLE tpdm.PerformanceEvaluationGradeLevel (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationGradeLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, GradeLevelDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.PerformanceEvaluationGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.PerformanceEvaluationProgramGateway --
CREATE TABLE tpdm.PerformanceEvaluationProgramGateway (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    ProgramGatewayDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationProgramGateway_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, ProgramGatewayDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.PerformanceEvaluationProgramGateway ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.PerformanceEvaluationRating --
CREATE TABLE tpdm.PerformanceEvaluationRating (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ActualDate DATE NOT NULL,
    Announced BOOLEAN NULL,
    Comments VARCHAR(1024) NULL,
    CoteachingStyleObservedDescriptorId INT NULL,
    ActualDuration INT NULL,
    PerformanceEvaluationRatingLevelDescriptorId INT NULL,
    ScheduleDate DATE NULL,
    ActualTime TIME NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT PerformanceEvaluationRating_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.PerformanceEvaluationRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.PerformanceEvaluationRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.PerformanceEvaluationRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.PerformanceEvaluationRatingLevel --
CREATE TABLE tpdm.PerformanceEvaluationRatingLevel (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    MinRating DECIMAL(6, 3) NULL,
    MaxRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationRatingLevelDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.PerformanceEvaluationRatingLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.PerformanceEvaluationRatingLevelDescriptor --
CREATE TABLE tpdm.PerformanceEvaluationRatingLevelDescriptor (
    PerformanceEvaluationRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingLevelDescriptor_PK PRIMARY KEY (PerformanceEvaluationRatingLevelDescriptorId)
); 

-- Table tpdm.PerformanceEvaluationRatingResult --
CREATE TABLE tpdm.PerformanceEvaluationRatingResult (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    Rating DECIMAL(6, 3) NOT NULL,
    RatingResultTitle VARCHAR(50) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingResult_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, Rating, RatingResultTitle, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.PerformanceEvaluationRatingResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.PerformanceEvaluationRatingReviewer --
CREATE TABLE tpdm.PerformanceEvaluationRatingReviewer (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ReviewerPersonId VARCHAR(32) NULL,
    ReviewerSourceSystemDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingReviewer_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.PerformanceEvaluationRatingReviewer ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.PerformanceEvaluationRatingReviewerReceivedTraining --
CREATE TABLE tpdm.PerformanceEvaluationRatingReviewerReceivedTraining (
    EducationOrganizationId INT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ReceivedTrainingDate DATE NULL,
    InterRaterReliabilityScore INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingReviewerReceivedTraining_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.PerformanceEvaluationRatingReviewerReceivedTraining ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.PerformanceEvaluationTypeDescriptor --
CREATE TABLE tpdm.PerformanceEvaluationTypeDescriptor (
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    CONSTRAINT PerformanceEvaluationTypeDescriptor_PK PRIMARY KEY (PerformanceEvaluationTypeDescriptorId)
); 

-- Table tpdm.PostSecondaryInstitutionExtension --
CREATE TABLE tpdm.PostSecondaryInstitutionExtension (
    PostSecondaryInstitutionId INT NOT NULL,
    FederalLocaleCodeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PostSecondaryInstitutionExtension_PK PRIMARY KEY (PostSecondaryInstitutionId)
); 
ALTER TABLE tpdm.PostSecondaryInstitutionExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.PreviousCareerDescriptor --
CREATE TABLE tpdm.PreviousCareerDescriptor (
    PreviousCareerDescriptorId INT NOT NULL,
    CONSTRAINT PreviousCareerDescriptor_PK PRIMARY KEY (PreviousCareerDescriptorId)
); 

-- Table tpdm.ProfessionalDevelopmentEvent --
CREATE TABLE tpdm.ProfessionalDevelopmentEvent (
    Namespace VARCHAR(255) NOT NULL,
    ProfessionalDevelopmentTitle VARCHAR(60) NOT NULL,
    ProfessionalDevelopmentOfferedByDescriptorId INT NOT NULL,
    TotalHours INT NULL,
    Required BOOLEAN NULL,
    MultipleSession BOOLEAN NULL,
    ProfessionalDevelopmentReason VARCHAR(60) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ProfessionalDevelopmentEvent_PK PRIMARY KEY (Namespace, ProfessionalDevelopmentTitle)
); 
ALTER TABLE tpdm.ProfessionalDevelopmentEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.ProfessionalDevelopmentEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.ProfessionalDevelopmentEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ProfessionalDevelopmentEventAttendance --
CREATE TABLE tpdm.ProfessionalDevelopmentEventAttendance (
    AttendanceDate DATE NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    ProfessionalDevelopmentTitle VARCHAR(60) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    AttendanceEventCategoryDescriptorId INT NOT NULL,
    AttendanceEventReason VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ProfessionalDevelopmentEventAttendance_PK PRIMARY KEY (AttendanceDate, Namespace, PersonId, ProfessionalDevelopmentTitle, SourceSystemDescriptorId)
); 
ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ProfessionalDevelopmentOfferedByDescriptor --
CREATE TABLE tpdm.ProfessionalDevelopmentOfferedByDescriptor (
    ProfessionalDevelopmentOfferedByDescriptorId INT NOT NULL,
    CONSTRAINT ProfessionalDevelopmentOfferedByDescriptor_PK PRIMARY KEY (ProfessionalDevelopmentOfferedByDescriptorId)
); 

-- Table tpdm.ProgramGatewayDescriptor --
CREATE TABLE tpdm.ProgramGatewayDescriptor (
    ProgramGatewayDescriptorId INT NOT NULL,
    CONSTRAINT ProgramGatewayDescriptor_PK PRIMARY KEY (ProgramGatewayDescriptorId)
); 

-- Table tpdm.QuantitativeMeasure --
CREATE TABLE tpdm.QuantitativeMeasure (
    EducationOrganizationId INT NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    QuantitativeMeasureIdentifier VARCHAR(64) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    QuantitativeMeasureTypeDescriptorId INT NULL,
    QuantitativeMeasureDatatypeDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT QuantitativeMeasure_PK PRIMARY KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.QuantitativeMeasure ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.QuantitativeMeasure ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.QuantitativeMeasure ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.QuantitativeMeasureDatatypeDescriptor --
CREATE TABLE tpdm.QuantitativeMeasureDatatypeDescriptor (
    QuantitativeMeasureDatatypeDescriptorId INT NOT NULL,
    CONSTRAINT QuantitativeMeasureDatatypeDescriptor_PK PRIMARY KEY (QuantitativeMeasureDatatypeDescriptorId)
); 

-- Table tpdm.QuantitativeMeasureScore --
CREATE TABLE tpdm.QuantitativeMeasureScore (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    QuantitativeMeasureIdentifier VARCHAR(64) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ScoreValue DECIMAL(6, 3) NOT NULL,
    StandardError DECIMAL(6, 3) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT QuantitativeMeasureScore_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, QuantitativeMeasureIdentifier, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
); 
ALTER TABLE tpdm.QuantitativeMeasureScore ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.QuantitativeMeasureScore ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.QuantitativeMeasureScore ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.QuantitativeMeasureTypeDescriptor --
CREATE TABLE tpdm.QuantitativeMeasureTypeDescriptor (
    QuantitativeMeasureTypeDescriptorId INT NOT NULL,
    CONSTRAINT QuantitativeMeasureTypeDescriptor_PK PRIMARY KEY (QuantitativeMeasureTypeDescriptorId)
); 

-- Table tpdm.RecruitmentEvent --
CREATE TABLE tpdm.RecruitmentEvent (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    EventDescription VARCHAR(255) NULL,
    RecruitmentEventTypeDescriptorId INT NOT NULL,
    EventLocation VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT RecruitmentEvent_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle)
); 
ALTER TABLE tpdm.RecruitmentEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.RecruitmentEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.RecruitmentEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendance --
CREATE TABLE tpdm.RecruitmentEventAttendance (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    Applied BOOLEAN NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    GenderDescriptorId INT NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    Met BOOLEAN NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    FirstName VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    MaidenName VARCHAR(75) NULL,
    Notes VARCHAR(255) NULL,
    PreScreeningRating INT NULL,
    RecruitmentEventAttendeeTypeDescriptorId INT NULL,
    Referral BOOLEAN NULL,
    ReferredBy VARCHAR(50) NULL,
    SexDescriptorId INT NULL,
    SocialMediaNetworkName VARCHAR(50) NULL,
    SocialMediaUserName VARCHAR(50) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT RecruitmentEventAttendance_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.RecruitmentEventAttendance ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.RecruitmentEventAttendance ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.RecruitmentEventAttendance ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendanceCurrentPosition --
CREATE TABLE tpdm.RecruitmentEventAttendanceCurrentPosition (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    Location VARCHAR(75) NOT NULL,
    PositionTitle VARCHAR(100) NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceCurrentPosition_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.RecruitmentEventAttendanceCurrentPosition ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel --
CREATE TABLE tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceCurrentPositionGradeLevel_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, GradeLevelDescriptorId, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendanceDisability --
CREATE TABLE tpdm.RecruitmentEventAttendanceDisability (
    DisabilityDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceDisability_PK PRIMARY KEY (DisabilityDescriptorId, EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.RecruitmentEventAttendanceDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendanceDisabilityDesignation --
CREATE TABLE tpdm.RecruitmentEventAttendanceDisabilityDesignation (
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceDisabilityDesignation_PK PRIMARY KEY (DisabilityDescriptorId, DisabilityDesignationDescriptorId, EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.RecruitmentEventAttendanceDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendancePersonalIdentificationDocument --
CREATE TABLE tpdm.RecruitmentEventAttendancePersonalIdentificationDocument (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendancePersonalIdentificationDocument_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.RecruitmentEventAttendancePersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendanceRace --
CREATE TABLE tpdm.RecruitmentEventAttendanceRace (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RaceDescriptorId INT NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceRace_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RaceDescriptorId, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.RecruitmentEventAttendanceRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7 --
CREATE TABLE tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7 (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    Eligible BOOLEAN NOT NULL,
    CapacityToServe BOOLEAN NULL,
    YearsOfServiceCurrentPlacement DECIMAL(5, 2) NULL,
    YearsOfServiceTotal DECIMAL(5, 2) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceRecruitmentEventAttendee_82dbb7_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
); 
ALTER TABLE tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7 ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendanceTelephone --
CREATE TABLE tpdm.RecruitmentEventAttendanceTelephone (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceTelephone_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
); 
ALTER TABLE tpdm.RecruitmentEventAttendanceTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendanceTouchpoint --
CREATE TABLE tpdm.RecruitmentEventAttendanceTouchpoint (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    TouchpointContent VARCHAR(255) NOT NULL,
    TouchpointDate DATE NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceTouchpoint_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, TouchpointContent, TouchpointDate)
); 
ALTER TABLE tpdm.RecruitmentEventAttendanceTouchpoint ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.RecruitmentEventAttendeeTypeDescriptor --
CREATE TABLE tpdm.RecruitmentEventAttendeeTypeDescriptor (
    RecruitmentEventAttendeeTypeDescriptorId INT NOT NULL,
    CONSTRAINT RecruitmentEventAttendeeTypeDescriptor_PK PRIMARY KEY (RecruitmentEventAttendeeTypeDescriptorId)
); 

-- Table tpdm.RecruitmentEventTypeDescriptor --
CREATE TABLE tpdm.RecruitmentEventTypeDescriptor (
    RecruitmentEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT RecruitmentEventTypeDescriptor_PK PRIMARY KEY (RecruitmentEventTypeDescriptorId)
); 

-- Table tpdm.RubricDimension --
CREATE TABLE tpdm.RubricDimension (
    EducationOrganizationId INT NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    RubricRating INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    RubricRatingLevelDescriptorId INT NULL,
    CriterionDescription VARCHAR(1024) NOT NULL,
    DimensionOrder INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT RubricDimension_PK PRIMARY KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, RubricRating, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.RubricDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.RubricDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.RubricDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.RubricRatingLevelDescriptor --
CREATE TABLE tpdm.RubricRatingLevelDescriptor (
    RubricRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT RubricRatingLevelDescriptor_PK PRIMARY KEY (RubricRatingLevelDescriptorId)
); 

-- Table tpdm.SalaryTypeDescriptor --
CREATE TABLE tpdm.SalaryTypeDescriptor (
    SalaryTypeDescriptorId INT NOT NULL,
    CONSTRAINT SalaryTypeDescriptor_PK PRIMARY KEY (SalaryTypeDescriptorId)
); 

-- Table tpdm.SchoolExtension --
CREATE TABLE tpdm.SchoolExtension (
    SchoolId INT NOT NULL,
    FederalLocaleCodeDescriptorId INT NULL,
    PostSecondaryInstitutionId INT NULL,
    ImprovingSchool BOOLEAN NULL,
    AccreditationStatusDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SchoolExtension_PK PRIMARY KEY (SchoolId)
); 
ALTER TABLE tpdm.SchoolExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffEducationOrganizationAssignmentAssociationExtension --
CREATE TABLE tpdm.StaffEducationOrganizationAssignmentAssociationExtension (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    StaffClassificationDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    YearsOfExperienceAtCurrentEducationOrganization DECIMAL(5, 2) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducationOrganizationAssignmentAssociationExtension_PK PRIMARY KEY (BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI)
); 
ALTER TABLE tpdm.StaffEducationOrganizationAssignmentAssociationExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck --
CREATE TABLE tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck (
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    StaffUSI INT NOT NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducationOrganizationEmploymentAssociationBac_b66085_PK PRIMARY KEY (BackgroundCheckTypeDescriptorId, EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
); 
ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffEducationOrganizationEmploymentAssociationExtension --
CREATE TABLE tpdm.StaffEducationOrganizationEmploymentAssociationExtension (
    EducationOrganizationId INT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    StaffUSI INT NOT NULL,
    ProbationCompleteDate DATE NULL,
    LengthOfContractDescriptorId INT NULL,
    TenureTrack BOOLEAN NULL,
    Tenured BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducationOrganizationEmploymentAssociationExtension_PK PRIMARY KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
); 
ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffEducationOrganizationEmploymentAssociationSalary --
CREATE TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSalary (
    EducationOrganizationId INT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    StaffUSI INT NOT NULL,
    SalaryMinRange INT NULL,
    SalaryMaxRange INT NULL,
    SalaryTypeDescriptorId INT NULL,
    SalaryAmount MONEY NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducationOrganizationEmploymentAssociationSalary_PK PRIMARY KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
); 
ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSalary ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffEducationOrganizationEmploymentAssociationSeniority --
CREATE TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSeniority (
    CredentialFieldDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    StaffUSI INT NOT NULL,
    YearsExperience DECIMAL(5, 2) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducationOrganizationEmploymentAssociationSeniority_PK PRIMARY KEY (CredentialFieldDescriptorId, EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, NameOfInstitution, StaffUSI)
); 
ALTER TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSeniority ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffEducatorPreparationProgram --
CREATE TABLE tpdm.StaffEducatorPreparationProgram (
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducatorPreparationProgram_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI)
); 
ALTER TABLE tpdm.StaffEducatorPreparationProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffEducatorPreparationProgramAssociation --
CREATE TABLE tpdm.StaffEducatorPreparationProgramAssociation (
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    Completer BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffEducatorPreparationProgramAssociation_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI)
); 
ALTER TABLE tpdm.StaffEducatorPreparationProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.StaffEducatorPreparationProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.StaffEducatorPreparationProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffEducatorResearch --
CREATE TABLE tpdm.StaffEducatorResearch (
    StaffUSI INT NOT NULL,
    ResearchExperienceDate DATE NOT NULL,
    ResearchExperienceTitle VARCHAR(60) NULL,
    ResearchExperienceDescription VARCHAR(1024) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducatorResearch_PK PRIMARY KEY (StaffUSI)
); 
ALTER TABLE tpdm.StaffEducatorResearch ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffExtension --
CREATE TABLE tpdm.StaffExtension (
    StaffUSI INT NOT NULL,
    GenderDescriptorId INT NULL,
    RequisitionNumber VARCHAR(20) NULL,
    EducationOrganizationId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffExtension_PK PRIMARY KEY (StaffUSI)
); 
ALTER TABLE tpdm.StaffExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffHighlyQualifiedAcademicSubject --
CREATE TABLE tpdm.StaffHighlyQualifiedAcademicSubject (
    AcademicSubjectDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffHighlyQualifiedAcademicSubject_PK PRIMARY KEY (AcademicSubjectDescriptorId, StaffUSI)
); 
ALTER TABLE tpdm.StaffHighlyQualifiedAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffToCandidateRelationshipDescriptor --
CREATE TABLE tpdm.StaffToCandidateRelationshipDescriptor (
    StaffToCandidateRelationshipDescriptorId INT NOT NULL,
    CONSTRAINT StaffToCandidateRelationshipDescriptor_PK PRIMARY KEY (StaffToCandidateRelationshipDescriptorId)
); 

-- Table tpdm.StateEducationAgencyExtension --
CREATE TABLE tpdm.StateEducationAgencyExtension (
    StateEducationAgencyId INT NOT NULL,
    FederalLocaleCodeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StateEducationAgencyExtension_PK PRIMARY KEY (StateEducationAgencyId)
); 
ALTER TABLE tpdm.StateEducationAgencyExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StudentGradebookEntryExtension --
CREATE TABLE tpdm.StudentGradebookEntryExtension (
    BeginDate DATE NOT NULL,
    DateAssigned DATE NOT NULL,
    GradebookEntryTitle VARCHAR(60) NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    DateCompleted DATE NULL,
    AssignmentPassed BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentGradebookEntryExtension_PK PRIMARY KEY (BeginDate, DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
); 
ALTER TABLE tpdm.StudentGradebookEntryExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.SurveyResponseExtension --
CREATE TABLE tpdm.SurveyResponseExtension (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(60) NOT NULL,
    SurveyResponseIdentifier VARCHAR(60) NOT NULL,
    PersonId VARCHAR(32) NULL,
    SourceSystemDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SurveyResponseExtension_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
); 
ALTER TABLE tpdm.SurveyResponseExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.SurveyResponsePersonTargetAssociation --
CREATE TABLE tpdm.SurveyResponsePersonTargetAssociation (
    Namespace VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    SurveyIdentifier VARCHAR(60) NOT NULL,
    SurveyResponseIdentifier VARCHAR(60) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyResponsePersonTargetAssociation_PK PRIMARY KEY (Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier)
); 
ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.SurveyResponsePersonTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.SurveySectionAggregateResponse --
CREATE TABLE tpdm.SurveySectionAggregateResponse (
    EducationOrganizationId INT NOT NULL,
    EvaluationDate DATE NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    SurveyIdentifier VARCHAR(60) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    TermDescriptorId INT NOT NULL,
    ScoreValue DECIMAL(6, 3) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionAggregateResponse_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, Namespace, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, SurveyIdentifier, SurveySectionTitle, TermDescriptorId)
); 
ALTER TABLE tpdm.SurveySectionAggregateResponse ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.SurveySectionAggregateResponse ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.SurveySectionAggregateResponse ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.SurveySectionExtension --
CREATE TABLE tpdm.SurveySectionExtension (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(60) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NULL,
    TermDescriptorId INT NULL,
    PerformanceEvaluationTypeDescriptorId INT NULL,
    SchoolYear SMALLINT NULL,
    EvaluationPeriodDescriptorId INT NULL,
    EducationOrganizationId INT NULL,
    EvaluationTitle VARCHAR(50) NULL,
    EvaluationObjectiveTitle VARCHAR(50) NULL,
    EvaluationElementTitle VARCHAR(255) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SurveySectionExtension_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
); 
ALTER TABLE tpdm.SurveySectionExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.SurveySectionResponsePersonTargetAssociation --
CREATE TABLE tpdm.SurveySectionResponsePersonTargetAssociation (
    Namespace VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    SurveyIdentifier VARCHAR(60) NOT NULL,
    SurveyResponseIdentifier VARCHAR(60) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionResponsePersonTargetAssociation_PK PRIMARY KEY (Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
); 
ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.SurveySectionResponsePersonTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.WithdrawReasonDescriptor --
CREATE TABLE tpdm.WithdrawReasonDescriptor (
    WithdrawReasonDescriptorId INT NOT NULL,
    CONSTRAINT WithdrawReasonDescriptor_PK PRIMARY KEY (WithdrawReasonDescriptorId)
); 

