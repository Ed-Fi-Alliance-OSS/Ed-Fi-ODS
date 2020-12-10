-- Extended Properties [tpdm].[AccreditationStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Accreditation Status for a Teacher Preparation Provider.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AccreditationStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AccreditationStatusDescriptor', @level2type=N'COLUMN', @level2name=N'AccreditationStatusDescriptorId'
GO

-- Extended Properties [tpdm].[AidTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the classification of financial aid awarded to a person for the academic term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AidTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AidTypeDescriptor', @level2type=N'COLUMN', @level2name=N'AidTypeDescriptorId'
GO

-- Extended Properties [tpdm].[AnonymizedStudent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Domain entity to collect data for indiviudal students with whom the teacher candidate is associated through field work or student teaching', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Domain entity to collect data for indiviudal students with whom the teacher candidate is associated through field work or student teaching', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'ValueTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'SexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'HispanicLatinoEthnicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade level for the student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the students who are enrolled in a 504 program', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'Section504Enrollment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data about the ELL enrollment of the student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'ELLEnrollment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data about the ESL enrollment of the student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'ESLEnrollment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data about the enrollment in SPED of the student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'SPEDEnrollment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data about the enrollment in Title I of the student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'TitleIEnrollment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator that identifies if the student has been flagged as being at risk according to the District''s definition of at risk.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'AtriskIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of times a student has moved schools during the current school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudent', @level2type=N'COLUMN', @level2name=N'Mobility'
GO

-- Extended Properties [tpdm].[AnonymizedStudentAcademicRecord] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic record for an anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of grade points an individual earned for this session.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionGradePointAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average cumulative grade point average for a student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeGradePointAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum grade point average that can be achieved by a student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'GPAMax'
GO

-- Extended Properties [tpdm].[AnonymizedStudentAssessment] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents the analysis or scoring of a Student''s response on an assessment. The analysis results in a value that represents a Student''s performance on a set of items on a test.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date the assessment was administered', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'AdministrationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier that uniquely identifies the assessment to which the student results are associated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'AssessmentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the assessment was taken', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'TakenSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term in which the assessment was administered', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title if any specific assessment given to a group', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'AssessmentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of an assessment based on format and content. For example: Achievement test Advanced placement test Alternate assessment/grade-level standards Attitudinal test Cognitive and perceptual skills test ...', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'AssessmentCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject associated with a student assessment', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grade level for which effectiveness is measured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessment', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO

-- Extended Properties [tpdm].[AnonymizedStudentAssessmentCourseAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The course associated with aggregated student data.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date the assessment was administered', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation', @level2type=N'COLUMN', @level2name=N'AdministrationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier that uniquely identifies the assessment to which the student results are associated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation', @level2type=N'COLUMN', @level2name=N'AssessmentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation', @level2type=N'COLUMN', @level2name=N'CourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the assessment was taken', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentCourseAssociation', @level2type=N'COLUMN', @level2name=N'TakenSchoolYear'
GO

-- Extended Properties [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The performance level(s) achieved for the StudentAssessment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date the assessment was administered', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'AdministrationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier that uniquely identifies the assessment to which the student results are associated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'AssessmentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the assessment was taken', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'TakenSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the performance level was met.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'PerformanceLevelMet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which performance level value describes the student proficiency.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'PerformanceLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The method that the instructor of the class uses to report the performance and achievement. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or numerical grade. In some cases, more than one type of reporting method may be used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentPerformanceLevel', @level2type=N'COLUMN', @level2name=N'AssessmentReportingMethodDescriptorId'
GO

-- Extended Properties [tpdm].[AnonymizedStudentAssessmentScoreResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which performance level value describes the student proficiency.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date the assessment was administered', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'AdministrationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier that uniquely identifies the assessment to which the student results are associated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'AssessmentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the assessment was taken', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'TakenSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'Result'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentScoreResult', @level2type=N'COLUMN', @level2name=N'AssessmentReportingMethodDescriptorId'
GO

-- Extended Properties [tpdm].[AnonymizedStudentAssessmentSectionAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The course associated with aggregated student data.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date the assessment was administered', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'AdministrationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier that uniquely identifies the assessment to which the student results are associated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'AssessmentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the assessment was taken', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentAssessmentSectionAssociation', @level2type=N'COLUMN', @level2name=N'TakenSchoolYear'
GO

-- Extended Properties [tpdm].[AnonymizedStudentCourseAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the association between an anonymized student and the course they are enrolled in', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseAssociation', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseAssociation', @level2type=N'COLUMN', @level2name=N'CourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseAssociation', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[AnonymizedStudentCourseTranscript] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'CourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The final indicator of student performance in a class as submitted by the instructor.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'FinalLetterGradeEarned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The final indicator of student performance in a class as submitted by the instructor.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'FinalNumericGradeEarned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that an academic course has been repeated by a student and how that repeat is to be computed in the student''s academic grade average.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'CourseRepeatCodeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive name given to a course of study offered in a school or other institution or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentCourseTranscript', @level2type=N'COLUMN', @level2name=N'CourseTitle'
GO

-- Extended Properties [tpdm].[AnonymizedStudentDisability] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisability', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisability', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisability', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the disability diagnosis.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDiagnosis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisability', @level2type=N'COLUMN', @level2name=N'OrderOfDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source that provided the disability determination.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDeterminationSourceTypeDescriptorId'
GO

-- Extended Properties [tpdm].[AnonymizedStudentDisabilityDesignation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisabilityDesignation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDesignationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO

-- Extended Properties [tpdm].[AnonymizedStudentEducationOrganizationAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the association between an anonymized student and the Education Organziation they are enrolled in', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentEducationOrganizationAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[AnonymizedStudentLanguage] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The language(s) the individual uses to communicate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguage', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguage', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguage', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguage', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO

-- Extended Properties [tpdm].[AnonymizedStudentLanguageUse] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguageUse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguageUse', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguageUse', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentLanguageUse', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO

-- Extended Properties [tpdm].[AnonymizedStudentRace] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s
                   recognition of his or her community or with which the individual most
                   identifies. The data model allows for multiple entries so that each individual
                   can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentRace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentRace', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentRace', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s
                   recognition of his or her community or with which the individual most
                   identifies. The data model allows for multiple entries so that each individual
                   can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentRace', @level2type=N'COLUMN', @level2name=N'RaceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentRace', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO

-- Extended Properties [tpdm].[AnonymizedStudentSectionAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the association between an anonymized student and the Section they are enrolled in', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for anonymized student', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'AnonymizedStudentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'FactsAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AnonymizedStudentSectionAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[Applicant] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person who makes a formal application for an OpenStaffPosition.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s maiden name.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'MaidenName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'SexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'BirthDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'HispanicLatinoEthnicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of whether or not the person is a U.S. citizen.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'CitizenshipStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The login ID for the user; used for security access control interface.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'LoginId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'EconomicDisadvantaged'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether individual is a first generation college student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'FirstGenerationStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Applicant', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The apartment, room, or suite number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'ApartmentRoomSuiteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of the building on the site, if more than one building shares the same address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'BuildingSiteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'NameOfCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'CountyFIPSCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The congressional district in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'CongressionalDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddress', @level2type=N'COLUMN', @level2name=N'LocaleDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantAddressPeriod] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAddressPeriod', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[ApplicantAid] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents the financial aid a person is awarded.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The classification of financial aid awarded to a person for the academic term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAid', @level2type=N'COLUMN', @level2name=N'AidTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAid', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was designated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAid', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAid', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the condition (e.g., placement in a high need school) under which the aid was given.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAid', @level2type=N'COLUMN', @level2name=N'AidConditionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of financial aid awarded to a person for the term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAid', @level2type=N'COLUMN', @level2name=N'AidAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates a person who receives Pell Grant aid.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantAid', @level2type=N'COLUMN', @level2name=N'PellGrantRecipient'
GO

-- Extended Properties [tpdm].[ApplicantBackgroundCheck] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Applicant background check history and disposition.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantBackgroundCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantBackgroundCheck', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of background check (e.g., online, criminal, employment).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was requested.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckRequestedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckCompletedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person has or has not completed a fingerprint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantBackgroundCheck', @level2type=N'COLUMN', @level2name=N'Fingerprint'
GO

-- Extended Properties [tpdm].[ApplicantCharacteristic] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects important characteristics of the applicant''s home situation:
      Displaced Homemaker, Immigrant, Migratory, Military Parent, Pregnant Teen, Single Parent, and Unaccompanied Youth.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantCharacteristic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The characteristic designated for the Student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'StudentCharacteristicDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the characteristic was designated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the characteristic was removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person, organization, or department that designated the characteristic.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantCharacteristic', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO

-- Extended Properties [tpdm].[ApplicantDisability] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability condition(s) that best describes an individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisability', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the disability diagnosis.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDiagnosis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisability', @level2type=N'COLUMN', @level2name=N'OrderOfDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source that provided the disability determination.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDeterminationSourceTypeDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantDisabilityDesignation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisabilityDesignation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDesignationDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantElectronicMail] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantElectronicMail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantElectronicMail', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The electronic mail (e-mail) address listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantElectronicMail', @level2type=N'COLUMN', @level2name=N'ElectronicMailAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantElectronicMail', @level2type=N'COLUMN', @level2name=N'ElectronicMailTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantElectronicMail', @level2type=N'COLUMN', @level2name=N'PrimaryEmailAddressIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic email address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantElectronicMail', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[ApplicantIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Describe the documentation of citizenship.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantInternationalAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an international address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The second line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The third line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fourth line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'CountryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first date the address is valid. For physical addresses, the date the person moved to that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last date the address is valid. For physical addresses, this would be the date the person moved from that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantInternationalAddress', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[ApplicantLanguage] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The language(s) the individual uses to communicate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantLanguage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantLanguage', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantLanguage', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantLanguageUse] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantLanguageUse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantLanguageUse', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageUseDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantPersonalIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantProspectAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Associated previously identified prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProspectAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProspectAssociation', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProspectAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantProspectAssociation', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO

-- Extended Properties [tpdm].[ApplicantRace] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantRace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantRace', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantRace', @level2type=N'COLUMN', @level2name=N'RaceDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicantStaffIdentificationCode] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to an applicant by a school, school system, a state, or other agency or entity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantStaffIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantStaffIdentificationCode', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a staff member.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantStaffIdentificationCode', @level2type=N'COLUMN', @level2name=N'StaffIdentificationSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to a staff member by a school, school system, a state, or other agency or entity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantStaffIdentificationCode', @level2type=N'COLUMN', @level2name=N'IdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The organization code or name assigning the staff Identification Code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantStaffIdentificationCode', @level2type=N'COLUMN', @level2name=N'AssigningOrganizationIdentificationCode'
GO

-- Extended Properties [tpdm].[ApplicantTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The 10-digit telephone number, including the area code, for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantTelephone', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[ApplicantVisa] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of a non-US citizen''s Visa type.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantVisa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantVisa', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of a non-US citizen''s Visa type.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicantVisa', @level2type=N'COLUMN', @level2name=N'VisaDescriptorId'
GO

-- Extended Properties [tpdm].[Application] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An application for employment or contract.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year the application was submitted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the current status of the application (e.g., received, phone screen, interview, awaiting decision, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicationStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator as to whether the applicant is a current employee of the school district.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'CurrentEmployee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject for which the application is made.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of job acceptance, if offered.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'AcceptedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Specifies the source for the application (e.g., Job fair, website, referral).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'ApplicationSourceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date applicant was first contacted after submitting application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'FirstContactDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The high need academic subject for the application, if any.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HighNeedsAcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the current status of the application for hire (e.g., applied, recommended, rejected, exited, offered, hired).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HireStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source for the application (e.g.,job fair, website, referral, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HiringSourceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the application was withdrawn by the applicant.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'WithdrawDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reason applicant withdrew application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'WithdrawReasonDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The extent of formal instruction an individual has received (e.g., the highest grade in school completed or its equivalent or the highest degree received).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HighestCompletedLevelOfEducationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years that an individual has previously held a similar professional position in one or more education institutions.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'YearsOfPriorProfessionalExperience'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years that an individual has previously held a teaching position in one or more education institutions.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'YearsOfPriorTeachingExperience'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HighlyQualifiedTeacher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject(s) in which the staff is deemed to be "highly qualified".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Application', @level2type=N'COLUMN', @level2name=N'HighlyQualifiedAcademicSubjectDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The life cycle events associated with an application (phone screen, review, interview, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of application event (e.g., added to pool, phone screen, interview, sample lesson).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicationEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the application event, or begin date if an interval.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sequence number of the application events. This is used to discriminate between mutiple events of the same type in the same day.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'SequenceNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date of the event, if an interval.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'EventEndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application evaluation score, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicationEvaluationScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The recommendation, result or conclusion of the application event (e.g., Continue, exit, recommend for hire).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'ApplicationEventResultDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier for a school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the term of a session during the school year (e.g., Fall Semester).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEvent', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationEventResultDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the recommendation, result or conclusion of the application event (e.g., Continue, exit, recommend for hire).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEventResultDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEventResultDescriptor', @level2type=N'COLUMN', @level2name=N'ApplicationEventResultDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the description of application event (e.g., added to pool, phone screen, interview, sample lesson).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'ApplicationEventTypeDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationGradePointAverage] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data that provides information on a measure of average performance in a group of courses taken by an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationGradePointAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationGradePointAverage', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationGradePointAverage', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationGradePointAverage', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The system used for calculating the grade point average for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationGradePointAverage', @level2type=N'COLUMN', @level2name=N'GradePointAverageTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether or not the Grade Point Average value is cumulative.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationGradePointAverage', @level2type=N'COLUMN', @level2name=N'IsCumulative'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the grade points earned divided by the number of credits attempted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationGradePointAverage', @level2type=N'COLUMN', @level2name=N'GradePointAverageValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum value for the grade point average.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationGradePointAverage', @level2type=N'COLUMN', @level2name=N'MaxGradePointAverageValue'
GO

-- Extended Properties [tpdm].[ApplicationOpenStaffPosition] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The open staff position(s) associated with the application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationOpenStaffPosition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationOpenStaffPosition', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationOpenStaffPosition', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationOpenStaffPosition', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationOpenStaffPosition', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO

-- Extended Properties [tpdm].[ApplicationScoreResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A meaningful score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'AssessmentReportingMethodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'Result'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationScoreResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationSourceDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the source for the application (e.g., Job fair, website, referral).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationSourceDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationSourceDescriptor', @level2type=N'COLUMN', @level2name=N'ApplicationSourceDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the current status of the application (e.g., received, phone screen, interview, awaiting decision, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationStatusDescriptor', @level2type=N'COLUMN', @level2name=N'ApplicationStatusDescriptorId'
GO

-- Extended Properties [tpdm].[ApplicationTerm] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The intended term of enrollment for which the application is being submitted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm', @level2type=N'COLUMN', @level2name=N'ApplicationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The intended term of enrollment for which the application is being submitted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ApplicationTerm', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[AssessmentExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AssessmentExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to an assessment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AssessmentExtension', @level2type=N'COLUMN', @level2name=N'AssessmentIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Assessment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AssessmentExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway an assessment may be associated with for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'AssessmentExtension', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO

-- Extended Properties [tpdm].[BackgroundCheckStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor holds the  status of the background check (e.g., pending, under investigation, offense(s) found, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'BackgroundCheckStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'BackgroundCheckStatusDescriptor', @level2type=N'COLUMN', @level2name=N'BackgroundCheckStatusDescriptorId'
GO

-- Extended Properties [tpdm].[BackgroundCheckTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the classification of the background check a person receives.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'BackgroundCheckTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'BackgroundCheckTypeDescriptor', @level2type=N'COLUMN', @level2name=N'BackgroundCheckTypeDescriptorId'
GO

-- Extended Properties [tpdm].[Certification] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An offering by an official granting authority of a certification or license that qualifies persons to perform specific job functions, such as full fill a teaching assignment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The level (e.g., Elementary, Secondary) or category (administrative, specialist) of the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The field of certification (e.g., Mathematics, Music).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationFieldDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The standard, law or policy defining the certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'CertificationStandardDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum level of degree, if any, required for Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'MinimumDegreeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The role authorized by the Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'EducatorRoleDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of students the Section is offered and tailored to; for example: Bilingual students, Remedial education students, Gifted and talented students, Career and Technical Education students, Special education students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'PopulationServedDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The setting authorized by the Certification in which a child receives education and related services; for example: Classroom, Virtual, Vocational.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'InstructionalSettingDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year, month and day on which the Certification is offered.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'EffectiveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the Certification offering is expected to end.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Certification', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[CertificationCertificationExam] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Certification Eams required for the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamNamespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationCertificationExam', @level2type=N'COLUMN', @level2name=N'Namespace'
GO

-- Extended Properties [tpdm].[CertificationExam] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An examination required by one or more Certifications.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type or category of Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'CertificationExamTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year, month and day on which the CertificationExam is offered.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'EffectiveDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the CertificationExam offering is expected to end.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExam', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[CertificationExamResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s result from taking a Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year, month and day on which the CertificationExam is taken.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the CertificationExam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of the person''s attempt for the Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'AttemptNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The score result for the Certification Exam attempt.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the person passed the Certification Exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamPassIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the Certification Exam attempt.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamResult', @level2type=N'COLUMN', @level2name=N'CertificationExamStatusDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationExamStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the exam.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamStatusDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationExamStatusDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationExamTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of certification exam that was taken.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationExamTypeDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationExamTypeDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationFieldDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The field of certification for the credential (e.g., Mathematics, Music).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationFieldDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationFieldDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationFieldDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade level(s) certified for teaching.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationGradeLevel', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade level(s) certified for teaching.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationGradeLevel', @level2type=N'COLUMN', @level2name=N'Namespace'
GO

-- Extended Properties [tpdm].[CertificationLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The level (e.g., Elementary, Secondary) or category (administrative, specialist) of the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationLevelDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationLevelDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationRoute] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program ,or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRoute'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRoute', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program ,or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRoute', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRoute', @level2type=N'COLUMN', @level2name=N'Namespace'
GO

-- Extended Properties [tpdm].[CertificationRouteDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program ,or pathway used to obtain a certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRouteDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationRouteDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO

-- Extended Properties [tpdm].[CertificationStandardDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The standard, law or policy defining the certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationStandardDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CertificationStandardDescriptor', @level2type=N'COLUMN', @level2name=N'CertificationStandardDescriptorId'
GO

-- Extended Properties [tpdm].[CompleterAsStaffAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This describes a teacher candidate who has completed a teacher prep program and is considered a completer who is now also employed as a staff member in a partnering K12 district.  This is the same person but may have two different identifiers, one as a (former) teacher candidate and one as an employed staff person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CompleterAsStaffAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CompleterAsStaffAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CompleterAsStaffAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO

-- Extended Properties [tpdm].[CoteachingStyleObservedDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A type of co-teaching observed as part of the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CoteachingStyleObservedDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CoteachingStyleObservedDescriptor', @level2type=N'COLUMN', @level2name=N'CoteachingStyleObservedDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An event associated with a person''s Credential (e.g, suspension, revocation, or renewal).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year, month and day of the Credential Event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'CredentialEventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of event associated with a person''s Credential (e.g, suspension, revocation, or renewal).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'CredentialEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'CredentialIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'StateOfIssueStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reason for the credential event, or any other descriptive text.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEvent', @level2type=N'COLUMN', @level2name=N'CredentialEventReason'
GO

-- Extended Properties [tpdm].[CredentialEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of event associated with a person''s Credential (e.g, suspension, revocation, or renewal).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'CredentialEventTypeDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'StateOfIssueStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the certification obtained by the educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CertificationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program, or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the credential was granted under the authority of a national Board Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'BoardCertificationIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The most recent status of the credential (e.g., active, suspended, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the credential status was effective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialExtension', @level2type=N'COLUMN', @level2name=N'CredentialStatusDate'
GO

-- Extended Properties [tpdm].[CredentialStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The most recent status of the credential (e.g., active, suspended, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStatusDescriptor', @level2type=N'COLUMN', @level2name=N'CredentialStatusDescriptorId'
GO

-- Extended Properties [tpdm].[CredentialStudentAcademicRecord] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reference to the person''s Student Academic Records for the school(s) with which the Credential is associated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the credential.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'CredentialIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'StateOfIssueStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'CredentialStudentAcademicRecord', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[DegreeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum level of degree, if any, required for Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'DegreeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'DegreeDescriptor', @level2type=N'COLUMN', @level2name=N'DegreeDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorPreparationProgram] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Educator Preparation Program is designed to prepare students to become licensed educators.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to a program by a school, school system, a state, or other agency or entity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'ProgramId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of educator prep program (e.g., college, alternative, TFA, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'EducatorPreparationProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current accreditation status of the Educator Preparation Program (e.g., active, pending, revoked,...).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgram', @level2type=N'COLUMN', @level2name=N'AccreditationStatusDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorPreparationProgramGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels served at the EPP Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels served at the EPP Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramGradeLevel', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorPreparationProgramTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of educator prep program (e.g., college, alternative, TFA, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorPreparationProgramTypeDescriptor', @level2type=N'COLUMN', @level2name=N'EducatorPreparationProgramTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EducatorRoleDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The role authorized by the Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorRoleDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EducatorRoleDescriptor', @level2type=N'COLUMN', @level2name=N'EducatorRoleDescriptorId'
GO

-- Extended Properties [tpdm].[EmploymentEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The event associated with hiring staff for employment (or contract).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the employment event (e.g., transfer, new hire, title change).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent', @level2type=N'COLUMN', @level2name=N'EmploymentEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was hired for a position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent', @level2type=N'COLUMN', @level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether this was an early hire.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent', @level2type=N'COLUMN', @level2name=N'EarlyHire'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether the hire was an internal or external person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent', @level2type=N'COLUMN', @level2name=N'InternalExternalHireDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether this was a mutual consent hire.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent', @level2type=N'COLUMN', @level2name=N'MutualConsent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether this was a restricted choice hire.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEvent', @level2type=N'COLUMN', @level2name=N'RestrictedChoice'
GO

-- Extended Properties [tpdm].[EmploymentEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of the employment event (e.g., transfer, new hire, title change).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'EmploymentEventTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EmploymentSeparationEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The separation event that triggered an end to an employment or contractual relationship.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationEvent', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Effective date of the separation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationEvent', @level2type=N'COLUMN', @level2name=N'EmploymentSeparationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationEvent', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of separation (e.g., termination, displacement, retirement, transfer, voluntary departure).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationEvent', @level2type=N'COLUMN', @level2name=N'EmploymentSeparationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the separation event was first entered or when notice was given.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationEvent', @level2type=N'COLUMN', @level2name=N'EmploymentSeparationEnteredDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reason(s) for the separation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationEvent', @level2type=N'COLUMN', @level2name=N'EmploymentSeparationReasonDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether a teacher is leaving a school but remaining within the district, or leaving the district entirely.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationEvent', @level2type=N'COLUMN', @level2name=N'RemainingInDistrict'
GO

-- Extended Properties [tpdm].[EmploymentSeparationReasonDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the reason(s) for the separation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationReasonDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationReasonDescriptor', @level2type=N'COLUMN', @level2name=N'EmploymentSeparationReasonDescriptorId'
GO

-- Extended Properties [tpdm].[EmploymentSeparationTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of separation (e.g., termination, displacement, retirement, transfer, voluntary departure).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EmploymentSeparationTypeDescriptor', @level2type=N'COLUMN', @level2name=N'EmploymentSeparationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EnglishLanguageExamDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EnglishLanguageExamDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EnglishLanguageExamDescriptor', @level2type=N'COLUMN', @level2name=N'EnglishLanguageExamDescriptorId'
GO

-- Extended Properties [tpdm].[Evaluation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An evaluation instrument appled to evaluate an educator.  The evaluation could be internally developed, or could be an industry recognized instrument such as TTESS or Marzano.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Evaluation', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
GO

-- Extended Properties [tpdm].[EvaluationElement] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The lowest-level Elements or criterion of performance being evaluated by rubric, quantitative measure, or aggregate survey response.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sort order of this Evaluation Element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'SortOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation element. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElement', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationElementRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The lowest-level rating for an Evaluation Element for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'EvaluationElementRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Area(s) identified for person to refine or improve as part of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'AreaOfRefinement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Area(s) identified for reinforcement or positive feedback as part of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'AreaOfReinforcement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feedback provided to the evaluated person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRating', @level2type=N'COLUMN', @level2name=N'Feedback'
GO

-- Extended Properties [tpdm].[EvaluationElementRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO

-- Extended Properties [tpdm].[EvaluationElementRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationElementRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationElementRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationElementRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationObjective] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A subcomponent of an Evaluation, a specific educator Objective or domain of performance that is being evaluated.  ', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sort order of this Evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'SortOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum summary numerical rating or score for the evaluation Objective. If omitted, assumed to be 0.0.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum summary numerical rating or score for the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation Objective (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjective', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationObjectiveRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating for the component Evaluation Objective for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'ObjectiveRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO

-- Extended Properties [tpdm].[EvaluationObjectiveRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO

-- Extended Properties [tpdm].[EvaluationObjectiveRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationObjectiveRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationPeriodDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationPeriodDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationPeriodDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The summary weighting for the Evaluation instrument for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRating', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO

-- Extended Properties [tpdm].[EvaluationRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO

-- Extended Properties [tpdm].[EvaluationRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRatingReviewer] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person(s) that conducted the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'ReviewerPersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'ReviewerSourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[EvaluationRatingReviewerReceivedTraining] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the person administering the performance meausre received training on how to conduct performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'ReceivedTrainingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
GO

-- Extended Properties [tpdm].[EvaluationTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'EvaluationTypeDescriptor', @level2type=N'COLUMN', @level2name=N'EvaluationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[FederalLocaleCodeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the federal locale code applicable to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FederalLocaleCodeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FederalLocaleCodeDescriptor', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO

-- Extended Properties [tpdm].[FieldworkExperience] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The information regarding a postsecondary instructional course in a particular field of study that typically involves a prescribed number or instruction periods or meetings for enrolled students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff first starts fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the fieldwork experience', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'FieldworkIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of fieldwork being executed by a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'FieldworkTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of hours completed during the fieldwork experience.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'HoursCompleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff ends fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the program gateway that is associated with continuation in a program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperience', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO

-- Extended Properties [tpdm].[FieldworkExperienceCoteaching] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The act of two teachers (teacher candidate and cooperating teacher) working together with groups of students; sharing the planning, organization, delivery, and assessment of instruction, as well as the physical space.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff first starts fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the fieldwork experience', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'FieldworkIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the teacher candidate first starts co-teaching.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'CoteachingBeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the teacher candidate stopped co-teaching.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceCoteaching', @level2type=N'COLUMN', @level2name=N'CoteachingEndDate'
GO

-- Extended Properties [tpdm].[FieldworkExperienceSchool] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school the field work experience is associated with', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSchool'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff first starts fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSchool', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the fieldwork experience', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSchool', @level2type=N'COLUMN', @level2name=N'FieldworkIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSchool', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSchool', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [tpdm].[FieldworkExperienceSectionAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The section the field work experience is associated with.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the staff first starts fieldwork.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the fieldwork experience', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'FieldworkIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkExperienceSectionAssociation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO

-- Extended Properties [tpdm].[FieldworkTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of fieldwork being executed by a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FieldworkTypeDescriptor', @level2type=N'COLUMN', @level2name=N'FieldworkTypeDescriptorId'
GO

-- Extended Properties [tpdm].[FundingSourceDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the funding source (e.g., federal, district).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FundingSourceDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'FundingSourceDescriptor', @level2type=N'COLUMN', @level2name=N'FundingSourceDescriptorId'
GO

-- Extended Properties [tpdm].[GenderDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with with a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GenderDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GenderDescriptor', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO

-- Extended Properties [tpdm].[Goal] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Goal for performance improvement assigned to an educator associated with an Evaluation Element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the goal was assigned.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'AssignmentDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the goal.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'GoalTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the goal (e.g., management, instruction).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'GoalTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the goal.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'GoalDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the goal is due or expected to be completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'DueDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator that the goal was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'CompletedIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the goal was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'CompletedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the goal or its completion to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Goal', @level2type=N'COLUMN', @level2name=N'Comments'
GO

-- Extended Properties [tpdm].[GoalTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the goal (e.g., management, instruction).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GoalTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GoalTypeDescriptor', @level2type=N'COLUMN', @level2name=N'GoalTypeDescriptorId'
GO

-- Extended Properties [tpdm].[GraduationPlanRequiredCertification] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or reference to the certifiation(s) required for graduation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the Certification required for Graduation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'CertificationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'GraduationPlanTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year the student is expected to graduate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'GraduationSchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier or serial number assigned to the Certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'CertificationIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Certification, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The process, program ,or pathway used to obtain certification.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'GraduationPlanRequiredCertification', @level2type=N'COLUMN', @level2name=N'CertificationRouteDescriptorId'
GO

-- Extended Properties [tpdm].[HireStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the current status of the application for hire (e.g., applied, recommended, rejected, exited, offered, hired).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'HireStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'HireStatusDescriptor', @level2type=N'COLUMN', @level2name=N'HireStatusDescriptorId'
GO

-- Extended Properties [tpdm].[HiringSourceDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the source for the application (e.g.,job fair, website, referral, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'HiringSourceDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'HiringSourceDescriptor', @level2type=N'COLUMN', @level2name=N'HiringSourceDescriptorId'
GO

-- Extended Properties [tpdm].[InstructionalSettingDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The setting authorized by the Certification in which a child receives education and related services; for example: Classroom, Virtual, Vocational.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'InstructionalSettingDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'InstructionalSettingDescriptor', @level2type=N'COLUMN', @level2name=N'InstructionalSettingDescriptorId'
GO

-- Extended Properties [tpdm].[InternalExternalHireDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether the hire was an internal or external person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'InternalExternalHireDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'InternalExternalHireDescriptor', @level2type=N'COLUMN', @level2name=N'InternalExternalHireDescriptorId'
GO

-- Extended Properties [tpdm].[LevelOfDegreeAwardedDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the level of degree awarded by the teacher prep program to the person (e.g., Certificate Only, Bachelor''s, Master''s, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LevelOfDegreeAwardedDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LevelOfDegreeAwardedDescriptor', @level2type=N'COLUMN', @level2name=N'LevelOfDegreeAwardedDescriptorId'
GO

-- Extended Properties [tpdm].[LocalEducationAgencyExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LocalEducationAgencyExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a local education agency.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LocalEducationAgencyExtension', @level2type=N'COLUMN', @level2name=N'LocalEducationAgencyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The federal locale code associated with an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'LocalEducationAgencyExtension', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO

-- Extended Properties [tpdm].[ObjectiveRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ObjectiveRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ObjectiveRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'ObjectiveRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[OpenStaffPositionEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects milestones like vacancy approved, vacancy posted, date onboarded, processing date, orientation date, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date of the open staff position event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects milestones like vacancy approved, vacancy posted, date onboarded, processing date, orientation date, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the status of the milestone (e.g., pending, completed, cancelled).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEvent', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionEventStatusDescriptorId'
GO

-- Extended Properties [tpdm].[OpenStaffPositionEventStatusDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the status of the milestone (e.g., pending, completed, cancelled).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEventStatusDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEventStatusDescriptor', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionEventStatusDescriptorId'
GO

-- Extended Properties [tpdm].[OpenStaffPositionEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the milestones like vacancy approved, vacancy posted, date onboarded. processing date, orientation date  etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionEventTypeDescriptorId'
GO

-- Extended Properties [tpdm].[OpenStaffPositionExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'RequisitionNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year for which the OpenStaffPosition is seeking to fill.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ratio between the hours of work expected in a position and the hours of work normally expected in a full-time position in the same setting.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'FullTimeEquivalency'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reason for the open staff position (e.g., new position, replacement, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionReasonDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the OpenStaffPosition is currently Active.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum salary or wage a person is paid before deductions (excluding differentials) but including annuities.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'MaxSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum salary or wage a person is paid before deductions (excluding differentials) but including annuities.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'MinSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The funding source for open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'FundingSourceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator as to whether the OpenStaffPosition is filling a high-need subject area designated as a teacher shortage that may be eligible for special grants, aid or compensation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'HighNeedAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to the position to be filled.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'PositionControlNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first term for the Session during the school year for which the OpenStaffPosition is seeking to fill.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Including salary, the fully loaded cost budgeted for this teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionExtension', @level2type=N'COLUMN', @level2name=N'TotalBudgeted'
GO

-- Extended Properties [tpdm].[OpenStaffPositionReasonDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the reason for the open staff position (e.g., new position, replacement, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionReasonDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'OpenStaffPositionReasonDescriptor', @level2type=N'COLUMN', @level2name=N'OpenStaffPositionReasonDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A performance evaluation of an educator, typically regularly scheduled and uniformly applied, comporsed of one or more Evaluations.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluation', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels involved with the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade levels involved with the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationGradeLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationProgramGateway] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway that may be associated for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway that may be associated for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationProgramGateway', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRating] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The summary rating for a Performance Evaluation across all Evaluation instruments for an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the performance evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of whether the performance evaluation was announced or not.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'Announced'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the performance evaluation to be captured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A type of co-teaching observed as part of the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'CoteachingStyleObservedDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual or estimated number of clock minutes during which the performance evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the performance evaluation was to be conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ScheduleDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of the the time at which the performance evaluation was conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRating', @level2type=N'COLUMN', @level2name=N'ActualTime'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive level(s) of ratings (cut scores) for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'EvaluationRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MinRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum numerical rating or score to achieve the evaluation rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevel', @level2type=N'COLUMN', @level2name=N'MaxRating'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved based upon the rating or score.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingResult] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerical summary rating or score for the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of Rating Result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'RatingResultTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingResult', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewer] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person(s) that conducted the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'ReviewerPersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewer', @level2type=N'COLUMN', @level2name=N'ReviewerSourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the person administering the performance meausre received training on how to conduct performance measures.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'ReceivedTrainingDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationRatingReviewerReceivedTraining', @level2type=N'COLUMN', @level2name=N'InterRaterReliabilityScore'
GO

-- Extended Properties [tpdm].[PerformanceEvaluationTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PerformanceEvaluationTypeDescriptor', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO

-- Extended Properties [tpdm].[PostSecondaryInstitutionExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PostSecondaryInstitutionExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ID of the post secondary institution.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PostSecondaryInstitutionExtension', @level2type=N'COLUMN', @level2name=N'PostSecondaryInstitutionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The federal locale code associated with an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PostSecondaryInstitutionExtension', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO

-- Extended Properties [tpdm].[PreviousCareerDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the previous career of an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PreviousCareerDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'PreviousCareerDescriptor', @level2type=N'COLUMN', @level2name=N'PreviousCareerDescriptorId'
GO

-- Extended Properties [tpdm].[ProfessionalDevelopmentEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about a professional development event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the event, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or name for a professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing an organization that is offering a specific professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentOfferedByDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of total hours the professional development contains.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'TotalHours'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether a teacher candidate is active in a professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'Required'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether or not a professional development event is comprised of multiple sessions or not.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'MultipleSession'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reported reason for a teacher candidate''s professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEvent', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentReason'
GO

-- Extended Properties [tpdm].[ProfessionalDevelopmentEventAttendance] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This event entity represents the recording of whether a staff is in attendance for professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date for this attendance event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'AttendanceDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the event, typically associated with the issuing authority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or name for a professional development.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing the attendance event, for example:
       Present
       Unexcused absence
       Excused absence
       Tardy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'AttendanceEventCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reported reason for a teacher candidate''s absence.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentEventAttendance', @level2type=N'COLUMN', @level2name=N'AttendanceEventReason'
GO

-- Extended Properties [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the organization that a professional development is offered by.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentOfferedByDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProfessionalDevelopmentOfferedByDescriptor', @level2type=N'COLUMN', @level2name=N'ProfessionalDevelopmentOfferedByDescriptorId'
GO

-- Extended Properties [tpdm].[ProgramGatewayDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway that may be associated for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProgramGatewayDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProgramGatewayDescriptor', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO

-- Extended Properties [tpdm].[Prospect] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prospect for employment or contract that has not yet made formal application, often obtained from job fairs or university recruiting visits.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s maiden name.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'MaidenName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'ElectronicMailAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the prospect applied for a position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'Applied'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'HispanicLatinoEthnicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator whether the person was met by a representative of the education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'Met'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional notes about the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating initially assigned to the prospect prior to an official screening.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'PreScreeningRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the prospect was a referral.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'Referral'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person making the referral.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'ReferredBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'SexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The user name of the person on social media.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'SocialMediaUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The social media network name (e.g., LinkedIn, Twitter, etc.) associated with the SocialMediaUserName.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'SocialMediaNetworkName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'EconomicDisadvantaged'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether individual is a first generation college student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'FirstGenerationStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of prospect, such as TPP Applicant, Hire, or Mentor Teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'ProspectTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'Prospect', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[ProspectAid] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents the financial aid a person is awarded.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was designated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the condition (e.g., placement in a high need school) under which the aid was given.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid', @level2type=N'COLUMN', @level2name=N'AidConditionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The classification of financial aid awarded to a person for the academic term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid', @level2type=N'COLUMN', @level2name=N'AidTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of financial aid awarded to a person for the term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid', @level2type=N'COLUMN', @level2name=N'AidAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates a person who receives Pell Grant aid.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectAid', @level2type=N'COLUMN', @level2name=N'PellGrantRecipient'
GO

-- Extended Properties [tpdm].[ProspectCurrentPosition] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current position of the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPosition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPosition', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPosition', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formal name of the education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPosition', @level2type=N'COLUMN', @level2name=N'NameOfInstitution'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The location, typically City and State, for the institution.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPosition', @level2type=N'COLUMN', @level2name=N'Location'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive name of an individual''s position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPosition', @level2type=N'COLUMN', @level2name=N'PositionTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject the staff person''s assignment to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPosition', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO

-- Extended Properties [tpdm].[ProspectCurrentPositionGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of grade levels for which the individual''s assignment is responsible.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPositionGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPositionGradeLevel', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of grade levels for which the individual''s assignment is responsible.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPositionGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectCurrentPositionGradeLevel', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO

-- Extended Properties [tpdm].[ProspectDisability] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability condition(s) that best describes an individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisability', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisability', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the disability diagnosis.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDiagnosis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisability', @level2type=N'COLUMN', @level2name=N'OrderOfDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source that provided the disability determination.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDeterminationSourceTypeDescriptorId'
GO

-- Extended Properties [tpdm].[ProspectDisabilityDesignation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisabilityDesignation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDesignationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO

-- Extended Properties [tpdm].[ProspectPersonalIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectPersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[ProspectQualifications] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The qualifications of a prospective mentor teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectQualifications'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectQualifications', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectQualifications', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether the prospect is eligible for the position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectQualifications', @level2type=N'COLUMN', @level2name=N'Eligible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether or not a prospect mentor teacher has capacity to serve.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectQualifications', @level2type=N'COLUMN', @level2name=N'CapacityToServe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years of service at the current school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectQualifications', @level2type=N'COLUMN', @level2name=N'YearsOfServiceCurrentPlacement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years of service as a teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectQualifications', @level2type=N'COLUMN', @level2name=N'YearsOfServiceTotal'
GO

-- Extended Properties [tpdm].[ProspectRace] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRace', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRace', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRace', @level2type=N'COLUMN', @level2name=N'RaceDescriptorId'
GO

-- Extended Properties [tpdm].[ProspectRecruitmentEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reference(s) to events associated with the recruitment process.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRecruitmentEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectRecruitmentEvent', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO

-- Extended Properties [tpdm].[ProspectTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The 10-digit telephone number, including the area code, for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTelephone', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTelephone', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[ProspectTouchpoint] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Content associated with different touchpoints with the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTouchpoint'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTouchpoint', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTouchpoint', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The content associated with or an artifact from the touchpoint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTouchpoint', @level2type=N'COLUMN', @level2name=N'TouchpointContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the touchpoint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTouchpoint', @level2type=N'COLUMN', @level2name=N'TouchpointDate'
GO

-- Extended Properties [tpdm].[ProspectTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects the type of prospect, such as TPP Applicant, Hire, or Mentor Teacher.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ProspectTypeDescriptor', @level2type=N'COLUMN', @level2name=N'ProspectTypeDescriptorId'
GO

-- Extended Properties [tpdm].[QuantitativeMeasure] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A quantitative measure of educator performance associated with an Evaluation Element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the quantitative measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the quantitative measure (e.g., achievement, growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasure', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureDatatypeDescriptorId'
GO

-- Extended Properties [tpdm].[QuantitativeMeasureDatatypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureDatatypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureDatatypeDescriptor', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureDatatypeDescriptorId'
GO

-- Extended Properties [tpdm].[QuantitativeMeasureScore] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The score or value for a Quantitative Measure achieved by an individual educator.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the quantitative measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The score value for the quantitive measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'ScoreValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The standard error for the quantitative measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureScore', @level2type=N'COLUMN', @level2name=N'StandardError'
GO

-- Extended Properties [tpdm].[QuantitativeMeasureTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the quantitative measure (e.g., achievement, growth).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'QuantitativeMeasureTypeDescriptor', @level2type=N'COLUMN', @level2name=N'QuantitativeMeasureTypeDescriptorId'
GO

-- Extended Properties [tpdm].[RecruitmentEvent] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Events associated with the recruitment process.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The long description of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'RecruitmentEventTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The location of the event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEvent', @level2type=N'COLUMN', @level2name=N'EventLocation'
GO

-- Extended Properties [tpdm].[RecruitmentEventTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of event.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RecruitmentEventTypeDescriptor', @level2type=N'COLUMN', @level2name=N'RecruitmentEventTypeDescriptorId'
GO

-- Extended Properties [tpdm].[RubricDimension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The cells of a rubric, consisting of a qualitative decription, definition, or exemplar with the associated rubric rating and rating level.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating achieved for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'RubricRating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'RubricRatingLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The criterion description for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'CriterionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricDimension', @level2type=N'COLUMN', @level2name=N'DimensionOrder'
GO

-- Extended Properties [tpdm].[RubricRatingLevelDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rating level achieved for the rubric dimension.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricRatingLevelDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'RubricRatingLevelDescriptor', @level2type=N'COLUMN', @level2name=N'RubricRatingLevelDescriptorId'
GO

-- Extended Properties [tpdm].[SalaryTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the type of salary that a staff member is receiving.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SalaryTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SalaryTypeDescriptor', @level2type=N'COLUMN', @level2name=N'SalaryTypeDescriptorId'
GO

-- Extended Properties [tpdm].[SchoolExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The federal locale code associated with an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ID of the post secondary institution.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'PostSecondaryInstitutionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether a school is identified as an improving school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'ImprovingSchool'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Accreditation Status for a Education Preparation Provider.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SchoolExtension', @level2type=N'COLUMN', @level2name=N'AccreditationStatusDescriptorId'
GO

-- Extended Properties [tpdm].[StaffApplicantAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Associated applicant(s) represented by this staff member.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffApplicantAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier assigned to a person making formal application for an open staff position.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffApplicantAssociation', @level2type=N'COLUMN', @level2name=N'ApplicantIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffApplicantAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [tpdm].[StaffBackgroundCheck] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Staff background check history and disposition.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffBackgroundCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of background check (e.g., online, criminal, employment).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffBackgroundCheck', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was requested.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckRequestedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckCompletedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person has or has not completed a fingerprint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffBackgroundCheck', @level2type=N'COLUMN', @level2name=N'Fingerprint'
GO

-- Extended Properties [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the LEA.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The titles of employment, official status, or rank of education staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'StaffClassificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of years that an individual has previously held a teaching position in one or more education institutions.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffEducationOrganizationAssignmentAssociationExtension', @level2type=N'COLUMN', @level2name=N'YearsOfExperienceAtCurrentEducationOrganization'
GO

-- Extended Properties [tpdm].[StaffExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the probation period ended or is scheduled to end.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'ProbationCompleteDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the staff member is tenured.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'Tenured'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the staff is on track for tenure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffExtension', @level2type=N'COLUMN', @level2name=N'TenureTrack'
GO

-- Extended Properties [tpdm].[StaffHighlyQualifiedAcademicSubject] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject(s) in which the staff is deemed to be "highly qualified".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffHighlyQualifiedAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic subject(s) in which the staff is deemed to be "highly qualified".', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffHighlyQualifiedAcademicSubject', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffHighlyQualifiedAcademicSubject', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [tpdm].[StaffProspectAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Associated previously identified prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffProspectAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffProspectAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the prospect.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffProspectAssociation', @level2type=N'COLUMN', @level2name=N'ProspectIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffProspectAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [tpdm].[StaffSalary] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information regarding the salary of a staff member.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSalary', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The minimum salary range for a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSalary', @level2type=N'COLUMN', @level2name=N'SalaryMinRange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum salary range for a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSalary', @level2type=N'COLUMN', @level2name=N'SalaryMaxRange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of salary that a staff member is receiving.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSalary', @level2type=N'COLUMN', @level2name=N'SalaryTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The salary of a staff member.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSalary', @level2type=N'COLUMN', @level2name=N'SalaryAmount'
GO

-- Extended Properties [tpdm].[StaffSeniority] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Entries of job experience contributing to computations of seniority.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSeniority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The field of the credential being applied.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSeniority', @level2type=N'COLUMN', @level2name=N'CredentialFieldDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the education organization worked.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSeniority', @level2type=N'COLUMN', @level2name=N'NameOfInstitution'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSeniority', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of years of experience.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffSeniority', @level2type=N'COLUMN', @level2name=N'YearsExperience'
GO

-- Extended Properties [tpdm].[StaffStudentGrowthMeasure] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Complex type that provides data about a group of students and their student growth as it pertains to the Teacher Candidate', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StaffStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the student growth is measured', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthMeasureDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identification of the type of score that was used to determine student growth', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The target score that has been set for the group of students as it pertains to their student growth.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthTargetScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual score a group of students receives on their student growth assessment', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthActualScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies if the student has met the student growth target score', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthMet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of students included in the average score result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthNCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standard error for growth score measurement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StandardError'
GO

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureAcademicSubject] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'StaffStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureCourseAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any courses associated with the staff''s student growth data, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'CourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'StaffStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any education organizations associated with the staff''s student growth data, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureEducationOrganizationAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'StaffStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the set of grade levels.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the set of grade levels.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'StaffStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureSectionAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any sections associated with the staff''s student growth data, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'StaffStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[StaffTeacherEducatorResearch] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Teacher preparation provider faculty that instruct teacher candidates in content area or pedagogy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherEducatorResearch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherEducatorResearch', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the start or effective date of a staff member''s teacher educator position for an Education Organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherEducatorResearch', @level2type=N'COLUMN', @level2name=N'ResearchExperienceDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the research experience.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherEducatorResearch', @level2type=N'COLUMN', @level2name=N'ResearchExperienceTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the research experience.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherEducatorResearch', @level2type=N'COLUMN', @level2name=N'ResearchExperienceDescription'
GO

-- Extended Properties [tpdm].[StaffTeacherPreparationProviderProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This association indicates the Staff associated with a teacher preparation provider program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherPreparationProviderProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Start date for the association of staff to this program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'End date for the association of staff to this program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the staff has access to the student records of the program per district interpretation of FERPA and other privacy laws, regulations, and policies.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StaffTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'StudentRecordAccess'
GO

-- Extended Properties [tpdm].[StateEducationAgencyExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StateEducationAgencyExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a state education agency.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StateEducationAgencyExtension', @level2type=N'COLUMN', @level2name=N'StateEducationAgencyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The federal locale code associated with an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StateEducationAgencyExtension', @level2type=N'COLUMN', @level2name=N'FederalLocaleCodeDescriptorId'
GO

-- Extended Properties [tpdm].[StudentGradebookEntryExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Month, day, and year of the Student''s entry or assignment to the Section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the assignment, homework, or assessment was assigned or executed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'DateAssigned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the activity to be recorded in the GradebookEntry.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'GradebookEntryTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date that the assignment was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'DateCompleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indication of whether the assignment was passed or not.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGradebookEntryExtension', @level2type=N'COLUMN', @level2name=N'AssignmentPassed'
GO

-- Extended Properties [tpdm].[StudentGrowthTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identification of the type of score that was used to determine student growth', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGrowthTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'StudentGrowthTypeDescriptor', @level2type=N'COLUMN', @level2name=N'StudentGrowthTypeDescriptorId'
GO

-- Extended Properties [tpdm].[SurveyResponseExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier of the survey typically from the survey application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'SurveyResponseIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseExtension', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The association provides information about the survey being taken and who the survey is about.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseTeacherCandidateTargetAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier of the survey typically from the survey application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyResponseIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveyResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO

-- Extended Properties [tpdm].[SurveySectionAggregateResponse] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The aggregate or average score across the surveying population for a survey section being used for performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for the person''s evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or label for the survey section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'SurveySectionTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The score value for the aggregate survey section response.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionAggregateResponse', @level2type=N'COLUMN', @level2name=N'ScoreValue'
GO

-- Extended Properties [tpdm].[SurveySectionExtension] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or label for the survey section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'SurveySectionTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An assigned unique identifier for the performance evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (e.g., walkthrough, summative) of performance evaluation conducted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'PerformanceEvaluationTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EvaluationPeriodDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EvaluationTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation Objective.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EvaluationObjectiveTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name or title of the evaluation element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionExtension', @level2type=N'COLUMN', @level2name=N'EvaluationElementTitle'
GO

-- Extended Properties [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This association provides information about the survey section and the teacher candidate the survey section is about.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponseTeacherCandidateTargetAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace for the Survey.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique survey identifier from the survey tool.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier of the survey typically from the survey application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveyResponseIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title or label for the survey section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'SurveySectionTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'SurveySectionResponseTeacherCandidateTargetAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO

-- Extended Properties [tpdm].[TeacherCandidate] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents an individual for whom instruction and/or services in a Teacher Preparation Program are provided under the jurisdiction of a Teacher Preparation Provider.  A teacher candidate is a person who has been enrolled in a teacher preparation program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s maiden name.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'MaidenName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'SexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which an individual was born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'BirthDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The city the student was born in.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'BirthCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'BirthStateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For students born outside of the U.S., the Province or jurisdiction in which an individual is born.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'BirthInternationalProvince'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The country in which an individual is born. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'BirthCountryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For students born outside of the U.S., the date the student entered the U.S.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'DateEnteredUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'MultipleBirthStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A person''s gender at birth.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'BirthSexDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Locator for the student photo.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'ProfileThumbnail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'HispanicLatinoEthnicity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Previous definition of Ethnicity combining Hispanic/Latino and race:
      1 - American Indian or Alaskan Native
      2 - Asian or Pacific Islander
      3 - Black, not of Hispanic origin
      4 - Hispanic
      5 - White, not of Hispanic origin.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'OldEthnicityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of whether or not the person is a U.S. citizen.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'CitizenshipStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'EconomicDisadvantaged'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the student has been identified as limited English proficient by the Language Proficiency Assessment Committee (LPAC), or English proficient.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'LimitedEnglishProficiencyDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'DisplacementStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The login ID for the user; used for security access control interface.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'LoginId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The gender with which a person associates.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'GenderDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The tuition for a person''s participation in a program, service. or course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'TuitionCost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'EnglishLanguageExamDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The career previous for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'PreviousCareerDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication of whether a teacher candidate has completed the teacher preparation program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'ProgramComplete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether individual is a first generation college student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'FirstGenerationStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'PersonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the originating record source system for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidate', @level2type=N'COLUMN', @level2name=N'SourceSystemDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecord] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This educational entity represents the cumulative record of academic achievement for a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeEarnedCredits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeEarnedCreditTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeEarnedCreditConversion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeAttemptedCredits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeAttemptedCreditTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeAttemptedCreditConversion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The cumulative number of grade points an individual earns by successfully completing courses or examinations during his or her enrollment in the current school as well as those transferred from schools in which the individual had been previously enrolled.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeGradePointsEarned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A measure of average performance in all courses taken by an individual during his or her school career as determined for record-keeping purposes. This is obtained by dividing the total grade points received by the total number of credits attempted. This usually includes grade points received and credits attempted in his or her current school as well as those transferred from schools in which the individual was previously enrolled.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'CumulativeGradePointAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The scale of equivalents, if applicable, for grades awarded as indicators of performance in schoolwork. For example, numerical equivalents for letter grades used in determining a student''s Grade Point Average (A=4, B=3, C=2, D=1 in a four-point system) or letter equivalents for percentage grades (90-100%=A, 80-90%=B, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'GradeValueQualifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month and year the student is projected to graduate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'ProjectedGraduationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionEarnedCredits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionEarnedCreditTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionEarnedCreditConversion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionAttemptedCredits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionAttemptedCreditTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionAttemptedCreditConversion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of grade points an individual earned for this session.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionGradePointsEarned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade point average for an individual computed as the grade points earned during the session divided by the number of credits attempted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'SessionGradePointAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A measure of average performance in all courses taken by an individual within a given content area during his or her school career as determined for record-keeping purposes. This is obtained by dividing the total grade points received by the total number of credits attempted. This usually includes grade points received and credits attempted in his or her current school as well as those transferred from schools in which the individual was previously enrolled.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'ContentGradePointAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The cumulative number of grade points an individual earns within a given content area by successfully completing courses or examinations during his or her enrollment in the current school as well as those transferred from schools in which the individual had been previously enrolled.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'ContentGradePointEarned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the program gateway that may be associated for continuation in the program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'ProgramGatewayDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The degree type that a teacher candidate accomplishes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecord', @level2type=N'COLUMN', @level2name=N'TPPDegreeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Academic distinctions earned by or awarded to the student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A designation of the type of academic distinctions earned by or awarded to the student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'AcademicHonorCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the type of academic distinctions earned by or awarded to the individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'HonorDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title assigned to the achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'AchievementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of achievement attributed to the learner.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'AchievementCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The system that defines the categories by which an achievement is attributed to the learner.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'AchievementCategorySystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the agent, entity, or institution issuing the element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) from which the award was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'IssuerOriginURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The criteria for competency-based completion of the achievement/award.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'Criteria'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'CriteriaURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A statement or reference describing the evidence that the learner met the criteria for attainment of the Achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'EvidenceStatement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the Achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'ImageURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the honor was awarded or earned.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'HonorAwardDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which the award expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordAcademicHonor', @level2type=N'COLUMN', @level2name=N'HonorAwardExpiresDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordClassRanking] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic rank information of a student in relation to his or her graduating class.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic rank of a student in relation to his or her graduating class (e.g., 1st, 2nd, 3rd).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking', @level2type=N'COLUMN', @level2name=N'ClassRank'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of students in the student''s graduating class.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking', @level2type=N'COLUMN', @level2name=N'TotalNumberInClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The academic percentage rank of a student in relation to his or her graduating class (e.g., 95%, 80%, 50%).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking', @level2type=N'COLUMN', @level2name=N'PercentageRanking'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date class ranking was determined.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordClassRanking', @level2type=N'COLUMN', @level2name=N'ClassRankingDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordDiploma] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Diploma(s) earned by the student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the student met  graduation requirements and was awarded a diploma.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'DiplomaAwardDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'DiplomaTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title assigned to the achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'AchievementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of achievement attributed to the learner.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'AchievementCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The system that defines the categories by which an achievement is attributed to the learner.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'AchievementCategorySystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the agent, entity, or institution issuing the element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) from which the award was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'IssuerOriginURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The criteria for competency-based completion of the achievement/award.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'Criteria'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'CriteriaURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A statement or reference describing the evidence that the learner met the criteria for attainment of the Achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'EvidenceStatement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the Achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'ImageURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The level of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.
        Minimum high school program
        Recommended high school program
        Distinguished Achievement Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'DiplomaLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicated a student who reached a state-defined threshold of vocational education and who attained a high school diploma or its recognized state equivalent or GED.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'CTECompleter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of diploma given to the student for accomplishments.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'DiplomaDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which the award expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordDiploma', @level2type=N'COLUMN', @level2name=N'DiplomaAwardExpiresDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data that provides information on a measure of average performance in a group of courses taken by an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The system used for calculating the grade point average for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage', @level2type=N'COLUMN', @level2name=N'GradePointAverageTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator of whether or not the Grade Point Average value is cumulative.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage', @level2type=N'COLUMN', @level2name=N'IsCumulative'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the grade points earned divided by the number of credits attempted.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage', @level2type=N'COLUMN', @level2name=N'GradePointAverageValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The maximum value for the grade point average.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordGradePointAverage', @level2type=N'COLUMN', @level2name=N'MaxGradePointAverageValue'
GO

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordRecognition] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Recognitions given to the student for accomplishments in a co-curricular or extracurricular activity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The nature of recognition given to the learner for accomplishments in a co-curricular, or extra-curricular activity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'RecognitionTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title assigned to the achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'AchievementTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of achievement attributed to the learner.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'AchievementCategoryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The system that defines the categories by which an achievement is attributed to the learner.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'AchievementCategorySystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the agent, entity, or institution issuing the element.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) from which the award was issued.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'IssuerOriginURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The criteria for competency-based completion of the achievement/award.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'Criteria'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'CriteriaURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A statement or reference describing the evidence that the learner met the criteria for attainment of the Achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'EvidenceStatement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the Achievement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'ImageURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the type of academic distinctions earned by or awarded to the individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'RecognitionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the recognition was awarded or earned.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'RecognitionAwardDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which the award expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAcademicRecordRecognition', @level2type=N'COLUMN', @level2name=N'RecognitionAwardExpiresDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The apartment, room, or suite number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'ApartmentRoomSuiteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of the building on the site, if more than one building shares the same address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'BuildingSiteNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'NameOfCounty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'CountyFIPSCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The congressional district in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'CongressionalDistrict'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddress', @level2type=N'COLUMN', @level2name=N'LocaleDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateAddressPeriod] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the start of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The five or nine digit zip code or overseas postal code portion of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation for the state (within the United States) or outlying area in which an address is located.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'StateAbbreviationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street number and street name or post office box number of an address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'StreetNumberName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year for the end of the period.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAddressPeriod', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateAid] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents the financial aid a person is awarded.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The classification of financial aid awarded to a person for the academic term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAid', @level2type=N'COLUMN', @level2name=N'AidTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was designated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAid', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAid', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the award was removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAid', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the condition (e.g., placement in a high need school) under which the aid was given.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAid', @level2type=N'COLUMN', @level2name=N'AidConditionDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of financial aid awarded to a person for the term/year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAid', @level2type=N'COLUMN', @level2name=N'AidAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates a person who receives Pell Grant aid.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateAid', @level2type=N'COLUMN', @level2name=N'PellGrantRecipient'
GO

-- Extended Properties [tpdm].[TeacherCandidateBackgroundCheck] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Applicant background check history and disposition.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateBackgroundCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of background check (e.g., online, criminal, employment).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was requested.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckRequestedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckStatusDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the background check was completed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'BackgroundCheckCompletedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that a person has or has not completed a fingerprint.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateBackgroundCheck', @level2type=N'COLUMN', @level2name=N'Fingerprint'
GO

-- Extended Properties [tpdm].[TeacherCandidateCharacteristic] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reflects important characteristics of the teacher candidate''s home situation:
      Displaced Homemaker, Immigrant, Migratory, Military Parent, Pregnant Teen, Single Parent, and Unaccompanied Youth.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCharacteristic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The characteristic designated for the Student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'StudentCharacteristicDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the characteristic was designated.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the characteristic was removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person, organization, or department that designated the characteristic.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCharacteristic', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO

-- Extended Properties [tpdm].[TeacherCandidateCharacteristicDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The characteristic designated for the TeacherCandidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCharacteristicDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCharacteristicDescriptor', @level2type=N'COLUMN', @level2name=N'TeacherCandidateCharacteristicDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateCohortYear] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type and year of a cohort (e.g., 9th grade) the student belongs to as determined by the year that student entered a specific grade.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCohortYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of cohort year (9th grade, graduation).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCohortYear', @level2type=N'COLUMN', @level2name=N'CohortYearTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the  school year for the Cohort.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCohortYear', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCohortYear', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO

-- Extended Properties [tpdm].[TeacherCandidateCourseTranscript] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity is the final record of a student''s performance in their courses at the end of a semester or school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The result from the student''s attempt to take the course, for example:
        Pass
        Fail
        Incomplete
        Withdrawn.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'CourseAttemptResultDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'CourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'CourseEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'AttemptedCredits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'AttemptedCreditTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'AttemptedCreditConversion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'EarnedCredits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'EarnedCreditTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'EarnedCreditConversion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Student''s grade level at time of course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'WhenTakenGradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The method the credits were earned (e.g., Classroom, Examination, Transfer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'MethodCreditEarnedDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The final indicator of student performance in a class as submitted by the instructor.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'FinalLetterGradeEarned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The final indicator of student performance in a class as submitted by the instructor.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'FinalNumericGradeEarned'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that an academic course has been repeated by a student and how that repeat is to be computed in the student''s academic grade average.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'CourseRepeatCodeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, language arts).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'CourseTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive name given to a course of study offered in the school, if different from the CourseTitle.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'AlternativeCourseTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the school that identifies the course offering, the code from an external educational organization, or other alternate course code.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscript', @level2type=N'COLUMN', @level2name=N'AlternativeCourseCode'
GO

-- Extended Properties [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of additional credits a student attempted and could earn for successfully completing a given course (e.g., dual credit, AP, IB).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of credits or units of value awarded for the completion of a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'AdditionalCreditTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The result from the student''s attempt to take the course, for example:
        Pass
        Fail
        Incomplete
        Withdrawn.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'CourseAttemptResultDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'CourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'CourseEducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The term for the session during the school year.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'TermDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of credits or units of value awarded for the completion of a course', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateCourseTranscriptEarnedAdditionalCredits', @level2type=N'COLUMN', @level2name=N'Credits'
GO

-- Extended Properties [tpdm].[TeacherCandidateDegreeSpecialization] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information around the area(s) of specialization for an individual.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDegreeSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the Teacher Candidate first declared specialization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The major area for a degree or area of specialization for a certificate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'MajorSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The major area for a degree or area of specialization for a certificate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'MinorSpecialization'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the Teacher Candidate exited the declared specialization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDegreeSpecialization', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateDisability] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The disability condition(s) that best describes an individual''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisability', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the disability diagnosis.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDiagnosis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisability', @level2type=N'COLUMN', @level2name=N'OrderOfDisability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source that provided the disability determination.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisability', @level2type=N'COLUMN', @level2name=N'DisabilityDeterminationSourceTypeDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateDisabilityDesignation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisabilityDesignation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A disability category that describes a child''s impairment.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Whether the disability is IDEA, Section 504, or other disability designation.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'DisabilityDesignationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateDisabilityDesignation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO

-- Extended Properties [tpdm].[TeacherCandidateElectronicMail] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateElectronicMail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The electronic mail (e-mail) address listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'ElectronicMailAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'ElectronicMailTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'PrimaryEmailAddressIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the electronic email address should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateElectronicMail', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[TeacherCandidateIdentificationCode] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The organization code or name assigning the StudentIdentificationCode.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationCode', @level2type=N'COLUMN', @level2name=N'AssigningOrganizationIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a student.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationCode', @level2type=N'COLUMN', @level2name=N'StudentIdentificationSystemDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationCode', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique number or alphanumeric code assigned to a student by a school, school system, a state, or other agency or entity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationCode', @level2type=N'COLUMN', @level2name=N'IdentificationCode'
GO

-- Extended Properties [tpdm].[TeacherCandidateIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Describe the documentation of citizenship.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateIndicator] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicator(s) or metric(s) computed for the student (e.g., at risk) to influence more effective education or direct specific interventions.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the indicator or metric.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIndicator', @level2type=N'COLUMN', @level2name=N'IndicatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIndicator', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name for a group of indicators.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIndicator', @level2type=N'COLUMN', @level2name=N'IndicatorGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the indicator or metric.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIndicator', @level2type=N'COLUMN', @level2name=N'Indicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the indicator was assigned or computed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIndicator', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the indicator or metric was sunset or removed.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIndicator', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person, organization, or department that designated the program association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateIndicator', @level2type=N'COLUMN', @level2name=N'DesignatedBy'
GO

-- Extended Properties [tpdm].[TeacherCandidateInternationalAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an international address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The second line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The third line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fourth line of the address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'AddressLine4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'CountryDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic latitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The geographic longitude of the physical address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first date the address is valid. For physical addresses, the date the person moved to that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last date the address is valid. For physical addresses, this would be the date the person moved from that address.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateInternationalAddress', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateLanguage] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The language(s) the individual uses to communicate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateLanguage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateLanguage', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateLanguage', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO

-- Extended Properties [tpdm].[TeacherCandidateLanguageUse] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateLanguageUse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A specification of which written or spoken communication is being used.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateLanguageUse', @level2type=N'COLUMN', @level2name=N'LanguageUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateLanguageUse', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO

-- Extended Properties [tpdm].[TeacherCandidateOtherName] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Other names (e.g., alias, nickname, previous legal name) associated with a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateOtherName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The types of alternate names for a person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateOtherName', @level2type=N'COLUMN', @level2name=N'OtherNameTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateOtherName', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A prefix used to denote the title, degree, position, or seniority of the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateOtherName', @level2type=N'COLUMN', @level2name=N'PersonalTitlePrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateOtherName', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A secondary name given to an individual at birth, baptism, or during another naming ceremony.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateOtherName', @level2type=N'COLUMN', @level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateOtherName', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateOtherName', @level2type=N'COLUMN', @level2name=N'GenerationCodeSuffix'
GO

-- Extended Properties [tpdm].[TeacherCandidatePersonalIdentificationDocument] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The primary function of the document used for establishing identity.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IdentificationDocumentUseDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The category of the document relative to its purpose.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'PersonalInformationVerificationDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the document given by the issuer.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The day when the document  expires, if null then never expires.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'DocumentExpirationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier on the issuer''s identification system.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerDocumentIdentificationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the entity or institution that issued the document.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidatePersonalIdentificationDocument', @level2type=N'COLUMN', @level2name=N'IssuerCountryDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateRace] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateRace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateRace', @level2type=N'COLUMN', @level2name=N'RaceDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateRace', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO

-- Extended Properties [tpdm].[TeacherCandidateStaffAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This describes a relationship between a (current) teacher candidate and a staff person, typically at a K12 partnering district in the role of a mentor teacher, coordinating teacher, supervising principal, etc.  It could also describe the relationship between a (current) teacher candidate and a university staff member, i.e., field placement supervisor, advisor, etc.  This is a relationship between two different people.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStaffAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStaffAssociation', @level2type=N'COLUMN', @level2name=N'StaffUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStaffAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the teacher candidate is associated to the staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStaffAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The month, day, and year on which the teacher candidate stops association with the staff.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStaffAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasure] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Complex type that provides data about a group of students and their student growth as it pertains to the Teacher Candidate', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'TeacherCandidateStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the student growth is measured', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthMeasureDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'ResultDatatypeTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identification of the type of score that was used to determine student growth', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The target score that has been set for the group of students as it pertains to their student growth.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthTargetScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual score a group of students receives on their student growth assessment', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthActualScore'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies if the student growth target score is achieved.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthMet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of students included in the average score result.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StudentGrowthNCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standard error for growth score measurement.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasure', @level2type=N'COLUMN', @level2name=N'StandardError'
GO

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureAcademicSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureAcademicSubject', @level2type=N'COLUMN', @level2name=N'TeacherCandidateStudentGrowthMeasureIdentifier'
GO

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any courses associated with the teacher candidate''s student growth data, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a course.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'CourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureCourseAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any education organizations associated with the teacher candidate''s student growth data, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the set of grade levels.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureGradeLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This descriptor defines the set of grade levels.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureGradeLevel', @level2type=N'COLUMN', @level2name=N'TeacherCandidateStudentGrowthMeasureIdentifier'
GO

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any sections associated with the teacher candidate''s student growth data, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date for which the data element is relevant', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'FactAsOfDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local code assigned by the School that identifies the course offering provided for the instruction of students.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'LocalCourseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The school year for which the data is associated', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The local identifier assigned to a section.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'SectionIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'SessionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assigned unique identifier for the student growth measure.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateStudentGrowthMeasureIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begin date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateStudentGrowthMeasureSectionAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO

-- Extended Properties [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the association between the Teacher Candidate and the EducatorPreparationProgram', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTeacherPreparationProviderProgramAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The begin date for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to an education organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'EducationOrganizationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Educator Preparation Program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of program.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'ProgramTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reason exited for the association.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTeacherPreparationProviderProgramAssociation', @level2type=N'COLUMN', @level2name=N'ReasonExitedDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateTelephone] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The 10-digit telephone number, including the area code, for the person.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTelephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTelephone', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone number including the area code, and extension, if applicable.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of communication number listed for an individual or organization.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTelephone', @level2type=N'COLUMN', @level2name=N'TelephoneNumberTypeDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTelephone', @level2type=N'COLUMN', @level2name=N'OrderOfPriority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTelephone', @level2type=N'COLUMN', @level2name=N'TextMessageCapabilityIndicator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indication that the telephone number should not be published.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTelephone', @level2type=N'COLUMN', @level2name=N'DoNotPublishIndicator'
GO

-- Extended Properties [tpdm].[TeacherCandidateTPPProgramDegree] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details of the degree.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTPPProgramDegree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a degree.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTPPProgramDegree', @level2type=N'COLUMN', @level2name=N'AcademicSubjectDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The grade level associated with the degree plan for the teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTPPProgramDegree', @level2type=N'COLUMN', @level2name=N'GradeLevelDescriptorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTPPProgramDegree', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code for describing the degree type that a teacher candidate accomplishes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateTPPProgramDegree', @level2type=N'COLUMN', @level2name=N'TPPDegreeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[TeacherCandidateVisa] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of a non-US citizen''s Visa type.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateVisa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a teacher candidate.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateVisa', @level2type=N'COLUMN', @level2name=N'TeacherCandidateIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of a non-US citizen''s Visa type.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TeacherCandidateVisa', @level2type=N'COLUMN', @level2name=N'VisaDescriptorId'
GO

-- Extended Properties [tpdm].[TPPDegreeTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the degree that a teacher candidate accomplishes.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TPPDegreeTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TPPDegreeTypeDescriptor', @level2type=N'COLUMN', @level2name=N'TPPDegreeTypeDescriptorId'
GO

-- Extended Properties [tpdm].[TPPProgramPathwayDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the program pathways available at TPP''s.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TPPProgramPathwayDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'TPPProgramPathwayDescriptor', @level2type=N'COLUMN', @level2name=N'TPPProgramPathwayDescriptorId'
GO

-- Extended Properties [tpdm].[ValueTypeDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type (i.e. actual or projected) of value.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ValueTypeDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'ValueTypeDescriptor', @level2type=N'COLUMN', @level2name=N'ValueTypeDescriptorId'
GO

-- Extended Properties [tpdm].[WithdrawReasonDescriptor] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptor holds the reason applicant withdrew application.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'WithdrawReasonDescriptor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.', @level0type=N'SCHEMA', @level0name=N'tpdm', @level1type=N'TABLE', @level1name=N'WithdrawReasonDescriptor', @level2type=N'COLUMN', @level2name=N'WithdrawReasonDescriptorId'
GO

