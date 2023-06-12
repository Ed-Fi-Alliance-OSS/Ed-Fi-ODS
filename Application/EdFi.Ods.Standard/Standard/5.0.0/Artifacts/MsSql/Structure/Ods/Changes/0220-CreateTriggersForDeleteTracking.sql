-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [edfi].[edfi_AbsenceEventCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AbsenceEventCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AbsenceEventCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AbsenceEventCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AbsenceEventCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AbsenceEventCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AbsenceEventCategoryDescriptor] ENABLE TRIGGER [edfi_AbsenceEventCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AcademicHonorCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AcademicHonorCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AcademicHonorCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AcademicHonorCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AcademicHonorCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AcademicHonorCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AcademicHonorCategoryDescriptor] ENABLE TRIGGER [edfi_AcademicHonorCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AcademicSubjectDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AcademicSubjectDescriptor_TR_DeleteTracking] ON [edfi].[AcademicSubjectDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AcademicSubjectDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AcademicSubjectDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AcademicSubjectDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AcademicSubjectDescriptor] ENABLE TRIGGER [edfi_AcademicSubjectDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AcademicWeek_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AcademicWeek_TR_DeleteTracking] ON [edfi].[AcademicWeek] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[AcademicWeek](OldSchoolId, OldWeekIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.SchoolId, d.WeekIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AcademicWeek] ENABLE TRIGGER [edfi_AcademicWeek_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AccommodationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AccommodationDescriptor_TR_DeleteTracking] ON [edfi].[AccommodationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AccommodationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AccommodationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AccommodationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AccommodationDescriptor] ENABLE TRIGGER [edfi_AccommodationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AccountabilityRating_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AccountabilityRating_TR_DeleteTracking] ON [edfi].[AccountabilityRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[AccountabilityRating](OldEducationOrganizationId, OldRatingTitle, OldSchoolYear, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.RatingTitle, d.SchoolYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AccountabilityRating] ENABLE TRIGGER [edfi_AccountabilityRating_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AccountTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AccountTypeDescriptor_TR_DeleteTracking] ON [edfi].[AccountTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AccountTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AccountTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AccountTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AccountTypeDescriptor] ENABLE TRIGGER [edfi_AccountTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AchievementCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AchievementCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AchievementCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AchievementCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AchievementCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AchievementCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AchievementCategoryDescriptor] ENABLE TRIGGER [edfi_AchievementCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AdditionalCreditTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AdditionalCreditTypeDescriptor_TR_DeleteTracking] ON [edfi].[AdditionalCreditTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AdditionalCreditTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AdditionalCreditTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AdditionalCreditTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AdditionalCreditTypeDescriptor] ENABLE TRIGGER [edfi_AdditionalCreditTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AddressTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AddressTypeDescriptor_TR_DeleteTracking] ON [edfi].[AddressTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AddressTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AddressTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AddressTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AddressTypeDescriptor] ENABLE TRIGGER [edfi_AddressTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AdministrationEnvironmentDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AdministrationEnvironmentDescriptor_TR_DeleteTracking] ON [edfi].[AdministrationEnvironmentDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AdministrationEnvironmentDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AdministrationEnvironmentDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AdministrationEnvironmentDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AdministrationEnvironmentDescriptor] ENABLE TRIGGER [edfi_AdministrationEnvironmentDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AdministrativeFundingControlDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AdministrativeFundingControlDescriptor_TR_DeleteTracking] ON [edfi].[AdministrativeFundingControlDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AdministrativeFundingControlDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AdministrativeFundingControlDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AdministrativeFundingControlDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AdministrativeFundingControlDescriptor] ENABLE TRIGGER [edfi_AdministrativeFundingControlDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AncestryEthnicOriginDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AncestryEthnicOriginDescriptor_TR_DeleteTracking] ON [edfi].[AncestryEthnicOriginDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AncestryEthnicOriginDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AncestryEthnicOriginDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AncestryEthnicOriginDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AncestryEthnicOriginDescriptor] ENABLE TRIGGER [edfi_AncestryEthnicOriginDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Assessment_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Assessment_TR_DeleteTracking] ON [edfi].[Assessment] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Assessment](OldAssessmentIdentifier, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT d.AssessmentIdentifier, d.Namespace, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Assessment] ENABLE TRIGGER [edfi_Assessment_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AssessmentCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AssessmentCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentCategoryDescriptor] ENABLE TRIGGER [edfi_AssessmentCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentIdentificationSystemDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AssessmentIdentificationSystemDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AssessmentIdentificationSystemDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_AssessmentIdentificationSystemDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentItem_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentItem_TR_DeleteTracking] ON [edfi].[AssessmentItem] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[AssessmentItem](OldAssessmentIdentifier, OldIdentificationCode, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT d.AssessmentIdentifier, d.IdentificationCode, d.Namespace, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AssessmentItem] ENABLE TRIGGER [edfi_AssessmentItem_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentItemCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentItemCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentItemCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AssessmentItemCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AssessmentItemCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentItemCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentItemCategoryDescriptor] ENABLE TRIGGER [edfi_AssessmentItemCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentItemResultDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentItemResultDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentItemResultDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AssessmentItemResultDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AssessmentItemResultDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentItemResultDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentItemResultDescriptor] ENABLE TRIGGER [edfi_AssessmentItemResultDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentPeriodDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentPeriodDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentPeriodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AssessmentPeriodDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AssessmentPeriodDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentPeriodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentPeriodDescriptor] ENABLE TRIGGER [edfi_AssessmentPeriodDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentReportingMethodDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentReportingMethodDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentReportingMethodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AssessmentReportingMethodDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AssessmentReportingMethodDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentReportingMethodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentReportingMethodDescriptor] ENABLE TRIGGER [edfi_AssessmentReportingMethodDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentScoreRangeLearningStandard_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentScoreRangeLearningStandard_TR_DeleteTracking] ON [edfi].[AssessmentScoreRangeLearningStandard] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[AssessmentScoreRangeLearningStandard](OldAssessmentIdentifier, OldNamespace, OldScoreRangeId, Id, Discriminator, ChangeVersion)
    SELECT d.AssessmentIdentifier, d.Namespace, d.ScoreRangeId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ENABLE TRIGGER [edfi_AssessmentScoreRangeLearningStandard_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AssignmentLateStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AssignmentLateStatusDescriptor_TR_DeleteTracking] ON [edfi].[AssignmentLateStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AssignmentLateStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AssignmentLateStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssignmentLateStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssignmentLateStatusDescriptor] ENABLE TRIGGER [edfi_AssignmentLateStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AttemptStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AttemptStatusDescriptor_TR_DeleteTracking] ON [edfi].[AttemptStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AttemptStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AttemptStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AttemptStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AttemptStatusDescriptor] ENABLE TRIGGER [edfi_AttemptStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_AttendanceEventCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_AttendanceEventCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AttendanceEventCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AttendanceEventCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.AttendanceEventCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AttendanceEventCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AttendanceEventCategoryDescriptor] ENABLE TRIGGER [edfi_AttendanceEventCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_BalanceSheetDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_BalanceSheetDimension_TR_DeleteTracking] ON [edfi].[BalanceSheetDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[BalanceSheetDimension](OldCode, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.Code, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[BalanceSheetDimension] ENABLE TRIGGER [edfi_BalanceSheetDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_BarrierToInternetAccessInResidenceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_BarrierToInternetAccessInResidenceDescriptor_TR_DeleteTracking] ON [edfi].[BarrierToInternetAccessInResidenceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.BarrierToInternetAccessInResidenceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.BarrierToInternetAccessInResidenceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.BarrierToInternetAccessInResidenceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[BarrierToInternetAccessInResidenceDescriptor] ENABLE TRIGGER [edfi_BarrierToInternetAccessInResidenceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_BehaviorDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_BehaviorDescriptor_TR_DeleteTracking] ON [edfi].[BehaviorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.BehaviorDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.BehaviorDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.BehaviorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[BehaviorDescriptor] ENABLE TRIGGER [edfi_BehaviorDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_BellSchedule_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_BellSchedule_TR_DeleteTracking] ON [edfi].[BellSchedule] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[BellSchedule](OldBellScheduleName, OldSchoolId, Id, Discriminator, ChangeVersion)
    SELECT d.BellScheduleName, d.SchoolId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[BellSchedule] ENABLE TRIGGER [edfi_BellSchedule_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Calendar_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Calendar_TR_DeleteTracking] ON [edfi].[Calendar] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Calendar](OldCalendarCode, OldSchoolId, OldSchoolYear, Id, Discriminator, ChangeVersion)
    SELECT d.CalendarCode, d.SchoolId, d.SchoolYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Calendar] ENABLE TRIGGER [edfi_Calendar_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CalendarDate_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CalendarDate_TR_DeleteTracking] ON [edfi].[CalendarDate] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[CalendarDate](OldCalendarCode, OldDate, OldSchoolId, OldSchoolYear, Id, Discriminator, ChangeVersion)
    SELECT d.CalendarCode, d.Date, d.SchoolId, d.SchoolYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[CalendarDate] ENABLE TRIGGER [edfi_CalendarDate_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CalendarEventDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CalendarEventDescriptor_TR_DeleteTracking] ON [edfi].[CalendarEventDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CalendarEventDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CalendarEventDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CalendarEventDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CalendarEventDescriptor] ENABLE TRIGGER [edfi_CalendarEventDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CalendarTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CalendarTypeDescriptor_TR_DeleteTracking] ON [edfi].[CalendarTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CalendarTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CalendarTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CalendarTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CalendarTypeDescriptor] ENABLE TRIGGER [edfi_CalendarTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CareerPathwayDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CareerPathwayDescriptor_TR_DeleteTracking] ON [edfi].[CareerPathwayDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CareerPathwayDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CareerPathwayDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CareerPathwayDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CareerPathwayDescriptor] ENABLE TRIGGER [edfi_CareerPathwayDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CharterApprovalAgencyTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CharterApprovalAgencyTypeDescriptor_TR_DeleteTracking] ON [edfi].[CharterApprovalAgencyTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CharterApprovalAgencyTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CharterApprovalAgencyTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CharterApprovalAgencyTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CharterApprovalAgencyTypeDescriptor] ENABLE TRIGGER [edfi_CharterApprovalAgencyTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CharterStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CharterStatusDescriptor_TR_DeleteTracking] ON [edfi].[CharterStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CharterStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CharterStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CharterStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CharterStatusDescriptor] ENABLE TRIGGER [edfi_CharterStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ChartOfAccount_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ChartOfAccount_TR_DeleteTracking] ON [edfi].[ChartOfAccount] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[ChartOfAccount](OldAccountIdentifier, OldEducationOrganizationId, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.AccountIdentifier, d.EducationOrganizationId, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ChartOfAccount] ENABLE TRIGGER [edfi_ChartOfAccount_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CitizenshipStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CitizenshipStatusDescriptor_TR_DeleteTracking] ON [edfi].[CitizenshipStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CitizenshipStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CitizenshipStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CitizenshipStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CitizenshipStatusDescriptor] ENABLE TRIGGER [edfi_CitizenshipStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ClassPeriod_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ClassPeriod_TR_DeleteTracking] ON [edfi].[ClassPeriod] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[ClassPeriod](OldClassPeriodName, OldSchoolId, Id, Discriminator, ChangeVersion)
    SELECT d.ClassPeriodName, d.SchoolId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ClassPeriod] ENABLE TRIGGER [edfi_ClassPeriod_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ClassroomPositionDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ClassroomPositionDescriptor_TR_DeleteTracking] ON [edfi].[ClassroomPositionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ClassroomPositionDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ClassroomPositionDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ClassroomPositionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ClassroomPositionDescriptor] ENABLE TRIGGER [edfi_ClassroomPositionDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Cohort_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Cohort_TR_DeleteTracking] ON [edfi].[Cohort] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Cohort](OldCohortIdentifier, OldEducationOrganizationId, Id, Discriminator, ChangeVersion)
    SELECT d.CohortIdentifier, d.EducationOrganizationId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Cohort] ENABLE TRIGGER [edfi_Cohort_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CohortScopeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CohortScopeDescriptor_TR_DeleteTracking] ON [edfi].[CohortScopeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CohortScopeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CohortScopeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CohortScopeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CohortScopeDescriptor] ENABLE TRIGGER [edfi_CohortScopeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CohortTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CohortTypeDescriptor_TR_DeleteTracking] ON [edfi].[CohortTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CohortTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CohortTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CohortTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CohortTypeDescriptor] ENABLE TRIGGER [edfi_CohortTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CohortYearTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CohortYearTypeDescriptor_TR_DeleteTracking] ON [edfi].[CohortYearTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CohortYearTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CohortYearTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CohortYearTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CohortYearTypeDescriptor] ENABLE TRIGGER [edfi_CohortYearTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CommunityProviderLicense_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CommunityProviderLicense_TR_DeleteTracking] ON [edfi].[CommunityProviderLicense] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[CommunityProviderLicense](OldCommunityProviderId, OldLicenseIdentifier, OldLicensingOrganization, Id, Discriminator, ChangeVersion)
    SELECT d.CommunityProviderId, d.LicenseIdentifier, d.LicensingOrganization, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[CommunityProviderLicense] ENABLE TRIGGER [edfi_CommunityProviderLicense_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CompetencyLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CompetencyLevelDescriptor_TR_DeleteTracking] ON [edfi].[CompetencyLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CompetencyLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CompetencyLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CompetencyLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CompetencyLevelDescriptor] ENABLE TRIGGER [edfi_CompetencyLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CompetencyObjective_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CompetencyObjective_TR_DeleteTracking] ON [edfi].[CompetencyObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[CompetencyObjective](OldEducationOrganizationId, OldObjective, OldObjectiveGradeLevelDescriptorId, OldObjectiveGradeLevelDescriptorNamespace, OldObjectiveGradeLevelDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.Objective, d.ObjectiveGradeLevelDescriptorId, j0.Namespace, j0.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ObjectiveGradeLevelDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [edfi].[CompetencyObjective] ENABLE TRIGGER [edfi_CompetencyObjective_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ContactTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ContactTypeDescriptor_TR_DeleteTracking] ON [edfi].[ContactTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ContactTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ContactTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ContactTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ContactTypeDescriptor] ENABLE TRIGGER [edfi_ContactTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ContentClassDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ContentClassDescriptor_TR_DeleteTracking] ON [edfi].[ContentClassDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ContentClassDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ContentClassDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ContentClassDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ContentClassDescriptor] ENABLE TRIGGER [edfi_ContentClassDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ContinuationOfServicesReasonDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ContinuationOfServicesReasonDescriptor_TR_DeleteTracking] ON [edfi].[ContinuationOfServicesReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ContinuationOfServicesReasonDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ContinuationOfServicesReasonDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ContinuationOfServicesReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ContinuationOfServicesReasonDescriptor] ENABLE TRIGGER [edfi_ContinuationOfServicesReasonDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CostRateDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CostRateDescriptor_TR_DeleteTracking] ON [edfi].[CostRateDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CostRateDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CostRateDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CostRateDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CostRateDescriptor] ENABLE TRIGGER [edfi_CostRateDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CountryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CountryDescriptor_TR_DeleteTracking] ON [edfi].[CountryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CountryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CountryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CountryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CountryDescriptor] ENABLE TRIGGER [edfi_CountryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Course_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Course_TR_DeleteTracking] ON [edfi].[Course] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Course](OldCourseCode, OldEducationOrganizationId, Id, Discriminator, ChangeVersion)
    SELECT d.CourseCode, d.EducationOrganizationId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Course] ENABLE TRIGGER [edfi_Course_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CourseAttemptResultDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CourseAttemptResultDescriptor_TR_DeleteTracking] ON [edfi].[CourseAttemptResultDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CourseAttemptResultDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CourseAttemptResultDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseAttemptResultDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseAttemptResultDescriptor] ENABLE TRIGGER [edfi_CourseAttemptResultDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CourseDefinedByDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CourseDefinedByDescriptor_TR_DeleteTracking] ON [edfi].[CourseDefinedByDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CourseDefinedByDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CourseDefinedByDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseDefinedByDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseDefinedByDescriptor] ENABLE TRIGGER [edfi_CourseDefinedByDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CourseGPAApplicabilityDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CourseGPAApplicabilityDescriptor_TR_DeleteTracking] ON [edfi].[CourseGPAApplicabilityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CourseGPAApplicabilityDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CourseGPAApplicabilityDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseGPAApplicabilityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseGPAApplicabilityDescriptor] ENABLE TRIGGER [edfi_CourseGPAApplicabilityDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CourseIdentificationSystemDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CourseIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[CourseIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CourseIdentificationSystemDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CourseIdentificationSystemDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_CourseIdentificationSystemDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CourseLevelCharacteristicDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CourseLevelCharacteristicDescriptor_TR_DeleteTracking] ON [edfi].[CourseLevelCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CourseLevelCharacteristicDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CourseLevelCharacteristicDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseLevelCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseLevelCharacteristicDescriptor] ENABLE TRIGGER [edfi_CourseLevelCharacteristicDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CourseOffering_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CourseOffering_TR_DeleteTracking] ON [edfi].[CourseOffering] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[CourseOffering](OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSessionName, Id, Discriminator, ChangeVersion)
    SELECT d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SessionName, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[CourseOffering] ENABLE TRIGGER [edfi_CourseOffering_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CourseRepeatCodeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CourseRepeatCodeDescriptor_TR_DeleteTracking] ON [edfi].[CourseRepeatCodeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CourseRepeatCodeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CourseRepeatCodeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseRepeatCodeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseRepeatCodeDescriptor] ENABLE TRIGGER [edfi_CourseRepeatCodeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CourseTranscript_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CourseTranscript_TR_DeleteTracking] ON [edfi].[CourseTranscript] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[CourseTranscript](OldCourseAttemptResultDescriptorId, OldCourseAttemptResultDescriptorNamespace, OldCourseAttemptResultDescriptorCodeValue, OldCourseCode, OldCourseEducationOrganizationId, OldEducationOrganizationId, OldSchoolYear, OldStudentUSI, OldStudentUniqueId, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.CourseAttemptResultDescriptorId, j0.Namespace, j0.CodeValue, d.CourseCode, d.CourseEducationOrganizationId, d.EducationOrganizationId, d.SchoolYear, d.StudentUSI, j1.StudentUniqueId, d.TermDescriptorId, j2.Namespace, j2.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.CourseAttemptResultDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
        INNER JOIN edfi.Descriptor j2
            ON d.TermDescriptorId = j2.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseTranscript] ENABLE TRIGGER [edfi_CourseTranscript_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Credential_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Credential_TR_DeleteTracking] ON [edfi].[Credential] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Credential](OldCredentialIdentifier, OldStateOfIssueStateAbbreviationDescriptorId, OldStateOfIssueStateAbbreviationDescriptorNamespace, OldStateOfIssueStateAbbreviationDescriptorCodeValue, Id, OldNamespace, Discriminator, ChangeVersion)
    SELECT d.CredentialIdentifier, d.StateOfIssueStateAbbreviationDescriptorId, j0.Namespace, j0.CodeValue, d.Id, d.Namespace, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.StateOfIssueStateAbbreviationDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [edfi].[Credential] ENABLE TRIGGER [edfi_Credential_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CredentialFieldDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CredentialFieldDescriptor_TR_DeleteTracking] ON [edfi].[CredentialFieldDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CredentialFieldDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CredentialFieldDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CredentialFieldDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CredentialFieldDescriptor] ENABLE TRIGGER [edfi_CredentialFieldDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CredentialTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CredentialTypeDescriptor_TR_DeleteTracking] ON [edfi].[CredentialTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CredentialTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CredentialTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CredentialTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CredentialTypeDescriptor] ENABLE TRIGGER [edfi_CredentialTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CreditCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CreditCategoryDescriptor_TR_DeleteTracking] ON [edfi].[CreditCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CreditCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CreditCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CreditCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CreditCategoryDescriptor] ENABLE TRIGGER [edfi_CreditCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CreditTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CreditTypeDescriptor_TR_DeleteTracking] ON [edfi].[CreditTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CreditTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CreditTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CreditTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CreditTypeDescriptor] ENABLE TRIGGER [edfi_CreditTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CTEProgramServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CTEProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[CTEProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CTEProgramServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CTEProgramServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CTEProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CTEProgramServiceDescriptor] ENABLE TRIGGER [edfi_CTEProgramServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_CurriculumUsedDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_CurriculumUsedDescriptor_TR_DeleteTracking] ON [edfi].[CurriculumUsedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.CurriculumUsedDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.CurriculumUsedDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CurriculumUsedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CurriculumUsedDescriptor] ENABLE TRIGGER [edfi_CurriculumUsedDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DeliveryMethodDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DeliveryMethodDescriptor_TR_DeleteTracking] ON [edfi].[DeliveryMethodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DeliveryMethodDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DeliveryMethodDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DeliveryMethodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DeliveryMethodDescriptor] ENABLE TRIGGER [edfi_DeliveryMethodDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DescriptorMapping_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DescriptorMapping_TR_DeleteTracking] ON [edfi].[DescriptorMapping] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[DescriptorMapping](OldMappedNamespace, OldMappedValue, OldNamespace, OldValue, Id, Discriminator, ChangeVersion)
    SELECT d.MappedNamespace, d.MappedValue, d.Namespace, d.Value, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[DescriptorMapping] ENABLE TRIGGER [edfi_DescriptorMapping_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DiagnosisDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DiagnosisDescriptor_TR_DeleteTracking] ON [edfi].[DiagnosisDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DiagnosisDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DiagnosisDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DiagnosisDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DiagnosisDescriptor] ENABLE TRIGGER [edfi_DiagnosisDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DiplomaLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DiplomaLevelDescriptor_TR_DeleteTracking] ON [edfi].[DiplomaLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DiplomaLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DiplomaLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DiplomaLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DiplomaLevelDescriptor] ENABLE TRIGGER [edfi_DiplomaLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DiplomaTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DiplomaTypeDescriptor_TR_DeleteTracking] ON [edfi].[DiplomaTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DiplomaTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DiplomaTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DiplomaTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DiplomaTypeDescriptor] ENABLE TRIGGER [edfi_DiplomaTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DisabilityDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DisabilityDescriptor_TR_DeleteTracking] ON [edfi].[DisabilityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DisabilityDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DisabilityDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisabilityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisabilityDescriptor] ENABLE TRIGGER [edfi_DisabilityDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DisabilityDesignationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DisabilityDesignationDescriptor_TR_DeleteTracking] ON [edfi].[DisabilityDesignationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DisabilityDesignationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DisabilityDesignationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisabilityDesignationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisabilityDesignationDescriptor] ENABLE TRIGGER [edfi_DisabilityDesignationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DisabilityDeterminationSourceTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DisabilityDeterminationSourceTypeDescriptor_TR_DeleteTracking] ON [edfi].[DisabilityDeterminationSourceTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DisabilityDeterminationSourceTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DisabilityDeterminationSourceTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisabilityDeterminationSourceTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisabilityDeterminationSourceTypeDescriptor] ENABLE TRIGGER [edfi_DisabilityDeterminationSourceTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineAction_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineAction_TR_DeleteTracking] ON [edfi].[DisciplineAction] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[DisciplineAction](OldDisciplineActionIdentifier, OldDisciplineDate, OldStudentUSI, OldStudentUniqueId, OldResponsibilitySchoolId, Id, Discriminator, ChangeVersion)
    SELECT d.DisciplineActionIdentifier, d.DisciplineDate, d.StudentUSI, j0.StudentUniqueId, d.ResponsibilitySchoolId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[DisciplineAction] ENABLE TRIGGER [edfi_DisciplineAction_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineActionLengthDifferenceReasonDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineActionLengthDifferenceReasonDescriptor_TR_DeleteTracking] ON [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DisciplineActionLengthDifferenceReasonDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DisciplineActionLengthDifferenceReasonDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisciplineActionLengthDifferenceReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] ENABLE TRIGGER [edfi_DisciplineActionLengthDifferenceReasonDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineDescriptor_TR_DeleteTracking] ON [edfi].[DisciplineDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DisciplineDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DisciplineDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisciplineDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisciplineDescriptor] ENABLE TRIGGER [edfi_DisciplineDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineIncident_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineIncident_TR_DeleteTracking] ON [edfi].[DisciplineIncident] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[DisciplineIncident](OldIncidentIdentifier, OldSchoolId, Id, Discriminator, ChangeVersion)
    SELECT d.IncidentIdentifier, d.SchoolId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[DisciplineIncident] ENABLE TRIGGER [edfi_DisciplineIncident_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineIncidentParticipationCodeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineIncidentParticipationCodeDescriptor_TR_DeleteTracking] ON [edfi].[DisciplineIncidentParticipationCodeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.DisciplineIncidentParticipationCodeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.DisciplineIncidentParticipationCodeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisciplineIncidentParticipationCodeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisciplineIncidentParticipationCodeDescriptor] ENABLE TRIGGER [edfi_DisciplineIncidentParticipationCodeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationalEnvironmentDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationalEnvironmentDescriptor_TR_DeleteTracking] ON [edfi].[EducationalEnvironmentDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EducationalEnvironmentDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EducationalEnvironmentDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationalEnvironmentDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationalEnvironmentDescriptor] ENABLE TRIGGER [edfi_EducationalEnvironmentDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationContent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationContent_TR_DeleteTracking] ON [edfi].[EducationContent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[EducationContent](OldContentIdentifier, Id, OldNamespace, Discriminator, ChangeVersion)
    SELECT d.ContentIdentifier, d.Id, d.Namespace, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationContent] ENABLE TRIGGER [edfi_EducationContent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganization_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganization_TR_DeleteTracking] ON [edfi].[EducationOrganization] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[EducationOrganization](OldEducationOrganizationId, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationOrganization] ENABLE TRIGGER [edfi_EducationOrganization_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationAssociationTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationAssociationTypeDescriptor_TR_DeleteTracking] ON [edfi].[EducationOrganizationAssociationTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EducationOrganizationAssociationTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EducationOrganizationAssociationTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationOrganizationAssociationTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationOrganizationAssociationTypeDescriptor] ENABLE TRIGGER [edfi_EducationOrganizationAssociationTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationCategoryDescriptor_TR_DeleteTracking] ON [edfi].[EducationOrganizationCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EducationOrganizationCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EducationOrganizationCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationOrganizationCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationOrganizationCategoryDescriptor] ENABLE TRIGGER [edfi_EducationOrganizationCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationIdentificationSystemDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[EducationOrganizationIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EducationOrganizationIdentificationSystemDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EducationOrganizationIdentificationSystemDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationOrganizationIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationOrganizationIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_EducationOrganizationIdentificationSystemDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_DeleteTracking] ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[EducationOrganizationInterventionPrescriptionAssociation](OldEducationOrganizationId, OldInterventionPrescriptionEducationOrganizationId, OldInterventionPrescriptionIdentificationCode, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.InterventionPrescriptionEducationOrganizationId, d.InterventionPrescriptionIdentificationCode, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ENABLE TRIGGER [edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationNetworkAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationNetworkAssociation_TR_DeleteTracking] ON [edfi].[EducationOrganizationNetworkAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[EducationOrganizationNetworkAssociation](OldEducationOrganizationNetworkId, OldMemberEducationOrganizationId, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationNetworkId, d.MemberEducationOrganizationId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ENABLE TRIGGER [edfi_EducationOrganizationNetworkAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationPeerAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationPeerAssociation_TR_DeleteTracking] ON [edfi].[EducationOrganizationPeerAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[EducationOrganizationPeerAssociation](OldEducationOrganizationId, OldPeerEducationOrganizationId, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.PeerEducationOrganizationId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ENABLE TRIGGER [edfi_EducationOrganizationPeerAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EducationPlanDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EducationPlanDescriptor_TR_DeleteTracking] ON [edfi].[EducationPlanDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EducationPlanDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EducationPlanDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationPlanDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationPlanDescriptor] ENABLE TRIGGER [edfi_EducationPlanDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ElectronicMailTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ElectronicMailTypeDescriptor_TR_DeleteTracking] ON [edfi].[ElectronicMailTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ElectronicMailTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ElectronicMailTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ElectronicMailTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ElectronicMailTypeDescriptor] ENABLE TRIGGER [edfi_ElectronicMailTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EmploymentStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EmploymentStatusDescriptor_TR_DeleteTracking] ON [edfi].[EmploymentStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EmploymentStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EmploymentStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EmploymentStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EmploymentStatusDescriptor] ENABLE TRIGGER [edfi_EmploymentStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EnrollmentTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EnrollmentTypeDescriptor_TR_DeleteTracking] ON [edfi].[EnrollmentTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EnrollmentTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EnrollmentTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EnrollmentTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EnrollmentTypeDescriptor] ENABLE TRIGGER [edfi_EnrollmentTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EntryGradeLevelReasonDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EntryGradeLevelReasonDescriptor_TR_DeleteTracking] ON [edfi].[EntryGradeLevelReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EntryGradeLevelReasonDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EntryGradeLevelReasonDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EntryGradeLevelReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EntryGradeLevelReasonDescriptor] ENABLE TRIGGER [edfi_EntryGradeLevelReasonDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EntryTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EntryTypeDescriptor_TR_DeleteTracking] ON [edfi].[EntryTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EntryTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EntryTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EntryTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EntryTypeDescriptor] ENABLE TRIGGER [edfi_EntryTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_EventCircumstanceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_EventCircumstanceDescriptor_TR_DeleteTracking] ON [edfi].[EventCircumstanceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.EventCircumstanceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.EventCircumstanceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EventCircumstanceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EventCircumstanceDescriptor] ENABLE TRIGGER [edfi_EventCircumstanceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ExitWithdrawTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ExitWithdrawTypeDescriptor_TR_DeleteTracking] ON [edfi].[ExitWithdrawTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ExitWithdrawTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ExitWithdrawTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ExitWithdrawTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ExitWithdrawTypeDescriptor] ENABLE TRIGGER [edfi_ExitWithdrawTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_FeederSchoolAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_FeederSchoolAssociation_TR_DeleteTracking] ON [edfi].[FeederSchoolAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[FeederSchoolAssociation](OldBeginDate, OldFeederSchoolId, OldSchoolId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.FeederSchoolId, d.SchoolId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[FeederSchoolAssociation] ENABLE TRIGGER [edfi_FeederSchoolAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_FinancialCollectionDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_FinancialCollectionDescriptor_TR_DeleteTracking] ON [edfi].[FinancialCollectionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.FinancialCollectionDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.FinancialCollectionDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.FinancialCollectionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[FinancialCollectionDescriptor] ENABLE TRIGGER [edfi_FinancialCollectionDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_FunctionDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_FunctionDimension_TR_DeleteTracking] ON [edfi].[FunctionDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[FunctionDimension](OldCode, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.Code, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[FunctionDimension] ENABLE TRIGGER [edfi_FunctionDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_FundDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_FundDimension_TR_DeleteTracking] ON [edfi].[FundDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[FundDimension](OldCode, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.Code, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[FundDimension] ENABLE TRIGGER [edfi_FundDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GeneralStudentProgramAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GeneralStudentProgramAssociation_TR_DeleteTracking] ON [edfi].[GeneralStudentProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[GeneralStudentProgramAssociation](OldBeginDate, OldEducationOrganizationId, OldProgramEducationOrganizationId, OldProgramName, OldProgramTypeDescriptorId, OldProgramTypeDescriptorNamespace, OldProgramTypeDescriptorCodeValue, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, j0.Namespace, j0.CodeValue, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ProgramTypeDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ENABLE TRIGGER [edfi_GeneralStudentProgramAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Grade_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Grade_TR_DeleteTracking] ON [edfi].[Grade] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Grade](OldBeginDate, OldGradeTypeDescriptorId, OldGradeTypeDescriptorNamespace, OldGradeTypeDescriptorCodeValue, OldGradingPeriodDescriptorId, OldGradingPeriodDescriptorNamespace, OldGradingPeriodDescriptorCodeValue, OldGradingPeriodSchoolYear, OldGradingPeriodSequence, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.GradeTypeDescriptorId, j0.Namespace, j0.CodeValue, d.GradingPeriodDescriptorId, j1.Namespace, j1.CodeValue, d.GradingPeriodSchoolYear, d.GradingPeriodSequence, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, j2.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.GradeTypeDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.GradingPeriodDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Student j2
            ON d.StudentUSI = j2.StudentUSI
END
GO

ALTER TABLE [edfi].[Grade] ENABLE TRIGGER [edfi_Grade_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GradebookEntry_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GradebookEntry_TR_DeleteTracking] ON [edfi].[GradebookEntry] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[GradebookEntry](OldGradebookEntryIdentifier, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT d.GradebookEntryIdentifier, d.Namespace, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[GradebookEntry] ENABLE TRIGGER [edfi_GradebookEntry_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GradebookEntryTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GradebookEntryTypeDescriptor_TR_DeleteTracking] ON [edfi].[GradebookEntryTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.GradebookEntryTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.GradebookEntryTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradebookEntryTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradebookEntryTypeDescriptor] ENABLE TRIGGER [edfi_GradebookEntryTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GradeLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GradeLevelDescriptor_TR_DeleteTracking] ON [edfi].[GradeLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.GradeLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.GradeLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradeLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradeLevelDescriptor] ENABLE TRIGGER [edfi_GradeLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GradePointAverageTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GradePointAverageTypeDescriptor_TR_DeleteTracking] ON [edfi].[GradePointAverageTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.GradePointAverageTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.GradePointAverageTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradePointAverageTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradePointAverageTypeDescriptor] ENABLE TRIGGER [edfi_GradePointAverageTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GradeTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GradeTypeDescriptor_TR_DeleteTracking] ON [edfi].[GradeTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.GradeTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.GradeTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradeTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradeTypeDescriptor] ENABLE TRIGGER [edfi_GradeTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GradingPeriod_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GradingPeriod_TR_DeleteTracking] ON [edfi].[GradingPeriod] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[GradingPeriod](OldGradingPeriodDescriptorId, OldGradingPeriodDescriptorNamespace, OldGradingPeriodDescriptorCodeValue, OldPeriodSequence, OldSchoolId, OldSchoolYear, Id, Discriminator, ChangeVersion)
    SELECT d.GradingPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.PeriodSequence, d.SchoolId, d.SchoolYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.GradingPeriodDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [edfi].[GradingPeriod] ENABLE TRIGGER [edfi_GradingPeriod_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GradingPeriodDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GradingPeriodDescriptor_TR_DeleteTracking] ON [edfi].[GradingPeriodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.GradingPeriodDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.GradingPeriodDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradingPeriodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradingPeriodDescriptor] ENABLE TRIGGER [edfi_GradingPeriodDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GraduationPlan_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GraduationPlan_TR_DeleteTracking] ON [edfi].[GraduationPlan] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[GraduationPlan](OldEducationOrganizationId, OldGraduationPlanTypeDescriptorId, OldGraduationPlanTypeDescriptorNamespace, OldGraduationPlanTypeDescriptorCodeValue, OldGraduationSchoolYear, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.GraduationPlanTypeDescriptorId, j0.Namespace, j0.CodeValue, d.GraduationSchoolYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.GraduationPlanTypeDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [edfi].[GraduationPlan] ENABLE TRIGGER [edfi_GraduationPlan_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GraduationPlanTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GraduationPlanTypeDescriptor_TR_DeleteTracking] ON [edfi].[GraduationPlanTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.GraduationPlanTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.GraduationPlanTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GraduationPlanTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GraduationPlanTypeDescriptor] ENABLE TRIGGER [edfi_GraduationPlanTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_GunFreeSchoolsActReportingStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_GunFreeSchoolsActReportingStatusDescriptor_TR_DeleteTracking] ON [edfi].[GunFreeSchoolsActReportingStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.GunFreeSchoolsActReportingStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.GunFreeSchoolsActReportingStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GunFreeSchoolsActReportingStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GunFreeSchoolsActReportingStatusDescriptor] ENABLE TRIGGER [edfi_GunFreeSchoolsActReportingStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_HomelessPrimaryNighttimeResidenceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_HomelessPrimaryNighttimeResidenceDescriptor_TR_DeleteTracking] ON [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.HomelessPrimaryNighttimeResidenceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.HomelessPrimaryNighttimeResidenceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.HomelessPrimaryNighttimeResidenceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] ENABLE TRIGGER [edfi_HomelessPrimaryNighttimeResidenceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_HomelessProgramServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_HomelessProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[HomelessProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.HomelessProgramServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.HomelessProgramServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.HomelessProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[HomelessProgramServiceDescriptor] ENABLE TRIGGER [edfi_HomelessProgramServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_IdentificationDocumentUseDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_IdentificationDocumentUseDescriptor_TR_DeleteTracking] ON [edfi].[IdentificationDocumentUseDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.IdentificationDocumentUseDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.IdentificationDocumentUseDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IdentificationDocumentUseDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IdentificationDocumentUseDescriptor] ENABLE TRIGGER [edfi_IdentificationDocumentUseDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_IncidentLocationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_IncidentLocationDescriptor_TR_DeleteTracking] ON [edfi].[IncidentLocationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.IncidentLocationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.IncidentLocationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IncidentLocationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IncidentLocationDescriptor] ENABLE TRIGGER [edfi_IncidentLocationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_IndicatorDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_IndicatorDescriptor_TR_DeleteTracking] ON [edfi].[IndicatorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.IndicatorDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.IndicatorDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IndicatorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IndicatorDescriptor] ENABLE TRIGGER [edfi_IndicatorDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_IndicatorGroupDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_IndicatorGroupDescriptor_TR_DeleteTracking] ON [edfi].[IndicatorGroupDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.IndicatorGroupDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.IndicatorGroupDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IndicatorGroupDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IndicatorGroupDescriptor] ENABLE TRIGGER [edfi_IndicatorGroupDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_IndicatorLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_IndicatorLevelDescriptor_TR_DeleteTracking] ON [edfi].[IndicatorLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.IndicatorLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.IndicatorLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IndicatorLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IndicatorLevelDescriptor] ENABLE TRIGGER [edfi_IndicatorLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InstitutionTelephoneNumberTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InstitutionTelephoneNumberTypeDescriptor_TR_DeleteTracking] ON [edfi].[InstitutionTelephoneNumberTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InstitutionTelephoneNumberTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.InstitutionTelephoneNumberTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InstitutionTelephoneNumberTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InstitutionTelephoneNumberTypeDescriptor] ENABLE TRIGGER [edfi_InstitutionTelephoneNumberTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InteractivityStyleDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InteractivityStyleDescriptor_TR_DeleteTracking] ON [edfi].[InteractivityStyleDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InteractivityStyleDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.InteractivityStyleDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InteractivityStyleDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InteractivityStyleDescriptor] ENABLE TRIGGER [edfi_InteractivityStyleDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InternetAccessDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InternetAccessDescriptor_TR_DeleteTracking] ON [edfi].[InternetAccessDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InternetAccessDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.InternetAccessDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InternetAccessDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InternetAccessDescriptor] ENABLE TRIGGER [edfi_InternetAccessDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InternetAccessTypeInResidenceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InternetAccessTypeInResidenceDescriptor_TR_DeleteTracking] ON [edfi].[InternetAccessTypeInResidenceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InternetAccessTypeInResidenceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.InternetAccessTypeInResidenceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InternetAccessTypeInResidenceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InternetAccessTypeInResidenceDescriptor] ENABLE TRIGGER [edfi_InternetAccessTypeInResidenceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InternetPerformanceInResidenceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InternetPerformanceInResidenceDescriptor_TR_DeleteTracking] ON [edfi].[InternetPerformanceInResidenceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InternetPerformanceInResidenceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.InternetPerformanceInResidenceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InternetPerformanceInResidenceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InternetPerformanceInResidenceDescriptor] ENABLE TRIGGER [edfi_InternetPerformanceInResidenceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Intervention_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Intervention_TR_DeleteTracking] ON [edfi].[Intervention] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Intervention](OldEducationOrganizationId, OldInterventionIdentificationCode, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.InterventionIdentificationCode, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Intervention] ENABLE TRIGGER [edfi_Intervention_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionClassDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InterventionClassDescriptor_TR_DeleteTracking] ON [edfi].[InterventionClassDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InterventionClassDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.InterventionClassDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InterventionClassDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InterventionClassDescriptor] ENABLE TRIGGER [edfi_InterventionClassDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionEffectivenessRatingDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InterventionEffectivenessRatingDescriptor_TR_DeleteTracking] ON [edfi].[InterventionEffectivenessRatingDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.InterventionEffectivenessRatingDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.InterventionEffectivenessRatingDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InterventionEffectivenessRatingDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InterventionEffectivenessRatingDescriptor] ENABLE TRIGGER [edfi_InterventionEffectivenessRatingDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionPrescription_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InterventionPrescription_TR_DeleteTracking] ON [edfi].[InterventionPrescription] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[InterventionPrescription](OldEducationOrganizationId, OldInterventionPrescriptionIdentificationCode, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.InterventionPrescriptionIdentificationCode, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[InterventionPrescription] ENABLE TRIGGER [edfi_InterventionPrescription_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionStudy_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_InterventionStudy_TR_DeleteTracking] ON [edfi].[InterventionStudy] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[InterventionStudy](OldEducationOrganizationId, OldInterventionStudyIdentificationCode, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.InterventionStudyIdentificationCode, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[InterventionStudy] ENABLE TRIGGER [edfi_InterventionStudy_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LanguageDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LanguageDescriptor_TR_DeleteTracking] ON [edfi].[LanguageDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LanguageDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LanguageDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LanguageDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LanguageDescriptor] ENABLE TRIGGER [edfi_LanguageDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LanguageInstructionProgramServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LanguageInstructionProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[LanguageInstructionProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LanguageInstructionProgramServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LanguageInstructionProgramServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LanguageInstructionProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LanguageInstructionProgramServiceDescriptor] ENABLE TRIGGER [edfi_LanguageInstructionProgramServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LanguageUseDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LanguageUseDescriptor_TR_DeleteTracking] ON [edfi].[LanguageUseDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LanguageUseDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LanguageUseDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LanguageUseDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LanguageUseDescriptor] ENABLE TRIGGER [edfi_LanguageUseDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LearningObjective_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LearningObjective_TR_DeleteTracking] ON [edfi].[LearningObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LearningObjective](OldLearningObjectiveId, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT d.LearningObjectiveId, d.Namespace, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LearningObjective] ENABLE TRIGGER [edfi_LearningObjective_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandard_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandard_TR_DeleteTracking] ON [edfi].[LearningStandard] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LearningStandard](OldLearningStandardId, Id, OldNamespace, Discriminator, ChangeVersion)
    SELECT d.LearningStandardId, d.Id, d.Namespace, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LearningStandard] ENABLE TRIGGER [edfi_LearningStandard_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandardCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandardCategoryDescriptor_TR_DeleteTracking] ON [edfi].[LearningStandardCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LearningStandardCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LearningStandardCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LearningStandardCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LearningStandardCategoryDescriptor] ENABLE TRIGGER [edfi_LearningStandardCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandardEquivalenceAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandardEquivalenceAssociation_TR_DeleteTracking] ON [edfi].[LearningStandardEquivalenceAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LearningStandardEquivalenceAssociation](OldNamespace, OldSourceLearningStandardId, OldTargetLearningStandardId, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.SourceLearningStandardId, d.TargetLearningStandardId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ENABLE TRIGGER [edfi_LearningStandardEquivalenceAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandardEquivalenceStrengthDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandardEquivalenceStrengthDescriptor_TR_DeleteTracking] ON [edfi].[LearningStandardEquivalenceStrengthDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LearningStandardEquivalenceStrengthDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LearningStandardEquivalenceStrengthDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LearningStandardEquivalenceStrengthDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceStrengthDescriptor] ENABLE TRIGGER [edfi_LearningStandardEquivalenceStrengthDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandardScopeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandardScopeDescriptor_TR_DeleteTracking] ON [edfi].[LearningStandardScopeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LearningStandardScopeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LearningStandardScopeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LearningStandardScopeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LearningStandardScopeDescriptor] ENABLE TRIGGER [edfi_LearningStandardScopeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LevelOfEducationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LevelOfEducationDescriptor_TR_DeleteTracking] ON [edfi].[LevelOfEducationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LevelOfEducationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LevelOfEducationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LevelOfEducationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LevelOfEducationDescriptor] ENABLE TRIGGER [edfi_LevelOfEducationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LicenseStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LicenseStatusDescriptor_TR_DeleteTracking] ON [edfi].[LicenseStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LicenseStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LicenseStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LicenseStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LicenseStatusDescriptor] ENABLE TRIGGER [edfi_LicenseStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LicenseTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LicenseTypeDescriptor_TR_DeleteTracking] ON [edfi].[LicenseTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LicenseTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LicenseTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LicenseTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LicenseTypeDescriptor] ENABLE TRIGGER [edfi_LicenseTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LimitedEnglishProficiencyDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LimitedEnglishProficiencyDescriptor_TR_DeleteTracking] ON [edfi].[LimitedEnglishProficiencyDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LimitedEnglishProficiencyDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LimitedEnglishProficiencyDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LimitedEnglishProficiencyDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LimitedEnglishProficiencyDescriptor] ENABLE TRIGGER [edfi_LimitedEnglishProficiencyDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LocalAccount_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LocalAccount_TR_DeleteTracking] ON [edfi].[LocalAccount] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LocalAccount](OldAccountIdentifier, OldEducationOrganizationId, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.AccountIdentifier, d.EducationOrganizationId, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LocalAccount] ENABLE TRIGGER [edfi_LocalAccount_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LocalActual_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LocalActual_TR_DeleteTracking] ON [edfi].[LocalActual] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LocalActual](OldAccountIdentifier, OldAsOfDate, OldEducationOrganizationId, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.AccountIdentifier, d.AsOfDate, d.EducationOrganizationId, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LocalActual] ENABLE TRIGGER [edfi_LocalActual_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LocalBudget_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LocalBudget_TR_DeleteTracking] ON [edfi].[LocalBudget] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LocalBudget](OldAccountIdentifier, OldAsOfDate, OldEducationOrganizationId, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.AccountIdentifier, d.AsOfDate, d.EducationOrganizationId, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LocalBudget] ENABLE TRIGGER [edfi_LocalBudget_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LocalContractedStaff_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LocalContractedStaff_TR_DeleteTracking] ON [edfi].[LocalContractedStaff] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LocalContractedStaff](OldAccountIdentifier, OldAsOfDate, OldEducationOrganizationId, OldFiscalYear, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AccountIdentifier, d.AsOfDate, d.EducationOrganizationId, d.FiscalYear, d.StaffUSI, j0.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Staff j0
            ON d.StaffUSI = j0.StaffUSI
END
GO

ALTER TABLE [edfi].[LocalContractedStaff] ENABLE TRIGGER [edfi_LocalContractedStaff_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LocaleDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LocaleDescriptor_TR_DeleteTracking] ON [edfi].[LocaleDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LocaleDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LocaleDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LocaleDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LocaleDescriptor] ENABLE TRIGGER [edfi_LocaleDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LocalEducationAgencyCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LocalEducationAgencyCategoryDescriptor_TR_DeleteTracking] ON [edfi].[LocalEducationAgencyCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.LocalEducationAgencyCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.LocalEducationAgencyCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LocalEducationAgencyCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LocalEducationAgencyCategoryDescriptor] ENABLE TRIGGER [edfi_LocalEducationAgencyCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LocalEncumbrance_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LocalEncumbrance_TR_DeleteTracking] ON [edfi].[LocalEncumbrance] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LocalEncumbrance](OldAccountIdentifier, OldAsOfDate, OldEducationOrganizationId, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.AccountIdentifier, d.AsOfDate, d.EducationOrganizationId, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LocalEncumbrance] ENABLE TRIGGER [edfi_LocalEncumbrance_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_LocalPayroll_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_LocalPayroll_TR_DeleteTracking] ON [edfi].[LocalPayroll] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[LocalPayroll](OldAccountIdentifier, OldAsOfDate, OldEducationOrganizationId, OldFiscalYear, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AccountIdentifier, d.AsOfDate, d.EducationOrganizationId, d.FiscalYear, d.StaffUSI, j0.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Staff j0
            ON d.StaffUSI = j0.StaffUSI
END
GO

ALTER TABLE [edfi].[LocalPayroll] ENABLE TRIGGER [edfi_LocalPayroll_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Location_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Location_TR_DeleteTracking] ON [edfi].[Location] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Location](OldClassroomIdentificationCode, OldSchoolId, Id, Discriminator, ChangeVersion)
    SELECT d.ClassroomIdentificationCode, d.SchoolId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Location] ENABLE TRIGGER [edfi_Location_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_MagnetSpecialProgramEmphasisSchoolDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_MagnetSpecialProgramEmphasisSchoolDescriptor_TR_DeleteTracking] ON [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.MagnetSpecialProgramEmphasisSchoolDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.MagnetSpecialProgramEmphasisSchoolDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MagnetSpecialProgramEmphasisSchoolDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] ENABLE TRIGGER [edfi_MagnetSpecialProgramEmphasisSchoolDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_MediumOfInstructionDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_MediumOfInstructionDescriptor_TR_DeleteTracking] ON [edfi].[MediumOfInstructionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.MediumOfInstructionDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.MediumOfInstructionDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MediumOfInstructionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MediumOfInstructionDescriptor] ENABLE TRIGGER [edfi_MediumOfInstructionDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_MethodCreditEarnedDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_MethodCreditEarnedDescriptor_TR_DeleteTracking] ON [edfi].[MethodCreditEarnedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.MethodCreditEarnedDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.MethodCreditEarnedDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MethodCreditEarnedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MethodCreditEarnedDescriptor] ENABLE TRIGGER [edfi_MethodCreditEarnedDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_MigrantEducationProgramServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_MigrantEducationProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[MigrantEducationProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.MigrantEducationProgramServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.MigrantEducationProgramServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MigrantEducationProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MigrantEducationProgramServiceDescriptor] ENABLE TRIGGER [edfi_MigrantEducationProgramServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ModelEntityDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ModelEntityDescriptor_TR_DeleteTracking] ON [edfi].[ModelEntityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ModelEntityDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ModelEntityDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ModelEntityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ModelEntityDescriptor] ENABLE TRIGGER [edfi_ModelEntityDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_MonitoredDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_MonitoredDescriptor_TR_DeleteTracking] ON [edfi].[MonitoredDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.MonitoredDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.MonitoredDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MonitoredDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MonitoredDescriptor] ENABLE TRIGGER [edfi_MonitoredDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_NeglectedOrDelinquentProgramDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_NeglectedOrDelinquentProgramDescriptor_TR_DeleteTracking] ON [edfi].[NeglectedOrDelinquentProgramDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.NeglectedOrDelinquentProgramDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.NeglectedOrDelinquentProgramDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.NeglectedOrDelinquentProgramDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[NeglectedOrDelinquentProgramDescriptor] ENABLE TRIGGER [edfi_NeglectedOrDelinquentProgramDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_NeglectedOrDelinquentProgramServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_NeglectedOrDelinquentProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.NeglectedOrDelinquentProgramServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.NeglectedOrDelinquentProgramServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.NeglectedOrDelinquentProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] ENABLE TRIGGER [edfi_NeglectedOrDelinquentProgramServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_NetworkPurposeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_NetworkPurposeDescriptor_TR_DeleteTracking] ON [edfi].[NetworkPurposeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.NetworkPurposeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.NetworkPurposeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.NetworkPurposeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[NetworkPurposeDescriptor] ENABLE TRIGGER [edfi_NetworkPurposeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ObjectDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ObjectDimension_TR_DeleteTracking] ON [edfi].[ObjectDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[ObjectDimension](OldCode, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.Code, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ObjectDimension] ENABLE TRIGGER [edfi_ObjectDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ObjectiveAssessment_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ObjectiveAssessment_TR_DeleteTracking] ON [edfi].[ObjectiveAssessment] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[ObjectiveAssessment](OldAssessmentIdentifier, OldIdentificationCode, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT d.AssessmentIdentifier, d.IdentificationCode, d.Namespace, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ObjectiveAssessment] ENABLE TRIGGER [edfi_ObjectiveAssessment_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_OldEthnicityDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_OldEthnicityDescriptor_TR_DeleteTracking] ON [edfi].[OldEthnicityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.OldEthnicityDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.OldEthnicityDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OldEthnicityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[OldEthnicityDescriptor] ENABLE TRIGGER [edfi_OldEthnicityDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_OpenStaffPosition_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_OpenStaffPosition_TR_DeleteTracking] ON [edfi].[OpenStaffPosition] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[OpenStaffPosition](OldEducationOrganizationId, OldRequisitionNumber, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.RequisitionNumber, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[OpenStaffPosition] ENABLE TRIGGER [edfi_OpenStaffPosition_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_OperationalStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_OperationalStatusDescriptor_TR_DeleteTracking] ON [edfi].[OperationalStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.OperationalStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.OperationalStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OperationalStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[OperationalStatusDescriptor] ENABLE TRIGGER [edfi_OperationalStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_OperationalUnitDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_OperationalUnitDimension_TR_DeleteTracking] ON [edfi].[OperationalUnitDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[OperationalUnitDimension](OldCode, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.Code, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[OperationalUnitDimension] ENABLE TRIGGER [edfi_OperationalUnitDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_OtherNameTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_OtherNameTypeDescriptor_TR_DeleteTracking] ON [edfi].[OtherNameTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.OtherNameTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.OtherNameTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OtherNameTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[OtherNameTypeDescriptor] ENABLE TRIGGER [edfi_OtherNameTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Parent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Parent_TR_DeleteTracking] ON [edfi].[Parent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Parent](OldParentUSI, OldParentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.ParentUSI, d.ParentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Parent] ENABLE TRIGGER [edfi_Parent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ParticipationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ParticipationDescriptor_TR_DeleteTracking] ON [edfi].[ParticipationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ParticipationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ParticipationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ParticipationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ParticipationDescriptor] ENABLE TRIGGER [edfi_ParticipationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ParticipationStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ParticipationStatusDescriptor_TR_DeleteTracking] ON [edfi].[ParticipationStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ParticipationStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ParticipationStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ParticipationStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ParticipationStatusDescriptor] ENABLE TRIGGER [edfi_ParticipationStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PerformanceBaseConversionDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PerformanceBaseConversionDescriptor_TR_DeleteTracking] ON [edfi].[PerformanceBaseConversionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PerformanceBaseConversionDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PerformanceBaseConversionDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PerformanceBaseConversionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PerformanceBaseConversionDescriptor] ENABLE TRIGGER [edfi_PerformanceBaseConversionDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PerformanceLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PerformanceLevelDescriptor_TR_DeleteTracking] ON [edfi].[PerformanceLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PerformanceLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PerformanceLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PerformanceLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PerformanceLevelDescriptor] ENABLE TRIGGER [edfi_PerformanceLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Person_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Person_TR_DeleteTracking] ON [edfi].[Person] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Person](OldPersonId, OldSourceSystemDescriptorId, OldSourceSystemDescriptorNamespace, OldSourceSystemDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.PersonId, d.SourceSystemDescriptorId, j0.Namespace, j0.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.SourceSystemDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [edfi].[Person] ENABLE TRIGGER [edfi_Person_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PersonalInformationVerificationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PersonalInformationVerificationDescriptor_TR_DeleteTracking] ON [edfi].[PersonalInformationVerificationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PersonalInformationVerificationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PersonalInformationVerificationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PersonalInformationVerificationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PersonalInformationVerificationDescriptor] ENABLE TRIGGER [edfi_PersonalInformationVerificationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PlatformTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PlatformTypeDescriptor_TR_DeleteTracking] ON [edfi].[PlatformTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PlatformTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PlatformTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PlatformTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PlatformTypeDescriptor] ENABLE TRIGGER [edfi_PlatformTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PopulationServedDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PopulationServedDescriptor_TR_DeleteTracking] ON [edfi].[PopulationServedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PopulationServedDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PopulationServedDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PopulationServedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PopulationServedDescriptor] ENABLE TRIGGER [edfi_PopulationServedDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PostingResultDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PostingResultDescriptor_TR_DeleteTracking] ON [edfi].[PostingResultDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PostingResultDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PostingResultDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PostingResultDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PostingResultDescriptor] ENABLE TRIGGER [edfi_PostingResultDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PostSecondaryEvent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PostSecondaryEvent_TR_DeleteTracking] ON [edfi].[PostSecondaryEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[PostSecondaryEvent](OldEventDate, OldPostSecondaryEventCategoryDescriptorId, OldPostSecondaryEventCategoryDescriptorNamespace, OldPostSecondaryEventCategoryDescriptorCodeValue, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.EventDate, d.PostSecondaryEventCategoryDescriptorId, j0.Namespace, j0.CodeValue, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.PostSecondaryEventCategoryDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[PostSecondaryEvent] ENABLE TRIGGER [edfi_PostSecondaryEvent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PostSecondaryEventCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PostSecondaryEventCategoryDescriptor_TR_DeleteTracking] ON [edfi].[PostSecondaryEventCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PostSecondaryEventCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PostSecondaryEventCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PostSecondaryEventCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PostSecondaryEventCategoryDescriptor] ENABLE TRIGGER [edfi_PostSecondaryEventCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PostSecondaryInstitutionLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PostSecondaryInstitutionLevelDescriptor_TR_DeleteTracking] ON [edfi].[PostSecondaryInstitutionLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PostSecondaryInstitutionLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PostSecondaryInstitutionLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PostSecondaryInstitutionLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PostSecondaryInstitutionLevelDescriptor] ENABLE TRIGGER [edfi_PostSecondaryInstitutionLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PrimaryLearningDeviceAccessDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PrimaryLearningDeviceAccessDescriptor_TR_DeleteTracking] ON [edfi].[PrimaryLearningDeviceAccessDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PrimaryLearningDeviceAccessDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PrimaryLearningDeviceAccessDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PrimaryLearningDeviceAccessDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceAccessDescriptor] ENABLE TRIGGER [edfi_PrimaryLearningDeviceAccessDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PrimaryLearningDeviceAwayFromSchoolDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PrimaryLearningDeviceAwayFromSchoolDescriptor_TR_DeleteTracking] ON [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PrimaryLearningDeviceAwayFromSchoolDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PrimaryLearningDeviceAwayFromSchoolDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] ENABLE TRIGGER [edfi_PrimaryLearningDeviceAwayFromSchoolDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PrimaryLearningDeviceProviderDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PrimaryLearningDeviceProviderDescriptor_TR_DeleteTracking] ON [edfi].[PrimaryLearningDeviceProviderDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PrimaryLearningDeviceProviderDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PrimaryLearningDeviceProviderDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PrimaryLearningDeviceProviderDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceProviderDescriptor] ENABLE TRIGGER [edfi_PrimaryLearningDeviceProviderDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProficiencyDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProficiencyDescriptor_TR_DeleteTracking] ON [edfi].[ProficiencyDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProficiencyDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProficiencyDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProficiencyDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProficiencyDescriptor] ENABLE TRIGGER [edfi_ProficiencyDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Program_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Program_TR_DeleteTracking] ON [edfi].[Program] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Program](OldEducationOrganizationId, OldProgramName, OldProgramTypeDescriptorId, OldProgramTypeDescriptorNamespace, OldProgramTypeDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, j0.Namespace, j0.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ProgramTypeDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [edfi].[Program] ENABLE TRIGGER [edfi_Program_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramAssignmentDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProgramAssignmentDescriptor_TR_DeleteTracking] ON [edfi].[ProgramAssignmentDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProgramAssignmentDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProgramAssignmentDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramAssignmentDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgramAssignmentDescriptor] ENABLE TRIGGER [edfi_ProgramAssignmentDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramCharacteristicDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProgramCharacteristicDescriptor_TR_DeleteTracking] ON [edfi].[ProgramCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProgramCharacteristicDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProgramCharacteristicDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgramCharacteristicDescriptor] ENABLE TRIGGER [edfi_ProgramCharacteristicDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProgramDimension_TR_DeleteTracking] ON [edfi].[ProgramDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[ProgramDimension](OldCode, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.Code, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ProgramDimension] ENABLE TRIGGER [edfi_ProgramDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramSponsorDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProgramSponsorDescriptor_TR_DeleteTracking] ON [edfi].[ProgramSponsorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProgramSponsorDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProgramSponsorDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramSponsorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgramSponsorDescriptor] ENABLE TRIGGER [edfi_ProgramSponsorDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProgramTypeDescriptor_TR_DeleteTracking] ON [edfi].[ProgramTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProgramTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProgramTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgramTypeDescriptor] ENABLE TRIGGER [edfi_ProgramTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProgressDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProgressDescriptor_TR_DeleteTracking] ON [edfi].[ProgressDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProgressDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProgressDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgressDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgressDescriptor] ENABLE TRIGGER [edfi_ProgressDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProgressLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProgressLevelDescriptor_TR_DeleteTracking] ON [edfi].[ProgressLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProgressLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProgressLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgressLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgressLevelDescriptor] ENABLE TRIGGER [edfi_ProgressLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProjectDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProjectDimension_TR_DeleteTracking] ON [edfi].[ProjectDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[ProjectDimension](OldCode, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.Code, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ProjectDimension] ENABLE TRIGGER [edfi_ProjectDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProviderCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProviderCategoryDescriptor_TR_DeleteTracking] ON [edfi].[ProviderCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProviderCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProviderCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProviderCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProviderCategoryDescriptor] ENABLE TRIGGER [edfi_ProviderCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProviderProfitabilityDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProviderProfitabilityDescriptor_TR_DeleteTracking] ON [edfi].[ProviderProfitabilityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProviderProfitabilityDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProviderProfitabilityDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProviderProfitabilityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProviderProfitabilityDescriptor] ENABLE TRIGGER [edfi_ProviderProfitabilityDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ProviderStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ProviderStatusDescriptor_TR_DeleteTracking] ON [edfi].[ProviderStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ProviderStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ProviderStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProviderStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProviderStatusDescriptor] ENABLE TRIGGER [edfi_ProviderStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_PublicationStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_PublicationStatusDescriptor_TR_DeleteTracking] ON [edfi].[PublicationStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.PublicationStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.PublicationStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PublicationStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PublicationStatusDescriptor] ENABLE TRIGGER [edfi_PublicationStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_QuestionFormDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_QuestionFormDescriptor_TR_DeleteTracking] ON [edfi].[QuestionFormDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.QuestionFormDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.QuestionFormDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.QuestionFormDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[QuestionFormDescriptor] ENABLE TRIGGER [edfi_QuestionFormDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_RaceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_RaceDescriptor_TR_DeleteTracking] ON [edfi].[RaceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.RaceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.RaceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RaceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RaceDescriptor] ENABLE TRIGGER [edfi_RaceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ReasonExitedDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ReasonExitedDescriptor_TR_DeleteTracking] ON [edfi].[ReasonExitedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ReasonExitedDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ReasonExitedDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ReasonExitedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ReasonExitedDescriptor] ENABLE TRIGGER [edfi_ReasonExitedDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ReasonNotTestedDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ReasonNotTestedDescriptor_TR_DeleteTracking] ON [edfi].[ReasonNotTestedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ReasonNotTestedDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ReasonNotTestedDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ReasonNotTestedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ReasonNotTestedDescriptor] ENABLE TRIGGER [edfi_ReasonNotTestedDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_RecognitionTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_RecognitionTypeDescriptor_TR_DeleteTracking] ON [edfi].[RecognitionTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.RecognitionTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.RecognitionTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RecognitionTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RecognitionTypeDescriptor] ENABLE TRIGGER [edfi_RecognitionTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_RelationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_RelationDescriptor_TR_DeleteTracking] ON [edfi].[RelationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.RelationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.RelationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RelationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RelationDescriptor] ENABLE TRIGGER [edfi_RelationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_RepeatIdentifierDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_RepeatIdentifierDescriptor_TR_DeleteTracking] ON [edfi].[RepeatIdentifierDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.RepeatIdentifierDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.RepeatIdentifierDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RepeatIdentifierDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RepeatIdentifierDescriptor] ENABLE TRIGGER [edfi_RepeatIdentifierDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ReportCard_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ReportCard_TR_DeleteTracking] ON [edfi].[ReportCard] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[ReportCard](OldEducationOrganizationId, OldGradingPeriodDescriptorId, OldGradingPeriodDescriptorNamespace, OldGradingPeriodDescriptorCodeValue, OldGradingPeriodSchoolId, OldGradingPeriodSchoolYear, OldGradingPeriodSequence, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.GradingPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.GradingPeriodSchoolId, d.GradingPeriodSchoolYear, d.GradingPeriodSequence, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.GradingPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[ReportCard] ENABLE TRIGGER [edfi_ReportCard_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ReporterDescriptionDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ReporterDescriptionDescriptor_TR_DeleteTracking] ON [edfi].[ReporterDescriptionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ReporterDescriptionDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ReporterDescriptionDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ReporterDescriptionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ReporterDescriptionDescriptor] ENABLE TRIGGER [edfi_ReporterDescriptionDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ReportingTagDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ReportingTagDescriptor_TR_DeleteTracking] ON [edfi].[ReportingTagDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ReportingTagDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ReportingTagDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ReportingTagDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ReportingTagDescriptor] ENABLE TRIGGER [edfi_ReportingTagDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ResidencyStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ResidencyStatusDescriptor_TR_DeleteTracking] ON [edfi].[ResidencyStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ResidencyStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ResidencyStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ResidencyStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ResidencyStatusDescriptor] ENABLE TRIGGER [edfi_ResidencyStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ResponseIndicatorDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ResponseIndicatorDescriptor_TR_DeleteTracking] ON [edfi].[ResponseIndicatorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ResponseIndicatorDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ResponseIndicatorDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ResponseIndicatorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ResponseIndicatorDescriptor] ENABLE TRIGGER [edfi_ResponseIndicatorDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ResponsibilityDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ResponsibilityDescriptor_TR_DeleteTracking] ON [edfi].[ResponsibilityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ResponsibilityDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ResponsibilityDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ResponsibilityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ResponsibilityDescriptor] ENABLE TRIGGER [edfi_ResponsibilityDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_RestraintEvent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_RestraintEvent_TR_DeleteTracking] ON [edfi].[RestraintEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[RestraintEvent](OldRestraintEventIdentifier, OldSchoolId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.RestraintEventIdentifier, d.SchoolId, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[RestraintEvent] ENABLE TRIGGER [edfi_RestraintEvent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_RestraintEventReasonDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_RestraintEventReasonDescriptor_TR_DeleteTracking] ON [edfi].[RestraintEventReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.RestraintEventReasonDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.RestraintEventReasonDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RestraintEventReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RestraintEventReasonDescriptor] ENABLE TRIGGER [edfi_RestraintEventReasonDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ResultDatatypeTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ResultDatatypeTypeDescriptor_TR_DeleteTracking] ON [edfi].[ResultDatatypeTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ResultDatatypeTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ResultDatatypeTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ResultDatatypeTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ResultDatatypeTypeDescriptor] ENABLE TRIGGER [edfi_ResultDatatypeTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_RetestIndicatorDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_RetestIndicatorDescriptor_TR_DeleteTracking] ON [edfi].[RetestIndicatorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.RetestIndicatorDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.RetestIndicatorDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RetestIndicatorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RetestIndicatorDescriptor] ENABLE TRIGGER [edfi_RetestIndicatorDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SchoolCategoryDescriptor_TR_DeleteTracking] ON [edfi].[SchoolCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SchoolCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SchoolCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolCategoryDescriptor] ENABLE TRIGGER [edfi_SchoolCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolChoiceBasisDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SchoolChoiceBasisDescriptor_TR_DeleteTracking] ON [edfi].[SchoolChoiceBasisDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SchoolChoiceBasisDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SchoolChoiceBasisDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolChoiceBasisDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolChoiceBasisDescriptor] ENABLE TRIGGER [edfi_SchoolChoiceBasisDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolChoiceImplementStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SchoolChoiceImplementStatusDescriptor_TR_DeleteTracking] ON [edfi].[SchoolChoiceImplementStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SchoolChoiceImplementStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SchoolChoiceImplementStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolChoiceImplementStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolChoiceImplementStatusDescriptor] ENABLE TRIGGER [edfi_SchoolChoiceImplementStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolFoodServiceProgramServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SchoolFoodServiceProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[SchoolFoodServiceProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SchoolFoodServiceProgramServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SchoolFoodServiceProgramServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolFoodServiceProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolFoodServiceProgramServiceDescriptor] ENABLE TRIGGER [edfi_SchoolFoodServiceProgramServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SchoolTypeDescriptor_TR_DeleteTracking] ON [edfi].[SchoolTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SchoolTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SchoolTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolTypeDescriptor] ENABLE TRIGGER [edfi_SchoolTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolYearType_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SchoolYearType_TR_DeleteTracking] ON [edfi].[SchoolYearType] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SchoolYearType](OldSchoolYear, Id, ChangeVersion)
    SELECT d.SchoolYear, d.Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SchoolYearType] ENABLE TRIGGER [edfi_SchoolYearType_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Section_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Section_TR_DeleteTracking] ON [edfi].[Section] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Section](OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, Id, Discriminator, ChangeVersion)
    SELECT d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Section] ENABLE TRIGGER [edfi_Section_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SectionAttendanceTakenEvent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SectionAttendanceTakenEvent_TR_DeleteTracking] ON [edfi].[SectionAttendanceTakenEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SectionAttendanceTakenEvent](OldCalendarCode, OldDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, Id, Discriminator, ChangeVersion)
    SELECT d.CalendarCode, d.Date, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ENABLE TRIGGER [edfi_SectionAttendanceTakenEvent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SectionCharacteristicDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SectionCharacteristicDescriptor_TR_DeleteTracking] ON [edfi].[SectionCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SectionCharacteristicDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SectionCharacteristicDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SectionCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SectionCharacteristicDescriptor] ENABLE TRIGGER [edfi_SectionCharacteristicDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SeparationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SeparationDescriptor_TR_DeleteTracking] ON [edfi].[SeparationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SeparationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SeparationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SeparationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SeparationDescriptor] ENABLE TRIGGER [edfi_SeparationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SeparationReasonDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SeparationReasonDescriptor_TR_DeleteTracking] ON [edfi].[SeparationReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SeparationReasonDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SeparationReasonDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SeparationReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SeparationReasonDescriptor] ENABLE TRIGGER [edfi_SeparationReasonDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_ServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_ServiceDescriptor_TR_DeleteTracking] ON [edfi].[ServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.ServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.ServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ServiceDescriptor] ENABLE TRIGGER [edfi_ServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Session_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Session_TR_DeleteTracking] ON [edfi].[Session] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Session](OldSchoolId, OldSchoolYear, OldSessionName, Id, Discriminator, ChangeVersion)
    SELECT d.SchoolId, d.SchoolYear, d.SessionName, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Session] ENABLE TRIGGER [edfi_Session_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SexDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SexDescriptor_TR_DeleteTracking] ON [edfi].[SexDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SexDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SexDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SexDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SexDescriptor] ENABLE TRIGGER [edfi_SexDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SourceDimension_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SourceDimension_TR_DeleteTracking] ON [edfi].[SourceDimension] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SourceDimension](OldCode, OldFiscalYear, Id, Discriminator, ChangeVersion)
    SELECT d.Code, d.FiscalYear, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SourceDimension] ENABLE TRIGGER [edfi_SourceDimension_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SourceSystemDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SourceSystemDescriptor_TR_DeleteTracking] ON [edfi].[SourceSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SourceSystemDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SourceSystemDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SourceSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SourceSystemDescriptor] ENABLE TRIGGER [edfi_SourceSystemDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SpecialEducationProgramServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SpecialEducationProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[SpecialEducationProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SpecialEducationProgramServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SpecialEducationProgramServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SpecialEducationProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SpecialEducationProgramServiceDescriptor] ENABLE TRIGGER [edfi_SpecialEducationProgramServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SpecialEducationSettingDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SpecialEducationSettingDescriptor_TR_DeleteTracking] ON [edfi].[SpecialEducationSettingDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SpecialEducationSettingDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SpecialEducationSettingDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SpecialEducationSettingDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SpecialEducationSettingDescriptor] ENABLE TRIGGER [edfi_SpecialEducationSettingDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Staff_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Staff_TR_DeleteTracking] ON [edfi].[Staff] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Staff](OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.StaffUSI, d.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Staff] ENABLE TRIGGER [edfi_Staff_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffAbsenceEvent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffAbsenceEvent_TR_DeleteTracking] ON [edfi].[StaffAbsenceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffAbsenceEvent](OldAbsenceEventCategoryDescriptorId, OldAbsenceEventCategoryDescriptorNamespace, OldAbsenceEventCategoryDescriptorCodeValue, OldEventDate, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AbsenceEventCategoryDescriptorId, j0.Namespace, j0.CodeValue, d.EventDate, d.StaffUSI, j1.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.AbsenceEventCategoryDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Staff j1
            ON d.StaffUSI = j1.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffAbsenceEvent] ENABLE TRIGGER [edfi_StaffAbsenceEvent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffClassificationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffClassificationDescriptor_TR_DeleteTracking] ON [edfi].[StaffClassificationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.StaffClassificationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.StaffClassificationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StaffClassificationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StaffClassificationDescriptor] ENABLE TRIGGER [edfi_StaffClassificationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffCohortAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffCohortAssociation_TR_DeleteTracking] ON [edfi].[StaffCohortAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffCohortAssociation](OldBeginDate, OldCohortIdentifier, OldEducationOrganizationId, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.CohortIdentifier, d.EducationOrganizationId, d.StaffUSI, j0.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Staff j0
            ON d.StaffUSI = j0.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffCohortAssociation] ENABLE TRIGGER [edfi_StaffCohortAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffDisciplineIncidentAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffDisciplineIncidentAssociation_TR_DeleteTracking] ON [edfi].[StaffDisciplineIncidentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffDisciplineIncidentAssociation](OldIncidentIdentifier, OldSchoolId, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.IncidentIdentifier, d.SchoolId, d.StaffUSI, j0.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Staff j0
            ON d.StaffUSI = j0.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ENABLE TRIGGER [edfi_StaffDisciplineIncidentAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationAssignmentAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationAssignmentAssociation_TR_DeleteTracking] ON [edfi].[StaffEducationOrganizationAssignmentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffEducationOrganizationAssignmentAssociation](OldBeginDate, OldEducationOrganizationId, OldStaffClassificationDescriptorId, OldStaffClassificationDescriptorNamespace, OldStaffClassificationDescriptorCodeValue, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.EducationOrganizationId, d.StaffClassificationDescriptorId, j0.Namespace, j0.CodeValue, d.StaffUSI, j1.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.StaffClassificationDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Staff j1
            ON d.StaffUSI = j1.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ENABLE TRIGGER [edfi_StaffEducationOrganizationAssignmentAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationContactAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationContactAssociation_TR_DeleteTracking] ON [edfi].[StaffEducationOrganizationContactAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffEducationOrganizationContactAssociation](OldContactTitle, OldEducationOrganizationId, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.ContactTitle, d.EducationOrganizationId, d.StaffUSI, j0.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Staff j0
            ON d.StaffUSI = j0.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] ENABLE TRIGGER [edfi_StaffEducationOrganizationContactAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationEmploymentAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationEmploymentAssociation_TR_DeleteTracking] ON [edfi].[StaffEducationOrganizationEmploymentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffEducationOrganizationEmploymentAssociation](OldEducationOrganizationId, OldEmploymentStatusDescriptorId, OldEmploymentStatusDescriptorNamespace, OldEmploymentStatusDescriptorCodeValue, OldHireDate, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.EmploymentStatusDescriptorId, j0.Namespace, j0.CodeValue, d.HireDate, d.StaffUSI, j1.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EmploymentStatusDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Staff j1
            ON d.StaffUSI = j1.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ENABLE TRIGGER [edfi_StaffEducationOrganizationEmploymentAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffIdentificationSystemDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[StaffIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.StaffIdentificationSystemDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.StaffIdentificationSystemDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StaffIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StaffIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_StaffIdentificationSystemDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffLeave_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffLeave_TR_DeleteTracking] ON [edfi].[StaffLeave] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffLeave](OldBeginDate, OldStaffLeaveEventCategoryDescriptorId, OldStaffLeaveEventCategoryDescriptorNamespace, OldStaffLeaveEventCategoryDescriptorCodeValue, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.StaffLeaveEventCategoryDescriptorId, j0.Namespace, j0.CodeValue, d.StaffUSI, j1.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.StaffLeaveEventCategoryDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Staff j1
            ON d.StaffUSI = j1.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffLeave] ENABLE TRIGGER [edfi_StaffLeave_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffLeaveEventCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffLeaveEventCategoryDescriptor_TR_DeleteTracking] ON [edfi].[StaffLeaveEventCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.StaffLeaveEventCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.StaffLeaveEventCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StaffLeaveEventCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StaffLeaveEventCategoryDescriptor] ENABLE TRIGGER [edfi_StaffLeaveEventCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffProgramAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffProgramAssociation_TR_DeleteTracking] ON [edfi].[StaffProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffProgramAssociation](OldBeginDate, OldProgramEducationOrganizationId, OldProgramName, OldProgramTypeDescriptorId, OldProgramTypeDescriptorNamespace, OldProgramTypeDescriptorCodeValue, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, j0.Namespace, j0.CodeValue, d.StaffUSI, j1.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ProgramTypeDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Staff j1
            ON d.StaffUSI = j1.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffProgramAssociation] ENABLE TRIGGER [edfi_StaffProgramAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffSchoolAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffSchoolAssociation_TR_DeleteTracking] ON [edfi].[StaffSchoolAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffSchoolAssociation](OldProgramAssignmentDescriptorId, OldProgramAssignmentDescriptorNamespace, OldProgramAssignmentDescriptorCodeValue, OldSchoolId, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.ProgramAssignmentDescriptorId, j0.Namespace, j0.CodeValue, d.SchoolId, d.StaffUSI, j1.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ProgramAssignmentDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Staff j1
            ON d.StaffUSI = j1.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] ENABLE TRIGGER [edfi_StaffSchoolAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StaffSectionAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StaffSectionAssociation_TR_DeleteTracking] ON [edfi].[StaffSectionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StaffSectionAssociation](OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStaffUSI, OldStaffUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StaffUSI, j0.StaffUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Staff j0
            ON d.StaffUSI = j0.StaffUSI
END
GO

ALTER TABLE [edfi].[StaffSectionAssociation] ENABLE TRIGGER [edfi_StaffSectionAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StateAbbreviationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StateAbbreviationDescriptor_TR_DeleteTracking] ON [edfi].[StateAbbreviationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.StateAbbreviationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.StateAbbreviationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StateAbbreviationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StateAbbreviationDescriptor] ENABLE TRIGGER [edfi_StateAbbreviationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Student_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Student_TR_DeleteTracking] ON [edfi].[Student] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Student](OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.StudentUSI, d.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Student] ENABLE TRIGGER [edfi_Student_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAcademicRecord_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentAcademicRecord_TR_DeleteTracking] ON [edfi].[StudentAcademicRecord] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentAcademicRecord](OldEducationOrganizationId, OldSchoolYear, OldStudentUSI, OldStudentUniqueId, OldTermDescriptorId, OldTermDescriptorNamespace, OldTermDescriptorCodeValue, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.SchoolYear, d.StudentUSI, j0.StudentUniqueId, d.TermDescriptorId, j1.Namespace, j1.CodeValue, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
        INNER JOIN edfi.Descriptor j1
            ON d.TermDescriptorId = j1.DescriptorId
END
GO

ALTER TABLE [edfi].[StudentAcademicRecord] ENABLE TRIGGER [edfi_StudentAcademicRecord_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessment_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentAssessment_TR_DeleteTracking] ON [edfi].[StudentAssessment] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentAssessment](OldAssessmentIdentifier, OldNamespace, OldStudentAssessmentIdentifier, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AssessmentIdentifier, d.Namespace, d.StudentAssessmentIdentifier, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentAssessment] ENABLE TRIGGER [edfi_StudentAssessment_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessmentEducationOrganizationAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentAssessmentEducationOrganizationAssociation_TR_DeleteTracking] ON [edfi].[StudentAssessmentEducationOrganizationAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentAssessmentEducationOrganizationAssociation](OldAssessmentIdentifier, OldEducationOrganizationAssociationTypeDescriptorId, OldEducationOrganizationAssociationTypeDescriptorNamespace, OldEducationOrganizationAssociationTypeDescriptorCodeValue, OldEducationOrganizationId, OldNamespace, OldStudentAssessmentIdentifier, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AssessmentIdentifier, d.EducationOrganizationAssociationTypeDescriptorId, j0.Namespace, j0.CodeValue, d.EducationOrganizationId, d.Namespace, d.StudentAssessmentIdentifier, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.EducationOrganizationAssociationTypeDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentAssessmentEducationOrganizationAssociation] ENABLE TRIGGER [edfi_StudentAssessmentEducationOrganizationAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCharacteristicDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentCharacteristicDescriptor_TR_DeleteTracking] ON [edfi].[StudentCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.StudentCharacteristicDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.StudentCharacteristicDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StudentCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StudentCharacteristicDescriptor] ENABLE TRIGGER [edfi_StudentCharacteristicDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCohortAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentCohortAssociation_TR_DeleteTracking] ON [edfi].[StudentCohortAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentCohortAssociation](OldBeginDate, OldCohortIdentifier, OldEducationOrganizationId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.CohortIdentifier, d.EducationOrganizationId, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentCohortAssociation] ENABLE TRIGGER [edfi_StudentCohortAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCompetencyObjective_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentCompetencyObjective_TR_DeleteTracking] ON [edfi].[StudentCompetencyObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentCompetencyObjective](OldGradingPeriodDescriptorId, OldGradingPeriodDescriptorNamespace, OldGradingPeriodDescriptorCodeValue, OldGradingPeriodSchoolId, OldGradingPeriodSchoolYear, OldGradingPeriodSequence, OldObjective, OldObjectiveEducationOrganizationId, OldObjectiveGradeLevelDescriptorId, OldObjectiveGradeLevelDescriptorNamespace, OldObjectiveGradeLevelDescriptorCodeValue, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.GradingPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.GradingPeriodSchoolId, d.GradingPeriodSchoolYear, d.GradingPeriodSequence, d.Objective, d.ObjectiveEducationOrganizationId, d.ObjectiveGradeLevelDescriptorId, j1.Namespace, j1.CodeValue, d.StudentUSI, j2.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.GradingPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.ObjectiveGradeLevelDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Student j2
            ON d.StudentUSI = j2.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] ENABLE TRIGGER [edfi_StudentCompetencyObjective_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentAssociation_TR_DeleteTracking] ON [edfi].[StudentDisciplineIncidentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentDisciplineIncidentAssociation](OldIncidentIdentifier, OldSchoolId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.IncidentIdentifier, d.SchoolId, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ENABLE TRIGGER [edfi_StudentDisciplineIncidentAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentBehaviorAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentBehaviorAssociation_TR_DeleteTracking] ON [edfi].[StudentDisciplineIncidentBehaviorAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentDisciplineIncidentBehaviorAssociation](OldBehaviorDescriptorId, OldBehaviorDescriptorNamespace, OldBehaviorDescriptorCodeValue, OldIncidentIdentifier, OldSchoolId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BehaviorDescriptorId, j0.Namespace, j0.CodeValue, d.IncidentIdentifier, d.SchoolId, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.BehaviorDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ENABLE TRIGGER [edfi_StudentDisciplineIncidentBehaviorAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_DeleteTracking] ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentDisciplineIncidentNonOffenderAssociation](OldIncidentIdentifier, OldSchoolId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.IncidentIdentifier, d.SchoolId, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ENABLE TRIGGER [edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentEducationOrganizationAssociation_TR_DeleteTracking] ON [edfi].[StudentEducationOrganizationAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentEducationOrganizationAssociation](OldEducationOrganizationId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ENABLE TRIGGER [edfi_StudentEducationOrganizationAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationResponsibilityAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentEducationOrganizationResponsibilityAssociation_TR_DeleteTracking] ON [edfi].[StudentEducationOrganizationResponsibilityAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentEducationOrganizationResponsibilityAssociation](OldBeginDate, OldEducationOrganizationId, OldResponsibilityDescriptorId, OldResponsibilityDescriptorNamespace, OldResponsibilityDescriptorCodeValue, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.EducationOrganizationId, d.ResponsibilityDescriptorId, j0.Namespace, j0.CodeValue, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ResponsibilityDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ENABLE TRIGGER [edfi_StudentEducationOrganizationResponsibilityAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentGradebookEntry_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentGradebookEntry_TR_DeleteTracking] ON [edfi].[StudentGradebookEntry] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentGradebookEntry](OldGradebookEntryIdentifier, OldNamespace, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.GradebookEntryIdentifier, d.Namespace, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentGradebookEntry] ENABLE TRIGGER [edfi_StudentGradebookEntry_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentIdentificationSystemDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[StudentIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.StudentIdentificationSystemDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.StudentIdentificationSystemDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StudentIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StudentIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_StudentIdentificationSystemDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentInterventionAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentInterventionAssociation_TR_DeleteTracking] ON [edfi].[StudentInterventionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentInterventionAssociation](OldEducationOrganizationId, OldInterventionIdentificationCode, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.InterventionIdentificationCode, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentInterventionAssociation] ENABLE TRIGGER [edfi_StudentInterventionAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentInterventionAttendanceEvent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentInterventionAttendanceEvent_TR_DeleteTracking] ON [edfi].[StudentInterventionAttendanceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentInterventionAttendanceEvent](OldAttendanceEventCategoryDescriptorId, OldAttendanceEventCategoryDescriptorNamespace, OldAttendanceEventCategoryDescriptorCodeValue, OldEducationOrganizationId, OldEventDate, OldInterventionIdentificationCode, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AttendanceEventCategoryDescriptorId, j0.Namespace, j0.CodeValue, d.EducationOrganizationId, d.EventDate, d.InterventionIdentificationCode, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.AttendanceEventCategoryDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ENABLE TRIGGER [edfi_StudentInterventionAttendanceEvent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentLearningObjective_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentLearningObjective_TR_DeleteTracking] ON [edfi].[StudentLearningObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentLearningObjective](OldGradingPeriodDescriptorId, OldGradingPeriodDescriptorNamespace, OldGradingPeriodDescriptorCodeValue, OldGradingPeriodSchoolId, OldGradingPeriodSchoolYear, OldGradingPeriodSequence, OldLearningObjectiveId, OldNamespace, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.GradingPeriodDescriptorId, j0.Namespace, j0.CodeValue, d.GradingPeriodSchoolId, d.GradingPeriodSchoolYear, d.GradingPeriodSequence, d.LearningObjectiveId, d.Namespace, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.GradingPeriodDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentLearningObjective] ENABLE TRIGGER [edfi_StudentLearningObjective_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentParentAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentParentAssociation_TR_DeleteTracking] ON [edfi].[StudentParentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentParentAssociation](OldParentUSI, OldParentUniqueId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.ParentUSI, j0.ParentUniqueId, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Parent j0
            ON d.ParentUSI = j0.ParentUSI
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentParentAssociation] ENABLE TRIGGER [edfi_StudentParentAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentParticipationCodeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentParticipationCodeDescriptor_TR_DeleteTracking] ON [edfi].[StudentParticipationCodeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.StudentParticipationCodeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.StudentParticipationCodeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StudentParticipationCodeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StudentParticipationCodeDescriptor] ENABLE TRIGGER [edfi_StudentParticipationCodeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentProgramAttendanceEvent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentProgramAttendanceEvent_TR_DeleteTracking] ON [edfi].[StudentProgramAttendanceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentProgramAttendanceEvent](OldAttendanceEventCategoryDescriptorId, OldAttendanceEventCategoryDescriptorNamespace, OldAttendanceEventCategoryDescriptorCodeValue, OldEducationOrganizationId, OldEventDate, OldProgramEducationOrganizationId, OldProgramName, OldProgramTypeDescriptorId, OldProgramTypeDescriptorNamespace, OldProgramTypeDescriptorCodeValue, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AttendanceEventCategoryDescriptorId, j0.Namespace, j0.CodeValue, d.EducationOrganizationId, d.EventDate, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, j1.Namespace, j1.CodeValue, d.StudentUSI, j2.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.AttendanceEventCategoryDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Descriptor j1
            ON d.ProgramTypeDescriptorId = j1.DescriptorId
        INNER JOIN edfi.Student j2
            ON d.StudentUSI = j2.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ENABLE TRIGGER [edfi_StudentProgramAttendanceEvent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSchoolAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentSchoolAssociation_TR_DeleteTracking] ON [edfi].[StudentSchoolAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentSchoolAssociation](OldEntryDate, OldSchoolId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.EntryDate, d.SchoolId, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] ENABLE TRIGGER [edfi_StudentSchoolAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSchoolAttendanceEvent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentSchoolAttendanceEvent_TR_DeleteTracking] ON [edfi].[StudentSchoolAttendanceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentSchoolAttendanceEvent](OldAttendanceEventCategoryDescriptorId, OldAttendanceEventCategoryDescriptorNamespace, OldAttendanceEventCategoryDescriptorCodeValue, OldEventDate, OldSchoolId, OldSchoolYear, OldSessionName, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AttendanceEventCategoryDescriptorId, j0.Namespace, j0.CodeValue, d.EventDate, d.SchoolId, d.SchoolYear, d.SessionName, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.AttendanceEventCategoryDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ENABLE TRIGGER [edfi_StudentSchoolAttendanceEvent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSectionAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentSectionAssociation_TR_DeleteTracking] ON [edfi].[StudentSectionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentSectionAssociation](OldBeginDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.BeginDate, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentSectionAssociation] ENABLE TRIGGER [edfi_StudentSectionAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSectionAttendanceEvent_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_StudentSectionAttendanceEvent_TR_DeleteTracking] ON [edfi].[StudentSectionAttendanceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[StudentSectionAttendanceEvent](OldAttendanceEventCategoryDescriptorId, OldAttendanceEventCategoryDescriptorNamespace, OldAttendanceEventCategoryDescriptorCodeValue, OldEventDate, OldLocalCourseCode, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AttendanceEventCategoryDescriptorId, j0.Namespace, j0.CodeValue, d.EventDate, d.LocalCourseCode, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.StudentUSI, j1.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.AttendanceEventCategoryDescriptorId = j0.DescriptorId
        INNER JOIN edfi.Student j1
            ON d.StudentUSI = j1.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ENABLE TRIGGER [edfi_StudentSectionAttendanceEvent_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SubmissionStatusDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SubmissionStatusDescriptor_TR_DeleteTracking] ON [edfi].[SubmissionStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SubmissionStatusDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SubmissionStatusDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SubmissionStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SubmissionStatusDescriptor] ENABLE TRIGGER [edfi_SubmissionStatusDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_Survey_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_Survey_TR_DeleteTracking] ON [edfi].[Survey] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Survey](OldNamespace, OldSurveyIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.SurveyIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Survey] ENABLE TRIGGER [edfi_Survey_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyCategoryDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyCategoryDescriptor_TR_DeleteTracking] ON [edfi].[SurveyCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SurveyCategoryDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SurveyCategoryDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SurveyCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SurveyCategoryDescriptor] ENABLE TRIGGER [edfi_SurveyCategoryDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyCourseAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyCourseAssociation_TR_DeleteTracking] ON [edfi].[SurveyCourseAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveyCourseAssociation](OldCourseCode, OldEducationOrganizationId, OldNamespace, OldSurveyIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.CourseCode, d.EducationOrganizationId, d.Namespace, d.SurveyIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyCourseAssociation] ENABLE TRIGGER [edfi_SurveyCourseAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyLevelDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyLevelDescriptor_TR_DeleteTracking] ON [edfi].[SurveyLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.SurveyLevelDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.SurveyLevelDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SurveyLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SurveyLevelDescriptor] ENABLE TRIGGER [edfi_SurveyLevelDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyProgramAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyProgramAssociation_TR_DeleteTracking] ON [edfi].[SurveyProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveyProgramAssociation](OldEducationOrganizationId, OldNamespace, OldProgramName, OldProgramTypeDescriptorId, OldProgramTypeDescriptorNamespace, OldProgramTypeDescriptorCodeValue, OldSurveyIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.Namespace, d.ProgramName, d.ProgramTypeDescriptorId, j0.Namespace, j0.CodeValue, d.SurveyIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Descriptor j0
            ON d.ProgramTypeDescriptorId = j0.DescriptorId
END
GO

ALTER TABLE [edfi].[SurveyProgramAssociation] ENABLE TRIGGER [edfi_SurveyProgramAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyQuestion_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyQuestion_TR_DeleteTracking] ON [edfi].[SurveyQuestion] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveyQuestion](OldNamespace, OldQuestionCode, OldSurveyIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.QuestionCode, d.SurveyIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyQuestion] ENABLE TRIGGER [edfi_SurveyQuestion_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyQuestionResponse_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyQuestionResponse_TR_DeleteTracking] ON [edfi].[SurveyQuestionResponse] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveyQuestionResponse](OldNamespace, OldQuestionCode, OldSurveyIdentifier, OldSurveyResponseIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.QuestionCode, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyQuestionResponse] ENABLE TRIGGER [edfi_SurveyQuestionResponse_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponse_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponse_TR_DeleteTracking] ON [edfi].[SurveyResponse] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveyResponse](OldNamespace, OldSurveyIdentifier, OldSurveyResponseIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyResponse] ENABLE TRIGGER [edfi_SurveyResponse_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_DeleteTracking] ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveyResponseEducationOrganizationTargetAssociation](OldEducationOrganizationId, OldNamespace, OldSurveyIdentifier, OldSurveyResponseIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.Namespace, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ENABLE TRIGGER [edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponseStaffTargetAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponseStaffTargetAssociation_TR_DeleteTracking] ON [edfi].[SurveyResponseStaffTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveyResponseStaffTargetAssociation](OldNamespace, OldStaffUSI, OldStaffUniqueId, OldSurveyIdentifier, OldSurveyResponseIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.StaffUSI, j0.StaffUniqueId, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Staff j0
            ON d.StaffUSI = j0.StaffUSI
END
GO

ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ENABLE TRIGGER [edfi_SurveyResponseStaffTargetAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySection_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveySection_TR_DeleteTracking] ON [edfi].[SurveySection] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveySection](OldNamespace, OldSurveyIdentifier, OldSurveySectionTitle, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.SurveyIdentifier, d.SurveySectionTitle, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySection] ENABLE TRIGGER [edfi_SurveySection_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionAssociation_TR_DeleteTracking] ON [edfi].[SurveySectionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveySectionAssociation](OldLocalCourseCode, OldNamespace, OldSchoolId, OldSchoolYear, OldSectionIdentifier, OldSessionName, OldSurveyIdentifier, Id, Discriminator, ChangeVersion)
    SELECT d.LocalCourseCode, d.Namespace, d.SchoolId, d.SchoolYear, d.SectionIdentifier, d.SessionName, d.SurveyIdentifier, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySectionAssociation] ENABLE TRIGGER [edfi_SurveySectionAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponse_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponse_TR_DeleteTracking] ON [edfi].[SurveySectionResponse] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveySectionResponse](OldNamespace, OldSurveyIdentifier, OldSurveyResponseIdentifier, OldSurveySectionTitle, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.SurveySectionTitle, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySectionResponse] ENABLE TRIGGER [edfi_SurveySectionResponse_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_DeleteTracking] ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveySectionResponseEducationOrganizationTargetAssociation](OldEducationOrganizationId, OldNamespace, OldSurveyIdentifier, OldSurveyResponseIdentifier, OldSurveySectionTitle, Id, Discriminator, ChangeVersion)
    SELECT d.EducationOrganizationId, d.Namespace, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.SurveySectionTitle, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ENABLE TRIGGER [edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponseStaffTargetAssociation_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponseStaffTargetAssociation_TR_DeleteTracking] ON [edfi].[SurveySectionResponseStaffTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[SurveySectionResponseStaffTargetAssociation](OldNamespace, OldStaffUSI, OldStaffUniqueId, OldSurveyIdentifier, OldSurveyResponseIdentifier, OldSurveySectionTitle, Id, Discriminator, ChangeVersion)
    SELECT d.Namespace, d.StaffUSI, j0.StaffUniqueId, d.SurveyIdentifier, d.SurveyResponseIdentifier, d.SurveySectionTitle, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Staff j0
            ON d.StaffUSI = j0.StaffUSI
END
GO

ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ENABLE TRIGGER [edfi_SurveySectionResponseStaffTargetAssociation_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TeachingCredentialBasisDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TeachingCredentialBasisDescriptor_TR_DeleteTracking] ON [edfi].[TeachingCredentialBasisDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TeachingCredentialBasisDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TeachingCredentialBasisDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TeachingCredentialBasisDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TeachingCredentialBasisDescriptor] ENABLE TRIGGER [edfi_TeachingCredentialBasisDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TeachingCredentialDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TeachingCredentialDescriptor_TR_DeleteTracking] ON [edfi].[TeachingCredentialDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TeachingCredentialDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TeachingCredentialDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TeachingCredentialDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TeachingCredentialDescriptor] ENABLE TRIGGER [edfi_TeachingCredentialDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TechnicalSkillsAssessmentDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TechnicalSkillsAssessmentDescriptor_TR_DeleteTracking] ON [edfi].[TechnicalSkillsAssessmentDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TechnicalSkillsAssessmentDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TechnicalSkillsAssessmentDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TechnicalSkillsAssessmentDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TechnicalSkillsAssessmentDescriptor] ENABLE TRIGGER [edfi_TechnicalSkillsAssessmentDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TelephoneNumberTypeDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TelephoneNumberTypeDescriptor_TR_DeleteTracking] ON [edfi].[TelephoneNumberTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TelephoneNumberTypeDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TelephoneNumberTypeDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TelephoneNumberTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TelephoneNumberTypeDescriptor] ENABLE TRIGGER [edfi_TelephoneNumberTypeDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TermDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TermDescriptor_TR_DeleteTracking] ON [edfi].[TermDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TermDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TermDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TermDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TermDescriptor] ENABLE TRIGGER [edfi_TermDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TitleIPartAParticipantDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TitleIPartAParticipantDescriptor_TR_DeleteTracking] ON [edfi].[TitleIPartAParticipantDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TitleIPartAParticipantDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TitleIPartAParticipantDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TitleIPartAParticipantDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TitleIPartAParticipantDescriptor] ENABLE TRIGGER [edfi_TitleIPartAParticipantDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TitleIPartAProgramServiceDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TitleIPartAProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[TitleIPartAProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TitleIPartAProgramServiceDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TitleIPartAProgramServiceDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TitleIPartAProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TitleIPartAProgramServiceDescriptor] ENABLE TRIGGER [edfi_TitleIPartAProgramServiceDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TitleIPartASchoolDesignationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TitleIPartASchoolDesignationDescriptor_TR_DeleteTracking] ON [edfi].[TitleIPartASchoolDesignationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TitleIPartASchoolDesignationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TitleIPartASchoolDesignationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TitleIPartASchoolDesignationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TitleIPartASchoolDesignationDescriptor] ENABLE TRIGGER [edfi_TitleIPartASchoolDesignationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_TribalAffiliationDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_TribalAffiliationDescriptor_TR_DeleteTracking] ON [edfi].[TribalAffiliationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.TribalAffiliationDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.TribalAffiliationDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TribalAffiliationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TribalAffiliationDescriptor] ENABLE TRIGGER [edfi_TribalAffiliationDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_VisaDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_VisaDescriptor_TR_DeleteTracking] ON [edfi].[VisaDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.VisaDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.VisaDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.VisaDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[VisaDescriptor] ENABLE TRIGGER [edfi_VisaDescriptor_TR_DeleteTracking]
GO


DROP TRIGGER IF EXISTS [edfi].[edfi_WeaponDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [edfi].[edfi_WeaponDescriptor_TR_DeleteTracking] ON [edfi].[WeaponDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.WeaponDescriptorId, b.CodeValue, b.Namespace, b.Id, 'edfi.WeaponDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.WeaponDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[WeaponDescriptor] ENABLE TRIGGER [edfi_WeaponDescriptor_TR_DeleteTracking]
GO


