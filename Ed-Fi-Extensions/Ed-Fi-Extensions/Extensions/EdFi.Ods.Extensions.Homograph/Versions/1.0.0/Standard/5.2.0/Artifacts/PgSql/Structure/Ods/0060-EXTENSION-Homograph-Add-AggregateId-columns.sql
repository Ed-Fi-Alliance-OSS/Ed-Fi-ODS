-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Create sequences, alter tables to add the AggregateId column, and create indexes in PostgreSQL

-- For the "studentschoolassociation" table
CREATE SEQUENCE homograph.studentschoolassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.studentschoolassociation ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.studentschoolassociation_aggseq');
CREATE INDEX ix_studentschoolassociation_aggregateid ON homograph.studentschoolassociation (aggregateid);


-- For the "student" table
CREATE SEQUENCE homograph.student_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.student ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.student_aggseq');
CREATE INDEX ix_student_aggregateid ON homograph.student (aggregateid);

-- For the "staff" table
CREATE SEQUENCE homograph.staff_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.staff ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.staff_aggseq');
CREATE INDEX ix_staff_aggregateid ON homograph.staff (aggregateid);

-- For the "schoolyeartype" table
CREATE SEQUENCE homograph.schoolyeartype_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.schoolyeartype ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.schoolyeartype_aggseq');
CREATE INDEX ix_schoolyeartype_aggregateid ON homograph.schoolyeartype (aggregateid);

-- For the "Contact" table
CREATE SEQUENCE homograph.contact_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.contact ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.contact_aggseq');
CREATE INDEX ix_contact_aggregateid ON homograph.contact (aggregateid);

-- For the "Name" table
CREATE SEQUENCE homograph.name_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.name ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.name_aggseq');
CREATE INDEX ix_name_aggregateid ON homograph.name (aggregateid);

-- For the "School" table
CREATE SEQUENCE homograph.school_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.school ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('homograph.school_aggseq');
CREATE INDEX ix_school_aggregateid ON homograph.school (aggregateid);
