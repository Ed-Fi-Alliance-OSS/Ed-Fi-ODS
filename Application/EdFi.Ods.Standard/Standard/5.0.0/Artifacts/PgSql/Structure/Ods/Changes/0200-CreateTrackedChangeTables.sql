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
       oldschoolid INT NOT NULL,
       oldweekidentifier VARCHAR(80) NOT NULL,
       newschoolid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldratingtitle VARCHAR(60) NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       neweducationorganizationid INT NULL,
       newratingtitle VARCHAR(60) NULL,
       newschoolyear SMALLINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT accountabilityrating_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessment') THEN
CREATE TABLE tracked_changes_edfi.assessment
(
       oldassessmentidentifier VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newassessmentidentifier VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessment_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessmentitem') THEN
CREATE TABLE tracked_changes_edfi.assessmentitem
(
       oldassessmentidentifier VARCHAR(60) NOT NULL,
       oldidentificationcode VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newassessmentidentifier VARCHAR(60) NULL,
       newidentificationcode VARCHAR(60) NULL,
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
       oldassessmentidentifier VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldscorerangeid VARCHAR(60) NOT NULL,
       newassessmentidentifier VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       newscorerangeid VARCHAR(60) NULL,
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
       oldschoolid INT NOT NULL,
       newbellschedulename VARCHAR(60) NULL,
       newschoolid INT NULL,
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
       oldcalendarcode VARCHAR(60) NOT NULL,
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       newcalendarcode VARCHAR(60) NULL,
       newschoolid INT NULL,
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
       oldcalendarcode VARCHAR(60) NOT NULL,
       olddate DATE NOT NULL,
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       newcalendarcode VARCHAR(60) NULL,
       newdate DATE NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT calendardate_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'chartofaccount') THEN
CREATE TABLE tracked_changes_edfi.chartofaccount
(
       oldaccountidentifier VARCHAR(50) NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       neweducationorganizationid INT NULL,
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
       oldschoolid INT NOT NULL,
       newclassperiodname VARCHAR(60) NULL,
       newschoolid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       newcohortidentifier VARCHAR(36) NULL,
       neweducationorganizationid INT NULL,
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
       oldcommunityproviderid INT NOT NULL,
       oldlicenseidentifier VARCHAR(36) NOT NULL,
       oldlicensingorganization VARCHAR(75) NOT NULL,
       newcommunityproviderid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldobjective VARCHAR(60) NOT NULL,
       oldobjectivegradeleveldescriptorid INT NOT NULL,
       oldobjectivegradeleveldescriptornamespace VARCHAR(255) NOT NULL,
       oldobjectivegradeleveldescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'course') THEN
CREATE TABLE tracked_changes_edfi.course
(
       oldcoursecode VARCHAR(60) NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       newcoursecode VARCHAR(60) NULL,
       neweducationorganizationid INT NULL,
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
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsessionname VARCHAR(60) NULL,
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
       oldcoursecode VARCHAR(60) NOT NULL,
       oldcourseeducationorganizationid INT NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       newcourseattemptresultdescriptorid INT NULL,
       newcourseattemptresultdescriptornamespace VARCHAR(255) NULL,
       newcourseattemptresultdescriptorcodevalue VARCHAR(50) NULL,
       newcoursecode VARCHAR(60) NULL,
       newcourseeducationorganizationid INT NULL,
       neweducationorganizationid INT NULL,
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
       oldcredentialidentifier VARCHAR(60) NOT NULL,
       oldstateofissuestateabbreviationdescriptorid INT NOT NULL,
       oldstateofissuestateabbreviationdescriptornamespace VARCHAR(255) NOT NULL,
       oldstateofissuestateabbreviationdescriptorcodevalue VARCHAR(50) NOT NULL,
       newcredentialidentifier VARCHAR(60) NULL,
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
       oldresponsibilityschoolid INT NOT NULL,
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
       oldschoolid INT NOT NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       neweducationorganizationid INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganization_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganizationinterventionprescriptionassociation') THEN
CREATE TABLE tracked_changes_edfi.educationorganizationinterventionprescriptionassociation
(
       oldeducationorganizationid INT NOT NULL,
       oldinterventionprescriptioneducationorganizationid INT NOT NULL,
       oldinterventionprescriptionidentificationcode VARCHAR(60) NOT NULL,
       neweducationorganizationid INT NULL,
       newinterventionprescriptioneducationorganizationid INT NULL,
       newinterventionprescriptionidentificationcode VARCHAR(60) NULL,
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
       oldeducationorganizationnetworkid INT NOT NULL,
       oldmembereducationorganizationid INT NOT NULL,
       neweducationorganizationnetworkid INT NULL,
       newmembereducationorganizationid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldpeereducationorganizationid INT NOT NULL,
       neweducationorganizationid INT NULL,
       newpeereducationorganizationid INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganizationpeerassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'feederschoolassociation') THEN
CREATE TABLE tracked_changes_edfi.feederschoolassociation
(
       oldbegindate DATE NOT NULL,
       oldfeederschoolid INT NOT NULL,
       oldschoolid INT NOT NULL,
       newbegindate DATE NULL,
       newfeederschoolid INT NULL,
       newschoolid INT NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT feederschoolassociation_pk PRIMARY KEY (ChangeVersion)
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
       oldeducationorganizationid INT NOT NULL,
       oldprogrameducationorganizationid INT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       neweducationorganizationid INT NULL,
       newprogrameducationorganizationid INT NULL,
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
       oldgradingperiodschoolyear SMALLINT NOT NULL,
       oldgradingperiodsequence INT NOT NULL,
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newgradetypedescriptorid INT NULL,
       newgradetypedescriptornamespace VARCHAR(255) NULL,
       newgradetypedescriptorcodevalue VARCHAR(50) NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newgradingperiodschoolyear SMALLINT NULL,
       newgradingperiodsequence INT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(60) NULL,
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
       oldperiodsequence INT NOT NULL,
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newperiodsequence INT NULL,
       newschoolid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldgraduationplantypedescriptorid INT NOT NULL,
       oldgraduationplantypedescriptornamespace VARCHAR(255) NOT NULL,
       oldgraduationplantypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgraduationschoolyear SMALLINT NOT NULL,
       neweducationorganizationid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldinterventionidentificationcode VARCHAR(60) NOT NULL,
       neweducationorganizationid INT NULL,
       newinterventionidentificationcode VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldinterventionprescriptionidentificationcode VARCHAR(60) NOT NULL,
       neweducationorganizationid INT NULL,
       newinterventionprescriptionidentificationcode VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldinterventionstudyidentificationcode VARCHAR(60) NOT NULL,
       neweducationorganizationid INT NULL,
       newinterventionstudyidentificationcode VARCHAR(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT interventionstudy_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'learningobjective') THEN
CREATE TABLE tracked_changes_edfi.learningobjective
(
       oldlearningobjectiveid VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newlearningobjectiveid VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT learningobjective_pk PRIMARY KEY (ChangeVersion)
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
       oldeducationorganizationid INT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       neweducationorganizationid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldfiscalyear INT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldfiscalyear INT NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldfiscalyear INT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newaccountidentifier VARCHAR(50) NULL,
       newasofdate DATE NULL,
       neweducationorganizationid INT NULL,
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
       oldschoolid INT NOT NULL,
       newclassroomidentificationcode VARCHAR(60) NULL,
       newschoolid INT NULL,
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
       oldassessmentidentifier VARCHAR(60) NOT NULL,
       oldidentificationcode VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       newassessmentidentifier VARCHAR(60) NULL,
       newidentificationcode VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldrequisitionnumber VARCHAR(20) NOT NULL,
       neweducationorganizationid INT NULL,
       newrequisitionnumber VARCHAR(20) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT openstaffposition_pk PRIMARY KEY (ChangeVersion)
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'parent') THEN
CREATE TABLE tracked_changes_edfi.parent
(
       oldparentusi INT NOT NULL,
       oldparentuniqueid VARCHAR(32) NOT NULL,
       newparentusi INT NULL,
       newparentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT parent_pk PRIMARY KEY (ChangeVersion)
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'program') THEN
CREATE TABLE tracked_changes_edfi.program
(
       oldeducationorganizationid INT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'reportcard') THEN
CREATE TABLE tracked_changes_edfi.reportcard
(
       oldeducationorganizationid INT NOT NULL,
       oldgradingperioddescriptorid INT NOT NULL,
       oldgradingperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldgradingperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgradingperiodschoolid INT NOT NULL,
       oldgradingperiodschoolyear SMALLINT NOT NULL,
       oldgradingperiodsequence INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid INT NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newgradingperiodschoolid INT NULL,
       newgradingperiodschoolyear SMALLINT NULL,
       newgradingperiodsequence INT NULL,
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
       oldschoolid INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newrestrainteventidentifier VARCHAR(36) NULL,
       newschoolid INT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT restraintevent_pk PRIMARY KEY (ChangeVersion)
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
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(60) NULL,
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
       oldcalendarcode VARCHAR(60) NOT NULL,
       olddate DATE NOT NULL,
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       newcalendarcode VARCHAR(60) NULL,
       newdate DATE NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(60) NULL,
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
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsessionname VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newcohortidentifier VARCHAR(36) NULL,
       neweducationorganizationid INT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffcohortassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffdisciplineincidentassociation') THEN
CREATE TABLE tracked_changes_edfi.staffdisciplineincidentassociation
(
       oldincidentidentifier VARCHAR(36) NOT NULL,
       oldschoolid INT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldstaffclassificationdescriptorid INT NOT NULL,
       oldstaffclassificationdescriptornamespace VARCHAR(255) NOT NULL,
       oldstaffclassificationdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffeducationorganizationcontactassociation') THEN
CREATE TABLE tracked_changes_edfi.staffeducationorganizationcontactassociation
(
       oldcontacttitle VARCHAR(75) NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newcontacttitle VARCHAR(75) NULL,
       neweducationorganizationid INT NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffeducationorganizationcontactassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffeducationorganizationemploymentassociation') THEN
CREATE TABLE tracked_changes_edfi.staffeducationorganizationemploymentassociation
(
       oldeducationorganizationid INT NOT NULL,
       oldemploymentstatusdescriptorid INT NOT NULL,
       oldemploymentstatusdescriptornamespace VARCHAR(255) NOT NULL,
       oldemploymentstatusdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldhiredate DATE NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid INT NULL,
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
       oldprogrameducationorganizationid INT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newprogrameducationorganizationid INT NULL,
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
       oldschoolid INT NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newprogramassignmentdescriptorid INT NULL,
       newprogramassignmentdescriptornamespace VARCHAR(255) NULL,
       newprogramassignmentdescriptorcodevalue VARCHAR(50) NULL,
       newschoolid INT NULL,
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
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       oldtermdescriptorid INT NOT NULL,
       oldtermdescriptornamespace VARCHAR(255) NOT NULL,
       oldtermdescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid INT NULL,
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
       oldassessmentidentifier VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldstudentassessmentidentifier VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newassessmentidentifier VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       newstudentassessmentidentifier VARCHAR(60) NULL,
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
       oldassessmentidentifier VARCHAR(60) NOT NULL,
       oldeducationorganizationassociationtypedescriptorid INT NOT NULL,
       oldeducationorganizationassociationtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldeducationorganizationassociationtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldstudentassessmentidentifier VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newassessmentidentifier VARCHAR(60) NULL,
       neweducationorganizationassociationtypedescriptorid INT NULL,
       neweducationorganizationassociationtypedescriptornamespace VARCHAR(255) NULL,
       neweducationorganizationassociationtypedescriptorcodevalue VARCHAR(50) NULL,
       neweducationorganizationid INT NULL,
       newnamespace VARCHAR(255) NULL,
       newstudentassessmentidentifier VARCHAR(60) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentassessmenteducationorganizationassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentcohortassociation') THEN
CREATE TABLE tracked_changes_edfi.studentcohortassociation
(
       oldbegindate DATE NOT NULL,
       oldcohortidentifier VARCHAR(36) NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newcohortidentifier VARCHAR(36) NULL,
       neweducationorganizationid INT NULL,
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
       oldgradingperiodschoolid INT NOT NULL,
       oldgradingperiodschoolyear SMALLINT NOT NULL,
       oldgradingperiodsequence INT NOT NULL,
       oldobjective VARCHAR(60) NOT NULL,
       oldobjectiveeducationorganizationid INT NOT NULL,
       oldobjectivegradeleveldescriptorid INT NOT NULL,
       oldobjectivegradeleveldescriptornamespace VARCHAR(255) NOT NULL,
       oldobjectivegradeleveldescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newgradingperiodschoolid INT NULL,
       newgradingperiodschoolyear SMALLINT NULL,
       newgradingperiodsequence INT NULL,
       newobjective VARCHAR(60) NULL,
       newobjectiveeducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdisciplineincidentassociation') THEN
CREATE TABLE tracked_changes_edfi.studentdisciplineincidentassociation
(
       oldincidentidentifier VARCHAR(36) NOT NULL,
       oldschoolid INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid INT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdisciplineincidentassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdisciplineincidentbehaviorassociation') THEN
CREATE TABLE tracked_changes_edfi.studentdisciplineincidentbehaviorassociation
(
       oldbehaviordescriptorid INT NOT NULL,
       oldbehaviordescriptornamespace VARCHAR(255) NOT NULL,
       oldbehaviordescriptorcodevalue VARCHAR(50) NOT NULL,
       oldincidentidentifier VARCHAR(36) NOT NULL,
       oldschoolid INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbehaviordescriptorid INT NULL,
       newbehaviordescriptornamespace VARCHAR(255) NULL,
       newbehaviordescriptorcodevalue VARCHAR(50) NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid INT NULL,
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
       oldschoolid INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newincidentidentifier VARCHAR(36) NULL,
       newschoolid INT NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdisciplineincidentnonoffenderassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studenteducationorganizationassociation') THEN
CREATE TABLE tracked_changes_edfi.studenteducationorganizationassociation
(
       oldeducationorganizationid INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid INT NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldresponsibilitydescriptorid INT NOT NULL,
       oldresponsibilitydescriptornamespace VARCHAR(255) NOT NULL,
       oldresponsibilitydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentinterventionassociation') THEN
CREATE TABLE tracked_changes_edfi.studentinterventionassociation
(
       oldeducationorganizationid INT NOT NULL,
       oldinterventionidentificationcode VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       neweducationorganizationid INT NULL,
       newinterventionidentificationcode VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldeventdate DATE NOT NULL,
       oldinterventionidentificationcode VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newattendanceeventcategorydescriptorid INT NULL,
       newattendanceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newattendanceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweducationorganizationid INT NULL,
       neweventdate DATE NULL,
       newinterventionidentificationcode VARCHAR(60) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentinterventionattendanceevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentlearningobjective') THEN
CREATE TABLE tracked_changes_edfi.studentlearningobjective
(
       oldgradingperioddescriptorid INT NOT NULL,
       oldgradingperioddescriptornamespace VARCHAR(255) NOT NULL,
       oldgradingperioddescriptorcodevalue VARCHAR(50) NOT NULL,
       oldgradingperiodschoolid INT NOT NULL,
       oldgradingperiodschoolyear SMALLINT NOT NULL,
       oldgradingperiodsequence INT NOT NULL,
       oldlearningobjectiveid VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newgradingperioddescriptorid INT NULL,
       newgradingperioddescriptornamespace VARCHAR(255) NULL,
       newgradingperioddescriptorcodevalue VARCHAR(50) NULL,
       newgradingperiodschoolid INT NULL,
       newgradingperiodschoolyear SMALLINT NULL,
       newgradingperiodsequence INT NULL,
       newlearningobjectiveid VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentlearningobjective_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentparentassociation') THEN
CREATE TABLE tracked_changes_edfi.studentparentassociation
(
       oldparentusi INT NOT NULL,
       oldparentuniqueid VARCHAR(32) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newparentusi INT NULL,
       newparentuniqueid VARCHAR(32) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentparentassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentprogramattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentprogramattendanceevent
(
       oldattendanceeventcategorydescriptorid INT NOT NULL,
       oldattendanceeventcategorydescriptornamespace VARCHAR(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue VARCHAR(50) NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       oldeventdate DATE NOT NULL,
       oldprogrameducationorganizationid INT NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newattendanceeventcategorydescriptorid INT NULL,
       newattendanceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newattendanceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweducationorganizationid INT NULL,
       neweventdate DATE NULL,
       newprogrameducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentschoolassociation') THEN
CREATE TABLE tracked_changes_edfi.studentschoolassociation
(
       oldentrydate DATE NOT NULL,
       oldschoolid INT NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newentrydate DATE NULL,
       newschoolid INT NULL,
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
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newattendanceeventcategorydescriptorid INT NULL,
       newattendanceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newattendanceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweventdate DATE NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsessionname VARCHAR(60) NULL,
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
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newbegindate DATE NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(60) NULL,
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
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       oldstudentusi INT NOT NULL,
       oldstudentuniqueid VARCHAR(32) NOT NULL,
       newattendanceeventcategorydescriptorid INT NULL,
       newattendanceeventcategorydescriptornamespace VARCHAR(255) NULL,
       newattendanceeventcategorydescriptorcodevalue VARCHAR(50) NULL,
       neweventdate DATE NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(60) NULL,
       newstudentusi INT NULL,
       newstudentuniqueid VARCHAR(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentsectionattendanceevent_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'survey') THEN
CREATE TABLE tracked_changes_edfi.survey
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
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
       oldcoursecode VARCHAR(60) NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       newcoursecode VARCHAR(60) NULL,
       neweducationorganizationid INT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldprogramname VARCHAR(60) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       neweducationorganizationid INT NULL,
       newnamespace VARCHAR(255) NULL,
       newprogramname VARCHAR(60) NULL,
       newprogramtypedescriptorid INT NULL,
       newprogramtypedescriptornamespace VARCHAR(255) NULL,
       newprogramtypedescriptorcodevalue VARCHAR(50) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
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
       oldquestioncode VARCHAR(60) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newquestioncode VARCHAR(60) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
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
       oldquestioncode VARCHAR(60) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newquestioncode VARCHAR(60) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
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
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       neweducationorganizationid INT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponseeducationorganizationtargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyresponsestafftargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveyresponsestafftargetassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
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
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysection_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionassociation
(
       oldlocalcoursecode VARCHAR(60) NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldschoolid INT NOT NULL,
       oldschoolyear SMALLINT NOT NULL,
       oldsectionidentifier VARCHAR(255) NOT NULL,
       oldsessionname VARCHAR(60) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       newlocalcoursecode VARCHAR(60) NULL,
       newnamespace VARCHAR(255) NULL,
       newschoolid INT NULL,
       newschoolyear SMALLINT NULL,
       newsectionidentifier VARCHAR(255) NULL,
       newsessionname VARCHAR(60) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
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
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
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
       oldeducationorganizationid INT NOT NULL,
       oldnamespace VARCHAR(255) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       neweducationorganizationid INT NULL,
       newnamespace VARCHAR(255) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponseeducationorganizationtargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionresponsestafftargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionresponsestafftargetassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldstaffusi INT NOT NULL,
       oldstaffuniqueid VARCHAR(32) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newstaffusi INT NULL,
       newstaffuniqueid VARCHAR(32) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
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
