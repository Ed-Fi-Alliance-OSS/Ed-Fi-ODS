CREATE TRIGGER [edfi].[edfi_AbsenceEventCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AbsenceEventCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AbsenceEventCategoryDescriptor](AbsenceEventCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.AbsenceEventCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AbsenceEventCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AbsenceEventCategoryDescriptor] ENABLE TRIGGER [edfi_AbsenceEventCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AcademicHonorCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AcademicHonorCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AcademicHonorCategoryDescriptor](AcademicHonorCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.AcademicHonorCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AcademicHonorCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AcademicHonorCategoryDescriptor] ENABLE TRIGGER [edfi_AcademicHonorCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AcademicSubjectDescriptor_TR_DeleteTracking] ON [edfi].[AcademicSubjectDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AcademicSubjectDescriptor](AcademicSubjectDescriptorId, Id, ChangeVersion)
    SELECT  d.AcademicSubjectDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AcademicSubjectDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AcademicSubjectDescriptor] ENABLE TRIGGER [edfi_AcademicSubjectDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AcademicWeek_TR_DeleteTracking] ON [edfi].[AcademicWeek] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AcademicWeek](SchoolId, WeekIdentifier, Id, ChangeVersion)
    SELECT  SchoolId, WeekIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AcademicWeek] ENABLE TRIGGER [edfi_AcademicWeek_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AccommodationDescriptor_TR_DeleteTracking] ON [edfi].[AccommodationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AccommodationDescriptor](AccommodationDescriptorId, Id, ChangeVersion)
    SELECT  d.AccommodationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AccommodationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AccommodationDescriptor] ENABLE TRIGGER [edfi_AccommodationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AccountClassificationDescriptor_TR_DeleteTracking] ON [edfi].[AccountClassificationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AccountClassificationDescriptor](AccountClassificationDescriptorId, Id, ChangeVersion)
    SELECT  d.AccountClassificationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AccountClassificationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AccountClassificationDescriptor] ENABLE TRIGGER [edfi_AccountClassificationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AccountCode_TR_DeleteTracking] ON [edfi].[AccountCode] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AccountCode](AccountClassificationDescriptorId, AccountCodeNumber, EducationOrganizationId, FiscalYear, Id, ChangeVersion)
    SELECT  AccountClassificationDescriptorId, AccountCodeNumber, EducationOrganizationId, FiscalYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AccountCode] ENABLE TRIGGER [edfi_AccountCode_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Account_TR_DeleteTracking] ON [edfi].[Account] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Account](AccountIdentifier, EducationOrganizationId, FiscalYear, Id, ChangeVersion)
    SELECT  AccountIdentifier, EducationOrganizationId, FiscalYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Account] ENABLE TRIGGER [edfi_Account_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AccountabilityRating_TR_DeleteTracking] ON [edfi].[AccountabilityRating] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AccountabilityRating](EducationOrganizationId, RatingTitle, SchoolYear, Id, ChangeVersion)
    SELECT  EducationOrganizationId, RatingTitle, SchoolYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AccountabilityRating] ENABLE TRIGGER [edfi_AccountabilityRating_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AchievementCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AchievementCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AchievementCategoryDescriptor](AchievementCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.AchievementCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AchievementCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AchievementCategoryDescriptor] ENABLE TRIGGER [edfi_AchievementCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Actual_TR_DeleteTracking] ON [edfi].[Actual] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Actual](AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, Id, ChangeVersion)
    SELECT  AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Actual] ENABLE TRIGGER [edfi_Actual_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AdditionalCreditTypeDescriptor_TR_DeleteTracking] ON [edfi].[AdditionalCreditTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AdditionalCreditTypeDescriptor](AdditionalCreditTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.AdditionalCreditTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AdditionalCreditTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AdditionalCreditTypeDescriptor] ENABLE TRIGGER [edfi_AdditionalCreditTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AddressTypeDescriptor_TR_DeleteTracking] ON [edfi].[AddressTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AddressTypeDescriptor](AddressTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.AddressTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AddressTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AddressTypeDescriptor] ENABLE TRIGGER [edfi_AddressTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AdministrationEnvironmentDescriptor_TR_DeleteTracking] ON [edfi].[AdministrationEnvironmentDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AdministrationEnvironmentDescriptor](AdministrationEnvironmentDescriptorId, Id, ChangeVersion)
    SELECT  d.AdministrationEnvironmentDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AdministrationEnvironmentDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AdministrationEnvironmentDescriptor] ENABLE TRIGGER [edfi_AdministrationEnvironmentDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AdministrativeFundingControlDescriptor_TR_DeleteTracking] ON [edfi].[AdministrativeFundingControlDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AdministrativeFundingControlDescriptor](AdministrativeFundingControlDescriptorId, Id, ChangeVersion)
    SELECT  d.AdministrativeFundingControlDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AdministrativeFundingControlDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AdministrativeFundingControlDescriptor] ENABLE TRIGGER [edfi_AdministrativeFundingControlDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AncestryEthnicOriginDescriptor_TR_DeleteTracking] ON [edfi].[AncestryEthnicOriginDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AncestryEthnicOriginDescriptor](AncestryEthnicOriginDescriptorId, Id, ChangeVersion)
    SELECT  d.AncestryEthnicOriginDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AncestryEthnicOriginDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AncestryEthnicOriginDescriptor] ENABLE TRIGGER [edfi_AncestryEthnicOriginDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AssessmentCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AssessmentCategoryDescriptor](AssessmentCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.AssessmentCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentCategoryDescriptor] ENABLE TRIGGER [edfi_AssessmentCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AssessmentIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AssessmentIdentificationSystemDescriptor](AssessmentIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT  d.AssessmentIdentificationSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_AssessmentIdentificationSystemDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AssessmentItemCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentItemCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AssessmentItemCategoryDescriptor](AssessmentItemCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.AssessmentItemCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentItemCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentItemCategoryDescriptor] ENABLE TRIGGER [edfi_AssessmentItemCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AssessmentItemResultDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentItemResultDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AssessmentItemResultDescriptor](AssessmentItemResultDescriptorId, Id, ChangeVersion)
    SELECT  d.AssessmentItemResultDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentItemResultDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentItemResultDescriptor] ENABLE TRIGGER [edfi_AssessmentItemResultDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AssessmentItem_TR_DeleteTracking] ON [edfi].[AssessmentItem] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AssessmentItem](AssessmentIdentifier, IdentificationCode, Namespace, Id, ChangeVersion)
    SELECT  AssessmentIdentifier, IdentificationCode, Namespace, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AssessmentItem] ENABLE TRIGGER [edfi_AssessmentItem_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AssessmentPeriodDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentPeriodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AssessmentPeriodDescriptor](AssessmentPeriodDescriptorId, Id, ChangeVersion)
    SELECT  d.AssessmentPeriodDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentPeriodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentPeriodDescriptor] ENABLE TRIGGER [edfi_AssessmentPeriodDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AssessmentReportingMethodDescriptor_TR_DeleteTracking] ON [edfi].[AssessmentReportingMethodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AssessmentReportingMethodDescriptor](AssessmentReportingMethodDescriptorId, Id, ChangeVersion)
    SELECT  d.AssessmentReportingMethodDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AssessmentReportingMethodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AssessmentReportingMethodDescriptor] ENABLE TRIGGER [edfi_AssessmentReportingMethodDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AssessmentScoreRangeLearningStandard_TR_DeleteTracking] ON [edfi].[AssessmentScoreRangeLearningStandard] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AssessmentScoreRangeLearningStandard](AssessmentIdentifier, Namespace, ScoreRangeId, Id, ChangeVersion)
    SELECT  AssessmentIdentifier, Namespace, ScoreRangeId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[AssessmentScoreRangeLearningStandard] ENABLE TRIGGER [edfi_AssessmentScoreRangeLearningStandard_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Assessment_TR_DeleteTracking] ON [edfi].[Assessment] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Assessment](AssessmentIdentifier, Namespace, Id, ChangeVersion)
    SELECT  AssessmentIdentifier, Namespace, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Assessment] ENABLE TRIGGER [edfi_Assessment_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AttemptStatusDescriptor_TR_DeleteTracking] ON [edfi].[AttemptStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AttemptStatusDescriptor](AttemptStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.AttemptStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AttemptStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AttemptStatusDescriptor] ENABLE TRIGGER [edfi_AttemptStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_AttendanceEventCategoryDescriptor_TR_DeleteTracking] ON [edfi].[AttendanceEventCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[AttendanceEventCategoryDescriptor](AttendanceEventCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.AttendanceEventCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AttendanceEventCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[AttendanceEventCategoryDescriptor] ENABLE TRIGGER [edfi_AttendanceEventCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_BarrierToInternetAccessInResidenceDescriptor_TR_DeleteTracking] ON [edfi].[BarrierToInternetAccessInResidenceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[BarrierToInternetAccessInResidenceDescriptor](BarrierToInternetAccessInResidenceDescriptorId, Id, ChangeVersion)
    SELECT  d.BarrierToInternetAccessInResidenceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.BarrierToInternetAccessInResidenceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[BarrierToInternetAccessInResidenceDescriptor] ENABLE TRIGGER [edfi_BarrierToInternetAccessInResidenceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_BehaviorDescriptor_TR_DeleteTracking] ON [edfi].[BehaviorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[BehaviorDescriptor](BehaviorDescriptorId, Id, ChangeVersion)
    SELECT  d.BehaviorDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.BehaviorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[BehaviorDescriptor] ENABLE TRIGGER [edfi_BehaviorDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_BellSchedule_TR_DeleteTracking] ON [edfi].[BellSchedule] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[BellSchedule](BellScheduleName, SchoolId, Id, ChangeVersion)
    SELECT  BellScheduleName, SchoolId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[BellSchedule] ENABLE TRIGGER [edfi_BellSchedule_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Budget_TR_DeleteTracking] ON [edfi].[Budget] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Budget](AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, Id, ChangeVersion)
    SELECT  AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Budget] ENABLE TRIGGER [edfi_Budget_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CTEProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[CTEProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CTEProgramServiceDescriptor](CTEProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.CTEProgramServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CTEProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CTEProgramServiceDescriptor] ENABLE TRIGGER [edfi_CTEProgramServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CalendarDate_TR_DeleteTracking] ON [edfi].[CalendarDate] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CalendarDate](CalendarCode, Date, SchoolId, SchoolYear, Id, ChangeVersion)
    SELECT  CalendarCode, Date, SchoolId, SchoolYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[CalendarDate] ENABLE TRIGGER [edfi_CalendarDate_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CalendarEventDescriptor_TR_DeleteTracking] ON [edfi].[CalendarEventDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CalendarEventDescriptor](CalendarEventDescriptorId, Id, ChangeVersion)
    SELECT  d.CalendarEventDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CalendarEventDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CalendarEventDescriptor] ENABLE TRIGGER [edfi_CalendarEventDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CalendarTypeDescriptor_TR_DeleteTracking] ON [edfi].[CalendarTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CalendarTypeDescriptor](CalendarTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.CalendarTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CalendarTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CalendarTypeDescriptor] ENABLE TRIGGER [edfi_CalendarTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Calendar_TR_DeleteTracking] ON [edfi].[Calendar] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Calendar](CalendarCode, SchoolId, SchoolYear, Id, ChangeVersion)
    SELECT  CalendarCode, SchoolId, SchoolYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Calendar] ENABLE TRIGGER [edfi_Calendar_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CareerPathwayDescriptor_TR_DeleteTracking] ON [edfi].[CareerPathwayDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CareerPathwayDescriptor](CareerPathwayDescriptorId, Id, ChangeVersion)
    SELECT  d.CareerPathwayDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CareerPathwayDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CareerPathwayDescriptor] ENABLE TRIGGER [edfi_CareerPathwayDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CharterApprovalAgencyTypeDescriptor_TR_DeleteTracking] ON [edfi].[CharterApprovalAgencyTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CharterApprovalAgencyTypeDescriptor](CharterApprovalAgencyTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.CharterApprovalAgencyTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CharterApprovalAgencyTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CharterApprovalAgencyTypeDescriptor] ENABLE TRIGGER [edfi_CharterApprovalAgencyTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CharterStatusDescriptor_TR_DeleteTracking] ON [edfi].[CharterStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CharterStatusDescriptor](CharterStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.CharterStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CharterStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CharterStatusDescriptor] ENABLE TRIGGER [edfi_CharterStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CitizenshipStatusDescriptor_TR_DeleteTracking] ON [edfi].[CitizenshipStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CitizenshipStatusDescriptor](CitizenshipStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.CitizenshipStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CitizenshipStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CitizenshipStatusDescriptor] ENABLE TRIGGER [edfi_CitizenshipStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ClassPeriod_TR_DeleteTracking] ON [edfi].[ClassPeriod] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ClassPeriod](ClassPeriodName, SchoolId, Id, ChangeVersion)
    SELECT  ClassPeriodName, SchoolId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ClassPeriod] ENABLE TRIGGER [edfi_ClassPeriod_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ClassroomPositionDescriptor_TR_DeleteTracking] ON [edfi].[ClassroomPositionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ClassroomPositionDescriptor](ClassroomPositionDescriptorId, Id, ChangeVersion)
    SELECT  d.ClassroomPositionDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ClassroomPositionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ClassroomPositionDescriptor] ENABLE TRIGGER [edfi_ClassroomPositionDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CohortScopeDescriptor_TR_DeleteTracking] ON [edfi].[CohortScopeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CohortScopeDescriptor](CohortScopeDescriptorId, Id, ChangeVersion)
    SELECT  d.CohortScopeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CohortScopeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CohortScopeDescriptor] ENABLE TRIGGER [edfi_CohortScopeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CohortTypeDescriptor_TR_DeleteTracking] ON [edfi].[CohortTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CohortTypeDescriptor](CohortTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.CohortTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CohortTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CohortTypeDescriptor] ENABLE TRIGGER [edfi_CohortTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CohortYearTypeDescriptor_TR_DeleteTracking] ON [edfi].[CohortYearTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CohortYearTypeDescriptor](CohortYearTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.CohortYearTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CohortYearTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CohortYearTypeDescriptor] ENABLE TRIGGER [edfi_CohortYearTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Cohort_TR_DeleteTracking] ON [edfi].[Cohort] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Cohort](CohortIdentifier, EducationOrganizationId, Id, ChangeVersion)
    SELECT  CohortIdentifier, EducationOrganizationId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Cohort] ENABLE TRIGGER [edfi_Cohort_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CommunityOrganization_TR_DeleteTracking] ON [edfi].[CommunityOrganization] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CommunityOrganization](CommunityOrganizationId, Id, ChangeVersion)
    SELECT  d.CommunityOrganizationId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.CommunityOrganizationId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[CommunityOrganization] ENABLE TRIGGER [edfi_CommunityOrganization_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CommunityProviderLicense_TR_DeleteTracking] ON [edfi].[CommunityProviderLicense] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CommunityProviderLicense](CommunityProviderId, LicenseIdentifier, LicensingOrganization, Id, ChangeVersion)
    SELECT  CommunityProviderId, LicenseIdentifier, LicensingOrganization, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[CommunityProviderLicense] ENABLE TRIGGER [edfi_CommunityProviderLicense_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CommunityProvider_TR_DeleteTracking] ON [edfi].[CommunityProvider] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CommunityProvider](CommunityProviderId, Id, ChangeVersion)
    SELECT  d.CommunityProviderId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.CommunityProviderId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[CommunityProvider] ENABLE TRIGGER [edfi_CommunityProvider_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CompetencyLevelDescriptor_TR_DeleteTracking] ON [edfi].[CompetencyLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CompetencyLevelDescriptor](CompetencyLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.CompetencyLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CompetencyLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CompetencyLevelDescriptor] ENABLE TRIGGER [edfi_CompetencyLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CompetencyObjective_TR_DeleteTracking] ON [edfi].[CompetencyObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CompetencyObjective](EducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[CompetencyObjective] ENABLE TRIGGER [edfi_CompetencyObjective_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ContactTypeDescriptor_TR_DeleteTracking] ON [edfi].[ContactTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ContactTypeDescriptor](ContactTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.ContactTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ContactTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ContactTypeDescriptor] ENABLE TRIGGER [edfi_ContactTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ContentClassDescriptor_TR_DeleteTracking] ON [edfi].[ContentClassDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ContentClassDescriptor](ContentClassDescriptorId, Id, ChangeVersion)
    SELECT  d.ContentClassDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ContentClassDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ContentClassDescriptor] ENABLE TRIGGER [edfi_ContentClassDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ContinuationOfServicesReasonDescriptor_TR_DeleteTracking] ON [edfi].[ContinuationOfServicesReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ContinuationOfServicesReasonDescriptor](ContinuationOfServicesReasonDescriptorId, Id, ChangeVersion)
    SELECT  d.ContinuationOfServicesReasonDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ContinuationOfServicesReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ContinuationOfServicesReasonDescriptor] ENABLE TRIGGER [edfi_ContinuationOfServicesReasonDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ContractedStaff_TR_DeleteTracking] ON [edfi].[ContractedStaff] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ContractedStaff](AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, StaffUSI, Id, ChangeVersion)
    SELECT  AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ContractedStaff] ENABLE TRIGGER [edfi_ContractedStaff_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CostRateDescriptor_TR_DeleteTracking] ON [edfi].[CostRateDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CostRateDescriptor](CostRateDescriptorId, Id, ChangeVersion)
    SELECT  d.CostRateDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CostRateDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CostRateDescriptor] ENABLE TRIGGER [edfi_CostRateDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CountryDescriptor_TR_DeleteTracking] ON [edfi].[CountryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CountryDescriptor](CountryDescriptorId, Id, ChangeVersion)
    SELECT  d.CountryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CountryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CountryDescriptor] ENABLE TRIGGER [edfi_CountryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CourseAttemptResultDescriptor_TR_DeleteTracking] ON [edfi].[CourseAttemptResultDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CourseAttemptResultDescriptor](CourseAttemptResultDescriptorId, Id, ChangeVersion)
    SELECT  d.CourseAttemptResultDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseAttemptResultDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseAttemptResultDescriptor] ENABLE TRIGGER [edfi_CourseAttemptResultDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CourseDefinedByDescriptor_TR_DeleteTracking] ON [edfi].[CourseDefinedByDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CourseDefinedByDescriptor](CourseDefinedByDescriptorId, Id, ChangeVersion)
    SELECT  d.CourseDefinedByDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseDefinedByDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseDefinedByDescriptor] ENABLE TRIGGER [edfi_CourseDefinedByDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CourseGPAApplicabilityDescriptor_TR_DeleteTracking] ON [edfi].[CourseGPAApplicabilityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CourseGPAApplicabilityDescriptor](CourseGPAApplicabilityDescriptorId, Id, ChangeVersion)
    SELECT  d.CourseGPAApplicabilityDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseGPAApplicabilityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseGPAApplicabilityDescriptor] ENABLE TRIGGER [edfi_CourseGPAApplicabilityDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CourseIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[CourseIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CourseIdentificationSystemDescriptor](CourseIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT  d.CourseIdentificationSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_CourseIdentificationSystemDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CourseLevelCharacteristicDescriptor_TR_DeleteTracking] ON [edfi].[CourseLevelCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CourseLevelCharacteristicDescriptor](CourseLevelCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT  d.CourseLevelCharacteristicDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseLevelCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseLevelCharacteristicDescriptor] ENABLE TRIGGER [edfi_CourseLevelCharacteristicDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CourseOffering_TR_DeleteTracking] ON [edfi].[CourseOffering] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CourseOffering](LocalCourseCode, SchoolId, SchoolYear, SessionName, Id, ChangeVersion)
    SELECT  LocalCourseCode, SchoolId, SchoolYear, SessionName, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[CourseOffering] ENABLE TRIGGER [edfi_CourseOffering_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CourseRepeatCodeDescriptor_TR_DeleteTracking] ON [edfi].[CourseRepeatCodeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CourseRepeatCodeDescriptor](CourseRepeatCodeDescriptorId, Id, ChangeVersion)
    SELECT  d.CourseRepeatCodeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CourseRepeatCodeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CourseRepeatCodeDescriptor] ENABLE TRIGGER [edfi_CourseRepeatCodeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CourseTranscript_TR_DeleteTracking] ON [edfi].[CourseTranscript] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CourseTranscript](CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, Id, ChangeVersion)
    SELECT  CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[CourseTranscript] ENABLE TRIGGER [edfi_CourseTranscript_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Course_TR_DeleteTracking] ON [edfi].[Course] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Course](CourseCode, EducationOrganizationId, Id, ChangeVersion)
    SELECT  CourseCode, EducationOrganizationId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Course] ENABLE TRIGGER [edfi_Course_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CredentialFieldDescriptor_TR_DeleteTracking] ON [edfi].[CredentialFieldDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CredentialFieldDescriptor](CredentialFieldDescriptorId, Id, ChangeVersion)
    SELECT  d.CredentialFieldDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CredentialFieldDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CredentialFieldDescriptor] ENABLE TRIGGER [edfi_CredentialFieldDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CredentialTypeDescriptor_TR_DeleteTracking] ON [edfi].[CredentialTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CredentialTypeDescriptor](CredentialTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.CredentialTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CredentialTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CredentialTypeDescriptor] ENABLE TRIGGER [edfi_CredentialTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Credential_TR_DeleteTracking] ON [edfi].[Credential] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Credential](CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, Id, ChangeVersion)
    SELECT  CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Credential] ENABLE TRIGGER [edfi_Credential_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CreditCategoryDescriptor_TR_DeleteTracking] ON [edfi].[CreditCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CreditCategoryDescriptor](CreditCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.CreditCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CreditCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CreditCategoryDescriptor] ENABLE TRIGGER [edfi_CreditCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CreditTypeDescriptor_TR_DeleteTracking] ON [edfi].[CreditTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CreditTypeDescriptor](CreditTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.CreditTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CreditTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CreditTypeDescriptor] ENABLE TRIGGER [edfi_CreditTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_CurriculumUsedDescriptor_TR_DeleteTracking] ON [edfi].[CurriculumUsedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[CurriculumUsedDescriptor](CurriculumUsedDescriptorId, Id, ChangeVersion)
    SELECT  d.CurriculumUsedDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.CurriculumUsedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[CurriculumUsedDescriptor] ENABLE TRIGGER [edfi_CurriculumUsedDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DeliveryMethodDescriptor_TR_DeleteTracking] ON [edfi].[DeliveryMethodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DeliveryMethodDescriptor](DeliveryMethodDescriptorId, Id, ChangeVersion)
    SELECT  d.DeliveryMethodDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DeliveryMethodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DeliveryMethodDescriptor] ENABLE TRIGGER [edfi_DeliveryMethodDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Descriptor_TR_DeleteTracking] ON [edfi].[Descriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Descriptor](DescriptorId, Id, ChangeVersion)
    SELECT  DescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Descriptor] ENABLE TRIGGER [edfi_Descriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DiagnosisDescriptor_TR_DeleteTracking] ON [edfi].[DiagnosisDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DiagnosisDescriptor](DiagnosisDescriptorId, Id, ChangeVersion)
    SELECT  d.DiagnosisDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DiagnosisDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DiagnosisDescriptor] ENABLE TRIGGER [edfi_DiagnosisDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DiplomaLevelDescriptor_TR_DeleteTracking] ON [edfi].[DiplomaLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DiplomaLevelDescriptor](DiplomaLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.DiplomaLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DiplomaLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DiplomaLevelDescriptor] ENABLE TRIGGER [edfi_DiplomaLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DiplomaTypeDescriptor_TR_DeleteTracking] ON [edfi].[DiplomaTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DiplomaTypeDescriptor](DiplomaTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.DiplomaTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DiplomaTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DiplomaTypeDescriptor] ENABLE TRIGGER [edfi_DiplomaTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DisabilityDescriptor_TR_DeleteTracking] ON [edfi].[DisabilityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DisabilityDescriptor](DisabilityDescriptorId, Id, ChangeVersion)
    SELECT  d.DisabilityDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisabilityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisabilityDescriptor] ENABLE TRIGGER [edfi_DisabilityDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DisabilityDesignationDescriptor_TR_DeleteTracking] ON [edfi].[DisabilityDesignationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DisabilityDesignationDescriptor](DisabilityDesignationDescriptorId, Id, ChangeVersion)
    SELECT  d.DisabilityDesignationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisabilityDesignationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisabilityDesignationDescriptor] ENABLE TRIGGER [edfi_DisabilityDesignationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DisabilityDeterminationSourceTypeDescriptor_TR_DeleteTracking] ON [edfi].[DisabilityDeterminationSourceTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DisabilityDeterminationSourceTypeDescriptor](DisabilityDeterminationSourceTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.DisabilityDeterminationSourceTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisabilityDeterminationSourceTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisabilityDeterminationSourceTypeDescriptor] ENABLE TRIGGER [edfi_DisabilityDeterminationSourceTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DisciplineActionLengthDifferenceReasonDescriptor_TR_DeleteTracking] ON [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DisciplineActionLengthDifferenceReasonDescriptor](DisciplineActionLengthDifferenceReasonDescriptorId, Id, ChangeVersion)
    SELECT  d.DisciplineActionLengthDifferenceReasonDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisciplineActionLengthDifferenceReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] ENABLE TRIGGER [edfi_DisciplineActionLengthDifferenceReasonDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DisciplineAction_TR_DeleteTracking] ON [edfi].[DisciplineAction] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DisciplineAction](DisciplineActionIdentifier, DisciplineDate, StudentUSI, Id, ChangeVersion)
    SELECT  DisciplineActionIdentifier, DisciplineDate, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[DisciplineAction] ENABLE TRIGGER [edfi_DisciplineAction_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DisciplineDescriptor_TR_DeleteTracking] ON [edfi].[DisciplineDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DisciplineDescriptor](DisciplineDescriptorId, Id, ChangeVersion)
    SELECT  d.DisciplineDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisciplineDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisciplineDescriptor] ENABLE TRIGGER [edfi_DisciplineDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DisciplineIncidentParticipationCodeDescriptor_TR_DeleteTracking] ON [edfi].[DisciplineIncidentParticipationCodeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DisciplineIncidentParticipationCodeDescriptor](DisciplineIncidentParticipationCodeDescriptorId, Id, ChangeVersion)
    SELECT  d.DisciplineIncidentParticipationCodeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.DisciplineIncidentParticipationCodeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[DisciplineIncidentParticipationCodeDescriptor] ENABLE TRIGGER [edfi_DisciplineIncidentParticipationCodeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_DisciplineIncident_TR_DeleteTracking] ON [edfi].[DisciplineIncident] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[DisciplineIncident](IncidentIdentifier, SchoolId, Id, ChangeVersion)
    SELECT  IncidentIdentifier, SchoolId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[DisciplineIncident] ENABLE TRIGGER [edfi_DisciplineIncident_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationContent_TR_DeleteTracking] ON [edfi].[EducationContent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationContent](ContentIdentifier, Id, ChangeVersion)
    SELECT  ContentIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationContent] ENABLE TRIGGER [edfi_EducationContent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationOrganizationCategoryDescriptor_TR_DeleteTracking] ON [edfi].[EducationOrganizationCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationOrganizationCategoryDescriptor](EducationOrganizationCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.EducationOrganizationCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationOrganizationCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationOrganizationCategoryDescriptor] ENABLE TRIGGER [edfi_EducationOrganizationCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationOrganizationIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[EducationOrganizationIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationOrganizationIdentificationSystemDescriptor](EducationOrganizationIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT  d.EducationOrganizationIdentificationSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationOrganizationIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationOrganizationIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_EducationOrganizationIdentificationSystemDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_DeleteTracking] ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationOrganizationInterventionPrescriptionAssociation](EducationOrganizationId, InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode, Id, ChangeVersion)
    SELECT  EducationOrganizationId, InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ENABLE TRIGGER [edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationOrganizationNetworkAssociation_TR_DeleteTracking] ON [edfi].[EducationOrganizationNetworkAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationOrganizationNetworkAssociation](EducationOrganizationNetworkId, MemberEducationOrganizationId, Id, ChangeVersion)
    SELECT  EducationOrganizationNetworkId, MemberEducationOrganizationId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ENABLE TRIGGER [edfi_EducationOrganizationNetworkAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationOrganizationNetwork_TR_DeleteTracking] ON [edfi].[EducationOrganizationNetwork] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationOrganizationNetwork](EducationOrganizationNetworkId, Id, ChangeVersion)
    SELECT  d.EducationOrganizationNetworkId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.EducationOrganizationNetworkId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[EducationOrganizationNetwork] ENABLE TRIGGER [edfi_EducationOrganizationNetwork_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationOrganizationPeerAssociation_TR_DeleteTracking] ON [edfi].[EducationOrganizationPeerAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationOrganizationPeerAssociation](EducationOrganizationId, PeerEducationOrganizationId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, PeerEducationOrganizationId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ENABLE TRIGGER [edfi_EducationOrganizationPeerAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationOrganization_TR_DeleteTracking] ON [edfi].[EducationOrganization] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationOrganization](EducationOrganizationId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[EducationOrganization] ENABLE TRIGGER [edfi_EducationOrganization_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationPlanDescriptor_TR_DeleteTracking] ON [edfi].[EducationPlanDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationPlanDescriptor](EducationPlanDescriptorId, Id, ChangeVersion)
    SELECT  d.EducationPlanDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationPlanDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationPlanDescriptor] ENABLE TRIGGER [edfi_EducationPlanDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationServiceCenter_TR_DeleteTracking] ON [edfi].[EducationServiceCenter] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationServiceCenter](EducationServiceCenterId, Id, ChangeVersion)
    SELECT  d.EducationServiceCenterId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.EducationServiceCenterId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[EducationServiceCenter] ENABLE TRIGGER [edfi_EducationServiceCenter_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EducationalEnvironmentDescriptor_TR_DeleteTracking] ON [edfi].[EducationalEnvironmentDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EducationalEnvironmentDescriptor](EducationalEnvironmentDescriptorId, Id, ChangeVersion)
    SELECT  d.EducationalEnvironmentDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EducationalEnvironmentDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EducationalEnvironmentDescriptor] ENABLE TRIGGER [edfi_EducationalEnvironmentDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ElectronicMailTypeDescriptor_TR_DeleteTracking] ON [edfi].[ElectronicMailTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ElectronicMailTypeDescriptor](ElectronicMailTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.ElectronicMailTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ElectronicMailTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ElectronicMailTypeDescriptor] ENABLE TRIGGER [edfi_ElectronicMailTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EmploymentStatusDescriptor_TR_DeleteTracking] ON [edfi].[EmploymentStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EmploymentStatusDescriptor](EmploymentStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.EmploymentStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EmploymentStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EmploymentStatusDescriptor] ENABLE TRIGGER [edfi_EmploymentStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EntryGradeLevelReasonDescriptor_TR_DeleteTracking] ON [edfi].[EntryGradeLevelReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EntryGradeLevelReasonDescriptor](EntryGradeLevelReasonDescriptorId, Id, ChangeVersion)
    SELECT  d.EntryGradeLevelReasonDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EntryGradeLevelReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EntryGradeLevelReasonDescriptor] ENABLE TRIGGER [edfi_EntryGradeLevelReasonDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EntryTypeDescriptor_TR_DeleteTracking] ON [edfi].[EntryTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EntryTypeDescriptor](EntryTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.EntryTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EntryTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EntryTypeDescriptor] ENABLE TRIGGER [edfi_EntryTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_EventCircumstanceDescriptor_TR_DeleteTracking] ON [edfi].[EventCircumstanceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[EventCircumstanceDescriptor](EventCircumstanceDescriptorId, Id, ChangeVersion)
    SELECT  d.EventCircumstanceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.EventCircumstanceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[EventCircumstanceDescriptor] ENABLE TRIGGER [edfi_EventCircumstanceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ExitWithdrawTypeDescriptor_TR_DeleteTracking] ON [edfi].[ExitWithdrawTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ExitWithdrawTypeDescriptor](ExitWithdrawTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.ExitWithdrawTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ExitWithdrawTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ExitWithdrawTypeDescriptor] ENABLE TRIGGER [edfi_ExitWithdrawTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_FeederSchoolAssociation_TR_DeleteTracking] ON [edfi].[FeederSchoolAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[FeederSchoolAssociation](BeginDate, FeederSchoolId, SchoolId, Id, ChangeVersion)
    SELECT  BeginDate, FeederSchoolId, SchoolId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[FeederSchoolAssociation] ENABLE TRIGGER [edfi_FeederSchoolAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GeneralStudentProgramAssociation_TR_DeleteTracking] ON [edfi].[GeneralStudentProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GeneralStudentProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[GeneralStudentProgramAssociation] ENABLE TRIGGER [edfi_GeneralStudentProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GradeLevelDescriptor_TR_DeleteTracking] ON [edfi].[GradeLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GradeLevelDescriptor](GradeLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.GradeLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradeLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradeLevelDescriptor] ENABLE TRIGGER [edfi_GradeLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GradePointAverageTypeDescriptor_TR_DeleteTracking] ON [edfi].[GradePointAverageTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GradePointAverageTypeDescriptor](GradePointAverageTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.GradePointAverageTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradePointAverageTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradePointAverageTypeDescriptor] ENABLE TRIGGER [edfi_GradePointAverageTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GradeTypeDescriptor_TR_DeleteTracking] ON [edfi].[GradeTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GradeTypeDescriptor](GradeTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.GradeTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradeTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradeTypeDescriptor] ENABLE TRIGGER [edfi_GradeTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Grade_TR_DeleteTracking] ON [edfi].[Grade] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Grade](BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSchoolYear, GradingPeriodSequence, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    SELECT  BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSchoolYear, GradingPeriodSequence, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Grade] ENABLE TRIGGER [edfi_Grade_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GradebookEntryTypeDescriptor_TR_DeleteTracking] ON [edfi].[GradebookEntryTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GradebookEntryTypeDescriptor](GradebookEntryTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.GradebookEntryTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradebookEntryTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradebookEntryTypeDescriptor] ENABLE TRIGGER [edfi_GradebookEntryTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GradebookEntry_TR_DeleteTracking] ON [edfi].[GradebookEntry] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GradebookEntry](DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, ChangeVersion)
    SELECT  DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[GradebookEntry] ENABLE TRIGGER [edfi_GradebookEntry_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GradingPeriodDescriptor_TR_DeleteTracking] ON [edfi].[GradingPeriodDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GradingPeriodDescriptor](GradingPeriodDescriptorId, Id, ChangeVersion)
    SELECT  d.GradingPeriodDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GradingPeriodDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GradingPeriodDescriptor] ENABLE TRIGGER [edfi_GradingPeriodDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GradingPeriod_TR_DeleteTracking] ON [edfi].[GradingPeriod] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GradingPeriod](GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear, Id, ChangeVersion)
    SELECT  GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[GradingPeriod] ENABLE TRIGGER [edfi_GradingPeriod_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GraduationPlanTypeDescriptor_TR_DeleteTracking] ON [edfi].[GraduationPlanTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GraduationPlanTypeDescriptor](GraduationPlanTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.GraduationPlanTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GraduationPlanTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GraduationPlanTypeDescriptor] ENABLE TRIGGER [edfi_GraduationPlanTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GraduationPlan_TR_DeleteTracking] ON [edfi].[GraduationPlan] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GraduationPlan](EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, Id, ChangeVersion)
    SELECT  EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[GraduationPlan] ENABLE TRIGGER [edfi_GraduationPlan_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_GunFreeSchoolsActReportingStatusDescriptor_TR_DeleteTracking] ON [edfi].[GunFreeSchoolsActReportingStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[GunFreeSchoolsActReportingStatusDescriptor](GunFreeSchoolsActReportingStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.GunFreeSchoolsActReportingStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.GunFreeSchoolsActReportingStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[GunFreeSchoolsActReportingStatusDescriptor] ENABLE TRIGGER [edfi_GunFreeSchoolsActReportingStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_HomelessPrimaryNighttimeResidenceDescriptor_TR_DeleteTracking] ON [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[HomelessPrimaryNighttimeResidenceDescriptor](HomelessPrimaryNighttimeResidenceDescriptorId, Id, ChangeVersion)
    SELECT  d.HomelessPrimaryNighttimeResidenceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.HomelessPrimaryNighttimeResidenceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] ENABLE TRIGGER [edfi_HomelessPrimaryNighttimeResidenceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_HomelessProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[HomelessProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[HomelessProgramServiceDescriptor](HomelessProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.HomelessProgramServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.HomelessProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[HomelessProgramServiceDescriptor] ENABLE TRIGGER [edfi_HomelessProgramServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_IdentificationDocumentUseDescriptor_TR_DeleteTracking] ON [edfi].[IdentificationDocumentUseDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[IdentificationDocumentUseDescriptor](IdentificationDocumentUseDescriptorId, Id, ChangeVersion)
    SELECT  d.IdentificationDocumentUseDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IdentificationDocumentUseDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IdentificationDocumentUseDescriptor] ENABLE TRIGGER [edfi_IdentificationDocumentUseDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_IncidentLocationDescriptor_TR_DeleteTracking] ON [edfi].[IncidentLocationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[IncidentLocationDescriptor](IncidentLocationDescriptorId, Id, ChangeVersion)
    SELECT  d.IncidentLocationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IncidentLocationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IncidentLocationDescriptor] ENABLE TRIGGER [edfi_IncidentLocationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_IndicatorDescriptor_TR_DeleteTracking] ON [edfi].[IndicatorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[IndicatorDescriptor](IndicatorDescriptorId, Id, ChangeVersion)
    SELECT  d.IndicatorDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IndicatorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IndicatorDescriptor] ENABLE TRIGGER [edfi_IndicatorDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_IndicatorGroupDescriptor_TR_DeleteTracking] ON [edfi].[IndicatorGroupDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[IndicatorGroupDescriptor](IndicatorGroupDescriptorId, Id, ChangeVersion)
    SELECT  d.IndicatorGroupDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IndicatorGroupDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IndicatorGroupDescriptor] ENABLE TRIGGER [edfi_IndicatorGroupDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_IndicatorLevelDescriptor_TR_DeleteTracking] ON [edfi].[IndicatorLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[IndicatorLevelDescriptor](IndicatorLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.IndicatorLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.IndicatorLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[IndicatorLevelDescriptor] ENABLE TRIGGER [edfi_IndicatorLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InstitutionTelephoneNumberTypeDescriptor_TR_DeleteTracking] ON [edfi].[InstitutionTelephoneNumberTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InstitutionTelephoneNumberTypeDescriptor](InstitutionTelephoneNumberTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.InstitutionTelephoneNumberTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InstitutionTelephoneNumberTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InstitutionTelephoneNumberTypeDescriptor] ENABLE TRIGGER [edfi_InstitutionTelephoneNumberTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InteractivityStyleDescriptor_TR_DeleteTracking] ON [edfi].[InteractivityStyleDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InteractivityStyleDescriptor](InteractivityStyleDescriptorId, Id, ChangeVersion)
    SELECT  d.InteractivityStyleDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InteractivityStyleDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InteractivityStyleDescriptor] ENABLE TRIGGER [edfi_InteractivityStyleDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InternetAccessDescriptor_TR_DeleteTracking] ON [edfi].[InternetAccessDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InternetAccessDescriptor](InternetAccessDescriptorId, Id, ChangeVersion)
    SELECT  d.InternetAccessDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InternetAccessDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InternetAccessDescriptor] ENABLE TRIGGER [edfi_InternetAccessDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InternetAccessTypeInResidenceDescriptor_TR_DeleteTracking] ON [edfi].[InternetAccessTypeInResidenceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InternetAccessTypeInResidenceDescriptor](InternetAccessTypeInResidenceDescriptorId, Id, ChangeVersion)
    SELECT  d.InternetAccessTypeInResidenceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InternetAccessTypeInResidenceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InternetAccessTypeInResidenceDescriptor] ENABLE TRIGGER [edfi_InternetAccessTypeInResidenceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InternetPerformanceInResidenceDescriptor_TR_DeleteTracking] ON [edfi].[InternetPerformanceInResidenceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InternetPerformanceInResidenceDescriptor](InternetPerformanceInResidenceDescriptorId, Id, ChangeVersion)
    SELECT  d.InternetPerformanceInResidenceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InternetPerformanceInResidenceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InternetPerformanceInResidenceDescriptor] ENABLE TRIGGER [edfi_InternetPerformanceInResidenceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InterventionClassDescriptor_TR_DeleteTracking] ON [edfi].[InterventionClassDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InterventionClassDescriptor](InterventionClassDescriptorId, Id, ChangeVersion)
    SELECT  d.InterventionClassDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InterventionClassDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InterventionClassDescriptor] ENABLE TRIGGER [edfi_InterventionClassDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InterventionEffectivenessRatingDescriptor_TR_DeleteTracking] ON [edfi].[InterventionEffectivenessRatingDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InterventionEffectivenessRatingDescriptor](InterventionEffectivenessRatingDescriptorId, Id, ChangeVersion)
    SELECT  d.InterventionEffectivenessRatingDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.InterventionEffectivenessRatingDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[InterventionEffectivenessRatingDescriptor] ENABLE TRIGGER [edfi_InterventionEffectivenessRatingDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InterventionPrescription_TR_DeleteTracking] ON [edfi].[InterventionPrescription] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InterventionPrescription](EducationOrganizationId, InterventionPrescriptionIdentificationCode, Id, ChangeVersion)
    SELECT  EducationOrganizationId, InterventionPrescriptionIdentificationCode, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[InterventionPrescription] ENABLE TRIGGER [edfi_InterventionPrescription_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_InterventionStudy_TR_DeleteTracking] ON [edfi].[InterventionStudy] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[InterventionStudy](EducationOrganizationId, InterventionStudyIdentificationCode, Id, ChangeVersion)
    SELECT  EducationOrganizationId, InterventionStudyIdentificationCode, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[InterventionStudy] ENABLE TRIGGER [edfi_InterventionStudy_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Intervention_TR_DeleteTracking] ON [edfi].[Intervention] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Intervention](EducationOrganizationId, InterventionIdentificationCode, Id, ChangeVersion)
    SELECT  EducationOrganizationId, InterventionIdentificationCode, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Intervention] ENABLE TRIGGER [edfi_Intervention_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LanguageDescriptor_TR_DeleteTracking] ON [edfi].[LanguageDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LanguageDescriptor](LanguageDescriptorId, Id, ChangeVersion)
    SELECT  d.LanguageDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LanguageDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LanguageDescriptor] ENABLE TRIGGER [edfi_LanguageDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LanguageInstructionProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[LanguageInstructionProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LanguageInstructionProgramServiceDescriptor](LanguageInstructionProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.LanguageInstructionProgramServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LanguageInstructionProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LanguageInstructionProgramServiceDescriptor] ENABLE TRIGGER [edfi_LanguageInstructionProgramServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LanguageUseDescriptor_TR_DeleteTracking] ON [edfi].[LanguageUseDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LanguageUseDescriptor](LanguageUseDescriptorId, Id, ChangeVersion)
    SELECT  d.LanguageUseDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LanguageUseDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LanguageUseDescriptor] ENABLE TRIGGER [edfi_LanguageUseDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LearningObjective_TR_DeleteTracking] ON [edfi].[LearningObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LearningObjective](LearningObjectiveId, Namespace, Id, ChangeVersion)
    SELECT  LearningObjectiveId, Namespace, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LearningObjective] ENABLE TRIGGER [edfi_LearningObjective_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LearningStandardCategoryDescriptor_TR_DeleteTracking] ON [edfi].[LearningStandardCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LearningStandardCategoryDescriptor](LearningStandardCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.LearningStandardCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LearningStandardCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LearningStandardCategoryDescriptor] ENABLE TRIGGER [edfi_LearningStandardCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LearningStandardEquivalenceAssociation_TR_DeleteTracking] ON [edfi].[LearningStandardEquivalenceAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LearningStandardEquivalenceAssociation](Namespace, SourceLearningStandardId, TargetLearningStandardId, Id, ChangeVersion)
    SELECT  Namespace, SourceLearningStandardId, TargetLearningStandardId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceAssociation] ENABLE TRIGGER [edfi_LearningStandardEquivalenceAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LearningStandardEquivalenceStrengthDescriptor_TR_DeleteTracking] ON [edfi].[LearningStandardEquivalenceStrengthDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LearningStandardEquivalenceStrengthDescriptor](LearningStandardEquivalenceStrengthDescriptorId, Id, ChangeVersion)
    SELECT  d.LearningStandardEquivalenceStrengthDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LearningStandardEquivalenceStrengthDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LearningStandardEquivalenceStrengthDescriptor] ENABLE TRIGGER [edfi_LearningStandardEquivalenceStrengthDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LearningStandardScopeDescriptor_TR_DeleteTracking] ON [edfi].[LearningStandardScopeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LearningStandardScopeDescriptor](LearningStandardScopeDescriptorId, Id, ChangeVersion)
    SELECT  d.LearningStandardScopeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LearningStandardScopeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LearningStandardScopeDescriptor] ENABLE TRIGGER [edfi_LearningStandardScopeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LearningStandard_TR_DeleteTracking] ON [edfi].[LearningStandard] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LearningStandard](LearningStandardId, Id, ChangeVersion)
    SELECT  LearningStandardId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[LearningStandard] ENABLE TRIGGER [edfi_LearningStandard_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LevelOfEducationDescriptor_TR_DeleteTracking] ON [edfi].[LevelOfEducationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LevelOfEducationDescriptor](LevelOfEducationDescriptorId, Id, ChangeVersion)
    SELECT  d.LevelOfEducationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LevelOfEducationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LevelOfEducationDescriptor] ENABLE TRIGGER [edfi_LevelOfEducationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LicenseStatusDescriptor_TR_DeleteTracking] ON [edfi].[LicenseStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LicenseStatusDescriptor](LicenseStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.LicenseStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LicenseStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LicenseStatusDescriptor] ENABLE TRIGGER [edfi_LicenseStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LicenseTypeDescriptor_TR_DeleteTracking] ON [edfi].[LicenseTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LicenseTypeDescriptor](LicenseTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.LicenseTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LicenseTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LicenseTypeDescriptor] ENABLE TRIGGER [edfi_LicenseTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LimitedEnglishProficiencyDescriptor_TR_DeleteTracking] ON [edfi].[LimitedEnglishProficiencyDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LimitedEnglishProficiencyDescriptor](LimitedEnglishProficiencyDescriptorId, Id, ChangeVersion)
    SELECT  d.LimitedEnglishProficiencyDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LimitedEnglishProficiencyDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LimitedEnglishProficiencyDescriptor] ENABLE TRIGGER [edfi_LimitedEnglishProficiencyDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LocalEducationAgencyCategoryDescriptor_TR_DeleteTracking] ON [edfi].[LocalEducationAgencyCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LocalEducationAgencyCategoryDescriptor](LocalEducationAgencyCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.LocalEducationAgencyCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LocalEducationAgencyCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LocalEducationAgencyCategoryDescriptor] ENABLE TRIGGER [edfi_LocalEducationAgencyCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LocalEducationAgency_TR_DeleteTracking] ON [edfi].[LocalEducationAgency] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LocalEducationAgency](LocalEducationAgencyId, Id, ChangeVersion)
    SELECT  d.LocalEducationAgencyId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.LocalEducationAgencyId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[LocalEducationAgency] ENABLE TRIGGER [edfi_LocalEducationAgency_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_LocaleDescriptor_TR_DeleteTracking] ON [edfi].[LocaleDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[LocaleDescriptor](LocaleDescriptorId, Id, ChangeVersion)
    SELECT  d.LocaleDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.LocaleDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[LocaleDescriptor] ENABLE TRIGGER [edfi_LocaleDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Location_TR_DeleteTracking] ON [edfi].[Location] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Location](ClassroomIdentificationCode, SchoolId, Id, ChangeVersion)
    SELECT  ClassroomIdentificationCode, SchoolId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Location] ENABLE TRIGGER [edfi_Location_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_MagnetSpecialProgramEmphasisSchoolDescriptor_TR_DeleteTracking] ON [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor](MagnetSpecialProgramEmphasisSchoolDescriptorId, Id, ChangeVersion)
    SELECT  d.MagnetSpecialProgramEmphasisSchoolDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MagnetSpecialProgramEmphasisSchoolDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] ENABLE TRIGGER [edfi_MagnetSpecialProgramEmphasisSchoolDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_MediumOfInstructionDescriptor_TR_DeleteTracking] ON [edfi].[MediumOfInstructionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[MediumOfInstructionDescriptor](MediumOfInstructionDescriptorId, Id, ChangeVersion)
    SELECT  d.MediumOfInstructionDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MediumOfInstructionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MediumOfInstructionDescriptor] ENABLE TRIGGER [edfi_MediumOfInstructionDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_MethodCreditEarnedDescriptor_TR_DeleteTracking] ON [edfi].[MethodCreditEarnedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[MethodCreditEarnedDescriptor](MethodCreditEarnedDescriptorId, Id, ChangeVersion)
    SELECT  d.MethodCreditEarnedDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MethodCreditEarnedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MethodCreditEarnedDescriptor] ENABLE TRIGGER [edfi_MethodCreditEarnedDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_MigrantEducationProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[MigrantEducationProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[MigrantEducationProgramServiceDescriptor](MigrantEducationProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.MigrantEducationProgramServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MigrantEducationProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MigrantEducationProgramServiceDescriptor] ENABLE TRIGGER [edfi_MigrantEducationProgramServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_MonitoredDescriptor_TR_DeleteTracking] ON [edfi].[MonitoredDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[MonitoredDescriptor](MonitoredDescriptorId, Id, ChangeVersion)
    SELECT  d.MonitoredDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.MonitoredDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[MonitoredDescriptor] ENABLE TRIGGER [edfi_MonitoredDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_NeglectedOrDelinquentProgramDescriptor_TR_DeleteTracking] ON [edfi].[NeglectedOrDelinquentProgramDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[NeglectedOrDelinquentProgramDescriptor](NeglectedOrDelinquentProgramDescriptorId, Id, ChangeVersion)
    SELECT  d.NeglectedOrDelinquentProgramDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.NeglectedOrDelinquentProgramDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[NeglectedOrDelinquentProgramDescriptor] ENABLE TRIGGER [edfi_NeglectedOrDelinquentProgramDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_NeglectedOrDelinquentProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[NeglectedOrDelinquentProgramServiceDescriptor](NeglectedOrDelinquentProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.NeglectedOrDelinquentProgramServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.NeglectedOrDelinquentProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] ENABLE TRIGGER [edfi_NeglectedOrDelinquentProgramServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_NetworkPurposeDescriptor_TR_DeleteTracking] ON [edfi].[NetworkPurposeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[NetworkPurposeDescriptor](NetworkPurposeDescriptorId, Id, ChangeVersion)
    SELECT  d.NetworkPurposeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.NetworkPurposeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[NetworkPurposeDescriptor] ENABLE TRIGGER [edfi_NetworkPurposeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ObjectiveAssessment_TR_DeleteTracking] ON [edfi].[ObjectiveAssessment] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ObjectiveAssessment](AssessmentIdentifier, IdentificationCode, Namespace, Id, ChangeVersion)
    SELECT  AssessmentIdentifier, IdentificationCode, Namespace, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ObjectiveAssessment] ENABLE TRIGGER [edfi_ObjectiveAssessment_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_OldEthnicityDescriptor_TR_DeleteTracking] ON [edfi].[OldEthnicityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[OldEthnicityDescriptor](OldEthnicityDescriptorId, Id, ChangeVersion)
    SELECT  d.OldEthnicityDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OldEthnicityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[OldEthnicityDescriptor] ENABLE TRIGGER [edfi_OldEthnicityDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_OpenStaffPosition_TR_DeleteTracking] ON [edfi].[OpenStaffPosition] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[OpenStaffPosition](EducationOrganizationId, RequisitionNumber, Id, ChangeVersion)
    SELECT  EducationOrganizationId, RequisitionNumber, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[OpenStaffPosition] ENABLE TRIGGER [edfi_OpenStaffPosition_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_OperationalStatusDescriptor_TR_DeleteTracking] ON [edfi].[OperationalStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[OperationalStatusDescriptor](OperationalStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.OperationalStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OperationalStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[OperationalStatusDescriptor] ENABLE TRIGGER [edfi_OperationalStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_OrganizationDepartment_TR_DeleteTracking] ON [edfi].[OrganizationDepartment] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[OrganizationDepartment](OrganizationDepartmentId, Id, ChangeVersion)
    SELECT  d.OrganizationDepartmentId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.OrganizationDepartmentId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[OrganizationDepartment] ENABLE TRIGGER [edfi_OrganizationDepartment_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_OtherNameTypeDescriptor_TR_DeleteTracking] ON [edfi].[OtherNameTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[OtherNameTypeDescriptor](OtherNameTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.OtherNameTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.OtherNameTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[OtherNameTypeDescriptor] ENABLE TRIGGER [edfi_OtherNameTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Parent_TR_DeleteTracking] ON [edfi].[Parent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Parent](ParentUSI, Id, ChangeVersion)
    SELECT  ParentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Parent] ENABLE TRIGGER [edfi_Parent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ParticipationDescriptor_TR_DeleteTracking] ON [edfi].[ParticipationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ParticipationDescriptor](ParticipationDescriptorId, Id, ChangeVersion)
    SELECT  d.ParticipationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ParticipationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ParticipationDescriptor] ENABLE TRIGGER [edfi_ParticipationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ParticipationStatusDescriptor_TR_DeleteTracking] ON [edfi].[ParticipationStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ParticipationStatusDescriptor](ParticipationStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.ParticipationStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ParticipationStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ParticipationStatusDescriptor] ENABLE TRIGGER [edfi_ParticipationStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Payroll_TR_DeleteTracking] ON [edfi].[Payroll] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Payroll](AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, StaffUSI, Id, ChangeVersion)
    SELECT  AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Payroll] ENABLE TRIGGER [edfi_Payroll_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PerformanceBaseConversionDescriptor_TR_DeleteTracking] ON [edfi].[PerformanceBaseConversionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PerformanceBaseConversionDescriptor](PerformanceBaseConversionDescriptorId, Id, ChangeVersion)
    SELECT  d.PerformanceBaseConversionDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PerformanceBaseConversionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PerformanceBaseConversionDescriptor] ENABLE TRIGGER [edfi_PerformanceBaseConversionDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PerformanceLevelDescriptor_TR_DeleteTracking] ON [edfi].[PerformanceLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PerformanceLevelDescriptor](PerformanceLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.PerformanceLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PerformanceLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PerformanceLevelDescriptor] ENABLE TRIGGER [edfi_PerformanceLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Person_TR_DeleteTracking] ON [edfi].[Person] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Person](PersonId, SourceSystemDescriptorId, Id, ChangeVersion)
    SELECT  PersonId, SourceSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Person] ENABLE TRIGGER [edfi_Person_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PersonalInformationVerificationDescriptor_TR_DeleteTracking] ON [edfi].[PersonalInformationVerificationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PersonalInformationVerificationDescriptor](PersonalInformationVerificationDescriptorId, Id, ChangeVersion)
    SELECT  d.PersonalInformationVerificationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PersonalInformationVerificationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PersonalInformationVerificationDescriptor] ENABLE TRIGGER [edfi_PersonalInformationVerificationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PlatformTypeDescriptor_TR_DeleteTracking] ON [edfi].[PlatformTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PlatformTypeDescriptor](PlatformTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.PlatformTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PlatformTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PlatformTypeDescriptor] ENABLE TRIGGER [edfi_PlatformTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PopulationServedDescriptor_TR_DeleteTracking] ON [edfi].[PopulationServedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PopulationServedDescriptor](PopulationServedDescriptorId, Id, ChangeVersion)
    SELECT  d.PopulationServedDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PopulationServedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PopulationServedDescriptor] ENABLE TRIGGER [edfi_PopulationServedDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PostSecondaryEventCategoryDescriptor_TR_DeleteTracking] ON [edfi].[PostSecondaryEventCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PostSecondaryEventCategoryDescriptor](PostSecondaryEventCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.PostSecondaryEventCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PostSecondaryEventCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PostSecondaryEventCategoryDescriptor] ENABLE TRIGGER [edfi_PostSecondaryEventCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PostSecondaryEvent_TR_DeleteTracking] ON [edfi].[PostSecondaryEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PostSecondaryEvent](EventDate, PostSecondaryEventCategoryDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  EventDate, PostSecondaryEventCategoryDescriptorId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[PostSecondaryEvent] ENABLE TRIGGER [edfi_PostSecondaryEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PostSecondaryInstitutionLevelDescriptor_TR_DeleteTracking] ON [edfi].[PostSecondaryInstitutionLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PostSecondaryInstitutionLevelDescriptor](PostSecondaryInstitutionLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.PostSecondaryInstitutionLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PostSecondaryInstitutionLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PostSecondaryInstitutionLevelDescriptor] ENABLE TRIGGER [edfi_PostSecondaryInstitutionLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PostSecondaryInstitution_TR_DeleteTracking] ON [edfi].[PostSecondaryInstitution] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PostSecondaryInstitution](PostSecondaryInstitutionId, Id, ChangeVersion)
    SELECT  d.PostSecondaryInstitutionId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.PostSecondaryInstitutionId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[PostSecondaryInstitution] ENABLE TRIGGER [edfi_PostSecondaryInstitution_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PostingResultDescriptor_TR_DeleteTracking] ON [edfi].[PostingResultDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PostingResultDescriptor](PostingResultDescriptorId, Id, ChangeVersion)
    SELECT  d.PostingResultDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PostingResultDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PostingResultDescriptor] ENABLE TRIGGER [edfi_PostingResultDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PrimaryLearningDeviceAccessDescriptor_TR_DeleteTracking] ON [edfi].[PrimaryLearningDeviceAccessDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PrimaryLearningDeviceAccessDescriptor](PrimaryLearningDeviceAccessDescriptorId, Id, ChangeVersion)
    SELECT  d.PrimaryLearningDeviceAccessDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PrimaryLearningDeviceAccessDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceAccessDescriptor] ENABLE TRIGGER [edfi_PrimaryLearningDeviceAccessDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PrimaryLearningDeviceAwayFromSchoolDescriptor_TR_DeleteTracking] ON [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor](PrimaryLearningDeviceAwayFromSchoolDescriptorId, Id, ChangeVersion)
    SELECT  d.PrimaryLearningDeviceAwayFromSchoolDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PrimaryLearningDeviceAwayFromSchoolDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] ENABLE TRIGGER [edfi_PrimaryLearningDeviceAwayFromSchoolDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PrimaryLearningDeviceProviderDescriptor_TR_DeleteTracking] ON [edfi].[PrimaryLearningDeviceProviderDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PrimaryLearningDeviceProviderDescriptor](PrimaryLearningDeviceProviderDescriptorId, Id, ChangeVersion)
    SELECT  d.PrimaryLearningDeviceProviderDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PrimaryLearningDeviceProviderDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PrimaryLearningDeviceProviderDescriptor] ENABLE TRIGGER [edfi_PrimaryLearningDeviceProviderDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProficiencyDescriptor_TR_DeleteTracking] ON [edfi].[ProficiencyDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProficiencyDescriptor](ProficiencyDescriptorId, Id, ChangeVersion)
    SELECT  d.ProficiencyDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProficiencyDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProficiencyDescriptor] ENABLE TRIGGER [edfi_ProficiencyDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProgramAssignmentDescriptor_TR_DeleteTracking] ON [edfi].[ProgramAssignmentDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProgramAssignmentDescriptor](ProgramAssignmentDescriptorId, Id, ChangeVersion)
    SELECT  d.ProgramAssignmentDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramAssignmentDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgramAssignmentDescriptor] ENABLE TRIGGER [edfi_ProgramAssignmentDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProgramCharacteristicDescriptor_TR_DeleteTracking] ON [edfi].[ProgramCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProgramCharacteristicDescriptor](ProgramCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT  d.ProgramCharacteristicDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgramCharacteristicDescriptor] ENABLE TRIGGER [edfi_ProgramCharacteristicDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProgramSponsorDescriptor_TR_DeleteTracking] ON [edfi].[ProgramSponsorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProgramSponsorDescriptor](ProgramSponsorDescriptorId, Id, ChangeVersion)
    SELECT  d.ProgramSponsorDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramSponsorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgramSponsorDescriptor] ENABLE TRIGGER [edfi_ProgramSponsorDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProgramTypeDescriptor_TR_DeleteTracking] ON [edfi].[ProgramTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProgramTypeDescriptor](ProgramTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.ProgramTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgramTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgramTypeDescriptor] ENABLE TRIGGER [edfi_ProgramTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Program_TR_DeleteTracking] ON [edfi].[Program] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Program](EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Program] ENABLE TRIGGER [edfi_Program_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProgressDescriptor_TR_DeleteTracking] ON [edfi].[ProgressDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProgressDescriptor](ProgressDescriptorId, Id, ChangeVersion)
    SELECT  d.ProgressDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgressDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgressDescriptor] ENABLE TRIGGER [edfi_ProgressDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProgressLevelDescriptor_TR_DeleteTracking] ON [edfi].[ProgressLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProgressLevelDescriptor](ProgressLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.ProgressLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProgressLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProgressLevelDescriptor] ENABLE TRIGGER [edfi_ProgressLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProviderCategoryDescriptor_TR_DeleteTracking] ON [edfi].[ProviderCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProviderCategoryDescriptor](ProviderCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.ProviderCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProviderCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProviderCategoryDescriptor] ENABLE TRIGGER [edfi_ProviderCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProviderProfitabilityDescriptor_TR_DeleteTracking] ON [edfi].[ProviderProfitabilityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProviderProfitabilityDescriptor](ProviderProfitabilityDescriptorId, Id, ChangeVersion)
    SELECT  d.ProviderProfitabilityDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProviderProfitabilityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProviderProfitabilityDescriptor] ENABLE TRIGGER [edfi_ProviderProfitabilityDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ProviderStatusDescriptor_TR_DeleteTracking] ON [edfi].[ProviderStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ProviderStatusDescriptor](ProviderStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.ProviderStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ProviderStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ProviderStatusDescriptor] ENABLE TRIGGER [edfi_ProviderStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_PublicationStatusDescriptor_TR_DeleteTracking] ON [edfi].[PublicationStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[PublicationStatusDescriptor](PublicationStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.PublicationStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.PublicationStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[PublicationStatusDescriptor] ENABLE TRIGGER [edfi_PublicationStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_QuestionFormDescriptor_TR_DeleteTracking] ON [edfi].[QuestionFormDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[QuestionFormDescriptor](QuestionFormDescriptorId, Id, ChangeVersion)
    SELECT  d.QuestionFormDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.QuestionFormDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[QuestionFormDescriptor] ENABLE TRIGGER [edfi_QuestionFormDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_RaceDescriptor_TR_DeleteTracking] ON [edfi].[RaceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[RaceDescriptor](RaceDescriptorId, Id, ChangeVersion)
    SELECT  d.RaceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RaceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RaceDescriptor] ENABLE TRIGGER [edfi_RaceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ReasonExitedDescriptor_TR_DeleteTracking] ON [edfi].[ReasonExitedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ReasonExitedDescriptor](ReasonExitedDescriptorId, Id, ChangeVersion)
    SELECT  d.ReasonExitedDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ReasonExitedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ReasonExitedDescriptor] ENABLE TRIGGER [edfi_ReasonExitedDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ReasonNotTestedDescriptor_TR_DeleteTracking] ON [edfi].[ReasonNotTestedDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ReasonNotTestedDescriptor](ReasonNotTestedDescriptorId, Id, ChangeVersion)
    SELECT  d.ReasonNotTestedDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ReasonNotTestedDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ReasonNotTestedDescriptor] ENABLE TRIGGER [edfi_ReasonNotTestedDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_RecognitionTypeDescriptor_TR_DeleteTracking] ON [edfi].[RecognitionTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[RecognitionTypeDescriptor](RecognitionTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.RecognitionTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RecognitionTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RecognitionTypeDescriptor] ENABLE TRIGGER [edfi_RecognitionTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_RelationDescriptor_TR_DeleteTracking] ON [edfi].[RelationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[RelationDescriptor](RelationDescriptorId, Id, ChangeVersion)
    SELECT  d.RelationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RelationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RelationDescriptor] ENABLE TRIGGER [edfi_RelationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_RepeatIdentifierDescriptor_TR_DeleteTracking] ON [edfi].[RepeatIdentifierDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[RepeatIdentifierDescriptor](RepeatIdentifierDescriptorId, Id, ChangeVersion)
    SELECT  d.RepeatIdentifierDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RepeatIdentifierDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RepeatIdentifierDescriptor] ENABLE TRIGGER [edfi_RepeatIdentifierDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ReportCard_TR_DeleteTracking] ON [edfi].[ReportCard] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ReportCard](EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI, Id, ChangeVersion)
    SELECT  EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[ReportCard] ENABLE TRIGGER [edfi_ReportCard_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ReporterDescriptionDescriptor_TR_DeleteTracking] ON [edfi].[ReporterDescriptionDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ReporterDescriptionDescriptor](ReporterDescriptionDescriptorId, Id, ChangeVersion)
    SELECT  d.ReporterDescriptionDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ReporterDescriptionDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ReporterDescriptionDescriptor] ENABLE TRIGGER [edfi_ReporterDescriptionDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ResidencyStatusDescriptor_TR_DeleteTracking] ON [edfi].[ResidencyStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ResidencyStatusDescriptor](ResidencyStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.ResidencyStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ResidencyStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ResidencyStatusDescriptor] ENABLE TRIGGER [edfi_ResidencyStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ResponseIndicatorDescriptor_TR_DeleteTracking] ON [edfi].[ResponseIndicatorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ResponseIndicatorDescriptor](ResponseIndicatorDescriptorId, Id, ChangeVersion)
    SELECT  d.ResponseIndicatorDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ResponseIndicatorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ResponseIndicatorDescriptor] ENABLE TRIGGER [edfi_ResponseIndicatorDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ResponsibilityDescriptor_TR_DeleteTracking] ON [edfi].[ResponsibilityDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ResponsibilityDescriptor](ResponsibilityDescriptorId, Id, ChangeVersion)
    SELECT  d.ResponsibilityDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ResponsibilityDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ResponsibilityDescriptor] ENABLE TRIGGER [edfi_ResponsibilityDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_RestraintEventReasonDescriptor_TR_DeleteTracking] ON [edfi].[RestraintEventReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[RestraintEventReasonDescriptor](RestraintEventReasonDescriptorId, Id, ChangeVersion)
    SELECT  d.RestraintEventReasonDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RestraintEventReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RestraintEventReasonDescriptor] ENABLE TRIGGER [edfi_RestraintEventReasonDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_RestraintEvent_TR_DeleteTracking] ON [edfi].[RestraintEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[RestraintEvent](RestraintEventIdentifier, SchoolId, StudentUSI, Id, ChangeVersion)
    SELECT  RestraintEventIdentifier, SchoolId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[RestraintEvent] ENABLE TRIGGER [edfi_RestraintEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ResultDatatypeTypeDescriptor_TR_DeleteTracking] ON [edfi].[ResultDatatypeTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ResultDatatypeTypeDescriptor](ResultDatatypeTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.ResultDatatypeTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ResultDatatypeTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ResultDatatypeTypeDescriptor] ENABLE TRIGGER [edfi_ResultDatatypeTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_RetestIndicatorDescriptor_TR_DeleteTracking] ON [edfi].[RetestIndicatorDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[RetestIndicatorDescriptor](RetestIndicatorDescriptorId, Id, ChangeVersion)
    SELECT  d.RetestIndicatorDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.RetestIndicatorDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[RetestIndicatorDescriptor] ENABLE TRIGGER [edfi_RetestIndicatorDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SchoolCategoryDescriptor_TR_DeleteTracking] ON [edfi].[SchoolCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SchoolCategoryDescriptor](SchoolCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.SchoolCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolCategoryDescriptor] ENABLE TRIGGER [edfi_SchoolCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SchoolChoiceImplementStatusDescriptor_TR_DeleteTracking] ON [edfi].[SchoolChoiceImplementStatusDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SchoolChoiceImplementStatusDescriptor](SchoolChoiceImplementStatusDescriptorId, Id, ChangeVersion)
    SELECT  d.SchoolChoiceImplementStatusDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolChoiceImplementStatusDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolChoiceImplementStatusDescriptor] ENABLE TRIGGER [edfi_SchoolChoiceImplementStatusDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SchoolFoodServiceProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[SchoolFoodServiceProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SchoolFoodServiceProgramServiceDescriptor](SchoolFoodServiceProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.SchoolFoodServiceProgramServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolFoodServiceProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolFoodServiceProgramServiceDescriptor] ENABLE TRIGGER [edfi_SchoolFoodServiceProgramServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SchoolTypeDescriptor_TR_DeleteTracking] ON [edfi].[SchoolTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SchoolTypeDescriptor](SchoolTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.SchoolTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SchoolTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SchoolTypeDescriptor] ENABLE TRIGGER [edfi_SchoolTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_School_TR_DeleteTracking] ON [edfi].[School] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[School](SchoolId, Id, ChangeVersion)
    SELECT  d.SchoolId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.SchoolId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[School] ENABLE TRIGGER [edfi_School_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SectionAttendanceTakenEvent_TR_DeleteTracking] ON [edfi].[SectionAttendanceTakenEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SectionAttendanceTakenEvent](CalendarCode, Date, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, ChangeVersion)
    SELECT  CalendarCode, Date, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ENABLE TRIGGER [edfi_SectionAttendanceTakenEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SectionCharacteristicDescriptor_TR_DeleteTracking] ON [edfi].[SectionCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SectionCharacteristicDescriptor](SectionCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT  d.SectionCharacteristicDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SectionCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SectionCharacteristicDescriptor] ENABLE TRIGGER [edfi_SectionCharacteristicDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Section_TR_DeleteTracking] ON [edfi].[Section] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Section](LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, ChangeVersion)
    SELECT  LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Section] ENABLE TRIGGER [edfi_Section_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SeparationDescriptor_TR_DeleteTracking] ON [edfi].[SeparationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SeparationDescriptor](SeparationDescriptorId, Id, ChangeVersion)
    SELECT  d.SeparationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SeparationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SeparationDescriptor] ENABLE TRIGGER [edfi_SeparationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SeparationReasonDescriptor_TR_DeleteTracking] ON [edfi].[SeparationReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SeparationReasonDescriptor](SeparationReasonDescriptorId, Id, ChangeVersion)
    SELECT  d.SeparationReasonDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SeparationReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SeparationReasonDescriptor] ENABLE TRIGGER [edfi_SeparationReasonDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_ServiceDescriptor_TR_DeleteTracking] ON [edfi].[ServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[ServiceDescriptor](ServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.ServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.ServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[ServiceDescriptor] ENABLE TRIGGER [edfi_ServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Session_TR_DeleteTracking] ON [edfi].[Session] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Session](SchoolId, SchoolYear, SessionName, Id, ChangeVersion)
    SELECT  SchoolId, SchoolYear, SessionName, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Session] ENABLE TRIGGER [edfi_Session_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SexDescriptor_TR_DeleteTracking] ON [edfi].[SexDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SexDescriptor](SexDescriptorId, Id, ChangeVersion)
    SELECT  d.SexDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SexDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SexDescriptor] ENABLE TRIGGER [edfi_SexDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SourceSystemDescriptor_TR_DeleteTracking] ON [edfi].[SourceSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SourceSystemDescriptor](SourceSystemDescriptorId, Id, ChangeVersion)
    SELECT  d.SourceSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SourceSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SourceSystemDescriptor] ENABLE TRIGGER [edfi_SourceSystemDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SpecialEducationProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[SpecialEducationProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SpecialEducationProgramServiceDescriptor](SpecialEducationProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.SpecialEducationProgramServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SpecialEducationProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SpecialEducationProgramServiceDescriptor] ENABLE TRIGGER [edfi_SpecialEducationProgramServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SpecialEducationSettingDescriptor_TR_DeleteTracking] ON [edfi].[SpecialEducationSettingDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SpecialEducationSettingDescriptor](SpecialEducationSettingDescriptorId, Id, ChangeVersion)
    SELECT  d.SpecialEducationSettingDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SpecialEducationSettingDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SpecialEducationSettingDescriptor] ENABLE TRIGGER [edfi_SpecialEducationSettingDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffAbsenceEvent_TR_DeleteTracking] ON [edfi].[StaffAbsenceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffAbsenceEvent](AbsenceEventCategoryDescriptorId, EventDate, StaffUSI, Id, ChangeVersion)
    SELECT  AbsenceEventCategoryDescriptorId, EventDate, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffAbsenceEvent] ENABLE TRIGGER [edfi_StaffAbsenceEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffClassificationDescriptor_TR_DeleteTracking] ON [edfi].[StaffClassificationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffClassificationDescriptor](StaffClassificationDescriptorId, Id, ChangeVersion)
    SELECT  d.StaffClassificationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StaffClassificationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StaffClassificationDescriptor] ENABLE TRIGGER [edfi_StaffClassificationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffCohortAssociation_TR_DeleteTracking] ON [edfi].[StaffCohortAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffCohortAssociation](BeginDate, CohortIdentifier, EducationOrganizationId, StaffUSI, Id, ChangeVersion)
    SELECT  BeginDate, CohortIdentifier, EducationOrganizationId, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffCohortAssociation] ENABLE TRIGGER [edfi_StaffCohortAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffDisciplineIncidentAssociation_TR_DeleteTracking] ON [edfi].[StaffDisciplineIncidentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffDisciplineIncidentAssociation](IncidentIdentifier, SchoolId, StaffUSI, Id, ChangeVersion)
    SELECT  IncidentIdentifier, SchoolId, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffDisciplineIncidentAssociation] ENABLE TRIGGER [edfi_StaffDisciplineIncidentAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationAssignmentAssociation_TR_DeleteTracking] ON [edfi].[StaffEducationOrganizationAssignmentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffEducationOrganizationAssignmentAssociation](BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI, Id, ChangeVersion)
    SELECT  BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ENABLE TRIGGER [edfi_StaffEducationOrganizationAssignmentAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationContactAssociation_TR_DeleteTracking] ON [edfi].[StaffEducationOrganizationContactAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffEducationOrganizationContactAssociation](ContactTitle, EducationOrganizationId, StaffUSI, Id, ChangeVersion)
    SELECT  ContactTitle, EducationOrganizationId, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffEducationOrganizationContactAssociation] ENABLE TRIGGER [edfi_StaffEducationOrganizationContactAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationEmploymentAssociation_TR_DeleteTracking] ON [edfi].[StaffEducationOrganizationEmploymentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffEducationOrganizationEmploymentAssociation](EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI, Id, ChangeVersion)
    SELECT  EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ENABLE TRIGGER [edfi_StaffEducationOrganizationEmploymentAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[StaffIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffIdentificationSystemDescriptor](StaffIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT  d.StaffIdentificationSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StaffIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StaffIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_StaffIdentificationSystemDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffLeaveEventCategoryDescriptor_TR_DeleteTracking] ON [edfi].[StaffLeaveEventCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffLeaveEventCategoryDescriptor](StaffLeaveEventCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.StaffLeaveEventCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StaffLeaveEventCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StaffLeaveEventCategoryDescriptor] ENABLE TRIGGER [edfi_StaffLeaveEventCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffLeave_TR_DeleteTracking] ON [edfi].[StaffLeave] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffLeave](BeginDate, StaffLeaveEventCategoryDescriptorId, StaffUSI, Id, ChangeVersion)
    SELECT  BeginDate, StaffLeaveEventCategoryDescriptorId, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffLeave] ENABLE TRIGGER [edfi_StaffLeave_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffProgramAssociation_TR_DeleteTracking] ON [edfi].[StaffProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffProgramAssociation](BeginDate, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI, Id, ChangeVersion)
    SELECT  BeginDate, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffProgramAssociation] ENABLE TRIGGER [edfi_StaffProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffSchoolAssociation_TR_DeleteTracking] ON [edfi].[StaffSchoolAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffSchoolAssociation](ProgramAssignmentDescriptorId, SchoolId, StaffUSI, Id, ChangeVersion)
    SELECT  ProgramAssignmentDescriptorId, SchoolId, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffSchoolAssociation] ENABLE TRIGGER [edfi_StaffSchoolAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StaffSectionAssociation_TR_DeleteTracking] ON [edfi].[StaffSectionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StaffSectionAssociation](LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StaffUSI, Id, ChangeVersion)
    SELECT  LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StaffSectionAssociation] ENABLE TRIGGER [edfi_StaffSectionAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Staff_TR_DeleteTracking] ON [edfi].[Staff] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Staff](StaffUSI, Id, ChangeVersion)
    SELECT  StaffUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Staff] ENABLE TRIGGER [edfi_Staff_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StateAbbreviationDescriptor_TR_DeleteTracking] ON [edfi].[StateAbbreviationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StateAbbreviationDescriptor](StateAbbreviationDescriptorId, Id, ChangeVersion)
    SELECT  d.StateAbbreviationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StateAbbreviationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StateAbbreviationDescriptor] ENABLE TRIGGER [edfi_StateAbbreviationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StateEducationAgency_TR_DeleteTracking] ON [edfi].[StateEducationAgency] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StateEducationAgency](StateEducationAgencyId, Id, ChangeVersion)
    SELECT  d.StateEducationAgencyId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.EducationOrganization b ON d.StateEducationAgencyId = b.EducationOrganizationId
