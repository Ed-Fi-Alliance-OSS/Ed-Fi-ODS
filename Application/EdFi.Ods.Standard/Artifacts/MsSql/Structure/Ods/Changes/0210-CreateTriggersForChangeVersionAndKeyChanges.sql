-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [edfi].[edfi_AcademicWeek_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_AcademicWeek_TR_UpdateChangeVersion] ON [edfi].[AcademicWeek] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[AcademicWeek]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[AcademicWeek] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AccountabilityRating_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_AccountabilityRating_TR_UpdateChangeVersion] ON [edfi].[AccountabilityRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[AccountabilityRating]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[AccountabilityRating] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Assessment_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Assessment_TR_UpdateChangeVersion] ON [edfi].[Assessment] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Assessment]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Assessment] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentItem_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentItem_TR_UpdateChangeVersion] ON [edfi].[AssessmentItem] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[AssessmentItem]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[AssessmentItem] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentScoreRangeLearningStandard_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentScoreRangeLearningStandard_TR_UpdateChangeVersion] ON [edfi].[AssessmentScoreRangeLearningStandard] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[AssessmentScoreRangeLearningStandard]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[AssessmentScoreRangeLearningStandard] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_BalanceSheetDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_BalanceSheetDimension_TR_UpdateChangeVersion] ON [edfi].[BalanceSheetDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[BalanceSheetDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[BalanceSheetDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_BellSchedule_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_BellSchedule_TR_UpdateChangeVersion] ON [edfi].[BellSchedule] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[BellSchedule]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[BellSchedule] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Calendar_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Calendar_TR_UpdateChangeVersion] ON [edfi].[Calendar] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Calendar]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Calendar] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CalendarDate_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CalendarDate_TR_UpdateChangeVersion] ON [edfi].[CalendarDate] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[CalendarDate]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[CalendarDate] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ChartOfAccount_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ChartOfAccount_TR_UpdateChangeVersion] ON [edfi].[ChartOfAccount] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[ChartOfAccount]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[ChartOfAccount] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ClassPeriod_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ClassPeriod_TR_UpdateChangeVersion] ON [edfi].[ClassPeriod] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[ClassPeriod]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[ClassPeriod] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.ClassPeriod(
        OldClassPeriodName, OldSchoolId, 
        NewClassPeriodName, NewSchoolId, 
        Id, ChangeVersion)
    SELECT
        d.ClassPeriodName, d.SchoolId, 
        i.ClassPeriodName, i.SchoolId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id

    WHERE
        d.ClassPeriodName <> i.ClassPeriodName OR d.SchoolId <> i.SchoolId;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Cohort_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Cohort_TR_UpdateChangeVersion] ON [edfi].[Cohort] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Cohort]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Cohort] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CommunityProviderLicense_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CommunityProviderLicense_TR_UpdateChangeVersion] ON [edfi].[CommunityProviderLicense] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[CommunityProviderLicense]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[CommunityProviderLicense] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CompetencyObjective_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CompetencyObjective_TR_UpdateChangeVersion] ON [edfi].[CompetencyObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[CompetencyObjective]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[CompetencyObjective] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Course_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Course_TR_UpdateChangeVersion] ON [edfi].[Course] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Course]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Course] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CourseOffering_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CourseOffering_TR_UpdateChangeVersion] ON [edfi].[CourseOffering] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[CourseOffering]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[CourseOffering] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.CourseOffering(
        OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSessionName, 
        NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSessionName, 
        Id, ChangeVersion)
    SELECT
        d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SessionName, 
        i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SessionName, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id

    WHERE
        d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SessionName <> i.SessionName;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CourseTranscript_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CourseTranscript_TR_UpdateChangeVersion] ON [edfi].[CourseTranscript] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[CourseTranscript]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[CourseTranscript] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Credential_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Credential_TR_UpdateChangeVersion] ON [edfi].[Credential] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Credential]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Credential] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Descriptor_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Descriptor_TR_UpdateChangeVersion] ON [edfi].[Descriptor] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Descriptor]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Descriptor] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DescriptorMapping_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_DescriptorMapping_TR_UpdateChangeVersion] ON [edfi].[DescriptorMapping] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[DescriptorMapping]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[DescriptorMapping] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineAction_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineAction_TR_UpdateChangeVersion] ON [edfi].[DisciplineAction] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[DisciplineAction]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[DisciplineAction] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineIncident_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineIncident_TR_UpdateChangeVersion] ON [edfi].[DisciplineIncident] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[DisciplineIncident]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[DisciplineIncident] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationContent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationContent_TR_UpdateChangeVersion] ON [edfi].[EducationContent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[EducationContent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[EducationContent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganization_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganization_TR_UpdateChangeVersion] ON [edfi].[EducationOrganization] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[EducationOrganization]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[EducationOrganization] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_UpdateChangeVersion] ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[EducationOrganizationInterventionPrescriptionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[EducationOrganizationInterventionPrescriptionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationNetworkAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationNetworkAssociation_TR_UpdateChangeVersion] ON [edfi].[EducationOrganizationNetworkAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[EducationOrganizationNetworkAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[EducationOrganizationNetworkAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationPeerAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationPeerAssociation_TR_UpdateChangeVersion] ON [edfi].[EducationOrganizationPeerAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[EducationOrganizationPeerAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[EducationOrganizationPeerAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FeederSchoolAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_FeederSchoolAssociation_TR_UpdateChangeVersion] ON [edfi].[FeederSchoolAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[FeederSchoolAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[FeederSchoolAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FunctionDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_FunctionDimension_TR_UpdateChangeVersion] ON [edfi].[FunctionDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[FunctionDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[FunctionDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FundDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_FundDimension_TR_UpdateChangeVersion] ON [edfi].[FundDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[FundDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[FundDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GeneralStudentProgramAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GeneralStudentProgramAssociation_TR_UpdateChangeVersion] ON [edfi].[GeneralStudentProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[GeneralStudentProgramAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[GeneralStudentProgramAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Grade_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Grade_TR_UpdateChangeVersion] ON [edfi].[Grade] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Grade]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Grade] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.Grade(
        OldBeginDate, OldGradeTypeDescriptorId, OldGradeTypeDescriptorNamespace, OldGradeTypeDescriptorCodeValue, OldGradingPeriodDescriptorId, OldGradingPeriodDescriptorNamespace, OldGradingPeriodDescriptorCodeValue, OldGradingPeriodSchoolYear, OldGradingPeriodSequence, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, 
        NewBeginDate, NewGradeTypeDescriptorId, NewGradeTypeDescriptorNamespace, NewGradeTypeDescriptorCodeValue, NewGradingPeriodDescriptorId, NewGradingPeriodDescriptorNamespace, NewGradingPeriodDescriptorCodeValue, NewGradingPeriodSchoolYear, NewGradingPeriodSequence, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.BeginDate, d.GradeTypeDescriptorId, dj0.Namespace, dj0.CodeValue, d.GradingPeriodDescriptorId, dj1.Namespace, dj1.CodeValue, d.GradingPeriodSchoolYear, d.GradingPeriodSequence, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, dj2.StudentUniqueId, 
        i.BeginDate, i.GradeTypeDescriptorId, ij0.Namespace, ij0.CodeValue, i.GradingPeriodDescriptorId, ij1.Namespace, ij1.CodeValue, i.GradingPeriodSchoolYear, i.GradingPeriodSequence, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.StudentUSI, ij2.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id
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
        d.BeginDate <> i.BeginDate OR d.GradeTypeDescriptorId <> i.GradeTypeDescriptorId OR d.GradingPeriodDescriptorId <> i.GradingPeriodDescriptorId OR d.GradingPeriodSchoolYear <> i.GradingPeriodSchoolYear OR d.GradingPeriodSequence <> i.GradingPeriodSequence OR d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName OR d.StudentUSI <> i.StudentUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GradebookEntry_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GradebookEntry_TR_UpdateChangeVersion] ON [edfi].[GradebookEntry] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[GradebookEntry]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[GradebookEntry] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.GradebookEntry(
        OldGradebookEntryIdentifier, OldNamespace, 
        NewGradebookEntryIdentifier, NewNamespace, 
        Id, ChangeVersion)
    SELECT
        d.GradebookEntryIdentifier, d.Namespace, 
        i.GradebookEntryIdentifier, i.Namespace, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id

    WHERE
        d.GradebookEntryIdentifier <> i.GradebookEntryIdentifier OR d.Namespace <> i.Namespace;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GradingPeriod_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GradingPeriod_TR_UpdateChangeVersion] ON [edfi].[GradingPeriod] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[GradingPeriod]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[GradingPeriod] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GraduationPlan_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GraduationPlan_TR_UpdateChangeVersion] ON [edfi].[GraduationPlan] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[GraduationPlan]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[GraduationPlan] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Intervention_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Intervention_TR_UpdateChangeVersion] ON [edfi].[Intervention] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Intervention]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Intervention] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionPrescription_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_InterventionPrescription_TR_UpdateChangeVersion] ON [edfi].[InterventionPrescription] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[InterventionPrescription]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[InterventionPrescription] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionStudy_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_InterventionStudy_TR_UpdateChangeVersion] ON [edfi].[InterventionStudy] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[InterventionStudy]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[InterventionStudy] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LearningObjective_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LearningObjective_TR_UpdateChangeVersion] ON [edfi].[LearningObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LearningObjective]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LearningObjective] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandard_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandard_TR_UpdateChangeVersion] ON [edfi].[LearningStandard] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LearningStandard]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LearningStandard] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandardEquivalenceAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandardEquivalenceAssociation_TR_UpdateChangeVersion] ON [edfi].[LearningStandardEquivalenceAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LearningStandardEquivalenceAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LearningStandardEquivalenceAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalAccount_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalAccount_TR_UpdateChangeVersion] ON [edfi].[LocalAccount] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LocalAccount]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LocalAccount] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalActual_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalActual_TR_UpdateChangeVersion] ON [edfi].[LocalActual] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LocalActual]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LocalActual] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalBudget_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalBudget_TR_UpdateChangeVersion] ON [edfi].[LocalBudget] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LocalBudget]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LocalBudget] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalContractedStaff_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalContractedStaff_TR_UpdateChangeVersion] ON [edfi].[LocalContractedStaff] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LocalContractedStaff]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LocalContractedStaff] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalEncumbrance_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalEncumbrance_TR_UpdateChangeVersion] ON [edfi].[LocalEncumbrance] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LocalEncumbrance]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LocalEncumbrance] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalPayroll_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalPayroll_TR_UpdateChangeVersion] ON [edfi].[LocalPayroll] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[LocalPayroll]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[LocalPayroll] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Location_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Location_TR_UpdateChangeVersion] ON [edfi].[Location] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Location]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Location] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.Location(
        OldClassroomIdentificationCode, OldSchoolId, 
        NewClassroomIdentificationCode, NewSchoolId, 
        Id, ChangeVersion)
    SELECT
        d.ClassroomIdentificationCode, d.SchoolId, 
        i.ClassroomIdentificationCode, i.SchoolId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id

    WHERE
        d.ClassroomIdentificationCode <> i.ClassroomIdentificationCode OR d.SchoolId <> i.SchoolId;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ObjectDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ObjectDimension_TR_UpdateChangeVersion] ON [edfi].[ObjectDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[ObjectDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[ObjectDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ObjectiveAssessment_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ObjectiveAssessment_TR_UpdateChangeVersion] ON [edfi].[ObjectiveAssessment] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[ObjectiveAssessment]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[ObjectiveAssessment] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_OpenStaffPosition_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_OpenStaffPosition_TR_UpdateChangeVersion] ON [edfi].[OpenStaffPosition] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[OpenStaffPosition]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[OpenStaffPosition] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_OperationalUnitDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_OperationalUnitDimension_TR_UpdateChangeVersion] ON [edfi].[OperationalUnitDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[OperationalUnitDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[OperationalUnitDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Parent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Parent_TR_UpdateChangeVersion] ON [edfi].[Parent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Parent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Parent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    ---- Add key change entry when UniqueId is modified
    INSERT INTO [tracked_changes_edfi].[Parent] (
        OldParentUSI, OldParentUniqueId, 
        NewParentUSI, NewParentUniqueId,
        Id, ChangeVersion)
    SELECT
        old.ParentUSI, old.ParentUniqueId, 
        new.ParentUSI, new.ParentUniqueId,
        old.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted old INNER JOIN inserted new ON old.ParentUSI = new.ParentUSI
    WHERE new.ParentUniqueId <> old.ParentUniqueId;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Person_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Person_TR_UpdateChangeVersion] ON [edfi].[Person] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Person]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Person] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_PostSecondaryEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_PostSecondaryEvent_TR_UpdateChangeVersion] ON [edfi].[PostSecondaryEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[PostSecondaryEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[PostSecondaryEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Program_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Program_TR_UpdateChangeVersion] ON [edfi].[Program] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Program]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Program] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ProgramDimension_TR_UpdateChangeVersion] ON [edfi].[ProgramDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[ProgramDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[ProgramDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProjectDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ProjectDimension_TR_UpdateChangeVersion] ON [edfi].[ProjectDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[ProjectDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[ProjectDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ReportCard_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ReportCard_TR_UpdateChangeVersion] ON [edfi].[ReportCard] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[ReportCard]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[ReportCard] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_RestraintEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_RestraintEvent_TR_UpdateChangeVersion] ON [edfi].[RestraintEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[RestraintEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[RestraintEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolYearType_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SchoolYearType_TR_UpdateChangeVersion] ON [edfi].[SchoolYearType] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SchoolYearType]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SchoolYearType] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Section_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Section_TR_UpdateChangeVersion] ON [edfi].[Section] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Section]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Section] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.Section(
        OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, 
        NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, 
        Id, ChangeVersion)
    SELECT
        d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, 
        i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id

    WHERE
        d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SectionAttendanceTakenEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SectionAttendanceTakenEvent_TR_UpdateChangeVersion] ON [edfi].[SectionAttendanceTakenEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SectionAttendanceTakenEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SectionAttendanceTakenEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.SectionAttendanceTakenEvent(
        OldCalendarCode, OldDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, 
        NewCalendarCode, NewDate, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, 
        Id, ChangeVersion)
    SELECT
        d.CalendarCode, d.Date, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, 
        i.CalendarCode, i.Date, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id

    WHERE
        d.CalendarCode <> i.CalendarCode OR d.Date <> i.Date OR d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Session_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Session_TR_UpdateChangeVersion] ON [edfi].[Session] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Session]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Session] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.Session(
        OldSchoolId, OldSchoolYear, OldSessionName, 
        NewSchoolId, NewSchoolYear, NewSessionName, 
        Id, ChangeVersion)
    SELECT
        d.SchoolId, d.SchoolYear, d.SessionName, 
        i.SchoolId, i.SchoolYear, i.SessionName, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id

    WHERE
        d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SessionName <> i.SessionName;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SourceDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SourceDimension_TR_UpdateChangeVersion] ON [edfi].[SourceDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SourceDimension]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SourceDimension] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Staff_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Staff_TR_UpdateChangeVersion] ON [edfi].[Staff] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Staff]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Staff] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    ---- Add key change entry when UniqueId is modified
    INSERT INTO [tracked_changes_edfi].[Staff] (
        OldStaffUSI, OldStaffUniqueId, 
        NewStaffUSI, NewStaffUniqueId,
        Id, ChangeVersion)
    SELECT
        old.StaffUSI, old.StaffUniqueId, 
        new.StaffUSI, new.StaffUniqueId,
        old.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted old INNER JOIN inserted new ON old.StaffUSI = new.StaffUSI
    WHERE new.StaffUniqueId <> old.StaffUniqueId;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffAbsenceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffAbsenceEvent_TR_UpdateChangeVersion] ON [edfi].[StaffAbsenceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffAbsenceEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffAbsenceEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffCohortAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffCohortAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffCohortAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffCohortAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffCohortAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffDisciplineIncidentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffDisciplineIncidentAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffDisciplineIncidentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffDisciplineIncidentAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffDisciplineIncidentAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationAssignmentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationAssignmentAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffEducationOrganizationAssignmentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffEducationOrganizationAssignmentAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffEducationOrganizationAssignmentAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationContactAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationContactAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffEducationOrganizationContactAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffEducationOrganizationContactAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffEducationOrganizationContactAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationEmploymentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationEmploymentAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffEducationOrganizationEmploymentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffEducationOrganizationEmploymentAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffEducationOrganizationEmploymentAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffLeave_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffLeave_TR_UpdateChangeVersion] ON [edfi].[StaffLeave] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffLeave]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffLeave] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffProgramAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffProgramAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffProgramAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffProgramAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffSchoolAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffSchoolAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffSchoolAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffSchoolAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffSchoolAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffSectionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffSectionAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StaffSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StaffSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StaffSectionAssociation(
        OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStaffUSI, OldStaffUniqueId, 
        NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewStaffUSI, NewStaffUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StaffUSI, dj0.StaffUniqueId, 
        i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.StaffUSI, ij0.StaffUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id
        INNER JOIN edfi.Staff dj0
            ON d.StaffUSI = dj0.StaffUSI
        INNER JOIN edfi.Staff ij0
            ON i.StaffUSI = ij0.StaffUSI

    WHERE
        d.LocalCourseCode <> i.LocalCourseCode OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName OR d.StaffUSI <> i.StaffUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Student_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Student_TR_UpdateChangeVersion] ON [edfi].[Student] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Student]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Student] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    ---- Add key change entry when UniqueId is modified
    INSERT INTO [tracked_changes_edfi].[Student] (
        OldStudentUSI, OldStudentUniqueId, 
        NewStudentUSI, NewStudentUniqueId,
        Id, ChangeVersion)
    SELECT
        old.StudentUSI, old.StudentUniqueId, 
        new.StudentUSI, new.StudentUniqueId,
        old.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted old INNER JOIN inserted new ON old.StudentUSI = new.StudentUSI
    WHERE new.StudentUniqueId <> old.StudentUniqueId;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAcademicRecord_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentAcademicRecord_TR_UpdateChangeVersion] ON [edfi].[StudentAcademicRecord] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentAcademicRecord]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentAcademicRecord] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessment_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentAssessment_TR_UpdateChangeVersion] ON [edfi].[StudentAssessment] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentAssessment]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentAssessment] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCohortAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentCohortAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentCohortAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentCohortAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentCohortAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCompetencyObjective_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentCompetencyObjective_TR_UpdateChangeVersion] ON [edfi].[StudentCompetencyObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentCompetencyObjective]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentCompetencyObjective] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentDisciplineIncidentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentDisciplineIncidentAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentDisciplineIncidentAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentBehaviorAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentBehaviorAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentDisciplineIncidentBehaviorAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentDisciplineIncidentBehaviorAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentDisciplineIncidentBehaviorAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentDisciplineIncidentNonOffenderAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentDisciplineIncidentNonOffenderAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentEducationOrganizationAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentEducationOrganizationAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentEducationOrganizationAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentEducationOrganizationAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationResponsibilityAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentEducationOrganizationResponsibilityAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentEducationOrganizationResponsibilityAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentEducationOrganizationResponsibilityAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentEducationOrganizationResponsibilityAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentGradebookEntry_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentGradebookEntry_TR_UpdateChangeVersion] ON [edfi].[StudentGradebookEntry] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentGradebookEntry]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentGradebookEntry] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentGradebookEntry(
        OldGradebookEntryIdentifier, OldNamespace, OldStudentUSI, OldStudentUniqueId, 
        NewGradebookEntryIdentifier, NewNamespace, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.GradebookEntryIdentifier, d.Namespace, d.StudentUSI, dj0.StudentUniqueId, 
        i.GradebookEntryIdentifier, i.Namespace, i.StudentUSI, ij0.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id
        INNER JOIN edfi.Student dj0
            ON d.StudentUSI = dj0.StudentUSI
        INNER JOIN edfi.Student ij0
            ON i.StudentUSI = ij0.StudentUSI

    WHERE
        d.GradebookEntryIdentifier <> i.GradebookEntryIdentifier OR d.Namespace <> i.Namespace OR d.StudentUSI <> i.StudentUSI;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentInterventionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentInterventionAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentInterventionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentInterventionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentInterventionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentInterventionAttendanceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentInterventionAttendanceEvent_TR_UpdateChangeVersion] ON [edfi].[StudentInterventionAttendanceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentInterventionAttendanceEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentInterventionAttendanceEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentLearningObjective_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentLearningObjective_TR_UpdateChangeVersion] ON [edfi].[StudentLearningObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentLearningObjective]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentLearningObjective] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentParentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentParentAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentParentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentParentAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentParentAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentProgramAttendanceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentProgramAttendanceEvent_TR_UpdateChangeVersion] ON [edfi].[StudentProgramAttendanceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentProgramAttendanceEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentProgramAttendanceEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSchoolAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSchoolAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentSchoolAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[StudentSchoolAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentSchoolAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentSchoolAssociation(
        OldEntryDate, OldSchoolId, OldStudentUSI, OldStudentUniqueId, 
        NewEntryDate, NewSchoolId, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.EntryDate, d.SchoolId, d.StudentUSI, dj0.StudentUniqueId, 
        i.EntryDate, i.SchoolId, i.StudentUSI, ij0.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id
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
    UPDATE [edfi].[StudentSchoolAttendanceEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentSchoolAttendanceEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentSchoolAttendanceEvent(
        OldAttendanceEventCategoryDescriptorId, OldAttendanceEventCategoryDescriptorNamespace, OldAttendanceEventCategoryDescriptorCodeValue, OldEventDate, OldSchoolId, OldSchoolYear, OldSessionName, OldStudentUSI, OldStudentUniqueId, 
        NewAttendanceEventCategoryDescriptorId, NewAttendanceEventCategoryDescriptorNamespace, NewAttendanceEventCategoryDescriptorCodeValue, NewEventDate, NewSchoolId, NewSchoolYear, NewSessionName, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.AttendanceEventCategoryDescriptorId, dj0.Namespace, dj0.CodeValue, d.EventDate, d.SchoolId, d.SchoolYear, d.SessionName, d.StudentUSI, dj1.StudentUniqueId, 
        i.AttendanceEventCategoryDescriptorId, ij0.Namespace, ij0.CodeValue, i.EventDate, i.SchoolId, i.SchoolYear, i.SessionName, i.StudentUSI, ij1.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id
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
    UPDATE [edfi].[StudentSectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentSectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentSectionAssociation(
        OldBeginDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, 
        NewBeginDate, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.BeginDate, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, dj0.StudentUniqueId, 
        i.BeginDate, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.StudentUSI, ij0.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id
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
    UPDATE [edfi].[StudentSectionAttendanceEvent]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[StudentSectionAttendanceEvent] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.StudentSectionAttendanceEvent(
        OldAttendanceEventCategoryDescriptorId, OldAttendanceEventCategoryDescriptorNamespace, OldAttendanceEventCategoryDescriptorCodeValue, OldEventDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, 
        NewAttendanceEventCategoryDescriptorId, NewAttendanceEventCategoryDescriptorNamespace, NewAttendanceEventCategoryDescriptorCodeValue, NewEventDate, NewLocalCourseCode, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewStudentUSI, NewStudentUniqueId, 
        Id, ChangeVersion)
    SELECT
        d.AttendanceEventCategoryDescriptorId, dj0.Namespace, dj0.CodeValue, d.EventDate, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, dj1.StudentUniqueId, 
        i.AttendanceEventCategoryDescriptorId, ij0.Namespace, ij0.CodeValue, i.EventDate, i.LocalCourseCode, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.StudentUSI, ij1.StudentUniqueId, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id
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

DROP TRIGGER IF EXISTS [edfi].[edfi_Survey_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Survey_TR_UpdateChangeVersion] ON [edfi].[Survey] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[Survey]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[Survey] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyCourseAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyCourseAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveyCourseAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveyCourseAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveyCourseAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyProgramAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyProgramAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveyProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveyProgramAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveyProgramAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyQuestion_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyQuestion_TR_UpdateChangeVersion] ON [edfi].[SurveyQuestion] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveyQuestion]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveyQuestion] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyQuestionResponse_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyQuestionResponse_TR_UpdateChangeVersion] ON [edfi].[SurveyQuestionResponse] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveyQuestionResponse]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveyQuestionResponse] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponse_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponse_TR_UpdateChangeVersion] ON [edfi].[SurveyResponse] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveyResponse]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveyResponse] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveyResponseEducationOrganizationTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveyResponseEducationOrganizationTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponseStaffTargetAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponseStaffTargetAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveyResponseStaffTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveyResponseStaffTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveyResponseStaffTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySection_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySection_TR_UpdateChangeVersion] ON [edfi].[SurveySection] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveySection]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveySection] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveySectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveySectionAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveySectionAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);

    -- Handle key changes
    INSERT INTO tracked_changes_edfi.SurveySectionAssociation(
        OldLocalCourseCode, OldNamespace, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldSurveyIdentifier, 
        NewLocalCourseCode, NewNamespace, NewSchoolId, NewSchoolYear, NewSectionIdentifier, NewSessionName, NewSurveyIdentifier, 
        Id, ChangeVersion)
    SELECT
        d.LocalCourseCode, d.Namespace, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.SurveyIdentifier, 
        i.LocalCourseCode, i.Namespace, i.SchoolId, i.SchoolYear, i.SectionIdentifier, i.SessionName, i.SurveyIdentifier, 
        d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM deleted d INNER JOIN inserted i ON d.Id = i.Id

    WHERE
        d.LocalCourseCode <> i.LocalCourseCode OR d.Namespace <> i.Namespace OR d.SchoolId <> i.SchoolId OR d.SchoolYear <> i.SchoolYear OR d.SectionIdentifier <> i.SectionIdentifier OR d.SessionName <> i.SessionName OR d.SurveyIdentifier <> i.SurveyIdentifier;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponse_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponse_TR_UpdateChangeVersion] ON [edfi].[SurveySectionResponse] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveySectionResponse]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveySectionResponse] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponseStaffTargetAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponseStaffTargetAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveySectionResponseStaffTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [edfi].[SurveySectionResponseStaffTargetAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [edfi].[SurveySectionResponseStaffTargetAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

