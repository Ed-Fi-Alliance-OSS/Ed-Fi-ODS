-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE SCHEMA interop AUTHORIZATION postgres;

BEGIN;

CREATE TABLE interop.OperationalContext
	(
	OperationalContextUri varchar(255) NOT NULL,
	DisplayName varchar(100) NOT NULL,
	OrganizationName varchar(50) NULL,
	CreateDate timestamp NOT NULL,
	LastModifiedDate timestamp NOT NULL,
	Id uuid NOT NULL
	);

ALTER TABLE interop.OperationalContext ADD CONSTRAINT
	PK_OperationalContext PRIMARY KEY 
	(
	OperationalContextUri
	);

ALTER TABLE interop.OperationalContext ALTER COLUMN Id SET DEFAULT gen_random_uuid();

ALTER TABLE interop.OperationalContext ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

ALTER TABLE interop.OperationalContext ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

COMMIT;
BEGIN;


CREATE TABLE interop.DescriptorEquivalenceGroup
	(
	DescriptorEquivalenceGroupId uuid NOT NULL,
	CreateDate timestamp NOT NULL,
	LastModifiedDate timestamp NOT NULL,
	Id uuid NOT NULL	
	);

ALTER TABLE interop.DescriptorEquivalenceGroup ADD CONSTRAINT
	PK_DescriptorEquivalenceGroup PRIMARY KEY 
	(
	DescriptorEquivalenceGroupId
	);

ALTER TABLE interop.DescriptorEquivalenceGroup ALTER COLUMN DescriptorEquivalenceGroupId SET DEFAULT gen_random_uuid();

ALTER TABLE interop.DescriptorEquivalenceGroup ALTER COLUMN Id SET DEFAULT gen_random_uuid();

ALTER TABLE interop.DescriptorEquivalenceGroup ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

ALTER TABLE interop.DescriptorEquivalenceGroup ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

COMMIT;
BEGIN;


CREATE TABLE interop.DescriptorEquivalenceGroupGeneralization
	(
	DescriptorEquivalenceGroupId uuid NOT NULL,
	GeneralizationDescriptorEquivalenceGroupId uuid NOT NULL,
	CreateDate timestamp NOT NULL,
	LastModifiedDate timestamp NOT NULL,
	Id uuid NOT NULL	
	);

ALTER TABLE interop.DescriptorEquivalenceGroupGeneralization ADD CONSTRAINT
	PK_DescEquivGroupGeneral PRIMARY KEY 
	(
	DescriptorEquivalenceGroupId,
	GeneralizationDescriptorEquivalenceGroupId
	);

ALTER TABLE interop.DescriptorEquivalenceGroupGeneralization ADD CONSTRAINT
	FK_DescEquivGroupGeneral_DescriptorEquivalenceGroup FOREIGN KEY
	(
	DescriptorEquivalenceGroupId
	) REFERENCES interop.DescriptorEquivalenceGroup
	(
	DescriptorEquivalenceGroupId
	) ON UPDATE  NO ACTION
	 ON DELETE  NO ACTION;

ALTER TABLE interop.DescriptorEquivalenceGroupGeneralization ADD CONSTRAINT
	FK_DescEquivGroupGeneral_DescriptorEquivalenceGroupGeneral FOREIGN KEY
	(
	GeneralizationDescriptorEquivalenceGroupId
	) REFERENCES interop.DescriptorEquivalenceGroup
	(
	DescriptorEquivalenceGroupId
	) ON UPDATE  NO ACTION
	 ON DELETE  NO ACTION;	

ALTER TABLE interop.DescriptorEquivalenceGroupGeneralization ALTER COLUMN Id SET DEFAULT gen_random_uuid();

ALTER TABLE interop.DescriptorEquivalenceGroupGeneralization ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

ALTER TABLE interop.DescriptorEquivalenceGroupGeneralization ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

COMMIT;
BEGIN;


CREATE TABLE interop.OperationalContextDescriptorUsage
	(
	OperationalContextUri varchar(255) NOT NULL,
	DescriptorId int NOT NULL,
	CreateDate timestamp NOT NULL);

ALTER TABLE interop.OperationalContextDescriptorUsage ADD CONSTRAINT
	PK_OperationalContextDescriptorUsage PRIMARY KEY 
	(
	OperationalContextUri,
	DescriptorId
	);

ALTER TABLE interop.OperationalContextDescriptorUsage ADD CONSTRAINT
	FK_OperationalContextDescriptorUsage_Descriptor FOREIGN KEY
	(
	DescriptorId
	) REFERENCES edfi.Descriptor
	(
	DescriptorId
	) ON UPDATE  NO ACTION
	 ON DELETE  CASCADE;

ALTER TABLE interop.OperationalContextDescriptorUsage ADD CONSTRAINT
	FK_OperationalContextDescriptorUsage_OperationalContext FOREIGN KEY
	(
	OperationalContextUri
	) REFERENCES interop.OperationalContext
	(
	OperationalContextUri
	) ON UPDATE  NO ACTION
	 ON DELETE  NO ACTION;

ALTER TABLE interop.OperationalContextDescriptorUsage ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

COMMIT;
BEGIN;


CREATE TABLE interop.DescriptorEquivalenceGroupAssignment
	(
	DescriptorId int NOT NULL,
	DescriptorEquivalenceGroupId uuid NOT NULL,
	CreateDate timestamp NOT NULL,
	LastModifiedDate timestamp NOT NULL,
	Id uuid NOT NULL	
	);
ALTER TABLE interop.DescriptorEquivalenceGroupAssignment ADD CONSTRAINT
	PK_DescEquivGroupAssign PRIMARY KEY 
	(
	DescriptorId
	);

ALTER TABLE interop.DescriptorEquivalenceGroupAssignment ADD CONSTRAINT
	FK_DescEquivGroupAssign_DescriptorEquivalenceGroup FOREIGN KEY
	(
	DescriptorEquivalenceGroupId
	) REFERENCES interop.DescriptorEquivalenceGroup
	(
	DescriptorEquivalenceGroupId
	) ON UPDATE  NO ACTION
	 ON DELETE  NO ACTION;

ALTER TABLE interop.DescriptorEquivalenceGroupAssignment ADD CONSTRAINT
	FK_DescEquivGroupAssign_Descriptor FOREIGN KEY
	(
	DescriptorId
	) REFERENCES edfi.Descriptor
	(
	DescriptorId
	) ON UPDATE  NO ACTION
	 ON DELETE  CASCADE;

ALTER TABLE interop.DescriptorEquivalenceGroupAssignment ALTER COLUMN Id SET DEFAULT gen_random_uuid();

ALTER TABLE interop.DescriptorEquivalenceGroupAssignment ALTER COLUMN CreateDate SET DEFAULT current_timestamp;

ALTER TABLE interop.DescriptorEquivalenceGroupAssignment ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

COMMIT;