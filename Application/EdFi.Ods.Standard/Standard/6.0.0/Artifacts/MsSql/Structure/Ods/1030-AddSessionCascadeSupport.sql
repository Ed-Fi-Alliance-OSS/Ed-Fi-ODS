-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_CourseOffering_Session' AND CONSTRAINT_SCHEMA = 'edfi')
    ALTER TABLE [edfi].[CourseOffering] DROP CONSTRAINT [FK_CourseOffering_Session];
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_CourseOfferingCourseLevelCharacteristic_CourseOffering' AND CONSTRAINT_SCHEMA = 'edfi')
    ALTER TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] DROP CONSTRAINT [FK_CourseOfferingCourseLevelCharacteristic_CourseOffering];
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_CourseOfferingCurriculumUsed_CourseOffering' AND CONSTRAINT_SCHEMA = 'edfi')
    ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] DROP CONSTRAINT [FK_CourseOfferingCurriculumUsed_CourseOffering];
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_CourseOfferingOfferedGradeLevel_CourseOffering' AND CONSTRAINT_SCHEMA = 'edfi')
    ALTER TABLE [edfi].[CourseOfferingOfferedGradeLevel] DROP CONSTRAINT [FK_CourseOfferingOfferedGradeLevel_CourseOffering];
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Section_CourseOffering' AND CONSTRAINT_SCHEMA = 'edfi')
    ALTER TABLE [edfi].[Section] DROP CONSTRAINT [FK_Section_CourseOffering];
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_SessionAcademicWeek_Session' AND CONSTRAINT_SCHEMA = 'edfi')
    ALTER TABLE [edfi].[SessionAcademicWeek] DROP CONSTRAINT [FK_SessionAcademicWeek_Session];
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_SessionGradingPeriod_Session' AND CONSTRAINT_SCHEMA = 'edfi')
    ALTER TABLE [edfi].[SessionGradingPeriod] DROP CONSTRAINT [FK_SessionGradingPeriod_Session];
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_StudentSchoolAttendanceEvent_Session' AND CONSTRAINT_SCHEMA = 'edfi')
    ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] DROP CONSTRAINT [FK_StudentSchoolAttendanceEvent_Session];

-- Add back all the constraints with cascade
ALTER TABLE [edfi].[CourseOffering] WITH CHECK
    ADD CONSTRAINT [FK_CourseOffering_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName]) REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName]) ON UPDATE CASCADE;
ALTER TABLE [edfi].[CourseOfferingCourseLevelCharacteristic] WITH CHECK
    ADD CONSTRAINT [FK_CourseOfferingCourseLevelCharacteristic_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName]) REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName]) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] WITH CHECK
    ADD CONSTRAINT [FK_CourseOfferingCurriculumUsed_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName]) REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName]) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE [edfi].[CourseOfferingOfferedGradeLevel] WITH CHECK
    ADD CONSTRAINT [FK_CourseOfferingOfferedGradeLevel_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName]) REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName]) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE [edfi].[Section] WITH CHECK
    ADD CONSTRAINT [FK_Section_CourseOffering] FOREIGN KEY ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName]) REFERENCES [edfi].[CourseOffering] ([LocalCourseCode], [SchoolId], [SchoolYear], [SessionName]) ON UPDATE CASCADE;
ALTER TABLE [edfi].[SessionAcademicWeek] WITH CHECK
    ADD CONSTRAINT [FK_SessionAcademicWeek_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName]) REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName]) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE [edfi].[SessionGradingPeriod] WITH CHECK
    ADD CONSTRAINT [FK_SessionGradingPeriod_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName]) REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName]) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] WITH CHECK
    ADD CONSTRAINT [FK_StudentSchoolAttendanceEvent_Session] FOREIGN KEY ([SchoolId], [SchoolYear], [SessionName]) REFERENCES [edfi].[Session] ([SchoolId], [SchoolYear], [SessionName]) ON UPDATE CASCADE;