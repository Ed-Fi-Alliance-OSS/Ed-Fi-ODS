-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM information_schema.schemata WHERE schema_name = 'tracked_changes_edfi') THEN
CREATE SCHEMA tracked_changes_edfi;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'academicweek') THEN
CREATE TABLE tracked_changes_edfi.academicweek
(
       oldschoolid BIGINT NOT NULL,
       oldweekidentifier VARCHAR(80) NOT NULL,
       newschoolid BIGINT NULL,
       newweekidentifier VARCHAR(80) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT academicweek_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'accountabilityrating') THEN
CREATE TABLE tracked_changes_edfi.accountabilityrating
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldratingtitle VARCHAR(60) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newratingtitle VARCHAR(60) NULL,
       newschoolyear SMALLINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT accountabilityrating_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'applicantprofile') THEN
CREATE TABLE tracked_changes_edfi.applicantprofile
(
       oldapplicantprofileidentifier VARCHAR(32) NOT NULL,
       newapplicantprofileidentifier VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT applicantprofile_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'application') THEN
CREATE TABLE tracked_changes_edfi.application
(
       oldapplicantprofileidentifier VARCHAR(32) NOT NULL,
       oldapplicationidentifier VARCHAR(20) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       newapplicantprofileidentifier VARCHAR(32) NULL,
       newapplicationidentifier VARCHAR(20) NULL,
       neweducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT application_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'applicationevent') THEN
