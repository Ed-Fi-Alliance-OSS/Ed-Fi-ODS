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

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudent]
(
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudent PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudentAcademicRecord]
(
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       FactAsOfDate [DATE] NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudentAcademicRecord PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudentAssessment]
(
       AdministrationDate [DATE] NOT NULL,
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       AssessmentIdentifier [NVARCHAR](60) NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TakenSchoolYear [SMALLINT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudentAssessment PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudentAssessmentCourseAssociation]
(
       AdministrationDate [DATE] NOT NULL,
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       AssessmentIdentifier [NVARCHAR](60) NOT NULL,
       CourseCode [NVARCHAR](60) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TakenSchoolYear [SMALLINT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudentAssessmentCourseAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudentAssessmentSectionAssociation]
(
       AdministrationDate [DATE] NOT NULL,
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       AssessmentIdentifier [NVARCHAR](60) NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       LocalCourseCode [NVARCHAR](60) NOT NULL,
       SchoolId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SectionIdentifier [NVARCHAR](255) NOT NULL,
       SessionName [NVARCHAR](60) NOT NULL,
       TakenSchoolYear [SMALLINT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudentAssessmentSectionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudentCourseAssociation]
(
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       BeginDate [DATE] NOT NULL,
       CourseCode [NVARCHAR](60) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudentCourseAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudentCourseTranscript]
(
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       CourseCode [NVARCHAR](60) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       FactAsOfDate [DATE] NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudentCourseTranscript PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudentEducationOrganizationAssociation]
(
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       BeginDate [DATE] NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudentEducationOrganizationAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[AnonymizedStudentSectionAssociation]
(
       AnonymizedStudentIdentifier [NVARCHAR](60) NOT NULL,
       BeginDate [DATE] NOT NULL,
       FactsAsOfDate [DATE] NOT NULL,
       LocalCourseCode [NVARCHAR](60) NOT NULL,
       SchoolId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SectionIdentifier [NVARCHAR](255) NOT NULL,
       SessionName [NVARCHAR](60) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_AnonymizedStudentSectionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[Applicant]
(
       ApplicantIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Applicant PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[ApplicantProspectAssociation]
(
       ApplicantIdentifier [NVARCHAR](32) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       ProspectIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ApplicantProspectAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[Application]
(
       ApplicantIdentifier [NVARCHAR](32) NOT NULL,
       ApplicationIdentifier [NVARCHAR](20) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Application PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[ApplicationEvent]
(
       ApplicantIdentifier [NVARCHAR](32) NOT NULL,
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

CREATE TABLE [tracked_deletes_tpdm].[CompleterAsStaffAssociation]
(
       StaffUSI [INT] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_CompleterAsStaffAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
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

CREATE TABLE [tracked_deletes_tpdm].[EducatorRoleDescriptor]
(
       EducatorRoleDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EducatorRoleDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[EmploymentEvent]
(
       EducationOrganizationId [INT] NOT NULL,
       EmploymentEventTypeDescriptorId [INT] NOT NULL,
       RequisitionNumber [NVARCHAR](20) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EmploymentEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[EmploymentEventTypeDescriptor]
(
       EmploymentEventTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EmploymentEventTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[EmploymentSeparationEvent]
(
       EducationOrganizationId [INT] NOT NULL,
       EmploymentSeparationDate [DATE] NOT NULL,
       RequisitionNumber [NVARCHAR](20) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EmploymentSeparationEvent PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[EmploymentSeparationReasonDescriptor]
(
       EmploymentSeparationReasonDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EmploymentSeparationReasonDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[EmploymentSeparationTypeDescriptor]
(
       EmploymentSeparationTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_EmploymentSeparationTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
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

CREATE TABLE [tracked_deletes_tpdm].[InternalExternalHireDescriptor]
(
       InternalExternalHireDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_InternalExternalHireDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[LevelOfDegreeAwardedDescriptor]
(
       LevelOfDegreeAwardedDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_LevelOfDegreeAwardedDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
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

CREATE TABLE [tracked_deletes_tpdm].[Prospect]
(
       EducationOrganizationId [INT] NOT NULL,
       ProspectIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Prospect PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[ProspectTypeDescriptor]
(
       ProspectTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ProspectTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
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
       EventDate [DATE] NOT NULL,
       EventTitle [NVARCHAR](50) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_RecruitmentEvent PRIMARY KEY CLUSTERED (ChangeVersion)
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

CREATE TABLE [tracked_deletes_tpdm].[SchoolStatusDescriptor]
(
       SchoolStatusDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SchoolStatusDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StaffApplicantAssociation]
(
       ApplicantIdentifier [NVARCHAR](32) NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffApplicantAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StaffProspectAssociation]
(
       EducationOrganizationId [INT] NOT NULL,
       ProspectIdentifier [NVARCHAR](32) NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffProspectAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StaffStudentGrowthMeasure]
(
       FactAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       StaffStudentGrowthMeasureIdentifier [NVARCHAR](64) NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffStudentGrowthMeasure PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StaffStudentGrowthMeasureCourseAssociation]
(
       CourseCode [NVARCHAR](60) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       FactAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       StaffStudentGrowthMeasureIdentifier [NVARCHAR](64) NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffStudentGrowthMeasureCourseAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation]
(
       EducationOrganizationId [INT] NOT NULL,
       FactAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       StaffStudentGrowthMeasureIdentifier [NVARCHAR](64) NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffStudentGrowthMeasureEducationOrganizationAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StaffStudentGrowthMeasureSectionAssociation]
(
       FactAsOfDate [DATE] NOT NULL,
       LocalCourseCode [NVARCHAR](60) NOT NULL,
       SchoolId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SectionIdentifier [NVARCHAR](255) NOT NULL,
       SessionName [NVARCHAR](60) NOT NULL,
       StaffStudentGrowthMeasureIdentifier [NVARCHAR](64) NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffStudentGrowthMeasureSectionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StaffTeacherPreparationProviderAssociation]
(
       StaffUSI [INT] NOT NULL,
       TeacherPreparationProviderId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffTeacherPreparationProviderAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StaffTeacherPreparationProviderProgramAssociation]
(
       EducationOrganizationId [INT] NOT NULL,
       ProgramName [NVARCHAR](255) NOT NULL,
       ProgramTypeDescriptorId [INT] NOT NULL,
       StaffUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StaffTeacherPreparationProviderProgramAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[StudentGrowthTypeDescriptor]
(
       StudentGrowthTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StudentGrowthTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[SurveyResponseTeacherCandidateTargetAssociation]
(
       Namespace [NVARCHAR](255) NOT NULL,
       SurveyIdentifier [NVARCHAR](60) NOT NULL,
       SurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SurveyResponseTeacherCandidateTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
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

CREATE TABLE [tracked_deletes_tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation]
(
       Namespace [NVARCHAR](255) NOT NULL,
       SurveyIdentifier [NVARCHAR](60) NOT NULL,
       SurveyResponseIdentifier [NVARCHAR](60) NOT NULL,
       SurveySectionTitle [NVARCHAR](255) NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SurveySectionResponseTeacherCandidateTargetAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TPPDegreeTypeDescriptor]
(
       TPPDegreeTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TPPDegreeTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TPPProgramPathwayDescriptor]
(
       TPPProgramPathwayDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TPPProgramPathwayDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidate]
(
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidate PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateAcademicRecord]
(
       EducationOrganizationId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateAcademicRecord PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateCharacteristicDescriptor]
(
       TeacherCandidateCharacteristicDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateCharacteristicDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateCourseTranscript]
(
       CourseAttemptResultDescriptorId [INT] NOT NULL,
       CourseCode [NVARCHAR](60) NOT NULL,
       CourseEducationOrganizationId [INT] NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       TermDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateCourseTranscript PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateStaffAssociation]
(
       StaffUSI [INT] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateStaffAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateStudentGrowthMeasure]
(
       FactAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       TeacherCandidateStudentGrowthMeasureIdentifier [NVARCHAR](64) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateStudentGrowthMeasure PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation]
(
       CourseCode [NVARCHAR](60) NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       FactAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       TeacherCandidateStudentGrowthMeasureIdentifier [NVARCHAR](64) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateStudentGrowthMeasureCourseAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation]
(
       EducationOrganizationId [INT] NOT NULL,
       FactAsOfDate [DATE] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       TeacherCandidateStudentGrowthMeasureIdentifier [NVARCHAR](64) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation]
(
       FactAsOfDate [DATE] NOT NULL,
       LocalCourseCode [NVARCHAR](60) NOT NULL,
       SchoolId [INT] NOT NULL,
       SchoolYear [SMALLINT] NOT NULL,
       SectionIdentifier [NVARCHAR](255) NOT NULL,
       SessionName [NVARCHAR](60) NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       TeacherCandidateStudentGrowthMeasureIdentifier [NVARCHAR](64) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateStudentGrowthMeasureSectionAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateTeacherPreparationProviderAssociation]
(
       EntryDate [DATE] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       TeacherPreparationProviderId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateTeacherPreparationProviderAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation]
(
       BeginDate [DATE] NOT NULL,
       EducationOrganizationId [INT] NOT NULL,
       ProgramName [NVARCHAR](255) NOT NULL,
       ProgramTypeDescriptorId [INT] NOT NULL,
       TeacherCandidateIdentifier [NVARCHAR](32) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherCandidateTeacherPreparationProviderProgramAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherPreparationProgramTypeDescriptor]
(
       TeacherPreparationProgramTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherPreparationProgramTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherPreparationProvider]
(
       TeacherPreparationProviderId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherPreparationProvider PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[TeacherPreparationProviderProgram]
(
       EducationOrganizationId [INT] NOT NULL,
       ProgramName [NVARCHAR](255) NOT NULL,
       ProgramTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_TeacherPreparationProviderProgram PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[University]
(
       UniversityId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_University PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[ValueTypeDescriptor]
(
       ValueTypeDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_ValueTypeDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_tpdm].[WithdrawReasonDescriptor]
(
       WithdrawReasonDescriptorId [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_WithdrawReasonDescriptor PRIMARY KEY CLUSTERED (ChangeVersion)
)

