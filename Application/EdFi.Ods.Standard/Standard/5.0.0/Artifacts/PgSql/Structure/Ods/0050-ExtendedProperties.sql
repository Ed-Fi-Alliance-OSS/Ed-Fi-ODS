-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [edfi].[AbsenceEventCategoryDescriptor] --
COMMENT ON TABLE edfi.AbsenceEventCategoryDescriptor IS 'This descriptor describes the type of absence';
COMMENT ON COLUMN edfi.AbsenceEventCategoryDescriptor.AbsenceEventCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AcademicHonorCategoryDescriptor] --
COMMENT ON TABLE edfi.AcademicHonorCategoryDescriptor IS 'A designation of the type of academic distinctions earned by or awarded to the student.';
COMMENT ON COLUMN edfi.AcademicHonorCategoryDescriptor.AcademicHonorCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AcademicSubjectDescriptor] --
COMMENT ON TABLE edfi.AcademicSubjectDescriptor IS 'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).';
COMMENT ON COLUMN edfi.AcademicSubjectDescriptor.AcademicSubjectDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AcademicWeek] --
COMMENT ON TABLE edfi.AcademicWeek IS 'This entity represents the academic weeks for a school year, optionally captured to support analyses.';
COMMENT ON COLUMN edfi.AcademicWeek.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.AcademicWeek.WeekIdentifier IS 'The school label for the week.';
COMMENT ON COLUMN edfi.AcademicWeek.BeginDate IS 'The start date for the academic week.';
COMMENT ON COLUMN edfi.AcademicWeek.EndDate IS 'The end date for the academic week.';
COMMENT ON COLUMN edfi.AcademicWeek.TotalInstructionalDays IS 'The total instructional days during the academic week.';

-- Extended Properties [edfi].[AccommodationDescriptor] --
COMMENT ON TABLE edfi.AccommodationDescriptor IS 'This descriptor defines variations used in how an assessment is presented or taken.';
COMMENT ON COLUMN edfi.AccommodationDescriptor.AccommodationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AccountabilityRating] --
COMMENT ON TABLE edfi.AccountabilityRating IS 'An accountability rating for a school or district.';
COMMENT ON COLUMN edfi.AccountabilityRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.AccountabilityRating.RatingTitle IS 'The title of the rating.';
COMMENT ON COLUMN edfi.AccountabilityRating.SchoolYear IS 'The school year for which the accountability rating is assessed.';
COMMENT ON COLUMN edfi.AccountabilityRating.Rating IS 'An accountability rating level, designation, or assessment.';
COMMENT ON COLUMN edfi.AccountabilityRating.RatingDate IS 'The date the rating was awarded.';
COMMENT ON COLUMN edfi.AccountabilityRating.RatingOrganization IS 'The organization that assessed the rating.';
COMMENT ON COLUMN edfi.AccountabilityRating.RatingProgram IS 'The program associated with the accountability rating (e.g., NCLB, AEIS).';

-- Extended Properties [edfi].[AccountTypeDescriptor] --
COMMENT ON TABLE edfi.AccountTypeDescriptor IS 'The type of account used in accounting such as revenue, expenditure, or balance sheet.';
COMMENT ON COLUMN edfi.AccountTypeDescriptor.AccountTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AchievementCategoryDescriptor] --
COMMENT ON TABLE edfi.AchievementCategoryDescriptor IS 'This descriptor defines the category of achievement attributed to the learner.';
COMMENT ON COLUMN edfi.AchievementCategoryDescriptor.AchievementCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AdditionalCreditTypeDescriptor] --
COMMENT ON TABLE edfi.AdditionalCreditTypeDescriptor IS 'The type of additional credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.AdditionalCreditTypeDescriptor.AdditionalCreditTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AddressTypeDescriptor] --
COMMENT ON TABLE edfi.AddressTypeDescriptor IS 'The type of address listed for an individual or organization.';
COMMENT ON COLUMN edfi.AddressTypeDescriptor.AddressTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AdministrationEnvironmentDescriptor] --
COMMENT ON TABLE edfi.AdministrationEnvironmentDescriptor IS 'The environment in which the test was administered.';
COMMENT ON COLUMN edfi.AdministrationEnvironmentDescriptor.AdministrationEnvironmentDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AdministrativeFundingControlDescriptor] --
COMMENT ON TABLE edfi.AdministrativeFundingControlDescriptor IS 'This descriptor holds the type of education institution as classified by its funding source (e.g., public or private).';
COMMENT ON COLUMN edfi.AdministrativeFundingControlDescriptor.AdministrativeFundingControlDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AncestryEthnicOriginDescriptor] --
COMMENT ON TABLE edfi.AncestryEthnicOriginDescriptor IS 'The original peoples or cultures with which the individual identifies.';
COMMENT ON COLUMN edfi.AncestryEthnicOriginDescriptor.AncestryEthnicOriginDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Assessment] --
COMMENT ON TABLE edfi.Assessment IS 'This entity represents a tool, instrument, process, or exhibition composed of a systematic sampling of behavior for measuring a student''s competence, knowledge, skills, or behavior. An assessment can be used to measure differences in individuals or groups and changes in performance from one occasion to the next.';
COMMENT ON COLUMN edfi.Assessment.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.Assessment.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.Assessment.AssessmentTitle IS 'The title or name of the assessment.';
COMMENT ON COLUMN edfi.Assessment.AssessmentCategoryDescriptorId IS 'The category of an assessment based on format and content.';
COMMENT ON COLUMN edfi.Assessment.AssessmentForm IS 'Identifies the form of the assessment, for example a regular versus makeup form, multiple choice versus constructed response, etc.';
COMMENT ON COLUMN edfi.Assessment.AssessmentVersion IS 'The version identifier for the assessment.';
COMMENT ON COLUMN edfi.Assessment.RevisionDate IS 'The month, day, and year that the conceptual design for the assessment was most recently revised substantially.';
COMMENT ON COLUMN edfi.Assessment.MaxRawScore IS 'The maximum raw score achievable across all assessment items that are correct and scored at the maximum.';
COMMENT ON COLUMN edfi.Assessment.Nomenclature IS 'Reflects the specific nomenclature used for assessment.';
COMMENT ON COLUMN edfi.Assessment.AssessmentFamily IS 'The assessment family this assessment is a member of.';
COMMENT ON COLUMN edfi.Assessment.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.Assessment.AdaptiveAssessment IS 'Indicates that the assessment is adaptive.';

-- Extended Properties [edfi].[AssessmentAcademicSubject] --
COMMENT ON TABLE edfi.AssessmentAcademicSubject IS 'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.';
COMMENT ON COLUMN edfi.AssessmentAcademicSubject.AcademicSubjectDescriptorId IS 'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.';
COMMENT ON COLUMN edfi.AssessmentAcademicSubject.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentAcademicSubject.Namespace IS 'Namespace for the assessment.';

-- Extended Properties [edfi].[AssessmentAssessedGradeLevel] --
COMMENT ON TABLE edfi.AssessmentAssessedGradeLevel IS 'The grade level(s) for which an assessment is designed. The semantics of null is assumed to mean that the assessment is not associated with any grade level.';
COMMENT ON COLUMN edfi.AssessmentAssessedGradeLevel.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentAssessedGradeLevel.GradeLevelDescriptorId IS 'The grade level(s) for which an assessment is designed. The semantics of null is assumed to mean that the assessment is not associated with any grade level.';
COMMENT ON COLUMN edfi.AssessmentAssessedGradeLevel.Namespace IS 'Namespace for the assessment.';

-- Extended Properties [edfi].[AssessmentCategoryDescriptor] --
COMMENT ON TABLE edfi.AssessmentCategoryDescriptor IS 'This descriptor holds the category of an assessment based on format and content.';
COMMENT ON COLUMN edfi.AssessmentCategoryDescriptor.AssessmentCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AssessmentContentStandard] --
COMMENT ON TABLE edfi.AssessmentContentStandard IS 'An indication as to whether an assessment conforms to a standard (e.g., local standard, statewide standard, regional standard, association standard).';
COMMENT ON COLUMN edfi.AssessmentContentStandard.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.Title IS 'The name of the content standard, for example Common Core.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.Version IS 'The version identifier for the content.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.URI IS 'An unambiguous reference to the standards using a network-resolvable URI.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.PublicationDate IS 'The date on which this content was first published.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.PublicationYear IS 'The year at which this content was first published.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.PublicationStatusDescriptorId IS 'The publication status of the document (i.e., Adopted, Draft, Published, Deprecated, Unknown).';
COMMENT ON COLUMN edfi.AssessmentContentStandard.MandatingEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.BeginDate IS 'The beginning of the period during which this learning standard document is intended for use.';
COMMENT ON COLUMN edfi.AssessmentContentStandard.EndDate IS 'The end of the period during which this learning standard document is intended for use.';

-- Extended Properties [edfi].[AssessmentContentStandardAuthor] --
COMMENT ON TABLE edfi.AssessmentContentStandardAuthor IS 'The person or organization chiefly responsible for the intellectual content of the standard.';
COMMENT ON COLUMN edfi.AssessmentContentStandardAuthor.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentContentStandardAuthor.Author IS 'The person or organization chiefly responsible for the intellectual content of the standard.';
COMMENT ON COLUMN edfi.AssessmentContentStandardAuthor.Namespace IS 'Namespace for the assessment.';

-- Extended Properties [edfi].[AssessmentIdentificationCode] --
COMMENT ON TABLE edfi.AssessmentIdentificationCode IS 'A unique number or alphanumeric code assigned to an assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.AssessmentIdentificationCode.AssessmentIdentificationSystemDescriptorId IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to an assessment.';
COMMENT ON COLUMN edfi.AssessmentIdentificationCode.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentIdentificationCode.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code assigned to an assessment by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.AssessmentIdentificationCode.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the assessment identification code.';

-- Extended Properties [edfi].[AssessmentIdentificationSystemDescriptor] --
COMMENT ON TABLE edfi.AssessmentIdentificationSystemDescriptor IS 'This descriptor holds a coding scheme that is used for identification and record-keeping purposes by schools, social services or other agencies to refer to an assessment.';
COMMENT ON COLUMN edfi.AssessmentIdentificationSystemDescriptor.AssessmentIdentificationSystemDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AssessmentItem] --
COMMENT ON TABLE edfi.AssessmentItem IS 'This entity represents one of many single measures that make up an assessment.';
COMMENT ON COLUMN edfi.AssessmentItem.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentItem.IdentificationCode IS 'A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.AssessmentItem.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentItem.AssessmentItemCategoryDescriptorId IS 'Category or type of the assessment item.';
COMMENT ON COLUMN edfi.AssessmentItem.MaxRawScore IS 'The maximum raw score achievable across all assessment items that are correct and scored at the maximum.';
COMMENT ON COLUMN edfi.AssessmentItem.ItemText IS 'The text of the item.';
COMMENT ON COLUMN edfi.AssessmentItem.ExpectedTimeAssessed IS 'The duration of time allotted for the assessment item.';
COMMENT ON COLUMN edfi.AssessmentItem.Nomenclature IS 'Reflects the specific nomenclature used for assessment item.';
COMMENT ON COLUMN edfi.AssessmentItem.AssessmentItemURI IS 'The URI (typical a URL) pointing to the entry in an assessment item bank, which describes this content item.';

-- Extended Properties [edfi].[AssessmentItemCategoryDescriptor] --
COMMENT ON TABLE edfi.AssessmentItemCategoryDescriptor IS 'Category or type of the assessment item.';
COMMENT ON COLUMN edfi.AssessmentItemCategoryDescriptor.AssessmentItemCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AssessmentItemLearningStandard] --
COMMENT ON TABLE edfi.AssessmentItemLearningStandard IS 'Learning standard tested by this item.';
COMMENT ON COLUMN edfi.AssessmentItemLearningStandard.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentItemLearningStandard.IdentificationCode IS 'A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.AssessmentItemLearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.AssessmentItemLearningStandard.Namespace IS 'Namespace for the assessment.';

-- Extended Properties [edfi].[AssessmentItemPossibleResponse] --
COMMENT ON TABLE edfi.AssessmentItemPossibleResponse IS 'A possible response to an assessment item.';
COMMENT ON COLUMN edfi.AssessmentItemPossibleResponse.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentItemPossibleResponse.IdentificationCode IS 'A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.AssessmentItemPossibleResponse.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentItemPossibleResponse.ResponseValue IS 'The response value, often an option number or code value (e.g., 1, 2, A, B, true, false).';
COMMENT ON COLUMN edfi.AssessmentItemPossibleResponse.ResponseDescription IS 'Additional text provided to define the response value.';
COMMENT ON COLUMN edfi.AssessmentItemPossibleResponse.CorrectResponse IS 'Indicates the response is correct.';

-- Extended Properties [edfi].[AssessmentItemResultDescriptor] --
COMMENT ON TABLE edfi.AssessmentItemResultDescriptor IS 'The analyzed result of a student''s response to an assessment item.. For example:
    Correct
    Incorrect
    Met standard
    ...';
COMMENT ON COLUMN edfi.AssessmentItemResultDescriptor.AssessmentItemResultDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AssessmentLanguage] --
COMMENT ON TABLE edfi.AssessmentLanguage IS 'An indication of the languages in which the assessment is designed.';
COMMENT ON COLUMN edfi.AssessmentLanguage.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentLanguage.LanguageDescriptorId IS 'An indication of the languages in which the assessment is designed.';
COMMENT ON COLUMN edfi.AssessmentLanguage.Namespace IS 'Namespace for the assessment.';

-- Extended Properties [edfi].[AssessmentPerformanceLevel] --
COMMENT ON TABLE edfi.AssessmentPerformanceLevel IS 'Definition of the performance levels and the associated cut scores. Three styles are supported: 1. Specification of performance level by minimum and maximum score, 2. Specification of performance level by cut score, using only minimum score, 3. Specification of performance level without any mapping to scores.';
COMMENT ON COLUMN edfi.AssessmentPerformanceLevel.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentPerformanceLevel.AssessmentReportingMethodDescriptorId IS 'The method that the instructor of the class uses to report the performance and achievement of all students. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or numerical grade. In some cases, more than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.AssessmentPerformanceLevel.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentPerformanceLevel.PerformanceLevelDescriptorId IS 'The performance level(s) defined for the assessment.';
COMMENT ON COLUMN edfi.AssessmentPerformanceLevel.MinimumScore IS 'The minimum score required to make the indicated level of performance.';
COMMENT ON COLUMN edfi.AssessmentPerformanceLevel.MaximumScore IS 'The maximum score to make the indicated level of performance.';
COMMENT ON COLUMN edfi.AssessmentPerformanceLevel.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN edfi.AssessmentPerformanceLevel.PerformanceLevelIndicatorName IS 'The name of the indicator being measured for a collection of performance level values.';

-- Extended Properties [edfi].[AssessmentPeriod] --
COMMENT ON TABLE edfi.AssessmentPeriod IS 'The period or window in which an assessment is supposed to be administered.';
COMMENT ON COLUMN edfi.AssessmentPeriod.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentPeriod.AssessmentPeriodDescriptorId IS 'The period of time in which an assessment is supposed to be administered (e.g., Beginning of Year, Middle of Year, End of Year).';
COMMENT ON COLUMN edfi.AssessmentPeriod.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentPeriod.BeginDate IS 'The first date the assessment is to be administered.';
COMMENT ON COLUMN edfi.AssessmentPeriod.EndDate IS 'The last date the assessment is to be administered.';

-- Extended Properties [edfi].[AssessmentPeriodDescriptor] --
COMMENT ON TABLE edfi.AssessmentPeriodDescriptor IS 'This descriptor holds the period of time window in which an assessment is supposed to be administered.';
COMMENT ON COLUMN edfi.AssessmentPeriodDescriptor.AssessmentPeriodDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AssessmentPlatformType] --
COMMENT ON TABLE edfi.AssessmentPlatformType IS 'The platforms with which the assessment may be delivered.';
COMMENT ON COLUMN edfi.AssessmentPlatformType.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentPlatformType.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentPlatformType.PlatformTypeDescriptorId IS 'The platforms with which the assessment may be delivered.';

-- Extended Properties [edfi].[AssessmentProgram] --
COMMENT ON TABLE edfi.AssessmentProgram IS 'The programs associated with the assessment.';
COMMENT ON COLUMN edfi.AssessmentProgram.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.AssessmentProgram.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentProgram.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.AssessmentProgram.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [edfi].[AssessmentReportingMethodDescriptor] --
COMMENT ON TABLE edfi.AssessmentReportingMethodDescriptor IS 'This descriptor defines the method that the instructor of the class uses to report the performance and achievement of all students. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or a numerical grade.';
COMMENT ON COLUMN edfi.AssessmentReportingMethodDescriptor.AssessmentReportingMethodDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AssessmentScore] --
COMMENT ON TABLE edfi.AssessmentScore IS 'Definition of the scores to be expected from this assessment.';
COMMENT ON COLUMN edfi.AssessmentScore.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentScore.AssessmentReportingMethodDescriptorId IS 'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.AssessmentScore.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentScore.MinimumScore IS 'The minimum score possible on the assessment.';
COMMENT ON COLUMN edfi.AssessmentScore.MaximumScore IS 'The maximum score possible on the assessment.';
COMMENT ON COLUMN edfi.AssessmentScore.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [edfi].[AssessmentScoreRangeLearningStandard] --
COMMENT ON TABLE edfi.AssessmentScoreRangeLearningStandard IS 'Score ranges of an assessment associated with one or more learning standards.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandard.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandard.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandard.ScoreRangeId IS 'A unique number or alphanumeric code assigned to the score range associated with one or more learning standards.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandard.AssessmentReportingMethodDescriptorId IS 'The assessment reporting method defined (e.g., scale score, RIT scale score) associated with the referenced learning standard(s).';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandard.MinimumScore IS 'The minimum score in the score range.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandard.MaximumScore IS 'The maximum score in the score range.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandard.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';

-- Extended Properties [edfi].[AssessmentScoreRangeLearningStandardLearningStandard] --
COMMENT ON TABLE edfi.AssessmentScoreRangeLearningStandardLearningStandard IS 'Learning standard associated with the score range.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandardLearningStandard.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandardLearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandardLearningStandard.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentScoreRangeLearningStandardLearningStandard.ScoreRangeId IS 'A unique number or alphanumeric code assigned to the score range associated with one or more learning standards.';

-- Extended Properties [edfi].[AssessmentSection] --
COMMENT ON TABLE edfi.AssessmentSection IS 'The Section(s) to which the assessment is associated.';
COMMENT ON COLUMN edfi.AssessmentSection.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.AssessmentSection.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.AssessmentSection.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.AssessmentSection.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.AssessmentSection.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.AssessmentSection.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.AssessmentSection.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[AssignmentLateStatusDescriptor] --
COMMENT ON TABLE edfi.AssignmentLateStatusDescriptor IS 'Status of whether the assignment was submitted after the due date and/or marked as late.';
COMMENT ON COLUMN edfi.AssignmentLateStatusDescriptor.AssignmentLateStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AttemptStatusDescriptor] --
COMMENT ON TABLE edfi.AttemptStatusDescriptor IS 'This descriptor describes a student''s completion status for a section.';
COMMENT ON COLUMN edfi.AttemptStatusDescriptor.AttemptStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[AttendanceEventCategoryDescriptor] --
COMMENT ON TABLE edfi.AttendanceEventCategoryDescriptor IS 'This descriptor holds the category of the attendance event (e.g., tardy). The map to known enumeration values is required.';
COMMENT ON COLUMN edfi.AttendanceEventCategoryDescriptor.AttendanceEventCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[BalanceSheetDimension] --
COMMENT ON TABLE edfi.BalanceSheetDimension IS 'The NCES balance sheet accounting dimension, used to track financial transactions for each fund. These financial statements only report assets, deferred outflows of resources, liabilities, deferred inflows of resources, and equity accounts. The statements are considered snapshots of how these accounts stand as of a certain point in time.';
COMMENT ON COLUMN edfi.BalanceSheetDimension.Code IS 'The code representation of the account balance sheet dimension.';
COMMENT ON COLUMN edfi.BalanceSheetDimension.FiscalYear IS 'The fiscal year for which the account balance sheet dimension is valid.';
COMMENT ON COLUMN edfi.BalanceSheetDimension.CodeName IS 'A description of the account balance sheet dimension.';

-- Extended Properties [edfi].[BalanceSheetDimensionReportingTag] --
COMMENT ON TABLE edfi.BalanceSheetDimensionReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.BalanceSheetDimensionReportingTag.Code IS 'The code representation of the account balance sheet dimension.';
COMMENT ON COLUMN edfi.BalanceSheetDimensionReportingTag.FiscalYear IS 'The fiscal year for which the account balance sheet dimension is valid.';
COMMENT ON COLUMN edfi.BalanceSheetDimensionReportingTag.ReportingTagDescriptorId IS 'Optional tag for accountability reporting.';

-- Extended Properties [edfi].[BarrierToInternetAccessInResidenceDescriptor] --
COMMENT ON TABLE edfi.BarrierToInternetAccessInResidenceDescriptor IS 'An indication of the barrier to having internet access in the student’s primary place of residence.';
COMMENT ON COLUMN edfi.BarrierToInternetAccessInResidenceDescriptor.BarrierToInternetAccessInResidenceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[BehaviorDescriptor] --
COMMENT ON TABLE edfi.BehaviorDescriptor IS 'This descriptor holds the categories of behavior describing a discipline incident.';
COMMENT ON COLUMN edfi.BehaviorDescriptor.BehaviorDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[BellSchedule] --
COMMENT ON TABLE edfi.BellSchedule IS 'This entity represents the schedule of class period meeting times.';
COMMENT ON COLUMN edfi.BellSchedule.BellScheduleName IS 'Name or title of the bell schedule.';
COMMENT ON COLUMN edfi.BellSchedule.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.BellSchedule.AlternateDayName IS 'An alternate name for the day (e.g., Red, Blue).';
COMMENT ON COLUMN edfi.BellSchedule.StartTime IS 'An indication of the time of day the bell schedule begins.';
COMMENT ON COLUMN edfi.BellSchedule.EndTime IS 'An indication of the time of day the bell schedule ends.';
COMMENT ON COLUMN edfi.BellSchedule.TotalInstructionalTime IS 'The total instructional time in minutes per day for the bell schedule.';

-- Extended Properties [edfi].[BellScheduleClassPeriod] --
COMMENT ON TABLE edfi.BellScheduleClassPeriod IS 'The class periods that compose this bell schedule.';
COMMENT ON COLUMN edfi.BellScheduleClassPeriod.BellScheduleName IS 'Name or title of the bell schedule.';
COMMENT ON COLUMN edfi.BellScheduleClassPeriod.ClassPeriodName IS 'An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).';
COMMENT ON COLUMN edfi.BellScheduleClassPeriod.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [edfi].[BellScheduleDate] --
COMMENT ON TABLE edfi.BellScheduleDate IS 'The dates for which the bell schedule applies.';
COMMENT ON COLUMN edfi.BellScheduleDate.BellScheduleName IS 'Name or title of the bell schedule.';
COMMENT ON COLUMN edfi.BellScheduleDate.Date IS 'The dates for which the bell schedule applies.';
COMMENT ON COLUMN edfi.BellScheduleDate.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [edfi].[BellScheduleGradeLevel] --
COMMENT ON TABLE edfi.BellScheduleGradeLevel IS 'The grade levels the particular bell schedule applies to.';
COMMENT ON COLUMN edfi.BellScheduleGradeLevel.BellScheduleName IS 'Name or title of the bell schedule.';
COMMENT ON COLUMN edfi.BellScheduleGradeLevel.GradeLevelDescriptorId IS 'The grade levels the particular bell schedule applies to.';
COMMENT ON COLUMN edfi.BellScheduleGradeLevel.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [edfi].[Calendar] --
COMMENT ON TABLE edfi.Calendar IS 'A set of dates associated with an organization.';
COMMENT ON COLUMN edfi.Calendar.CalendarCode IS 'The identifier for the calendar.';
COMMENT ON COLUMN edfi.Calendar.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.Calendar.SchoolYear IS 'The identifier for the school year associated with the calendar.';
COMMENT ON COLUMN edfi.Calendar.CalendarTypeDescriptorId IS 'Indicates the type of calendar.';

-- Extended Properties [edfi].[CalendarDate] --
COMMENT ON TABLE edfi.CalendarDate IS 'The type of scheduled or unscheduled event for the day.';
COMMENT ON COLUMN edfi.CalendarDate.CalendarCode IS 'The identifier for the calendar.';
COMMENT ON COLUMN edfi.CalendarDate.Date IS 'The month, day, and year of the calendar event.';
COMMENT ON COLUMN edfi.CalendarDate.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.CalendarDate.SchoolYear IS 'The identifier for the school year associated with the calendar.';

-- Extended Properties [edfi].[CalendarDateCalendarEvent] --
COMMENT ON TABLE edfi.CalendarDateCalendarEvent IS 'The type of scheduled or unscheduled event for the day.';
COMMENT ON COLUMN edfi.CalendarDateCalendarEvent.CalendarCode IS 'The identifier for the calendar.';
COMMENT ON COLUMN edfi.CalendarDateCalendarEvent.CalendarEventDescriptorId IS 'The type of scheduled or unscheduled event for the day.';
COMMENT ON COLUMN edfi.CalendarDateCalendarEvent.Date IS 'The month, day, and year of the calendar event.';
COMMENT ON COLUMN edfi.CalendarDateCalendarEvent.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.CalendarDateCalendarEvent.SchoolYear IS 'The identifier for the school year associated with the calendar.';

-- Extended Properties [edfi].[CalendarEventDescriptor] --
COMMENT ON TABLE edfi.CalendarEventDescriptor IS 'This descriptor holds the types of scheduled or unscheduled event for the day (e.g., Instructional day, Teacher only day, Holiday, Make-up day, Weather day, Student late arrival/early dismissal day).';
COMMENT ON COLUMN edfi.CalendarEventDescriptor.CalendarEventDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CalendarGradeLevel] --
COMMENT ON TABLE edfi.CalendarGradeLevel IS 'Indicates the grade level associated with the calendar.';
COMMENT ON COLUMN edfi.CalendarGradeLevel.CalendarCode IS 'The identifier for the calendar.';
COMMENT ON COLUMN edfi.CalendarGradeLevel.GradeLevelDescriptorId IS 'Indicates the grade level associated with the calendar.';
COMMENT ON COLUMN edfi.CalendarGradeLevel.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.CalendarGradeLevel.SchoolYear IS 'The identifier for the school year associated with the calendar.';

-- Extended Properties [edfi].[CalendarTypeDescriptor] --
COMMENT ON TABLE edfi.CalendarTypeDescriptor IS 'This descriptor defines the calendar types.';
COMMENT ON COLUMN edfi.CalendarTypeDescriptor.CalendarTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CareerPathwayDescriptor] --
COMMENT ON TABLE edfi.CareerPathwayDescriptor IS 'The career cluster or pathway representing the career path of the Vocational/Career Tech concentrator.';
COMMENT ON COLUMN edfi.CareerPathwayDescriptor.CareerPathwayDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CharterApprovalAgencyTypeDescriptor] --
COMMENT ON TABLE edfi.CharterApprovalAgencyTypeDescriptor IS 'The type of agency that approved the establishment or continuation of a charter school.';
COMMENT ON COLUMN edfi.CharterApprovalAgencyTypeDescriptor.CharterApprovalAgencyTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CharterStatusDescriptor] --
COMMENT ON TABLE edfi.CharterStatusDescriptor IS 'The category of charter school. For example: School Charter, Open Enrollment Charter.';
COMMENT ON COLUMN edfi.CharterStatusDescriptor.CharterStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ChartOfAccount] --
COMMENT ON TABLE edfi.ChartOfAccount IS 'A valid combination of account dimensions under which financials are reported. This financial entity represents a funding source combined with its purpose and type of transaction. It provides a formal record of the debits and credits relating to the specific account.';
COMMENT ON COLUMN edfi.ChartOfAccount.AccountIdentifier IS 'SEA populated code value for the valid combination of account dimensions under which financials are reported.';
COMMENT ON COLUMN edfi.ChartOfAccount.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ChartOfAccount.FiscalYear IS 'The fiscal year for the account';
COMMENT ON COLUMN edfi.ChartOfAccount.AccountTypeDescriptorId IS 'The type of account used in accounting such as revenue, expenditure, or balance sheet.';
COMMENT ON COLUMN edfi.ChartOfAccount.AccountName IS 'A descriptive name for the account.';
COMMENT ON COLUMN edfi.ChartOfAccount.BalanceSheetCode IS 'The code representation of the account balance sheet dimension.';
COMMENT ON COLUMN edfi.ChartOfAccount.FunctionCode IS 'The code representation of the account function dimension.';
COMMENT ON COLUMN edfi.ChartOfAccount.FundCode IS 'The code representation of the account fund dimension.';
COMMENT ON COLUMN edfi.ChartOfAccount.ObjectCode IS 'The code representation of the account object dimension.';
COMMENT ON COLUMN edfi.ChartOfAccount.OperationalUnitCode IS 'The code representation of the account operational unit dimension.';
COMMENT ON COLUMN edfi.ChartOfAccount.ProgramCode IS 'The code representation of the account program dimension.';
COMMENT ON COLUMN edfi.ChartOfAccount.ProjectCode IS 'The code representation of the account project dimension.';
COMMENT ON COLUMN edfi.ChartOfAccount.SourceCode IS 'The code representation of the account source dimension.';

-- Extended Properties [edfi].[ChartOfAccountReportingTag] --
COMMENT ON TABLE edfi.ChartOfAccountReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.ChartOfAccountReportingTag.AccountIdentifier IS 'SEA populated code value for the valid combination of account dimensions under which financials are reported.';
COMMENT ON COLUMN edfi.ChartOfAccountReportingTag.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ChartOfAccountReportingTag.FiscalYear IS 'The fiscal year for the account';
COMMENT ON COLUMN edfi.ChartOfAccountReportingTag.ReportingTagDescriptorId IS 'A descriptor used at the dimension and/or chart of account levels to demote specific state needs for reporting.';
COMMENT ON COLUMN edfi.ChartOfAccountReportingTag.TagValue IS 'The value associated with the reporting tag.';

-- Extended Properties [edfi].[CitizenshipStatusDescriptor] --
COMMENT ON TABLE edfi.CitizenshipStatusDescriptor IS 'An indicator of whether or not the person is a U.S. citizen.';
COMMENT ON COLUMN edfi.CitizenshipStatusDescriptor.CitizenshipStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ClassPeriod] --
COMMENT ON TABLE edfi.ClassPeriod IS 'This entity represents the designation of a regularly scheduled series of class meetings at designated times and days of the week.';
COMMENT ON COLUMN edfi.ClassPeriod.ClassPeriodName IS 'An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).';
COMMENT ON COLUMN edfi.ClassPeriod.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.ClassPeriod.OfficialAttendancePeriod IS 'Indicator of whether this class period is used for official daily attendance. Alternatively, official daily attendance may be tied to a section.';

-- Extended Properties [edfi].[ClassPeriodMeetingTime] --
COMMENT ON TABLE edfi.ClassPeriodMeetingTime IS 'The meeting time(s) for a class period.';
COMMENT ON COLUMN edfi.ClassPeriodMeetingTime.ClassPeriodName IS 'An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).';
COMMENT ON COLUMN edfi.ClassPeriodMeetingTime.EndTime IS 'An indication of the time of day the meeting time ends.';
COMMENT ON COLUMN edfi.ClassPeriodMeetingTime.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.ClassPeriodMeetingTime.StartTime IS 'An indication of the time of day the meeting time begins.';

-- Extended Properties [edfi].[ClassroomPositionDescriptor] --
COMMENT ON TABLE edfi.ClassroomPositionDescriptor IS 'This descriptor defines the type of position the staff member holds in a specific class/section.';
COMMENT ON COLUMN edfi.ClassroomPositionDescriptor.ClassroomPositionDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Cohort] --
COMMENT ON TABLE edfi.Cohort IS 'This entity represents any type of list of designated students for tracking, analysis, or intervention.';
COMMENT ON COLUMN edfi.Cohort.CohortIdentifier IS 'The name or ID for the cohort.';
COMMENT ON COLUMN edfi.Cohort.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.Cohort.CohortDescription IS 'The description of the cohort and its purpose.';
COMMENT ON COLUMN edfi.Cohort.CohortTypeDescriptorId IS 'The type of cohort (e.g., academic intervention, classroom breakout).';
COMMENT ON COLUMN edfi.Cohort.CohortScopeDescriptorId IS 'The scope of cohort (e.g., school, district, classroom).';
COMMENT ON COLUMN edfi.Cohort.AcademicSubjectDescriptorId IS 'The academic subject associated with an academic intervention.';

-- Extended Properties [edfi].[CohortProgram] --
COMMENT ON TABLE edfi.CohortProgram IS 'The (optional) program associated with this cohort (e.g., special education).';
COMMENT ON COLUMN edfi.CohortProgram.CohortIdentifier IS 'The name or ID for the cohort.';
COMMENT ON COLUMN edfi.CohortProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CohortProgram.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CohortProgram.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.CohortProgram.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [edfi].[CohortScopeDescriptor] --
COMMENT ON TABLE edfi.CohortScopeDescriptor IS 'The scope of cohort (e.g., school, district, classroom).';
COMMENT ON COLUMN edfi.CohortScopeDescriptor.CohortScopeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CohortTypeDescriptor] --
COMMENT ON TABLE edfi.CohortTypeDescriptor IS 'The type of the cohort (e.g., academic intervention, classroom breakout).';
COMMENT ON COLUMN edfi.CohortTypeDescriptor.CohortTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CohortYearTypeDescriptor] --
COMMENT ON TABLE edfi.CohortYearTypeDescriptor IS 'The enumeration items for the set of cohort years.';
COMMENT ON COLUMN edfi.CohortYearTypeDescriptor.CohortYearTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CommunityOrganization] --
COMMENT ON TABLE edfi.CommunityOrganization IS 'This entity represents an administrative unit at the state level which exists primarily to operate local community providers.';
COMMENT ON COLUMN edfi.CommunityOrganization.CommunityOrganizationId IS 'The identifier assigned to a community organization.';

-- Extended Properties [edfi].[CommunityProvider] --
COMMENT ON TABLE edfi.CommunityProvider IS 'This entity represents an educational organization that includes staff and students who participate in classes and educational activity groups.';
COMMENT ON COLUMN edfi.CommunityProvider.CommunityProviderId IS 'The identifier assigned to a community provider.';
COMMENT ON COLUMN edfi.CommunityProvider.CommunityOrganizationId IS 'The identifier assigned to a community organization.';
COMMENT ON COLUMN edfi.CommunityProvider.ProviderProfitabilityDescriptorId IS 'Indicates the profitability status of the provider.';
COMMENT ON COLUMN edfi.CommunityProvider.ProviderStatusDescriptorId IS 'Indicates the status of the provider.';
COMMENT ON COLUMN edfi.CommunityProvider.ProviderCategoryDescriptorId IS 'Indicates the category of the provider.';
COMMENT ON COLUMN edfi.CommunityProvider.SchoolIndicator IS 'An indication of whether the community provider is a school.';
COMMENT ON COLUMN edfi.CommunityProvider.LicenseExemptIndicator IS 'An indication of whether the provider is exempt from having a license.';

-- Extended Properties [edfi].[CommunityProviderLicense] --
COMMENT ON TABLE edfi.CommunityProviderLicense IS 'The legal document held by the community provider that authorizes the holder to perform certain functions and or services.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.CommunityProviderId IS 'The identifier assigned to a community provider.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.LicenseIdentifier IS 'The unique identifier issued by the licensing organization.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.LicensingOrganization IS 'The organization issuing the license.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.LicenseEffectiveDate IS 'The month, day, and year on which a license is active or becomes effective.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.LicenseExpirationDate IS 'The month, day, and year on which a license will expire.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.LicenseIssueDate IS 'The month, day, and year on which an active license was issued.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.LicenseStatusDescriptorId IS 'An indication of the status of the license.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.LicenseTypeDescriptorId IS 'An indication of the category of the license.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.AuthorizedFacilityCapacity IS 'The maximum number that can be contained or accommodated which a provider is authorized or licensed to serve.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.OldestAgeAuthorizedToServe IS 'The oldest age of children a provider is authorized or licensed to serve.';
COMMENT ON COLUMN edfi.CommunityProviderLicense.YoungestAgeAuthorizedToServe IS 'The youngest age of children a provider is authorized or licensed to serve.';

-- Extended Properties [edfi].[CompetencyLevelDescriptor] --
COMMENT ON TABLE edfi.CompetencyLevelDescriptor IS 'This descriptor defines various levels for assessed competencies.';
COMMENT ON COLUMN edfi.CompetencyLevelDescriptor.CompetencyLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CompetencyObjective] --
COMMENT ON TABLE edfi.CompetencyObjective IS 'This entity holds additional competencies for student achievement that are not associated with specific learning objectives (e.g., paying attention in class).';
COMMENT ON COLUMN edfi.CompetencyObjective.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CompetencyObjective.Objective IS 'The designated title of the competency objective.';
COMMENT ON COLUMN edfi.CompetencyObjective.ObjectiveGradeLevelDescriptorId IS 'The grade level for which the competency objective is targeted.';
COMMENT ON COLUMN edfi.CompetencyObjective.CompetencyObjectiveId IS 'The Identifier for the competency objective.';
COMMENT ON COLUMN edfi.CompetencyObjective.Description IS 'The description of the student competency objective.';
COMMENT ON COLUMN edfi.CompetencyObjective.SuccessCriteria IS 'One or more statements that describes the criteria used by teachers and students to check for attainment of a competency objective. This criteria gives clear indications as to the degree to which learning is moving through the Zone or Proximal Development toward independent achievement of the competency objective.';