CREATE TABLE tracked_changes_edfi.applicationevent
(
       oldapplicantprofileidentifier VARCHAR(32) NOT NULL,
       oldapplicationeventtypedescriptorid INT NOT NULL,
       oldapplicationeventtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldapplicationeventtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldapplicationidentifier VARCHAR(20) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldeventdate DATE NOT NULL,
       oldsequencenumber INT NOT NULL,
       newapplicantprofileidentifier VARCHAR(32) NULL,
       newapplicationeventtypedescriptorid INT NULL,
       newapplicationeventtypedescriptornamespace VARCHAR(255) NULL,
       newapplicationeventtypedescriptorcodevalue VARCHAR(50) NULL,
       newapplicationidentifier VARCHAR(20) NULL,
       neweducationorganizationid BIGINT NULL,
       neweventdate DATE NULL,
       newsequencenumber INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT applicationevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessment') THEN
CREATE TABLE tracked_changes_edfi.assessment
(
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessment_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessmentadministration') THEN
CREATE TABLE tracked_changes_edfi.assessmentadministration
(
       oldadministrationidentifier VARCHAR(255) NOT NULL,
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldassigningeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newadministrationidentifier VARCHAR(255) NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newassigningeducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessmentadministration_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessmentadministrationparticipation') THEN
CREATE TABLE tracked_changes_edfi.assessmentadministrationparticipation
(
       oldadministrationidentifier VARCHAR(255) NOT NULL,
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldassigningeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldparticipatingeducationorganizationid BIGINT NOT NULL,
       newadministrationidentifier VARCHAR(255) NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newassigningeducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       newparticipatingeducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessmentadministrationparticipation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessmentbatterypart') THEN
CREATE TABLE tracked_changes_edfi.assessmentbatterypart
(
       oldassessmentbatterypartname VARCHAR(65) NOT NULL,
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newassessmentbatterypartname VARCHAR(65) NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessmentbatterypart_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessmentitem') THEN
CREATE TABLE tracked_changes_edfi.assessmentitem
(
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldidentificationcode VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newidentificationcode VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessmentitem_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessmentscorerangelearningstandard') THEN
CREATE TABLE tracked_changes_edfi.assessmentscorerangelearningstandard
(
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldscorerangeid VARCHAR(120) NOT NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       newscorerangeid VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessmentscorerangelearningstandard_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'balancesheetdimension') THEN
CREATE TABLE tracked_changes_edfi.balancesheetdimension
(
       oldcode VARCHAR(16) NOT NULL,
       oldfiscalyear INT NOT NULL,
       newcode VARCHAR(16) NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT balancesheetdimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'bellschedule') THEN
CREATE TABLE tracked_changes_edfi.bellschedule
(
       oldbellschedulename VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       newbellschedulename VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT bellschedule_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'calendar') THEN
CREATE TABLE tracked_changes_edfi.calendar
(
       oldcalendarcode VARCHAR(120) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       newcalendarcode VARCHAR(120) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT calendar_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'calendardate') THEN
CREATE TABLE tracked_changes_edfi.calendardate
(
       oldcalendarcode VARCHAR(120) NOT NULL,
       olddate DATE NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       newcalendarcode VARCHAR(120) NULL,
       newdate DATE NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT calendardate_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'candidate') THEN
CREATE TABLE tracked_changes_edfi.candidate
(
       oldcandidateidentifier VARCHAR(32) NOT NULL,
       newcandidateidentifier VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT candidate_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'candidateeducatorpreparationprogramassociation') THEN
CREATE TABLE tracked_changes_edfi.candidateeducatorpreparationprogramassociation
(
       oldbegindate DATE NOT NULL,
       oldcandidateidentifier VARCHAR(32) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldprogramname VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       newbegindate DATE NULL,
       newcandidateidentifier VARCHAR(32) NULL,
       neweducationorganizationid BIGINT NULL,
       newprogramname VARCHAR(255) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT candidateeducatorpreparationprogramassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'candidateidentity') THEN
CREATE TABLE tracked_changes_edfi.candidateidentity
(
       oldcandidateidentificationsystemdescriptorid INT NOT NULL,
       oldcandidateidentificationsystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldcandidateidentificationsystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldcandidateidentifier VARCHAR(32) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       newcandidateidentificationsystemdescriptorid INT NULL,
       newcandidateidentificationsystemdescriptornamespace VARCHAR(255) NULL,
       newcandidateidentificationsystemdescriptorcodevalue VARCHAR(50) NULL,
       newcandidateidentifier VARCHAR(32) NULL,
       neweducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT candidateidentity_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'candidaterelationshiptostaffassociation') THEN
CREATE TABLE tracked_changes_edfi.candidaterelationshiptostaffassociation
(
       oldcandidateidentifier VARCHAR(32) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newcandidateidentifier VARCHAR(32) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT candidaterelationshiptostaffassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'certification') THEN
CREATE TABLE tracked_changes_edfi.certification
(
       oldcertificationidentifier VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newcertificationidentifier VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT certification_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'certificationexam') THEN
CREATE TABLE tracked_changes_edfi.certificationexam
(
       oldcertificationexamidentifier VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newcertificationexamidentifier VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT certificationexam_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'certificationexamresult') THEN
CREATE TABLE tracked_changes_edfi.certificationexamresult
(
       oldcertificationexamdate DATE NOT NULL,
       oldcertificationexamidentifier VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       newcertificationexamdate DATE NULL,
       newcertificationexamidentifier VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       newpersonid VARCHAR(32) NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT certificationexamresult_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'chartofaccount') THEN
CREATE TABLE tracked_changes_edfi.chartofaccount
(
       oldaccountidentifier VARCHAR(50) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       neweducationorganizationid BIGINT NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT chartofaccount_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'classperiod') THEN
CREATE TABLE tracked_changes_edfi.classperiod
(
       oldclassperiodname VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       newclassperiodname VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT classperiod_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'cohort') THEN
CREATE TABLE tracked_changes_edfi.cohort
(
       oldcohortidentifier VARCHAR(36) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       newcohortidentifier VARCHAR(36) NULL,
       neweducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT cohort_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'communityproviderlicense') THEN
CREATE TABLE tracked_changes_edfi.communityproviderlicense
(
       oldcommunityproviderid BIGINT NOT NULL,
       oldlicenseidentifier VARCHAR(36) NOT NULL,
       oldlicensingorganization VARCHAR(75) NOT NULL,
       newcommunityproviderid BIGINT NULL,
       newlicenseidentifier VARCHAR(36) NULL,
       newlicensingorganization VARCHAR(75) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT communityproviderlicense_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'competencyobjective') THEN
CREATE TABLE tracked_changes_edfi.competencyobjective
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldobjective VARCHAR(60) NOT NULL,
       oldobjectivegradeleveldescriptorid INT NOT NULL,
       oldobjectivegradeleveldescriptornamespace VARCHAR(255) NOT NULL,
       oldobjectivegradeleveldescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newobjective VARCHAR(60) NULL,
       newobjectivegradeleveldescriptorid INT NULL,
       newobjectivegradeleveldescriptornamespace VARCHAR(255) NULL,
       newobjectivegradeleveldescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT competencyobjective_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'contact') THEN
CREATE TABLE tracked_changes_edfi.contact
(
       oldcontactusi INT NOT NULL,
       oldcontactuniqueid VARCHAR(32) NOT NULL,
       newcontactusi INT NULL,
       newcontactuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT contact_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'contactidentity') THEN
CREATE TABLE tracked_changes_edfi.contactidentity
(
       oldcontactidentificationsystemdescriptorid INT NOT NULL,
       oldcontactidentificationsystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldcontactidentificationsystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldcontactusi INT NOT NULL,
       oldcontactuniqueid VARCHAR(32) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       newcontactidentificationsystemdescriptorid INT NULL,
       newcontactidentificationsystemdescriptornamespace VARCHAR(255) NULL,
       newcontactidentificationsystemdescriptorcodevalue VARCHAR(50) NULL,
       newcontactusi INT NULL,
       newcontactuniqueid VARCHAR(32) NULL,
       neweducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT contactidentity_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'course') THEN
CREATE TABLE tracked_changes_edfi.course
(
       oldcoursecode VARCHAR(120) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       newcoursecode VARCHAR(120) NULL,
       neweducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT course_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'courseoffering') THEN
CREATE TABLE tracked_changes_edfi.courseoffering
(
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsessionname VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT courseoffering_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'coursetranscript') THEN
CREATE TABLE tracked_changes_edfi.coursetranscript
(
       oldcourseattemptresultdescriptorid INT NOT NULL,
       oldcourseattemptresultdescriptornamespace VARCHAR(255) NOT NULL,
       oldcourseattemptresultdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldcoursecode VARCHAR(120) NOT NULL,
       oldcourseeducationorganizationid BIGINT NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       newcourseattemptresultdescriptorid INT NULL,
       newcourseattemptresultdescriptornamespace VARCHAR(255) NULL,
       newcourseattemptresultdescriptorcodevalue VARCHAR(50) NULL,
       newcoursecode VARCHAR(120) NULL,
       newcourseeducationorganizationid BIGINT NULL,
       neweducationorganizationid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT coursetranscript_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'credential') THEN
CREATE TABLE tracked_changes_edfi.credential
(
       oldcredentialidentifier VARCHAR(120) NOT NULL,
       oldstateofissuestateabbreviationdescriptorid INT NOT NULL,
       oldstateofissuestateabbreviationdescriptornamespace VARCHAR(255) NOT NULL,
       oldstateofissuestateabbreviationdescriptorcodevalue VARCHAR(50) NOT NULL,
       newcredentialidentifier VARCHAR(120) NULL,
       newstateofissuestateabbreviationdescriptorid INT NULL,
       newstateofissuestateabbreviationdescriptornamespace VARCHAR(255) NULL,
       newstateofissuestateabbreviationdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT credential_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'credentialevent') THEN
CREATE TABLE tracked_changes_edfi.credentialevent
(
       oldcredentialeventdate DATE NOT NULL,
       oldcredentialeventtypedescriptorid INT NOT NULL,
       oldcredentialeventtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldcredentialeventtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldcredentialidentifier VARCHAR(120) NOT NULL,
       oldstateofissuestateabbreviationdescriptorid INT NOT NULL,
       oldstateofissuestateabbreviationdescriptornamespace VARCHAR(255) NOT NULL,
       oldstateofissuestateabbreviationdescriptorcodevalue VARCHAR(50) NOT NULL,
       newcredentialeventdate DATE NULL,
       newcredentialeventtypedescriptorid INT NULL,
       newcredentialeventtypedescriptornamespace VARCHAR(255) NULL,
       newcredentialeventtypedescriptorcodevalue VARCHAR(50) NULL,
       newcredentialidentifier VARCHAR(120) NULL,
       newstateofissuestateabbreviationdescriptorid INT NULL,
       newstateofissuestateabbreviationdescriptornamespace VARCHAR(255) NULL,
       newstateofissuestateabbreviationdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT credentialevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'crisisevent') THEN
CREATE TABLE tracked_changes_edfi.crisisevent
(
       oldcrisiseventname VARCHAR(100) NOT NULL,
       newcrisiseventname VARCHAR(100) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT crisisevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'descriptor') THEN
CREATE TABLE tracked_changes_edfi.descriptor
(
       olddescriptorid INT NOT NULL,
       oldcodevalue VARCHAR(50) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newdescriptorid INT NULL,
       newcodevalue VARCHAR(50) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT descriptor_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'descriptormapping') THEN
CREATE TABLE tracked_changes_edfi.descriptormapping
(
       oldmappednamespace VARCHAR(255) NOT NULL,
       oldmappedvalue VARCHAR(50) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldvalue VARCHAR(50) NOT NULL,
       newmappednamespace VARCHAR(255) NULL,
       newmappedvalue VARCHAR(50) NULL,
       newnamespace VARCHAR(255) NULL,
       newvalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT descriptormapping_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'disciplineaction') THEN
CREATE TABLE tracked_changes_edfi.disciplineaction
(
       olddisciplineactionidentifier VARCHAR(36) NOT NULL,
       olddisciplinedate DATE NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       oldresponsibilityschoolid BIGINT NOT NULL,
       newdisciplineactionidentifier VARCHAR(36) NULL,
       newdisciplinedate DATE NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT disciplineaction_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'disciplineincident') THEN
CREATE TABLE tracked_changes_edfi.disciplineincident
(
       oldincidentidentifier VARCHAR(36) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT disciplineincident_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationcontent') THEN
CREATE TABLE tracked_changes_edfi.educationcontent
(
       oldcontentidentifier VARCHAR(225) NOT NULL,
       newcontentidentifier VARCHAR(225) NULL,
       id uuid NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationcontent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganization') THEN
CREATE TABLE tracked_changes_edfi.educationorganization
(
       oldeducationorganizationid BIGINT NOT NULL,
       neweducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganization_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganizationidentity') THEN
CREATE TABLE tracked_changes_edfi.educationorganizationidentity
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldeducationorganizationidentificationsystemdescriptorid INT NOT NULL,
       oldeducationorganizationidentificationsystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldeducationorganizationidentificationsystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       neweducationorganizationidentificationsystemdescriptorid INT NULL,
       neweducationorganizationidentificationsystemdescriptornamespace VARCHAR(255) NULL,
       neweducationorganizationidentificationsystemdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganizationidentity_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganizationinterventionprescriptionassociation') THEN
CREATE TABLE tracked_changes_edfi.educationorganizationinterventionprescriptionassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldinterventionprescriptioneducationorganizationid BIGINT NOT NULL,
       oldinterventionprescriptionidentificationcode VARCHAR(120) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newinterventionprescriptioneducationorganizationid BIGINT NULL,
       newinterventionprescriptionidentificationcode VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganizationinterventionprescriptionassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganizationnetworkassociation') THEN
CREATE TABLE tracked_changes_edfi.educationorganizationnetworkassociation
(
       oldeducationorganizationnetworkid BIGINT NOT NULL,
       oldmembereducationorganizationid BIGINT NOT NULL,
       neweducationorganizationnetworkid BIGINT NULL,
       newmembereducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganizationnetworkassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganizationpeerassociation') THEN
CREATE TABLE tracked_changes_edfi.educationorganizationpeerassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldpeereducationorganizationid BIGINT NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newpeereducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganizationpeerassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educatorpreparationprogram') THEN
CREATE TABLE tracked_changes_edfi.educatorpreparationprogram
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldprogramname VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newprogramname VARCHAR(255) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educatorpreparationprogram_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'evaluation') THEN
CREATE TABLE tracked_changes_edfi.evaluation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newschoolyear SMALLINT NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT evaluation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'evaluationelement') THEN
CREATE TABLE tracked_changes_edfi.evaluationelement
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationelementtitle VARCHAR(255) NOT NULL,
       oldevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationelementtitle VARCHAR(255) NULL,
       newevaluationobjectivetitle VARCHAR(50) NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newschoolyear SMALLINT NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT evaluationelement_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'evaluationelementrating') THEN
CREATE TABLE tracked_changes_edfi.evaluationelementrating
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationdate TIMESTAMP NOT NULL,
       oldevaluationelementtitle VARCHAR(255) NOT NULL,
       oldevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationdate TIMESTAMP NULL,
       newevaluationelementtitle VARCHAR(255) NULL,
       newevaluationobjectivetitle VARCHAR(50) NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newpersonid VARCHAR(32) NULL,
       newschoolyear SMALLINT NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT evaluationelementrating_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'evaluationobjective') THEN
CREATE TABLE tracked_changes_edfi.evaluationobjective
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationobjectivetitle VARCHAR(50) NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newschoolyear SMALLINT NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT evaluationobjective_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'evaluationobjectiverating') THEN
CREATE TABLE tracked_changes_edfi.evaluationobjectiverating
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationdate TIMESTAMP NOT NULL,
       oldevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationdate TIMESTAMP NULL,
       newevaluationobjectivetitle VARCHAR(50) NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newpersonid VARCHAR(32) NULL,
       newschoolyear SMALLINT NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT evaluationobjectiverating_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'evaluationrating') THEN
CREATE TABLE tracked_changes_edfi.evaluationrating
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationdate TIMESTAMP NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationdate TIMESTAMP NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newpersonid VARCHAR(32) NULL,
       newschoolyear SMALLINT NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT evaluationrating_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'evaluationrubricdimension') THEN
CREATE TABLE tracked_changes_edfi.evaluationrubricdimension
(
       oldevaluationrubricrating INT NOT NULL,
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramevaluationelementtitle VARCHAR(50) NOT NULL,
       oldprogramevaluationperioddescriptorid INT NOT NULL,
       oldprogramevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramevaluationtitle VARCHAR(50) NOT NULL,
       oldprogramevaluationtypedescriptorid INT NOT NULL,
       oldprogramevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       newevaluationrubricrating INT NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramevaluationelementtitle VARCHAR(50) NULL,
       newprogramevaluationperioddescriptorid INT NULL,
       newprogramevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newprogramevaluationtitle VARCHAR(50) NULL,
       newprogramevaluationtypedescriptorid INT NULL,
       newprogramevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT evaluationrubricdimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'feederschoolassociation') THEN
CREATE TABLE tracked_changes_edfi.feederschoolassociation
(
       oldbegindate DATE NOT NULL,
       oldfeederschoolid BIGINT NOT NULL,
       oldschoolid BIGINT NOT NULL,
       newbegindate DATE NULL,
       newfeederschoolid BIGINT NULL,
       newschoolid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT feederschoolassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'fieldworkexperience') THEN
CREATE TABLE tracked_changes_edfi.fieldworkexperience
(
       oldbegindate DATE NOT NULL,
       oldfieldworkidentifier VARCHAR(64) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newfieldworkidentifier VARCHAR(64) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT fieldworkexperience_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'fieldworkexperiencesectionassociation') THEN
CREATE TABLE tracked_changes_edfi.fieldworkexperiencesectionassociation
(
       oldbegindate DATE NOT NULL,
       oldfieldworkidentifier VARCHAR(64) NOT NULL,
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newfieldworkidentifier VARCHAR(64) NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT fieldworkexperiencesectionassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'financialaid') THEN
CREATE TABLE tracked_changes_edfi.financialaid
(
       oldaidtypedescriptorid INT NOT NULL,
       oldaidtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldaidtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldbegindate DATE NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newaidtypedescriptorid INT NULL,
       newaidtypedescriptornamespace VARCHAR(255) NULL,
       newaidtypedescriptorcodevalue VARCHAR(50) NULL,
       newbegindate DATE NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT financialaid_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'functiondimension') THEN
CREATE TABLE tracked_changes_edfi.functiondimension
(
       oldcode VARCHAR(16) NOT NULL,
       oldfiscalyear INT NOT NULL,
       newcode VARCHAR(16) NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT functiondimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'funddimension') THEN
CREATE TABLE tracked_changes_edfi.funddimension
(
       oldcode VARCHAR(16) NOT NULL,
       oldfiscalyear INT NOT NULL,
       newcode VARCHAR(16) NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT funddimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'generalstudentprogramassociation') THEN
CREATE TABLE tracked_changes_edfi.generalstudentprogramassociation
(
       oldbegindate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT generalstudentprogramassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'goal') THEN
CREATE TABLE tracked_changes_edfi.goal
(
       oldassignmentdate DATE NOT NULL,
       oldgoaltitle VARCHAR(255) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       newassignmentdate DATE NULL,
       newgoaltitle VARCHAR(255) NULL,
       newpersonid VARCHAR(32) NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT goal_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'grade') THEN
CREATE TABLE tracked_changes_edfi.grade
(
       oldbegindate DATE NOT NULL,
       oldgradetypedescriptorid INT NOT NULL,
       oldgradetypedescriptornamespace VARCHAR(255) NOT NULL,
       oldgradetypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgradingperioddescriptorid INT NOT NULL,
       oldgradingperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldgradingperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgradingperiodname VARCHAR(60) NOT NULL,
       oldgradingperiodschoolyear SMALLINT NOT NULL,
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newgradetypedescriptorid INT NULL,
       newgradetypedescriptornamespace VARCHAR(255) NULL,
       newgradetypedescriptorcodevalue VARCHAR(50) NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newgradingperiodname VARCHAR(60) NULL,
       newgradingperiodschoolyear SMALLINT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT grade_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'gradebookentry') THEN
CREATE TABLE tracked_changes_edfi.gradebookentry
(
       oldgradebookentryidentifier VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newgradebookentryidentifier VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT gradebookentry_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'gradingperiod') THEN
CREATE TABLE tracked_changes_edfi.gradingperiod
(
       oldgradingperioddescriptorid INT NOT NULL,
       oldgradingperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldgradingperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgradingperiodname VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newgradingperiodname VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT gradingperiod_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'graduationplan') THEN
CREATE TABLE tracked_changes_edfi.graduationplan
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldgraduationplantypedescriptorid INT NOT NULL,
       oldgraduationplantypedescriptornamespace VARCHAR(255) NOT NULL,
       oldgraduationplantypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgraduationschoolyear SMALLINT NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newgraduationplantypedescriptorid INT NULL,
       newgraduationplantypedescriptornamespace VARCHAR(255) NULL,
       newgraduationplantypedescriptorcodevalue VARCHAR(50) NULL,
       newgraduationschoolyear SMALLINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT graduationplan_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'intervention') THEN
CREATE TABLE tracked_changes_edfi.intervention
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldinterventionidentificationcode VARCHAR(120) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newinterventionidentificationcode VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT intervention_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'interventionprescription') THEN
CREATE TABLE tracked_changes_edfi.interventionprescription
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldinterventionprescriptionidentificationcode VARCHAR(120) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newinterventionprescriptionidentificationcode VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT interventionprescription_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'interventionstudy') THEN
CREATE TABLE tracked_changes_edfi.interventionstudy
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldinterventionstudyidentificationcode VARCHAR(120) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newinterventionstudyidentificationcode VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT interventionstudy_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'learningstandard') THEN
CREATE TABLE tracked_changes_edfi.learningstandard
(
       oldlearningstandardid VARCHAR(60) NOT NULL,
       newlearningstandardid VARCHAR(60) NULL,
       id uuid NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT learningstandard_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'learningstandardequivalenceassociation') THEN
