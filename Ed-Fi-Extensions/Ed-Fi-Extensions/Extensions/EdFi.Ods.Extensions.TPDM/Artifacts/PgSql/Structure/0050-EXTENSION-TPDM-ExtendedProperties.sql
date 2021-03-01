-- Extended Properties [tpdm].[AccreditationStatusDescriptor] --
COMMENT ON TABLE tpdm.AccreditationStatusDescriptor IS 'Accreditation Status for a Teacher Preparation Provider.';
COMMENT ON COLUMN tpdm.AccreditationStatusDescriptor.AccreditationStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[AidTypeDescriptor] --
COMMENT ON TABLE tpdm.AidTypeDescriptor IS 'This descriptor defines the classification of financial aid awarded to a person for the academic term/year.';
COMMENT ON COLUMN tpdm.AidTypeDescriptor.AidTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[AnonymizedStudent] --
COMMENT ON TABLE tpdm.AnonymizedStudent IS 'Domain entity to collect data for indiviudal students with whom the teacher candidate is associated through field work or student teaching';
COMMENT ON COLUMN tpdm.AnonymizedStudent.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudent.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudent.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudent.ValueTypeDescriptorId IS 'Domain entity to collect data for indiviudal students with whom the teacher candidate is associated through field work or student teaching';
COMMENT ON COLUMN tpdm.AnonymizedStudent.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN tpdm.AnonymizedStudent.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.AnonymizedStudent.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."';
COMMENT ON COLUMN tpdm.AnonymizedStudent.GradeLevelDescriptorId IS 'The grade level for the student.';
COMMENT ON COLUMN tpdm.AnonymizedStudent.Section504Enrollment IS 'Information about the students who are enrolled in a 504 program';
COMMENT ON COLUMN tpdm.AnonymizedStudent.ELLEnrollment IS 'Data about the ELL enrollment of the student';
COMMENT ON COLUMN tpdm.AnonymizedStudent.ESLEnrollment IS 'Data about the ESL enrollment of the student';
COMMENT ON COLUMN tpdm.AnonymizedStudent.SPEDEnrollment IS 'Data about the enrollment in SPED of the student';
COMMENT ON COLUMN tpdm.AnonymizedStudent.TitleIEnrollment IS 'Data about the enrollment in Title I of the student';
COMMENT ON COLUMN tpdm.AnonymizedStudent.AtriskIndicator IS 'An indicator that identifies if the student has been flagged as being at risk according to the District''s definition of at risk.';
COMMENT ON COLUMN tpdm.AnonymizedStudent.Mobility IS 'The number of times a student has moved schools during the current school year.';

-- Extended Properties [tpdm].[AnonymizedStudentAcademicRecord] --
COMMENT ON TABLE tpdm.AnonymizedStudentAcademicRecord IS 'The academic record for an anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.SessionGradePointAverage IS 'The number of grade points an individual earned for this session.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.CumulativeGradePointAverage IS 'The average cumulative grade point average for a student';
COMMENT ON COLUMN tpdm.AnonymizedStudentAcademicRecord.GPAMax IS 'The maximum grade point average that can be achieved by a student';

-- Extended Properties [tpdm].[AnonymizedStudentAssessment] --
COMMENT ON TABLE tpdm.AnonymizedStudentAssessment IS 'This entity represents the analysis or scoring of a Student''s response on an assessment. The analysis results in a value that represents a Student''s performance on a set of items on a test.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.AdministrationDate IS 'Date the assessment was administered';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.AssessmentIdentifier IS 'An identifier that uniquely identifies the assessment to which the student results are associated.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.TakenSchoolYear IS 'The school year the assessment was taken';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.TermDescriptorId IS 'The term in which the assessment was administered';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.AssessmentTitle IS 'The title if any specific assessment given to a group';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.AssessmentCategoryDescriptorId IS 'The category of an assessment based on format and content. For example: Achievement test Advanced placement test Alternate assessment/grade-level standards Attitudinal test Cognitive and perceptual skills test ...';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.AcademicSubjectDescriptorId IS 'The academic subject associated with a student assessment';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessment.GradeLevelDescriptorId IS 'Grade level for which effectiveness is measured.';

-- Extended Properties [tpdm].[AnonymizedStudentAssessmentCourseAssociation] --
COMMENT ON TABLE tpdm.AnonymizedStudentAssessmentCourseAssociation IS 'The course associated with aggregated student data.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentCourseAssociation.AdministrationDate IS 'Date the assessment was administered';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentCourseAssociation.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentCourseAssociation.AssessmentIdentifier IS 'An identifier that uniquely identifies the assessment to which the student results are associated.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentCourseAssociation.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentCourseAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentCourseAssociation.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentCourseAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentCourseAssociation.TakenSchoolYear IS 'The school year the assessment was taken';

-- Extended Properties [tpdm].[AnonymizedStudentAssessmentPerformanceLevel] --
COMMENT ON TABLE tpdm.AnonymizedStudentAssessmentPerformanceLevel IS 'The performance level(s) achieved for the StudentAssessment.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.AdministrationDate IS 'Date the assessment was administered';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.AssessmentIdentifier IS 'An identifier that uniquely identifies the assessment to which the student results are associated.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.TakenSchoolYear IS 'The school year the assessment was taken';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.PerformanceLevelMet IS 'Indicator of whether the performance level was met.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.PerformanceLevelDescriptorId IS 'A specification of which performance level value describes the student proficiency.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentPerformanceLevel.AssessmentReportingMethodDescriptorId IS 'The method that the instructor of the class uses to report the performance and achievement. It may be a qualitative method such as individualized teacher comments or a quantitative method such as a letter or numerical grade. In some cases, more than one type of reporting method may be used.';

-- Extended Properties [tpdm].[AnonymizedStudentAssessmentScoreResult] --
COMMENT ON TABLE tpdm.AnonymizedStudentAssessmentScoreResult IS 'A specification of which performance level value describes the student proficiency.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.AdministrationDate IS 'Date the assessment was administered';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.AssessmentIdentifier IS 'An identifier that uniquely identifies the assessment to which the student results are associated.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.TakenSchoolYear IS 'The school year the assessment was taken';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.Result IS 'The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentScoreResult.AssessmentReportingMethodDescriptorId IS 'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.';

-- Extended Properties [tpdm].[AnonymizedStudentAssessmentSectionAssociation] --
COMMENT ON TABLE tpdm.AnonymizedStudentAssessmentSectionAssociation IS 'The course associated with aggregated student data.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.AdministrationDate IS 'Date the assessment was administered';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.AssessmentIdentifier IS 'An identifier that uniquely identifies the assessment to which the student results are associated.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.AnonymizedStudentAssessmentSectionAssociation.TakenSchoolYear IS 'The school year the assessment was taken';

-- Extended Properties [tpdm].[AnonymizedStudentCourseAssociation] --
COMMENT ON TABLE tpdm.AnonymizedStudentCourseAssociation IS 'Information about the association between an anonymized student and the course they are enrolled in';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseAssociation.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseAssociation.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseAssociation.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseAssociation.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseAssociation.EndDate IS 'The end date for the association';

-- Extended Properties [tpdm].[AnonymizedStudentCourseTranscript] --
COMMENT ON TABLE tpdm.AnonymizedStudentCourseTranscript IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.FinalLetterGradeEarned IS 'The final indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.FinalNumericGradeEarned IS 'The final indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.CourseRepeatCodeDescriptorId IS 'Indicates that an academic course has been repeated by a student and how that repeat is to be computed in the student''s academic grade average.';
COMMENT ON COLUMN tpdm.AnonymizedStudentCourseTranscript.CourseTitle IS 'The descriptive name given to a course of study offered in a school or other institution or organization.';

-- Extended Properties [tpdm].[AnonymizedStudentDisability] --
COMMENT ON TABLE tpdm.AnonymizedStudentDisability IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisability.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisability.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisability.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisability.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisability.OrderOfDisability IS 'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [tpdm].[AnonymizedStudentDisabilityDesignation] --
COMMENT ON TABLE tpdm.AnonymizedStudentDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisabilityDesignation.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisabilityDesignation.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentDisabilityDesignation.SchoolYear IS 'The school year for which the data is associated';

-- Extended Properties [tpdm].[AnonymizedStudentEducationOrganizationAssociation] --
COMMENT ON TABLE tpdm.AnonymizedStudentEducationOrganizationAssociation IS 'Information about the association between an anonymized student and the Education Organziation they are enrolled in';
COMMENT ON COLUMN tpdm.AnonymizedStudentEducationOrganizationAssociation.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentEducationOrganizationAssociation.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.AnonymizedStudentEducationOrganizationAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.AnonymizedStudentEducationOrganizationAssociation.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentEducationOrganizationAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentEducationOrganizationAssociation.EndDate IS 'The end date for the association.';

-- Extended Properties [tpdm].[AnonymizedStudentLanguage] --
COMMENT ON TABLE tpdm.AnonymizedStudentLanguage IS 'The language(s) the individual uses to communicate.';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguage.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguage.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguage.SchoolYear IS 'The school year for which the data is associated';

-- Extended Properties [tpdm].[AnonymizedStudentLanguageUse] --
COMMENT ON TABLE tpdm.AnonymizedStudentLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguageUse.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguageUse.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN tpdm.AnonymizedStudentLanguageUse.SchoolYear IS 'The school year for which the data is associated';

-- Extended Properties [tpdm].[AnonymizedStudentRace] --
COMMENT ON TABLE tpdm.AnonymizedStudentRace IS 'The general racial category which most clearly reflects the individual''s
                   recognition of his or her community or with which the individual most
                   identifies. The data model allows for multiple entries so that each individual
                   can specify all appropriate races.';
COMMENT ON COLUMN tpdm.AnonymizedStudentRace.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentRace.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s
                   recognition of his or her community or with which the individual most
                   identifies. The data model allows for multiple entries so that each individual
                   can specify all appropriate races.';
COMMENT ON COLUMN tpdm.AnonymizedStudentRace.SchoolYear IS 'The school year for which the data is associated';

-- Extended Properties [tpdm].[AnonymizedStudentSectionAssociation] --
COMMENT ON TABLE tpdm.AnonymizedStudentSectionAssociation IS 'Information about the association between an anonymized student and the Section they are enrolled in';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.AnonymizedStudentIdentifier IS 'Unique identifier for anonymized student';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.FactsAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.AnonymizedStudentSectionAssociation.EndDate IS 'The end date for the association';

-- Extended Properties [tpdm].[Applicant] --
COMMENT ON TABLE tpdm.Applicant IS 'A person who makes a formal application for an OpenStaffPosition.';
COMMENT ON COLUMN tpdm.Applicant.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.Applicant.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the person.';
COMMENT ON COLUMN tpdm.Applicant.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.Applicant.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.Applicant.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.Applicant.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN tpdm.Applicant.MaidenName IS 'The person''s maiden name.';
COMMENT ON COLUMN tpdm.Applicant.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN tpdm.Applicant.BirthDate IS 'The month, day, and year on which an individual was born.';
COMMENT ON COLUMN tpdm.Applicant.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino".';
COMMENT ON COLUMN tpdm.Applicant.CitizenshipStatusDescriptorId IS 'An indicator of whether or not the person is a U.S. citizen.';
COMMENT ON COLUMN tpdm.Applicant.LoginId IS 'The login ID for the user; used for security access control interface.';
COMMENT ON COLUMN tpdm.Applicant.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.Applicant.EconomicDisadvantaged IS 'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.';
COMMENT ON COLUMN tpdm.Applicant.FirstGenerationStudent IS 'Indicator of whether individual is a first generation college student.';
COMMENT ON COLUMN tpdm.Applicant.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.Applicant.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.Applicant.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[ApplicantAddress] --
COMMENT ON TABLE tpdm.ApplicantAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN tpdm.ApplicantAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.ApplicantAddress.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.ApplicantAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.ApplicantAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN tpdm.ApplicantAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN tpdm.ApplicantAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN tpdm.ApplicantAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.ApplicantAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.ApplicantAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN tpdm.ApplicantAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [tpdm].[ApplicantAddressPeriod] --
COMMENT ON TABLE tpdm.ApplicantAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN tpdm.ApplicantAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.ApplicantAddressPeriod.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN tpdm.ApplicantAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.ApplicantAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.ApplicantAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [tpdm].[ApplicantAid] --
COMMENT ON TABLE tpdm.ApplicantAid IS 'This entity represents the financial aid a person is awarded.';
COMMENT ON COLUMN tpdm.ApplicantAid.AidTypeDescriptorId IS 'The classification of financial aid awarded to a person for the academic term/year.';
COMMENT ON COLUMN tpdm.ApplicantAid.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantAid.BeginDate IS 'The date the award was designated.';
COMMENT ON COLUMN tpdm.ApplicantAid.EndDate IS 'The date the award was removed.';
COMMENT ON COLUMN tpdm.ApplicantAid.AidConditionDescription IS 'The description of the condition (e.g., placement in a high need school) under which the aid was given.';
COMMENT ON COLUMN tpdm.ApplicantAid.AidAmount IS 'The amount of financial aid awarded to a person for the term/year.';
COMMENT ON COLUMN tpdm.ApplicantAid.PellGrantRecipient IS 'Indicates a person who receives Pell Grant aid.';

-- Extended Properties [tpdm].[ApplicantBackgroundCheck] --
COMMENT ON TABLE tpdm.ApplicantBackgroundCheck IS 'Applicant background check history and disposition.';
COMMENT ON COLUMN tpdm.ApplicantBackgroundCheck.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantBackgroundCheck.BackgroundCheckTypeDescriptorId IS 'The type of background check (e.g., online, criminal, employment).';
COMMENT ON COLUMN tpdm.ApplicantBackgroundCheck.BackgroundCheckRequestedDate IS 'The date the background check was requested.';
COMMENT ON COLUMN tpdm.ApplicantBackgroundCheck.BackgroundCheckStatusDescriptorId IS 'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).';
COMMENT ON COLUMN tpdm.ApplicantBackgroundCheck.BackgroundCheckCompletedDate IS 'The date the background check was completed.';
COMMENT ON COLUMN tpdm.ApplicantBackgroundCheck.Fingerprint IS 'Indicates that a person has or has not completed a fingerprint.';

-- Extended Properties [tpdm].[ApplicantCharacteristic] --
COMMENT ON TABLE tpdm.ApplicantCharacteristic IS 'Reflects important characteristics of the applicant''s home situation:
      Displaced Homemaker, Immigrant, Migratory, Military Parent, Pregnant Teen, Single Parent, and Unaccompanied Youth.';
COMMENT ON COLUMN tpdm.ApplicantCharacteristic.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantCharacteristic.StudentCharacteristicDescriptorId IS 'The characteristic designated for the Student.';
COMMENT ON COLUMN tpdm.ApplicantCharacteristic.BeginDate IS 'The date the characteristic was designated.';
COMMENT ON COLUMN tpdm.ApplicantCharacteristic.EndDate IS 'The date the characteristic was removed.';
COMMENT ON COLUMN tpdm.ApplicantCharacteristic.DesignatedBy IS 'The person, organization, or department that designated the characteristic.';

