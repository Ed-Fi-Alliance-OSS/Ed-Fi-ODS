-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE SEQUENCE [homograph].[Contact_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [homograph].[Contact] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [homograph].[Contact_AggSeq];
CREATE INDEX [IX_Contact_AggregateId] ON [homograph].[Contact] (AggregateId);

CREATE SEQUENCE [homograph].[Name_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [homograph].[Name] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [homograph].[Name_AggSeq];
CREATE INDEX [IX_Name_AggregateId] ON [homograph].[Name] (AggregateId);

CREATE SEQUENCE [homograph].[School_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [homograph].[School] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [homograph].[School_AggSeq];
CREATE INDEX [IX_School_AggregateId] ON [homograph].[School] (AggregateId);

CREATE SEQUENCE [homograph].[SchoolYearType_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [homograph].[SchoolYearType] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [homograph].[SchoolYearType_AggSeq];
CREATE INDEX [IX_SchoolYearType_AggregateId] ON [homograph].[SchoolYearType] (AggregateId);

CREATE SEQUENCE [homograph].[Staff_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [homograph].[Staff] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [homograph].[Staff_AggSeq];
CREATE INDEX [IX_Staff_AggregateId] ON [homograph].[Staff] (AggregateId);

CREATE SEQUENCE [homograph].[Student_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [homograph].[Student] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [homograph].[Student_AggSeq];
CREATE INDEX [IX_Student_AggregateId] ON [homograph].[Student] (AggregateId);

CREATE SEQUENCE [homograph].[StudentSchoolAssociation_AggSeq] START WITH -2147483648 INCREMENT BY 1;
ALTER TABLE [homograph].[StudentSchoolAssociation] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [homograph].[StudentSchoolAssociation_AggSeq];
CREATE INDEX [IX_StudentSchoolAssociation_AggregateId] ON [homograph].[StudentSchoolAssociation] (AggregateId);

