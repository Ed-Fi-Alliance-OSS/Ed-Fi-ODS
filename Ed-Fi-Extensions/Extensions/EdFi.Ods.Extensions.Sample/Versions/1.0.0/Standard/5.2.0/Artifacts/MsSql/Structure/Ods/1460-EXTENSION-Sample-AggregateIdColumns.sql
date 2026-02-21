-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE SEQUENCE [sample].[Bus_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [sample].[Bus] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [sample].[Bus_AggSeq], AggregateData varbinary(8000);
CREATE INDEX [IX_Bus_AggregateId] ON [sample].[Bus] (AggregateId);

CREATE SEQUENCE [sample].[BusRoute_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [sample].[BusRoute] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [sample].[BusRoute_AggSeq], AggregateData varbinary(8000);
CREATE INDEX [IX_BusRoute_AggregateId] ON [sample].[BusRoute] (AggregateId);

CREATE SEQUENCE [sample].[StudentGraduationPlanAssociation_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [sample].[StudentGraduationPlanAssociation] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [sample].[StudentGraduationPlanAssociation_AggSeq], AggregateData varbinary(8000);
CREATE INDEX [IX_StudentGraduationPlanAssociation_AggregateId] ON [sample].[StudentGraduationPlanAssociation] (AggregateId);

