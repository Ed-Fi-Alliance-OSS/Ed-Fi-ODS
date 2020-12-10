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

-- Table tpdm.AnonymizedStudent --
CREATE TABLE tpdm.AnonymizedStudent (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    ValueTypeDescriptorId INT NULL,
    SexDescriptorId INT NULL,
    GenderDescriptorId INT NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    GradeLevelDescriptorId INT NULL,
    Section504Enrollment BOOLEAN NULL,
    ELLEnrollment BOOLEAN NULL,
    ESLEnrollment BOOLEAN NULL,
    SPEDEnrollment BOOLEAN NULL,
    TitleIEnrollment BOOLEAN NULL,
    AtriskIndicator BOOLEAN NULL,
    Mobility INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudent_PK PRIMARY KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentAcademicRecord --
CREATE TABLE tpdm.AnonymizedStudentAcademicRecord (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    FactAsOfDate DATE NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    SessionGradePointAverage DECIMAL(18, 4) NULL,
    CumulativeGradePointAverage DECIMAL(18, 4) NULL,
    GPAMax DECIMAL(18, 4) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudentAcademicRecord_PK PRIMARY KEY (AnonymizedStudentIdentifier, EducationOrganizationId, FactAsOfDate, FactsAsOfDate, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.AnonymizedStudentAcademicRecord ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudentAcademicRecord ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudentAcademicRecord ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentAssessment --
CREATE TABLE tpdm.AnonymizedStudentAssessment (
    AdministrationDate DATE NOT NULL,
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    AssessmentIdentifier VARCHAR(60) NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TakenSchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NULL,
    AssessmentTitle VARCHAR(100) NULL,
    AssessmentCategoryDescriptorId INT NULL,
    AcademicSubjectDescriptorId INT NULL,
    GradeLevelDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudentAssessment_PK PRIMARY KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentAssessment ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudentAssessment ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudentAssessment ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentAssessmentCourseAssociation --
CREATE TABLE tpdm.AnonymizedStudentAssessmentCourseAssociation (
    AdministrationDate DATE NOT NULL,
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    AssessmentIdentifier VARCHAR(60) NOT NULL,
    CourseCode VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TakenSchoolYear SMALLINT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudentAssessmentCourseAssociation_PK PRIMARY KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, CourseCode, EducationOrganizationId, FactsAsOfDate, SchoolYear, TakenSchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentAssessmentCourseAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudentAssessmentCourseAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudentAssessmentCourseAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentAssessmentPerformanceLevel --
CREATE TABLE tpdm.AnonymizedStudentAssessmentPerformanceLevel (
    AdministrationDate DATE NOT NULL,
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    AssessmentIdentifier VARCHAR(60) NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TakenSchoolYear SMALLINT NOT NULL,
    PerformanceLevelMet BOOLEAN NOT NULL,
    PerformanceLevelDescriptorId INT NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AnonymizedStudentAssessmentPerformanceLevel_PK PRIMARY KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentAssessmentPerformanceLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentAssessmentScoreResult --
CREATE TABLE tpdm.AnonymizedStudentAssessmentScoreResult (
    AdministrationDate DATE NOT NULL,
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    AssessmentIdentifier VARCHAR(60) NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TakenSchoolYear SMALLINT NOT NULL,
    Result VARCHAR(35) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AnonymizedStudentAssessmentScoreResult_PK PRIMARY KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentAssessmentScoreResult ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentAssessmentSectionAssociation --
CREATE TABLE tpdm.AnonymizedStudentAssessmentSectionAssociation (
    AdministrationDate DATE NOT NULL,
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    AssessmentIdentifier VARCHAR(60) NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(60) NOT NULL,
    TakenSchoolYear SMALLINT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudentAssessmentSectionAssociation_PK PRIMARY KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, TakenSchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentAssessmentSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudentAssessmentSectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudentAssessmentSectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentCourseAssociation --
CREATE TABLE tpdm.AnonymizedStudentCourseAssociation (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    BeginDate DATE NOT NULL,
    CourseCode VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudentCourseAssociation_PK PRIMARY KEY (AnonymizedStudentIdentifier, BeginDate, CourseCode, EducationOrganizationId, FactsAsOfDate, SchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentCourseAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudentCourseAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudentCourseAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentCourseTranscript --
CREATE TABLE tpdm.AnonymizedStudentCourseTranscript (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    CourseCode VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    FactAsOfDate DATE NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TermDescriptorId INT NOT NULL,
    FinalLetterGradeEarned VARCHAR(20) NULL,
    FinalNumericGradeEarned DECIMAL(9, 2) NULL,
    CourseRepeatCodeDescriptorId INT NULL,
    CourseTitle VARCHAR(60) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudentCourseTranscript_PK PRIMARY KEY (AnonymizedStudentIdentifier, CourseCode, EducationOrganizationId, FactAsOfDate, FactsAsOfDate, SchoolYear, TermDescriptorId)
); 
ALTER TABLE tpdm.AnonymizedStudentCourseTranscript ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudentCourseTranscript ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudentCourseTranscript ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentDisability --
CREATE TABLE tpdm.AnonymizedStudentDisability (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AnonymizedStudentDisability_PK PRIMARY KEY (AnonymizedStudentIdentifier, DisabilityDescriptorId, FactsAsOfDate, SchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentDisabilityDesignation --
CREATE TABLE tpdm.AnonymizedStudentDisabilityDesignation (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AnonymizedStudentDisabilityDesignation_PK PRIMARY KEY (AnonymizedStudentIdentifier, DisabilityDescriptorId, DisabilityDesignationDescriptorId, FactsAsOfDate, SchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentEducationOrganizationAssociation --
CREATE TABLE tpdm.AnonymizedStudentEducationOrganizationAssociation (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudentEducationOrganizationAssociation_PK PRIMARY KEY (AnonymizedStudentIdentifier, BeginDate, EducationOrganizationId, FactsAsOfDate, SchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentEducationOrganizationAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudentEducationOrganizationAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudentEducationOrganizationAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentLanguage --
CREATE TABLE tpdm.AnonymizedStudentLanguage (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AnonymizedStudentLanguage_PK PRIMARY KEY (AnonymizedStudentIdentifier, FactsAsOfDate, LanguageDescriptorId, SchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentLanguageUse --
CREATE TABLE tpdm.AnonymizedStudentLanguageUse (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AnonymizedStudentLanguageUse_PK PRIMARY KEY (AnonymizedStudentIdentifier, FactsAsOfDate, LanguageDescriptorId, LanguageUseDescriptorId, SchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentRace --
CREATE TABLE tpdm.AnonymizedStudentRace (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    RaceDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT AnonymizedStudentRace_PK PRIMARY KEY (AnonymizedStudentIdentifier, FactsAsOfDate, RaceDescriptorId, SchoolYear)
); 
ALTER TABLE tpdm.AnonymizedStudentRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.AnonymizedStudentSectionAssociation --
CREATE TABLE tpdm.AnonymizedStudentSectionAssociation (
    AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
    BeginDate DATE NOT NULL,
    FactsAsOfDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(60) NOT NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT AnonymizedStudentSectionAssociation_PK PRIMARY KEY (AnonymizedStudentIdentifier, BeginDate, FactsAsOfDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
); 
ALTER TABLE tpdm.AnonymizedStudentSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.AnonymizedStudentSectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.AnonymizedStudentSectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.Applicant --
CREATE TABLE tpdm.Applicant (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
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
    LoginId VARCHAR(60) NULL,
    GenderDescriptorId INT NULL,
    EconomicDisadvantaged BOOLEAN NULL,
    FirstGenerationStudent BOOLEAN NULL,
    TeacherCandidateIdentifier VARCHAR(32) NULL,
    PersonId VARCHAR(32) NULL,
    SourceSystemDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Applicant_PK PRIMARY KEY (ApplicantIdentifier)
); 
ALTER TABLE tpdm.Applicant ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.Applicant ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.Applicant ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantAddress --
CREATE TABLE tpdm.ApplicantAddress (
    AddressTypeDescriptorId INT NOT NULL,
    ApplicantIdentifier VARCHAR(32) NOT NULL,
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
    CONSTRAINT ApplicantAddress_PK PRIMARY KEY (AddressTypeDescriptorId, ApplicantIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
); 
ALTER TABLE tpdm.ApplicantAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantAddressPeriod --
CREATE TABLE tpdm.ApplicantAddressPeriod (
    AddressTypeDescriptorId INT NOT NULL,
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    BeginDate DATE NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantAddressPeriod_PK PRIMARY KEY (AddressTypeDescriptorId, ApplicantIdentifier, BeginDate, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
); 
ALTER TABLE tpdm.ApplicantAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantAid --
CREATE TABLE tpdm.ApplicantAid (
    AidTypeDescriptorId INT NOT NULL,
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    AidConditionDescription VARCHAR(1024) NULL,
    AidAmount MONEY NULL,
    PellGrantRecipient BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantAid_PK PRIMARY KEY (AidTypeDescriptorId, ApplicantIdentifier, BeginDate)
); 
ALTER TABLE tpdm.ApplicantAid ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantBackgroundCheck --
CREATE TABLE tpdm.ApplicantBackgroundCheck (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantBackgroundCheck_PK PRIMARY KEY (ApplicantIdentifier, BackgroundCheckTypeDescriptorId)
); 
ALTER TABLE tpdm.ApplicantBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantCharacteristic --
CREATE TABLE tpdm.ApplicantCharacteristic (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    StudentCharacteristicDescriptorId INT NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    DesignatedBy VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantCharacteristic_PK PRIMARY KEY (ApplicantIdentifier, StudentCharacteristicDescriptorId)
); 
ALTER TABLE tpdm.ApplicantCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantDisability --
CREATE TABLE tpdm.ApplicantDisability (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantDisability_PK PRIMARY KEY (ApplicantIdentifier, DisabilityDescriptorId)
); 
ALTER TABLE tpdm.ApplicantDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantDisabilityDesignation --
CREATE TABLE tpdm.ApplicantDisabilityDesignation (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantDisabilityDesignation_PK PRIMARY KEY (ApplicantIdentifier, DisabilityDescriptorId, DisabilityDesignationDescriptorId)
); 
ALTER TABLE tpdm.ApplicantDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantElectronicMail --
CREATE TABLE tpdm.ApplicantElectronicMail (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantElectronicMail_PK PRIMARY KEY (ApplicantIdentifier, ElectronicMailAddress, ElectronicMailTypeDescriptorId)
); 
ALTER TABLE tpdm.ApplicantElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantIdentificationDocument --
CREATE TABLE tpdm.ApplicantIdentificationDocument (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantIdentificationDocument_PK PRIMARY KEY (ApplicantIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
); 
ALTER TABLE tpdm.ApplicantIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantInternationalAddress --
CREATE TABLE tpdm.ApplicantInternationalAddress (
    AddressTypeDescriptorId INT NOT NULL,
    ApplicantIdentifier VARCHAR(32) NOT NULL,
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
    CONSTRAINT ApplicantInternationalAddress_PK PRIMARY KEY (AddressTypeDescriptorId, ApplicantIdentifier)
); 
ALTER TABLE tpdm.ApplicantInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantLanguage --
CREATE TABLE tpdm.ApplicantLanguage (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantLanguage_PK PRIMARY KEY (ApplicantIdentifier, LanguageDescriptorId)
); 
ALTER TABLE tpdm.ApplicantLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantLanguageUse --
CREATE TABLE tpdm.ApplicantLanguageUse (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantLanguageUse_PK PRIMARY KEY (ApplicantIdentifier, LanguageDescriptorId, LanguageUseDescriptorId)
); 
ALTER TABLE tpdm.ApplicantLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantPersonalIdentificationDocument --
CREATE TABLE tpdm.ApplicantPersonalIdentificationDocument (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantPersonalIdentificationDocument_PK PRIMARY KEY (ApplicantIdentifier, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId)
); 
ALTER TABLE tpdm.ApplicantPersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantProspectAssociation --
CREATE TABLE tpdm.ApplicantProspectAssociation (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT ApplicantProspectAssociation_PK PRIMARY KEY (ApplicantIdentifier, EducationOrganizationId, ProspectIdentifier)
); 
ALTER TABLE tpdm.ApplicantProspectAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.ApplicantProspectAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.ApplicantProspectAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantRace --
CREATE TABLE tpdm.ApplicantRace (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantRace_PK PRIMARY KEY (ApplicantIdentifier, RaceDescriptorId)
); 
ALTER TABLE tpdm.ApplicantRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantStaffIdentificationCode --
CREATE TABLE tpdm.ApplicantStaffIdentificationCode (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    StaffIdentificationSystemDescriptorId INT NOT NULL,
    IdentificationCode VARCHAR(60) NOT NULL,
    AssigningOrganizationIdentificationCode VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantStaffIdentificationCode_PK PRIMARY KEY (ApplicantIdentifier, StaffIdentificationSystemDescriptorId)
); 
ALTER TABLE tpdm.ApplicantStaffIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantTeacherPreparationProgram --
CREATE TABLE tpdm.ApplicantTeacherPreparationProgram (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    TeacherPreparationProgramName VARCHAR(255) NOT NULL,
    TeacherPreparationProgramIdentifier VARCHAR(75) NULL,
    TeacherPreparationProgramTypeDescriptorId INT NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    MajorSpecialization VARCHAR(75) NOT NULL,
    GPA DECIMAL(18, 4) NULL,
    LevelOfDegreeAwardedDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantTeacherPreparationProgram_PK PRIMARY KEY (ApplicantIdentifier, TeacherPreparationProgramName)
); 
ALTER TABLE tpdm.ApplicantTeacherPreparationProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantTelephone --
CREATE TABLE tpdm.ApplicantTelephone (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantTelephone_PK PRIMARY KEY (ApplicantIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
); 
ALTER TABLE tpdm.ApplicantTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicantVisa --
CREATE TABLE tpdm.ApplicantVisa (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicantVisa_PK PRIMARY KEY (ApplicantIdentifier, VisaDescriptorId)
); 
ALTER TABLE tpdm.ApplicantVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.Application --
CREATE TABLE tpdm.Application (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
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
    HighestCompletedLevelOfEducationDescriptorId INT NULL,
    YearsOfPriorProfessionalExperience DECIMAL(5, 2) NULL,
    YearsOfPriorTeachingExperience DECIMAL(5, 2) NULL,
    HighlyQualifiedTeacher BOOLEAN NULL,
    HighlyQualifiedAcademicSubjectDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Application_PK PRIMARY KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
); 
ALTER TABLE tpdm.Application ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.Application ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.Application ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicationEvent --
CREATE TABLE tpdm.ApplicationEvent (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
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
    CONSTRAINT ApplicationEvent_PK PRIMARY KEY (ApplicantIdentifier, ApplicationEventTypeDescriptorId, ApplicationIdentifier, EducationOrganizationId, EventDate, SequenceNumber)
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

-- Table tpdm.ApplicationGradePointAverage --
CREATE TABLE tpdm.ApplicationGradePointAverage (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    GradePointAverageTypeDescriptorId INT NOT NULL,
    IsCumulative BOOLEAN NULL,
    GradePointAverageValue DECIMAL(18, 4) NOT NULL,
    MaxGradePointAverageValue DECIMAL(18, 4) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationGradePointAverage_PK PRIMARY KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId, GradePointAverageTypeDescriptorId)
); 
ALTER TABLE tpdm.ApplicationGradePointAverage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicationOpenStaffPosition --
CREATE TABLE tpdm.ApplicationOpenStaffPosition (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    RequisitionNumber VARCHAR(20) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationOpenStaffPosition_PK PRIMARY KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId, RequisitionNumber)
); 
ALTER TABLE tpdm.ApplicationOpenStaffPosition ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ApplicationScoreResult --
CREATE TABLE tpdm.ApplicationScoreResult (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    AssessmentReportingMethodDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    Result VARCHAR(35) NOT NULL,
    ResultDatatypeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationScoreResult_PK PRIMARY KEY (ApplicantIdentifier, ApplicationIdentifier, AssessmentReportingMethodDescriptorId, EducationOrganizationId)
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
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    ApplicationIdentifier VARCHAR(20) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    TermDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ApplicationTerm_PK PRIMARY KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId, TermDescriptorId)
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

-- Table tpdm.CompleterAsStaffAssociation --
CREATE TABLE tpdm.CompleterAsStaffAssociation (
    StaffUSI INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT CompleterAsStaffAssociation_PK PRIMARY KEY (StaffUSI, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.CompleterAsStaffAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.CompleterAsStaffAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.CompleterAsStaffAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

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

-- Table tpdm.EducatorRoleDescriptor --
CREATE TABLE tpdm.EducatorRoleDescriptor (
    EducatorRoleDescriptorId INT NOT NULL,
    CONSTRAINT EducatorRoleDescriptor_PK PRIMARY KEY (EducatorRoleDescriptorId)
); 

-- Table tpdm.EmploymentEvent --
CREATE TABLE tpdm.EmploymentEvent (
    EducationOrganizationId INT NOT NULL,
    EmploymentEventTypeDescriptorId INT NOT NULL,
    RequisitionNumber VARCHAR(20) NOT NULL,
    HireDate DATE NULL,
    EarlyHire BOOLEAN NULL,
    InternalExternalHireDescriptorId INT NULL,
    MutualConsent BOOLEAN NULL,
    RestrictedChoice BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EmploymentEvent_PK PRIMARY KEY (EducationOrganizationId, EmploymentEventTypeDescriptorId, RequisitionNumber)
); 
ALTER TABLE tpdm.EmploymentEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.EmploymentEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.EmploymentEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EmploymentEventTypeDescriptor --
CREATE TABLE tpdm.EmploymentEventTypeDescriptor (
    EmploymentEventTypeDescriptorId INT NOT NULL,
    CONSTRAINT EmploymentEventTypeDescriptor_PK PRIMARY KEY (EmploymentEventTypeDescriptorId)
); 

-- Table tpdm.EmploymentSeparationEvent --
CREATE TABLE tpdm.EmploymentSeparationEvent (
    EducationOrganizationId INT NOT NULL,
    EmploymentSeparationDate DATE NOT NULL,
    RequisitionNumber VARCHAR(20) NOT NULL,
    EmploymentSeparationTypeDescriptorId INT NOT NULL,
    EmploymentSeparationEnteredDate DATE NULL,
    EmploymentSeparationReasonDescriptorId INT NULL,
    RemainingInDistrict BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT EmploymentSeparationEvent_PK PRIMARY KEY (EducationOrganizationId, EmploymentSeparationDate, RequisitionNumber)
); 
ALTER TABLE tpdm.EmploymentSeparationEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.EmploymentSeparationEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.EmploymentSeparationEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.EmploymentSeparationReasonDescriptor --
CREATE TABLE tpdm.EmploymentSeparationReasonDescriptor (
    EmploymentSeparationReasonDescriptorId INT NOT NULL,
    CONSTRAINT EmploymentSeparationReasonDescriptor_PK PRIMARY KEY (EmploymentSeparationReasonDescriptorId)
); 

-- Table tpdm.EmploymentSeparationTypeDescriptor --
CREATE TABLE tpdm.EmploymentSeparationTypeDescriptor (
    EmploymentSeparationTypeDescriptorId INT NOT NULL,
    CONSTRAINT EmploymentSeparationTypeDescriptor_PK PRIMARY KEY (EmploymentSeparationTypeDescriptorId)
); 

-- Table tpdm.EnglishLanguageExamDescriptor --
CREATE TABLE tpdm.EnglishLanguageExamDescriptor (
    EnglishLanguageExamDescriptorId INT NOT NULL,
    CONSTRAINT EnglishLanguageExamDescriptor_PK PRIMARY KEY (EnglishLanguageExamDescriptorId)
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

-- Table tpdm.FieldworkExperienceSchool --
CREATE TABLE tpdm.FieldworkExperienceSchool (
    BeginDate DATE NOT NULL,
    FieldworkIdentifier VARCHAR(64) NOT NULL,
    SchoolId INT NOT NULL,
    StudentUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT FieldworkExperienceSchool_PK PRIMARY KEY (BeginDate, FieldworkIdentifier, SchoolId, StudentUSI)
); 
ALTER TABLE tpdm.FieldworkExperienceSchool ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

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

-- Table tpdm.InternalExternalHireDescriptor --
CREATE TABLE tpdm.InternalExternalHireDescriptor (
    InternalExternalHireDescriptorId INT NOT NULL,
    CONSTRAINT InternalExternalHireDescriptor_PK PRIMARY KEY (InternalExternalHireDescriptorId)
); 

-- Table tpdm.LevelOfDegreeAwardedDescriptor --
CREATE TABLE tpdm.LevelOfDegreeAwardedDescriptor (
    LevelOfDegreeAwardedDescriptorId INT NOT NULL,
    CONSTRAINT LevelOfDegreeAwardedDescriptor_PK PRIMARY KEY (LevelOfDegreeAwardedDescriptorId)
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

-- Table tpdm.Prospect --
CREATE TABLE tpdm.Prospect (
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    FirstName VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    MaidenName VARCHAR(75) NULL,
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    Applied BOOLEAN NULL,
    HispanicLatinoEthnicity BOOLEAN NULL,
    Met BOOLEAN NULL,
    Notes VARCHAR(255) NULL,
    PreScreeningRating INT NULL,
    Referral BOOLEAN NULL,
    ReferredBy VARCHAR(50) NULL,
    SexDescriptorId INT NULL,
    SocialMediaUserName VARCHAR(50) NULL,
    SocialMediaNetworkName VARCHAR(50) NULL,
    GenderDescriptorId INT NULL,
    EconomicDisadvantaged BOOLEAN NULL,
    FirstGenerationStudent BOOLEAN NULL,
    ProspectTypeDescriptorId INT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NULL,
    PersonId VARCHAR(32) NULL,
    SourceSystemDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Prospect_PK PRIMARY KEY (EducationOrganizationId, ProspectIdentifier)
); 
ALTER TABLE tpdm.Prospect ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.Prospect ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.Prospect ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectAid --
CREATE TABLE tpdm.ProspectAid (
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    AidConditionDescription VARCHAR(1024) NULL,
    AidTypeDescriptorId INT NOT NULL,
    AidAmount MONEY NULL,
    PellGrantRecipient BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectAid_PK PRIMARY KEY (EducationOrganizationId, ProspectIdentifier)
); 
ALTER TABLE tpdm.ProspectAid ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectCurrentPosition --
CREATE TABLE tpdm.ProspectCurrentPosition (
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    Location VARCHAR(75) NOT NULL,
    PositionTitle VARCHAR(100) NOT NULL,
    AcademicSubjectDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectCurrentPosition_PK PRIMARY KEY (EducationOrganizationId, ProspectIdentifier)
); 
ALTER TABLE tpdm.ProspectCurrentPosition ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectCurrentPositionGradeLevel --
CREATE TABLE tpdm.ProspectCurrentPositionGradeLevel (
    EducationOrganizationId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectCurrentPositionGradeLevel_PK PRIMARY KEY (EducationOrganizationId, GradeLevelDescriptorId, ProspectIdentifier)
); 
ALTER TABLE tpdm.ProspectCurrentPositionGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectDisability --
CREATE TABLE tpdm.ProspectDisability (
    DisabilityDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectDisability_PK PRIMARY KEY (DisabilityDescriptorId, EducationOrganizationId, ProspectIdentifier)
); 
ALTER TABLE tpdm.ProspectDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectDisabilityDesignation --
CREATE TABLE tpdm.ProspectDisabilityDesignation (
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectDisabilityDesignation_PK PRIMARY KEY (DisabilityDescriptorId, DisabilityDesignationDescriptorId, EducationOrganizationId, ProspectIdentifier)
); 
ALTER TABLE tpdm.ProspectDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectPersonalIdentificationDocument --
CREATE TABLE tpdm.ProspectPersonalIdentificationDocument (
    EducationOrganizationId INT NOT NULL,
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectPersonalIdentificationDocument_PK PRIMARY KEY (EducationOrganizationId, IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId, ProspectIdentifier)
); 
ALTER TABLE tpdm.ProspectPersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectQualifications --
CREATE TABLE tpdm.ProspectQualifications (
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    Eligible BOOLEAN NOT NULL,
    CapacityToServe BOOLEAN NULL,
    YearsOfServiceCurrentPlacement DECIMAL(5, 2) NULL,
    YearsOfServiceTotal DECIMAL(5, 2) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectQualifications_PK PRIMARY KEY (EducationOrganizationId, ProspectIdentifier)
); 
ALTER TABLE tpdm.ProspectQualifications ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectRace --
CREATE TABLE tpdm.ProspectRace (
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    RaceDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectRace_PK PRIMARY KEY (EducationOrganizationId, ProspectIdentifier, RaceDescriptorId)
); 
ALTER TABLE tpdm.ProspectRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectRecruitmentEvent --
CREATE TABLE tpdm.ProspectRecruitmentEvent (
    EducationOrganizationId INT NOT NULL,
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectRecruitmentEvent_PK PRIMARY KEY (EducationOrganizationId, EventDate, EventTitle, ProspectIdentifier)
); 
ALTER TABLE tpdm.ProspectRecruitmentEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectTelephone --
CREATE TABLE tpdm.ProspectTelephone (
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectTelephone_PK PRIMARY KEY (EducationOrganizationId, ProspectIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
); 
ALTER TABLE tpdm.ProspectTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectTouchpoint --
CREATE TABLE tpdm.ProspectTouchpoint (
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    TouchpointContent VARCHAR(255) NOT NULL,
    TouchpointDate DATE NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ProspectTouchpoint_PK PRIMARY KEY (EducationOrganizationId, ProspectIdentifier, TouchpointContent, TouchpointDate)
); 
ALTER TABLE tpdm.ProspectTouchpoint ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.ProspectTypeDescriptor --
CREATE TABLE tpdm.ProspectTypeDescriptor (
    ProspectTypeDescriptorId INT NOT NULL,
    CONSTRAINT ProspectTypeDescriptor_PK PRIMARY KEY (ProspectTypeDescriptorId)
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
    EventDate DATE NOT NULL,
    EventTitle VARCHAR(50) NOT NULL,
    EventDescription VARCHAR(255) NULL,
    RecruitmentEventTypeDescriptorId INT NOT NULL,
    EventLocation VARCHAR(255) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT RecruitmentEvent_PK PRIMARY KEY (EventDate, EventTitle)
); 
ALTER TABLE tpdm.RecruitmentEvent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.RecruitmentEvent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.RecruitmentEvent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

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

-- Table tpdm.StaffApplicantAssociation --
CREATE TABLE tpdm.StaffApplicantAssociation (
    ApplicantIdentifier VARCHAR(32) NOT NULL,
    StaffUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffApplicantAssociation_PK PRIMARY KEY (ApplicantIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.StaffApplicantAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.StaffApplicantAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.StaffApplicantAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffBackgroundCheck --
CREATE TABLE tpdm.StaffBackgroundCheck (
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffBackgroundCheck_PK PRIMARY KEY (BackgroundCheckTypeDescriptorId, StaffUSI)
); 
ALTER TABLE tpdm.StaffBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

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

-- Table tpdm.StaffExtension --
CREATE TABLE tpdm.StaffExtension (
    StaffUSI INT NOT NULL,
    ProbationCompleteDate DATE NULL,
    Tenured BOOLEAN NULL,
    GenderDescriptorId INT NULL,
    TenureTrack BOOLEAN NULL,
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

-- Table tpdm.StaffProspectAssociation --
CREATE TABLE tpdm.StaffProspectAssociation (
    EducationOrganizationId INT NOT NULL,
    ProspectIdentifier VARCHAR(32) NOT NULL,
    StaffUSI INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffProspectAssociation_PK PRIMARY KEY (EducationOrganizationId, ProspectIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.StaffProspectAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.StaffProspectAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.StaffProspectAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffSalary --
CREATE TABLE tpdm.StaffSalary (
    StaffUSI INT NOT NULL,
    SalaryMinRange INT NULL,
    SalaryMaxRange INT NULL,
    SalaryTypeDescriptorId INT NULL,
    SalaryAmount MONEY NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffSalary_PK PRIMARY KEY (StaffUSI)
); 
ALTER TABLE tpdm.StaffSalary ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffSeniority --
CREATE TABLE tpdm.StaffSeniority (
    CredentialFieldDescriptorId INT NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    StaffUSI INT NOT NULL,
    YearsExperience DECIMAL(5, 2) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffSeniority_PK PRIMARY KEY (CredentialFieldDescriptorId, NameOfInstitution, StaffUSI)
); 
ALTER TABLE tpdm.StaffSeniority ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffStudentGrowthMeasure --
CREATE TABLE tpdm.StaffStudentGrowthMeasure (
    FactAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    StaffUSI INT NOT NULL,
    StudentGrowthMeasureDate DATE NULL,
    ResultDatatypeTypeDescriptorId INT NULL,
    StudentGrowthTypeDescriptorId INT NULL,
    StudentGrowthTargetScore INT NULL,
    StudentGrowthActualScore INT NOT NULL,
    StudentGrowthMet BOOLEAN NOT NULL,
    StudentGrowthNCount INT NULL,
    StandardError DECIMAL(5, 4) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffStudentGrowthMeasure_PK PRIMARY KEY (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.StaffStudentGrowthMeasure ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.StaffStudentGrowthMeasure ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.StaffStudentGrowthMeasure ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffStudentGrowthMeasureAcademicSubject --
CREATE TABLE tpdm.StaffStudentGrowthMeasureAcademicSubject (
    AcademicSubjectDescriptorId INT NOT NULL,
    FactAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    StaffUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffStudentGrowthMeasureAcademicSubject_PK PRIMARY KEY (AcademicSubjectDescriptorId, FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.StaffStudentGrowthMeasureAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffStudentGrowthMeasureCourseAssociation --
CREATE TABLE tpdm.StaffStudentGrowthMeasureCourseAssociation (
    CourseCode VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    FactAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    StaffUSI INT NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffStudentGrowthMeasureCourseAssociation_PK PRIMARY KEY (CourseCode, EducationOrganizationId, FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.StaffStudentGrowthMeasureCourseAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.StaffStudentGrowthMeasureCourseAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.StaffStudentGrowthMeasureCourseAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation --
CREATE TABLE tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation (
    EducationOrganizationId INT NOT NULL,
    FactAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    StaffUSI INT NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffStudentGrowthMeasureEducationOrganizationAssociation_PK PRIMARY KEY (EducationOrganizationId, FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffStudentGrowthMeasureGradeLevel --
CREATE TABLE tpdm.StaffStudentGrowthMeasureGradeLevel (
    FactAsOfDate DATE NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    StaffUSI INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffStudentGrowthMeasureGradeLevel_PK PRIMARY KEY (FactAsOfDate, GradeLevelDescriptorId, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.StaffStudentGrowthMeasureGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffStudentGrowthMeasureSectionAssociation --
CREATE TABLE tpdm.StaffStudentGrowthMeasureSectionAssociation (
    FactAsOfDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(60) NOT NULL,
    StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    StaffUSI INT NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffStudentGrowthMeasureSectionAssociation_PK PRIMARY KEY (FactAsOfDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StaffStudentGrowthMeasureIdentifier, StaffUSI)
); 
ALTER TABLE tpdm.StaffStudentGrowthMeasureSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.StaffStudentGrowthMeasureSectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.StaffStudentGrowthMeasureSectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffTeacherEducatorResearch --
CREATE TABLE tpdm.StaffTeacherEducatorResearch (
    StaffUSI INT NOT NULL,
    ResearchExperienceDate DATE NOT NULL,
    ResearchExperienceTitle VARCHAR(60) NULL,
    ResearchExperienceDescription VARCHAR(1024) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffTeacherEducatorResearch_PK PRIMARY KEY (StaffUSI)
); 
ALTER TABLE tpdm.StaffTeacherEducatorResearch ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffTeacherPreparationProgram --
CREATE TABLE tpdm.StaffTeacherPreparationProgram (
    StaffUSI INT NOT NULL,
    TeacherPreparationProgramName VARCHAR(255) NOT NULL,
    TeacherPreparationProgramIdentifier VARCHAR(75) NULL,
    TeacherPreparationProgramTypeDescriptorId INT NOT NULL,
    NameOfInstitution VARCHAR(75) NOT NULL,
    MajorSpecialization VARCHAR(75) NOT NULL,
    GPA DECIMAL(18, 4) NULL,
    LevelOfDegreeAwardedDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffTeacherPreparationProgram_PK PRIMARY KEY (StaffUSI, TeacherPreparationProgramName)
); 
ALTER TABLE tpdm.StaffTeacherPreparationProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.StaffTeacherPreparationProviderProgramAssociation --
CREATE TABLE tpdm.StaffTeacherPreparationProviderProgramAssociation (
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    StaffUSI INT NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    StudentRecordAccess BOOLEAN NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StaffTeacherPreparationProviderProgramAssociation_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI)
); 
ALTER TABLE tpdm.StaffTeacherPreparationProviderProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.StaffTeacherPreparationProviderProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.StaffTeacherPreparationProviderProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

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

-- Table tpdm.StudentGrowthTypeDescriptor --
CREATE TABLE tpdm.StudentGrowthTypeDescriptor (
    StudentGrowthTypeDescriptorId INT NOT NULL,
    CONSTRAINT StudentGrowthTypeDescriptor_PK PRIMARY KEY (StudentGrowthTypeDescriptorId)
); 

-- Table tpdm.SurveyResponseExtension --
CREATE TABLE tpdm.SurveyResponseExtension (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(60) NOT NULL,
    SurveyResponseIdentifier VARCHAR(60) NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NULL,
    ApplicantIdentifier VARCHAR(32) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SurveyResponseExtension_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
); 
ALTER TABLE tpdm.SurveyResponseExtension ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.SurveyResponseTeacherCandidateTargetAssociation --
CREATE TABLE tpdm.SurveyResponseTeacherCandidateTargetAssociation (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(60) NOT NULL,
    SurveyResponseIdentifier VARCHAR(60) NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveyResponseTeacherCandidateTargetAssociation_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.SurveyResponseTeacherCandidateTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.SurveyResponseTeacherCandidateTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.SurveyResponseTeacherCandidateTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

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

-- Table tpdm.SurveySectionResponseTeacherCandidateTargetAssociation --
CREATE TABLE tpdm.SurveySectionResponseTeacherCandidateTargetAssociation (
    Namespace VARCHAR(255) NOT NULL,
    SurveyIdentifier VARCHAR(60) NOT NULL,
    SurveyResponseIdentifier VARCHAR(60) NOT NULL,
    SurveySectionTitle VARCHAR(255) NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SurveySectionResponseTeacherCandidateTargetAssociation_PK PRIMARY KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.SurveySectionResponseTeacherCandidateTargetAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.SurveySectionResponseTeacherCandidateTargetAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.SurveySectionResponseTeacherCandidateTargetAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidate --
CREATE TABLE tpdm.TeacherCandidate (
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
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
    StudentUSI INT NOT NULL,
    PersonId VARCHAR(32) NULL,
    SourceSystemDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidate_PK PRIMARY KEY (TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidate ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidate ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidate ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAcademicRecord --
CREATE TABLE tpdm.TeacherCandidateAcademicRecord (
    EducationOrganizationId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TermDescriptorId INT NOT NULL,
    CumulativeEarnedCredits DECIMAL(9, 3) NULL,
    CumulativeEarnedCreditTypeDescriptorId INT NULL,
    CumulativeEarnedCreditConversion DECIMAL(9, 2) NULL,
    CumulativeAttemptedCredits DECIMAL(9, 3) NULL,
    CumulativeAttemptedCreditTypeDescriptorId INT NULL,
    CumulativeAttemptedCreditConversion DECIMAL(9, 2) NULL,
    CumulativeGradePointsEarned DECIMAL(18, 4) NULL,
    CumulativeGradePointAverage DECIMAL(18, 4) NULL,
    GradeValueQualifier VARCHAR(80) NULL,
    ProjectedGraduationDate DATE NULL,
    SessionEarnedCredits DECIMAL(9, 3) NULL,
    SessionEarnedCreditTypeDescriptorId INT NULL,
    SessionEarnedCreditConversion DECIMAL(9, 2) NULL,
    SessionAttemptedCredits DECIMAL(9, 3) NULL,
    SessionAttemptedCreditTypeDescriptorId INT NULL,
    SessionAttemptedCreditConversion DECIMAL(9, 2) NULL,
    SessionGradePointsEarned DECIMAL(18, 4) NULL,
    SessionGradePointAverage DECIMAL(18, 4) NULL,
    ContentGradePointAverage DECIMAL(18, 4) NULL,
    ContentGradePointEarned DECIMAL(18, 4) NULL,
    ProgramGatewayDescriptorId INT NOT NULL,
    TPPDegreeTypeDescriptorId INT NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidateAcademicRecord_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateAcademicRecord ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidateAcademicRecord ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidateAcademicRecord ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAcademicRecordAcademicHonor --
CREATE TABLE tpdm.TeacherCandidateAcademicRecordAcademicHonor (
    AcademicHonorCategoryDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    HonorDescription VARCHAR(80) NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TermDescriptorId INT NOT NULL,
    AchievementTitle VARCHAR(60) NULL,
    AchievementCategoryDescriptorId INT NULL,
    AchievementCategorySystem VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerOriginURL VARCHAR(255) NULL,
    Criteria VARCHAR(150) NULL,
    CriteriaURL VARCHAR(255) NULL,
    EvidenceStatement VARCHAR(150) NULL,
    ImageURL VARCHAR(255) NULL,
    HonorAwardDate DATE NULL,
    HonorAwardExpiresDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateAcademicRecordAcademicHonor_PK PRIMARY KEY (AcademicHonorCategoryDescriptorId, EducationOrganizationId, HonorDescription, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateAcademicRecordAcademicHonor ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAcademicRecordClassRanking --
CREATE TABLE tpdm.TeacherCandidateAcademicRecordClassRanking (
    EducationOrganizationId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TermDescriptorId INT NOT NULL,
    ClassRank INT NOT NULL,
    TotalNumberInClass INT NOT NULL,
    PercentageRanking INT NULL,
    ClassRankingDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateAcademicRecordClassRanking_PK PRIMARY KEY (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateAcademicRecordClassRanking ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAcademicRecordDiploma --
CREATE TABLE tpdm.TeacherCandidateAcademicRecordDiploma (
    DiplomaAwardDate DATE NOT NULL,
    DiplomaTypeDescriptorId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TermDescriptorId INT NOT NULL,
    AchievementTitle VARCHAR(60) NULL,
    AchievementCategoryDescriptorId INT NULL,
    AchievementCategorySystem VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerOriginURL VARCHAR(255) NULL,
    Criteria VARCHAR(150) NULL,
    CriteriaURL VARCHAR(255) NULL,
    EvidenceStatement VARCHAR(150) NULL,
    ImageURL VARCHAR(255) NULL,
    DiplomaLevelDescriptorId INT NULL,
    CTECompleter BOOLEAN NULL,
    DiplomaDescription VARCHAR(80) NULL,
    DiplomaAwardExpiresDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateAcademicRecordDiploma_PK PRIMARY KEY (DiplomaAwardDate, DiplomaTypeDescriptorId, EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateAcademicRecordDiploma ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAcademicRecordGradePointAverage --
CREATE TABLE tpdm.TeacherCandidateAcademicRecordGradePointAverage (
    EducationOrganizationId INT NOT NULL,
    GradePointAverageTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TermDescriptorId INT NOT NULL,
    IsCumulative BOOLEAN NULL,
    GradePointAverageValue DECIMAL(18, 4) NOT NULL,
    MaxGradePointAverageValue DECIMAL(18, 4) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateAcademicRecordGradePointAverage_PK PRIMARY KEY (EducationOrganizationId, GradePointAverageTypeDescriptorId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateAcademicRecordGradePointAverage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAcademicRecordRecognition --
CREATE TABLE tpdm.TeacherCandidateAcademicRecordRecognition (
    EducationOrganizationId INT NOT NULL,
    RecognitionTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TermDescriptorId INT NOT NULL,
    AchievementTitle VARCHAR(60) NULL,
    AchievementCategoryDescriptorId INT NULL,
    AchievementCategorySystem VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerOriginURL VARCHAR(255) NULL,
    Criteria VARCHAR(150) NULL,
    CriteriaURL VARCHAR(255) NULL,
    EvidenceStatement VARCHAR(150) NULL,
    ImageURL VARCHAR(255) NULL,
    RecognitionDescription VARCHAR(80) NULL,
    RecognitionAwardDate DATE NULL,
    RecognitionAwardExpiresDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateAcademicRecordRecognition_PK PRIMARY KEY (EducationOrganizationId, RecognitionTypeDescriptorId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateAcademicRecordRecognition ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAddress --
CREATE TABLE tpdm.TeacherCandidateAddress (
    AddressTypeDescriptorId INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
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
    CONSTRAINT TeacherCandidateAddress_PK PRIMARY KEY (AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAddressPeriod --
CREATE TABLE tpdm.TeacherCandidateAddressPeriod (
    AddressTypeDescriptorId INT NOT NULL,
    BeginDate DATE NOT NULL,
    City VARCHAR(30) NOT NULL,
    PostalCode VARCHAR(17) NOT NULL,
    StateAbbreviationDescriptorId INT NOT NULL,
    StreetNumberName VARCHAR(150) NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateAddressPeriod_PK PRIMARY KEY (AddressTypeDescriptorId, BeginDate, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateAddressPeriod ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateAid --
CREATE TABLE tpdm.TeacherCandidateAid (
    AidTypeDescriptorId INT NOT NULL,
    BeginDate DATE NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    EndDate DATE NULL,
    AidConditionDescription VARCHAR(1024) NULL,
    AidAmount MONEY NULL,
    PellGrantRecipient BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateAid_PK PRIMARY KEY (AidTypeDescriptorId, BeginDate, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateAid ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateBackgroundCheck --
CREATE TABLE tpdm.TeacherCandidateBackgroundCheck (
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    BackgroundCheckTypeDescriptorId INT NOT NULL,
    BackgroundCheckRequestedDate DATE NOT NULL,
    BackgroundCheckStatusDescriptorId INT NULL,
    BackgroundCheckCompletedDate DATE NULL,
    Fingerprint BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateBackgroundCheck_PK PRIMARY KEY (TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateBackgroundCheck ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateCharacteristic --
CREATE TABLE tpdm.TeacherCandidateCharacteristic (
    StudentCharacteristicDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    DesignatedBy VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateCharacteristic_PK PRIMARY KEY (StudentCharacteristicDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateCharacteristic ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateCharacteristicDescriptor --
CREATE TABLE tpdm.TeacherCandidateCharacteristicDescriptor (
    TeacherCandidateCharacteristicDescriptorId INT NOT NULL,
    CONSTRAINT TeacherCandidateCharacteristicDescriptor_PK PRIMARY KEY (TeacherCandidateCharacteristicDescriptorId)
); 

-- Table tpdm.TeacherCandidateCohortYear --
CREATE TABLE tpdm.TeacherCandidateCohortYear (
    CohortYearTypeDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateCohortYear_PK PRIMARY KEY (CohortYearTypeDescriptorId, SchoolYear, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateCohortYear ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateCourseTranscript --
CREATE TABLE tpdm.TeacherCandidateCourseTranscript (
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(60) NOT NULL,
    CourseEducationOrganizationId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TermDescriptorId INT NOT NULL,
    AttemptedCredits DECIMAL(9, 3) NULL,
    AttemptedCreditTypeDescriptorId INT NULL,
    AttemptedCreditConversion DECIMAL(9, 2) NULL,
    EarnedCredits DECIMAL(9, 3) NOT NULL,
    EarnedCreditTypeDescriptorId INT NULL,
    EarnedCreditConversion DECIMAL(9, 2) NULL,
    WhenTakenGradeLevelDescriptorId INT NULL,
    MethodCreditEarnedDescriptorId INT NULL,
    FinalLetterGradeEarned VARCHAR(20) NULL,
    FinalNumericGradeEarned DECIMAL(9, 2) NULL,
    CourseRepeatCodeDescriptorId INT NULL,
    SchoolId INT NULL,
    CourseTitle VARCHAR(60) NULL,
    AlternativeCourseTitle VARCHAR(60) NULL,
    AlternativeCourseCode VARCHAR(60) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidateCourseTranscript_PK PRIMARY KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateCourseTranscript ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidateCourseTranscript ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidateCourseTranscript ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits --
CREATE TABLE tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits (
    AdditionalCreditTypeDescriptorId INT NOT NULL,
    CourseAttemptResultDescriptorId INT NOT NULL,
    CourseCode VARCHAR(60) NOT NULL,
    CourseEducationOrganizationId INT NOT NULL,
    EducationOrganizationId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TermDescriptorId INT NOT NULL,
    Credits DECIMAL(9, 3) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateCourseTranscriptEarnedAdditionalCredits_PK PRIMARY KEY (AdditionalCreditTypeDescriptorId, CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateDegreeSpecialization --
CREATE TABLE tpdm.TeacherCandidateDegreeSpecialization (
    BeginDate DATE NOT NULL,
    MajorSpecialization VARCHAR(75) NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    MinorSpecialization VARCHAR(75) NULL,
    EndDate DATE NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateDegreeSpecialization_PK PRIMARY KEY (BeginDate, MajorSpecialization, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateDegreeSpecialization ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateDisability --
CREATE TABLE tpdm.TeacherCandidateDisability (
    DisabilityDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    DisabilityDiagnosis VARCHAR(80) NULL,
    OrderOfDisability INT NULL,
    DisabilityDeterminationSourceTypeDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateDisability_PK PRIMARY KEY (DisabilityDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateDisability ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateDisabilityDesignation --
CREATE TABLE tpdm.TeacherCandidateDisabilityDesignation (
    DisabilityDescriptorId INT NOT NULL,
    DisabilityDesignationDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateDisabilityDesignation_PK PRIMARY KEY (DisabilityDescriptorId, DisabilityDesignationDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateDisabilityDesignation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateElectronicMail --
CREATE TABLE tpdm.TeacherCandidateElectronicMail (
    ElectronicMailAddress VARCHAR(128) NOT NULL,
    ElectronicMailTypeDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    PrimaryEmailAddressIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateElectronicMail_PK PRIMARY KEY (ElectronicMailAddress, ElectronicMailTypeDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateElectronicMail ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateIdentificationCode --
CREATE TABLE tpdm.TeacherCandidateIdentificationCode (
    AssigningOrganizationIdentificationCode VARCHAR(60) NOT NULL,
    StudentIdentificationSystemDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    IdentificationCode VARCHAR(60) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateIdentificationCode_PK PRIMARY KEY (AssigningOrganizationIdentificationCode, StudentIdentificationSystemDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateIdentificationCode ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateIdentificationDocument --
CREATE TABLE tpdm.TeacherCandidateIdentificationDocument (
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateIdentificationDocument_PK PRIMARY KEY (IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateIndicator --
CREATE TABLE tpdm.TeacherCandidateIndicator (
    IndicatorName VARCHAR(200) NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    IndicatorGroup VARCHAR(200) NULL,
    Indicator VARCHAR(35) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    DesignatedBy VARCHAR(60) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateIndicator_PK PRIMARY KEY (IndicatorName, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateIndicator ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateInternationalAddress --
CREATE TABLE tpdm.TeacherCandidateInternationalAddress (
    AddressTypeDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
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
    CONSTRAINT TeacherCandidateInternationalAddress_PK PRIMARY KEY (AddressTypeDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateInternationalAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateLanguage --
CREATE TABLE tpdm.TeacherCandidateLanguage (
    LanguageDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateLanguage_PK PRIMARY KEY (LanguageDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateLanguage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateLanguageUse --
CREATE TABLE tpdm.TeacherCandidateLanguageUse (
    LanguageDescriptorId INT NOT NULL,
    LanguageUseDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateLanguageUse_PK PRIMARY KEY (LanguageDescriptorId, LanguageUseDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateLanguageUse ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateOtherName --
CREATE TABLE tpdm.TeacherCandidateOtherName (
    OtherNameTypeDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    PersonalTitlePrefix VARCHAR(30) NULL,
    FirstName VARCHAR(75) NOT NULL,
    MiddleName VARCHAR(75) NULL,
    LastSurname VARCHAR(75) NOT NULL,
    GenerationCodeSuffix VARCHAR(10) NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateOtherName_PK PRIMARY KEY (OtherNameTypeDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateOtherName ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidatePersonalIdentificationDocument --
CREATE TABLE tpdm.TeacherCandidatePersonalIdentificationDocument (
    IdentificationDocumentUseDescriptorId INT NOT NULL,
    PersonalInformationVerificationDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    DocumentTitle VARCHAR(60) NULL,
    DocumentExpirationDate DATE NULL,
    IssuerDocumentIdentificationCode VARCHAR(60) NULL,
    IssuerName VARCHAR(150) NULL,
    IssuerCountryDescriptorId INT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidatePersonalIdentificationDocument_PK PRIMARY KEY (IdentificationDocumentUseDescriptorId, PersonalInformationVerificationDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidatePersonalIdentificationDocument ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateRace --
CREATE TABLE tpdm.TeacherCandidateRace (
    RaceDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateRace_PK PRIMARY KEY (RaceDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateRace ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateStaffAssociation --
CREATE TABLE tpdm.TeacherCandidateStaffAssociation (
    StaffUSI INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    BeginDate DATE NOT NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidateStaffAssociation_PK PRIMARY KEY (StaffUSI, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateStaffAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidateStaffAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidateStaffAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateStudentGrowthMeasure --
CREATE TABLE tpdm.TeacherCandidateStudentGrowthMeasure (
    FactAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    StudentGrowthMeasureDate DATE NULL,
    ResultDatatypeTypeDescriptorId INT NULL,
    StudentGrowthTypeDescriptorId INT NULL,
    StudentGrowthTargetScore INT NULL,
    StudentGrowthActualScore INT NOT NULL,
    StudentGrowthMet BOOLEAN NOT NULL,
    StudentGrowthNCount INT NULL,
    StandardError DECIMAL(5, 4) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidateStudentGrowthMeasure_PK PRIMARY KEY (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasure ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasure ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasure ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject --
CREATE TABLE tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject (
    AcademicSubjectDescriptorId INT NOT NULL,
    FactAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateStudentGrowthMeasureAcademicSubject_PK PRIMARY KEY (AcademicSubjectDescriptorId, FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation --
CREATE TABLE tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation (
    CourseCode VARCHAR(60) NOT NULL,
    EducationOrganizationId INT NOT NULL,
    FactAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidateStudentGrowthMeasureCourseAssociation_PK PRIMARY KEY (CourseCode, EducationOrganizationId, FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 --
CREATE TABLE tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 (
    EducationOrganizationId INT NOT NULL,
    FactAsOfDate DATE NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidateStudentGrowthMeasureEducationOrgan_22b9a4_PK PRIMARY KEY (EducationOrganizationId, FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel --
CREATE TABLE tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel (
    FactAsOfDate DATE NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateStudentGrowthMeasureGradeLevel_PK PRIMARY KEY (FactAsOfDate, GradeLevelDescriptorId, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation --
CREATE TABLE tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation (
    FactAsOfDate DATE NOT NULL,
    LocalCourseCode VARCHAR(60) NOT NULL,
    SchoolId INT NOT NULL,
    SchoolYear SMALLINT NOT NULL,
    SectionIdentifier VARCHAR(255) NOT NULL,
    SessionName VARCHAR(60) NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
    BeginDate DATE NULL,
    EndDate DATE NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidateStudentGrowthMeasureSectionAssociation_PK PRIMARY KEY (FactAsOfDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation --
CREATE TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation (
    BeginDate DATE NOT NULL,
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    EndDate DATE NULL,
    ReasonExitedDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherCandidateTeacherPreparationProviderProgramAssociation_PK PRIMARY KEY (BeginDate, EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, TeacherCandidateIdentifier)
); 
ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateTelephone --
CREATE TABLE tpdm.TeacherCandidateTelephone (
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TelephoneNumber VARCHAR(24) NOT NULL,
    TelephoneNumberTypeDescriptorId INT NOT NULL,
    OrderOfPriority INT NULL,
    TextMessageCapabilityIndicator BOOLEAN NULL,
    DoNotPublishIndicator BOOLEAN NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateTelephone_PK PRIMARY KEY (TeacherCandidateIdentifier, TelephoneNumber, TelephoneNumberTypeDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateTelephone ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateTPPProgramDegree --
CREATE TABLE tpdm.TeacherCandidateTPPProgramDegree (
    AcademicSubjectDescriptorId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    TPPDegreeTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateTPPProgramDegree_PK PRIMARY KEY (AcademicSubjectDescriptorId, GradeLevelDescriptorId, TeacherCandidateIdentifier, TPPDegreeTypeDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateTPPProgramDegree ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherCandidateVisa --
CREATE TABLE tpdm.TeacherCandidateVisa (
    TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
    VisaDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherCandidateVisa_PK PRIMARY KEY (TeacherCandidateIdentifier, VisaDescriptorId)
); 
ALTER TABLE tpdm.TeacherCandidateVisa ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherPreparationProgramTypeDescriptor --
CREATE TABLE tpdm.TeacherPreparationProgramTypeDescriptor (
    TeacherPreparationProgramTypeDescriptorId INT NOT NULL,
    CONSTRAINT TeacherPreparationProgramTypeDescriptor_PK PRIMARY KEY (TeacherPreparationProgramTypeDescriptorId)
); 

-- Table tpdm.TeacherPreparationProviderProgram --
CREATE TABLE tpdm.TeacherPreparationProviderProgram (
    EducationOrganizationId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    ProgramId VARCHAR(20) NULL,
    MajorSpecialization VARCHAR(75) NULL,
    MinorSpecialization VARCHAR(75) NULL,
    TeacherPreparationProgramTypeDescriptorId INT NULL,
    TPPProgramPathwayDescriptorId INT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT TeacherPreparationProviderProgram_PK PRIMARY KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
); 
ALTER TABLE tpdm.TeacherPreparationProviderProgram ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE tpdm.TeacherPreparationProviderProgram ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE tpdm.TeacherPreparationProviderProgram ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table tpdm.TeacherPreparationProviderProgramGradeLevel --
CREATE TABLE tpdm.TeacherPreparationProviderProgramGradeLevel (
    EducationOrganizationId INT NOT NULL,
    GradeLevelDescriptorId INT NOT NULL,
    ProgramName VARCHAR(255) NOT NULL,
    ProgramTypeDescriptorId INT NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT TeacherPreparationProviderProgramGradeLevel_PK PRIMARY KEY (EducationOrganizationId, GradeLevelDescriptorId, ProgramName, ProgramTypeDescriptorId)
); 
ALTER TABLE tpdm.TeacherPreparationProviderProgramGradeLevel ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table tpdm.TPPDegreeTypeDescriptor --
CREATE TABLE tpdm.TPPDegreeTypeDescriptor (
    TPPDegreeTypeDescriptorId INT NOT NULL,
    CONSTRAINT TPPDegreeTypeDescriptor_PK PRIMARY KEY (TPPDegreeTypeDescriptorId)
); 

-- Table tpdm.TPPProgramPathwayDescriptor --
CREATE TABLE tpdm.TPPProgramPathwayDescriptor (
    TPPProgramPathwayDescriptorId INT NOT NULL,
    CONSTRAINT TPPProgramPathwayDescriptor_PK PRIMARY KEY (TPPProgramPathwayDescriptorId)
); 

-- Table tpdm.ValueTypeDescriptor --
CREATE TABLE tpdm.ValueTypeDescriptor (
    ValueTypeDescriptorId INT NOT NULL,
    CONSTRAINT ValueTypeDescriptor_PK PRIMARY KEY (ValueTypeDescriptorId)
); 

-- Table tpdm.WithdrawReasonDescriptor --
CREATE TABLE tpdm.WithdrawReasonDescriptor (
    WithdrawReasonDescriptorId INT NOT NULL,
    CONSTRAINT WithdrawReasonDescriptor_PK PRIMARY KEY (WithdrawReasonDescriptorId)
); 