END
GO

ALTER TABLE [edfi].[StateEducationAgency] ENABLE TRIGGER [edfi_StateEducationAgency_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentAcademicRecord_TR_DeleteTracking] ON [edfi].[StudentAcademicRecord] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentAcademicRecord](EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, Id, ChangeVersion)
    SELECT  EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentAcademicRecord] ENABLE TRIGGER [edfi_StudentAcademicRecord_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentAssessment_TR_DeleteTracking] ON [edfi].[StudentAssessment] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentAssessment](AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, Id, ChangeVersion)
    SELECT  AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentAssessment] ENABLE TRIGGER [edfi_StudentAssessment_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentCTEProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentCTEProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentCTEProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentCTEProgramAssociation] ENABLE TRIGGER [edfi_StudentCTEProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentCharacteristicDescriptor_TR_DeleteTracking] ON [edfi].[StudentCharacteristicDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentCharacteristicDescriptor](StudentCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT  d.StudentCharacteristicDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StudentCharacteristicDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StudentCharacteristicDescriptor] ENABLE TRIGGER [edfi_StudentCharacteristicDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentCohortAssociation_TR_DeleteTracking] ON [edfi].[StudentCohortAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentCohortAssociation](BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI, Id, ChangeVersion)
    SELECT  BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentCohortAssociation] ENABLE TRIGGER [edfi_StudentCohortAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentCompetencyObjective_TR_DeleteTracking] ON [edfi].[StudentCompetencyObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentCompetencyObjective](GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentCompetencyObjective] ENABLE TRIGGER [edfi_StudentCompetencyObjective_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentAssociation_TR_DeleteTracking] ON [edfi].[StudentDisciplineIncidentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentDisciplineIncidentAssociation](IncidentIdentifier, SchoolId, StudentUSI, Id, ChangeVersion)
    SELECT  IncidentIdentifier, SchoolId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ENABLE TRIGGER [edfi_StudentDisciplineIncidentAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentBehaviorAssociation_TR_DeleteTracking] ON [edfi].[StudentDisciplineIncidentBehaviorAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentDisciplineIncidentBehaviorAssociation](BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI, Id, ChangeVersion)
    SELECT  BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentBehaviorAssociation] ENABLE TRIGGER [edfi_StudentDisciplineIncidentBehaviorAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_DeleteTracking] ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentDisciplineIncidentNonOffenderAssociation](IncidentIdentifier, SchoolId, StudentUSI, Id, ChangeVersion)
    SELECT  IncidentIdentifier, SchoolId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ENABLE TRIGGER [edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentEducationOrganizationAssociation_TR_DeleteTracking] ON [edfi].[StudentEducationOrganizationAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentEducationOrganizationAssociation](EducationOrganizationId, StudentUSI, Id, ChangeVersion)
    SELECT  EducationOrganizationId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ENABLE TRIGGER [edfi_StudentEducationOrganizationAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentEducationOrganizationResponsibilityAssociation_TR_DeleteTracking] ON [edfi].[StudentEducationOrganizationResponsibilityAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentEducationOrganizationResponsibilityAssociation](BeginDate, EducationOrganizationId, ResponsibilityDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  BeginDate, EducationOrganizationId, ResponsibilityDescriptorId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentEducationOrganizationResponsibilityAssociation] ENABLE TRIGGER [edfi_StudentEducationOrganizationResponsibilityAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentGradebookEntry_TR_DeleteTracking] ON [edfi].[StudentGradebookEntry] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentGradebookEntry](BeginDate, DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    SELECT  BeginDate, DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentGradebookEntry] ENABLE TRIGGER [edfi_StudentGradebookEntry_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentHomelessProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentHomelessProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentHomelessProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentHomelessProgramAssociation] ENABLE TRIGGER [edfi_StudentHomelessProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentIdentificationSystemDescriptor_TR_DeleteTracking] ON [edfi].[StudentIdentificationSystemDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentIdentificationSystemDescriptor](StudentIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT  d.StudentIdentificationSystemDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StudentIdentificationSystemDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StudentIdentificationSystemDescriptor] ENABLE TRIGGER [edfi_StudentIdentificationSystemDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentInterventionAssociation_TR_DeleteTracking] ON [edfi].[StudentInterventionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentInterventionAssociation](EducationOrganizationId, InterventionIdentificationCode, StudentUSI, Id, ChangeVersion)
    SELECT  EducationOrganizationId, InterventionIdentificationCode, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentInterventionAssociation] ENABLE TRIGGER [edfi_StudentInterventionAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentInterventionAttendanceEvent_TR_DeleteTracking] ON [edfi].[StudentInterventionAttendanceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentInterventionAttendanceEvent](AttendanceEventCategoryDescriptorId, EducationOrganizationId, EventDate, InterventionIdentificationCode, StudentUSI, Id, ChangeVersion)
    SELECT  AttendanceEventCategoryDescriptorId, EducationOrganizationId, EventDate, InterventionIdentificationCode, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ENABLE TRIGGER [edfi_StudentInterventionAttendanceEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentLanguageInstructionProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentLanguageInstructionProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentLanguageInstructionProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentLanguageInstructionProgramAssociation] ENABLE TRIGGER [edfi_StudentLanguageInstructionProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentLearningObjective_TR_DeleteTracking] ON [edfi].[StudentLearningObjective] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentLearningObjective](GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI, Id, ChangeVersion)
    SELECT  GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentLearningObjective] ENABLE TRIGGER [edfi_StudentLearningObjective_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentMigrantEducationProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentMigrantEducationProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentMigrantEducationProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociation] ENABLE TRIGGER [edfi_StudentMigrantEducationProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentNeglectedOrDelinquentProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentNeglectedOrDelinquentProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentNeglectedOrDelinquentProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentNeglectedOrDelinquentProgramAssociation] ENABLE TRIGGER [edfi_StudentNeglectedOrDelinquentProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentParentAssociation_TR_DeleteTracking] ON [edfi].[StudentParentAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentParentAssociation](ParentUSI, StudentUSI, Id, ChangeVersion)
    SELECT  ParentUSI, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentParentAssociation] ENABLE TRIGGER [edfi_StudentParentAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentParticipationCodeDescriptor_TR_DeleteTracking] ON [edfi].[StudentParticipationCodeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentParticipationCodeDescriptor](StudentParticipationCodeDescriptorId, Id, ChangeVersion)
    SELECT  d.StudentParticipationCodeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.StudentParticipationCodeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[StudentParticipationCodeDescriptor] ENABLE TRIGGER [edfi_StudentParticipationCodeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentProgramAssociation] ENABLE TRIGGER [edfi_StudentProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentProgramAttendanceEvent_TR_DeleteTracking] ON [edfi].[StudentProgramAttendanceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentProgramAttendanceEvent](AttendanceEventCategoryDescriptorId, EducationOrganizationId, EventDate, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  AttendanceEventCategoryDescriptorId, EducationOrganizationId, EventDate, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ENABLE TRIGGER [edfi_StudentProgramAttendanceEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentSchoolAssociation_TR_DeleteTracking] ON [edfi].[StudentSchoolAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentSchoolAssociation](EntryDate, SchoolId, StudentUSI, Id, ChangeVersion)
    SELECT  EntryDate, SchoolId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentSchoolAssociation] ENABLE TRIGGER [edfi_StudentSchoolAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentSchoolAttendanceEvent_TR_DeleteTracking] ON [edfi].[StudentSchoolAttendanceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentSchoolAttendanceEvent](AttendanceEventCategoryDescriptorId, EventDate, SchoolId, SchoolYear, SessionName, StudentUSI, Id, ChangeVersion)
    SELECT  AttendanceEventCategoryDescriptorId, EventDate, SchoolId, SchoolYear, SessionName, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ENABLE TRIGGER [edfi_StudentSchoolAttendanceEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentSchoolFoodServiceProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentSchoolFoodServiceProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentSchoolFoodServiceProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentSchoolFoodServiceProgramAssociation] ENABLE TRIGGER [edfi_StudentSchoolFoodServiceProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentSectionAssociation_TR_DeleteTracking] ON [edfi].[StudentSectionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentSectionAssociation](BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    SELECT  BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentSectionAssociation] ENABLE TRIGGER [edfi_StudentSectionAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentSectionAttendanceEvent_TR_DeleteTracking] ON [edfi].[StudentSectionAttendanceEvent] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentSectionAttendanceEvent](AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    SELECT  AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ENABLE TRIGGER [edfi_StudentSectionAttendanceEvent_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentSpecialEducationProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentSpecialEducationProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentSpecialEducationProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociation] ENABLE TRIGGER [edfi_StudentSpecialEducationProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_StudentTitleIPartAProgramAssociation_TR_DeleteTracking] ON [edfi].[StudentTitleIPartAProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[StudentTitleIPartAProgramAssociation](BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT  d.BeginDate, d.EducationOrganizationId, d.ProgramEducationOrganizationId, d.ProgramName, d.ProgramTypeDescriptorId, d.StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.GeneralStudentProgramAssociation b ON d.BeginDate = b.BeginDate AND d.EducationOrganizationId = b.EducationOrganizationId AND d.ProgramEducationOrganizationId = b.ProgramEducationOrganizationId AND d.ProgramName = b.ProgramName AND d.ProgramTypeDescriptorId = b.ProgramTypeDescriptorId AND d.StudentUSI = b.StudentUSI
END
GO

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociation] ENABLE TRIGGER [edfi_StudentTitleIPartAProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Student_TR_DeleteTracking] ON [edfi].[Student] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Student](StudentUSI, Id, ChangeVersion)
    SELECT  StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Student] ENABLE TRIGGER [edfi_Student_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyCategoryDescriptor_TR_DeleteTracking] ON [edfi].[SurveyCategoryDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyCategoryDescriptor](SurveyCategoryDescriptorId, Id, ChangeVersion)
    SELECT  d.SurveyCategoryDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SurveyCategoryDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SurveyCategoryDescriptor] ENABLE TRIGGER [edfi_SurveyCategoryDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyCourseAssociation_TR_DeleteTracking] ON [edfi].[SurveyCourseAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyCourseAssociation](CourseCode, EducationOrganizationId, Namespace, SurveyIdentifier, Id, ChangeVersion)
    SELECT  CourseCode, EducationOrganizationId, Namespace, SurveyIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyCourseAssociation] ENABLE TRIGGER [edfi_SurveyCourseAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyLevelDescriptor_TR_DeleteTracking] ON [edfi].[SurveyLevelDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyLevelDescriptor](SurveyLevelDescriptorId, Id, ChangeVersion)
    SELECT  d.SurveyLevelDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.SurveyLevelDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[SurveyLevelDescriptor] ENABLE TRIGGER [edfi_SurveyLevelDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyProgramAssociation_TR_DeleteTracking] ON [edfi].[SurveyProgramAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyProgramAssociation](EducationOrganizationId, Namespace, ProgramName, ProgramTypeDescriptorId, SurveyIdentifier, Id, ChangeVersion)
    SELECT  EducationOrganizationId, Namespace, ProgramName, ProgramTypeDescriptorId, SurveyIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyProgramAssociation] ENABLE TRIGGER [edfi_SurveyProgramAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyQuestionResponse_TR_DeleteTracking] ON [edfi].[SurveyQuestionResponse] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyQuestionResponse](Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    SELECT  Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyQuestionResponse] ENABLE TRIGGER [edfi_SurveyQuestionResponse_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyQuestion_TR_DeleteTracking] ON [edfi].[SurveyQuestion] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyQuestion](Namespace, QuestionCode, SurveyIdentifier, Id, ChangeVersion)
    SELECT  Namespace, QuestionCode, SurveyIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyQuestion] ENABLE TRIGGER [edfi_SurveyQuestion_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_DeleteTracking] ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyResponseEducationOrganizationTargetAssociation](EducationOrganizationId, Namespace, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    SELECT  EducationOrganizationId, Namespace, SurveyIdentifier, SurveyResponseIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ENABLE TRIGGER [edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyResponseStaffTargetAssociation_TR_DeleteTracking] ON [edfi].[SurveyResponseStaffTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyResponseStaffTargetAssociation](Namespace, StaffUSI, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    SELECT  Namespace, StaffUSI, SurveyIdentifier, SurveyResponseIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyResponseStaffTargetAssociation] ENABLE TRIGGER [edfi_SurveyResponseStaffTargetAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveyResponse_TR_DeleteTracking] ON [edfi].[SurveyResponse] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveyResponse](Namespace, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    SELECT  Namespace, SurveyIdentifier, SurveyResponseIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveyResponse] ENABLE TRIGGER [edfi_SurveyResponse_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveySectionAssociation_TR_DeleteTracking] ON [edfi].[SurveySectionAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveySectionAssociation](LocalCourseCode, Namespace, SchoolId, SchoolYear, SectionIdentifier, SessionName, SurveyIdentifier, Id, ChangeVersion)
    SELECT  LocalCourseCode, Namespace, SchoolId, SchoolYear, SectionIdentifier, SessionName, SurveyIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySectionAssociation] ENABLE TRIGGER [edfi_SurveySectionAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_DeleteTracking] ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveySectionResponseEducationOrganizationTargetAssociation](EducationOrganizationId, Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, ChangeVersion)
    SELECT  EducationOrganizationId, Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ENABLE TRIGGER [edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveySectionResponseStaffTargetAssociation_TR_DeleteTracking] ON [edfi].[SurveySectionResponseStaffTargetAssociation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveySectionResponseStaffTargetAssociation](Namespace, StaffUSI, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, ChangeVersion)
    SELECT  Namespace, StaffUSI, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySectionResponseStaffTargetAssociation] ENABLE TRIGGER [edfi_SurveySectionResponseStaffTargetAssociation_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveySectionResponse_TR_DeleteTracking] ON [edfi].[SurveySectionResponse] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveySectionResponse](Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, ChangeVersion)
    SELECT  Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySectionResponse] ENABLE TRIGGER [edfi_SurveySectionResponse_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_SurveySection_TR_DeleteTracking] ON [edfi].[SurveySection] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[SurveySection](Namespace, SurveyIdentifier, SurveySectionTitle, Id, ChangeVersion)
    SELECT  Namespace, SurveyIdentifier, SurveySectionTitle, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[SurveySection] ENABLE TRIGGER [edfi_SurveySection_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_Survey_TR_DeleteTracking] ON [edfi].[Survey] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[Survey](Namespace, SurveyIdentifier, Id, ChangeVersion)
    SELECT  Namespace, SurveyIdentifier, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [edfi].[Survey] ENABLE TRIGGER [edfi_Survey_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TeachingCredentialBasisDescriptor_TR_DeleteTracking] ON [edfi].[TeachingCredentialBasisDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TeachingCredentialBasisDescriptor](TeachingCredentialBasisDescriptorId, Id, ChangeVersion)
    SELECT  d.TeachingCredentialBasisDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TeachingCredentialBasisDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TeachingCredentialBasisDescriptor] ENABLE TRIGGER [edfi_TeachingCredentialBasisDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TeachingCredentialDescriptor_TR_DeleteTracking] ON [edfi].[TeachingCredentialDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TeachingCredentialDescriptor](TeachingCredentialDescriptorId, Id, ChangeVersion)
    SELECT  d.TeachingCredentialDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TeachingCredentialDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TeachingCredentialDescriptor] ENABLE TRIGGER [edfi_TeachingCredentialDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TechnicalSkillsAssessmentDescriptor_TR_DeleteTracking] ON [edfi].[TechnicalSkillsAssessmentDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TechnicalSkillsAssessmentDescriptor](TechnicalSkillsAssessmentDescriptorId, Id, ChangeVersion)
    SELECT  d.TechnicalSkillsAssessmentDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TechnicalSkillsAssessmentDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TechnicalSkillsAssessmentDescriptor] ENABLE TRIGGER [edfi_TechnicalSkillsAssessmentDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TelephoneNumberTypeDescriptor_TR_DeleteTracking] ON [edfi].[TelephoneNumberTypeDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TelephoneNumberTypeDescriptor](TelephoneNumberTypeDescriptorId, Id, ChangeVersion)
    SELECT  d.TelephoneNumberTypeDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TelephoneNumberTypeDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TelephoneNumberTypeDescriptor] ENABLE TRIGGER [edfi_TelephoneNumberTypeDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TermDescriptor_TR_DeleteTracking] ON [edfi].[TermDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TermDescriptor](TermDescriptorId, Id, ChangeVersion)
    SELECT  d.TermDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TermDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TermDescriptor] ENABLE TRIGGER [edfi_TermDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TitleIPartAParticipantDescriptor_TR_DeleteTracking] ON [edfi].[TitleIPartAParticipantDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TitleIPartAParticipantDescriptor](TitleIPartAParticipantDescriptorId, Id, ChangeVersion)
    SELECT  d.TitleIPartAParticipantDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TitleIPartAParticipantDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TitleIPartAParticipantDescriptor] ENABLE TRIGGER [edfi_TitleIPartAParticipantDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TitleIPartAProgramServiceDescriptor_TR_DeleteTracking] ON [edfi].[TitleIPartAProgramServiceDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TitleIPartAProgramServiceDescriptor](TitleIPartAProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT  d.TitleIPartAProgramServiceDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TitleIPartAProgramServiceDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TitleIPartAProgramServiceDescriptor] ENABLE TRIGGER [edfi_TitleIPartAProgramServiceDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TitleIPartASchoolDesignationDescriptor_TR_DeleteTracking] ON [edfi].[TitleIPartASchoolDesignationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TitleIPartASchoolDesignationDescriptor](TitleIPartASchoolDesignationDescriptorId, Id, ChangeVersion)
    SELECT  d.TitleIPartASchoolDesignationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TitleIPartASchoolDesignationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TitleIPartASchoolDesignationDescriptor] ENABLE TRIGGER [edfi_TitleIPartASchoolDesignationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_TribalAffiliationDescriptor_TR_DeleteTracking] ON [edfi].[TribalAffiliationDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[TribalAffiliationDescriptor](TribalAffiliationDescriptorId, Id, ChangeVersion)
    SELECT  d.TribalAffiliationDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.TribalAffiliationDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[TribalAffiliationDescriptor] ENABLE TRIGGER [edfi_TribalAffiliationDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_VisaDescriptor_TR_DeleteTracking] ON [edfi].[VisaDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[VisaDescriptor](VisaDescriptorId, Id, ChangeVersion)
    SELECT  d.VisaDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.VisaDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[VisaDescriptor] ENABLE TRIGGER [edfi_VisaDescriptor_TR_DeleteTracking]
GO


CREATE TRIGGER [edfi].[edfi_WeaponDescriptor_TR_DeleteTracking] ON [edfi].[WeaponDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_edfi].[WeaponDescriptor](WeaponDescriptorId, Id, ChangeVersion)
    SELECT  d.WeaponDescriptorId, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.WeaponDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [edfi].[WeaponDescriptor] ENABLE TRIGGER [edfi_WeaponDescriptor_TR_DeleteTracking]
GO


