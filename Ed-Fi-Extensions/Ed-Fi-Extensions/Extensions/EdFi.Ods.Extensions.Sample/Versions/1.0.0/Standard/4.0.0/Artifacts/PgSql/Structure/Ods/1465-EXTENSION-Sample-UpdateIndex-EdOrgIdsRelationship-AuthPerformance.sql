-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


DROP INDEX IF EXISTS IX_BusRoute_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_BusRoute_EducationOrganizationId ON sample.BusRoute(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_BusRoute_StaffUSI ON sample.BusRoute(StaffUSI) INCLUDE (AggregateId);

DROP INDEX IF EXISTS IX_StudentGraduationPlanAssociation_EducationOrganizationId;
CREATE INDEX IF NOT EXISTS IX_StudentGraduationPlanAssociation_EducationOrganizationId ON sample.StudentGraduationPlanAssociation(EducationOrganizationId) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentGraduationPlanAssociation_StudentUSI ON sample.StudentGraduationPlanAssociation(StudentUSI) INCLUDE (AggregateId);

CREATE INDEX IF NOT EXISTS IX_StudentGraduationPlanAssociation_StaffUSI ON sample.StudentGraduationPlanAssociation(StaffUSI) INCLUDE (AggregateId);
