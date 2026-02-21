-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM information_schema.schemata WHERE schema_name = 'tracked_changes_homograph') THEN
CREATE SCHEMA tracked_changes_homograph;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_homograph' AND table_name = 'name') THEN
CREATE TABLE tracked_changes_homograph.name
(
       oldfirstname VARCHAR(75) NOT NULL,
       oldlastsurname VARCHAR(75) NOT NULL,
       newfirstname VARCHAR(75) NULL,
       newlastsurname VARCHAR(75) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT name_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_homograph' AND table_name = 'parent') THEN
CREATE TABLE tracked_changes_homograph.parent
(
       oldparentfirstname VARCHAR(75) NOT NULL,
       oldparentlastsurname VARCHAR(75) NOT NULL,
       newparentfirstname VARCHAR(75) NULL,
       newparentlastsurname VARCHAR(75) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT parent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_homograph' AND table_name = 'school') THEN
CREATE TABLE tracked_changes_homograph.school
(
       oldschoolname VARCHAR(100) NOT NULL,
       newschoolname VARCHAR(100) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT school_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_homograph' AND table_name = 'schoolyeartype') THEN
CREATE TABLE tracked_changes_homograph.schoolyeartype
(
       oldschoolyear VARCHAR(20) NOT NULL,
       newschoolyear VARCHAR(20) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT schoolyeartype_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_homograph' AND table_name = 'staff') THEN
CREATE TABLE tracked_changes_homograph.staff
(
       oldstafffirstname VARCHAR(75) NOT NULL,
       oldstafflastsurname VARCHAR(75) NOT NULL,
       newstafffirstname VARCHAR(75) NULL,
       newstafflastsurname VARCHAR(75) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staff_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_homograph' AND table_name = 'student') THEN
CREATE TABLE tracked_changes_homograph.student
(
       oldstudentfirstname VARCHAR(75) NOT NULL,
       oldstudentlastsurname VARCHAR(75) NOT NULL,
       newstudentfirstname VARCHAR(75) NULL,
       newstudentlastsurname VARCHAR(75) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT student_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_homograph' AND table_name = 'studentschoolassociation') THEN
CREATE TABLE tracked_changes_homograph.studentschoolassociation
(
       oldschoolname VARCHAR(100) NOT NULL,
       oldstudentfirstname VARCHAR(75) NOT NULL,
       oldstudentlastsurname VARCHAR(75) NOT NULL,
       newschoolname VARCHAR(100) NULL,
       newstudentfirstname VARCHAR(75) NULL,
       newstudentlastsurname VARCHAR(75) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentschoolassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

END
$$;
