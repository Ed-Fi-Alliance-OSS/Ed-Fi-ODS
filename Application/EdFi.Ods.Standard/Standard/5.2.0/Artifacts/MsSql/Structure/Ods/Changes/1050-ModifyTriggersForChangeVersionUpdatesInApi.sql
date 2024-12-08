-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [edfi].[edfi_AcademicWeek_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AccountabilityRating_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Assessment_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentAdministration_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentAdministrationParticipation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentBatteryPart_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentItem_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentScoreRangeLearningStandard_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_BalanceSheetDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_BellSchedule_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Calendar_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CalendarDate_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ChartOfAccount_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ClassPeriod_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ClassPeriod_TR_UpdateChangeVersion] ON [edfi].[ClassPeriod] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.ClassPeriod(
        OldClassPeriodName, OldSchoolId, 
        NewClassPeriodName, NewSchoolId, 
        Id, ChangeVersion)
    SELECT
        d.ClassPeriodName, d.SchoolId, 
        i.ClassPeriodName, i.SchoolId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.ClassPeriodName <> i.ClassPeriodName OR d.SchoolId <> i.SchoolId;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Cohort_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CommunityProviderLicense_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CompetencyObjective_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Contact_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Course_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CourseOffering_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CourseOffering_TR_UpdateChangeVersion] ON [edfi].[CourseOffering] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[CourseOffering]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[CourseOffering] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.CourseOffering(
        OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSessionName, 
        NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSessionName, 
        Id, ChangeVersion)
    SELECT
        d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SessionName, 
        i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SessionName, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SessionName <> i.SessionName;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CourseTranscript_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Credential_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CrisisEvent_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Descriptor_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DescriptorMapping_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineAction_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineIncident_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationContent_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganization_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationNetworkAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationPeerAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EvaluationRubricDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FeederSchoolAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FunctionDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FundDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GeneralStudentProgramAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Grade_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Grade_TR_UpdateChangeVersion] ON [edfi].[Grade] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[Grade]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Grade] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.Grade(
        OldBeginDate, OldGradeTypeDescriptorId, OldGradeTypeDescriptorNamespace, OldGradeTypeDescriptorCodeValue, OldGradingPeriodDescriptorId, OldGradingPeriodDescriptorNamespace, OldGradingPeriodDescriptorCodeValue, OldGradingPeriodName, OldGradingPeriodSchoolYear, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, 
        NewBeginDate, NewGradeTypeDescriptorId, NewGradeTypeDescriptorNamespace, NewGradeTypeDescriptorCodeValue, NewGradingPeriodDescriptorId, NewGradingPeriodDescriptorNamespace, NewGradingPeriodDescriptorCodeValue, NewGradingPeriodName, NewGradingPeriodSchoolYear, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.BeginDate, d.GradeTypeDescriptorId, dj0.Namespace, dj0.CodeValue, d.GradingPeriodDescriptorId, dj1.Namespace, dj1.CodeValue, d.GradingPeriodName, d.GradingPeriodSchoolYear, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, dj2.StudentUniqueId, 
        i.BeginDate, i.GradeTypeDescriptorId, ij0.Namespace, ij0.CodeValue, i.GradingPeriodDescriptorId, ij1.Namespace, ij1.CodeValue, i.GradingPeriodName, i.GradingPeriodSchoolYear, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.StudentUSI, ij2.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId
        INNER JOIN edfi.Descriptor dj0
            ON d.GradeTypeDescriptorId = dj0.DescriptorId
        INNER JOIN edfi.Descriptor dj1
            ON d.GradingPeriodDescriptorId = dj1.DescriptorId
        INNER JOIN edfi.Student dj2
            ON d.StudentUSI = dj2.StudentUSI
        INNER JOIN edfi.Descriptor ij0
            ON i.GradeTypeDescriptorId = ij0.DescriptorId
        INNER JOIN edfi.Descriptor ij1
            ON i.GradingPeriodDescriptorId = ij1.DescriptorId
        INNER JOIN edfi.Student ij2
            ON i.StudentUSI = ij2.StudentUSI

    WHERE
        d.BeginDate <> i.BeginDate OR d.GradeTypeDescriptorId <> i.GradeTypeDescriptorId OR d.GradingPeriodDescriptorId <> i.GradingPeriodDescriptorId OR d.GradingPeriodName <> i.GradingPeriodName OR d.GradingPeriodSchoolYear <> i.GradingPeriodSchoolYear OR d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName OR d.StudentUSI <> i.StudentUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GradebookEntry_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GradebookEntry_TR_UpdateChangeVersion] ON [edfi].[GradebookEntry] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[GradebookEntry]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[GradebookEntry] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.GradebookEntry(
        OldGradebookEntryIdentifier, OldNamespace, 
        NewGradebookEntryIdentifier, NewNamespace, 
        Id, ChangeVersion)
    SELECT
        d.GradebookEntryIdentifier, d.Namespace, 
        i.GradebookEntryIdentifier, i.Namespace, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.GradebookEntryIdentifier <> i.GradebookEntryIdentifier OR d.Namespace <> i.Namespace;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GradingPeriod_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GraduationPlan_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Intervention_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionPrescription_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionStudy_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandard_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandardEquivalenceAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalAccount_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalActual_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalBudget_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalContractedStaff_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalEncumbrance_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalPayroll_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Location_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Location_TR_UpdateChangeVersion] ON [edfi].[Location] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.Location(
        OldClassroomIdentificationCode, OldSchoolId, 
        NewClassroomIdentificationCode, NewSchoolId, 
        Id, ChangeVersion)
    SELECT
        d.ClassroomIdentificationCode, d.SchoolId, 
        i.ClassroomIdentificationCode, i.SchoolId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.ClassroomIdentificationCode <> i.ClassroomIdentificationCode OR d.SchoolId <> i.SchoolId;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ObjectDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ObjectiveAssessment_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_OpenStaffPosition_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_OperationalUnitDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Person_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_PostSecondaryEvent_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Program_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramEvaluation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramEvaluationElement_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramEvaluationObjective_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProjectDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ReportCard_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_RestraintEvent_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolYearType_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Section_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Section_TR_UpdateChangeVersion] ON [edfi].[Section] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[Section]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Section] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.Section(
        OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, 
        NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, 
        Id, ChangeVersion)
    SELECT
        d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, 
        i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SectionAttendanceTakenEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SectionAttendanceTakenEvent_TR_UpdateChangeVersion] ON [edfi].[SectionAttendanceTakenEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[SectionAttendanceTakenEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SectionAttendanceTakenEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.SectionAttendanceTakenEvent(
        OldCalendarCode, OldDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, 
        NewCalendarCode, NewDate, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, 
        Id, ChangeVersion)
    SELECT
        d.CalendarCode, d.Date, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, 
        i.CalendarCode, i.Date, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.CalendarCode <> i.CalendarCode OR d.Date <> i.Date OR d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Session_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Session_TR_UpdateChangeVersion] ON [edfi].[Session] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.Session(
        OldSchoolId, OldSchoolYear, OldSessionName, 
        NewSchoolId, NewSchoolYear, NewSessionName, 
        Id, ChangeVersion)
    SELECT
        d.SchoolId, d.SchoolYear, d.SessionName, 
        i.SchoolId, i.SchoolYear, i.SessionName, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SessionName <> i.SessionName;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SourceDimension_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Staff_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffAbsenceEvent_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffCohortAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffDisciplineIncidentAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationAssignmentAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationContactAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationEmploymentAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffLeave_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffProgramAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffSchoolAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffSectionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffSectionAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[StaffSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StaffSectionAssociation(
        OldBeginDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStaffUSI, OldStaffUniqueId, 
        NewBeginDate, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewStaffUSI, NewStaffUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.BeginDate, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StaffUSI, dj0.StaffUniqueId, 
        i.BeginDate, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.StaffUSI, ij0.StaffUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId
        INNER JOIN edfi.Staff dj0
            ON d.StaffUSI = dj0.StaffUSI
        INNER JOIN edfi.Staff ij0
            ON i.StaffUSI = ij0.StaffUSI

    WHERE
        d.BeginDate <> i.BeginDate OR d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName OR d.StaffUSI <> i.StaffUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Student_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAcademicRecord_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessment_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessmentEducationOrganizationAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessmentRegistration_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentAssessmentRegistration_TR_UpdateChangeVersion] ON [edfi].[StudentAssessmentRegistration] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[StudentAssessmentRegistration]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentAssessmentRegistration] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessmentRegistrationBatteryPartAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCohortAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCompetencyObjective_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentContactAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentBehaviorAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationAssessmentAccommodation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationResponsibilityAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentGradebookEntry_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentGradebookEntry_TR_UpdateChangeVersion] ON [edfi].[StudentGradebookEntry] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[StudentGradebookEntry]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentGradebookEntry] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentGradebookEntry(
        OldGradebookEntryIdentifier, OldNamespace, OldStudentUSI, OldStudentUniqueId, 
        NewGradebookEntryIdentifier, NewNamespace, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.GradebookEntryIdentifier, d.Namespace, d.StudentUSI, dj0.StudentUniqueId, 
        i.GradebookEntryIdentifier, i.Namespace, i.StudentUSI, ij0.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId
        INNER JOIN edfi.Student dj0
            ON d.StudentUSI = dj0.StudentUSI
        INNER JOIN edfi.Student ij0
            ON i.StudentUSI = ij0.StudentUSI

    WHERE
        d.GradebookEntryIdentifier <> i.GradebookEntryIdentifier OR d.Namespace <> i.Namespace OR d.StudentUSI <> i.StudentUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentHealth_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentInterventionAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentInterventionAttendanceEvent_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentProgramAttendanceEvent_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentProgramEvaluation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSchoolAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSchoolAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentSchoolAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentSchoolAssociation(
        OldEntryDate, OldSchoolId, OldStudentUSI, OldStudentUniqueId, 
        NewEntryDate, NewSchoolId, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.EntryDate, d.SchoolId, d.StudentUSI, dj0.StudentUniqueId, 
        i.EntryDate, i.SchoolId, i.StudentUSI, ij0.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId
        INNER JOIN edfi.Student dj0
            ON d.StudentUSI = dj0.StudentUSI
        INNER JOIN edfi.Student ij0
            ON i.StudentUSI = ij0.StudentUSI

    WHERE
        d.EntryDate <> i.EntryDate OR d.SchoolId <> i.SchoolId OR d.StudentUSI <> i.StudentUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSchoolAttendanceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSchoolAttendanceEvent_TR_UpdateChangeVersion] ON [edfi].[StudentSchoolAttendanceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[StudentSchoolAttendanceEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentSchoolAttendanceEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentSchoolAttendanceEvent(
        OldAttendanceEventCategoryDescriptorId, OldAttendanceEventCategoryDescriptorNamespace, OldAttendanceEventCategoryDescriptorCodeValue, OldEventDate, OldSchoolId, OldSchoolYear, OldSessionName, OldStudentUSI, OldStudentUniqueId, 
        NewAttendanceEventCategoryDescriptorId, NewAttendanceEventCategoryDescriptorNamespace, NewAttendanceEventCategoryDescriptorCodeValue, NewEventDate, NewSchoolId, NewSchoolYear, NewSessionName, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.AttendanceEventCategoryDescriptorId, dj0.Namespace, dj0.CodeValue, d.EventDate, d.SchoolId, d.SchoolYear, d.SessionName, d.StudentUSI, dj1.StudentUniqueId, 
        i.AttendanceEventCategoryDescriptorId, ij0.Namespace, ij0.CodeValue, i.EventDate, i.SchoolId, i.SchoolYear, i.SessionName, i.StudentUSI, ij1.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId
        INNER JOIN edfi.Descriptor dj0
            ON d.AttendanceEventCategoryDescriptorId = dj0.DescriptorId
        INNER JOIN edfi.Student dj1
            ON d.StudentUSI = dj1.StudentUSI
        INNER JOIN edfi.Descriptor ij0
            ON i.AttendanceEventCategoryDescriptorId = ij0.DescriptorId
        INNER JOIN edfi.Student ij1
            ON i.StudentUSI = ij1.StudentUSI

    WHERE
        d.AttendanceEventCategoryDescriptorId <> i.AttendanceEventCategoryDescriptorId OR d.EventDate <> i.EventDate OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SessionName <> i.SessionName OR d.StudentUSI <> i.StudentUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSectionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSectionAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[StudentSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentSectionAssociation(
        OldBeginDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, 
        NewBeginDate, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.BeginDate, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, dj0.StudentUniqueId, 
        i.BeginDate, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.StudentUSI, ij0.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId
        INNER JOIN edfi.Student dj0
            ON d.StudentUSI = dj0.StudentUSI
        INNER JOIN edfi.Student ij0
            ON i.StudentUSI = ij0.StudentUSI

    WHERE
        d.BeginDate <> i.BeginDate OR d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName OR d.StudentUSI <> i.StudentUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSectionAttendanceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSectionAttendanceEvent_TR_UpdateChangeVersion] ON [edfi].[StudentSectionAttendanceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[StudentSectionAttendanceEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentSectionAttendanceEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentSectionAttendanceEvent(
        OldAttendanceEventCategoryDescriptorId, OldAttendanceEventCategoryDescriptorNamespace, OldAttendanceEventCategoryDescriptorCodeValue, OldEventDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, 
        NewAttendanceEventCategoryDescriptorId, NewAttendanceEventCategoryDescriptorNamespace, NewAttendanceEventCategoryDescriptorCodeValue, NewEventDate, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.AttendanceEventCategoryDescriptorId, dj0.Namespace, dj0.CodeValue, d.EventDate, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, dj1.StudentUniqueId, 
        i.AttendanceEventCategoryDescriptorId, ij0.Namespace, ij0.CodeValue, i.EventDate, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.StudentUSI, ij1.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId
        INNER JOIN edfi.Descriptor dj0
            ON d.AttendanceEventCategoryDescriptorId = dj0.DescriptorId
        INNER JOIN edfi.Student dj1
            ON d.StudentUSI = dj1.StudentUSI
        INNER JOIN edfi.Descriptor ij0
            ON i.AttendanceEventCategoryDescriptorId = ij0.DescriptorId
        INNER JOIN edfi.Student ij1
            ON i.StudentUSI = ij1.StudentUSI

    WHERE
        d.AttendanceEventCategoryDescriptorId <> i.AttendanceEventCategoryDescriptorId OR d.EventDate <> i.EventDate OR d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName OR d.StudentUSI <> i.StudentUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSpecialEducationProgramEligibilityAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentTransportation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Survey_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Survey_TR_UpdateChangeVersion] ON [edfi].[Survey] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[Survey]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Survey] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyCourseAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyProgramAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyQuestion_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyQuestionResponse_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponse_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponseStaffTargetAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySection_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveySectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    -- Handle cascading key changes
    UPDATE [edfi].[SurveySectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveySectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.AggregateId = u.AggregateId AND i.ChangeVersion = u.ChangeVersion);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.SurveySectionAssociation(
        OldLocalCourseCode, OldNamespace, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldSurveyIdentifier, 
        NewLocalCourseCode, NewNamespace, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewSurveyIdentifier, 
        Id, ChangeVersion)
    SELECT
        d.LocalCourseCode, d.Namespace, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.SurveyIdentifier, 
        i.LocalCourseCode, i.Namespace, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.SurveyIdentifier, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.AggregateId = i.AggregateId

    WHERE
        d.LocalCourseCode <> i.LocalCourseCode OR d.Namespace <> i.Namespace OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName OR d.SurveyIdentifier <> i.SurveyIdentifier;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponse_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion]
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponseStaffTargetAssociation_TR_UpdateChangeVersion]
GO

