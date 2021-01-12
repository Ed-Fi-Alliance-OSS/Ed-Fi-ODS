CREATE TABLE tracked_deletes_tpdm.AccreditationStatusDescriptor
(
       AccreditationStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AccreditationStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AidTypeDescriptor
(
       AidTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AidTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ApplicantProfile
(
       ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ApplicantProfile_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Application
(
       ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
       ApplicationIdentifier VARCHAR(20) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Application_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ApplicationEvent
(
       ApplicantProfileIdentifier VARCHAR(32) NOT NULL,
       ApplicationEventTypeDescriptorId INT NOT NULL,
       ApplicationIdentifier VARCHAR(20) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       EventDate DATE NOT NULL,
       SequenceNumber INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ApplicationEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ApplicationEventResultDescriptor
(
       ApplicationEventResultDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ApplicationEventResultDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ApplicationEventTypeDescriptor
(
       ApplicationEventTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ApplicationEventTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ApplicationSourceDescriptor
(
       ApplicationSourceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ApplicationSourceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ApplicationStatusDescriptor
(
       ApplicationStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ApplicationStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.BackgroundCheckStatusDescriptor
(
       BackgroundCheckStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT BackgroundCheckStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.BackgroundCheckTypeDescriptor
(
       BackgroundCheckTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT BackgroundCheckTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Candidate
(
       CandidateIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Candidate_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CandidateCharacteristicDescriptor
(
       CandidateCharacteristicDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CandidateCharacteristicDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CandidateEducatorPreparationProgramAssociation
(
       BeginDate DATE NOT NULL,
       CandidateIdentifier VARCHAR(32) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(255) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CandidateEducatorPreparationProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CandidateRelationshipToStaffAssociation
(
       CandidateIdentifier VARCHAR(32) NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CandidateRelationshipToStaffAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Certification
(
       CertificationIdentifier VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Certification_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationExam
(
       CertificationExamIdentifier VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationExam_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationExamResult
(
       CertificationExamDate DATE NOT NULL,
       CertificationExamIdentifier VARCHAR(60) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationExamResult_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationExamStatusDescriptor
(
       CertificationExamStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationExamStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationExamTypeDescriptor
(
       CertificationExamTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationExamTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationFieldDescriptor
(
       CertificationFieldDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationFieldDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationLevelDescriptor
(
       CertificationLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationRouteDescriptor
(
       CertificationRouteDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationRouteDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CertificationStandardDescriptor
(
       CertificationStandardDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CertificationStandardDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CoteachingStyleObservedDescriptor
(
       CoteachingStyleObservedDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CoteachingStyleObservedDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CredentialEvent
(
       CredentialEventDate DATE NOT NULL,
       CredentialEventTypeDescriptorId INT NOT NULL,
       CredentialIdentifier VARCHAR(60) NOT NULL,
       StateOfIssueStateAbbreviationDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CredentialEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CredentialEventTypeDescriptor
(
       CredentialEventTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CredentialEventTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.CredentialStatusDescriptor
(
       CredentialStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CredentialStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.DegreeDescriptor
(
       DegreeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT DegreeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EPPDegreeTypeDescriptor
(
       EPPDegreeTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EPPDegreeTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EPPProgramPathwayDescriptor
(
       EPPProgramPathwayDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EPPProgramPathwayDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EducatorPreparationProgram
(
       EducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(255) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducatorPreparationProgram_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EducatorPreparationProgramTypeDescriptor
(
       EducatorPreparationProgramTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducatorPreparationProgramTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EducatorRoleDescriptor
(
       EducatorRoleDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EducatorRoleDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EnglishLanguageExamDescriptor
(
       EnglishLanguageExamDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EnglishLanguageExamDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Evaluation
(
       EducationOrganizationId INT NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Evaluation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationElement
(
       EducationOrganizationId INT NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationElement_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationElementRating
(
       EducationOrganizationId INT NOT NULL,
       EvaluationDate DATE NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationElementRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationElementRatingLevelDescriptor
(
       EvaluationElementRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationElementRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationObjective
(
       EducationOrganizationId INT NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationObjective_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationObjectiveRating
(
       EducationOrganizationId INT NOT NULL,
       EvaluationDate DATE NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationObjectiveRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationPeriodDescriptor
(
       EvaluationPeriodDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationPeriodDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationRating
(
       EducationOrganizationId INT NOT NULL,
       EvaluationDate DATE NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationRatingLevelDescriptor
(
       EvaluationRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EvaluationTypeDescriptor
(
       EvaluationTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EvaluationTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.FederalLocaleCodeDescriptor
(
       FederalLocaleCodeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT FederalLocaleCodeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.FieldworkExperience
(
       BeginDate DATE NOT NULL,
       FieldworkIdentifier VARCHAR(64) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT FieldworkExperience_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.FieldworkExperienceSectionAssociation
(
       BeginDate DATE NOT NULL,
       FieldworkIdentifier VARCHAR(64) NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT FieldworkExperienceSectionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.FieldworkTypeDescriptor
(
       FieldworkTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT FieldworkTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.FundingSourceDescriptor
(
       FundingSourceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT FundingSourceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.GenderDescriptor
(
       GenderDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GenderDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Goal
(
       AssignmentDate DATE NOT NULL,
       GoalTitle VARCHAR(255) NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Goal_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.GoalTypeDescriptor
(
       GoalTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT GoalTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.HireStatusDescriptor
(
       HireStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT HireStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.HiringSourceDescriptor
(
       HiringSourceDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT HiringSourceDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.InstructionalSettingDescriptor
(
       InstructionalSettingDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InstructionalSettingDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.LengthOfContractDescriptor
(
       LengthOfContractDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LengthOfContractDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ObjectiveRatingLevelDescriptor
(
       ObjectiveRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ObjectiveRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.OpenStaffPositionEvent
(
       EducationOrganizationId INT NOT NULL,
       EventDate DATE NOT NULL,
       OpenStaffPositionEventTypeDescriptorId INT NOT NULL,
       RequisitionNumber VARCHAR(20) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OpenStaffPositionEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.OpenStaffPositionEventStatusDescriptor
(
       OpenStaffPositionEventStatusDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OpenStaffPositionEventStatusDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.OpenStaffPositionEventTypeDescriptor
(
       OpenStaffPositionEventTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OpenStaffPositionEventTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.OpenStaffPositionReasonDescriptor
(
       OpenStaffPositionReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT OpenStaffPositionReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PerformanceEvaluation
(
       EducationOrganizationId INT NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceEvaluation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PerformanceEvaluationRating
(
       EducationOrganizationId INT NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceEvaluationRating_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PerformanceEvaluationRatingLevelDescriptor
(
       PerformanceEvaluationRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceEvaluationRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PerformanceEvaluationTypeDescriptor
(
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PerformanceEvaluationTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.PreviousCareerDescriptor
(
       PreviousCareerDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT PreviousCareerDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ProfessionalDevelopmentEvent
(
       Namespace VARCHAR(255) NOT NULL,
       ProfessionalDevelopmentTitle VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProfessionalDevelopmentEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ProfessionalDevelopmentEventAttendance
(
       AttendanceDate DATE NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       ProfessionalDevelopmentTitle VARCHAR(60) NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProfessionalDevelopmentEventAttendance_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ProfessionalDevelopmentOfferedByDescriptor
(
       ProfessionalDevelopmentOfferedByDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProfessionalDevelopmentOfferedByDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ProgramGatewayDescriptor
(
       ProgramGatewayDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProgramGatewayDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.QuantitativeMeasure
(
       EducationOrganizationId INT NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       QuantitativeMeasureIdentifier VARCHAR(64) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT QuantitativeMeasure_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.QuantitativeMeasureDatatypeDescriptor
(
       QuantitativeMeasureDatatypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT QuantitativeMeasureDatatypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.QuantitativeMeasureScore
(
       EducationOrganizationId INT NOT NULL,
       EvaluationDate DATE NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       QuantitativeMeasureIdentifier VARCHAR(64) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT QuantitativeMeasureScore_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.QuantitativeMeasureTypeDescriptor
(
       QuantitativeMeasureTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT QuantitativeMeasureTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.RecruitmentEvent
(
       EducationOrganizationId INT NOT NULL,
       EventDate DATE NOT NULL,
       EventTitle VARCHAR(50) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RecruitmentEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.RecruitmentEventAttendance
(
       EducationOrganizationId INT NOT NULL,
       EventDate DATE NOT NULL,
       EventTitle VARCHAR(50) NOT NULL,
       RecruitmentEventAttendeeIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RecruitmentEventAttendance_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.RecruitmentEventAttendeeTypeDescriptor
(
       RecruitmentEventAttendeeTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RecruitmentEventAttendeeTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.RecruitmentEventTypeDescriptor
(
       RecruitmentEventTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RecruitmentEventTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.RubricDimension
(
       EducationOrganizationId INT NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       RubricRating INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RubricDimension_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.RubricRatingLevelDescriptor
(
       RubricRatingLevelDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RubricRatingLevelDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.SalaryTypeDescriptor
(
       SalaryTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SalaryTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StaffEducatorPreparationProgramAssociation
(
       EducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(255) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffEducatorPreparationProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StaffToCandidateRelationshipDescriptor
(
       StaffToCandidateRelationshipDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffToCandidateRelationshipDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.SurveyResponsePersonTargetAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyResponsePersonTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.SurveySectionAggregateResponse
(
       EducationOrganizationId INT NOT NULL,
       EvaluationDate DATE NOT NULL,
       EvaluationElementTitle VARCHAR(255) NOT NULL,
       EvaluationObjectiveTitle VARCHAR(50) NOT NULL,
       EvaluationPeriodDescriptorId INT NOT NULL,
       EvaluationTitle VARCHAR(50) NOT NULL,
       Namespace VARCHAR(255) NOT NULL,
       PerformanceEvaluationTitle VARCHAR(50) NOT NULL,
       PerformanceEvaluationTypeDescriptorId INT NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveySectionTitle VARCHAR(255) NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySectionAggregateResponse_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.SurveySectionResponsePersonTargetAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       PersonId VARCHAR(32) NOT NULL,
       SourceSystemDescriptorId INT NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       SurveySectionTitle VARCHAR(255) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySectionResponsePersonTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.WithdrawReasonDescriptor
(
       WithdrawReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT WithdrawReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

