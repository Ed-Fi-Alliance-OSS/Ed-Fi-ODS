-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE dbo.aspnetroles ( 
  "id" varchar(128) NOT NULL,
  "name" varchar(256) NOT NULL,
  PRIMARY KEY ("id")
);

CREATE TABLE dbo.aspnetusers (
  "id" character varying(128) NOT NULL,
  "username" character varying(256) NOT NULL,
  "passwordhash" character varying(256),
  "securitystamp" character varying(256),
  "email" character varying(256) DEFAULT NULL::character varying,
  "emailconfirmed" boolean NOT NULL DEFAULT false,
  "phonenumber" character varying(256),
  "phonenumberconfirmed" boolean NOT NULL DEFAULT false,
  "twofactorenabled" boolean NOT NULL DEFAULT false,
  "lockoutenddateutc" timestamp,
  "lockoutenabled" boolean NOT NULL DEFAULT false,
  "accessfailedcount" int NOT NULL DEFAULT 0,
  PRIMARY KEY ("id")
);

CREATE TABLE dbo.aspnetuserclaims ( 
  "id" serial NOT NULL,
  "claimtype" varchar(256) NULL,
  "claimvalue" varchar(256) NULL,
  "userid" varchar(128) NOT NULL,
  PRIMARY KEY ("id")
);

CREATE TABLE dbo.aspnetuserlogins ( 
  "userid" varchar(128) NOT NULL,
  "loginprovider" varchar(128) NOT NULL,
  "providerkey" varchar(128) NOT NULL,
  PRIMARY KEY ("userid", "loginprovider", "providerkey")
);

CREATE TABLE dbo.aspnetuserroles ( 
  "userid" varchar(128) NOT NULL,
  "roleid" varchar(128) NOT NULL,
  PRIMARY KEY ("userid", "roleid")
);

CREATE INDEX "ix_aspnetuserclaims_userid"	ON dbo.aspnetuserclaims	("userid");
CREATE INDEX "ix_aspnetuserlogins_userid"	ON dbo.aspnetuserlogins	("userid");
CREATE INDEX "ix_aspnetuserroles_roleid"	ON dbo.aspnetuserroles	("roleid");
CREATE INDEX "ix_aspnetuserroles_userid"	ON dbo.aspnetuserroles	("userid");

ALTER TABLE dbo.aspnetuserclaims
  ADD CONSTRAINT "fk_aspnetuserclaims_aspnetusers_user_id" FOREIGN KEY ("userid") REFERENCES dbo.aspnetusers ("id")
  ON DELETE CASCADE;

ALTER TABLE dbo.aspnetuserlogins
  ADD CONSTRAINT "fk_aspnetuserlogins_aspnetusers_userid" FOREIGN KEY ("userid") REFERENCES dbo.aspnetusers ("id")
  ON DELETE CASCADE;

ALTER TABLE dbo.aspnetuserroles
  ADD CONSTRAINT "fk_aspnetuserroles_aspnetroles_roleid" FOREIGN KEY ("roleid") REFERENCES dbo.aspnetroles ("id")
  ON DELETE CASCADE;

ALTER TABLE dbo.aspnetuserroles
  ADD CONSTRAINT "fk_aspnetuserroles_aspnetusers_userid" FOREIGN KEY ("userid") REFERENCES dbo.aspnetusers ("id")
  ON DELETE CASCADE;