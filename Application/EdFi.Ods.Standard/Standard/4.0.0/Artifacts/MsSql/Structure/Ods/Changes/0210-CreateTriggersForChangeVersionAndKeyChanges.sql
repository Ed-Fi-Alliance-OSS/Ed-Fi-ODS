-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [edfi].[edfi_AcademicWeek_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_AcademicWeek_TR_UpdateChangeVersion] ON [edfi].[AcademicWeek] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[AcademicWeek] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AccountabilityRating_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_AccountabilityRating_TR_UpdateChangeVersion] ON [edfi].[AccountabilityRating] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[AccountabilityRating] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Assessment_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Assessment_TR_UpdateChangeVersion] ON [edfi].[Assessment] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Assessment] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentItem_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentItem_TR_UpdateChangeVersion] ON [edfi].[AssessmentItem] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[AssessmentItem] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_AssessmentScoreRangeLearningStandard_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_AssessmentScoreRangeLearningStandard_TR_UpdateChangeVersion] ON [edfi].[AssessmentScoreRangeLearningStandard] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[AssessmentScoreRangeLearningStandard] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_BalanceSheetDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_BalanceSheetDimension_TR_UpdateChangeVersion] ON [edfi].[BalanceSheetDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[BalanceSheetDimension] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_BellSchedule_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_BellSchedule_TR_UpdateChangeVersion] ON [edfi].[BellSchedule] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[BellSchedule] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Calendar_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Calendar_TR_UpdateChangeVersion] ON [edfi].[Calendar] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Calendar] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CalendarDate_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CalendarDate_TR_UpdateChangeVersion] ON [edfi].[CalendarDate] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[CalendarDate] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ChartOfAccount_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ChartOfAccount_TR_UpdateChangeVersion] ON [edfi].[ChartOfAccount] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[ChartOfAccount] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ClassPeriod_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ClassPeriod_TR_UpdateChangeVersion] ON [edfi].[ClassPeriod] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[ClassPeriod] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Cohort_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Cohort_TR_UpdateChangeVersion] ON [edfi].[Cohort] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Cohort] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CommunityProviderLicense_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CommunityProviderLicense_TR_UpdateChangeVersion] ON [edfi].[CommunityProviderLicense] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[CommunityProviderLicense] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CompetencyObjective_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CompetencyObjective_TR_UpdateChangeVersion] ON [edfi].[CompetencyObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[CompetencyObjective] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Course_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Course_TR_UpdateChangeVersion] ON [edfi].[Course] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Course] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CourseOffering_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CourseOffering_TR_UpdateChangeVersion] ON [edfi].[CourseOffering] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[CourseOffering] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_CourseTranscript_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_CourseTranscript_TR_UpdateChangeVersion] ON [edfi].[CourseTranscript] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[CourseTranscript] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Credential_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Credential_TR_UpdateChangeVersion] ON [edfi].[Credential] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Credential] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Descriptor_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Descriptor_TR_UpdateChangeVersion] ON [edfi].[Descriptor] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Descriptor] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DescriptorMapping_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_DescriptorMapping_TR_UpdateChangeVersion] ON [edfi].[DescriptorMapping] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[DescriptorMapping] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineAction_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineAction_TR_UpdateChangeVersion] ON [edfi].[DisciplineAction] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[DisciplineAction] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_DisciplineIncident_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_DisciplineIncident_TR_UpdateChangeVersion] ON [edfi].[DisciplineIncident] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[DisciplineIncident] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationContent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationContent_TR_UpdateChangeVersion] ON [edfi].[EducationContent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[EducationContent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganization_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganization_TR_UpdateChangeVersion] ON [edfi].[EducationOrganization] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[EducationOrganization] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationInterventionPrescriptionAssociation_TR_UpdateChangeVersion] ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[EducationOrganizationInterventionPrescriptionAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationNetworkAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationNetworkAssociation_TR_UpdateChangeVersion] ON [edfi].[EducationOrganizationNetworkAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[EducationOrganizationNetworkAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_EducationOrganizationPeerAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_EducationOrganizationPeerAssociation_TR_UpdateChangeVersion] ON [edfi].[EducationOrganizationPeerAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[EducationOrganizationPeerAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FeederSchoolAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_FeederSchoolAssociation_TR_UpdateChangeVersion] ON [edfi].[FeederSchoolAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[FeederSchoolAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FunctionDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_FunctionDimension_TR_UpdateChangeVersion] ON [edfi].[FunctionDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[FunctionDimension] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_FundDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_FundDimension_TR_UpdateChangeVersion] ON [edfi].[FundDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[FundDimension] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GeneralStudentProgramAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GeneralStudentProgramAssociation_TR_UpdateChangeVersion] ON [edfi].[GeneralStudentProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[GeneralStudentProgramAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Grade_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Grade_TR_UpdateChangeVersion] ON [edfi].[Grade] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Grade] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GradebookEntry_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GradebookEntry_TR_UpdateChangeVersion] ON [edfi].[GradebookEntry] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[GradebookEntry] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GradingPeriod_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GradingPeriod_TR_UpdateChangeVersion] ON [edfi].[GradingPeriod] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[GradingPeriod] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_GraduationPlan_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_GraduationPlan_TR_UpdateChangeVersion] ON [edfi].[GraduationPlan] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[GraduationPlan] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Intervention_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Intervention_TR_UpdateChangeVersion] ON [edfi].[Intervention] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Intervention] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionPrescription_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_InterventionPrescription_TR_UpdateChangeVersion] ON [edfi].[InterventionPrescription] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[InterventionPrescription] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_InterventionStudy_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_InterventionStudy_TR_UpdateChangeVersion] ON [edfi].[InterventionStudy] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[InterventionStudy] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LearningObjective_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LearningObjective_TR_UpdateChangeVersion] ON [edfi].[LearningObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LearningObjective] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandard_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandard_TR_UpdateChangeVersion] ON [edfi].[LearningStandard] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LearningStandard] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LearningStandardEquivalenceAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LearningStandardEquivalenceAssociation_TR_UpdateChangeVersion] ON [edfi].[LearningStandardEquivalenceAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LearningStandardEquivalenceAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalAccount_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalAccount_TR_UpdateChangeVersion] ON [edfi].[LocalAccount] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LocalAccount] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalActual_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalActual_TR_UpdateChangeVersion] ON [edfi].[LocalActual] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LocalActual] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalBudget_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalBudget_TR_UpdateChangeVersion] ON [edfi].[LocalBudget] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LocalBudget] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalContractedStaff_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalContractedStaff_TR_UpdateChangeVersion] ON [edfi].[LocalContractedStaff] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LocalContractedStaff] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalEncumbrance_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalEncumbrance_TR_UpdateChangeVersion] ON [edfi].[LocalEncumbrance] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LocalEncumbrance] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_LocalPayroll_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_LocalPayroll_TR_UpdateChangeVersion] ON [edfi].[LocalPayroll] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[LocalPayroll] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Location_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Location_TR_UpdateChangeVersion] ON [edfi].[Location] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Location] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ObjectDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ObjectDimension_TR_UpdateChangeVersion] ON [edfi].[ObjectDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[ObjectDimension] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ObjectiveAssessment_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ObjectiveAssessment_TR_UpdateChangeVersion] ON [edfi].[ObjectiveAssessment] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[ObjectiveAssessment] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_OpenStaffPosition_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_OpenStaffPosition_TR_UpdateChangeVersion] ON [edfi].[OpenStaffPosition] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[OpenStaffPosition] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_OperationalUnitDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_OperationalUnitDimension_TR_UpdateChangeVersion] ON [edfi].[OperationalUnitDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[OperationalUnitDimension] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Parent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Parent_TR_UpdateChangeVersion] ON [edfi].[Parent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Parent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Person_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Person_TR_UpdateChangeVersion] ON [edfi].[Person] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Person] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_PostSecondaryEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_PostSecondaryEvent_TR_UpdateChangeVersion] ON [edfi].[PostSecondaryEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[PostSecondaryEvent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Program_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Program_TR_UpdateChangeVersion] ON [edfi].[Program] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Program] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProgramDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ProgramDimension_TR_UpdateChangeVersion] ON [edfi].[ProgramDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[ProgramDimension] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ProjectDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ProjectDimension_TR_UpdateChangeVersion] ON [edfi].[ProjectDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[ProjectDimension] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_ReportCard_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_ReportCard_TR_UpdateChangeVersion] ON [edfi].[ReportCard] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[ReportCard] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_RestraintEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_RestraintEvent_TR_UpdateChangeVersion] ON [edfi].[RestraintEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[RestraintEvent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SchoolYearType_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SchoolYearType_TR_UpdateChangeVersion] ON [edfi].[SchoolYearType] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SchoolYearType] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Section_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Section_TR_UpdateChangeVersion] ON [edfi].[Section] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Section] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SectionAttendanceTakenEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SectionAttendanceTakenEvent_TR_UpdateChangeVersion] ON [edfi].[SectionAttendanceTakenEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SectionAttendanceTakenEvent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Session_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Session_TR_UpdateChangeVersion] ON [edfi].[Session] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Session] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SourceDimension_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SourceDimension_TR_UpdateChangeVersion] ON [edfi].[SourceDimension] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SourceDimension] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Staff_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Staff_TR_UpdateChangeVersion] ON [edfi].[Staff] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Staff] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffAbsenceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffAbsenceEvent_TR_UpdateChangeVersion] ON [edfi].[StaffAbsenceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffAbsenceEvent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffCohortAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffCohortAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffCohortAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffCohortAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffDisciplineIncidentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffDisciplineIncidentAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffDisciplineIncidentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffDisciplineIncidentAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationAssignmentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationAssignmentAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffEducationOrganizationAssignmentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffEducationOrganizationAssignmentAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationContactAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationContactAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffEducationOrganizationContactAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffEducationOrganizationContactAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffEducationOrganizationEmploymentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffEducationOrganizationEmploymentAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffEducationOrganizationEmploymentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffEducationOrganizationEmploymentAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffLeave_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffLeave_TR_UpdateChangeVersion] ON [edfi].[StaffLeave] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffLeave] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffProgramAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffProgramAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffProgramAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffSchoolAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffSchoolAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffSchoolAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffSchoolAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StaffSectionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StaffSectionAssociation_TR_UpdateChangeVersion] ON [edfi].[StaffSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StaffSectionAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Student_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Student_TR_UpdateChangeVersion] ON [edfi].[Student] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Student] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAcademicRecord_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentAcademicRecord_TR_UpdateChangeVersion] ON [edfi].[StudentAcademicRecord] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentAcademicRecord] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessment_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentAssessment_TR_UpdateChangeVersion] ON [edfi].[StudentAssessment] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentAssessment] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentAssessmentEducationOrganizationAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentAssessmentEducationOrganizationAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentAssessmentEducationOrganizationAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentAssessmentEducationOrganizationAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCohortAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentCohortAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentCohortAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentCohortAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentCompetencyObjective_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentCompetencyObjective_TR_UpdateChangeVersion] ON [edfi].[StudentCompetencyObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentCompetencyObjective] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentDisciplineIncidentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentDisciplineIncidentAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentBehaviorAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentBehaviorAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentDisciplineIncidentBehaviorAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentDisciplineIncidentBehaviorAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentDisciplineIncidentNonOffenderAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentDisciplineIncidentNonOffenderAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentEducationOrganizationAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentEducationOrganizationAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentEducationOrganizationAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentEducationOrganizationResponsibilityAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentEducationOrganizationResponsibilityAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentEducationOrganizationResponsibilityAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentEducationOrganizationResponsibilityAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentGradebookEntry_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentGradebookEntry_TR_UpdateChangeVersion] ON [edfi].[StudentGradebookEntry] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentGradebookEntry] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentInterventionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentInterventionAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentInterventionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentInterventionAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentInterventionAttendanceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentInterventionAttendanceEvent_TR_UpdateChangeVersion] ON [edfi].[StudentInterventionAttendanceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentInterventionAttendanceEvent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentLearningObjective_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentLearningObjective_TR_UpdateChangeVersion] ON [edfi].[StudentLearningObjective] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentLearningObjective] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentParentAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentParentAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentParentAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentParentAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentProgramAttendanceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentProgramAttendanceEvent_TR_UpdateChangeVersion] ON [edfi].[StudentProgramAttendanceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentProgramAttendanceEvent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSchoolAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSchoolAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentSchoolAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentSchoolAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSchoolAttendanceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSchoolAttendanceEvent_TR_UpdateChangeVersion] ON [edfi].[StudentSchoolAttendanceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentSchoolAttendanceEvent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSectionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSectionAssociation_TR_UpdateChangeVersion] ON [edfi].[StudentSectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentSectionAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_StudentSectionAttendanceEvent_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_StudentSectionAttendanceEvent_TR_UpdateChangeVersion] ON [edfi].[StudentSectionAttendanceEvent] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[StudentSectionAttendanceEvent] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_Survey_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_Survey_TR_UpdateChangeVersion] ON [edfi].[Survey] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[Survey] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyCourseAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyCourseAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveyCourseAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveyCourseAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyProgramAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyProgramAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveyProgramAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveyProgramAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyQuestion_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyQuestion_TR_UpdateChangeVersion] ON [edfi].[SurveyQuestion] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveyQuestion] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyQuestionResponse_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyQuestionResponse_TR_UpdateChangeVersion] ON [edfi].[SurveyQuestionResponse] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveyQuestionResponse] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponse_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponse_TR_UpdateChangeVersion] ON [edfi].[SurveyResponse] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveyResponse] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveyResponseEducationOrganizationTargetAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveyResponseStaffTargetAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveyResponseStaffTargetAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveyResponseStaffTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveyResponseStaffTargetAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySection_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySection_TR_UpdateChangeVersion] ON [edfi].[SurveySection] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveySection] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveySectionAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveySectionAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponse_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponse_TR_UpdateChangeVersion] ON [edfi].[SurveySectionResponse] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveySectionResponse] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponseEducationOrganizationTargetAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

DROP TRIGGER IF EXISTS [edfi].[edfi_SurveySectionResponseStaffTargetAssociation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [edfi].[edfi_SurveySectionResponseStaffTargetAssociation_TR_UpdateChangeVersion] ON [edfi].[SurveySectionResponseStaffTargetAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE u
    SET 
        ChangeVersion = NEXT VALUE FOR [changes].[ChangeVersionSequence],
        LastModifiedDate = 
            CASE 
                WHEN i.LastModifiedDate = d.LastModifiedDate THEN GETUTCDATE()
                ELSE i.LastModifiedDate
            END
    FROM [edfi].[SurveySectionResponseStaffTargetAssociation] u
    INNER JOIN inserted i ON i.Id = u.Id
    INNER JOIN deleted d ON d.Id = u.Id;
END	
GO

