-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


CREATE SEQUENCE homograph.Contact_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.Contact ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('homograph.Contact_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Contact_aggid ON homograph.Contact (AggregateId);


CREATE SEQUENCE homograph.Name_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.Name ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('homograph.Name_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Name_aggid ON homograph.Name (AggregateId);


CREATE SEQUENCE homograph.School_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.School ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('homograph.School_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_School_aggid ON homograph.School (AggregateId);


CREATE SEQUENCE homograph.SchoolYearType_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.SchoolYearType ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('homograph.SchoolYearType_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_SchoolYearType_aggid ON homograph.SchoolYearType (AggregateId);


CREATE SEQUENCE homograph.Staff_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.Staff ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('homograph.Staff_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Staff_aggid ON homograph.Staff (AggregateId);


CREATE SEQUENCE homograph.Student_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.Student ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('homograph.Student_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Student_aggid ON homograph.Student (AggregateId);


CREATE SEQUENCE homograph.StudentSchoolAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE homograph.StudentSchoolAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('homograph.StudentSchoolAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentSchoolAssociation_aggid ON homograph.StudentSchoolAssociation (AggregateId);

