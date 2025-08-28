-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table edfi.AbsenceEventCategoryDescriptor --
CREATE TABLE edfi.AbsenceEventCategoryDescriptor (
    AbsenceEventCategoryDescriptorId INT NOT NULL,
    CONSTRAINT AbsenceEventCategoryDescriptor_PK PRIMARY KEY (AbsenceEventCategoryDescriptorId)
);

-- Table edfi.AcademicHonorCategoryDescriptor --
CREATE TABLE edfi.AcademicHonorCategoryDescriptor (
    AcademicHonorCategoryDescriptorId INT NOT NULL,
    CONSTRAINT AcademicHonorCategoryDescriptor_PK PRIMARY KEY (AcademicHonorCategoryDescriptorId)
);

-- Table edfi.AcademicSubjectDescriptor --
CREATE TABLE edfi.AcademicSubjectDescriptor (
    AcademicSubjectDescriptorId INT NOT NULL,
    CONSTRAINT AcademicSubjectDescriptor_PK PRIMARY KEY (AcademicSubjectDescriptorId)
);

-- Table edfi.AcademicWeek --
CREATE TABLE edfi.AcademicWeek (
    SchoolId BIGINT NOT NULL,
    WeekIdentifier VARCHAR(80) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalInstructionalDays INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AcademicWeek_PK PRIMARY KEY (SchoolId, WeekIdentifier)
);
ALTER TABLE edfi.AcademicWeek ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.AcademicWeek ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.AcademicWeek ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AccommodationDescriptor --
CREATE TABLE edfi.AccommodationDescriptor (
    AccommodationDescriptorId INT NOT NULL,
    CONSTRAINT AccommodationDescriptor_PK PRIMARY KEY (AccommodationDescriptorId)
);

-- Table edfi.AccountabilityRating --
CREATE TABLE edfi.AccountabilityRating (
    EducationOrganizationId BIGINT NOT NULL,
    RatingTitle VARCHAR(60) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    Rating VARCHAR(35) NOT NULL,
    RatingDate DATE NULL,
    RatingOrganization VARCHAR(35) NULL,
    RatingProgram VARCHAR(30) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AccountabilityRating_PK PRIMARY KEY (EducationOrganizationId, RatingTitle, SchoolYear)
);
ALTER TABLE edfi.AccountabilityRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.AccountabilityRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.AccountabilityRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AccountTypeDescriptor --
CREATE TABLE edfi.AccountTypeDescriptor (
    AccountTypeDescriptorId INT NOT NULL,
    CONSTRAINT AccountTypeDescriptor_PK PRIMARY KEY (AccountTypeDescriptorId)
);

-- Table edfi.AccreditationStatusDescriptor --
CREATE TABLE edfi.AccreditationStatusDescriptor (
    AccreditationStatusDescriptorId INT NOT NULL,
    CONSTRAINT AccreditationStatusDescriptor_PK PRIMARY KEY (AccreditationStatusDescriptorId)
);

-- Table edfi.AchievementCategoryDescriptor --
CREATE TABLE edfi.AchievementCategoryDescriptor (
    AchievementCategoryDescriptorId INT NOT NULL,
    CONSTRAINT AchievementCategoryDescriptor_PK PRIMARY KEY (AchievementCategoryDescriptorId)
);

-- Table edfi.AdditionalCreditTypeDescriptor --
CREATE TABLE edfi.AdditionalCreditTypeDescriptor (
    AdditionalCreditTypeDescriptorId INT NOT NULL,
    CONSTRAINT AdditionalCreditTypeDescriptor_PK PRIMARY KEY (AdditionalCreditTypeDescriptorId)
);

-- Table edfi.AddressTypeDescriptor --
CREATE TABLE edfi.AddressTypeDescriptor (
    AddressTypeDescriptorId INT NOT NULL,
    CONSTRAINT AddressTypeDescriptor_PK PRIMARY KEY (AddressTypeDescriptorId)
);

-- Table edfi.AdministrationEnvironmentDescriptor --
CREATE TABLE edfi.AdministrationEnvironmentDescriptor (
    AdministrationEnvironmentDescriptorId INT NOT NULL,
    CONSTRAINT AdministrationEnvironmentDescriptor_PK PRIMARY KEY (AdministrationEnvironmentDescriptorId)
);

-- Table edfi.AdministrativeFundingControlDescriptor --
CREATE TABLE edfi.AdministrativeFundingControlDescriptor (
    AdministrativeFundingControlDescriptorId INT NOT NULL,
    CONSTRAINT AdministrativeFundingControlDescriptor_PK PRIMARY KEY (AdministrativeFundingControlDescriptorId)
);

-- Table edfi.AidTypeDescriptor --
CREATE TABLE edfi.AidTypeDescriptor (
    AidTypeDescriptorId INT NOT NULL,
    CONSTRAINT AidTypeDescriptor_PK PRIMARY KEY (AidTypeDescriptorId)
);

-- Table edfi.AncestryEthnicOriginDescriptor --
CREATE TABLE edfi.AncestryEthnicOriginDescriptor (
    AncestryEthnicOriginDescriptorId INT NOT NULL,
    CONSTRAINT AncestryEthnicOriginDescriptor_PK PRIMARY KEY (AncestryEthnicOriginDescriptorId)
);