CREATE TABLE tracked_changes_edfi.learningstandardequivalenceassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldsourcelearningstandardid VARCHAR(60) NOT NULL,
       oldtargetlearningstandardid VARCHAR(60) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsourcelearningstandardid VARCHAR(60) NULL,
       newtargetlearningstandardid VARCHAR(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT learningstandardequivalenceassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'localaccount') THEN
CREATE TABLE tracked_changes_edfi.localaccount
(
       oldaccountidentifier VARCHAR(50) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       neweducationorganizationid BIGINT NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT localaccount_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'localactual') THEN
CREATE TABLE tracked_changes_edfi.localactual
(
       oldaccountidentifier VARCHAR(50) NOT NULL,
       oldasofdate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT localactual_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'localbudget') THEN
CREATE TABLE tracked_changes_edfi.localbudget
(
       oldaccountidentifier VARCHAR(50) NOT NULL,
       oldasofdate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT localbudget_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'localcontractedstaff') THEN
CREATE TABLE tracked_changes_edfi.localcontractedstaff
(
       oldaccountidentifier VARCHAR(50) NOT NULL,
       oldasofdate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldfiscalyear INT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newfiscalyear INT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT localcontractedstaff_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'localencumbrance') THEN
CREATE TABLE tracked_changes_edfi.localencumbrance
(
       oldaccountidentifier VARCHAR(50) NOT NULL,
       oldasofdate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT localencumbrance_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'localpayroll') THEN