-- Extended Properties [edfi].[ContactTypeDescriptor] --
COMMENT ON TABLE edfi.ContactTypeDescriptor IS 'This descriptor defines the set of contact types.';
COMMENT ON COLUMN edfi.ContactTypeDescriptor.ContactTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ContentClassDescriptor] --
COMMENT ON TABLE edfi.ContentClassDescriptor IS 'The predominate type or kind characterizing the learning resource.';
COMMENT ON COLUMN edfi.ContentClassDescriptor.ContentClassDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ContinuationOfServicesReasonDescriptor] --
COMMENT ON TABLE edfi.ContinuationOfServicesReasonDescriptor IS 'In the Migrant Education program, a provision allows continuation of services after a child is no longer considered migratory for certain reasons. This descriptor holds the reasons prescribed in the statute. The mapping of descriptor values to known Ed-Fi enumeration values is required.';
COMMENT ON COLUMN edfi.ContinuationOfServicesReasonDescriptor.ContinuationOfServicesReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CostRateDescriptor] --
COMMENT ON TABLE edfi.CostRateDescriptor IS 'The rate by which a cost applies (e.g. $1 per student).';
COMMENT ON COLUMN edfi.CostRateDescriptor.CostRateDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CountryDescriptor] --
COMMENT ON TABLE edfi.CountryDescriptor IS 'This descriptor defines the name and code of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN edfi.CountryDescriptor.CountryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Course] --
COMMENT ON TABLE edfi.Course IS 'This educational entity represents the organization of subject matter and related learning experiences provided for the instruction of students on a regular or systematic basis.';
COMMENT ON COLUMN edfi.Course.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.Course.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.Course.CourseTitle IS 'The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, and language arts).';
COMMENT ON COLUMN edfi.Course.NumberOfParts IS 'The number of parts identified for a course.';
COMMENT ON COLUMN edfi.Course.AcademicSubjectDescriptorId IS 'The intended major subject area of the course.';
COMMENT ON COLUMN edfi.Course.CourseDescription IS 'A description of the content standards and goals covered in the course. Reference may be made to state or national content standards.';
COMMENT ON COLUMN edfi.Course.TimeRequiredForCompletion IS 'The actual or estimated number of clock minutes required for class completion. This number is especially important for career and technical education classes and may represent (in minutes) the clock hour requirement of the class.';
COMMENT ON COLUMN edfi.Course.DateCourseAdopted IS 'Date the course was adopted by the education agency.';
COMMENT ON COLUMN edfi.Course.HighSchoolCourseRequirement IS 'An indication that this course may satisfy high school graduation requirements in the course''s subject area.';
COMMENT ON COLUMN edfi.Course.CourseGPAApplicabilityDescriptorId IS 'An indicator of whether or not the course being described is included in the computation of the student''s grade point average, and if so, if it is weighted differently from regular courses.';
COMMENT ON COLUMN edfi.Course.CourseDefinedByDescriptorId IS 'Specifies whether the course was defined by the SEA, LEA, School, or national organization.';
COMMENT ON COLUMN edfi.Course.MinimumAvailableCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.Course.MinimumAvailableCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.Course.MinimumAvailableCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.Course.MaximumAvailableCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.Course.MaximumAvailableCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.Course.MaximumAvailableCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.Course.CareerPathwayDescriptorId IS 'Indicates the career cluster or pathway the course is associated with as part of a CTE curriculum.';
COMMENT ON COLUMN edfi.Course.MaxCompletionsForCredit IS 'Designates how many times the course may be taken with credit received by the student.';

-- Extended Properties [edfi].[CourseAttemptResultDescriptor] --
COMMENT ON TABLE edfi.CourseAttemptResultDescriptor IS 'The result from the student''s attempt to take the course.';
COMMENT ON COLUMN edfi.CourseAttemptResultDescriptor.CourseAttemptResultDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CourseCompetencyLevel] --
COMMENT ON TABLE edfi.CourseCompetencyLevel IS 'The competency levels defined to rate the student for the course.';
COMMENT ON COLUMN edfi.CourseCompetencyLevel.CompetencyLevelDescriptorId IS 'The competency levels defined to rate the student for the course.';
COMMENT ON COLUMN edfi.CourseCompetencyLevel.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseCompetencyLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';

-- Extended Properties [edfi].[CourseDefinedByDescriptor] --
COMMENT ON TABLE edfi.CourseDefinedByDescriptor IS 'Specifies whether the course was defined by the state education agency, local education agency, school, or national organization.';
COMMENT ON COLUMN edfi.CourseDefinedByDescriptor.CourseDefinedByDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CourseGPAApplicabilityDescriptor] --
COMMENT ON TABLE edfi.CourseGPAApplicabilityDescriptor IS 'An indicator of whether or not this course being described is included in the computation of the student''s Grade Point Average, and if so, if it is weighted differently than regular courses.';
COMMENT ON COLUMN edfi.CourseGPAApplicabilityDescriptor.CourseGPAApplicabilityDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CourseIdentificationCode] --
COMMENT ON TABLE edfi.CourseIdentificationCode IS 'The code that identifies the organization of subject matter and related learning experiences provided for the instruction of students.';
COMMENT ON COLUMN edfi.CourseIdentificationCode.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseIdentificationCode.CourseIdentificationSystemDescriptorId IS 'A system that is used to identify the organization of subject matter and related learning experiences provided for the instruction of students.';
COMMENT ON COLUMN edfi.CourseIdentificationCode.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code assigned to a course by a school, school system, state, or other agency or entity. For multi-part course codes, concatenate the parts separated by a "/". For example, consider the following SCED code-    subject = 20 Math    course = 272 Geometry    level = G General    credits = 1.00   course sequence 1 of 1- would be entered as 20/272/G/1.00/1 of 1.';
COMMENT ON COLUMN edfi.CourseIdentificationCode.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the Identification Code.';
COMMENT ON COLUMN edfi.CourseIdentificationCode.CourseCatalogURL IS 'The URL for the course catalog that defines the course identification code.';

-- Extended Properties [edfi].[CourseIdentificationSystemDescriptor] --
COMMENT ON TABLE edfi.CourseIdentificationSystemDescriptor IS 'This descriptor defines a standard code that identifies the organization of subject matter and related learning experiences provided for the instruction of students.';
COMMENT ON COLUMN edfi.CourseIdentificationSystemDescriptor.CourseIdentificationSystemDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CourseLearningObjective] --
COMMENT ON TABLE edfi.CourseLearningObjective IS 'Learning objectives to be mastered in the course.';
COMMENT ON COLUMN edfi.CourseLearningObjective.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseLearningObjective.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseLearningObjective.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.CourseLearningObjective.Namespace IS 'Namespace for the learning objective.';

-- Extended Properties [edfi].[CourseLearningStandard] --
COMMENT ON TABLE edfi.CourseLearningStandard IS 'Learning standard(s) to be taught by the course.';
COMMENT ON COLUMN edfi.CourseLearningStandard.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseLearningStandard.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseLearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';

-- Extended Properties [edfi].[CourseLevelCharacteristic] --
COMMENT ON TABLE edfi.CourseLevelCharacteristic IS 'The type of specific program or designation with which the course is associated (e.g., AP, IB, Dual Credit, CTE).';
COMMENT ON COLUMN edfi.CourseLevelCharacteristic.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseLevelCharacteristic.CourseLevelCharacteristicDescriptorId IS 'The type of specific program or designation with which the course is associated (e.g., AP, IB, Dual Credit, CTE).';
COMMENT ON COLUMN edfi.CourseLevelCharacteristic.EducationOrganizationId IS 'The identifier assigned to an education organization.';

-- Extended Properties [edfi].[CourseLevelCharacteristicDescriptor] --
COMMENT ON TABLE edfi.CourseLevelCharacteristicDescriptor IS 'The item for indication of the nature and difficulty of instruction: Remedial, Basic, Honors, Ap, IB, Dual Credit, CTE. etc.';
COMMENT ON COLUMN edfi.CourseLevelCharacteristicDescriptor.CourseLevelCharacteristicDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CourseOfferedGradeLevel] --
COMMENT ON TABLE edfi.CourseOfferedGradeLevel IS 'The grade levels in which the course is offered.';
COMMENT ON COLUMN edfi.CourseOfferedGradeLevel.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseOfferedGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseOfferedGradeLevel.GradeLevelDescriptorId IS 'The grade levels in which the course is offered.';

-- Extended Properties [edfi].[CourseOffering] --
COMMENT ON TABLE edfi.CourseOffering IS 'This entity represents an entry in the course catalog of available courses offered by the school during a session.';
COMMENT ON COLUMN edfi.CourseOffering.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.CourseOffering.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.CourseOffering.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseOffering.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.CourseOffering.LocalCourseTitle IS 'The descriptive name given to a course of study offered in the school, if different from the course title.';
COMMENT ON COLUMN edfi.CourseOffering.InstructionalTimePlanned IS 'The planned total number of clock minutes of instruction for this course offering. Generally, this should be at least as many minutes as is required for completion by the related state- or district-defined course.';
COMMENT ON COLUMN edfi.CourseOffering.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseOffering.EducationOrganizationId IS 'The identifier assigned to an education organization.';

-- Extended Properties [edfi].[CourseOfferingCourseLevelCharacteristic] --
COMMENT ON TABLE edfi.CourseOfferingCourseLevelCharacteristic IS 'The type of specific program or designation with which the course offering is associated (e.g., AP, IB, Dual Credit, CTE). This collection should only be populated if it differs from the course level characteristics identified at the course level.';
COMMENT ON COLUMN edfi.CourseOfferingCourseLevelCharacteristic.CourseLevelCharacteristicDescriptorId IS 'The type of specific program or designation with which the course offering is associated (e.g., AP, IB, Dual Credit, CTE). This collection should only be populated if it differs from the course level characteristics identified at the course level.';
COMMENT ON COLUMN edfi.CourseOfferingCourseLevelCharacteristic.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.CourseOfferingCourseLevelCharacteristic.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.CourseOfferingCourseLevelCharacteristic.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseOfferingCourseLevelCharacteristic.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[CourseOfferingCurriculumUsed] --
COMMENT ON TABLE edfi.CourseOfferingCurriculumUsed IS 'The type of curriculum used in an early learning classroom or group.';
COMMENT ON COLUMN edfi.CourseOfferingCurriculumUsed.CurriculumUsedDescriptorId IS 'The type of curriculum used in an early learning classroom or group.';
COMMENT ON COLUMN edfi.CourseOfferingCurriculumUsed.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.CourseOfferingCurriculumUsed.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.CourseOfferingCurriculumUsed.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseOfferingCurriculumUsed.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[CourseOfferingOfferedGradeLevel] --
COMMENT ON TABLE edfi.CourseOfferingOfferedGradeLevel IS 'The grade levels in which the course is offered. This collection should only be populated if it differs from the offered grade levels identified at the course level.';
COMMENT ON COLUMN edfi.CourseOfferingOfferedGradeLevel.GradeLevelDescriptorId IS 'The grade levels in which the course is offered. This collection should only be populated if it differs from the offered grade levels identified at the course level.';
COMMENT ON COLUMN edfi.CourseOfferingOfferedGradeLevel.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.CourseOfferingOfferedGradeLevel.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.CourseOfferingOfferedGradeLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseOfferingOfferedGradeLevel.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[CourseRepeatCodeDescriptor] --
COMMENT ON TABLE edfi.CourseRepeatCodeDescriptor IS 'Indicates that an academic course has been repeated by a student and how that repeat is to be computed in the student''s academic grade average.';
COMMENT ON COLUMN edfi.CourseRepeatCodeDescriptor.CourseRepeatCodeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CourseTranscript] --
COMMENT ON TABLE edfi.CourseTranscript IS 'This entity is the final record of a student''s performance in their courses at the end of a semester or school year.';
COMMENT ON COLUMN edfi.CourseTranscript.CourseAttemptResultDescriptorId IS 'The result from the student''s attempt to take the course.';
COMMENT ON COLUMN edfi.CourseTranscript.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseTranscript.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscript.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscript.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseTranscript.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.CourseTranscript.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.CourseTranscript.AttemptedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.CourseTranscript.AttemptedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.CourseTranscript.AttemptedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.CourseTranscript.EarnedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.CourseTranscript.EarnedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.CourseTranscript.EarnedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.CourseTranscript.WhenTakenGradeLevelDescriptorId IS 'Student''s grade level at time of course.';
COMMENT ON COLUMN edfi.CourseTranscript.MethodCreditEarnedDescriptorId IS 'The method the credits were earned.';
COMMENT ON COLUMN edfi.CourseTranscript.FinalLetterGradeEarned IS 'The final indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN edfi.CourseTranscript.FinalNumericGradeEarned IS 'The final indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN edfi.CourseTranscript.CourseRepeatCodeDescriptorId IS 'Indicates that an academic course has been repeated by a student and how that repeat is to be computed in the student''s academic grade average.';
COMMENT ON COLUMN edfi.CourseTranscript.CourseTitle IS 'The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, language arts).';
COMMENT ON COLUMN edfi.CourseTranscript.AlternativeCourseTitle IS 'The descriptive name given to a course of study offered in the school, if different from the CourseTitle.';
COMMENT ON COLUMN edfi.CourseTranscript.AlternativeCourseCode IS 'The local code assigned by the school that identifies the course offering, the code from an external educational organization, or other alternate course code.';
COMMENT ON COLUMN edfi.CourseTranscript.ExternalEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscript.ExternalEducationOrganizationNameOfInstitution IS 'Name of the external institution where the student completed the course; to be used only when the reference external education organization is not available.';
COMMENT ON COLUMN edfi.CourseTranscript.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the course identification code.';
COMMENT ON COLUMN edfi.CourseTranscript.CourseCatalogURL IS 'The URL for the course catalog that defines the course identification code.';

-- Extended Properties [edfi].[CourseTranscriptAcademicSubject] --
COMMENT ON TABLE edfi.CourseTranscriptAcademicSubject IS 'The subject area for the course transcript credits awarded in the course transcript.';
COMMENT ON COLUMN edfi.CourseTranscriptAcademicSubject.AcademicSubjectDescriptorId IS 'The subject area for the course transcript credits awarded in the course transcript.';
COMMENT ON COLUMN edfi.CourseTranscriptAcademicSubject.CourseAttemptResultDescriptorId IS 'The result from the student''s attempt to take the course.';
COMMENT ON COLUMN edfi.CourseTranscriptAcademicSubject.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseTranscriptAcademicSubject.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptAcademicSubject.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptAcademicSubject.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseTranscriptAcademicSubject.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.CourseTranscriptAcademicSubject.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [edfi].[CourseTranscriptAlternativeCourseIdentificationCode] --
COMMENT ON TABLE edfi.CourseTranscriptAlternativeCourseIdentificationCode IS 'The code that identifies the course, course offering, the code from an external educational organization, or other alternate course code.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.CourseAttemptResultDescriptorId IS 'The result from the student''s attempt to take the course.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.CourseIdentificationSystemDescriptorId IS 'A system that is used to identify the organization of subject matter and related learning experiences provided for the instruction of students.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code assigned to a course by a school, school system, state, or other agency or entity. For multi-part course codes, concatenate the parts separated by a "/". For example, consider the following SCED code-    subject = 20 Math    course = 272 Geometry    level = G General    credits = 1.00   course sequence 1 of 1- would be entered as 20/272/G/1.00/1 of 1.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the Identification Code.';
COMMENT ON COLUMN edfi.CourseTranscriptAlternativeCourseIdentificationCode.CourseCatalogURL IS 'The URL for the course catalog that defines the course identification code.';

-- Extended Properties [edfi].[CourseTranscriptCreditCategory] --
COMMENT ON TABLE edfi.CourseTranscriptCreditCategory IS 'A categorization for the course transcript credits awarded in the course transcript.';
COMMENT ON COLUMN edfi.CourseTranscriptCreditCategory.CourseAttemptResultDescriptorId IS 'The result from the student''s attempt to take the course.';
COMMENT ON COLUMN edfi.CourseTranscriptCreditCategory.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseTranscriptCreditCategory.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptCreditCategory.CreditCategoryDescriptorId IS 'A categorization for the course transcript credits awarded in the course transcript.';
COMMENT ON COLUMN edfi.CourseTranscriptCreditCategory.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptCreditCategory.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseTranscriptCreditCategory.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.CourseTranscriptCreditCategory.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [edfi].[CourseTranscriptEarnedAdditionalCredits] --
COMMENT ON TABLE edfi.CourseTranscriptEarnedAdditionalCredits IS 'The number of additional credits a student attempted and could earn for successfully completing a given course.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.AdditionalCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.CourseAttemptResultDescriptorId IS 'The result from the student''s attempt to take the course.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.CourseTranscriptEarnedAdditionalCredits.Credits IS 'The value of credits or units of value awarded for the completion of a course';

-- Extended Properties [edfi].[CourseTranscriptPartialCourseTranscriptAwards] --
COMMENT ON TABLE edfi.CourseTranscriptPartialCourseTranscriptAwards IS 'A collection of partial credits and/or grades a student earned against the course over the session, used when awards of credit are incremental.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.AwardDate IS 'The date the partial credits and/or grades were awarded or earned.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.CourseAttemptResultDescriptorId IS 'The result from the student''s attempt to take the course.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.EarnedCredits IS 'The number of credits a student earned for completing a given course.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.MethodCreditEarnedDescriptorId IS 'The method the credits were earned.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.LetterGradeEarned IS 'The indicator of student performance as submitted by the instructor.';
COMMENT ON COLUMN edfi.CourseTranscriptPartialCourseTranscriptAwards.NumericGradeEarned IS 'The indicator of student performance as submitted by the instructor.';

-- Extended Properties [edfi].[Credential] --
COMMENT ON TABLE edfi.Credential IS 'The legal document giving authorization to perform teaching assignment services.';
COMMENT ON COLUMN edfi.Credential.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN edfi.Credential.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN edfi.Credential.EffectiveDate IS 'The year, month and day on which an active credential held by an individual was issued.';
COMMENT ON COLUMN edfi.Credential.ExpirationDate IS 'The month, day, and year on which an active credential held by an individual will expire.';
COMMENT ON COLUMN edfi.Credential.CredentialFieldDescriptorId IS 'The field of certification for the certificate (e.g., Mathematics, Music).';
COMMENT ON COLUMN edfi.Credential.IssuanceDate IS 'The month, day, and year on which an active credential was issued to an individual.';
COMMENT ON COLUMN edfi.Credential.CredentialTypeDescriptorId IS 'An indication of the category of credential an individual holds.';
COMMENT ON COLUMN edfi.Credential.TeachingCredentialDescriptorId IS 'An indication of the category of a legal document giving authorization to perform teaching assignment services.';
COMMENT ON COLUMN edfi.Credential.TeachingCredentialBasisDescriptorId IS 'An indication of the pre-determined criteria for granting the teaching credential that an individual holds.';
COMMENT ON COLUMN edfi.Credential.Namespace IS 'Namespace for the credential.';

-- Extended Properties [edfi].[CredentialAcademicSubject] --
COMMENT ON TABLE edfi.CredentialAcademicSubject IS 'The academic subjects to which the credential pertains.';
COMMENT ON COLUMN edfi.CredentialAcademicSubject.AcademicSubjectDescriptorId IS 'The academic subjects to which the credential pertains.';
COMMENT ON COLUMN edfi.CredentialAcademicSubject.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN edfi.CredentialAcademicSubject.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';

-- Extended Properties [edfi].[CredentialEndorsement] --
COMMENT ON TABLE edfi.CredentialEndorsement IS 'Endorsements are attachments to teaching certificates and indicate areas of specialization.';
COMMENT ON COLUMN edfi.CredentialEndorsement.CredentialEndorsement IS 'Endorsements are attachments to teaching certificates and indicate areas of specialization.';
COMMENT ON COLUMN edfi.CredentialEndorsement.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN edfi.CredentialEndorsement.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';

-- Extended Properties [edfi].[CredentialFieldDescriptor] --
COMMENT ON TABLE edfi.CredentialFieldDescriptor IS 'This descriptor defines the fields of certification that the state education agency offers to teachers.';
COMMENT ON COLUMN edfi.CredentialFieldDescriptor.CredentialFieldDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CredentialGradeLevel] --
COMMENT ON TABLE edfi.CredentialGradeLevel IS 'The grade level(s) certified for teaching.';
COMMENT ON COLUMN edfi.CredentialGradeLevel.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN edfi.CredentialGradeLevel.GradeLevelDescriptorId IS 'The grade level(s) certified for teaching.';
COMMENT ON COLUMN edfi.CredentialGradeLevel.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';

-- Extended Properties [edfi].[CredentialTypeDescriptor] --
COMMENT ON TABLE edfi.CredentialTypeDescriptor IS 'An indication of the category of credential an individual holds.';
COMMENT ON COLUMN edfi.CredentialTypeDescriptor.CredentialTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CreditCategoryDescriptor] --
COMMENT ON TABLE edfi.CreditCategoryDescriptor IS 'A categorization for the course transcript credits.';
COMMENT ON COLUMN edfi.CreditCategoryDescriptor.CreditCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CreditTypeDescriptor] --
COMMENT ON TABLE edfi.CreditTypeDescriptor IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.CreditTypeDescriptor.CreditTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CTEProgramServiceDescriptor] --
COMMENT ON TABLE edfi.CTEProgramServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a CTE program.';
COMMENT ON COLUMN edfi.CTEProgramServiceDescriptor.CTEProgramServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[CurriculumUsedDescriptor] --
COMMENT ON TABLE edfi.CurriculumUsedDescriptor IS 'The type of curriculum used in an early learning classroom or group.';
COMMENT ON COLUMN edfi.CurriculumUsedDescriptor.CurriculumUsedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DeliveryMethodDescriptor] --
COMMENT ON TABLE edfi.DeliveryMethodDescriptor IS 'The way in which an intervention was implemented: individual, small group, whole class, or whole school.';
COMMENT ON COLUMN edfi.DeliveryMethodDescriptor.DeliveryMethodDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Descriptor] --
COMMENT ON TABLE edfi.Descriptor IS 'This is the base entity for the descriptor pattern.';
COMMENT ON COLUMN edfi.Descriptor.DescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';
COMMENT ON COLUMN edfi.Descriptor.Namespace IS 'A globally unique namespace that identifies this descriptor set. Author is strongly encouraged to use the Universal Resource Identifier (http, ftp, file, etc.) for the source of the descriptor definition. Best practice is for this source to be the descriptor file itself, so that it can be machine-readable and be fetched in real-time, if necessary.';
COMMENT ON COLUMN edfi.Descriptor.CodeValue IS 'A code or abbreviation that is used to refer to the descriptor.';
COMMENT ON COLUMN edfi.Descriptor.ShortDescription IS 'A shortened description for the descriptor.';
COMMENT ON COLUMN edfi.Descriptor.Description IS 'The description of the descriptor.';
COMMENT ON COLUMN edfi.Descriptor.PriorDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';
COMMENT ON COLUMN edfi.Descriptor.EffectiveBeginDate IS 'The beginning date of the period when the descriptor is in effect. If omitted, the default is immediate effectiveness.';
COMMENT ON COLUMN edfi.Descriptor.EffectiveEndDate IS 'The end date of the period when the descriptor is in effect.';

-- Extended Properties [edfi].[DescriptorMapping] --
COMMENT ON TABLE edfi.DescriptorMapping IS 'A mapping of a descriptor value in one namespace to a descriptor value in another namespace. This can be used to exchange known contextual mappings of enumeration values.';
COMMENT ON COLUMN edfi.DescriptorMapping.MappedNamespace IS 'The namespace of the descriptor value to which the from descriptor value is mapped to.';
COMMENT ON COLUMN edfi.DescriptorMapping.MappedValue IS 'The descriptor value to which the from descriptor value is being mapped to.';
COMMENT ON COLUMN edfi.DescriptorMapping.Namespace IS 'The namespace of the descriptor value that is being mapped to another value.';
COMMENT ON COLUMN edfi.DescriptorMapping.Value IS 'The descriptor value that is being mapped to another value.';

-- Extended Properties [edfi].[DescriptorMappingModelEntity] --
COMMENT ON TABLE edfi.DescriptorMappingModelEntity IS 'The resources for which the descriptor mapping applies. If empty, the mapping is assumed to be applicable to all resources in which the descriptor appears.';
COMMENT ON COLUMN edfi.DescriptorMappingModelEntity.MappedNamespace IS 'The namespace of the descriptor value to which the from descriptor value is mapped to.';
COMMENT ON COLUMN edfi.DescriptorMappingModelEntity.MappedValue IS 'The descriptor value to which the from descriptor value is being mapped to.';
COMMENT ON COLUMN edfi.DescriptorMappingModelEntity.ModelEntityDescriptorId IS 'The resources for which the descriptor mapping applies. If empty, the mapping is assumed to be applicable to all resources in which the descriptor appears.';
COMMENT ON COLUMN edfi.DescriptorMappingModelEntity.Namespace IS 'The namespace of the descriptor value that is being mapped to another value.';
COMMENT ON COLUMN edfi.DescriptorMappingModelEntity.Value IS 'The descriptor value that is being mapped to another value.';

-- Extended Properties [edfi].[DiagnosisDescriptor] --
COMMENT ON TABLE edfi.DiagnosisDescriptor IS 'This descriptor defines diagnoses that interventions are intended to target.';
COMMENT ON COLUMN edfi.DiagnosisDescriptor.DiagnosisDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DiplomaLevelDescriptor] --
COMMENT ON TABLE edfi.DiplomaLevelDescriptor IS 'The level of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.';
COMMENT ON COLUMN edfi.DiplomaLevelDescriptor.DiplomaLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DiplomaTypeDescriptor] --
COMMENT ON TABLE edfi.DiplomaTypeDescriptor IS 'The type of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.';
COMMENT ON COLUMN edfi.DiplomaTypeDescriptor.DiplomaTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DisabilityDescriptor] --
COMMENT ON TABLE edfi.DisabilityDescriptor IS 'This descriptor defines a student''s impairment.';
COMMENT ON COLUMN edfi.DisabilityDescriptor.DisabilityDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DisabilityDesignationDescriptor] --
COMMENT ON TABLE edfi.DisabilityDesignationDescriptor IS 'The type of disability designation (e.g., IDEA, Section 504).';
COMMENT ON COLUMN edfi.DisabilityDesignationDescriptor.DisabilityDesignationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DisabilityDeterminationSourceTypeDescriptor] --
COMMENT ON TABLE edfi.DisabilityDeterminationSourceTypeDescriptor IS 'The source that provided the disability determination.';
COMMENT ON COLUMN edfi.DisabilityDeterminationSourceTypeDescriptor.DisabilityDeterminationSourceTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DisciplineAction] --
COMMENT ON TABLE edfi.DisciplineAction IS 'This event entity represents actions taken by an education organization after a disruptive event that is recorded as a discipline incident.';
COMMENT ON COLUMN edfi.DisciplineAction.DisciplineActionIdentifier IS 'Identifier assigned by the education organization to the discipline action.';
COMMENT ON COLUMN edfi.DisciplineAction.DisciplineDate IS 'The date of the discipline action.';
COMMENT ON COLUMN edfi.DisciplineAction.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.DisciplineAction.DisciplineActionLength IS 'The length of time in school days for the discipline action (e.g. removal, detention), if applicable.';
COMMENT ON COLUMN edfi.DisciplineAction.ActualDisciplineActionLength IS 'Indicates the actual length in school days of a student''s disciplinary assignment.';
COMMENT ON COLUMN edfi.DisciplineAction.DisciplineActionLengthDifferenceReasonDescriptorId IS 'Indicates the reason for the difference, if any, between the official and actual lengths of a student''s disciplinary assignment.';
COMMENT ON COLUMN edfi.DisciplineAction.RelatedToZeroTolerancePolicy IS 'An indication of whether or not this disciplinary action taken against a student was imposed as a consequence of state or local zero tolerance policies.';
COMMENT ON COLUMN edfi.DisciplineAction.ResponsibilitySchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.DisciplineAction.AssignmentSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.DisciplineAction.ReceivedEducationServicesDuringExpulsion IS 'An indication of whether the student received educational services when removed from the regular school program for disciplinary reasons.';
COMMENT ON COLUMN edfi.DisciplineAction.IEPPlacementMeetingIndicator IS 'An indication as to whether an offense and/or disciplinary action resulted in a meeting of a student''s Individualized Education Program (IEP) team to determine appropriate placement.';

-- Extended Properties [edfi].[DisciplineActionDiscipline] --
COMMENT ON TABLE edfi.DisciplineActionDiscipline IS 'Type of action, such as removal from the classroom, used to discipline the student involved as a perpetrator in a discipline incident.';
COMMENT ON COLUMN edfi.DisciplineActionDiscipline.DisciplineActionIdentifier IS 'Identifier assigned by the education organization to the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionDiscipline.DisciplineDate IS 'The date of the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionDiscipline.DisciplineDescriptorId IS 'Type of action, such as removal from the classroom, used to discipline the student involved as a perpetrator in a discipline incident.';
COMMENT ON COLUMN edfi.DisciplineActionDiscipline.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[DisciplineActionLengthDifferenceReasonDescriptor] --
COMMENT ON TABLE edfi.DisciplineActionLengthDifferenceReasonDescriptor IS 'Indicates the reason for the difference, if any, between the official and actual lengths of a student''s disciplinary assignment.';
COMMENT ON COLUMN edfi.DisciplineActionLengthDifferenceReasonDescriptor.DisciplineActionLengthDifferenceReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DisciplineActionStaff] --
COMMENT ON TABLE edfi.DisciplineActionStaff IS 'The staff responsible for enforcing the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionStaff.DisciplineActionIdentifier IS 'Identifier assigned by the education organization to the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionStaff.DisciplineDate IS 'The date of the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionStaff.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.DisciplineActionStaff.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[DisciplineActionStudentDisciplineIncidentAssociation] --
COMMENT ON TABLE edfi.DisciplineActionStudentDisciplineIncidentAssociation IS 'Reference to the discipline incident associated with the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentAssociation.DisciplineActionIdentifier IS 'Identifier assigned by the education organization to the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentAssociation.DisciplineDate IS 'The date of the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentAssociation.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[DisciplineActionStudentDisciplineIncidentBehaviorAssociation] --
COMMENT ON TABLE edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation IS 'A reference to the behavior(s) by the student that led or contributed to this specific action.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation.BehaviorDescriptorId IS 'Describes behavior by category.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation.DisciplineActionIdentifier IS 'Identifier assigned by the education organization to the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation.DisciplineDate IS 'The date of the discipline action.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.DisciplineActionStudentDisciplineIncidentBehaviorAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[DisciplineDescriptor] --
COMMENT ON TABLE edfi.DisciplineDescriptor IS 'This descriptor defines the type of action or removal from the classroom used to discipline the student involved as a perpetrator in a discipline incident.';
COMMENT ON COLUMN edfi.DisciplineDescriptor.DisciplineDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DisciplineIncident] --
COMMENT ON TABLE edfi.DisciplineIncident IS 'This event entity represents an occurrence of an infraction ranging from a minor behavioral problem that disrupts the orderly functioning of a school or classroom (such as tardiness) to a criminal act that results in the involvement of a law enforcement official (such as robbery). A single event (e.g., a fight) is one incident regardless of how many perpetrators or victims are involved. Discipline incidents are events classified as warranting discipline action.';
COMMENT ON COLUMN edfi.DisciplineIncident.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.DisciplineIncident.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.DisciplineIncident.IncidentDate IS 'The month, day, and year on which the discipline incident occurred.';
COMMENT ON COLUMN edfi.DisciplineIncident.IncidentTime IS 'An indication of the time of day the incident took place.';
COMMENT ON COLUMN edfi.DisciplineIncident.IncidentLocationDescriptorId IS 'Identifies where the discipline incident occurred and whether or not it occurred on school.';
COMMENT ON COLUMN edfi.DisciplineIncident.IncidentDescription IS 'The description for an incident.';
COMMENT ON COLUMN edfi.DisciplineIncident.ReporterDescriptionDescriptorId IS 'Information on the type of individual who reported the discipline incident. When known and/or if useful, use a more specific option code (e.g., "Counselor" rather than "Professional Staff").';
COMMENT ON COLUMN edfi.DisciplineIncident.ReporterName IS 'Identifies the reporter of the discipline incident by name.';
COMMENT ON COLUMN edfi.DisciplineIncident.ReportedToLawEnforcement IS 'Indicator of whether the incident was reported to law enforcement.';
COMMENT ON COLUMN edfi.DisciplineIncident.CaseNumber IS 'The case number assigned to the DisciplineIncident by law enforcement or other organization.';
COMMENT ON COLUMN edfi.DisciplineIncident.IncidentCost IS 'The value of any quantifiable monetary loss directly resulting from the discipline incident. Examples include the value of repairs necessitated by vandalism of a school facility, or the value of personnel resources used for repairs or consumed by the incident.';
COMMENT ON COLUMN edfi.DisciplineIncident.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[DisciplineIncidentBehavior] --
COMMENT ON TABLE edfi.DisciplineIncidentBehavior IS 'Describes behavior by category and provides a detailed description.';
COMMENT ON COLUMN edfi.DisciplineIncidentBehavior.BehaviorDescriptorId IS 'Describes behavior by category and provides a detailed description.';
COMMENT ON COLUMN edfi.DisciplineIncidentBehavior.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.DisciplineIncidentBehavior.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.DisciplineIncidentBehavior.BehaviorDetailedDescription IS 'Specifies a more granular level of detail of a behavior involved in the incident.';

-- Extended Properties [edfi].[DisciplineIncidentExternalParticipant] --
COMMENT ON TABLE edfi.DisciplineIncidentExternalParticipant IS 'Information on an individual involved in the discipline incident.';
COMMENT ON COLUMN edfi.DisciplineIncidentExternalParticipant.DisciplineIncidentParticipationCodeDescriptorId IS 'The role or type of participation of an individual in the discipline incident.';
COMMENT ON COLUMN edfi.DisciplineIncidentExternalParticipant.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN edfi.DisciplineIncidentExternalParticipant.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.DisciplineIncidentExternalParticipant.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN edfi.DisciplineIncidentExternalParticipant.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [edfi].[DisciplineIncidentParticipationCodeDescriptor] --
COMMENT ON TABLE edfi.DisciplineIncidentParticipationCodeDescriptor IS 'The role or type of participation of a person in a discipline incident; for example: Victim, Perpetrator, Witness, Reporter.';
COMMENT ON COLUMN edfi.DisciplineIncidentParticipationCodeDescriptor.DisciplineIncidentParticipationCodeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[DisciplineIncidentWeapon] --
COMMENT ON TABLE edfi.DisciplineIncidentWeapon IS 'Identifies the type of weapon used during an incident. The Federal Gun-Free Schools Act requires states to report the number of students expelled for bringing firearms to school by type of firearm.';
COMMENT ON COLUMN edfi.DisciplineIncidentWeapon.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.DisciplineIncidentWeapon.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.DisciplineIncidentWeapon.WeaponDescriptorId IS 'Identifies the type of weapon used during an incident. The Federal Gun-Free Schools Act requires states to report the number of students expelled for bringing firearms to school by type of firearm.';

-- Extended Properties [edfi].[EducationalEnvironmentDescriptor] --
COMMENT ON TABLE edfi.EducationalEnvironmentDescriptor IS 'The setting in which a child receives education and related services.';
COMMENT ON COLUMN edfi.EducationalEnvironmentDescriptor.EducationalEnvironmentDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EducationContent] --
COMMENT ON TABLE edfi.EducationContent IS 'This entity represents materials for students or teachers that can be used for teaching, learning, research, and more. Education content includes full courses, course materials, modules, intervention descriptions, textbooks, streaming videos, tests, software, and any other tools, materials, or techniques used to support access to knowledge.';
COMMENT ON COLUMN edfi.EducationContent.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.EducationContent.LearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';
COMMENT ON COLUMN edfi.EducationContent.ShortDescription IS 'A short description or name of the entity.';
COMMENT ON COLUMN edfi.EducationContent.Description IS 'An extended written representation of the education content.';
COMMENT ON COLUMN edfi.EducationContent.AdditionalAuthorsIndicator IS 'Indicates whether there are additional un-named authors. In a research report, this is often marked by the abbreviation "et al".';
COMMENT ON COLUMN edfi.EducationContent.Publisher IS 'The organization credited with publishing the resource.';
COMMENT ON COLUMN edfi.EducationContent.TimeRequired IS 'Approximate or typical time it takes to work with or through this learning resource for the typical intended target audience.';
COMMENT ON COLUMN edfi.EducationContent.InteractivityStyleDescriptorId IS 'The predominate mode of learning supported by the learning resource. Acceptable values are active, expositive, or mixed.';
COMMENT ON COLUMN edfi.EducationContent.ContentClassDescriptorId IS 'The predominate type or kind characterizing the learning resource.';
COMMENT ON COLUMN edfi.EducationContent.UseRightsURL IS 'The URL where the owner specifies permissions for using the resource.';
COMMENT ON COLUMN edfi.EducationContent.PublicationDate IS 'The date on which this content was first published.';
COMMENT ON COLUMN edfi.EducationContent.PublicationYear IS 'The year at which this content was first published.';
COMMENT ON COLUMN edfi.EducationContent.Version IS 'The version identifier for the content.';
COMMENT ON COLUMN edfi.EducationContent.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.EducationContent.Cost IS 'An amount that has to be paid or spent to buy or obtain the education content.';
COMMENT ON COLUMN edfi.EducationContent.CostRateDescriptorId IS 'The rate by which the cost applies.';
COMMENT ON COLUMN edfi.EducationContent.Namespace IS 'Namespace for the education content.';

-- Extended Properties [edfi].[EducationContentAppropriateGradeLevel] --
COMMENT ON TABLE edfi.EducationContentAppropriateGradeLevel IS 'Grade levels for which this education content is applicable. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.EducationContentAppropriateGradeLevel.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.EducationContentAppropriateGradeLevel.GradeLevelDescriptorId IS 'Grade levels for which this education content is applicable. If omitted, considered generally applicable.';