-- Extended Properties [tpdm].[ApplicantDisability] --
COMMENT ON TABLE tpdm.ApplicantDisability IS 'The disability condition(s) that best describes an individual''s impairment.';
COMMENT ON COLUMN tpdm.ApplicantDisability.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantDisability.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.ApplicantDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN tpdm.ApplicantDisability.OrderOfDisability IS 'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN tpdm.ApplicantDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [tpdm].[ApplicantDisabilityDesignation] --
COMMENT ON TABLE tpdm.ApplicantDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.ApplicantDisabilityDesignation.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.ApplicantDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';

-- Extended Properties [tpdm].[ApplicantElectronicMail] --
COMMENT ON TABLE tpdm.ApplicantElectronicMail IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN tpdm.ApplicantElectronicMail.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantElectronicMail.ElectronicMailAddress IS 'The electronic mail (e-mail) address listed for an individual or organization.';
COMMENT ON COLUMN tpdm.ApplicantElectronicMail.ElectronicMailTypeDescriptorId IS 'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)';
COMMENT ON COLUMN tpdm.ApplicantElectronicMail.PrimaryEmailAddressIndicator IS 'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.';
COMMENT ON COLUMN tpdm.ApplicantElectronicMail.DoNotPublishIndicator IS 'An indication that the electronic email address should not be published.';

-- Extended Properties [tpdm].[ApplicantIdentificationDocument] --
COMMENT ON TABLE tpdm.ApplicantIdentificationDocument IS 'Describe the documentation of citizenship.';
COMMENT ON COLUMN tpdm.ApplicantIdentificationDocument.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.ApplicantIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.ApplicantIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.ApplicantIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.ApplicantIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.ApplicantIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.ApplicantIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[ApplicantInternationalAddress] --
COMMENT ON TABLE tpdm.ApplicantInternationalAddress IS 'The set of elements that describes an international address.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.AddressLine1 IS 'The first line of the address.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.AddressLine2 IS 'The second line of the address.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.AddressLine3 IS 'The third line of the address.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.AddressLine4 IS 'The fourth line of the address.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.CountryDescriptorId IS 'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.BeginDate IS 'The first date the address is valid. For physical addresses, the date the person moved to that address.';
COMMENT ON COLUMN tpdm.ApplicantInternationalAddress.EndDate IS 'The last date the address is valid. For physical addresses, this would be the date the person moved from that address.';

-- Extended Properties [tpdm].[ApplicantLanguage] --
COMMENT ON TABLE tpdm.ApplicantLanguage IS 'The language(s) the individual uses to communicate.';
COMMENT ON COLUMN tpdm.ApplicantLanguage.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';

-- Extended Properties [tpdm].[ApplicantLanguageUse] --
COMMENT ON TABLE tpdm.ApplicantLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN tpdm.ApplicantLanguageUse.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN tpdm.ApplicantLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';

-- Extended Properties [tpdm].[ApplicantPersonalIdentificationDocument] --
COMMENT ON TABLE tpdm.ApplicantPersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN tpdm.ApplicantPersonalIdentificationDocument.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantPersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.ApplicantPersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.ApplicantPersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.ApplicantPersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.ApplicantPersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.ApplicantPersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.ApplicantPersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[ApplicantProspectAssociation] --
COMMENT ON TABLE tpdm.ApplicantProspectAssociation IS 'Associated previously identified prospect.';
COMMENT ON COLUMN tpdm.ApplicantProspectAssociation.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProspectAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicantProspectAssociation.ProspectIdentifier IS 'The identifier for the prospect.';

-- Extended Properties [tpdm].[ApplicantRace] --
COMMENT ON TABLE tpdm.ApplicantRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.ApplicantRace.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';

-- Extended Properties [tpdm].[ApplicantStaffIdentificationCode] --
COMMENT ON TABLE tpdm.ApplicantStaffIdentificationCode IS 'A unique number or alphanumeric code assigned to an applicant by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN tpdm.ApplicantStaffIdentificationCode.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantStaffIdentificationCode.StaffIdentificationSystemDescriptorId IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a staff member.';
COMMENT ON COLUMN tpdm.ApplicantStaffIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code assigned to a staff member by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN tpdm.ApplicantStaffIdentificationCode.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the staff Identification Code.';

-- Extended Properties [tpdm].[ApplicantTeacherPreparationProgram] --
COMMENT ON TABLE tpdm.ApplicantTeacherPreparationProgram IS 'The Teacher Preparation Program(s) completed by the teacher.';
COMMENT ON COLUMN tpdm.ApplicantTeacherPreparationProgram.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantTeacherPreparationProgram.TeacherPreparationProgramName IS 'The name of the Teacher Preparation Program.';
COMMENT ON COLUMN tpdm.ApplicantTeacherPreparationProgram.TeacherPreparationProgramIdentifier IS 'An identifier assigned to the teacher preparation program.';
COMMENT ON COLUMN tpdm.ApplicantTeacherPreparationProgram.TeacherPreparationProgramTypeDescriptorId IS 'The type of teacher prep program (e.g., college, alternative, TFA, etc.).';
COMMENT ON COLUMN tpdm.ApplicantTeacherPreparationProgram.NameOfInstitution IS 'The name of the organization providing the teacher preparation program.';
COMMENT ON COLUMN tpdm.ApplicantTeacherPreparationProgram.MajorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.ApplicantTeacherPreparationProgram.GPA IS 'The final GPA the teacher achieved in the program.';
COMMENT ON COLUMN tpdm.ApplicantTeacherPreparationProgram.LevelOfDegreeAwardedDescriptorId IS 'The level of degree awarded by the teacher preparation program to the person (e.g., Certificate Only, Bachelor''s, Master''s, etc.).';

-- Extended Properties [tpdm].[ApplicantTelephone] --
COMMENT ON TABLE tpdm.ApplicantTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN tpdm.ApplicantTelephone.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN tpdm.ApplicantTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN tpdm.ApplicantTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN tpdm.ApplicantTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN tpdm.ApplicantTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [tpdm].[ApplicantVisa] --
COMMENT ON TABLE tpdm.ApplicantVisa IS 'An indicator of a non-US citizen''s Visa type.';
COMMENT ON COLUMN tpdm.ApplicantVisa.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantVisa.VisaDescriptorId IS 'An indicator of a non-US citizen''s Visa type.';

-- Extended Properties [tpdm].[Application] --
COMMENT ON TABLE tpdm.Application IS 'An application for employment or contract.';
COMMENT ON COLUMN tpdm.Application.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.Application.ApplicationIdentifier IS 'Identifier assigned to the application for an open staff position.';
COMMENT ON COLUMN tpdm.Application.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Application.ApplicationDate IS 'The month, day, and year the application was submitted.';
COMMENT ON COLUMN tpdm.Application.ApplicationStatusDescriptorId IS 'Indicates the current status of the application (e.g., received, phone screen, interview, awaiting decision, etc.).';
COMMENT ON COLUMN tpdm.Application.CurrentEmployee IS 'Indicator as to whether the applicant is a current employee of the school district.';
COMMENT ON COLUMN tpdm.Application.AcademicSubjectDescriptorId IS 'The academic subject for which the application is made.';
COMMENT ON COLUMN tpdm.Application.AcceptedDate IS 'The date of job acceptance, if offered.';
COMMENT ON COLUMN tpdm.Application.ApplicationSourceDescriptorId IS 'Specifies the source for the application (e.g., Job fair, website, referral).';
COMMENT ON COLUMN tpdm.Application.FirstContactDate IS 'Date applicant was first contacted after submitting application.';
COMMENT ON COLUMN tpdm.Application.HighNeedsAcademicSubjectDescriptorId IS 'The high need academic subject for the application, if any.';
COMMENT ON COLUMN tpdm.Application.HireStatusDescriptorId IS 'Indicates the current status of the application for hire (e.g., applied, recommended, rejected, exited, offered, hired).';
COMMENT ON COLUMN tpdm.Application.HiringSourceDescriptorId IS 'The source for the application (e.g.,job fair, website, referral, etc.).';
COMMENT ON COLUMN tpdm.Application.WithdrawDate IS 'The date the application was withdrawn by the applicant.';
COMMENT ON COLUMN tpdm.Application.WithdrawReasonDescriptorId IS 'Reason applicant withdrew application.';
COMMENT ON COLUMN tpdm.Application.HighestCompletedLevelOfEducationDescriptorId IS 'The extent of formal instruction an individual has received (e.g., the highest grade in school completed or its equivalent or the highest degree received).';
COMMENT ON COLUMN tpdm.Application.YearsOfPriorProfessionalExperience IS 'The total number of years that an individual has previously held a similar professional position in one or more education institutions.';
COMMENT ON COLUMN tpdm.Application.YearsOfPriorTeachingExperience IS 'The total number of years that an individual has previously held a teaching position in one or more education institutions.';
COMMENT ON COLUMN tpdm.Application.HighlyQualifiedTeacher IS 'An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.';
COMMENT ON COLUMN tpdm.Application.HighlyQualifiedAcademicSubjectDescriptorId IS 'The academic subject(s) in which the staff is deemed to be "highly qualified".';

-- Extended Properties [tpdm].[ApplicationEvent] --
COMMENT ON TABLE tpdm.ApplicationEvent IS 'The life cycle events associated with an application (phone screen, review, interview, etc.).';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicationEventTypeDescriptorId IS 'Description of application event (e.g., added to pool, phone screen, interview, sample lesson).';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicationIdentifier IS 'Identifier assigned to the application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationEvent.EventDate IS 'The date of the application event, or begin date if an interval.';
COMMENT ON COLUMN tpdm.ApplicationEvent.SequenceNumber IS 'The sequence number of the application events. This is used to discriminate between mutiple events of the same type in the same day.';
COMMENT ON COLUMN tpdm.ApplicationEvent.EventEndDate IS 'The end date of the event, if an interval.';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicationEvaluationScore IS 'Application evaluation score, if applicable.';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicationEventResultDescriptorId IS 'The recommendation, result or conclusion of the application event (e.g., Continue, exit, recommend for hire).';
COMMENT ON COLUMN tpdm.ApplicationEvent.SchoolYear IS 'Identifier for a school year.';
COMMENT ON COLUMN tpdm.ApplicationEvent.TermDescriptorId IS 'This descriptor defines the term of a session during the school year (e.g., Fall Semester).';

-- Extended Properties [tpdm].[ApplicationEventResultDescriptor] --
COMMENT ON TABLE tpdm.ApplicationEventResultDescriptor IS 'The descriptor holds the recommendation, result or conclusion of the application event (e.g., Continue, exit, recommend for hire).';
COMMENT ON COLUMN tpdm.ApplicationEventResultDescriptor.ApplicationEventResultDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicationEventTypeDescriptor] --
COMMENT ON TABLE tpdm.ApplicationEventTypeDescriptor IS 'The descriptor holds the description of application event (e.g., added to pool, phone screen, interview, sample lesson).';
COMMENT ON COLUMN tpdm.ApplicationEventTypeDescriptor.ApplicationEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicationGradePointAverage] --
COMMENT ON TABLE tpdm.ApplicationGradePointAverage IS 'Data that provides information on a measure of average performance in a group of courses taken by an individual.';
COMMENT ON COLUMN tpdm.ApplicationGradePointAverage.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationGradePointAverage.ApplicationIdentifier IS 'Identifier assigned to the application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationGradePointAverage.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationGradePointAverage.GradePointAverageTypeDescriptorId IS 'The system used for calculating the grade point average for an individual.';
COMMENT ON COLUMN tpdm.ApplicationGradePointAverage.IsCumulative IS 'Indicator of whether or not the Grade Point Average value is cumulative.';
COMMENT ON COLUMN tpdm.ApplicationGradePointAverage.GradePointAverageValue IS 'The value of the grade points earned divided by the number of credits attempted.';
COMMENT ON COLUMN tpdm.ApplicationGradePointAverage.MaxGradePointAverageValue IS 'The maximum value for the grade point average.';

-- Extended Properties [tpdm].[ApplicationOpenStaffPosition] --
COMMENT ON TABLE tpdm.ApplicationOpenStaffPosition IS 'The open staff position(s) associated with the application.';
COMMENT ON COLUMN tpdm.ApplicationOpenStaffPosition.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationOpenStaffPosition.ApplicationIdentifier IS 'Identifier assigned to the application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationOpenStaffPosition.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationOpenStaffPosition.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';

-- Extended Properties [tpdm].[ApplicationScoreResult] --
COMMENT ON TABLE tpdm.ApplicationScoreResult IS 'A meaningful score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.ApplicationIdentifier IS 'Identifier assigned to the application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.AssessmentReportingMethodDescriptorId IS 'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.Result IS 'The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[ApplicationSourceDescriptor] --
COMMENT ON TABLE tpdm.ApplicationSourceDescriptor IS 'The descriptor holds the source for the application (e.g., Job fair, website, referral).';
COMMENT ON COLUMN tpdm.ApplicationSourceDescriptor.ApplicationSourceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicationStatusDescriptor] --
COMMENT ON TABLE tpdm.ApplicationStatusDescriptor IS 'The descriptor holds the current status of the application (e.g., received, phone screen, interview, awaiting decision, etc.).';
COMMENT ON COLUMN tpdm.ApplicationStatusDescriptor.ApplicationStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicationTerm] --
COMMENT ON TABLE tpdm.ApplicationTerm IS 'The intended term of enrollment for which the application is being submitted.';
COMMENT ON COLUMN tpdm.ApplicationTerm.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationTerm.ApplicationIdentifier IS 'Identifier assigned to the application for an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationTerm.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationTerm.TermDescriptorId IS 'The intended term of enrollment for which the application is being submitted.';

-- Extended Properties [tpdm].[AssessmentExtension] --
COMMENT ON TABLE tpdm.AssessmentExtension IS '';
COMMENT ON COLUMN tpdm.AssessmentExtension.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN tpdm.AssessmentExtension.Namespace IS 'Namespace for the Assessment.';
COMMENT ON COLUMN tpdm.AssessmentExtension.ProgramGatewayDescriptorId IS 'Identifies the program gateway an assessment may be associated with for continuation in the program.';

-- Extended Properties [tpdm].[BackgroundCheckStatusDescriptor] --
COMMENT ON TABLE tpdm.BackgroundCheckStatusDescriptor IS 'This descriptor holds the  status of the background check (e.g., pending, under investigation, offense(s) found, etc.).';
COMMENT ON COLUMN tpdm.BackgroundCheckStatusDescriptor.BackgroundCheckStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[BackgroundCheckTypeDescriptor] --
COMMENT ON TABLE tpdm.BackgroundCheckTypeDescriptor IS 'This descriptor defines the classification of the background check a person receives.';
COMMENT ON COLUMN tpdm.BackgroundCheckTypeDescriptor.BackgroundCheckTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Certification] --
COMMENT ON TABLE tpdm.Certification IS 'An offering by an official granting authority of a certification or license that qualifies persons to perform specific job functions, such as full fill a teaching assignment.';
COMMENT ON COLUMN tpdm.Certification.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.Certification.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.Certification.CertificationTitle IS 'The title of the Certification.';
COMMENT ON COLUMN tpdm.Certification.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Certification.CertificationLevelDescriptorId IS 'The level (e.g., Elementary, Secondary) or category (administrative, specialist) of the Certification.';
COMMENT ON COLUMN tpdm.Certification.CertificationFieldDescriptorId IS 'The field of certification (e.g., Mathematics, Music).';
COMMENT ON COLUMN tpdm.Certification.CertificationStandardDescriptorId IS 'The standard, law or policy defining the certification.';
COMMENT ON COLUMN tpdm.Certification.MinimumDegreeDescriptorId IS 'The minimum level of degree, if any, required for Certification.';
COMMENT ON COLUMN tpdm.Certification.EducatorRoleDescriptorId IS 'The role authorized by the Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.';
COMMENT ON COLUMN tpdm.Certification.PopulationServedDescriptorId IS 'The type of students the Section is offered and tailored to; for example: Bilingual students, Remedial education students, Gifted and talented students, Career and Technical Education students, Special education students.';
COMMENT ON COLUMN tpdm.Certification.InstructionalSettingDescriptorId IS 'The setting authorized by the Certification in which a child receives education and related services; for example: Classroom, Virtual, Vocational.';
COMMENT ON COLUMN tpdm.Certification.EffectiveDate IS 'The year, month and day on which the Certification is offered.';
COMMENT ON COLUMN tpdm.Certification.EndDate IS 'The month, day, and year on which the Certification offering is expected to end.';