CREATE TABLE tracked_changes_edfi.localpayroll
(
       oldaccountidentifier VARCHAR(50) NOT NULL,
       oldasofdate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldfiscalyear INT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newfiscalyear INT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT localpayroll_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'location') THEN
CREATE TABLE tracked_changes_edfi.location
(
       oldclassroomidentificationcode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       newclassroomidentificationcode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT location_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'objectdimension') THEN
CREATE TABLE tracked_changes_edfi.objectdimension
(
       oldcode VARCHAR(16) NOT NULL,
       oldfiscalyear INT NOT NULL,
       newcode VARCHAR(16) NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT objectdimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'objectiveassessment') THEN
CREATE TABLE tracked_changes_edfi.objectiveassessment
(
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldidentificationcode VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newidentificationcode VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT objectiveassessment_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'openstaffposition') THEN
CREATE TABLE tracked_changes_edfi.openstaffposition
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldrequisitionnumber VARCHAR(20) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newrequisitionnumber VARCHAR(20) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT openstaffposition_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'openstaffpositionevent') THEN
CREATE TABLE tracked_changes_edfi.openstaffpositionevent
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldeventdate DATE NOT NULL,
       oldopenstaffpositioneventtypedescriptorid INT NOT NULL,
       oldopenstaffpositioneventtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldopenstaffpositioneventtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldrequisitionnumber VARCHAR(20) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       neweventdate DATE NULL,
       newopenstaffpositioneventtypedescriptorid INT NULL,
       newopenstaffpositioneventtypedescriptornamespace VARCHAR(255) NULL,
       newopenstaffpositioneventtypedescriptorcodevalue VARCHAR(50) NULL,
       newrequisitionnumber VARCHAR(20) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT openstaffpositionevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'operationalunitdimension') THEN
CREATE TABLE tracked_changes_edfi.operationalunitdimension
(
       oldcode VARCHAR(16) NOT NULL,
       oldfiscalyear INT NOT NULL,
       newcode VARCHAR(16) NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT operationalunitdimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'path') THEN
CREATE TABLE tracked_changes_edfi.path
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldpathname VARCHAR(60) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newpathname VARCHAR(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT path_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'pathmilestone') THEN
CREATE TABLE tracked_changes_edfi.pathmilestone
(
       oldpathmilestonename VARCHAR(60) NOT NULL,
       oldpathmilestonetypedescriptorid INT NOT NULL,
       oldpathmilestonetypedescriptornamespace VARCHAR(255) NOT NULL,
       oldpathmilestonetypedescriptorcodevalue VARCHAR(50) NOT NULL,
       newpathmilestonename VARCHAR(60) NULL,
       newpathmilestonetypedescriptorid INT NULL,
       newpathmilestonetypedescriptornamespace VARCHAR(255) NULL,
       newpathmilestonetypedescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT pathmilestone_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'pathphase') THEN
CREATE TABLE tracked_changes_edfi.pathphase
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldpathname VARCHAR(60) NOT NULL,
       oldpathphasename VARCHAR(60) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newpathname VARCHAR(60) NULL,
       newpathphasename VARCHAR(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT pathphase_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'performanceevaluation') THEN