-- Extended Properties [edfi].[EducationContentAppropriateSex] --
COMMENT ON TABLE edfi.EducationContentAppropriateSex IS 'Sexes for which this education content is applicable. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.EducationContentAppropriateSex.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.EducationContentAppropriateSex.SexDescriptorId IS 'Sexes for which this education content is applicable. If omitted, considered generally applicable.';

-- Extended Properties [edfi].[EducationContentAuthor] --
COMMENT ON TABLE edfi.EducationContentAuthor IS 'The individual credited with the creation of the resource.';
COMMENT ON COLUMN edfi.EducationContentAuthor.Author IS 'The individual credited with the creation of the resource.';
COMMENT ON COLUMN edfi.EducationContentAuthor.ContentIdentifier IS 'A unique identifier for the education content.';

-- Extended Properties [edfi].[EducationContentDerivativeSourceEducationContent] --
COMMENT ON TABLE edfi.EducationContentDerivativeSourceEducationContent IS 'Relates the education content source to the education content.';
COMMENT ON COLUMN edfi.EducationContentDerivativeSourceEducationContent.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.EducationContentDerivativeSourceEducationContent.DerivativeSourceContentIdentifier IS 'A unique identifier for the education content.';

-- Extended Properties [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] --
COMMENT ON TABLE edfi.EducationContentDerivativeSourceLearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';
COMMENT ON COLUMN edfi.EducationContentDerivativeSourceLearningResourceMetadataURI.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.EducationContentDerivativeSourceLearningResourceMetadataURI.DerivativeSourceLearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';

-- Extended Properties [edfi].[EducationContentDerivativeSourceURI] --
COMMENT ON TABLE edfi.EducationContentDerivativeSourceURI IS 'The URI (typical a URL) pointing to an education content item.';
COMMENT ON COLUMN edfi.EducationContentDerivativeSourceURI.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.EducationContentDerivativeSourceURI.DerivativeSourceURI IS 'The URI (typical a URL) pointing to an education content item.';

-- Extended Properties [edfi].[EducationContentLanguage] --
COMMENT ON TABLE edfi.EducationContentLanguage IS 'An indication of the languages in which the Education Content is designed.';
COMMENT ON COLUMN edfi.EducationContentLanguage.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.EducationContentLanguage.LanguageDescriptorId IS 'An indication of the languages in which the Education Content is designed.';

-- Extended Properties [edfi].[EducationOrganization] --
COMMENT ON TABLE edfi.EducationOrganization IS 'This entity represents any public or private institution, organization, or agency that provides instructional or support services to students or staff at any level.';
COMMENT ON COLUMN edfi.EducationOrganization.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganization.NameOfInstitution IS 'The full, legally accepted name of the institution.';
COMMENT ON COLUMN edfi.EducationOrganization.ShortNameOfInstitution IS 'A short name for the institution.';
COMMENT ON COLUMN edfi.EducationOrganization.WebSite IS 'The public web site address (URL) for the education organization.';
COMMENT ON COLUMN edfi.EducationOrganization.OperationalStatusDescriptorId IS 'The current operational status of the education organization (e.g., active, inactive).';

-- Extended Properties [edfi].[EducationOrganizationAddress] --
COMMENT ON TABLE edfi.EducationOrganizationAddress IS 'The set of elements that describes an address for the education entity, including the street address, city, state, ZIP code, and ZIP code + 4.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN edfi.EducationOrganizationAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [edfi].[EducationOrganizationAddressPeriod] --
COMMENT ON TABLE edfi.EducationOrganizationAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.EducationOrganizationAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN edfi.EducationOrganizationAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.EducationOrganizationAddressPeriod.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.EducationOrganizationAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.EducationOrganizationAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [edfi].[EducationOrganizationAssociationTypeDescriptor] --
COMMENT ON TABLE edfi.EducationOrganizationAssociationTypeDescriptor IS 'The type of education organization association being represented.';
COMMENT ON COLUMN edfi.EducationOrganizationAssociationTypeDescriptor.EducationOrganizationAssociationTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EducationOrganizationCategory] --
COMMENT ON TABLE edfi.EducationOrganizationCategory IS 'The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.';
COMMENT ON COLUMN edfi.EducationOrganizationCategory.EducationOrganizationCategoryDescriptorId IS 'The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.';
COMMENT ON COLUMN edfi.EducationOrganizationCategory.EducationOrganizationId IS 'The identifier assigned to an education organization.';

-- Extended Properties [edfi].[EducationOrganizationCategoryDescriptor] --
COMMENT ON TABLE edfi.EducationOrganizationCategoryDescriptor IS 'The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.';
COMMENT ON COLUMN edfi.EducationOrganizationCategoryDescriptor.EducationOrganizationCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EducationOrganizationIdentificationCode] --
COMMENT ON TABLE edfi.EducationOrganizationIdentificationCode IS 'A unique number or alphanumeric code assigned to an education organization by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.EducationOrganizationIdentificationCode.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationIdentificationCode.EducationOrganizationIdentificationSystemDescriptorId IS 'The school system, state, or agency assigning the identification code.';
COMMENT ON COLUMN edfi.EducationOrganizationIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code that is assigned to an education organization by a school, school system, state, or other agency or entity.';

-- Extended Properties [edfi].[EducationOrganizationIdentificationSystemDescriptor] --
COMMENT ON TABLE edfi.EducationOrganizationIdentificationSystemDescriptor IS 'This descriptor defines the originating record system and code that is used for record-keeping purposes by education organizations.';
COMMENT ON COLUMN edfi.EducationOrganizationIdentificationSystemDescriptor.EducationOrganizationIdentificationSystemDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EducationOrganizationIndicator] --
COMMENT ON TABLE edfi.EducationOrganizationIndicator IS 'An indicator or metric of an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationIndicator.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationIndicator.IndicatorDescriptorId IS 'The name or code for the indicator or metric.';
COMMENT ON COLUMN edfi.EducationOrganizationIndicator.DesignatedBy IS 'The person, organization, or department that defined the metric.';
COMMENT ON COLUMN edfi.EducationOrganizationIndicator.IndicatorValue IS 'The value of the indicator or metric. The semantics of an empty value is "not submitted."';
COMMENT ON COLUMN edfi.EducationOrganizationIndicator.IndicatorLevelDescriptorId IS 'The value of the indicator or metric, as a value from a controlled vocabulary. The semantics of an empty value is "not submitted."';
COMMENT ON COLUMN edfi.EducationOrganizationIndicator.IndicatorGroupDescriptorId IS 'The name for a group of indicators.';

-- Extended Properties [edfi].[EducationOrganizationIndicatorPeriod] --
COMMENT ON TABLE edfi.EducationOrganizationIndicatorPeriod IS 'The time period or as-of date for the indicator.';
COMMENT ON COLUMN edfi.EducationOrganizationIndicatorPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN edfi.EducationOrganizationIndicatorPeriod.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationIndicatorPeriod.IndicatorDescriptorId IS 'The name or code for the indicator or metric.';
COMMENT ON COLUMN edfi.EducationOrganizationIndicatorPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [edfi].[EducationOrganizationInstitutionTelephone] --
COMMENT ON TABLE edfi.EducationOrganizationInstitutionTelephone IS 'The 10-digit telephone number, including the area code, for the education entity.';
COMMENT ON COLUMN edfi.EducationOrganizationInstitutionTelephone.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationInstitutionTelephone.InstitutionTelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN edfi.EducationOrganizationInstitutionTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';

-- Extended Properties [edfi].[EducationOrganizationInternationalAddress] --
COMMENT ON TABLE edfi.EducationOrganizationInternationalAddress IS 'The set of elements that describes the international physical location of the education entity.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.AddressLine1 IS 'The first line of the address.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.AddressLine2 IS 'The second line of the address.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.AddressLine3 IS 'The third line of the address.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.AddressLine4 IS 'The fourth line of the address.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.CountryDescriptorId IS 'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.BeginDate IS 'The first date the address is valid. For physical addresses, the date the individual moved to that address.';
COMMENT ON COLUMN edfi.EducationOrganizationInternationalAddress.EndDate IS 'The last date the address is valid. For physical addresses, the date the individual moved from that address.';

-- Extended Properties [edfi].[EducationOrganizationInterventionPrescriptionAssociation] --
COMMENT ON TABLE edfi.EducationOrganizationInterventionPrescriptionAssociation IS 'This association indicates interventions made available by an education organization. Often, a district-level education organization purchases a set of intervention prescriptions and makes them available to its schools for use on demand.';
COMMENT ON COLUMN edfi.EducationOrganizationInterventionPrescriptionAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationInterventionPrescriptionAssociation.InterventionPrescriptionEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationInterventionPrescriptionAssociation.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';
COMMENT ON COLUMN edfi.EducationOrganizationInterventionPrescriptionAssociation.BeginDate IS 'The begin date of the period during which the intervention prescription is available.';
COMMENT ON COLUMN edfi.EducationOrganizationInterventionPrescriptionAssociation.EndDate IS 'The end date of the period during which the intervention prescription is available.';

-- Extended Properties [edfi].[EducationOrganizationNetwork] --
COMMENT ON TABLE edfi.EducationOrganizationNetwork IS 'This entity is a self-organized membership network of peer-level education organizations intended to provide shared services or collective procurement.';
COMMENT ON COLUMN edfi.EducationOrganizationNetwork.EducationOrganizationNetworkId IS 'The identifier assigned to a network of education organizations.';
COMMENT ON COLUMN edfi.EducationOrganizationNetwork.NetworkPurposeDescriptorId IS 'The purpose(s) of the network (e.g., shared services, collective procurement).';

-- Extended Properties [edfi].[EducationOrganizationNetworkAssociation] --
COMMENT ON TABLE edfi.EducationOrganizationNetworkAssociation IS 'Properties of the association between the education organization and its network(s).';
COMMENT ON COLUMN edfi.EducationOrganizationNetworkAssociation.EducationOrganizationNetworkId IS 'The identifier assigned to a network of education organizations.';
COMMENT ON COLUMN edfi.EducationOrganizationNetworkAssociation.MemberEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationNetworkAssociation.BeginDate IS 'The date on which the education organization joined this network.';
COMMENT ON COLUMN edfi.EducationOrganizationNetworkAssociation.EndDate IS 'The date on which the education organization left this network.';

-- Extended Properties [edfi].[EducationOrganizationPeerAssociation] --
COMMENT ON TABLE edfi.EducationOrganizationPeerAssociation IS 'The association from an education organization to its peers.';
COMMENT ON COLUMN edfi.EducationOrganizationPeerAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.EducationOrganizationPeerAssociation.PeerEducationOrganizationId IS 'The identifier assigned to an education organization.';

-- Extended Properties [edfi].[EducationPlanDescriptor] --
COMMENT ON TABLE edfi.EducationPlanDescriptor IS 'The type of education plan(s) the student is following, if appropriate.';
COMMENT ON COLUMN edfi.EducationPlanDescriptor.EducationPlanDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EducationServiceCenter] --
COMMENT ON TABLE edfi.EducationServiceCenter IS 'This entity represents a regional, multi-services public agency authorized by state law to develop, manage and provide services, programs, or other support options (e.g., construction, food services, and technology services) to LEAs.';
COMMENT ON COLUMN edfi.EducationServiceCenter.EducationServiceCenterId IS 'The identifier assigned to an education service center.';
COMMENT ON COLUMN edfi.EducationServiceCenter.StateEducationAgencyId IS 'The identifier assigned to a state education agency.';

-- Extended Properties [edfi].[ElectronicMailTypeDescriptor] --
COMMENT ON TABLE edfi.ElectronicMailTypeDescriptor IS 'The type of email listed for an individual or organization.';
COMMENT ON COLUMN edfi.ElectronicMailTypeDescriptor.ElectronicMailTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EmploymentStatusDescriptor] --
COMMENT ON TABLE edfi.EmploymentStatusDescriptor IS 'This descriptor defines the type of employment or contract.';
COMMENT ON COLUMN edfi.EmploymentStatusDescriptor.EmploymentStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EnrollmentTypeDescriptor] --
COMMENT ON TABLE edfi.EnrollmentTypeDescriptor IS 'The type of enrollment reflected by the StudentSchoolAssociation.';
COMMENT ON COLUMN edfi.EnrollmentTypeDescriptor.EnrollmentTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EntryGradeLevelReasonDescriptor] --
COMMENT ON TABLE edfi.EntryGradeLevelReasonDescriptor IS 'The primary reason as to why a staff member determined that a student should be promoted or not (or be demoted) at the end of a given school term.';
COMMENT ON COLUMN edfi.EntryGradeLevelReasonDescriptor.EntryGradeLevelReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EntryTypeDescriptor] --
COMMENT ON TABLE edfi.EntryTypeDescriptor IS 'This descriptor defines the process by which a student enters a school during a given academic session.';
COMMENT ON COLUMN edfi.EntryTypeDescriptor.EntryTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[EventCircumstanceDescriptor] --
COMMENT ON TABLE edfi.EventCircumstanceDescriptor IS 'An unusual event occurred during the administration of the assessment. This could include fire alarm, student became ill, etc.';
COMMENT ON COLUMN edfi.EventCircumstanceDescriptor.EventCircumstanceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ExitWithdrawTypeDescriptor] --
COMMENT ON TABLE edfi.ExitWithdrawTypeDescriptor IS 'This descriptor defines the circumstances under which the student exited from membership in an educational institution.';
COMMENT ON COLUMN edfi.ExitWithdrawTypeDescriptor.ExitWithdrawTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[FeederSchoolAssociation] --
COMMENT ON TABLE edfi.FeederSchoolAssociation IS 'The association from feeder school to the receiving school.';
COMMENT ON COLUMN edfi.FeederSchoolAssociation.BeginDate IS 'The month, day, and year of the first day of the feeder school association.';
COMMENT ON COLUMN edfi.FeederSchoolAssociation.FeederSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.FeederSchoolAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.FeederSchoolAssociation.EndDate IS 'The month, day, and year of the last day of the feeder school association.';
COMMENT ON COLUMN edfi.FeederSchoolAssociation.FeederRelationshipDescription IS 'Describes the relationship from the feeder school to the receiving school, for example by program emphasis, such as special education, language immersion, science, or performing art.';

-- Extended Properties [edfi].[FinancialCollectionDescriptor] --
COMMENT ON TABLE edfi.FinancialCollectionDescriptor IS 'The accounting period or grouping for which financial information is collected.';
COMMENT ON COLUMN edfi.FinancialCollectionDescriptor.FinancialCollectionDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[FunctionDimension] --
COMMENT ON TABLE edfi.FunctionDimension IS 'The NCES function accounting dimension representing an expenditure. The function describes the activity for which a service or material object is acquired. The functions of a school district are generally classified into five broad areas, including instruction, support services, operation of non-instructional services, facilities acquisition and construction, and debt service.';
COMMENT ON COLUMN edfi.FunctionDimension.Code IS 'The code representation of the account function dimension.';
COMMENT ON COLUMN edfi.FunctionDimension.FiscalYear IS 'The fiscal year for which the account function dimension is valid.';
COMMENT ON COLUMN edfi.FunctionDimension.CodeName IS 'A description of the account function dimension.';

-- Extended Properties [edfi].[FunctionDimensionReportingTag] --
COMMENT ON TABLE edfi.FunctionDimensionReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.FunctionDimensionReportingTag.Code IS 'The code representation of the account function dimension.';
COMMENT ON COLUMN edfi.FunctionDimensionReportingTag.FiscalYear IS 'The fiscal year for which the account function dimension is valid.';
COMMENT ON COLUMN edfi.FunctionDimensionReportingTag.ReportingTagDescriptorId IS 'Optional tag for accountability reporting.';

-- Extended Properties [edfi].[FundDimension] --
COMMENT ON TABLE edfi.FundDimension IS 'The NCES fund accounting dimension. A fund is a fiscal and accounting entity with a self-balancing set of accounts recording cash and other financial resources, together with all related liabilities and residual equities or balances, and changes therein, which are segregated for the purpose of carrying on specific activities or attaining certain objectives in accordance with special regulations, restrictions, or limitations.';
COMMENT ON COLUMN edfi.FundDimension.Code IS 'The code representation of the account fund dimension.';
COMMENT ON COLUMN edfi.FundDimension.FiscalYear IS 'The fiscal year for which the account fund dimension is valid.';
COMMENT ON COLUMN edfi.FundDimension.CodeName IS 'A description of the account fund dimension.';

-- Extended Properties [edfi].[FundDimensionReportingTag] --
COMMENT ON TABLE edfi.FundDimensionReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.FundDimensionReportingTag.Code IS 'The code representation of the account fund dimension.';
COMMENT ON COLUMN edfi.FundDimensionReportingTag.FiscalYear IS 'The fiscal year for which the account fund dimension is valid.';
COMMENT ON COLUMN edfi.FundDimensionReportingTag.ReportingTagDescriptorId IS 'Optional tag for accountability reporting.';

-- Extended Properties [edfi].[GeneralStudentProgramAssociation] --
COMMENT ON TABLE edfi.GeneralStudentProgramAssociation IS 'This association base class represents the basic relationship between students and programs.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.EndDate IS 'The month, day, and year on which the student exited the program or stopped receiving services.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.ReasonExitedDescriptorId IS 'The reason the student left the program within a school or district.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociation.ServedOutsideOfRegularSession IS 'Indicates whether the student received services during the summer session or between sessions.';

-- Extended Properties [edfi].[GeneralStudentProgramAssociationParticipationStatus] --
COMMENT ON TABLE edfi.GeneralStudentProgramAssociationParticipationStatus IS 'The status of the student''s program participation.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.ParticipationStatusDescriptorId IS 'The student''s program participation status.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.StatusBeginDate IS 'The date the student''s program participation status began.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.StatusEndDate IS 'The date the student''s program participation status ended.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationParticipationStatus.DesignatedBy IS 'The person, organization, or department that designated the participation status.';

-- Extended Properties [edfi].[GeneralStudentProgramAssociationProgramParticipationStatus] --
COMMENT ON TABLE edfi.GeneralStudentProgramAssociationProgramParticipationStatus IS 'The status of the student''s program participation.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.ParticipationStatusDescriptorId IS 'The student''s program participation status.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.StatusBeginDate IS 'The date the student''s program participation status began.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.StatusEndDate IS 'The date the student''s program participation status ended.';
COMMENT ON COLUMN edfi.GeneralStudentProgramAssociationProgramParticipationStatus.DesignatedBy IS 'The person, organization, or department that designated the participation status.';

-- Extended Properties [edfi].[Grade] --
COMMENT ON TABLE edfi.Grade IS 'This educational entity represents an overall score or assessment tied to a course over a period of time (i.e., the grading period). Student grades are usually a compilation of marks and other scores.';
COMMENT ON COLUMN edfi.Grade.BeginDate IS 'Month, day, and year of the student''s entry or assignment to the section.';
COMMENT ON COLUMN edfi.Grade.GradeTypeDescriptorId IS 'The type of grade reported (e.g., exam, final, grading period).';
COMMENT ON COLUMN edfi.Grade.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.Grade.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.Grade.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.Grade.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.Grade.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.Grade.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.Grade.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.Grade.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.Grade.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.Grade.LetterGradeEarned IS 'A final or interim (grading period) indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN edfi.Grade.NumericGradeEarned IS 'A final or interim (grading period) indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN edfi.Grade.DiagnosticStatement IS 'A statement provided by the teacher that provides information in addition to the grade or assessment score.';
COMMENT ON COLUMN edfi.Grade.PerformanceBaseConversionDescriptorId IS 'A conversion of the level to a standard set of performance levels.';
COMMENT ON COLUMN edfi.Grade.CurrentGradeIndicator IS 'An indicator that the posted grade is an interim grade for the grading period and not the final grade.';
COMMENT ON COLUMN edfi.Grade.CurrentGradeAsOfDate IS 'As-Of date for a grade posted as the current grade.';
COMMENT ON COLUMN edfi.Grade.GradeEarnedDescription IS 'A description of the grade earned by the learner.';

-- Extended Properties [edfi].[GradebookEntry] --
COMMENT ON TABLE edfi.GradebookEntry IS 'This entity represents an assignment, homework, or classroom assessment to be recorded in a gradebook.';
COMMENT ON COLUMN edfi.GradebookEntry.GradebookEntryIdentifier IS 'A unique number or alphanumeric code assigned to a gradebook entry by the source system.';
COMMENT ON COLUMN edfi.GradebookEntry.Namespace IS 'Namespace URI for the source of the gradebook entry.';
COMMENT ON COLUMN edfi.GradebookEntry.SourceSectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.GradebookEntry.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.GradebookEntry.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.GradebookEntry.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.GradebookEntry.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.GradebookEntry.DateAssigned IS 'The date the assignment, homework, or assessment was assigned or executed.';
COMMENT ON COLUMN edfi.GradebookEntry.Title IS 'The name or title of the activity to be recorded in the gradebook entry.';
COMMENT ON COLUMN edfi.GradebookEntry.Description IS 'A description of the assignment, homework, or classroom assessment.';
COMMENT ON COLUMN edfi.GradebookEntry.DueDate IS 'The date the assignment, homework, or assessment is due.';
COMMENT ON COLUMN edfi.GradebookEntry.DueTime IS 'The time the assignment, homework, or assessment is due.';
COMMENT ON COLUMN edfi.GradebookEntry.GradebookEntryTypeDescriptorId IS 'The type of the gradebook entry.';
COMMENT ON COLUMN edfi.GradebookEntry.MaxPoints IS 'The maximum number of points  that can be earned for the submission.';
COMMENT ON COLUMN edfi.GradebookEntry.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.GradebookEntry.PeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.GradebookEntry.SchoolYear IS 'The identifier for the school year.';

-- Extended Properties [edfi].[GradebookEntryLearningStandard] --
COMMENT ON TABLE edfi.GradebookEntryLearningStandard IS 'LearningStandard(s) associated with the gradebook entry.';
COMMENT ON COLUMN edfi.GradebookEntryLearningStandard.GradebookEntryIdentifier IS 'A unique number or alphanumeric code assigned to a gradebook entry by the source system.';
COMMENT ON COLUMN edfi.GradebookEntryLearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.GradebookEntryLearningStandard.Namespace IS 'Namespace URI for the source of the gradebook entry.';

-- Extended Properties [edfi].[GradebookEntryTypeDescriptor] --
COMMENT ON TABLE edfi.GradebookEntryTypeDescriptor IS 'The type of the gradebook entry; for example, homework, assignment, quiz, unit test, oral presentation, etc.';
COMMENT ON COLUMN edfi.GradebookEntryTypeDescriptor.GradebookEntryTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[GradeLearningStandardGrade] --
COMMENT ON TABLE edfi.GradeLearningStandardGrade IS 'A collection of learning standards associated with the grade.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.BeginDate IS 'Month, day, and year of the student''s entry or assignment to the section.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.GradeTypeDescriptorId IS 'The type of grade reported (e.g., exam, final, grading period).';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.LetterGradeEarned IS 'A final or interim (grading period) indicator of student performance for a learning standard as submitted by the instructor.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.NumericGradeEarned IS 'A final or interim (grading period) indicator of student performance for a learning standard as submitted by the instructor.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.DiagnosticStatement IS 'A statement provided by the teacher that provides information in addition to the grade or assessment score.';
COMMENT ON COLUMN edfi.GradeLearningStandardGrade.PerformanceBaseConversionDescriptorId IS 'A performance level that describes the student proficiency.';

-- Extended Properties [edfi].[GradeLevelDescriptor] --
COMMENT ON TABLE edfi.GradeLevelDescriptor IS 'This descriptor defines the set of grade levels. The map to known Ed-Fi enumeration values is required.';
COMMENT ON COLUMN edfi.GradeLevelDescriptor.GradeLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[GradePointAverageTypeDescriptor] --
COMMENT ON TABLE edfi.GradePointAverageTypeDescriptor IS 'The system used for calculating the grade point average for an individual.';
COMMENT ON COLUMN edfi.GradePointAverageTypeDescriptor.GradePointAverageTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[GradeTypeDescriptor] --
COMMENT ON TABLE edfi.GradeTypeDescriptor IS 'The type of grade in a report card or transcript (e.g., Final, Exam, Grading Period).';
COMMENT ON COLUMN edfi.GradeTypeDescriptor.GradeTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[GradingPeriod] --
COMMENT ON TABLE edfi.GradingPeriod IS 'This entity represents the time span for which grades are reported.';
COMMENT ON COLUMN edfi.GradingPeriod.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.GradingPeriod.PeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.GradingPeriod.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.GradingPeriod.SchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.GradingPeriod.BeginDate IS 'Month, day, and year of the first day of the grading period.';
COMMENT ON COLUMN edfi.GradingPeriod.EndDate IS 'Month, day, and year of the last day of the grading period.';
COMMENT ON COLUMN edfi.GradingPeriod.TotalInstructionalDays IS 'Total days available for educational instruction during the grading period.';

-- Extended Properties [edfi].[GradingPeriodDescriptor] --
COMMENT ON TABLE edfi.GradingPeriodDescriptor IS 'This descriptor defines the name of the period for which grades are reported. The mapping of descriptor values to known Ed-Fi enumeration values is required.';
COMMENT ON COLUMN edfi.GradingPeriodDescriptor.GradingPeriodDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[GraduationPlan] --
COMMENT ON TABLE edfi.GraduationPlan IS 'This entity is a plan outlining the required credits, credits by subject, credits by course, and other criteria required for graduation. A graduation plan may be one or more standard plans defined by an education organization and/or individual plans for some or all students.';
COMMENT ON COLUMN edfi.GraduationPlan.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlan.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.GraduationPlan.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.GraduationPlan.IndividualPlan IS 'An indicator of whether the graduation plan is tailored for an individual.';
COMMENT ON COLUMN edfi.GraduationPlan.TotalRequiredCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.GraduationPlan.TotalRequiredCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.GraduationPlan.TotalRequiredCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';

-- Extended Properties [edfi].[GraduationPlanCreditsByCourse] --
COMMENT ON TABLE edfi.GraduationPlanCreditsByCourse IS 'The total credits required for graduation by taking a specific course, or by taking one or more from a set of courses.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourse.CourseSetName IS 'Identifying name given to a collection of courses.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourse.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourse.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourse.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourse.Credits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourse.CreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourse.CreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourse.WhenTakenGradeLevelDescriptorId IS 'The grade level when the student is planned to take the course.';

-- Extended Properties [edfi].[GraduationPlanCreditsByCourseCourse] --
COMMENT ON TABLE edfi.GraduationPlanCreditsByCourseCourse IS 'The course reference that identifies the organization of subject matter and related learning experiences provided for the instruction of students.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourseCourse.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourseCourse.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourseCourse.CourseSetName IS 'Identifying name given to a collection of courses.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourseCourse.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourseCourse.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCourseCourse.GraduationSchoolYear IS 'The school year the student is expected to graduate.';

-- Extended Properties [edfi].[GraduationPlanCreditsByCreditCategory] --
COMMENT ON TABLE edfi.GraduationPlanCreditsByCreditCategory IS 'The total credits required for graduation based on the credit category.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCreditCategory.CreditCategoryDescriptorId IS 'A categorization for the course transcript credits awarded in the course transcript.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCreditCategory.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCreditCategory.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCreditCategory.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCreditCategory.Credits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCreditCategory.CreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsByCreditCategory.CreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';

-- Extended Properties [edfi].[GraduationPlanCreditsBySubject] --
COMMENT ON TABLE edfi.GraduationPlanCreditsBySubject IS 'The total credits required in subject to graduate. Only those courses identified as a high school course requirement are eligible to meet subject credit requirements.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsBySubject.AcademicSubjectDescriptorId IS 'The intended major subject area of the graduation requirement.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsBySubject.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsBySubject.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsBySubject.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsBySubject.Credits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsBySubject.CreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.GraduationPlanCreditsBySubject.CreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';

-- Extended Properties [edfi].[GraduationPlanRequiredAssessment] --
COMMENT ON TABLE edfi.GraduationPlanRequiredAssessment IS 'The assessments and associated required score and performance level needed to satisfy graduation requirements.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessment.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessment.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessment.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessment.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessment.Namespace IS 'Namespace for the assessment.';

-- Extended Properties [edfi].[GraduationPlanRequiredAssessmentPerformanceLevel] --
COMMENT ON TABLE edfi.GraduationPlanRequiredAssessmentPerformanceLevel IS 'Performance level required to be met or exceeded.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.PerformanceLevelDescriptorId IS 'The performance level(s) defined for the assessment.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.AssessmentReportingMethodDescriptorId IS 'The method that the instructor of the class uses to report the performance and achievement of all students. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or numerical grade. In some cases, more than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.MinimumScore IS 'The minimum score required to make the indicated level of performance.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.MaximumScore IS 'The maximum score to make the indicated level of performance.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentPerformanceLevel.PerformanceLevelIndicatorName IS 'The name of the indicator being measured for a collection of performance level values.';

-- Extended Properties [edfi].[GraduationPlanRequiredAssessmentScore] --
COMMENT ON TABLE edfi.GraduationPlanRequiredAssessmentScore IS 'Score required to be met or exceeded.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.AssessmentReportingMethodDescriptorId IS 'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.MinimumScore IS 'The minimum score possible on the assessment.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.MaximumScore IS 'The maximum score possible on the assessment.';
COMMENT ON COLUMN edfi.GraduationPlanRequiredAssessmentScore.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [edfi].[GraduationPlanTypeDescriptor] --
COMMENT ON TABLE edfi.GraduationPlanTypeDescriptor IS 'This descriptor defines the set of graduation plan types.';
COMMENT ON COLUMN edfi.GraduationPlanTypeDescriptor.GraduationPlanTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[GunFreeSchoolsActReportingStatusDescriptor] --
COMMENT ON TABLE edfi.GunFreeSchoolsActReportingStatusDescriptor IS 'An indication of whether the school or local education agency (LEA) submitted a Gun-Free Schools Act (GFSA) of 1994 report to the state, as defined by Title 18, Section 921.';
COMMENT ON COLUMN edfi.GunFreeSchoolsActReportingStatusDescriptor.GunFreeSchoolsActReportingStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[HomelessPrimaryNighttimeResidenceDescriptor] --
COMMENT ON TABLE edfi.HomelessPrimaryNighttimeResidenceDescriptor IS 'The primary nighttime residence of the student at the time the student is identified as homeless.';
COMMENT ON COLUMN edfi.HomelessPrimaryNighttimeResidenceDescriptor.HomelessPrimaryNighttimeResidenceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[HomelessProgramServiceDescriptor] --
COMMENT ON TABLE edfi.HomelessProgramServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a homeless program.';
COMMENT ON COLUMN edfi.HomelessProgramServiceDescriptor.HomelessProgramServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[IdentificationDocumentUseDescriptor] --
COMMENT ON TABLE edfi.IdentificationDocumentUseDescriptor IS 'Identifies the type of use given to an identification document.';
COMMENT ON COLUMN edfi.IdentificationDocumentUseDescriptor.IdentificationDocumentUseDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[IncidentLocationDescriptor] --
COMMENT ON TABLE edfi.IncidentLocationDescriptor IS 'Identifies where the incident occurred and whether or not it occurred on school property.';
COMMENT ON COLUMN edfi.IncidentLocationDescriptor.IncidentLocationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[IndicatorDescriptor] --
COMMENT ON TABLE edfi.IndicatorDescriptor IS 'The name or code for the indicator or metric.';
COMMENT ON COLUMN edfi.IndicatorDescriptor.IndicatorDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[IndicatorGroupDescriptor] --
COMMENT ON TABLE edfi.IndicatorGroupDescriptor IS 'The name for a group of indicators.';
COMMENT ON COLUMN edfi.IndicatorGroupDescriptor.IndicatorGroupDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[IndicatorLevelDescriptor] --
COMMENT ON TABLE edfi.IndicatorLevelDescriptor IS 'The value of the indicator or metric, as a value from a controlled vocabulary. The semantics of an empty value is "not submitted."';
COMMENT ON COLUMN edfi.IndicatorLevelDescriptor.IndicatorLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[InstitutionTelephoneNumberTypeDescriptor] --
COMMENT ON TABLE edfi.InstitutionTelephoneNumberTypeDescriptor IS 'The type of communication number listed for an organization.';
COMMENT ON COLUMN edfi.InstitutionTelephoneNumberTypeDescriptor.InstitutionTelephoneNumberTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[InteractivityStyleDescriptor] --
COMMENT ON TABLE edfi.InteractivityStyleDescriptor IS 'The predominate mode of learning supported by the learning resource. Acceptable values are active, expositive, or mixed.';
COMMENT ON COLUMN edfi.InteractivityStyleDescriptor.InteractivityStyleDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[InternetAccessDescriptor] --
COMMENT ON TABLE edfi.InternetAccessDescriptor IS 'The type of Internet access available.';
COMMENT ON COLUMN edfi.InternetAccessDescriptor.InternetAccessDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[InternetAccessTypeInResidenceDescriptor] --
COMMENT ON TABLE edfi.InternetAccessTypeInResidenceDescriptor IS 'The primary type of internet service used in the student’s primary place of residence.';
COMMENT ON COLUMN edfi.InternetAccessTypeInResidenceDescriptor.InternetAccessTypeInResidenceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[InternetPerformanceInResidenceDescriptor] --
COMMENT ON TABLE edfi.InternetPerformanceInResidenceDescriptor IS 'An indication of whether the student can complete the full range of learning activities, including video streaming and assignment upload, without interruptions caused by poor internet performance in their primary place of residence.';
COMMENT ON COLUMN edfi.InternetPerformanceInResidenceDescriptor.InternetPerformanceInResidenceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Intervention] --
COMMENT ON TABLE edfi.Intervention IS 'An implementation of an instructional approach focusing on the specific techniques and materials used to teach a given subject.';
COMMENT ON COLUMN edfi.Intervention.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.Intervention.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.Intervention.InterventionClassDescriptorId IS 'The way in which an intervention is used: curriculum, supplement, or practice.';
COMMENT ON COLUMN edfi.Intervention.DeliveryMethodDescriptorId IS 'The way in which an intervention was implemented.';
COMMENT ON COLUMN edfi.Intervention.BeginDate IS 'The start date for the intervention implementation.';
COMMENT ON COLUMN edfi.Intervention.EndDate IS 'The end date for the intervention implementation.';
COMMENT ON COLUMN edfi.Intervention.MinDosage IS 'The minimum duration of time in minutes that may be assigned for the intervention.';
COMMENT ON COLUMN edfi.Intervention.MaxDosage IS 'The maximum duration of time in minutes that may be assigned for the intervention.';
COMMENT ON COLUMN edfi.Intervention.Namespace IS 'Namespace for the intervention.';

-- Extended Properties [edfi].[InterventionAppropriateGradeLevel] --
COMMENT ON TABLE edfi.InterventionAppropriateGradeLevel IS 'Grade levels for the intervention. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.InterventionAppropriateGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionAppropriateGradeLevel.GradeLevelDescriptorId IS 'Grade levels for the intervention. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.InterventionAppropriateGradeLevel.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';

-- Extended Properties [edfi].[InterventionAppropriateSex] --
COMMENT ON TABLE edfi.InterventionAppropriateSex IS 'Sexes for the intervention. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.InterventionAppropriateSex.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionAppropriateSex.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.InterventionAppropriateSex.SexDescriptorId IS 'Sexes for the intervention. If omitted, considered generally applicable.';

-- Extended Properties [edfi].[InterventionClassDescriptor] --
COMMENT ON TABLE edfi.InterventionClassDescriptor IS 'The way in which an intervention is used: curriculum, supplement, or practice.';
COMMENT ON COLUMN edfi.InterventionClassDescriptor.InterventionClassDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[InterventionDiagnosis] --
COMMENT ON TABLE edfi.InterventionDiagnosis IS 'Targeted purpose of the intervention.';
COMMENT ON COLUMN edfi.InterventionDiagnosis.DiagnosisDescriptorId IS 'Targeted purpose of the intervention.';
COMMENT ON COLUMN edfi.InterventionDiagnosis.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionDiagnosis.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';

-- Extended Properties [edfi].[InterventionEducationContent] --
COMMENT ON TABLE edfi.InterventionEducationContent IS 'Relates the education content source to the education content.';
COMMENT ON COLUMN edfi.InterventionEducationContent.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.InterventionEducationContent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionEducationContent.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';

-- Extended Properties [edfi].[InterventionEffectivenessRatingDescriptor] --
COMMENT ON TABLE edfi.InterventionEffectivenessRatingDescriptor IS 'An intervention demonstrates effectiveness if the research has shown that the program caused an improvement in outcomes. Rating Values: positive effects, potentially positive effects, mixed effects, potentially negative effects, negative effects, and no discernible effects.';
COMMENT ON COLUMN edfi.InterventionEffectivenessRatingDescriptor.InterventionEffectivenessRatingDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[InterventionInterventionPrescription] --
COMMENT ON TABLE edfi.InterventionInterventionPrescription IS 'The reference to the intervention prescription being followed in this intervention implementation.';
COMMENT ON COLUMN edfi.InterventionInterventionPrescription.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionInterventionPrescription.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.InterventionInterventionPrescription.InterventionPrescriptionEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionInterventionPrescription.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';

-- Extended Properties [edfi].[InterventionLearningResourceMetadataURI] --
COMMENT ON TABLE edfi.InterventionLearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';
COMMENT ON COLUMN edfi.InterventionLearningResourceMetadataURI.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionLearningResourceMetadataURI.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.InterventionLearningResourceMetadataURI.LearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';