-- Extended Properties [tpdm].[CertificationCertificationExam] --
COMMENT ON TABLE tpdm.CertificationCertificationExam IS 'The Certification Eams required for the Certification.';
COMMENT ON COLUMN tpdm.CertificationCertificationExam.CertificationExamIdentifier IS 'Identifier or serial number assigned to the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationCertificationExam.CertificationExamNamespace IS 'Namespace for the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationCertificationExam.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.CertificationCertificationExam.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';

-- Extended Properties [tpdm].[CertificationExam] --
COMMENT ON TABLE tpdm.CertificationExam IS 'An examination required by one or more Certifications.';
COMMENT ON COLUMN tpdm.CertificationExam.CertificationExamIdentifier IS 'Identifier or serial number assigned to the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationExam.Namespace IS 'Namespace for the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationExam.CertificationExamTitle IS 'The title of the Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExam.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CertificationExam.CertificationExamTypeDescriptorId IS 'The type or category of Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExam.EffectiveDate IS 'The year, month and day on which the CertificationExam is offered.';
COMMENT ON COLUMN tpdm.CertificationExam.EndDate IS 'The month, day, and year on which the CertificationExam offering is expected to end.';

-- Extended Properties [tpdm].[CertificationExamResult] --
COMMENT ON TABLE tpdm.CertificationExamResult IS 'The person''s result from taking a Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamDate IS 'The year, month and day on which the CertificationExam is taken.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamIdentifier IS 'Identifier or serial number assigned to the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.Namespace IS 'Namespace for the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.CertificationExamResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.CertificationExamResult.AttemptNumber IS 'The number of the person''s attempt for the Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamScore IS 'The score result for the Certification Exam attempt.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamPassIndicator IS 'Indicator that the person passed the Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamStatusDescriptorId IS 'The status of the Certification Exam attempt.';

-- Extended Properties [tpdm].[CertificationExamStatusDescriptor] --
COMMENT ON TABLE tpdm.CertificationExamStatusDescriptor IS 'The status of the exam.';
COMMENT ON COLUMN tpdm.CertificationExamStatusDescriptor.CertificationExamStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationExamTypeDescriptor] --
COMMENT ON TABLE tpdm.CertificationExamTypeDescriptor IS 'The descriptor holds the type of certification exam that was taken.';
COMMENT ON COLUMN tpdm.CertificationExamTypeDescriptor.CertificationExamTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationFieldDescriptor] --
COMMENT ON TABLE tpdm.CertificationFieldDescriptor IS 'The field of certification for the credential (e.g., Mathematics, Music).';
COMMENT ON COLUMN tpdm.CertificationFieldDescriptor.CertificationFieldDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationGradeLevel] --
COMMENT ON TABLE tpdm.CertificationGradeLevel IS 'The grade level(s) certified for teaching.';
COMMENT ON COLUMN tpdm.CertificationGradeLevel.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.CertificationGradeLevel.GradeLevelDescriptorId IS 'The grade level(s) certified for teaching.';
COMMENT ON COLUMN tpdm.CertificationGradeLevel.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';

-- Extended Properties [tpdm].[CertificationLevelDescriptor] --
COMMENT ON TABLE tpdm.CertificationLevelDescriptor IS 'The level (e.g., Elementary, Secondary) or category (administrative, specialist) of the Certification.';
COMMENT ON COLUMN tpdm.CertificationLevelDescriptor.CertificationLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationRoute] --
COMMENT ON TABLE tpdm.CertificationRoute IS 'The process, program ,or pathway used to obtain certification.';
COMMENT ON COLUMN tpdm.CertificationRoute.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.CertificationRoute.CertificationRouteDescriptorId IS 'The process, program ,or pathway used to obtain certification.';
COMMENT ON COLUMN tpdm.CertificationRoute.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';

-- Extended Properties [tpdm].[CertificationRouteDescriptor] --
COMMENT ON TABLE tpdm.CertificationRouteDescriptor IS 'The process, program ,or pathway used to obtain a certification.';
COMMENT ON COLUMN tpdm.CertificationRouteDescriptor.CertificationRouteDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationStandardDescriptor] --
COMMENT ON TABLE tpdm.CertificationStandardDescriptor IS 'The standard, law or policy defining the certification.';
COMMENT ON COLUMN tpdm.CertificationStandardDescriptor.CertificationStandardDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CompleterAsStaffAssociation] --
COMMENT ON TABLE tpdm.CompleterAsStaffAssociation IS 'This describes a teacher candidate who has completed a teacher prep program and is considered a completer who is now also employed as a staff member in a partnering K12 district.  This is the same person but may have two different identifiers, one as a (former) teacher candidate and one as an employed staff person.';
COMMENT ON COLUMN tpdm.CompleterAsStaffAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.CompleterAsStaffAssociation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';

-- Extended Properties [tpdm].[CoteachingStyleObservedDescriptor] --
COMMENT ON TABLE tpdm.CoteachingStyleObservedDescriptor IS 'A type of co-teaching observed as part of the performance evaluation.';
COMMENT ON COLUMN tpdm.CoteachingStyleObservedDescriptor.CoteachingStyleObservedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CredentialEvent] --
COMMENT ON TABLE tpdm.CredentialEvent IS 'An event associated with a person''s Credential (e.g, suspension, revocation, or renewal).';
COMMENT ON COLUMN tpdm.CredentialEvent.CredentialEventDate IS 'The year, month and day of the Credential Event.';
COMMENT ON COLUMN tpdm.CredentialEvent.CredentialEventTypeDescriptorId IS 'The type of event associated with a person''s Credential (e.g, suspension, revocation, or renewal).';
COMMENT ON COLUMN tpdm.CredentialEvent.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN tpdm.CredentialEvent.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN tpdm.CredentialEvent.CredentialEventReason IS 'The reason for the credential event, or any other descriptive text.';

-- Extended Properties [tpdm].[CredentialEventTypeDescriptor] --
COMMENT ON TABLE tpdm.CredentialEventTypeDescriptor IS 'The type of event associated with a person''s Credential (e.g, suspension, revocation, or renewal).';
COMMENT ON COLUMN tpdm.CredentialEventTypeDescriptor.CredentialEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CredentialExtension] --
COMMENT ON TABLE tpdm.CredentialExtension IS '';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN tpdm.CredentialExtension.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN tpdm.CredentialExtension.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.CredentialExtension.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.CredentialExtension.CertificationTitle IS 'The title of the certification obtained by the educator.';
COMMENT ON COLUMN tpdm.CredentialExtension.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.CredentialExtension.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.CredentialExtension.CertificationRouteDescriptorId IS 'The process, program, or pathway used to obtain certification.';
COMMENT ON COLUMN tpdm.CredentialExtension.BoardCertificationIndicator IS 'Indicator that the credential was granted under the authority of a national Board Certification.';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialStatusDescriptorId IS 'The most recent status of the credential (e.g., active, suspended, etc.).';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialStatusDate IS 'The month, day, and year on which the credential status was effective.';

-- Extended Properties [tpdm].[CredentialStatusDescriptor] --
COMMENT ON TABLE tpdm.CredentialStatusDescriptor IS 'The most recent status of the credential (e.g., active, suspended, etc.).';
COMMENT ON COLUMN tpdm.CredentialStatusDescriptor.CredentialStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CredentialStudentAcademicRecord] --
COMMENT ON TABLE tpdm.CredentialStudentAcademicRecord IS 'Reference to the person''s Student Academic Records for the school(s) with which the Credential is associated.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[DegreeDescriptor] --
COMMENT ON TABLE tpdm.DegreeDescriptor IS 'The minimum level of degree, if any, required for Certification.';
COMMENT ON COLUMN tpdm.DegreeDescriptor.DegreeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EducatorRoleDescriptor] --
COMMENT ON TABLE tpdm.EducatorRoleDescriptor IS 'The role authorized by the Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.';
COMMENT ON COLUMN tpdm.EducatorRoleDescriptor.EducatorRoleDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EmploymentEvent] --
COMMENT ON TABLE tpdm.EmploymentEvent IS 'The event associated with hiring staff for employment (or contract).';
COMMENT ON COLUMN tpdm.EmploymentEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EmploymentEvent.EmploymentEventTypeDescriptorId IS 'The type of the employment event (e.g., transfer, new hire, title change).';
COMMENT ON COLUMN tpdm.EmploymentEvent.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';
COMMENT ON COLUMN tpdm.EmploymentEvent.HireDate IS 'The month, day, and year on which an individual was hired for a position.';
COMMENT ON COLUMN tpdm.EmploymentEvent.EarlyHire IS 'Indicator of whether this was an early hire.';
COMMENT ON COLUMN tpdm.EmploymentEvent.InternalExternalHireDescriptorId IS 'Indicates whether the hire was an internal or external person.';
COMMENT ON COLUMN tpdm.EmploymentEvent.MutualConsent IS 'Indicator of whether this was a mutual consent hire.';
COMMENT ON COLUMN tpdm.EmploymentEvent.RestrictedChoice IS 'Indicator of whether this was a restricted choice hire.';

-- Extended Properties [tpdm].[EmploymentEventTypeDescriptor] --
COMMENT ON TABLE tpdm.EmploymentEventTypeDescriptor IS 'The descriptor holds the type of the employment event (e.g., transfer, new hire, title change).';
COMMENT ON COLUMN tpdm.EmploymentEventTypeDescriptor.EmploymentEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EmploymentSeparationEvent] --
COMMENT ON TABLE tpdm.EmploymentSeparationEvent IS 'The separation event that triggered an end to an employment or contractual relationship.';
COMMENT ON COLUMN tpdm.EmploymentSeparationEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EmploymentSeparationEvent.EmploymentSeparationDate IS 'Effective date of the separation.';
COMMENT ON COLUMN tpdm.EmploymentSeparationEvent.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';
COMMENT ON COLUMN tpdm.EmploymentSeparationEvent.EmploymentSeparationTypeDescriptorId IS 'The type of separation (e.g., termination, displacement, retirement, transfer, voluntary departure).';
COMMENT ON COLUMN tpdm.EmploymentSeparationEvent.EmploymentSeparationEnteredDate IS 'The date the separation event was first entered or when notice was given.';
COMMENT ON COLUMN tpdm.EmploymentSeparationEvent.EmploymentSeparationReasonDescriptorId IS 'The reason(s) for the separation.';
COMMENT ON COLUMN tpdm.EmploymentSeparationEvent.RemainingInDistrict IS 'Whether a teacher is leaving a school but remaining within the district, or leaving the district entirely.';

-- Extended Properties [tpdm].[EmploymentSeparationReasonDescriptor] --
COMMENT ON TABLE tpdm.EmploymentSeparationReasonDescriptor IS 'The descriptor holds the reason(s) for the separation.';
COMMENT ON COLUMN tpdm.EmploymentSeparationReasonDescriptor.EmploymentSeparationReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EmploymentSeparationTypeDescriptor] --
COMMENT ON TABLE tpdm.EmploymentSeparationTypeDescriptor IS 'The descriptor holds the type of separation (e.g., termination, displacement, retirement, transfer, voluntary departure).';
COMMENT ON COLUMN tpdm.EmploymentSeparationTypeDescriptor.EmploymentSeparationTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EnglishLanguageExamDescriptor] --
COMMENT ON TABLE tpdm.EnglishLanguageExamDescriptor IS 'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).';
COMMENT ON COLUMN tpdm.EnglishLanguageExamDescriptor.EnglishLanguageExamDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Evaluation] --
COMMENT ON TABLE tpdm.Evaluation IS 'An evaluation instrument appled to evaluate an educator.  The evaluation could be internally developed, or could be an industry recognized instrument such as TTESS or Marzano.';
COMMENT ON COLUMN tpdm.Evaluation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.Evaluation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.Evaluation.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.Evaluation.MinRating IS 'The minimum summary numerical rating or score for the evaluation. If omitted, assumed to be 0.0.';
COMMENT ON COLUMN tpdm.Evaluation.MaxRating IS 'The maximum summary numerical rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationTypeDescriptorId IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';
COMMENT ON COLUMN tpdm.Evaluation.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.';

-- Extended Properties [tpdm].[EvaluationElement] --
COMMENT ON TABLE tpdm.EvaluationElement IS 'The lowest-level Elements or criterion of performance being evaluated by rubric, quantitative measure, or aggregate survey response.';
COMMENT ON COLUMN tpdm.EvaluationElement.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElement.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElement.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElement.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElement.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElement.SortOrder IS 'The sort order of this Evaluation Element.';
COMMENT ON COLUMN tpdm.EvaluationElement.MinRating IS 'The minimum summary numerical rating or score for the evaluation element. If omitted, assumed to be 0.0.';
COMMENT ON COLUMN tpdm.EvaluationElement.MaxRating IS 'The maximum summary numerical rating or score for the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationTypeDescriptorId IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';

-- Extended Properties [tpdm].[EvaluationElementRating] --
COMMENT ON TABLE tpdm.EvaluationElementRating IS 'The lowest-level rating for an Evaluation Element for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationElementRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.AreaOfRefinement IS 'Area(s) identified for person to refine or improve as part of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.AreaOfReinforcement IS 'Area(s) identified for reinforcement or positive feedback as part of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.Comments IS 'Any comments about the performance evaluation to be captured.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.Feedback IS 'Feedback provided to the evaluated person.';

-- Extended Properties [tpdm].[EvaluationElementRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationElementRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationElementRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.EvaluationElementRatingLevelDescriptor IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevelDescriptor.EvaluationElementRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationElementRatingResult] --
COMMENT ON TABLE tpdm.EvaluationElementRatingResult IS 'The numerical summary rating or score for the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[EvaluationObjective] --
COMMENT ON TABLE tpdm.EvaluationObjective IS 'A subcomponent of an Evaluation, a specific educator Objective or domain of performance that is being evaluated.  ';
COMMENT ON COLUMN tpdm.EvaluationObjective.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjective.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjective.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjective.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjective.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjective.SortOrder IS 'The sort order of this Evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.MinRating IS 'The minimum summary numerical rating or score for the evaluation Objective. If omitted, assumed to be 0.0.';
COMMENT ON COLUMN tpdm.EvaluationObjective.MaxRating IS 'The maximum summary numerical rating or score for the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationTypeDescriptorId IS 'The type of the evaluation Objective (e.g., observation, principal, peer, student survey, student growth).';