CREATE TABLE tracked_changes_edfi.performanceevaluation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newschoolyear SMALLINT NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT performanceevaluation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'performanceevaluationrating') THEN
CREATE TABLE tracked_changes_edfi.performanceevaluationrating
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newpersonid VARCHAR(32) NULL,
       newschoolyear SMALLINT NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT performanceevaluationrating_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'person') THEN
CREATE TABLE tracked_changes_edfi.person
(
       oldpersonid VARCHAR(32) NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       newpersonid VARCHAR(32) NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT person_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'postsecondaryevent') THEN
CREATE TABLE tracked_changes_edfi.postsecondaryevent
(
       oldeventdate DATE NOT NULL,
       oldpostsecondaryeventcategorydescriptorid INT NOT NULL,
       oldpostsecondaryeventcategorydescriptornamespace VARCHAR(255) NOT NULL,
       oldpostsecondaryeventcategorydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweventdate DATE NULL,
       newpostsecondaryeventcategorydescriptorid INT NULL,
       newpostsecondaryeventcategorydescriptornamespace VARCHAR(255) NULL,
       newpostsecondaryeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT postsecondaryevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'professionaldevelopmentevent') THEN
CREATE TABLE tracked_changes_edfi.professionaldevelopmentevent
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldprofessionaldevelopmenttitle VARCHAR(60) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newprofessionaldevelopmenttitle VARCHAR(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT professionaldevelopmentevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'professionaldevelopmenteventattendance') THEN
CREATE TABLE tracked_changes_edfi.professionaldevelopmenteventattendance
(
       oldattendancedate DATE NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldprofessionaldevelopmenttitle VARCHAR(60) NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       newattendancedate DATE NULL,
       newnamespace VARCHAR(255) NULL,
       newpersonid VARCHAR(32) NULL,
       newprofessionaldevelopmenttitle VARCHAR(60) NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT professionaldevelopmenteventattendance_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'program') THEN
CREATE TABLE tracked_changes_edfi.program
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT program_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'programdimension') THEN
CREATE TABLE tracked_changes_edfi.programdimension
(
       oldcode VARCHAR(16) NOT NULL,
       oldfiscalyear INT NOT NULL,
       newcode VARCHAR(16) NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT programdimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'programevaluation') THEN
CREATE TABLE tracked_changes_edfi.programevaluation
(
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramevaluationperioddescriptorid INT NOT NULL,
       oldprogramevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramevaluationtitle VARCHAR(50) NOT NULL,
       oldprogramevaluationtypedescriptorid INT NOT NULL,
       oldprogramevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramevaluationperioddescriptorid INT NULL,
       newprogramevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newprogramevaluationtitle VARCHAR(50) NULL,
       newprogramevaluationtypedescriptorid INT NULL,
       newprogramevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT programevaluation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'programevaluationelement') THEN
CREATE TABLE tracked_changes_edfi.programevaluationelement
(
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramevaluationelementtitle VARCHAR(50) NOT NULL,
       oldprogramevaluationperioddescriptorid INT NOT NULL,
       oldprogramevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramevaluationtitle VARCHAR(50) NOT NULL,
       oldprogramevaluationtypedescriptorid INT NOT NULL,
       oldprogramevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramevaluationelementtitle VARCHAR(50) NULL,
       newprogramevaluationperioddescriptorid INT NULL,
       newprogramevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newprogramevaluationtitle VARCHAR(50) NULL,
       newprogramevaluationtypedescriptorid INT NULL,
       newprogramevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT programevaluationelement_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'programevaluationobjective') THEN
CREATE TABLE tracked_changes_edfi.programevaluationobjective
(
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldprogramevaluationperioddescriptorid INT NOT NULL,
       oldprogramevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramevaluationtitle VARCHAR(50) NOT NULL,
       oldprogramevaluationtypedescriptorid INT NOT NULL,
       oldprogramevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramevaluationobjectivetitle VARCHAR(50) NULL,
       newprogramevaluationperioddescriptorid INT NULL,
       newprogramevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newprogramevaluationtitle VARCHAR(50) NULL,
       newprogramevaluationtypedescriptorid INT NULL,
       newprogramevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT programevaluationobjective_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'projectdimension') THEN
CREATE TABLE tracked_changes_edfi.projectdimension
(
       oldcode VARCHAR(16) NOT NULL,
       oldfiscalyear INT NOT NULL,
       newcode VARCHAR(16) NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT projectdimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'quantitativemeasure') THEN
CREATE TABLE tracked_changes_edfi.quantitativemeasure
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationelementtitle VARCHAR(255) NOT NULL,
       oldevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldquantitativemeasureidentifier VARCHAR(64) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationelementtitle VARCHAR(255) NULL,
       newevaluationobjectivetitle VARCHAR(50) NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newquantitativemeasureidentifier VARCHAR(64) NULL,
       newschoolyear SMALLINT NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT quantitativemeasure_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'quantitativemeasurescore') THEN
CREATE TABLE tracked_changes_edfi.quantitativemeasurescore
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationdate TIMESTAMP NOT NULL,
       oldevaluationelementtitle VARCHAR(255) NOT NULL,
       oldevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldquantitativemeasureidentifier VARCHAR(64) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationdate TIMESTAMP NULL,
       newevaluationelementtitle VARCHAR(255) NULL,
       newevaluationobjectivetitle VARCHAR(50) NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newpersonid VARCHAR(32) NULL,
       newquantitativemeasureidentifier VARCHAR(64) NULL,
       newschoolyear SMALLINT NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT quantitativemeasurescore_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'recruitmentevent') THEN
CREATE TABLE tracked_changes_edfi.recruitmentevent
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldeventdate DATE NOT NULL,
       oldeventtitle VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       neweventdate DATE NULL,
       neweventtitle VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT recruitmentevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'recruitmenteventattendance') THEN
CREATE TABLE tracked_changes_edfi.recruitmenteventattendance
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldeventdate DATE NOT NULL,
       oldeventtitle VARCHAR(50) NOT NULL,
       oldrecruitmenteventattendeeidentifier VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       neweventdate DATE NULL,
       neweventtitle VARCHAR(50) NULL,
       newrecruitmenteventattendeeidentifier VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT recruitmenteventattendance_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'reportcard') THEN
CREATE TABLE tracked_changes_edfi.reportcard
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldgradingperioddescriptorid INT NOT NULL,
       oldgradingperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldgradingperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgradingperiodname VARCHAR(60) NOT NULL,
       oldgradingperiodschoolid BIGINT NOT NULL,
       oldgradingperiodschoolyear SMALLINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newgradingperiodname VARCHAR(60) NULL,
       newgradingperiodschoolid BIGINT NULL,
       newgradingperiodschoolyear SMALLINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT reportcard_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'restraintevent') THEN
CREATE TABLE tracked_changes_edfi.restraintevent
(
       oldrestrainteventidentifier VARCHAR(36) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newrestrainteventidentifier VARCHAR(36) NULL,
       newschoolid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT restraintevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'rubricdimension') THEN
