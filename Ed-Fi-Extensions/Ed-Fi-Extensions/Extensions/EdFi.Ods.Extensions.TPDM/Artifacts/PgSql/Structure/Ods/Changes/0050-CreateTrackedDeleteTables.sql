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

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudent
(
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudentAcademicRecord
(
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FactAsOfDate DATE NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudentAcademicRecord_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudentAssessment
(
       AdministrationDate DATE NOT NULL,
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       AssessmentIdentifier VARCHAR(60) NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TakenSchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudentAssessment_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudentAssessmentCourseAssociation
(
       AdministrationDate DATE NOT NULL,
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       AssessmentIdentifier VARCHAR(60) NOT NULL,
       CourseCode VARCHAR(60) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TakenSchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudentAssessmentCourseAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudentAssessmentSectionAssociation
(
       AdministrationDate DATE NOT NULL,
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       AssessmentIdentifier VARCHAR(60) NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       TakenSchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudentAssessmentSectionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudentCourseAssociation
(
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       BeginDate DATE NOT NULL,
       CourseCode VARCHAR(60) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudentCourseAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudentCourseTranscript
(
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       CourseCode VARCHAR(60) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FactAsOfDate DATE NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudentCourseTranscript_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudentEducationOrganizationAssociation
(
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudentEducationOrganizationAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.AnonymizedStudentSectionAssociation
(
       AnonymizedStudentIdentifier VARCHAR(60) NOT NULL,
       BeginDate DATE NOT NULL,
       FactsAsOfDate DATE NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT AnonymizedStudentSectionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Applicant
(
       ApplicantIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Applicant_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ApplicantProspectAssociation
(
       ApplicantIdentifier VARCHAR(32) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProspectIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ApplicantProspectAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.Application
(
       ApplicantIdentifier VARCHAR(32) NOT NULL,
       ApplicationIdentifier VARCHAR(20) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Application_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ApplicationEvent
(
       ApplicantIdentifier VARCHAR(32) NOT NULL,
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

CREATE TABLE tracked_deletes_tpdm.CompleterAsStaffAssociation
(
       StaffUSI INT NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT CompleterAsStaffAssociation_PK PRIMARY KEY (ChangeVersion)
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

CREATE TABLE tracked_deletes_tpdm.EmploymentEvent
(
       EducationOrganizationId INT NOT NULL,
       EmploymentEventTypeDescriptorId INT NOT NULL,
       RequisitionNumber VARCHAR(20) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EmploymentEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EmploymentEventTypeDescriptor
(
       EmploymentEventTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EmploymentEventTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EmploymentSeparationEvent
(
       EducationOrganizationId INT NOT NULL,
       EmploymentSeparationDate DATE NOT NULL,
       RequisitionNumber VARCHAR(20) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EmploymentSeparationEvent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EmploymentSeparationReasonDescriptor
(
       EmploymentSeparationReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EmploymentSeparationReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.EmploymentSeparationTypeDescriptor
(
       EmploymentSeparationTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT EmploymentSeparationTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
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

CREATE TABLE tracked_deletes_tpdm.InternalExternalHireDescriptor
(
       InternalExternalHireDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT InternalExternalHireDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.LevelOfDegreeAwardedDescriptor
(
       LevelOfDegreeAwardedDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT LevelOfDegreeAwardedDescriptor_PK PRIMARY KEY (ChangeVersion)
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

CREATE TABLE tracked_deletes_tpdm.Prospect
(
       EducationOrganizationId INT NOT NULL,
       ProspectIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Prospect_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ProspectTypeDescriptor
(
       ProspectTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ProspectTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
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
       EventDate DATE NOT NULL,
       EventTitle VARCHAR(50) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT RecruitmentEvent_PK PRIMARY KEY (ChangeVersion)
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

CREATE TABLE tracked_deletes_tpdm.StaffApplicantAssociation
(
       ApplicantIdentifier VARCHAR(32) NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffApplicantAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StaffProspectAssociation
(
       EducationOrganizationId INT NOT NULL,
       ProspectIdentifier VARCHAR(32) NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffProspectAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StaffStudentGrowthMeasure
(
       FactAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffStudentGrowthMeasure_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StaffStudentGrowthMeasureCourseAssociation
(
       CourseCode VARCHAR(60) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FactAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffStudentGrowthMeasureCourseAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation
(
       EducationOrganizationId INT NOT NULL,
       FactAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffStudentGrowthMeasureEducationOrganizationAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StaffStudentGrowthMeasureSectionAssociation
(
       FactAsOfDate DATE NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       StaffStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffStudentGrowthMeasureSectionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StaffTeacherPreparationProviderProgramAssociation
(
       EducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(255) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StaffUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StaffTeacherPreparationProviderProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.StudentGrowthTypeDescriptor
(
       StudentGrowthTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentGrowthTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.SurveyResponseTeacherCandidateTargetAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveyResponseTeacherCandidateTargetAssociation_PK PRIMARY KEY (ChangeVersion)
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

CREATE TABLE tracked_deletes_tpdm.SurveySectionResponseTeacherCandidateTargetAssociation
(
       Namespace VARCHAR(255) NOT NULL,
       SurveyIdentifier VARCHAR(60) NOT NULL,
       SurveyResponseIdentifier VARCHAR(60) NOT NULL,
       SurveySectionTitle VARCHAR(255) NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SurveySectionResponseTeacherCandidateTargetAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TPPDegreeTypeDescriptor
(
       TPPDegreeTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TPPDegreeTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TPPProgramPathwayDescriptor
(
       TPPProgramPathwayDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TPPProgramPathwayDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidate
(
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidate_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateAcademicRecord
(
       EducationOrganizationId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateAcademicRecord_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateCharacteristicDescriptor
(
       TeacherCandidateCharacteristicDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateCharacteristicDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateCourseTranscript
(
       CourseAttemptResultDescriptorId INT NOT NULL,
       CourseCode VARCHAR(60) NOT NULL,
       CourseEducationOrganizationId INT NOT NULL,
       EducationOrganizationId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       TermDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateCourseTranscript_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateStaffAssociation
(
       StaffUSI INT NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateStaffAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasure
(
       FactAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateStudentGrowthMeasure_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation
(
       CourseCode VARCHAR(60) NOT NULL,
       EducationOrganizationId INT NOT NULL,
       FactAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateStudentGrowthMeasureCourseAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4
(
       EducationOrganizationId INT NOT NULL,
       FactAsOfDate DATE NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateStudentGrowthMeasureEducationOrgan_22b9a4_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation
(
       FactAsOfDate DATE NOT NULL,
       LocalCourseCode VARCHAR(60) NOT NULL,
       SchoolId INT NOT NULL,
       SchoolYear SMALLINT NOT NULL,
       SectionIdentifier VARCHAR(255) NOT NULL,
       SessionName VARCHAR(60) NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       TeacherCandidateStudentGrowthMeasureIdentifier VARCHAR(64) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateStudentGrowthMeasureSectionAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(255) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       TeacherCandidateIdentifier VARCHAR(32) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT TeacherCandidateTeacherPreparationProviderProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.ValueTypeDescriptor
(
       ValueTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ValueTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_tpdm.WithdrawReasonDescriptor
(
       WithdrawReasonDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT WithdrawReasonDescriptor_PK PRIMARY KEY (ChangeVersion)
);