-- Extended Properties [tpdm].[EvaluationObjectiveRating] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRating IS 'The rating for the component Evaluation Objective for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.ObjectiveRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.Comments IS 'Any comments about the performance evaluation to be captured.';

-- Extended Properties [tpdm].[EvaluationObjectiveRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationObjectiveRatingResult] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRatingResult IS 'The numerical summary rating or score for the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[EvaluationPeriodDescriptor] --
COMMENT ON TABLE tpdm.EvaluationPeriodDescriptor IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationPeriodDescriptor.EvaluationPeriodDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationRating] --
COMMENT ON TABLE tpdm.EvaluationRating IS 'The summary weighting for the Evaluation instrument for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationRating.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.EvaluationRating.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.EvaluationRating.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.EvaluationRating.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [tpdm].[EvaluationRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.EvaluationRatingLevelDescriptor IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevelDescriptor.EvaluationRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationRatingResult] --
COMMENT ON TABLE tpdm.EvaluationRatingResult IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[EvaluationRatingReviewer] --
COMMENT ON TABLE tpdm.EvaluationRatingReviewer IS 'The person(s) that conducted the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[EvaluationRatingReviewerReceivedTraining] --
COMMENT ON TABLE tpdm.EvaluationRatingReviewerReceivedTraining IS 'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.ReceivedTrainingDate IS 'The date on which the person administering the performance meausre received training on how to conduct performance measures.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.';

-- Extended Properties [tpdm].[EvaluationTypeDescriptor] --
COMMENT ON TABLE tpdm.EvaluationTypeDescriptor IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';
COMMENT ON COLUMN tpdm.EvaluationTypeDescriptor.EvaluationTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[FederalLocaleCodeDescriptor] --
COMMENT ON TABLE tpdm.FederalLocaleCodeDescriptor IS 'The descriptor holds the federal locale code applicable to an education organization.';
COMMENT ON COLUMN tpdm.FederalLocaleCodeDescriptor.FederalLocaleCodeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[FieldworkExperience] --
COMMENT ON TABLE tpdm.FieldworkExperience IS 'The information regarding a postsecondary instructional course in a particular field of study that typically involves a prescribed number or instruction periods or meetings for enrolled students.';
COMMENT ON COLUMN tpdm.FieldworkExperience.BeginDate IS 'The month, day, and year on which the staff first starts fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperience.FieldworkIdentifier IS 'The unique identifier for the fieldwork experience';
COMMENT ON COLUMN tpdm.FieldworkExperience.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.FieldworkExperience.FieldworkTypeDescriptorId IS 'The type of fieldwork being executed by a staff.';
COMMENT ON COLUMN tpdm.FieldworkExperience.HoursCompleted IS 'The number of hours completed during the fieldwork experience.';
COMMENT ON COLUMN tpdm.FieldworkExperience.EndDate IS 'The month, day, and year on which the staff ends fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperience.ProgramGatewayDescriptorId IS 'The descriptor holds the program gateway that is associated with continuation in a program.';

-- Extended Properties [tpdm].[FieldworkExperienceCoteaching] --
COMMENT ON TABLE tpdm.FieldworkExperienceCoteaching IS 'The act of two teachers (teacher candidate and cooperating teacher) working together with groups of students; sharing the planning, organization, delivery, and assessment of instruction, as well as the physical space.';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.BeginDate IS 'The month, day, and year on which the staff first starts fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.FieldworkIdentifier IS 'The unique identifier for the fieldwork experience';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.CoteachingBeginDate IS 'The month, day, and year on which the teacher candidate first starts co-teaching.';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.CoteachingEndDate IS 'The month, day, and year on which the teacher candidate stopped co-teaching.';

-- Extended Properties [tpdm].[FieldworkExperienceSchool] --
COMMENT ON TABLE tpdm.FieldworkExperienceSchool IS 'The school the field work experience is associated with';
COMMENT ON COLUMN tpdm.FieldworkExperienceSchool.BeginDate IS 'The month, day, and year on which the staff first starts fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSchool.FieldworkIdentifier IS 'The unique identifier for the fieldwork experience';
COMMENT ON COLUMN tpdm.FieldworkExperienceSchool.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSchool.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [tpdm].[FieldworkExperienceSectionAssociation] --
COMMENT ON TABLE tpdm.FieldworkExperienceSectionAssociation IS 'The section the field work experience is associated with.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.BeginDate IS 'The month, day, and year on which the staff first starts fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.FieldworkIdentifier IS 'The unique identifier for the fieldwork experience';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [tpdm].[FieldworkTypeDescriptor] --
COMMENT ON TABLE tpdm.FieldworkTypeDescriptor IS 'The descriptor holds the type of fieldwork being executed by a teacher candidate.';
COMMENT ON COLUMN tpdm.FieldworkTypeDescriptor.FieldworkTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[FundingSourceDescriptor] --
COMMENT ON TABLE tpdm.FundingSourceDescriptor IS 'The descriptor holds the funding source (e.g., federal, district).';
COMMENT ON COLUMN tpdm.FundingSourceDescriptor.FundingSourceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[GenderDescriptor] --
COMMENT ON TABLE tpdm.GenderDescriptor IS 'The gender with with a person associates.';
COMMENT ON COLUMN tpdm.GenderDescriptor.GenderDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Goal] --
COMMENT ON TABLE tpdm.Goal IS 'Goal for performance improvement assigned to an educator associated with an Evaluation Element.';
COMMENT ON COLUMN tpdm.Goal.AssignmentDate IS 'The month, day, and year on which the goal was assigned.';
COMMENT ON COLUMN tpdm.Goal.GoalTitle IS 'The name or title of the goal.';
COMMENT ON COLUMN tpdm.Goal.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.Goal.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.Goal.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.Goal.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.Goal.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.Goal.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.Goal.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.Goal.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Goal.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.Goal.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.Goal.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.Goal.GoalTypeDescriptorId IS 'The type of the goal (e.g., management, instruction).';
COMMENT ON COLUMN tpdm.Goal.GoalDescription IS 'The description of the goal.';
COMMENT ON COLUMN tpdm.Goal.DueDate IS 'The month, day, and year on which the goal is due or expected to be completed.';
COMMENT ON COLUMN tpdm.Goal.CompletedIndicator IS 'Indicator that the goal was completed.';
COMMENT ON COLUMN tpdm.Goal.CompletedDate IS 'The month, day, and year on which the goal was completed.';
COMMENT ON COLUMN tpdm.Goal.Comments IS 'Any comments about the goal or its completion to be captured.';

-- Extended Properties [tpdm].[GoalTypeDescriptor] --
COMMENT ON TABLE tpdm.GoalTypeDescriptor IS 'The type of the goal (e.g., management, instruction).';
COMMENT ON COLUMN tpdm.GoalTypeDescriptor.GoalTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[GraduationPlanRequiredCertification] --
COMMENT ON TABLE tpdm.GraduationPlanRequiredCertification IS 'The title or reference to the certifiation(s) required for graduation.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.CertificationTitle IS 'The title of the Certification required for Graduation.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.CertificationRouteDescriptorId IS 'The process, program ,or pathway used to obtain certification.';

-- Extended Properties [tpdm].[HireStatusDescriptor] --
COMMENT ON TABLE tpdm.HireStatusDescriptor IS 'The descriptor holds the current status of the application for hire (e.g., applied, recommended, rejected, exited, offered, hired).';
COMMENT ON COLUMN tpdm.HireStatusDescriptor.HireStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[HiringSourceDescriptor] --
COMMENT ON TABLE tpdm.HiringSourceDescriptor IS 'The descriptor holds the source for the application (e.g.,job fair, website, referral, etc.).';
COMMENT ON COLUMN tpdm.HiringSourceDescriptor.HiringSourceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[InstructionalSettingDescriptor] --
COMMENT ON TABLE tpdm.InstructionalSettingDescriptor IS 'The setting authorized by the Certification in which a child receives education and related services; for example: Classroom, Virtual, Vocational.';
COMMENT ON COLUMN tpdm.InstructionalSettingDescriptor.InstructionalSettingDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[InternalExternalHireDescriptor] --
COMMENT ON TABLE tpdm.InternalExternalHireDescriptor IS 'Indicates whether the hire was an internal or external person.';
COMMENT ON COLUMN tpdm.InternalExternalHireDescriptor.InternalExternalHireDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[LevelOfDegreeAwardedDescriptor] --
COMMENT ON TABLE tpdm.LevelOfDegreeAwardedDescriptor IS 'The descriptor holds the level of degree awarded by the teacher prep program to the person (e.g., Certificate Only, Bachelor''s, Master''s, etc.).';
COMMENT ON COLUMN tpdm.LevelOfDegreeAwardedDescriptor.LevelOfDegreeAwardedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[LocalEducationAgencyExtension] --
COMMENT ON TABLE tpdm.LocalEducationAgencyExtension IS '';
COMMENT ON COLUMN tpdm.LocalEducationAgencyExtension.LocalEducationAgencyId IS 'The identifier assigned to a local education agency.';
COMMENT ON COLUMN tpdm.LocalEducationAgencyExtension.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';

-- Extended Properties [tpdm].[ObjectiveRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.ObjectiveRatingLevelDescriptor IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.ObjectiveRatingLevelDescriptor.ObjectiveRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[OpenStaffPositionEvent] --
COMMENT ON TABLE tpdm.OpenStaffPositionEvent IS 'Reflects milestones like vacancy approved, vacancy posted, date onboarded, processing date, orientation date, etc.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.EventDate IS 'Date of the open staff position event.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.OpenStaffPositionEventTypeDescriptorId IS 'Reflects milestones like vacancy approved, vacancy posted, date onboarded, processing date, orientation date, etc.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.OpenStaffPositionEventStatusDescriptorId IS 'Reflects the status of the milestone (e.g., pending, completed, cancelled).';

-- Extended Properties [tpdm].[OpenStaffPositionEventStatusDescriptor] --
COMMENT ON TABLE tpdm.OpenStaffPositionEventStatusDescriptor IS 'The descriptor holds the status of the milestone (e.g., pending, completed, cancelled).';
COMMENT ON COLUMN tpdm.OpenStaffPositionEventStatusDescriptor.OpenStaffPositionEventStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[OpenStaffPositionEventTypeDescriptor] --
COMMENT ON TABLE tpdm.OpenStaffPositionEventTypeDescriptor IS 'The descriptor holds the milestones like vacancy approved, vacancy posted, date onboarded. processing date, orientation date  etc.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEventTypeDescriptor.OpenStaffPositionEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[OpenStaffPositionExtension] --
COMMENT ON TABLE tpdm.OpenStaffPositionExtension IS '';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.SchoolYear IS 'The identifier for the school year for which the OpenStaffPosition is seeking to fill.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.FullTimeEquivalency IS 'The ratio between the hours of work expected in a position and the hours of work normally expected in a full-time position in the same setting.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.OpenStaffPositionReasonDescriptorId IS 'The reason for the open staff position (e.g., new position, replacement, etc.).';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.IsActive IS 'Indicator of whether the OpenStaffPosition is currently Active.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.MaxSalary IS 'The maximum salary or wage a person is paid before deductions (excluding differentials) but including annuities.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.MinSalary IS 'The minimum salary or wage a person is paid before deductions (excluding differentials) but including annuities.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.FundingSourceDescriptorId IS 'The funding source for open staff position.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.HighNeedAcademicSubject IS 'Indicator as to whether the OpenStaffPosition is filling a high-need subject area designated as a teacher shortage that may be eligible for special grants, aid or compensation.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.PositionControlNumber IS 'Identifier assigned to the position to be filled.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.TermDescriptorId IS 'The first term for the Session during the school year for which the OpenStaffPosition is seeking to fill.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.TotalBudgeted IS 'Including salary, the fully loaded cost budgeted for this teacher.';

-- Extended Properties [tpdm].[OpenStaffPositionReasonDescriptor] --
COMMENT ON TABLE tpdm.OpenStaffPositionReasonDescriptor IS 'The descriptor holds the reason for the open staff position (e.g., new position, replacement, etc.).';
COMMENT ON COLUMN tpdm.OpenStaffPositionReasonDescriptor.OpenStaffPositionReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[PerformanceEvaluation] --
COMMENT ON TABLE tpdm.PerformanceEvaluation IS 'A performance evaluation of an educator, typically regularly scheduled and uniformly applied, comporsed of one or more Evaluations.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.AcademicSubjectDescriptorId IS 'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a performance evaluation.';

-- Extended Properties [tpdm].[PerformanceEvaluationGradeLevel] --
COMMENT ON TABLE tpdm.PerformanceEvaluationGradeLevel IS 'The grade levels involved with the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.GradeLevelDescriptorId IS 'The grade levels involved with the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[PerformanceEvaluationProgramGateway] --
COMMENT ON TABLE tpdm.PerformanceEvaluationProgramGateway IS 'Identifies the program gateway that may be associated for continuation in the program.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.ProgramGatewayDescriptorId IS 'Identifies the program gateway that may be associated for continuation in the program.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[PerformanceEvaluationRating] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRating IS 'The summary rating for a Performance Evaluation across all Evaluation instruments for an individual educator.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualDate IS 'The month, day, and year on which the performance evaluation was conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.Announced IS 'An indicator of whether the performance evaluation was announced or not.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.Comments IS 'Any comments about the performance evaluation to be captured.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.CoteachingStyleObservedDescriptorId IS 'A type of co-teaching observed as part of the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualDuration IS 'The actual or estimated number of clock minutes during which the performance evaluation was conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ScheduleDate IS 'The month, day, and year on which the performance evaluation was to be conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualTime IS 'An indication of the the time at which the performance evaluation was conducted.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevel] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingLevelDescriptor IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevelDescriptor.PerformanceEvaluationRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingResult] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingResult IS 'The numerical summary rating or score for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewer] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingReviewer IS 'The person(s) that conducted the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingReviewerReceivedTraining IS 'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.ReceivedTrainingDate IS 'The date on which the person administering the performance meausre received training on how to conduct performance measures.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.';

-- Extended Properties [tpdm].[PerformanceEvaluationTypeDescriptor] --
COMMENT ON TABLE tpdm.PerformanceEvaluationTypeDescriptor IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationTypeDescriptor.PerformanceEvaluationTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[PostSecondaryInstitutionExtension] --
COMMENT ON TABLE tpdm.PostSecondaryInstitutionExtension IS '';
COMMENT ON COLUMN tpdm.PostSecondaryInstitutionExtension.PostSecondaryInstitutionId IS 'The ID of the post secondary institution.';
COMMENT ON COLUMN tpdm.PostSecondaryInstitutionExtension.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';

-- Extended Properties [tpdm].[PreviousCareerDescriptor] --
COMMENT ON TABLE tpdm.PreviousCareerDescriptor IS 'The descriptor holds the previous career of an individual.';
COMMENT ON COLUMN tpdm.PreviousCareerDescriptor.PreviousCareerDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ProfessionalDevelopmentEvent] --
COMMENT ON TABLE tpdm.ProfessionalDevelopmentEvent IS 'Information about a professional development event.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.Namespace IS 'Namespace for the event, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.ProfessionalDevelopmentTitle IS 'The title or name for a professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.ProfessionalDevelopmentOfferedByDescriptorId IS 'A code describing an organization that is offering a specific professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.TotalHours IS 'The number of total hours the professional development contains.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.Required IS 'An indication of whether a teacher candidate is active in a professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.MultipleSession IS 'An indication of whether or not a professional development event is comprised of multiple sessions or not.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.ProfessionalDevelopmentReason IS 'The reported reason for a teacher candidate''s professional development.';