-- Table edfi.ApplicantProfile --
CREATE TABLE edfi.ApplicantProfile (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    BirthDate DATE NULL,
    CitizenshipStatusDescriptorId INT NULL,
    EconomicDisadvantaged BOOLEAN NULL,
    FirstGenerationStudent BOOLEAN NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenderIdentity VARCHAR(60) NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    HighestCompletedLevelOfEducationDescriptorId INT NULL,
    HighlyQualifiedTeacher BOOLEAN NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    LastSurname VARCHAR(75) NOT NULL,
    MaidenName VARCHAR(75) NULL,
    MiddleName VARCHAR(75) NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    PreferredFirstName VARCHAR(75) NULL,
    PreferredLastSurname VARCHAR(75) NULL,
    SexDescriptorId INT NULL,
    YearsOfPriorProfessionalExperience DECIMAL(5, 2) NULL,
    YearsOfPriorTeachingExperience DECIMAL(5, 2) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ApplicantProfile_PK PRIMARY KEY (ApplicantProfileIdentifier)
);
ALTER TABLE edfi.ApplicantProfile ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ApplicantProfile ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ApplicantProfile ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileAddress --
CREATE TABLE edfi.ApplicantProfileAddress (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    Latitude VARCHAR(20) NULL,
    LocaleDescriptorId INT NULL,
    Longitude VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileAddress_PK PRIMARY KEY (ApplicantProfileIdentifier, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
);
ALTER TABLE edfi.ApplicantProfileAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileAddressPeriod --
CREATE TABLE edfi.ApplicantProfileAddressPeriod (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileAddressPeriod_PK PRIMARY KEY (ApplicantProfileIdentifier, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, BeginDate)
);
ALTER TABLE edfi.ApplicantProfileAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileApplicantCharacteristic --
CREATE TABLE edfi.ApplicantProfileApplicantCharacteristic (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    StudentCharacteristicDescriptorId INT NOT NULL,
    BeginDate DATE NULL,
    DesignatedBy VARCHAR(60) NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileApplicantCharacteristic_PK PRIMARY KEY (ApplicantProfileIdentifier, StudentCharacteristicDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileApplicantCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileBackgroundCheck --
CREATE TABLE edfi.ApplicantProfileBackgroundCheck (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileBackgroundCheck_PK PRIMARY KEY (ApplicantProfileIdentifier, BackgroundCheckTypeDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileDisability --
CREATE TABLE edfi.ApplicantProfileDisability (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileDisability_PK PRIMARY KEY (ApplicantProfileIdentifier, DisabilityDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileDisabilityDesignation --
CREATE TABLE edfi.ApplicantProfileDisabilityDesignation (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileDisabilityDesignation_PK PRIMARY KEY (ApplicantProfileIdentifier, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileEducatorPreparationProgramName --
CREATE TABLE edfi.ApplicantProfileEducatorPreparationProgramName (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    EducatorPreparationProgramName VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileEducatorPreparationProgramName_PK PRIMARY KEY (ApplicantProfileIdentifier, EducatorPreparationProgramName)
);
ALTER TABLE edfi.ApplicantProfileEducatorPreparationProgramName ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileElectronicMail --
CREATE TABLE edfi.ApplicantProfileElectronicMail (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileElectronicMail_PK PRIMARY KEY (ApplicantProfileIdentifier, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileGradePointAverage --
CREATE TABLE edfi.ApplicantProfileGradePointAverage (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    GradePointAverageTypeDescriptorId INT NOT NULL,
    GradePointAverageValue DECIMAL(18, 4) NOT NULL,
    IsCumulative BOOLEAN NULL,
    MaxGradePointAverageValue DECIMAL(18, 4) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileGradePointAverage_PK PRIMARY KEY (ApplicantProfileIdentifier, GradePointAverageTypeDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileGradePointAverage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileHighlyQualifiedAcademicSubject --
CREATE TABLE edfi.ApplicantProfileHighlyQualifiedAcademicSubject (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileHighlyQualifiedAcademicSubject_PK PRIMARY KEY (ApplicantProfileIdentifier, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileHighlyQualifiedAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileIdentificationDocument --
CREATE TABLE edfi.ApplicantProfileIdentificationDocument (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileIdentificationDocument_PK PRIMARY KEY (ApplicantProfileIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileInternationalAddress --
CREATE TABLE edfi.ApplicantProfileInternationalAddress (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    BeginDate DATE NULL,
    CountryDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileInternationalAddress_PK PRIMARY KEY (ApplicantProfileIdentifier, AddressTypeDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileLanguage --
CREATE TABLE edfi.ApplicantProfileLanguage (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileLanguage_PK PRIMARY KEY (ApplicantProfileIdentifier, LanguageDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileLanguageUse --
CREATE TABLE edfi.ApplicantProfileLanguageUse (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileLanguageUse_PK PRIMARY KEY (ApplicantProfileIdentifier, LanguageDescriptorId, LanguageUseDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfilePersonalIdentificationDocument --
CREATE TABLE edfi.ApplicantProfilePersonalIdentificationDocument (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfilePersonalIdentificationDocument_PK PRIMARY KEY (ApplicantProfileIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.ApplicantProfilePersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileRace --
CREATE TABLE edfi.ApplicantProfileRace (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileRace_PK PRIMARY KEY (ApplicantProfileIdentifier, RaceDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileTelephone --
CREATE TABLE edfi.ApplicantProfileTelephone (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileTelephone_PK PRIMARY KEY (ApplicantProfileIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicantProfileVisa --
CREATE TABLE edfi.ApplicantProfileVisa (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantProfileVisa_PK PRIMARY KEY (ApplicantProfileIdentifier, VisaDescriptorId)
);
ALTER TABLE edfi.ApplicantProfileVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Application --
CREATE TABLE edfi.Application (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    AcceptedDate DATE NULL,
    ApplicationDate DATE NOT NULL,
    ApplicationSourceDescriptorId INT NULL,
    ApplicationStatusDescriptorId INT NOT NULL,
    CurrentEmployee BOOLEAN NULL,
    FirstContactDate DATE NULL,
    HighNeedsAcademicSubjectDescriptorId INT NULL,
    HireStatusDescriptorId INT NULL,
    HiringSourceDescriptorId INT NULL,
    RequisitionNumber VARCHAR(20) NULL,
    WithdrawDate DATE NULL,
    WithdrawReasonDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Application_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId)
);
ALTER TABLE edfi.Application ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Application ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Application ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicationEvent --
CREATE TABLE edfi.ApplicationEvent (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationEventTypeDescriptorId INT NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    SequenceNumber INT NOT NULL,
    ApplicationEvaluationScore DECIMAL(36, 18) NULL,
    ApplicationEventResultDescriptorId INT NULL,
    EventEndDate DATE NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ApplicationEvent_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationEventTypeDescriptorId, ApplicationIdentifier, EducationOrganizationId, EventDate, SequenceNumber)
);
ALTER TABLE edfi.ApplicationEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ApplicationEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ApplicationEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicationEventResultDescriptor --
CREATE TABLE edfi.ApplicationEventResultDescriptor (
    ApplicationEventResultDescriptorId INT NOT NULL,
    CONSTRAINT ApplicationEventResultDescriptor_PK PRIMARY KEY (ApplicationEventResultDescriptorId)
);

-- Table edfi.ApplicationEventTypeDescriptor --
CREATE TABLE edfi.ApplicationEventTypeDescriptor (
    ApplicationEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT ApplicationEventTypeDescriptor_PK PRIMARY KEY (ApplicationEventTypeDescriptorId)
);

-- Table edfi.ApplicationRecruitmentEventAttendance --
CREATE TABLE edfi.ApplicationRecruitmentEventAttendance (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationRecruitmentEventAttendance_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
);
ALTER TABLE edfi.ApplicationRecruitmentEventAttendance ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicationScoreResult --
CREATE TABLE edfi.ApplicationScoreResult (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    Result VARCHAR(35) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationScoreResult_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId, AssessmentReportingMethodDescriptorId)
);
ALTER TABLE edfi.ApplicationScoreResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ApplicationSourceDescriptor --
CREATE TABLE edfi.ApplicationSourceDescriptor (
    ApplicationSourceDescriptorId INT NOT NULL,
    CONSTRAINT ApplicationSourceDescriptor_PK PRIMARY KEY (ApplicationSourceDescriptorId)
);

-- Table edfi.ApplicationStatusDescriptor --
CREATE TABLE edfi.ApplicationStatusDescriptor (
    ApplicationStatusDescriptorId INT NOT NULL,
    CONSTRAINT ApplicationStatusDescriptor_PK PRIMARY KEY (ApplicationStatusDescriptorId)
);

-- Table edfi.ApplicationTerm --
CREATE TABLE edfi.ApplicationTerm (
    ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationTerm_PK PRIMARY KEY (ApplicantProfileIdentifier, ApplicationIdentifier, EducationOrganizationId, TermDescriptorId)
);
ALTER TABLE edfi.ApplicationTerm ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Assessment --
CREATE TABLE edfi.Assessment (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AdaptiveAssessment BOOLEAN NULL,
    AssessmentCategoryDescriptorId INT NULL,
    AssessmentFamily VARCHAR(60) NULL,
    AssessmentForm VARCHAR(60) NULL,
    AssessmentTitle VARCHAR(255) NOT NULL,
    AssessmentVersion INT NULL,
    EducationOrganizationId BIGINT NULL,
    MaxRawScore DECIMAL(15, 5) NULL,
    Nomenclature VARCHAR(100) NULL,
    RevisionDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Assessment_PK PRIMARY KEY (AssessmentIdentifier, Namespace)
);
ALTER TABLE edfi.Assessment ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Assessment ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Assessment ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentAcademicSubject --
CREATE TABLE edfi.AssessmentAcademicSubject (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentAcademicSubject_PK PRIMARY KEY (AssessmentIdentifier, Namespace, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.AssessmentAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentAdministration --
CREATE TABLE edfi.AssessmentAdministration (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AssessmentAdministration_PK PRIMARY KEY (AdministrationIdentifier, AssessmentIdentifier, AssigningEducationOrganizationId, Namespace)
);
ALTER TABLE edfi.AssessmentAdministration ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.AssessmentAdministration ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.AssessmentAdministration ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentAdministrationAssessmentBatteryPart --
CREATE TABLE edfi.AssessmentAdministrationAssessmentBatteryPart (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentBatteryPartName VARCHAR(65) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentAdministrationAssessmentBatteryPart_PK PRIMARY KEY (AdministrationIdentifier, AssessmentIdentifier, AssigningEducationOrganizationId, Namespace, AssessmentBatteryPartName)
);
ALTER TABLE edfi.AssessmentAdministrationAssessmentBatteryPart ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentAdministrationParticipation --
CREATE TABLE edfi.AssessmentAdministrationParticipation (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    ParticipatingEducationOrganizationId BIGINT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AssessmentAdministrationParticipation_PK PRIMARY KEY (AdministrationIdentifier, AssessmentIdentifier, AssigningEducationOrganizationId, Namespace, ParticipatingEducationOrganizationId)
);
ALTER TABLE edfi.AssessmentAdministrationParticipation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.AssessmentAdministrationParticipation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.AssessmentAdministrationParticipation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentAdministrationParticipationAdministrationPoint_c63833 --
CREATE TABLE edfi.AssessmentAdministrationParticipationAdministrationPoint_c63833 (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    ParticipatingEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    LoginId VARCHAR(120) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentAdministrationParticipationAdministratio_c63833_PK PRIMARY KEY (AdministrationIdentifier, AssessmentIdentifier, AssigningEducationOrganizationId, Namespace, ParticipatingEducationOrganizationId, EducationOrganizationId, ElectronicMailAddress)
);
ALTER TABLE edfi.AssessmentAdministrationParticipationAdministrationPoint_c63833 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentAdministrationPeriod --
CREATE TABLE edfi.AssessmentAdministrationPeriod (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentAdministrationPeriod_PK PRIMARY KEY (AdministrationIdentifier, AssessmentIdentifier, AssigningEducationOrganizationId, Namespace, BeginDate)
);
ALTER TABLE edfi.AssessmentAdministrationPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentAssessedGradeLevel --
CREATE TABLE edfi.AssessmentAssessedGradeLevel (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentAssessedGradeLevel_PK PRIMARY KEY (AssessmentIdentifier, Namespace, GradeLevelDescriptorId)
);
ALTER TABLE edfi.AssessmentAssessedGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentBatteryPart --
CREATE TABLE edfi.AssessmentBatteryPart (
    AssessmentBatteryPartName VARCHAR(65) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AssessmentBatteryPart_PK PRIMARY KEY (AssessmentBatteryPartName, AssessmentIdentifier, Namespace)
);
ALTER TABLE edfi.AssessmentBatteryPart ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.AssessmentBatteryPart ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.AssessmentBatteryPart ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentBatteryPartObjectiveAssessment --
CREATE TABLE edfi.AssessmentBatteryPartObjectiveAssessment (
    AssessmentBatteryPartName VARCHAR(65) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentBatteryPartObjectiveAssessment_PK PRIMARY KEY (AssessmentBatteryPartName, AssessmentIdentifier, Namespace, IdentificationCode)
);
ALTER TABLE edfi.AssessmentBatteryPartObjectiveAssessment ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentCategoryDescriptor --
CREATE TABLE edfi.AssessmentCategoryDescriptor (
    AssessmentCategoryDescriptorId INT NOT NULL,
    CONSTRAINT AssessmentCategoryDescriptor_PK PRIMARY KEY (AssessmentCategoryDescriptorId)
);

-- Table edfi.AssessmentContentStandard --
CREATE TABLE edfi.AssessmentContentStandard (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    MandatingEducationOrganizationId BIGINT NULL,
    PublicationDate DATE NULL,
    PublicationStatusDescriptorId INT NULL,
    PublicationYear SMALLINT NULL,
    Title VARCHAR(100) NOT NULL,
    URI VARCHAR(255) NULL,
    Version VARCHAR(50) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentContentStandard_PK PRIMARY KEY (AssessmentIdentifier, Namespace)
);
ALTER TABLE edfi.AssessmentContentStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentContentStandardAuthor --
CREATE TABLE edfi.AssessmentContentStandardAuthor (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentContentStandardAuthor_PK PRIMARY KEY (AssessmentIdentifier, Namespace, Author)
);
ALTER TABLE edfi.AssessmentContentStandardAuthor ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentIdentificationCode --
CREATE TABLE edfi.AssessmentIdentificationCode (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentIdentificationSystemDescriptorId INT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(120) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentIdentificationCode_PK PRIMARY KEY (AssessmentIdentifier, Namespace, AssessmentIdentificationSystemDescriptorId)
);
ALTER TABLE edfi.AssessmentIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentIdentificationSystemDescriptor --
CREATE TABLE edfi.AssessmentIdentificationSystemDescriptor (
    AssessmentIdentificationSystemDescriptorId INT NOT NULL,
    CONSTRAINT AssessmentIdentificationSystemDescriptor_PK PRIMARY KEY (AssessmentIdentificationSystemDescriptorId)
);

-- Table edfi.AssessmentItem --
CREATE TABLE edfi.AssessmentItem (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentItemCategoryDescriptorId INT NULL,
    AssessmentItemURI VARCHAR(255) NULL,
    ExpectedTimeAssessed VARCHAR(30) NULL,
    ItemText VARCHAR(1024) NULL,
    MaxRawScore DECIMAL(15, 5) NULL,
    Nomenclature VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AssessmentItem_PK PRIMARY KEY (AssessmentIdentifier, IdentificationCode, Namespace)
);
ALTER TABLE edfi.AssessmentItem ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.AssessmentItem ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.AssessmentItem ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentItemCategoryDescriptor --
CREATE TABLE edfi.AssessmentItemCategoryDescriptor (
    AssessmentItemCategoryDescriptorId INT NOT NULL,
    CONSTRAINT AssessmentItemCategoryDescriptor_PK PRIMARY KEY (AssessmentItemCategoryDescriptorId)
);

-- Table edfi.AssessmentItemLearningStandard --
CREATE TABLE edfi.AssessmentItemLearningStandard (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    LearningStandardId VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentItemLearningStandard_PK PRIMARY KEY (AssessmentIdentifier, IdentificationCode, Namespace, LearningStandardId)
);
ALTER TABLE edfi.AssessmentItemLearningStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentItemPossibleResponse --
CREATE TABLE edfi.AssessmentItemPossibleResponse (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    ResponseValue VARCHAR(60) NOT NULL,
    CorrectResponse BOOLEAN NULL,
    ResponseDescription VARCHAR(1024) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentItemPossibleResponse_PK PRIMARY KEY (AssessmentIdentifier, IdentificationCode, Namespace, ResponseValue)
);
ALTER TABLE edfi.AssessmentItemPossibleResponse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentItemResultDescriptor --
CREATE TABLE edfi.AssessmentItemResultDescriptor (
    AssessmentItemResultDescriptorId INT NOT NULL,
    CONSTRAINT AssessmentItemResultDescriptor_PK PRIMARY KEY (AssessmentItemResultDescriptorId)
);

-- Table edfi.AssessmentLanguage --
CREATE TABLE edfi.AssessmentLanguage (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentLanguage_PK PRIMARY KEY (AssessmentIdentifier, Namespace, LanguageDescriptorId)
);
ALTER TABLE edfi.AssessmentLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentPerformanceLevel --
CREATE TABLE edfi.AssessmentPerformanceLevel (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    PerformanceLevelDescriptorId INT NOT NULL,
    MaximumScore VARCHAR(35) NULL,
    MinimumScore VARCHAR(35) NULL,
    PerformanceLevelIndicatorName VARCHAR(60) NULL,
    ResultDatatypeTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentPerformanceLevel_PK PRIMARY KEY (AssessmentIdentifier, Namespace, AssessmentReportingMethodDescriptorId, PerformanceLevelDescriptorId)
);
ALTER TABLE edfi.AssessmentPerformanceLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentPeriod --
CREATE TABLE edfi.AssessmentPeriod (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentPeriodDescriptorId INT NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentPeriod_PK PRIMARY KEY (AssessmentIdentifier, Namespace, AssessmentPeriodDescriptorId)
);
ALTER TABLE edfi.AssessmentPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentPeriodDescriptor --
CREATE TABLE edfi.AssessmentPeriodDescriptor (
    AssessmentPeriodDescriptorId INT NOT NULL,
    CONSTRAINT AssessmentPeriodDescriptor_PK PRIMARY KEY (AssessmentPeriodDescriptorId)
);

-- Table edfi.AssessmentPlatformType --
CREATE TABLE edfi.AssessmentPlatformType (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    PlatformTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentPlatformType_PK PRIMARY KEY (AssessmentIdentifier, Namespace, PlatformTypeDescriptorId)
);
ALTER TABLE edfi.AssessmentPlatformType ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentProgram --
CREATE TABLE edfi.AssessmentProgram (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentProgram_PK PRIMARY KEY (AssessmentIdentifier, Namespace, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.AssessmentProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentReportingMethodDescriptor --
CREATE TABLE edfi.AssessmentReportingMethodDescriptor (
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    CONSTRAINT AssessmentReportingMethodDescriptor_PK PRIMARY KEY (AssessmentReportingMethodDescriptorId)
);

-- Table edfi.AssessmentScore --
CREATE TABLE edfi.AssessmentScore (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    MaximumScore VARCHAR(35) NULL,
    MinimumScore VARCHAR(35) NULL,
    ResultDatatypeTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentScore_PK PRIMARY KEY (AssessmentIdentifier, Namespace, AssessmentReportingMethodDescriptorId)
);
ALTER TABLE edfi.AssessmentScore ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentScoreRangeLearningStandard --
CREATE TABLE edfi.AssessmentScoreRangeLearningStandard (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    ScoreRangeId VARCHAR(120) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NULL,
    IdentificationCode VARCHAR(120) NULL,
    MaximumScore VARCHAR(35) NOT NULL,
    MinimumScore VARCHAR(35) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AssessmentScoreRangeLearningStandard_PK PRIMARY KEY (AssessmentIdentifier, Namespace, ScoreRangeId)
);
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.AssessmentScoreRangeLearningStandard ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentScoreRangeLearningStandardLearningStandard --
CREATE TABLE edfi.AssessmentScoreRangeLearningStandardLearningStandard (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    ScoreRangeId VARCHAR(120) NOT NULL,
    LearningStandardId VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentScoreRangeLearningStandardLearningStandard_PK PRIMARY KEY (AssessmentIdentifier, Namespace, ScoreRangeId, LearningStandardId)
);
ALTER TABLE edfi.AssessmentScoreRangeLearningStandardLearningStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssessmentSection --
CREATE TABLE edfi.AssessmentSection (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AssessmentSection_PK PRIMARY KEY (AssessmentIdentifier, Namespace, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
);
ALTER TABLE edfi.AssessmentSection ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.AssignmentLateStatusDescriptor --
CREATE TABLE edfi.AssignmentLateStatusDescriptor (
    AssignmentLateStatusDescriptorId INT NOT NULL,
    CONSTRAINT AssignmentLateStatusDescriptor_PK PRIMARY KEY (AssignmentLateStatusDescriptorId)
);

-- Table edfi.AttemptStatusDescriptor --
CREATE TABLE edfi.AttemptStatusDescriptor (
    AttemptStatusDescriptorId INT NOT NULL,
    CONSTRAINT AttemptStatusDescriptor_PK PRIMARY KEY (AttemptStatusDescriptorId)
);

-- Table edfi.AttendanceEventCategoryDescriptor --
CREATE TABLE edfi.AttendanceEventCategoryDescriptor (
    AttendanceEventCategoryDescriptorId INT NOT NULL,
    CONSTRAINT AttendanceEventCategoryDescriptor_PK PRIMARY KEY (AttendanceEventCategoryDescriptorId)
);

-- Table edfi.BackgroundCheckStatusDescriptor --
CREATE TABLE edfi.BackgroundCheckStatusDescriptor (
    BackgroundCheckStatusDescriptorId INT NOT NULL,
    CONSTRAINT BackgroundCheckStatusDescriptor_PK PRIMARY KEY (BackgroundCheckStatusDescriptorId)
);

-- Table edfi.BackgroundCheckTypeDescriptor --
CREATE TABLE edfi.BackgroundCheckTypeDescriptor (
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    CONSTRAINT BackgroundCheckTypeDescriptor_PK PRIMARY KEY (BackgroundCheckTypeDescriptorId)
);

-- Table edfi.BalanceSheetDimension --
CREATE TABLE edfi.BalanceSheetDimension (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    CodeName VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT BalanceSheetDimension_PK PRIMARY KEY (Code, FiscalYear)
);
ALTER TABLE edfi.BalanceSheetDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.BalanceSheetDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.BalanceSheetDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.BalanceSheetDimensionReportingTag --
CREATE TABLE edfi.BalanceSheetDimensionReportingTag (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BalanceSheetDimensionReportingTag_PK PRIMARY KEY (Code, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.BalanceSheetDimensionReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.BarrierToInternetAccessInResidenceDescriptor --
CREATE TABLE edfi.BarrierToInternetAccessInResidenceDescriptor (
    BarrierToInternetAccessInResidenceDescriptorId INT NOT NULL,
    CONSTRAINT BarrierToInternetAccessInResidenceDescriptor_PK PRIMARY KEY (BarrierToInternetAccessInResidenceDescriptorId)
);

-- Table edfi.BehaviorDescriptor --
CREATE TABLE edfi.BehaviorDescriptor (
    BehaviorDescriptorId INT NOT NULL,
    CONSTRAINT BehaviorDescriptor_PK PRIMARY KEY (BehaviorDescriptorId)
);

-- Table edfi.BellSchedule --
CREATE TABLE edfi.BellSchedule (
    BellScheduleName VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    AlternateDayName VARCHAR(20) NULL,
    EndTime TIME NULL,
    StartTime TIME NULL,
    TotalInstructionalTime INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT BellSchedule_PK PRIMARY KEY (BellScheduleName, SchoolId)
);
ALTER TABLE edfi.BellSchedule ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.BellSchedule ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.BellSchedule ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.BellScheduleClassPeriod --
CREATE TABLE edfi.BellScheduleClassPeriod (
    BellScheduleName VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    ClassPeriodName VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BellScheduleClassPeriod_PK PRIMARY KEY (BellScheduleName, SchoolId, ClassPeriodName)
);
ALTER TABLE edfi.BellScheduleClassPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.BellScheduleDate --
CREATE TABLE edfi.BellScheduleDate (
    BellScheduleName VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    Date DATE NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BellScheduleDate_PK PRIMARY KEY (BellScheduleName, SchoolId, Date)
);
ALTER TABLE edfi.BellScheduleDate ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.BellScheduleGradeLevel --
CREATE TABLE edfi.BellScheduleGradeLevel (
    BellScheduleName VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT BellScheduleGradeLevel_PK PRIMARY KEY (BellScheduleName, SchoolId, GradeLevelDescriptorId)
);
ALTER TABLE edfi.BellScheduleGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.BusRouteDescriptor --
CREATE TABLE edfi.BusRouteDescriptor (
    BusRouteDescriptorId INT NOT NULL,
    CONSTRAINT BusRouteDescriptor_PK PRIMARY KEY (BusRouteDescriptorId)
);

-- Table edfi.Calendar --
CREATE TABLE edfi.Calendar (
    CalendarCode VARCHAR(120) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    CalendarTypeDescriptorId INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Calendar_PK PRIMARY KEY (CalendarCode, SchoolId, SchoolYear)
);
ALTER TABLE edfi.Calendar ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Calendar ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Calendar ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CalendarDate --
CREATE TABLE edfi.CalendarDate (
    CalendarCode VARCHAR(120) NOT NULL,
    Date DATE NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CalendarDate_PK PRIMARY KEY (CalendarCode, Date, SchoolId, SchoolYear)
);
ALTER TABLE edfi.CalendarDate ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CalendarDate ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CalendarDate ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CalendarDateCalendarEvent --
CREATE TABLE edfi.CalendarDateCalendarEvent (
    CalendarCode VARCHAR(120) NOT NULL,
    Date DATE NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    CalendarEventDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CalendarDateCalendarEvent_PK PRIMARY KEY (CalendarCode, Date, SchoolId, SchoolYear, CalendarEventDescriptorId)
);
ALTER TABLE edfi.CalendarDateCalendarEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CalendarEventDescriptor --
CREATE TABLE edfi.CalendarEventDescriptor (
    CalendarEventDescriptorId INT NOT NULL,
    CONSTRAINT CalendarEventDescriptor_PK PRIMARY KEY (CalendarEventDescriptorId)
);

-- Table edfi.CalendarGradeLevel --
CREATE TABLE edfi.CalendarGradeLevel (
    CalendarCode VARCHAR(120) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CalendarGradeLevel_PK PRIMARY KEY (CalendarCode, SchoolId, SchoolYear, GradeLevelDescriptorId)
);
ALTER TABLE edfi.CalendarGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CalendarTypeDescriptor --
CREATE TABLE edfi.CalendarTypeDescriptor (
    CalendarTypeDescriptorId INT NOT NULL,
    CONSTRAINT CalendarTypeDescriptor_PK PRIMARY KEY (CalendarTypeDescriptorId)
);

-- Table edfi.Candidate --
CREATE TABLE edfi.Candidate (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    BirthCity VARCHAR(30) NULL,
    BirthCountryDescriptorId INT NULL,
    BirthDate DATE NOT NULL,
    BirthInternationalProvince VARCHAR(150) NULL,
    BirthSexDescriptorId INT NULL,
    BirthStateAbbreviationDescriptorId INT NULL,
    CitizenshipStatusDescriptorId INT NULL,
    DateEnteredUS DATE NULL,
    DisplacementStatus VARCHAR(30) NULL,
    EconomicDisadvantaged BOOLEAN NULL,
    EnglishLanguageExamDescriptorId INT NULL,
    FirstGenerationStudent BOOLEAN NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenderIdentity VARCHAR(60) NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    LastSurname VARCHAR(75) NOT NULL,
    LimitedEnglishProficiencyDescriptorId INT NULL,
    LoginId VARCHAR(120) NULL,
    MaidenName VARCHAR(75) NULL,
    MiddleName VARCHAR(75) NULL,
    MultipleBirthStatus BOOLEAN NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    PersonId VARCHAR(32) NULL,
    PreferredFirstName VARCHAR(75) NULL,
    PreferredLastSurname VARCHAR(75) NULL,
    PreviousCareerDescriptorId INT NULL,
    ProfileThumbnail VARCHAR(255) NULL,
    SexDescriptorId INT NOT NULL,
    SourceSystemDescriptorId INT NULL,
    TuitionCost DECIMAL(19, 4) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Candidate_PK PRIMARY KEY (CandidateIdentifier)
);
ALTER TABLE edfi.Candidate ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Candidate ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Candidate ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateAddress --
CREATE TABLE edfi.CandidateAddress (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    Latitude VARCHAR(20) NULL,
    LocaleDescriptorId INT NULL,
    Longitude VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateAddress_PK PRIMARY KEY (CandidateIdentifier, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
);
ALTER TABLE edfi.CandidateAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateAddressPeriod --
CREATE TABLE edfi.CandidateAddressPeriod (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateAddressPeriod_PK PRIMARY KEY (CandidateIdentifier, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, BeginDate)
);
ALTER TABLE edfi.CandidateAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateBackgroundCheck --
CREATE TABLE edfi.CandidateBackgroundCheck (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateBackgroundCheck_PK PRIMARY KEY (CandidateIdentifier)
);
ALTER TABLE edfi.CandidateBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateCharacteristic --
CREATE TABLE edfi.CandidateCharacteristic (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    CandidateCharacteristicDescriptorId INT NOT NULL,
    BeginDate DATE NULL,
    DesignatedBy VARCHAR(60) NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateCharacteristic_PK PRIMARY KEY (CandidateIdentifier, CandidateCharacteristicDescriptorId)
);
ALTER TABLE edfi.CandidateCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateCharacteristicDescriptor --
CREATE TABLE edfi.CandidateCharacteristicDescriptor (
    CandidateCharacteristicDescriptorId INT NOT NULL,
    CONSTRAINT CandidateCharacteristicDescriptor_PK PRIMARY KEY (CandidateCharacteristicDescriptorId)
);

-- Table edfi.CandidateDisability --
CREATE TABLE edfi.CandidateDisability (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateDisability_PK PRIMARY KEY (CandidateIdentifier, DisabilityDescriptorId)
);
ALTER TABLE edfi.CandidateDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateDisabilityDesignation --
CREATE TABLE edfi.CandidateDisabilityDesignation (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateDisabilityDesignation_PK PRIMARY KEY (CandidateIdentifier, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
);
ALTER TABLE edfi.CandidateDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateEducatorPreparationProgramAssociation --
CREATE TABLE edfi.CandidateEducatorPreparationProgramAssociation (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ApplicantProfileIdentifier VARCHAR(32) NULL,
    ApplicationIdentifier VARCHAR(20) NULL,
    EndDate DATE NULL,
    EPPProgramPathwayDescriptorId INT NULL,
    ReasonExitedDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CandidateEducatorPreparationProgramAssociation_PK PRIMARY KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.CandidateEducatorPreparationProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CandidateEducatorPreparationProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CandidateEducatorPreparationProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b --
CREATE TABLE edfi.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    IndicatorName VARCHAR(200) NOT NULL,
    DesignatedBy VARCHAR(60) NULL,
    EndDate DATE NULL,
    Indicator VARCHAR(60) NOT NULL,
    IndicatorGroup VARCHAR(200) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateEducatorPreparationProgramAssociationCand_0d7c2b_PK PRIMARY KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, IndicatorName)
);
ALTER TABLE edfi.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateEducatorPreparationProgramAssociationCohortYear --
CREATE TABLE edfi.CandidateEducatorPreparationProgramAssociationCohortYear (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CohortYearTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateEducatorPreparationProgramAssociationCohortYear_PK PRIMARY KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, CohortYearTypeDescriptorId, SchoolYear)
);
ALTER TABLE edfi.CandidateEducatorPreparationProgramAssociationCohortYear ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4 --
CREATE TABLE edfi.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4 (
    BeginDate DATE NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    MajorSpecialization VARCHAR(255) NOT NULL,
    EndDate DATE NULL,
    MinorSpecialization VARCHAR(255) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateEducatorPreparationProgramAssociationDegr_2501c4_PK PRIMARY KEY (BeginDate, CandidateIdentifier, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, MajorSpecialization)
);
ALTER TABLE edfi.CandidateEducatorPreparationProgramAssociationDegreeSpec_2501c4 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateElectronicMail --
CREATE TABLE edfi.CandidateElectronicMail (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateElectronicMail_PK PRIMARY KEY (CandidateIdentifier, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
);
ALTER TABLE edfi.CandidateElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateEPPProgramDegree --
CREATE TABLE edfi.CandidateEPPProgramDegree (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    EPPDegreeTypeDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateEPPProgramDegree_PK PRIMARY KEY (CandidateIdentifier, AcademicSubjectDescriptorId, EPPDegreeTypeDescriptorId, GradeLevelDescriptorId)
);
ALTER TABLE edfi.CandidateEPPProgramDegree ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateIdentificationCode --
CREATE TABLE edfi.CandidateIdentificationCode (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    StudentIdentificationSystemDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateIdentificationCode_PK PRIMARY KEY (CandidateIdentifier, AssigningOrganizationIdentificationCode, IdentificationCode, StudentIdentificationSystemDescriptorId)
);
ALTER TABLE edfi.CandidateIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateIdentificationDocument --
CREATE TABLE edfi.CandidateIdentificationDocument (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateIdentificationDocument_PK PRIMARY KEY (CandidateIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.CandidateIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateIdentificationSystemDescriptor --
CREATE TABLE edfi.CandidateIdentificationSystemDescriptor (
    CandidateIdentificationSystemDescriptorId INT NOT NULL,
    CONSTRAINT CandidateIdentificationSystemDescriptor_PK PRIMARY KEY (CandidateIdentificationSystemDescriptorId)
);

-- Table edfi.CandidateIdentity --
CREATE TABLE edfi.CandidateIdentity (
    CandidateIdentificationSystemDescriptorId INT NOT NULL,
    CandidateIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(60) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CandidateIdentity_PK PRIMARY KEY (CandidateIdentificationSystemDescriptorId, CandidateIdentifier, EducationOrganizationId)
);
ALTER TABLE edfi.CandidateIdentity ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CandidateIdentity ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CandidateIdentity ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateIndicator --
CREATE TABLE edfi.CandidateIndicator (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    BeginDate DATE NOT NULL,
    IndicatorName VARCHAR(200) NOT NULL,
    DesignatedBy VARCHAR(60) NULL,
    EndDate DATE NULL,
    Indicator VARCHAR(60) NOT NULL,
    IndicatorGroup VARCHAR(200) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateIndicator_PK PRIMARY KEY (CandidateIdentifier, BeginDate, IndicatorName)
);
ALTER TABLE edfi.CandidateIndicator ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateInternationalAddress --
CREATE TABLE edfi.CandidateInternationalAddress (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    BeginDate DATE NULL,
    CountryDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateInternationalAddress_PK PRIMARY KEY (CandidateIdentifier, AddressTypeDescriptorId)
);
ALTER TABLE edfi.CandidateInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateLanguage --
CREATE TABLE edfi.CandidateLanguage (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateLanguage_PK PRIMARY KEY (CandidateIdentifier, LanguageDescriptorId)
);
ALTER TABLE edfi.CandidateLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateLanguageUse --
CREATE TABLE edfi.CandidateLanguageUse (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateLanguageUse_PK PRIMARY KEY (CandidateIdentifier, LanguageDescriptorId, LanguageUseDescriptorId)
);
ALTER TABLE edfi.CandidateLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateOtherName --
CREATE TABLE edfi.CandidateOtherName (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    OtherNameTypeDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateOtherName_PK PRIMARY KEY (CandidateIdentifier, OtherNameTypeDescriptorId)
);
ALTER TABLE edfi.CandidateOtherName ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidatePersonalIdentificationDocument --
CREATE TABLE edfi.CandidatePersonalIdentificationDocument (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidatePersonalIdentificationDocument_PK PRIMARY KEY (CandidateIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.CandidatePersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateRace --
CREATE TABLE edfi.CandidateRace (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateRace_PK PRIMARY KEY (CandidateIdentifier, RaceDescriptorId)
);
ALTER TABLE edfi.CandidateRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateRelationshipToStaffAssociation --
CREATE TABLE edfi.CandidateRelationshipToStaffAssociation (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    StaffUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    StaffToCandidateRelationshipDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CandidateRelationshipToStaffAssociation_PK PRIMARY KEY (CandidateIdentifier, StaffUSI)
);
ALTER TABLE edfi.CandidateRelationshipToStaffAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CandidateRelationshipToStaffAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CandidateRelationshipToStaffAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateTelephone --
CREATE TABLE edfi.CandidateTelephone (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateTelephone_PK PRIMARY KEY (CandidateIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.CandidateTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CandidateVisa --
CREATE TABLE edfi.CandidateVisa (
    CandidateIdentifier VARCHAR(32) NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CandidateVisa_PK PRIMARY KEY (CandidateIdentifier, VisaDescriptorId)
);
ALTER TABLE edfi.CandidateVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CareerPathwayDescriptor --
CREATE TABLE edfi.CareerPathwayDescriptor (
    CareerPathwayDescriptorId INT NOT NULL,
    CONSTRAINT CareerPathwayDescriptor_PK PRIMARY KEY (CareerPathwayDescriptorId)
);

-- Table edfi.Certification --
CREATE TABLE edfi.Certification (
    CertificationIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CertificationFieldDescriptorId INT NULL,
    CertificationLevelDescriptorId INT NULL,
    CertificationStandardDescriptorId INT NULL,
    CertificationTitle VARCHAR(64) NOT NULL,
    EducationOrganizationId BIGINT NULL,
    EducatorRoleDescriptorId INT NULL,
    EffectiveDate DATE NULL,
    EndDate DATE NULL,
    InstructionalSettingDescriptorId INT NULL,
    MinimumDegreeDescriptorId INT NULL,
    PopulationServedDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Certification_PK PRIMARY KEY (CertificationIdentifier, Namespace)
);
ALTER TABLE edfi.Certification ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Certification ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Certification ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CertificationCertificationExam --
CREATE TABLE edfi.CertificationCertificationExam (
    CertificationIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CertificationExamIdentifier VARCHAR(120) NOT NULL,
    CertificationExamNamespace VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CertificationCertificationExam_PK PRIMARY KEY (CertificationIdentifier, Namespace, CertificationExamIdentifier, CertificationExamNamespace)
);
ALTER TABLE edfi.CertificationCertificationExam ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CertificationExam --
CREATE TABLE edfi.CertificationExam (
    CertificationExamIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CertificationExamTitle VARCHAR(60) NOT NULL,
    CertificationExamTypeDescriptorId INT NULL,
    EducationOrganizationId BIGINT NULL,
    EffectiveDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CertificationExam_PK PRIMARY KEY (CertificationExamIdentifier, Namespace)
);
ALTER TABLE edfi.CertificationExam ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CertificationExam ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CertificationExam ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CertificationExamResult --
CREATE TABLE edfi.CertificationExamResult (
    CertificationExamDate DATE NOT NULL,
    CertificationExamIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    AttemptNumber INT NULL,
    CertificationExamAssessmentIdentifier VARCHAR(120) NULL,
    CertificationExamNamespace VARCHAR(255) NULL,
    CertificationExamPassIndicator BOOLEAN NULL,
    CertificationExamScore DECIMAL(6, 3) NULL,
    CertificationExamStatusDescriptorId INT NULL,
    CertificationExamStudentAssessmentIdentifier VARCHAR(120) NULL,
    CertificationExamStudentUSI INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CertificationExamResult_PK PRIMARY KEY (CertificationExamDate, CertificationExamIdentifier, Namespace, PersonId, SourceSystemDescriptorId)
);
ALTER TABLE edfi.CertificationExamResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CertificationExamResult ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CertificationExamResult ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CertificationExamStatusDescriptor --
CREATE TABLE edfi.CertificationExamStatusDescriptor (
    CertificationExamStatusDescriptorId INT NOT NULL,
    CONSTRAINT CertificationExamStatusDescriptor_PK PRIMARY KEY (CertificationExamStatusDescriptorId)
);

-- Table edfi.CertificationExamTypeDescriptor --
CREATE TABLE edfi.CertificationExamTypeDescriptor (
    CertificationExamTypeDescriptorId INT NOT NULL,
    CONSTRAINT CertificationExamTypeDescriptor_PK PRIMARY KEY (CertificationExamTypeDescriptorId)
);

-- Table edfi.CertificationFieldDescriptor --
CREATE TABLE edfi.CertificationFieldDescriptor (
    CertificationFieldDescriptorId INT NOT NULL,
    CONSTRAINT CertificationFieldDescriptor_PK PRIMARY KEY (CertificationFieldDescriptorId)
);

-- Table edfi.CertificationGradeLevel --
CREATE TABLE edfi.CertificationGradeLevel (
    CertificationIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CertificationGradeLevel_PK PRIMARY KEY (CertificationIdentifier, Namespace, GradeLevelDescriptorId)
);
ALTER TABLE edfi.CertificationGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CertificationLevelDescriptor --
CREATE TABLE edfi.CertificationLevelDescriptor (
    CertificationLevelDescriptorId INT NOT NULL,
    CONSTRAINT CertificationLevelDescriptor_PK PRIMARY KEY (CertificationLevelDescriptorId)
);

-- Table edfi.CertificationRoute --
CREATE TABLE edfi.CertificationRoute (
    CertificationIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CertificationRouteDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CertificationRoute_PK PRIMARY KEY (CertificationIdentifier, Namespace, CertificationRouteDescriptorId)
);
ALTER TABLE edfi.CertificationRoute ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CertificationRouteDescriptor --
CREATE TABLE edfi.CertificationRouteDescriptor (
    CertificationRouteDescriptorId INT NOT NULL,
    CONSTRAINT CertificationRouteDescriptor_PK PRIMARY KEY (CertificationRouteDescriptorId)
);

-- Table edfi.CertificationStandardDescriptor --
CREATE TABLE edfi.CertificationStandardDescriptor (
    CertificationStandardDescriptorId INT NOT NULL,
    CONSTRAINT CertificationStandardDescriptor_PK PRIMARY KEY (CertificationStandardDescriptorId)
);

-- Table edfi.CharterApprovalAgencyTypeDescriptor --
CREATE TABLE edfi.CharterApprovalAgencyTypeDescriptor (
    CharterApprovalAgencyTypeDescriptorId INT NOT NULL,
    CONSTRAINT CharterApprovalAgencyTypeDescriptor_PK PRIMARY KEY (CharterApprovalAgencyTypeDescriptorId)
);

-- Table edfi.CharterStatusDescriptor --
CREATE TABLE edfi.CharterStatusDescriptor (
    CharterStatusDescriptorId INT NOT NULL,
    CONSTRAINT CharterStatusDescriptor_PK PRIMARY KEY (CharterStatusDescriptorId)
);

-- Table edfi.ChartOfAccount --
CREATE TABLE edfi.ChartOfAccount (
    AccountIdentifier VARCHAR(50) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    AccountName VARCHAR(100) NULL,
    AccountTypeDescriptorId INT NOT NULL,
    BalanceSheetCode VARCHAR(16) NULL,
    FunctionCode VARCHAR(16) NULL,
    FundCode VARCHAR(16) NULL,
    ObjectCode VARCHAR(16) NULL,
    OperationalUnitCode VARCHAR(16) NULL,
    ProgramCode VARCHAR(16) NULL,
    ProjectCode VARCHAR(16) NULL,
    SourceCode VARCHAR(16) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ChartOfAccount_PK PRIMARY KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
);
ALTER TABLE edfi.ChartOfAccount ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ChartOfAccount ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ChartOfAccount ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ChartOfAccountReportingTag --
CREATE TABLE edfi.ChartOfAccountReportingTag (
    AccountIdentifier VARCHAR(50) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    TagValue VARCHAR(100) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ChartOfAccountReportingTag_PK PRIMARY KEY (AccountIdentifier, EducationOrganizationId, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.ChartOfAccountReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CitizenshipStatusDescriptor --
CREATE TABLE edfi.CitizenshipStatusDescriptor (
    CitizenshipStatusDescriptorId INT NOT NULL,
    CONSTRAINT CitizenshipStatusDescriptor_PK PRIMARY KEY (CitizenshipStatusDescriptorId)
);

-- Table edfi.ClassPeriod --
CREATE TABLE edfi.ClassPeriod (
    ClassPeriodName VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    OfficialAttendancePeriod BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ClassPeriod_PK PRIMARY KEY (ClassPeriodName, SchoolId)
);
ALTER TABLE edfi.ClassPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ClassPeriod ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ClassPeriod ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ClassPeriodMeetingTime --
CREATE TABLE edfi.ClassPeriodMeetingTime (
    ClassPeriodName VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    EndTime TIME NOT NULL,
    StartTime TIME NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ClassPeriodMeetingTime_PK PRIMARY KEY (ClassPeriodName, SchoolId, EndTime, StartTime)
);
ALTER TABLE edfi.ClassPeriodMeetingTime ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ClassroomPositionDescriptor --
CREATE TABLE edfi.ClassroomPositionDescriptor (
    ClassroomPositionDescriptorId INT NOT NULL,
    CONSTRAINT ClassroomPositionDescriptor_PK PRIMARY KEY (ClassroomPositionDescriptorId)
);

-- Table edfi.Cohort --
CREATE TABLE edfi.Cohort (
    CohortIdentifier VARCHAR(36) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    CohortDescription VARCHAR(1024) NULL,
    CohortScopeDescriptorId INT NULL,
    CohortTypeDescriptorId INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Cohort_PK PRIMARY KEY (CohortIdentifier, EducationOrganizationId)
);
ALTER TABLE edfi.Cohort ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Cohort ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Cohort ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CohortProgram --
CREATE TABLE edfi.CohortProgram (
    CohortIdentifier VARCHAR(36) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CohortProgram_PK PRIMARY KEY (CohortIdentifier, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.CohortProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CohortScopeDescriptor --
CREATE TABLE edfi.CohortScopeDescriptor (
    CohortScopeDescriptorId INT NOT NULL,
    CONSTRAINT CohortScopeDescriptor_PK PRIMARY KEY (CohortScopeDescriptorId)
);

-- Table edfi.CohortTypeDescriptor --
CREATE TABLE edfi.CohortTypeDescriptor (
    CohortTypeDescriptorId INT NOT NULL,
    CONSTRAINT CohortTypeDescriptor_PK PRIMARY KEY (CohortTypeDescriptorId)
);

-- Table edfi.CohortYearTypeDescriptor --
CREATE TABLE edfi.CohortYearTypeDescriptor (
    CohortYearTypeDescriptorId INT NOT NULL,
    CONSTRAINT CohortYearTypeDescriptor_PK PRIMARY KEY (CohortYearTypeDescriptorId)
);

-- Table edfi.CommunityOrganization --
CREATE TABLE edfi.CommunityOrganization (
    CommunityOrganizationId BIGINT NOT NULL,
    CONSTRAINT CommunityOrganization_PK PRIMARY KEY (CommunityOrganizationId)
);

-- Table edfi.CommunityProvider --
CREATE TABLE edfi.CommunityProvider (
    CommunityProviderId BIGINT NOT NULL,
    CommunityOrganizationId BIGINT NULL,
    LicenseExemptIndicator BOOLEAN NULL,
    ProviderCategoryDescriptorId INT NOT NULL,
    ProviderProfitabilityDescriptorId INT NULL,
    ProviderStatusDescriptorId INT NOT NULL,
    SchoolIndicator BOOLEAN NULL,
    CONSTRAINT CommunityProvider_PK PRIMARY KEY (CommunityProviderId)
);

-- Table edfi.CommunityProviderLicense --
CREATE TABLE edfi.CommunityProviderLicense (
    CommunityProviderId BIGINT NOT NULL,
    LicenseIdentifier VARCHAR(36) NOT NULL,
    LicensingOrganization VARCHAR(75) NOT NULL,
    AuthorizedFacilityCapacity INT NULL,
    LicenseEffectiveDate DATE NOT NULL,
    LicenseExpirationDate DATE NULL,
    LicenseIssueDate DATE NULL,
    LicenseStatusDescriptorId INT NULL,
    LicenseTypeDescriptorId INT NOT NULL,
    OldestAgeAuthorizedToServe INT NULL,
    YoungestAgeAuthorizedToServe INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CommunityProviderLicense_PK PRIMARY KEY (CommunityProviderId, LicenseIdentifier, LicensingOrganization)
);
ALTER TABLE edfi.CommunityProviderLicense ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CommunityProviderLicense ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CommunityProviderLicense ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CompetencyLevelDescriptor --
CREATE TABLE edfi.CompetencyLevelDescriptor (
    CompetencyLevelDescriptorId INT NOT NULL,
    CONSTRAINT CompetencyLevelDescriptor_PK PRIMARY KEY (CompetencyLevelDescriptorId)
);

-- Table edfi.CompetencyObjective --
CREATE TABLE edfi.CompetencyObjective (
    EducationOrganizationId BIGINT NOT NULL,
    Objective VARCHAR(60) NOT NULL,
    ObjectiveGradeLevelDescriptorId INT NOT NULL,
    CompetencyObjectiveId VARCHAR(120) NULL,
    Description VARCHAR(1024) NULL,
    SuccessCriteria VARCHAR(150) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CompetencyObjective_PK PRIMARY KEY (EducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId)
);
ALTER TABLE edfi.CompetencyObjective ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CompetencyObjective ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CompetencyObjective ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Contact --
CREATE TABLE edfi.Contact (
    ContactUSI SERIAL NOT NULL,
    ContactUniqueId VARCHAR(32) NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenderIdentity VARCHAR(60) NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    HighestCompletedLevelOfEducationDescriptorId INT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    LoginId VARCHAR(120) NULL,
    MaidenName VARCHAR(75) NULL,
    MiddleName VARCHAR(75) NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    PersonId VARCHAR(32) NULL,
    PreferredFirstName VARCHAR(75) NULL,
    PreferredLastSurname VARCHAR(75) NULL,
    SexDescriptorId INT NULL,
    SourceSystemDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Contact_PK PRIMARY KEY (ContactUSI)
);
CREATE UNIQUE INDEX Contact_UI_ContactUniqueId ON edfi.Contact (ContactUniqueId) INCLUDE (ContactUSI);
ALTER TABLE edfi.Contact ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Contact ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Contact ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactAddress --
CREATE TABLE edfi.ContactAddress (
    ContactUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    Latitude VARCHAR(20) NULL,
    LocaleDescriptorId INT NULL,
    Longitude VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactAddress_PK PRIMARY KEY (ContactUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
);
ALTER TABLE edfi.ContactAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactAddressPeriod --
CREATE TABLE edfi.ContactAddressPeriod (
    ContactUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactAddressPeriod_PK PRIMARY KEY (ContactUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, BeginDate)
);
ALTER TABLE edfi.ContactAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactElectronicMail --
CREATE TABLE edfi.ContactElectronicMail (
    ContactUSI INT NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactElectronicMail_PK PRIMARY KEY (ContactUSI, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
);
ALTER TABLE edfi.ContactElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactIdentificationSystemDescriptor --
CREATE TABLE edfi.ContactIdentificationSystemDescriptor (
    ContactIdentificationSystemDescriptorId INT NOT NULL,
    CONSTRAINT ContactIdentificationSystemDescriptor_PK PRIMARY KEY (ContactIdentificationSystemDescriptorId)
);

-- Table edfi.ContactIdentity --
CREATE TABLE edfi.ContactIdentity (
    ContactIdentificationSystemDescriptorId INT NOT NULL,
    ContactUSI INT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(60) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ContactIdentity_PK PRIMARY KEY (ContactIdentificationSystemDescriptorId, ContactUSI, EducationOrganizationId)
);
ALTER TABLE edfi.ContactIdentity ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ContactIdentity ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ContactIdentity ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactInternationalAddress --
CREATE TABLE edfi.ContactInternationalAddress (
    ContactUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    BeginDate DATE NULL,
    CountryDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactInternationalAddress_PK PRIMARY KEY (ContactUSI, AddressTypeDescriptorId)
);
ALTER TABLE edfi.ContactInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactLanguage --
CREATE TABLE edfi.ContactLanguage (
    ContactUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactLanguage_PK PRIMARY KEY (ContactUSI, LanguageDescriptorId)
);
ALTER TABLE edfi.ContactLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactLanguageUse --
CREATE TABLE edfi.ContactLanguageUse (
    ContactUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactLanguageUse_PK PRIMARY KEY (ContactUSI, LanguageDescriptorId, LanguageUseDescriptorId)
);
ALTER TABLE edfi.ContactLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactOtherName --
CREATE TABLE edfi.ContactOtherName (
    ContactUSI INT NOT NULL,
    OtherNameTypeDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactOtherName_PK PRIMARY KEY (ContactUSI, OtherNameTypeDescriptorId)
);
ALTER TABLE edfi.ContactOtherName ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactPersonalIdentificationDocument --
CREATE TABLE edfi.ContactPersonalIdentificationDocument (
    ContactUSI INT NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactPersonalIdentificationDocument_PK PRIMARY KEY (ContactUSI, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.ContactPersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactTelephone --
CREATE TABLE edfi.ContactTelephone (
    ContactUSI INT NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ContactTelephone_PK PRIMARY KEY (ContactUSI, TelephoneNumber, TelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.ContactTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ContactTypeDescriptor --
CREATE TABLE edfi.ContactTypeDescriptor (
    ContactTypeDescriptorId INT NOT NULL,
    CONSTRAINT ContactTypeDescriptor_PK PRIMARY KEY (ContactTypeDescriptorId)
);

-- Table edfi.ContentClassDescriptor --
CREATE TABLE edfi.ContentClassDescriptor (
    ContentClassDescriptorId INT NOT NULL,
    CONSTRAINT ContentClassDescriptor_PK PRIMARY KEY (ContentClassDescriptorId)
);

-- Table edfi.ContinuationOfServicesReasonDescriptor --
CREATE TABLE edfi.ContinuationOfServicesReasonDescriptor (
    ContinuationOfServicesReasonDescriptorId INT NOT NULL,
    CONSTRAINT ContinuationOfServicesReasonDescriptor_PK PRIMARY KEY (ContinuationOfServicesReasonDescriptorId)
);

-- Table edfi.CostRateDescriptor --
CREATE TABLE edfi.CostRateDescriptor (
    CostRateDescriptorId INT NOT NULL,
    CONSTRAINT CostRateDescriptor_PK PRIMARY KEY (CostRateDescriptorId)
);

-- Table edfi.CoteachingStyleObservedDescriptor --
CREATE TABLE edfi.CoteachingStyleObservedDescriptor (
    CoteachingStyleObservedDescriptorId INT NOT NULL,
    CONSTRAINT CoteachingStyleObservedDescriptor_PK PRIMARY KEY (CoteachingStyleObservedDescriptorId)
);

-- Table edfi.CountryDescriptor --
CREATE TABLE edfi.CountryDescriptor (
    CountryDescriptorId INT NOT NULL,
    CONSTRAINT CountryDescriptor_PK PRIMARY KEY (CountryDescriptorId)
);

-- Table edfi.Course --
CREATE TABLE edfi.Course (
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    CareerPathwayDescriptorId INT NULL,
    CourseDefinedByDescriptorId INT NULL,
    CourseDescription VARCHAR(1024) NULL,
    CourseGPAApplicabilityDescriptorId INT NULL,
    CourseTitle VARCHAR(120) NOT NULL,
    DateCourseAdopted DATE NULL,
    HighSchoolCourseRequirement BOOLEAN NULL,
    MaxCompletionsForCredit INT NULL,
    MaximumAvailableCreditConversion DECIMAL(9, 2) NULL,
    MaximumAvailableCredits DECIMAL(9, 3) NULL,
    MaximumAvailableCreditTypeDescriptorId INT NULL,
    MinimumAvailableCreditConversion DECIMAL(9, 2) NULL,
    MinimumAvailableCredits DECIMAL(9, 3) NULL,
    MinimumAvailableCreditTypeDescriptorId INT NULL,
    NumberOfParts INT NOT NULL,
    TimeRequiredForCompletion INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Course_PK PRIMARY KEY (CourseCode, EducationOrganizationId)
);
ALTER TABLE edfi.Course ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Course ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Course ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseAcademicSubject --
CREATE TABLE edfi.CourseAcademicSubject (
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseAcademicSubject_PK PRIMARY KEY (CourseCode, EducationOrganizationId, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.CourseAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseAttemptResultDescriptor --
CREATE TABLE edfi.CourseAttemptResultDescriptor (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CONSTRAINT CourseAttemptResultDescriptor_PK PRIMARY KEY (CourseAttemptResultDescriptorId)
);

-- Table edfi.CourseCompetencyLevel --
CREATE TABLE edfi.CourseCompetencyLevel (
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    CompetencyLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseCompetencyLevel_PK PRIMARY KEY (CourseCode, EducationOrganizationId, CompetencyLevelDescriptorId)
);
ALTER TABLE edfi.CourseCompetencyLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseDefinedByDescriptor --
CREATE TABLE edfi.CourseDefinedByDescriptor (
    CourseDefinedByDescriptorId INT NOT NULL,
    CONSTRAINT CourseDefinedByDescriptor_PK PRIMARY KEY (CourseDefinedByDescriptorId)
);

-- Table edfi.CourseGPAApplicabilityDescriptor --
CREATE TABLE edfi.CourseGPAApplicabilityDescriptor (
    CourseGPAApplicabilityDescriptorId INT NOT NULL,
    CONSTRAINT CourseGPAApplicabilityDescriptor_PK PRIMARY KEY (CourseGPAApplicabilityDescriptorId)
);

-- Table edfi.CourseIdentificationCode --
CREATE TABLE edfi.CourseIdentificationCode (
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    CourseIdentificationSystemDescriptorId INT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(120) NULL,
    CourseCatalogURL VARCHAR(255) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseIdentificationCode_PK PRIMARY KEY (CourseCode, EducationOrganizationId, CourseIdentificationSystemDescriptorId)
);
ALTER TABLE edfi.CourseIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseIdentificationSystemDescriptor --
CREATE TABLE edfi.CourseIdentificationSystemDescriptor (
    CourseIdentificationSystemDescriptorId INT NOT NULL,
    CONSTRAINT CourseIdentificationSystemDescriptor_PK PRIMARY KEY (CourseIdentificationSystemDescriptorId)
);

-- Table edfi.CourseLearningStandard --
CREATE TABLE edfi.CourseLearningStandard (
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    LearningStandardId VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseLearningStandard_PK PRIMARY KEY (CourseCode, EducationOrganizationId, LearningStandardId)
);
ALTER TABLE edfi.CourseLearningStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseLevelCharacteristic --
CREATE TABLE edfi.CourseLevelCharacteristic (
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    CourseLevelCharacteristicDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseLevelCharacteristic_PK PRIMARY KEY (CourseCode, EducationOrganizationId, CourseLevelCharacteristicDescriptorId)
);
ALTER TABLE edfi.CourseLevelCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseLevelCharacteristicDescriptor --
CREATE TABLE edfi.CourseLevelCharacteristicDescriptor (
    CourseLevelCharacteristicDescriptorId INT NOT NULL,
    CONSTRAINT CourseLevelCharacteristicDescriptor_PK PRIMARY KEY (CourseLevelCharacteristicDescriptorId)
);

-- Table edfi.CourseOfferedGradeLevel --
CREATE TABLE edfi.CourseOfferedGradeLevel (
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseOfferedGradeLevel_PK PRIMARY KEY (CourseCode, EducationOrganizationId, GradeLevelDescriptorId)
);
ALTER TABLE edfi.CourseOfferedGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseOffering --
CREATE TABLE edfi.CourseOffering (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    InstructionalTimePlanned INT NULL,
    LocalCourseTitle VARCHAR(120) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CourseOffering_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName)
);
ALTER TABLE edfi.CourseOffering ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CourseOffering ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CourseOffering ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseOfferingCourseLevelCharacteristic --
CREATE TABLE edfi.CourseOfferingCourseLevelCharacteristic (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CourseLevelCharacteristicDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseOfferingCourseLevelCharacteristic_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName, CourseLevelCharacteristicDescriptorId)
);
ALTER TABLE edfi.CourseOfferingCourseLevelCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseOfferingCurriculumUsed --
CREATE TABLE edfi.CourseOfferingCurriculumUsed (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CurriculumUsedDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseOfferingCurriculumUsed_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName, CurriculumUsedDescriptorId)
);
ALTER TABLE edfi.CourseOfferingCurriculumUsed ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseOfferingOfferedGradeLevel --
CREATE TABLE edfi.CourseOfferingOfferedGradeLevel (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseOfferingOfferedGradeLevel_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName, GradeLevelDescriptorId)
);
ALTER TABLE edfi.CourseOfferingOfferedGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseRepeatCodeDescriptor --
CREATE TABLE edfi.CourseRepeatCodeDescriptor (
    CourseRepeatCodeDescriptorId INT NOT NULL,
    CONSTRAINT CourseRepeatCodeDescriptor_PK PRIMARY KEY (CourseRepeatCodeDescriptorId)
);

-- Table edfi.CourseTranscript --
CREATE TABLE edfi.CourseTranscript (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    AlternativeCourseTitle VARCHAR(120) NULL,
    AssigningOrganizationIdentificationCode VARCHAR(120) NULL,
    AttemptedCreditConversion DECIMAL(9, 2) NULL,
    AttemptedCredits DECIMAL(9, 3) NULL,
    AttemptedCreditTypeDescriptorId INT NULL,
    CourseCatalogURL VARCHAR(255) NULL,
    CourseRepeatCodeDescriptorId INT NULL,
    CourseTitle VARCHAR(120) NULL,
    EarnedCreditConversion DECIMAL(9, 2) NULL,
    EarnedCredits DECIMAL(9, 3) NULL,
    EarnedCreditTypeDescriptorId INT NULL,
    ExternalEducationOrganizationId BIGINT NULL,
    ExternalEducationOrganizationNameOfInstitution VARCHAR(75) NULL,
    FinalLetterGradeEarned VARCHAR(20) NULL,
    FinalNumericGradeEarned DECIMAL(9, 2) NULL,
    MethodCreditEarnedDescriptorId INT NULL,
    ResponsibleTeacherStaffUSI INT NULL,
    WhenTakenGradeLevelDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CourseTranscript_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
);
ALTER TABLE edfi.CourseTranscript ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CourseTranscript ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CourseTranscript ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseTranscriptAcademicSubject --
CREATE TABLE edfi.CourseTranscriptAcademicSubject (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseTranscriptAcademicSubject_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.CourseTranscriptAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseTranscriptAlternativeCourseIdentificationCode --
CREATE TABLE edfi.CourseTranscriptAlternativeCourseIdentificationCode (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CourseIdentificationSystemDescriptorId INT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(120) NULL,
    CourseCatalogURL VARCHAR(255) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseTranscriptAlternativeCourseIdentificationCode_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, CourseIdentificationSystemDescriptorId)
);
ALTER TABLE edfi.CourseTranscriptAlternativeCourseIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseTranscriptCourseProgram --
CREATE TABLE edfi.CourseTranscriptCourseProgram (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CourseProgramName VARCHAR(60) NOT NULL,
    CourseProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseTranscriptCourseProgram_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, CourseProgramName, CourseProgramTypeDescriptorId)
);
ALTER TABLE edfi.CourseTranscriptCourseProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseTranscriptCreditCategory --
CREATE TABLE edfi.CourseTranscriptCreditCategory (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreditCategoryDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseTranscriptCreditCategory_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, CreditCategoryDescriptorId)
);
ALTER TABLE edfi.CourseTranscriptCreditCategory ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseTranscriptEarnedAdditionalCredits --
CREATE TABLE edfi.CourseTranscriptEarnedAdditionalCredits (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    AdditionalCreditTypeDescriptorId INT NOT NULL,
    Credits DECIMAL(9, 3) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseTranscriptEarnedAdditionalCredits_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, AdditionalCreditTypeDescriptorId)
);
ALTER TABLE edfi.CourseTranscriptEarnedAdditionalCredits ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseTranscriptPartialCourseTranscriptAwards --
CREATE TABLE edfi.CourseTranscriptPartialCourseTranscriptAwards (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    AwardDate DATE NOT NULL,
    EarnedCredits DECIMAL(9, 3) NOT NULL,
    LetterGradeEarned VARCHAR(20) NULL,
    MethodCreditEarnedDescriptorId INT NULL,
    NumericGradeEarned VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseTranscriptPartialCourseTranscriptAwards_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, AwardDate)
);
ALTER TABLE edfi.CourseTranscriptPartialCourseTranscriptAwards ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CourseTranscriptSection --
CREATE TABLE edfi.CourseTranscriptSection (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CourseTranscriptSection_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, LocalCourseCode, SchoolId, SectionIdentifier, SessionName)
);
ALTER TABLE edfi.CourseTranscriptSection ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Credential --
CREATE TABLE edfi.Credential (
    CredentialIdentifier VARCHAR(120) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    BoardCertificationIndicator BOOLEAN NULL,
    CertificationIdentifier VARCHAR(120) NULL,
    CertificationNamespace VARCHAR(255) NULL,
    CertificationRouteDescriptorId INT NULL,
    CertificationTitle VARCHAR(64) NULL,
    CredentialFieldDescriptorId INT NULL,
    CredentialStatusDate DATE NULL,
    CredentialStatusDescriptorId INT NULL,
    CredentialTypeDescriptorId INT NOT NULL,
    EducatorRoleDescriptorId INT NULL,
    EffectiveDate DATE NULL,
    ExpirationDate DATE NULL,
    IssuanceDate DATE NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NULL,
    SourceSystemDescriptorId INT NULL,
    TeachingCredentialBasisDescriptorId INT NULL,
    TeachingCredentialDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Credential_PK PRIMARY KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
);
ALTER TABLE edfi.Credential ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Credential ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Credential ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CredentialAcademicSubject --
CREATE TABLE edfi.CredentialAcademicSubject (
    CredentialIdentifier VARCHAR(120) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CredentialAcademicSubject_PK PRIMARY KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.CredentialAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CredentialEndorsement --
CREATE TABLE edfi.CredentialEndorsement (
    CredentialIdentifier VARCHAR(120) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    CredentialEndorsement VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CredentialEndorsement_PK PRIMARY KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, CredentialEndorsement)
);
ALTER TABLE edfi.CredentialEndorsement ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CredentialEvent --
CREATE TABLE edfi.CredentialEvent (
    CredentialEventDate DATE NOT NULL,
    CredentialEventTypeDescriptorId INT NOT NULL,
    CredentialIdentifier VARCHAR(120) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    CredentialEventReason VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CredentialEvent_PK PRIMARY KEY (CredentialEventDate, CredentialEventTypeDescriptorId, CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
);
ALTER TABLE edfi.CredentialEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CredentialEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CredentialEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CredentialEventTypeDescriptor --
CREATE TABLE edfi.CredentialEventTypeDescriptor (
    CredentialEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT CredentialEventTypeDescriptor_PK PRIMARY KEY (CredentialEventTypeDescriptorId)
);

-- Table edfi.CredentialFieldDescriptor --
CREATE TABLE edfi.CredentialFieldDescriptor (
    CredentialFieldDescriptorId INT NOT NULL,
    CONSTRAINT CredentialFieldDescriptor_PK PRIMARY KEY (CredentialFieldDescriptorId)
);

-- Table edfi.CredentialGradeLevel --
CREATE TABLE edfi.CredentialGradeLevel (
    CredentialIdentifier VARCHAR(120) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CredentialGradeLevel_PK PRIMARY KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, GradeLevelDescriptorId)
);
ALTER TABLE edfi.CredentialGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CredentialStatusDescriptor --
CREATE TABLE edfi.CredentialStatusDescriptor (
    CredentialStatusDescriptorId INT NOT NULL,
    CONSTRAINT CredentialStatusDescriptor_PK PRIMARY KEY (CredentialStatusDescriptorId)
);

-- Table edfi.CredentialStudentAcademicRecord --
CREATE TABLE edfi.CredentialStudentAcademicRecord (
    CredentialIdentifier VARCHAR(120) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT CredentialStudentAcademicRecord_PK PRIMARY KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
);
ALTER TABLE edfi.CredentialStudentAcademicRecord ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CredentialTypeDescriptor --
CREATE TABLE edfi.CredentialTypeDescriptor (
    CredentialTypeDescriptorId INT NOT NULL,
    CONSTRAINT CredentialTypeDescriptor_PK PRIMARY KEY (CredentialTypeDescriptorId)
);

-- Table edfi.CreditCategoryDescriptor --
CREATE TABLE edfi.CreditCategoryDescriptor (
    CreditCategoryDescriptorId INT NOT NULL,
    CONSTRAINT CreditCategoryDescriptor_PK PRIMARY KEY (CreditCategoryDescriptorId)
);

-- Table edfi.CreditTypeDescriptor --
CREATE TABLE edfi.CreditTypeDescriptor (
    CreditTypeDescriptorId INT NOT NULL,
    CONSTRAINT CreditTypeDescriptor_PK PRIMARY KEY (CreditTypeDescriptorId)
);

-- Table edfi.CrisisEvent --
CREATE TABLE edfi.CrisisEvent (
    CrisisEventName VARCHAR(100) NOT NULL,
    CrisisDescription VARCHAR(1024) NULL,
    CrisisEndDate DATE NULL,
    CrisisStartDate DATE NULL,
    CrisisTypeDescriptorId INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CrisisEvent_PK PRIMARY KEY (CrisisEventName)
);
ALTER TABLE edfi.CrisisEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.CrisisEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.CrisisEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.CrisisTypeDescriptor --
CREATE TABLE edfi.CrisisTypeDescriptor (
    CrisisTypeDescriptorId INT NOT NULL,
    CONSTRAINT CrisisTypeDescriptor_PK PRIMARY KEY (CrisisTypeDescriptorId)
);

-- Table edfi.CTEProgramServiceDescriptor --
CREATE TABLE edfi.CTEProgramServiceDescriptor (
    CTEProgramServiceDescriptorId INT NOT NULL,
    CONSTRAINT CTEProgramServiceDescriptor_PK PRIMARY KEY (CTEProgramServiceDescriptorId)
);

-- Table edfi.CurriculumUsedDescriptor --
CREATE TABLE edfi.CurriculumUsedDescriptor (
    CurriculumUsedDescriptorId INT NOT NULL,
    CONSTRAINT CurriculumUsedDescriptor_PK PRIMARY KEY (CurriculumUsedDescriptorId)
);

-- Table edfi.DegreeDescriptor --
CREATE TABLE edfi.DegreeDescriptor (
    DegreeDescriptorId INT NOT NULL,
    CONSTRAINT DegreeDescriptor_PK PRIMARY KEY (DegreeDescriptorId)
);

-- Table edfi.DeliveryMethodDescriptor --
CREATE TABLE edfi.DeliveryMethodDescriptor (
    DeliveryMethodDescriptorId INT NOT NULL,
    CONSTRAINT DeliveryMethodDescriptor_PK PRIMARY KEY (DeliveryMethodDescriptorId)
);

-- Table edfi.Descriptor --
CREATE TABLE edfi.Descriptor (
    DescriptorId SERIAL NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CodeValue VARCHAR(50) NOT NULL,
    ShortDescription VARCHAR(75) NOT NULL,
    Description VARCHAR(1024) NULL,
    PriorDescriptorId INT NULL,
    EffectiveBeginDate DATE NULL,
    EffectiveEndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    Uri VARCHAR(306) GENERATED ALWAYS AS ( Namespace || '#' || CodeValue ) STORED,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Descriptor_PK PRIMARY KEY (DescriptorId),
    CONSTRAINT Descriptor_AK UNIQUE (Namespace, CodeValue)
);
ALTER TABLE edfi.Descriptor ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Descriptor ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Descriptor ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
CREATE UNIQUE INDEX UX_Descriptor_Uri ON edfi.Descriptor (Uri) INCLUDE (DescriptorId, Discriminator);

-- Table edfi.DescriptorMapping --
CREATE TABLE edfi.DescriptorMapping (
    MappedNamespace VARCHAR(255) NOT NULL,
    MappedValue VARCHAR(50) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    Value VARCHAR(50) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT DescriptorMapping_PK PRIMARY KEY (MappedNamespace, MappedValue, Namespace, Value)
);
ALTER TABLE edfi.DescriptorMapping ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.DescriptorMapping ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.DescriptorMapping ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DescriptorMappingModelEntity --
CREATE TABLE edfi.DescriptorMappingModelEntity (
    MappedNamespace VARCHAR(255) NOT NULL,
    MappedValue VARCHAR(50) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    Value VARCHAR(50) NOT NULL,
    ModelEntityDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT DescriptorMappingModelEntity_PK PRIMARY KEY (MappedNamespace, MappedValue, Namespace, Value, ModelEntityDescriptorId)
);
ALTER TABLE edfi.DescriptorMappingModelEntity ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DiagnosisDescriptor --
CREATE TABLE edfi.DiagnosisDescriptor (
    DiagnosisDescriptorId INT NOT NULL,
    CONSTRAINT DiagnosisDescriptor_PK PRIMARY KEY (DiagnosisDescriptorId)
);

-- Table edfi.DiplomaLevelDescriptor --
CREATE TABLE edfi.DiplomaLevelDescriptor (
    DiplomaLevelDescriptorId INT NOT NULL,
    CONSTRAINT DiplomaLevelDescriptor_PK PRIMARY KEY (DiplomaLevelDescriptorId)
);

-- Table edfi.DiplomaTypeDescriptor --
CREATE TABLE edfi.DiplomaTypeDescriptor (
    DiplomaTypeDescriptorId INT NOT NULL,
    CONSTRAINT DiplomaTypeDescriptor_PK PRIMARY KEY (DiplomaTypeDescriptorId)
);

-- Table edfi.DisabilityDescriptor --
CREATE TABLE edfi.DisabilityDescriptor (
    DisabilityDescriptorId INT NOT NULL,
    CONSTRAINT DisabilityDescriptor_PK PRIMARY KEY (DisabilityDescriptorId)
);

-- Table edfi.DisabilityDesignationDescriptor --
CREATE TABLE edfi.DisabilityDesignationDescriptor (
    DisabilityDesignationDescriptorId INT NOT NULL,
    CONSTRAINT DisabilityDesignationDescriptor_PK PRIMARY KEY (DisabilityDesignationDescriptorId)
);

-- Table edfi.DisabilityDeterminationSourceTypeDescriptor --
CREATE TABLE edfi.DisabilityDeterminationSourceTypeDescriptor (
    DisabilityDeterminationSourceTypeDescriptorId INT NOT NULL,
    CONSTRAINT DisabilityDeterminationSourceTypeDescriptor_PK PRIMARY KEY (DisabilityDeterminationSourceTypeDescriptorId)
);

-- Table edfi.DisciplineAction --
CREATE TABLE edfi.DisciplineAction (
    DisciplineActionIdentifier VARCHAR(36) NOT NULL,
    DisciplineDate DATE NOT NULL,
    StudentUSI INT NOT NULL,
    ActualDisciplineActionLength DECIMAL(5, 2) NULL,
    AssignmentSchoolId BIGINT NULL,
    DisciplineActionLength DECIMAL(5, 2) NULL,
    DisciplineActionLengthDifferenceReasonDescriptorId INT NULL,
    IEPPlacementMeetingIndicator BOOLEAN NULL,
    RelatedToZeroTolerancePolicy BOOLEAN NULL,
    ResponsibilitySchoolId BIGINT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT DisciplineAction_PK PRIMARY KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI)
);
ALTER TABLE edfi.DisciplineAction ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.DisciplineAction ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.DisciplineAction ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DisciplineActionDiscipline --
CREATE TABLE edfi.DisciplineActionDiscipline (
    DisciplineActionIdentifier VARCHAR(36) NOT NULL,
    DisciplineDate DATE NOT NULL,
    StudentUSI INT NOT NULL,
    DisciplineDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT DisciplineActionDiscipline_PK PRIMARY KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI, DisciplineDescriptorId)
);
ALTER TABLE edfi.DisciplineActionDiscipline ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DisciplineActionLengthDifferenceReasonDescriptor --
CREATE TABLE edfi.DisciplineActionLengthDifferenceReasonDescriptor (
    DisciplineActionLengthDifferenceReasonDescriptorId INT NOT NULL,
    CONSTRAINT DisciplineActionLengthDifferenceReasonDescriptor_PK PRIMARY KEY (DisciplineActionLengthDifferenceReasonDescriptorId)
);

-- Table edfi.DisciplineActionStaff --
CREATE TABLE edfi.DisciplineActionStaff (
    DisciplineActionIdentifier VARCHAR(36) NOT NULL,
    DisciplineDate DATE NOT NULL,
    StudentUSI INT NOT NULL,
    StaffUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT DisciplineActionStaff_PK PRIMARY KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI, StaffUSI)
);
ALTER TABLE edfi.DisciplineActionStaff ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation --
CREATE TABLE edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation (
    DisciplineActionIdentifier VARCHAR(36) NOT NULL,
    DisciplineDate DATE NOT NULL,
    StudentUSI INT NOT NULL,
    BehaviorDescriptorId INT NOT NULL,
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT DisciplineActionStudentDisciplineIncidentBehaviorAssociation_PK PRIMARY KEY (DisciplineActionIdentifier, DisciplineDate, StudentUSI, BehaviorDescriptorId, IncidentIdentifier, SchoolId)
);
ALTER TABLE edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DisciplineDescriptor --
CREATE TABLE edfi.DisciplineDescriptor (
    DisciplineDescriptorId INT NOT NULL,
    CONSTRAINT DisciplineDescriptor_PK PRIMARY KEY (DisciplineDescriptorId)
);

-- Table edfi.DisciplineIncident --
CREATE TABLE edfi.DisciplineIncident (
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    CaseNumber VARCHAR(20) NULL,
    IncidentCost MONEY NULL,
    IncidentDate DATE NOT NULL,
    IncidentDescription VARCHAR(1024) NULL,
    IncidentLocationDescriptorId INT NULL,
    IncidentTime TIME NULL,
    ReportedToLawEnforcement BOOLEAN NULL,
    ReporterDescriptionDescriptorId INT NULL,
    ReporterName VARCHAR(75) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT DisciplineIncident_PK PRIMARY KEY (IncidentIdentifier, SchoolId)
);
ALTER TABLE edfi.DisciplineIncident ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.DisciplineIncident ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.DisciplineIncident ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DisciplineIncidentBehavior --
CREATE TABLE edfi.DisciplineIncidentBehavior (
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    BehaviorDescriptorId INT NOT NULL,
    BehaviorDetailedDescription VARCHAR(1024) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT DisciplineIncidentBehavior_PK PRIMARY KEY (IncidentIdentifier, SchoolId, BehaviorDescriptorId)
);
ALTER TABLE edfi.DisciplineIncidentBehavior ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DisciplineIncidentExternalParticipant --
CREATE TABLE edfi.DisciplineIncidentExternalParticipant (
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    DisciplineIncidentParticipationCodeDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT DisciplineIncidentExternalParticipant_PK PRIMARY KEY (IncidentIdentifier, SchoolId, DisciplineIncidentParticipationCodeDescriptorId, FirstName, LastSurname)
);
ALTER TABLE edfi.DisciplineIncidentExternalParticipant ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DisciplineIncidentParticipationCodeDescriptor --
CREATE TABLE edfi.DisciplineIncidentParticipationCodeDescriptor (
    DisciplineIncidentParticipationCodeDescriptorId INT NOT NULL,
    CONSTRAINT DisciplineIncidentParticipationCodeDescriptor_PK PRIMARY KEY (DisciplineIncidentParticipationCodeDescriptorId)
);

-- Table edfi.DisciplineIncidentWeapon --
CREATE TABLE edfi.DisciplineIncidentWeapon (
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    WeaponDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT DisciplineIncidentWeapon_PK PRIMARY KEY (IncidentIdentifier, SchoolId, WeaponDescriptorId)
);
ALTER TABLE edfi.DisciplineIncidentWeapon ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.DisplacedStudentStatusDescriptor --
CREATE TABLE edfi.DisplacedStudentStatusDescriptor (
    DisplacedStudentStatusDescriptorId INT NOT NULL,
    CONSTRAINT DisplacedStudentStatusDescriptor_PK PRIMARY KEY (DisplacedStudentStatusDescriptorId)
);

-- Table edfi.DualCreditInstitutionDescriptor --
CREATE TABLE edfi.DualCreditInstitutionDescriptor (
    DualCreditInstitutionDescriptorId INT NOT NULL,
    CONSTRAINT DualCreditInstitutionDescriptor_PK PRIMARY KEY (DualCreditInstitutionDescriptorId)
);

-- Table edfi.DualCreditTypeDescriptor --
CREATE TABLE edfi.DualCreditTypeDescriptor (
    DualCreditTypeDescriptorId INT NOT NULL,
    CONSTRAINT DualCreditTypeDescriptor_PK PRIMARY KEY (DualCreditTypeDescriptorId)
);

-- Table edfi.EconomicDisadvantageDescriptor --
CREATE TABLE edfi.EconomicDisadvantageDescriptor (
    EconomicDisadvantageDescriptorId INT NOT NULL,
    CONSTRAINT EconomicDisadvantageDescriptor_PK PRIMARY KEY (EconomicDisadvantageDescriptorId)
);

-- Table edfi.EducationalEnvironmentDescriptor --
CREATE TABLE edfi.EducationalEnvironmentDescriptor (
    EducationalEnvironmentDescriptorId INT NOT NULL,
    CONSTRAINT EducationalEnvironmentDescriptor_PK PRIMARY KEY (EducationalEnvironmentDescriptorId)
);

-- Table edfi.EducationContent --
CREATE TABLE edfi.EducationContent (
    ContentIdentifier VARCHAR(225) NOT NULL,
    AdditionalAuthorsIndicator BOOLEAN NULL,
    ContentClassDescriptorId INT NULL,
    Cost MONEY NULL,
    CostRateDescriptorId INT NULL,
    Description VARCHAR(1024) NULL,
    InteractivityStyleDescriptorId INT NULL,
    LearningResourceMetadataURI VARCHAR(255) NULL,
    LearningStandardId VARCHAR(60) NULL,
    Namespace VARCHAR(255) NOT NULL,
    PublicationDate DATE NULL,
    PublicationYear SMALLINT NULL,
    Publisher VARCHAR(50) NULL,
    ShortDescription VARCHAR(75) NULL,
    TimeRequired VARCHAR(30) NULL,
    UseRightsURL VARCHAR(255) NULL,
    Version VARCHAR(10) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EducationContent_PK PRIMARY KEY (ContentIdentifier)
);
ALTER TABLE edfi.EducationContent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EducationContent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EducationContent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationContentAppropriateGradeLevel --
CREATE TABLE edfi.EducationContentAppropriateGradeLevel (
    ContentIdentifier VARCHAR(225) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationContentAppropriateGradeLevel_PK PRIMARY KEY (ContentIdentifier, GradeLevelDescriptorId)
);
ALTER TABLE edfi.EducationContentAppropriateGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationContentAppropriateSex --
CREATE TABLE edfi.EducationContentAppropriateSex (
    ContentIdentifier VARCHAR(225) NOT NULL,
    SexDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationContentAppropriateSex_PK PRIMARY KEY (ContentIdentifier, SexDescriptorId)
);
ALTER TABLE edfi.EducationContentAppropriateSex ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationContentAuthor --
CREATE TABLE edfi.EducationContentAuthor (
    ContentIdentifier VARCHAR(225) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationContentAuthor_PK PRIMARY KEY (ContentIdentifier, Author)
);
ALTER TABLE edfi.EducationContentAuthor ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationContentDerivativeSourceEducationContent --
CREATE TABLE edfi.EducationContentDerivativeSourceEducationContent (
    ContentIdentifier VARCHAR(225) NOT NULL,
    DerivativeSourceContentIdentifier VARCHAR(225) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationContentDerivativeSourceEducationContent_PK PRIMARY KEY (ContentIdentifier, DerivativeSourceContentIdentifier)
);
ALTER TABLE edfi.EducationContentDerivativeSourceEducationContent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationContentDerivativeSourceLearningResourceMetadataURI --
CREATE TABLE edfi.EducationContentDerivativeSourceLearningResourceMetadataURI (
    ContentIdentifier VARCHAR(225) NOT NULL,
    DerivativeSourceLearningResourceMetadataURI VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationContentDerivativeSourceLearningResourceMetadataURI_PK PRIMARY KEY (ContentIdentifier, DerivativeSourceLearningResourceMetadataURI)
);
ALTER TABLE edfi.EducationContentDerivativeSourceLearningResourceMetadataURI ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationContentDerivativeSourceURI --
CREATE TABLE edfi.EducationContentDerivativeSourceURI (
    ContentIdentifier VARCHAR(225) NOT NULL,
    DerivativeSourceURI VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationContentDerivativeSourceURI_PK PRIMARY KEY (ContentIdentifier, DerivativeSourceURI)
);
ALTER TABLE edfi.EducationContentDerivativeSourceURI ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationContentLanguage --
CREATE TABLE edfi.EducationContentLanguage (
    ContentIdentifier VARCHAR(225) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationContentLanguage_PK PRIMARY KEY (ContentIdentifier, LanguageDescriptorId)
);
ALTER TABLE edfi.EducationContentLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganization --
CREATE TABLE edfi.EducationOrganization (
    EducationOrganizationId BIGINT NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    OperationalStatusDescriptorId INT NULL,
    ShortNameOfInstitution VARCHAR(75) NULL,
    WebSite VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EducationOrganization_PK PRIMARY KEY (EducationOrganizationId)
);
ALTER TABLE edfi.EducationOrganization ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EducationOrganization ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EducationOrganization ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationAddress --
CREATE TABLE edfi.EducationOrganizationAddress (
    EducationOrganizationId BIGINT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    Latitude VARCHAR(20) NULL,
    LocaleDescriptorId INT NULL,
    Longitude VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationOrganizationAddress_PK PRIMARY KEY (EducationOrganizationId, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
);
ALTER TABLE edfi.EducationOrganizationAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationAddressPeriod --
CREATE TABLE edfi.EducationOrganizationAddressPeriod (
    EducationOrganizationId BIGINT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationOrganizationAddressPeriod_PK PRIMARY KEY (EducationOrganizationId, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, BeginDate)
);
ALTER TABLE edfi.EducationOrganizationAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationAssociationTypeDescriptor --
CREATE TABLE edfi.EducationOrganizationAssociationTypeDescriptor (
    EducationOrganizationAssociationTypeDescriptorId INT NOT NULL,
    CONSTRAINT EducationOrganizationAssociationTypeDescriptor_PK PRIMARY KEY (EducationOrganizationAssociationTypeDescriptorId)
);

-- Table edfi.EducationOrganizationCategory --
CREATE TABLE edfi.EducationOrganizationCategory (
    EducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationCategoryDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationOrganizationCategory_PK PRIMARY KEY (EducationOrganizationId, EducationOrganizationCategoryDescriptorId)
);
ALTER TABLE edfi.EducationOrganizationCategory ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationCategoryDescriptor --
CREATE TABLE edfi.EducationOrganizationCategoryDescriptor (
    EducationOrganizationCategoryDescriptorId INT NOT NULL,
    CONSTRAINT EducationOrganizationCategoryDescriptor_PK PRIMARY KEY (EducationOrganizationCategoryDescriptorId)
);

-- Table edfi.EducationOrganizationIdentificationCode --
CREATE TABLE edfi.EducationOrganizationIdentificationCode (
    EducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationIdentificationSystemDescriptorId INT NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationOrganizationIdentificationCode_PK PRIMARY KEY (EducationOrganizationId, EducationOrganizationIdentificationSystemDescriptorId)
);
ALTER TABLE edfi.EducationOrganizationIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationIdentificationSystemDescriptor --
CREATE TABLE edfi.EducationOrganizationIdentificationSystemDescriptor (
    EducationOrganizationIdentificationSystemDescriptorId INT NOT NULL,
    CONSTRAINT EducationOrganizationIdentificationSystemDescriptor_PK PRIMARY KEY (EducationOrganizationIdentificationSystemDescriptorId)
);

-- Table edfi.EducationOrganizationIdentity --
CREATE TABLE edfi.EducationOrganizationIdentity (
    EducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationIdentificationSystemDescriptorId INT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(60) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EducationOrganizationIdentity_PK PRIMARY KEY (EducationOrganizationId, EducationOrganizationIdentificationSystemDescriptorId)
);
ALTER TABLE edfi.EducationOrganizationIdentity ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EducationOrganizationIdentity ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EducationOrganizationIdentity ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationIndicator --
CREATE TABLE edfi.EducationOrganizationIndicator (
    EducationOrganizationId BIGINT NOT NULL,
    IndicatorDescriptorId INT NOT NULL,
    DesignatedBy VARCHAR(60) NULL,
    IndicatorGroupDescriptorId INT NULL,
    IndicatorLevelDescriptorId INT NULL,
    IndicatorValue VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationOrganizationIndicator_PK PRIMARY KEY (EducationOrganizationId, IndicatorDescriptorId)
);
ALTER TABLE edfi.EducationOrganizationIndicator ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationIndicatorPeriod --
CREATE TABLE edfi.EducationOrganizationIndicatorPeriod (
    EducationOrganizationId BIGINT NOT NULL,
    IndicatorDescriptorId INT NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationOrganizationIndicatorPeriod_PK PRIMARY KEY (EducationOrganizationId, IndicatorDescriptorId, BeginDate)
);
ALTER TABLE edfi.EducationOrganizationIndicatorPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationInstitutionTelephone --
CREATE TABLE edfi.EducationOrganizationInstitutionTelephone (
    EducationOrganizationId BIGINT NOT NULL,
    InstitutionTelephoneNumberTypeDescriptorId INT NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationOrganizationInstitutionTelephone_PK PRIMARY KEY (EducationOrganizationId, InstitutionTelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.EducationOrganizationInstitutionTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationInternationalAddress --
CREATE TABLE edfi.EducationOrganizationInternationalAddress (
    EducationOrganizationId BIGINT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    BeginDate DATE NULL,
    CountryDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducationOrganizationInternationalAddress_PK PRIMARY KEY (EducationOrganizationId, AddressTypeDescriptorId)
);
ALTER TABLE edfi.EducationOrganizationInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationInterventionPrescriptionAssociation --
CREATE TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionEducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EducationOrganizationInterventionPrescriptionAssociation_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode)
);
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationNetwork --
CREATE TABLE edfi.EducationOrganizationNetwork (
    EducationOrganizationNetworkId BIGINT NOT NULL,
    NetworkPurposeDescriptorId INT NOT NULL,
    CONSTRAINT EducationOrganizationNetwork_PK PRIMARY KEY (EducationOrganizationNetworkId)
);

-- Table edfi.EducationOrganizationNetworkAssociation --
CREATE TABLE edfi.EducationOrganizationNetworkAssociation (
    EducationOrganizationNetworkId BIGINT NOT NULL,
    MemberEducationOrganizationId BIGINT NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EducationOrganizationNetworkAssociation_PK PRIMARY KEY (EducationOrganizationNetworkId, MemberEducationOrganizationId)
);
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EducationOrganizationNetworkAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationOrganizationPeerAssociation --
CREATE TABLE edfi.EducationOrganizationPeerAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    PeerEducationOrganizationId BIGINT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EducationOrganizationPeerAssociation_PK PRIMARY KEY (EducationOrganizationId, PeerEducationOrganizationId)
);
ALTER TABLE edfi.EducationOrganizationPeerAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EducationOrganizationPeerAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EducationOrganizationPeerAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducationPlanDescriptor --
CREATE TABLE edfi.EducationPlanDescriptor (
    EducationPlanDescriptorId INT NOT NULL,
    CONSTRAINT EducationPlanDescriptor_PK PRIMARY KEY (EducationPlanDescriptorId)
);

-- Table edfi.EducationServiceCenter --
CREATE TABLE edfi.EducationServiceCenter (
    EducationServiceCenterId BIGINT NOT NULL,
    StateEducationAgencyId BIGINT NULL,
    CONSTRAINT EducationServiceCenter_PK PRIMARY KEY (EducationServiceCenterId)
);

-- Table edfi.EducatorPreparationProgram --
CREATE TABLE edfi.EducatorPreparationProgram (
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    AccreditationStatusDescriptorId INT NULL,
    ProgramId VARCHAR(20) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EducatorPreparationProgram_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.EducatorPreparationProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EducatorPreparationProgram ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EducatorPreparationProgram ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducatorPreparationProgramGradeLevel --
CREATE TABLE edfi.EducatorPreparationProgramGradeLevel (
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EducatorPreparationProgramGradeLevel_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, GradeLevelDescriptorId)
);
ALTER TABLE edfi.EducatorPreparationProgramGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EducatorRoleDescriptor --
CREATE TABLE edfi.EducatorRoleDescriptor (
    EducatorRoleDescriptorId INT NOT NULL,
    CONSTRAINT EducatorRoleDescriptor_PK PRIMARY KEY (EducatorRoleDescriptorId)
);

-- Table edfi.ElectronicMailTypeDescriptor --
CREATE TABLE edfi.ElectronicMailTypeDescriptor (
    ElectronicMailTypeDescriptorId INT NOT NULL,
    CONSTRAINT ElectronicMailTypeDescriptor_PK PRIMARY KEY (ElectronicMailTypeDescriptorId)
);

-- Table edfi.EligibilityDelayReasonDescriptor --
CREATE TABLE edfi.EligibilityDelayReasonDescriptor (
    EligibilityDelayReasonDescriptorId INT NOT NULL,
    CONSTRAINT EligibilityDelayReasonDescriptor_PK PRIMARY KEY (EligibilityDelayReasonDescriptorId)
);

-- Table edfi.EligibilityEvaluationTypeDescriptor --
CREATE TABLE edfi.EligibilityEvaluationTypeDescriptor (
    EligibilityEvaluationTypeDescriptorId INT NOT NULL,
    CONSTRAINT EligibilityEvaluationTypeDescriptor_PK PRIMARY KEY (EligibilityEvaluationTypeDescriptorId)
);

-- Table edfi.EmploymentStatusDescriptor --
CREATE TABLE edfi.EmploymentStatusDescriptor (
    EmploymentStatusDescriptorId INT NOT NULL,
    CONSTRAINT EmploymentStatusDescriptor_PK PRIMARY KEY (EmploymentStatusDescriptorId)
);

-- Table edfi.EnglishLanguageExamDescriptor --
CREATE TABLE edfi.EnglishLanguageExamDescriptor (
    EnglishLanguageExamDescriptorId INT NOT NULL,
    CONSTRAINT EnglishLanguageExamDescriptor_PK PRIMARY KEY (EnglishLanguageExamDescriptorId)
);

-- Table edfi.EnrollmentTypeDescriptor --
CREATE TABLE edfi.EnrollmentTypeDescriptor (
    EnrollmentTypeDescriptorId INT NOT NULL,
    CONSTRAINT EnrollmentTypeDescriptor_PK PRIMARY KEY (EnrollmentTypeDescriptorId)
);

-- Table edfi.EntryGradeLevelReasonDescriptor --
CREATE TABLE edfi.EntryGradeLevelReasonDescriptor (
    EntryGradeLevelReasonDescriptorId INT NOT NULL,
    CONSTRAINT EntryGradeLevelReasonDescriptor_PK PRIMARY KEY (EntryGradeLevelReasonDescriptorId)
);

-- Table edfi.EntryTypeDescriptor --
CREATE TABLE edfi.EntryTypeDescriptor (
    EntryTypeDescriptorId INT NOT NULL,
    CONSTRAINT EntryTypeDescriptor_PK PRIMARY KEY (EntryTypeDescriptorId)
);

-- Table edfi.EPPDegreeTypeDescriptor --
CREATE TABLE edfi.EPPDegreeTypeDescriptor (
    EPPDegreeTypeDescriptorId INT NOT NULL,
    CONSTRAINT EPPDegreeTypeDescriptor_PK PRIMARY KEY (EPPDegreeTypeDescriptorId)
);

-- Table edfi.EPPProgramPathwayDescriptor --
CREATE TABLE edfi.EPPProgramPathwayDescriptor (
    EPPProgramPathwayDescriptorId INT NOT NULL,
    CONSTRAINT EPPProgramPathwayDescriptor_PK PRIMARY KEY (EPPProgramPathwayDescriptorId)
);

-- Table edfi.Evaluation --
CREATE TABLE edfi.Evaluation (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationDescription VARCHAR(255) NULL,
    EvaluationTypeDescriptorId INT NULL,
    InterRaterReliabilityScore INT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Evaluation_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
);
ALTER TABLE edfi.Evaluation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Evaluation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Evaluation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationDelayReasonDescriptor --
CREATE TABLE edfi.EvaluationDelayReasonDescriptor (
    EvaluationDelayReasonDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationDelayReasonDescriptor_PK PRIMARY KEY (EvaluationDelayReasonDescriptorId)
);

-- Table edfi.EvaluationElement --
CREATE TABLE edfi.EvaluationElement (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationTypeDescriptorId INT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    SortOrder INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationElement_PK PRIMARY KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
);
ALTER TABLE edfi.EvaluationElement ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EvaluationElement ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EvaluationElement ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationElementRating --
CREATE TABLE edfi.EvaluationElementRating (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
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
    AreaOfRefinement VARCHAR(1024) NULL,
    AreaOfReinforcement VARCHAR(1024) NULL,
    Comments VARCHAR(1024) NULL,
    EvaluationElementRatingLevelDescriptorId INT NULL,
    Feedback VARCHAR(2048) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationElementRating_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
);
ALTER TABLE edfi.EvaluationElementRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EvaluationElementRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EvaluationElementRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationElementRatingLevel --
CREATE TABLE edfi.EvaluationElementRatingLevel (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationElementRatingLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, EvaluationRatingLevelDescriptorId)
);
ALTER TABLE edfi.EvaluationElementRatingLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationElementRatingLevelDescriptor --
CREATE TABLE edfi.EvaluationElementRatingLevelDescriptor (
    EvaluationElementRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationElementRatingLevelDescriptor_PK PRIMARY KEY (EvaluationElementRatingLevelDescriptorId)
);

-- Table edfi.EvaluationElementRatingResult --
CREATE TABLE edfi.EvaluationElementRatingResult (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
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
    NumericRating DECIMAL(6, 3) NOT NULL,
    RatingResultTitle VARCHAR(50) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationElementRatingResult_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, NumericRating, RatingResultTitle)
);
ALTER TABLE edfi.EvaluationElementRatingResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationObjective --
CREATE TABLE edfi.EvaluationObjective (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationObjectiveDescription VARCHAR(255) NULL,
    EvaluationTypeDescriptorId INT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    SortOrder INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationObjective_PK PRIMARY KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
);
ALTER TABLE edfi.EvaluationObjective ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EvaluationObjective ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EvaluationObjective ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationObjectiveRating --
CREATE TABLE edfi.EvaluationObjectiveRating (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    Comments VARCHAR(1024) NULL,
    ObjectiveRatingLevelDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationObjectiveRating_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
);
ALTER TABLE edfi.EvaluationObjectiveRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EvaluationObjectiveRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EvaluationObjectiveRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationObjectiveRatingLevel --
CREATE TABLE edfi.EvaluationObjectiveRatingLevel (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationObjectiveRatingLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, EvaluationRatingLevelDescriptorId)
);
ALTER TABLE edfi.EvaluationObjectiveRatingLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationObjectiveRatingResult --
CREATE TABLE edfi.EvaluationObjectiveRatingResult (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    NumericRating DECIMAL(6, 3) NOT NULL,
    RatingResultTitle VARCHAR(50) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationObjectiveRatingResult_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, NumericRating, RatingResultTitle)
);
ALTER TABLE edfi.EvaluationObjectiveRatingResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationPeriodDescriptor --
CREATE TABLE edfi.EvaluationPeriodDescriptor (
    EvaluationPeriodDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationPeriodDescriptor_PK PRIMARY KEY (EvaluationPeriodDescriptorId)
);

-- Table edfi.EvaluationRating --
CREATE TABLE edfi.EvaluationRating (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ActualDuration INT NULL,
    Comments VARCHAR(1024) NULL,
    EvaluationRatingLevelDescriptorId INT NULL,
    EvaluationRatingStatusDescriptorId INT NULL,
    LocalCourseCode VARCHAR(60) NULL,
    SchoolId BIGINT NULL,
    SectionIdentifier VARCHAR(255) NULL,
    SessionName VARCHAR(120) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationRating_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
);
ALTER TABLE edfi.EvaluationRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EvaluationRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EvaluationRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationRatingLevel --
CREATE TABLE edfi.EvaluationRatingLevel (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationRatingLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, EvaluationRatingLevelDescriptorId)
);
ALTER TABLE edfi.EvaluationRatingLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationRatingLevelDescriptor --
CREATE TABLE edfi.EvaluationRatingLevelDescriptor (
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationRatingLevelDescriptor_PK PRIMARY KEY (EvaluationRatingLevelDescriptorId)
);

-- Table edfi.EvaluationRatingResult --
CREATE TABLE edfi.EvaluationRatingResult (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    NumericRating DECIMAL(6, 3) NOT NULL,
    RatingResultTitle VARCHAR(50) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationRatingResult_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, NumericRating, RatingResultTitle)
);
ALTER TABLE edfi.EvaluationRatingResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationRatingReviewer --
CREATE TABLE edfi.EvaluationRatingReviewer (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    ReviewerPersonId VARCHAR(32) NULL,
    ReviewerSourceSystemDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationRatingReviewer_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, FirstName, LastSurname)
);
ALTER TABLE edfi.EvaluationRatingReviewer ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationRatingReviewerReceivedTraining --
CREATE TABLE edfi.EvaluationRatingReviewerReceivedTraining (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    InterRaterReliabilityScore INT NULL,
    ReceivedTrainingDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT EvaluationRatingReviewerReceivedTraining_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, FirstName, LastSurname)
);
ALTER TABLE edfi.EvaluationRatingReviewerReceivedTraining ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationRatingStatusDescriptor --
CREATE TABLE edfi.EvaluationRatingStatusDescriptor (
    EvaluationRatingStatusDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationRatingStatusDescriptor_PK PRIMARY KEY (EvaluationRatingStatusDescriptorId)
);

-- Table edfi.EvaluationRubricDimension --
CREATE TABLE edfi.EvaluationRubricDimension (
    EvaluationRubricRating INT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationElementTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    EvaluationCriterionDescription VARCHAR(1024) NOT NULL,
    EvaluationRubricRatingLevelDescriptorId INT NULL,
    RubricDimensionSortOrder INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EvaluationRubricDimension_PK PRIMARY KEY (EvaluationRubricRating, ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.EvaluationRubricDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.EvaluationRubricDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.EvaluationRubricDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.EvaluationTypeDescriptor --
CREATE TABLE edfi.EvaluationTypeDescriptor (
    EvaluationTypeDescriptorId INT NOT NULL,
    CONSTRAINT EvaluationTypeDescriptor_PK PRIMARY KEY (EvaluationTypeDescriptorId)
);

-- Table edfi.EventCircumstanceDescriptor --
CREATE TABLE edfi.EventCircumstanceDescriptor (
    EventCircumstanceDescriptorId INT NOT NULL,
    CONSTRAINT EventCircumstanceDescriptor_PK PRIMARY KEY (EventCircumstanceDescriptorId)
);

-- Table edfi.ExitWithdrawTypeDescriptor --
CREATE TABLE edfi.ExitWithdrawTypeDescriptor (
    ExitWithdrawTypeDescriptorId INT NOT NULL,
    CONSTRAINT ExitWithdrawTypeDescriptor_PK PRIMARY KEY (ExitWithdrawTypeDescriptorId)
);

-- Table edfi.FederalLocaleCodeDescriptor --
CREATE TABLE edfi.FederalLocaleCodeDescriptor (
    FederalLocaleCodeDescriptorId INT NOT NULL,
    CONSTRAINT FederalLocaleCodeDescriptor_PK PRIMARY KEY (FederalLocaleCodeDescriptorId)
);

-- Table edfi.FeederSchoolAssociation --
CREATE TABLE edfi.FeederSchoolAssociation (
    BeginDate DATE NOT NULL,
    FeederSchoolId BIGINT NOT NULL,
    SchoolId BIGINT NOT NULL,
    EndDate DATE NULL,
    FeederRelationshipDescription VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT FeederSchoolAssociation_PK PRIMARY KEY (BeginDate, FeederSchoolId, SchoolId)
);
ALTER TABLE edfi.FeederSchoolAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.FeederSchoolAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.FeederSchoolAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FieldworkExperience --
CREATE TABLE edfi.FieldworkExperience (
    BeginDate DATE NOT NULL,
    FieldworkIdentifier VARCHAR(64) NOT NULL,
    StudentUSI INT NOT NULL,
    EducationOrganizationId BIGINT NULL,
    EndDate DATE NULL,
    FieldworkTypeDescriptorId INT NOT NULL,
    HoursCompleted DECIMAL(5, 2) NULL,
    ProgramName VARCHAR(255) NULL,
    ProgramTypeDescriptorId INT NULL,
    SchoolId BIGINT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT FieldworkExperience_PK PRIMARY KEY (BeginDate, FieldworkIdentifier, StudentUSI)
);
ALTER TABLE edfi.FieldworkExperience ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.FieldworkExperience ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.FieldworkExperience ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FieldworkExperienceCoteaching --
CREATE TABLE edfi.FieldworkExperienceCoteaching (
    BeginDate DATE NOT NULL,
    FieldworkIdentifier VARCHAR(64) NOT NULL,
    StudentUSI INT NOT NULL,
    CoteachingBeginDate DATE NOT NULL,
    CoteachingEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT FieldworkExperienceCoteaching_PK PRIMARY KEY (BeginDate, FieldworkIdentifier, StudentUSI)
);
ALTER TABLE edfi.FieldworkExperienceCoteaching ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FieldworkExperienceSectionAssociation --
CREATE TABLE edfi.FieldworkExperienceSectionAssociation (
    BeginDate DATE NOT NULL,
    FieldworkIdentifier VARCHAR(64) NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT FieldworkExperienceSectionAssociation_PK PRIMARY KEY (BeginDate, FieldworkIdentifier, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
);
ALTER TABLE edfi.FieldworkExperienceSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.FieldworkExperienceSectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.FieldworkExperienceSectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FieldworkTypeDescriptor --
CREATE TABLE edfi.FieldworkTypeDescriptor (
    FieldworkTypeDescriptorId INT NOT NULL,
    CONSTRAINT FieldworkTypeDescriptor_PK PRIMARY KEY (FieldworkTypeDescriptorId)
);

-- Table edfi.FinancialAid --
CREATE TABLE edfi.FinancialAid (
    AidTypeDescriptorId INT NOT NULL,
    BeginDate DATE NOT NULL,
    StudentUSI INT NOT NULL,
    AidAmount DECIMAL(19, 4) NULL,
    AidConditionDescription VARCHAR(1024) NULL,
    EndDate DATE NULL,
    PellGrantRecipient BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT FinancialAid_PK PRIMARY KEY (AidTypeDescriptorId, BeginDate, StudentUSI)
);
ALTER TABLE edfi.FinancialAid ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.FinancialAid ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.FinancialAid ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FinancialCollectionDescriptor --
CREATE TABLE edfi.FinancialCollectionDescriptor (
    FinancialCollectionDescriptorId INT NOT NULL,
    CONSTRAINT FinancialCollectionDescriptor_PK PRIMARY KEY (FinancialCollectionDescriptorId)
);

-- Table edfi.FunctionDimension --
CREATE TABLE edfi.FunctionDimension (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    CodeName VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT FunctionDimension_PK PRIMARY KEY (Code, FiscalYear)
);
ALTER TABLE edfi.FunctionDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.FunctionDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.FunctionDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FunctionDimensionReportingTag --
CREATE TABLE edfi.FunctionDimensionReportingTag (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT FunctionDimensionReportingTag_PK PRIMARY KEY (Code, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.FunctionDimensionReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FundDimension --
CREATE TABLE edfi.FundDimension (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    CodeName VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT FundDimension_PK PRIMARY KEY (Code, FiscalYear)
);
ALTER TABLE edfi.FundDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.FundDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.FundDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FundDimensionReportingTag --
CREATE TABLE edfi.FundDimensionReportingTag (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT FundDimensionReportingTag_PK PRIMARY KEY (Code, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.FundDimensionReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.FundingSourceDescriptor --
CREATE TABLE edfi.FundingSourceDescriptor (
    FundingSourceDescriptorId INT NOT NULL,
    CONSTRAINT FundingSourceDescriptor_PK PRIMARY KEY (FundingSourceDescriptorId)
);

-- Table edfi.GeneralStudentProgramAssociation --
CREATE TABLE edfi.GeneralStudentProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    EndDate DATE NULL,
    ReasonExitedDescriptorId INT NULL,
    ServedOutsideOfRegularSession BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT GeneralStudentProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);
ALTER TABLE edfi.GeneralStudentProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.GeneralStudentProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.GeneralStudentProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GeneralStudentProgramAssociationProgramParticipationStatus --
CREATE TABLE edfi.GeneralStudentProgramAssociationProgramParticipationStatus (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ParticipationStatusDescriptorId INT NOT NULL,
    StatusBeginDate DATE NOT NULL,
    DesignatedBy VARCHAR(60) NULL,
    StatusEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GeneralStudentProgramAssociationProgramParticipationStatus_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, ParticipationStatusDescriptorId, StatusBeginDate)
);
ALTER TABLE edfi.GeneralStudentProgramAssociationProgramParticipationStatus ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Goal --
CREATE TABLE edfi.Goal (
    AssignmentDate DATE NOT NULL,
    GoalTitle VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    Comments VARCHAR(1024) NULL,
    CompletedDate DATE NULL,
    CompletedIndicator BOOLEAN NULL,
    DueDate DATE NULL,
    EducationOrganizationId BIGINT NULL,
    EvaluationElementTitle VARCHAR(255) NULL,
    EvaluationObjectiveTitle VARCHAR(50) NULL,
    EvaluationPeriodDescriptorId INT NULL,
    EvaluationTitle VARCHAR(50) NULL,
    GoalDescription VARCHAR(1024) NULL,
    GoalTypeDescriptorId INT NULL,
    ParentAssignmentDate DATE NULL,
    ParentGoalTitle VARCHAR(255) NULL,
    ParentPersonId VARCHAR(32) NULL,
    ParentSourceSystemDescriptorId INT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NULL,
    PerformanceEvaluationTypeDescriptorId INT NULL,
    SchoolYear SMALLINT NULL,
    TermDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Goal_PK PRIMARY KEY (AssignmentDate, GoalTitle, PersonId, SourceSystemDescriptorId)
);
ALTER TABLE edfi.Goal ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Goal ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Goal ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GoalTypeDescriptor --
CREATE TABLE edfi.GoalTypeDescriptor (
    GoalTypeDescriptorId INT NOT NULL,
    CONSTRAINT GoalTypeDescriptor_PK PRIMARY KEY (GoalTypeDescriptorId)
);

-- Table edfi.Grade --
CREATE TABLE edfi.Grade (
    BeginDate DATE NOT NULL,
    GradeTypeDescriptorId INT NOT NULL,
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    CurrentGradeAsOfDate DATE NULL,
    CurrentGradeIndicator BOOLEAN NULL,
    DiagnosticStatement VARCHAR(1024) NULL,
    GradeEarnedDescription VARCHAR(64) NULL,
    LetterGradeEarned VARCHAR(20) NULL,
    NumericGradeEarned DECIMAL(9, 2) NULL,
    PerformanceBaseConversionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Grade_PK PRIMARY KEY (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolYear, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
);
ALTER TABLE edfi.Grade ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Grade ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Grade ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GradebookEntry --
CREATE TABLE edfi.GradebookEntry (
    GradebookEntryIdentifier VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    DateAssigned DATE NOT NULL,
    Description VARCHAR(1024) NULL,
    DueDate DATE NULL,
    DueTime TIME NULL,
    GradebookEntryTypeDescriptorId INT NULL,
    GradingPeriodDescriptorId INT NULL,
    GradingPeriodName VARCHAR(60) NULL,
    LocalCourseCode VARCHAR(60) NULL,
    MaxPoints DECIMAL(9, 2) NULL,
    SchoolId BIGINT NULL,
    SchoolYear SMALLINT NULL,
    SectionIdentifier VARCHAR(255) NULL,
    SessionName VARCHAR(120) NULL,
    SourceSectionIdentifier VARCHAR(255) NOT NULL,
    Title VARCHAR(100) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT GradebookEntry_PK PRIMARY KEY (GradebookEntryIdentifier, Namespace)
);
ALTER TABLE edfi.GradebookEntry ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.GradebookEntry ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.GradebookEntry ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GradebookEntryLearningStandard --
CREATE TABLE edfi.GradebookEntryLearningStandard (
    GradebookEntryIdentifier VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    LearningStandardId VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GradebookEntryLearningStandard_PK PRIMARY KEY (GradebookEntryIdentifier, Namespace, LearningStandardId)
);
ALTER TABLE edfi.GradebookEntryLearningStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GradebookEntryTypeDescriptor --
CREATE TABLE edfi.GradebookEntryTypeDescriptor (
    GradebookEntryTypeDescriptorId INT NOT NULL,
    CONSTRAINT GradebookEntryTypeDescriptor_PK PRIMARY KEY (GradebookEntryTypeDescriptorId)
);

-- Table edfi.GradeLearningStandardGrade --
CREATE TABLE edfi.GradeLearningStandardGrade (
    BeginDate DATE NOT NULL,
    GradeTypeDescriptorId INT NOT NULL,
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    LearningStandardId VARCHAR(60) NOT NULL,
    DiagnosticStatement VARCHAR(1024) NULL,
    LetterGradeEarned VARCHAR(20) NULL,
    NumericGradeEarned DECIMAL(9, 2) NULL,
    PerformanceBaseConversionDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GradeLearningStandardGrade_PK PRIMARY KEY (BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolYear, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, LearningStandardId)
);
ALTER TABLE edfi.GradeLearningStandardGrade ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GradeLevelDescriptor --
CREATE TABLE edfi.GradeLevelDescriptor (
    GradeLevelDescriptorId INT NOT NULL,
    CONSTRAINT GradeLevelDescriptor_PK PRIMARY KEY (GradeLevelDescriptorId)
);

-- Table edfi.GradePointAverageTypeDescriptor --
CREATE TABLE edfi.GradePointAverageTypeDescriptor (
    GradePointAverageTypeDescriptorId INT NOT NULL,
    CONSTRAINT GradePointAverageTypeDescriptor_PK PRIMARY KEY (GradePointAverageTypeDescriptorId)
);

-- Table edfi.GradeTypeDescriptor --
CREATE TABLE edfi.GradeTypeDescriptor (
    GradeTypeDescriptorId INT NOT NULL,
    CONSTRAINT GradeTypeDescriptor_PK PRIMARY KEY (GradeTypeDescriptorId)
);

-- Table edfi.GradingPeriod --
CREATE TABLE edfi.GradingPeriod (
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    PeriodSequence INT NULL,
    TotalInstructionalDays INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT GradingPeriod_PK PRIMARY KEY (GradingPeriodDescriptorId, GradingPeriodName, SchoolId, SchoolYear)
);
ALTER TABLE edfi.GradingPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.GradingPeriod ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.GradingPeriod ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GradingPeriodDescriptor --
CREATE TABLE edfi.GradingPeriodDescriptor (
    GradingPeriodDescriptorId INT NOT NULL,
    CONSTRAINT GradingPeriodDescriptor_PK PRIMARY KEY (GradingPeriodDescriptorId)
);

-- Table edfi.GraduationPlan --
CREATE TABLE edfi.GraduationPlan (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    IndividualPlan BOOLEAN NULL,
    TotalRequiredCreditConversion DECIMAL(9, 2) NULL,
    TotalRequiredCredits DECIMAL(9, 3) NOT NULL,
    TotalRequiredCreditTypeDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT GraduationPlan_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
);
ALTER TABLE edfi.GraduationPlan ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.GraduationPlan ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.GraduationPlan ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanCreditsByCourse --
CREATE TABLE edfi.GraduationPlanCreditsByCourse (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    CourseSetName VARCHAR(120) NOT NULL,
    CreditConversion DECIMAL(9, 2) NULL,
    Credits DECIMAL(9, 3) NOT NULL,
    CreditTypeDescriptorId INT NULL,
    WhenTakenGradeLevelDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanCreditsByCourse_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, CourseSetName)
);
ALTER TABLE edfi.GraduationPlanCreditsByCourse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanCreditsByCourseCourse --
CREATE TABLE edfi.GraduationPlanCreditsByCourseCourse (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    CourseSetName VARCHAR(120) NOT NULL,
    CourseCode VARCHAR(120) NOT NULL,
    CourseEducationOrganizationId BIGINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanCreditsByCourseCourse_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, CourseSetName, CourseCode, CourseEducationOrganizationId)
);
ALTER TABLE edfi.GraduationPlanCreditsByCourseCourse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanCreditsByCreditCategory --
CREATE TABLE edfi.GraduationPlanCreditsByCreditCategory (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    CreditCategoryDescriptorId INT NOT NULL,
    CreditConversion DECIMAL(9, 2) NULL,
    Credits DECIMAL(9, 3) NOT NULL,
    CreditTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanCreditsByCreditCategory_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, CreditCategoryDescriptorId)
);
ALTER TABLE edfi.GraduationPlanCreditsByCreditCategory ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanCreditsBySubject --
CREATE TABLE edfi.GraduationPlanCreditsBySubject (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreditConversion DECIMAL(9, 2) NULL,
    Credits DECIMAL(9, 3) NOT NULL,
    CreditTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanCreditsBySubject_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.GraduationPlanCreditsBySubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanRequiredAssessment --
CREATE TABLE edfi.GraduationPlanRequiredAssessment (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanRequiredAssessment_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, AssessmentIdentifier, Namespace)
);
ALTER TABLE edfi.GraduationPlanRequiredAssessment ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanRequiredAssessmentPerformanceLevel --
CREATE TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    MaximumScore VARCHAR(35) NULL,
    MinimumScore VARCHAR(35) NULL,
    PerformanceLevelDescriptorId INT NOT NULL,
    PerformanceLevelIndicatorName VARCHAR(60) NULL,
    ResultDatatypeTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanRequiredAssessmentPerformanceLevel_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, AssessmentIdentifier, Namespace)
);
ALTER TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanRequiredAssessmentScore --
CREATE TABLE edfi.GraduationPlanRequiredAssessmentScore (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    MaximumScore VARCHAR(35) NULL,
    MinimumScore VARCHAR(35) NULL,
    ResultDatatypeTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanRequiredAssessmentScore_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, AssessmentIdentifier, Namespace, AssessmentReportingMethodDescriptorId)
);
ALTER TABLE edfi.GraduationPlanRequiredAssessmentScore ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanRequiredCertification --
CREATE TABLE edfi.GraduationPlanRequiredCertification (
    EducationOrganizationId BIGINT NOT NULL,
    GraduationPlanTypeDescriptorId INT NOT NULL,
    GraduationSchoolYear SMALLINT NOT NULL,
    CertificationTitle VARCHAR(64) NOT NULL,
    CertificationIdentifier VARCHAR(120) NULL,
    CertificationRouteDescriptorId INT NULL,
    Namespace VARCHAR(255) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT GraduationPlanRequiredCertification_PK PRIMARY KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, CertificationTitle)
);
ALTER TABLE edfi.GraduationPlanRequiredCertification ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.GraduationPlanTypeDescriptor --
CREATE TABLE edfi.GraduationPlanTypeDescriptor (
    GraduationPlanTypeDescriptorId INT NOT NULL,
    CONSTRAINT GraduationPlanTypeDescriptor_PK PRIMARY KEY (GraduationPlanTypeDescriptorId)
);

-- Table edfi.GunFreeSchoolsActReportingStatusDescriptor --
CREATE TABLE edfi.GunFreeSchoolsActReportingStatusDescriptor (
    GunFreeSchoolsActReportingStatusDescriptorId INT NOT NULL,
    CONSTRAINT GunFreeSchoolsActReportingStatusDescriptor_PK PRIMARY KEY (GunFreeSchoolsActReportingStatusDescriptorId)
);

-- Table edfi.HireStatusDescriptor --
CREATE TABLE edfi.HireStatusDescriptor (
    HireStatusDescriptorId INT NOT NULL,
    CONSTRAINT HireStatusDescriptor_PK PRIMARY KEY (HireStatusDescriptorId)
);

-- Table edfi.HiringSourceDescriptor --
CREATE TABLE edfi.HiringSourceDescriptor (
    HiringSourceDescriptorId INT NOT NULL,
    CONSTRAINT HiringSourceDescriptor_PK PRIMARY KEY (HiringSourceDescriptorId)
);

-- Table edfi.HomelessPrimaryNighttimeResidenceDescriptor --
CREATE TABLE edfi.HomelessPrimaryNighttimeResidenceDescriptor (
    HomelessPrimaryNighttimeResidenceDescriptorId INT NOT NULL,
    CONSTRAINT HomelessPrimaryNighttimeResidenceDescriptor_PK PRIMARY KEY (HomelessPrimaryNighttimeResidenceDescriptorId)
);

-- Table edfi.HomelessProgramServiceDescriptor --
CREATE TABLE edfi.HomelessProgramServiceDescriptor (
    HomelessProgramServiceDescriptorId INT NOT NULL,
    CONSTRAINT HomelessProgramServiceDescriptor_PK PRIMARY KEY (HomelessProgramServiceDescriptorId)
);

-- Table edfi.IDEAPartDescriptor --
CREATE TABLE edfi.IDEAPartDescriptor (
    IDEAPartDescriptorId INT NOT NULL,
    CONSTRAINT IDEAPartDescriptor_PK PRIMARY KEY (IDEAPartDescriptorId)
);

-- Table edfi.IdentificationDocumentUseDescriptor --
CREATE TABLE edfi.IdentificationDocumentUseDescriptor (
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    CONSTRAINT IdentificationDocumentUseDescriptor_PK PRIMARY KEY (IdentificationDocumentUseDescriptorId)
);

-- Table edfi.ImmunizationTypeDescriptor --
CREATE TABLE edfi.ImmunizationTypeDescriptor (
    ImmunizationTypeDescriptorId INT NOT NULL,
    CONSTRAINT ImmunizationTypeDescriptor_PK PRIMARY KEY (ImmunizationTypeDescriptorId)
);

-- Table edfi.IncidentLocationDescriptor --
CREATE TABLE edfi.IncidentLocationDescriptor (
    IncidentLocationDescriptorId INT NOT NULL,
    CONSTRAINT IncidentLocationDescriptor_PK PRIMARY KEY (IncidentLocationDescriptorId)
);

-- Table edfi.IndicatorDescriptor --
CREATE TABLE edfi.IndicatorDescriptor (
    IndicatorDescriptorId INT NOT NULL,
    CONSTRAINT IndicatorDescriptor_PK PRIMARY KEY (IndicatorDescriptorId)
);

-- Table edfi.IndicatorGroupDescriptor --
CREATE TABLE edfi.IndicatorGroupDescriptor (
    IndicatorGroupDescriptorId INT NOT NULL,
    CONSTRAINT IndicatorGroupDescriptor_PK PRIMARY KEY (IndicatorGroupDescriptorId)
);

-- Table edfi.IndicatorLevelDescriptor --
CREATE TABLE edfi.IndicatorLevelDescriptor (
    IndicatorLevelDescriptorId INT NOT NULL,
    CONSTRAINT IndicatorLevelDescriptor_PK PRIMARY KEY (IndicatorLevelDescriptorId)
);

-- Table edfi.InstitutionTelephoneNumberTypeDescriptor --
CREATE TABLE edfi.InstitutionTelephoneNumberTypeDescriptor (
    InstitutionTelephoneNumberTypeDescriptorId INT NOT NULL,
    CONSTRAINT InstitutionTelephoneNumberTypeDescriptor_PK PRIMARY KEY (InstitutionTelephoneNumberTypeDescriptorId)
);

-- Table edfi.InstructionalSettingDescriptor --
CREATE TABLE edfi.InstructionalSettingDescriptor (
    InstructionalSettingDescriptorId INT NOT NULL,
    CONSTRAINT InstructionalSettingDescriptor_PK PRIMARY KEY (InstructionalSettingDescriptorId)
);

-- Table edfi.InteractivityStyleDescriptor --
CREATE TABLE edfi.InteractivityStyleDescriptor (
    InteractivityStyleDescriptorId INT NOT NULL,
    CONSTRAINT InteractivityStyleDescriptor_PK PRIMARY KEY (InteractivityStyleDescriptorId)
);

-- Table edfi.InternetAccessDescriptor --
CREATE TABLE edfi.InternetAccessDescriptor (
    InternetAccessDescriptorId INT NOT NULL,
    CONSTRAINT InternetAccessDescriptor_PK PRIMARY KEY (InternetAccessDescriptorId)
);

-- Table edfi.InternetAccessTypeInResidenceDescriptor --
CREATE TABLE edfi.InternetAccessTypeInResidenceDescriptor (
    InternetAccessTypeInResidenceDescriptorId INT NOT NULL,
    CONSTRAINT InternetAccessTypeInResidenceDescriptor_PK PRIMARY KEY (InternetAccessTypeInResidenceDescriptorId)
);

-- Table edfi.InternetPerformanceInResidenceDescriptor --
CREATE TABLE edfi.InternetPerformanceInResidenceDescriptor (
    InternetPerformanceInResidenceDescriptorId INT NOT NULL,
    CONSTRAINT InternetPerformanceInResidenceDescriptor_PK PRIMARY KEY (InternetPerformanceInResidenceDescriptorId)
);

-- Table edfi.Intervention --
CREATE TABLE edfi.Intervention (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    BeginDate DATE NOT NULL,
    DeliveryMethodDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    InterventionClassDescriptorId INT NOT NULL,
    MaxDosage INT NULL,
    MinDosage INT NULL,
    Namespace VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Intervention_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode)
);
ALTER TABLE edfi.Intervention ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Intervention ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Intervention ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionAppropriateGradeLevel --
CREATE TABLE edfi.InterventionAppropriateGradeLevel (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionAppropriateGradeLevel_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, GradeLevelDescriptorId)
);
ALTER TABLE edfi.InterventionAppropriateGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionAppropriateSex --
CREATE TABLE edfi.InterventionAppropriateSex (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    SexDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionAppropriateSex_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, SexDescriptorId)
);
ALTER TABLE edfi.InterventionAppropriateSex ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionClassDescriptor --
CREATE TABLE edfi.InterventionClassDescriptor (
    InterventionClassDescriptorId INT NOT NULL,
    CONSTRAINT InterventionClassDescriptor_PK PRIMARY KEY (InterventionClassDescriptorId)
);

-- Table edfi.InterventionDiagnosis --
CREATE TABLE edfi.InterventionDiagnosis (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    DiagnosisDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionDiagnosis_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, DiagnosisDescriptorId)
);
ALTER TABLE edfi.InterventionDiagnosis ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionEducationContent --
CREATE TABLE edfi.InterventionEducationContent (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    ContentIdentifier VARCHAR(225) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionEducationContent_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, ContentIdentifier)
);
ALTER TABLE edfi.InterventionEducationContent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionEffectivenessRatingDescriptor --
CREATE TABLE edfi.InterventionEffectivenessRatingDescriptor (
    InterventionEffectivenessRatingDescriptorId INT NOT NULL,
    CONSTRAINT InterventionEffectivenessRatingDescriptor_PK PRIMARY KEY (InterventionEffectivenessRatingDescriptorId)
);

-- Table edfi.InterventionInterventionPrescription --
CREATE TABLE edfi.InterventionInterventionPrescription (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    InterventionPrescriptionEducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionInterventionPrescription_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode)
);
ALTER TABLE edfi.InterventionInterventionPrescription ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionLearningResourceMetadataURI --
CREATE TABLE edfi.InterventionLearningResourceMetadataURI (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    LearningResourceMetadataURI VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionLearningResourceMetadataURI_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, LearningResourceMetadataURI)
);
ALTER TABLE edfi.InterventionLearningResourceMetadataURI ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionMeetingTime --
CREATE TABLE edfi.InterventionMeetingTime (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    EndTime TIME NOT NULL,
    StartTime TIME NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionMeetingTime_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, EndTime, StartTime)
);
ALTER TABLE edfi.InterventionMeetingTime ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPopulationServed --
CREATE TABLE edfi.InterventionPopulationServed (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    PopulationServedDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionPopulationServed_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, PopulationServedDescriptorId)
);
ALTER TABLE edfi.InterventionPopulationServed ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPrescription --
CREATE TABLE edfi.InterventionPrescription (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    DeliveryMethodDescriptorId INT NOT NULL,
    InterventionClassDescriptorId INT NOT NULL,
    MaxDosage INT NULL,
    MinDosage INT NULL,
    Namespace VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT InterventionPrescription_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode)
);
ALTER TABLE edfi.InterventionPrescription ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.InterventionPrescription ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.InterventionPrescription ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPrescriptionAppropriateGradeLevel --
CREATE TABLE edfi.InterventionPrescriptionAppropriateGradeLevel (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionPrescriptionAppropriateGradeLevel_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode, GradeLevelDescriptorId)
);
ALTER TABLE edfi.InterventionPrescriptionAppropriateGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPrescriptionAppropriateSex --
CREATE TABLE edfi.InterventionPrescriptionAppropriateSex (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    SexDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionPrescriptionAppropriateSex_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode, SexDescriptorId)
);
ALTER TABLE edfi.InterventionPrescriptionAppropriateSex ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPrescriptionDiagnosis --
CREATE TABLE edfi.InterventionPrescriptionDiagnosis (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    DiagnosisDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionPrescriptionDiagnosis_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode, DiagnosisDescriptorId)
);
ALTER TABLE edfi.InterventionPrescriptionDiagnosis ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPrescriptionEducationContent --
CREATE TABLE edfi.InterventionPrescriptionEducationContent (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    ContentIdentifier VARCHAR(225) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionPrescriptionEducationContent_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode, ContentIdentifier)
);
ALTER TABLE edfi.InterventionPrescriptionEducationContent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPrescriptionLearningResourceMetadataURI --
CREATE TABLE edfi.InterventionPrescriptionLearningResourceMetadataURI (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    LearningResourceMetadataURI VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionPrescriptionLearningResourceMetadataURI_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode, LearningResourceMetadataURI)
);
ALTER TABLE edfi.InterventionPrescriptionLearningResourceMetadataURI ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPrescriptionPopulationServed --
CREATE TABLE edfi.InterventionPrescriptionPopulationServed (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    PopulationServedDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionPrescriptionPopulationServed_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode, PopulationServedDescriptorId)
);
ALTER TABLE edfi.InterventionPrescriptionPopulationServed ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionPrescriptionURI --
CREATE TABLE edfi.InterventionPrescriptionURI (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    URI VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionPrescriptionURI_PK PRIMARY KEY (EducationOrganizationId, InterventionPrescriptionIdentificationCode, URI)
);
ALTER TABLE edfi.InterventionPrescriptionURI ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStaff --
CREATE TABLE edfi.InterventionStaff (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    StaffUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStaff_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, StaffUSI)
);
ALTER TABLE edfi.InterventionStaff ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudy --
CREATE TABLE edfi.InterventionStudy (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    DeliveryMethodDescriptorId INT NOT NULL,
    InterventionClassDescriptorId INT NOT NULL,
    InterventionPrescriptionEducationOrganizationId BIGINT NOT NULL,
    InterventionPrescriptionIdentificationCode VARCHAR(120) NOT NULL,
    Participants INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT InterventionStudy_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
);
ALTER TABLE edfi.InterventionStudy ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.InterventionStudy ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.InterventionStudy ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudyAppropriateGradeLevel --
CREATE TABLE edfi.InterventionStudyAppropriateGradeLevel (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStudyAppropriateGradeLevel_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode, GradeLevelDescriptorId)
);
ALTER TABLE edfi.InterventionStudyAppropriateGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudyAppropriateSex --
CREATE TABLE edfi.InterventionStudyAppropriateSex (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    SexDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStudyAppropriateSex_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode, SexDescriptorId)
);
ALTER TABLE edfi.InterventionStudyAppropriateSex ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudyEducationContent --
CREATE TABLE edfi.InterventionStudyEducationContent (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    ContentIdentifier VARCHAR(225) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStudyEducationContent_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode, ContentIdentifier)
);
ALTER TABLE edfi.InterventionStudyEducationContent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudyInterventionEffectiveness --
CREATE TABLE edfi.InterventionStudyInterventionEffectiveness (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    DiagnosisDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    PopulationServedDescriptorId INT NOT NULL,
    ImprovementIndex INT NULL,
    InterventionEffectivenessRatingDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStudyInterventionEffectiveness_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode, DiagnosisDescriptorId, GradeLevelDescriptorId, PopulationServedDescriptorId)
);
ALTER TABLE edfi.InterventionStudyInterventionEffectiveness ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudyLearningResourceMetadataURI --
CREATE TABLE edfi.InterventionStudyLearningResourceMetadataURI (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    LearningResourceMetadataURI VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStudyLearningResourceMetadataURI_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode, LearningResourceMetadataURI)
);
ALTER TABLE edfi.InterventionStudyLearningResourceMetadataURI ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudyPopulationServed --
CREATE TABLE edfi.InterventionStudyPopulationServed (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    PopulationServedDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStudyPopulationServed_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode, PopulationServedDescriptorId)
);
ALTER TABLE edfi.InterventionStudyPopulationServed ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudyStateAbbreviation --
CREATE TABLE edfi.InterventionStudyStateAbbreviation (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStudyStateAbbreviation_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode, StateAbbreviationDescriptorId)
);
ALTER TABLE edfi.InterventionStudyStateAbbreviation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionStudyURI --
CREATE TABLE edfi.InterventionStudyURI (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionStudyIdentificationCode VARCHAR(120) NOT NULL,
    URI VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionStudyURI_PK PRIMARY KEY (EducationOrganizationId, InterventionStudyIdentificationCode, URI)
);
ALTER TABLE edfi.InterventionStudyURI ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.InterventionURI --
CREATE TABLE edfi.InterventionURI (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    URI VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT InterventionURI_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, URI)
);
ALTER TABLE edfi.InterventionURI ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LanguageDescriptor --
CREATE TABLE edfi.LanguageDescriptor (
    LanguageDescriptorId INT NOT NULL,
    CONSTRAINT LanguageDescriptor_PK PRIMARY KEY (LanguageDescriptorId)
);

-- Table edfi.LanguageInstructionProgramServiceDescriptor --
CREATE TABLE edfi.LanguageInstructionProgramServiceDescriptor (
    LanguageInstructionProgramServiceDescriptorId INT NOT NULL,
    CONSTRAINT LanguageInstructionProgramServiceDescriptor_PK PRIMARY KEY (LanguageInstructionProgramServiceDescriptorId)
);

-- Table edfi.LanguageUseDescriptor --
CREATE TABLE edfi.LanguageUseDescriptor (
    LanguageUseDescriptorId INT NOT NULL,
    CONSTRAINT LanguageUseDescriptor_PK PRIMARY KEY (LanguageUseDescriptorId)
);

-- Table edfi.LearningStandard --
CREATE TABLE edfi.LearningStandard (
    LearningStandardId VARCHAR(60) NOT NULL,
    CourseTitle VARCHAR(120) NULL,
    Description VARCHAR(1024) NOT NULL,
    LearningStandardCategoryDescriptorId INT NULL,
    LearningStandardItemCode VARCHAR(120) NULL,
    LearningStandardScopeDescriptorId INT NULL,
    Namespace VARCHAR(255) NOT NULL,
    ParentLearningStandardId VARCHAR(60) NULL,
    SuccessCriteria VARCHAR(150) NULL,
    URI VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT LearningStandard_PK PRIMARY KEY (LearningStandardId)
);
ALTER TABLE edfi.LearningStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.LearningStandard ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.LearningStandard ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LearningStandardAcademicSubject --
CREATE TABLE edfi.LearningStandardAcademicSubject (
    LearningStandardId VARCHAR(60) NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LearningStandardAcademicSubject_PK PRIMARY KEY (LearningStandardId, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.LearningStandardAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LearningStandardCategoryDescriptor --
CREATE TABLE edfi.LearningStandardCategoryDescriptor (
    LearningStandardCategoryDescriptorId INT NOT NULL,
    CONSTRAINT LearningStandardCategoryDescriptor_PK PRIMARY KEY (LearningStandardCategoryDescriptorId)
);

-- Table edfi.LearningStandardContentStandard --
CREATE TABLE edfi.LearningStandardContentStandard (
    LearningStandardId VARCHAR(60) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    MandatingEducationOrganizationId BIGINT NULL,
    PublicationDate DATE NULL,
    PublicationStatusDescriptorId INT NULL,
    PublicationYear SMALLINT NULL,
    Title VARCHAR(100) NOT NULL,
    URI VARCHAR(255) NULL,
    Version VARCHAR(50) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LearningStandardContentStandard_PK PRIMARY KEY (LearningStandardId)
);
ALTER TABLE edfi.LearningStandardContentStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LearningStandardContentStandardAuthor --
CREATE TABLE edfi.LearningStandardContentStandardAuthor (
    LearningStandardId VARCHAR(60) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LearningStandardContentStandardAuthor_PK PRIMARY KEY (LearningStandardId, Author)
);
ALTER TABLE edfi.LearningStandardContentStandardAuthor ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LearningStandardEquivalenceAssociation --
CREATE TABLE edfi.LearningStandardEquivalenceAssociation (
    Namespace VARCHAR(255) NOT NULL,
    SourceLearningStandardId VARCHAR(60) NOT NULL,
    TargetLearningStandardId VARCHAR(60) NOT NULL,
    EffectiveDate DATE NULL,
    LearningStandardEquivalenceStrengthDescription VARCHAR(255) NULL,
    LearningStandardEquivalenceStrengthDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT LearningStandardEquivalenceAssociation_PK PRIMARY KEY (Namespace, SourceLearningStandardId, TargetLearningStandardId)
);
ALTER TABLE edfi.LearningStandardEquivalenceAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.LearningStandardEquivalenceAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.LearningStandardEquivalenceAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LearningStandardEquivalenceStrengthDescriptor --
CREATE TABLE edfi.LearningStandardEquivalenceStrengthDescriptor (
    LearningStandardEquivalenceStrengthDescriptorId INT NOT NULL,
    CONSTRAINT LearningStandardEquivalenceStrengthDescriptor_PK PRIMARY KEY (LearningStandardEquivalenceStrengthDescriptorId)
);

-- Table edfi.LearningStandardGradeLevel --
CREATE TABLE edfi.LearningStandardGradeLevel (
    LearningStandardId VARCHAR(60) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LearningStandardGradeLevel_PK PRIMARY KEY (LearningStandardId, GradeLevelDescriptorId)
);
ALTER TABLE edfi.LearningStandardGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LearningStandardIdentificationCode --
CREATE TABLE edfi.LearningStandardIdentificationCode (
    LearningStandardId VARCHAR(60) NOT NULL,
    ContentStandardName VARCHAR(65) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LearningStandardIdentificationCode_PK PRIMARY KEY (LearningStandardId, ContentStandardName, IdentificationCode)
);
ALTER TABLE edfi.LearningStandardIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LearningStandardScopeDescriptor --
CREATE TABLE edfi.LearningStandardScopeDescriptor (
    LearningStandardScopeDescriptorId INT NOT NULL,
    CONSTRAINT LearningStandardScopeDescriptor_PK PRIMARY KEY (LearningStandardScopeDescriptorId)
);

-- Table edfi.LengthOfContractDescriptor --
CREATE TABLE edfi.LengthOfContractDescriptor (
    LengthOfContractDescriptorId INT NOT NULL,
    CONSTRAINT LengthOfContractDescriptor_PK PRIMARY KEY (LengthOfContractDescriptorId)
);

-- Table edfi.LevelOfEducationDescriptor --
CREATE TABLE edfi.LevelOfEducationDescriptor (
    LevelOfEducationDescriptorId INT NOT NULL,
    CONSTRAINT LevelOfEducationDescriptor_PK PRIMARY KEY (LevelOfEducationDescriptorId)
);

-- Table edfi.LicenseStatusDescriptor --
CREATE TABLE edfi.LicenseStatusDescriptor (
    LicenseStatusDescriptorId INT NOT NULL,
    CONSTRAINT LicenseStatusDescriptor_PK PRIMARY KEY (LicenseStatusDescriptorId)
);

-- Table edfi.LicenseTypeDescriptor --
CREATE TABLE edfi.LicenseTypeDescriptor (
    LicenseTypeDescriptorId INT NOT NULL,
    CONSTRAINT LicenseTypeDescriptor_PK PRIMARY KEY (LicenseTypeDescriptorId)
);

-- Table edfi.LimitedEnglishProficiencyDescriptor --
CREATE TABLE edfi.LimitedEnglishProficiencyDescriptor (
    LimitedEnglishProficiencyDescriptorId INT NOT NULL,
    CONSTRAINT LimitedEnglishProficiencyDescriptor_PK PRIMARY KEY (LimitedEnglishProficiencyDescriptorId)
);

-- Table edfi.LocalAccount --
CREATE TABLE edfi.LocalAccount (
    AccountIdentifier VARCHAR(50) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    AccountName VARCHAR(100) NULL,
    ChartOfAccountIdentifier VARCHAR(50) NOT NULL,
    ChartOfAccountEducationOrganizationId BIGINT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT LocalAccount_PK PRIMARY KEY (AccountIdentifier, EducationOrganizationId, FiscalYear)
);
ALTER TABLE edfi.LocalAccount ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.LocalAccount ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.LocalAccount ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LocalAccountReportingTag --
CREATE TABLE edfi.LocalAccountReportingTag (
    AccountIdentifier VARCHAR(50) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    TagValue VARCHAR(100) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LocalAccountReportingTag_PK PRIMARY KEY (AccountIdentifier, EducationOrganizationId, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.LocalAccountReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LocalActual --
CREATE TABLE edfi.LocalActual (
    AccountIdentifier VARCHAR(50) NOT NULL,
    AsOfDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    Amount MONEY NOT NULL,
    FinancialCollectionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT LocalActual_PK PRIMARY KEY (AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear)
);
ALTER TABLE edfi.LocalActual ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.LocalActual ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.LocalActual ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LocalBudget --
CREATE TABLE edfi.LocalBudget (
    AccountIdentifier VARCHAR(50) NOT NULL,
    AsOfDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    Amount MONEY NOT NULL,
    FinancialCollectionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT LocalBudget_PK PRIMARY KEY (AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear)
);
ALTER TABLE edfi.LocalBudget ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.LocalBudget ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.LocalBudget ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LocalContractedStaff --
CREATE TABLE edfi.LocalContractedStaff (
    AccountIdentifier VARCHAR(50) NOT NULL,
    AsOfDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    StaffUSI INT NOT NULL,
    Amount MONEY NOT NULL,
    FinancialCollectionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT LocalContractedStaff_PK PRIMARY KEY (AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, StaffUSI)
);
ALTER TABLE edfi.LocalContractedStaff ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.LocalContractedStaff ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.LocalContractedStaff ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LocaleDescriptor --
CREATE TABLE edfi.LocaleDescriptor (
    LocaleDescriptorId INT NOT NULL,
    CONSTRAINT LocaleDescriptor_PK PRIMARY KEY (LocaleDescriptorId)
);

-- Table edfi.LocalEducationAgency --
CREATE TABLE edfi.LocalEducationAgency (
    LocalEducationAgencyId BIGINT NOT NULL,
    CharterStatusDescriptorId INT NULL,
    EducationServiceCenterId BIGINT NULL,
    FederalLocaleCodeDescriptorId INT NULL,
    LocalEducationAgencyCategoryDescriptorId INT NOT NULL,
    ParentLocalEducationAgencyId BIGINT NULL,
    StateEducationAgencyId BIGINT NULL,
    CONSTRAINT LocalEducationAgency_PK PRIMARY KEY (LocalEducationAgencyId)
);

-- Table edfi.LocalEducationAgencyAccountability --
CREATE TABLE edfi.LocalEducationAgencyAccountability (
    LocalEducationAgencyId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    GunFreeSchoolsActReportingStatusDescriptorId INT NULL,
    SchoolChoiceImplementStatusDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LocalEducationAgencyAccountability_PK PRIMARY KEY (LocalEducationAgencyId, SchoolYear)
);
ALTER TABLE edfi.LocalEducationAgencyAccountability ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LocalEducationAgencyCategoryDescriptor --
CREATE TABLE edfi.LocalEducationAgencyCategoryDescriptor (
    LocalEducationAgencyCategoryDescriptorId INT NOT NULL,
    CONSTRAINT LocalEducationAgencyCategoryDescriptor_PK PRIMARY KEY (LocalEducationAgencyCategoryDescriptorId)
);

-- Table edfi.LocalEducationAgencyFederalFunds --
CREATE TABLE edfi.LocalEducationAgencyFederalFunds (
    LocalEducationAgencyId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    InnovativeDollarsSpent MONEY NULL,
    InnovativeDollarsSpentStrategicPriorities MONEY NULL,
    InnovativeProgramsFundsReceived MONEY NULL,
    SchoolImprovementAllocation MONEY NULL,
    SchoolImprovementReservedFundsPercentage DECIMAL(5, 4) NULL,
    StateAssessmentAdministrationFunding DECIMAL(5, 4) NULL,
    SupplementalEducationalServicesFundsSpent MONEY NULL,
    SupplementalEducationalServicesPerPupilExpenditure MONEY NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT LocalEducationAgencyFederalFunds_PK PRIMARY KEY (LocalEducationAgencyId, FiscalYear)
);
ALTER TABLE edfi.LocalEducationAgencyFederalFunds ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LocalEncumbrance --
CREATE TABLE edfi.LocalEncumbrance (
    AccountIdentifier VARCHAR(50) NOT NULL,
    AsOfDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    Amount MONEY NOT NULL,
    FinancialCollectionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT LocalEncumbrance_PK PRIMARY KEY (AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear)
);
ALTER TABLE edfi.LocalEncumbrance ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.LocalEncumbrance ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.LocalEncumbrance ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.LocalPayroll --
CREATE TABLE edfi.LocalPayroll (
    AccountIdentifier VARCHAR(50) NOT NULL,
    AsOfDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    StaffUSI INT NOT NULL,
    Amount MONEY NOT NULL,
    FinancialCollectionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT LocalPayroll_PK PRIMARY KEY (AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, StaffUSI)
);
ALTER TABLE edfi.LocalPayroll ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.LocalPayroll ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.LocalPayroll ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Location --
CREATE TABLE edfi.Location (
    ClassroomIdentificationCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    MaximumNumberOfSeats INT NULL,
    OptimalNumberOfSeats INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Location_PK PRIMARY KEY (ClassroomIdentificationCode, SchoolId)
);
ALTER TABLE edfi.Location ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Location ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Location ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.MagnetSpecialProgramEmphasisSchoolDescriptor --
CREATE TABLE edfi.MagnetSpecialProgramEmphasisSchoolDescriptor (
    MagnetSpecialProgramEmphasisSchoolDescriptorId INT NOT NULL,
    CONSTRAINT MagnetSpecialProgramEmphasisSchoolDescriptor_PK PRIMARY KEY (MagnetSpecialProgramEmphasisSchoolDescriptorId)
);

-- Table edfi.MediumOfInstructionDescriptor --
CREATE TABLE edfi.MediumOfInstructionDescriptor (
    MediumOfInstructionDescriptorId INT NOT NULL,
    CONSTRAINT MediumOfInstructionDescriptor_PK PRIMARY KEY (MediumOfInstructionDescriptorId)
);

-- Table edfi.MethodCreditEarnedDescriptor --
CREATE TABLE edfi.MethodCreditEarnedDescriptor (
    MethodCreditEarnedDescriptorId INT NOT NULL,
    CONSTRAINT MethodCreditEarnedDescriptor_PK PRIMARY KEY (MethodCreditEarnedDescriptorId)
);

-- Table edfi.MigrantEducationProgramServiceDescriptor --
CREATE TABLE edfi.MigrantEducationProgramServiceDescriptor (
    MigrantEducationProgramServiceDescriptorId INT NOT NULL,
    CONSTRAINT MigrantEducationProgramServiceDescriptor_PK PRIMARY KEY (MigrantEducationProgramServiceDescriptorId)
);

-- Table edfi.ModelEntityDescriptor --
CREATE TABLE edfi.ModelEntityDescriptor (
    ModelEntityDescriptorId INT NOT NULL,
    CONSTRAINT ModelEntityDescriptor_PK PRIMARY KEY (ModelEntityDescriptorId)
);

-- Table edfi.MonitoredDescriptor --
CREATE TABLE edfi.MonitoredDescriptor (
    MonitoredDescriptorId INT NOT NULL,
    CONSTRAINT MonitoredDescriptor_PK PRIMARY KEY (MonitoredDescriptorId)
);

-- Table edfi.NeglectedOrDelinquentProgramDescriptor --
CREATE TABLE edfi.NeglectedOrDelinquentProgramDescriptor (
    NeglectedOrDelinquentProgramDescriptorId INT NOT NULL,
    CONSTRAINT NeglectedOrDelinquentProgramDescriptor_PK PRIMARY KEY (NeglectedOrDelinquentProgramDescriptorId)
);

-- Table edfi.NeglectedOrDelinquentProgramServiceDescriptor --
CREATE TABLE edfi.NeglectedOrDelinquentProgramServiceDescriptor (
    NeglectedOrDelinquentProgramServiceDescriptorId INT NOT NULL,
    CONSTRAINT NeglectedOrDelinquentProgramServiceDescriptor_PK PRIMARY KEY (NeglectedOrDelinquentProgramServiceDescriptorId)
);

-- Table edfi.NetworkPurposeDescriptor --
CREATE TABLE edfi.NetworkPurposeDescriptor (
    NetworkPurposeDescriptorId INT NOT NULL,
    CONSTRAINT NetworkPurposeDescriptor_PK PRIMARY KEY (NetworkPurposeDescriptorId)
);

-- Table edfi.NonMedicalImmunizationExemptionDescriptor --
CREATE TABLE edfi.NonMedicalImmunizationExemptionDescriptor (
    NonMedicalImmunizationExemptionDescriptorId INT NOT NULL,
    CONSTRAINT NonMedicalImmunizationExemptionDescriptor_PK PRIMARY KEY (NonMedicalImmunizationExemptionDescriptorId)
);

-- Table edfi.ObjectDimension --
CREATE TABLE edfi.ObjectDimension (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    CodeName VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ObjectDimension_PK PRIMARY KEY (Code, FiscalYear)
);
ALTER TABLE edfi.ObjectDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ObjectDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ObjectDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ObjectDimensionReportingTag --
CREATE TABLE edfi.ObjectDimensionReportingTag (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ObjectDimensionReportingTag_PK PRIMARY KEY (Code, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.ObjectDimensionReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ObjectiveAssessment --
CREATE TABLE edfi.ObjectiveAssessment (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    Description VARCHAR(1024) NULL,
    MaxRawScore DECIMAL(15, 5) NULL,
    Nomenclature VARCHAR(100) NULL,
    ParentIdentificationCode VARCHAR(120) NULL,
    PercentOfAssessment DECIMAL(5, 4) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ObjectiveAssessment_PK PRIMARY KEY (AssessmentIdentifier, IdentificationCode, Namespace)
);
ALTER TABLE edfi.ObjectiveAssessment ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ObjectiveAssessment ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ObjectiveAssessment ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ObjectiveAssessmentAssessmentItem --
CREATE TABLE edfi.ObjectiveAssessmentAssessmentItem (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentItemIdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ObjectiveAssessmentAssessmentItem_PK PRIMARY KEY (AssessmentIdentifier, IdentificationCode, Namespace, AssessmentItemIdentificationCode)
);
ALTER TABLE edfi.ObjectiveAssessmentAssessmentItem ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ObjectiveAssessmentLearningStandard --
CREATE TABLE edfi.ObjectiveAssessmentLearningStandard (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    LearningStandardId VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ObjectiveAssessmentLearningStandard_PK PRIMARY KEY (AssessmentIdentifier, IdentificationCode, Namespace, LearningStandardId)
);
ALTER TABLE edfi.ObjectiveAssessmentLearningStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ObjectiveAssessmentPerformanceLevel --
CREATE TABLE edfi.ObjectiveAssessmentPerformanceLevel (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    PerformanceLevelDescriptorId INT NOT NULL,
    MaximumScore VARCHAR(35) NULL,
    MinimumScore VARCHAR(35) NULL,
    PerformanceLevelIndicatorName VARCHAR(60) NULL,
    ResultDatatypeTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ObjectiveAssessmentPerformanceLevel_PK PRIMARY KEY (AssessmentIdentifier, IdentificationCode, Namespace, AssessmentReportingMethodDescriptorId, PerformanceLevelDescriptorId)
);
ALTER TABLE edfi.ObjectiveAssessmentPerformanceLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ObjectiveAssessmentScore --
CREATE TABLE edfi.ObjectiveAssessmentScore (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    MaximumScore VARCHAR(35) NULL,
    MinimumScore VARCHAR(35) NULL,
    ResultDatatypeTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ObjectiveAssessmentScore_PK PRIMARY KEY (AssessmentIdentifier, IdentificationCode, Namespace, AssessmentReportingMethodDescriptorId)
);
ALTER TABLE edfi.ObjectiveAssessmentScore ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ObjectiveRatingLevelDescriptor --
CREATE TABLE edfi.ObjectiveRatingLevelDescriptor (
    ObjectiveRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT ObjectiveRatingLevelDescriptor_PK PRIMARY KEY (ObjectiveRatingLevelDescriptorId)
);

-- Table edfi.OpenStaffPosition --
CREATE TABLE edfi.OpenStaffPosition (
    EducationOrganizationId BIGINT NOT NULL,
    RequisitionNumber VARCHAR(20) NOT NULL,
    DatePosted DATE NOT NULL,
    DatePostingRemoved DATE NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    FullTimeEquivalency DECIMAL(5, 4) NULL,
    FundingSourceDescriptorId INT NULL,
    HighNeedAcademicSubject BOOLEAN NULL,
    IsActive BOOLEAN NULL,
    MaxSalary DECIMAL(9, 2) NULL,
    MinSalary DECIMAL(9, 2) NULL,
    OpenStaffPositionReasonDescriptorId INT NULL,
    PositionControlNumber VARCHAR(20) NULL,
    PositionTitle VARCHAR(100) NULL,
    PostingResultDescriptorId INT NULL,
    ProgramAssignmentDescriptorId INT NULL,
    SchoolYear SMALLINT NULL,
    StaffClassificationDescriptorId INT NOT NULL,
    TermDescriptorId INT NULL,
    TotalBudgeted DECIMAL(9, 2) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT OpenStaffPosition_PK PRIMARY KEY (EducationOrganizationId, RequisitionNumber)
);
ALTER TABLE edfi.OpenStaffPosition ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.OpenStaffPosition ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.OpenStaffPosition ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.OpenStaffPositionAcademicSubject --
CREATE TABLE edfi.OpenStaffPositionAcademicSubject (
    EducationOrganizationId BIGINT NOT NULL,
    RequisitionNumber VARCHAR(20) NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT OpenStaffPositionAcademicSubject_PK PRIMARY KEY (EducationOrganizationId, RequisitionNumber, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.OpenStaffPositionAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.OpenStaffPositionEvent --
CREATE TABLE edfi.OpenStaffPositionEvent (
    EducationOrganizationId BIGINT NOT NULL,
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
ALTER TABLE edfi.OpenStaffPositionEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.OpenStaffPositionEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.OpenStaffPositionEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.OpenStaffPositionEventStatusDescriptor --
CREATE TABLE edfi.OpenStaffPositionEventStatusDescriptor (
    OpenStaffPositionEventStatusDescriptorId INT NOT NULL,
    CONSTRAINT OpenStaffPositionEventStatusDescriptor_PK PRIMARY KEY (OpenStaffPositionEventStatusDescriptorId)
);

-- Table edfi.OpenStaffPositionEventTypeDescriptor --
CREATE TABLE edfi.OpenStaffPositionEventTypeDescriptor (
    OpenStaffPositionEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT OpenStaffPositionEventTypeDescriptor_PK PRIMARY KEY (OpenStaffPositionEventTypeDescriptorId)
);

-- Table edfi.OpenStaffPositionInstructionalGradeLevel --
CREATE TABLE edfi.OpenStaffPositionInstructionalGradeLevel (
    EducationOrganizationId BIGINT NOT NULL,
    RequisitionNumber VARCHAR(20) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT OpenStaffPositionInstructionalGradeLevel_PK PRIMARY KEY (EducationOrganizationId, RequisitionNumber, GradeLevelDescriptorId)
);
ALTER TABLE edfi.OpenStaffPositionInstructionalGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.OpenStaffPositionReasonDescriptor --
CREATE TABLE edfi.OpenStaffPositionReasonDescriptor (
    OpenStaffPositionReasonDescriptorId INT NOT NULL,
    CONSTRAINT OpenStaffPositionReasonDescriptor_PK PRIMARY KEY (OpenStaffPositionReasonDescriptorId)
);

-- Table edfi.OperationalStatusDescriptor --
CREATE TABLE edfi.OperationalStatusDescriptor (
    OperationalStatusDescriptorId INT NOT NULL,
    CONSTRAINT OperationalStatusDescriptor_PK PRIMARY KEY (OperationalStatusDescriptorId)
);

-- Table edfi.OperationalUnitDimension --
CREATE TABLE edfi.OperationalUnitDimension (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    CodeName VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT OperationalUnitDimension_PK PRIMARY KEY (Code, FiscalYear)
);
ALTER TABLE edfi.OperationalUnitDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.OperationalUnitDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.OperationalUnitDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.OperationalUnitDimensionReportingTag --
CREATE TABLE edfi.OperationalUnitDimensionReportingTag (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT OperationalUnitDimensionReportingTag_PK PRIMARY KEY (Code, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.OperationalUnitDimensionReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.OrganizationDepartment --
CREATE TABLE edfi.OrganizationDepartment (
    OrganizationDepartmentId BIGINT NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    ParentEducationOrganizationId BIGINT NULL,
    CONSTRAINT OrganizationDepartment_PK PRIMARY KEY (OrganizationDepartmentId)
);

-- Table edfi.OtherNameTypeDescriptor --
CREATE TABLE edfi.OtherNameTypeDescriptor (
    OtherNameTypeDescriptorId INT NOT NULL,
    CONSTRAINT OtherNameTypeDescriptor_PK PRIMARY KEY (OtherNameTypeDescriptorId)
);

-- Table edfi.ParticipationDescriptor --
CREATE TABLE edfi.ParticipationDescriptor (
    ParticipationDescriptorId INT NOT NULL,
    CONSTRAINT ParticipationDescriptor_PK PRIMARY KEY (ParticipationDescriptorId)
);

-- Table edfi.ParticipationStatusDescriptor --
CREATE TABLE edfi.ParticipationStatusDescriptor (
    ParticipationStatusDescriptorId INT NOT NULL,
    CONSTRAINT ParticipationStatusDescriptor_PK PRIMARY KEY (ParticipationStatusDescriptorId)
);

-- Table edfi.Path --
CREATE TABLE edfi.Path (
    EducationOrganizationId BIGINT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    GraduationPlanTypeDescriptorId INT NULL,
    GraduationSchoolYear SMALLINT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Path_PK PRIMARY KEY (EducationOrganizationId, PathName)
);
ALTER TABLE edfi.Path ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Path ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Path ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PathMilestone --
CREATE TABLE edfi.PathMilestone (
    PathMilestoneName VARCHAR(60) NOT NULL,
    PathMilestoneTypeDescriptorId INT NOT NULL,
    PathMilestoneCode VARCHAR(60) NULL,
    PathMilestoneDescription VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT PathMilestone_PK PRIMARY KEY (PathMilestoneName, PathMilestoneTypeDescriptorId)
);
ALTER TABLE edfi.PathMilestone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.PathMilestone ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.PathMilestone ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PathMilestoneStatusDescriptor --
CREATE TABLE edfi.PathMilestoneStatusDescriptor (
    PathMilestoneStatusDescriptorId INT NOT NULL,
    CONSTRAINT PathMilestoneStatusDescriptor_PK PRIMARY KEY (PathMilestoneStatusDescriptorId)
);

-- Table edfi.PathMilestoneTypeDescriptor --
CREATE TABLE edfi.PathMilestoneTypeDescriptor (
    PathMilestoneTypeDescriptorId INT NOT NULL,
    CONSTRAINT PathMilestoneTypeDescriptor_PK PRIMARY KEY (PathMilestoneTypeDescriptorId)
);

-- Table edfi.PathPhase --
CREATE TABLE edfi.PathPhase (
    EducationOrganizationId BIGINT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    PathPhaseName VARCHAR(60) NOT NULL,
    PathPhaseSequence INT NULL,
    PhasePathDescription VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT PathPhase_PK PRIMARY KEY (EducationOrganizationId, PathName, PathPhaseName)
);
ALTER TABLE edfi.PathPhase ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.PathPhase ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.PathPhase ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PathPhasePathMilestone --
CREATE TABLE edfi.PathPhasePathMilestone (
    EducationOrganizationId BIGINT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    PathPhaseName VARCHAR(60) NOT NULL,
    PathMilestoneName VARCHAR(60) NOT NULL,
    PathMilestoneTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PathPhasePathMilestone_PK PRIMARY KEY (EducationOrganizationId, PathName, PathPhaseName, PathMilestoneName, PathMilestoneTypeDescriptorId)
);
ALTER TABLE edfi.PathPhasePathMilestone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PathPhaseStatusDescriptor --
CREATE TABLE edfi.PathPhaseStatusDescriptor (
    PathPhaseStatusDescriptorId INT NOT NULL,
    CONSTRAINT PathPhaseStatusDescriptor_PK PRIMARY KEY (PathPhaseStatusDescriptorId)
);

-- Table edfi.PerformanceBaseConversionDescriptor --
CREATE TABLE edfi.PerformanceBaseConversionDescriptor (
    PerformanceBaseConversionDescriptorId INT NOT NULL,
    CONSTRAINT PerformanceBaseConversionDescriptor_PK PRIMARY KEY (PerformanceBaseConversionDescriptorId)
);

-- Table edfi.PerformanceEvaluation --
CREATE TABLE edfi.PerformanceEvaluation (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    PerformanceEvaluationDescription VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT PerformanceEvaluation_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
);
ALTER TABLE edfi.PerformanceEvaluation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.PerformanceEvaluation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.PerformanceEvaluation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PerformanceEvaluationGradeLevel --
CREATE TABLE edfi.PerformanceEvaluationGradeLevel (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationGradeLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, GradeLevelDescriptorId)
);
ALTER TABLE edfi.PerformanceEvaluationGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PerformanceEvaluationRating --
CREATE TABLE edfi.PerformanceEvaluationRating (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ActualDate DATE NOT NULL,
    ActualDuration INT NULL,
    ActualTime TIME NULL,
    Announced BOOLEAN NULL,
    Comments VARCHAR(1024) NULL,
    CoteachingStyleObservedDescriptorId INT NULL,
    PerformanceEvaluationRatingLevelDescriptorId INT NULL,
    ScheduleDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT PerformanceEvaluationRating_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
);
ALTER TABLE edfi.PerformanceEvaluationRating ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.PerformanceEvaluationRating ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.PerformanceEvaluationRating ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PerformanceEvaluationRatingLevel --
CREATE TABLE edfi.PerformanceEvaluationRatingLevel (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    EvaluationRatingLevelDescriptorId INT NOT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingLevel_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId, EvaluationRatingLevelDescriptorId)
);
ALTER TABLE edfi.PerformanceEvaluationRatingLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PerformanceEvaluationRatingLevelDescriptor --
CREATE TABLE edfi.PerformanceEvaluationRatingLevelDescriptor (
    PerformanceEvaluationRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingLevelDescriptor_PK PRIMARY KEY (PerformanceEvaluationRatingLevelDescriptorId)
);

-- Table edfi.PerformanceEvaluationRatingResult --
CREATE TABLE edfi.PerformanceEvaluationRatingResult (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    NumericRating DECIMAL(6, 3) NOT NULL,
    RatingResultTitle VARCHAR(50) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingResult_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, NumericRating, RatingResultTitle)
);
ALTER TABLE edfi.PerformanceEvaluationRatingResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PerformanceEvaluationRatingReviewer --
CREATE TABLE edfi.PerformanceEvaluationRatingReviewer (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    ReviewerPersonId VARCHAR(32) NULL,
    ReviewerSourceSystemDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingReviewer_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, FirstName, LastSurname)
);
ALTER TABLE edfi.PerformanceEvaluationRatingReviewer ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PerformanceEvaluationRatingReviewerReceivedTraining --
CREATE TABLE edfi.PerformanceEvaluationRatingReviewerReceivedTraining (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    InterRaterReliabilityScore INT NULL,
    ReceivedTrainingDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PerformanceEvaluationRatingReviewerReceivedTraining_PK PRIMARY KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId, FirstName, LastSurname)
);
ALTER TABLE edfi.PerformanceEvaluationRatingReviewerReceivedTraining ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PerformanceEvaluationTypeDescriptor --
CREATE TABLE edfi.PerformanceEvaluationTypeDescriptor (
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    CONSTRAINT PerformanceEvaluationTypeDescriptor_PK PRIMARY KEY (PerformanceEvaluationTypeDescriptorId)
);

-- Table edfi.PerformanceLevelDescriptor --
CREATE TABLE edfi.PerformanceLevelDescriptor (
    PerformanceLevelDescriptorId INT NOT NULL,
    CONSTRAINT PerformanceLevelDescriptor_PK PRIMARY KEY (PerformanceLevelDescriptorId)
);

-- Table edfi.Person --
CREATE TABLE edfi.Person (
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Person_PK PRIMARY KEY (PersonId, SourceSystemDescriptorId)
);
ALTER TABLE edfi.Person ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Person ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Person ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PersonalInformationVerificationDescriptor --
CREATE TABLE edfi.PersonalInformationVerificationDescriptor (
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    CONSTRAINT PersonalInformationVerificationDescriptor_PK PRIMARY KEY (PersonalInformationVerificationDescriptorId)
);

-- Table edfi.PlatformTypeDescriptor --
CREATE TABLE edfi.PlatformTypeDescriptor (
    PlatformTypeDescriptorId INT NOT NULL,
    CONSTRAINT PlatformTypeDescriptor_PK PRIMARY KEY (PlatformTypeDescriptorId)
);

-- Table edfi.PopulationServedDescriptor --
CREATE TABLE edfi.PopulationServedDescriptor (
    PopulationServedDescriptorId INT NOT NULL,
    CONSTRAINT PopulationServedDescriptor_PK PRIMARY KEY (PopulationServedDescriptorId)
);

-- Table edfi.PostingResultDescriptor --
CREATE TABLE edfi.PostingResultDescriptor (
    PostingResultDescriptorId INT NOT NULL,
    CONSTRAINT PostingResultDescriptor_PK PRIMARY KEY (PostingResultDescriptorId)
);

-- Table edfi.PostSecondaryEvent --
CREATE TABLE edfi.PostSecondaryEvent (
    EventDate DATE NOT NULL,
    PostSecondaryEventCategoryDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    PostSecondaryInstitutionId BIGINT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT PostSecondaryEvent_PK PRIMARY KEY (EventDate, PostSecondaryEventCategoryDescriptorId, StudentUSI)
);
ALTER TABLE edfi.PostSecondaryEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.PostSecondaryEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.PostSecondaryEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PostSecondaryEventCategoryDescriptor --
CREATE TABLE edfi.PostSecondaryEventCategoryDescriptor (
    PostSecondaryEventCategoryDescriptorId INT NOT NULL,
    CONSTRAINT PostSecondaryEventCategoryDescriptor_PK PRIMARY KEY (PostSecondaryEventCategoryDescriptorId)
);

-- Table edfi.PostSecondaryInstitution --
CREATE TABLE edfi.PostSecondaryInstitution (
    PostSecondaryInstitutionId BIGINT NOT NULL,
    AdministrativeFundingControlDescriptorId INT NULL,
    FederalLocaleCodeDescriptorId INT NULL,
    PostSecondaryInstitutionLevelDescriptorId INT NULL,
    CONSTRAINT PostSecondaryInstitution_PK PRIMARY KEY (PostSecondaryInstitutionId)
);

-- Table edfi.PostSecondaryInstitutionLevelDescriptor --
CREATE TABLE edfi.PostSecondaryInstitutionLevelDescriptor (
    PostSecondaryInstitutionLevelDescriptorId INT NOT NULL,
    CONSTRAINT PostSecondaryInstitutionLevelDescriptor_PK PRIMARY KEY (PostSecondaryInstitutionLevelDescriptorId)
);

-- Table edfi.PostSecondaryInstitutionMediumOfInstruction --
CREATE TABLE edfi.PostSecondaryInstitutionMediumOfInstruction (
    PostSecondaryInstitutionId BIGINT NOT NULL,
    MediumOfInstructionDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT PostSecondaryInstitutionMediumOfInstruction_PK PRIMARY KEY (PostSecondaryInstitutionId, MediumOfInstructionDescriptorId)
);
ALTER TABLE edfi.PostSecondaryInstitutionMediumOfInstruction ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.PreviousCareerDescriptor --
CREATE TABLE edfi.PreviousCareerDescriptor (
    PreviousCareerDescriptorId INT NOT NULL,
    CONSTRAINT PreviousCareerDescriptor_PK PRIMARY KEY (PreviousCareerDescriptorId)
);

-- Table edfi.PrimaryLearningDeviceAccessDescriptor --
CREATE TABLE edfi.PrimaryLearningDeviceAccessDescriptor (
    PrimaryLearningDeviceAccessDescriptorId INT NOT NULL,
    CONSTRAINT PrimaryLearningDeviceAccessDescriptor_PK PRIMARY KEY (PrimaryLearningDeviceAccessDescriptorId)
);

-- Table edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor --
CREATE TABLE edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor (
    PrimaryLearningDeviceAwayFromSchoolDescriptorId INT NOT NULL,
    CONSTRAINT PrimaryLearningDeviceAwayFromSchoolDescriptor_PK PRIMARY KEY (PrimaryLearningDeviceAwayFromSchoolDescriptorId)
);

-- Table edfi.PrimaryLearningDeviceProviderDescriptor --
CREATE TABLE edfi.PrimaryLearningDeviceProviderDescriptor (
    PrimaryLearningDeviceProviderDescriptorId INT NOT NULL,
    CONSTRAINT PrimaryLearningDeviceProviderDescriptor_PK PRIMARY KEY (PrimaryLearningDeviceProviderDescriptorId)
);

-- Table edfi.ProfessionalDevelopmentEvent --
CREATE TABLE edfi.ProfessionalDevelopmentEvent (
    Namespace VARCHAR(255) NOT NULL,
    ProfessionalDevelopmentTitle VARCHAR(60) NOT NULL,
    MultipleSession BOOLEAN NULL,
    ProfessionalDevelopmentOfferedByDescriptorId INT NOT NULL,
    ProfessionalDevelopmentReason VARCHAR(60) NULL,
    Required BOOLEAN NULL,
    TotalHours INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ProfessionalDevelopmentEvent_PK PRIMARY KEY (Namespace, ProfessionalDevelopmentTitle)
);
ALTER TABLE edfi.ProfessionalDevelopmentEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ProfessionalDevelopmentEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ProfessionalDevelopmentEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProfessionalDevelopmentEventAttendance --
CREATE TABLE edfi.ProfessionalDevelopmentEventAttendance (
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
ALTER TABLE edfi.ProfessionalDevelopmentEventAttendance ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ProfessionalDevelopmentEventAttendance ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ProfessionalDevelopmentEventAttendance ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProfessionalDevelopmentOfferedByDescriptor --
CREATE TABLE edfi.ProfessionalDevelopmentOfferedByDescriptor (
    ProfessionalDevelopmentOfferedByDescriptorId INT NOT NULL,
    CONSTRAINT ProfessionalDevelopmentOfferedByDescriptor_PK PRIMARY KEY (ProfessionalDevelopmentOfferedByDescriptorId)
);

-- Table edfi.ProficiencyDescriptor --
CREATE TABLE edfi.ProficiencyDescriptor (
    ProficiencyDescriptorId INT NOT NULL,
    CONSTRAINT ProficiencyDescriptor_PK PRIMARY KEY (ProficiencyDescriptorId)
);

-- Table edfi.Program --
CREATE TABLE edfi.Program (
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ProgramId VARCHAR(20) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Program_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.Program ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Program ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Program ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramAssignmentDescriptor --
CREATE TABLE edfi.ProgramAssignmentDescriptor (
    ProgramAssignmentDescriptorId INT NOT NULL,
    CONSTRAINT ProgramAssignmentDescriptor_PK PRIMARY KEY (ProgramAssignmentDescriptorId)
);

-- Table edfi.ProgramCharacteristic --
CREATE TABLE edfi.ProgramCharacteristic (
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ProgramCharacteristicDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProgramCharacteristic_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, ProgramCharacteristicDescriptorId)
);
ALTER TABLE edfi.ProgramCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramCharacteristicDescriptor --
CREATE TABLE edfi.ProgramCharacteristicDescriptor (
    ProgramCharacteristicDescriptorId INT NOT NULL,
    CONSTRAINT ProgramCharacteristicDescriptor_PK PRIMARY KEY (ProgramCharacteristicDescriptorId)
);

-- Table edfi.ProgramDimension --
CREATE TABLE edfi.ProgramDimension (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    CodeName VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ProgramDimension_PK PRIMARY KEY (Code, FiscalYear)
);
ALTER TABLE edfi.ProgramDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ProgramDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ProgramDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramDimensionReportingTag --
CREATE TABLE edfi.ProgramDimensionReportingTag (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProgramDimensionReportingTag_PK PRIMARY KEY (Code, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.ProgramDimensionReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramEvaluation --
CREATE TABLE edfi.ProgramEvaluation (
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    EvaluationMaxNumericRating DECIMAL(6, 3) NULL,
    EvaluationMinNumericRating DECIMAL(6, 3) NULL,
    ProgramEvaluationDescription VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ProgramEvaluation_PK PRIMARY KEY (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.ProgramEvaluation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ProgramEvaluation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ProgramEvaluation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramEvaluationElement --
CREATE TABLE edfi.ProgramEvaluationElement (
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationElementTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ElementMaxNumericRating DECIMAL(6, 3) NULL,
    ElementMinNumericRating DECIMAL(6, 3) NULL,
    ElementSortOrder INT NULL,
    ProgramEvaluationElementDescription VARCHAR(255) NULL,
    ProgramEvaluationObjectiveTitle VARCHAR(50) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ProgramEvaluationElement_PK PRIMARY KEY (ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.ProgramEvaluationElement ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ProgramEvaluationElement ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ProgramEvaluationElement ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramEvaluationElementProgramEvaluationLevel --
CREATE TABLE edfi.ProgramEvaluationElementProgramEvaluationLevel (
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationElementTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    RatingLevelDescriptorId INT NOT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProgramEvaluationElementProgramEvaluationLevel_PK PRIMARY KEY (ProgramEducationOrganizationId, ProgramEvaluationElementTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, RatingLevelDescriptorId)
);
ALTER TABLE edfi.ProgramEvaluationElementProgramEvaluationLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramEvaluationLevel --
CREATE TABLE edfi.ProgramEvaluationLevel (
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    RatingLevelDescriptorId INT NOT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProgramEvaluationLevel_PK PRIMARY KEY (ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, RatingLevelDescriptorId)
);
ALTER TABLE edfi.ProgramEvaluationLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramEvaluationObjective --
CREATE TABLE edfi.ProgramEvaluationObjective (
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ObjectiveMaxNumericRating DECIMAL(6, 3) NULL,
    ObjectiveMinNumericRating DECIMAL(6, 3) NULL,
    ObjectiveSortOrder INT NULL,
    ProgramEvaluationObjectiveDescription VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ProgramEvaluationObjective_PK PRIMARY KEY (ProgramEducationOrganizationId, ProgramEvaluationObjectiveTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.ProgramEvaluationObjective ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ProgramEvaluationObjective ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ProgramEvaluationObjective ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramEvaluationObjectiveProgramEvaluationLevel --
CREATE TABLE edfi.ProgramEvaluationObjectiveProgramEvaluationLevel (
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    RatingLevelDescriptorId INT NOT NULL,
    MaxNumericRating DECIMAL(6, 3) NULL,
    MinNumericRating DECIMAL(6, 3) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProgramEvaluationObjectiveProgramEvaluationLevel_PK PRIMARY KEY (ProgramEducationOrganizationId, ProgramEvaluationObjectiveTitle, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, RatingLevelDescriptorId)
);
ALTER TABLE edfi.ProgramEvaluationObjectiveProgramEvaluationLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramEvaluationPeriodDescriptor --
CREATE TABLE edfi.ProgramEvaluationPeriodDescriptor (
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    CONSTRAINT ProgramEvaluationPeriodDescriptor_PK PRIMARY KEY (ProgramEvaluationPeriodDescriptorId)
);

-- Table edfi.ProgramEvaluationTypeDescriptor --
CREATE TABLE edfi.ProgramEvaluationTypeDescriptor (
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    CONSTRAINT ProgramEvaluationTypeDescriptor_PK PRIMARY KEY (ProgramEvaluationTypeDescriptorId)
);

-- Table edfi.ProgramLearningStandard --
CREATE TABLE edfi.ProgramLearningStandard (
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    LearningStandardId VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProgramLearningStandard_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, LearningStandardId)
);
ALTER TABLE edfi.ProgramLearningStandard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramSponsor --
CREATE TABLE edfi.ProgramSponsor (
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ProgramSponsorDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProgramSponsor_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, ProgramSponsorDescriptorId)
);
ALTER TABLE edfi.ProgramSponsor ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProgramSponsorDescriptor --
CREATE TABLE edfi.ProgramSponsorDescriptor (
    ProgramSponsorDescriptorId INT NOT NULL,
    CONSTRAINT ProgramSponsorDescriptor_PK PRIMARY KEY (ProgramSponsorDescriptorId)
);

-- Table edfi.ProgramTypeDescriptor --
CREATE TABLE edfi.ProgramTypeDescriptor (
    ProgramTypeDescriptorId INT NOT NULL,
    CONSTRAINT ProgramTypeDescriptor_PK PRIMARY KEY (ProgramTypeDescriptorId)
);

-- Table edfi.ProgressDescriptor --
CREATE TABLE edfi.ProgressDescriptor (
    ProgressDescriptorId INT NOT NULL,
    CONSTRAINT ProgressDescriptor_PK PRIMARY KEY (ProgressDescriptorId)
);

-- Table edfi.ProgressLevelDescriptor --
CREATE TABLE edfi.ProgressLevelDescriptor (
    ProgressLevelDescriptorId INT NOT NULL,
    CONSTRAINT ProgressLevelDescriptor_PK PRIMARY KEY (ProgressLevelDescriptorId)
);

-- Table edfi.ProjectDimension --
CREATE TABLE edfi.ProjectDimension (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    CodeName VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ProjectDimension_PK PRIMARY KEY (Code, FiscalYear)
);
ALTER TABLE edfi.ProjectDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ProjectDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ProjectDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProjectDimensionReportingTag --
CREATE TABLE edfi.ProjectDimensionReportingTag (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProjectDimensionReportingTag_PK PRIMARY KEY (Code, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.ProjectDimensionReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ProviderCategoryDescriptor --
CREATE TABLE edfi.ProviderCategoryDescriptor (
    ProviderCategoryDescriptorId INT NOT NULL,
    CONSTRAINT ProviderCategoryDescriptor_PK PRIMARY KEY (ProviderCategoryDescriptorId)
);

-- Table edfi.ProviderProfitabilityDescriptor --
CREATE TABLE edfi.ProviderProfitabilityDescriptor (
    ProviderProfitabilityDescriptorId INT NOT NULL,
    CONSTRAINT ProviderProfitabilityDescriptor_PK PRIMARY KEY (ProviderProfitabilityDescriptorId)
);

-- Table edfi.ProviderStatusDescriptor --
CREATE TABLE edfi.ProviderStatusDescriptor (
    ProviderStatusDescriptorId INT NOT NULL,
    CONSTRAINT ProviderStatusDescriptor_PK PRIMARY KEY (ProviderStatusDescriptorId)
);

-- Table edfi.PublicationStatusDescriptor --
CREATE TABLE edfi.PublicationStatusDescriptor (
    PublicationStatusDescriptorId INT NOT NULL,
    CONSTRAINT PublicationStatusDescriptor_PK PRIMARY KEY (PublicationStatusDescriptorId)
);

-- Table edfi.QuantitativeMeasure --
CREATE TABLE edfi.QuantitativeMeasure (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    QuantitativeMeasureIdentifier VARCHAR(64) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    QuantitativeMeasureDatatypeDescriptorId INT NULL,
    QuantitativeMeasureTypeDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT QuantitativeMeasure_PK PRIMARY KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId)
);
ALTER TABLE edfi.QuantitativeMeasure ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.QuantitativeMeasure ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.QuantitativeMeasure ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.QuantitativeMeasureDatatypeDescriptor --
CREATE TABLE edfi.QuantitativeMeasureDatatypeDescriptor (
    QuantitativeMeasureDatatypeDescriptorId INT NOT NULL,
    CONSTRAINT QuantitativeMeasureDatatypeDescriptor_PK PRIMARY KEY (QuantitativeMeasureDatatypeDescriptorId)
);

-- Table edfi.QuantitativeMeasureScore --
CREATE TABLE edfi.QuantitativeMeasureScore (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
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
ALTER TABLE edfi.QuantitativeMeasureScore ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.QuantitativeMeasureScore ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.QuantitativeMeasureScore ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.QuantitativeMeasureTypeDescriptor --
CREATE TABLE edfi.QuantitativeMeasureTypeDescriptor (
    QuantitativeMeasureTypeDescriptorId INT NOT NULL,
    CONSTRAINT QuantitativeMeasureTypeDescriptor_PK PRIMARY KEY (QuantitativeMeasureTypeDescriptorId)
);

-- Table edfi.QuestionFormDescriptor --
CREATE TABLE edfi.QuestionFormDescriptor (
    QuestionFormDescriptorId INT NOT NULL,
    CONSTRAINT QuestionFormDescriptor_PK PRIMARY KEY (QuestionFormDescriptorId)
);

-- Table edfi.RaceDescriptor --
CREATE TABLE edfi.RaceDescriptor (
    RaceDescriptorId INT NOT NULL,
    CONSTRAINT RaceDescriptor_PK PRIMARY KEY (RaceDescriptorId)
);

-- Table edfi.RatingLevelDescriptor --
CREATE TABLE edfi.RatingLevelDescriptor (
    RatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT RatingLevelDescriptor_PK PRIMARY KEY (RatingLevelDescriptorId)
);

-- Table edfi.ReasonExitedDescriptor --
CREATE TABLE edfi.ReasonExitedDescriptor (
    ReasonExitedDescriptorId INT NOT NULL,
    CONSTRAINT ReasonExitedDescriptor_PK PRIMARY KEY (ReasonExitedDescriptorId)
);

-- Table edfi.ReasonNotTestedDescriptor --
CREATE TABLE edfi.ReasonNotTestedDescriptor (
    ReasonNotTestedDescriptorId INT NOT NULL,
    CONSTRAINT ReasonNotTestedDescriptor_PK PRIMARY KEY (ReasonNotTestedDescriptorId)
);

-- Table edfi.RecognitionTypeDescriptor --
CREATE TABLE edfi.RecognitionTypeDescriptor (
    RecognitionTypeDescriptorId INT NOT NULL,
    CONSTRAINT RecognitionTypeDescriptor_PK PRIMARY KEY (RecognitionTypeDescriptorId)
);

-- Table edfi.RecruitmentEvent --
CREATE TABLE edfi.RecruitmentEvent (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    EventDescription VARCHAR(255) NULL,
    EventLocation VARCHAR(255) NULL,
    RecruitmentEventTypeDescriptorId INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT RecruitmentEvent_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle)
);
ALTER TABLE edfi.RecruitmentEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.RecruitmentEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.RecruitmentEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendance --
CREATE TABLE edfi.RecruitmentEventAttendance (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    Applied BOOLEAN NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenderIdentity VARCHAR(60) NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    LastSurname VARCHAR(75) NOT NULL,
    MaidenName VARCHAR(75) NULL,
    Met BOOLEAN NULL,
    MiddleName VARCHAR(75) NULL,
    Notes VARCHAR(255) NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    PreferredFirstName VARCHAR(75) NULL,
    PreferredLastSurname VARCHAR(75) NULL,
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
ALTER TABLE edfi.RecruitmentEventAttendance ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.RecruitmentEventAttendance ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.RecruitmentEventAttendance ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendanceCurrentPosition --
CREATE TABLE edfi.RecruitmentEventAttendanceCurrentPosition (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    Location VARCHAR(75) NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    PositionTitle VARCHAR(100) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceCurrentPosition_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
);
ALTER TABLE edfi.RecruitmentEventAttendanceCurrentPosition ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendanceCurrentPositionGradeLevel --
CREATE TABLE edfi.RecruitmentEventAttendanceCurrentPositionGradeLevel (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceCurrentPositionGradeLevel_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, GradeLevelDescriptorId)
);
ALTER TABLE edfi.RecruitmentEventAttendanceCurrentPositionGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendanceDisability --
CREATE TABLE edfi.RecruitmentEventAttendanceDisability (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceDisability_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, DisabilityDescriptorId)
);
ALTER TABLE edfi.RecruitmentEventAttendanceDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendanceDisabilityDesignation --
CREATE TABLE edfi.RecruitmentEventAttendanceDisabilityDesignation (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceDisabilityDesignation_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
);
ALTER TABLE edfi.RecruitmentEventAttendanceDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendancePersonalIdentificationDocument --
CREATE TABLE edfi.RecruitmentEventAttendancePersonalIdentificationDocument (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendancePersonalIdentificationDocument_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.RecruitmentEventAttendancePersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendanceRace --
CREATE TABLE edfi.RecruitmentEventAttendanceRace (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceRace_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, RaceDescriptorId)
);
ALTER TABLE edfi.RecruitmentEventAttendanceRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7 --
CREATE TABLE edfi.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7 (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    CapacityToServe BOOLEAN NULL,
    Eligible BOOLEAN NOT NULL,
    YearsOfServiceCurrentPlacement DECIMAL(5, 2) NULL,
    YearsOfServiceTotal DECIMAL(5, 2) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceRecruitmentEventAttendee_82dbb7_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier)
);
ALTER TABLE edfi.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendanceTelephone --
CREATE TABLE edfi.RecruitmentEventAttendanceTelephone (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceTelephone_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.RecruitmentEventAttendanceTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendanceTouchpoint --
CREATE TABLE edfi.RecruitmentEventAttendanceTouchpoint (
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
    TouchpointContent VARCHAR(255) NOT NULL,
    TouchpointDate DATE NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RecruitmentEventAttendanceTouchpoint_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, RecruitmentEventAttendeeIdentifier, TouchpointContent, TouchpointDate)
);
ALTER TABLE edfi.RecruitmentEventAttendanceTouchpoint ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RecruitmentEventAttendeeTypeDescriptor --
CREATE TABLE edfi.RecruitmentEventAttendeeTypeDescriptor (
    RecruitmentEventAttendeeTypeDescriptorId INT NOT NULL,
    CONSTRAINT RecruitmentEventAttendeeTypeDescriptor_PK PRIMARY KEY (RecruitmentEventAttendeeTypeDescriptorId)
);

-- Table edfi.RecruitmentEventTypeDescriptor --
CREATE TABLE edfi.RecruitmentEventTypeDescriptor (
    RecruitmentEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT RecruitmentEventTypeDescriptor_PK PRIMARY KEY (RecruitmentEventTypeDescriptorId)
);

-- Table edfi.RelationDescriptor --
CREATE TABLE edfi.RelationDescriptor (
    RelationDescriptorId INT NOT NULL,
    CONSTRAINT RelationDescriptor_PK PRIMARY KEY (RelationDescriptorId)
);

-- Table edfi.RepeatIdentifierDescriptor --
CREATE TABLE edfi.RepeatIdentifierDescriptor (
    RepeatIdentifierDescriptorId INT NOT NULL,
    CONSTRAINT RepeatIdentifierDescriptor_PK PRIMARY KEY (RepeatIdentifierDescriptorId)
);

-- Table edfi.ReportCard --
CREATE TABLE edfi.ReportCard (
    EducationOrganizationId BIGINT NOT NULL,
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolId BIGINT NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    NumberOfDaysAbsent DECIMAL(18, 4) NULL,
    NumberOfDaysInAttendance DECIMAL(18, 4) NULL,
    NumberOfDaysTardy INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ReportCard_PK PRIMARY KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI)
);
ALTER TABLE edfi.ReportCard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.ReportCard ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.ReportCard ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ReportCardGrade --
CREATE TABLE edfi.ReportCardGrade (
    EducationOrganizationId BIGINT NOT NULL,
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolId BIGINT NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    GradeTypeDescriptorId INT NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ReportCardGrade_PK PRIMARY KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI, BeginDate, GradeTypeDescriptorId, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
);
ALTER TABLE edfi.ReportCardGrade ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ReportCardGradePointAverage --
CREATE TABLE edfi.ReportCardGradePointAverage (
    EducationOrganizationId BIGINT NOT NULL,
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolId BIGINT NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    GradePointAverageTypeDescriptorId INT NOT NULL,
    GradePointAverageValue DECIMAL(18, 4) NOT NULL,
    IsCumulative BOOLEAN NULL,
    MaxGradePointAverageValue DECIMAL(18, 4) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ReportCardGradePointAverage_PK PRIMARY KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI, GradePointAverageTypeDescriptorId)
);
ALTER TABLE edfi.ReportCardGradePointAverage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ReportCardStudentCompetencyObjective --
CREATE TABLE edfi.ReportCardStudentCompetencyObjective (
    EducationOrganizationId BIGINT NOT NULL,
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolId BIGINT NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    ObjectiveEducationOrganizationId BIGINT NOT NULL,
    Objective VARCHAR(60) NOT NULL,
    ObjectiveGradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ReportCardStudentCompetencyObjective_PK PRIMARY KEY (EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolId, GradingPeriodSchoolYear, StudentUSI, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId)
);
ALTER TABLE edfi.ReportCardStudentCompetencyObjective ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.ReporterDescriptionDescriptor --
CREATE TABLE edfi.ReporterDescriptionDescriptor (
    ReporterDescriptionDescriptorId INT NOT NULL,
    CONSTRAINT ReporterDescriptionDescriptor_PK PRIMARY KEY (ReporterDescriptionDescriptorId)
);

-- Table edfi.ReportingTagDescriptor --
CREATE TABLE edfi.ReportingTagDescriptor (
    ReportingTagDescriptorId INT NOT NULL,
    CONSTRAINT ReportingTagDescriptor_PK PRIMARY KEY (ReportingTagDescriptorId)
);

-- Table edfi.ResidencyStatusDescriptor --
CREATE TABLE edfi.ResidencyStatusDescriptor (
    ResidencyStatusDescriptorId INT NOT NULL,
    CONSTRAINT ResidencyStatusDescriptor_PK PRIMARY KEY (ResidencyStatusDescriptorId)
);

-- Table edfi.ResponseIndicatorDescriptor --
CREATE TABLE edfi.ResponseIndicatorDescriptor (
    ResponseIndicatorDescriptorId INT NOT NULL,
    CONSTRAINT ResponseIndicatorDescriptor_PK PRIMARY KEY (ResponseIndicatorDescriptorId)
);

-- Table edfi.ResponsibilityDescriptor --
CREATE TABLE edfi.ResponsibilityDescriptor (
    ResponsibilityDescriptorId INT NOT NULL,
    CONSTRAINT ResponsibilityDescriptor_PK PRIMARY KEY (ResponsibilityDescriptorId)
);

-- Table edfi.RestraintEvent --
CREATE TABLE edfi.RestraintEvent (
    RestraintEventIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    EducationalEnvironmentDescriptorId INT NULL,
    EventDate DATE NOT NULL,
    IncidentIdentifier VARCHAR(36) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT RestraintEvent_PK PRIMARY KEY (RestraintEventIdentifier, SchoolId, StudentUSI)
);
ALTER TABLE edfi.RestraintEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.RestraintEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.RestraintEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RestraintEventProgram --
CREATE TABLE edfi.RestraintEventProgram (
    RestraintEventIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RestraintEventProgram_PK PRIMARY KEY (RestraintEventIdentifier, SchoolId, StudentUSI, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.RestraintEventProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RestraintEventReason --
CREATE TABLE edfi.RestraintEventReason (
    RestraintEventIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    RestraintEventReasonDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT RestraintEventReason_PK PRIMARY KEY (RestraintEventIdentifier, SchoolId, StudentUSI, RestraintEventReasonDescriptorId)
);
ALTER TABLE edfi.RestraintEventReason ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RestraintEventReasonDescriptor --
CREATE TABLE edfi.RestraintEventReasonDescriptor (
    RestraintEventReasonDescriptorId INT NOT NULL,
    CONSTRAINT RestraintEventReasonDescriptor_PK PRIMARY KEY (RestraintEventReasonDescriptorId)
);

-- Table edfi.ResultDatatypeTypeDescriptor --
CREATE TABLE edfi.ResultDatatypeTypeDescriptor (
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CONSTRAINT ResultDatatypeTypeDescriptor_PK PRIMARY KEY (ResultDatatypeTypeDescriptorId)
);

-- Table edfi.RetestIndicatorDescriptor --
CREATE TABLE edfi.RetestIndicatorDescriptor (
    RetestIndicatorDescriptorId INT NOT NULL,
    CONSTRAINT RetestIndicatorDescriptor_PK PRIMARY KEY (RetestIndicatorDescriptorId)
);

-- Table edfi.RubricDimension --
CREATE TABLE edfi.RubricDimension (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationElementTitle VARCHAR(255) NOT NULL,
    EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationPeriodDescriptorId INT NOT NULL,
    EvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
    PerformanceEvaluationTypeDescriptorId INT NOT NULL,
    RubricRating INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CriterionDescription VARCHAR(1024) NOT NULL,
    DimensionOrder INT NULL,
    RubricRatingLevelDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT RubricDimension_PK PRIMARY KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, RubricRating, SchoolYear, TermDescriptorId)
);
ALTER TABLE edfi.RubricDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.RubricDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.RubricDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.RubricRatingLevelDescriptor --
CREATE TABLE edfi.RubricRatingLevelDescriptor (
    RubricRatingLevelDescriptorId INT NOT NULL,
    CONSTRAINT RubricRatingLevelDescriptor_PK PRIMARY KEY (RubricRatingLevelDescriptorId)
);

-- Table edfi.SalaryTypeDescriptor --
CREATE TABLE edfi.SalaryTypeDescriptor (
    SalaryTypeDescriptorId INT NOT NULL,
    CONSTRAINT SalaryTypeDescriptor_PK PRIMARY KEY (SalaryTypeDescriptorId)
);

-- Table edfi.School --
CREATE TABLE edfi.School (
    SchoolId BIGINT NOT NULL,
    AccreditationStatusDescriptorId INT NULL,
    AdministrativeFundingControlDescriptorId INT NULL,
    CharterApprovalAgencyTypeDescriptorId INT NULL,
    CharterApprovalSchoolYear SMALLINT NULL,
    CharterStatusDescriptorId INT NULL,
    FederalLocaleCodeDescriptorId INT NULL,
    ImprovingSchool BOOLEAN NULL,
    InternetAccessDescriptorId INT NULL,
    LocalEducationAgencyId BIGINT NULL,
    MagnetSpecialProgramEmphasisSchoolDescriptorId INT NULL,
    PostSecondaryInstitutionId BIGINT NULL,
    SchoolTypeDescriptorId INT NULL,
    TitleIPartASchoolDesignationDescriptorId INT NULL,
    CONSTRAINT School_PK PRIMARY KEY (SchoolId)
);

-- Table edfi.SchoolCategory --
CREATE TABLE edfi.SchoolCategory (
    SchoolId BIGINT NOT NULL,
    SchoolCategoryDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SchoolCategory_PK PRIMARY KEY (SchoolId, SchoolCategoryDescriptorId)
);
ALTER TABLE edfi.SchoolCategory ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SchoolCategoryDescriptor --
CREATE TABLE edfi.SchoolCategoryDescriptor (
    SchoolCategoryDescriptorId INT NOT NULL,
    CONSTRAINT SchoolCategoryDescriptor_PK PRIMARY KEY (SchoolCategoryDescriptorId)
);

-- Table edfi.SchoolChoiceBasisDescriptor --
CREATE TABLE edfi.SchoolChoiceBasisDescriptor (
    SchoolChoiceBasisDescriptorId INT NOT NULL,
    CONSTRAINT SchoolChoiceBasisDescriptor_PK PRIMARY KEY (SchoolChoiceBasisDescriptorId)
);

-- Table edfi.SchoolChoiceImplementStatusDescriptor --
CREATE TABLE edfi.SchoolChoiceImplementStatusDescriptor (
    SchoolChoiceImplementStatusDescriptorId INT NOT NULL,
    CONSTRAINT SchoolChoiceImplementStatusDescriptor_PK PRIMARY KEY (SchoolChoiceImplementStatusDescriptorId)
);

-- Table edfi.SchoolFoodServiceProgramServiceDescriptor --
CREATE TABLE edfi.SchoolFoodServiceProgramServiceDescriptor (
    SchoolFoodServiceProgramServiceDescriptorId INT NOT NULL,
    CONSTRAINT SchoolFoodServiceProgramServiceDescriptor_PK PRIMARY KEY (SchoolFoodServiceProgramServiceDescriptorId)
);

-- Table edfi.SchoolGradeLevel --
CREATE TABLE edfi.SchoolGradeLevel (
    SchoolId BIGINT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SchoolGradeLevel_PK PRIMARY KEY (SchoolId, GradeLevelDescriptorId)
);
ALTER TABLE edfi.SchoolGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SchoolTypeDescriptor --
CREATE TABLE edfi.SchoolTypeDescriptor (
    SchoolTypeDescriptorId INT NOT NULL,
    CONSTRAINT SchoolTypeDescriptor_PK PRIMARY KEY (SchoolTypeDescriptorId)
);

-- Table edfi.SchoolYearType --
CREATE TABLE edfi.SchoolYearType (
    SchoolYear SMALLINT NOT NULL,
    SchoolYearDescription VARCHAR(50) NOT NULL,
    CurrentSchoolYear BOOLEAN NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SchoolYearType_PK PRIMARY KEY (SchoolYear)
);
ALTER TABLE edfi.SchoolYearType ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SchoolYearType ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SchoolYearType ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Section --
CREATE TABLE edfi.Section (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    AvailableCreditConversion DECIMAL(9, 2) NULL,
    AvailableCredits DECIMAL(9, 3) NULL,
    AvailableCreditTypeDescriptorId INT NULL,
    EducationalEnvironmentDescriptorId INT NULL,
    InstructionLanguageDescriptorId INT NULL,
    LocationClassroomIdentificationCode VARCHAR(60) NULL,
    LocationSchoolId BIGINT NULL,
    MediumOfInstructionDescriptorId INT NULL,
    OfficialAttendancePeriod BOOLEAN NULL,
    PopulationServedDescriptorId INT NULL,
    SectionName VARCHAR(100) NULL,
    SectionTypeDescriptorId INT NULL,
    SequenceOfCourse INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Section_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
);
ALTER TABLE edfi.Section ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Section ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Section ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Section504DisabilityDescriptor --
CREATE TABLE edfi.Section504DisabilityDescriptor (
    Section504DisabilityDescriptorId INT NOT NULL,
    CONSTRAINT Section504DisabilityDescriptor_PK PRIMARY KEY (Section504DisabilityDescriptorId)
);

-- Table edfi.SectionAttendanceTakenEvent --
CREATE TABLE edfi.SectionAttendanceTakenEvent (
    CalendarCode VARCHAR(120) NOT NULL,
    Date DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    EventDate DATE NOT NULL,
    StaffUSI INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SectionAttendanceTakenEvent_PK PRIMARY KEY (CalendarCode, Date, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
);
ALTER TABLE edfi.SectionAttendanceTakenEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SectionAttendanceTakenEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SectionAttendanceTakenEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SectionCharacteristic --
CREATE TABLE edfi.SectionCharacteristic (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    SectionCharacteristicDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SectionCharacteristic_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, SectionCharacteristicDescriptorId)
);
ALTER TABLE edfi.SectionCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SectionCharacteristicDescriptor --
CREATE TABLE edfi.SectionCharacteristicDescriptor (
    SectionCharacteristicDescriptorId INT NOT NULL,
    CONSTRAINT SectionCharacteristicDescriptor_PK PRIMARY KEY (SectionCharacteristicDescriptorId)
);

-- Table edfi.SectionClassPeriod --
CREATE TABLE edfi.SectionClassPeriod (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    ClassPeriodName VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SectionClassPeriod_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, ClassPeriodName)
);
ALTER TABLE edfi.SectionClassPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SectionCourseLevelCharacteristic --
CREATE TABLE edfi.SectionCourseLevelCharacteristic (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CourseLevelCharacteristicDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SectionCourseLevelCharacteristic_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, CourseLevelCharacteristicDescriptorId)
);
ALTER TABLE edfi.SectionCourseLevelCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SectionOfferedGradeLevel --
CREATE TABLE edfi.SectionOfferedGradeLevel (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SectionOfferedGradeLevel_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, GradeLevelDescriptorId)
);
ALTER TABLE edfi.SectionOfferedGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SectionProgram --
CREATE TABLE edfi.SectionProgram (
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SectionProgram_PK PRIMARY KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.SectionProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SectionTypeDescriptor --
CREATE TABLE edfi.SectionTypeDescriptor (
    SectionTypeDescriptorId INT NOT NULL,
    CONSTRAINT SectionTypeDescriptor_PK PRIMARY KEY (SectionTypeDescriptorId)
);

-- Table edfi.SeparationDescriptor --
CREATE TABLE edfi.SeparationDescriptor (
    SeparationDescriptorId INT NOT NULL,
    CONSTRAINT SeparationDescriptor_PK PRIMARY KEY (SeparationDescriptorId)
);

-- Table edfi.SeparationReasonDescriptor --
CREATE TABLE edfi.SeparationReasonDescriptor (
    SeparationReasonDescriptorId INT NOT NULL,
    CONSTRAINT SeparationReasonDescriptor_PK PRIMARY KEY (SeparationReasonDescriptorId)
);

-- Table edfi.ServiceDescriptor --
CREATE TABLE edfi.ServiceDescriptor (
    ServiceDescriptorId INT NOT NULL,
    CONSTRAINT ServiceDescriptor_PK PRIMARY KEY (ServiceDescriptorId)
);

-- Table edfi.Session --
CREATE TABLE edfi.Session (
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TermDescriptorId INT NOT NULL,
    TotalInstructionalDays INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Session_PK PRIMARY KEY (SchoolId, SchoolYear, SessionName)
);
ALTER TABLE edfi.Session ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Session ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Session ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SessionAcademicWeek --
CREATE TABLE edfi.SessionAcademicWeek (
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    WeekIdentifier VARCHAR(80) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SessionAcademicWeek_PK PRIMARY KEY (SchoolId, SchoolYear, SessionName, WeekIdentifier)
);
ALTER TABLE edfi.SessionAcademicWeek ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SessionGradingPeriod --
CREATE TABLE edfi.SessionGradingPeriod (
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SessionGradingPeriod_PK PRIMARY KEY (SchoolId, SchoolYear, SessionName, GradingPeriodDescriptorId, GradingPeriodName)
);
ALTER TABLE edfi.SessionGradingPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SexDescriptor --
CREATE TABLE edfi.SexDescriptor (
    SexDescriptorId INT NOT NULL,
    CONSTRAINT SexDescriptor_PK PRIMARY KEY (SexDescriptorId)
);

-- Table edfi.SourceDimension --
CREATE TABLE edfi.SourceDimension (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    CodeName VARCHAR(100) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SourceDimension_PK PRIMARY KEY (Code, FiscalYear)
);
ALTER TABLE edfi.SourceDimension ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SourceDimension ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SourceDimension ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SourceDimensionReportingTag --
CREATE TABLE edfi.SourceDimensionReportingTag (
    Code VARCHAR(16) NOT NULL,
    FiscalYear INT NOT NULL,
    ReportingTagDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SourceDimensionReportingTag_PK PRIMARY KEY (Code, FiscalYear, ReportingTagDescriptorId)
);
ALTER TABLE edfi.SourceDimensionReportingTag ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SourceSystemDescriptor --
CREATE TABLE edfi.SourceSystemDescriptor (
    SourceSystemDescriptorId INT NOT NULL,
    CONSTRAINT SourceSystemDescriptor_PK PRIMARY KEY (SourceSystemDescriptorId)
);

-- Table edfi.SpecialEducationExitReasonDescriptor --
CREATE TABLE edfi.SpecialEducationExitReasonDescriptor (
    SpecialEducationExitReasonDescriptorId INT NOT NULL,
    CONSTRAINT SpecialEducationExitReasonDescriptor_PK PRIMARY KEY (SpecialEducationExitReasonDescriptorId)
);

-- Table edfi.SpecialEducationProgramServiceDescriptor --
CREATE TABLE edfi.SpecialEducationProgramServiceDescriptor (
    SpecialEducationProgramServiceDescriptorId INT NOT NULL,
    CONSTRAINT SpecialEducationProgramServiceDescriptor_PK PRIMARY KEY (SpecialEducationProgramServiceDescriptorId)
);

-- Table edfi.SpecialEducationSettingDescriptor --
CREATE TABLE edfi.SpecialEducationSettingDescriptor (
    SpecialEducationSettingDescriptorId INT NOT NULL,
    CONSTRAINT SpecialEducationSettingDescriptor_PK PRIMARY KEY (SpecialEducationSettingDescriptorId)
);

-- Table edfi.Staff --
CREATE TABLE edfi.Staff (
    StaffUSI SERIAL NOT NULL,
    BirthDate DATE NULL,
    CitizenshipStatusDescriptorId INT NULL,
    EducationOrganizationId BIGINT NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenderIdentity VARCHAR(60) NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    HighestCompletedLevelOfEducationDescriptorId INT NULL,
    HighlyQualifiedTeacher BOOLEAN NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    LastSurname VARCHAR(75) NOT NULL,
    LoginId VARCHAR(120) NULL,
    MaidenName VARCHAR(75) NULL,
    MiddleName VARCHAR(75) NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    PersonId VARCHAR(32) NULL,
    PreferredFirstName VARCHAR(75) NULL,
    PreferredLastSurname VARCHAR(75) NULL,
    RequisitionNumber VARCHAR(20) NULL,
    SexDescriptorId INT NULL,
    SourceSystemDescriptorId INT NULL,
    StaffUniqueId VARCHAR(32) NOT NULL,
    YearsOfPriorProfessionalExperience DECIMAL(5, 2) NULL,
    YearsOfPriorTeachingExperience DECIMAL(5, 2) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Staff_PK PRIMARY KEY (StaffUSI)
);
CREATE UNIQUE INDEX Staff_UI_StaffUniqueId ON edfi.Staff (StaffUniqueId) INCLUDE (StaffUSI);
ALTER TABLE edfi.Staff ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Staff ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Staff ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffAbsenceEvent --
CREATE TABLE edfi.StaffAbsenceEvent (
    AbsenceEventCategoryDescriptorId INT NOT NULL,
    EventDate DATE NOT NULL,
    StaffUSI INT NOT NULL,
    AbsenceEventReason VARCHAR(40) NULL,
    HoursAbsent DECIMAL(18, 2) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffAbsenceEvent_PK PRIMARY KEY (AbsenceEventCategoryDescriptorId, EventDate, StaffUSI)
);
ALTER TABLE edfi.StaffAbsenceEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffAbsenceEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffAbsenceEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffAddress --
CREATE TABLE edfi.StaffAddress (
    StaffUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    Latitude VARCHAR(20) NULL,
    LocaleDescriptorId INT NULL,
    Longitude VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffAddress_PK PRIMARY KEY (StaffUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
);
ALTER TABLE edfi.StaffAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffAddressPeriod --
CREATE TABLE edfi.StaffAddressPeriod (
    StaffUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffAddressPeriod_PK PRIMARY KEY (StaffUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, BeginDate)
);
ALTER TABLE edfi.StaffAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffAncestryEthnicOrigin --
CREATE TABLE edfi.StaffAncestryEthnicOrigin (
    StaffUSI INT NOT NULL,
    AncestryEthnicOriginDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffAncestryEthnicOrigin_PK PRIMARY KEY (StaffUSI, AncestryEthnicOriginDescriptorId)
);
ALTER TABLE edfi.StaffAncestryEthnicOrigin ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffClassificationDescriptor --
CREATE TABLE edfi.StaffClassificationDescriptor (
    StaffClassificationDescriptorId INT NOT NULL,
    CONSTRAINT StaffClassificationDescriptor_PK PRIMARY KEY (StaffClassificationDescriptorId)
);

-- Table edfi.StaffCohortAssociation --
CREATE TABLE edfi.StaffCohortAssociation (
    BeginDate DATE NOT NULL,
    CohortIdentifier VARCHAR(36) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    EndDate DATE NULL,
    StudentRecordAccess BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffCohortAssociation_PK PRIMARY KEY (BeginDate, CohortIdentifier, EducationOrganizationId, StaffUSI)
);
ALTER TABLE edfi.StaffCohortAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffCohortAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffCohortAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffCredential --
CREATE TABLE edfi.StaffCredential (
    StaffUSI INT NOT NULL,
    CredentialIdentifier VARCHAR(120) NOT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffCredential_PK PRIMARY KEY (StaffUSI, CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
);
ALTER TABLE edfi.StaffCredential ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDemographic --
CREATE TABLE edfi.StaffDemographic (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    CitizenshipStatusDescriptorId INT NULL,
    GenderIdentity VARCHAR(60) NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    SexDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffDemographic_PK PRIMARY KEY (EducationOrganizationId, StaffUSI)
);
ALTER TABLE edfi.StaffDemographic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffDemographic ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffDemographic ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDemographicAncestryEthnicOrigin --
CREATE TABLE edfi.StaffDemographicAncestryEthnicOrigin (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    AncestryEthnicOriginDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDemographicAncestryEthnicOrigin_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, AncestryEthnicOriginDescriptorId)
);
ALTER TABLE edfi.StaffDemographicAncestryEthnicOrigin ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDemographicIdentificationDocument --
CREATE TABLE edfi.StaffDemographicIdentificationDocument (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDemographicIdentificationDocument_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.StaffDemographicIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDemographicLanguage --
CREATE TABLE edfi.StaffDemographicLanguage (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDemographicLanguage_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, LanguageDescriptorId)
);
ALTER TABLE edfi.StaffDemographicLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDemographicLanguageUse --
CREATE TABLE edfi.StaffDemographicLanguageUse (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDemographicLanguageUse_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, LanguageDescriptorId, LanguageUseDescriptorId)
);
ALTER TABLE edfi.StaffDemographicLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDemographicRace --
CREATE TABLE edfi.StaffDemographicRace (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDemographicRace_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, RaceDescriptorId)
);
ALTER TABLE edfi.StaffDemographicRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDemographicTribalAffiliation --
CREATE TABLE edfi.StaffDemographicTribalAffiliation (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    TribalAffiliationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDemographicTribalAffiliation_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, TribalAffiliationDescriptorId)
);
ALTER TABLE edfi.StaffDemographicTribalAffiliation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDemographicVisa --
CREATE TABLE edfi.StaffDemographicVisa (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDemographicVisa_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, VisaDescriptorId)
);
ALTER TABLE edfi.StaffDemographicVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDirectory --
CREATE TABLE edfi.StaffDirectory (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffDirectory_PK PRIMARY KEY (EducationOrganizationId, StaffUSI)
);
ALTER TABLE edfi.StaffDirectory ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffDirectory ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffDirectory ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDirectoryAddress --
CREATE TABLE edfi.StaffDirectoryAddress (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    Latitude VARCHAR(20) NULL,
    LocaleDescriptorId INT NULL,
    Longitude VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDirectoryAddress_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
);
ALTER TABLE edfi.StaffDirectoryAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDirectoryAddressPeriod --
CREATE TABLE edfi.StaffDirectoryAddressPeriod (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDirectoryAddressPeriod_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, BeginDate)
);
ALTER TABLE edfi.StaffDirectoryAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDirectoryElectronicMail --
CREATE TABLE edfi.StaffDirectoryElectronicMail (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDirectoryElectronicMail_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
);
ALTER TABLE edfi.StaffDirectoryElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDirectoryInternationalAddress --
CREATE TABLE edfi.StaffDirectoryInternationalAddress (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    BeginDate DATE NULL,
    CountryDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDirectoryInternationalAddress_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, AddressTypeDescriptorId)
);
ALTER TABLE edfi.StaffDirectoryInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDirectoryTelephone --
CREATE TABLE edfi.StaffDirectoryTelephone (
    EducationOrganizationId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDirectoryTelephone_PK PRIMARY KEY (EducationOrganizationId, StaffUSI, TelephoneNumber, TelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.StaffDirectoryTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDisciplineIncidentAssociation --
CREATE TABLE edfi.StaffDisciplineIncidentAssociation (
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffDisciplineIncidentAssociation_PK PRIMARY KEY (IncidentIdentifier, SchoolId, StaffUSI)
);
ALTER TABLE edfi.StaffDisciplineIncidentAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffDisciplineIncidentAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffDisciplineIncidentAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be --
CREATE TABLE edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be (
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    DisciplineIncidentParticipationCodeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffDisciplineIncidentAssociationDisciplineIncide_7fa4be_PK PRIMARY KEY (IncidentIdentifier, SchoolId, StaffUSI, DisciplineIncidentParticipationCodeDescriptorId)
);
ALTER TABLE edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffEducationOrganizationAssignmentAssociation --
CREATE TABLE edfi.StaffEducationOrganizationAssignmentAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    StaffClassificationDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    CredentialIdentifier VARCHAR(120) NULL,
    EmploymentEducationOrganizationId BIGINT NULL,
    EmploymentStatusDescriptorId INT NULL,
    EmploymentHireDate DATE NULL,
    EndDate DATE NULL,
    FullTimeEquivalency DECIMAL(5, 4) NULL,
    OrderOfAssignment INT NULL,
    PositionTitle VARCHAR(100) NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NULL,
    YearsOfExperienceAtCurrentEducationOrganization DECIMAL(5, 2) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffEducationOrganizationAssignmentAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI)
);
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffEducationOrganizationAssignmentAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffEducationOrganizationEmploymentAssociation --
CREATE TABLE edfi.StaffEducationOrganizationEmploymentAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    StaffUSI INT NOT NULL,
    AnnualWage MONEY NULL,
    CredentialIdentifier VARCHAR(120) NULL,
    Department VARCHAR(60) NULL,
    EndDate DATE NULL,
    FullTimeEquivalency DECIMAL(5, 4) NULL,
    HourlyWage MONEY NULL,
    LengthOfContractDescriptorId INT NULL,
    OfferDate DATE NULL,
    ProbationCompleteDate DATE NULL,
    SeparationDescriptorId INT NULL,
    SeparationReasonDescriptorId INT NULL,
    StateOfIssueStateAbbreviationDescriptorId INT NULL,
    Tenured BOOLEAN NULL,
    TenureTrack BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffEducationOrganizationEmploymentAssociation_PK PRIMARY KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
);
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffEducationOrganizationEmploymentAssociationBackgroundCheck --
CREATE TABLE edfi.StaffEducationOrganizationEmploymentAssociationBackgroundCheck (
    EducationOrganizationId BIGINT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    StaffUSI INT NOT NULL,
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducationOrganizationEmploymentAssociationBac_b66085_PK PRIMARY KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI, BackgroundCheckTypeDescriptorId)
);
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociationBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffEducationOrganizationEmploymentAssociationSalary --
CREATE TABLE edfi.StaffEducationOrganizationEmploymentAssociationSalary (
    EducationOrganizationId BIGINT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    StaffUSI INT NOT NULL,
    SalaryAmount DECIMAL(19, 4) NULL,
    SalaryMaxRange INT NULL,
    SalaryMinRange INT NULL,
    SalaryTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducationOrganizationEmploymentAssociationSalary_PK PRIMARY KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
);
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociationSalary ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffEducationOrganizationEmploymentAssociationSeniority --
CREATE TABLE edfi.StaffEducationOrganizationEmploymentAssociationSeniority (
    EducationOrganizationId BIGINT NOT NULL,
    EmploymentStatusDescriptorId INT NOT NULL,
    HireDate DATE NOT NULL,
    StaffUSI INT NOT NULL,
    CredentialFieldDescriptorId INT NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    YearsExperience DECIMAL(5, 2) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducationOrganizationEmploymentAssociationSeniority_PK PRIMARY KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI, CredentialFieldDescriptorId, NameOfInstitution)
);
ALTER TABLE edfi.StaffEducationOrganizationEmploymentAssociationSeniority ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffEducatorPreparationProgram --
CREATE TABLE edfi.StaffEducatorPreparationProgram (
    StaffUSI INT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducatorPreparationProgram_PK PRIMARY KEY (StaffUSI, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.StaffEducatorPreparationProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffEducatorPreparationProgramAssociation --
CREATE TABLE edfi.StaffEducatorPreparationProgramAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    Completer BOOLEAN NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffEducatorPreparationProgramAssociation_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI)
);
ALTER TABLE edfi.StaffEducatorPreparationProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffEducatorPreparationProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffEducatorPreparationProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffEducatorResearch --
CREATE TABLE edfi.StaffEducatorResearch (
    StaffUSI INT NOT NULL,
    ResearchExperienceDate DATE NOT NULL,
    ResearchExperienceDescription VARCHAR(1024) NULL,
    ResearchExperienceTitle VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffEducatorResearch_PK PRIMARY KEY (StaffUSI)
);
ALTER TABLE edfi.StaffEducatorResearch ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffElectronicMail --
CREATE TABLE edfi.StaffElectronicMail (
    StaffUSI INT NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffElectronicMail_PK PRIMARY KEY (StaffUSI, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
);
ALTER TABLE edfi.StaffElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffHighlyQualifiedAcademicSubject --
CREATE TABLE edfi.StaffHighlyQualifiedAcademicSubject (
    StaffUSI INT NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffHighlyQualifiedAcademicSubject_PK PRIMARY KEY (StaffUSI, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.StaffHighlyQualifiedAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffIdentificationCode --
CREATE TABLE edfi.StaffIdentificationCode (
    StaffUSI INT NOT NULL,
    StaffIdentificationSystemDescriptorId INT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(120) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffIdentificationCode_PK PRIMARY KEY (StaffUSI, StaffIdentificationSystemDescriptorId)
);
ALTER TABLE edfi.StaffIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffIdentificationDocument --
CREATE TABLE edfi.StaffIdentificationDocument (
    StaffUSI INT NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffIdentificationDocument_PK PRIMARY KEY (StaffUSI, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.StaffIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffIdentificationSystemDescriptor --
CREATE TABLE edfi.StaffIdentificationSystemDescriptor (
    StaffIdentificationSystemDescriptorId INT NOT NULL,
    CONSTRAINT StaffIdentificationSystemDescriptor_PK PRIMARY KEY (StaffIdentificationSystemDescriptorId)
);

-- Table edfi.StaffIdentity --
CREATE TABLE edfi.StaffIdentity (
    EducationOrganizationId BIGINT NOT NULL,
    StaffIdentificationSystemDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(60) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffIdentity_PK PRIMARY KEY (EducationOrganizationId, StaffIdentificationSystemDescriptorId, StaffUSI)
);
ALTER TABLE edfi.StaffIdentity ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffIdentity ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffIdentity ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffInternationalAddress --
CREATE TABLE edfi.StaffInternationalAddress (
    StaffUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    BeginDate DATE NULL,
    CountryDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffInternationalAddress_PK PRIMARY KEY (StaffUSI, AddressTypeDescriptorId)
);
ALTER TABLE edfi.StaffInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffLanguage --
CREATE TABLE edfi.StaffLanguage (
    StaffUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffLanguage_PK PRIMARY KEY (StaffUSI, LanguageDescriptorId)
);
ALTER TABLE edfi.StaffLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffLanguageUse --
CREATE TABLE edfi.StaffLanguageUse (
    StaffUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffLanguageUse_PK PRIMARY KEY (StaffUSI, LanguageDescriptorId, LanguageUseDescriptorId)
);
ALTER TABLE edfi.StaffLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffLeave --
CREATE TABLE edfi.StaffLeave (
    BeginDate DATE NOT NULL,
    StaffLeaveEventCategoryDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    EndDate DATE NULL,
    Reason VARCHAR(40) NULL,
    SubstituteAssigned BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffLeave_PK PRIMARY KEY (BeginDate, StaffLeaveEventCategoryDescriptorId, StaffUSI)
);
ALTER TABLE edfi.StaffLeave ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffLeave ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffLeave ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffLeaveEventCategoryDescriptor --
CREATE TABLE edfi.StaffLeaveEventCategoryDescriptor (
    StaffLeaveEventCategoryDescriptorId INT NOT NULL,
    CONSTRAINT StaffLeaveEventCategoryDescriptor_PK PRIMARY KEY (StaffLeaveEventCategoryDescriptorId)
);

-- Table edfi.StaffOtherName --
CREATE TABLE edfi.StaffOtherName (
    StaffUSI INT NOT NULL,
    OtherNameTypeDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffOtherName_PK PRIMARY KEY (StaffUSI, OtherNameTypeDescriptorId)
);
ALTER TABLE edfi.StaffOtherName ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffPersonalIdentificationDocument --
CREATE TABLE edfi.StaffPersonalIdentificationDocument (
    StaffUSI INT NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffPersonalIdentificationDocument_PK PRIMARY KEY (StaffUSI, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.StaffPersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffProgramAssociation --
CREATE TABLE edfi.StaffProgramAssociation (
    BeginDate DATE NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    EndDate DATE NULL,
    StudentRecordAccess BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffProgramAssociation_PK PRIMARY KEY (BeginDate, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI)
);
ALTER TABLE edfi.StaffProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffRace --
CREATE TABLE edfi.StaffRace (
    StaffUSI INT NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffRace_PK PRIMARY KEY (StaffUSI, RaceDescriptorId)
);
ALTER TABLE edfi.StaffRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffRecognition --
CREATE TABLE edfi.StaffRecognition (
    StaffUSI INT NOT NULL,
    RecognitionTypeDescriptorId INT NOT NULL,
    AchievementCategoryDescriptorId INT NULL,
    AchievementCategorySystem VARCHAR(60) NULL,
    AchievementTitle VARCHAR(60) NULL,
    Criteria VARCHAR(150) NULL,
    CriteriaURL VARCHAR(255) NULL,
    EvidenceStatement VARCHAR(150) NULL,
    ImageURL VARCHAR(255) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerOriginURL VARCHAR(255) NULL,
    RecognitionAwardDate DATE NULL,
    RecognitionAwardExpiresDate DATE NULL,
    RecognitionDescription VARCHAR(80) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffRecognition_PK PRIMARY KEY (StaffUSI, RecognitionTypeDescriptorId)
);
ALTER TABLE edfi.StaffRecognition ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffSchoolAssociation --
CREATE TABLE edfi.StaffSchoolAssociation (
    ProgramAssignmentDescriptorId INT NOT NULL,
    SchoolId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    CalendarCode VARCHAR(120) NULL,
    SchoolYear SMALLINT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffSchoolAssociation_PK PRIMARY KEY (ProgramAssignmentDescriptorId, SchoolId, StaffUSI)
);
ALTER TABLE edfi.StaffSchoolAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffSchoolAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffSchoolAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffSchoolAssociationAcademicSubject --
CREATE TABLE edfi.StaffSchoolAssociationAcademicSubject (
    ProgramAssignmentDescriptorId INT NOT NULL,
    SchoolId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    AcademicSubjectDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffSchoolAssociationAcademicSubject_PK PRIMARY KEY (ProgramAssignmentDescriptorId, SchoolId, StaffUSI, AcademicSubjectDescriptorId)
);
ALTER TABLE edfi.StaffSchoolAssociationAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffSchoolAssociationGradeLevel --
CREATE TABLE edfi.StaffSchoolAssociationGradeLevel (
    ProgramAssignmentDescriptorId INT NOT NULL,
    SchoolId BIGINT NOT NULL,
    StaffUSI INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffSchoolAssociationGradeLevel_PK PRIMARY KEY (ProgramAssignmentDescriptorId, SchoolId, StaffUSI, GradeLevelDescriptorId)
);
ALTER TABLE edfi.StaffSchoolAssociationGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffSectionAssociation --
CREATE TABLE edfi.StaffSectionAssociation (
    BeginDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StaffUSI INT NOT NULL,
    ClassroomPositionDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    HighlyQualifiedTeacher BOOLEAN NULL,
    PercentageContribution DECIMAL(5, 4) NULL,
    TeacherStudentDataLinkExclusion BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffSectionAssociation_PK PRIMARY KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StaffUSI)
);
ALTER TABLE edfi.StaffSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StaffSectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StaffSectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffTelephone --
CREATE TABLE edfi.StaffTelephone (
    StaffUSI INT NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffTelephone_PK PRIMARY KEY (StaffUSI, TelephoneNumber, TelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.StaffTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffToCandidateRelationshipDescriptor --
CREATE TABLE edfi.StaffToCandidateRelationshipDescriptor (
    StaffToCandidateRelationshipDescriptorId INT NOT NULL,
    CONSTRAINT StaffToCandidateRelationshipDescriptor_PK PRIMARY KEY (StaffToCandidateRelationshipDescriptorId)
);

-- Table edfi.StaffTribalAffiliation --
CREATE TABLE edfi.StaffTribalAffiliation (
    StaffUSI INT NOT NULL,
    TribalAffiliationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffTribalAffiliation_PK PRIMARY KEY (StaffUSI, TribalAffiliationDescriptorId)
);
ALTER TABLE edfi.StaffTribalAffiliation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StaffVisa --
CREATE TABLE edfi.StaffVisa (
    StaffUSI INT NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffVisa_PK PRIMARY KEY (StaffUSI, VisaDescriptorId)
);
ALTER TABLE edfi.StaffVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StateAbbreviationDescriptor --
CREATE TABLE edfi.StateAbbreviationDescriptor (
    StateAbbreviationDescriptorId INT NOT NULL,
    CONSTRAINT StateAbbreviationDescriptor_PK PRIMARY KEY (StateAbbreviationDescriptorId)
);

-- Table edfi.StateEducationAgency --
CREATE TABLE edfi.StateEducationAgency (
    StateEducationAgencyId BIGINT NOT NULL,
    FederalLocaleCodeDescriptorId INT NULL,
    CONSTRAINT StateEducationAgency_PK PRIMARY KEY (StateEducationAgencyId)
);

-- Table edfi.StateEducationAgencyAccountability --
CREATE TABLE edfi.StateEducationAgencyAccountability (
    StateEducationAgencyId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    CTEGraduationRateInclusion BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StateEducationAgencyAccountability_PK PRIMARY KEY (StateEducationAgencyId, SchoolYear)
);
ALTER TABLE edfi.StateEducationAgencyAccountability ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StateEducationAgencyFederalFunds --
CREATE TABLE edfi.StateEducationAgencyFederalFunds (
    StateEducationAgencyId BIGINT NOT NULL,
    FiscalYear INT NOT NULL,
    FederalProgramsFundingAllocation MONEY NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StateEducationAgencyFederalFunds_PK PRIMARY KEY (StateEducationAgencyId, FiscalYear)
);
ALTER TABLE edfi.StateEducationAgencyFederalFunds ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.Student --
CREATE TABLE edfi.Student (
    StudentUSI SERIAL NOT NULL,
    BirthCity VARCHAR(30) NULL,
    BirthCountryDescriptorId INT NULL,
    BirthDate DATE NOT NULL,
    BirthInternationalProvince VARCHAR(150) NULL,
    BirthSexDescriptorId INT NULL,
    BirthStateAbbreviationDescriptorId INT NULL,
    CitizenshipStatusDescriptorId INT NULL,
    DateEnteredUS DATE NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    MaidenName VARCHAR(75) NULL,
    MiddleName VARCHAR(75) NULL,
    MultipleBirthStatus BOOLEAN NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    PersonId VARCHAR(32) NULL,
    PreferredFirstName VARCHAR(75) NULL,
    PreferredLastSurname VARCHAR(75) NULL,
    SourceSystemDescriptorId INT NULL,
    StudentUniqueId VARCHAR(32) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Student_PK PRIMARY KEY (StudentUSI)
);
CREATE UNIQUE INDEX Student_UI_StudentUniqueId ON edfi.Student (StudentUniqueId) INCLUDE (StudentUSI);
ALTER TABLE edfi.Student ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Student ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Student ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAcademicRecord --
CREATE TABLE edfi.StudentAcademicRecord (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CumulativeAttemptedCreditConversion DECIMAL(9, 2) NULL,
    CumulativeAttemptedCredits DECIMAL(9, 3) NULL,
    CumulativeAttemptedCreditTypeDescriptorId INT NULL,
    CumulativeEarnedCreditConversion DECIMAL(9, 2) NULL,
    CumulativeEarnedCredits DECIMAL(9, 3) NULL,
    CumulativeEarnedCreditTypeDescriptorId INT NULL,
    ProjectedGraduationDate DATE NULL,
    SessionAttemptedCreditConversion DECIMAL(9, 2) NULL,
    SessionAttemptedCredits DECIMAL(9, 3) NULL,
    SessionAttemptedCreditTypeDescriptorId INT NULL,
    SessionEarnedCreditConversion DECIMAL(9, 2) NULL,
    SessionEarnedCredits DECIMAL(9, 3) NULL,
    SessionEarnedCreditTypeDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentAcademicRecord_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
);
ALTER TABLE edfi.StudentAcademicRecord ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentAcademicRecord ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentAcademicRecord ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAcademicRecordAcademicHonor --
CREATE TABLE edfi.StudentAcademicRecordAcademicHonor (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    AcademicHonorCategoryDescriptorId INT NOT NULL,
    HonorDescription VARCHAR(80) NOT NULL,
    AchievementCategoryDescriptorId INT NULL,
    AchievementCategorySystem VARCHAR(60) NULL,
    AchievementTitle VARCHAR(60) NULL,
    Criteria VARCHAR(150) NULL,
    CriteriaURL VARCHAR(255) NULL,
    EvidenceStatement VARCHAR(150) NULL,
    HonorAwardDate DATE NULL,
    HonorAwardExpiresDate DATE NULL,
    ImageURL VARCHAR(255) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerOriginURL VARCHAR(255) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAcademicRecordAcademicHonor_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, AcademicHonorCategoryDescriptorId, HonorDescription)
);
ALTER TABLE edfi.StudentAcademicRecordAcademicHonor ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAcademicRecordClassRanking --
CREATE TABLE edfi.StudentAcademicRecordClassRanking (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    ClassRank INT NOT NULL,
    ClassRankingDate DATE NULL,
    PercentageRanking INT NULL,
    TotalNumberInClass INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAcademicRecordClassRanking_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
);
ALTER TABLE edfi.StudentAcademicRecordClassRanking ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAcademicRecordDiploma --
CREATE TABLE edfi.StudentAcademicRecordDiploma (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    DiplomaAwardDate DATE NOT NULL,
    DiplomaTypeDescriptorId INT NOT NULL,
    AchievementCategoryDescriptorId INT NULL,
    AchievementCategorySystem VARCHAR(60) NULL,
    AchievementTitle VARCHAR(60) NULL,
    Criteria VARCHAR(150) NULL,
    CriteriaURL VARCHAR(255) NULL,
    CTECompleter BOOLEAN NULL,
    DiplomaAwardExpiresDate DATE NULL,
    DiplomaDescription VARCHAR(80) NULL,
    DiplomaLevelDescriptorId INT NULL,
    EvidenceStatement VARCHAR(150) NULL,
    ImageURL VARCHAR(255) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerOriginURL VARCHAR(255) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAcademicRecordDiploma_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, DiplomaAwardDate, DiplomaTypeDescriptorId)
);
ALTER TABLE edfi.StudentAcademicRecordDiploma ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAcademicRecordGradePointAverage --
CREATE TABLE edfi.StudentAcademicRecordGradePointAverage (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    GradePointAverageTypeDescriptorId INT NOT NULL,
    GradePointAverageValue DECIMAL(18, 4) NOT NULL,
    IsCumulative BOOLEAN NULL,
    MaxGradePointAverageValue DECIMAL(18, 4) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAcademicRecordGradePointAverage_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, GradePointAverageTypeDescriptorId)
);
ALTER TABLE edfi.StudentAcademicRecordGradePointAverage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAcademicRecordRecognition --
CREATE TABLE edfi.StudentAcademicRecordRecognition (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    RecognitionTypeDescriptorId INT NOT NULL,
    AchievementCategoryDescriptorId INT NULL,
    AchievementCategorySystem VARCHAR(60) NULL,
    AchievementTitle VARCHAR(60) NULL,
    Criteria VARCHAR(150) NULL,
    CriteriaURL VARCHAR(255) NULL,
    EvidenceStatement VARCHAR(150) NULL,
    ImageURL VARCHAR(255) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerOriginURL VARCHAR(255) NULL,
    RecognitionAwardDate DATE NULL,
    RecognitionAwardExpiresDate DATE NULL,
    RecognitionDescription VARCHAR(80) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAcademicRecordRecognition_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, RecognitionTypeDescriptorId)
);
ALTER TABLE edfi.StudentAcademicRecordRecognition ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAcademicRecordReportCard --
CREATE TABLE edfi.StudentAcademicRecordReportCard (
    EducationOrganizationId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StudentUSI INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolId BIGINT NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAcademicRecordReportCard_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolId, GradingPeriodSchoolYear)
);
ALTER TABLE edfi.StudentAcademicRecordReportCard ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessment --
CREATE TABLE edfi.StudentAssessment (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    AdministrationDate TIMESTAMP NULL,
    AdministrationEndDate TIMESTAMP NULL,
    AdministrationEnvironmentDescriptorId INT NULL,
    AdministrationLanguageDescriptorId INT NULL,
    AssessedMinutes INT NULL,
    EventCircumstanceDescriptorId INT NULL,
    EventDescription VARCHAR(1024) NULL,
    PlatformTypeDescriptorId INT NULL,
    ReasonNotTestedDescriptorId INT NULL,
    ReportedSchoolId BIGINT NULL,
    ReportedSchoolIdentifier VARCHAR(60) NULL,
    RetestIndicatorDescriptorId INT NULL,
    SchoolYear SMALLINT NULL,
    SerialNumber VARCHAR(120) NULL,
    WhenAssessedGradeLevelDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentAssessment_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
);
ALTER TABLE edfi.StudentAssessment ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentAssessment ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentAssessment ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentAccommodation --
CREATE TABLE edfi.StudentAssessmentAccommodation (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    AccommodationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentAccommodation_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, AccommodationDescriptorId)
);
ALTER TABLE edfi.StudentAssessmentAccommodation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentEducationOrganizationAssociation --
CREATE TABLE edfi.StudentAssessmentEducationOrganizationAssociation (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    EducationOrganizationAssociationTypeDescriptorId INT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    SchoolYear SMALLINT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentAssessmentEducationOrganizationAssociation_PK PRIMARY KEY (AssessmentIdentifier, EducationOrganizationAssociationTypeDescriptorId, EducationOrganizationId, Namespace, StudentAssessmentIdentifier, StudentUSI)
);
ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentAssessmentEducationOrganizationAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentItem --
CREATE TABLE edfi.StudentAssessmentItem (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    AssessmentItemResultDescriptorId INT NOT NULL,
    AssessmentResponse VARCHAR(255) NULL,
    DescriptiveFeedback VARCHAR(1024) NULL,
    ItemNumber INT NULL,
    RawScoreResult DECIMAL(15, 5) NULL,
    ResponseIndicatorDescriptorId INT NULL,
    TimeAssessed VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentItem_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, IdentificationCode)
);
ALTER TABLE edfi.StudentAssessmentItem ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentPerformanceLevel --
CREATE TABLE edfi.StudentAssessmentPerformanceLevel (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    PerformanceLevelDescriptorId INT NOT NULL,
    PerformanceLevelIndicatorName VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentPerformanceLevel_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, AssessmentReportingMethodDescriptorId, PerformanceLevelDescriptorId)
);
ALTER TABLE edfi.StudentAssessmentPerformanceLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentPeriod --
CREATE TABLE edfi.StudentAssessmentPeriod (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    AssessmentPeriodDescriptorId INT NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentPeriod_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI)
);
ALTER TABLE edfi.StudentAssessmentPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentRegistration --
CREATE TABLE edfi.StudentAssessmentRegistration (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentUSI INT NOT NULL,
    AssessmentGradeLevelDescriptorId INT NULL,
    EntryDate DATE NOT NULL,
    PlatformTypeDescriptorId INT NULL,
    ReportingEducationOrganizationId BIGINT NULL,
    ScheduledEducationOrganizationId BIGINT NULL,
    ScheduledStudentUSI INT NULL,
    SchoolId BIGINT NOT NULL,
    TestingEducationOrganizationId BIGINT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentAssessmentRegistration_PK PRIMARY KEY (AdministrationIdentifier, AssessmentIdentifier, AssigningEducationOrganizationId, EducationOrganizationId, Namespace, StudentUSI)
);
ALTER TABLE edfi.StudentAssessmentRegistration ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentAssessmentRegistration ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentAssessmentRegistration ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentRegistrationAssessmentAccommodation --
CREATE TABLE edfi.StudentAssessmentRegistrationAssessmentAccommodation (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentUSI INT NOT NULL,
    AccommodationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentRegistrationAssessmentAccommodation_PK PRIMARY KEY (AdministrationIdentifier, AssessmentIdentifier, AssigningEducationOrganizationId, EducationOrganizationId, Namespace, StudentUSI, AccommodationDescriptorId)
);
ALTER TABLE edfi.StudentAssessmentRegistrationAssessmentAccommodation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentRegistrationAssessmentCustomization --
CREATE TABLE edfi.StudentAssessmentRegistrationAssessmentCustomization (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentUSI INT NOT NULL,
    CustomizationKey VARCHAR(60) NOT NULL,
    CustomizationValue VARCHAR(1024) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentRegistrationAssessmentCustomization_PK PRIMARY KEY (AdministrationIdentifier, AssessmentIdentifier, AssigningEducationOrganizationId, EducationOrganizationId, Namespace, StudentUSI, CustomizationKey)
);
ALTER TABLE edfi.StudentAssessmentRegistrationAssessmentCustomization ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentRegistrationBatteryPartAssociation --
CREATE TABLE edfi.StudentAssessmentRegistrationBatteryPartAssociation (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentBatteryPartName VARCHAR(65) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentAssessmentRegistrationBatteryPartAssociation_PK PRIMARY KEY (AdministrationIdentifier, AssessmentBatteryPartName, AssessmentIdentifier, AssigningEducationOrganizationId, EducationOrganizationId, Namespace, StudentUSI)
);
ALTER TABLE edfi.StudentAssessmentRegistrationBatteryPartAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentAssessmentRegistrationBatteryPartAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentAssessmentRegistrationBatteryPartAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentRegistrationBatteryPartAssociationAccom_c87694 --
CREATE TABLE edfi.StudentAssessmentRegistrationBatteryPartAssociationAccom_c87694 (
    AdministrationIdentifier VARCHAR(255) NOT NULL,
    AssessmentBatteryPartName VARCHAR(65) NOT NULL,
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    AssigningEducationOrganizationId BIGINT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentUSI INT NOT NULL,
    AccommodationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentRegistrationBatteryPartAssociatio_c87694_PK PRIMARY KEY (AdministrationIdentifier, AssessmentBatteryPartName, AssessmentIdentifier, AssigningEducationOrganizationId, EducationOrganizationId, Namespace, StudentUSI, AccommodationDescriptorId)
);
ALTER TABLE edfi.StudentAssessmentRegistrationBatteryPartAssociationAccom_c87694 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentScoreResult --
CREATE TABLE edfi.StudentAssessmentScoreResult (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    Result VARCHAR(35) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentScoreResult_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, AssessmentReportingMethodDescriptorId)
);
ALTER TABLE edfi.StudentAssessmentScoreResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentStudentObjectiveAssessment --
CREATE TABLE edfi.StudentAssessmentStudentObjectiveAssessment (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    AdministrationDate TIMESTAMP NULL,
    AdministrationEndDate TIMESTAMP NULL,
    AssessedMinutes INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentStudentObjectiveAssessment_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, IdentificationCode)
);
ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessment ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel --
CREATE TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    PerformanceLevelDescriptorId INT NOT NULL,
    PerformanceLevelIndicatorName VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentStudentObjectiveAssessmentPerformanceLevel_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, IdentificationCode, AssessmentReportingMethodDescriptorId, PerformanceLevelDescriptorId)
);
ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult --
CREATE TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult (
    AssessmentIdentifier VARCHAR(120) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentAssessmentIdentifier VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    Result VARCHAR(35) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAssessmentStudentObjectiveAssessmentScoreResult_PK PRIMARY KEY (AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, IdentificationCode, AssessmentReportingMethodDescriptorId)
);
ALTER TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentCharacteristicDescriptor --
CREATE TABLE edfi.StudentCharacteristicDescriptor (
    StudentCharacteristicDescriptorId INT NOT NULL,
    CONSTRAINT StudentCharacteristicDescriptor_PK PRIMARY KEY (StudentCharacteristicDescriptorId)
);

-- Table edfi.StudentCohortAssociation --
CREATE TABLE edfi.StudentCohortAssociation (
    BeginDate DATE NOT NULL,
    CohortIdentifier VARCHAR(36) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentCohortAssociation_PK PRIMARY KEY (BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI)
);
ALTER TABLE edfi.StudentCohortAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentCohortAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentCohortAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentCohortAssociationSection --
CREATE TABLE edfi.StudentCohortAssociationSection (
    BeginDate DATE NOT NULL,
    CohortIdentifier VARCHAR(36) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentCohortAssociationSection_PK PRIMARY KEY (BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
);
ALTER TABLE edfi.StudentCohortAssociationSection ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentCompetencyObjective --
CREATE TABLE edfi.StudentCompetencyObjective (
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolId BIGINT NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    ObjectiveEducationOrganizationId BIGINT NOT NULL,
    Objective VARCHAR(60) NOT NULL,
    ObjectiveGradeLevelDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    CompetencyLevelDescriptorId INT NOT NULL,
    DiagnosticStatement VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentCompetencyObjective_PK PRIMARY KEY (GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI)
);
ALTER TABLE edfi.StudentCompetencyObjective ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentCompetencyObjective ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentCompetencyObjective ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation --
CREATE TABLE edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation (
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolId BIGINT NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    ObjectiveEducationOrganizationId BIGINT NOT NULL,
    Objective VARCHAR(60) NOT NULL,
    ObjectiveGradeLevelDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentCompetencyObjectiveGeneralStudentProgramAssociation_PK PRIMARY KEY (GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI, BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentCompetencyObjectiveStudentSectionAssociation --
CREATE TABLE edfi.StudentCompetencyObjectiveStudentSectionAssociation (
    GradingPeriodDescriptorId INT NOT NULL,
    GradingPeriodName VARCHAR(60) NOT NULL,
    GradingPeriodSchoolId BIGINT NOT NULL,
    GradingPeriodSchoolYear SMALLINT NOT NULL,
    ObjectiveEducationOrganizationId BIGINT NOT NULL,
    Objective VARCHAR(60) NOT NULL,
    ObjectiveGradeLevelDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentCompetencyObjectiveStudentSectionAssociation_PK PRIMARY KEY (GradingPeriodDescriptorId, GradingPeriodName, GradingPeriodSchoolId, GradingPeriodSchoolYear, ObjectiveEducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, StudentUSI, BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
);
ALTER TABLE edfi.StudentCompetencyObjectiveStudentSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentContactAssociation --
CREATE TABLE edfi.StudentContactAssociation (
    ContactUSI INT NOT NULL,
    StudentUSI INT NOT NULL,
    ContactPriority INT NULL,
    ContactRestrictions VARCHAR(250) NULL,
    EmergencyContactStatus BOOLEAN NULL,
    LegalGuardian BOOLEAN NULL,
    LivesWith BOOLEAN NULL,
    PrimaryContactStatus BOOLEAN NULL,
    RelationDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentContactAssociation_PK PRIMARY KEY (ContactUSI, StudentUSI)
);
ALTER TABLE edfi.StudentContactAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentContactAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentContactAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentCTEProgramAssociation --
CREATE TABLE edfi.StudentCTEProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    NonTraditionalGenderStatus BOOLEAN NULL,
    PrivateCTEProgram BOOLEAN NULL,
    TechnicalSkillsAssessmentDescriptorId INT NULL,
    CONSTRAINT StudentCTEProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentCTEProgramAssociationCTEProgramService --
CREATE TABLE edfi.StudentCTEProgramAssociationCTEProgramService (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    CTEProgramServiceDescriptorId INT NOT NULL,
    CIPCode VARCHAR(120) NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentCTEProgramAssociationCTEProgramService_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, CTEProgramServiceDescriptorId)
);
ALTER TABLE edfi.StudentCTEProgramAssociationCTEProgramService ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographic --
CREATE TABLE edfi.StudentDemographic (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    CitizenshipStatusDescriptorId INT NULL,
    EconomicDisadvantageDescriptorId INT NULL,
    GenderIdentity VARCHAR(60) NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    LimitedEnglishProficiencyDescriptorId INT NULL,
    SexDescriptorId INT NULL,
    SupporterMilitaryConnectionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentDemographic_PK PRIMARY KEY (EducationOrganizationId, StudentUSI)
);
ALTER TABLE edfi.StudentDemographic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentDemographic ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentDemographic ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicAncestryEthnicOrigin --
CREATE TABLE edfi.StudentDemographicAncestryEthnicOrigin (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AncestryEthnicOriginDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicAncestryEthnicOrigin_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AncestryEthnicOriginDescriptorId)
);
ALTER TABLE edfi.StudentDemographicAncestryEthnicOrigin ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicDisability --
CREATE TABLE edfi.StudentDemographicDisability (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicDisability_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, DisabilityDescriptorId)
);
ALTER TABLE edfi.StudentDemographicDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicDisabilityDesignation --
CREATE TABLE edfi.StudentDemographicDisabilityDesignation (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicDisabilityDesignation_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
);
ALTER TABLE edfi.StudentDemographicDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicIdentificationDocument --
CREATE TABLE edfi.StudentDemographicIdentificationDocument (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicIdentificationDocument_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.StudentDemographicIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicLanguage --
CREATE TABLE edfi.StudentDemographicLanguage (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicLanguage_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, LanguageDescriptorId)
);
ALTER TABLE edfi.StudentDemographicLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicLanguageUse --
CREATE TABLE edfi.StudentDemographicLanguageUse (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicLanguageUse_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, LanguageDescriptorId, LanguageUseDescriptorId)
);
ALTER TABLE edfi.StudentDemographicLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicRace --
CREATE TABLE edfi.StudentDemographicRace (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicRace_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, RaceDescriptorId)
);
ALTER TABLE edfi.StudentDemographicRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicTribalAffiliation --
CREATE TABLE edfi.StudentDemographicTribalAffiliation (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    TribalAffiliationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicTribalAffiliation_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, TribalAffiliationDescriptorId)
);
ALTER TABLE edfi.StudentDemographicTribalAffiliation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDemographicVisa --
CREATE TABLE edfi.StudentDemographicVisa (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDemographicVisa_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, VisaDescriptorId)
);
ALTER TABLE edfi.StudentDemographicVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDirectory --
CREATE TABLE edfi.StudentDirectory (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentDirectory_PK PRIMARY KEY (EducationOrganizationId, StudentUSI)
);
ALTER TABLE edfi.StudentDirectory ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentDirectory ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentDirectory ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDirectoryAddress --
CREATE TABLE edfi.StudentDirectoryAddress (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    Latitude VARCHAR(20) NULL,
    LocaleDescriptorId INT NULL,
    Longitude VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDirectoryAddress_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
);
ALTER TABLE edfi.StudentDirectoryAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDirectoryAddressPeriod --
CREATE TABLE edfi.StudentDirectoryAddressPeriod (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDirectoryAddressPeriod_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, BeginDate)
);
ALTER TABLE edfi.StudentDirectoryAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDirectoryElectronicMail --
CREATE TABLE edfi.StudentDirectoryElectronicMail (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDirectoryElectronicMail_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
);
ALTER TABLE edfi.StudentDirectoryElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDirectoryInternationalAddress --
CREATE TABLE edfi.StudentDirectoryInternationalAddress (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    BeginDate DATE NULL,
    CountryDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDirectoryInternationalAddress_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AddressTypeDescriptorId)
);
ALTER TABLE edfi.StudentDirectoryInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDirectoryTelephone --
CREATE TABLE edfi.StudentDirectoryTelephone (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDirectoryTelephone_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, TelephoneNumber, TelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.StudentDirectoryTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDisciplineIncidentBehaviorAssociation --
CREATE TABLE edfi.StudentDisciplineIncidentBehaviorAssociation (
    BehaviorDescriptorId INT NOT NULL,
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    BehaviorDetailedDescription VARCHAR(1024) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentDisciplineIncidentBehaviorAssociation_PK PRIMARY KEY (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI)
);
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 --
CREATE TABLE edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 (
    BehaviorDescriptorId INT NOT NULL,
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    DisciplineIncidentParticipationCodeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDisciplineIncidentBehaviorAssociationDiscip_ae6a21_PK PRIMARY KEY (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI, DisciplineIncidentParticipationCodeDescriptorId)
);
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDisciplineIncidentBehaviorAssociationWeapon --
CREATE TABLE edfi.StudentDisciplineIncidentBehaviorAssociationWeapon (
    BehaviorDescriptorId INT NOT NULL,
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    WeaponDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDisciplineIncidentBehaviorAssociationWeapon_PK PRIMARY KEY (BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI, WeaponDescriptorId)
);
ALTER TABLE edfi.StudentDisciplineIncidentBehaviorAssociationWeapon ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDisciplineIncidentNonOffenderAssociation --
CREATE TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation (
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentDisciplineIncidentNonOffenderAssociation_PK PRIMARY KEY (IncidentIdentifier, SchoolId, StudentUSI)
);
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a --
CREATE TABLE edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a (
    IncidentIdentifier VARCHAR(36) NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    DisciplineIncidentParticipationCodeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentDisciplineIncidentNonOffenderAssociationDis_4c979a_PK PRIMARY KEY (IncidentIdentifier, SchoolId, StudentUSI, DisciplineIncidentParticipationCodeDescriptorId)
);
ALTER TABLE edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssessmentAccommodation --
CREATE TABLE edfi.StudentEducationOrganizationAssessmentAccommodation (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssessmentAccommodation_PK PRIMARY KEY (EducationOrganizationId, StudentUSI)
);
ALTER TABLE edfi.StudentEducationOrganizationAssessmentAccommodation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentEducationOrganizationAssessmentAccommodation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentEducationOrganizationAssessmentAccommodation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssessmentAccommodationGener_d1d10a --
CREATE TABLE edfi.StudentEducationOrganizationAssessmentAccommodationGener_d1d10a (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AccommodationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssessmentAccommodatio_d1d10a_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AccommodationDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssessmentAccommodationGener_d1d10a ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociation --
CREATE TABLE edfi.StudentEducationOrganizationAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    BarrierToInternetAccessInResidenceDescriptorId INT NULL,
    GenderIdentity VARCHAR(60) NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    InternetAccessInResidence BOOLEAN NULL,
    InternetAccessTypeInResidenceDescriptorId INT NULL,
    InternetPerformanceInResidenceDescriptorId INT NULL,
    LimitedEnglishProficiencyDescriptorId INT NULL,
    LoginId VARCHAR(120) NULL,
    PrimaryLearningDeviceAccessDescriptorId INT NULL,
    PrimaryLearningDeviceAwayFromSchoolDescriptorId INT NULL,
    PrimaryLearningDeviceProviderDescriptorId INT NULL,
    ProfileThumbnail VARCHAR(255) NULL,
    SexDescriptorId INT NULL,
    SupporterMilitaryConnectionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociation_PK PRIMARY KEY (EducationOrganizationId, StudentUSI)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentEducationOrganizationAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentEducationOrganizationAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationAddress --
CREATE TABLE edfi.StudentEducationOrganizationAssociationAddress (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    ApartmentRoomSuiteNumber VARCHAR(50) NULL,
    BuildingSiteNumber VARCHAR(20) NULL,
    CongressionalDistrict VARCHAR(30) NULL,
    CountyFIPSCode VARCHAR(5) NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    Latitude VARCHAR(20) NULL,
    LocaleDescriptorId INT NULL,
    Longitude VARCHAR(20) NULL,
    NameOfCounty VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationAddress_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationAddressPeriod --
CREATE TABLE edfi.StudentEducationOrganizationAssociationAddressPeriod (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationAddressPeriod_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, BeginDate)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin --
CREATE TABLE edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AncestryEthnicOriginDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationAncestryEthnicOrigin_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AncestryEthnicOriginDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationCohortYear --
CREATE TABLE edfi.StudentEducationOrganizationAssociationCohortYear (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    CohortYearTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationCohortYear_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, CohortYearTypeDescriptorId, SchoolYear)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationCohortYear ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationDisability --
CREATE TABLE edfi.StudentEducationOrganizationAssociationDisability (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationDisability_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, DisabilityDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationDisabilityDesignation --
CREATE TABLE edfi.StudentEducationOrganizationAssociationDisabilityDesignation (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationDisabilityDesignation_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationDisplacedStudent --
CREATE TABLE edfi.StudentEducationOrganizationAssociationDisplacedStudent (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    CrisisEventName VARCHAR(100) NOT NULL,
    CrisisHomelessnessIndicator BOOLEAN NULL,
    DisplacedStudentEndDate DATE NULL,
    DisplacedStudentStartDate DATE NULL,
    DisplacedStudentStatusDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationDisplacedStudent_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, CrisisEventName)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationDisplacedStudent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationElectronicMail --
CREATE TABLE edfi.StudentEducationOrganizationAssociationElectronicMail (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationElectronicMail_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationInternationalAddress --
CREATE TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AddressTypeDescriptorId INT NOT NULL,
    AddressLine1 VARCHAR(150) NOT NULL,
    AddressLine2 VARCHAR(150) NULL,
    AddressLine3 VARCHAR(150) NULL,
    AddressLine4 VARCHAR(150) NULL,
    BeginDate DATE NULL,
    CountryDescriptorId INT NOT NULL,
    EndDate DATE NULL,
    Latitude VARCHAR(20) NULL,
    Longitude VARCHAR(20) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationInternationalAddress_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AddressTypeDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationLanguage --
CREATE TABLE edfi.StudentEducationOrganizationAssociationLanguage (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationLanguage_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, LanguageDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationLanguageUse --
CREATE TABLE edfi.StudentEducationOrganizationAssociationLanguageUse (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationLanguageUse_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, LanguageDescriptorId, LanguageUseDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationRace --
CREATE TABLE edfi.StudentEducationOrganizationAssociationRace (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationRace_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, RaceDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf --
CREATE TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    StudentCharacteristicDescriptorId INT NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationStudentChar_a18fcf_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, StudentCharacteristicDescriptorId, BeginDate)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationStudentCharacteristic --
CREATE TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteristic (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    StudentCharacteristicDescriptorId INT NOT NULL,
    DesignatedBy VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationStudentCharacteristic_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, StudentCharacteristicDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 --
CREATE TABLE edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(120) NOT NULL,
    StudentIdentificationSystemDescriptorId INT NOT NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationStudentIden_c15030_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, AssigningOrganizationIdentificationCode, StudentIdentificationSystemDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationStudentIndicator --
CREATE TABLE edfi.StudentEducationOrganizationAssociationStudentIndicator (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    IndicatorName VARCHAR(200) NOT NULL,
    DesignatedBy VARCHAR(60) NULL,
    Indicator VARCHAR(60) NOT NULL,
    IndicatorGroup VARCHAR(200) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationStudentIndicator_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, IndicatorName)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIndicator ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod --
CREATE TABLE edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    IndicatorName VARCHAR(200) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationStudentIndi_a61b72_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, IndicatorName, BeginDate)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationTelephone --
CREATE TABLE edfi.StudentEducationOrganizationAssociationTelephone (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationTelephone_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, TelephoneNumber, TelephoneNumberTypeDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationAssociationTribalAffiliation --
CREATE TABLE edfi.StudentEducationOrganizationAssociationTribalAffiliation (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    TribalAffiliationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentEducationOrganizationAssociationTribalAffiliation_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, TribalAffiliationDescriptorId)
);
ALTER TABLE edfi.StudentEducationOrganizationAssociationTribalAffiliation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentEducationOrganizationResponsibilityAssociation --
CREATE TABLE edfi.StudentEducationOrganizationResponsibilityAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ResponsibilityDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentEducationOrganizationResponsibilityAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ResponsibilityDescriptorId, StudentUSI)
);
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentEducationOrganizationResponsibilityAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentGradebookEntry --
CREATE TABLE edfi.StudentGradebookEntry (
    GradebookEntryIdentifier VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    StudentUSI INT NOT NULL,
    AssignmentLateStatusDescriptorId INT NULL,
    AssignmentPassed BOOLEAN NULL,
    CompetencyLevelDescriptorId INT NULL,
    DateCompleted DATE NULL,
    DateFulfilled DATE NULL,
    DiagnosticStatement VARCHAR(1024) NULL,
    LetterGradeEarned VARCHAR(20) NULL,
    NumericGradeEarned DECIMAL(9, 2) NULL,
    PointsEarned DECIMAL(9, 2) NULL,
    SubmissionStatusDescriptorId INT NULL,
    TimeFulfilled TIME NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentGradebookEntry_PK PRIMARY KEY (GradebookEntryIdentifier, Namespace, StudentUSI)
);
ALTER TABLE edfi.StudentGradebookEntry ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentGradebookEntry ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentGradebookEntry ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentHealth --
CREATE TABLE edfi.StudentHealth (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AsOfDate DATE NOT NULL,
    NonMedicalImmunizationExemptionDate DATE NULL,
    NonMedicalImmunizationExemptionDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentHealth_PK PRIMARY KEY (EducationOrganizationId, StudentUSI)
);
ALTER TABLE edfi.StudentHealth ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentHealth ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentHealth ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentHealthAdditionalImmunization --
CREATE TABLE edfi.StudentHealthAdditionalImmunization (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    ImmunizationName VARCHAR(100) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentHealthAdditionalImmunization_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, ImmunizationName)
);
ALTER TABLE edfi.StudentHealthAdditionalImmunization ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentHealthAdditionalImmunizationDate --
CREATE TABLE edfi.StudentHealthAdditionalImmunizationDate (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    ImmunizationName VARCHAR(100) NOT NULL,
    ImmunizationDate DATE NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentHealthAdditionalImmunizationDate_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, ImmunizationName, ImmunizationDate)
);
ALTER TABLE edfi.StudentHealthAdditionalImmunizationDate ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentHealthRequiredImmunization --
CREATE TABLE edfi.StudentHealthRequiredImmunization (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    ImmunizationTypeDescriptorId INT NOT NULL,
    MedicalExemption VARCHAR(1024) NULL,
    MedicalExemptionDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentHealthRequiredImmunization_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, ImmunizationTypeDescriptorId)
);
ALTER TABLE edfi.StudentHealthRequiredImmunization ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentHealthRequiredImmunizationDate --
CREATE TABLE edfi.StudentHealthRequiredImmunizationDate (
    EducationOrganizationId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    ImmunizationTypeDescriptorId INT NOT NULL,
    ImmunizationDate DATE NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentHealthRequiredImmunizationDate_PK PRIMARY KEY (EducationOrganizationId, StudentUSI, ImmunizationTypeDescriptorId, ImmunizationDate)
);
ALTER TABLE edfi.StudentHealthRequiredImmunizationDate ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentHomelessProgramAssociation --
CREATE TABLE edfi.StudentHomelessProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    AwaitingFosterCare BOOLEAN NULL,
    HomelessPrimaryNighttimeResidenceDescriptorId INT NULL,
    HomelessUnaccompaniedYouth BOOLEAN NULL,
    CONSTRAINT StudentHomelessProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentHomelessProgramAssociationHomelessProgramService --
CREATE TABLE edfi.StudentHomelessProgramAssociationHomelessProgramService (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    HomelessProgramServiceDescriptorId INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentHomelessProgramAssociationHomelessProgramService_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, HomelessProgramServiceDescriptorId)
);
ALTER TABLE edfi.StudentHomelessProgramAssociationHomelessProgramService ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentIdentificationDocument --
CREATE TABLE edfi.StudentIdentificationDocument (
    StudentUSI INT NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentIdentificationDocument_PK PRIMARY KEY (StudentUSI, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.StudentIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentIdentificationSystemDescriptor --
CREATE TABLE edfi.StudentIdentificationSystemDescriptor (
    StudentIdentificationSystemDescriptorId INT NOT NULL,
    CONSTRAINT StudentIdentificationSystemDescriptor_PK PRIMARY KEY (StudentIdentificationSystemDescriptorId)
);

-- Table edfi.StudentIdentity --
CREATE TABLE edfi.StudentIdentity (
    EducationOrganizationId BIGINT NOT NULL,
    StudentIdentificationSystemDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(60) NULL,
    IdentificationCode VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentIdentity_PK PRIMARY KEY (EducationOrganizationId, StudentIdentificationSystemDescriptorId, StudentUSI)
);
ALTER TABLE edfi.StudentIdentity ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentIdentity ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentIdentity ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentInterventionAssociation --
CREATE TABLE edfi.StudentInterventionAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    CohortIdentifier VARCHAR(36) NULL,
    CohortEducationOrganizationId BIGINT NULL,
    DiagnosticStatement VARCHAR(1024) NULL,
    Dosage INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentInterventionAssociation_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, StudentUSI)
);
ALTER TABLE edfi.StudentInterventionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentInterventionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentInterventionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentInterventionAssociationInterventionEffectiveness --
CREATE TABLE edfi.StudentInterventionAssociationInterventionEffectiveness (
    EducationOrganizationId BIGINT NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    DiagnosisDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    PopulationServedDescriptorId INT NOT NULL,
    ImprovementIndex INT NULL,
    InterventionEffectivenessRatingDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentInterventionAssociationInterventionEffectiveness_PK PRIMARY KEY (EducationOrganizationId, InterventionIdentificationCode, StudentUSI, DiagnosisDescriptorId, GradeLevelDescriptorId, PopulationServedDescriptorId)
);
ALTER TABLE edfi.StudentInterventionAssociationInterventionEffectiveness ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentInterventionAttendanceEvent --
CREATE TABLE edfi.StudentInterventionAttendanceEvent (
    AttendanceEventCategoryDescriptorId INT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    InterventionIdentificationCode VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    AttendanceEventReason VARCHAR(255) NULL,
    EducationalEnvironmentDescriptorId INT NULL,
    EventDuration DECIMAL(3, 2) NULL,
    InterventionDuration INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentInterventionAttendanceEvent_PK PRIMARY KEY (AttendanceEventCategoryDescriptorId, EducationOrganizationId, EventDate, InterventionIdentificationCode, StudentUSI)
);
ALTER TABLE edfi.StudentInterventionAttendanceEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentInterventionAttendanceEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentInterventionAttendanceEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentLanguageInstructionProgramAssociation --
CREATE TABLE edfi.StudentLanguageInstructionProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    Dosage INT NULL,
    EnglishLearnerParticipation BOOLEAN NULL,
    CONSTRAINT StudentLanguageInstructionProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 --
CREATE TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    MonitoredDescriptorId INT NULL,
    ParticipationDescriptorId INT NULL,
    ProficiencyDescriptorId INT NULL,
    ProgressDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentLanguageInstructionProgramAssociationEnglis_1ac620_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, SchoolYear)
);
ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 --
CREATE TABLE edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    LanguageInstructionProgramServiceDescriptorId INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentLanguageInstructionProgramAssociationLangua_268e07_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, LanguageInstructionProgramServiceDescriptorId)
);
ALTER TABLE edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentMigrantEducationProgramAssociation --
CREATE TABLE edfi.StudentMigrantEducationProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ContinuationOfServicesReasonDescriptorId INT NULL,
    EligibilityExpirationDate DATE NULL,
    LastQualifyingMove DATE NOT NULL,
    PriorityForServices BOOLEAN NOT NULL,
    QualifyingArrivalDate DATE NULL,
    StateResidencyDate DATE NULL,
    USInitialEntry DATE NULL,
    USInitialSchoolEntry DATE NULL,
    USMostRecentEntry DATE NULL,
    CONSTRAINT StudentMigrantEducationProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 --