-- Extended Properties [edfi].[InterventionMeetingTime] --
COMMENT ON TABLE edfi.InterventionMeetingTime IS 'The times at which this intervention is scheduled to meet.';
COMMENT ON COLUMN edfi.InterventionMeetingTime.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionMeetingTime.EndTime IS 'An indication of the time of day the meeting time ends.';
COMMENT ON COLUMN edfi.InterventionMeetingTime.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.InterventionMeetingTime.StartTime IS 'An indication of the time of day the meeting time begins.';

-- Extended Properties [edfi].[InterventionPopulationServed] --
COMMENT ON TABLE edfi.InterventionPopulationServed IS 'A subset of students that are the focus of the intervention.';
COMMENT ON COLUMN edfi.InterventionPopulationServed.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPopulationServed.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.InterventionPopulationServed.PopulationServedDescriptorId IS 'A subset of students that are the focus of the intervention.';

-- Extended Properties [edfi].[InterventionPrescription] --
COMMENT ON TABLE edfi.InterventionPrescription IS 'This entity represents a formal prescription of an instructional approach focusing on the specific techniques and materials used to teach a given subject. This can be prescribed by academic research, an interventions vendor, or another entity.';
COMMENT ON COLUMN edfi.InterventionPrescription.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPrescription.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';
COMMENT ON COLUMN edfi.InterventionPrescription.InterventionClassDescriptorId IS 'The way in which an intervention is used: curriculum, supplement, or practice.';
COMMENT ON COLUMN edfi.InterventionPrescription.DeliveryMethodDescriptorId IS 'The way in which an intervention was implemented: individual, small group, whole class, or whole school.';
COMMENT ON COLUMN edfi.InterventionPrescription.MinDosage IS 'The minimum duration of time in minutes that is recommended for the intervention.';
COMMENT ON COLUMN edfi.InterventionPrescription.MaxDosage IS 'The maximum duration of time in minutes that is recommended for the intervention.';
COMMENT ON COLUMN edfi.InterventionPrescription.Namespace IS 'Namespace for the intervention.';

-- Extended Properties [edfi].[InterventionPrescriptionAppropriateGradeLevel] --
COMMENT ON TABLE edfi.InterventionPrescriptionAppropriateGradeLevel IS 'Grade levels for the prescribed intervention. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.InterventionPrescriptionAppropriateGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPrescriptionAppropriateGradeLevel.GradeLevelDescriptorId IS 'Grade levels for the prescribed intervention. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.InterventionPrescriptionAppropriateGradeLevel.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';

-- Extended Properties [edfi].[InterventionPrescriptionAppropriateSex] --
COMMENT ON TABLE edfi.InterventionPrescriptionAppropriateSex IS 'Sexes for the intervention prescription. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.InterventionPrescriptionAppropriateSex.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPrescriptionAppropriateSex.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';
COMMENT ON COLUMN edfi.InterventionPrescriptionAppropriateSex.SexDescriptorId IS 'Sexes for the intervention prescription. If omitted, considered generally applicable.';

-- Extended Properties [edfi].[InterventionPrescriptionDiagnosis] --
COMMENT ON TABLE edfi.InterventionPrescriptionDiagnosis IS 'Targeted purpose of the intervention prescription.';
COMMENT ON COLUMN edfi.InterventionPrescriptionDiagnosis.DiagnosisDescriptorId IS 'Targeted purpose of the intervention prescription.';
COMMENT ON COLUMN edfi.InterventionPrescriptionDiagnosis.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPrescriptionDiagnosis.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';

-- Extended Properties [edfi].[InterventionPrescriptionEducationContent] --
COMMENT ON TABLE edfi.InterventionPrescriptionEducationContent IS 'Relates the education content source to the education content.';
COMMENT ON COLUMN edfi.InterventionPrescriptionEducationContent.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.InterventionPrescriptionEducationContent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPrescriptionEducationContent.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';

-- Extended Properties [edfi].[InterventionPrescriptionLearningResourceMetadataURI] --
COMMENT ON TABLE edfi.InterventionPrescriptionLearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';
COMMENT ON COLUMN edfi.InterventionPrescriptionLearningResourceMetadataURI.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPrescriptionLearningResourceMetadataURI.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';
COMMENT ON COLUMN edfi.InterventionPrescriptionLearningResourceMetadataURI.LearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';

-- Extended Properties [edfi].[InterventionPrescriptionPopulationServed] --
COMMENT ON TABLE edfi.InterventionPrescriptionPopulationServed IS 'A subset of students that are the focus of the intervention prescription.';
COMMENT ON COLUMN edfi.InterventionPrescriptionPopulationServed.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPrescriptionPopulationServed.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';
COMMENT ON COLUMN edfi.InterventionPrescriptionPopulationServed.PopulationServedDescriptorId IS 'A subset of students that are the focus of the intervention prescription.';

-- Extended Properties [edfi].[InterventionPrescriptionURI] --
COMMENT ON TABLE edfi.InterventionPrescriptionURI IS 'The URI (typical a URL) pointing to an education content item.';
COMMENT ON COLUMN edfi.InterventionPrescriptionURI.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionPrescriptionURI.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';
COMMENT ON COLUMN edfi.InterventionPrescriptionURI.URI IS 'The URI (typical a URL) pointing to an education content item.';

-- Extended Properties [edfi].[InterventionStaff] --
COMMENT ON TABLE edfi.InterventionStaff IS 'Relates the staff member associated with the Intervention.';
COMMENT ON COLUMN edfi.InterventionStaff.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStaff.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.InterventionStaff.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[InterventionStudy] --
COMMENT ON TABLE edfi.InterventionStudy IS 'An experimental or quasi-experimental study of an intervention technique.';
COMMENT ON COLUMN edfi.InterventionStudy.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudy.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';
COMMENT ON COLUMN edfi.InterventionStudy.InterventionPrescriptionEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudy.InterventionPrescriptionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention prescription.';
COMMENT ON COLUMN edfi.InterventionStudy.Participants IS 'The number of participants observed in the study.';
COMMENT ON COLUMN edfi.InterventionStudy.DeliveryMethodDescriptorId IS 'The way in which an intervention was implemented: individual, small group, whole class, or whole school.';
COMMENT ON COLUMN edfi.InterventionStudy.InterventionClassDescriptorId IS 'The way in which an intervention is used: curriculum, supplement, or practice.';

-- Extended Properties [edfi].[InterventionStudyAppropriateGradeLevel] --
COMMENT ON TABLE edfi.InterventionStudyAppropriateGradeLevel IS 'Grade levels participating in this study.';
COMMENT ON COLUMN edfi.InterventionStudyAppropriateGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudyAppropriateGradeLevel.GradeLevelDescriptorId IS 'Grade levels participating in this study.';
COMMENT ON COLUMN edfi.InterventionStudyAppropriateGradeLevel.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';

-- Extended Properties [edfi].[InterventionStudyAppropriateSex] --
COMMENT ON TABLE edfi.InterventionStudyAppropriateSex IS 'Sexes participating in this study. If omitted, considered generally applicable.';
COMMENT ON COLUMN edfi.InterventionStudyAppropriateSex.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudyAppropriateSex.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';
COMMENT ON COLUMN edfi.InterventionStudyAppropriateSex.SexDescriptorId IS 'Sexes participating in this study. If omitted, considered generally applicable.';

-- Extended Properties [edfi].[InterventionStudyEducationContent] --
COMMENT ON TABLE edfi.InterventionStudyEducationContent IS 'Relates the education content source to the education content.';
COMMENT ON COLUMN edfi.InterventionStudyEducationContent.ContentIdentifier IS 'A unique identifier for the education content.';
COMMENT ON COLUMN edfi.InterventionStudyEducationContent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudyEducationContent.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';

-- Extended Properties [edfi].[InterventionStudyInterventionEffectiveness] --
COMMENT ON TABLE edfi.InterventionStudyInterventionEffectiveness IS 'Measurement of the effectiveness of the intervention study per diagnosis.';
COMMENT ON COLUMN edfi.InterventionStudyInterventionEffectiveness.DiagnosisDescriptorId IS 'Targeted purpose of the intervention (e.g., attendance issue, dropout risk) for which the effectiveness is measured.';
COMMENT ON COLUMN edfi.InterventionStudyInterventionEffectiveness.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudyInterventionEffectiveness.GradeLevelDescriptorId IS 'Grade level for which effectiveness is measured.';
COMMENT ON COLUMN edfi.InterventionStudyInterventionEffectiveness.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';
COMMENT ON COLUMN edfi.InterventionStudyInterventionEffectiveness.PopulationServedDescriptorId IS 'Population for which effectiveness is measured.';
COMMENT ON COLUMN edfi.InterventionStudyInterventionEffectiveness.ImprovementIndex IS 'Along a percentile distribution of students, the improvement index represents the change in an average student''s percentile rank that is considered to be due to the intervention.';
COMMENT ON COLUMN edfi.InterventionStudyInterventionEffectiveness.InterventionEffectivenessRatingDescriptorId IS 'An intervention demonstrates effectiveness if the research has shown that the program caused an improvement in outcomes. Values: positive effects, potentially positive effects, mixed effects, potentially negative effects, negative effects, and no discernible effects.';

-- Extended Properties [edfi].[InterventionStudyLearningResourceMetadataURI] --
COMMENT ON TABLE edfi.InterventionStudyLearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';
COMMENT ON COLUMN edfi.InterventionStudyLearningResourceMetadataURI.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudyLearningResourceMetadataURI.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';
COMMENT ON COLUMN edfi.InterventionStudyLearningResourceMetadataURI.LearningResourceMetadataURI IS 'The URI (typical a URL) pointing to the metadata entry in a LRMI metadata repository, which describes this content item.';

-- Extended Properties [edfi].[InterventionStudyPopulationServed] --
COMMENT ON TABLE edfi.InterventionStudyPopulationServed IS 'A subset of students that are the focus of the intervention study.';
COMMENT ON COLUMN edfi.InterventionStudyPopulationServed.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudyPopulationServed.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';
COMMENT ON COLUMN edfi.InterventionStudyPopulationServed.PopulationServedDescriptorId IS 'A subset of students that are the focus of the intervention study.';

-- Extended Properties [edfi].[InterventionStudyStateAbbreviation] --
COMMENT ON TABLE edfi.InterventionStudyStateAbbreviation IS 'The abbreviation for the state (within the United States) or outlying area, the school system of which the participants of the study are considered to be a part.';
COMMENT ON COLUMN edfi.InterventionStudyStateAbbreviation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudyStateAbbreviation.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';
COMMENT ON COLUMN edfi.InterventionStudyStateAbbreviation.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area, the school system of which the participants of the study are considered to be a part.';

-- Extended Properties [edfi].[InterventionStudyURI] --
COMMENT ON TABLE edfi.InterventionStudyURI IS 'The URI (typical a URL) pointing to an education content item.';
COMMENT ON COLUMN edfi.InterventionStudyURI.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionStudyURI.InterventionStudyIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention study.';
COMMENT ON COLUMN edfi.InterventionStudyURI.URI IS 'The URI (typical a URL) pointing to an education content item.';

-- Extended Properties [edfi].[InterventionURI] --
COMMENT ON TABLE edfi.InterventionURI IS 'The URI (typical a URL) pointing to an education content item.';
COMMENT ON COLUMN edfi.InterventionURI.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.InterventionURI.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.InterventionURI.URI IS 'The URI (typical a URL) pointing to an education content item.';

-- Extended Properties [edfi].[LanguageDescriptor] --
COMMENT ON TABLE edfi.LanguageDescriptor IS 'This descriptor defines the language(s) that are spoken or written. It is strongly recommended that entries use only ISO 639-2 language codes: for CodeValue, use the 3 character code; for ShortDescription and Description use the full language name.';
COMMENT ON COLUMN edfi.LanguageDescriptor.LanguageDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LanguageInstructionProgramServiceDescriptor] --
COMMENT ON TABLE edfi.LanguageInstructionProgramServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a language instruction program.';
COMMENT ON COLUMN edfi.LanguageInstructionProgramServiceDescriptor.LanguageInstructionProgramServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LanguageUseDescriptor] --
COMMENT ON TABLE edfi.LanguageUseDescriptor IS 'The category denoting how a language is used.';
COMMENT ON COLUMN edfi.LanguageUseDescriptor.LanguageUseDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LearningObjective] --
COMMENT ON TABLE edfi.LearningObjective IS 'This entity represents identified LearningObjectives for courses in specific grades.';
COMMENT ON COLUMN edfi.LearningObjective.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningObjective.Namespace IS 'Namespace for the learning objective.';
COMMENT ON COLUMN edfi.LearningObjective.Objective IS 'The designated title of the learning objective.';
COMMENT ON COLUMN edfi.LearningObjective.Description IS 'The description of the learning objective.';
COMMENT ON COLUMN edfi.LearningObjective.Nomenclature IS 'Reflects the specific nomenclature used for the learning objective.';
COMMENT ON COLUMN edfi.LearningObjective.SuccessCriteria IS 'One or more statements that describes the criteria used by teachers and students to check for attainment of a learning objective. This criteria gives clear indications as to the degree to which learning is moving through the Zone or Proximal Development toward independent achievement of the learning objective.';
COMMENT ON COLUMN edfi.LearningObjective.ParentLearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningObjective.ParentNamespace IS 'Namespace for the learning objective.';

-- Extended Properties [edfi].[LearningObjectiveAcademicSubject] --
COMMENT ON TABLE edfi.LearningObjectiveAcademicSubject IS 'The description of the content or subject area of an assessment.';
COMMENT ON COLUMN edfi.LearningObjectiveAcademicSubject.AcademicSubjectDescriptorId IS 'The description of the content or subject area of an assessment.';
COMMENT ON COLUMN edfi.LearningObjectiveAcademicSubject.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningObjectiveAcademicSubject.Namespace IS 'Namespace for the learning objective.';

-- Extended Properties [edfi].[LearningObjectiveContentStandard] --
COMMENT ON TABLE edfi.LearningObjectiveContentStandard IS 'A reference to the type of content standard (e.g., state, national)';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.Namespace IS 'Namespace for the learning objective.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.Title IS 'The name of the content standard, for example Common Core.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.Version IS 'The version identifier for the content.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.URI IS 'An unambiguous reference to the standards using a network-resolvable URI.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.PublicationDate IS 'The date on which this content was first published.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.PublicationYear IS 'The year at which this content was first published.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.PublicationStatusDescriptorId IS 'The publication status of the document (i.e., Adopted, Draft, Published, Deprecated, Unknown).';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.MandatingEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.BeginDate IS 'The beginning of the period during which this learning standard document is intended for use.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandard.EndDate IS 'The end of the period during which this learning standard document is intended for use.';

-- Extended Properties [edfi].[LearningObjectiveContentStandardAuthor] --
COMMENT ON TABLE edfi.LearningObjectiveContentStandardAuthor IS 'The person or organization chiefly responsible for the intellectual content of the standard.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandardAuthor.Author IS 'The person or organization chiefly responsible for the intellectual content of the standard.';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandardAuthor.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningObjectiveContentStandardAuthor.Namespace IS 'Namespace for the learning objective.';

-- Extended Properties [edfi].[LearningObjectiveGradeLevel] --
COMMENT ON TABLE edfi.LearningObjectiveGradeLevel IS 'The grade level for which the learning objective is targeted. The semantics of null is assumed to mean that the learning objective is not associated with any grade level.';
COMMENT ON COLUMN edfi.LearningObjectiveGradeLevel.GradeLevelDescriptorId IS 'The grade level for which the learning objective is targeted. The semantics of null is assumed to mean that the learning objective is not associated with any grade level.';
COMMENT ON COLUMN edfi.LearningObjectiveGradeLevel.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningObjectiveGradeLevel.Namespace IS 'Namespace for the learning objective.';

-- Extended Properties [edfi].[LearningObjectiveLearningStandard] --
COMMENT ON TABLE edfi.LearningObjectiveLearningStandard IS 'Learning standard(s) included in this objective.';
COMMENT ON COLUMN edfi.LearningObjectiveLearningStandard.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningObjectiveLearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningObjectiveLearningStandard.Namespace IS 'Namespace for the learning objective.';

-- Extended Properties [edfi].[LearningStandard] --
COMMENT ON TABLE edfi.LearningStandard IS 'A statement that describes a specific competency or academic standard.';
COMMENT ON COLUMN edfi.LearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningStandard.Description IS 'The text of the statement. The textual content that either describes a specific competency such as "Apply the Pythagorean Theorem to determine unknown side lengths in right triangles in real-world and mathematical problems in two and three dimensions." or describes a less granular group of competencies within the taxonomy of the standards document, e.g. "Understand and apply the Pythagorean Theorem," or "Geometry".';
COMMENT ON COLUMN edfi.LearningStandard.LearningStandardItemCode IS 'A code designated by the promulgating body to identify the statement, e.g. 1.N.3 (usually not globally unique).';
COMMENT ON COLUMN edfi.LearningStandard.URI IS 'An unambiguous reference to the statement using a network-resolvable URI.';
COMMENT ON COLUMN edfi.LearningStandard.CourseTitle IS 'The official course title with which this learning standard is associated.';
COMMENT ON COLUMN edfi.LearningStandard.SuccessCriteria IS 'One or more statements that describes the criteria used by teachers and students to check for attainment of a learning standard. This criteria gives clear indications as to the degree to which learning is moving through the Zone or Proximal Development toward independent achievement of the learning standard.';
COMMENT ON COLUMN edfi.LearningStandard.ParentLearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningStandard.Namespace IS 'The namespace of the organization or entity who governs the standard. It is recommended the namespaces observe a URI format and begin with a domain name under the governing organization or entity control.';
COMMENT ON COLUMN edfi.LearningStandard.LearningStandardCategoryDescriptorId IS 'An additional classification of the type of a specific learning standard.';
COMMENT ON COLUMN edfi.LearningStandard.LearningStandardScopeDescriptorId IS 'Signals the scope of usage the standard. Does not necessarily relate the standard to the governing body.';

-- Extended Properties [edfi].[LearningStandardAcademicSubject] --
COMMENT ON TABLE edfi.LearningStandardAcademicSubject IS 'Subject area for the learning standard.';
COMMENT ON COLUMN edfi.LearningStandardAcademicSubject.AcademicSubjectDescriptorId IS 'Subject area for the learning standard.';
COMMENT ON COLUMN edfi.LearningStandardAcademicSubject.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';

-- Extended Properties [edfi].[LearningStandardCategoryDescriptor] --
COMMENT ON TABLE edfi.LearningStandardCategoryDescriptor IS 'An additional classification of the type of a specific learning standard.';
COMMENT ON COLUMN edfi.LearningStandardCategoryDescriptor.LearningStandardCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LearningStandardContentStandard] --
COMMENT ON TABLE edfi.LearningStandardContentStandard IS 'The content standard from which the learning standard was derived.';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.Title IS 'The name of the content standard, for example Common Core.';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.Version IS 'The version identifier for the content.';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.URI IS 'An unambiguous reference to the standards using a network-resolvable URI.';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.PublicationDate IS 'The date on which this content was first published.';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.PublicationYear IS 'The year at which this content was first published.';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.PublicationStatusDescriptorId IS 'The publication status of the document (i.e., Adopted, Draft, Published, Deprecated, Unknown).';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.MandatingEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.BeginDate IS 'The beginning of the period during which this learning standard document is intended for use.';
COMMENT ON COLUMN edfi.LearningStandardContentStandard.EndDate IS 'The end of the period during which this learning standard document is intended for use.';

-- Extended Properties [edfi].[LearningStandardContentStandardAuthor] --
COMMENT ON TABLE edfi.LearningStandardContentStandardAuthor IS 'The person or organization chiefly responsible for the intellectual content of the standard.';
COMMENT ON COLUMN edfi.LearningStandardContentStandardAuthor.Author IS 'The person or organization chiefly responsible for the intellectual content of the standard.';
COMMENT ON COLUMN edfi.LearningStandardContentStandardAuthor.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';

-- Extended Properties [edfi].[LearningStandardEquivalenceAssociation] --
COMMENT ON TABLE edfi.LearningStandardEquivalenceAssociation IS 'Indicates a directional association of equivalence from a source to a target learning standard.';
COMMENT ON COLUMN edfi.LearningStandardEquivalenceAssociation.Namespace IS 'The namespace of the organization that has created and owns the association.';
COMMENT ON COLUMN edfi.LearningStandardEquivalenceAssociation.SourceLearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningStandardEquivalenceAssociation.TargetLearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningStandardEquivalenceAssociation.EffectiveDate IS 'The date that the association is considered to be applicable or effective.';
COMMENT ON COLUMN edfi.LearningStandardEquivalenceAssociation.LearningStandardEquivalenceStrengthDescriptorId IS 'A measure that indicates the strength or quality of the equivalence relationship.';
COMMENT ON COLUMN edfi.LearningStandardEquivalenceAssociation.LearningStandardEquivalenceStrengthDescription IS 'Captures supplemental information on the relationship. Recommended for use only when the match is partial.';

-- Extended Properties [edfi].[LearningStandardEquivalenceStrengthDescriptor] --
COMMENT ON TABLE edfi.LearningStandardEquivalenceStrengthDescriptor IS 'A measure that indicates the strength or quality of the equivalence relationship.';
COMMENT ON COLUMN edfi.LearningStandardEquivalenceStrengthDescriptor.LearningStandardEquivalenceStrengthDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LearningStandardGradeLevel] --
COMMENT ON TABLE edfi.LearningStandardGradeLevel IS 'The grade levels for the specific learning standard.';
COMMENT ON COLUMN edfi.LearningStandardGradeLevel.GradeLevelDescriptorId IS 'The grade levels for the specific learning standard.';
COMMENT ON COLUMN edfi.LearningStandardGradeLevel.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';

-- Extended Properties [edfi].[LearningStandardIdentificationCode] --
COMMENT ON TABLE edfi.LearningStandardIdentificationCode IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a learning standard.';
COMMENT ON COLUMN edfi.LearningStandardIdentificationCode.ContentStandardName IS 'The name of the content standard, for example Common Core.';
COMMENT ON COLUMN edfi.LearningStandardIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code assigned to a Learning Standard.';
COMMENT ON COLUMN edfi.LearningStandardIdentificationCode.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';

-- Extended Properties [edfi].[LearningStandardPrerequisiteLearningStandard] --
COMMENT ON TABLE edfi.LearningStandardPrerequisiteLearningStandard IS 'The unique identifier of a prerequisite learning standard item, a competency needed prior to learning this one. (Some items may have no prerequisites others may have one or more prerequisites. This should only be used to represent the immediate predecessors in a competency-based pathway, i.e. not prerequisites of prerequisites).';
COMMENT ON COLUMN edfi.LearningStandardPrerequisiteLearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.LearningStandardPrerequisiteLearningStandard.PrerequisiteLearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';

-- Extended Properties [edfi].[LearningStandardScopeDescriptor] --
COMMENT ON TABLE edfi.LearningStandardScopeDescriptor IS 'Signals the scope of usage the standard. Does not necessarily relate the standard to the governing body.';
COMMENT ON COLUMN edfi.LearningStandardScopeDescriptor.LearningStandardScopeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LevelOfEducationDescriptor] --
COMMENT ON TABLE edfi.LevelOfEducationDescriptor IS 'This descriptor defines the different levels of education achievable.';
COMMENT ON COLUMN edfi.LevelOfEducationDescriptor.LevelOfEducationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LicenseStatusDescriptor] --
COMMENT ON TABLE edfi.LicenseStatusDescriptor IS 'This descriptor defines the license statuses.';
COMMENT ON COLUMN edfi.LicenseStatusDescriptor.LicenseStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LicenseTypeDescriptor] --
COMMENT ON TABLE edfi.LicenseTypeDescriptor IS 'This descriptor defines the type of a license.';
COMMENT ON COLUMN edfi.LicenseTypeDescriptor.LicenseTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LimitedEnglishProficiencyDescriptor] --
COMMENT ON TABLE edfi.LimitedEnglishProficiencyDescriptor IS 'This descriptor defines the indications that the student has been identified as limited English proficient by the Language Proficiency Assessment Committee (LPAC), or English proficient. The mapping of descriptor values to known Ed-Fi enumeration values is required.';
COMMENT ON COLUMN edfi.LimitedEnglishProficiencyDescriptor.LimitedEnglishProficiencyDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LocalAccount] --
COMMENT ON TABLE edfi.LocalAccount IS 'The set of account codes defined by an education organization for a fiscal year. It provides a formal record of the debits and credits relating to the specific account.';
COMMENT ON COLUMN edfi.LocalAccount.AccountIdentifier IS 'Code value for the valid combination of account dimensions by LEA under which financials are reported. ';
COMMENT ON COLUMN edfi.LocalAccount.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LocalAccount.FiscalYear IS 'The fiscal year for the account.';
COMMENT ON COLUMN edfi.LocalAccount.AccountName IS 'A descriptive name for the account.';
COMMENT ON COLUMN edfi.LocalAccount.ChartOfAccountIdentifier IS 'SEA populated code value for the valid combination of account dimensions under which financials are reported.';
COMMENT ON COLUMN edfi.LocalAccount.ChartOfAccountEducationOrganizationId IS 'The identifier assigned to an education organization.';

-- Extended Properties [edfi].[LocalAccountReportingTag] --
COMMENT ON TABLE edfi.LocalAccountReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.LocalAccountReportingTag.AccountIdentifier IS 'Code value for the valid combination of account dimensions by LEA under which financials are reported. ';
COMMENT ON COLUMN edfi.LocalAccountReportingTag.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LocalAccountReportingTag.FiscalYear IS 'The fiscal year for the account.';
COMMENT ON COLUMN edfi.LocalAccountReportingTag.ReportingTagDescriptorId IS 'A descriptor used at the dimension and/or chart of account levels to demote specific state needs for reporting.';
COMMENT ON COLUMN edfi.LocalAccountReportingTag.TagValue IS 'The value associated with the reporting tag.';

-- Extended Properties [edfi].[LocalActual] --
COMMENT ON TABLE edfi.LocalActual IS 'The set of local education agency or charter management organization expense or revenue amounts.';
COMMENT ON COLUMN edfi.LocalActual.AccountIdentifier IS 'Code value for the valid combination of account dimensions by LEA under which financials are reported. ';
COMMENT ON COLUMN edfi.LocalActual.AsOfDate IS 'The date of the reported amount for the account.';
COMMENT ON COLUMN edfi.LocalActual.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LocalActual.FiscalYear IS 'The fiscal year for the account.';
COMMENT ON COLUMN edfi.LocalActual.Amount IS 'Current balance for the account.';
COMMENT ON COLUMN edfi.LocalActual.FinancialCollectionDescriptorId IS 'The accounting period or grouping for which the amount is collected.';

-- Extended Properties [edfi].[LocalBudget] --
COMMENT ON TABLE edfi.LocalBudget IS 'The set of local education agency or charter management organization budget amounts.';
COMMENT ON COLUMN edfi.LocalBudget.AccountIdentifier IS 'Code value for the valid combination of account dimensions by LEA under which financials are reported. ';
COMMENT ON COLUMN edfi.LocalBudget.AsOfDate IS 'The date of the reported amount for the account.';
COMMENT ON COLUMN edfi.LocalBudget.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LocalBudget.FiscalYear IS 'The fiscal year for the account.';
COMMENT ON COLUMN edfi.LocalBudget.Amount IS 'Current balance for the account.';
COMMENT ON COLUMN edfi.LocalBudget.FinancialCollectionDescriptorId IS 'The accounting period or grouping for which the amount is collected.';

-- Extended Properties [edfi].[LocalContractedStaff] --
COMMENT ON TABLE edfi.LocalContractedStaff IS 'The set of local education agency or charter management organization contracted staff amounts.';
COMMENT ON COLUMN edfi.LocalContractedStaff.AccountIdentifier IS 'Code value for the valid combination of account dimensions by LEA under which financials are reported. ';
COMMENT ON COLUMN edfi.LocalContractedStaff.AsOfDate IS 'The date of the reported amount for the account.';
COMMENT ON COLUMN edfi.LocalContractedStaff.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LocalContractedStaff.FiscalYear IS 'The fiscal year for the account.';
COMMENT ON COLUMN edfi.LocalContractedStaff.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.LocalContractedStaff.Amount IS 'Current balance for the account.';
COMMENT ON COLUMN edfi.LocalContractedStaff.FinancialCollectionDescriptorId IS 'The accounting period or grouping for which the amount is collected.';

-- Extended Properties [edfi].[LocaleDescriptor] --
COMMENT ON TABLE edfi.LocaleDescriptor IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';
COMMENT ON COLUMN edfi.LocaleDescriptor.LocaleDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LocalEducationAgency] --
COMMENT ON TABLE edfi.LocalEducationAgency IS 'This entity represents an administrative unit at the local level which exists primarily to operate schools or to contract for educational services. It includes school districts, charter schools, charter management organizations, or other local administrative organizations.';
COMMENT ON COLUMN edfi.LocalEducationAgency.LocalEducationAgencyId IS 'The identifier assigned to a local education agency.';
COMMENT ON COLUMN edfi.LocalEducationAgency.LocalEducationAgencyCategoryDescriptorId IS 'The category of local education agency/district.';
COMMENT ON COLUMN edfi.LocalEducationAgency.CharterStatusDescriptorId IS 'A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.';
COMMENT ON COLUMN edfi.LocalEducationAgency.ParentLocalEducationAgencyId IS 'The identifier assigned to a local education agency.';
COMMENT ON COLUMN edfi.LocalEducationAgency.EducationServiceCenterId IS 'The identifier assigned to an education service center.';
COMMENT ON COLUMN edfi.LocalEducationAgency.StateEducationAgencyId IS 'The identifier assigned to a state education agency.';

-- Extended Properties [edfi].[LocalEducationAgencyAccountability] --
COMMENT ON TABLE edfi.LocalEducationAgencyAccountability IS 'This entity maintains information about federal reporting and accountability for local education agencies.';
COMMENT ON COLUMN edfi.LocalEducationAgencyAccountability.LocalEducationAgencyId IS 'The identifier assigned to a local education agency.';
COMMENT ON COLUMN edfi.LocalEducationAgencyAccountability.SchoolYear IS 'The school year for which the accountability is reported.';
COMMENT ON COLUMN edfi.LocalEducationAgencyAccountability.GunFreeSchoolsActReportingStatusDescriptorId IS 'An indication of whether the school or Local Education Agency (LEA) submitted a Gun-Free Schools Act (GFSA) of 1994 report to the state, as defined by Title 18, Section 921.';
COMMENT ON COLUMN edfi.LocalEducationAgencyAccountability.SchoolChoiceImplementStatusDescriptorId IS 'An indication of whether the LEA was able to implement the provisions for public school choice under Title I, Part A, Section 1116 of ESEA as amended.';

-- Extended Properties [edfi].[LocalEducationAgencyCategoryDescriptor] --
COMMENT ON TABLE edfi.LocalEducationAgencyCategoryDescriptor IS 'The category of local education agency/district. For example: Independent or Charter.';
COMMENT ON COLUMN edfi.LocalEducationAgencyCategoryDescriptor.LocalEducationAgencyCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[LocalEducationAgencyFederalFunds] --
COMMENT ON TABLE edfi.LocalEducationAgencyFederalFunds IS 'Contains the information about the reception and use of federal funds for reporting purposes.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.FiscalYear IS 'The fiscal year for which the federal funds are received.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.LocalEducationAgencyId IS 'The identifier assigned to a local education agency.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.InnovativeDollarsSpent IS 'The total Title V, Part A funds expended by LEAs.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.InnovativeDollarsSpentStrategicPriorities IS 'The total amount of Title V, Part A funds expended by LEAs for the four strategic priorities.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.InnovativeProgramsFundsReceived IS 'The total Title V, Part A funds received by LEAs.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.SchoolImprovementAllocation IS 'The amount of Section 1003(a) and 1003(g) allocations to LEAs.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.SchoolImprovementReservedFundsPercentage IS 'An indication of the percentage of the Title I, Part A allocation that the SEA reserved in accordance with Section 1003(a) of ESEA and 200.100(a) of ED''s regulations governing the reservation of funds for school improvement under Section 1003(a) of ESEA.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.SupplementalEducationalServicesFundsSpent IS 'The dollar amount spent on supplemental educational services during the school year under Title I, Part A, Section 1116 of ESEA as amended.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.SupplementalEducationalServicesPerPupilExpenditure IS 'The maximum dollar amount that may be spent per child for expenditures related to supplemental educational services under Title I of the ESEA.';
COMMENT ON COLUMN edfi.LocalEducationAgencyFederalFunds.StateAssessmentAdministrationFunding IS 'The percentage of funds used to administer assessments required by Section 1111(b) or to carry out other activities described in Section 6111 and other activities related to ensuring that the state''s schools and LEAs are held accountable for results.';

-- Extended Properties [edfi].[LocalEncumbrance] --
COMMENT ON TABLE edfi.LocalEncumbrance IS 'The set of local education agency or charter management organization encumbrance amounts.';
COMMENT ON COLUMN edfi.LocalEncumbrance.AccountIdentifier IS 'Code value for the valid combination of account dimensions by LEA under which financials are reported. ';
COMMENT ON COLUMN edfi.LocalEncumbrance.AsOfDate IS 'The date of the reported amount for the account.';
COMMENT ON COLUMN edfi.LocalEncumbrance.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LocalEncumbrance.FiscalYear IS 'The fiscal year for the account.';
COMMENT ON COLUMN edfi.LocalEncumbrance.Amount IS 'Current balance for the account.';
COMMENT ON COLUMN edfi.LocalEncumbrance.FinancialCollectionDescriptorId IS 'The accounting period or grouping for which the amount is collected.';

-- Extended Properties [edfi].[LocalPayroll] --
COMMENT ON TABLE edfi.LocalPayroll IS 'The set of local education agency or charter management organization payroll amounts.';
COMMENT ON COLUMN edfi.LocalPayroll.AccountIdentifier IS 'Code value for the valid combination of account dimensions by LEA under which financials are reported. ';
COMMENT ON COLUMN edfi.LocalPayroll.AsOfDate IS 'The date of the reported amount for the account.';
COMMENT ON COLUMN edfi.LocalPayroll.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.LocalPayroll.FiscalYear IS 'The fiscal year for the account.';
COMMENT ON COLUMN edfi.LocalPayroll.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.LocalPayroll.Amount IS 'Current balance for the account.';
COMMENT ON COLUMN edfi.LocalPayroll.FinancialCollectionDescriptorId IS 'The accounting period or grouping for which the amount is collected.';

-- Extended Properties [edfi].[Location] --
COMMENT ON TABLE edfi.Location IS 'This entity represents the physical space where students gather for a particular class/section. The location may be an indoor or outdoor area designated for the purpose of meeting the educational needs of students.';
COMMENT ON COLUMN edfi.Location.ClassroomIdentificationCode IS 'A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.Location.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.Location.MaximumNumberOfSeats IS 'The most number of seats the class can maintain.';
COMMENT ON COLUMN edfi.Location.OptimalNumberOfSeats IS 'The number of seats that is most favorable to the class.';

-- Extended Properties [edfi].[MagnetSpecialProgramEmphasisSchoolDescriptor] --
COMMENT ON TABLE edfi.MagnetSpecialProgramEmphasisSchoolDescriptor IS 'A school that has been designed to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing or eliminating racial isolation; and/or to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).';
COMMENT ON COLUMN edfi.MagnetSpecialProgramEmphasisSchoolDescriptor.MagnetSpecialProgramEmphasisSchoolDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[MediumOfInstructionDescriptor] --
COMMENT ON TABLE edfi.MediumOfInstructionDescriptor IS 'The media through which teachers provide instruction to students and students and teachers communicate about instructional matters.';
COMMENT ON COLUMN edfi.MediumOfInstructionDescriptor.MediumOfInstructionDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[MethodCreditEarnedDescriptor] --
COMMENT ON TABLE edfi.MethodCreditEarnedDescriptor IS 'The method the credits were earned, for example:  Classroom, Examination, Transfer.';
COMMENT ON COLUMN edfi.MethodCreditEarnedDescriptor.MethodCreditEarnedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[MigrantEducationProgramServiceDescriptor] --
COMMENT ON TABLE edfi.MigrantEducationProgramServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a migrant education program.';
COMMENT ON COLUMN edfi.MigrantEducationProgramServiceDescriptor.MigrantEducationProgramServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ModelEntityDescriptor] --
COMMENT ON TABLE edfi.ModelEntityDescriptor IS 'The class of a domain entity in the Ed-Fi data model.';
COMMENT ON COLUMN edfi.ModelEntityDescriptor.ModelEntityDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[MonitoredDescriptor] --
COMMENT ON TABLE edfi.MonitoredDescriptor IS 'This descriptor defines monitorization statuses for students who are no longer receiving language instruction program services.';
COMMENT ON COLUMN edfi.MonitoredDescriptor.MonitoredDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[NeglectedOrDelinquentProgramDescriptor] --
COMMENT ON TABLE edfi.NeglectedOrDelinquentProgramDescriptor IS 'This descriptor defines the type of program under ESEA Title I, Part D, Subpart 1 (state programs) or Subpart 2 (LEA).';
COMMENT ON COLUMN edfi.NeglectedOrDelinquentProgramDescriptor.NeglectedOrDelinquentProgramDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[NeglectedOrDelinquentProgramServiceDescriptor] --
COMMENT ON TABLE edfi.NeglectedOrDelinquentProgramServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a neglected or delinquent program.';
COMMENT ON COLUMN edfi.NeglectedOrDelinquentProgramServiceDescriptor.NeglectedOrDelinquentProgramServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[NetworkPurposeDescriptor] --
COMMENT ON TABLE edfi.NetworkPurposeDescriptor IS 'The purpose(s) of the network, e.g. shared services, collective procurement, etc.';
COMMENT ON COLUMN edfi.NetworkPurposeDescriptor.NetworkPurposeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ObjectDimension] --
COMMENT ON TABLE edfi.ObjectDimension IS 'The NCES object accounting dimension representing an expenditure. Per the NCES definition, this classification is used to describe the service or commodity obtained as the result of a specific expenditure, such as salaries, benefits, tuition reimbursement, and so forth.';
COMMENT ON COLUMN edfi.ObjectDimension.Code IS 'The code representation of the account object dimension.';
COMMENT ON COLUMN edfi.ObjectDimension.FiscalYear IS 'The fiscal year for which the account object dimension is valid.';
COMMENT ON COLUMN edfi.ObjectDimension.CodeName IS 'A description of the account object dimension.';

