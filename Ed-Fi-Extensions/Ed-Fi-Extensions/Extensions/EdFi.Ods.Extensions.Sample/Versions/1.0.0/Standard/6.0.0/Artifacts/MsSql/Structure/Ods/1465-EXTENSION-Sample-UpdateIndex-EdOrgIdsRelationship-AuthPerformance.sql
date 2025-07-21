-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


DROP INDEX IF EXISTS IX_BusRoute_EducationOrganizationId ON [sample].[BusRoute];
CREATE INDEX IX_BusRoute_EducationOrganizationId ON [sample].[BusRoute](EducationOrganizationId) INCLUDE (AggregateId);

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_BusRoute_StaffUSI' AND object_id = OBJECT_ID('sample.BusRoute')) 
BEGIN
    CREATE INDEX IX_BusRoute_StaffUSI ON [sample].[BusRoute](StaffUSI) INCLUDE (AggregateId)
END;

DROP INDEX IF EXISTS IX_StudentGraduationPlanAssociation_EducationOrganizationId ON [sample].[StudentGraduationPlanAssociation];
CREATE INDEX IX_StudentGraduationPlanAssociation_EducationOrganizationId ON [sample].[StudentGraduationPlanAssociation](EducationOrganizationId) INCLUDE (AggregateId);

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentGraduationPlanAssociation_StudentUSI' AND object_id = OBJECT_ID('sample.StudentGraduationPlanAssociation')) 
BEGIN
    CREATE INDEX IX_StudentGraduationPlanAssociation_StudentUSI ON [sample].[StudentGraduationPlanAssociation](StudentUSI) INCLUDE (AggregateId)
END;

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentGraduationPlanAssociation_StaffUSI' AND object_id = OBJECT_ID('sample.StudentGraduationPlanAssociation')) 
BEGIN
    CREATE INDEX IX_StudentGraduationPlanAssociation_StaffUSI ON [sample].[StudentGraduationPlanAssociation](StaffUSI) INCLUDE (AggregateId)
END;
