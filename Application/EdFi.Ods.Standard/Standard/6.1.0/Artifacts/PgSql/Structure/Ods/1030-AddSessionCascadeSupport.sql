-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE edfi.CourseOffering DROP CONSTRAINT IF EXISTS FK_CourseOffering_Session;
ALTER TABLE edfi.CourseOfferingCourseLevelCharacteristic DROP CONSTRAINT IF EXISTS FK_CourseOfferingCourseLevelCharacteristic_CourseOffering;
ALTER TABLE edfi.CourseOfferingCurriculumUsed DROP CONSTRAINT IF EXISTS FK_CourseOfferingCurriculumUsed_CourseOffering;
ALTER TABLE edfi.CourseOfferingOfferedGradeLevel DROP CONSTRAINT IF EXISTS FK_CourseOfferingOfferedGradeLevel_CourseOffering;
ALTER TABLE edfi.Section DROP CONSTRAINT IF EXISTS FK_Section_CourseOffering;
ALTER TABLE edfi.SessionAcademicWeek DROP CONSTRAINT IF EXISTS FK_SessionAcademicWeek_Session;
ALTER TABLE edfi.SessionGradingPeriod DROP CONSTRAINT IF EXISTS FK_SessionGradingPeriod_Session;
ALTER TABLE edfi.StudentSchoolAttendanceEvent DROP CONSTRAINT IF EXISTS FK_StudentSchoolAttendanceEvent_Session;

-- Add back all the constraints with cascade
ALTER TABLE edfi.CourseOffering
    ADD CONSTRAINT FK_CourseOffering_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName) REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName) ON UPDATE CASCADE;
ALTER TABLE edfi.CourseOffering VALIDATE CONSTRAINT FK_CourseOffering_Session;

ALTER TABLE edfi.CourseOfferingCourseLevelCharacteristic
    ADD CONSTRAINT FK_CourseOfferingCourseLevelCharacteristic_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName) REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE edfi.CourseOfferingCourseLevelCharacteristic VALIDATE CONSTRAINT FK_CourseOfferingCourseLevelCharacteristic_CourseOffering;

ALTER TABLE edfi.CourseOfferingCurriculumUsed
    ADD CONSTRAINT FK_CourseOfferingCurriculumUsed_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName) REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE edfi.CourseOfferingCurriculumUsed VALIDATE CONSTRAINT FK_CourseOfferingCurriculumUsed_CourseOffering;

ALTER TABLE edfi.CourseOfferingOfferedGradeLevel
    ADD CONSTRAINT FK_CourseOfferingOfferedGradeLevel_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName) REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE edfi.CourseOfferingOfferedGradeLevel VALIDATE CONSTRAINT FK_CourseOfferingOfferedGradeLevel_CourseOffering;

ALTER TABLE edfi.Section
    ADD CONSTRAINT FK_Section_CourseOffering FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SessionName) REFERENCES edfi.CourseOffering (LocalCourseCode, SchoolId, SchoolYear, SessionName) ON UPDATE CASCADE;
ALTER TABLE edfi.Section VALIDATE CONSTRAINT FK_Section_CourseOffering;

ALTER TABLE edfi.SessionAcademicWeek
    ADD CONSTRAINT FK_SessionAcademicWeek_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName) REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE edfi.SessionAcademicWeek VALIDATE CONSTRAINT FK_SessionAcademicWeek_Session;

ALTER TABLE edfi.SessionGradingPeriod
    ADD CONSTRAINT FK_SessionGradingPeriod_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName) REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE edfi.SessionGradingPeriod VALIDATE CONSTRAINT FK_SessionGradingPeriod_Session;

ALTER TABLE edfi.StudentSchoolAttendanceEvent
    ADD CONSTRAINT FK_StudentSchoolAttendanceEvent_Session FOREIGN KEY (SchoolId, SchoolYear, SessionName) REFERENCES edfi.Session (SchoolId, SchoolYear, SessionName) ON UPDATE CASCADE;
ALTER TABLE edfi.StudentSchoolAttendanceEvent VALIDATE CONSTRAINT FK_StudentSchoolAttendanceEvent_Session;