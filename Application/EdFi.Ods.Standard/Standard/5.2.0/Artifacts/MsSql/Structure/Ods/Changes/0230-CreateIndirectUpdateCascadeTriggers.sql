-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER TRIGGER [edfi].[edfi_AssessmentSection_TR_Assessment_Update]
ON [edfi].[AssessmentSection]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(LocalCourseCode)
       OR UPDATE(SchoolId)
       OR UPDATE(SchoolYear)
       OR UPDATE(SectionIdentifier)
       OR UPDATE(SessionName)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [edfi].[Assessment] rt
        INNER JOIN inserted i
            ON rt.AssessmentIdentifier = i.AssessmentIdentifier
               AND rt.Namespace = i.Namespace;
    END
END;
GO

CREATE OR ALTER TRIGGER  [edfi].[edfi_BellScheduleClassPeriod_TR_BellSchedule_Update]
ON [edfi].[BellScheduleClassPeriod]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(ClassPeriodName)
       OR UPDATE(SchoolId)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [edfi].[BellSchedule] rt
        INNER JOIN inserted i
            ON rt.BellScheduleName = i.BellScheduleName
               AND rt.SchoolId = i.SchoolId;
    END
END;
GO

CREATE OR ALTER TRIGGER  [edfi].[edfi_CourseTranscriptSection_TR_CourseTranscript_Update]
ON [edfi].[CourseTranscriptSection]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(LocalCourseCode)
       OR UPDATE(SchoolId)
       OR UPDATE(SchoolYear)
       OR UPDATE(SectionIdentifier)
       OR UPDATE(SessionName)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [edfi].[CourseTranscript] rt
        INNER JOIN inserted i
            ON rt.CourseAttemptResultDescriptorId = i.CourseAttemptResultDescriptorId
               AND rt.CourseCode = i.CourseCode
               AND rt.CourseEducationOrganizationId = i.CourseEducationOrganizationId
               AND rt.EducationOrganizationId = i.EducationOrganizationId
               AND rt.SchoolYear = i.SchoolYear
               AND rt.StudentUSI = i.StudentUSI
               AND rt.TermDescriptorId = i.TermDescriptorId;
    END
END;
GO

CREATE OR ALTER TRIGGER [edfi].[edfi_ReportCardGrade_TR_ReportCard_Update]
ON [edfi].[ReportCardGrade]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(BeginDate)
       OR UPDATE(GradeTypeDescriptorId)
       OR UPDATE(GradingPeriodDescriptorId)
       OR UPDATE(GradingPeriodName)
       OR UPDATE(GradingPeriodSchoolYear)
       OR UPDATE(LocalCourseCode)
       OR UPDATE(SchoolId)
       OR UPDATE(SchoolYear)
       OR UPDATE(SectionIdentifier)
       OR UPDATE(SessionName)
       OR UPDATE(StudentUSI)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [edfi].[ReportCard] rt
        INNER JOIN inserted i
            ON rt.EducationOrganizationId = i.EducationOrganizationId
               AND rt.GradingPeriodDescriptorId = i.GradingPeriodDescriptorId
               AND rt.GradingPeriodName = i.GradingPeriodName
               AND rt.GradingPeriodSchoolId = i.GradingPeriodSchoolId
               AND rt.GradingPeriodSchoolYear = i.GradingPeriodSchoolYear
               AND rt.StudentUSI = i.StudentUSI;
    END
END;
GO

CREATE OR ALTER TRIGGER  [edfi].[edfi_SectionClassPeriod_TR_Section_Update]
ON [edfi].[SectionClassPeriod]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(ClassPeriodName)
       OR UPDATE(SchoolId)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [edfi].[Section] rt
        INNER JOIN inserted i
            ON rt.LocalCourseCode = i.LocalCourseCode
               AND rt.SchoolId = i.SchoolId
               AND rt.SchoolYear = i.SchoolYear
               AND rt.SectionIdentifier = i.SectionIdentifier
               AND rt.SessionName = i.SessionName;
    END
END;
GO

CREATE OR ALTER TRIGGER  [edfi].[edfi_StudentCohortAssociationSection_TR_StudentCohortAssociation_Update]
ON [edfi].[StudentCohortAssociationSection]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(LocalCourseCode)
       OR UPDATE(SchoolId)
       OR UPDATE(SchoolYear)
       OR UPDATE(SectionIdentifier)
       OR UPDATE(SessionName)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [edfi].[StudentCohortAssociation] rt
        INNER JOIN inserted i
            ON rt.BeginDate = i.BeginDate
               AND rt.CohortIdentifier = i.CohortIdentifier
               AND rt.EducationOrganizationId = i.EducationOrganizationId
               AND rt.StudentUSI = i.StudentUSI;
    END
END;
GO

CREATE OR ALTER TRIGGER  [edfi].[edfi_StudentCompetencyObjectiveStudentSectionAssociation_TR_StudentCompetencyObjective_Update]
ON [edfi].[StudentCompetencyObjectiveStudentSectionAssociation]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(BeginDate)
       OR UPDATE(LocalCourseCode)
       OR UPDATE(SchoolId)
       OR UPDATE(SchoolYear)
       OR UPDATE(SectionIdentifier)
       OR UPDATE(SessionName)
       OR UPDATE(StudentUSI)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [edfi].[StudentCompetencyObjective] rt
        INNER JOIN inserted i
            ON rt.GradingPeriodDescriptorId = i.GradingPeriodDescriptorId
               AND rt.GradingPeriodName = i.GradingPeriodName
               AND rt.GradingPeriodSchoolId = i.GradingPeriodSchoolId
               AND rt.GradingPeriodSchoolYear = i.GradingPeriodSchoolYear
               AND rt.ObjectiveEducationOrganizationId = i.ObjectiveEducationOrganizationId
               AND rt.Objective = i.Objective
               AND rt.ObjectiveGradeLevelDescriptorId = i.ObjectiveGradeLevelDescriptorId
               AND rt.StudentUSI = i.StudentUSI;
    END
END;
GO

CREATE OR ALTER TRIGGER  [edfi].[edfi_StudentSectionAttendanceEventClassPeriod_TR_StudentSectionAttendanceEvent_Update]
ON [edfi].[StudentSectionAttendanceEventClassPeriod]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if any volatile foreign key values have changed
    IF UPDATE(ClassPeriodName)
       OR UPDATE(SchoolId)
    BEGIN
        -- Update the LastModifiedDate in the root table to the current UTC time
        UPDATE rt
        SET rt.LastModifiedDate = GETUTCDATE()
        FROM [edfi].[StudentSectionAttendanceEvent] rt
        INNER JOIN inserted i
            ON rt.AttendanceEventCategoryDescriptorId = i.AttendanceEventCategoryDescriptorId
               AND rt.EventDate = i.EventDate
               AND rt.LocalCourseCode = i.LocalCourseCode
               AND rt.SchoolId = i.SchoolId
               AND rt.SchoolYear = i.SchoolYear
               AND rt.SectionIdentifier = i.SectionIdentifier
               AND rt.SessionName = i.SessionName
               AND rt.StudentUSI = i.StudentUSI;
    END
END;
GO

