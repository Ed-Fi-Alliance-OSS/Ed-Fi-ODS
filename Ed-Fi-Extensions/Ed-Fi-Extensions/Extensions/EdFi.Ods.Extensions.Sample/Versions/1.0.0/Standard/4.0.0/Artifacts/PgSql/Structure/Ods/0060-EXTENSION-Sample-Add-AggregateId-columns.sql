-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- For the "Bus" table
CREATE SEQUENCE sample.bus_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE sample.bus ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('sample.bus_aggseq');
CREATE INDEX ix_bus_aggregateid ON sample.bus (aggregateid);

-- For the "BusRoute" table
CREATE SEQUENCE sample.busroute_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE sample.busroute ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('sample.busroute_aggseq');
CREATE INDEX ix_busroute_aggregateid ON sample.busroute (aggregateid);

-- For the "StudentGraduationPlanAssociation" table
CREATE SEQUENCE sample.studentgraduationplanassociation_aggseq START WITH -2147483648 INCREMENT BY 1 MINVALUE -2147483648;
ALTER TABLE sample.studentgraduationplanassociation ADD COLUMN aggregateid INT NOT NULL DEFAULT nextval('sample.studentgraduationplanassociation_aggseq');
CREATE INDEX ix_studentgraduationplanassociation_aggregateid ON sample.studentgraduationplanassociation (aggregateid);
