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
       oldschoolid integer NOT NULL,
       oldweekidentifier varchar(80) NOT NULL,
       newschoolid integer NULL,
       newweekidentifier varchar(80) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT academicweek_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'account') THEN
CREATE TABLE tracked_changes_edfi.account
(
       oldaccountidentifier varchar(50) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldfiscalyear integer NOT NULL,
       newaccountidentifier varchar(50) NULL,
       neweducationorganizationid integer NULL,
       newfiscalyear integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT account_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'accountabilityrating') THEN
CREATE TABLE tracked_changes_edfi.accountabilityrating
(
       oldeducationorganizationid integer NOT NULL,
       oldratingtitle varchar(60) NOT NULL,
       oldschoolyear smallint NOT NULL,
       neweducationorganizationid integer NULL,
       newratingtitle varchar(60) NULL,
       newschoolyear smallint NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT accountabilityrating_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'accountcode') THEN
CREATE TABLE tracked_changes_edfi.accountcode
(
       oldaccountclassificationdescriptorid integer NOT NULL,
       oldaccountclassificationdescriptornamespace varchar(255) NOT NULL,
       oldaccountclassificationdescriptorcodevalue varchar(50) NOT NULL,
       oldaccountcodenumber varchar(50) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldfiscalyear integer NOT NULL,
       newaccountclassificationdescriptorid integer NULL,
       newaccountclassificationdescriptornamespace varchar(255) NULL,
       newaccountclassificationdescriptorcodevalue varchar(50) NULL,
       newaccountcodenumber varchar(50) NULL,
       neweducationorganizationid integer NULL,
       newfiscalyear integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT accountcode_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'actual') THEN
