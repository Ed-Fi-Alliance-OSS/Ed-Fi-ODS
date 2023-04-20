-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table homograph.Name --
CREATE TABLE homograph.Name (
    FirstName VARCHAR(75) NOT NULL,
    LastSurname VARCHAR(75) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Name_PK PRIMARY KEY (FirstName, LastSurname)
); 
ALTER TABLE homograph.Name ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE homograph.Name ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE homograph.Name ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table homograph.Parent --
CREATE TABLE homograph.Parent (
    ParentFirstName VARCHAR(75) NOT NULL,
    ParentLastSurname VARCHAR(75) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Parent_PK PRIMARY KEY (ParentFirstName, ParentLastSurname)
); 
ALTER TABLE homograph.Parent ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE homograph.Parent ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE homograph.Parent ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table homograph.ParentAddress --
CREATE TABLE homograph.ParentAddress (
    City VARCHAR(30) NOT NULL,
    ParentFirstName VARCHAR(75) NOT NULL,
    ParentLastSurname VARCHAR(75) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentAddress_PK PRIMARY KEY (City, ParentFirstName, ParentLastSurname)
); 
ALTER TABLE homograph.ParentAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table homograph.ParentStudentSchoolAssociation --
CREATE TABLE homograph.ParentStudentSchoolAssociation (
    ParentFirstName VARCHAR(75) NOT NULL,
    ParentLastSurname VARCHAR(75) NOT NULL,
    SchoolName VARCHAR(100) NOT NULL,
    StudentFirstName VARCHAR(75) NOT NULL,
    StudentLastSurname VARCHAR(75) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT ParentStudentSchoolAssociation_PK PRIMARY KEY (ParentFirstName, ParentLastSurname, SchoolName, StudentFirstName, StudentLastSurname)
); 
ALTER TABLE homograph.ParentStudentSchoolAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table homograph.School --
CREATE TABLE homograph.School (
    SchoolName VARCHAR(100) NOT NULL,
    SchoolYear VARCHAR(20) NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT School_PK PRIMARY KEY (SchoolName)
); 
ALTER TABLE homograph.School ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE homograph.School ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE homograph.School ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table homograph.SchoolAddress --
CREATE TABLE homograph.SchoolAddress (
    SchoolName VARCHAR(100) NOT NULL,
    City VARCHAR(30) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT SchoolAddress_PK PRIMARY KEY (SchoolName)
); 
ALTER TABLE homograph.SchoolAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table homograph.SchoolYearType --
CREATE TABLE homograph.SchoolYearType (
    SchoolYear VARCHAR(20) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT SchoolYearType_PK PRIMARY KEY (SchoolYear)
); 
ALTER TABLE homograph.SchoolYearType ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE homograph.SchoolYearType ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE homograph.SchoolYearType ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table homograph.Staff --
CREATE TABLE homograph.Staff (
    StaffFirstName VARCHAR(75) NOT NULL,
    StaffLastSurname VARCHAR(75) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Staff_PK PRIMARY KEY (StaffFirstName, StaffLastSurname)
); 
ALTER TABLE homograph.Staff ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE homograph.Staff ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE homograph.Staff ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table homograph.StaffAddress --
CREATE TABLE homograph.StaffAddress (
    City VARCHAR(30) NOT NULL,
    StaffFirstName VARCHAR(75) NOT NULL,
    StaffLastSurname VARCHAR(75) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffAddress_PK PRIMARY KEY (City, StaffFirstName, StaffLastSurname)
); 
ALTER TABLE homograph.StaffAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table homograph.StaffStudentSchoolAssociation --
CREATE TABLE homograph.StaffStudentSchoolAssociation (
    SchoolName VARCHAR(100) NOT NULL,
    StaffFirstName VARCHAR(75) NOT NULL,
    StaffLastSurname VARCHAR(75) NOT NULL,
    StudentFirstName VARCHAR(75) NOT NULL,
    StudentLastSurname VARCHAR(75) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StaffStudentSchoolAssociation_PK PRIMARY KEY (SchoolName, StaffFirstName, StaffLastSurname, StudentFirstName, StudentLastSurname)
); 
ALTER TABLE homograph.StaffStudentSchoolAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table homograph.Student --
CREATE TABLE homograph.Student (
    StudentFirstName VARCHAR(75) NOT NULL,
    StudentLastSurname VARCHAR(75) NOT NULL,
    SchoolYear VARCHAR(20) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Student_PK PRIMARY KEY (StudentFirstName, StudentLastSurname)
); 
ALTER TABLE homograph.Student ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE homograph.Student ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE homograph.Student ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

-- Table homograph.StudentAddress --
CREATE TABLE homograph.StudentAddress (
    City VARCHAR(30) NOT NULL,
    StudentFirstName VARCHAR(75) NOT NULL,
    StudentLastSurname VARCHAR(75) NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    CONSTRAINT StudentAddress_PK PRIMARY KEY (City, StudentFirstName, StudentLastSurname)
); 
ALTER TABLE homograph.StudentAddress ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

-- Table homograph.StudentSchoolAssociation --
CREATE TABLE homograph.StudentSchoolAssociation (
    SchoolName VARCHAR(100) NOT NULL,
    StudentFirstName VARCHAR(75) NOT NULL,
    StudentLastSurname VARCHAR(75) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentSchoolAssociation_PK PRIMARY KEY (SchoolName, StudentFirstName, StudentLastSurname)
); 
ALTER TABLE homograph.StudentSchoolAssociation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE homograph.StudentSchoolAssociation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE homograph.StudentSchoolAssociation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

