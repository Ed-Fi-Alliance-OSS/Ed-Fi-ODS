-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM information_schema.schemata WHERE schema_name = 'tracked_changes_tpdm') THEN
CREATE SCHEMA tracked_changes_edfi;
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'candidate') THEN
CREATE TABLE tracked_changes_tpdm.candidate
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'candidateeducatorpreparationprogramassociation') THEN
CREATE TABLE tracked_changes_tpdm.candidateeducatorpreparationprogramassociation
(
       oldbegindate DATE NOT NULL,
       oldcandidateidentifier VARCHAR(32) NOT NULL,
       oldeducationorganizationid INT NOT NULL,
       oldprogramname VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       newbegindate DATE NULL,
       newcandidateidentifier VARCHAR(32) NULL,
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'educatorpreparationprogram') THEN
CREATE TABLE tracked_changes_tpdm.educatorpreparationprogram
(
       oldeducationorganizationid INT NOT NULL,
       oldprogramname VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorid INT NOT NULL,
       oldprogramtypedescriptornamespace VARCHAR(255) NOT NULL,
       oldprogramtypedescriptorcodevalue VARCHAR(50) NOT NULL,
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'evaluation') THEN
CREATE TABLE tracked_changes_tpdm.evaluation
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'evaluationelement') THEN
CREATE TABLE tracked_changes_tpdm.evaluationelement
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'evaluationelementrating') THEN
CREATE TABLE tracked_changes_tpdm.evaluationelementrating
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'evaluationobjective') THEN
CREATE TABLE tracked_changes_tpdm.evaluationobjective
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'evaluationobjectiverating') THEN
CREATE TABLE tracked_changes_tpdm.evaluationobjectiverating
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'evaluationrating') THEN
CREATE TABLE tracked_changes_tpdm.evaluationrating
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'financialaid') THEN
CREATE TABLE tracked_changes_tpdm.financialaid
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'performanceevaluation') THEN
CREATE TABLE tracked_changes_tpdm.performanceevaluation
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'performanceevaluationrating') THEN
CREATE TABLE tracked_changes_tpdm.performanceevaluationrating
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'rubricdimension') THEN
CREATE TABLE tracked_changes_tpdm.rubricdimension
(
       oldeducationorganizationid INT NOT NULL,
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
       neweducationorganizationid INT NULL,
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

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'surveyresponsepersontargetassociation') THEN
CREATE TABLE tracked_changes_tpdm.surveyresponsepersontargetassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newpersonid VARCHAR(32) NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveyresponsepersontargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

IF NOT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'tracked_changes_tpdm' AND table_name = 'surveysectionresponsepersontargetassociation') THEN
CREATE TABLE tracked_changes_tpdm.surveysectionresponsepersontargetassociation
(
       oldnamespace VARCHAR(255) NOT NULL,
       oldpersonid VARCHAR(32) NOT NULL,
       oldsourcesystemdescriptorid INT NOT NULL,
       oldsourcesystemdescriptornamespace VARCHAR(255) NOT NULL,
       oldsourcesystemdescriptorcodevalue VARCHAR(50) NOT NULL,
       oldsurveyidentifier VARCHAR(60) NOT NULL,
       oldsurveyresponseidentifier VARCHAR(60) NOT NULL,
       oldsurveysectiontitle VARCHAR(255) NOT NULL,
       newnamespace VARCHAR(255) NULL,
       newpersonid VARCHAR(32) NULL,
       newsourcesystemdescriptorid INT NULL,
       newsourcesystemdescriptornamespace VARCHAR(255) NULL,
       newsourcesystemdescriptorcodevalue VARCHAR(50) NULL,
       newsurveyidentifier VARCHAR(60) NULL,
       newsurveyresponseidentifier VARCHAR(60) NULL,
       newsurveysectiontitle VARCHAR(255) NULL,
       id uuid NOT NULL,
       changeversion bigint NOT NULL,
       discriminator varchar(128) NULL,
       createdate timestamp NOT NULL DEFAULT (now()),
       CONSTRAINT surveysectionresponsepersontargetassociation_pk PRIMARY KEY (ChangeVersion)
);
END IF;

END
$$;