CREATE TABLE edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    MigrantEducationProgramServiceDescriptorId INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentMigrantEducationProgramAssociationMigrantEd_d9dcd7_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, MigrantEducationProgramServiceDescriptorId)
);
ALTER TABLE edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentNeglectedOrDelinquentProgramAssociation --
CREATE TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ELAProgressLevelDescriptorId INT NULL,
    MathematicsProgressLevelDescriptorId INT NULL,
    NeglectedOrDelinquentProgramDescriptorId INT NULL,
    CONSTRAINT StudentNeglectedOrDelinquentProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 --
CREATE TABLE edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    NeglectedOrDelinquentProgramServiceDescriptorId INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentNeglectedOrDelinquentProgramAssociationNegl_520251_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, NeglectedOrDelinquentProgramServiceDescriptorId)
);
ALTER TABLE edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentOtherName --
CREATE TABLE edfi.StudentOtherName (
    StudentUSI INT NOT NULL,
    OtherNameTypeDescriptorId INT NOT NULL,
    FirstName VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentOtherName_PK PRIMARY KEY (StudentUSI, OtherNameTypeDescriptorId)
);
ALTER TABLE edfi.StudentOtherName ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentPath --
CREATE TABLE edfi.StudentPath (
    EducationOrganizationId BIGINT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentPath_PK PRIMARY KEY (EducationOrganizationId, PathName, StudentUSI)
);
ALTER TABLE edfi.StudentPath ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentPath ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentPath ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentPathMilestoneStatus --
CREATE TABLE edfi.StudentPathMilestoneStatus (
    EducationOrganizationId BIGINT NOT NULL,
    PathMilestoneName VARCHAR(60) NOT NULL,
    PathMilestoneTypeDescriptorId INT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    CompletionIndicator BOOLEAN NULL,
    PathPhaseName VARCHAR(60) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentPathMilestoneStatus_PK PRIMARY KEY (EducationOrganizationId, PathMilestoneName, PathMilestoneTypeDescriptorId, PathName, StudentUSI)
);
ALTER TABLE edfi.StudentPathMilestoneStatus ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentPathMilestoneStatus ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentPathMilestoneStatus ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentPathMilestoneStatusEvent --
CREATE TABLE edfi.StudentPathMilestoneStatusEvent (
    EducationOrganizationId BIGINT NOT NULL,
    PathMilestoneName VARCHAR(60) NOT NULL,
    PathMilestoneTypeDescriptorId INT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    Description VARCHAR(1024) NULL,
    PathMilestoneStatusDate DATE NOT NULL,
    PathMilestoneStatusDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentPathMilestoneStatusEvent_PK PRIMARY KEY (EducationOrganizationId, PathMilestoneName, PathMilestoneTypeDescriptorId, PathName, StudentUSI)
);
ALTER TABLE edfi.StudentPathMilestoneStatusEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentPathPeriod --
CREATE TABLE edfi.StudentPathPeriod (
    EducationOrganizationId BIGINT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentPathPeriod_PK PRIMARY KEY (EducationOrganizationId, PathName, StudentUSI, BeginDate)
);
ALTER TABLE edfi.StudentPathPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentPathPhaseStatus --
CREATE TABLE edfi.StudentPathPhaseStatus (
    EducationOrganizationId BIGINT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    PathPhaseName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    CompletionIndicator BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentPathPhaseStatus_PK PRIMARY KEY (EducationOrganizationId, PathName, PathPhaseName, StudentUSI)
);
ALTER TABLE edfi.StudentPathPhaseStatus ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentPathPhaseStatus ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentPathPhaseStatus ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentPathPhaseStatusEvent --
CREATE TABLE edfi.StudentPathPhaseStatusEvent (
    EducationOrganizationId BIGINT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    PathPhaseName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    PathPhaseStatusDate DATE NOT NULL,
    PathPhaseStatusDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentPathPhaseStatusEvent_PK PRIMARY KEY (EducationOrganizationId, PathName, PathPhaseName, StudentUSI, PathPhaseStatusDate, PathPhaseStatusDescriptorId)
);
ALTER TABLE edfi.StudentPathPhaseStatusEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentPathPhaseStatusPeriod --
CREATE TABLE edfi.StudentPathPhaseStatusPeriod (
    EducationOrganizationId BIGINT NOT NULL,
    PathName VARCHAR(60) NOT NULL,
    PathPhaseName VARCHAR(60) NOT NULL,
    StudentUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentPathPhaseStatusPeriod_PK PRIMARY KEY (EducationOrganizationId, PathName, PathPhaseName, StudentUSI, BeginDate)
);
ALTER TABLE edfi.StudentPathPhaseStatusPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentPersonalIdentificationDocument --
CREATE TABLE edfi.StudentPersonalIdentificationDocument (
    StudentUSI INT NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentExpirationDate DATE NULL,
    DocumentTitle VARCHAR(60) NULL,
    IssuerCountryDescriptorId INT NULL,
    IssuerDocumentIdentificationCode VARCHAR(120) NULL,
    IssuerName VARCHAR(150) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentPersonalIdentificationDocument_PK PRIMARY KEY (StudentUSI, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
);
ALTER TABLE edfi.StudentPersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentProgramAssociation --
CREATE TABLE edfi.StudentProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    CONSTRAINT StudentProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentProgramAssociationService --
CREATE TABLE edfi.StudentProgramAssociationService (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ServiceDescriptorId INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentProgramAssociationService_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, ServiceDescriptorId)
);
ALTER TABLE edfi.StudentProgramAssociationService ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentProgramAttendanceEvent --
CREATE TABLE edfi.StudentProgramAttendanceEvent (
    AttendanceEventCategoryDescriptorId INT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    EventDate DATE NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    AttendanceEventReason VARCHAR(255) NULL,
    EducationalEnvironmentDescriptorId INT NULL,
    EventDuration DECIMAL(3, 2) NULL,
    ProgramAttendanceDuration INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentProgramAttendanceEvent_PK PRIMARY KEY (AttendanceEventCategoryDescriptorId, EducationOrganizationId, EventDate, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);
ALTER TABLE edfi.StudentProgramAttendanceEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentProgramAttendanceEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentProgramAttendanceEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentProgramEvaluation --
CREATE TABLE edfi.StudentProgramEvaluation (
    EvaluationDate DATE NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    EducationOrganizationId BIGINT NULL,
    EvaluationDuration INT NULL,
    StaffEvaluatorStaffUSI INT NULL,
    SummaryEvaluationComment VARCHAR(1024) NULL,
    SummaryEvaluationNumericRating DECIMAL(6, 3) NULL,
    SummaryEvaluationRatingLevelDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentProgramEvaluation_PK PRIMARY KEY (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);
ALTER TABLE edfi.StudentProgramEvaluation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentProgramEvaluation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentProgramEvaluation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentProgramEvaluationExternalEvaluator --
CREATE TABLE edfi.StudentProgramEvaluationExternalEvaluator (
    EvaluationDate DATE NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ExternalEvaluator VARCHAR(150) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentProgramEvaluationExternalEvaluator_PK PRIMARY KEY (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI, ExternalEvaluator)
);
ALTER TABLE edfi.StudentProgramEvaluationExternalEvaluator ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentProgramEvaluationStudentEvaluationElement --
CREATE TABLE edfi.StudentProgramEvaluationStudentEvaluationElement (
    EvaluationDate DATE NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ProgramEvaluationElementTitle VARCHAR(50) NOT NULL,
    EvaluationElementNumericRating DECIMAL(6, 3) NULL,
    EvaluationElementRatingLevelDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentProgramEvaluationStudentEvaluationElement_PK PRIMARY KEY (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI, ProgramEvaluationElementTitle)
);
ALTER TABLE edfi.StudentProgramEvaluationStudentEvaluationElement ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentProgramEvaluationStudentEvaluationObjective --
CREATE TABLE edfi.StudentProgramEvaluationStudentEvaluationObjective (
    EvaluationDate DATE NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramEvaluationPeriodDescriptorId INT NOT NULL,
    ProgramEvaluationTitle VARCHAR(50) NOT NULL,
    ProgramEvaluationTypeDescriptorId INT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ProgramEvaluationObjectiveTitle VARCHAR(50) NOT NULL,
    EvaluationObjectiveNumericRating DECIMAL(6, 3) NULL,
    EvaluationObjectiveRatingLevelDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentProgramEvaluationStudentEvaluationObjective_PK PRIMARY KEY (EvaluationDate, ProgramEducationOrganizationId, ProgramEvaluationPeriodDescriptorId, ProgramEvaluationTitle, ProgramEvaluationTypeDescriptorId, ProgramName, ProgramTypeDescriptorId, StudentUSI, ProgramEvaluationObjectiveTitle)
);
ALTER TABLE edfi.StudentProgramEvaluationStudentEvaluationObjective ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSchoolAssociation --
CREATE TABLE edfi.StudentSchoolAssociation (
    EntryDate DATE NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    CalendarCode VARCHAR(120) NULL,
    ClassOfSchoolYear SMALLINT NULL,
    EducationOrganizationId BIGINT NULL,
    EmployedWhileEnrolled BOOLEAN NULL,
    EnrollmentTypeDescriptorId INT NULL,
    EntryGradeLevelDescriptorId INT NOT NULL,
    EntryGradeLevelReasonDescriptorId INT NULL,
    EntryTypeDescriptorId INT NULL,
    ExitWithdrawDate DATE NULL,
    ExitWithdrawTypeDescriptorId INT NULL,
    FullTimeEquivalency DECIMAL(5, 4) NULL,
    GraduationPlanTypeDescriptorId INT NULL,
    GraduationSchoolYear SMALLINT NULL,
    NextYearGradeLevelDescriptorId INT NULL,
    NextYearSchoolId BIGINT NULL,
    PrimarySchool BOOLEAN NULL,
    RepeatGradeIndicator BOOLEAN NULL,
    ResidencyStatusDescriptorId INT NULL,
    SchoolChoice BOOLEAN NULL,
    SchoolChoiceBasisDescriptorId INT NULL,
    SchoolChoiceTransfer BOOLEAN NULL,
    SchoolYear SMALLINT NULL,
    TermCompletionIndicator BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentSchoolAssociation_PK PRIMARY KEY (EntryDate, SchoolId, StudentUSI)
);
ALTER TABLE edfi.StudentSchoolAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentSchoolAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentSchoolAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSchoolAssociationAlternativeGraduationPlan --
CREATE TABLE edfi.StudentSchoolAssociationAlternativeGraduationPlan (
    EntryDate DATE NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    AlternativeEducationOrganizationId BIGINT NOT NULL,
    AlternativeGraduationPlanTypeDescriptorId INT NOT NULL,
    AlternativeGraduationSchoolYear SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSchoolAssociationAlternativeGraduationPlan_PK PRIMARY KEY (EntryDate, SchoolId, StudentUSI, AlternativeEducationOrganizationId, AlternativeGraduationPlanTypeDescriptorId, AlternativeGraduationSchoolYear)
);
ALTER TABLE edfi.StudentSchoolAssociationAlternativeGraduationPlan ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSchoolAssociationEducationPlan --
CREATE TABLE edfi.StudentSchoolAssociationEducationPlan (
    EntryDate DATE NOT NULL,
    SchoolId BIGINT NOT NULL,
    StudentUSI INT NOT NULL,
    EducationPlanDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSchoolAssociationEducationPlan_PK PRIMARY KEY (EntryDate, SchoolId, StudentUSI, EducationPlanDescriptorId)
);
ALTER TABLE edfi.StudentSchoolAssociationEducationPlan ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSchoolAttendanceEvent --
CREATE TABLE edfi.StudentSchoolAttendanceEvent (
    AttendanceEventCategoryDescriptorId INT NOT NULL,
    EventDate DATE NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    ArrivalTime TIME NULL,
    AttendanceEventReason VARCHAR(255) NULL,
    DepartureTime TIME NULL,
    EducationalEnvironmentDescriptorId INT NULL,
    EventDuration DECIMAL(3, 2) NULL,
    SchoolAttendanceDuration INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentSchoolAttendanceEvent_PK PRIMARY KEY (AttendanceEventCategoryDescriptorId, EventDate, SchoolId, SchoolYear, SessionName, StudentUSI)
);
ALTER TABLE edfi.StudentSchoolAttendanceEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentSchoolAttendanceEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentSchoolAttendanceEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSchoolFoodServiceProgramAssociation --
CREATE TABLE edfi.StudentSchoolFoodServiceProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    DirectCertification BOOLEAN NULL,
    CONSTRAINT StudentSchoolFoodServiceProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb --
CREATE TABLE edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    SchoolFoodServiceProgramServiceDescriptorId INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSchoolFoodServiceProgramAssociationSchoolFo_85a0eb_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, SchoolFoodServiceProgramServiceDescriptorId)
);
ALTER TABLE edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSection504ProgramAssociation --
CREATE TABLE edfi.StudentSection504ProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    AccommodationPlan BOOLEAN NULL,
    Section504DisabilityDescriptorId INT NULL,
    Section504Eligibility BOOLEAN NOT NULL,
    Section504EligibilityDecisionDate DATE NULL,
    Section504MeetingDate DATE NULL,
    CONSTRAINT StudentSection504ProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentSectionAssociation --
CREATE TABLE edfi.StudentSectionAssociation (
    BeginDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    AttemptStatusDescriptorId INT NULL,
    DualCreditEducationOrganizationId BIGINT NULL,
    DualCreditIndicator BOOLEAN NULL,
    DualCreditInstitutionDescriptorId INT NULL,
    DualCreditTypeDescriptorId INT NULL,
    DualHighSchoolCreditIndicator BOOLEAN NULL,
    EndDate DATE NULL,
    HomeroomIndicator BOOLEAN NULL,
    RepeatIdentifierDescriptorId INT NULL,
    TeacherStudentDataLinkExclusion BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentSectionAssociation_PK PRIMARY KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
);
ALTER TABLE edfi.StudentSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentSectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentSectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSectionAssociationProgram --
CREATE TABLE edfi.StudentSectionAssociationProgram (
    BeginDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSectionAssociationProgram_PK PRIMARY KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
);
ALTER TABLE edfi.StudentSectionAssociationProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSectionAttendanceEvent --
CREATE TABLE edfi.StudentSectionAttendanceEvent (
    AttendanceEventCategoryDescriptorId INT NOT NULL,
    EventDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    ArrivalTime TIME NULL,
    AttendanceEventReason VARCHAR(255) NULL,
    DepartureTime TIME NULL,
    EducationalEnvironmentDescriptorId INT NULL,
    EventDuration DECIMAL(3, 2) NULL,
    SectionAttendanceDuration INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentSectionAttendanceEvent_PK PRIMARY KEY (AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
);
ALTER TABLE edfi.StudentSectionAttendanceEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentSectionAttendanceEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentSectionAttendanceEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSectionAttendanceEventClassPeriod --
CREATE TABLE edfi.StudentSectionAttendanceEventClassPeriod (
    AttendanceEventCategoryDescriptorId INT NOT NULL,
    EventDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    StudentUSI INT NOT NULL,
    ClassPeriodName VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSectionAttendanceEventClassPeriod_PK PRIMARY KEY (AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, ClassPeriodName)
);
ALTER TABLE edfi.StudentSectionAttendanceEventClassPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSpecialEducationProgramAssociation --
CREATE TABLE edfi.StudentSpecialEducationProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    IdeaEligibility BOOLEAN NULL,
    IEPBeginDate DATE NULL,
    IEPEndDate DATE NULL,
    IEPEvaluationDueDate DATE NULL,
    IEPLastEvaluationDate DATE NULL,
    IEPLastReviewDate DATE NULL,
    IEPReviewDueDate DATE NULL,
    MedicallyFragile BOOLEAN NULL,
    MultiplyDisabled BOOLEAN NULL,
    ReductionInHoursPerWeekComparedToPeers DECIMAL(5, 2) NULL,
    SchoolHoursPerWeek DECIMAL(5, 2) NULL,
    ShortenedSchoolDayIndicator BOOLEAN NULL,
    SpecialEducationExitDate DATE NULL,
    SpecialEducationExitExplained VARCHAR(1024) NULL,
    SpecialEducationExitReasonDescriptorId INT NULL,
    SpecialEducationHoursPerWeek DECIMAL(5, 2) NULL,
    SpecialEducationSettingDescriptorId INT NULL,
    CONSTRAINT StudentSpecialEducationProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentSpecialEducationProgramAssociationDisability --
CREATE TABLE edfi.StudentSpecialEducationProgramAssociationDisability (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSpecialEducationProgramAssociationDisability_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, DisabilityDescriptorId)
);
ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation --
CREATE TABLE edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSpecialEducationProgramAssociationDisabilit_a2fd20_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
);
ALTER TABLE edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSpecialEducationProgramAssociationServiceProvider --
CREATE TABLE edfi.StudentSpecialEducationProgramAssociationServiceProvider (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    StaffUSI INT NOT NULL,
    PrimaryProvider BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSpecialEducationProgramAssociationServiceProvider_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, StaffUSI)
);
ALTER TABLE edfi.StudentSpecialEducationProgramAssociationServiceProvider ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 --
CREATE TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    SpecialEducationProgramServiceDescriptorId INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSpecialEducationProgramAssociationSpecialEd_a51ff9_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, SpecialEducationProgramServiceDescriptorId)
);
ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c --
CREATE TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    SpecialEducationProgramServiceDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    PrimaryProvider BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentSpecialEducationProgramAssociationSpecialEd_bcba5c_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, SpecialEducationProgramServiceDescriptorId, StaffUSI)
);
ALTER TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentSpecialEducationProgramEligibilityAssociation --
CREATE TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation (
    ConsentToEvaluationReceivedDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    ConsentToEvaluationDate DATE NULL,
    EligibilityConferenceDate DATE NULL,
    EligibilityDelayReasonDescriptorId INT NULL,
    EligibilityDeterminationDate DATE NULL,
    EligibilityEvaluationDate DATE NULL,
    EligibilityEvaluationTypeDescriptorId INT NULL,
    EvaluationCompleteIndicator BOOLEAN NULL,
    EvaluationDelayDays INT NULL,
    EvaluationDelayReasonDescriptorId INT NULL,
    EvaluationLateReason VARCHAR(255) NULL,
    IDEAIndicator BOOLEAN NULL,
    IDEAPartDescriptorId INT NOT NULL,
    OriginalECIServicesDate DATE NULL,
    TransitionConferenceDate DATE NULL,
    TransitionNotificationDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentSpecialEducationProgramEligibilityAssociation_PK PRIMARY KEY (ConsentToEvaluationReceivedDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);
ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentSpecialEducationProgramEligibilityAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentTitleIPartAProgramAssociation --
CREATE TABLE edfi.StudentTitleIPartAProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    TitleIPartAParticipantDescriptorId INT NOT NULL,
    CONSTRAINT StudentTitleIPartAProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
);

