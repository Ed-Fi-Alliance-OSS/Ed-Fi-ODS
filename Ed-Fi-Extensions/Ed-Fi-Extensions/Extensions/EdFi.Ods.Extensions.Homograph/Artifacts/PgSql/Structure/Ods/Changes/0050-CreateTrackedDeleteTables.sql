-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE tracked_deletes_homograph.Name
(
       FirstName VARCHAR(75) NOT NULL,
       LastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Name_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.Parent
(
       ParentFirstName VARCHAR(75) NOT NULL,
       ParentLastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Parent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.School
(
       SchoolName VARCHAR(100) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT School_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.SchoolYearType
(
       SchoolYear VARCHAR(20) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SchoolYearType_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.Staff
(
       StaffFirstName VARCHAR(75) NOT NULL,
       StaffLastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Staff_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.Student
(
       StudentFirstName VARCHAR(75) NOT NULL,
       StudentLastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Student_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.StudentSchoolAssociation
(
       SchoolName VARCHAR(100) NOT NULL,
       StudentFirstName VARCHAR(75) NOT NULL,
       StudentLastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentSchoolAssociation_PK PRIMARY KEY (ChangeVersion)
);

