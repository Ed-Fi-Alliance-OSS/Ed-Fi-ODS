-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE [tracked_deletes_tpdm].[AccreditationStatusDescriptor]
(
       AccreditationStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AccreditationStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[AidTypeDescriptor]
(
       AidTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AidTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ApplicantProfile]
(
       ApplicantProfileIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ApplicantProfile PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[Application]
(
       ApplicantProfileIdentifier [NVARCHAR](32) NOT NULL,
       ApplicationIdentifier [NVARCHAR](20) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Application PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ApplicationEvent]
(
       ApplicantProfileIdentifier [NVARCHAR](32) NOT NULL,
       ApplicationEventTypeDescriptorId [INT] NOT NULL,
       ApplicationIdentifier [NVARCHAR](20) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       EventDate [DATE] NOT NULL,
       SequenceNumber [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ApplicationEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ApplicationEventResultDescriptor]
(
       ApplicationEventResultDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ApplicationEventResultDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ApplicationEventTypeDescriptor]
(
       ApplicationEventTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ApplicationEventTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ApplicationSourceDescriptor]
(
       ApplicationSourceDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ApplicationSourceDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ApplicationStatusDescriptor]
(
       ApplicationStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ApplicationStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[BackgroundCheckStatusDescriptor]
(
       BackgroundCheckStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_BackgroundCheckStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[BackgroundCheckTypeDescriptor]
(
       BackgroundCheckTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_BackgroundCheckTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[Candidate]
(
       CandidateIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Candidate PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CandidateCharacteristicDescriptor]
(
       CandidateCharacteristicDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CandidateCharacteristicDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CandidateEducatorPreparationProgramAssociation]
(
       BeginDate [DATE] NOT NULL,
       CandidateIdentifier [NVARCHAR](32) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       ProgramName [NVARCHAR](255) NOT NULL,
       ProgramTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CandidateEducatorPreparationProgramAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CandidateRelationshipToStaffAssociation]
(
       CandidateIdentifier [NVARCHAR](32) NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CandidateRelationshipToStaffAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[Certification]
(
       CertificationIdentifier [NVARCHAR](60) NOT NULL,
       Namespace [NVARCHAR](255) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Certification PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationExam]
(
       CertificationExamIdentifier [NVARCHAR](60) NOT NULL,
       Namespace [NVARCHAR](255) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationExam PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationExamResult]
(
       CertificationExamDate [DATE] NOT NULL,
       CertificationExamIdentifier [NVARCHAR](60) NOT NULL,
       Namespace [NVARCHAR](255) NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationExamResult PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationExamStatusDescriptor]
(
       CertificationExamStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationExamStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationExamTypeDescriptor]
(
       CertificationExamTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationExamTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationFieldDescriptor]
(
       CertificationFieldDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationFieldDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationLevelDescriptor]
(
       CertificationLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationRouteDescriptor]
(
       CertificationRouteDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationRouteDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CertificationStandardDescriptor]
(
       CertificationStandardDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CertificationStandardDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CoteachingStyleObservedDescriptor]
(
       CoteachingStyleObservedDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CoteachingStyleObservedDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CredentialEvent]
(
       CredentialEventDate [DATE] NOT NULL,
       CredentialEventTypeDescriptorId [INT] NOT NULL,
       CredentialIdentifier [NVARCHAR](60) NOT NULL,
       StateOfIssueStateAbbreviationDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CredentialEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CredentialEventTypeDescriptor]
(
       CredentialEventTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CredentialEventTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[CredentialStatusDescriptor]
(
       CredentialStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CredentialStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[DegreeDescriptor]
(
       DegreeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_DegreeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EPPDegreeTypeDescriptor]
(
       EPPDegreeTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EPPDegreeTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EPPProgramPathwayDescriptor]
(
       EPPProgramPathwayDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EPPProgramPathwayDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EducatorPreparationProgram]
(
       EducationOrganizationId [INT] NOT NULL,
       ProgramName [NVARCHAR](255) NOT NULL,
       ProgramTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EducatorPreparationProgram PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EducatorPreparationProgramTypeDescriptor]
(
       EducatorPreparationProgramTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EducatorPreparationProgramTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EducatorRoleDescriptor]
(
       EducatorRoleDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EducatorRoleDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EnglishLanguageExamDescriptor]
(
       EnglishLanguageExamDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EnglishLanguageExamDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[Evaluation]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Evaluation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationElement]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationElement PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationElementRating]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationDate [DATE] NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationElementRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationElementRatingLevelDescriptor]
(
       EvaluationElementRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationElementRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationObjective]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationObjective PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationObjectiveRating]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationDate [DATE] NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationObjectiveRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationPeriodDescriptor]
(
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationPeriodDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationRating]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationDate [DATE] NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationRatingLevelDescriptor]
(
       EvaluationRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[EvaluationTypeDescriptor]
(
       EvaluationTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EvaluationTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[FederalLocaleCodeDescriptor]
(
       FederalLocaleCodeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_FederalLocaleCodeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[FieldworkExperience]
(
       BeginDate [DATE] NOT NULL,
       FieldworkIdentifier [NVARCHAR](64) NOT NULL,
       StudentUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_FieldworkExperience PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[FieldworkExperienceSectionAssociation]
(
       BeginDate [DATE] NOT NULL,
       FieldworkIdentifier [NVARCHAR](64) NOT NULL,
       LocalCourseCode [NVARCHAR](60) NOT NULL,
       SchoolId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SectionIdentifier [NVARCHAR](255) NOT NULL,
       SessionName [NVARCHAR](60) NOT NULL,
       StudentUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_FieldworkExperienceSectionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[FieldworkTypeDescriptor]
(
       FieldworkTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_FieldworkTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[FundingSourceDescriptor]
(
       FundingSourceDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_FundingSourceDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[GenderDescriptor]
(
       GenderDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_GenderDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[Goal]
(
       AssignmentDate [DATE] NOT NULL,
       GoalTitle [NVARCHAR](255) NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Goal PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[GoalTypeDescriptor]
(
       GoalTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_GoalTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[HireStatusDescriptor]
(
       HireStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_HireStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[HiringSourceDescriptor]
(
       HiringSourceDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_HiringSourceDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[InstructionalSettingDescriptor]
(
       InstructionalSettingDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_InstructionalSettingDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[LengthOfContractDescriptor]
(
       LengthOfContractDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_LengthOfContractDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ObjectiveRatingLevelDescriptor]
(
       ObjectiveRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ObjectiveRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[OpenStaffPositionEvent]
(
       EducationOrganizationId [INT] NOT NULL,
       EventDate [DATE] NOT NULL,
       OpenStaffPositionEventTypeDescriptorId [INT] NOT NULL,
       RequisitionNumber [NVARCHAR](20) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_OpenStaffPositionEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[OpenStaffPositionEventStatusDescriptor]
(
       OpenStaffPositionEventStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_OpenStaffPositionEventStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[OpenStaffPositionEventTypeDescriptor]
(
       OpenStaffPositionEventTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_OpenStaffPositionEventTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[OpenStaffPositionReasonDescriptor]
(
       OpenStaffPositionReasonDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_OpenStaffPositionReasonDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PerformanceEvaluation]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PerformanceEvaluation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PerformanceEvaluationRating]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PerformanceEvaluationRating PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PerformanceEvaluationRatingLevelDescriptor]
(
       PerformanceEvaluationRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PerformanceEvaluationRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PerformanceEvaluationTypeDescriptor]
(
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PerformanceEvaluationTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[PreviousCareerDescriptor]
(
       PreviousCareerDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_PreviousCareerDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ProfessionalDevelopmentEvent]
(
       Namespace [NVARCHAR](255) NOT NULL,
       ProfessionalDevelopmentTitle [NVARCHAR](60) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ProfessionalDevelopmentEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ProfessionalDevelopmentEventAttendance]
(
       AttendanceDate [DATE] NOT NULL,
       Namespace [NVARCHAR](255) NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       ProfessionalDevelopmentTitle [NVARCHAR](60) NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ProfessionalDevelopmentEventAttendance PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ProfessionalDevelopmentOfferedByDescriptor]
(
       ProfessionalDevelopmentOfferedByDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ProfessionalDevelopmentOfferedByDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[ProgramGatewayDescriptor]
(
       ProgramGatewayDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ProgramGatewayDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[QuantitativeMeasure]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       QuantitativeMeasureIdentifier [NVARCHAR](64) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_QuantitativeMeasure PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[QuantitativeMeasureDatatypeDescriptor]
(
       QuantitativeMeasureDatatypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_QuantitativeMeasureDatatypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[QuantitativeMeasureScore]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationDate [DATE] NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       QuantitativeMeasureIdentifier [NVARCHAR](64) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_QuantitativeMeasureScore PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[QuantitativeMeasureTypeDescriptor]
(
       QuantitativeMeasureTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_QuantitativeMeasureTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[RecruitmentEvent]
(
       EducationOrganizationId [INT] NOT NULL,
       EventDate [DATE] NOT NULL,
       EventTitle [NVARCHAR](50) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RecruitmentEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[RecruitmentEventAttendance]
(
       EducationOrganizationId [INT] NOT NULL,
       EventDate [DATE] NOT NULL,
       EventTitle [NVARCHAR](50) NOT NULL,
       RecruitmentEventAttendeeIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RecruitmentEventAttendance PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[RecruitmentEventAttendeeTypeDescriptor]
(
       RecruitmentEventAttendeeTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RecruitmentEventAttendeeTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[RecruitmentEventTypeDescriptor]
(
       RecruitmentEventTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RecruitmentEventTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[RubricDimension]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       RubricRating [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RubricDimension PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[RubricRatingLevelDescriptor]
(
       RubricRatingLevelDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RubricRatingLevelDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[SalaryTypeDescriptor]
(
       SalaryTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SalaryTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[StaffEducatorPreparationProgramAssociation]
(
       EducationOrganizationId [INT] NOT NULL,
       ProgramName [NVARCHAR](255) NOT NULL,
       ProgramTypeDescriptorId [INT] NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffEducatorPreparationProgramAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[StaffToCandidateRelationshipDescriptor]
(
       StaffToCandidateRelationshipDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffToCandidateRelationshipDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[SurveyResponsePersonTargetAssociation]
(
       Namespace [NVARCHAR](255) NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       SurveyIdentifier [NVARCHAR](60) NOT NULL,
       SurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SurveyResponsePersonTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[SurveySectionAggregateResponse]
(
       EducationOrganizationId [INT] NOT NULL,
       EvaluationDate [DATE] NOT NULL,
       EvaluationElementTitle [NVARCHAR](255) NOT NULL,
       EvaluationObjectiveTitle [NVARCHAR](50) NOT NULL,
       EvaluationPeriodDescriptorId [INT] NOT NULL,
       EvaluationTitle [NVARCHAR](50) NOT NULL,
       Namespace [NVARCHAR](255) NOT NULL,
       PerformanceEvaluationTitle [NVARCHAR](50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId [INT] NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       SurveyIdentifier [NVARCHAR](60) NOT NULL,
       SurveySectionTitle [NVARCHAR](255) NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SurveySectionAggregateResponse PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[SurveySectionResponsePersonTargetAssociation]
(
       Namespace [NVARCHAR](255) NOT NULL,
       PersonId [NVARCHAR](32) NOT NULL,
       SourceSystemDescriptorId [INT] NOT NULL,
       SurveyIdentifier [NVARCHAR](60) NOT NULL,
       SurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       SurveySectionTitle [NVARCHAR](255) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SurveySectionResponsePersonTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)
CREATE TABLE [tracked_deletes_tpdm].[WithdrawReasonDescriptor]
(
       WithdrawReasonDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_WithdrawReasonDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)