-- Table edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService --
CREATE TABLE edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService (
    BeginDate DATE NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    ProgramEducationOrganizationId BIGINT NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StudentUSI INT NOT NULL,
    TitleIPartAProgramServiceDescriptorId INT NOT NULL,
    PrimaryIndicator BOOLEAN NULL,
    ServiceBeginDate DATE NULL,
    ServiceEndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentTitleIPartAProgramAssociationTitleIPartAPro_8adb29_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, TitleIPartAProgramServiceDescriptorId)
);
ALTER TABLE edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentTransportation --
CREATE TABLE edfi.StudentTransportation (
    StudentUSI INT NOT NULL,
    TransportationEducationOrganizationId BIGINT NOT NULL,
    SpecialAccomodationRequirements VARCHAR(1024) NULL,
    TransportationPublicExpenseEligibilityTypeDescriptorId INT NULL,
    TransportationTypeDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentTransportation_PK PRIMARY KEY (StudentUSI, TransportationEducationOrganizationId)
);
ALTER TABLE edfi.StudentTransportation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.StudentTransportation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.StudentTransportation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentTransportationStudentBusDetails --
CREATE TABLE edfi.StudentTransportationStudentBusDetails (
    StudentUSI INT NOT NULL,
    TransportationEducationOrganizationId BIGINT NOT NULL,
    BusNumber VARCHAR(36) NOT NULL,
    BusRouteDescriptorId INT NOT NULL,
    Mileage DECIMAL(5, 2) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentTransportationStudentBusDetails_PK PRIMARY KEY (StudentUSI, TransportationEducationOrganizationId)
);
ALTER TABLE edfi.StudentTransportationStudentBusDetails ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentTransportationStudentBusDetailsTravelDayofWeek --
CREATE TABLE edfi.StudentTransportationStudentBusDetailsTravelDayofWeek (
    StudentUSI INT NOT NULL,
    TransportationEducationOrganizationId BIGINT NOT NULL,
    TravelDayofWeekDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentTransportationStudentBusDetailsTravelDayofWeek_PK PRIMARY KEY (StudentUSI, TransportationEducationOrganizationId, TravelDayofWeekDescriptorId)
);
ALTER TABLE edfi.StudentTransportationStudentBusDetailsTravelDayofWeek ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentTransportationStudentBusDetailsTravelDirection --
CREATE TABLE edfi.StudentTransportationStudentBusDetailsTravelDirection (
    StudentUSI INT NOT NULL,
    TransportationEducationOrganizationId BIGINT NOT NULL,
    TravelDirectionDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentTransportationStudentBusDetailsTravelDirection_PK PRIMARY KEY (StudentUSI, TransportationEducationOrganizationId, TravelDirectionDescriptorId)
);
ALTER TABLE edfi.StudentTransportationStudentBusDetailsTravelDirection ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.StudentVisa --
CREATE TABLE edfi.StudentVisa (
    StudentUSI INT NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentVisa_PK PRIMARY KEY (StudentUSI, VisaDescriptorId)
);
ALTER TABLE edfi.StudentVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SubmissionStatusDescriptor --
CREATE TABLE edfi.SubmissionStatusDescriptor (
    SubmissionStatusDescriptorId INT NOT NULL,
    CONSTRAINT SubmissionStatusDescriptor_PK PRIMARY KEY (SubmissionStatusDescriptorId)
);