CREATE TABLE tracked_changes_edfi.rubricdimension
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationelementtitle VARCHAR(255) NOT NULL,
       oldevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldrubricrating INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationelementtitle VARCHAR(255) NULL,
       newevaluationobjectivetitle VARCHAR(50) NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newrubricrating INT NULL,
       newschoolyear SMALLINT NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT rubricdimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'schoolyeartype') THEN
CREATE TABLE tracked_changes_edfi.schoolyeartype
(
       oldschoolyear SMALLINT NOT NULL,
       newschoolyear SMALLINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT schoolyeartype_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'section') THEN
CREATE TABLE tracked_changes_edfi.section
(
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT section_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'sectionattendancetakenevent') THEN
CREATE TABLE tracked_changes_edfi.sectionattendancetakenevent
(
       oldcalendarcode VARCHAR(120) NOT NULL,
       olddate DATE NOT NULL,
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       newcalendarcode VARCHAR(120) NULL,
       newdate DATE NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT sectionattendancetakenevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'session') THEN
CREATE TABLE tracked_changes_edfi.session
(
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsessionname VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT session_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'sourcedimension') THEN
CREATE TABLE tracked_changes_edfi.sourcedimension
(
       oldcode VARCHAR(16) NOT NULL,
       oldfiscalyear INT NOT NULL,
       newcode VARCHAR(16) NULL,
       newfiscalyear INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT sourcedimension_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staff') THEN
CREATE TABLE tracked_changes_edfi.staff
(
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staff_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffabsenceevent') THEN
CREATE TABLE tracked_changes_edfi.staffabsenceevent
(
       oldabsenceeventcategorydescriptorid INT NOT NULL,
       oldabsenceeventcategorydescriptornamespace VARCHAR(255) NOT NULL,
       oldabsenceeventcategorydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldeventdate DATE NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newabsenceeventcategorydescriptorid INT NULL,
       newabsenceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newabsenceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweventdate DATE NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffabsenceevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffcohortassociation') THEN
CREATE TABLE tracked_changes_edfi.staffcohortassociation
(
       oldbegindate DATE NOT NULL,
       oldcohortidentifier VARCHAR(36) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newcohortidentifier VARCHAR(36) NULL,
       neweducationorganizationid BIGINT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffcohortassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffdemographic') THEN
CREATE TABLE tracked_changes_edfi.staffdemographic
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffdemographic_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffdirectory') THEN
CREATE TABLE tracked_changes_edfi.staffdirectory
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffdirectory_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffdisciplineincidentassociation') THEN
CREATE TABLE tracked_changes_edfi.staffdisciplineincidentassociation
(
       oldincidentidentifier VARCHAR(36) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid BIGINT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffdisciplineincidentassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffeducationorganizationassignmentassociation') THEN
CREATE TABLE tracked_changes_edfi.staffeducationorganizationassignmentassociation
(
       oldbegindate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldstaffclassificationdescriptorid INT NOT NULL,
       oldstaffclassificationdescriptornamespace VARCHAR(255) NOT NULL,
       oldstaffclassificationdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newstaffclassificationdescriptorid INT NULL,
       newstaffclassificationdescriptornamespace VARCHAR(255) NULL,
       newstaffclassificationdescriptorcodevalue VARCHAR(50) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffeducationorganizationassignmentassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffeducationorganizationemploymentassociation') THEN
CREATE TABLE tracked_changes_edfi.staffeducationorganizationemploymentassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldemploymentstatusdescriptorid INT NOT NULL,
       oldemploymentstatusdescriptornamespace VARCHAR(255) NOT NULL,
       oldemploymentstatusdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldhiredate DATE NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newemploymentstatusdescriptorid INT NULL,
       newemploymentstatusdescriptornamespace VARCHAR(255) NULL,
       newemploymentstatusdescriptorcodevalue VARCHAR(50) NULL,
       newhiredate DATE NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffeducationorganizationemploymentassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffeducatorpreparationprogramassociation') THEN
CREATE TABLE tracked_changes_edfi.staffeducatorpreparationprogramassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldprogramname VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newprogramname VARCHAR(255) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffeducatorpreparationprogramassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffidentity') THEN
CREATE TABLE tracked_changes_edfi.staffidentity
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstaffidentificationsystemdescriptorid INT NOT NULL,
       oldstaffidentificationsystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldstaffidentificationsystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstaffidentificationsystemdescriptorid INT NULL,
       newstaffidentificationsystemdescriptornamespace VARCHAR(255) NULL,
       newstaffidentificationsystemdescriptorcodevalue VARCHAR(50) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffidentity_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffleave') THEN
CREATE TABLE tracked_changes_edfi.staffleave
(
       oldbegindate DATE NOT NULL,
       oldstaffleaveeventcategorydescriptorid INT NOT NULL,
       oldstaffleaveeventcategorydescriptornamespace VARCHAR(255) NOT NULL,
       oldstaffleaveeventcategorydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newstaffleaveeventcategorydescriptorid INT NULL,
       newstaffleaveeventcategorydescriptornamespace VARCHAR(255) NULL,
       newstaffleaveeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffleave_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffprogramassociation') THEN
CREATE TABLE tracked_changes_edfi.staffprogramassociation
(
       oldbegindate DATE NOT NULL,
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffprogramassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffschoolassociation') THEN
CREATE TABLE tracked_changes_edfi.staffschoolassociation
(
       oldprogramassignmentdescriptorid INT NOT NULL,
       oldprogramassignmentdescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramassignmentdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newprogramassignmentdescriptorid INT NULL,
       newprogramassignmentdescriptornamespace VARCHAR(255) NULL,
       newprogramassignmentdescriptorcodevalue VARCHAR(50) NULL,
       newschoolid BIGINT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffschoolassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffsectionassociation') THEN
CREATE TABLE tracked_changes_edfi.staffsectionassociation
(
       oldbegindate DATE NOT NULL,
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(120) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffsectionassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'student') THEN
CREATE TABLE tracked_changes_edfi.student
(
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT student_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentacademicrecord') THEN
CREATE TABLE tracked_changes_edfi.studentacademicrecord
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentacademicrecord_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentassessment') THEN
CREATE TABLE tracked_changes_edfi.studentassessment
(
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldstudentassessmentidentifier VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newnamespace VARCHAR(255) NULL,
       newstudentassessmentidentifier VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentassessment_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentassessmenteducationorganizationassociation') THEN
CREATE TABLE tracked_changes_edfi.studentassessmenteducationorganizationassociation
(
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldeducationorganizationassociationtypedescriptorid INT NOT NULL,
       oldeducationorganizationassociationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldeducationorganizationassociationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldstudentassessmentidentifier VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       neweducationorganizationassociationtypedescriptorid INT NULL,
       neweducationorganizationassociationtypedescriptornamespace VARCHAR(255) NULL,
       neweducationorganizationassociationtypedescriptorcodevalue VARCHAR(50) NULL,
       neweducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       newstudentassessmentidentifier VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentassessmenteducationorganizationassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentassessmentregistration') THEN
CREATE TABLE tracked_changes_edfi.studentassessmentregistration
(
       oldadministrationidentifier VARCHAR(255) NOT NULL,
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldassigningeducationorganizationid BIGINT NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newadministrationidentifier VARCHAR(255) NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newassigningeducationorganizationid BIGINT NULL,
       neweducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentassessmentregistration_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentassessmentregistrationbatterypartassociation') THEN
CREATE TABLE tracked_changes_edfi.studentassessmentregistrationbatterypartassociation
(
       oldadministrationidentifier VARCHAR(255) NOT NULL,
       oldassessmentbatterypartname VARCHAR(65) NOT NULL,
       oldassessmentidentifier VARCHAR(120) NOT NULL,
       oldassigningeducationorganizationid BIGINT NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newadministrationidentifier VARCHAR(255) NULL,
       newassessmentbatterypartname VARCHAR(65) NULL,
       newassessmentidentifier VARCHAR(120) NULL,
       newassigningeducationorganizationid BIGINT NULL,
       neweducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentassessmentregistrationbatterypartassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentcohortassociation') THEN
CREATE TABLE tracked_changes_edfi.studentcohortassociation
(
       oldbegindate DATE NOT NULL,
       oldcohortidentifier VARCHAR(36) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newcohortidentifier VARCHAR(36) NULL,
       neweducationorganizationid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentcohortassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentcompetencyobjective') THEN
CREATE TABLE tracked_changes_edfi.studentcompetencyobjective
(
       oldgradingperioddescriptorid INT NOT NULL,
       oldgradingperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldgradingperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgradingperiodname VARCHAR(60) NOT NULL,
       oldgradingperiodschoolid BIGINT NOT NULL,
       oldgradingperiodschoolyear SMALLINT NOT NULL,
       oldobjectiveeducationorganizationid BIGINT NOT NULL,
       oldobjective VARCHAR(60) NOT NULL,
       oldobjectivegradeleveldescriptorid INT NOT NULL,
       oldobjectivegradeleveldescriptornamespace VARCHAR(255) NOT NULL,
       oldobjectivegradeleveldescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newgradingperiodname VARCHAR(60) NULL,
       newgradingperiodschoolid BIGINT NULL,
       newgradingperiodschoolyear SMALLINT NULL,
       newobjectiveeducationorganizationid BIGINT NULL,
       newobjective VARCHAR(60) NULL,
       newobjectivegradeleveldescriptorid INT NULL,
       newobjectivegradeleveldescriptornamespace VARCHAR(255) NULL,
       newobjectivegradeleveldescriptorcodevalue VARCHAR(50) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentcompetencyobjective_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentcontactassociation') THEN
CREATE TABLE tracked_changes_edfi.studentcontactassociation
(
       oldcontactusi INT NOT NULL,
       oldcontactuniqueid VARCHAR(32) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newcontactusi INT NULL,
       newcontactuniqueid VARCHAR(32) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentcontactassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdemographic') THEN
CREATE TABLE tracked_changes_edfi.studentdemographic
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdemographic_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdirectory') THEN
CREATE TABLE tracked_changes_edfi.studentdirectory
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdirectory_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdisciplineincidentbehaviorassociation') THEN
CREATE TABLE tracked_changes_edfi.studentdisciplineincidentbehaviorassociation
(
       oldbehaviordescriptorid INT NOT NULL,
       oldbehaviordescriptornamespace VARCHAR(255) NOT NULL,
       oldbehaviordescriptorcodevalue VARCHAR(50) NOT NULL,
       oldincidentidentifier VARCHAR(36) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbehaviordescriptorid INT NULL,
       newbehaviordescriptornamespace VARCHAR(255) NULL,
       newbehaviordescriptorcodevalue VARCHAR(50) NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdisciplineincidentbehaviorassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdisciplineincidentnonoffenderassociation') THEN
CREATE TABLE tracked_changes_edfi.studentdisciplineincidentnonoffenderassociation
(
       oldincidentidentifier VARCHAR(36) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdisciplineincidentnonoffenderassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studenteducationorganizationassessmentaccommodation') THEN
CREATE TABLE tracked_changes_edfi.studenteducationorganizationassessmentaccommodation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studenteducationorganizationassessmentaccommodation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studenteducationorganizationassociation') THEN
CREATE TABLE tracked_changes_edfi.studenteducationorganizationassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studenteducationorganizationassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studenteducationorganizationresponsibilityassociation') THEN
CREATE TABLE tracked_changes_edfi.studenteducationorganizationresponsibilityassociation
(
       oldbegindate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldresponsibilitydescriptorid INT NOT NULL,
       oldresponsibilitydescriptornamespace VARCHAR(255) NOT NULL,
       oldresponsibilitydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newresponsibilitydescriptorid INT NULL,
       newresponsibilitydescriptornamespace VARCHAR(255) NULL,
       newresponsibilitydescriptorcodevalue VARCHAR(50) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studenteducationorganizationresponsibilityassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentgradebookentry') THEN
CREATE TABLE tracked_changes_edfi.studentgradebookentry
(
       oldgradebookentryidentifier VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newgradebookentryidentifier VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentgradebookentry_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studenthealth') THEN
CREATE TABLE tracked_changes_edfi.studenthealth
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studenthealth_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentidentity') THEN
CREATE TABLE tracked_changes_edfi.studentidentity
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldstudentidentificationsystemdescriptorid INT NOT NULL,
       oldstudentidentificationsystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldstudentidentificationsystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newstudentidentificationsystemdescriptorid INT NULL,
       newstudentidentificationsystemdescriptornamespace VARCHAR(255) NULL,
       newstudentidentificationsystemdescriptorcodevalue VARCHAR(50) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentidentity_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentinterventionassociation') THEN
CREATE TABLE tracked_changes_edfi.studentinterventionassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldinterventionidentificationcode VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newinterventionidentificationcode VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentinterventionassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentinterventionattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentinterventionattendanceevent
(
       oldattendanceeventcategorydescriptorid INT NOT NULL,
       oldattendanceeventcategorydescriptornamespace VARCHAR(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldeventdate DATE NOT NULL,
       oldinterventionidentificationcode VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newattendanceeventcategorydescriptorid INT NULL,
       newattendanceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newattendanceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweducationorganizationid BIGINT NULL,
       neweventdate DATE NULL,
       newinterventionidentificationcode VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentinterventionattendanceevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentpath') THEN
CREATE TABLE tracked_changes_edfi.studentpath
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldpathname VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newpathname VARCHAR(60) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentpath_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentpathmilestonestatus') THEN
CREATE TABLE tracked_changes_edfi.studentpathmilestonestatus
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldpathmilestonename VARCHAR(60) NOT NULL,
       oldpathmilestonetypedescriptorid INT NOT NULL,
       oldpathmilestonetypedescriptornamespace VARCHAR(255) NOT NULL,
       oldpathmilestonetypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldpathname VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newpathmilestonename VARCHAR(60) NULL,
       newpathmilestonetypedescriptorid INT NULL,
       newpathmilestonetypedescriptornamespace VARCHAR(255) NULL,
       newpathmilestonetypedescriptorcodevalue VARCHAR(50) NULL,
       newpathname VARCHAR(60) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentpathmilestonestatus_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentpathphasestatus') THEN
CREATE TABLE tracked_changes_edfi.studentpathphasestatus
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldpathname VARCHAR(60) NOT NULL,
       oldpathphasename VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newpathname VARCHAR(60) NULL,
       newpathphasename VARCHAR(60) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentpathphasestatus_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentprogramattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentprogramattendanceevent
(
       oldattendanceeventcategorydescriptorid INT NOT NULL,
       oldattendanceeventcategorydescriptornamespace VARCHAR(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldeventdate DATE NOT NULL,
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newattendanceeventcategorydescriptorid INT NULL,
       newattendanceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newattendanceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweducationorganizationid BIGINT NULL,
       neweventdate DATE NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentprogramattendanceevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentprogramevaluation') THEN
CREATE TABLE tracked_changes_edfi.studentprogramevaluation
(
       oldevaluationdate DATE NOT NULL,
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramevaluationperioddescriptorid INT NOT NULL,
       oldprogramevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramevaluationtitle VARCHAR(50) NOT NULL,
       oldprogramevaluationtypedescriptorid INT NOT NULL,
       oldprogramevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newevaluationdate DATE NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramevaluationperioddescriptorid INT NULL,
       newprogramevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newprogramevaluationtitle VARCHAR(50) NULL,
       newprogramevaluationtypedescriptorid INT NULL,
       newprogramevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newprogramevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentprogramevaluation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentschoolassociation') THEN
CREATE TABLE tracked_changes_edfi.studentschoolassociation
(
       oldentrydate DATE NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newentrydate DATE NULL,
       newschoolid BIGINT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentschoolassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentschoolattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentschoolattendanceevent
(
       oldattendanceeventcategorydescriptorid INT NOT NULL,
       oldattendanceeventcategorydescriptornamespace VARCHAR(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldeventdate DATE NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newattendanceeventcategorydescriptorid INT NULL,
       newattendanceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newattendanceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweventdate DATE NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsessionname VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentschoolattendanceevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentsectionassociation') THEN
CREATE TABLE tracked_changes_edfi.studentsectionassociation
(
       oldbegindate DATE NOT NULL,
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentsectionassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentsectionattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentsectionattendanceevent
(
       oldattendanceeventcategorydescriptorid INT NOT NULL,
       oldattendanceeventcategorydescriptornamespace VARCHAR(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldeventdate DATE NOT NULL,
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newattendanceeventcategorydescriptorid INT NULL,
       newattendanceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newattendanceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweventdate DATE NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(120) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentsectionattendanceevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentspecialeducationprogrameligibilityassociation') THEN
CREATE TABLE tracked_changes_edfi.studentspecialeducationprogrameligibilityassociation
(
       oldconsenttoevaluationreceiveddate DATE NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldprogrameducationorganizationid BIGINT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newconsenttoevaluationreceiveddate DATE NULL,
       neweducationorganizationid BIGINT NULL,
       newprogrameducationorganizationid BIGINT NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentspecialeducationprogrameligibilityassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studenttransportation') THEN
CREATE TABLE tracked_changes_edfi.studenttransportation
(
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       oldtransportationeducationorganizationid BIGINT NOT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       newtransportationeducationorganizationid BIGINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studenttransportation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'survey') THEN
CREATE TABLE tracked_changes_edfi.survey
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT survey_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveycourseassociation') THEN
CREATE TABLE tracked_changes_edfi.surveycourseassociation
(
       oldcoursecode VARCHAR(120) NOT NULL,
       oldeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       newcoursecode VARCHAR(120) NULL,
       neweducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveycourseassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyprogramassociation') THEN
CREATE TABLE tracked_changes_edfi.surveyprogramassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyprogramassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyquestion') THEN
CREATE TABLE tracked_changes_edfi.surveyquestion
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldquestioncode VARCHAR(120) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newquestioncode VARCHAR(120) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyquestion_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyquestionresponse') THEN
CREATE TABLE tracked_changes_edfi.surveyquestionresponse
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldquestioncode VARCHAR(120) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newquestioncode VARCHAR(120) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyquestionresponse_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyresponse') THEN
CREATE TABLE tracked_changes_edfi.surveyresponse
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponse_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyresponseeducationorganizationtargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveyresponseeducationorganizationtargetassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponseeducationorganizationtargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyresponsepersontargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveyresponsepersontargetassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newpersonid VARCHAR(32) NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponsepersontargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyresponsestafftargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveyresponsestafftargetassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponsestafftargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysection') THEN
CREATE TABLE tracked_changes_edfi.surveysection
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysection_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionaggregateresponse') THEN
CREATE TABLE tracked_changes_edfi.surveysectionaggregateresponse
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldevaluationdate TIMESTAMP NOT NULL,
       oldevaluationelementtitle VARCHAR(255) NOT NULL,
       oldevaluationobjectivetitle VARCHAR(50) NOT NULL,
       oldevaluationperioddescriptorid INT NOT NULL,
       oldevaluationperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldevaluationperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldevaluationtitle VARCHAR(50) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtitle VARCHAR(50) NOT NULL,
       oldperformanceevaluationtypedescriptorid INT NOT NULL,
       oldperformanceevaluationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newevaluationdate TIMESTAMP NULL,
       newevaluationelementtitle VARCHAR(255) NULL,
       newevaluationobjectivetitle VARCHAR(50) NULL,
       newevaluationperioddescriptorid INT NULL,
       newevaluationperioddescriptornamespace VARCHAR(255) NULL,
       newevaluationperioddescriptorcodevalue VARCHAR(50) NULL,
       newevaluationtitle VARCHAR(50) NULL,
       newnamespace VARCHAR(255) NULL,
       newperformanceevaluationtitle VARCHAR(50) NULL,
       newperformanceevaluationtypedescriptorid INT NULL,
       newperformanceevaluationtypedescriptornamespace VARCHAR(255) NULL,
       newperformanceevaluationtypedescriptorcodevalue VARCHAR(50) NULL,
       newpersonid VARCHAR(32) NULL,
       newschoolyear SMALLINT NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       newtermdescriptorid INT NULL,
       newtermdescriptornamespace VARCHAR(255) NULL,
       newtermdescriptorcodevalue VARCHAR(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionaggregateresponse_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionassociation
(
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldschoolid BIGINT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(120) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       newschoolid BIGINT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(120) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionresponse') THEN
CREATE TABLE tracked_changes_edfi.surveysectionresponse
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponse_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionresponseeducationorganizationtargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionresponseeducationorganizationtargetassociation
(
       oldeducationorganizationid BIGINT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       neweducationorganizationid BIGINT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponseeducationorganizationtargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionresponsepersontargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionresponsepersontargetassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newpersonid VARCHAR(32) NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponsepersontargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionresponsestafftargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionresponsestafftargetassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       oldsurveyidentifier VARCHAR(120) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(120) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       newsurveyidentifier VARCHAR(120) NULL,
       newsurveyresponseidentifier VARCHAR(120) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponsestafftargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

END
$$;