-- Extended Properties [tpdm].[ProfessionalDevelopmentEventAttendance] --
COMMENT ON TABLE tpdm.ProfessionalDevelopmentEventAttendance IS 'This event entity represents the recording of whether a staff is in attendance for professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.AttendanceDate IS 'Date for this attendance event.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.Namespace IS 'Namespace for the event, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.ProfessionalDevelopmentTitle IS 'The title or name for a professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.AttendanceEventCategoryDescriptorId IS 'A code describing the attendance event, for example:
       Present
       Unexcused absence
       Excused absence
       Tardy.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.AttendanceEventReason IS 'The reported reason for a teacher candidate''s absence.';

-- Extended Properties [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] --
COMMENT ON TABLE tpdm.ProfessionalDevelopmentOfferedByDescriptor IS 'The descriptor holds the organization that a professional development is offered by.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentOfferedByDescriptor.ProfessionalDevelopmentOfferedByDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ProgramGatewayDescriptor] --
COMMENT ON TABLE tpdm.ProgramGatewayDescriptor IS 'Identifies the program gateway that may be associated for continuation in the program.';
COMMENT ON COLUMN tpdm.ProgramGatewayDescriptor.ProgramGatewayDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Prospect] --
COMMENT ON TABLE tpdm.Prospect IS 'A prospect for employment or contract that has not yet made formal application, often obtained from job fairs or university recruiting visits.';
COMMENT ON COLUMN tpdm.Prospect.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Prospect.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.Prospect.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the person.';
COMMENT ON COLUMN tpdm.Prospect.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.Prospect.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.Prospect.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.Prospect.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN tpdm.Prospect.MaidenName IS 'The person''s maiden name.';
COMMENT ON COLUMN tpdm.Prospect.ElectronicMailAddress IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN tpdm.Prospect.Applied IS 'Indicator of whether the prospect applied for a position.';
COMMENT ON COLUMN tpdm.Prospect.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino".';
COMMENT ON COLUMN tpdm.Prospect.Met IS 'Indicator whether the person was met by a representative of the education organization.';
COMMENT ON COLUMN tpdm.Prospect.Notes IS 'Additional notes about the prospect.';
COMMENT ON COLUMN tpdm.Prospect.PreScreeningRating IS 'The rating initially assigned to the prospect prior to an official screening.';
COMMENT ON COLUMN tpdm.Prospect.Referral IS 'Indicator of whether the prospect was a referral.';
COMMENT ON COLUMN tpdm.Prospect.ReferredBy IS 'The person making the referral.';
COMMENT ON COLUMN tpdm.Prospect.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN tpdm.Prospect.SocialMediaUserName IS 'The user name of the person on social media.';
COMMENT ON COLUMN tpdm.Prospect.SocialMediaNetworkName IS 'The social media network name (e.g., LinkedIn, Twitter, etc.) associated with the SocialMediaUserName.';
COMMENT ON COLUMN tpdm.Prospect.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.Prospect.EconomicDisadvantaged IS 'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.';
COMMENT ON COLUMN tpdm.Prospect.FirstGenerationStudent IS 'Indicator of whether individual is a first generation college student.';
COMMENT ON COLUMN tpdm.Prospect.ProspectTypeDescriptorId IS 'Reflects the type of prospect, such as TPP Applicant, Hire, or Mentor Teacher.';
COMMENT ON COLUMN tpdm.Prospect.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.Prospect.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.Prospect.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[ProspectAid] --
COMMENT ON TABLE tpdm.ProspectAid IS 'This entity represents the financial aid a person is awarded.';
COMMENT ON COLUMN tpdm.ProspectAid.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectAid.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.ProspectAid.BeginDate IS 'The date the award was designated.';
COMMENT ON COLUMN tpdm.ProspectAid.EndDate IS 'The date the award was removed.';
COMMENT ON COLUMN tpdm.ProspectAid.AidConditionDescription IS 'The description of the condition (e.g., placement in a high need school) under which the aid was given.';
COMMENT ON COLUMN tpdm.ProspectAid.AidTypeDescriptorId IS 'The classification of financial aid awarded to a person for the academic term/year.';
COMMENT ON COLUMN tpdm.ProspectAid.AidAmount IS 'The amount of financial aid awarded to a person for the term/year.';
COMMENT ON COLUMN tpdm.ProspectAid.PellGrantRecipient IS 'Indicates a person who receives Pell Grant aid.';

-- Extended Properties [tpdm].[ProspectCurrentPosition] --
COMMENT ON TABLE tpdm.ProspectCurrentPosition IS 'The current position of the prospect.';
COMMENT ON COLUMN tpdm.ProspectCurrentPosition.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectCurrentPosition.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.ProspectCurrentPosition.NameOfInstitution IS 'The formal name of the education organization.';
COMMENT ON COLUMN tpdm.ProspectCurrentPosition.Location IS 'The location, typically City and State, for the institution.';
COMMENT ON COLUMN tpdm.ProspectCurrentPosition.PositionTitle IS 'The descriptive name of an individual''s position.';
COMMENT ON COLUMN tpdm.ProspectCurrentPosition.AcademicSubjectDescriptorId IS 'The academic subject the staff person''s assignment to a school.';

-- Extended Properties [tpdm].[ProspectCurrentPositionGradeLevel] --
COMMENT ON TABLE tpdm.ProspectCurrentPositionGradeLevel IS 'The set of grade levels for which the individual''s assignment is responsible.';
COMMENT ON COLUMN tpdm.ProspectCurrentPositionGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectCurrentPositionGradeLevel.GradeLevelDescriptorId IS 'The set of grade levels for which the individual''s assignment is responsible.';
COMMENT ON COLUMN tpdm.ProspectCurrentPositionGradeLevel.ProspectIdentifier IS 'The identifier for the prospect.';

-- Extended Properties [tpdm].[ProspectDisability] --
COMMENT ON TABLE tpdm.ProspectDisability IS 'The disability condition(s) that best describes an individual''s impairment.';
COMMENT ON COLUMN tpdm.ProspectDisability.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.ProspectDisability.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectDisability.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.ProspectDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN tpdm.ProspectDisability.OrderOfDisability IS 'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN tpdm.ProspectDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [tpdm].[ProspectDisabilityDesignation] --
COMMENT ON TABLE tpdm.ProspectDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.ProspectDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.ProspectDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.ProspectDisabilityDesignation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectDisabilityDesignation.ProspectIdentifier IS 'The identifier for the prospect.';

-- Extended Properties [tpdm].[ProspectPersonalIdentificationDocument] --
COMMENT ON TABLE tpdm.ProspectPersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.ProspectPersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[ProspectQualifications] --
COMMENT ON TABLE tpdm.ProspectQualifications IS 'The qualifications of a prospective mentor teacher.';
COMMENT ON COLUMN tpdm.ProspectQualifications.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectQualifications.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.ProspectQualifications.Eligible IS 'An indication of whether the prospect is eligible for the position.';
COMMENT ON COLUMN tpdm.ProspectQualifications.CapacityToServe IS 'An indication of whether or not a prospect mentor teacher has capacity to serve.';
COMMENT ON COLUMN tpdm.ProspectQualifications.YearsOfServiceCurrentPlacement IS 'The total number of years of service at the current school.';
COMMENT ON COLUMN tpdm.ProspectQualifications.YearsOfServiceTotal IS 'The total number of years of service as a teacher.';

-- Extended Properties [tpdm].[ProspectRace] --
COMMENT ON TABLE tpdm.ProspectRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.ProspectRace.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectRace.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.ProspectRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';

-- Extended Properties [tpdm].[ProspectRecruitmentEvent] --
COMMENT ON TABLE tpdm.ProspectRecruitmentEvent IS 'Reference(s) to events associated with the recruitment process.';
COMMENT ON COLUMN tpdm.ProspectRecruitmentEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectRecruitmentEvent.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.ProspectRecruitmentEvent.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.ProspectRecruitmentEvent.ProspectIdentifier IS 'The identifier for the prospect.';

-- Extended Properties [tpdm].[ProspectTelephone] --
COMMENT ON TABLE tpdm.ProspectTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN tpdm.ProspectTelephone.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectTelephone.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.ProspectTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN tpdm.ProspectTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN tpdm.ProspectTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN tpdm.ProspectTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN tpdm.ProspectTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [tpdm].[ProspectTouchpoint] --
COMMENT ON TABLE tpdm.ProspectTouchpoint IS 'Content associated with different touchpoints with the prospect.';
COMMENT ON COLUMN tpdm.ProspectTouchpoint.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ProspectTouchpoint.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.ProspectTouchpoint.TouchpointContent IS 'The content associated with or an artifact from the touchpoint.';
COMMENT ON COLUMN tpdm.ProspectTouchpoint.TouchpointDate IS 'The date of the touchpoint.';

-- Extended Properties [tpdm].[ProspectTypeDescriptor] --
COMMENT ON TABLE tpdm.ProspectTypeDescriptor IS 'Reflects the type of prospect, such as TPP Applicant, Hire, or Mentor Teacher.';
COMMENT ON COLUMN tpdm.ProspectTypeDescriptor.ProspectTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[QuantitativeMeasure] --
COMMENT ON TABLE tpdm.QuantitativeMeasure IS 'A quantitative measure of educator performance associated with an Evaluation Element.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.QuantitativeMeasureIdentifier IS 'An assigned unique identifier for the quantitative measure.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.QuantitativeMeasureTypeDescriptorId IS 'The type of the quantitative measure (e.g., achievement, growth).';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.QuantitativeMeasureDatatypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[QuantitativeMeasureDatatypeDescriptor] --
COMMENT ON TABLE tpdm.QuantitativeMeasureDatatypeDescriptor IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureDatatypeDescriptor.QuantitativeMeasureDatatypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[QuantitativeMeasureScore] --
COMMENT ON TABLE tpdm.QuantitativeMeasureScore IS 'The score or value for a Quantitative Measure achieved by an individual educator.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.QuantitativeMeasureIdentifier IS 'An assigned unique identifier for the quantitative measure.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.ScoreValue IS 'The score value for the quantitive measure.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.StandardError IS 'The standard error for the quantitative measure.';

-- Extended Properties [tpdm].[QuantitativeMeasureTypeDescriptor] --
COMMENT ON TABLE tpdm.QuantitativeMeasureTypeDescriptor IS 'The type of the quantitative measure (e.g., achievement, growth).';
COMMENT ON COLUMN tpdm.QuantitativeMeasureTypeDescriptor.QuantitativeMeasureTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[RecruitmentEvent] --
COMMENT ON TABLE tpdm.RecruitmentEvent IS 'Events associated with the recruitment process.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EventDescription IS 'The long description of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.RecruitmentEventTypeDescriptorId IS 'The type of event.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EventLocation IS 'The location of the event.';

-- Extended Properties [tpdm].[RecruitmentEventTypeDescriptor] --
COMMENT ON TABLE tpdm.RecruitmentEventTypeDescriptor IS 'The type of event.';
COMMENT ON COLUMN tpdm.RecruitmentEventTypeDescriptor.RecruitmentEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[RubricDimension] --
COMMENT ON TABLE tpdm.RubricDimension IS 'The cells of a rubric, consisting of a qualitative decription, definition, or exemplar with the associated rubric rating and rating level.';
COMMENT ON COLUMN tpdm.RubricDimension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.RubricDimension.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.RubricDimension.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.RubricDimension.RubricRating IS 'The rating achieved for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.RubricDimension.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.RubricDimension.RubricRatingLevelDescriptorId IS 'The rating level achieved for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.CriterionDescription IS 'The criterion description for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.DimensionOrder IS 'The order for the rubric dimension.';

