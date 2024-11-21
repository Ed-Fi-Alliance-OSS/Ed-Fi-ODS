-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


CREATE SEQUENCE sample.Bus_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE sample.Bus ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('sample.Bus_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_Bus_aggid ON sample.Bus (AggregateId);


CREATE SEQUENCE sample.BusRoute_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE sample.BusRoute ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('sample.BusRoute_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_BusRoute_aggid ON sample.BusRoute (AggregateId);


CREATE SEQUENCE sample.StudentGraduationPlanAssociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE sample.StudentGraduationPlanAssociation ADD COLUMN AggregateId int NOT NULL DEFAULT nextval('sample.StudentGraduationPlanAssociation_aggseq'), ADD COLUMN AggregateData bytea;
CREATE INDEX ix_StudentGraduationPlanAssociation_aggid ON sample.StudentGraduationPlanAssociation (AggregateId);