-- Table edfi.SupporterMilitaryConnectionDescriptor --
CREATE TABLE edfi.SupporterMilitaryConnectionDescriptor (
    SupporterMilitaryConnectionDescriptorId INT NOT NULL,
    CONSTRAINT SupporterMilitaryConnectionDescriptor_PK PRIMARY KEY (SupporterMilitaryConnectionDescriptorId)
);

-- Table edfi.Survey --
CREATE TABLE edfi.Survey (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NULL,
    NumberAdministered INT NULL,
    SchoolId BIGINT NULL,
    SchoolYear SMALLINT NOT NULL,
    SessionName VARCHAR(120) NULL,
    SurveyCategoryDescriptorId INT NULL,
    SurveyTitle VARCHAR(255) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Survey_PK PRIMARY KEY (Namespace, SurveyIdentifier)
);
ALTER TABLE edfi.Survey ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.Survey ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.Survey ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyCategoryDescriptor --
CREATE TABLE edfi.SurveyCategoryDescriptor (
    SurveyCategoryDescriptorId INT NOT NULL,
    CONSTRAINT SurveyCategoryDescriptor_PK PRIMARY KEY (SurveyCategoryDescriptorId)
);

-- Table edfi.SurveyCourseAssociation --
CREATE TABLE edfi.SurveyCourseAssociation (
    CourseCode VARCHAR(120) NOT NULL,
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyCourseAssociation_PK PRIMARY KEY (CourseCode, EducationOrganizationId, Namespace, SurveyIdentifier)
);
ALTER TABLE edfi.SurveyCourseAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveyCourseAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveyCourseAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyLevelDescriptor --
CREATE TABLE edfi.SurveyLevelDescriptor (
    SurveyLevelDescriptorId INT NOT NULL,
    CONSTRAINT SurveyLevelDescriptor_PK PRIMARY KEY (SurveyLevelDescriptorId)
);