-- Extended Properties [edfi].[ObjectDimensionReportingTag] --
COMMENT ON TABLE edfi.ObjectDimensionReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.ObjectDimensionReportingTag.Code IS 'The code representation of the account object dimension.';
COMMENT ON COLUMN edfi.ObjectDimensionReportingTag.FiscalYear IS 'The fiscal year for which the account object dimension is valid.';
COMMENT ON COLUMN edfi.ObjectDimensionReportingTag.ReportingTagDescriptorId IS 'Optional tag for accountability reporting.';

-- Extended Properties [edfi].[ObjectiveAssessment] --
COMMENT ON TABLE edfi.ObjectiveAssessment IS 'This entity represents subtests that assess specific learning objectives.';
COMMENT ON COLUMN edfi.ObjectiveAssessment.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessment.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.ObjectiveAssessment.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessment.MaxRawScore IS 'The maximum raw score achievable across all assessment items that are correct and scored at the maximum.';
COMMENT ON COLUMN edfi.ObjectiveAssessment.PercentOfAssessment IS 'The percentage of the assessment that tests this objective.';
COMMENT ON COLUMN edfi.ObjectiveAssessment.Nomenclature IS 'Reflects the specific nomenclature used for this level of objective assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessment.Description IS 'The description of the objective assessment (e.g., vocabulary, measurement, or geometry).';
COMMENT ON COLUMN edfi.ObjectiveAssessment.ParentIdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.ObjectiveAssessment.AcademicSubjectDescriptorId IS 'The subject area of the objective assessment.';

-- Extended Properties [edfi].[ObjectiveAssessmentAssessmentItem] --
COMMENT ON TABLE edfi.ObjectiveAssessmentAssessmentItem IS 'References individual test items, if appropriate.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentAssessmentItem.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentAssessmentItem.AssessmentItemIdentificationCode IS 'A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentAssessmentItem.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentAssessmentItem.Namespace IS 'Namespace for the assessment.';

-- Extended Properties [edfi].[ObjectiveAssessmentLearningStandard] --
COMMENT ON TABLE edfi.ObjectiveAssessmentLearningStandard IS 'Learning standard tested by this objective assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentLearningStandard.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentLearningStandard.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentLearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.ObjectiveAssessmentLearningStandard.Namespace IS 'Namespace for the assessment.';

-- Extended Properties [edfi].[ObjectiveAssessmentPerformanceLevel] --
COMMENT ON TABLE edfi.ObjectiveAssessmentPerformanceLevel IS 'Definition of the performance levels and the associated cut scores. Three styles are supported: 1. Specification of performance level by minimum and maximum score, 2. Specification of performance level by cut score, using only minimum score, 3. Specification of performance level without any mapping to scores';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.AssessmentReportingMethodDescriptorId IS 'The method that the instructor of the class uses to report the performance and achievement of all students. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or numerical grade. In some cases, more than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.PerformanceLevelDescriptorId IS 'The performance level(s) defined for the assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.MinimumScore IS 'The minimum score required to make the indicated level of performance.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.MaximumScore IS 'The maximum score to make the indicated level of performance.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentPerformanceLevel.PerformanceLevelIndicatorName IS 'The name of the indicator being measured for a collection of performance level values.';

-- Extended Properties [edfi].[ObjectiveAssessmentScore] --
COMMENT ON TABLE edfi.ObjectiveAssessmentScore IS 'Definition of the scores to be expected from this objective assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentScore.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentScore.AssessmentReportingMethodDescriptorId IS 'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentScore.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentScore.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentScore.MinimumScore IS 'The minimum score possible on the assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentScore.MaximumScore IS 'The maximum score possible on the assessment.';
COMMENT ON COLUMN edfi.ObjectiveAssessmentScore.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [edfi].[OldEthnicityDescriptor] --
COMMENT ON TABLE edfi.OldEthnicityDescriptor IS 'Previous definition of Ethnicity combining Hispanic/Latino and Race.';
COMMENT ON COLUMN edfi.OldEthnicityDescriptor.OldEthnicityDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[OpenStaffPosition] --
COMMENT ON TABLE edfi.OpenStaffPosition IS 'This entity represents an open staff position that the education organization is seeking to fill.';
COMMENT ON COLUMN edfi.OpenStaffPosition.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.OpenStaffPosition.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';
COMMENT ON COLUMN edfi.OpenStaffPosition.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract desired for the position.';
COMMENT ON COLUMN edfi.OpenStaffPosition.StaffClassificationDescriptorId IS 'The titles of employment, official status, or rank of education staff.';
COMMENT ON COLUMN edfi.OpenStaffPosition.PositionTitle IS 'The descriptive name of an individual''s position.';
COMMENT ON COLUMN edfi.OpenStaffPosition.ProgramAssignmentDescriptorId IS 'The name of the program for which the open staff position will be assigned.';
COMMENT ON COLUMN edfi.OpenStaffPosition.DatePosted IS 'Date the open staff position was posted.';
COMMENT ON COLUMN edfi.OpenStaffPosition.DatePostingRemoved IS 'The date the posting was removed or filled.';
COMMENT ON COLUMN edfi.OpenStaffPosition.PostingResultDescriptorId IS 'Indication of whether the OpenStaffPosition was filled or retired without filling.';

-- Extended Properties [edfi].[OpenStaffPositionAcademicSubject] --
COMMENT ON TABLE edfi.OpenStaffPositionAcademicSubject IS 'The teaching field required for the open staff position.';
COMMENT ON COLUMN edfi.OpenStaffPositionAcademicSubject.AcademicSubjectDescriptorId IS 'The teaching field required for the open staff position.';
COMMENT ON COLUMN edfi.OpenStaffPositionAcademicSubject.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.OpenStaffPositionAcademicSubject.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';

-- Extended Properties [edfi].[OpenStaffPositionInstructionalGradeLevel] --
COMMENT ON TABLE edfi.OpenStaffPositionInstructionalGradeLevel IS 'The set of grade levels for which the position''s assignment is responsible.';
COMMENT ON COLUMN edfi.OpenStaffPositionInstructionalGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.OpenStaffPositionInstructionalGradeLevel.GradeLevelDescriptorId IS 'The set of grade levels for which the position''s assignment is responsible.';
COMMENT ON COLUMN edfi.OpenStaffPositionInstructionalGradeLevel.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';

-- Extended Properties [edfi].[OperationalStatusDescriptor] --
COMMENT ON TABLE edfi.OperationalStatusDescriptor IS 'The current operational status of the education organization (e.g., active, inactive).';
COMMENT ON COLUMN edfi.OperationalStatusDescriptor.OperationalStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[OperationalUnitDimension] --
COMMENT ON TABLE edfi.OperationalUnitDimension IS 'The NCES operational unit accounting dimension. This dimension is used to segregate costs by school and operational unit such as physical location, department, or other method.';
COMMENT ON COLUMN edfi.OperationalUnitDimension.Code IS 'The code representation of the account operational unit dimension.';
COMMENT ON COLUMN edfi.OperationalUnitDimension.FiscalYear IS 'The fiscal year for which the account operational unit dimension is valid.';
COMMENT ON COLUMN edfi.OperationalUnitDimension.CodeName IS 'A description of the account operational unit dimension.';

-- Extended Properties [edfi].[OperationalUnitDimensionReportingTag] --
COMMENT ON TABLE edfi.OperationalUnitDimensionReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.OperationalUnitDimensionReportingTag.Code IS 'The code representation of the account operational unit dimension.';
COMMENT ON COLUMN edfi.OperationalUnitDimensionReportingTag.FiscalYear IS 'The fiscal year for which the account operational unit dimension is valid.';
COMMENT ON COLUMN edfi.OperationalUnitDimensionReportingTag.ReportingTagDescriptorId IS 'Optional tag for accountability reporting.';

-- Extended Properties [edfi].[OrganizationDepartment] --
COMMENT ON TABLE edfi.OrganizationDepartment IS 'An organizational unit of another education organization, often devoted to a particular academic discipline, area of study, or organization function.';
COMMENT ON COLUMN edfi.OrganizationDepartment.OrganizationDepartmentId IS 'The unique identification code for the organization department.';
COMMENT ON COLUMN edfi.OrganizationDepartment.AcademicSubjectDescriptorId IS 'The intended major subject area of the department.';
COMMENT ON COLUMN edfi.OrganizationDepartment.ParentEducationOrganizationId IS 'The identifier assigned to an education organization.';

-- Extended Properties [edfi].[OtherNameTypeDescriptor] --
COMMENT ON TABLE edfi.OtherNameTypeDescriptor IS 'The types of alternate names for a person.';
COMMENT ON COLUMN edfi.OtherNameTypeDescriptor.OtherNameTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Parent] --
COMMENT ON TABLE edfi.Parent IS 'This entity represents a parent or guardian of a student, such as mother, father, or caretaker.';
COMMENT ON COLUMN edfi.Parent.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.Parent.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the individual.';
COMMENT ON COLUMN edfi.Parent.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN edfi.Parent.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN edfi.Parent.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN edfi.Parent.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN edfi.Parent.MaidenName IS 'The individual''s maiden name.';
COMMENT ON COLUMN edfi.Parent.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN edfi.Parent.LoginId IS 'The login ID for the user; used for security access control interface.';
COMMENT ON COLUMN edfi.Parent.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN edfi.Parent.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN edfi.Parent.HighestCompletedLevelOfEducationDescriptorId IS 'The extent of formal instruction an individual has received (e.g., the highest grade in school completed or its equivalent or the highest degree received).';
COMMENT ON COLUMN edfi.Parent.ParentUniqueId IS 'A unique alphanumeric code assigned to a parent.';

-- Extended Properties [edfi].[ParentAddress] --
COMMENT ON TABLE edfi.ParentAddress IS 'Parent''s address, if different from the student address.';
COMMENT ON COLUMN edfi.ParentAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.ParentAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.ParentAddress.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.ParentAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.ParentAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.ParentAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.ParentAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN edfi.ParentAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN edfi.ParentAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN edfi.ParentAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN edfi.ParentAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.ParentAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.ParentAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN edfi.ParentAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN edfi.ParentAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [edfi].[ParentAddressPeriod] --
COMMENT ON TABLE edfi.ParentAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN edfi.ParentAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.ParentAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN edfi.ParentAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.ParentAddressPeriod.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.ParentAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.ParentAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.ParentAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.ParentAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [edfi].[ParentElectronicMail] --
COMMENT ON TABLE edfi.ParentElectronicMail IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN edfi.ParentElectronicMail.ElectronicMailAddress IS 'The electronic mail (e-mail) address listed for an individual or organization.';
COMMENT ON COLUMN edfi.ParentElectronicMail.ElectronicMailTypeDescriptorId IS 'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)';
COMMENT ON COLUMN edfi.ParentElectronicMail.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.ParentElectronicMail.PrimaryEmailAddressIndicator IS 'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.';
COMMENT ON COLUMN edfi.ParentElectronicMail.DoNotPublishIndicator IS 'An indication that the electronic email address should not be published.';

-- Extended Properties [edfi].[ParentInternationalAddress] --
COMMENT ON TABLE edfi.ParentInternationalAddress IS 'The set of elements that describes an international address.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.ParentInternationalAddress.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.AddressLine1 IS 'The first line of the address.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.AddressLine2 IS 'The second line of the address.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.AddressLine3 IS 'The third line of the address.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.AddressLine4 IS 'The fourth line of the address.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.CountryDescriptorId IS 'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.BeginDate IS 'The first date the address is valid. For physical addresses, the date the individual moved to that address.';
COMMENT ON COLUMN edfi.ParentInternationalAddress.EndDate IS 'The last date the address is valid. For physical addresses, the date the individual moved from that address.';

-- Extended Properties [edfi].[ParentLanguage] --
COMMENT ON TABLE edfi.ParentLanguage IS 'The language(s) the individual uses to communicate. It is strongly recommended that entries use only ISO 639-2 language codes.';
COMMENT ON COLUMN edfi.ParentLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN edfi.ParentLanguage.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';

-- Extended Properties [edfi].[ParentLanguageUse] --
COMMENT ON TABLE edfi.ParentLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN edfi.ParentLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN edfi.ParentLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN edfi.ParentLanguageUse.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';

-- Extended Properties [edfi].[ParentOtherName] --
COMMENT ON TABLE edfi.ParentOtherName IS 'Other names (e.g., alias, nickname, previous legal name) associated with a person.';
COMMENT ON COLUMN edfi.ParentOtherName.OtherNameTypeDescriptorId IS 'The types of alternate names for an individual.';
COMMENT ON COLUMN edfi.ParentOtherName.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.ParentOtherName.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the individual.';
COMMENT ON COLUMN edfi.ParentOtherName.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN edfi.ParentOtherName.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN edfi.ParentOtherName.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN edfi.ParentOtherName.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';

-- Extended Properties [edfi].[ParentPersonalIdentificationDocument] --
COMMENT ON TABLE edfi.ParentPersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN edfi.ParentPersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN edfi.ParentPersonalIdentificationDocument.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.ParentPersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN edfi.ParentPersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN edfi.ParentPersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN edfi.ParentPersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN edfi.ParentPersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN edfi.ParentPersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [edfi].[ParentTelephone] --
COMMENT ON TABLE edfi.ParentTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN edfi.ParentTelephone.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.ParentTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN edfi.ParentTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN edfi.ParentTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN edfi.ParentTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN edfi.ParentTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [edfi].[ParticipationDescriptor] --
COMMENT ON TABLE edfi.ParticipationDescriptor IS 'This descriptor defines participation in a yearly English language assessment.';
COMMENT ON COLUMN edfi.ParticipationDescriptor.ParticipationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ParticipationStatusDescriptor] --
COMMENT ON TABLE edfi.ParticipationStatusDescriptor IS 'The student''s program participation status.';
COMMENT ON COLUMN edfi.ParticipationStatusDescriptor.ParticipationStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PerformanceBaseConversionDescriptor] --
COMMENT ON TABLE edfi.PerformanceBaseConversionDescriptor IS 'Defines standard levels of competency or performance that can be used for dashboard visualizations: advanced, proficient, basic, and below basic.';
COMMENT ON COLUMN edfi.PerformanceBaseConversionDescriptor.PerformanceBaseConversionDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PerformanceLevelDescriptor] --
COMMENT ON TABLE edfi.PerformanceLevelDescriptor IS 'This descriptor defines various levels or thresholds for performance on the assessment.';
COMMENT ON COLUMN edfi.PerformanceLevelDescriptor.PerformanceLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Person] --
COMMENT ON TABLE edfi.Person IS 'This entity represents a human being.';
COMMENT ON COLUMN edfi.Person.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN edfi.Person.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [edfi].[PersonalInformationVerificationDescriptor] --
COMMENT ON TABLE edfi.PersonalInformationVerificationDescriptor IS 'The evidence presented to verify one''s personal identity; for example: driver''s license, passport, birth certificate, etc.';
COMMENT ON COLUMN edfi.PersonalInformationVerificationDescriptor.PersonalInformationVerificationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PlatformTypeDescriptor] --
COMMENT ON TABLE edfi.PlatformTypeDescriptor IS 'The platforms with which an assessment may be delivered.';
COMMENT ON COLUMN edfi.PlatformTypeDescriptor.PlatformTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PopulationServedDescriptor] --
COMMENT ON TABLE edfi.PopulationServedDescriptor IS 'The type of students the Section is offered and tailored to.';
COMMENT ON COLUMN edfi.PopulationServedDescriptor.PopulationServedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PostingResultDescriptor] --
COMMENT ON TABLE edfi.PostingResultDescriptor IS 'Indication of whether the position was filled or retired without filling.';
COMMENT ON COLUMN edfi.PostingResultDescriptor.PostingResultDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PostSecondaryEvent] --
COMMENT ON TABLE edfi.PostSecondaryEvent IS 'This entity captures significant postsecondary events during a student''s high school tenure (e.g., FAFSA application or college application, acceptance, and enrollment) or during a student''s enrollment at a post-secondary institution.';
COMMENT ON COLUMN edfi.PostSecondaryEvent.EventDate IS 'The date the event occurred or was recorded.';
COMMENT ON COLUMN edfi.PostSecondaryEvent.PostSecondaryEventCategoryDescriptorId IS 'The post secondary event that is logged.';
COMMENT ON COLUMN edfi.PostSecondaryEvent.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.PostSecondaryEvent.PostSecondaryInstitutionId IS 'The ID of the post secondary institution.';

-- Extended Properties [edfi].[PostSecondaryEventCategoryDescriptor] --
COMMENT ON TABLE edfi.PostSecondaryEventCategoryDescriptor IS 'A code describing the type of post-secondary event (e.g., college application or acceptance).';
COMMENT ON COLUMN edfi.PostSecondaryEventCategoryDescriptor.PostSecondaryEventCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PostSecondaryInstitution] --
COMMENT ON TABLE edfi.PostSecondaryInstitution IS 'An organization that provides educational programs for individuals who have completed or otherwise left educational programs in secondary school(s).';
COMMENT ON COLUMN edfi.PostSecondaryInstitution.PostSecondaryInstitutionId IS 'The ID of the post secondary institution.';
COMMENT ON COLUMN edfi.PostSecondaryInstitution.PostSecondaryInstitutionLevelDescriptorId IS 'A classification of whether a post secondary institution''s highest level of offering is a program of 4-years or higher (4 year), 2-but-less-than 4-years (2 year), or less than 2-years.';
COMMENT ON COLUMN edfi.PostSecondaryInstitution.AdministrativeFundingControlDescriptorId IS 'A classification of whether a postsecondary institution is operated by publicly elected or appointed officials (public control) or by privately elected or appointed officials and derives its major source of funds from private sources (private control).';

-- Extended Properties [edfi].[PostSecondaryInstitutionLevelDescriptor] --
COMMENT ON TABLE edfi.PostSecondaryInstitutionLevelDescriptor IS 'A classification of a postsecondary institution''s highest level of offering. Default values are based on the Carnegie Classifications.';
COMMENT ON COLUMN edfi.PostSecondaryInstitutionLevelDescriptor.PostSecondaryInstitutionLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PostSecondaryInstitutionMediumOfInstruction] --
COMMENT ON TABLE edfi.PostSecondaryInstitutionMediumOfInstruction IS 'The categories in which an institution serves the students.';
COMMENT ON COLUMN edfi.PostSecondaryInstitutionMediumOfInstruction.MediumOfInstructionDescriptorId IS 'The categories in which an institution serves the students.';
COMMENT ON COLUMN edfi.PostSecondaryInstitutionMediumOfInstruction.PostSecondaryInstitutionId IS 'The ID of the post secondary institution.';

-- Extended Properties [edfi].[PrimaryLearningDeviceAccessDescriptor] --
COMMENT ON TABLE edfi.PrimaryLearningDeviceAccessDescriptor IS 'An indication of whether the primary learning device is shared or not shared with another individual.';
COMMENT ON COLUMN edfi.PrimaryLearningDeviceAccessDescriptor.PrimaryLearningDeviceAccessDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PrimaryLearningDeviceAwayFromSchoolDescriptor] --
COMMENT ON TABLE edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor IS 'The type of device the student uses most often to complete learning activities away from school.';
COMMENT ON COLUMN edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor.PrimaryLearningDeviceAwayFromSchoolDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PrimaryLearningDeviceProviderDescriptor] --
COMMENT ON TABLE edfi.PrimaryLearningDeviceProviderDescriptor IS 'The provider of the primary learning device.';
COMMENT ON COLUMN edfi.PrimaryLearningDeviceProviderDescriptor.PrimaryLearningDeviceProviderDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProficiencyDescriptor] --
COMMENT ON TABLE edfi.ProficiencyDescriptor IS 'This descriptor defines proficiency levels for a yearly English language assessment.';
COMMENT ON COLUMN edfi.ProficiencyDescriptor.ProficiencyDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Program] --
COMMENT ON TABLE edfi.Program IS 'This entity represents any program designed to work in conjunction with, or as a supplement to, the main academic program. Programs may provide instruction, training, services, or benefits through federal, state, or local agencies. Programs may also include organized extracurricular activities for students.';
COMMENT ON COLUMN edfi.Program.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.Program.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.Program.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.Program.ProgramId IS 'A unique number or alphanumeric code assigned to a program by a school, school system, a state, or other agency or entity.';

-- Extended Properties [edfi].[ProgramAssignmentDescriptor] --
COMMENT ON TABLE edfi.ProgramAssignmentDescriptor IS 'This descriptor defines the name of the education program for which a teacher is assigned to a school.';
COMMENT ON COLUMN edfi.ProgramAssignmentDescriptor.ProgramAssignmentDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProgramCharacteristic] --
COMMENT ON TABLE edfi.ProgramCharacteristic IS 'Reflects important characteristics of the program, such as categories or particular indications.';
COMMENT ON COLUMN edfi.ProgramCharacteristic.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ProgramCharacteristic.ProgramCharacteristicDescriptorId IS 'Reflects important characteristics of the program, such as categories or particular indications.';
COMMENT ON COLUMN edfi.ProgramCharacteristic.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.ProgramCharacteristic.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [edfi].[ProgramCharacteristicDescriptor] --
COMMENT ON TABLE edfi.ProgramCharacteristicDescriptor IS 'This descriptor defines important characteristics of the Program, such as categories or particular indications.';
COMMENT ON COLUMN edfi.ProgramCharacteristicDescriptor.ProgramCharacteristicDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProgramDimension] --
COMMENT ON TABLE edfi.ProgramDimension IS 'The NCES program accounting dimension. A program is defined by the NCES as a plan of activities and procedures designed to accomplish a predetermined objective or set of objectives. These are often categorized into broad program areas such as regular education, special education, vocational education, other PK-12 instructional, nonpublic school, adult and continuing education, community and junior college education, community services, and co-curricular or extracurricular activities.';
COMMENT ON COLUMN edfi.ProgramDimension.Code IS 'The code representation of the account program dimension.';
COMMENT ON COLUMN edfi.ProgramDimension.FiscalYear IS 'The fiscal year for which the account program dimension is valid.';
COMMENT ON COLUMN edfi.ProgramDimension.CodeName IS 'A description of the account program dimension.';

-- Extended Properties [edfi].[ProgramDimensionReportingTag] --
COMMENT ON TABLE edfi.ProgramDimensionReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.ProgramDimensionReportingTag.Code IS 'The code representation of the account program dimension.';
COMMENT ON COLUMN edfi.ProgramDimensionReportingTag.FiscalYear IS 'The fiscal year for which the account program dimension is valid.';
COMMENT ON COLUMN edfi.ProgramDimensionReportingTag.ReportingTagDescriptorId IS 'Optional tag for accountability reporting.';

-- Extended Properties [edfi].[ProgramLearningObjective] --
COMMENT ON TABLE edfi.ProgramLearningObjective IS 'References the learning objective(s) with which the program is associated.';
COMMENT ON COLUMN edfi.ProgramLearningObjective.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ProgramLearningObjective.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.ProgramLearningObjective.Namespace IS 'Namespace for the learning objective.';
COMMENT ON COLUMN edfi.ProgramLearningObjective.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.ProgramLearningObjective.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [edfi].[ProgramLearningStandard] --
COMMENT ON TABLE edfi.ProgramLearningStandard IS 'Learning standard followed by this program.';
COMMENT ON COLUMN edfi.ProgramLearningStandard.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ProgramLearningStandard.LearningStandardId IS 'The identifier for the specific learning standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.ProgramLearningStandard.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.ProgramLearningStandard.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [edfi].[ProgramService] --
COMMENT ON TABLE edfi.ProgramService IS 'Defines the services this program provides to students.';
COMMENT ON COLUMN edfi.ProgramService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ProgramService.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.ProgramService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.ProgramService.ServiceDescriptorId IS 'Defines the services this program provides to students.';

-- Extended Properties [edfi].[ProgramSponsor] --
COMMENT ON TABLE edfi.ProgramSponsor IS 'Ultimate and intermediate providers of funds for a particular educational or service program or activity, or for an individual''s participation in the program or activity (e.g., Federal, State, ESC, District, School, Private Organization).';
COMMENT ON COLUMN edfi.ProgramSponsor.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ProgramSponsor.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.ProgramSponsor.ProgramSponsorDescriptorId IS 'Ultimate and intermediate providers of funds for a particular educational or service program or activity, or for an individual''s participation in the program or activity (e.g., Federal, State, ESC, District, School, Private Organization).';
COMMENT ON COLUMN edfi.ProgramSponsor.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [edfi].[ProgramSponsorDescriptor] --
COMMENT ON TABLE edfi.ProgramSponsorDescriptor IS 'Ultimate and intermediate providers of funds for a particular educational or service program or activity or for an individual''s participation in the program or activity (e.g., Federal, State, ESC, District, School, Private Org).';
COMMENT ON COLUMN edfi.ProgramSponsorDescriptor.ProgramSponsorDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProgramTypeDescriptor] --
COMMENT ON TABLE edfi.ProgramTypeDescriptor IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.ProgramTypeDescriptor.ProgramTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProgressDescriptor] --
COMMENT ON TABLE edfi.ProgressDescriptor IS 'This descriptor defines yearly progress or growth from last year''s assessment.';
COMMENT ON COLUMN edfi.ProgressDescriptor.ProgressDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProgressLevelDescriptor] --
COMMENT ON TABLE edfi.ProgressLevelDescriptor IS 'This descriptor defines progress measured from pre- to post-test.';
COMMENT ON COLUMN edfi.ProgressLevelDescriptor.ProgressLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProjectDimension] --
COMMENT ON TABLE edfi.ProjectDimension IS 'The NCES project accounting dimension. The project dimension reporting code permits school districts to accumulate expenditures to meet a variety of specialized reporting requirements at the local, state, and federal levels.';
COMMENT ON COLUMN edfi.ProjectDimension.Code IS 'The code representation of the account project dimension.';
COMMENT ON COLUMN edfi.ProjectDimension.FiscalYear IS 'The fiscal year for which the account project dimension is valid.';
COMMENT ON COLUMN edfi.ProjectDimension.CodeName IS 'A description of the account project dimension.';

-- Extended Properties [edfi].[ProjectDimensionReportingTag] --
COMMENT ON TABLE edfi.ProjectDimensionReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.ProjectDimensionReportingTag.Code IS 'The code representation of the account project dimension.';
COMMENT ON COLUMN edfi.ProjectDimensionReportingTag.FiscalYear IS 'The fiscal year for which the account project dimension is valid.';
COMMENT ON COLUMN edfi.ProjectDimensionReportingTag.ReportingTagDescriptorId IS 'Optional tag for accountability reporting.';

-- Extended Properties [edfi].[ProviderCategoryDescriptor] --
COMMENT ON TABLE edfi.ProviderCategoryDescriptor IS 'This descriptor holds the category of the provider.';
COMMENT ON COLUMN edfi.ProviderCategoryDescriptor.ProviderCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProviderProfitabilityDescriptor] --
COMMENT ON TABLE edfi.ProviderProfitabilityDescriptor IS 'This descriptor indicates the profitability status of the provider.';
COMMENT ON COLUMN edfi.ProviderProfitabilityDescriptor.ProviderProfitabilityDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ProviderStatusDescriptor] --
COMMENT ON TABLE edfi.ProviderStatusDescriptor IS 'This descriptor defines the status of the provider.';
COMMENT ON COLUMN edfi.ProviderStatusDescriptor.ProviderStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[PublicationStatusDescriptor] --
COMMENT ON TABLE edfi.PublicationStatusDescriptor IS 'The publication status of the document (i.e., Adopted, Draft, Published, Deprecated, Unknown).';
COMMENT ON COLUMN edfi.PublicationStatusDescriptor.PublicationStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[QuestionFormDescriptor] --
COMMENT ON TABLE edfi.QuestionFormDescriptor IS 'The form or type of question.';
COMMENT ON COLUMN edfi.QuestionFormDescriptor.QuestionFormDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[RaceDescriptor] --
COMMENT ON TABLE edfi.RaceDescriptor IS 'The enumeration items defining the racial categories which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies.';
COMMENT ON COLUMN edfi.RaceDescriptor.RaceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ReasonExitedDescriptor] --
COMMENT ON TABLE edfi.ReasonExitedDescriptor IS 'This descriptor defines the reason a student exited a program.';
COMMENT ON COLUMN edfi.ReasonExitedDescriptor.ReasonExitedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ReasonNotTestedDescriptor] --
COMMENT ON TABLE edfi.ReasonNotTestedDescriptor IS 'The primary reason student is not tested.';
COMMENT ON COLUMN edfi.ReasonNotTestedDescriptor.ReasonNotTestedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[RecognitionTypeDescriptor] --
COMMENT ON TABLE edfi.RecognitionTypeDescriptor IS 'The nature of recognition given to the student for accomplishments in a co-curricular, or extra-curricular activity.';
COMMENT ON COLUMN edfi.RecognitionTypeDescriptor.RecognitionTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[RelationDescriptor] --
COMMENT ON TABLE edfi.RelationDescriptor IS 'The nature of an individual''s relationship to a student.';
COMMENT ON COLUMN edfi.RelationDescriptor.RelationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[RepeatIdentifierDescriptor] --
COMMENT ON TABLE edfi.RepeatIdentifierDescriptor IS 'An indication as to whether a student has previously taken a given course.';
COMMENT ON COLUMN edfi.RepeatIdentifierDescriptor.RepeatIdentifierDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ReportCard] --
COMMENT ON TABLE edfi.ReportCard IS 'This educational entity represents the collection of student grades for courses taken during a grading period.';
COMMENT ON COLUMN edfi.ReportCard.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ReportCard.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.ReportCard.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.ReportCard.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.ReportCard.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.ReportCard.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.ReportCard.GPAGivenGradingPeriod IS 'A measure of average performance in all courses taken by an individual for the current grading period.';
COMMENT ON COLUMN edfi.ReportCard.GPACumulative IS 'A measure of cumulative average performance in all courses taken by an individual from the beginning of the school year through the current grading period.';
COMMENT ON COLUMN edfi.ReportCard.NumberOfDaysAbsent IS 'The number of days an individual is absent when school is in session during a given reporting period.';
COMMENT ON COLUMN edfi.ReportCard.NumberOfDaysInAttendance IS 'The number of days an individual is present when school is in session during a given reporting period.';
COMMENT ON COLUMN edfi.ReportCard.NumberOfDaysTardy IS 'The number of days an individual is tardy during a given reporting period.';

-- Extended Properties [edfi].[ReportCardGrade] --
COMMENT ON TABLE edfi.ReportCardGrade IS 'Grades for the classes attended by the student for this grading period.';
COMMENT ON COLUMN edfi.ReportCardGrade.BeginDate IS 'Month, day, and year of the student''s entry or assignment to the section.';
COMMENT ON COLUMN edfi.ReportCardGrade.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ReportCardGrade.GradeTypeDescriptorId IS 'The type of grade reported (e.g., exam, final, grading period).';
COMMENT ON COLUMN edfi.ReportCardGrade.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.ReportCardGrade.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.ReportCardGrade.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.ReportCardGrade.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.ReportCardGrade.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.ReportCardGrade.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.ReportCardGrade.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.ReportCardGrade.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.ReportCardGrade.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.ReportCardGrade.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[ReportCardGradePointAverage] --
COMMENT ON TABLE edfi.ReportCardGradePointAverage IS 'A measure of average performance for courses taken by an individual.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.GradePointAverageTypeDescriptorId IS 'The system used for calculating the grade point average for an individual.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.IsCumulative IS 'Indicator of whether or not the Grade Point Average value is cumulative.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.GradePointAverageValue IS 'The value of the grade points earned divided by the number of credits attempted.';
COMMENT ON COLUMN edfi.ReportCardGradePointAverage.MaxGradePointAverageValue IS 'The maximum value for the grade point average.';

-- Extended Properties [edfi].[ReportCardStudentCompetencyObjective] --
COMMENT ON TABLE edfi.ReportCardStudentCompetencyObjective IS 'The student competency evaluations associated for this grading period.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.Objective IS 'The designated title of the competency objective.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.ObjectiveEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.ObjectiveGradeLevelDescriptorId IS 'The grade level for which the competency objective is targeted.';
COMMENT ON COLUMN edfi.ReportCardStudentCompetencyObjective.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[ReportCardStudentLearningObjective] --
COMMENT ON TABLE edfi.ReportCardStudentLearningObjective IS 'The student learning objective evaluations associated for this grading period.';
COMMENT ON COLUMN edfi.ReportCardStudentLearningObjective.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.ReportCardStudentLearningObjective.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.ReportCardStudentLearningObjective.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.ReportCardStudentLearningObjective.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.ReportCardStudentLearningObjective.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.ReportCardStudentLearningObjective.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.ReportCardStudentLearningObjective.Namespace IS 'Namespace for the learning objective.';
COMMENT ON COLUMN edfi.ReportCardStudentLearningObjective.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[ReporterDescriptionDescriptor] --
COMMENT ON TABLE edfi.ReporterDescriptionDescriptor IS 'This descriptor defines the type of individual who reported an incident.';
COMMENT ON COLUMN edfi.ReporterDescriptionDescriptor.ReporterDescriptionDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ReportingTagDescriptor] --
COMMENT ON TABLE edfi.ReportingTagDescriptor IS 'A descriptor used at the dimension and/or chart of account levels to demote specific state needs for reporting.';
COMMENT ON COLUMN edfi.ReportingTagDescriptor.ReportingTagDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ResidencyStatusDescriptor] --
COMMENT ON TABLE edfi.ResidencyStatusDescriptor IS 'This descriptor defines indications of the location of a person''s legal residence relative to (within or outside of) the boundaries of the public school attended and its administrative unit.';
COMMENT ON COLUMN edfi.ResidencyStatusDescriptor.ResidencyStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ResponseIndicatorDescriptor] --
COMMENT ON TABLE edfi.ResponseIndicatorDescriptor IS 'Indicator of the response.';
COMMENT ON COLUMN edfi.ResponseIndicatorDescriptor.ResponseIndicatorDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ResponsibilityDescriptor] --
COMMENT ON TABLE edfi.ResponsibilityDescriptor IS 'This descriptor defines types of responsibility an education organization may have for a student (e.g., accountability, attendance, funding).';
COMMENT ON COLUMN edfi.ResponsibilityDescriptor.ResponsibilityDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[RestraintEvent] --
COMMENT ON TABLE edfi.RestraintEvent IS 'This event entity represents the instances where a special education student was physically or mechanically restrained due to imminent serious physical harm to themselves or others, imminent serious property destruction or a combination of both imminent serious physical harm to themselves or others and imminent serious property destruction.';
COMMENT ON COLUMN edfi.RestraintEvent.RestraintEventIdentifier IS 'A unique number or alphanumeric code assigned to a restraint event by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.RestraintEvent.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.RestraintEvent.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.RestraintEvent.EventDate IS 'Month, day, and year of the restraint event.';
COMMENT ON COLUMN edfi.RestraintEvent.EducationalEnvironmentDescriptorId IS 'The setting where the RestraintEvent was exercised.';

-- Extended Properties [edfi].[RestraintEventProgram] --
COMMENT ON TABLE edfi.RestraintEventProgram IS 'The special education program associated with the restraint event.';
COMMENT ON COLUMN edfi.RestraintEventProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.RestraintEventProgram.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.RestraintEventProgram.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.RestraintEventProgram.RestraintEventIdentifier IS 'A unique number or alphanumeric code assigned to a restraint event by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.RestraintEventProgram.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.RestraintEventProgram.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[RestraintEventReason] --
COMMENT ON TABLE edfi.RestraintEventReason IS 'A categorization of the circumstances or reason for the RestraintEvent.';
COMMENT ON COLUMN edfi.RestraintEventReason.RestraintEventIdentifier IS 'A unique number or alphanumeric code assigned to a restraint event by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.RestraintEventReason.RestraintEventReasonDescriptorId IS 'A categorization of the circumstances or reason for the RestraintEvent.';
COMMENT ON COLUMN edfi.RestraintEventReason.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.RestraintEventReason.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[RestraintEventReasonDescriptor] --
COMMENT ON TABLE edfi.RestraintEventReasonDescriptor IS 'The items of categorization of the circumstances or reason for the restraint.';
COMMENT ON COLUMN edfi.RestraintEventReasonDescriptor.RestraintEventReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ResultDatatypeTypeDescriptor] --
COMMENT ON TABLE edfi.ResultDatatypeTypeDescriptor IS 'The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN edfi.ResultDatatypeTypeDescriptor.ResultDatatypeTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[RetestIndicatorDescriptor] --
COMMENT ON TABLE edfi.RetestIndicatorDescriptor IS 'Indicator if the test was retaken.';
COMMENT ON COLUMN edfi.RetestIndicatorDescriptor.RetestIndicatorDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[School] --
COMMENT ON TABLE edfi.School IS 'This entity represents an educational organization that includes staff and students who participate in classes and educational activity groups.';
COMMENT ON COLUMN edfi.School.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.School.SchoolTypeDescriptorId IS 'The type of education institution as classified by its primary focus.';
COMMENT ON COLUMN edfi.School.CharterStatusDescriptorId IS 'A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.';
COMMENT ON COLUMN edfi.School.TitleIPartASchoolDesignationDescriptorId IS 'Denotes the Title I Part A designation for the school.';
COMMENT ON COLUMN edfi.School.MagnetSpecialProgramEmphasisSchoolDescriptorId IS 'A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2) to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).';
COMMENT ON COLUMN edfi.School.AdministrativeFundingControlDescriptorId IS 'The type of education institution as classified by its funding source, for example public or private.';
COMMENT ON COLUMN edfi.School.InternetAccessDescriptorId IS 'The type of Internet access available.';
COMMENT ON COLUMN edfi.School.LocalEducationAgencyId IS 'The identifier assigned to a local education agency.';
COMMENT ON COLUMN edfi.School.CharterApprovalAgencyTypeDescriptorId IS 'The type of agency that approved the establishment or continuation of a charter school.';
COMMENT ON COLUMN edfi.School.CharterApprovalSchoolYear IS 'The school year in which a charter school was initially approved.';

