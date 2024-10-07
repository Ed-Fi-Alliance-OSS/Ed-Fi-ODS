-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/* Generated with SSMS using:
------------------------------------------------
    DECLARE @schema NVARCHAR(128) = 'sample'; 

	SELECT 'CREATE SEQUENCE [' + c.TABLE_SCHEMA + '].[' + c.TABLE_NAME + '_AggSeq] START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648; ALTER TABLE [' + c.TABLE_SCHEMA + '].[' + c.TABLE_NAME + '] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [' + c.TABLE_SCHEMA + '].[' + c.TABLE_NAME + '_AggSeq]; CREATE INDEX [IX_' + c.TABLE_NAME + '_AggregateId] ON [' + c.TABLE_SCHEMA + '].[' + c.TABLE_NAME + '] (AggregateId);' AS SqlServer
	FROM INFORMATION_SCHEMA.COLUMNS c
	WHERE c.COLUMN_NAME = 'Id' and c.TABLE_SCHEMA = @schema
	ORDER BY c.TABLE_SCHEMA, c.TABLE_NAME
------------------------------------------------
*/

-- Create sequences and add columns with default values
CREATE SEQUENCE homograph.name_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.name ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.name_aggseq');
CREATE INDEX ix_name_aggregateid ON homograph.name (aggregateid);

CREATE SEQUENCE homograph.parent_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.parent ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.parent_aggseq');
CREATE INDEX ix_parent_aggregateid ON homograph.parent (aggregateid);

CREATE SEQUENCE homograph.school_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.school ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.school_aggseq');
CREATE INDEX ix_school_aggregateid ON homograph.school (aggregateid);

CREATE SEQUENCE homograph.schoolyeartype_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.schoolyeartype ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.schoolyeartype_aggseq');
CREATE INDEX ix_schoolyeartype_aggregateid ON homograph.schoolyeartype (aggregateid);

CREATE SEQUENCE homograph.staff_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.staff ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.staff_aggseq');
CREATE INDEX ix_staff_aggregateid ON homograph.staff (aggregateid);

CREATE SEQUENCE homograph.student_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.student ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.student_aggseq');
CREATE INDEX ix_student_aggregateid ON homograph.student (aggregateid);

CREATE SEQUENCE homograph.studentschoolassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.studentschoolassociation ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.studentschoolassociation_aggseq');
CREATE INDEX ix_studentschoolassociation_aggregateid ON homograph.studentschoolassociation (aggregateid);