-- Table edfi.SurveyProgramAssociation --
CREATE TABLE edfi.SurveyProgramAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    ProgramName VARCHAR(60) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyProgramAssociation_PK PRIMARY KEY (EducationOrganizationId, Namespace, ProgramName, ProgramTypeDescriptorId, SurveyIdentifier)
);
ALTER TABLE edfi.SurveyProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveyProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveyProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyQuestion --
CREATE TABLE edfi.SurveyQuestion (
    Namespace VARCHAR(255) NOT NULL,
    QuestionCode VARCHAR(120) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    QuestionFormDescriptorId INT NOT NULL,
    QuestionText VARCHAR(1024) NOT NULL,
    SurveySectionTitle VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyQuestion_PK PRIMARY KEY (Namespace, QuestionCode, SurveyIdentifier)
);
ALTER TABLE edfi.SurveyQuestion ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveyQuestion ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveyQuestion ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyQuestionMatrix --
CREATE TABLE edfi.SurveyQuestionMatrix (
    Namespace VARCHAR(255) NOT NULL,
    QuestionCode VARCHAR(120) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    MatrixElement VARCHAR(255) NOT NULL,
    MaxRawScore INT NULL,
    MinRawScore INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SurveyQuestionMatrix_PK PRIMARY KEY (Namespace, QuestionCode, SurveyIdentifier, MatrixElement)
);
ALTER TABLE edfi.SurveyQuestionMatrix ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyQuestionResponse --
CREATE TABLE edfi.SurveyQuestionResponse (
    Namespace VARCHAR(255) NOT NULL,
    QuestionCode VARCHAR(120) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    Comment VARCHAR(1024) NULL,
    NoResponse BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyQuestionResponse_PK PRIMARY KEY (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier)
);
ALTER TABLE edfi.SurveyQuestionResponse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveyQuestionResponse ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveyQuestionResponse ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyQuestionResponseChoice --
CREATE TABLE edfi.SurveyQuestionResponseChoice (
    Namespace VARCHAR(255) NOT NULL,
    QuestionCode VARCHAR(120) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SortOrder INT NOT NULL,
    NumericValue INT NULL,
    TextValue VARCHAR(255) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SurveyQuestionResponseChoice_PK PRIMARY KEY (Namespace, QuestionCode, SurveyIdentifier, SortOrder)
);
ALTER TABLE edfi.SurveyQuestionResponseChoice ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse --
CREATE TABLE edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse (
    Namespace VARCHAR(255) NOT NULL,
    QuestionCode VARCHAR(120) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    MatrixElement VARCHAR(255) NOT NULL,
    MaxNumericResponse INT NULL,
    MinNumericResponse INT NULL,
    NoResponse BOOLEAN NULL,
    NumericResponse INT NULL,
    TextResponse VARCHAR(2048) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SurveyQuestionResponseSurveyQuestionMatrixElementResponse_PK PRIMARY KEY (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier, MatrixElement)
);
ALTER TABLE edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyQuestionResponseValue --
CREATE TABLE edfi.SurveyQuestionResponseValue (
    Namespace VARCHAR(255) NOT NULL,
    QuestionCode VARCHAR(120) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    SurveyQuestionResponseValueIdentifier INT NOT NULL,
    NumericResponse INT NULL,
    TextResponse VARCHAR(2048) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SurveyQuestionResponseValue_PK PRIMARY KEY (Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier, SurveyQuestionResponseValueIdentifier)
);
ALTER TABLE edfi.SurveyQuestionResponseValue ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyResponse --
CREATE TABLE edfi.SurveyResponse (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    ContactUSI INT NULL,
    ElectronicMailAddress VARCHAR(128) NULL,
    FullName VARCHAR(80) NULL,
    Location VARCHAR(75) NULL,
    PersonId VARCHAR(32) NULL,
    ResponseDate DATE NOT NULL,
    ResponseTime INT NULL,
    SourceSystemDescriptorId INT NULL,
    StaffUSI INT NULL,
    StudentUSI INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyResponse_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
);
ALTER TABLE edfi.SurveyResponse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveyResponse ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveyResponse ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyResponseEducationOrganizationTargetAssociation --
CREATE TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyResponseEducationOrganizationTargetAssociation_PK PRIMARY KEY (EducationOrganizationId, Namespace, SurveyIdentifier, SurveyResponseIdentifier)
);
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyResponsePersonTargetAssociation --
CREATE TABLE edfi.SurveyResponsePersonTargetAssociation (
    Namespace VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyResponsePersonTargetAssociation_PK PRIMARY KEY (Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier)
);
ALTER TABLE edfi.SurveyResponsePersonTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveyResponsePersonTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveyResponsePersonTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyResponseStaffTargetAssociation --
CREATE TABLE edfi.SurveyResponseStaffTargetAssociation (
    Namespace VARCHAR(255) NOT NULL,
    StaffUSI INT NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyResponseStaffTargetAssociation_PK PRIMARY KEY (Namespace, StaffUSI, SurveyIdentifier, SurveyResponseIdentifier)
);
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveyResponseStaffTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveyResponseSurveyLevel --
CREATE TABLE edfi.SurveyResponseSurveyLevel (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    SurveyLevelDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SurveyResponseSurveyLevel_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveyLevelDescriptorId)
);
ALTER TABLE edfi.SurveyResponseSurveyLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveySection --
CREATE TABLE edfi.SurveySection (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    EducationOrganizationId BIGINT NULL,
    EvaluationElementTitle VARCHAR(255) NULL,
    EvaluationObjectiveTitle VARCHAR(50) NULL,
    EvaluationPeriodDescriptorId INT NULL,
    EvaluationTitle VARCHAR(50) NULL,
    PerformanceEvaluationTitle VARCHAR(50) NULL,
    PerformanceEvaluationTypeDescriptorId INT NULL,
    SchoolYear SMALLINT NULL,
    TermDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySection_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
);
ALTER TABLE edfi.SurveySection ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveySection ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveySection ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveySectionAggregateResponse --
CREATE TABLE edfi.SurveySectionAggregateResponse (
    EducationOrganizationId BIGINT NOT NULL,
    EvaluationDate TIMESTAMP NOT NULL,
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
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    TermDescriptorId INT NOT NULL,
    ScoreValue DECIMAL(6, 3) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionAggregateResponse_PK PRIMARY KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, Namespace, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, SurveyIdentifier, SurveySectionTitle, TermDescriptorId)
);
ALTER TABLE edfi.SurveySectionAggregateResponse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveySectionAggregateResponse ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveySectionAggregateResponse ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveySectionAssociation --
CREATE TABLE edfi.SurveySectionAssociation (
    LocalCourseCode VARCHAR(60) NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    SchoolId BIGINT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(120) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionAssociation_PK PRIMARY KEY (LocalCourseCode, Namespace, SchoolId, SchoolYear, SectionIdentifier, SessionName, SurveyIdentifier)
);
ALTER TABLE edfi.SurveySectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveySectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveySectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveySectionResponse --
CREATE TABLE edfi.SurveySectionResponse (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    SectionRating DECIMAL(9, 3) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionResponse_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
);
ALTER TABLE edfi.SurveySectionResponse ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveySectionResponse ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveySectionResponse ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveySectionResponseEducationOrganizationTargetAssociation --
CREATE TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation (
    EducationOrganizationId BIGINT NOT NULL,
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionResponseEducationOrganizationTargetAssociation_PK PRIMARY KEY (EducationOrganizationId, Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
);
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveySectionResponsePersonTargetAssociation --
CREATE TABLE edfi.SurveySectionResponsePersonTargetAssociation (
    Namespace VARCHAR(255) NOT NULL,
    PersonId VARCHAR(32) NOT NULL,
    SourceSystemDescriptorId INT NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionResponsePersonTargetAssociation_PK PRIMARY KEY (Namespace, PersonId, SourceSystemDescriptorId, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
);
ALTER TABLE edfi.SurveySectionResponsePersonTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveySectionResponsePersonTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveySectionResponsePersonTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.SurveySectionResponseStaffTargetAssociation --
CREATE TABLE edfi.SurveySectionResponseStaffTargetAssociation (
    Namespace VARCHAR(255) NOT NULL,
    StaffUSI INT NOT NULL,
    SurveyIdentifier VARCHAR(120) NOT NULL,
    SurveyResponseIdentifier VARCHAR(120) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionResponseStaffTargetAssociation_PK PRIMARY KEY (Namespace, StaffUSI, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
);
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE edfi.SurveySectionResponseStaffTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp AT TIME ZONE 'UTC';

-- Table edfi.TeachingCredentialBasisDescriptor --
CREATE TABLE edfi.TeachingCredentialBasisDescriptor (
    TeachingCredentialBasisDescriptorId INT NOT NULL,
    CONSTRAINT TeachingCredentialBasisDescriptor_PK PRIMARY KEY (TeachingCredentialBasisDescriptorId)
);

-- Table edfi.TeachingCredentialDescriptor --
CREATE TABLE edfi.TeachingCredentialDescriptor (
    TeachingCredentialDescriptorId INT NOT NULL,
    CONSTRAINT TeachingCredentialDescriptor_PK PRIMARY KEY (TeachingCredentialDescriptorId)
);

-- Table edfi.TechnicalSkillsAssessmentDescriptor --
CREATE TABLE edfi.TechnicalSkillsAssessmentDescriptor (
    TechnicalSkillsAssessmentDescriptorId INT NOT NULL,
    CONSTRAINT TechnicalSkillsAssessmentDescriptor_PK PRIMARY KEY (TechnicalSkillsAssessmentDescriptorId)
);

-- Table edfi.TelephoneNumberTypeDescriptor --
CREATE TABLE edfi.TelephoneNumberTypeDescriptor (
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    CONSTRAINT TelephoneNumberTypeDescriptor_PK PRIMARY KEY (TelephoneNumberTypeDescriptorId)
);

-- Table edfi.TermDescriptor --
CREATE TABLE edfi.TermDescriptor (
    TermDescriptorId INT NOT NULL,
    CONSTRAINT TermDescriptor_PK PRIMARY KEY (TermDescriptorId)
);

-- Table edfi.TitleIPartAParticipantDescriptor --
CREATE TABLE edfi.TitleIPartAParticipantDescriptor (
    TitleIPartAParticipantDescriptorId INT NOT NULL,
    CONSTRAINT TitleIPartAParticipantDescriptor_PK PRIMARY KEY (TitleIPartAParticipantDescriptorId)
);

-- Table edfi.TitleIPartAProgramServiceDescriptor --
CREATE TABLE edfi.TitleIPartAProgramServiceDescriptor (
    TitleIPartAProgramServiceDescriptorId INT NOT NULL,
    CONSTRAINT TitleIPartAProgramServiceDescriptor_PK PRIMARY KEY (TitleIPartAProgramServiceDescriptorId)
);

-- Table edfi.TitleIPartASchoolDesignationDescriptor --
CREATE TABLE edfi.TitleIPartASchoolDesignationDescriptor (
    TitleIPartASchoolDesignationDescriptorId INT NOT NULL,
    CONSTRAINT TitleIPartASchoolDesignationDescriptor_PK PRIMARY KEY (TitleIPartASchoolDesignationDescriptorId)
);

-- Table edfi.TransportationPublicExpenseEligibilityTypeDescriptor --
CREATE TABLE edfi.TransportationPublicExpenseEligibilityTypeDescriptor (
    TransportationPublicExpenseEligibilityTypeDescriptorId INT NOT NULL,
    CONSTRAINT TransportationPublicExpenseEligibilityTypeDescriptor_PK PRIMARY KEY (TransportationPublicExpenseEligibilityTypeDescriptorId)
);

-- Table edfi.TransportationTypeDescriptor --
CREATE TABLE edfi.TransportationTypeDescriptor (
    TransportationTypeDescriptorId INT NOT NULL,
    CONSTRAINT TransportationTypeDescriptor_PK PRIMARY KEY (TransportationTypeDescriptorId)
);

-- Table edfi.TravelDayofWeekDescriptor --
CREATE TABLE edfi.TravelDayofWeekDescriptor (
    TravelDayofWeekDescriptorId INT NOT NULL,
    CONSTRAINT TravelDayofWeekDescriptor_PK PRIMARY KEY (TravelDayofWeekDescriptorId)
);

-- Table edfi.TravelDirectionDescriptor --
CREATE TABLE edfi.TravelDirectionDescriptor (
    TravelDirectionDescriptorId INT NOT NULL,
    CONSTRAINT TravelDirectionDescriptor_PK PRIMARY KEY (TravelDirectionDescriptorId)
);

-- Table edfi.TribalAffiliationDescriptor --
CREATE TABLE edfi.TribalAffiliationDescriptor (
    TribalAffiliationDescriptorId INT NOT NULL,
    CONSTRAINT TribalAffiliationDescriptor_PK PRIMARY KEY (TribalAffiliationDescriptorId)
);

-- Table edfi.VisaDescriptor --
CREATE TABLE edfi.VisaDescriptor (
    VisaDescriptorId INT NOT NULL,
    CONSTRAINT VisaDescriptor_PK PRIMARY KEY (VisaDescriptorId)
);

-- Table edfi.WeaponDescriptor --
CREATE TABLE edfi.WeaponDescriptor (
    WeaponDescriptorId INT NOT NULL,
    CONSTRAINT WeaponDescriptor_PK PRIMARY KEY (WeaponDescriptorId)
);

-- Table edfi.WithdrawReasonDescriptor --
CREATE TABLE edfi.WithdrawReasonDescriptor (
    WithdrawReasonDescriptorId INT NOT NULL,
    CONSTRAINT WithdrawReasonDescriptor_PK PRIMARY KEY (WithdrawReasonDescriptorId)
);