-- Extended Properties [edfi].[SchoolCategory] --
COMMENT ON TABLE edfi.SchoolCategory IS 'The one or more categories of school.';
COMMENT ON COLUMN edfi.SchoolCategory.SchoolCategoryDescriptorId IS 'The one or more categories of school.';
COMMENT ON COLUMN edfi.SchoolCategory.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [edfi].[SchoolCategoryDescriptor] --
COMMENT ON TABLE edfi.SchoolCategoryDescriptor IS 'The category of school. For example: High School, Middle School, Elementary School.';
COMMENT ON COLUMN edfi.SchoolCategoryDescriptor.SchoolCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SchoolChoiceBasisDescriptor] --
COMMENT ON TABLE edfi.SchoolChoiceBasisDescriptor IS 'The legal basis for the school choice enrollment according to local, state or federal policy or regulation. (The descriptor provides the list of available bases specific to the state).';
COMMENT ON COLUMN edfi.SchoolChoiceBasisDescriptor.SchoolChoiceBasisDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SchoolChoiceImplementStatusDescriptor] --
COMMENT ON TABLE edfi.SchoolChoiceImplementStatusDescriptor IS 'An indication of whether the LEA was able to implement the provisions for public school choice under Title I, Part A, Section 1116 of ESEA, as amended.';
COMMENT ON COLUMN edfi.SchoolChoiceImplementStatusDescriptor.SchoolChoiceImplementStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SchoolFoodServiceProgramServiceDescriptor] --
COMMENT ON TABLE edfi.SchoolFoodServiceProgramServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a school food service program.';
COMMENT ON COLUMN edfi.SchoolFoodServiceProgramServiceDescriptor.SchoolFoodServiceProgramServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SchoolGradeLevel] --
COMMENT ON TABLE edfi.SchoolGradeLevel IS 'The grade levels served at the school.';
COMMENT ON COLUMN edfi.SchoolGradeLevel.GradeLevelDescriptorId IS 'The grade levels served at the school.';
COMMENT ON COLUMN edfi.SchoolGradeLevel.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [edfi].[SchoolTypeDescriptor] --
COMMENT ON TABLE edfi.SchoolTypeDescriptor IS 'The type of education institution as classified by its primary focus.';
COMMENT ON COLUMN edfi.SchoolTypeDescriptor.SchoolTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SchoolYearType] --
COMMENT ON TABLE edfi.SchoolYearType IS 'Identifier for a school year.';
COMMENT ON COLUMN edfi.SchoolYearType.SchoolYear IS 'Key for School Year';
COMMENT ON COLUMN edfi.SchoolYearType.SchoolYearDescription IS 'The description for the SchoolYear type.';
COMMENT ON COLUMN edfi.SchoolYearType.CurrentSchoolYear IS 'The code for the current school year.';

-- Extended Properties [edfi].[Section] --
COMMENT ON TABLE edfi.Section IS 'This entity represents a setting in which organized instruction of course content is provided, in-person or otherwise, to one or more students for a given period of time. A course offering may be offered to more than one section.';
COMMENT ON COLUMN edfi.Section.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.Section.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.Section.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.Section.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.Section.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.Section.SequenceOfCourse IS 'When a section is part of a sequence of parts for a course, the number of the sequence. If the course has only one part, the value of this section attribute should be 1.';
COMMENT ON COLUMN edfi.Section.EducationalEnvironmentDescriptorId IS 'The setting in which a student receives education and related services.';
COMMENT ON COLUMN edfi.Section.MediumOfInstructionDescriptorId IS 'The media through which teachers provide instruction to students and students and teachers communicate about instructional matters.';
COMMENT ON COLUMN edfi.Section.PopulationServedDescriptorId IS 'The type of students the section is offered and tailored to.';
COMMENT ON COLUMN edfi.Section.AvailableCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.Section.AvailableCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.Section.AvailableCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.Section.InstructionLanguageDescriptorId IS 'The primary language of instruction. If omitted, English is assumed.';
COMMENT ON COLUMN edfi.Section.LocationSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.Section.LocationClassroomIdentificationCode IS 'A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.Section.OfficialAttendancePeriod IS 'Indicator of whether this section is used for official daily attendance. Alternatively, official daily attendance may be tied to a class period.';
COMMENT ON COLUMN edfi.Section.SectionName IS 'A locally-defined name for the section, generally created to make the section more recognizable in informal contexts and generally distinct from the section identifier.';

-- Extended Properties [edfi].[SectionAttendanceTakenEvent] --
COMMENT ON TABLE edfi.SectionAttendanceTakenEvent IS 'Captures attendance taken event for given section.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.CalendarCode IS 'The identifier for the calendar.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.Date IS 'The month, day, and year of the calendar event.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.EventDate IS 'The date the section attendance taken event was submitted, which could be a different date than the instructional day.';
COMMENT ON COLUMN edfi.SectionAttendanceTakenEvent.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[SectionCharacteristic] --
COMMENT ON TABLE edfi.SectionCharacteristic IS 'Reflects important characteristics of the section, such as whether or not attendance is taken and the section is graded.';
COMMENT ON COLUMN edfi.SectionCharacteristic.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.SectionCharacteristic.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SectionCharacteristic.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SectionCharacteristic.SectionCharacteristicDescriptorId IS 'Reflects important characteristics of the section, such as whether or not attendance is taken and the section is graded.';
COMMENT ON COLUMN edfi.SectionCharacteristic.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.SectionCharacteristic.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[SectionCharacteristicDescriptor] --
COMMENT ON TABLE edfi.SectionCharacteristicDescriptor IS 'This descriptor defines characteristics of a Section, such as whether attendance is taken and the Section is graded.';
COMMENT ON COLUMN edfi.SectionCharacteristicDescriptor.SectionCharacteristicDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SectionClassPeriod] --
COMMENT ON TABLE edfi.SectionClassPeriod IS 'The class period during which the section meets.';
COMMENT ON COLUMN edfi.SectionClassPeriod.ClassPeriodName IS 'An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).';
COMMENT ON COLUMN edfi.SectionClassPeriod.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.SectionClassPeriod.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SectionClassPeriod.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SectionClassPeriod.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.SectionClassPeriod.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[SectionCourseLevelCharacteristic] --
COMMENT ON TABLE edfi.SectionCourseLevelCharacteristic IS 'The type of specific program or designation with which the section is associated. This collection should only be populated if it differs from the course level characteristics identified at the course offering level.';
COMMENT ON COLUMN edfi.SectionCourseLevelCharacteristic.CourseLevelCharacteristicDescriptorId IS 'The type of specific program or designation with which the section is associated. This collection should only be populated if it differs from the course level characteristics identified at the course offering level.';
COMMENT ON COLUMN edfi.SectionCourseLevelCharacteristic.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.SectionCourseLevelCharacteristic.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SectionCourseLevelCharacteristic.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SectionCourseLevelCharacteristic.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.SectionCourseLevelCharacteristic.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[SectionOfferedGradeLevel] --
COMMENT ON TABLE edfi.SectionOfferedGradeLevel IS 'The grade levels in which the section is offered. This collection should only be populated if it differs from the Offered Grade Levels identified at the course offering level.';
COMMENT ON COLUMN edfi.SectionOfferedGradeLevel.GradeLevelDescriptorId IS 'The grade levels in which the section is offered. This collection should only be populated if it differs from the Offered Grade Levels identified at the course offering level.';
COMMENT ON COLUMN edfi.SectionOfferedGradeLevel.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.SectionOfferedGradeLevel.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SectionOfferedGradeLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SectionOfferedGradeLevel.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.SectionOfferedGradeLevel.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[SectionProgram] --
COMMENT ON TABLE edfi.SectionProgram IS 'Optional reference to program to which the section is associated.';
COMMENT ON COLUMN edfi.SectionProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.SectionProgram.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.SectionProgram.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.SectionProgram.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.SectionProgram.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SectionProgram.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SectionProgram.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.SectionProgram.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[SeparationDescriptor] --
COMMENT ON TABLE edfi.SeparationDescriptor IS 'Type of employment separation; for example:  Voluntary separation, Involuntary separation, Mutual agreement. Other, etc.';
COMMENT ON COLUMN edfi.SeparationDescriptor.SeparationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SeparationReasonDescriptor] --
COMMENT ON TABLE edfi.SeparationReasonDescriptor IS 'This descriptor defines the reasons for terminating the employment.';
COMMENT ON COLUMN edfi.SeparationReasonDescriptor.SeparationReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[ServiceDescriptor] --
COMMENT ON TABLE edfi.ServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a program.';
COMMENT ON COLUMN edfi.ServiceDescriptor.ServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Session] --
COMMENT ON TABLE edfi.Session IS 'A term in the school year, generally a unit of time into which courses are scheduled, instruction occurs and by which credits are awarded. Sessions may be interrupted by vacations or other events.';
COMMENT ON COLUMN edfi.Session.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.Session.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.Session.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.Session.BeginDate IS 'Month, day, and year of the first day of the session.';
COMMENT ON COLUMN edfi.Session.EndDate IS 'Month, day and year of the last day of the session.';
COMMENT ON COLUMN edfi.Session.TermDescriptorId IS 'An descriptor value indicating the term.';
COMMENT ON COLUMN edfi.Session.TotalInstructionalDays IS 'The total number of instructional days in the school calendar.';

-- Extended Properties [edfi].[SessionAcademicWeek] --
COMMENT ON TABLE edfi.SessionAcademicWeek IS 'The academic weeks associated with the school year.';
COMMENT ON COLUMN edfi.SessionAcademicWeek.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SessionAcademicWeek.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SessionAcademicWeek.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.SessionAcademicWeek.WeekIdentifier IS 'The school label for the week.';

-- Extended Properties [edfi].[SessionGradingPeriod] --
COMMENT ON TABLE edfi.SessionGradingPeriod IS 'Grading periods associated with the session.';
COMMENT ON COLUMN edfi.SessionGradingPeriod.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.SessionGradingPeriod.PeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.SessionGradingPeriod.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SessionGradingPeriod.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SessionGradingPeriod.SessionName IS 'The identifier for the calendar for the academic session.';

-- Extended Properties [edfi].[SexDescriptor] --
COMMENT ON TABLE edfi.SexDescriptor IS 'A person''s gender.';
COMMENT ON COLUMN edfi.SexDescriptor.SexDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SourceDimension] --
COMMENT ON TABLE edfi.SourceDimension IS 'The NCES source dimension. This dimension is used to segregate costs by school and operational unit such as physical location, department, or other method.';
COMMENT ON COLUMN edfi.SourceDimension.Code IS 'The code representation of the account source dimension.';
COMMENT ON COLUMN edfi.SourceDimension.FiscalYear IS 'The fiscal year for which the account source dimension is valid.';
COMMENT ON COLUMN edfi.SourceDimension.CodeName IS 'A description of the account source dimension.';

-- Extended Properties [edfi].[SourceDimensionReportingTag] --
COMMENT ON TABLE edfi.SourceDimensionReportingTag IS 'Optional tag for accountability reporting.';
COMMENT ON COLUMN edfi.SourceDimensionReportingTag.Code IS 'The code representation of the account source dimension.';
COMMENT ON COLUMN edfi.SourceDimensionReportingTag.FiscalYear IS 'The fiscal year for which the account source dimension is valid.';
COMMENT ON COLUMN edfi.SourceDimensionReportingTag.ReportingTagDescriptorId IS 'Optional tag for accountability reporting.';

-- Extended Properties [edfi].[SourceSystemDescriptor] --
COMMENT ON TABLE edfi.SourceSystemDescriptor IS 'This descriptor defines the originating record source system.';
COMMENT ON COLUMN edfi.SourceSystemDescriptor.SourceSystemDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SpecialEducationProgramServiceDescriptor] --
COMMENT ON TABLE edfi.SpecialEducationProgramServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a special education program.';
COMMENT ON COLUMN edfi.SpecialEducationProgramServiceDescriptor.SpecialEducationProgramServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SpecialEducationSettingDescriptor] --
COMMENT ON TABLE edfi.SpecialEducationSettingDescriptor IS 'This descriptor defines the major instructional setting (more than 50 percent of a student''s special education program).';
COMMENT ON COLUMN edfi.SpecialEducationSettingDescriptor.SpecialEducationSettingDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Staff] --
COMMENT ON TABLE edfi.Staff IS 'This entity represents an individual who performs specified activities for any public or private education institution or agency that provides instructional and/or support services to students or staff at the early childhood level through high school completion.';
COMMENT ON COLUMN edfi.Staff.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.Staff.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the individual.';
COMMENT ON COLUMN edfi.Staff.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN edfi.Staff.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN edfi.Staff.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN edfi.Staff.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN edfi.Staff.MaidenName IS 'The individual''s maiden name.';
COMMENT ON COLUMN edfi.Staff.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN edfi.Staff.BirthDate IS 'The month, day, and year on which an individual was born.';
COMMENT ON COLUMN edfi.Staff.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."';
COMMENT ON COLUMN edfi.Staff.OldEthnicityDescriptorId IS 'Previous definition of ethnicity combining Hispanic/Latino and race:
        1 - American Indian or Alaskan Native
        2 - Asian or Pacific Islander
        3 - Black, not of Hispanic origin
        4 - Hispanic
        5 - White, not of Hispanic origin.';
COMMENT ON COLUMN edfi.Staff.CitizenshipStatusDescriptorId IS 'An indicator of whether or not the person is a U.S. citizen.';
COMMENT ON COLUMN edfi.Staff.HighestCompletedLevelOfEducationDescriptorId IS 'The extent of formal instruction an individual has received (e.g., the highest grade in school completed or its equivalent or the highest degree received).';
COMMENT ON COLUMN edfi.Staff.YearsOfPriorProfessionalExperience IS 'The total number of years that an individual has previously held a similar professional position in one or more education institutions prior to the current school year.';
COMMENT ON COLUMN edfi.Staff.YearsOfPriorTeachingExperience IS 'The total number of years that an individual has previously held a teaching position in one or more education institutions prior to the current school year.';
COMMENT ON COLUMN edfi.Staff.LoginId IS 'The login ID for the user; used for security access control interface.';
COMMENT ON COLUMN edfi.Staff.HighlyQualifiedTeacher IS 'An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.';
COMMENT ON COLUMN edfi.Staff.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN edfi.Staff.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN edfi.Staff.StaffUniqueId IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffAbsenceEvent] --
COMMENT ON TABLE edfi.StaffAbsenceEvent IS 'This event entity represents the recording of the dates of staff absence.';
COMMENT ON COLUMN edfi.StaffAbsenceEvent.AbsenceEventCategoryDescriptorId IS 'The code describing the type of absence.';
COMMENT ON COLUMN edfi.StaffAbsenceEvent.EventDate IS 'Date for this leave event.';
COMMENT ON COLUMN edfi.StaffAbsenceEvent.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffAbsenceEvent.AbsenceEventReason IS 'Expanded reason for the staff absence.';
COMMENT ON COLUMN edfi.StaffAbsenceEvent.HoursAbsent IS 'The hours the staff was absent, if not the entire working day.';

-- Extended Properties [edfi].[StaffAddress] --
COMMENT ON TABLE edfi.StaffAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN edfi.StaffAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.StaffAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.StaffAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.StaffAddress.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.StaffAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.StaffAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN edfi.StaffAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN edfi.StaffAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN edfi.StaffAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN edfi.StaffAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.StaffAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.StaffAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN edfi.StaffAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN edfi.StaffAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [edfi].[StaffAddressPeriod] --
COMMENT ON TABLE edfi.StaffAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN edfi.StaffAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.StaffAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN edfi.StaffAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.StaffAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.StaffAddressPeriod.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.StaffAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.StaffAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [edfi].[StaffAncestryEthnicOrigin] --
COMMENT ON TABLE edfi.StaffAncestryEthnicOrigin IS 'The original peoples or cultures with which the individual identifies.';
COMMENT ON COLUMN edfi.StaffAncestryEthnicOrigin.AncestryEthnicOriginDescriptorId IS 'The original peoples or cultures with which the individual identifies.';
COMMENT ON COLUMN edfi.StaffAncestryEthnicOrigin.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffClassificationDescriptor] --
COMMENT ON TABLE edfi.StaffClassificationDescriptor IS 'This descriptor defines an individual''s title of employment, official status or rank.';
COMMENT ON COLUMN edfi.StaffClassificationDescriptor.StaffClassificationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[StaffCohortAssociation] --
COMMENT ON TABLE edfi.StaffCohortAssociation IS 'This association indicates the staff associated with a cohort of students.';
COMMENT ON COLUMN edfi.StaffCohortAssociation.BeginDate IS 'Start date for the association of staff to this cohort.';
COMMENT ON COLUMN edfi.StaffCohortAssociation.CohortIdentifier IS 'The name or ID for the cohort.';
COMMENT ON COLUMN edfi.StaffCohortAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffCohortAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffCohortAssociation.EndDate IS 'End date for the association of staff to this cohort.';
COMMENT ON COLUMN edfi.StaffCohortAssociation.StudentRecordAccess IS 'Indicator of whether the staff has access to the student records of the cohort per district interpretation of FERPA and other privacy laws, regulations, and policies.';

-- Extended Properties [edfi].[StaffCredential] --
COMMENT ON TABLE edfi.StaffCredential IS 'The legal document giving authorization to perform teaching assignment services.';
COMMENT ON COLUMN edfi.StaffCredential.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN edfi.StaffCredential.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffCredential.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';

-- Extended Properties [edfi].[StaffDisciplineIncidentAssociation] --
COMMENT ON TABLE edfi.StaffDisciplineIncidentAssociation IS 'This association indicates those staff who were victims, perpetrators, witnesses, and reporters for a discipline incident.';
COMMENT ON COLUMN edfi.StaffDisciplineIncidentAssociation.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.StaffDisciplineIncidentAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StaffDisciplineIncidentAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be] --
COMMENT ON TABLE edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be IS 'The role or type of participation of a student in a discipline incident.';
COMMENT ON COLUMN edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be.DisciplineIncidentParticipationCodeDescriptorId IS 'The role or type of participation of a student in a discipline incident.';
COMMENT ON COLUMN edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StaffDisciplineIncidentAssociationDisciplineIncidentPart_7fa4be.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffEducationOrganizationAssignmentAssociation] --
COMMENT ON TABLE edfi.StaffEducationOrganizationAssignmentAssociation IS 'This association indicates the education organization to which a staff member provides services.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.BeginDate IS 'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.StaffClassificationDescriptorId IS 'The titles of employment, official status, or rank of education staff.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.PositionTitle IS 'The descriptive name of an individual''s position.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.EndDate IS 'Month, day, and year of the end or termination date of a staff member''s employment, contract, or relationship with the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.OrderOfAssignment IS 'Describes whether the assignment is this the staff member''s primary assignment, secondary assignment, etc.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.EmploymentEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.EmploymentHireDate IS 'The month, day, and year on which an individual was hired for a position.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationAssignmentAssociation.FullTimeEquivalency IS 'The ratio between the hours of work expected in a position and the hours of work normally expected in a full-time position in the same setting.';

-- Extended Properties [edfi].[StaffEducationOrganizationContactAssociation] --
COMMENT ON TABLE edfi.StaffEducationOrganizationContactAssociation IS 'This association provides the contact information of the staff associated with the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociation.ContactTitle IS 'The title of the contact in the context of the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociation.ContactTypeDescriptorId IS 'Indicates the type for the contact information.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociation.ElectronicMailAddress IS 'The email for the contact associated with the education organization.';

-- Extended Properties [edfi].[StaffEducationOrganizationContactAssociationAddress] --
COMMENT ON TABLE edfi.StaffEducationOrganizationContactAssociationAddress IS 'The optional address for the contact associated with the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.ContactTitle IS 'The title of the contact in the context of the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [edfi].[StaffEducationOrganizationContactAssociationAddressPeriod] --
COMMENT ON TABLE edfi.StaffEducationOrganizationContactAssociationAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddressPeriod.ContactTitle IS 'The title of the contact in the context of the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddressPeriod.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddressPeriod.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [edfi].[StaffEducationOrganizationContactAssociationTelephone] --
COMMENT ON TABLE edfi.StaffEducationOrganizationContactAssociationTelephone IS 'The optional telephone for the contact associated with the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationTelephone.ContactTitle IS 'The title of the contact in the context of the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationTelephone.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationTelephone.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationContactAssociationTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [edfi].[StaffEducationOrganizationEmploymentAssociation] --
COMMENT ON TABLE edfi.StaffEducationOrganizationEmploymentAssociation IS 'This association indicates the education organization an employee, contractor, volunteer, or other service provider is formally associated with typically indicated by which organization the staff member has a services contract with or receives compensation from.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.HireDate IS 'The month, day, and year on which an individual was hired for a position.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.EndDate IS 'The month, day, and year on which a contract between an individual and a governing authority ends or is terminated under the provisions of the contract (or the date on which the agreement is made invalid).';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.SeparationDescriptorId IS 'Type of employment separation.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.SeparationReasonDescriptorId IS 'Reason for terminating the employment.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.Department IS 'The department or suborganization the employee/contractor is associated with in the education organization.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.FullTimeEquivalency IS 'The ratio between the hours of work expected in a position and the hours of work normally expected in a full-time position in the same setting.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.OfferDate IS 'Date at which the staff member was made an official offer for this employment.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.HourlyWage IS 'Hourly wage associated with the employment position being reported.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN edfi.StaffEducationOrganizationEmploymentAssociation.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';

-- Extended Properties [edfi].[StaffElectronicMail] --
COMMENT ON TABLE edfi.StaffElectronicMail IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN edfi.StaffElectronicMail.ElectronicMailAddress IS 'The electronic mail (e-mail) address listed for an individual or organization.';
COMMENT ON COLUMN edfi.StaffElectronicMail.ElectronicMailTypeDescriptorId IS 'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)';
COMMENT ON COLUMN edfi.StaffElectronicMail.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffElectronicMail.PrimaryEmailAddressIndicator IS 'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.';
COMMENT ON COLUMN edfi.StaffElectronicMail.DoNotPublishIndicator IS 'An indication that the electronic email address should not be published.';

-- Extended Properties [edfi].[StaffIdentificationCode] --
COMMENT ON TABLE edfi.StaffIdentificationCode IS 'A unique number or alphanumeric code assigned to a staff member by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.StaffIdentificationCode.StaffIdentificationSystemDescriptorId IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a staff member.';
COMMENT ON COLUMN edfi.StaffIdentificationCode.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code assigned to a staff member by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.StaffIdentificationCode.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the staff Identification Code.';

-- Extended Properties [edfi].[StaffIdentificationDocument] --
COMMENT ON TABLE edfi.StaffIdentificationDocument IS 'Describe the documentation of citizenship.';
COMMENT ON COLUMN edfi.StaffIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN edfi.StaffIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN edfi.StaffIdentificationDocument.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN edfi.StaffIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN edfi.StaffIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN edfi.StaffIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN edfi.StaffIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [edfi].[StaffIdentificationSystemDescriptor] --
COMMENT ON TABLE edfi.StaffIdentificationSystemDescriptor IS 'This descriptor defines the originating record system and code that is used for record-keeping purposes of the staff.';
COMMENT ON COLUMN edfi.StaffIdentificationSystemDescriptor.StaffIdentificationSystemDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[StaffInternationalAddress] --
COMMENT ON TABLE edfi.StaffInternationalAddress IS 'The set of elements that describes an international address.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.StaffInternationalAddress.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.AddressLine1 IS 'The first line of the address.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.AddressLine2 IS 'The second line of the address.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.AddressLine3 IS 'The third line of the address.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.AddressLine4 IS 'The fourth line of the address.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.CountryDescriptorId IS 'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.BeginDate IS 'The first date the address is valid. For physical addresses, the date the individual moved to that address.';
COMMENT ON COLUMN edfi.StaffInternationalAddress.EndDate IS 'The last date the address is valid. For physical addresses, the date the individual moved from that address.';

-- Extended Properties [edfi].[StaffLanguage] --
COMMENT ON TABLE edfi.StaffLanguage IS 'The language(s) the individual uses to communicate. It is strongly recommended that entries use only ISO 639-2 language codes.';
COMMENT ON COLUMN edfi.StaffLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN edfi.StaffLanguage.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffLanguageUse] --
COMMENT ON TABLE edfi.StaffLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN edfi.StaffLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN edfi.StaffLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN edfi.StaffLanguageUse.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffLeave] --
COMMENT ON TABLE edfi.StaffLeave IS 'This entity represents the recording of the dates of staff leave (e.g., sick leave, personal time, vacation).';
COMMENT ON COLUMN edfi.StaffLeave.BeginDate IS 'The begin date of the staff leave.';
COMMENT ON COLUMN edfi.StaffLeave.StaffLeaveEventCategoryDescriptorId IS 'The code describing the type of leave taken.';
COMMENT ON COLUMN edfi.StaffLeave.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffLeave.EndDate IS 'The end date of the staff leave.';
COMMENT ON COLUMN edfi.StaffLeave.Reason IS 'Expanded reason for the staff leave.';
COMMENT ON COLUMN edfi.StaffLeave.SubstituteAssigned IS 'Indicator of whether a substitute was assigned during the period of staff leave.';

-- Extended Properties [edfi].[StaffLeaveEventCategoryDescriptor] --
COMMENT ON TABLE edfi.StaffLeaveEventCategoryDescriptor IS 'A code describing the type of the leave event.';
COMMENT ON COLUMN edfi.StaffLeaveEventCategoryDescriptor.StaffLeaveEventCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[StaffOtherName] --
COMMENT ON TABLE edfi.StaffOtherName IS 'Other names (e.g., alias, nickname, previous legal name) associated with a person.';
COMMENT ON COLUMN edfi.StaffOtherName.OtherNameTypeDescriptorId IS 'The types of alternate names for an individual.';
COMMENT ON COLUMN edfi.StaffOtherName.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffOtherName.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the individual.';
COMMENT ON COLUMN edfi.StaffOtherName.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN edfi.StaffOtherName.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN edfi.StaffOtherName.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN edfi.StaffOtherName.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';

-- Extended Properties [edfi].[StaffPersonalIdentificationDocument] --
COMMENT ON TABLE edfi.StaffPersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN edfi.StaffPersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN edfi.StaffPersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN edfi.StaffPersonalIdentificationDocument.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffPersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN edfi.StaffPersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN edfi.StaffPersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN edfi.StaffPersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN edfi.StaffPersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [edfi].[StaffProgramAssociation] --
COMMENT ON TABLE edfi.StaffProgramAssociation IS 'This association indicates the staff associated with a program.';
COMMENT ON COLUMN edfi.StaffProgramAssociation.BeginDate IS 'Start date for the association of staff to this program.';
COMMENT ON COLUMN edfi.StaffProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StaffProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StaffProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StaffProgramAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffProgramAssociation.EndDate IS 'End date for the association of staff to this program.';
COMMENT ON COLUMN edfi.StaffProgramAssociation.StudentRecordAccess IS 'Indicator of whether the staff has access to the student records of the program per district interpretation of FERPA and other privacy laws, regulations, and policies.';

-- Extended Properties [edfi].[StaffRace] --
COMMENT ON TABLE edfi.StaffRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN edfi.StaffRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN edfi.StaffRace.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffRecognition] --
COMMENT ON TABLE edfi.StaffRecognition IS 'Recognitions given to the staff for accomplishments in a co-curricular or extracurricular activity.';
COMMENT ON COLUMN edfi.StaffRecognition.RecognitionTypeDescriptorId IS 'The nature of recognition given to the individual for accomplishments in a co-curricular, or extra-curricular activity.';
COMMENT ON COLUMN edfi.StaffRecognition.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffRecognition.AchievementTitle IS 'The title assigned to the achievement.';
COMMENT ON COLUMN edfi.StaffRecognition.AchievementCategoryDescriptorId IS 'The category of achievement attributed to the individual.';
COMMENT ON COLUMN edfi.StaffRecognition.AchievementCategorySystem IS 'The system that defines the categories by which an achievement is attributed to the individual.';
COMMENT ON COLUMN edfi.StaffRecognition.IssuerName IS 'The name of the agent, entity, or institution issuing the element.';
COMMENT ON COLUMN edfi.StaffRecognition.IssuerOriginURL IS 'The Uniform Resource Locator (URL) from which the award was issued.';
COMMENT ON COLUMN edfi.StaffRecognition.Criteria IS 'The criteria for competency-based completion of the achievement/award.';
COMMENT ON COLUMN edfi.StaffRecognition.CriteriaURL IS 'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.';
COMMENT ON COLUMN edfi.StaffRecognition.EvidenceStatement IS 'A statement or reference describing the evidence that the individual met the criteria for attainment of the achievement/award.';
COMMENT ON COLUMN edfi.StaffRecognition.ImageURL IS 'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the achievement/award.';
COMMENT ON COLUMN edfi.StaffRecognition.RecognitionDescription IS 'A description of the type of recognition earned by or awarded to the individual.';
COMMENT ON COLUMN edfi.StaffRecognition.RecognitionAwardDate IS 'The date the recognition was awarded or earned.';
COMMENT ON COLUMN edfi.StaffRecognition.RecognitionAwardExpiresDate IS 'Date on which the recognition expires.';

-- Extended Properties [edfi].[StaffSchoolAssociation] --
COMMENT ON TABLE edfi.StaffSchoolAssociation IS 'This association indicates the school(s) to which a staff member provides instructional services.';
COMMENT ON COLUMN edfi.StaffSchoolAssociation.ProgramAssignmentDescriptorId IS 'The name of the program for which the individual is assigned.';
COMMENT ON COLUMN edfi.StaffSchoolAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StaffSchoolAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffSchoolAssociation.CalendarCode IS 'The identifier for the calendar.';
COMMENT ON COLUMN edfi.StaffSchoolAssociation.SchoolYear IS 'Identifier for a school year.';

-- Extended Properties [edfi].[StaffSchoolAssociationAcademicSubject] --
COMMENT ON TABLE edfi.StaffSchoolAssociationAcademicSubject IS 'The academic subjects the individual is eligible to teach.';
COMMENT ON COLUMN edfi.StaffSchoolAssociationAcademicSubject.AcademicSubjectDescriptorId IS 'The academic subjects the individual is eligible to teach.';
COMMENT ON COLUMN edfi.StaffSchoolAssociationAcademicSubject.ProgramAssignmentDescriptorId IS 'The name of the program for which the individual is assigned.';
COMMENT ON COLUMN edfi.StaffSchoolAssociationAcademicSubject.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StaffSchoolAssociationAcademicSubject.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffSchoolAssociationGradeLevel] --
COMMENT ON TABLE edfi.StaffSchoolAssociationGradeLevel IS 'The grade levels the individual is eligible to teach.';
COMMENT ON COLUMN edfi.StaffSchoolAssociationGradeLevel.GradeLevelDescriptorId IS 'The grade levels the individual is eligible to teach.';
COMMENT ON COLUMN edfi.StaffSchoolAssociationGradeLevel.ProgramAssignmentDescriptorId IS 'The name of the program for which the individual is assigned.';
COMMENT ON COLUMN edfi.StaffSchoolAssociationGradeLevel.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StaffSchoolAssociationGradeLevel.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[StaffSectionAssociation] --
COMMENT ON TABLE edfi.StaffSectionAssociation IS 'This association indicates the class sections to which a staff member is assigned.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.ClassroomPositionDescriptorId IS 'The type of position the staff member holds in the specific class/section.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.BeginDate IS 'Month, day, and year of a teacher''s assignment to the section. If blank, defaults to the first day of the first grading period for the section.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.EndDate IS 'Month, day, and year of the last day of a staff member''s assignment to the section.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.HighlyQualifiedTeacher IS 'An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for this section being taught.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.TeacherStudentDataLinkExclusion IS 'Indicates that the entire section is excluded from calculation of value-added or growth attribution calculations used for a particular teacher evaluation.';
COMMENT ON COLUMN edfi.StaffSectionAssociation.PercentageContribution IS 'Indicates the percentage of the total scheduled course time, academic standards, and/or learning activities delivered in this section by this staff member. A teacher of record designation may be based solely or partially on this contribution percentage.';

-- Extended Properties [edfi].[StaffTelephone] --
COMMENT ON TABLE edfi.StaffTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN edfi.StaffTelephone.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN edfi.StaffTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN edfi.StaffTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN edfi.StaffTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN edfi.StaffTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [edfi].[StaffTribalAffiliation] --
COMMENT ON TABLE edfi.StaffTribalAffiliation IS 'An American Indian tribe with which the staff member is affiliated.';
COMMENT ON COLUMN edfi.StaffTribalAffiliation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffTribalAffiliation.TribalAffiliationDescriptorId IS 'An American Indian tribe with which the staff member is affiliated.';

-- Extended Properties [edfi].[StaffVisa] --
COMMENT ON TABLE edfi.StaffVisa IS 'An indicator of a non-US citizen''s Visa type.';
COMMENT ON COLUMN edfi.StaffVisa.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StaffVisa.VisaDescriptorId IS 'An indicator of a non-US citizen''s Visa type.';

-- Extended Properties [edfi].[StateAbbreviationDescriptor] --
COMMENT ON TABLE edfi.StateAbbreviationDescriptor IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.StateAbbreviationDescriptor.StateAbbreviationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[StateEducationAgency] --
COMMENT ON TABLE edfi.StateEducationAgency IS 'This entity represents the agency of the state charged with the primary responsibility for coordinating and supervising public instruction, including the setting of standards for elementary and secondary instructional programs.';
COMMENT ON COLUMN edfi.StateEducationAgency.StateEducationAgencyId IS 'The identifier assigned to a state education agency.';

-- Extended Properties [edfi].[StateEducationAgencyAccountability] --
COMMENT ON TABLE edfi.StateEducationAgencyAccountability IS 'This entity maintains information about federal reporting and accountability for state education agencies.';
COMMENT ON COLUMN edfi.StateEducationAgencyAccountability.SchoolYear IS 'The school year for which the accountability is reported.';
COMMENT ON COLUMN edfi.StateEducationAgencyAccountability.StateEducationAgencyId IS 'The identifier assigned to a state education agency.';
COMMENT ON COLUMN edfi.StateEducationAgencyAccountability.CTEGraduationRateInclusion IS 'An indication of whether CTE concentrators are included in the state''s computation of its graduation rate.';

-- Extended Properties [edfi].[StateEducationAgencyFederalFunds] --
COMMENT ON TABLE edfi.StateEducationAgencyFederalFunds IS 'Contains the information about the reception and use of federal funds for reporting purposes.';
COMMENT ON COLUMN edfi.StateEducationAgencyFederalFunds.FiscalYear IS 'The fiscal year for which the federal funds are received.';
COMMENT ON COLUMN edfi.StateEducationAgencyFederalFunds.StateEducationAgencyId IS 'The identifier assigned to a state education agency.';
COMMENT ON COLUMN edfi.StateEducationAgencyFederalFunds.FederalProgramsFundingAllocation IS 'The amount of federal dollars distributed to Local Education Agencies (LEAs), retained by the State Education Agency (SEA) for program administration or other approved state-level activities (including unallocated, transferred to another state agency, or distributed to entities other than LEAs).';

-- Extended Properties [edfi].[Student] --
COMMENT ON TABLE edfi.Student IS 'This entity represents an individual for whom instruction, services, and/or care are provided in an early childhood, elementary, or secondary educational program under the jurisdiction of a school, education agency or other institution or program. A student is a person who has been enrolled in a school or other educational institution.';
COMMENT ON COLUMN edfi.Student.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.Student.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the individual.';
COMMENT ON COLUMN edfi.Student.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN edfi.Student.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN edfi.Student.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN edfi.Student.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN edfi.Student.MaidenName IS 'The individual''s maiden name.';
COMMENT ON COLUMN edfi.Student.BirthDate IS 'The month, day, and year on which an individual was born.';
COMMENT ON COLUMN edfi.Student.BirthCity IS 'The city the student was born in.';
COMMENT ON COLUMN edfi.Student.BirthStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.';
COMMENT ON COLUMN edfi.Student.BirthInternationalProvince IS 'For students born outside of the U.S., the Province or jurisdiction in which an individual is born.';
COMMENT ON COLUMN edfi.Student.BirthCountryDescriptorId IS 'The country in which an individual is born. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN edfi.Student.DateEnteredUS IS 'For students born outside of the U.S., the date the student entered the U.S.';
COMMENT ON COLUMN edfi.Student.MultipleBirthStatus IS 'Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)';
COMMENT ON COLUMN edfi.Student.BirthSexDescriptorId IS 'A person''s gender at birth.';
COMMENT ON COLUMN edfi.Student.CitizenshipStatusDescriptorId IS 'An indicator of whether or not the person is a U.S. citizen.';
COMMENT ON COLUMN edfi.Student.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN edfi.Student.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN edfi.Student.StudentUniqueId IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentAcademicRecord] --
COMMENT ON TABLE edfi.StudentAcademicRecord IS 'This educational entity represents the cumulative record of academic achievement for a student.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.CumulativeEarnedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.CumulativeEarnedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.CumulativeEarnedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.CumulativeAttemptedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.CumulativeAttemptedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.CumulativeAttemptedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.CumulativeGradePointsEarned IS 'The cumulative number of grade points an individual earns by successfully completing courses or examinations during his or her enrollment in the current school as well as those transferred from schools in which the individual had been previously enrolled.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.CumulativeGradePointAverage IS 'A measure of average performance in all courses taken by an individual during his or her school career as determined for record-keeping purposes. This is obtained by dividing the total grade points received by the total number of credits attempted. This usually includes grade points received and credits attempted in his or her current school as well as those transferred from schools in which the individual was previously enrolled.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.GradeValueQualifier IS 'The scale of equivalents, if applicable, for grades awarded as indicators of performance in schoolwork. For example, numerical equivalents for letter grades used in determining a student''s grade point average (A=4, B=3, C=2, D=1 in a four-point system) or letter equivalents for percentage grades (90-100%=A, 80-90%=B, etc.).';
COMMENT ON COLUMN edfi.StudentAcademicRecord.ProjectedGraduationDate IS 'The month and year the student is projected to graduate.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SessionEarnedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SessionEarnedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SessionEarnedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SessionAttemptedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SessionAttemptedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SessionAttemptedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SessionGradePointsEarned IS 'The number of grade points an individual earned for this session.';
COMMENT ON COLUMN edfi.StudentAcademicRecord.SessionGradePointAverage IS 'The grade point average for an individual computed as the grade points earned during the session divided by the number of credits attempted.';