-- Extended Properties [tpdm].[RubricRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.RubricRatingLevelDescriptor IS 'The rating level achieved for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricRatingLevelDescriptor.RubricRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[SalaryTypeDescriptor] --
COMMENT ON TABLE tpdm.SalaryTypeDescriptor IS 'The descriptor holds the type of salary that a staff member is receiving.';
COMMENT ON COLUMN tpdm.SalaryTypeDescriptor.SalaryTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[SchoolExtension] --
COMMENT ON TABLE tpdm.SchoolExtension IS '';
COMMENT ON COLUMN tpdm.SchoolExtension.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.SchoolExtension.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';
COMMENT ON COLUMN tpdm.SchoolExtension.SchoolStatusDescriptorId IS 'The status of school e.g. priority or focus.';
COMMENT ON COLUMN tpdm.SchoolExtension.ImprovingSchool IS 'An indication of whether a school is identified as an improving school.';

-- Extended Properties [tpdm].[SchoolStatusDescriptor] --
COMMENT ON TABLE tpdm.SchoolStatusDescriptor IS 'The descriptor holds the status of a school e.g. priority or focus.';
COMMENT ON COLUMN tpdm.SchoolStatusDescriptor.SchoolStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[StaffApplicantAssociation] --
COMMENT ON TABLE tpdm.StaffApplicantAssociation IS 'Associated applicant(s) represented by this staff member.';
COMMENT ON COLUMN tpdm.StaffApplicantAssociation.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';
COMMENT ON COLUMN tpdm.StaffApplicantAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [tpdm].[StaffBackgroundCheck] --
COMMENT ON TABLE tpdm.StaffBackgroundCheck IS 'Staff background check history and disposition.';
COMMENT ON COLUMN tpdm.StaffBackgroundCheck.BackgroundCheckTypeDescriptorId IS 'The type of background check (e.g., online, criminal, employment).';
COMMENT ON COLUMN tpdm.StaffBackgroundCheck.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffBackgroundCheck.BackgroundCheckRequestedDate IS 'The date the background check was requested.';
COMMENT ON COLUMN tpdm.StaffBackgroundCheck.BackgroundCheckStatusDescriptorId IS 'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).';
COMMENT ON COLUMN tpdm.StaffBackgroundCheck.BackgroundCheckCompletedDate IS 'The date the background check was completed.';
COMMENT ON COLUMN tpdm.StaffBackgroundCheck.Fingerprint IS 'Indicates that a person has or has not completed a fingerprint.';

-- Extended Properties [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] --
COMMENT ON TABLE tpdm.StaffEducationOrganizationAssignmentAssociationExtension IS '';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.BeginDate IS 'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the LEA.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.StaffClassificationDescriptorId IS 'The titles of employment, official status, or rank of education staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.YearsOfExperienceAtCurrentEducationOrganization IS 'The total number of years that an individual has previously held a teaching position in one or more education institutions.';

-- Extended Properties [tpdm].[StaffExtension] --
COMMENT ON TABLE tpdm.StaffExtension IS '';
COMMENT ON COLUMN tpdm.StaffExtension.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffExtension.ProbationCompleteDate IS 'The date the probation period ended or is scheduled to end.';
COMMENT ON COLUMN tpdm.StaffExtension.Tenured IS 'Indicator of whether the staff member is tenured.';
COMMENT ON COLUMN tpdm.StaffExtension.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.StaffExtension.TenureTrack IS 'An indication that the staff is on track for tenure.';

-- Extended Properties [tpdm].[StaffHighlyQualifiedAcademicSubject] --
COMMENT ON TABLE tpdm.StaffHighlyQualifiedAcademicSubject IS 'The academic subject(s) in which the staff is deemed to be "highly qualified".';
COMMENT ON COLUMN tpdm.StaffHighlyQualifiedAcademicSubject.AcademicSubjectDescriptorId IS 'The academic subject(s) in which the staff is deemed to be "highly qualified".';
COMMENT ON COLUMN tpdm.StaffHighlyQualifiedAcademicSubject.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [tpdm].[StaffProspectAssociation] --
COMMENT ON TABLE tpdm.StaffProspectAssociation IS 'Associated previously identified prospect.';
COMMENT ON COLUMN tpdm.StaffProspectAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffProspectAssociation.ProspectIdentifier IS 'The identifier for the prospect.';
COMMENT ON COLUMN tpdm.StaffProspectAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [tpdm].[StaffSalary] --
COMMENT ON TABLE tpdm.StaffSalary IS 'Information regarding the salary of a staff member.';
COMMENT ON COLUMN tpdm.StaffSalary.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffSalary.SalaryMinRange IS 'The minimum salary range for a staff.';
COMMENT ON COLUMN tpdm.StaffSalary.SalaryMaxRange IS 'The maximum salary range for a staff.';
COMMENT ON COLUMN tpdm.StaffSalary.SalaryTypeDescriptorId IS 'The type of salary that a staff member is receiving.';
COMMENT ON COLUMN tpdm.StaffSalary.SalaryAmount IS 'The salary of a staff member.';

-- Extended Properties [tpdm].[StaffSeniority] --
COMMENT ON TABLE tpdm.StaffSeniority IS 'Entries of job experience contributing to computations of seniority.';
COMMENT ON COLUMN tpdm.StaffSeniority.CredentialFieldDescriptorId IS 'The field of the credential being applied.';
COMMENT ON COLUMN tpdm.StaffSeniority.NameOfInstitution IS 'The name of the education organization worked.';
COMMENT ON COLUMN tpdm.StaffSeniority.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffSeniority.YearsExperience IS 'The number of years of experience.';

-- Extended Properties [tpdm].[StaffStudentGrowthMeasure] --
COMMENT ON TABLE tpdm.StaffStudentGrowthMeasure IS 'Complex type that provides data about a group of students and their student growth as it pertains to the Teacher Candidate';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StaffStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StudentGrowthMeasureDate IS 'The date for which the student growth is measured';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StudentGrowthTypeDescriptorId IS 'Identification of the type of score that was used to determine student growth';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StudentGrowthTargetScore IS 'The target score that has been set for the group of students as it pertains to their student growth.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StudentGrowthActualScore IS 'The actual score a group of students receives on their student growth assessment';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StudentGrowthMet IS 'Identifies if the student has met the student growth target score';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StudentGrowthNCount IS 'The number of students included in the average score result.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasure.StandardError IS 'Standard error for growth score measurement.';

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureAcademicSubject] --
COMMENT ON TABLE tpdm.StaffStudentGrowthMeasureAcademicSubject IS 'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureAcademicSubject.AcademicSubjectDescriptorId IS 'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureAcademicSubject.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureAcademicSubject.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureAcademicSubject.StaffStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureAcademicSubject.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureCourseAssociation] --
COMMENT ON TABLE tpdm.StaffStudentGrowthMeasureCourseAssociation IS 'Any courses associated with the staff''s student growth data, if applicable.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureCourseAssociation.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureCourseAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureCourseAssociation.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureCourseAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureCourseAssociation.StaffStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureCourseAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureCourseAssociation.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureCourseAssociation.EndDate IS 'The end date for the association';

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureEducationOrganizationAssociation] --
COMMENT ON TABLE tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation IS 'Any education organizations associated with the staff''s student growth data, if applicable.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation.StaffStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation.EndDate IS 'The end date for the association';

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureGradeLevel] --
COMMENT ON TABLE tpdm.StaffStudentGrowthMeasureGradeLevel IS 'This descriptor defines the set of grade levels.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureGradeLevel.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureGradeLevel.GradeLevelDescriptorId IS 'This descriptor defines the set of grade levels.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureGradeLevel.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureGradeLevel.StaffStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureGradeLevel.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [tpdm].[StaffStudentGrowthMeasureSectionAssociation] --
COMMENT ON TABLE tpdm.StaffStudentGrowthMeasureSectionAssociation IS 'Any sections associated with the staff''s student growth data, if applicable.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.StaffStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.StaffStudentGrowthMeasureSectionAssociation.EndDate IS 'The end date for the association';

-- Extended Properties [tpdm].[StaffTeacherEducatorResearch] --
COMMENT ON TABLE tpdm.StaffTeacherEducatorResearch IS 'Teacher preparation provider faculty that instruct teacher candidates in content area or pedagogy.';
COMMENT ON COLUMN tpdm.StaffTeacherEducatorResearch.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffTeacherEducatorResearch.ResearchExperienceDate IS 'Month, day, and year of the start or effective date of a staff member''s teacher educator position for an Education Organization.';
COMMENT ON COLUMN tpdm.StaffTeacherEducatorResearch.ResearchExperienceTitle IS 'The title of the research experience.';
COMMENT ON COLUMN tpdm.StaffTeacherEducatorResearch.ResearchExperienceDescription IS 'The description of the research experience.';

-- Extended Properties [tpdm].[StaffTeacherPreparationProgram] --
COMMENT ON TABLE tpdm.StaffTeacherPreparationProgram IS 'The Teacher Preparation Program(s) completed by the teacher.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProgram.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProgram.TeacherPreparationProgramName IS 'The name of the Teacher Preparation Program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProgram.TeacherPreparationProgramIdentifier IS 'An identifier assigned to the teacher preparation program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProgram.TeacherPreparationProgramTypeDescriptorId IS 'The type of teacher prep program (e.g., college, alternative, TFA, etc.).';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProgram.NameOfInstitution IS 'The name of the organization providing the teacher preparation program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProgram.MajorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProgram.GPA IS 'The final GPA the teacher achieved in the program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProgram.LevelOfDegreeAwardedDescriptorId IS 'The level of degree awarded by the teacher preparation program to the person (e.g., Certificate Only, Bachelor''s, Master''s, etc.).';

-- Extended Properties [tpdm].[StaffTeacherPreparationProviderAssociation] --
COMMENT ON TABLE tpdm.StaffTeacherPreparationProviderAssociation IS 'Information about the association between the Staff and the TeacherPreparationProvider';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociation.TeacherPreparationProviderId IS 'The unique identification code for the Teacher Preparation Provider';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociation.SchoolYear IS 'Identifier for a school year.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociation.ProgramAssignmentDescriptorId IS 'Program Assignment for the association';

-- Extended Properties [tpdm].[StaffTeacherPreparationProviderAssociationAcademicSubject] --
COMMENT ON TABLE tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject IS 'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a degree.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject.AcademicSubjectDescriptorId IS 'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a degree.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject.TeacherPreparationProviderId IS 'The unique identification code for the Teacher Preparation Provider';

-- Extended Properties [tpdm].[StaffTeacherPreparationProviderAssociationGradeLevel] --
COMMENT ON TABLE tpdm.StaffTeacherPreparationProviderAssociationGradeLevel IS 'The grade levels for the association.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociationGradeLevel.GradeLevelDescriptorId IS 'The grade levels for the association.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociationGradeLevel.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderAssociationGradeLevel.TeacherPreparationProviderId IS 'The unique identification code for the Teacher Preparation Provider';

-- Extended Properties [tpdm].[StaffTeacherPreparationProviderProgramAssociation] --
COMMENT ON TABLE tpdm.StaffTeacherPreparationProviderProgramAssociation IS 'This association indicates the Staff associated with a teacher preparation provider program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderProgramAssociation.ProgramName IS 'The name of the Teacher Preparation Program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderProgramAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderProgramAssociation.BeginDate IS 'Start date for the association of staff to this program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderProgramAssociation.EndDate IS 'End date for the association of staff to this program.';
COMMENT ON COLUMN tpdm.StaffTeacherPreparationProviderProgramAssociation.StudentRecordAccess IS 'Indicator of whether the staff has access to the student records of the program per district interpretation of FERPA and other privacy laws, regulations, and policies.';

-- Extended Properties [tpdm].[StateEducationAgencyExtension] --
COMMENT ON TABLE tpdm.StateEducationAgencyExtension IS '';
COMMENT ON COLUMN tpdm.StateEducationAgencyExtension.StateEducationAgencyId IS 'The identifier assigned to a state education agency.';
COMMENT ON COLUMN tpdm.StateEducationAgencyExtension.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';

-- Extended Properties [tpdm].[StudentGradebookEntryExtension] --
COMMENT ON TABLE tpdm.StudentGradebookEntryExtension IS '';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.BeginDate IS 'Month, day, and year of the Student''s entry or assignment to the Section.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.DateAssigned IS 'The date the assignment, homework, or assessment was assigned or executed.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.GradebookEntryTitle IS 'The name or title of the activity to be recorded in the GradebookEntry.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.DateCompleted IS 'The date that the assignment was completed.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.AssignmentPassed IS 'Indication of whether the assignment was passed or not.';

-- Extended Properties [tpdm].[StudentGrowthTypeDescriptor] --
COMMENT ON TABLE tpdm.StudentGrowthTypeDescriptor IS 'Identification of the type of score that was used to determine student growth';
COMMENT ON COLUMN tpdm.StudentGrowthTypeDescriptor.StudentGrowthTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[SurveyResponseExtension] --
COMMENT ON TABLE tpdm.SurveyResponseExtension IS '';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.ApplicantIdentifier IS 'Identifier assigned to a person making formal application for an open staff position.';

-- Extended Properties [tpdm].[SurveyResponseTeacherCandidateTargetAssociation] --
COMMENT ON TABLE tpdm.SurveyResponseTeacherCandidateTargetAssociation IS 'The association provides information about the survey being taken and who the survey is about.';
COMMENT ON COLUMN tpdm.SurveyResponseTeacherCandidateTargetAssociation.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveyResponseTeacherCandidateTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveyResponseTeacherCandidateTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN tpdm.SurveyResponseTeacherCandidateTargetAssociation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';

-- Extended Properties [tpdm].[SurveySectionAggregateResponse] --
COMMENT ON TABLE tpdm.SurveySectionAggregateResponse IS 'The aggregate or average score across the surveying population for a survey section being used for performance evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.SurveySectionTitle IS 'The title or label for the survey section.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.ScoreValue IS 'The score value for the aggregate survey section response.';

-- Extended Properties [tpdm].[SurveySectionExtension] --
COMMENT ON TABLE tpdm.SurveySectionExtension IS '';
COMMENT ON COLUMN tpdm.SurveySectionExtension.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.SurveySectionTitle IS 'The title or label for the survey section.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EvaluationElementTitle IS 'The name or title of the evaluation element.';

-- Extended Properties [tpdm].[SurveySectionResponseTeacherCandidateTargetAssociation] --
COMMENT ON TABLE tpdm.SurveySectionResponseTeacherCandidateTargetAssociation IS 'This association provides information about the survey section and the teacher candidate the survey section is about.';
COMMENT ON COLUMN tpdm.SurveySectionResponseTeacherCandidateTargetAssociation.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveySectionResponseTeacherCandidateTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveySectionResponseTeacherCandidateTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN tpdm.SurveySectionResponseTeacherCandidateTargetAssociation.SurveySectionTitle IS 'The title or label for the survey section.';
COMMENT ON COLUMN tpdm.SurveySectionResponseTeacherCandidateTargetAssociation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';

-- Extended Properties [tpdm].[TeacherCandidate] --
COMMENT ON TABLE tpdm.TeacherCandidate IS 'This entity represents an individual for whom instruction and/or services in a Teacher Preparation Program are provided under the jurisdiction of a Teacher Preparation Provider.  A teacher candidate is a person who has been enrolled in a teacher preparation program.';
COMMENT ON COLUMN tpdm.TeacherCandidate.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidate.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the person.';
COMMENT ON COLUMN tpdm.TeacherCandidate.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.TeacherCandidate.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.TeacherCandidate.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.TeacherCandidate.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN tpdm.TeacherCandidate.MaidenName IS 'The person''s maiden name.';
COMMENT ON COLUMN tpdm.TeacherCandidate.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN tpdm.TeacherCandidate.BirthDate IS 'The month, day, and year on which an individual was born.';
COMMENT ON COLUMN tpdm.TeacherCandidate.BirthCity IS 'The city the student was born in.';
COMMENT ON COLUMN tpdm.TeacherCandidate.BirthStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.';
COMMENT ON COLUMN tpdm.TeacherCandidate.BirthInternationalProvince IS 'For students born outside of the U.S., the Province or jurisdiction in which an individual is born.';
COMMENT ON COLUMN tpdm.TeacherCandidate.BirthCountryDescriptorId IS 'The country in which an individual is born. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN tpdm.TeacherCandidate.DateEnteredUS IS 'For students born outside of the U.S., the date the student entered the U.S.';
COMMENT ON COLUMN tpdm.TeacherCandidate.MultipleBirthStatus IS 'Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)';
COMMENT ON COLUMN tpdm.TeacherCandidate.BirthSexDescriptorId IS 'A person''s gender at birth.';
COMMENT ON COLUMN tpdm.TeacherCandidate.ProfileThumbnail IS 'Locator for the student photo.';
COMMENT ON COLUMN tpdm.TeacherCandidate.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."';
COMMENT ON COLUMN tpdm.TeacherCandidate.OldEthnicityDescriptorId IS 'Previous definition of Ethnicity combining Hispanic/Latino and race:
      1 - American Indian or Alaskan Native
      2 - Asian or Pacific Islander
      3 - Black, not of Hispanic origin
      4 - Hispanic
      5 - White, not of Hispanic origin.';