CREATE TABLE tracked_changes_edfi.actual
(
       oldaccountidentifier varchar(50) NOT NULL,
       oldasofdate date NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldfiscalyear integer NOT NULL,
       newaccountidentifier varchar(50) NULL,
       newasofdate date NULL,
       neweducationorganizationid integer NULL,
       newfiscalyear integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT actual_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessment') THEN
CREATE TABLE tracked_changes_edfi.assessment
(
       oldassessmentidentifier varchar(60) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       newassessmentidentifier varchar(60) NULL,
       newnamespace varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessment_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessmentitem') THEN
CREATE TABLE tracked_changes_edfi.assessmentitem
(
       oldassessmentidentifier varchar(60) NOT NULL,
       oldidentificationcode varchar(60) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       newassessmentidentifier varchar(60) NULL,
       newidentificationcode varchar(60) NULL,
       newnamespace varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessmentitem_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'assessmentscorerangelearningstandard') THEN
CREATE TABLE tracked_changes_edfi.assessmentscorerangelearningstandard
(
       oldassessmentidentifier varchar(60) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       oldscorerangeid varchar(60) NOT NULL,
       newassessmentidentifier varchar(60) NULL,
       newnamespace varchar(255) NULL,
       newscorerangeid varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT assessmentscorerangelearningstandard_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'bellschedule') THEN
CREATE TABLE tracked_changes_edfi.bellschedule
(
       oldbellschedulename varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       newbellschedulename varchar(60) NULL,
       newschoolid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT bellschedule_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'budget') THEN
CREATE TABLE tracked_changes_edfi.budget
(
       oldaccountidentifier varchar(50) NOT NULL,
       oldasofdate date NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldfiscalyear integer NOT NULL,
       newaccountidentifier varchar(50) NULL,
       newasofdate date NULL,
       neweducationorganizationid integer NULL,
       newfiscalyear integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT budget_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'calendar') THEN
CREATE TABLE tracked_changes_edfi.calendar
(
       oldcalendarcode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       newcalendarcode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT calendar_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'calendardate') THEN
CREATE TABLE tracked_changes_edfi.calendardate
(
       oldcalendarcode varchar(60) NOT NULL,
       olddate date NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       newcalendarcode varchar(60) NULL,
       newdate date NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT calendardate_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'classperiod') THEN
CREATE TABLE tracked_changes_edfi.classperiod
(
       oldclassperiodname varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       newclassperiodname varchar(60) NULL,
       newschoolid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT classperiod_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'cohort') THEN
CREATE TABLE tracked_changes_edfi.cohort
(
       oldcohortidentifier varchar(20) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       newcohortidentifier varchar(20) NULL,
       neweducationorganizationid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT cohort_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'communityproviderlicense') THEN
CREATE TABLE tracked_changes_edfi.communityproviderlicense
(
       oldcommunityproviderid integer NOT NULL,
       oldlicenseidentifier varchar(20) NOT NULL,
       oldlicensingorganization varchar(75) NOT NULL,
       newcommunityproviderid integer NULL,
       newlicenseidentifier varchar(20) NULL,
       newlicensingorganization varchar(75) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT communityproviderlicense_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'competencyobjective') THEN
CREATE TABLE tracked_changes_edfi.competencyobjective
(
       oldeducationorganizationid integer NOT NULL,
       oldobjective varchar(60) NOT NULL,
       oldobjectivegradeleveldescriptorid integer NOT NULL,
       oldobjectivegradeleveldescriptornamespace varchar(255) NOT NULL,
       oldobjectivegradeleveldescriptorcodevalue varchar(50) NOT NULL,
       neweducationorganizationid integer NULL,
       newobjective varchar(60) NULL,
       newobjectivegradeleveldescriptorid integer NULL,
       newobjectivegradeleveldescriptornamespace varchar(255) NULL,
       newobjectivegradeleveldescriptorcodevalue varchar(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT competencyobjective_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'contractedstaff') THEN
CREATE TABLE tracked_changes_edfi.contractedstaff
(
       oldaccountidentifier varchar(50) NOT NULL,
       oldasofdate date NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldfiscalyear integer NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newaccountidentifier varchar(50) NULL,
       newasofdate date NULL,
       neweducationorganizationid integer NULL,
       newfiscalyear integer NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT contractedstaff_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'course') THEN
CREATE TABLE tracked_changes_edfi.course
(
       oldcoursecode varchar(60) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       newcoursecode varchar(60) NULL,
       neweducationorganizationid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT course_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'courseoffering') THEN
CREATE TABLE tracked_changes_edfi.courseoffering
(
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsessionname varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT courseoffering_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'coursetranscript') THEN
CREATE TABLE tracked_changes_edfi.coursetranscript
(
       oldcourseattemptresultdescriptorid integer NOT NULL,
       oldcourseattemptresultdescriptornamespace varchar(255) NOT NULL,
       oldcourseattemptresultdescriptorcodevalue varchar(50) NOT NULL,
       oldcoursecode varchar(60) NOT NULL,
       oldcourseeducationorganizationid integer NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       oldtermdescriptorid integer NOT NULL,
       oldtermdescriptornamespace varchar(255) NOT NULL,
       oldtermdescriptorcodevalue varchar(50) NOT NULL,
       newcourseattemptresultdescriptorid integer NULL,
       newcourseattemptresultdescriptornamespace varchar(255) NULL,
       newcourseattemptresultdescriptorcodevalue varchar(50) NULL,
       newcoursecode varchar(60) NULL,
       newcourseeducationorganizationid integer NULL,
       neweducationorganizationid integer NULL,
       newschoolyear smallint NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       newtermdescriptorid integer NULL,
       newtermdescriptornamespace varchar(255) NULL,
       newtermdescriptorcodevalue varchar(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT coursetranscript_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'credential') THEN
CREATE TABLE tracked_changes_edfi.credential
(
       oldcredentialidentifier varchar(60) NOT NULL,
       oldstateofissuestateabbreviationdescriptorid integer NOT NULL,
       oldstateofissuestateabbreviationdescriptornamespace varchar(255) NOT NULL,
       oldstateofissuestateabbreviationdescriptorcodevalue varchar(50) NOT NULL,
       newcredentialidentifier varchar(60) NULL,
       newstateofissuestateabbreviationdescriptorid integer NULL,
       newstateofissuestateabbreviationdescriptornamespace varchar(255) NULL,
       newstateofissuestateabbreviationdescriptorcodevalue varchar(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT credential_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'descriptor') THEN
CREATE TABLE tracked_changes_edfi.descriptor
(
       olddescriptorid integer NOT NULL,
       oldcodevalue varchar(50) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       newdescriptorid integer NULL,
       newcodevalue varchar(50) NULL,
       newnamespace varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT descriptor_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'disciplineaction') THEN
CREATE TABLE tracked_changes_edfi.disciplineaction
(
       olddisciplineactionidentifier varchar(20) NOT NULL,
       olddisciplinedate date NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newdisciplineactionidentifier varchar(20) NULL,
       newdisciplinedate date NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT disciplineaction_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'disciplineincident') THEN
CREATE TABLE tracked_changes_edfi.disciplineincident
(
       oldincidentidentifier varchar(20) NOT NULL,
       oldschoolid integer NOT NULL,
       newincidentidentifier varchar(20) NULL,
       newschoolid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT disciplineincident_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationcontent') THEN
CREATE TABLE tracked_changes_edfi.educationcontent
(
       oldcontentidentifier varchar(225) NOT NULL,
       newcontentidentifier varchar(225) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationcontent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganization') THEN
CREATE TABLE tracked_changes_edfi.educationorganization
(
       oldeducationorganizationid integer NOT NULL,
       neweducationorganizationid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganization_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganizationinterventionprescriptionassociation') THEN
CREATE TABLE tracked_changes_edfi.educationorganizationinterventionprescriptionassociation
(
       oldeducationorganizationid integer NOT NULL,
       oldinterventionprescriptioneducationorganizationid integer NOT NULL,
       oldinterventionprescriptionidentificationcode varchar(60) NOT NULL,
       neweducationorganizationid integer NULL,
       newinterventionprescriptioneducationorganizationid integer NULL,
       newinterventionprescriptionidentificationcode varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganizationinterventionprescriptionassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganizationnetworkassociation') THEN
CREATE TABLE tracked_changes_edfi.educationorganizationnetworkassociation
(
       oldeducationorganizationnetworkid integer NOT NULL,
       oldmembereducationorganizationid integer NOT NULL,
       neweducationorganizationnetworkid integer NULL,
       newmembereducationorganizationid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganizationnetworkassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'educationorganizationpeerassociation') THEN
CREATE TABLE tracked_changes_edfi.educationorganizationpeerassociation
(
       oldeducationorganizationid integer NOT NULL,
       oldpeereducationorganizationid integer NOT NULL,
       neweducationorganizationid integer NULL,
       newpeereducationorganizationid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT educationorganizationpeerassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'feederschoolassociation') THEN
CREATE TABLE tracked_changes_edfi.feederschoolassociation
(
       oldbegindate date NOT NULL,
       oldfeederschoolid integer NOT NULL,
       oldschoolid integer NOT NULL,
       newbegindate date NULL,
       newfeederschoolid integer NULL,
       newschoolid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT feederschoolassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'generalstudentprogramassociation') THEN
CREATE TABLE tracked_changes_edfi.generalstudentprogramassociation
(
       oldbegindate date NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldprogrameducationorganizationid integer NOT NULL,
       oldprogramname varchar(60) NOT NULL,
       oldprogramtypedescriptorid integer NOT NULL,
       oldprogramtypedescriptornamespace varchar(255) NOT NULL,
       oldprogramtypedescriptorcodevalue varchar(50) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       neweducationorganizationid integer NULL,
       newprogrameducationorganizationid integer NULL,
       newprogramname varchar(60) NULL,
       newprogramtypedescriptorid integer NULL,
       newprogramtypedescriptornamespace varchar(255) NULL,
       newprogramtypedescriptorcodevalue varchar(50) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT generalstudentprogramassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'grade') THEN
CREATE TABLE tracked_changes_edfi.grade
(
       oldbegindate date NOT NULL,
       oldgradetypedescriptorid integer NOT NULL,
       oldgradetypedescriptornamespace varchar(255) NOT NULL,
       oldgradetypedescriptorcodevalue varchar(50) NOT NULL,
       oldgradingperioddescriptorid integer NOT NULL,
       oldgradingperioddescriptornamespace varchar(255) NOT NULL,
       oldgradingperioddescriptorcodevalue varchar(50) NOT NULL,
       oldgradingperiodschoolyear smallint NOT NULL,
       oldgradingperiodsequence integer NOT NULL,
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       newgradetypedescriptorid integer NULL,
       newgradetypedescriptornamespace varchar(255) NULL,
       newgradetypedescriptorcodevalue varchar(50) NULL,
       newgradingperioddescriptorid integer NULL,
       newgradingperioddescriptornamespace varchar(255) NULL,
       newgradingperioddescriptorcodevalue varchar(50) NULL,
       newgradingperiodschoolyear smallint NULL,
       newgradingperiodsequence integer NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT grade_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'gradebookentry') THEN
CREATE TABLE tracked_changes_edfi.gradebookentry
(
       olddateassigned date NOT NULL,
       oldgradebookentrytitle varchar(60) NOT NULL,
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       newdateassigned date NULL,
       newgradebookentrytitle varchar(60) NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT gradebookentry_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'gradingperiod') THEN
CREATE TABLE tracked_changes_edfi.gradingperiod
(
       oldgradingperioddescriptorid integer NOT NULL,
       oldgradingperioddescriptornamespace varchar(255) NOT NULL,
       oldgradingperioddescriptorcodevalue varchar(50) NOT NULL,
       oldperiodsequence integer NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       newgradingperioddescriptorid integer NULL,
       newgradingperioddescriptornamespace varchar(255) NULL,
       newgradingperioddescriptorcodevalue varchar(50) NULL,
       newperiodsequence integer NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT gradingperiod_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'graduationplan') THEN
CREATE TABLE tracked_changes_edfi.graduationplan
(
       oldeducationorganizationid integer NOT NULL,
       oldgraduationplantypedescriptorid integer NOT NULL,
       oldgraduationplantypedescriptornamespace varchar(255) NOT NULL,
       oldgraduationplantypedescriptorcodevalue varchar(50) NOT NULL,
       oldgraduationschoolyear smallint NOT NULL,
       neweducationorganizationid integer NULL,
       newgraduationplantypedescriptorid integer NULL,
       newgraduationplantypedescriptornamespace varchar(255) NULL,
       newgraduationplantypedescriptorcodevalue varchar(50) NULL,
       newgraduationschoolyear smallint NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT graduationplan_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'intervention') THEN
CREATE TABLE tracked_changes_edfi.intervention
(
       oldeducationorganizationid integer NOT NULL,
       oldinterventionidentificationcode varchar(60) NOT NULL,
       neweducationorganizationid integer NULL,
       newinterventionidentificationcode varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT intervention_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'interventionprescription') THEN
CREATE TABLE tracked_changes_edfi.interventionprescription
(
       oldeducationorganizationid integer NOT NULL,
       oldinterventionprescriptionidentificationcode varchar(60) NOT NULL,
       neweducationorganizationid integer NULL,
       newinterventionprescriptionidentificationcode varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT interventionprescription_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'interventionstudy') THEN
CREATE TABLE tracked_changes_edfi.interventionstudy
(
       oldeducationorganizationid integer NOT NULL,
       oldinterventionstudyidentificationcode varchar(60) NOT NULL,
       neweducationorganizationid integer NULL,
       newinterventionstudyidentificationcode varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT interventionstudy_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'learningobjective') THEN
CREATE TABLE tracked_changes_edfi.learningobjective
(
       oldlearningobjectiveid varchar(60) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       newlearningobjectiveid varchar(60) NULL,
       newnamespace varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT learningobjective_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'learningstandard') THEN
CREATE TABLE tracked_changes_edfi.learningstandard
(
       oldlearningstandardid varchar(60) NOT NULL,
       newlearningstandardid varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT learningstandard_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'learningstandardequivalenceassociation') THEN
CREATE TABLE tracked_changes_edfi.learningstandardequivalenceassociation
(
       oldnamespace varchar(255) NOT NULL,
       oldsourcelearningstandardid varchar(60) NOT NULL,
       oldtargetlearningstandardid varchar(60) NOT NULL,
       newnamespace varchar(255) NULL,
       newsourcelearningstandardid varchar(60) NULL,
       newtargetlearningstandardid varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT learningstandardequivalenceassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'location') THEN
CREATE TABLE tracked_changes_edfi.location
(
       oldclassroomidentificationcode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       newclassroomidentificationcode varchar(60) NULL,
       newschoolid integer NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT location_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'objectiveassessment') THEN
CREATE TABLE tracked_changes_edfi.objectiveassessment
(
       oldassessmentidentifier varchar(60) NOT NULL,
       oldidentificationcode varchar(60) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       newassessmentidentifier varchar(60) NULL,
       newidentificationcode varchar(60) NULL,
       newnamespace varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT objectiveassessment_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'openstaffposition') THEN
CREATE TABLE tracked_changes_edfi.openstaffposition
(
       oldeducationorganizationid integer NOT NULL,
       oldrequisitionnumber varchar(20) NOT NULL,
       neweducationorganizationid integer NULL,
       newrequisitionnumber varchar(20) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT openstaffposition_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'parent') THEN
CREATE TABLE tracked_changes_edfi.parent
(
       oldparentusi integer NOT NULL,
       oldparentuniqueid varchar(32) NOT NULL,
       newparentusi integer NULL,
       newparentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT parent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'payroll') THEN
CREATE TABLE tracked_changes_edfi.payroll
(
       oldaccountidentifier varchar(50) NOT NULL,
       oldasofdate date NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldfiscalyear integer NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newaccountidentifier varchar(50) NULL,
       newasofdate date NULL,
       neweducationorganizationid integer NULL,
       newfiscalyear integer NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT payroll_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'person') THEN
CREATE TABLE tracked_changes_edfi.person
(
       oldpersonid varchar(32) NOT NULL,
       oldsourcesystemdescriptorid integer NOT NULL,
       oldsourcesystemdescriptornamespace varchar(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue varchar(50) NOT NULL,
       newpersonid varchar(32) NULL,
       newsourcesystemdescriptorid integer NULL,
       newsourcesystemdescriptornamespace varchar(255) NULL,
       newsourcesystemdescriptorcodevalue varchar(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT person_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'postsecondaryevent') THEN
CREATE TABLE tracked_changes_edfi.postsecondaryevent
(
       oldeventdate date NOT NULL,
       oldpostsecondaryeventcategorydescriptorid integer NOT NULL,
       oldpostsecondaryeventcategorydescriptornamespace varchar(255) NOT NULL,
       oldpostsecondaryeventcategorydescriptorcodevalue varchar(50) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       neweventdate date NULL,
       newpostsecondaryeventcategorydescriptorid integer NULL,
       newpostsecondaryeventcategorydescriptornamespace varchar(255) NULL,
       newpostsecondaryeventcategorydescriptorcodevalue varchar(50) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT postsecondaryevent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'program') THEN
CREATE TABLE tracked_changes_edfi.program
(
       oldeducationorganizationid integer NOT NULL,
       oldprogramname varchar(60) NOT NULL,
       oldprogramtypedescriptorid integer NOT NULL,
       oldprogramtypedescriptornamespace varchar(255) NOT NULL,
       oldprogramtypedescriptorcodevalue varchar(50) NOT NULL,
       neweducationorganizationid integer NULL,
       newprogramname varchar(60) NULL,
       newprogramtypedescriptorid integer NULL,
       newprogramtypedescriptornamespace varchar(255) NULL,
       newprogramtypedescriptorcodevalue varchar(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT program_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'reportcard') THEN
CREATE TABLE tracked_changes_edfi.reportcard
(
       oldeducationorganizationid integer NOT NULL,
       oldgradingperioddescriptorid integer NOT NULL,
       oldgradingperioddescriptornamespace varchar(255) NOT NULL,
       oldgradingperioddescriptorcodevalue varchar(50) NOT NULL,
       oldgradingperiodschoolid integer NOT NULL,
       oldgradingperiodschoolyear smallint NOT NULL,
       oldgradingperiodsequence integer NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       neweducationorganizationid integer NULL,
       newgradingperioddescriptorid integer NULL,
       newgradingperioddescriptornamespace varchar(255) NULL,
       newgradingperioddescriptorcodevalue varchar(50) NULL,
       newgradingperiodschoolid integer NULL,
       newgradingperiodschoolyear smallint NULL,
       newgradingperiodsequence integer NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT reportcard_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'restraintevent') THEN
CREATE TABLE tracked_changes_edfi.restraintevent
(
       oldrestrainteventidentifier varchar(20) NOT NULL,
       oldschoolid integer NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newrestrainteventidentifier varchar(20) NULL,
       newschoolid integer NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT restraintevent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'schoolyeartype') THEN
CREATE TABLE tracked_changes_edfi.schoolyeartype
(
       oldschoolyear smallint NOT NULL,
       newschoolyear smallint NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT schoolyeartype_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'section') THEN
CREATE TABLE tracked_changes_edfi.section
(
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT section_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'sectionattendancetakenevent') THEN
CREATE TABLE tracked_changes_edfi.sectionattendancetakenevent
(
       oldcalendarcode varchar(60) NOT NULL,
       olddate date NOT NULL,
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       newcalendarcode varchar(60) NULL,
       newdate date NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT sectionattendancetakenevent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'session') THEN
CREATE TABLE tracked_changes_edfi.session
(
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsessionname varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT session_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staff') THEN
CREATE TABLE tracked_changes_edfi.staff
(
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staff_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffabsenceevent') THEN
CREATE TABLE tracked_changes_edfi.staffabsenceevent
(
       oldabsenceeventcategorydescriptorid integer NOT NULL,
       oldabsenceeventcategorydescriptornamespace varchar(255) NOT NULL,
       oldabsenceeventcategorydescriptorcodevalue varchar(50) NOT NULL,
       oldeventdate date NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newabsenceeventcategorydescriptorid integer NULL,
       newabsenceeventcategorydescriptornamespace varchar(255) NULL,
       newabsenceeventcategorydescriptorcodevalue varchar(50) NULL,
       neweventdate date NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffabsenceevent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffcohortassociation') THEN
CREATE TABLE tracked_changes_edfi.staffcohortassociation
(
       oldbegindate date NOT NULL,
       oldcohortidentifier varchar(20) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       newcohortidentifier varchar(20) NULL,
       neweducationorganizationid integer NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffcohortassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffdisciplineincidentassociation') THEN
CREATE TABLE tracked_changes_edfi.staffdisciplineincidentassociation
(
       oldincidentidentifier varchar(20) NOT NULL,
       oldschoolid integer NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newincidentidentifier varchar(20) NULL,
       newschoolid integer NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffdisciplineincidentassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffeducationorganizationassignmentassociation') THEN
CREATE TABLE tracked_changes_edfi.staffeducationorganizationassignmentassociation
(
       oldbegindate date NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldstaffclassificationdescriptorid integer NOT NULL,
       oldstaffclassificationdescriptornamespace varchar(255) NOT NULL,
       oldstaffclassificationdescriptorcodevalue varchar(50) NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       neweducationorganizationid integer NULL,
       newstaffclassificationdescriptorid integer NULL,
       newstaffclassificationdescriptornamespace varchar(255) NULL,
       newstaffclassificationdescriptorcodevalue varchar(50) NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffeducationorganizationassignmentassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffeducationorganizationcontactassociation') THEN
CREATE TABLE tracked_changes_edfi.staffeducationorganizationcontactassociation
(
       oldcontacttitle varchar(75) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newcontacttitle varchar(75) NULL,
       neweducationorganizationid integer NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffeducationorganizationcontactassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffeducationorganizationemploymentassociation') THEN
CREATE TABLE tracked_changes_edfi.staffeducationorganizationemploymentassociation
(
       oldeducationorganizationid integer NOT NULL,
       oldemploymentstatusdescriptorid integer NOT NULL,
       oldemploymentstatusdescriptornamespace varchar(255) NOT NULL,
       oldemploymentstatusdescriptorcodevalue varchar(50) NOT NULL,
       oldhiredate date NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       neweducationorganizationid integer NULL,
       newemploymentstatusdescriptorid integer NULL,
       newemploymentstatusdescriptornamespace varchar(255) NULL,
       newemploymentstatusdescriptorcodevalue varchar(50) NULL,
       newhiredate date NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffeducationorganizationemploymentassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffleave') THEN
CREATE TABLE tracked_changes_edfi.staffleave
(
       oldbegindate date NOT NULL,
       oldstaffleaveeventcategorydescriptorid integer NOT NULL,
       oldstaffleaveeventcategorydescriptornamespace varchar(255) NOT NULL,
       oldstaffleaveeventcategorydescriptorcodevalue varchar(50) NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       newstaffleaveeventcategorydescriptorid integer NULL,
       newstaffleaveeventcategorydescriptornamespace varchar(255) NULL,
       newstaffleaveeventcategorydescriptorcodevalue varchar(50) NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffleave_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffprogramassociation') THEN
CREATE TABLE tracked_changes_edfi.staffprogramassociation
(
       oldbegindate date NOT NULL,
       oldprogrameducationorganizationid integer NOT NULL,
       oldprogramname varchar(60) NOT NULL,
       oldprogramtypedescriptorid integer NOT NULL,
       oldprogramtypedescriptornamespace varchar(255) NOT NULL,
       oldprogramtypedescriptorcodevalue varchar(50) NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       newprogrameducationorganizationid integer NULL,
       newprogramname varchar(60) NULL,
       newprogramtypedescriptorid integer NULL,
       newprogramtypedescriptornamespace varchar(255) NULL,
       newprogramtypedescriptorcodevalue varchar(50) NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffprogramassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffschoolassociation') THEN
CREATE TABLE tracked_changes_edfi.staffschoolassociation
(
       oldprogramassignmentdescriptorid integer NOT NULL,
       oldprogramassignmentdescriptornamespace varchar(255) NOT NULL,
       oldprogramassignmentdescriptorcodevalue varchar(50) NOT NULL,
       oldschoolid integer NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newprogramassignmentdescriptorid integer NULL,
       newprogramassignmentdescriptornamespace varchar(255) NULL,
       newprogramassignmentdescriptorcodevalue varchar(50) NULL,
       newschoolid integer NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffschoolassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'staffsectionassociation') THEN
CREATE TABLE tracked_changes_edfi.staffsectionassociation
(
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT staffsectionassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'student') THEN
CREATE TABLE tracked_changes_edfi.student
(
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT student_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentacademicrecord') THEN
CREATE TABLE tracked_changes_edfi.studentacademicrecord
(
       oldeducationorganizationid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       oldtermdescriptorid integer NOT NULL,
       oldtermdescriptornamespace varchar(255) NOT NULL,
       oldtermdescriptorcodevalue varchar(50) NOT NULL,
       neweducationorganizationid integer NULL,
       newschoolyear smallint NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       newtermdescriptorid integer NULL,
       newtermdescriptornamespace varchar(255) NULL,
       newtermdescriptorcodevalue varchar(50) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentacademicrecord_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentassessment') THEN
CREATE TABLE tracked_changes_edfi.studentassessment
(
       oldassessmentidentifier varchar(60) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       oldstudentassessmentidentifier varchar(60) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newassessmentidentifier varchar(60) NULL,
       newnamespace varchar(255) NULL,
       newstudentassessmentidentifier varchar(60) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentassessment_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentcohortassociation') THEN
CREATE TABLE tracked_changes_edfi.studentcohortassociation
(
       oldbegindate date NOT NULL,
       oldcohortidentifier varchar(20) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       newcohortidentifier varchar(20) NULL,
       neweducationorganizationid integer NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentcohortassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentcompetencyobjective') THEN
CREATE TABLE tracked_changes_edfi.studentcompetencyobjective
(
       oldgradingperioddescriptorid integer NOT NULL,
       oldgradingperioddescriptornamespace varchar(255) NOT NULL,
       oldgradingperioddescriptorcodevalue varchar(50) NOT NULL,
       oldgradingperiodschoolid integer NOT NULL,
       oldgradingperiodschoolyear smallint NOT NULL,
       oldgradingperiodsequence integer NOT NULL,
       oldobjective varchar(60) NOT NULL,
       oldobjectiveeducationorganizationid integer NOT NULL,
       oldobjectivegradeleveldescriptorid integer NOT NULL,
       oldobjectivegradeleveldescriptornamespace varchar(255) NOT NULL,
       oldobjectivegradeleveldescriptorcodevalue varchar(50) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newgradingperioddescriptorid integer NULL,
       newgradingperioddescriptornamespace varchar(255) NULL,
       newgradingperioddescriptorcodevalue varchar(50) NULL,
       newgradingperiodschoolid integer NULL,
       newgradingperiodschoolyear smallint NULL,
       newgradingperiodsequence integer NULL,
       newobjective varchar(60) NULL,
       newobjectiveeducationorganizationid integer NULL,
       newobjectivegradeleveldescriptorid integer NULL,
       newobjectivegradeleveldescriptornamespace varchar(255) NULL,
       newobjectivegradeleveldescriptorcodevalue varchar(50) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentcompetencyobjective_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdisciplineincidentassociation') THEN
CREATE TABLE tracked_changes_edfi.studentdisciplineincidentassociation
(
       oldincidentidentifier varchar(20) NOT NULL,
       oldschoolid integer NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newincidentidentifier varchar(20) NULL,
       newschoolid integer NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdisciplineincidentassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdisciplineincidentbehaviorassociation') THEN
CREATE TABLE tracked_changes_edfi.studentdisciplineincidentbehaviorassociation
(
       oldbehaviordescriptorid integer NOT NULL,
       oldbehaviordescriptornamespace varchar(255) NOT NULL,
       oldbehaviordescriptorcodevalue varchar(50) NOT NULL,
       oldincidentidentifier varchar(20) NOT NULL,
       oldschoolid integer NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newbehaviordescriptorid integer NULL,
       newbehaviordescriptornamespace varchar(255) NULL,
       newbehaviordescriptorcodevalue varchar(50) NULL,
       newincidentidentifier varchar(20) NULL,
       newschoolid integer NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdisciplineincidentbehaviorassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentdisciplineincidentnonoffenderassociation') THEN
CREATE TABLE tracked_changes_edfi.studentdisciplineincidentnonoffenderassociation
(
       oldincidentidentifier varchar(20) NOT NULL,
       oldschoolid integer NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newincidentidentifier varchar(20) NULL,
       newschoolid integer NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentdisciplineincidentnonoffenderassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studenteducationorganizationassociation') THEN
CREATE TABLE tracked_changes_edfi.studenteducationorganizationassociation
(
       oldeducationorganizationid integer NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       neweducationorganizationid integer NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studenteducationorganizationassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studenteducationorganizationresponsibilityassociation') THEN
CREATE TABLE tracked_changes_edfi.studenteducationorganizationresponsibilityassociation
(
       oldbegindate date NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldresponsibilitydescriptorid integer NOT NULL,
       oldresponsibilitydescriptornamespace varchar(255) NOT NULL,
       oldresponsibilitydescriptorcodevalue varchar(50) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       neweducationorganizationid integer NULL,
       newresponsibilitydescriptorid integer NULL,
       newresponsibilitydescriptornamespace varchar(255) NULL,
       newresponsibilitydescriptorcodevalue varchar(50) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studenteducationorganizationresponsibilityassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentgradebookentry') THEN
CREATE TABLE tracked_changes_edfi.studentgradebookentry
(
       oldbegindate date NOT NULL,
       olddateassigned date NOT NULL,
       oldgradebookentrytitle varchar(60) NOT NULL,
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       newdateassigned date NULL,
       newgradebookentrytitle varchar(60) NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentgradebookentry_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentinterventionassociation') THEN
CREATE TABLE tracked_changes_edfi.studentinterventionassociation
(
       oldeducationorganizationid integer NOT NULL,
       oldinterventionidentificationcode varchar(60) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       neweducationorganizationid integer NULL,
       newinterventionidentificationcode varchar(60) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentinterventionassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentinterventionattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentinterventionattendanceevent
(
       oldattendanceeventcategorydescriptorid integer NOT NULL,
       oldattendanceeventcategorydescriptornamespace varchar(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue varchar(50) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldeventdate date NOT NULL,
       oldinterventionidentificationcode varchar(60) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newattendanceeventcategorydescriptorid integer NULL,
       newattendanceeventcategorydescriptornamespace varchar(255) NULL,
       newattendanceeventcategorydescriptorcodevalue varchar(50) NULL,
       neweducationorganizationid integer NULL,
       neweventdate date NULL,
       newinterventionidentificationcode varchar(60) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentinterventionattendanceevent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentlearningobjective') THEN
CREATE TABLE tracked_changes_edfi.studentlearningobjective
(
       oldgradingperioddescriptorid integer NOT NULL,
       oldgradingperioddescriptornamespace varchar(255) NOT NULL,
       oldgradingperioddescriptorcodevalue varchar(50) NOT NULL,
       oldgradingperiodschoolid integer NOT NULL,
       oldgradingperiodschoolyear smallint NOT NULL,
       oldgradingperiodsequence integer NOT NULL,
       oldlearningobjectiveid varchar(60) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newgradingperioddescriptorid integer NULL,
       newgradingperioddescriptornamespace varchar(255) NULL,
       newgradingperioddescriptorcodevalue varchar(50) NULL,
       newgradingperiodschoolid integer NULL,
       newgradingperiodschoolyear smallint NULL,
       newgradingperiodsequence integer NULL,
       newlearningobjectiveid varchar(60) NULL,
       newnamespace varchar(255) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentlearningobjective_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentparentassociation') THEN
CREATE TABLE tracked_changes_edfi.studentparentassociation
(
       oldparentusi integer NOT NULL,
       oldparentuniqueid varchar(32) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newparentusi integer NULL,
       newparentuniqueid varchar(32) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentparentassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentprogramattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentprogramattendanceevent
(
       oldattendanceeventcategorydescriptorid integer NOT NULL,
       oldattendanceeventcategorydescriptornamespace varchar(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue varchar(50) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldeventdate date NOT NULL,
       oldprogrameducationorganizationid integer NOT NULL,
       oldprogramname varchar(60) NOT NULL,
       oldprogramtypedescriptorid integer NOT NULL,
       oldprogramtypedescriptornamespace varchar(255) NOT NULL,
       oldprogramtypedescriptorcodevalue varchar(50) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newattendanceeventcategorydescriptorid integer NULL,
       newattendanceeventcategorydescriptornamespace varchar(255) NULL,
       newattendanceeventcategorydescriptorcodevalue varchar(50) NULL,
       neweducationorganizationid integer NULL,
       neweventdate date NULL,
       newprogrameducationorganizationid integer NULL,
       newprogramname varchar(60) NULL,
       newprogramtypedescriptorid integer NULL,
       newprogramtypedescriptornamespace varchar(255) NULL,
       newprogramtypedescriptorcodevalue varchar(50) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentprogramattendanceevent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentschoolassociation') THEN
CREATE TABLE tracked_changes_edfi.studentschoolassociation
(
       oldentrydate date NOT NULL,
       oldschoolid integer NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newentrydate date NULL,
       newschoolid integer NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentschoolassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentschoolattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentschoolattendanceevent
(
       oldattendanceeventcategorydescriptorid integer NOT NULL,
       oldattendanceeventcategorydescriptornamespace varchar(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue varchar(50) NOT NULL,
       oldeventdate date NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newattendanceeventcategorydescriptorid integer NULL,
       newattendanceeventcategorydescriptornamespace varchar(255) NULL,
       newattendanceeventcategorydescriptorcodevalue varchar(50) NULL,
       neweventdate date NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsessionname varchar(60) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentschoolattendanceevent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentsectionassociation') THEN
CREATE TABLE tracked_changes_edfi.studentsectionassociation
(
       oldbegindate date NOT NULL,
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newbegindate date NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentsectionassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'studentsectionattendanceevent') THEN
CREATE TABLE tracked_changes_edfi.studentsectionattendanceevent
(
       oldattendanceeventcategorydescriptorid integer NOT NULL,
       oldattendanceeventcategorydescriptornamespace varchar(255) NOT NULL,
       oldattendanceeventcategorydescriptorcodevalue varchar(50) NOT NULL,
       oldeventdate date NOT NULL,
       oldlocalcoursecode varchar(60) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       oldstudentusi integer NOT NULL,
       oldstudentuniqueid varchar(32) NOT NULL,
       newattendanceeventcategorydescriptorid integer NULL,
       newattendanceeventcategorydescriptornamespace varchar(255) NULL,
       newattendanceeventcategorydescriptorcodevalue varchar(50) NULL,
       neweventdate date NULL,
       newlocalcoursecode varchar(60) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       newstudentusi integer NULL,
       newstudentuniqueid varchar(32) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT studentsectionattendanceevent_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'survey') THEN
CREATE TABLE tracked_changes_edfi.survey
(
       oldnamespace varchar(255) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       newnamespace varchar(255) NULL,
       newsurveyidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT survey_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveycourseassociation') THEN
CREATE TABLE tracked_changes_edfi.surveycourseassociation
(
       oldcoursecode varchar(60) NOT NULL,
       oldeducationorganizationid integer NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       newcoursecode varchar(60) NULL,
       neweducationorganizationid integer NULL,
       newnamespace varchar(255) NULL,
       newsurveyidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveycourseassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyprogramassociation') THEN
CREATE TABLE tracked_changes_edfi.surveyprogramassociation
(
       oldeducationorganizationid integer NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       oldprogramname varchar(60) NOT NULL,
       oldprogramtypedescriptorid integer NOT NULL,
       oldprogramtypedescriptornamespace varchar(255) NOT NULL,
       oldprogramtypedescriptorcodevalue varchar(50) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       neweducationorganizationid integer NULL,
       newnamespace varchar(255) NULL,
       newprogramname varchar(60) NULL,
       newprogramtypedescriptorid integer NULL,
       newprogramtypedescriptornamespace varchar(255) NULL,
       newprogramtypedescriptorcodevalue varchar(50) NULL,
       newsurveyidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyprogramassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyquestion') THEN
CREATE TABLE tracked_changes_edfi.surveyquestion
(
       oldnamespace varchar(255) NOT NULL,
       oldquestioncode varchar(60) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       newnamespace varchar(255) NULL,
       newquestioncode varchar(60) NULL,
       newsurveyidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyquestion_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyquestionresponse') THEN
CREATE TABLE tracked_changes_edfi.surveyquestionresponse
(
       oldnamespace varchar(255) NOT NULL,
       oldquestioncode varchar(60) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       oldsurveyresponseidentifier varchar(60) NOT NULL,
       newnamespace varchar(255) NULL,
       newquestioncode varchar(60) NULL,
       newsurveyidentifier varchar(60) NULL,
       newsurveyresponseidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyquestionresponse_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyresponse') THEN
CREATE TABLE tracked_changes_edfi.surveyresponse
(
       oldnamespace varchar(255) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       oldsurveyresponseidentifier varchar(60) NOT NULL,
       newnamespace varchar(255) NULL,
       newsurveyidentifier varchar(60) NULL,
       newsurveyresponseidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponse_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyresponseeducationorganizationtargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveyresponseeducationorganizationtargetassociation
(
       oldeducationorganizationid integer NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       oldsurveyresponseidentifier varchar(60) NOT NULL,
       neweducationorganizationid integer NULL,
       newnamespace varchar(255) NULL,
       newsurveyidentifier varchar(60) NULL,
       newsurveyresponseidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponseeducationorganizationtargetassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveyresponsestafftargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveyresponsestafftargetassociation
(
       oldnamespace varchar(255) NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       oldsurveyresponseidentifier varchar(60) NOT NULL,
       newnamespace varchar(255) NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       newsurveyidentifier varchar(60) NULL,
       newsurveyresponseidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponsestafftargetassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysection') THEN
CREATE TABLE tracked_changes_edfi.surveysection
(
       oldnamespace varchar(255) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       oldsurveysectiontitle varchar(255) NOT NULL,
       newnamespace varchar(255) NULL,
       newsurveyidentifier varchar(60) NULL,
       newsurveysectiontitle varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysection_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionassociation
(
       oldlocalcoursecode varchar(60) NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       oldschoolid integer NOT NULL,
       oldschoolyear smallint NOT NULL,
       oldsectionidentifier varchar(255) NOT NULL,
       oldsessionname varchar(60) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       newlocalcoursecode varchar(60) NULL,
       newnamespace varchar(255) NULL,
       newschoolid integer NULL,
       newschoolyear smallint NULL,
       newsectionidentifier varchar(255) NULL,
       newsessionname varchar(60) NULL,
       newsurveyidentifier varchar(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionresponse') THEN
CREATE TABLE tracked_changes_edfi.surveysectionresponse
(
       oldnamespace varchar(255) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       oldsurveyresponseidentifier varchar(60) NOT NULL,
       oldsurveysectiontitle varchar(255) NOT NULL,
       newnamespace varchar(255) NULL,
       newsurveyidentifier varchar(60) NULL,
       newsurveyresponseidentifier varchar(60) NULL,
       newsurveysectiontitle varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponse_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionresponseeducationorganizationtargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionresponseeducationorganizationtargetassociation
(
       oldeducationorganizationid integer NOT NULL,
       oldnamespace varchar(255) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       oldsurveyresponseidentifier varchar(60) NOT NULL,
       oldsurveysectiontitle varchar(255) NOT NULL,
       neweducationorganizationid integer NULL,
       newnamespace varchar(255) NULL,
       newsurveyidentifier varchar(60) NULL,
       newsurveyresponseidentifier varchar(60) NULL,
       newsurveysectiontitle varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponseeducationorganizationtargetassociation_pk PRIMARY KEY (changeversion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_edfi' AND table_name = 'surveysectionresponsestafftargetassociation') THEN
CREATE TABLE tracked_changes_edfi.surveysectionresponsestafftargetassociation
(
       oldnamespace varchar(255) NOT NULL,
       oldstaffusi integer NOT NULL,
       oldstaffuniqueid varchar(32) NOT NULL,
       oldsurveyidentifier varchar(60) NOT NULL,
       oldsurveyresponseidentifier varchar(60) NOT NULL,
       oldsurveysectiontitle varchar(255) NOT NULL,
       newnamespace varchar(255) NULL,
       newstaffusi integer NULL,
       newstaffuniqueid varchar(32) NULL,
       newsurveyidentifier varchar(60) NULL,
       newsurveyresponseidentifier varchar(60) NULL,
       newsurveysectiontitle varchar(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponsestafftargetassociation_pk PRIMARY KEY (changeversion)
);
END IF;

END
$$;