-- Extended Properties [edfi].[StudentAcademicRecordAcademicHonor] --
COMMENT ON TABLE edfi.StudentAcademicRecordAcademicHonor IS 'Academic distinctions earned by or awarded to the student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.AcademicHonorCategoryDescriptorId IS 'A designation of the type of academic distinctions earned by or awarded to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.HonorDescription IS 'A description of the type of academic distinctions earned by or awarded to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.AchievementTitle IS 'The title assigned to the achievement.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.AchievementCategoryDescriptorId IS 'The category of achievement attributed to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.AchievementCategorySystem IS 'The system that defines the categories by which an achievement is attributed to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.IssuerName IS 'The name of the agent, entity, or institution issuing the element.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.IssuerOriginURL IS 'The Uniform Resource Locator (URL) from which the award was issued.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.Criteria IS 'The criteria for competency-based completion of the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.CriteriaURL IS 'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.EvidenceStatement IS 'A statement or reference describing the evidence that the individual met the criteria for attainment of the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.ImageURL IS 'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.HonorAwardDate IS 'The date the honor was awarded.';
COMMENT ON COLUMN edfi.StudentAcademicRecordAcademicHonor.HonorAwardExpiresDate IS 'Date on which the honor expires.';

-- Extended Properties [edfi].[StudentAcademicRecordClassRanking] --
COMMENT ON TABLE edfi.StudentAcademicRecordClassRanking IS 'The academic rank information of a student in relation to his or her graduating class.';
COMMENT ON COLUMN edfi.StudentAcademicRecordClassRanking.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentAcademicRecordClassRanking.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordClassRanking.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordClassRanking.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordClassRanking.ClassRank IS 'The academic rank of a student in relation to his or her graduating class (e.g., 1st, 2nd, 3rd).';
COMMENT ON COLUMN edfi.StudentAcademicRecordClassRanking.TotalNumberInClass IS 'The total number of students in the student''s graduating class.';
COMMENT ON COLUMN edfi.StudentAcademicRecordClassRanking.PercentageRanking IS 'The academic percentage rank of a student in relation to his or her graduating class (e.g., 95%, 80%, 50%).';
COMMENT ON COLUMN edfi.StudentAcademicRecordClassRanking.ClassRankingDate IS 'Date class ranking was determined.';

-- Extended Properties [edfi].[StudentAcademicRecordDiploma] --
COMMENT ON TABLE edfi.StudentAcademicRecordDiploma IS 'Diploma(s) earned by the student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.DiplomaAwardDate IS 'The month, day, and year on which the student met  graduation requirements and was awarded a diploma.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.DiplomaTypeDescriptorId IS 'The type of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.AchievementTitle IS 'The title assigned to the achievement.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.AchievementCategoryDescriptorId IS 'The category of achievement attributed to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.AchievementCategorySystem IS 'The system that defines the categories by which an achievement is attributed to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.IssuerName IS 'The name of the agent, entity, or institution issuing the element.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.IssuerOriginURL IS 'The Uniform Resource Locator (URL) from which the award was issued.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.Criteria IS 'The criteria for competency-based completion of the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.CriteriaURL IS 'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.EvidenceStatement IS 'A statement or reference describing the evidence that the individual met the criteria for attainment of the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.ImageURL IS 'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.DiplomaLevelDescriptorId IS 'The level of diploma/credential that is awarded to a student in recognition of completion of the curricular requirements.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.CTECompleter IS 'Indicated a student who reached a state-defined threshold of vocational education and who attained a high school diploma or its recognized state equivalent or GED.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.DiplomaDescription IS 'The description of the diploma given to the student for accomplishments.';
COMMENT ON COLUMN edfi.StudentAcademicRecordDiploma.DiplomaAwardExpiresDate IS 'Date on which the diploma expires.';

-- Extended Properties [edfi].[StudentAcademicRecordGradePointAverage] --
COMMENT ON TABLE edfi.StudentAcademicRecordGradePointAverage IS 'The grade point average for an individual computed as the grade points earned divided by the number of credits attempted.';
COMMENT ON COLUMN edfi.StudentAcademicRecordGradePointAverage.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentAcademicRecordGradePointAverage.GradePointAverageTypeDescriptorId IS 'The system used for calculating the grade point average for an individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordGradePointAverage.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordGradePointAverage.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordGradePointAverage.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordGradePointAverage.IsCumulative IS 'Indicator of whether or not the Grade Point Average value is cumulative.';
COMMENT ON COLUMN edfi.StudentAcademicRecordGradePointAverage.GradePointAverageValue IS 'The value of the grade points earned divided by the number of credits attempted.';
COMMENT ON COLUMN edfi.StudentAcademicRecordGradePointAverage.MaxGradePointAverageValue IS 'The maximum value for the grade point average.';

-- Extended Properties [edfi].[StudentAcademicRecordRecognition] --
COMMENT ON TABLE edfi.StudentAcademicRecordRecognition IS 'Recognitions given to the student for accomplishments in a co-curricular or extracurricular activity.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.RecognitionTypeDescriptorId IS 'The nature of recognition given to the individual for accomplishments in a co-curricular, or extra-curricular activity.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.AchievementTitle IS 'The title assigned to the achievement.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.AchievementCategoryDescriptorId IS 'The category of achievement attributed to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.AchievementCategorySystem IS 'The system that defines the categories by which an achievement is attributed to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.IssuerName IS 'The name of the agent, entity, or institution issuing the element.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.IssuerOriginURL IS 'The Uniform Resource Locator (URL) from which the award was issued.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.Criteria IS 'The criteria for competency-based completion of the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.CriteriaURL IS 'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.EvidenceStatement IS 'A statement or reference describing the evidence that the individual met the criteria for attainment of the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.ImageURL IS 'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the achievement/award.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.RecognitionDescription IS 'A description of the type of recognition earned by or awarded to the individual.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.RecognitionAwardDate IS 'The date the recognition was awarded or earned.';
COMMENT ON COLUMN edfi.StudentAcademicRecordRecognition.RecognitionAwardExpiresDate IS 'Date on which the recognition expires.';

-- Extended Properties [edfi].[StudentAcademicRecordReportCard] --
COMMENT ON TABLE edfi.StudentAcademicRecordReportCard IS 'Report cards for the student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordReportCard.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentAcademicRecordReportCard.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.StudentAcademicRecordReportCard.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentAcademicRecordReportCard.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordReportCard.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.StudentAcademicRecordReportCard.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentAcademicRecordReportCard.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAcademicRecordReportCard.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [edfi].[StudentAssessment] --
COMMENT ON TABLE edfi.StudentAssessment IS 'This entity represents the analysis or scoring of a student''s response on an assessment. The analysis results in a value that represents a student''s performance on a set of items on a test.';
COMMENT ON COLUMN edfi.StudentAssessment.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessment.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessment.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessment.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessment.AdministrationDate IS 'The date and time an assessment was completed by the student. The use of ISO-8601 formats with a timezone designator (UTC or time offset) is recommended in order to prevent ambiguity due to time zones.';
COMMENT ON COLUMN edfi.StudentAssessment.AdministrationEndDate IS 'The date and time an assessment administration ended.';
COMMENT ON COLUMN edfi.StudentAssessment.SerialNumber IS 'The unique number for the assessment form or answer document.';
COMMENT ON COLUMN edfi.StudentAssessment.AdministrationLanguageDescriptorId IS 'The language in which an assessment is written and/or administered.';
COMMENT ON COLUMN edfi.StudentAssessment.AdministrationEnvironmentDescriptorId IS 'The environment in which the test was administered.';
COMMENT ON COLUMN edfi.StudentAssessment.RetestIndicatorDescriptorId IS 'Indicator if the test was a retake.';
COMMENT ON COLUMN edfi.StudentAssessment.ReasonNotTestedDescriptorId IS 'The primary reason student is not tested.';
COMMENT ON COLUMN edfi.StudentAssessment.WhenAssessedGradeLevelDescriptorId IS 'The grade level of a student when assessed.';
COMMENT ON COLUMN edfi.StudentAssessment.EventCircumstanceDescriptorId IS 'An unusual event occurred during the administration of the assessment. This could include fire alarm, student became ill, etc.';
COMMENT ON COLUMN edfi.StudentAssessment.EventDescription IS 'Describes special events that occur before during or after the assessment session that may impact use of results.';
COMMENT ON COLUMN edfi.StudentAssessment.SchoolYear IS 'The school year for which the assessment was administered to a student. Among other uses, handles cases in which a student takes a prior-year exam in a subsequent school year during an exam re-test.';
COMMENT ON COLUMN edfi.StudentAssessment.PlatformTypeDescriptorId IS 'The platform with which the assessment was delivered to the student during the assessment session.';
COMMENT ON COLUMN edfi.StudentAssessment.AssessedMinutes IS 'Reported time student was assessed in minutes.';
COMMENT ON COLUMN edfi.StudentAssessment.ReportedSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentAssessment.ReportedSchoolIdentifier IS 'A reported school identifier for the school the enrollment at the time of the assessment used when the assigned SchoolId is not known by the assessment vendor.';

-- Extended Properties [edfi].[StudentAssessmentAccommodation] --
COMMENT ON TABLE edfi.StudentAssessmentAccommodation IS 'The specific type of special variation used in how an examination is presented, how it is administered, or how the test taker is allowed to respond. This generally refers to changes that do not substantially alter what the examination measures. The proper use of accommodations does not substantially change academic level or performance criteria.';
COMMENT ON COLUMN edfi.StudentAssessmentAccommodation.AccommodationDescriptorId IS 'The specific type of special variation used in how an examination is presented, how it is administered, or how the test taker is allowed to respond. This generally refers to changes that do not substantially alter what the examination measures. The proper use of accommodations does not substantially change academic level or performance criteria.';
COMMENT ON COLUMN edfi.StudentAssessmentAccommodation.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentAccommodation.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentAccommodation.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentAccommodation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentAssessmentEducationOrganizationAssociation] --
COMMENT ON TABLE edfi.StudentAssessmentEducationOrganizationAssociation IS 'The association of individual StudentAssessments with EducationOrganizations indicating administration, enrollment, or attribution.';
COMMENT ON COLUMN edfi.StudentAssessmentEducationOrganizationAssociation.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentEducationOrganizationAssociation.EducationOrganizationAssociationTypeDescriptorId IS 'The type of association being represented.';
COMMENT ON COLUMN edfi.StudentAssessmentEducationOrganizationAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentAssessmentEducationOrganizationAssociation.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentEducationOrganizationAssociation.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentEducationOrganizationAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentEducationOrganizationAssociation.SchoolYear IS 'The school year associated with the association..';

-- Extended Properties [edfi].[StudentAssessmentItem] --
COMMENT ON TABLE edfi.StudentAssessmentItem IS 'The student''s response to an assessment item and the item-level scores such as correct, incorrect, or met standard.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.IdentificationCode IS 'A unique number or alphanumeric code assigned to a space, room, site, building, individual, organization, program, or institution by a school, school system, state, or other agency or entity.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.AssessmentResponse IS 'A student''s response to a stimulus on a test.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.DescriptiveFeedback IS 'The formative descriptive feedback that was given to a student in response to the results from a scored/evaluated assessment item.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.ResponseIndicatorDescriptorId IS 'Indicator of the response.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.AssessmentItemResultDescriptorId IS 'The analyzed result of a student''s response to an assessment item.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.RawScoreResult IS 'A meaningful raw score of the performance of a student on an assessment item.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.TimeAssessed IS 'The overall time a student actually spent during the assessment item.';
COMMENT ON COLUMN edfi.StudentAssessmentItem.ItemNumber IS 'The test question number for this student''s test item.';

-- Extended Properties [edfi].[StudentAssessmentPerformanceLevel] --
COMMENT ON TABLE edfi.StudentAssessmentPerformanceLevel IS 'The performance level(s) achieved for the student assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentPerformanceLevel.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentPerformanceLevel.AssessmentReportingMethodDescriptorId IS 'The method that the instructor of the class uses to report the performance and achievement. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or numerical grade. In some cases, more than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.StudentAssessmentPerformanceLevel.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentPerformanceLevel.PerformanceLevelDescriptorId IS 'A specification of which performance level value describes the student proficiency.';
COMMENT ON COLUMN edfi.StudentAssessmentPerformanceLevel.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentPerformanceLevel.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentPerformanceLevel.PerformanceLevelIndicatorName IS 'The name of the indicator being measured for a collection of performance level values.';

-- Extended Properties [edfi].[StudentAssessmentPeriod] --
COMMENT ON TABLE edfi.StudentAssessmentPeriod IS 'The period or window in which an assessment is supposed to be administered.';
COMMENT ON COLUMN edfi.StudentAssessmentPeriod.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentPeriod.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentPeriod.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentPeriod.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentPeriod.AssessmentPeriodDescriptorId IS 'The period of time in which an assessment is supposed to be administered (e.g., Beginning of Year, Middle of Year, End of Year).';
COMMENT ON COLUMN edfi.StudentAssessmentPeriod.BeginDate IS 'The first date the assessment is to be administered.';
COMMENT ON COLUMN edfi.StudentAssessmentPeriod.EndDate IS 'The last date the assessment is to be administered.';

-- Extended Properties [edfi].[StudentAssessmentScoreResult] --
COMMENT ON TABLE edfi.StudentAssessmentScoreResult IS 'A meaningful score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN edfi.StudentAssessmentScoreResult.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentScoreResult.AssessmentReportingMethodDescriptorId IS 'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.StudentAssessmentScoreResult.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentScoreResult.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentScoreResult.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentScoreResult.Result IS 'The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN edfi.StudentAssessmentScoreResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [edfi].[StudentAssessmentStudentObjectiveAssessment] --
COMMENT ON TABLE edfi.StudentAssessmentStudentObjectiveAssessment IS 'The student''s score and/or performance levels earned for an objective assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessment.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessment.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessment.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessment.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessment.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessment.AssessedMinutes IS 'Reported time student was assessed in minutes.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessment.AdministrationDate IS 'The date and time an assessment was completed by the student. The use of ISO-8601 formats with a timezone designator (UTC or time offset) is recommended in order to prevent ambiguity due to time zones.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessment.AdministrationEndDate IS 'The date and time an assessment administration ended.';

-- Extended Properties [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] --
COMMENT ON TABLE edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel IS 'The performance level(s) achieved for the objective assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.AssessmentReportingMethodDescriptorId IS 'The method that the instructor of the class uses to report the performance and achievement. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or numerical grade. In some cases, more than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.PerformanceLevelDescriptorId IS 'A specification of which performance level value describes the student proficiency.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.PerformanceLevelIndicatorName IS 'The name of the indicator being measured for a collection of performance level values.';

-- Extended Properties [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] --
COMMENT ON TABLE edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult IS 'A meaningful score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult.AssessmentReportingMethodDescriptorId IS 'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult.IdentificationCode IS 'A unique number or alphanumeric code assigned to an objective assessment by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult.Namespace IS 'Namespace for the assessment.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult.StudentAssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment administered to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult.Result IS 'The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [edfi].[StudentCharacteristicDescriptor] --
COMMENT ON TABLE edfi.StudentCharacteristicDescriptor IS 'This descriptor captures important characteristics of the student''s environment or situation. Generally used for non-program-based student characteristics.';
COMMENT ON COLUMN edfi.StudentCharacteristicDescriptor.StudentCharacteristicDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[StudentCohortAssociation] --
COMMENT ON TABLE edfi.StudentCohortAssociation IS 'This association represents the cohort(s) for which a student is designated.';
COMMENT ON COLUMN edfi.StudentCohortAssociation.BeginDate IS 'The month, day, and year on which the student was first identified as part of the cohort.';
COMMENT ON COLUMN edfi.StudentCohortAssociation.CohortIdentifier IS 'The name or ID for the cohort.';
COMMENT ON COLUMN edfi.StudentCohortAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCohortAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentCohortAssociation.EndDate IS 'The month, day, and year on which the student was removed as part of the cohort.';

-- Extended Properties [edfi].[StudentCohortAssociationSection] --
COMMENT ON TABLE edfi.StudentCohortAssociationSection IS 'The cohort representing the subdivision of students within one or more sections. For example, a group of students may be given additional instruction and tracked as a cohort.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.BeginDate IS 'The month, day, and year on which the student was first identified as part of the cohort.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.CohortIdentifier IS 'The name or ID for the cohort.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.StudentCohortAssociationSection.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentCompetencyObjective] --
COMMENT ON TABLE edfi.StudentCompetencyObjective IS 'This entity represents the competency assessed or evaluated for the student against a specific competency objective.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.Objective IS 'The designated title of the competency objective.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.ObjectiveEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.ObjectiveGradeLevelDescriptorId IS 'The grade level for which the competency objective is targeted.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.CompetencyLevelDescriptorId IS 'The competency level assessed for the student for the referenced competency objective.';
COMMENT ON COLUMN edfi.StudentCompetencyObjective.DiagnosticStatement IS 'A statement provided by the teacher that provides information in addition to the grade or assessment score.';

-- Extended Properties [edfi].[StudentCompetencyObjectiveGeneralStudentProgramAssociation] --
COMMENT ON TABLE edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation IS 'Relates the student and program associated with the competency objective.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.Objective IS 'The designated title of the competency objective.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.ObjectiveEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.ObjectiveGradeLevelDescriptorId IS 'The grade level for which the competency objective is targeted.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveGeneralStudentProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentCompetencyObjectiveStudentSectionAssociation] --
COMMENT ON TABLE edfi.StudentCompetencyObjectiveStudentSectionAssociation IS 'Relates the student and section associated with the competency objective.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.BeginDate IS 'Month, day, and year of the student''s entry or assignment to the section.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.Objective IS 'The designated title of the competency objective.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.ObjectiveEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.ObjectiveGradeLevelDescriptorId IS 'The grade level for which the competency objective is targeted.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.StudentCompetencyObjectiveStudentSectionAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentCTEProgramAssociation] --
COMMENT ON TABLE edfi.StudentCTEProgramAssociation IS 'This association represents the career and technical education (CTE) program that a student participates in. The association is an extension of the StudentProgramAssociation particular for CTE programs.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.NonTraditionalGenderStatus IS 'Indicator that student is from a gender group that comprises less than 25% of the individuals employed in an occupation or field of work.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.PrivateCTEProgram IS 'Indicator that student participated in career and technical education at private agencies or institutions that are reported by the state for purposes of the Elementary and Secondary Education Act (ESEA). Students in private institutions which do not receive Perkins funding are reported only in the state file.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociation.TechnicalSkillsAssessmentDescriptorId IS 'Results of technical skills assessment aligned with industry recognized standards.';

-- Extended Properties [edfi].[StudentCTEProgramAssociationCTEProgram] --
COMMENT ON TABLE edfi.StudentCTEProgramAssociationCTEProgram IS 'The career cluster representing the career path of the Vocational/Career Tech concentrator.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.CareerPathwayDescriptorId IS 'A sequence of courses within an area of interest that is a student''s educational road map to a chosen career.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.CIPCode IS 'Number and description of the CIP code associated with the student''s CTE program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.PrimaryCTEProgramIndicator IS 'A boolean indicator of whether this CTE program is the student''s primary CTE program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgram.CTEProgramCompletionIndicator IS 'A boolean indicator of whether the student has completed the CTE program.';

-- Extended Properties [edfi].[StudentCTEProgramAssociationCTEProgramService] --
COMMENT ON TABLE edfi.StudentCTEProgramAssociationCTEProgramService IS 'Indicates the service(s) being provided to the student by the CTE program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.CTEProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the CTE program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.ServiceEndDate IS 'Last date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationCTEProgramService.CIPCode IS 'Number and description of the CIP code associated with the student''s CTE program.';

-- Extended Properties [edfi].[StudentCTEProgramAssociationService] --
COMMENT ON TABLE edfi.StudentCTEProgramAssociationService IS 'Indicates the service(s) being provided to the student by the program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.ServiceDescriptorId IS 'Indicates the service being provided to the student by the program.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentCTEProgramAssociationService.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentDisciplineIncidentAssociation] --
COMMENT ON TABLE edfi.StudentDisciplineIncidentAssociation IS 'This association indicates those students who were victims, perpetrators, witnesses, and reporters for a discipline incident.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociation.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociation.StudentParticipationCodeDescriptorId IS 'The role or type of participation of a student in a discipline incident.';

-- Extended Properties [edfi].[StudentDisciplineIncidentAssociationBehavior] --
COMMENT ON TABLE edfi.StudentDisciplineIncidentAssociationBehavior IS 'Describes behavior by category and provides a detailed description.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociationBehavior.BehaviorDescriptorId IS 'Describes behavior by category and provides a detailed description.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociationBehavior.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociationBehavior.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociationBehavior.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentAssociationBehavior.BehaviorDetailedDescription IS 'Specifies a more granular level of detail of a behavior involved in the incident.';

-- Extended Properties [edfi].[StudentDisciplineIncidentBehaviorAssociation] --
COMMENT ON TABLE edfi.StudentDisciplineIncidentBehaviorAssociation IS 'This association describes the behavior of students involved in a discipline incident.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociation.BehaviorDescriptorId IS 'Describes behavior by category.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociation.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociation.BehaviorDetailedDescription IS 'Specifies a more granular level of detail of a behavior involved in the incident.';

-- Extended Properties [edfi].[StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21] --
COMMENT ON TABLE edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21 IS 'The role or type of participation of a student in a discipline incident.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21.BehaviorDescriptorId IS 'Describes behavior by category.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21.DisciplineIncidentParticipationCodeDescriptorId IS 'The role or type of participation of a student in a discipline incident.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentBehaviorAssociationDisciplineIn_ae6a21.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentDisciplineIncidentNonOffenderAssociation] --
COMMENT ON TABLE edfi.StudentDisciplineIncidentNonOffenderAssociation IS 'This association indicates those students who were involved and not perpetrators for a discipline incident.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentNonOffenderAssociation.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentNonOffenderAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentNonOffenderAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a] --
COMMENT ON TABLE edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a IS 'The role or type of participation of a student in a discipline incident.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a.DisciplineIncidentParticipationCodeDescriptorId IS 'The role or type of participation of a student in a discipline incident.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a.IncidentIdentifier IS 'A locally assigned unique identifier (within the school or school district) to identify each specific DisciplineIncident or occurrence. The same identifier should be used to document the entire discipline incident even if it included multiple offenses and multiple offenders.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentDisciplineIncidentNonOffenderAssociationDisciplin_4c979a.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociation] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociation IS 'This association represents student information as reported in the context of the student''s relationship to the education organization. Enrollment relationship semantics are covered by StudentSchoolAssociation.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.SexDescriptorId IS 'The student''s gender as last reported to the education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.ProfileThumbnail IS 'Locator reference for the student photo. The specification for that reference is left to local definition.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race, as last reported to the education organization. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.OldEthnicityDescriptorId IS 'Previous definition of ethnicity combining Hispanic/Latino and race:
        1 - American Indian or Alaskan Native
        2 - Asian or Pacific Islander
        3 - Black, not of Hispanic origin
        4 - Hispanic
        5 - White, not of Hispanic origin.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.LimitedEnglishProficiencyDescriptorId IS 'An indication that the student has been identified as limited English proficient by the Language Proficiency Assessment Committee (LPAC), or English proficient.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.LoginId IS 'The login ID for the user; used for security access control interface.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.PrimaryLearningDeviceAwayFromSchoolDescriptorId IS 'The type of device the student uses most often to complete learning activities away from school.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.PrimaryLearningDeviceAccessDescriptorId IS 'An indication of whether the primary learning device is shared or not shared with another individual.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.PrimaryLearningDeviceProviderDescriptorId IS 'The provider of the primary learning device.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.InternetAccessInResidence IS 'An indication of whether the student is able to access the internet in their primary place of residence.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.BarrierToInternetAccessInResidenceDescriptorId IS 'An indication of the barrier to having internet access in the student’s primary place of residence.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.InternetAccessTypeInResidenceDescriptorId IS 'The primary type of internet service used in the student’s primary place of residence.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociation.InternetPerformanceInResidenceDescriptorId IS 'An indication of whether the student can complete the full range of learning activities, including video streaming and assignment upload, without interruptions caused by poor internet performance in their primary place of residence.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationAddress] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationAddressPeriod] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationAncestryEthnicOrigin] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin IS 'The original peoples or cultures with which the individual identifies.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin.AncestryEthnicOriginDescriptorId IS 'The original peoples or cultures with which the individual identifies.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationAncestryEthnicOrigin.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationCohortYear] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationCohortYear IS 'The type and year of a cohort (e.g., 9th grade) the student belongs to as determined by the year that student entered a specific grade.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationCohortYear.CohortYearTypeDescriptorId IS 'The type of cohort year (9th grade, graduation).';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationCohortYear.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationCohortYear.SchoolYear IS 'The school year associated with the cohort; for example, the intended school year of graduation.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationCohortYear.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationCohortYear.TermDescriptorId IS 'The term associated with the cohort year; for example, the intended term of graduation.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationDisability] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationDisability IS 'The disability condition(s) that best describes an individual''s impairment, as determined by evaluation(s) conducted by the education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisability.DisabilityDescriptorId IS 'A disability category that describes a individual''s impairment.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisability.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisability.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisability.OrderOfDisability IS 'The order by severity of individual''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationDisabilityDesignation] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a individual''s impairment.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisabilityDesignation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationDisabilityDesignation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationElectronicMail] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationElectronicMail IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationElectronicMail.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationElectronicMail.ElectronicMailAddress IS 'The electronic mail (e-mail) address listed for an individual or organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationElectronicMail.ElectronicMailTypeDescriptorId IS 'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationElectronicMail.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationElectronicMail.PrimaryEmailAddressIndicator IS 'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationElectronicMail.DoNotPublishIndicator IS 'An indication that the electronic email address should not be published.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationInternationalAddress] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationInternationalAddress IS 'The set of elements that describes an international address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.AddressLine1 IS 'The first line of the address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.AddressLine2 IS 'The second line of the address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.AddressLine3 IS 'The third line of the address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.AddressLine4 IS 'The fourth line of the address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.CountryDescriptorId IS 'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.BeginDate IS 'The first date the address is valid. For physical addresses, the date the individual moved to that address.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationInternationalAddress.EndDate IS 'The last date the address is valid. For physical addresses, the date the individual moved from that address.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationLanguage] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationLanguage IS 'The language(s) the individual uses to communicate. It is strongly recommended that entries use only ISO 639-3 language codes.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationLanguage.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationLanguage.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationLanguageUse] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationLanguageUse.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationLanguageUse.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationProgramParticipat_810575] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationProgramParticipat_810575 IS 'Reflects important characteristics of the program, such as categories or particular indications.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipat_810575.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipat_810575.ProgramCharacteristicDescriptorId IS 'Reflects important characteristics of the program, such as categories or particular indications.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipat_810575.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipat_810575.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationProgramParticipation] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationProgramParticipation IS 'Key programs the student is participating in or receives services from.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipation.BeginDate IS 'The date the student was associated with the program or service.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipation.EndDate IS 'The date the program participation ended.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationProgramParticipation.DesignatedBy IS 'The person, organization, or department that designated the program association.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationRace] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies as last reported to the education organization. The data model allows for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationRace.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies as last reported to the education organization. The data model allows for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationRace.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationStudentCharacteri_a18fcf] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf IS 'The time periods for which characteristic was effective.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf.StudentCharacteristicDescriptorId IS 'The characteristic designated for the student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteri_a18fcf.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationStudentCharacteristic IS 'Reflects important characteristics of a student. If a student has a characteristic present, that characteristic is considered true or active for that student. If a characteristic is not present, no assumption is made as to the applicability of the characteristic, but local policy may dictate otherwise.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteristic.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteristic.StudentCharacteristicDescriptorId IS 'The characteristic designated for the student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteristic.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentCharacteristic.DesignatedBy IS 'The person, organization, or department that designated the characteristic.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationStudentIdentifica_c15030] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030 IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the StudentIdentificationCode.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030.StudentIdentificationSystemDescriptorId IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIdentifica_c15030.IdentificationCode IS 'A unique number or alphanumeric code assigned to a student by a school, school system, a state, or other agency or entity.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationStudentIndicator] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationStudentIndicator IS 'An indicator or metric computed for the student (e.g., at risk).';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicator.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicator.IndicatorName IS 'The name of the indicator or metric.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicator.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicator.IndicatorGroup IS 'The name for a group of indicators.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicator.Indicator IS 'The value of the indicator or metric.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicator.DesignatedBy IS 'The person, organization, or department that designated the program association.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationStudentIndicatorPeriod] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod IS 'The time periods for which the indicator was effective.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod.IndicatorName IS 'The name of the indicator or metric.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationStudentIndicatorPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationTelephone] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTelephone.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTelephone.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [edfi].[StudentEducationOrganizationAssociationTribalAffiliation] --
COMMENT ON TABLE edfi.StudentEducationOrganizationAssociationTribalAffiliation IS 'An American Indian tribe with which the student is affiliated as last reported to the education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTribalAffiliation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTribalAffiliation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationAssociationTribalAffiliation.TribalAffiliationDescriptorId IS 'An American Indian tribe with which the student is affiliated as last reported to the education organization.';

-- Extended Properties [edfi].[StudentEducationOrganizationResponsibilityAssociation] --
COMMENT ON TABLE edfi.StudentEducationOrganizationResponsibilityAssociation IS 'This association indicates a relationship between a student and an education organization other than an enrollment relationship, and generally indicating some kind of responsibility of the education organization for the student. Enrollment relationship semantics are covered by StudentSchoolAssociation.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationResponsibilityAssociation.BeginDate IS 'Month, day, and year of the start date of an education organization''s responsibility for a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationResponsibilityAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationResponsibilityAssociation.ResponsibilityDescriptorId IS 'Indications of an education organization''s responsibility for a student, such as accountability, attendance, funding, etc.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationResponsibilityAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentEducationOrganizationResponsibilityAssociation.EndDate IS 'Month, day, and year of the end date of an education organization''s responsibility for a student.';

-- Extended Properties [edfi].[StudentGradebookEntry] --
COMMENT ON TABLE edfi.StudentGradebookEntry IS 'This entity holds a student''s grade or competency level for a gradebook entry.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.GradebookEntryIdentifier IS 'A unique number or alphanumeric code assigned to a gradebook entry by the source system.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.Namespace IS 'Namespace URI for the source of the gradebook entry.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.CompetencyLevelDescriptorId IS 'The competency level assessed for the student for the referenced learning objective.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.DateFulfilled IS 'The date an assignment was turned in or the date of an assessment.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.TimeFulfilled IS 'The time an assignment was turned in on the date fulfilled.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.DiagnosticStatement IS 'A statement provided by the teacher that provides information in addition to the grade or assessment score.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.PointsEarned IS 'The points earned for the submission. With extra credit, the points earned may exceed the max points.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.LetterGradeEarned IS 'A final or interim (grading period) indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.NumericGradeEarned IS 'A final or interim (grading period) indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.SubmissionStatusDescriptorId IS 'The status of the student''s submission.';
COMMENT ON COLUMN edfi.StudentGradebookEntry.AssignmentLateStatusDescriptorId IS 'Status of whether the assignment was submitted after the due date and/or marked as.';

-- Extended Properties [edfi].[StudentHomelessProgramAssociation] --
COMMENT ON TABLE edfi.StudentHomelessProgramAssociation IS 'This association represents the McKinney-Vento Homeless Program program(s) that a student participates in or from which the student receives services.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.HomelessPrimaryNighttimeResidenceDescriptorId IS 'The primary nighttime residence of the student at the time the student is identified as homeless.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.AwaitingFosterCare IS 'State defined definition for awaiting foster care.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociation.HomelessUnaccompaniedYouth IS 'A homeless unaccompanied youth is a youth who is not in the physical custody of a parent or guardian and who fits the McKinney-Vento definition of homeless. Students must be both unaccompanied and homeless to be included as an unaccompanied homeless youth.';

-- Extended Properties [edfi].[StudentHomelessProgramAssociationHomelessProgramService] --
COMMENT ON TABLE edfi.StudentHomelessProgramAssociationHomelessProgramService IS 'Indicates the service(s) being provided to the student by the homeless program.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.HomelessProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the homeless program.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentHomelessProgramAssociationHomelessProgramService.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentIdentificationDocument] --
COMMENT ON TABLE edfi.StudentIdentificationDocument IS 'Describe the documentation of citizenship.';
COMMENT ON COLUMN edfi.StudentIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN edfi.StudentIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN edfi.StudentIdentificationDocument.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN edfi.StudentIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN edfi.StudentIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN edfi.StudentIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN edfi.StudentIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [edfi].[StudentIdentificationSystemDescriptor] --
COMMENT ON TABLE edfi.StudentIdentificationSystemDescriptor IS 'This descriptor defines the originating record system and code that is used for record-keeping purposes of the student.';
COMMENT ON COLUMN edfi.StudentIdentificationSystemDescriptor.StudentIdentificationSystemDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[StudentInterventionAssociation] --
COMMENT ON TABLE edfi.StudentInterventionAssociation IS 'This association indicates the students participating in an intervention.';
COMMENT ON COLUMN edfi.StudentInterventionAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentInterventionAssociation.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.StudentInterventionAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentInterventionAssociation.CohortIdentifier IS 'The name or ID for the cohort.';
COMMENT ON COLUMN edfi.StudentInterventionAssociation.CohortEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentInterventionAssociation.DiagnosticStatement IS 'A statement provided by the assigner that provides information regarding why the student was assigned to this intervention.';
COMMENT ON COLUMN edfi.StudentInterventionAssociation.Dosage IS 'The duration of time in minutes for which the student was assigned to participate in the intervention.';

-- Extended Properties [edfi].[StudentInterventionAssociationInterventionEffectiveness] --
COMMENT ON TABLE edfi.StudentInterventionAssociationInterventionEffectiveness IS 'A measure of the effects of an intervention in each outcome domain. The rating of effectiveness takes into account four factors: the quality of the research on the intervention, the statistical significance of the research findings, the size of the differences between participants in the intervention and comparison groups and the consistency in results.';
COMMENT ON COLUMN edfi.StudentInterventionAssociationInterventionEffectiveness.DiagnosisDescriptorId IS 'Targeted purpose of the intervention (e.g., attendance issue, dropout risk) for which the effectiveness is measured.';
COMMENT ON COLUMN edfi.StudentInterventionAssociationInterventionEffectiveness.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentInterventionAssociationInterventionEffectiveness.GradeLevelDescriptorId IS 'Grade level for which effectiveness is measured.';
COMMENT ON COLUMN edfi.StudentInterventionAssociationInterventionEffectiveness.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.StudentInterventionAssociationInterventionEffectiveness.PopulationServedDescriptorId IS 'Population for which effectiveness is measured.';
COMMENT ON COLUMN edfi.StudentInterventionAssociationInterventionEffectiveness.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentInterventionAssociationInterventionEffectiveness.ImprovementIndex IS 'Along a percentile distribution of students, the improvement index represents the change in an average student''s percentile rank that is considered to be due to the intervention.';
COMMENT ON COLUMN edfi.StudentInterventionAssociationInterventionEffectiveness.InterventionEffectivenessRatingDescriptorId IS 'An intervention demonstrates effectiveness if the research has shown that the program caused an improvement in outcomes. Values: positive effects, potentially positive effects, mixed effects, potentially negative effects, negative effects, and no discernible effects.';

-- Extended Properties [edfi].[StudentInterventionAttendanceEvent] --
COMMENT ON TABLE edfi.StudentInterventionAttendanceEvent IS 'This event entity represents the recording of whether a student is in attendance for an intervention service.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.AttendanceEventCategoryDescriptorId IS 'A code describing the attendance event, for example:
        Present
        Unexcused absence
        Excused absence
        Tardy.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.EventDate IS 'Date for this attendance event.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.InterventionIdentificationCode IS 'A unique number or alphanumeric code assigned to an intervention.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.AttendanceEventReason IS 'The reported reason for a student''s absence.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.EducationalEnvironmentDescriptorId IS 'The setting in which a child receives education and related services. This attribute is only used if it differs from the EducationalEnvironment of the Section. This is only used in the AttendanceEvent if different from the associated Section.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.EventDuration IS 'The amount of time for the event as recognized by the school: 1 day = 1, 1/2 day = 0.5, 1/3 day = 0.33.';