COMMENT ON COLUMN tpdm.TeacherCandidate.CitizenshipStatusDescriptorId IS 'An indicator of whether or not the person is a U.S. citizen.';
COMMENT ON COLUMN tpdm.TeacherCandidate.EconomicDisadvantaged IS 'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.';
COMMENT ON COLUMN tpdm.TeacherCandidate.LimitedEnglishProficiencyDescriptorId IS 'An indication that the student has been identified as limited English proficient by the Language Proficiency Assessment Committee (LPAC), or English proficient.';
COMMENT ON COLUMN tpdm.TeacherCandidate.DisplacementStatus IS 'Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.';
COMMENT ON COLUMN tpdm.TeacherCandidate.LoginId IS 'The login ID for the user; used for security access control interface.';
COMMENT ON COLUMN tpdm.TeacherCandidate.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.TeacherCandidate.TuitionCost IS 'The tuition for a person''s participation in a program, service. or course.';
COMMENT ON COLUMN tpdm.TeacherCandidate.EnglishLanguageExamDescriptorId IS 'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).';
COMMENT ON COLUMN tpdm.TeacherCandidate.PreviousCareerDescriptorId IS 'The career previous for an individual.';
COMMENT ON COLUMN tpdm.TeacherCandidate.ProgramComplete IS 'An indication of whether a teacher candidate has completed the teacher preparation program.';
COMMENT ON COLUMN tpdm.TeacherCandidate.FirstGenerationStudent IS 'Indicator of whether individual is a first generation college student.';
COMMENT ON COLUMN tpdm.TeacherCandidate.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.TeacherCandidate.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.TeacherCandidate.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecord] --
COMMENT ON TABLE tpdm.TeacherCandidateAcademicRecord IS 'This educational entity represents the cumulative record of academic achievement for a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.CumulativeEarnedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.CumulativeEarnedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.CumulativeEarnedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.CumulativeAttemptedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.CumulativeAttemptedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.CumulativeAttemptedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.CumulativeGradePointsEarned IS 'The cumulative number of grade points an individual earns by successfully completing courses or examinations during his or her enrollment in the current school as well as those transferred from schools in which the individual had been previously enrolled.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.CumulativeGradePointAverage IS 'A measure of average performance in all courses taken by an individual during his or her school career as determined for record-keeping purposes. This is obtained by dividing the total grade points received by the total number of credits attempted. This usually includes grade points received and credits attempted in his or her current school as well as those transferred from schools in which the individual was previously enrolled.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.GradeValueQualifier IS 'The scale of equivalents, if applicable, for grades awarded as indicators of performance in schoolwork. For example, numerical equivalents for letter grades used in determining a student''s Grade Point Average (A=4, B=3, C=2, D=1 in a four-point system) or letter equivalents for percentage grades (90-100%=A, 80-90%=B, etc.)';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.ProjectedGraduationDate IS 'The month and year the student is projected to graduate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SessionEarnedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SessionEarnedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SessionEarnedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SessionAttemptedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SessionAttemptedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SessionAttemptedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SessionGradePointsEarned IS 'The number of grade points an individual earned for this session.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.SessionGradePointAverage IS 'The grade point average for an individual computed as the grade points earned during the session divided by the number of credits attempted.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.ContentGradePointAverage IS 'A measure of average performance in all courses taken by an individual within a given content area during his or her school career as determined for record-keeping purposes. This is obtained by dividing the total grade points received by the total number of credits attempted. This usually includes grade points received and credits attempted in his or her current school as well as those transferred from schools in which the individual was previously enrolled.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.ContentGradePointEarned IS 'The cumulative number of grade points an individual earns within a given content area by successfully completing courses or examinations during his or her enrollment in the current school as well as those transferred from schools in which the individual had been previously enrolled.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.ProgramGatewayDescriptorId IS 'Identifies the program gateway that may be associated for continuation in the program.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecord.TPPDegreeTypeDescriptorId IS 'The degree type that a teacher candidate accomplishes.';

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordAcademicHonor] --
COMMENT ON TABLE tpdm.TeacherCandidateAcademicRecordAcademicHonor IS 'Academic distinctions earned by or awarded to the student.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.AcademicHonorCategoryDescriptorId IS 'A designation of the type of academic distinctions earned by or awarded to the student.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.HonorDescription IS 'A description of the type of academic distinctions earned by or awarded to the individual.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.AchievementTitle IS 'The title assigned to the achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.AchievementCategoryDescriptorId IS 'The category of achievement attributed to the learner.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.AchievementCategorySystem IS 'The system that defines the categories by which an achievement is attributed to the learner.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.IssuerName IS 'The name of the agent, entity, or institution issuing the element.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.IssuerOriginURL IS 'The Uniform Resource Locator (URL) from which the award was issued.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.Criteria IS 'The criteria for competency-based completion of the achievement/award.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.CriteriaURL IS 'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.EvidenceStatement IS 'A statement or reference describing the evidence that the learner met the criteria for attainment of the Achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.ImageURL IS 'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the Achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.HonorAwardDate IS 'The date the honor was awarded or earned.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordAcademicHonor.HonorAwardExpiresDate IS 'Date on which the award expires.';

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordClassRanking] --
COMMENT ON TABLE tpdm.TeacherCandidateAcademicRecordClassRanking IS 'The academic rank information of a student in relation to his or her graduating class.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordClassRanking.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordClassRanking.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordClassRanking.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordClassRanking.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordClassRanking.ClassRank IS 'The academic rank of a student in relation to his or her graduating class (e.g., 1st, 2nd, 3rd).';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordClassRanking.TotalNumberInClass IS 'The total number of students in the student''s graduating class.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordClassRanking.PercentageRanking IS 'The academic percentage rank of a student in relation to his or her graduating class (e.g., 95%, 80%, 50%).';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordClassRanking.ClassRankingDate IS 'Date class ranking was determined.';

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordDiploma] --
COMMENT ON TABLE tpdm.TeacherCandidateAcademicRecordDiploma IS 'Diploma(s) earned by the student.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.DiplomaAwardDate IS 'The month, day, and year on which the student met  graduation requirements and was awarded a diploma.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.DiplomaTypeDescriptorId IS 'The type of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.AchievementTitle IS 'The title assigned to the achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.AchievementCategoryDescriptorId IS 'The category of achievement attributed to the learner.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.AchievementCategorySystem IS 'The system that defines the categories by which an achievement is attributed to the learner.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.IssuerName IS 'The name of the agent, entity, or institution issuing the element.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.IssuerOriginURL IS 'The Uniform Resource Locator (URL) from which the award was issued.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.Criteria IS 'The criteria for competency-based completion of the achievement/award.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.CriteriaURL IS 'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.EvidenceStatement IS 'A statement or reference describing the evidence that the learner met the criteria for attainment of the Achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.ImageURL IS 'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the Achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.DiplomaLevelDescriptorId IS 'The level of diploma/credential that is awarded to a student in recognition of his/her completion of the curricular requirements.
        Minimum high school program
        Recommended high school program
        Distinguished Achievement Program.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.CTECompleter IS 'Indicated a student who reached a state-defined threshold of vocational education and who attained a high school diploma or its recognized state equivalent or GED.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.DiplomaDescription IS 'The description of diploma given to the student for accomplishments.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordDiploma.DiplomaAwardExpiresDate IS 'Date on which the award expires.';

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordGradePointAverage] --
COMMENT ON TABLE tpdm.TeacherCandidateAcademicRecordGradePointAverage IS 'Data that provides information on a measure of average performance in a group of courses taken by an individual.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordGradePointAverage.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordGradePointAverage.GradePointAverageTypeDescriptorId IS 'The system used for calculating the grade point average for an individual.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordGradePointAverage.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordGradePointAverage.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordGradePointAverage.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordGradePointAverage.IsCumulative IS 'Indicator of whether or not the Grade Point Average value is cumulative.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordGradePointAverage.GradePointAverageValue IS 'The value of the grade points earned divided by the number of credits attempted.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordGradePointAverage.MaxGradePointAverageValue IS 'The maximum value for the grade point average.';

-- Extended Properties [tpdm].[TeacherCandidateAcademicRecordRecognition] --
COMMENT ON TABLE tpdm.TeacherCandidateAcademicRecordRecognition IS 'Recognitions given to the student for accomplishments in a co-curricular or extracurricular activity.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.RecognitionTypeDescriptorId IS 'The nature of recognition given to the learner for accomplishments in a co-curricular, or extra-curricular activity.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.AchievementTitle IS 'The title assigned to the achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.AchievementCategoryDescriptorId IS 'The category of achievement attributed to the learner.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.AchievementCategorySystem IS 'The system that defines the categories by which an achievement is attributed to the learner.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.IssuerName IS 'The name of the agent, entity, or institution issuing the element.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.IssuerOriginURL IS 'The Uniform Resource Locator (URL) from which the award was issued.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.Criteria IS 'The criteria for competency-based completion of the achievement/award.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.CriteriaURL IS 'The Uniform Resource Locator (URL) for the unique address of a web page describing the competency-based completion criteria for the achievement/award.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.EvidenceStatement IS 'A statement or reference describing the evidence that the learner met the criteria for attainment of the Achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.ImageURL IS 'The Uniform Resource Locator (URL) for the unique address of an image representing an award or badge associated with the Achievement.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.RecognitionDescription IS 'A description of the type of academic distinctions earned by or awarded to the individual.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.RecognitionAwardDate IS 'The date the recognition was awarded or earned.';
COMMENT ON COLUMN tpdm.TeacherCandidateAcademicRecordRecognition.RecognitionAwardExpiresDate IS 'Date on which the award expires.';

-- Extended Properties [tpdm].[TeacherCandidateAddress] --
COMMENT ON TABLE tpdm.TeacherCandidateAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [tpdm].[TeacherCandidateAddressPeriod] --
COMMENT ON TABLE tpdm.TeacherCandidateAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.TeacherCandidateAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddressPeriod.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [tpdm].[TeacherCandidateAid] --
COMMENT ON TABLE tpdm.TeacherCandidateAid IS 'This entity represents the financial aid a person is awarded.';
COMMENT ON COLUMN tpdm.TeacherCandidateAid.AidTypeDescriptorId IS 'The classification of financial aid awarded to a person for the academic term/year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAid.BeginDate IS 'The date the award was designated.';
COMMENT ON COLUMN tpdm.TeacherCandidateAid.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateAid.EndDate IS 'The date the award was removed.';
COMMENT ON COLUMN tpdm.TeacherCandidateAid.AidConditionDescription IS 'The description of the condition (e.g., placement in a high need school) under which the aid was given.';
COMMENT ON COLUMN tpdm.TeacherCandidateAid.AidAmount IS 'The amount of financial aid awarded to a person for the term/year.';
COMMENT ON COLUMN tpdm.TeacherCandidateAid.PellGrantRecipient IS 'Indicates a person who receives Pell Grant aid.';

-- Extended Properties [tpdm].[TeacherCandidateBackgroundCheck] --
COMMENT ON TABLE tpdm.TeacherCandidateBackgroundCheck IS 'Applicant background check history and disposition.';
COMMENT ON COLUMN tpdm.TeacherCandidateBackgroundCheck.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateBackgroundCheck.BackgroundCheckTypeDescriptorId IS 'The type of background check (e.g., online, criminal, employment).';
COMMENT ON COLUMN tpdm.TeacherCandidateBackgroundCheck.BackgroundCheckRequestedDate IS 'The date the background check was requested.';
COMMENT ON COLUMN tpdm.TeacherCandidateBackgroundCheck.BackgroundCheckStatusDescriptorId IS 'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).';
COMMENT ON COLUMN tpdm.TeacherCandidateBackgroundCheck.BackgroundCheckCompletedDate IS 'The date the background check was completed.';
COMMENT ON COLUMN tpdm.TeacherCandidateBackgroundCheck.Fingerprint IS 'Indicates that a person has or has not completed a fingerprint.';

-- Extended Properties [tpdm].[TeacherCandidateCharacteristic] --
COMMENT ON TABLE tpdm.TeacherCandidateCharacteristic IS 'Reflects important characteristics of the teacher candidate''s home situation:
      Displaced Homemaker, Immigrant, Migratory, Military Parent, Pregnant Teen, Single Parent, and Unaccompanied Youth.';
COMMENT ON COLUMN tpdm.TeacherCandidateCharacteristic.StudentCharacteristicDescriptorId IS 'The characteristic designated for the Student.';
COMMENT ON COLUMN tpdm.TeacherCandidateCharacteristic.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateCharacteristic.BeginDate IS 'The date the characteristic was designated.';
COMMENT ON COLUMN tpdm.TeacherCandidateCharacteristic.EndDate IS 'The date the characteristic was removed.';
COMMENT ON COLUMN tpdm.TeacherCandidateCharacteristic.DesignatedBy IS 'The person, organization, or department that designated the characteristic.';

-- Extended Properties [tpdm].[TeacherCandidateCharacteristicDescriptor] --
COMMENT ON TABLE tpdm.TeacherCandidateCharacteristicDescriptor IS 'The characteristic designated for the TeacherCandidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateCharacteristicDescriptor.TeacherCandidateCharacteristicDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[TeacherCandidateCohortYear] --
COMMENT ON TABLE tpdm.TeacherCandidateCohortYear IS 'The type and year of a cohort (e.g., 9th grade) the student belongs to as determined by the year that student entered a specific grade.';
COMMENT ON COLUMN tpdm.TeacherCandidateCohortYear.CohortYearTypeDescriptorId IS 'The type of cohort year (9th grade, graduation).';
COMMENT ON COLUMN tpdm.TeacherCandidateCohortYear.SchoolYear IS 'The value of the  school year for the Cohort.';
COMMENT ON COLUMN tpdm.TeacherCandidateCohortYear.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';

-- Extended Properties [tpdm].[TeacherCandidateCourseTranscript] --
COMMENT ON TABLE tpdm.TeacherCandidateCourseTranscript IS 'This entity is the final record of a student''s performance in their courses at the end of a semester or school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.CourseAttemptResultDescriptorId IS 'The result from the student''s attempt to take the course, for example:
        Pass
        Fail
        Incomplete
        Withdrawn.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.AttemptedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.AttemptedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.AttemptedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.EarnedCredits IS 'The value of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.EarnedCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.EarnedCreditConversion IS 'Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.WhenTakenGradeLevelDescriptorId IS 'Student''s grade level at time of course.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.MethodCreditEarnedDescriptorId IS 'The method the credits were earned (e.g., Classroom, Examination, Transfer).';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.FinalLetterGradeEarned IS 'The final indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.FinalNumericGradeEarned IS 'The final indicator of student performance in a class as submitted by the instructor.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.CourseRepeatCodeDescriptorId IS 'Indicates that an academic course has been repeated by a student and how that repeat is to be computed in the student''s academic grade average.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.CourseTitle IS 'The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, language arts).';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.AlternativeCourseTitle IS 'The descriptive name given to a course of study offered in the school, if different from the CourseTitle.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscript.AlternativeCourseCode IS 'The local code assigned by the school that identifies the course offering, the code from an external educational organization, or other alternate course code.';

-- Extended Properties [tpdm].[TeacherCandidateCourseTranscriptEarnedAdditionalCredits] --
COMMENT ON TABLE tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits IS 'The number of additional credits a student attempted and could earn for successfully completing a given course (e.g., dual credit, AP, IB).';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.AdditionalCreditTypeDescriptorId IS 'The type of credits or units of value awarded for the completion of a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.CourseAttemptResultDescriptorId IS 'The result from the student''s attempt to take the course, for example:
        Pass
        Fail
        Incomplete
        Withdrawn.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.CourseEducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits.Credits IS 'The value of credits or units of value awarded for the completion of a course';

-- Extended Properties [tpdm].[TeacherCandidateDegreeSpecialization] --
COMMENT ON TABLE tpdm.TeacherCandidateDegreeSpecialization IS 'Information around the area(s) of specialization for an individual.';
COMMENT ON COLUMN tpdm.TeacherCandidateDegreeSpecialization.BeginDate IS 'The month, day, and year on which the Teacher Candidate first declared specialization.';
COMMENT ON COLUMN tpdm.TeacherCandidateDegreeSpecialization.MajorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.TeacherCandidateDegreeSpecialization.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateDegreeSpecialization.MinorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.TeacherCandidateDegreeSpecialization.EndDate IS 'The month, day, and year on which the Teacher Candidate exited the declared specialization.';