COMMENT ON COLUMN edfi.StudentInterventionAttendanceEvent.InterventionDuration IS 'The duration in minutes in which the student participated in the intervention during this instance.';

-- Extended Properties [edfi].[StudentLanguageInstructionProgramAssociation] --
COMMENT ON TABLE edfi.StudentLanguageInstructionProgramAssociation IS 'This association represents the Title III Language Instruction for Limited English Proficient and Immigrant Students program(s) that a student participates in or from which the student receives services.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociation.EnglishLearnerParticipation IS 'An indication that an English learner student is served by an English language instruction educational program supported with Title III of ESEA funds.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociation.Dosage IS 'The duration of time in minutes for which the student was assigned to participate in the program.';

-- Extended Properties [edfi].[StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620] --
COMMENT ON TABLE edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620 IS 'Results of yearly English language assessment.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.SchoolYear IS 'The school year for which the assessment was administered.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.ParticipationDescriptorId IS 'Field indicating the participation in the yearly English language assessment.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.ProficiencyDescriptorId IS 'The proficiency level for the yearly English language assessment.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.ProgressDescriptorId IS 'The yearly progress or growth from last year''s assessment.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationEnglishLangu_1ac620.MonitoredDescriptorId IS 'Student is monitored on content achievement who are no longer receiving services.';

-- Extended Properties [edfi].[StudentLanguageInstructionProgramAssociationLanguageInst_268e07] --
COMMENT ON TABLE edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07 IS 'Indicates the service(s) being provided to the student by the language instruction program.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.LanguageInstructionProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the language instruction program.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentLanguageInstructionProgramAssociationLanguageInst_268e07.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentLearningObjective] --
COMMENT ON TABLE edfi.StudentLearningObjective IS 'This entity represents the competency assessed or evaluated for the student against a specific learning objective.';
COMMENT ON COLUMN edfi.StudentLearningObjective.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.StudentLearningObjective.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentLearningObjective.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.StudentLearningObjective.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.StudentLearningObjective.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.StudentLearningObjective.Namespace IS 'Namespace for the learning objective.';
COMMENT ON COLUMN edfi.StudentLearningObjective.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentLearningObjective.CompetencyLevelDescriptorId IS 'The competency level assessed for the student for the referenced learning objective.';
COMMENT ON COLUMN edfi.StudentLearningObjective.DiagnosticStatement IS 'A statement provided by the teacher that provides information in addition to the grade or assessment score.';

-- Extended Properties [edfi].[StudentLearningObjectiveGeneralStudentProgramAssociation] --
COMMENT ON TABLE edfi.StudentLearningObjectiveGeneralStudentProgramAssociation IS 'Relates the Student and Program associated with the LearningObjective.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.Namespace IS 'Namespace for the learning objective.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveGeneralStudentProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentLearningObjectiveStudentSectionAssociation] --
COMMENT ON TABLE edfi.StudentLearningObjectiveStudentSectionAssociation IS 'Relates the Student and Section associated with the LearningObjective.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.BeginDate IS 'Month, day, and year of the student''s entry or assignment to the section.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.GradingPeriodDescriptorId IS 'The name of the period for which grades are reported.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.GradingPeriodSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.GradingPeriodSchoolYear IS 'The identifier for the grading period school year.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.GradingPeriodSequence IS 'The sequential order of this period relative to other periods.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.LearningObjectiveId IS 'The identifier for the specific learning objective in the context of a standard (e.g., 111.15.3.1.A).';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.Namespace IS 'Namespace for the learning objective.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.StudentLearningObjectiveStudentSectionAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentMigrantEducationProgramAssociation] --
COMMENT ON TABLE edfi.StudentMigrantEducationProgramAssociation IS 'This association represents the migrant education program(s) that a student participates in or receives services from. The association is an extension of the StudentProgramAssociation with added elements particular to migrant education programs.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.PriorityForServices IS 'Report migratory children who are classified as having "priority for services" because they are failing, or most at risk of failing to meet the state''s challenging state academic content standards and challenging state student academic achievement standards, and their education has been interrupted during the regular school year.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.LastQualifyingMove IS 'Date the last qualifying move occurred; used to compute MEP status.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.ContinuationOfServicesReasonDescriptorId IS 'The "continuation of services" provision found in Section 1304(e) of the statute provides that (1) a child who ceases to be a migratory child during a school term shall be eligible for services until the end of such term; (2) a child who is no longer a migratory child may continue to receive services for one additional school year, but only if comparable services are not available through other programs; and (3) secondary school students who were eligible for services in secondary school may continue to be served through credit accrual programs until graduation. Only students who received services at any time during their 36 month eligibility period may continue to receive services (not necessarily the same service).';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.USInitialEntry IS 'The month, day, and year on which the student first entered the U.S.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.USMostRecentEntry IS 'The month, day, and year of the student''s most recent entry into the U.S.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.USInitialSchoolEntry IS 'The month, day, and year on which the student first entered a U.S. school.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.QualifyingArrivalDate IS 'The qualifying arrival date (QAD) is the date the child joins the worker who has already moved, or the date when the worker joins the child who has already moved. The QAD is the date that the child''s eligibility for the MEP begins. The QAD is not affected by subsequent non-qualifying moves.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.StateResidencyDate IS 'The verified state residency for the student.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociation.EligibilityExpirationDate IS 'The eligibility expiration date is used to determine end of eligibility and to account for a child''s eligibility expiring earlier than 36 months from the child''s QAD. A child''s eligibility would end earlier than 36 months from the child''s QAD, if the child is no longer entitled to a free public education (e.g., graduated with a high school diploma, obtained a high school equivalency diploma (HSED), or for other reasons as determined by states'' requirements), or if the child passes away.';

-- Extended Properties [edfi].[StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7] --
COMMENT ON TABLE edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7 IS 'Indicates the service(s) being provided to the student by the migrant education program.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.MigrantEducationProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the migrant education program.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentMigrantEducationProgramAssociationMigrantEducatio_d9dcd7.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentNeglectedOrDelinquentProgramAssociation] --
COMMENT ON TABLE edfi.StudentNeglectedOrDelinquentProgramAssociation IS 'This association represents the Title I Part D Neglected or Delinquent program(s) that a student participates in or from which the student receives services.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.NeglectedOrDelinquentProgramDescriptorId IS 'The type of program under ESEA Title I, Part D, Subpart 1 (state programs) or Subpart 2 (LEA).';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.ELAProgressLevelDescriptorId IS 'The progress measured from pre- to post- test for ELA.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociation.MathematicsProgressLevelDescriptorId IS 'The progress measured from pre- to post-test for Mathematics.';

-- Extended Properties [edfi].[StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251] --
COMMENT ON TABLE edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251 IS 'Indicates the service(s) being provided to the student by the neglected or delinquent program.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.NeglectedOrDelinquentProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the neglected or delinquent program.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentNeglectedOrDelinquentProgramAssociationNeglectedO_520251.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentOtherName] --
COMMENT ON TABLE edfi.StudentOtherName IS 'Other names (e.g., alias, nickname, previous legal name) associated with a person.';
COMMENT ON COLUMN edfi.StudentOtherName.OtherNameTypeDescriptorId IS 'The types of alternate names for an individual.';
COMMENT ON COLUMN edfi.StudentOtherName.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentOtherName.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the individual.';
COMMENT ON COLUMN edfi.StudentOtherName.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN edfi.StudentOtherName.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN edfi.StudentOtherName.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN edfi.StudentOtherName.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';

-- Extended Properties [edfi].[StudentParentAssociation] --
COMMENT ON TABLE edfi.StudentParentAssociation IS 'This association relates students to their parents, guardians, or caretakers.';
COMMENT ON COLUMN edfi.StudentParentAssociation.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.StudentParentAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentParentAssociation.RelationDescriptorId IS 'The nature of an individual''s relationship to a student, primarily used to capture family relationships.';
COMMENT ON COLUMN edfi.StudentParentAssociation.PrimaryContactStatus IS 'Indicator of whether the person is a primary parental contact for the student.';
COMMENT ON COLUMN edfi.StudentParentAssociation.LivesWith IS 'Indicator of whether the student lives with the associated parent.';
COMMENT ON COLUMN edfi.StudentParentAssociation.EmergencyContactStatus IS 'Indicator of whether the person is a designated emergency contact for the student.';
COMMENT ON COLUMN edfi.StudentParentAssociation.ContactPriority IS 'The numeric order of the preferred sequence or priority of contact.';
COMMENT ON COLUMN edfi.StudentParentAssociation.ContactRestrictions IS 'Restrictions for student and/or teacher contact with the individual (e.g., the student may not be picked up by the individual).';
COMMENT ON COLUMN edfi.StudentParentAssociation.LegalGuardian IS 'Indicator of whether the person is a legal guardian for the student.';

-- Extended Properties [edfi].[StudentParticipationCodeDescriptor] --
COMMENT ON TABLE edfi.StudentParticipationCodeDescriptor IS 'The role or type of participation of a student in a discipline incident; for example: Victim, Perpetrator, Witness, Reporter.';
COMMENT ON COLUMN edfi.StudentParticipationCodeDescriptor.StudentParticipationCodeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[StudentPersonalIdentificationDocument] --
COMMENT ON TABLE edfi.StudentPersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN edfi.StudentPersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN edfi.StudentPersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN edfi.StudentPersonalIdentificationDocument.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentPersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN edfi.StudentPersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN edfi.StudentPersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN edfi.StudentPersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN edfi.StudentPersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [edfi].[StudentProgramAssociation] --
COMMENT ON TABLE edfi.StudentProgramAssociation IS 'This association represents the program(s) that a student participates in or is served by.';
COMMENT ON COLUMN edfi.StudentProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentProgramAssociationService] --
COMMENT ON TABLE edfi.StudentProgramAssociationService IS 'Indicates the service(s) being provided to the student by the program.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.ServiceDescriptorId IS 'Indicates the service being provided to the student by the program.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentProgramAssociationService.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentProgramAttendanceEvent] --
COMMENT ON TABLE edfi.StudentProgramAttendanceEvent IS 'This event entity represents the recording of whether a student is in attendance to receive or participate in program services.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.AttendanceEventCategoryDescriptorId IS 'A code describing the attendance event, for example:
        Present
        Unexcused absence
        Excused absence
        Tardy.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.EventDate IS 'Date for this attendance event.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.AttendanceEventReason IS 'The reported reason for a student''s absence.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.EducationalEnvironmentDescriptorId IS 'The setting in which a child receives education and related services. This attribute is only used if it differs from the EducationalEnvironment of the Section. This is only used in the AttendanceEvent if different from the associated Section.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.EventDuration IS 'The amount of time for the event as recognized by the school: 1 day = 1, 1/2 day = 0.5, 1/3 day = 0.33.';
COMMENT ON COLUMN edfi.StudentProgramAttendanceEvent.ProgramAttendanceDuration IS 'The duration in minutes of the program attendance event.';

-- Extended Properties [edfi].[StudentSchoolAssociation] --
COMMENT ON TABLE edfi.StudentSchoolAssociation IS 'This association represents the school in which a student is enrolled. The semantics of enrollment may differ slightly by state. Non-enrollment relationships between a student and an education organization may be described using the StudentEducationOrganizationAssociation.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.EntryDate IS 'The month, day, and year on which an individual enters and begins to receive instructional services in a school.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.PrimarySchool IS 'Indicates if a given enrollment record should be considered the primary record for a student.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.EntryGradeLevelDescriptorId IS 'The grade level or primary instructional level at which a student enters and receives services in a school or an educational institution during a given academic session.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.EntryGradeLevelReasonDescriptorId IS 'The primary reason as to why a staff member determined that a student should be promoted or not (or be demoted) at the end of a given school term.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.EntryTypeDescriptorId IS 'The process by which a student enters a school during a given academic session.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.RepeatGradeIndicator IS 'An indicator of whether the student is enrolling to repeat a grade level, either by failure or an agreement to hold the student back.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.ClassOfSchoolYear IS 'Projected high school graduation year.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.SchoolChoiceTransfer IS 'An indication of whether students transferred in or out of the school did so during the school year under the provisions for public school choice in accordance with Title I, Part A, Section 1116.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.ExitWithdrawDate IS 'The recorded exit or withdraw date for the student.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.ExitWithdrawTypeDescriptorId IS 'The circumstances under which the student exited from membership in an educational institution.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.ResidencyStatusDescriptorId IS 'An indication of the location of a persons legal residence relative to (within or outside of) the boundaries of the public school attended and its administrative unit.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.EmployedWhileEnrolled IS 'An individual who is a paid employee or works in his or her own business, profession, or farm and at the same time is enrolled in secondary, postsecondary, or adult education.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.CalendarCode IS 'The identifier for the calendar.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.SchoolYear IS 'The school year associated with the student''s enrollment.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.FullTimeEquivalency IS 'The full-time equivalent ratio for the student’s assignment to a school for services or instruction. For example, a full-time student would have an FTE value of 1 while a half-time student would have an FTE value of 0.5.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.TermCompletionIndicator IS 'Idicates whether or not a student completed the most recent school term.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.NextYearSchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.NextYearGradeLevelDescriptorId IS 'The anticipated grade level for the student for the next school year.';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.SchoolChoice IS 'An indication of whether the student enrolled in this school under the provisions for public school choice';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.SchoolChoiceBasisDescriptorId IS 'The legal basis for the school choice enrollment according to local, state or federal policy or regulation. (The descriptor provides the list of available bases specific to the state';
COMMENT ON COLUMN edfi.StudentSchoolAssociation.EnrollmentTypeDescriptorId IS 'The type of enrollment reflected by the StudentSchoolAssociation.';

-- Extended Properties [edfi].[StudentSchoolAssociationAlternativeGraduationPlan] --
COMMENT ON TABLE edfi.StudentSchoolAssociationAlternativeGraduationPlan IS 'The secondary graduation plan or plans associated with the student enrolled in the school.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationAlternativeGraduationPlan.AlternativeEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationAlternativeGraduationPlan.AlternativeGraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationAlternativeGraduationPlan.AlternativeGraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationAlternativeGraduationPlan.EntryDate IS 'The month, day, and year on which an individual enters and begins to receive instructional services in a school.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationAlternativeGraduationPlan.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationAlternativeGraduationPlan.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentSchoolAssociationEducationPlan] --
COMMENT ON TABLE edfi.StudentSchoolAssociationEducationPlan IS 'The type of education plan(s) the student is following, if appropriate.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationEducationPlan.EducationPlanDescriptorId IS 'The type of education plan(s) the student is following, if appropriate.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationEducationPlan.EntryDate IS 'The month, day, and year on which an individual enters and begins to receive instructional services in a school.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationEducationPlan.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentSchoolAssociationEducationPlan.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentSchoolAttendanceEvent] --
COMMENT ON TABLE edfi.StudentSchoolAttendanceEvent IS 'This event entity represents the recording of whether a student is in attendance for a school day.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.AttendanceEventCategoryDescriptorId IS 'A code describing the attendance event, for example:
        Present
        Unexcused absence
        Excused absence
        Tardy.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.EventDate IS 'Date for this attendance event.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.AttendanceEventReason IS 'The reported reason for a student''s absence.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.EducationalEnvironmentDescriptorId IS 'The setting in which a child receives education and related services. This attribute is only used if it differs from the EducationalEnvironment of the Section. This is only used in the AttendanceEvent if different from the associated Section.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.EventDuration IS 'The amount of time for the event as recognized by the school: 1 day = 1, 1/2 day = 0.5, 1/3 day = 0.33.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.SchoolAttendanceDuration IS 'The duration in minutes of the school attendance event.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.ArrivalTime IS 'The time of day the student arrived for the attendance event in ISO 8601 format.';
COMMENT ON COLUMN edfi.StudentSchoolAttendanceEvent.DepartureTime IS 'The time of day the student departed for the attendance event in ISO 8601 format.';

-- Extended Properties [edfi].[StudentSchoolFoodServiceProgramAssociation] --
COMMENT ON TABLE edfi.StudentSchoolFoodServiceProgramAssociation IS 'This association represents the school food services program(s), such as the Free or Reduced Lunch program, that a student participates in or from which the student receives services.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociation.DirectCertification IS 'Indicates that the student''s National School Lunch Program (NSLP) eligibility has been determined through direct certification.';

-- Extended Properties [edfi].[StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb] --
COMMENT ON TABLE edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb IS 'Indicates the service(s) being provided to the student by the school food service program.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.SchoolFoodServiceProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the school food service program.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServ_85a0eb.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentSectionAssociation] --
COMMENT ON TABLE edfi.StudentSectionAssociation IS 'This association indicates the course sections to which a student is assigned.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.BeginDate IS 'Month, day, and year of the student''s entry or assignment to the section.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.EndDate IS 'Month, day, and year of the withdrawal or exit of the student from the section.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.HomeroomIndicator IS 'Indicates the section is the student''s homeroom. Homeroom period may the convention for taking daily attendance.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.RepeatIdentifierDescriptorId IS 'An indication as to whether a student has previously taken a given course.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.TeacherStudentDataLinkExclusion IS 'Indicates that the student-section combination is excluded from calculation of value-added or growth attribution calculations used for a particular teacher evaluation.';
COMMENT ON COLUMN edfi.StudentSectionAssociation.AttemptStatusDescriptorId IS 'An indication of the student''s completion status for the section.';

-- Extended Properties [edfi].[StudentSectionAttendanceEvent] --
COMMENT ON TABLE edfi.StudentSectionAttendanceEvent IS 'This event entity represents the recording of whether a student is in attendance for a section.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.AttendanceEventCategoryDescriptorId IS 'A code describing the attendance event, for example:
        Present
        Unexcused absence
        Excused absence
        Tardy.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.EventDate IS 'Date for this attendance event.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.AttendanceEventReason IS 'The reported reason for a student''s absence.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.EducationalEnvironmentDescriptorId IS 'The setting in which a child receives education and related services. This attribute is only used if it differs from the EducationalEnvironment of the Section. This is only used in the AttendanceEvent if different from the associated Section.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.EventDuration IS 'The amount of time for the event as recognized by the school: 1 day = 1, 1/2 day = 0.5, 1/3 day = 0.33.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.SectionAttendanceDuration IS 'The duration in minutes of the section attendance event.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.ArrivalTime IS 'The time of day the student arrived for the attendance event in ISO 8601 format.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEvent.DepartureTime IS 'The time of day the student departed for the attendance event in ISO 8601 format.';

-- Extended Properties [edfi].[StudentSectionAttendanceEventClassPeriod] --
COMMENT ON TABLE edfi.StudentSectionAttendanceEventClassPeriod IS 'The class period(s) to which the section attendance event applies.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.AttendanceEventCategoryDescriptorId IS 'A code describing the attendance event, for example:
        Present
        Unexcused absence
        Excused absence
        Tardy.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.ClassPeriodName IS 'An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.EventDate IS 'Date for this attendance event.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.StudentSectionAttendanceEventClassPeriod.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentSpecialEducationProgramAssociation] --
COMMENT ON TABLE edfi.StudentSpecialEducationProgramAssociation IS 'This association represents the special education program(s) that a student participates in or receives services from. The association is an extension of the StudentProgramAssociation particular for special education programs.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.IdeaEligibility IS 'Indicator of the eligibility of the student to receive special education services according to the Individuals with Disabilities Education Act (IDEA).';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.SpecialEducationSettingDescriptorId IS 'The major instructional setting (more than 50 percent of a student''s special education program).';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.SpecialEducationHoursPerWeek IS 'The number of hours per week for special education instruction and therapy.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.SchoolHoursPerWeek IS 'Indicate the total number of hours of instructional time per week for the school that the student attends.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.MultiplyDisabled IS 'Indicates whether the student receiving special education and related services has been designated as multiply disabled by the admission, review, and dismissal committee as aligned with federal requirements.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.MedicallyFragile IS 'Indicates whether the student receiving special education and related services is: 1) in the age range of birth to 22 years, and 2) has a serious, ongoing illness or a chronic condition that has lasted or is anticipated to last at least 12 or more months or has required at least one month of hospitalization, and that requires daily, ongoing medical treatments and monitoring by appropriately trained personnel which may include parents or other family members, and 3) requires the routine use of medical device or of assistive technology to compensate for the loss of usefulness of a body function needed to participate in activities of daily living, and 4) lives with ongoing threat to his or her continued well-being. Aligns with federal requirements.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.LastEvaluationDate IS 'The date of the last special education evaluation.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.IEPReviewDate IS 'The date of the last IEP review.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.IEPBeginDate IS 'The effective date of the most recent IEP.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociation.IEPEndDate IS 'The end date of the most recent IEP.';

-- Extended Properties [edfi].[StudentSpecialEducationProgramAssociationDisability] --
COMMENT ON TABLE edfi.StudentSpecialEducationProgramAssociationDisability IS 'The disability condition(s) that best describes an individual''s impairment, as related to special education services received.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.DisabilityDescriptorId IS 'A disability category that describes a individual''s impairment.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.OrderOfDisability IS 'The order by severity of individual''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [edfi].[StudentSpecialEducationProgramAssociationDisabilityDesignation] --
COMMENT ON TABLE edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a individual''s impairment.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationDisabilityDesignation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] --
COMMENT ON TABLE edfi.StudentSpecialEducationProgramAssociationServiceProvider IS 'The staff providing special education services to the student.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationServiceProvider.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationServiceProvider.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationServiceProvider.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationServiceProvider.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationServiceProvider.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationServiceProvider.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationServiceProvider.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationServiceProvider.PrimaryProvider IS 'Primary ServiceProvider.';

-- Extended Properties [edfi].[StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9] --
COMMENT ON TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9 IS 'Indicates the service(s) being provided to the student by the special education program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.SpecialEducationProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the special education program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_a51ff9.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c] --
COMMENT ON TABLE edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c IS 'The staff providing the service to the student.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.SpecialEducationProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the special education program.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentSpecialEducationProgramAssociationSpecialEducatio_bcba5c.PrimaryProvider IS 'Primary ServiceProvider.';

-- Extended Properties [edfi].[StudentTitleIPartAProgramAssociation] --
COMMENT ON TABLE edfi.StudentTitleIPartAProgramAssociation IS 'This association represents the Title I Part A program(s) that a student participates in or from which the student receives services. The association is an extension of the StudentProgramAssociation particular for Title I Part A programs.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociation.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociation.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociation.TitleIPartAParticipantDescriptorId IS 'An indication of the type of Title I program, if any, in which the student is participating and by which the student is served.';

-- Extended Properties [edfi].[StudentTitleIPartAProgramAssociationService] --
COMMENT ON TABLE edfi.StudentTitleIPartAProgramAssociationService IS 'Indicates the service(s) being provided to the student by the program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.ServiceDescriptorId IS 'Indicates the service being provided to the student by the program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.ServiceBeginDate IS 'First date the student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationService.ServiceEndDate IS 'Last date the student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentTitleIPartAProgramAssociationTitleIPartAProgramService] --
COMMENT ON TABLE edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService IS 'Indicates the service(s) being provided to the student by the Title I Part A program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.BeginDate IS 'The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.ProgramEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.TitleIPartAProgramServiceDescriptorId IS 'Indicates the service being provided to the student by the Title I Part A Program.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.PrimaryIndicator IS 'True if service is a primary service.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.ServiceBeginDate IS 'First date the Student was in this option for the current school year.';
COMMENT ON COLUMN edfi.StudentTitleIPartAProgramAssociationTitleIPartAProgramService.ServiceEndDate IS 'Last date the Student was in this option for the current school year.';

-- Extended Properties [edfi].[StudentVisa] --
COMMENT ON TABLE edfi.StudentVisa IS 'An indicator of a non-US citizen''s Visa type.';
COMMENT ON COLUMN edfi.StudentVisa.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.StudentVisa.VisaDescriptorId IS 'An indicator of a non-US citizen''s Visa type.';

-- Extended Properties [edfi].[SubmissionStatusDescriptor] --
COMMENT ON TABLE edfi.SubmissionStatusDescriptor IS 'The status of the student''s submission.';
COMMENT ON COLUMN edfi.SubmissionStatusDescriptor.SubmissionStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[Survey] --
COMMENT ON TABLE edfi.Survey IS 'A survey to identified or anonymous respondents.';
COMMENT ON COLUMN edfi.Survey.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.Survey.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.Survey.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.Survey.SurveyTitle IS 'The title of the survey.';
COMMENT ON COLUMN edfi.Survey.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.Survey.SchoolYear IS 'The school year associated with the survey.';
COMMENT ON COLUMN edfi.Survey.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.Survey.SurveyCategoryDescriptorId IS 'The category or type of survey.';
COMMENT ON COLUMN edfi.Survey.NumberAdministered IS 'Number of persons to whom this survey was administered.';

-- Extended Properties [edfi].[SurveyCategoryDescriptor] --
COMMENT ON TABLE edfi.SurveyCategoryDescriptor IS 'The descriptor holds the category or type of survey.';
COMMENT ON COLUMN edfi.SurveyCategoryDescriptor.SurveyCategoryDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SurveyCourseAssociation] --
COMMENT ON TABLE edfi.SurveyCourseAssociation IS 'The course associated with the survey.';
COMMENT ON COLUMN edfi.SurveyCourseAssociation.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN edfi.SurveyCourseAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.SurveyCourseAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyCourseAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';

-- Extended Properties [edfi].[SurveyLevelDescriptor] --
COMMENT ON TABLE edfi.SurveyLevelDescriptor IS 'Provides information about the respondents of a survey and how they can be grouped together.';
COMMENT ON COLUMN edfi.SurveyLevelDescriptor.SurveyLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[SurveyProgramAssociation] --
COMMENT ON TABLE edfi.SurveyProgramAssociation IS 'The program associated with the survey.';
COMMENT ON COLUMN edfi.SurveyProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.SurveyProgramAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyProgramAssociation.ProgramName IS 'The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.';
COMMENT ON COLUMN edfi.SurveyProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN edfi.SurveyProgramAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';

-- Extended Properties [edfi].[SurveyQuestion] --
COMMENT ON TABLE edfi.SurveyQuestion IS 'The questions for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestion.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestion.QuestionCode IS 'The identifying code for the question, unique for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestion.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyQuestion.QuestionFormDescriptorId IS 'The form or type of question.';
COMMENT ON COLUMN edfi.SurveyQuestion.QuestionText IS 'The text of the question.';
COMMENT ON COLUMN edfi.SurveyQuestion.SurveySectionTitle IS 'The title or label for the survey section.';

-- Extended Properties [edfi].[SurveyQuestionMatrix] --
COMMENT ON TABLE edfi.SurveyQuestionMatrix IS 'Information about the matrix element in the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionMatrix.MatrixElement IS 'For matrix questions, the text identifying each row of the matrix.';
COMMENT ON COLUMN edfi.SurveyQuestionMatrix.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionMatrix.QuestionCode IS 'The identifying code for the question, unique for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionMatrix.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyQuestionMatrix.MinRawScore IS 'The minimum score possible on a survey.';
COMMENT ON COLUMN edfi.SurveyQuestionMatrix.MaxRawScore IS 'The maximum score possible on a survey.';

-- Extended Properties [edfi].[SurveyQuestionResponse] --
COMMENT ON TABLE edfi.SurveyQuestionResponse IS 'The response to a survey question.';
COMMENT ON COLUMN edfi.SurveyQuestionResponse.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionResponse.QuestionCode IS 'The identifying code for the question, unique for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionResponse.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyQuestionResponse.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN edfi.SurveyQuestionResponse.NoResponse IS 'Indicates there was no response to the question.';
COMMENT ON COLUMN edfi.SurveyQuestionResponse.Comment IS 'Additional information provided by the responder about the question in the survey.';

-- Extended Properties [edfi].[SurveyQuestionResponseChoice] --
COMMENT ON TABLE edfi.SurveyQuestionResponseChoice IS 'The optional list of possible responses to a survey question.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseChoice.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseChoice.QuestionCode IS 'The identifying code for the question, unique for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseChoice.SortOrder IS 'Sort order of this ResponseChoice within the complete list of choices attached to a SurveyQuestion. If sort order doesn''t apply, the value of NumericValue or a unique, possibly sequential numeric value.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseChoice.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseChoice.NumericValue IS 'A valid numeric response. If paired with a TextValue, the numeric equivalent of the TextValue.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseChoice.TextValue IS 'A valid text response. If paired with a NumericValue, the text equivalent of the NumericValue.';

-- Extended Properties [edfi].[SurveyQuestionResponseSurveyQuestionMatrixElementResponse] --
COMMENT ON TABLE edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse IS 'For matrix questions, the response for each row of the matrix.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.MatrixElement IS 'For matrix questions, the text identifying each row of the matrix.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.QuestionCode IS 'The identifying code for the question, unique for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.NumericResponse IS 'The numeric response to the question.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.TextResponse IS 'The text response(s) for the question.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.NoResponse IS 'Indicates there was no response to the question.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.MinNumericResponse IS 'The minimum score response to the question.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse.MaxNumericResponse IS 'The maximum score response to the question.';

-- Extended Properties [edfi].[SurveyQuestionResponseValue] --
COMMENT ON TABLE edfi.SurveyQuestionResponseValue IS 'For free-form, single- or multiple-selection questions, one or more responses.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseValue.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseValue.QuestionCode IS 'The identifying code for the question, unique for the survey.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseValue.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseValue.SurveyQuestionResponseValueIdentifier IS 'Primary key for the response value; a unique, usually sequential numeric value for a collection of responses, or potentially the value of NumericResponse for a single response.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseValue.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseValue.NumericResponse IS 'A numeric response to the question.';
COMMENT ON COLUMN edfi.SurveyQuestionResponseValue.TextResponse IS 'A text response to the question.';

-- Extended Properties [edfi].[SurveyResponse] --
COMMENT ON TABLE edfi.SurveyResponse IS 'Responses to a Survey for named or anonymous persons.';
COMMENT ON COLUMN edfi.SurveyResponse.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyResponse.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyResponse.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN edfi.SurveyResponse.ResponseDate IS 'Date of the survey response.';
COMMENT ON COLUMN edfi.SurveyResponse.ResponseTime IS 'The amount of time (in seconds) it took for the respondent to complete the survey.';
COMMENT ON COLUMN edfi.SurveyResponse.ElectronicMailAddress IS 'Email address of the respondent.';
COMMENT ON COLUMN edfi.SurveyResponse.FullName IS 'Full name of the respondent.';
COMMENT ON COLUMN edfi.SurveyResponse.Location IS 'Location of the respondent, often a city, district, or school.';
COMMENT ON COLUMN edfi.SurveyResponse.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN edfi.SurveyResponse.ParentUSI IS 'A unique alphanumeric code assigned to a parent.';
COMMENT ON COLUMN edfi.SurveyResponse.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [edfi].[SurveyResponseEducationOrganizationTargetAssociation] --
COMMENT ON TABLE edfi.SurveyResponseEducationOrganizationTargetAssociation IS 'This association provides information about the survey being taken and the education organization the survey is about.';
COMMENT ON COLUMN edfi.SurveyResponseEducationOrganizationTargetAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.SurveyResponseEducationOrganizationTargetAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyResponseEducationOrganizationTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyResponseEducationOrganizationTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';

-- Extended Properties [edfi].[SurveyResponseStaffTargetAssociation] --
COMMENT ON TABLE edfi.SurveyResponseStaffTargetAssociation IS 'The association provides information about the survey being taken and who the survey is about.';
COMMENT ON COLUMN edfi.SurveyResponseStaffTargetAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyResponseStaffTargetAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.SurveyResponseStaffTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyResponseStaffTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';

-- Extended Properties [edfi].[SurveyResponseSurveyLevel] --
COMMENT ON TABLE edfi.SurveyResponseSurveyLevel IS 'Provides information about the respondents of a survey and how they can be grouped together.';
COMMENT ON COLUMN edfi.SurveyResponseSurveyLevel.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveyResponseSurveyLevel.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveyResponseSurveyLevel.SurveyLevelDescriptorId IS 'Provides information about the respondents of a survey and how they can be grouped together.';
COMMENT ON COLUMN edfi.SurveyResponseSurveyLevel.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';

-- Extended Properties [edfi].[SurveySection] --
COMMENT ON TABLE edfi.SurveySection IS 'The section of questions for the survey.';
COMMENT ON COLUMN edfi.SurveySection.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveySection.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveySection.SurveySectionTitle IS 'The title or label for the survey section.';

-- Extended Properties [edfi].[SurveySectionAssociation] --
COMMENT ON TABLE edfi.SurveySectionAssociation IS 'The section associated with the survey.';
COMMENT ON COLUMN edfi.SurveySectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN edfi.SurveySectionAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveySectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN edfi.SurveySectionAssociation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN edfi.SurveySectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN edfi.SurveySectionAssociation.SessionName IS 'The identifier for the calendar for the academic session.';
COMMENT ON COLUMN edfi.SurveySectionAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';

-- Extended Properties [edfi].[SurveySectionResponse] --
COMMENT ON TABLE edfi.SurveySectionResponse IS 'Optional information about the responses provided for a section of a survey.';
COMMENT ON COLUMN edfi.SurveySectionResponse.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveySectionResponse.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveySectionResponse.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN edfi.SurveySectionResponse.SurveySectionTitle IS 'The title or label for the survey section.';
COMMENT ON COLUMN edfi.SurveySectionResponse.SectionRating IS 'Numeric rating computed from the survey responses for the section.';

-- Extended Properties [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] --
COMMENT ON TABLE edfi.SurveySectionResponseEducationOrganizationTargetAssociation IS 'This association provides information about the survey section and the education organization the survey section is about.';
COMMENT ON COLUMN edfi.SurveySectionResponseEducationOrganizationTargetAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN edfi.SurveySectionResponseEducationOrganizationTargetAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveySectionResponseEducationOrganizationTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveySectionResponseEducationOrganizationTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN edfi.SurveySectionResponseEducationOrganizationTargetAssociation.SurveySectionTitle IS 'The title or label for the survey section.';

-- Extended Properties [edfi].[SurveySectionResponseStaffTargetAssociation] --
COMMENT ON TABLE edfi.SurveySectionResponseStaffTargetAssociation IS 'This association provides information about the survey section and the staff the survey section is about.';
COMMENT ON COLUMN edfi.SurveySectionResponseStaffTargetAssociation.Namespace IS 'Namespace for the survey.';
COMMENT ON COLUMN edfi.SurveySectionResponseStaffTargetAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN edfi.SurveySectionResponseStaffTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN edfi.SurveySectionResponseStaffTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN edfi.SurveySectionResponseStaffTargetAssociation.SurveySectionTitle IS 'The title or label for the survey section.';

-- Extended Properties [edfi].[TeachingCredentialBasisDescriptor] --
COMMENT ON TABLE edfi.TeachingCredentialBasisDescriptor IS 'An indication of the pre-determined criteria for granting the teaching credential that an individual holds.';
COMMENT ON COLUMN edfi.TeachingCredentialBasisDescriptor.TeachingCredentialBasisDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[TeachingCredentialDescriptor] --
COMMENT ON TABLE edfi.TeachingCredentialDescriptor IS 'This descriptor defines an indication of the category of a legal document giving authorization to perform teaching assignment services.';
COMMENT ON COLUMN edfi.TeachingCredentialDescriptor.TeachingCredentialDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[TechnicalSkillsAssessmentDescriptor] --
COMMENT ON TABLE edfi.TechnicalSkillsAssessmentDescriptor IS 'This descriptor defines the results of technical skills assessment aligned with industry recognized standards.';
COMMENT ON COLUMN edfi.TechnicalSkillsAssessmentDescriptor.TechnicalSkillsAssessmentDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[TelephoneNumberTypeDescriptor] --
COMMENT ON TABLE edfi.TelephoneNumberTypeDescriptor IS 'The type of communication number listed for an individual.';
COMMENT ON COLUMN edfi.TelephoneNumberTypeDescriptor.TelephoneNumberTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[TermDescriptor] --
COMMENT ON TABLE edfi.TermDescriptor IS 'This descriptor defines the term of a session during the school year (e.g., Semester).';
COMMENT ON COLUMN edfi.TermDescriptor.TermDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[TitleIPartAParticipantDescriptor] --
COMMENT ON TABLE edfi.TitleIPartAParticipantDescriptor IS 'An indication of the type of Title I program, if any, in which the student is participating and served.';
COMMENT ON COLUMN edfi.TitleIPartAParticipantDescriptor.TitleIPartAParticipantDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[TitleIPartAProgramServiceDescriptor] --
COMMENT ON TABLE edfi.TitleIPartAProgramServiceDescriptor IS 'This descriptor defines the services provided by an education organization to populations of students associated with a Title I Part A program.';
COMMENT ON COLUMN edfi.TitleIPartAProgramServiceDescriptor.TitleIPartAProgramServiceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[TitleIPartASchoolDesignationDescriptor] --
COMMENT ON TABLE edfi.TitleIPartASchoolDesignationDescriptor IS 'Denotes the Title I Part A designation for the school.';
COMMENT ON COLUMN edfi.TitleIPartASchoolDesignationDescriptor.TitleIPartASchoolDesignationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[TribalAffiliationDescriptor] --
COMMENT ON TABLE edfi.TribalAffiliationDescriptor IS 'An American Indian tribe with which an individual is affiliated.';
COMMENT ON COLUMN edfi.TribalAffiliationDescriptor.TribalAffiliationDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[VisaDescriptor] --
COMMENT ON TABLE edfi.VisaDescriptor IS 'An indicator of a non-U.S. citizen''s Visa type.';
COMMENT ON COLUMN edfi.VisaDescriptor.VisaDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [edfi].[WeaponDescriptor] --
COMMENT ON TABLE edfi.WeaponDescriptor IS 'This descriptor defines the types of weapon used during an incident.';
COMMENT ON COLUMN edfi.WeaponDescriptor.WeaponDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