-- Extended Properties [tpdm].[TeacherCandidateDisability] --
COMMENT ON TABLE tpdm.TeacherCandidateDisability IS 'The disability condition(s) that best describes an individual''s impairment.';
COMMENT ON COLUMN tpdm.TeacherCandidateDisability.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.TeacherCandidateDisability.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN tpdm.TeacherCandidateDisability.OrderOfDisability IS 'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN tpdm.TeacherCandidateDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [tpdm].[TeacherCandidateDisabilityDesignation] --
COMMENT ON TABLE tpdm.TeacherCandidateDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.TeacherCandidateDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.TeacherCandidateDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.TeacherCandidateDisabilityDesignation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';

-- Extended Properties [tpdm].[TeacherCandidateElectronicMail] --
COMMENT ON TABLE tpdm.TeacherCandidateElectronicMail IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN tpdm.TeacherCandidateElectronicMail.ElectronicMailAddress IS 'The electronic mail (e-mail) address listed for an individual or organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateElectronicMail.ElectronicMailTypeDescriptorId IS 'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)';
COMMENT ON COLUMN tpdm.TeacherCandidateElectronicMail.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateElectronicMail.PrimaryEmailAddressIndicator IS 'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateElectronicMail.DoNotPublishIndicator IS 'An indication that the electronic email address should not be published.';

-- Extended Properties [tpdm].[TeacherCandidateIdentificationCode] --
COMMENT ON TABLE tpdm.TeacherCandidateIdentificationCode IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationCode.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the StudentIdentificationCode.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationCode.StudentIdentificationSystemDescriptorId IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a student.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationCode.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code assigned to a student by a school, school system, a state, or other agency or entity.';

-- Extended Properties [tpdm].[TeacherCandidateIdentificationDocument] --
COMMENT ON TABLE tpdm.TeacherCandidateIdentificationDocument IS 'Describe the documentation of citizenship.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationDocument.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.TeacherCandidateIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[TeacherCandidateIndicator] --
COMMENT ON TABLE tpdm.TeacherCandidateIndicator IS 'Indicator(s) or metric(s) computed for the student (e.g., at risk) to influence more effective education or direct specific interventions.';
COMMENT ON COLUMN tpdm.TeacherCandidateIndicator.IndicatorName IS 'The name of the indicator or metric.';
COMMENT ON COLUMN tpdm.TeacherCandidateIndicator.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateIndicator.IndicatorGroup IS 'The name for a group of indicators.';
COMMENT ON COLUMN tpdm.TeacherCandidateIndicator.Indicator IS 'The value of the indicator or metric.';
COMMENT ON COLUMN tpdm.TeacherCandidateIndicator.BeginDate IS 'The date when the indicator was assigned or computed.';
COMMENT ON COLUMN tpdm.TeacherCandidateIndicator.EndDate IS 'The date the indicator or metric was sunset or removed.';
COMMENT ON COLUMN tpdm.TeacherCandidateIndicator.DesignatedBy IS 'The person, organization, or department that designated the program association.';

-- Extended Properties [tpdm].[TeacherCandidateInternationalAddress] --
COMMENT ON TABLE tpdm.TeacherCandidateInternationalAddress IS 'The set of elements that describes an international address.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.AddressLine1 IS 'The first line of the address.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.AddressLine2 IS 'The second line of the address.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.AddressLine3 IS 'The third line of the address.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.AddressLine4 IS 'The fourth line of the address.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.CountryDescriptorId IS 'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.BeginDate IS 'The first date the address is valid. For physical addresses, the date the person moved to that address.';
COMMENT ON COLUMN tpdm.TeacherCandidateInternationalAddress.EndDate IS 'The last date the address is valid. For physical addresses, this would be the date the person moved from that address.';

-- Extended Properties [tpdm].[TeacherCandidateLanguage] --
COMMENT ON TABLE tpdm.TeacherCandidateLanguage IS 'The language(s) the individual uses to communicate.';
COMMENT ON COLUMN tpdm.TeacherCandidateLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN tpdm.TeacherCandidateLanguage.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';

-- Extended Properties [tpdm].[TeacherCandidateLanguageUse] --
COMMENT ON TABLE tpdm.TeacherCandidateLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN tpdm.TeacherCandidateLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN tpdm.TeacherCandidateLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN tpdm.TeacherCandidateLanguageUse.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';

-- Extended Properties [tpdm].[TeacherCandidateOtherName] --
COMMENT ON TABLE tpdm.TeacherCandidateOtherName IS 'Other names (e.g., alias, nickname, previous legal name) associated with a person.';
COMMENT ON COLUMN tpdm.TeacherCandidateOtherName.OtherNameTypeDescriptorId IS 'The types of alternate names for a person.';
COMMENT ON COLUMN tpdm.TeacherCandidateOtherName.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateOtherName.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the person.';
COMMENT ON COLUMN tpdm.TeacherCandidateOtherName.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.TeacherCandidateOtherName.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.TeacherCandidateOtherName.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.TeacherCandidateOtherName.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';

-- Extended Properties [tpdm].[TeacherCandidatePersonalIdentificationDocument] --
COMMENT ON TABLE tpdm.TeacherCandidatePersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN tpdm.TeacherCandidatePersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.TeacherCandidatePersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.TeacherCandidatePersonalIdentificationDocument.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidatePersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.TeacherCandidatePersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.TeacherCandidatePersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.TeacherCandidatePersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.TeacherCandidatePersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[TeacherCandidateRace] --
COMMENT ON TABLE tpdm.TeacherCandidateRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.TeacherCandidateRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.TeacherCandidateRace.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';

-- Extended Properties [tpdm].[TeacherCandidateStaffAssociation] --
COMMENT ON TABLE tpdm.TeacherCandidateStaffAssociation IS 'This describes a relationship between a (current) teacher candidate and a staff person, typically at a K12 partnering district in the role of a mentor teacher, coordinating teacher, supervising principal, etc.  It could also describe the relationship between a (current) teacher candidate and a university staff member, i.e., field placement supervisor, advisor, etc.  This is a relationship between two different people.';
COMMENT ON COLUMN tpdm.TeacherCandidateStaffAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.TeacherCandidateStaffAssociation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateStaffAssociation.BeginDate IS 'The month, day, and year on which the teacher candidate is associated to the staff.';
COMMENT ON COLUMN tpdm.TeacherCandidateStaffAssociation.EndDate IS 'The month, day, and year on which the teacher candidate stops association with the staff.';

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasure] --
COMMENT ON TABLE tpdm.TeacherCandidateStudentGrowthMeasure IS 'Complex type that provides data about a group of students and their student growth as it pertains to the Teacher Candidate';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.TeacherCandidateStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.StudentGrowthMeasureDate IS 'The date for which the student growth is measured';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.StudentGrowthTypeDescriptorId IS 'Identification of the type of score that was used to determine student growth';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.StudentGrowthTargetScore IS 'The target score that has been set for the group of students as it pertains to their student growth.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.StudentGrowthActualScore IS 'The actual score a group of students receives on their student growth assessment';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.StudentGrowthMet IS 'Identifies if the student growth target score is achieved.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.StudentGrowthNCount IS 'The number of students included in the average score result.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasure.StandardError IS 'Standard error for growth score measurement.';

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureAcademicSubject] --
COMMENT ON TABLE tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject IS 'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject.AcademicSubjectDescriptorId IS 'This descriptor holds the description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language).';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject.TeacherCandidateStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureCourseAssociation] --
COMMENT ON TABLE tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation IS 'Any courses associated with the teacher candidate''s student growth data, if applicable.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation.CourseCode IS 'A unique alphanumeric code assigned to a course.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation.TeacherCandidateStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation.EndDate IS 'The end date for the association';

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4] --
COMMENT ON TABLE tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 IS 'Any education organizations associated with the teacher candidate''s student growth data, if applicable.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4.TeacherCandidateStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4.EndDate IS 'The end date for the association';

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureGradeLevel] --
COMMENT ON TABLE tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel IS 'This descriptor defines the set of grade levels.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel.GradeLevelDescriptorId IS 'This descriptor defines the set of grade levels.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel.TeacherCandidateStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';

-- Extended Properties [tpdm].[TeacherCandidateStudentGrowthMeasureSectionAssociation] --
COMMENT ON TABLE tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation IS 'Any sections associated with the teacher candidate''s student growth data, if applicable.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.FactAsOfDate IS 'The date for which the data element is relevant';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.SchoolYear IS 'The school year for which the data is associated';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.TeacherCandidateStudentGrowthMeasureIdentifier IS 'Assigned unique identifier for the student growth measure.';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.BeginDate IS 'Begin date for the association';
COMMENT ON COLUMN tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation.EndDate IS 'The end date for the association';

-- Extended Properties [tpdm].[TeacherCandidateTeacherPreparationProviderAssociation] --
COMMENT ON TABLE tpdm.TeacherCandidateTeacherPreparationProviderAssociation IS 'Information about the association between the Teacher Candidate and the TeacherPreparationProviderProgram';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderAssociation.EntryDate IS 'Entry date for the association';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderAssociation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderAssociation.TeacherPreparationProviderId IS 'The unique identification code for the Teacher Preparation Provider';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderAssociation.SchoolYear IS 'School Year for the association';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderAssociation.EntryTypeDescriptorId IS 'Entry Type for the association';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderAssociation.ExitWithdrawDate IS 'Exit date for the association';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderAssociation.ExitWithdrawTypeDescriptorId IS 'Exit type for the association';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderAssociation.ClassOfSchoolYear IS 'School Year cohort for the association';

-- Extended Properties [tpdm].[TeacherCandidateTeacherPreparationProviderProgramAssociation] --
COMMENT ON TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation IS 'Information about the association between the Teacher Candidate and the TeacherPreparationProviderProgram';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation.BeginDate IS 'The begin date for the association.';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation.ProgramName IS 'The name of the Teacher Preparation Program.';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation.EndDate IS 'The end date for the association.';
COMMENT ON COLUMN tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation.ReasonExitedDescriptorId IS 'Reason exited for the association.';

-- Extended Properties [tpdm].[TeacherCandidateTelephone] --
COMMENT ON TABLE tpdm.TeacherCandidateTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN tpdm.TeacherCandidateTelephone.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN tpdm.TeacherCandidateTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN tpdm.TeacherCandidateTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN tpdm.TeacherCandidateTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN tpdm.TeacherCandidateTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [tpdm].[TeacherCandidateTPPProgramDegree] --
COMMENT ON TABLE tpdm.TeacherCandidateTPPProgramDegree IS 'Details of the degree.';
COMMENT ON COLUMN tpdm.TeacherCandidateTPPProgramDegree.AcademicSubjectDescriptorId IS 'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a degree.';
COMMENT ON COLUMN tpdm.TeacherCandidateTPPProgramDegree.GradeLevelDescriptorId IS 'The grade level associated with the degree plan for the teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateTPPProgramDegree.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateTPPProgramDegree.TPPDegreeTypeDescriptorId IS 'A code for describing the degree type that a teacher candidate accomplishes.';

-- Extended Properties [tpdm].[TeacherCandidateVisa] --
COMMENT ON TABLE tpdm.TeacherCandidateVisa IS 'An indicator of a non-US citizen''s Visa type.';
COMMENT ON COLUMN tpdm.TeacherCandidateVisa.TeacherCandidateIdentifier IS 'A unique alphanumeric code assigned to a teacher candidate.';
COMMENT ON COLUMN tpdm.TeacherCandidateVisa.VisaDescriptorId IS 'An indicator of a non-US citizen''s Visa type.';

-- Extended Properties [tpdm].[TeacherPreparationProgramTypeDescriptor] --
COMMENT ON TABLE tpdm.TeacherPreparationProgramTypeDescriptor IS 'The descriptor holds the type of teacher prep program (e.g., college, alternative, TFA, etc.).';
COMMENT ON COLUMN tpdm.TeacherPreparationProgramTypeDescriptor.TeacherPreparationProgramTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[TeacherPreparationProvider] --
COMMENT ON TABLE tpdm.TeacherPreparationProvider IS 'This entity represents an educational organization that includes staff and students who participate in classes and educational activity groups.';
COMMENT ON COLUMN tpdm.TeacherPreparationProvider.TeacherPreparationProviderId IS 'The unique identification code for the Teacher Preparation Provider';
COMMENT ON COLUMN tpdm.TeacherPreparationProvider.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';
COMMENT ON COLUMN tpdm.TeacherPreparationProvider.AccreditationStatusDescriptorId IS 'Accreditation Status for a Teacher Preparation Provider.';
COMMENT ON COLUMN tpdm.TeacherPreparationProvider.UniversityId IS 'The unique identification code of the University';
COMMENT ON COLUMN tpdm.TeacherPreparationProvider.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [tpdm].[TeacherPreparationProviderProgram] --
COMMENT ON TABLE tpdm.TeacherPreparationProviderProgram IS 'This entity represents information regarding a teacher preparation provider program.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgram.ProgramName IS 'The name of the Teacher Preparation Program.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgram.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgram.ProgramId IS 'A unique number or alphanumeric code assigned to a program by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgram.MajorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgram.MinorSpecialization IS 'The minor area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgram.TeacherPreparationProgramTypeDescriptorId IS 'The descriptor holds the type of teacher prep program (e.g., college, alternative, TFA, etc.).';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgram.TPPProgramPathwayDescriptorId IS 'A code for describing the program pathway, for example: Residency, Internship, Traditional';

-- Extended Properties [tpdm].[TeacherPreparationProviderProgramGradeLevel] --
COMMENT ON TABLE tpdm.TeacherPreparationProviderProgramGradeLevel IS 'The grade levels served at the TPP Program.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgramGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgramGradeLevel.GradeLevelDescriptorId IS 'The grade levels served at the TPP Program.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgramGradeLevel.ProgramName IS 'The name of the Teacher Preparation Program.';
COMMENT ON COLUMN tpdm.TeacherPreparationProviderProgramGradeLevel.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [tpdm].[TPPDegreeTypeDescriptor] --
COMMENT ON TABLE tpdm.TPPDegreeTypeDescriptor IS 'The descriptor holds the degree that a teacher candidate accomplishes.';
COMMENT ON COLUMN tpdm.TPPDegreeTypeDescriptor.TPPDegreeTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[TPPProgramPathwayDescriptor] --
COMMENT ON TABLE tpdm.TPPProgramPathwayDescriptor IS 'The descriptor holds the program pathways available at TPP''s.';
COMMENT ON COLUMN tpdm.TPPProgramPathwayDescriptor.TPPProgramPathwayDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[University] --
COMMENT ON TABLE tpdm.University IS 'This entity represents an educational organization that includes staff and students who participate in classes and educational activity groups.';
COMMENT ON COLUMN tpdm.University.UniversityId IS 'The unique identification code of the University';
COMMENT ON COLUMN tpdm.University.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';
COMMENT ON COLUMN tpdm.University.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [tpdm].[ValueTypeDescriptor] --
COMMENT ON TABLE tpdm.ValueTypeDescriptor IS 'The type (i.e. actual or projected) of value.';
COMMENT ON COLUMN tpdm.ValueTypeDescriptor.ValueTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[WithdrawReasonDescriptor] --
COMMENT ON TABLE tpdm.WithdrawReasonDescriptor IS 'The descriptor holds the reason applicant withdrew application.';
COMMENT ON COLUMN tpdm.WithdrawReasonDescriptor.WithdrawReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

