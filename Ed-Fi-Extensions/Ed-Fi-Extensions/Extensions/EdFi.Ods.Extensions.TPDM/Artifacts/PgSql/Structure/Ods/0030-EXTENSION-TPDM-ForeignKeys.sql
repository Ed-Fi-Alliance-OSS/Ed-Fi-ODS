-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
  
ALTER TABLE tpdm.AccreditationStatusDescriptor ADD CONSTRAINT FK_69de81_Descriptor FOREIGN KEY (AccreditationStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.AidTypeDescriptor ADD CONSTRAINT FK_d6106a_Descriptor FOREIGN KEY (AidTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.AnonymizedStudent ADD CONSTRAINT FK_91a31b_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_91a31b_GenderDescriptor
ON tpdm.AnonymizedStudent (GenderDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudent ADD CONSTRAINT FK_91a31b_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_91a31b_GradeLevelDescriptor
ON tpdm.AnonymizedStudent (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudent ADD CONSTRAINT FK_91a31b_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_91a31b_SchoolYearType
ON tpdm.AnonymizedStudent (SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudent ADD CONSTRAINT FK_91a31b_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_91a31b_SexDescriptor
ON tpdm.AnonymizedStudent (SexDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudent ADD CONSTRAINT FK_91a31b_ValueTypeDescriptor FOREIGN KEY (ValueTypeDescriptorId)
REFERENCES tpdm.ValueTypeDescriptor (ValueTypeDescriptorId)
;

CREATE INDEX FK_91a31b_ValueTypeDescriptor
ON tpdm.AnonymizedStudent (ValueTypeDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAcademicRecord ADD CONSTRAINT FK_a5aeb2_AnonymizedStudent FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudent (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
;

CREATE INDEX FK_a5aeb2_AnonymizedStudent
ON tpdm.AnonymizedStudentAcademicRecord (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentAcademicRecord ADD CONSTRAINT FK_a5aeb2_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_a5aeb2_EducationOrganization
ON tpdm.AnonymizedStudentAcademicRecord (EducationOrganizationId ASC);

ALTER TABLE tpdm.AnonymizedStudentAcademicRecord ADD CONSTRAINT FK_a5aeb2_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_a5aeb2_SchoolYearType
ON tpdm.AnonymizedStudentAcademicRecord (SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentAcademicRecord ADD CONSTRAINT FK_a5aeb2_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_a5aeb2_TermDescriptor
ON tpdm.AnonymizedStudentAcademicRecord (TermDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessment ADD CONSTRAINT FK_e4eb73_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_e4eb73_AcademicSubjectDescriptor
ON tpdm.AnonymizedStudentAssessment (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessment ADD CONSTRAINT FK_e4eb73_AnonymizedStudent FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudent (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
;

CREATE INDEX FK_e4eb73_AnonymizedStudent
ON tpdm.AnonymizedStudentAssessment (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessment ADD CONSTRAINT FK_e4eb73_AssessmentCategoryDescriptor FOREIGN KEY (AssessmentCategoryDescriptorId)
REFERENCES edfi.AssessmentCategoryDescriptor (AssessmentCategoryDescriptorId)
;

CREATE INDEX FK_e4eb73_AssessmentCategoryDescriptor
ON tpdm.AnonymizedStudentAssessment (AssessmentCategoryDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessment ADD CONSTRAINT FK_e4eb73_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_e4eb73_GradeLevelDescriptor
ON tpdm.AnonymizedStudentAssessment (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessment ADD CONSTRAINT FK_e4eb73_SchoolYearType FOREIGN KEY (TakenSchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_e4eb73_SchoolYearType
ON tpdm.AnonymizedStudentAssessment (TakenSchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessment ADD CONSTRAINT FK_e4eb73_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_e4eb73_TermDescriptor
ON tpdm.AnonymizedStudentAssessment (TermDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessmentCourseAssociation ADD CONSTRAINT FK_e6ba6c_AnonymizedStudentAssessment FOREIGN KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
REFERENCES tpdm.AnonymizedStudentAssessment (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
;

CREATE INDEX FK_e6ba6c_AnonymizedStudentAssessment
ON tpdm.AnonymizedStudentAssessmentCourseAssociation (AdministrationDate ASC, AnonymizedStudentIdentifier ASC, AssessmentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC, TakenSchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessmentCourseAssociation ADD CONSTRAINT FK_e6ba6c_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_e6ba6c_Course
ON tpdm.AnonymizedStudentAssessmentCourseAssociation (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessmentPerformanceLevel ADD CONSTRAINT FK_38094a_AnonymizedStudentAssessment FOREIGN KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
REFERENCES tpdm.AnonymizedStudentAssessment (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
ON DELETE CASCADE
;

ALTER TABLE tpdm.AnonymizedStudentAssessmentPerformanceLevel ADD CONSTRAINT FK_38094a_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_38094a_AssessmentReportingMethodDescriptor
ON tpdm.AnonymizedStudentAssessmentPerformanceLevel (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessmentPerformanceLevel ADD CONSTRAINT FK_38094a_PerformanceLevelDescriptor FOREIGN KEY (PerformanceLevelDescriptorId)
REFERENCES edfi.PerformanceLevelDescriptor (PerformanceLevelDescriptorId)
;

CREATE INDEX FK_38094a_PerformanceLevelDescriptor
ON tpdm.AnonymizedStudentAssessmentPerformanceLevel (PerformanceLevelDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessmentScoreResult ADD CONSTRAINT FK_2361cb_AnonymizedStudentAssessment FOREIGN KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
REFERENCES tpdm.AnonymizedStudentAssessment (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
ON DELETE CASCADE
;

ALTER TABLE tpdm.AnonymizedStudentAssessmentScoreResult ADD CONSTRAINT FK_2361cb_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_2361cb_AssessmentReportingMethodDescriptor
ON tpdm.AnonymizedStudentAssessmentScoreResult (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessmentScoreResult ADD CONSTRAINT FK_2361cb_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_2361cb_ResultDatatypeTypeDescriptor
ON tpdm.AnonymizedStudentAssessmentScoreResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessmentSectionAssociation ADD CONSTRAINT FK_64d5d3_AnonymizedStudentAssessment FOREIGN KEY (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
REFERENCES tpdm.AnonymizedStudentAssessment (AdministrationDate, AnonymizedStudentIdentifier, AssessmentIdentifier, FactsAsOfDate, SchoolYear, TakenSchoolYear)
;

CREATE INDEX FK_64d5d3_AnonymizedStudentAssessment
ON tpdm.AnonymizedStudentAssessmentSectionAssociation (AdministrationDate ASC, AnonymizedStudentIdentifier ASC, AssessmentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC, TakenSchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentAssessmentSectionAssociation ADD CONSTRAINT FK_64d5d3_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_64d5d3_Section
ON tpdm.AnonymizedStudentAssessmentSectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE tpdm.AnonymizedStudentCourseAssociation ADD CONSTRAINT FK_2abb16_AnonymizedStudent FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudent (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
;

CREATE INDEX FK_2abb16_AnonymizedStudent
ON tpdm.AnonymizedStudentCourseAssociation (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentCourseAssociation ADD CONSTRAINT FK_2abb16_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_2abb16_Course
ON tpdm.AnonymizedStudentCourseAssociation (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.AnonymizedStudentCourseTranscript ADD CONSTRAINT FK_d194a8_AnonymizedStudentAcademicRecord FOREIGN KEY (AnonymizedStudentIdentifier, EducationOrganizationId, FactAsOfDate, FactsAsOfDate, SchoolYear, TermDescriptorId)
REFERENCES tpdm.AnonymizedStudentAcademicRecord (AnonymizedStudentIdentifier, EducationOrganizationId, FactAsOfDate, FactsAsOfDate, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_d194a8_AnonymizedStudentAcademicRecord
ON tpdm.AnonymizedStudentCourseTranscript (AnonymizedStudentIdentifier ASC, EducationOrganizationId ASC, FactAsOfDate ASC, FactsAsOfDate ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentCourseTranscript ADD CONSTRAINT FK_d194a8_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_d194a8_Course
ON tpdm.AnonymizedStudentCourseTranscript (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.AnonymizedStudentCourseTranscript ADD CONSTRAINT FK_d194a8_CourseRepeatCodeDescriptor FOREIGN KEY (CourseRepeatCodeDescriptorId)
REFERENCES edfi.CourseRepeatCodeDescriptor (CourseRepeatCodeDescriptorId)
;

CREATE INDEX FK_d194a8_CourseRepeatCodeDescriptor
ON tpdm.AnonymizedStudentCourseTranscript (CourseRepeatCodeDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentDisability ADD CONSTRAINT FK_9a85dd_AnonymizedStudent FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudent (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_9a85dd_AnonymizedStudent
ON tpdm.AnonymizedStudentDisability (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentDisability ADD CONSTRAINT FK_9a85dd_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_9a85dd_DisabilityDescriptor
ON tpdm.AnonymizedStudentDisability (DisabilityDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentDisability ADD CONSTRAINT FK_9a85dd_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_9a85dd_DisabilityDeterminationSourceTypeDescriptor
ON tpdm.AnonymizedStudentDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentDisabilityDesignation ADD CONSTRAINT FK_3e62fb_AnonymizedStudentDisability FOREIGN KEY (AnonymizedStudentIdentifier, DisabilityDescriptorId, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudentDisability (AnonymizedStudentIdentifier, DisabilityDescriptorId, FactsAsOfDate, SchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_3e62fb_AnonymizedStudentDisability
ON tpdm.AnonymizedStudentDisabilityDesignation (AnonymizedStudentIdentifier ASC, DisabilityDescriptorId ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentDisabilityDesignation ADD CONSTRAINT FK_3e62fb_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_3e62fb_DisabilityDesignationDescriptor
ON tpdm.AnonymizedStudentDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentEducationOrganizationAssociation ADD CONSTRAINT FK_7f59f4_AnonymizedStudent FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudent (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
;

CREATE INDEX FK_7f59f4_AnonymizedStudent
ON tpdm.AnonymizedStudentEducationOrganizationAssociation (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentEducationOrganizationAssociation ADD CONSTRAINT FK_7f59f4_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_7f59f4_EducationOrganization
ON tpdm.AnonymizedStudentEducationOrganizationAssociation (EducationOrganizationId ASC);

ALTER TABLE tpdm.AnonymizedStudentLanguage ADD CONSTRAINT FK_22e3fe_AnonymizedStudent FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudent (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_22e3fe_AnonymizedStudent
ON tpdm.AnonymizedStudentLanguage (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentLanguage ADD CONSTRAINT FK_22e3fe_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_22e3fe_LanguageDescriptor
ON tpdm.AnonymizedStudentLanguage (LanguageDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentLanguageUse ADD CONSTRAINT FK_4a60dd_AnonymizedStudentLanguage FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, LanguageDescriptorId, SchoolYear)
REFERENCES tpdm.AnonymizedStudentLanguage (AnonymizedStudentIdentifier, FactsAsOfDate, LanguageDescriptorId, SchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_4a60dd_AnonymizedStudentLanguage
ON tpdm.AnonymizedStudentLanguageUse (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, LanguageDescriptorId ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentLanguageUse ADD CONSTRAINT FK_4a60dd_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_4a60dd_LanguageUseDescriptor
ON tpdm.AnonymizedStudentLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentRace ADD CONSTRAINT FK_5da6a4_AnonymizedStudent FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudent (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_5da6a4_AnonymizedStudent
ON tpdm.AnonymizedStudentRace (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentRace ADD CONSTRAINT FK_5da6a4_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_5da6a4_RaceDescriptor
ON tpdm.AnonymizedStudentRace (RaceDescriptorId ASC);

ALTER TABLE tpdm.AnonymizedStudentSectionAssociation ADD CONSTRAINT FK_562e9d_AnonymizedStudent FOREIGN KEY (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
REFERENCES tpdm.AnonymizedStudent (AnonymizedStudentIdentifier, FactsAsOfDate, SchoolYear)
;

CREATE INDEX FK_562e9d_AnonymizedStudent
ON tpdm.AnonymizedStudentSectionAssociation (AnonymizedStudentIdentifier ASC, FactsAsOfDate ASC, SchoolYear ASC);

ALTER TABLE tpdm.AnonymizedStudentSectionAssociation ADD CONSTRAINT FK_562e9d_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_562e9d_Section
ON tpdm.AnonymizedStudentSectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE tpdm.Applicant ADD CONSTRAINT FK_0a1ce1_CitizenshipStatusDescriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.CitizenshipStatusDescriptor (CitizenshipStatusDescriptorId)
;

CREATE INDEX FK_0a1ce1_CitizenshipStatusDescriptor
ON tpdm.Applicant (CitizenshipStatusDescriptorId ASC);

ALTER TABLE tpdm.Applicant ADD CONSTRAINT FK_0a1ce1_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_0a1ce1_GenderDescriptor
ON tpdm.Applicant (GenderDescriptorId ASC);

ALTER TABLE tpdm.Applicant ADD CONSTRAINT FK_0a1ce1_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_0a1ce1_Person
ON tpdm.Applicant (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.Applicant ADD CONSTRAINT FK_0a1ce1_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_0a1ce1_SexDescriptor
ON tpdm.Applicant (SexDescriptorId ASC);

ALTER TABLE tpdm.Applicant ADD CONSTRAINT FK_0a1ce1_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_0a1ce1_TeacherCandidate
ON tpdm.Applicant (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.ApplicantAddress ADD CONSTRAINT FK_dc1bbc_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_dc1bbc_AddressTypeDescriptor
ON tpdm.ApplicantAddress (AddressTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantAddress ADD CONSTRAINT FK_dc1bbc_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_dc1bbc_Applicant
ON tpdm.ApplicantAddress (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantAddress ADD CONSTRAINT FK_dc1bbc_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_dc1bbc_LocaleDescriptor
ON tpdm.ApplicantAddress (LocaleDescriptorId ASC);

ALTER TABLE tpdm.ApplicantAddress ADD CONSTRAINT FK_dc1bbc_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_dc1bbc_StateAbbreviationDescriptor
ON tpdm.ApplicantAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantAddressPeriod ADD CONSTRAINT FK_3a403c_ApplicantAddress FOREIGN KEY (AddressTypeDescriptorId, ApplicantIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES tpdm.ApplicantAddress (AddressTypeDescriptorId, ApplicantIdentifier, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

CREATE INDEX FK_3a403c_ApplicantAddress
ON tpdm.ApplicantAddressPeriod (AddressTypeDescriptorId ASC, ApplicantIdentifier ASC, City ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC);

ALTER TABLE tpdm.ApplicantAid ADD CONSTRAINT FK_664f50_AidTypeDescriptor FOREIGN KEY (AidTypeDescriptorId)
REFERENCES tpdm.AidTypeDescriptor (AidTypeDescriptorId)
;

CREATE INDEX FK_664f50_AidTypeDescriptor
ON tpdm.ApplicantAid (AidTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantAid ADD CONSTRAINT FK_664f50_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_664f50_Applicant
ON tpdm.ApplicantAid (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantBackgroundCheck ADD CONSTRAINT FK_ca0f8c_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_ca0f8c_Applicant
ON tpdm.ApplicantBackgroundCheck (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantBackgroundCheck ADD CONSTRAINT FK_ca0f8c_BackgroundCheckStatusDescriptor FOREIGN KEY (BackgroundCheckStatusDescriptorId)
REFERENCES tpdm.BackgroundCheckStatusDescriptor (BackgroundCheckStatusDescriptorId)
;

CREATE INDEX FK_ca0f8c_BackgroundCheckStatusDescriptor
ON tpdm.ApplicantBackgroundCheck (BackgroundCheckStatusDescriptorId ASC);

ALTER TABLE tpdm.ApplicantBackgroundCheck ADD CONSTRAINT FK_ca0f8c_BackgroundCheckTypeDescriptor FOREIGN KEY (BackgroundCheckTypeDescriptorId)
REFERENCES tpdm.BackgroundCheckTypeDescriptor (BackgroundCheckTypeDescriptorId)
;

CREATE INDEX FK_ca0f8c_BackgroundCheckTypeDescriptor
ON tpdm.ApplicantBackgroundCheck (BackgroundCheckTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantCharacteristic ADD CONSTRAINT FK_12b3e2_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_12b3e2_Applicant
ON tpdm.ApplicantCharacteristic (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantCharacteristic ADD CONSTRAINT FK_12b3e2_StudentCharacteristicDescriptor FOREIGN KEY (StudentCharacteristicDescriptorId)
REFERENCES edfi.StudentCharacteristicDescriptor (StudentCharacteristicDescriptorId)
;

CREATE INDEX FK_12b3e2_StudentCharacteristicDescriptor
ON tpdm.ApplicantCharacteristic (StudentCharacteristicDescriptorId ASC);

ALTER TABLE tpdm.ApplicantDisability ADD CONSTRAINT FK_3ccfc3_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_3ccfc3_Applicant
ON tpdm.ApplicantDisability (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantDisability ADD CONSTRAINT FK_3ccfc3_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_3ccfc3_DisabilityDescriptor
ON tpdm.ApplicantDisability (DisabilityDescriptorId ASC);

ALTER TABLE tpdm.ApplicantDisability ADD CONSTRAINT FK_3ccfc3_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_3ccfc3_DisabilityDeterminationSourceTypeDescriptor
ON tpdm.ApplicantDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantDisabilityDesignation ADD CONSTRAINT FK_76fa33_ApplicantDisability FOREIGN KEY (ApplicantIdentifier, DisabilityDescriptorId)
REFERENCES tpdm.ApplicantDisability (ApplicantIdentifier, DisabilityDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_76fa33_ApplicantDisability
ON tpdm.ApplicantDisabilityDesignation (ApplicantIdentifier ASC, DisabilityDescriptorId ASC);

ALTER TABLE tpdm.ApplicantDisabilityDesignation ADD CONSTRAINT FK_76fa33_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_76fa33_DisabilityDesignationDescriptor
ON tpdm.ApplicantDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantElectronicMail ADD CONSTRAINT FK_2e402a_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_2e402a_Applicant
ON tpdm.ApplicantElectronicMail (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantElectronicMail ADD CONSTRAINT FK_2e402a_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

CREATE INDEX FK_2e402a_ElectronicMailTypeDescriptor
ON tpdm.ApplicantElectronicMail (ElectronicMailTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantIdentificationDocument ADD CONSTRAINT FK_e89a68_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_e89a68_Applicant
ON tpdm.ApplicantIdentificationDocument (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantIdentificationDocument ADD CONSTRAINT FK_e89a68_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_e89a68_CountryDescriptor
ON tpdm.ApplicantIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.ApplicantIdentificationDocument ADD CONSTRAINT FK_e89a68_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_e89a68_IdentificationDocumentUseDescriptor
ON tpdm.ApplicantIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.ApplicantIdentificationDocument ADD CONSTRAINT FK_e89a68_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_e89a68_PersonalInformationVerificationDescriptor
ON tpdm.ApplicantIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantInternationalAddress ADD CONSTRAINT FK_764520_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_764520_AddressTypeDescriptor
ON tpdm.ApplicantInternationalAddress (AddressTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantInternationalAddress ADD CONSTRAINT FK_764520_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_764520_Applicant
ON tpdm.ApplicantInternationalAddress (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantInternationalAddress ADD CONSTRAINT FK_764520_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_764520_CountryDescriptor
ON tpdm.ApplicantInternationalAddress (CountryDescriptorId ASC);

ALTER TABLE tpdm.ApplicantLanguage ADD CONSTRAINT FK_23ffbd_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_23ffbd_Applicant
ON tpdm.ApplicantLanguage (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantLanguage ADD CONSTRAINT FK_23ffbd_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_23ffbd_LanguageDescriptor
ON tpdm.ApplicantLanguage (LanguageDescriptorId ASC);

ALTER TABLE tpdm.ApplicantLanguageUse ADD CONSTRAINT FK_527711_ApplicantLanguage FOREIGN KEY (ApplicantIdentifier, LanguageDescriptorId)
REFERENCES tpdm.ApplicantLanguage (ApplicantIdentifier, LanguageDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_527711_ApplicantLanguage
ON tpdm.ApplicantLanguageUse (ApplicantIdentifier ASC, LanguageDescriptorId ASC);

ALTER TABLE tpdm.ApplicantLanguageUse ADD CONSTRAINT FK_527711_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_527711_LanguageUseDescriptor
ON tpdm.ApplicantLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE tpdm.ApplicantPersonalIdentificationDocument ADD CONSTRAINT FK_4c9a54_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_4c9a54_Applicant
ON tpdm.ApplicantPersonalIdentificationDocument (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantPersonalIdentificationDocument ADD CONSTRAINT FK_4c9a54_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_4c9a54_CountryDescriptor
ON tpdm.ApplicantPersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.ApplicantPersonalIdentificationDocument ADD CONSTRAINT FK_4c9a54_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_4c9a54_IdentificationDocumentUseDescriptor
ON tpdm.ApplicantPersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.ApplicantPersonalIdentificationDocument ADD CONSTRAINT FK_4c9a54_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_4c9a54_PersonalInformationVerificationDescriptor
ON tpdm.ApplicantPersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.ApplicantProspectAssociation ADD CONSTRAINT FK_57cdba_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
;

CREATE INDEX FK_57cdba_Applicant
ON tpdm.ApplicantProspectAssociation (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantProspectAssociation ADD CONSTRAINT FK_57cdba_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
;

CREATE INDEX FK_57cdba_Prospect
ON tpdm.ApplicantProspectAssociation (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ApplicantRace ADD CONSTRAINT FK_991ae6_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_991ae6_Applicant
ON tpdm.ApplicantRace (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantRace ADD CONSTRAINT FK_991ae6_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_991ae6_RaceDescriptor
ON tpdm.ApplicantRace (RaceDescriptorId ASC);

ALTER TABLE tpdm.ApplicantStaffIdentificationCode ADD CONSTRAINT FK_e02fd4_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_e02fd4_Applicant
ON tpdm.ApplicantStaffIdentificationCode (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantStaffIdentificationCode ADD CONSTRAINT FK_e02fd4_StaffIdentificationSystemDescriptor FOREIGN KEY (StaffIdentificationSystemDescriptorId)
REFERENCES edfi.StaffIdentificationSystemDescriptor (StaffIdentificationSystemDescriptorId)
;

CREATE INDEX FK_e02fd4_StaffIdentificationSystemDescriptor
ON tpdm.ApplicantStaffIdentificationCode (StaffIdentificationSystemDescriptorId ASC);

ALTER TABLE tpdm.ApplicantTeacherPreparationProgram ADD CONSTRAINT FK_468674_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_468674_Applicant
ON tpdm.ApplicantTeacherPreparationProgram (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantTeacherPreparationProgram ADD CONSTRAINT FK_468674_LevelOfDegreeAwardedDescriptor FOREIGN KEY (LevelOfDegreeAwardedDescriptorId)
REFERENCES tpdm.LevelOfDegreeAwardedDescriptor (LevelOfDegreeAwardedDescriptorId)
;

CREATE INDEX FK_468674_LevelOfDegreeAwardedDescriptor
ON tpdm.ApplicantTeacherPreparationProgram (LevelOfDegreeAwardedDescriptorId ASC);

ALTER TABLE tpdm.ApplicantTeacherPreparationProgram ADD CONSTRAINT FK_468674_TeacherPreparationProgramTypeDescriptor FOREIGN KEY (TeacherPreparationProgramTypeDescriptorId)
REFERENCES tpdm.TeacherPreparationProgramTypeDescriptor (TeacherPreparationProgramTypeDescriptorId)
;

CREATE INDEX FK_468674_TeacherPreparationProgramTypeDescriptor
ON tpdm.ApplicantTeacherPreparationProgram (TeacherPreparationProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantTelephone ADD CONSTRAINT FK_06c96d_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_06c96d_Applicant
ON tpdm.ApplicantTelephone (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantTelephone ADD CONSTRAINT FK_06c96d_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_06c96d_TelephoneNumberTypeDescriptor
ON tpdm.ApplicantTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicantVisa ADD CONSTRAINT FK_6b737c_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_6b737c_Applicant
ON tpdm.ApplicantVisa (ApplicantIdentifier ASC);

ALTER TABLE tpdm.ApplicantVisa ADD CONSTRAINT FK_6b737c_VisaDescriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.VisaDescriptor (VisaDescriptorId)
;

CREATE INDEX FK_6b737c_VisaDescriptor
ON tpdm.ApplicantVisa (VisaDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_e7ad52_AcademicSubjectDescriptor
ON tpdm.Application (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_AcademicSubjectDescriptor1 FOREIGN KEY (HighNeedsAcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_e7ad52_AcademicSubjectDescriptor1
ON tpdm.Application (HighNeedsAcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_AcademicSubjectDescriptor2 FOREIGN KEY (HighlyQualifiedAcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_e7ad52_AcademicSubjectDescriptor2
ON tpdm.Application (HighlyQualifiedAcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
;

CREATE INDEX FK_e7ad52_Applicant
ON tpdm.Application (ApplicantIdentifier ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_ApplicationSourceDescriptor FOREIGN KEY (ApplicationSourceDescriptorId)
REFERENCES tpdm.ApplicationSourceDescriptor (ApplicationSourceDescriptorId)
;

CREATE INDEX FK_e7ad52_ApplicationSourceDescriptor
ON tpdm.Application (ApplicationSourceDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_ApplicationStatusDescriptor FOREIGN KEY (ApplicationStatusDescriptorId)
REFERENCES tpdm.ApplicationStatusDescriptor (ApplicationStatusDescriptorId)
;

CREATE INDEX FK_e7ad52_ApplicationStatusDescriptor
ON tpdm.Application (ApplicationStatusDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_e7ad52_EducationOrganization
ON tpdm.Application (EducationOrganizationId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_HireStatusDescriptor FOREIGN KEY (HireStatusDescriptorId)
REFERENCES tpdm.HireStatusDescriptor (HireStatusDescriptorId)
;

CREATE INDEX FK_e7ad52_HireStatusDescriptor
ON tpdm.Application (HireStatusDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_HiringSourceDescriptor FOREIGN KEY (HiringSourceDescriptorId)
REFERENCES tpdm.HiringSourceDescriptor (HiringSourceDescriptorId)
;

CREATE INDEX FK_e7ad52_HiringSourceDescriptor
ON tpdm.Application (HiringSourceDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_LevelOfEducationDescriptor FOREIGN KEY (HighestCompletedLevelOfEducationDescriptorId)
REFERENCES edfi.LevelOfEducationDescriptor (LevelOfEducationDescriptorId)
;

CREATE INDEX FK_e7ad52_LevelOfEducationDescriptor
ON tpdm.Application (HighestCompletedLevelOfEducationDescriptorId ASC);

ALTER TABLE tpdm.Application ADD CONSTRAINT FK_e7ad52_WithdrawReasonDescriptor FOREIGN KEY (WithdrawReasonDescriptorId)
REFERENCES tpdm.WithdrawReasonDescriptor (WithdrawReasonDescriptorId)
;

CREATE INDEX FK_e7ad52_WithdrawReasonDescriptor
ON tpdm.Application (WithdrawReasonDescriptorId ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_Application FOREIGN KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
;

CREATE INDEX FK_143de6_Application
ON tpdm.ApplicationEvent (ApplicantIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_ApplicationEventResultDescriptor FOREIGN KEY (ApplicationEventResultDescriptorId)
REFERENCES tpdm.ApplicationEventResultDescriptor (ApplicationEventResultDescriptorId)
;

CREATE INDEX FK_143de6_ApplicationEventResultDescriptor
ON tpdm.ApplicationEvent (ApplicationEventResultDescriptorId ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_ApplicationEventTypeDescriptor FOREIGN KEY (ApplicationEventTypeDescriptorId)
REFERENCES tpdm.ApplicationEventTypeDescriptor (ApplicationEventTypeDescriptorId)
;

CREATE INDEX FK_143de6_ApplicationEventTypeDescriptor
ON tpdm.ApplicationEvent (ApplicationEventTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_143de6_SchoolYearType
ON tpdm.ApplicationEvent (SchoolYear ASC);

ALTER TABLE tpdm.ApplicationEvent ADD CONSTRAINT FK_143de6_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_143de6_TermDescriptor
ON tpdm.ApplicationEvent (TermDescriptorId ASC);

ALTER TABLE tpdm.ApplicationEventResultDescriptor ADD CONSTRAINT FK_3ade4b_Descriptor FOREIGN KEY (ApplicationEventResultDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicationEventTypeDescriptor ADD CONSTRAINT FK_07ba8e_Descriptor FOREIGN KEY (ApplicationEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicationGradePointAverage ADD CONSTRAINT FK_178330_Application FOREIGN KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_178330_Application
ON tpdm.ApplicationGradePointAverage (ApplicantIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationGradePointAverage ADD CONSTRAINT FK_178330_GradePointAverageTypeDescriptor FOREIGN KEY (GradePointAverageTypeDescriptorId)
REFERENCES edfi.GradePointAverageTypeDescriptor (GradePointAverageTypeDescriptorId)
;

CREATE INDEX FK_178330_GradePointAverageTypeDescriptor
ON tpdm.ApplicationGradePointAverage (GradePointAverageTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicationOpenStaffPosition ADD CONSTRAINT FK_078448_Application FOREIGN KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_078448_Application
ON tpdm.ApplicationOpenStaffPosition (ApplicantIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationOpenStaffPosition ADD CONSTRAINT FK_078448_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
;

CREATE INDEX FK_078448_OpenStaffPosition
ON tpdm.ApplicationOpenStaffPosition (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE tpdm.ApplicationScoreResult ADD CONSTRAINT FK_876029_Application FOREIGN KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_876029_Application
ON tpdm.ApplicationScoreResult (ApplicantIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationScoreResult ADD CONSTRAINT FK_876029_AssessmentReportingMethodDescriptor FOREIGN KEY (AssessmentReportingMethodDescriptorId)
REFERENCES edfi.AssessmentReportingMethodDescriptor (AssessmentReportingMethodDescriptorId)
;

CREATE INDEX FK_876029_AssessmentReportingMethodDescriptor
ON tpdm.ApplicationScoreResult (AssessmentReportingMethodDescriptorId ASC);

ALTER TABLE tpdm.ApplicationScoreResult ADD CONSTRAINT FK_876029_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_876029_ResultDatatypeTypeDescriptor
ON tpdm.ApplicationScoreResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.ApplicationSourceDescriptor ADD CONSTRAINT FK_bbb2ec_Descriptor FOREIGN KEY (ApplicationSourceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicationStatusDescriptor ADD CONSTRAINT FK_268ed8_Descriptor FOREIGN KEY (ApplicationStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ApplicationTerm ADD CONSTRAINT FK_dff24c_Application FOREIGN KEY (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
REFERENCES tpdm.Application (ApplicantIdentifier, ApplicationIdentifier, EducationOrganizationId)
ON DELETE CASCADE
;

CREATE INDEX FK_dff24c_Application
ON tpdm.ApplicationTerm (ApplicantIdentifier ASC, ApplicationIdentifier ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.ApplicationTerm ADD CONSTRAINT FK_dff24c_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_dff24c_TermDescriptor
ON tpdm.ApplicationTerm (TermDescriptorId ASC);

ALTER TABLE tpdm.AssessmentExtension ADD CONSTRAINT FK_75a008_Assessment FOREIGN KEY (AssessmentIdentifier, Namespace)
REFERENCES edfi.Assessment (AssessmentIdentifier, Namespace)
ON DELETE CASCADE
;

ALTER TABLE tpdm.AssessmentExtension ADD CONSTRAINT FK_75a008_ProgramGatewayDescriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES tpdm.ProgramGatewayDescriptor (ProgramGatewayDescriptorId)
;

CREATE INDEX FK_75a008_ProgramGatewayDescriptor
ON tpdm.AssessmentExtension (ProgramGatewayDescriptorId ASC);

ALTER TABLE tpdm.BackgroundCheckStatusDescriptor ADD CONSTRAINT FK_00ba96_Descriptor FOREIGN KEY (BackgroundCheckStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.BackgroundCheckTypeDescriptor ADD CONSTRAINT FK_ed9c02_Descriptor FOREIGN KEY (BackgroundCheckTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_CertificationFieldDescriptor FOREIGN KEY (CertificationFieldDescriptorId)
REFERENCES tpdm.CertificationFieldDescriptor (CertificationFieldDescriptorId)
;

CREATE INDEX FK_86846f_CertificationFieldDescriptor
ON tpdm.Certification (CertificationFieldDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_CertificationLevelDescriptor FOREIGN KEY (CertificationLevelDescriptorId)
REFERENCES tpdm.CertificationLevelDescriptor (CertificationLevelDescriptorId)
;

CREATE INDEX FK_86846f_CertificationLevelDescriptor
ON tpdm.Certification (CertificationLevelDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_CertificationStandardDescriptor FOREIGN KEY (CertificationStandardDescriptorId)
REFERENCES tpdm.CertificationStandardDescriptor (CertificationStandardDescriptorId)
;

CREATE INDEX FK_86846f_CertificationStandardDescriptor
ON tpdm.Certification (CertificationStandardDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_DegreeDescriptor FOREIGN KEY (MinimumDegreeDescriptorId)
REFERENCES tpdm.DegreeDescriptor (DegreeDescriptorId)
;

CREATE INDEX FK_86846f_DegreeDescriptor
ON tpdm.Certification (MinimumDegreeDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_86846f_EducationOrganization
ON tpdm.Certification (EducationOrganizationId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_EducatorRoleDescriptor FOREIGN KEY (EducatorRoleDescriptorId)
REFERENCES tpdm.EducatorRoleDescriptor (EducatorRoleDescriptorId)
;

CREATE INDEX FK_86846f_EducatorRoleDescriptor
ON tpdm.Certification (EducatorRoleDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_InstructionalSettingDescriptor FOREIGN KEY (InstructionalSettingDescriptorId)
REFERENCES tpdm.InstructionalSettingDescriptor (InstructionalSettingDescriptorId)
;

CREATE INDEX FK_86846f_InstructionalSettingDescriptor
ON tpdm.Certification (InstructionalSettingDescriptorId ASC);

ALTER TABLE tpdm.Certification ADD CONSTRAINT FK_86846f_PopulationServedDescriptor FOREIGN KEY (PopulationServedDescriptorId)
REFERENCES edfi.PopulationServedDescriptor (PopulationServedDescriptorId)
;

CREATE INDEX FK_86846f_PopulationServedDescriptor
ON tpdm.Certification (PopulationServedDescriptorId ASC);

ALTER TABLE tpdm.CertificationCertificationExam ADD CONSTRAINT FK_947c8f_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_947c8f_Certification
ON tpdm.CertificationCertificationExam (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CertificationCertificationExam ADD CONSTRAINT FK_947c8f_CertificationExam FOREIGN KEY (CertificationExamIdentifier, CertificationExamNamespace)
REFERENCES tpdm.CertificationExam (CertificationExamIdentifier, Namespace)
;

CREATE INDEX FK_947c8f_CertificationExam
ON tpdm.CertificationCertificationExam (CertificationExamIdentifier ASC, CertificationExamNamespace ASC);

ALTER TABLE tpdm.CertificationExam ADD CONSTRAINT FK_cb139c_CertificationExamTypeDescriptor FOREIGN KEY (CertificationExamTypeDescriptorId)
REFERENCES tpdm.CertificationExamTypeDescriptor (CertificationExamTypeDescriptorId)
;

CREATE INDEX FK_cb139c_CertificationExamTypeDescriptor
ON tpdm.CertificationExam (CertificationExamTypeDescriptorId ASC);

ALTER TABLE tpdm.CertificationExam ADD CONSTRAINT FK_cb139c_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_cb139c_EducationOrganization
ON tpdm.CertificationExam (EducationOrganizationId ASC);

ALTER TABLE tpdm.CertificationExamResult ADD CONSTRAINT FK_aed83e_CertificationExam FOREIGN KEY (CertificationExamIdentifier, Namespace)
REFERENCES tpdm.CertificationExam (CertificationExamIdentifier, Namespace)
;

CREATE INDEX FK_aed83e_CertificationExam
ON tpdm.CertificationExamResult (CertificationExamIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CertificationExamResult ADD CONSTRAINT FK_aed83e_CertificationExamStatusDescriptor FOREIGN KEY (CertificationExamStatusDescriptorId)
REFERENCES tpdm.CertificationExamStatusDescriptor (CertificationExamStatusDescriptorId)
;

CREATE INDEX FK_aed83e_CertificationExamStatusDescriptor
ON tpdm.CertificationExamResult (CertificationExamStatusDescriptorId ASC);

ALTER TABLE tpdm.CertificationExamResult ADD CONSTRAINT FK_aed83e_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_aed83e_Person
ON tpdm.CertificationExamResult (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.CertificationExamStatusDescriptor ADD CONSTRAINT FK_ffe8b6_Descriptor FOREIGN KEY (CertificationExamStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationExamTypeDescriptor ADD CONSTRAINT FK_9ccf0f_Descriptor FOREIGN KEY (CertificationExamTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationFieldDescriptor ADD CONSTRAINT FK_bc9385_Descriptor FOREIGN KEY (CertificationFieldDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationGradeLevel ADD CONSTRAINT FK_809d74_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_809d74_Certification
ON tpdm.CertificationGradeLevel (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CertificationGradeLevel ADD CONSTRAINT FK_809d74_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_809d74_GradeLevelDescriptor
ON tpdm.CertificationGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.CertificationLevelDescriptor ADD CONSTRAINT FK_6bfe73_Descriptor FOREIGN KEY (CertificationLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationRoute ADD CONSTRAINT FK_62187e_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
ON DELETE CASCADE
;

CREATE INDEX FK_62187e_Certification
ON tpdm.CertificationRoute (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CertificationRoute ADD CONSTRAINT FK_62187e_CertificationRouteDescriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES tpdm.CertificationRouteDescriptor (CertificationRouteDescriptorId)
;

CREATE INDEX FK_62187e_CertificationRouteDescriptor
ON tpdm.CertificationRoute (CertificationRouteDescriptorId ASC);

ALTER TABLE tpdm.CertificationRouteDescriptor ADD CONSTRAINT FK_40b601_Descriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CertificationStandardDescriptor ADD CONSTRAINT FK_e0bae9_Descriptor FOREIGN KEY (CertificationStandardDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CompleterAsStaffAssociation ADD CONSTRAINT FK_447e8f_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_447e8f_Staff
ON tpdm.CompleterAsStaffAssociation (StaffUSI ASC);

ALTER TABLE tpdm.CompleterAsStaffAssociation ADD CONSTRAINT FK_447e8f_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_447e8f_TeacherCandidate
ON tpdm.CompleterAsStaffAssociation (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.CoteachingStyleObservedDescriptor ADD CONSTRAINT FK_932c9a_Descriptor FOREIGN KEY (CoteachingStyleObservedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CredentialEvent ADD CONSTRAINT FK_3d6d96_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
;

CREATE INDEX FK_3d6d96_Credential
ON tpdm.CredentialEvent (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.CredentialEvent ADD CONSTRAINT FK_3d6d96_CredentialEventTypeDescriptor FOREIGN KEY (CredentialEventTypeDescriptorId)
REFERENCES tpdm.CredentialEventTypeDescriptor (CredentialEventTypeDescriptorId)
;

CREATE INDEX FK_3d6d96_CredentialEventTypeDescriptor
ON tpdm.CredentialEvent (CredentialEventTypeDescriptorId ASC);

ALTER TABLE tpdm.CredentialEventTypeDescriptor ADD CONSTRAINT FK_c57419_Descriptor FOREIGN KEY (CredentialEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
;

CREATE INDEX FK_6fae52_Certification
ON tpdm.CredentialExtension (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_CertificationRouteDescriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES tpdm.CertificationRouteDescriptor (CertificationRouteDescriptorId)
;

CREATE INDEX FK_6fae52_CertificationRouteDescriptor
ON tpdm.CredentialExtension (CertificationRouteDescriptorId ASC);

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_CredentialStatusDescriptor FOREIGN KEY (CredentialStatusDescriptorId)
REFERENCES tpdm.CredentialStatusDescriptor (CredentialStatusDescriptorId)
;

CREATE INDEX FK_6fae52_CredentialStatusDescriptor
ON tpdm.CredentialExtension (CredentialStatusDescriptorId ASC);

ALTER TABLE tpdm.CredentialExtension ADD CONSTRAINT FK_6fae52_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_6fae52_Person
ON tpdm.CredentialExtension (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.CredentialStatusDescriptor ADD CONSTRAINT FK_91080a_Descriptor FOREIGN KEY (CredentialStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.CredentialStudentAcademicRecord ADD CONSTRAINT FK_73e151_Credential FOREIGN KEY (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
REFERENCES edfi.Credential (CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_73e151_Credential
ON tpdm.CredentialStudentAcademicRecord (CredentialIdentifier ASC, StateOfIssueStateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.CredentialStudentAcademicRecord ADD CONSTRAINT FK_73e151_StudentAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
REFERENCES edfi.StudentAcademicRecord (EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId)
;

CREATE INDEX FK_73e151_StudentAcademicRecord
ON tpdm.CredentialStudentAcademicRecord (EducationOrganizationId ASC, SchoolYear ASC, StudentUSI ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.DegreeDescriptor ADD CONSTRAINT FK_0700f5_Descriptor FOREIGN KEY (DegreeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EducatorRoleDescriptor ADD CONSTRAINT FK_bc8b94_Descriptor FOREIGN KEY (EducatorRoleDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EmploymentEvent ADD CONSTRAINT FK_786774_EmploymentEventTypeDescriptor FOREIGN KEY (EmploymentEventTypeDescriptorId)
REFERENCES tpdm.EmploymentEventTypeDescriptor (EmploymentEventTypeDescriptorId)
;

CREATE INDEX FK_786774_EmploymentEventTypeDescriptor
ON tpdm.EmploymentEvent (EmploymentEventTypeDescriptorId ASC);

ALTER TABLE tpdm.EmploymentEvent ADD CONSTRAINT FK_786774_InternalExternalHireDescriptor FOREIGN KEY (InternalExternalHireDescriptorId)
REFERENCES tpdm.InternalExternalHireDescriptor (InternalExternalHireDescriptorId)
;

CREATE INDEX FK_786774_InternalExternalHireDescriptor
ON tpdm.EmploymentEvent (InternalExternalHireDescriptorId ASC);

ALTER TABLE tpdm.EmploymentEvent ADD CONSTRAINT FK_786774_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
;

CREATE INDEX FK_786774_OpenStaffPosition
ON tpdm.EmploymentEvent (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE tpdm.EmploymentEventTypeDescriptor ADD CONSTRAINT FK_aa55e0_Descriptor FOREIGN KEY (EmploymentEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EmploymentSeparationEvent ADD CONSTRAINT FK_f51cef_EmploymentSeparationReasonDescriptor FOREIGN KEY (EmploymentSeparationReasonDescriptorId)
REFERENCES tpdm.EmploymentSeparationReasonDescriptor (EmploymentSeparationReasonDescriptorId)
;

CREATE INDEX FK_f51cef_EmploymentSeparationReasonDescriptor
ON tpdm.EmploymentSeparationEvent (EmploymentSeparationReasonDescriptorId ASC);

ALTER TABLE tpdm.EmploymentSeparationEvent ADD CONSTRAINT FK_f51cef_EmploymentSeparationTypeDescriptor FOREIGN KEY (EmploymentSeparationTypeDescriptorId)
REFERENCES tpdm.EmploymentSeparationTypeDescriptor (EmploymentSeparationTypeDescriptorId)
;

CREATE INDEX FK_f51cef_EmploymentSeparationTypeDescriptor
ON tpdm.EmploymentSeparationEvent (EmploymentSeparationTypeDescriptorId ASC);

ALTER TABLE tpdm.EmploymentSeparationEvent ADD CONSTRAINT FK_f51cef_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
;

CREATE INDEX FK_f51cef_OpenStaffPosition
ON tpdm.EmploymentSeparationEvent (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE tpdm.EmploymentSeparationReasonDescriptor ADD CONSTRAINT FK_6ff06d_Descriptor FOREIGN KEY (EmploymentSeparationReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EmploymentSeparationTypeDescriptor ADD CONSTRAINT FK_7e945f_Descriptor FOREIGN KEY (EmploymentSeparationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EnglishLanguageExamDescriptor ADD CONSTRAINT FK_76d6e8_Descriptor FOREIGN KEY (EnglishLanguageExamDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.Evaluation ADD CONSTRAINT FK_163e44_EvaluationTypeDescriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES tpdm.EvaluationTypeDescriptor (EvaluationTypeDescriptorId)
;

CREATE INDEX FK_163e44_EvaluationTypeDescriptor
ON tpdm.Evaluation (EvaluationTypeDescriptorId ASC);

ALTER TABLE tpdm.Evaluation ADD CONSTRAINT FK_163e44_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_163e44_PerformanceEvaluation
ON tpdm.Evaluation (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElement ADD CONSTRAINT FK_e53186_EvaluationObjective FOREIGN KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationObjective (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_e53186_EvaluationObjective
ON tpdm.EvaluationElement (EducationOrganizationId ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElement ADD CONSTRAINT FK_e53186_EvaluationTypeDescriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES tpdm.EvaluationTypeDescriptor (EvaluationTypeDescriptorId)
;

CREATE INDEX FK_e53186_EvaluationTypeDescriptor
ON tpdm.EvaluationElement (EvaluationTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRating ADD CONSTRAINT FK_4479ea_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_4479ea_EvaluationElement
ON tpdm.EvaluationElementRating (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRating ADD CONSTRAINT FK_4479ea_EvaluationElementRatingLevelDescriptor FOREIGN KEY (EvaluationElementRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationElementRatingLevelDescriptor (EvaluationElementRatingLevelDescriptorId)
;

CREATE INDEX FK_4479ea_EvaluationElementRatingLevelDescriptor
ON tpdm.EvaluationElementRating (EvaluationElementRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRating ADD CONSTRAINT FK_4479ea_EvaluationObjectiveRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationObjectiveRating (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_4479ea_EvaluationObjectiveRating
ON tpdm.EvaluationElementRating (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRatingLevel ADD CONSTRAINT FK_afbeb2_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_afbeb2_EvaluationElement
ON tpdm.EvaluationElementRatingLevel (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRatingLevel ADD CONSTRAINT FK_afbeb2_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_afbeb2_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationElementRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRatingLevelDescriptor ADD CONSTRAINT FK_86df6c_Descriptor FOREIGN KEY (EvaluationElementRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationElementRatingResult ADD CONSTRAINT FK_c5877a_EvaluationElementRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationElementRating (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_c5877a_EvaluationElementRating
ON tpdm.EvaluationElementRatingResult (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationElementRatingResult ADD CONSTRAINT FK_c5877a_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_c5877a_ResultDatatypeTypeDescriptor
ON tpdm.EvaluationElementRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjective ADD CONSTRAINT FK_d4565d_Evaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.Evaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_d4565d_Evaluation
ON tpdm.EvaluationObjective (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjective ADD CONSTRAINT FK_d4565d_EvaluationTypeDescriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES tpdm.EvaluationTypeDescriptor (EvaluationTypeDescriptorId)
;

CREATE INDEX FK_d4565d_EvaluationTypeDescriptor
ON tpdm.EvaluationObjective (EvaluationTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRating ADD CONSTRAINT FK_7ae19d_EvaluationObjective FOREIGN KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationObjective (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_7ae19d_EvaluationObjective
ON tpdm.EvaluationObjectiveRating (EducationOrganizationId ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRating ADD CONSTRAINT FK_7ae19d_EvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRating (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_7ae19d_EvaluationRating
ON tpdm.EvaluationObjectiveRating (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRating ADD CONSTRAINT FK_7ae19d_ObjectiveRatingLevelDescriptor FOREIGN KEY (ObjectiveRatingLevelDescriptorId)
REFERENCES tpdm.ObjectiveRatingLevelDescriptor (ObjectiveRatingLevelDescriptorId)
;

CREATE INDEX FK_7ae19d_ObjectiveRatingLevelDescriptor
ON tpdm.EvaluationObjectiveRating (ObjectiveRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingLevel ADD CONSTRAINT FK_1d984c_EvaluationObjective FOREIGN KEY (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationObjective (EducationOrganizationId, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_1d984c_EvaluationObjective
ON tpdm.EvaluationObjectiveRatingLevel (EducationOrganizationId ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingLevel ADD CONSTRAINT FK_1d984c_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_1d984c_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationObjectiveRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingResult ADD CONSTRAINT FK_beeccb_EvaluationObjectiveRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationObjectiveRating (EducationOrganizationId, EvaluationDate, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_beeccb_EvaluationObjectiveRating
ON tpdm.EvaluationObjectiveRatingResult (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationObjectiveRatingResult ADD CONSTRAINT FK_beeccb_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_beeccb_ResultDatatypeTypeDescriptor
ON tpdm.EvaluationObjectiveRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationPeriodDescriptor ADD CONSTRAINT FK_83ff2a_Descriptor FOREIGN KEY (EvaluationPeriodDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_Evaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.Evaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_bfaa20_Evaluation
ON tpdm.EvaluationRating (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_bfaa20_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationRating (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_PerformanceEvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRating (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_bfaa20_PerformanceEvaluationRating
ON tpdm.EvaluationRating (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRating ADD CONSTRAINT FK_bfaa20_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_bfaa20_Section
ON tpdm.EvaluationRating (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE tpdm.EvaluationRatingLevel ADD CONSTRAINT FK_7052f8_Evaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.Evaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_7052f8_Evaluation
ON tpdm.EvaluationRatingLevel (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingLevel ADD CONSTRAINT FK_7052f8_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_7052f8_EvaluationRatingLevelDescriptor
ON tpdm.EvaluationRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingLevelDescriptor ADD CONSTRAINT FK_5fb2ad_Descriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationRatingResult ADD CONSTRAINT FK_268283_EvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRating (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_268283_EvaluationRating
ON tpdm.EvaluationRatingResult (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingResult ADD CONSTRAINT FK_268283_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_268283_ResultDatatypeTypeDescriptor
ON tpdm.EvaluationRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingReviewer ADD CONSTRAINT FK_2d29eb_EvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRating (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_2d29eb_EvaluationRating
ON tpdm.EvaluationRatingReviewer (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingReviewer ADD CONSTRAINT FK_2d29eb_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_2d29eb_Person
ON tpdm.EvaluationRatingReviewer (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.EvaluationRatingReviewerReceivedTraining ADD CONSTRAINT FK_608112_EvaluationRatingReviewer FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationRatingReviewer (EducationOrganizationId, EvaluationDate, EvaluationPeriodDescriptorId, EvaluationTitle, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.EvaluationTypeDescriptor ADD CONSTRAINT FK_67cd19_Descriptor FOREIGN KEY (EvaluationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FederalLocaleCodeDescriptor ADD CONSTRAINT FK_cec0ca_Descriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FieldworkExperience ADD CONSTRAINT FK_fd30bb_FieldworkTypeDescriptor FOREIGN KEY (FieldworkTypeDescriptorId)
REFERENCES tpdm.FieldworkTypeDescriptor (FieldworkTypeDescriptorId)
;

CREATE INDEX FK_fd30bb_FieldworkTypeDescriptor
ON tpdm.FieldworkExperience (FieldworkTypeDescriptorId ASC);

ALTER TABLE tpdm.FieldworkExperience ADD CONSTRAINT FK_fd30bb_ProgramGatewayDescriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES tpdm.ProgramGatewayDescriptor (ProgramGatewayDescriptorId)
;

CREATE INDEX FK_fd30bb_ProgramGatewayDescriptor
ON tpdm.FieldworkExperience (ProgramGatewayDescriptorId ASC);

ALTER TABLE tpdm.FieldworkExperience ADD CONSTRAINT FK_fd30bb_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_fd30bb_Student
ON tpdm.FieldworkExperience (StudentUSI ASC);

ALTER TABLE tpdm.FieldworkExperienceCoteaching ADD CONSTRAINT FK_1a4745_FieldworkExperience FOREIGN KEY (BeginDate, FieldworkIdentifier, StudentUSI)
REFERENCES tpdm.FieldworkExperience (BeginDate, FieldworkIdentifier, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FieldworkExperienceSchool ADD CONSTRAINT FK_5dbddd_FieldworkExperience FOREIGN KEY (BeginDate, FieldworkIdentifier, StudentUSI)
REFERENCES tpdm.FieldworkExperience (BeginDate, FieldworkIdentifier, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_5dbddd_FieldworkExperience
ON tpdm.FieldworkExperienceSchool (BeginDate ASC, FieldworkIdentifier ASC, StudentUSI ASC);

ALTER TABLE tpdm.FieldworkExperienceSchool ADD CONSTRAINT FK_5dbddd_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_5dbddd_School
ON tpdm.FieldworkExperienceSchool (SchoolId ASC);

ALTER TABLE tpdm.FieldworkExperienceSectionAssociation ADD CONSTRAINT FK_b2abcd_FieldworkExperience FOREIGN KEY (BeginDate, FieldworkIdentifier, StudentUSI)
REFERENCES tpdm.FieldworkExperience (BeginDate, FieldworkIdentifier, StudentUSI)
;

CREATE INDEX FK_b2abcd_FieldworkExperience
ON tpdm.FieldworkExperienceSectionAssociation (BeginDate ASC, FieldworkIdentifier ASC, StudentUSI ASC);

ALTER TABLE tpdm.FieldworkExperienceSectionAssociation ADD CONSTRAINT FK_b2abcd_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_b2abcd_Section
ON tpdm.FieldworkExperienceSectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE tpdm.FieldworkTypeDescriptor ADD CONSTRAINT FK_a16a29_Descriptor FOREIGN KEY (FieldworkTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.FundingSourceDescriptor ADD CONSTRAINT FK_3ecd1a_Descriptor FOREIGN KEY (FundingSourceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.GenderDescriptor ADD CONSTRAINT FK_554e4f_Descriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.Goal ADD CONSTRAINT FK_cdbf69_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_cdbf69_EvaluationElement
ON tpdm.Goal (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.Goal ADD CONSTRAINT FK_cdbf69_GoalTypeDescriptor FOREIGN KEY (GoalTypeDescriptorId)
REFERENCES tpdm.GoalTypeDescriptor (GoalTypeDescriptorId)
;

CREATE INDEX FK_cdbf69_GoalTypeDescriptor
ON tpdm.Goal (GoalTypeDescriptorId ASC);

ALTER TABLE tpdm.Goal ADD CONSTRAINT FK_cdbf69_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_cdbf69_Person
ON tpdm.Goal (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.GoalTypeDescriptor ADD CONSTRAINT FK_403c02_Descriptor FOREIGN KEY (GoalTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.GraduationPlanRequiredCertification ADD CONSTRAINT FK_bd70a1_Certification FOREIGN KEY (CertificationIdentifier, Namespace)
REFERENCES tpdm.Certification (CertificationIdentifier, Namespace)
;

CREATE INDEX FK_bd70a1_Certification
ON tpdm.GraduationPlanRequiredCertification (CertificationIdentifier ASC, Namespace ASC);

ALTER TABLE tpdm.GraduationPlanRequiredCertification ADD CONSTRAINT FK_bd70a1_CertificationRouteDescriptor FOREIGN KEY (CertificationRouteDescriptorId)
REFERENCES tpdm.CertificationRouteDescriptor (CertificationRouteDescriptorId)
;

CREATE INDEX FK_bd70a1_CertificationRouteDescriptor
ON tpdm.GraduationPlanRequiredCertification (CertificationRouteDescriptorId ASC);

ALTER TABLE tpdm.GraduationPlanRequiredCertification ADD CONSTRAINT FK_bd70a1_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
ON DELETE CASCADE
;

CREATE INDEX FK_bd70a1_GraduationPlan
ON tpdm.GraduationPlanRequiredCertification (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE tpdm.HireStatusDescriptor ADD CONSTRAINT FK_f84919_Descriptor FOREIGN KEY (HireStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.HiringSourceDescriptor ADD CONSTRAINT FK_7d10e3_Descriptor FOREIGN KEY (HiringSourceDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.InstructionalSettingDescriptor ADD CONSTRAINT FK_d9876b_Descriptor FOREIGN KEY (InstructionalSettingDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.InternalExternalHireDescriptor ADD CONSTRAINT FK_8ae758_Descriptor FOREIGN KEY (InternalExternalHireDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.LevelOfDegreeAwardedDescriptor ADD CONSTRAINT FK_bb5168_Descriptor FOREIGN KEY (LevelOfDegreeAwardedDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.LocalEducationAgencyExtension ADD CONSTRAINT FK_bf6aa4_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_bf6aa4_FederalLocaleCodeDescriptor
ON tpdm.LocalEducationAgencyExtension (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.LocalEducationAgencyExtension ADD CONSTRAINT FK_bf6aa4_LocalEducationAgency FOREIGN KEY (LocalEducationAgencyId)
REFERENCES edfi.LocalEducationAgency (LocalEducationAgencyId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ObjectiveRatingLevelDescriptor ADD CONSTRAINT FK_d49b1f_Descriptor FOREIGN KEY (ObjectiveRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.OpenStaffPositionEvent ADD CONSTRAINT FK_e809b0_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
;

CREATE INDEX FK_e809b0_OpenStaffPosition
ON tpdm.OpenStaffPositionEvent (EducationOrganizationId ASC, RequisitionNumber ASC);

ALTER TABLE tpdm.OpenStaffPositionEvent ADD CONSTRAINT FK_e809b0_OpenStaffPositionEventStatusDescriptor FOREIGN KEY (OpenStaffPositionEventStatusDescriptorId)
REFERENCES tpdm.OpenStaffPositionEventStatusDescriptor (OpenStaffPositionEventStatusDescriptorId)
;

CREATE INDEX FK_e809b0_OpenStaffPositionEventStatusDescriptor
ON tpdm.OpenStaffPositionEvent (OpenStaffPositionEventStatusDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionEvent ADD CONSTRAINT FK_e809b0_OpenStaffPositionEventTypeDescriptor FOREIGN KEY (OpenStaffPositionEventTypeDescriptorId)
REFERENCES tpdm.OpenStaffPositionEventTypeDescriptor (OpenStaffPositionEventTypeDescriptorId)
;

CREATE INDEX FK_e809b0_OpenStaffPositionEventTypeDescriptor
ON tpdm.OpenStaffPositionEvent (OpenStaffPositionEventTypeDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionEventStatusDescriptor ADD CONSTRAINT FK_1910c5_Descriptor FOREIGN KEY (OpenStaffPositionEventStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.OpenStaffPositionEventTypeDescriptor ADD CONSTRAINT FK_f48cc2_Descriptor FOREIGN KEY (OpenStaffPositionEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_FundingSourceDescriptor FOREIGN KEY (FundingSourceDescriptorId)
REFERENCES tpdm.FundingSourceDescriptor (FundingSourceDescriptorId)
;

CREATE INDEX FK_892567_FundingSourceDescriptor
ON tpdm.OpenStaffPositionExtension (FundingSourceDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_OpenStaffPosition FOREIGN KEY (EducationOrganizationId, RequisitionNumber)
REFERENCES edfi.OpenStaffPosition (EducationOrganizationId, RequisitionNumber)
ON DELETE CASCADE
;

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_OpenStaffPositionReasonDescriptor FOREIGN KEY (OpenStaffPositionReasonDescriptorId)
REFERENCES tpdm.OpenStaffPositionReasonDescriptor (OpenStaffPositionReasonDescriptorId)
;

CREATE INDEX FK_892567_OpenStaffPositionReasonDescriptor
ON tpdm.OpenStaffPositionExtension (OpenStaffPositionReasonDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_892567_SchoolYearType
ON tpdm.OpenStaffPositionExtension (SchoolYear ASC);

ALTER TABLE tpdm.OpenStaffPositionExtension ADD CONSTRAINT FK_892567_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_892567_TermDescriptor
ON tpdm.OpenStaffPositionExtension (TermDescriptorId ASC);

ALTER TABLE tpdm.OpenStaffPositionReasonDescriptor ADD CONSTRAINT FK_80ebb8_Descriptor FOREIGN KEY (OpenStaffPositionReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_15d685_AcademicSubjectDescriptor
ON tpdm.PerformanceEvaluation (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_15d685_EducationOrganization
ON tpdm.PerformanceEvaluation (EducationOrganizationId ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_EvaluationPeriodDescriptor FOREIGN KEY (EvaluationPeriodDescriptorId)
REFERENCES tpdm.EvaluationPeriodDescriptor (EvaluationPeriodDescriptorId)
;

CREATE INDEX FK_15d685_EvaluationPeriodDescriptor
ON tpdm.PerformanceEvaluation (EvaluationPeriodDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_PerformanceEvaluationTypeDescriptor FOREIGN KEY (PerformanceEvaluationTypeDescriptorId)
REFERENCES tpdm.PerformanceEvaluationTypeDescriptor (PerformanceEvaluationTypeDescriptorId)
;

CREATE INDEX FK_15d685_PerformanceEvaluationTypeDescriptor
ON tpdm.PerformanceEvaluation (PerformanceEvaluationTypeDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_15d685_SchoolYearType
ON tpdm.PerformanceEvaluation (SchoolYear ASC);

ALTER TABLE tpdm.PerformanceEvaluation ADD CONSTRAINT FK_15d685_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_15d685_TermDescriptor
ON tpdm.PerformanceEvaluation (TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationGradeLevel ADD CONSTRAINT FK_5b9d31_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_5b9d31_GradeLevelDescriptor
ON tpdm.PerformanceEvaluationGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationGradeLevel ADD CONSTRAINT FK_5b9d31_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_5b9d31_PerformanceEvaluation
ON tpdm.PerformanceEvaluationGradeLevel (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationProgramGateway ADD CONSTRAINT FK_611be2_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_611be2_PerformanceEvaluation
ON tpdm.PerformanceEvaluationProgramGateway (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationProgramGateway ADD CONSTRAINT FK_611be2_ProgramGatewayDescriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES tpdm.ProgramGatewayDescriptor (ProgramGatewayDescriptorId)
;

CREATE INDEX FK_611be2_ProgramGatewayDescriptor
ON tpdm.PerformanceEvaluationProgramGateway (ProgramGatewayDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRating ADD CONSTRAINT FK_759abe_CoteachingStyleObservedDescriptor FOREIGN KEY (CoteachingStyleObservedDescriptorId)
REFERENCES tpdm.CoteachingStyleObservedDescriptor (CoteachingStyleObservedDescriptorId)
;

CREATE INDEX FK_759abe_CoteachingStyleObservedDescriptor
ON tpdm.PerformanceEvaluationRating (CoteachingStyleObservedDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRating ADD CONSTRAINT FK_759abe_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_759abe_PerformanceEvaluation
ON tpdm.PerformanceEvaluationRating (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRating ADD CONSTRAINT FK_759abe_PerformanceEvaluationRatingLevelDescriptor FOREIGN KEY (PerformanceEvaluationRatingLevelDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRatingLevelDescriptor (PerformanceEvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_759abe_PerformanceEvaluationRatingLevelDescriptor
ON tpdm.PerformanceEvaluationRating (PerformanceEvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRating ADD CONSTRAINT FK_759abe_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_759abe_Person
ON tpdm.PerformanceEvaluationRating (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingLevel ADD CONSTRAINT FK_90ed3d_EvaluationRatingLevelDescriptor FOREIGN KEY (EvaluationRatingLevelDescriptorId)
REFERENCES tpdm.EvaluationRatingLevelDescriptor (EvaluationRatingLevelDescriptorId)
;

CREATE INDEX FK_90ed3d_EvaluationRatingLevelDescriptor
ON tpdm.PerformanceEvaluationRatingLevel (EvaluationRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingLevel ADD CONSTRAINT FK_90ed3d_PerformanceEvaluation FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluation (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_90ed3d_PerformanceEvaluation
ON tpdm.PerformanceEvaluationRatingLevel (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingLevelDescriptor ADD CONSTRAINT FK_ed7e01_Descriptor FOREIGN KEY (PerformanceEvaluationRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluationRatingResult ADD CONSTRAINT FK_863fa4_PerformanceEvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRating (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_863fa4_PerformanceEvaluationRating
ON tpdm.PerformanceEvaluationRatingResult (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingResult ADD CONSTRAINT FK_863fa4_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_863fa4_ResultDatatypeTypeDescriptor
ON tpdm.PerformanceEvaluationRatingResult (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewer ADD CONSTRAINT FK_477526_PerformanceEvaluationRating FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRating (EducationOrganizationId, EvaluationPeriodDescriptorId, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_477526_PerformanceEvaluationRating
ON tpdm.PerformanceEvaluationRatingReviewer (EducationOrganizationId ASC, EvaluationPeriodDescriptorId ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewer ADD CONSTRAINT FK_477526_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_477526_Person
ON tpdm.PerformanceEvaluationRatingReviewer (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.PerformanceEvaluationRatingReviewerReceivedTraining ADD CONSTRAINT FK_6e6517_PerformanceEvaluationRatingReviewer FOREIGN KEY (EducationOrganizationId, EvaluationPeriodDescriptorId, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.PerformanceEvaluationRatingReviewer (EducationOrganizationId, EvaluationPeriodDescriptorId, FirstName, LastSurname, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PerformanceEvaluationTypeDescriptor ADD CONSTRAINT FK_2ba831_Descriptor FOREIGN KEY (PerformanceEvaluationTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PostSecondaryInstitutionExtension ADD CONSTRAINT FK_bd2efc_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_bd2efc_FederalLocaleCodeDescriptor
ON tpdm.PostSecondaryInstitutionExtension (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.PostSecondaryInstitutionExtension ADD CONSTRAINT FK_bd2efc_PostSecondaryInstitution FOREIGN KEY (PostSecondaryInstitutionId)
REFERENCES edfi.PostSecondaryInstitution (PostSecondaryInstitutionId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.PreviousCareerDescriptor ADD CONSTRAINT FK_29798f_Descriptor FOREIGN KEY (PreviousCareerDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ProfessionalDevelopmentEvent ADD CONSTRAINT FK_8c4ca1_ProfessionalDevelopmentOfferedByDescriptor FOREIGN KEY (ProfessionalDevelopmentOfferedByDescriptorId)
REFERENCES tpdm.ProfessionalDevelopmentOfferedByDescriptor (ProfessionalDevelopmentOfferedByDescriptorId)
;

CREATE INDEX FK_8c4ca1_ProfessionalDevelopmentOfferedByDescriptor
ON tpdm.ProfessionalDevelopmentEvent (ProfessionalDevelopmentOfferedByDescriptorId ASC);

ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ADD CONSTRAINT FK_22e412_AttendanceEventCategoryDescriptor FOREIGN KEY (AttendanceEventCategoryDescriptorId)
REFERENCES edfi.AttendanceEventCategoryDescriptor (AttendanceEventCategoryDescriptorId)
;

CREATE INDEX FK_22e412_AttendanceEventCategoryDescriptor
ON tpdm.ProfessionalDevelopmentEventAttendance (AttendanceEventCategoryDescriptorId ASC);

ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ADD CONSTRAINT FK_22e412_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_22e412_Person
ON tpdm.ProfessionalDevelopmentEventAttendance (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.ProfessionalDevelopmentEventAttendance ADD CONSTRAINT FK_22e412_ProfessionalDevelopmentEvent FOREIGN KEY (Namespace, ProfessionalDevelopmentTitle)
REFERENCES tpdm.ProfessionalDevelopmentEvent (Namespace, ProfessionalDevelopmentTitle)
;

CREATE INDEX FK_22e412_ProfessionalDevelopmentEvent
ON tpdm.ProfessionalDevelopmentEventAttendance (Namespace ASC, ProfessionalDevelopmentTitle ASC);

ALTER TABLE tpdm.ProfessionalDevelopmentOfferedByDescriptor ADD CONSTRAINT FK_b58d9b_Descriptor FOREIGN KEY (ProfessionalDevelopmentOfferedByDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ProgramGatewayDescriptor ADD CONSTRAINT FK_d0ca9b_Descriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.Prospect ADD CONSTRAINT FK_f84f61_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_f84f61_EducationOrganization
ON tpdm.Prospect (EducationOrganizationId ASC);

ALTER TABLE tpdm.Prospect ADD CONSTRAINT FK_f84f61_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_f84f61_GenderDescriptor
ON tpdm.Prospect (GenderDescriptorId ASC);

ALTER TABLE tpdm.Prospect ADD CONSTRAINT FK_f84f61_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_f84f61_Person
ON tpdm.Prospect (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.Prospect ADD CONSTRAINT FK_f84f61_ProspectTypeDescriptor FOREIGN KEY (ProspectTypeDescriptorId)
REFERENCES tpdm.ProspectTypeDescriptor (ProspectTypeDescriptorId)
;

CREATE INDEX FK_f84f61_ProspectTypeDescriptor
ON tpdm.Prospect (ProspectTypeDescriptorId ASC);

ALTER TABLE tpdm.Prospect ADD CONSTRAINT FK_f84f61_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_f84f61_SexDescriptor
ON tpdm.Prospect (SexDescriptorId ASC);

ALTER TABLE tpdm.Prospect ADD CONSTRAINT FK_f84f61_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_f84f61_TeacherCandidate
ON tpdm.Prospect (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.ProspectAid ADD CONSTRAINT FK_f864a7_AidTypeDescriptor FOREIGN KEY (AidTypeDescriptorId)
REFERENCES tpdm.AidTypeDescriptor (AidTypeDescriptorId)
;

CREATE INDEX FK_f864a7_AidTypeDescriptor
ON tpdm.ProspectAid (AidTypeDescriptorId ASC);

ALTER TABLE tpdm.ProspectAid ADD CONSTRAINT FK_f864a7_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ProspectCurrentPosition ADD CONSTRAINT FK_f29793_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_f29793_AcademicSubjectDescriptor
ON tpdm.ProspectCurrentPosition (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.ProspectCurrentPosition ADD CONSTRAINT FK_f29793_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ProspectCurrentPositionGradeLevel ADD CONSTRAINT FK_918bf6_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_918bf6_GradeLevelDescriptor
ON tpdm.ProspectCurrentPositionGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.ProspectCurrentPositionGradeLevel ADD CONSTRAINT FK_918bf6_ProspectCurrentPosition FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.ProspectCurrentPosition (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_918bf6_ProspectCurrentPosition
ON tpdm.ProspectCurrentPositionGradeLevel (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ProspectDisability ADD CONSTRAINT FK_4804fb_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_4804fb_DisabilityDescriptor
ON tpdm.ProspectDisability (DisabilityDescriptorId ASC);

ALTER TABLE tpdm.ProspectDisability ADD CONSTRAINT FK_4804fb_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_4804fb_DisabilityDeterminationSourceTypeDescriptor
ON tpdm.ProspectDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE tpdm.ProspectDisability ADD CONSTRAINT FK_4804fb_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_4804fb_Prospect
ON tpdm.ProspectDisability (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ProspectDisabilityDesignation ADD CONSTRAINT FK_5c4c1c_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_5c4c1c_DisabilityDesignationDescriptor
ON tpdm.ProspectDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE tpdm.ProspectDisabilityDesignation ADD CONSTRAINT FK_5c4c1c_ProspectDisability FOREIGN KEY (DisabilityDescriptorId, EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.ProspectDisability (DisabilityDescriptorId, EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_5c4c1c_ProspectDisability
ON tpdm.ProspectDisabilityDesignation (DisabilityDescriptorId ASC, EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ProspectPersonalIdentificationDocument ADD CONSTRAINT FK_6b942a_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_6b942a_CountryDescriptor
ON tpdm.ProspectPersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.ProspectPersonalIdentificationDocument ADD CONSTRAINT FK_6b942a_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_6b942a_IdentificationDocumentUseDescriptor
ON tpdm.ProspectPersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.ProspectPersonalIdentificationDocument ADD CONSTRAINT FK_6b942a_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_6b942a_PersonalInformationVerificationDescriptor
ON tpdm.ProspectPersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.ProspectPersonalIdentificationDocument ADD CONSTRAINT FK_6b942a_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_6b942a_Prospect
ON tpdm.ProspectPersonalIdentificationDocument (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ProspectQualifications ADD CONSTRAINT FK_c954a4_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.ProspectRace ADD CONSTRAINT FK_f29b59_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_f29b59_Prospect
ON tpdm.ProspectRace (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ProspectRace ADD CONSTRAINT FK_f29b59_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_f29b59_RaceDescriptor
ON tpdm.ProspectRace (RaceDescriptorId ASC);

ALTER TABLE tpdm.ProspectRecruitmentEvent ADD CONSTRAINT FK_69cd94_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_69cd94_Prospect
ON tpdm.ProspectRecruitmentEvent (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ProspectRecruitmentEvent ADD CONSTRAINT FK_69cd94_RecruitmentEvent FOREIGN KEY (EventDate, EventTitle)
REFERENCES tpdm.RecruitmentEvent (EventDate, EventTitle)
;

CREATE INDEX FK_69cd94_RecruitmentEvent
ON tpdm.ProspectRecruitmentEvent (EventDate ASC, EventTitle ASC);

ALTER TABLE tpdm.ProspectTelephone ADD CONSTRAINT FK_347256_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_347256_Prospect
ON tpdm.ProspectTelephone (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ProspectTelephone ADD CONSTRAINT FK_347256_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_347256_TelephoneNumberTypeDescriptor
ON tpdm.ProspectTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE tpdm.ProspectTouchpoint ADD CONSTRAINT FK_2ecb98_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_2ecb98_Prospect
ON tpdm.ProspectTouchpoint (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.ProspectTypeDescriptor ADD CONSTRAINT FK_22c5bc_Descriptor FOREIGN KEY (ProspectTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.QuantitativeMeasure ADD CONSTRAINT FK_8b89fe_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_8b89fe_EvaluationElement
ON tpdm.QuantitativeMeasure (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasure ADD CONSTRAINT FK_8b89fe_QuantitativeMeasureDatatypeDescriptor FOREIGN KEY (QuantitativeMeasureDatatypeDescriptorId)
REFERENCES tpdm.QuantitativeMeasureDatatypeDescriptor (QuantitativeMeasureDatatypeDescriptorId)
;

CREATE INDEX FK_8b89fe_QuantitativeMeasureDatatypeDescriptor
ON tpdm.QuantitativeMeasure (QuantitativeMeasureDatatypeDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasure ADD CONSTRAINT FK_8b89fe_QuantitativeMeasureTypeDescriptor FOREIGN KEY (QuantitativeMeasureTypeDescriptorId)
REFERENCES tpdm.QuantitativeMeasureTypeDescriptor (QuantitativeMeasureTypeDescriptorId)
;

CREATE INDEX FK_8b89fe_QuantitativeMeasureTypeDescriptor
ON tpdm.QuantitativeMeasure (QuantitativeMeasureTypeDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasureDatatypeDescriptor ADD CONSTRAINT FK_1d0f9c_Descriptor FOREIGN KEY (QuantitativeMeasureDatatypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.QuantitativeMeasureScore ADD CONSTRAINT FK_e61067_EvaluationElementRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationElementRating (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_e61067_EvaluationElementRating
ON tpdm.QuantitativeMeasureScore (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasureScore ADD CONSTRAINT FK_e61067_QuantitativeMeasure FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId)
REFERENCES tpdm.QuantitativeMeasure (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, QuantitativeMeasureIdentifier, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_e61067_QuantitativeMeasure
ON tpdm.QuantitativeMeasureScore (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, QuantitativeMeasureIdentifier ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.QuantitativeMeasureTypeDescriptor ADD CONSTRAINT FK_9f49f2_Descriptor FOREIGN KEY (QuantitativeMeasureTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.RecruitmentEvent ADD CONSTRAINT FK_6232e8_RecruitmentEventTypeDescriptor FOREIGN KEY (RecruitmentEventTypeDescriptorId)
REFERENCES tpdm.RecruitmentEventTypeDescriptor (RecruitmentEventTypeDescriptorId)
;

CREATE INDEX FK_6232e8_RecruitmentEventTypeDescriptor
ON tpdm.RecruitmentEvent (RecruitmentEventTypeDescriptorId ASC);

ALTER TABLE tpdm.RecruitmentEventTypeDescriptor ADD CONSTRAINT FK_4075e3_Descriptor FOREIGN KEY (RecruitmentEventTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.RubricDimension ADD CONSTRAINT FK_643c81_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_643c81_EvaluationElement
ON tpdm.RubricDimension (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.RubricDimension ADD CONSTRAINT FK_643c81_RubricRatingLevelDescriptor FOREIGN KEY (RubricRatingLevelDescriptorId)
REFERENCES tpdm.RubricRatingLevelDescriptor (RubricRatingLevelDescriptorId)
;

CREATE INDEX FK_643c81_RubricRatingLevelDescriptor
ON tpdm.RubricDimension (RubricRatingLevelDescriptorId ASC);

ALTER TABLE tpdm.RubricRatingLevelDescriptor ADD CONSTRAINT FK_f24609_Descriptor FOREIGN KEY (RubricRatingLevelDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SalaryTypeDescriptor ADD CONSTRAINT FK_9bdb03_Descriptor FOREIGN KEY (SalaryTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_2199be_FederalLocaleCodeDescriptor
ON tpdm.SchoolExtension (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SchoolExtension ADD CONSTRAINT FK_2199be_SchoolStatusDescriptor FOREIGN KEY (SchoolStatusDescriptorId)
REFERENCES tpdm.SchoolStatusDescriptor (SchoolStatusDescriptorId)
;

CREATE INDEX FK_2199be_SchoolStatusDescriptor
ON tpdm.SchoolExtension (SchoolStatusDescriptorId ASC);

ALTER TABLE tpdm.SchoolStatusDescriptor ADD CONSTRAINT FK_3bd25e_Descriptor FOREIGN KEY (SchoolStatusDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffApplicantAssociation ADD CONSTRAINT FK_11e466_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
;

CREATE INDEX FK_11e466_Applicant
ON tpdm.StaffApplicantAssociation (ApplicantIdentifier ASC);

ALTER TABLE tpdm.StaffApplicantAssociation ADD CONSTRAINT FK_11e466_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_11e466_Staff
ON tpdm.StaffApplicantAssociation (StaffUSI ASC);

ALTER TABLE tpdm.StaffBackgroundCheck ADD CONSTRAINT FK_69e4a8_BackgroundCheckStatusDescriptor FOREIGN KEY (BackgroundCheckStatusDescriptorId)
REFERENCES tpdm.BackgroundCheckStatusDescriptor (BackgroundCheckStatusDescriptorId)
;

CREATE INDEX FK_69e4a8_BackgroundCheckStatusDescriptor
ON tpdm.StaffBackgroundCheck (BackgroundCheckStatusDescriptorId ASC);

ALTER TABLE tpdm.StaffBackgroundCheck ADD CONSTRAINT FK_69e4a8_BackgroundCheckTypeDescriptor FOREIGN KEY (BackgroundCheckTypeDescriptorId)
REFERENCES tpdm.BackgroundCheckTypeDescriptor (BackgroundCheckTypeDescriptorId)
;

CREATE INDEX FK_69e4a8_BackgroundCheckTypeDescriptor
ON tpdm.StaffBackgroundCheck (BackgroundCheckTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffBackgroundCheck ADD CONSTRAINT FK_69e4a8_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_69e4a8_Staff
ON tpdm.StaffBackgroundCheck (StaffUSI ASC);

ALTER TABLE tpdm.StaffEducationOrganizationAssignmentAssociationExtension ADD CONSTRAINT FK_6ea356_StaffEducationOrganizationAssignmentAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationAssignmentAssociation (BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffExtension ADD CONSTRAINT FK_d7b81a_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_d7b81a_GenderDescriptor
ON tpdm.StaffExtension (GenderDescriptorId ASC);

ALTER TABLE tpdm.StaffExtension ADD CONSTRAINT FK_d7b81a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffHighlyQualifiedAcademicSubject ADD CONSTRAINT FK_37449d_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_37449d_AcademicSubjectDescriptor
ON tpdm.StaffHighlyQualifiedAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.StaffHighlyQualifiedAcademicSubject ADD CONSTRAINT FK_37449d_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_37449d_Staff
ON tpdm.StaffHighlyQualifiedAcademicSubject (StaffUSI ASC);

ALTER TABLE tpdm.StaffProspectAssociation ADD CONSTRAINT FK_990b71_Prospect FOREIGN KEY (EducationOrganizationId, ProspectIdentifier)
REFERENCES tpdm.Prospect (EducationOrganizationId, ProspectIdentifier)
;

CREATE INDEX FK_990b71_Prospect
ON tpdm.StaffProspectAssociation (EducationOrganizationId ASC, ProspectIdentifier ASC);

ALTER TABLE tpdm.StaffProspectAssociation ADD CONSTRAINT FK_990b71_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_990b71_Staff
ON tpdm.StaffProspectAssociation (StaffUSI ASC);

ALTER TABLE tpdm.StaffSalary ADD CONSTRAINT FK_0169b7_SalaryTypeDescriptor FOREIGN KEY (SalaryTypeDescriptorId)
REFERENCES tpdm.SalaryTypeDescriptor (SalaryTypeDescriptorId)
;

CREATE INDEX FK_0169b7_SalaryTypeDescriptor
ON tpdm.StaffSalary (SalaryTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffSalary ADD CONSTRAINT FK_0169b7_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffSeniority ADD CONSTRAINT FK_3cc480_CredentialFieldDescriptor FOREIGN KEY (CredentialFieldDescriptorId)
REFERENCES edfi.CredentialFieldDescriptor (CredentialFieldDescriptorId)
;

CREATE INDEX FK_3cc480_CredentialFieldDescriptor
ON tpdm.StaffSeniority (CredentialFieldDescriptorId ASC);

ALTER TABLE tpdm.StaffSeniority ADD CONSTRAINT FK_3cc480_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_3cc480_Staff
ON tpdm.StaffSeniority (StaffUSI ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasure ADD CONSTRAINT FK_609983_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_609983_ResultDatatypeTypeDescriptor
ON tpdm.StaffStudentGrowthMeasure (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasure ADD CONSTRAINT FK_609983_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_609983_SchoolYearType
ON tpdm.StaffStudentGrowthMeasure (SchoolYear ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasure ADD CONSTRAINT FK_609983_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_609983_Staff
ON tpdm.StaffStudentGrowthMeasure (StaffUSI ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasure ADD CONSTRAINT FK_609983_StudentGrowthTypeDescriptor FOREIGN KEY (StudentGrowthTypeDescriptorId)
REFERENCES tpdm.StudentGrowthTypeDescriptor (StudentGrowthTypeDescriptorId)
;

CREATE INDEX FK_609983_StudentGrowthTypeDescriptor
ON tpdm.StaffStudentGrowthMeasure (StudentGrowthTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureAcademicSubject ADD CONSTRAINT FK_517653_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_517653_AcademicSubjectDescriptor
ON tpdm.StaffStudentGrowthMeasureAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureAcademicSubject ADD CONSTRAINT FK_517653_StaffStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
REFERENCES tpdm.StaffStudentGrowthMeasure (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_517653_StaffStudentGrowthMeasure
ON tpdm.StaffStudentGrowthMeasureAcademicSubject (FactAsOfDate ASC, SchoolYear ASC, StaffStudentGrowthMeasureIdentifier ASC, StaffUSI ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureCourseAssociation ADD CONSTRAINT FK_f22014_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_f22014_Course
ON tpdm.StaffStudentGrowthMeasureCourseAssociation (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureCourseAssociation ADD CONSTRAINT FK_f22014_StaffStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
REFERENCES tpdm.StaffStudentGrowthMeasure (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
;

CREATE INDEX FK_f22014_StaffStudentGrowthMeasure
ON tpdm.StaffStudentGrowthMeasureCourseAssociation (FactAsOfDate ASC, SchoolYear ASC, StaffStudentGrowthMeasureIdentifier ASC, StaffUSI ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation ADD CONSTRAINT FK_120788_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_120788_EducationOrganization
ON tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation (EducationOrganizationId ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation ADD CONSTRAINT FK_120788_StaffStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
REFERENCES tpdm.StaffStudentGrowthMeasure (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
;

CREATE INDEX FK_120788_StaffStudentGrowthMeasure
ON tpdm.StaffStudentGrowthMeasureEducationOrganizationAssociation (FactAsOfDate ASC, SchoolYear ASC, StaffStudentGrowthMeasureIdentifier ASC, StaffUSI ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureGradeLevel ADD CONSTRAINT FK_455e3f_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_455e3f_GradeLevelDescriptor
ON tpdm.StaffStudentGrowthMeasureGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureGradeLevel ADD CONSTRAINT FK_455e3f_StaffStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
REFERENCES tpdm.StaffStudentGrowthMeasure (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_455e3f_StaffStudentGrowthMeasure
ON tpdm.StaffStudentGrowthMeasureGradeLevel (FactAsOfDate ASC, SchoolYear ASC, StaffStudentGrowthMeasureIdentifier ASC, StaffUSI ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureSectionAssociation ADD CONSTRAINT FK_fbfeb4_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_fbfeb4_Section
ON tpdm.StaffStudentGrowthMeasureSectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE tpdm.StaffStudentGrowthMeasureSectionAssociation ADD CONSTRAINT FK_fbfeb4_StaffStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
REFERENCES tpdm.StaffStudentGrowthMeasure (FactAsOfDate, SchoolYear, StaffStudentGrowthMeasureIdentifier, StaffUSI)
;

CREATE INDEX FK_fbfeb4_StaffStudentGrowthMeasure
ON tpdm.StaffStudentGrowthMeasureSectionAssociation (FactAsOfDate ASC, SchoolYear ASC, StaffStudentGrowthMeasureIdentifier ASC, StaffUSI ASC);

ALTER TABLE tpdm.StaffTeacherEducatorResearch ADD CONSTRAINT FK_3234a7_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StaffTeacherPreparationProgram ADD CONSTRAINT FK_41a331_LevelOfDegreeAwardedDescriptor FOREIGN KEY (LevelOfDegreeAwardedDescriptorId)
REFERENCES tpdm.LevelOfDegreeAwardedDescriptor (LevelOfDegreeAwardedDescriptorId)
;

CREATE INDEX FK_41a331_LevelOfDegreeAwardedDescriptor
ON tpdm.StaffTeacherPreparationProgram (LevelOfDegreeAwardedDescriptorId ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProgram ADD CONSTRAINT FK_41a331_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_41a331_Staff
ON tpdm.StaffTeacherPreparationProgram (StaffUSI ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProgram ADD CONSTRAINT FK_41a331_TeacherPreparationProgramTypeDescriptor FOREIGN KEY (TeacherPreparationProgramTypeDescriptorId)
REFERENCES tpdm.TeacherPreparationProgramTypeDescriptor (TeacherPreparationProgramTypeDescriptorId)
;

CREATE INDEX FK_41a331_TeacherPreparationProgramTypeDescriptor
ON tpdm.StaffTeacherPreparationProgram (TeacherPreparationProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderAssociation ADD CONSTRAINT FK_7bf40b_ProgramAssignmentDescriptor FOREIGN KEY (ProgramAssignmentDescriptorId)
REFERENCES edfi.ProgramAssignmentDescriptor (ProgramAssignmentDescriptorId)
;

CREATE INDEX FK_7bf40b_ProgramAssignmentDescriptor
ON tpdm.StaffTeacherPreparationProviderAssociation (ProgramAssignmentDescriptorId ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderAssociation ADD CONSTRAINT FK_7bf40b_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_7bf40b_SchoolYearType
ON tpdm.StaffTeacherPreparationProviderAssociation (SchoolYear ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderAssociation ADD CONSTRAINT FK_7bf40b_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_7bf40b_Staff
ON tpdm.StaffTeacherPreparationProviderAssociation (StaffUSI ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderAssociation ADD CONSTRAINT FK_7bf40b_TeacherPreparationProvider FOREIGN KEY (TeacherPreparationProviderId)
REFERENCES tpdm.TeacherPreparationProvider (TeacherPreparationProviderId)
;

CREATE INDEX FK_7bf40b_TeacherPreparationProvider
ON tpdm.StaffTeacherPreparationProviderAssociation (TeacherPreparationProviderId ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject ADD CONSTRAINT FK_32c1aa_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_32c1aa_AcademicSubjectDescriptor
ON tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject ADD CONSTRAINT FK_32c1aa_StaffTeacherPreparationProviderAssociation FOREIGN KEY (StaffUSI, TeacherPreparationProviderId)
REFERENCES tpdm.StaffTeacherPreparationProviderAssociation (StaffUSI, TeacherPreparationProviderId)
ON DELETE CASCADE
;

CREATE INDEX FK_32c1aa_StaffTeacherPreparationProviderAssociation
ON tpdm.StaffTeacherPreparationProviderAssociationAcademicSubject (StaffUSI ASC, TeacherPreparationProviderId ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderAssociationGradeLevel ADD CONSTRAINT FK_e2901f_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_e2901f_GradeLevelDescriptor
ON tpdm.StaffTeacherPreparationProviderAssociationGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderAssociationGradeLevel ADD CONSTRAINT FK_e2901f_StaffTeacherPreparationProviderAssociation FOREIGN KEY (StaffUSI, TeacherPreparationProviderId)
REFERENCES tpdm.StaffTeacherPreparationProviderAssociation (StaffUSI, TeacherPreparationProviderId)
ON DELETE CASCADE
;

CREATE INDEX FK_e2901f_StaffTeacherPreparationProviderAssociation
ON tpdm.StaffTeacherPreparationProviderAssociationGradeLevel (StaffUSI ASC, TeacherPreparationProviderId ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderProgramAssociation ADD CONSTRAINT FK_5bac62_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_5bac62_Staff
ON tpdm.StaffTeacherPreparationProviderProgramAssociation (StaffUSI ASC);

ALTER TABLE tpdm.StaffTeacherPreparationProviderProgramAssociation ADD CONSTRAINT FK_5bac62_TeacherPreparationProviderProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.TeacherPreparationProviderProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_5bac62_TeacherPreparationProviderProgram
ON tpdm.StaffTeacherPreparationProviderProgramAssociation (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.StateEducationAgencyExtension ADD CONSTRAINT FK_31f08a_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_31f08a_FederalLocaleCodeDescriptor
ON tpdm.StateEducationAgencyExtension (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.StateEducationAgencyExtension ADD CONSTRAINT FK_31f08a_StateEducationAgency FOREIGN KEY (StateEducationAgencyId)
REFERENCES edfi.StateEducationAgency (StateEducationAgencyId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.StudentGradebookEntryExtension ADD CONSTRAINT FK_c1d2f5_StudentGradebookEntry FOREIGN KEY (BeginDate, DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentGradebookEntry (BeginDate, DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE tpdm.StudentGrowthTypeDescriptor ADD CONSTRAINT FK_132667_Descriptor FOREIGN KEY (StudentGrowthTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SurveyResponseExtension ADD CONSTRAINT FK_fa906d_Applicant FOREIGN KEY (ApplicantIdentifier)
REFERENCES tpdm.Applicant (ApplicantIdentifier)
;

CREATE INDEX FK_fa906d_Applicant
ON tpdm.SurveyResponseExtension (ApplicantIdentifier ASC);

ALTER TABLE tpdm.SurveyResponseExtension ADD CONSTRAINT FK_fa906d_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SurveyResponseExtension ADD CONSTRAINT FK_fa906d_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_fa906d_TeacherCandidate
ON tpdm.SurveyResponseExtension (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.SurveyResponseTeacherCandidateTargetAssociation ADD CONSTRAINT FK_049bd0_SurveyResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
REFERENCES edfi.SurveyResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier)
;

CREATE INDEX FK_049bd0_SurveyResponse
ON tpdm.SurveyResponseTeacherCandidateTargetAssociation (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC);

ALTER TABLE tpdm.SurveyResponseTeacherCandidateTargetAssociation ADD CONSTRAINT FK_049bd0_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_049bd0_TeacherCandidate
ON tpdm.SurveyResponseTeacherCandidateTargetAssociation (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.SurveySectionAggregateResponse ADD CONSTRAINT FK_f37ae9_EvaluationElementRating FOREIGN KEY (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
REFERENCES tpdm.EvaluationElementRating (EducationOrganizationId, EvaluationDate, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, PersonId, SchoolYear, SourceSystemDescriptorId, TermDescriptorId)
;

CREATE INDEX FK_f37ae9_EvaluationElementRating
ON tpdm.SurveySectionAggregateResponse (EducationOrganizationId ASC, EvaluationDate ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, PersonId ASC, SchoolYear ASC, SourceSystemDescriptorId ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.SurveySectionAggregateResponse ADD CONSTRAINT FK_f37ae9_SurveySection FOREIGN KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySection (Namespace, SurveyIdentifier, SurveySectionTitle)
;

CREATE INDEX FK_f37ae9_SurveySection
ON tpdm.SurveySectionAggregateResponse (Namespace ASC, SurveyIdentifier ASC, SurveySectionTitle ASC);

ALTER TABLE tpdm.SurveySectionExtension ADD CONSTRAINT FK_a1b07d_EvaluationElement FOREIGN KEY (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
REFERENCES tpdm.EvaluationElement (EducationOrganizationId, EvaluationElementTitle, EvaluationObjectiveTitle, EvaluationPeriodDescriptorId, EvaluationTitle, PerformanceEvaluationTitle, PerformanceEvaluationTypeDescriptorId, SchoolYear, TermDescriptorId)
;

CREATE INDEX FK_a1b07d_EvaluationElement
ON tpdm.SurveySectionExtension (EducationOrganizationId ASC, EvaluationElementTitle ASC, EvaluationObjectiveTitle ASC, EvaluationPeriodDescriptorId ASC, EvaluationTitle ASC, PerformanceEvaluationTitle ASC, PerformanceEvaluationTypeDescriptorId ASC, SchoolYear ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.SurveySectionExtension ADD CONSTRAINT FK_a1b07d_SurveySection FOREIGN KEY (Namespace, SurveyIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySection (Namespace, SurveyIdentifier, SurveySectionTitle)
ON DELETE CASCADE
;

ALTER TABLE tpdm.SurveySectionResponseTeacherCandidateTargetAssociation ADD CONSTRAINT FK_948dd8_SurveySectionResponse FOREIGN KEY (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
REFERENCES edfi.SurveySectionResponse (Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle)
;

CREATE INDEX FK_948dd8_SurveySectionResponse
ON tpdm.SurveySectionResponseTeacherCandidateTargetAssociation (Namespace ASC, SurveyIdentifier ASC, SurveyResponseIdentifier ASC, SurveySectionTitle ASC);

ALTER TABLE tpdm.SurveySectionResponseTeacherCandidateTargetAssociation ADD CONSTRAINT FK_948dd8_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_948dd8_TeacherCandidate
ON tpdm.SurveySectionResponseTeacherCandidateTargetAssociation (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_CitizenshipStatusDescriptor FOREIGN KEY (CitizenshipStatusDescriptorId)
REFERENCES edfi.CitizenshipStatusDescriptor (CitizenshipStatusDescriptorId)
;

CREATE INDEX FK_835b49_CitizenshipStatusDescriptor
ON tpdm.TeacherCandidate (CitizenshipStatusDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_CountryDescriptor FOREIGN KEY (BirthCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_835b49_CountryDescriptor
ON tpdm.TeacherCandidate (BirthCountryDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_EnglishLanguageExamDescriptor FOREIGN KEY (EnglishLanguageExamDescriptorId)
REFERENCES tpdm.EnglishLanguageExamDescriptor (EnglishLanguageExamDescriptorId)
;

CREATE INDEX FK_835b49_EnglishLanguageExamDescriptor
ON tpdm.TeacherCandidate (EnglishLanguageExamDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_GenderDescriptor FOREIGN KEY (GenderDescriptorId)
REFERENCES tpdm.GenderDescriptor (GenderDescriptorId)
;

CREATE INDEX FK_835b49_GenderDescriptor
ON tpdm.TeacherCandidate (GenderDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_LimitedEnglishProficiencyDescriptor FOREIGN KEY (LimitedEnglishProficiencyDescriptorId)
REFERENCES edfi.LimitedEnglishProficiencyDescriptor (LimitedEnglishProficiencyDescriptorId)
;

CREATE INDEX FK_835b49_LimitedEnglishProficiencyDescriptor
ON tpdm.TeacherCandidate (LimitedEnglishProficiencyDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_OldEthnicityDescriptor FOREIGN KEY (OldEthnicityDescriptorId)
REFERENCES edfi.OldEthnicityDescriptor (OldEthnicityDescriptorId)
;

CREATE INDEX FK_835b49_OldEthnicityDescriptor
ON tpdm.TeacherCandidate (OldEthnicityDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_Person FOREIGN KEY (PersonId, SourceSystemDescriptorId)
REFERENCES edfi.Person (PersonId, SourceSystemDescriptorId)
;

CREATE INDEX FK_835b49_Person
ON tpdm.TeacherCandidate (PersonId ASC, SourceSystemDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_PreviousCareerDescriptor FOREIGN KEY (PreviousCareerDescriptorId)
REFERENCES tpdm.PreviousCareerDescriptor (PreviousCareerDescriptorId)
;

CREATE INDEX FK_835b49_PreviousCareerDescriptor
ON tpdm.TeacherCandidate (PreviousCareerDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_SexDescriptor FOREIGN KEY (SexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_835b49_SexDescriptor
ON tpdm.TeacherCandidate (SexDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_SexDescriptor1 FOREIGN KEY (BirthSexDescriptorId)
REFERENCES edfi.SexDescriptor (SexDescriptorId)
;

CREATE INDEX FK_835b49_SexDescriptor1
ON tpdm.TeacherCandidate (BirthSexDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_StateAbbreviationDescriptor FOREIGN KEY (BirthStateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_835b49_StateAbbreviationDescriptor
ON tpdm.TeacherCandidate (BirthStateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidate ADD CONSTRAINT FK_835b49_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_835b49_Student
ON tpdm.TeacherCandidate (StudentUSI ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_CreditTypeDescriptor FOREIGN KEY (CumulativeEarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_163dde_CreditTypeDescriptor
ON tpdm.TeacherCandidateAcademicRecord (CumulativeEarnedCreditTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_CreditTypeDescriptor1 FOREIGN KEY (CumulativeAttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_163dde_CreditTypeDescriptor1
ON tpdm.TeacherCandidateAcademicRecord (CumulativeAttemptedCreditTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_CreditTypeDescriptor2 FOREIGN KEY (SessionEarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_163dde_CreditTypeDescriptor2
ON tpdm.TeacherCandidateAcademicRecord (SessionEarnedCreditTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_CreditTypeDescriptor3 FOREIGN KEY (SessionAttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_163dde_CreditTypeDescriptor3
ON tpdm.TeacherCandidateAcademicRecord (SessionAttemptedCreditTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_163dde_EducationOrganization
ON tpdm.TeacherCandidateAcademicRecord (EducationOrganizationId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_ProgramGatewayDescriptor FOREIGN KEY (ProgramGatewayDescriptorId)
REFERENCES tpdm.ProgramGatewayDescriptor (ProgramGatewayDescriptorId)
;

CREATE INDEX FK_163dde_ProgramGatewayDescriptor
ON tpdm.TeacherCandidateAcademicRecord (ProgramGatewayDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_163dde_SchoolYearType
ON tpdm.TeacherCandidateAcademicRecord (SchoolYear ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_163dde_TeacherCandidate
ON tpdm.TeacherCandidateAcademicRecord (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_163dde_TermDescriptor
ON tpdm.TeacherCandidateAcademicRecord (TermDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecord ADD CONSTRAINT FK_163dde_TPPDegreeTypeDescriptor FOREIGN KEY (TPPDegreeTypeDescriptorId)
REFERENCES tpdm.TPPDegreeTypeDescriptor (TPPDegreeTypeDescriptorId)
;

CREATE INDEX FK_163dde_TPPDegreeTypeDescriptor
ON tpdm.TeacherCandidateAcademicRecord (TPPDegreeTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordAcademicHonor ADD CONSTRAINT FK_5422f8_AcademicHonorCategoryDescriptor FOREIGN KEY (AcademicHonorCategoryDescriptorId)
REFERENCES edfi.AcademicHonorCategoryDescriptor (AcademicHonorCategoryDescriptorId)
;

CREATE INDEX FK_5422f8_AcademicHonorCategoryDescriptor
ON tpdm.TeacherCandidateAcademicRecordAcademicHonor (AcademicHonorCategoryDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordAcademicHonor ADD CONSTRAINT FK_5422f8_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

CREATE INDEX FK_5422f8_AchievementCategoryDescriptor
ON tpdm.TeacherCandidateAcademicRecordAcademicHonor (AchievementCategoryDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordAcademicHonor ADD CONSTRAINT FK_5422f8_TeacherCandidateAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
REFERENCES tpdm.TeacherCandidateAcademicRecord (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_5422f8_TeacherCandidateAcademicRecord
ON tpdm.TeacherCandidateAcademicRecordAcademicHonor (EducationOrganizationId ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordClassRanking ADD CONSTRAINT FK_e59008_TeacherCandidateAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
REFERENCES tpdm.TeacherCandidateAcademicRecord (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.TeacherCandidateAcademicRecordDiploma ADD CONSTRAINT FK_dd7b47_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

CREATE INDEX FK_dd7b47_AchievementCategoryDescriptor
ON tpdm.TeacherCandidateAcademicRecordDiploma (AchievementCategoryDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordDiploma ADD CONSTRAINT FK_dd7b47_DiplomaLevelDescriptor FOREIGN KEY (DiplomaLevelDescriptorId)
REFERENCES edfi.DiplomaLevelDescriptor (DiplomaLevelDescriptorId)
;

CREATE INDEX FK_dd7b47_DiplomaLevelDescriptor
ON tpdm.TeacherCandidateAcademicRecordDiploma (DiplomaLevelDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordDiploma ADD CONSTRAINT FK_dd7b47_DiplomaTypeDescriptor FOREIGN KEY (DiplomaTypeDescriptorId)
REFERENCES edfi.DiplomaTypeDescriptor (DiplomaTypeDescriptorId)
;

CREATE INDEX FK_dd7b47_DiplomaTypeDescriptor
ON tpdm.TeacherCandidateAcademicRecordDiploma (DiplomaTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordDiploma ADD CONSTRAINT FK_dd7b47_TeacherCandidateAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
REFERENCES tpdm.TeacherCandidateAcademicRecord (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_dd7b47_TeacherCandidateAcademicRecord
ON tpdm.TeacherCandidateAcademicRecordDiploma (EducationOrganizationId ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordGradePointAverage ADD CONSTRAINT FK_ab13d0_GradePointAverageTypeDescriptor FOREIGN KEY (GradePointAverageTypeDescriptorId)
REFERENCES edfi.GradePointAverageTypeDescriptor (GradePointAverageTypeDescriptorId)
;

CREATE INDEX FK_ab13d0_GradePointAverageTypeDescriptor
ON tpdm.TeacherCandidateAcademicRecordGradePointAverage (GradePointAverageTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordGradePointAverage ADD CONSTRAINT FK_ab13d0_TeacherCandidateAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
REFERENCES tpdm.TeacherCandidateAcademicRecord (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_ab13d0_TeacherCandidateAcademicRecord
ON tpdm.TeacherCandidateAcademicRecordGradePointAverage (EducationOrganizationId ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordRecognition ADD CONSTRAINT FK_ffa30c_AchievementCategoryDescriptor FOREIGN KEY (AchievementCategoryDescriptorId)
REFERENCES edfi.AchievementCategoryDescriptor (AchievementCategoryDescriptorId)
;

CREATE INDEX FK_ffa30c_AchievementCategoryDescriptor
ON tpdm.TeacherCandidateAcademicRecordRecognition (AchievementCategoryDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordRecognition ADD CONSTRAINT FK_ffa30c_RecognitionTypeDescriptor FOREIGN KEY (RecognitionTypeDescriptorId)
REFERENCES edfi.RecognitionTypeDescriptor (RecognitionTypeDescriptorId)
;

CREATE INDEX FK_ffa30c_RecognitionTypeDescriptor
ON tpdm.TeacherCandidateAcademicRecordRecognition (RecognitionTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAcademicRecordRecognition ADD CONSTRAINT FK_ffa30c_TeacherCandidateAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
REFERENCES tpdm.TeacherCandidateAcademicRecord (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_ffa30c_TeacherCandidateAcademicRecord
ON tpdm.TeacherCandidateAcademicRecordRecognition (EducationOrganizationId ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAddress ADD CONSTRAINT FK_791088_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_791088_AddressTypeDescriptor
ON tpdm.TeacherCandidateAddress (AddressTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAddress ADD CONSTRAINT FK_791088_LocaleDescriptor FOREIGN KEY (LocaleDescriptorId)
REFERENCES edfi.LocaleDescriptor (LocaleDescriptorId)
;

CREATE INDEX FK_791088_LocaleDescriptor
ON tpdm.TeacherCandidateAddress (LocaleDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAddress ADD CONSTRAINT FK_791088_StateAbbreviationDescriptor FOREIGN KEY (StateAbbreviationDescriptorId)
REFERENCES edfi.StateAbbreviationDescriptor (StateAbbreviationDescriptorId)
;

CREATE INDEX FK_791088_StateAbbreviationDescriptor
ON tpdm.TeacherCandidateAddress (StateAbbreviationDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAddress ADD CONSTRAINT FK_791088_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_791088_TeacherCandidate
ON tpdm.TeacherCandidateAddress (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateAddressPeriod ADD CONSTRAINT FK_5309d6_TeacherCandidateAddress FOREIGN KEY (AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidateAddress (AddressTypeDescriptorId, City, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_5309d6_TeacherCandidateAddress
ON tpdm.TeacherCandidateAddressPeriod (AddressTypeDescriptorId ASC, City ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC, TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateAid ADD CONSTRAINT FK_8d1b7a_AidTypeDescriptor FOREIGN KEY (AidTypeDescriptorId)
REFERENCES tpdm.AidTypeDescriptor (AidTypeDescriptorId)
;

CREATE INDEX FK_8d1b7a_AidTypeDescriptor
ON tpdm.TeacherCandidateAid (AidTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateAid ADD CONSTRAINT FK_8d1b7a_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_8d1b7a_TeacherCandidate
ON tpdm.TeacherCandidateAid (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateBackgroundCheck ADD CONSTRAINT FK_c7750c_BackgroundCheckStatusDescriptor FOREIGN KEY (BackgroundCheckStatusDescriptorId)
REFERENCES tpdm.BackgroundCheckStatusDescriptor (BackgroundCheckStatusDescriptorId)
;

CREATE INDEX FK_c7750c_BackgroundCheckStatusDescriptor
ON tpdm.TeacherCandidateBackgroundCheck (BackgroundCheckStatusDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateBackgroundCheck ADD CONSTRAINT FK_c7750c_BackgroundCheckTypeDescriptor FOREIGN KEY (BackgroundCheckTypeDescriptorId)
REFERENCES tpdm.BackgroundCheckTypeDescriptor (BackgroundCheckTypeDescriptorId)
;

CREATE INDEX FK_c7750c_BackgroundCheckTypeDescriptor
ON tpdm.TeacherCandidateBackgroundCheck (BackgroundCheckTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateBackgroundCheck ADD CONSTRAINT FK_c7750c_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

ALTER TABLE tpdm.TeacherCandidateCharacteristic ADD CONSTRAINT FK_2a656a_StudentCharacteristicDescriptor FOREIGN KEY (StudentCharacteristicDescriptorId)
REFERENCES edfi.StudentCharacteristicDescriptor (StudentCharacteristicDescriptorId)
;

CREATE INDEX FK_2a656a_StudentCharacteristicDescriptor
ON tpdm.TeacherCandidateCharacteristic (StudentCharacteristicDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCharacteristic ADD CONSTRAINT FK_2a656a_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_2a656a_TeacherCandidate
ON tpdm.TeacherCandidateCharacteristic (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateCharacteristicDescriptor ADD CONSTRAINT FK_953e18_Descriptor FOREIGN KEY (TeacherCandidateCharacteristicDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.TeacherCandidateCohortYear ADD CONSTRAINT FK_c65c6e_CohortYearTypeDescriptor FOREIGN KEY (CohortYearTypeDescriptorId)
REFERENCES edfi.CohortYearTypeDescriptor (CohortYearTypeDescriptorId)
;

CREATE INDEX FK_c65c6e_CohortYearTypeDescriptor
ON tpdm.TeacherCandidateCohortYear (CohortYearTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCohortYear ADD CONSTRAINT FK_c65c6e_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_c65c6e_SchoolYearType
ON tpdm.TeacherCandidateCohortYear (SchoolYear ASC);

ALTER TABLE tpdm.TeacherCandidateCohortYear ADD CONSTRAINT FK_c65c6e_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_c65c6e_TeacherCandidate
ON tpdm.TeacherCandidateCohortYear (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_Course FOREIGN KEY (CourseCode, CourseEducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_87fd83_Course
ON tpdm.TeacherCandidateCourseTranscript (CourseCode ASC, CourseEducationOrganizationId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_CourseAttemptResultDescriptor FOREIGN KEY (CourseAttemptResultDescriptorId)
REFERENCES edfi.CourseAttemptResultDescriptor (CourseAttemptResultDescriptorId)
;

CREATE INDEX FK_87fd83_CourseAttemptResultDescriptor
ON tpdm.TeacherCandidateCourseTranscript (CourseAttemptResultDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_CourseRepeatCodeDescriptor FOREIGN KEY (CourseRepeatCodeDescriptorId)
REFERENCES edfi.CourseRepeatCodeDescriptor (CourseRepeatCodeDescriptorId)
;

CREATE INDEX FK_87fd83_CourseRepeatCodeDescriptor
ON tpdm.TeacherCandidateCourseTranscript (CourseRepeatCodeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_CreditTypeDescriptor FOREIGN KEY (AttemptedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_87fd83_CreditTypeDescriptor
ON tpdm.TeacherCandidateCourseTranscript (AttemptedCreditTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_CreditTypeDescriptor1 FOREIGN KEY (EarnedCreditTypeDescriptorId)
REFERENCES edfi.CreditTypeDescriptor (CreditTypeDescriptorId)
;

CREATE INDEX FK_87fd83_CreditTypeDescriptor1
ON tpdm.TeacherCandidateCourseTranscript (EarnedCreditTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_GradeLevelDescriptor FOREIGN KEY (WhenTakenGradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_87fd83_GradeLevelDescriptor
ON tpdm.TeacherCandidateCourseTranscript (WhenTakenGradeLevelDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_MethodCreditEarnedDescriptor FOREIGN KEY (MethodCreditEarnedDescriptorId)
REFERENCES edfi.MethodCreditEarnedDescriptor (MethodCreditEarnedDescriptorId)
;

CREATE INDEX FK_87fd83_MethodCreditEarnedDescriptor
ON tpdm.TeacherCandidateCourseTranscript (MethodCreditEarnedDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_87fd83_School
ON tpdm.TeacherCandidateCourseTranscript (SchoolId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscript ADD CONSTRAINT FK_87fd83_TeacherCandidateAcademicRecord FOREIGN KEY (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
REFERENCES tpdm.TeacherCandidateAcademicRecord (EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
;

CREATE INDEX FK_87fd83_TeacherCandidateAcademicRecord
ON tpdm.TeacherCandidateCourseTranscript (EducationOrganizationId ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits ADD CONSTRAINT FK_ae1084_AdditionalCreditTypeDescriptor FOREIGN KEY (AdditionalCreditTypeDescriptorId)
REFERENCES edfi.AdditionalCreditTypeDescriptor (AdditionalCreditTypeDescriptorId)
;

CREATE INDEX FK_ae1084_AdditionalCreditTypeDescriptor
ON tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits (AdditionalCreditTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits ADD CONSTRAINT FK_ae1084_TeacherCandidateCourseTranscript FOREIGN KEY (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
REFERENCES tpdm.TeacherCandidateCourseTranscript (CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, TeacherCandidateIdentifier, TermDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_ae1084_TeacherCandidateCourseTranscript
ON tpdm.TeacherCandidateCourseTranscriptEarnedAdditionalCredits (CourseAttemptResultDescriptorId ASC, CourseCode ASC, CourseEducationOrganizationId ASC, EducationOrganizationId ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TermDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateDegreeSpecialization ADD CONSTRAINT FK_8b2999_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_8b2999_TeacherCandidate
ON tpdm.TeacherCandidateDegreeSpecialization (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateDisability ADD CONSTRAINT FK_976a42_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_976a42_DisabilityDescriptor
ON tpdm.TeacherCandidateDisability (DisabilityDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateDisability ADD CONSTRAINT FK_976a42_DisabilityDeterminationSourceTypeDescriptor FOREIGN KEY (DisabilityDeterminationSourceTypeDescriptorId)
REFERENCES edfi.DisabilityDeterminationSourceTypeDescriptor (DisabilityDeterminationSourceTypeDescriptorId)
;

CREATE INDEX FK_976a42_DisabilityDeterminationSourceTypeDescriptor
ON tpdm.TeacherCandidateDisability (DisabilityDeterminationSourceTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateDisability ADD CONSTRAINT FK_976a42_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_976a42_TeacherCandidate
ON tpdm.TeacherCandidateDisability (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateDisabilityDesignation ADD CONSTRAINT FK_b5627c_DisabilityDesignationDescriptor FOREIGN KEY (DisabilityDesignationDescriptorId)
REFERENCES edfi.DisabilityDesignationDescriptor (DisabilityDesignationDescriptorId)
;

CREATE INDEX FK_b5627c_DisabilityDesignationDescriptor
ON tpdm.TeacherCandidateDisabilityDesignation (DisabilityDesignationDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateDisabilityDesignation ADD CONSTRAINT FK_b5627c_TeacherCandidateDisability FOREIGN KEY (DisabilityDescriptorId, TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidateDisability (DisabilityDescriptorId, TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_b5627c_TeacherCandidateDisability
ON tpdm.TeacherCandidateDisabilityDesignation (DisabilityDescriptorId ASC, TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateElectronicMail ADD CONSTRAINT FK_a3a2ab_ElectronicMailTypeDescriptor FOREIGN KEY (ElectronicMailTypeDescriptorId)
REFERENCES edfi.ElectronicMailTypeDescriptor (ElectronicMailTypeDescriptorId)
;

CREATE INDEX FK_a3a2ab_ElectronicMailTypeDescriptor
ON tpdm.TeacherCandidateElectronicMail (ElectronicMailTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateElectronicMail ADD CONSTRAINT FK_a3a2ab_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_a3a2ab_TeacherCandidate
ON tpdm.TeacherCandidateElectronicMail (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateIdentificationCode ADD CONSTRAINT FK_6f624f_StudentIdentificationSystemDescriptor FOREIGN KEY (StudentIdentificationSystemDescriptorId)
REFERENCES edfi.StudentIdentificationSystemDescriptor (StudentIdentificationSystemDescriptorId)
;

CREATE INDEX FK_6f624f_StudentIdentificationSystemDescriptor
ON tpdm.TeacherCandidateIdentificationCode (StudentIdentificationSystemDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateIdentificationCode ADD CONSTRAINT FK_6f624f_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_6f624f_TeacherCandidate
ON tpdm.TeacherCandidateIdentificationCode (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateIdentificationDocument ADD CONSTRAINT FK_b8a0a3_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_b8a0a3_CountryDescriptor
ON tpdm.TeacherCandidateIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateIdentificationDocument ADD CONSTRAINT FK_b8a0a3_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_b8a0a3_IdentificationDocumentUseDescriptor
ON tpdm.TeacherCandidateIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateIdentificationDocument ADD CONSTRAINT FK_b8a0a3_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_b8a0a3_PersonalInformationVerificationDescriptor
ON tpdm.TeacherCandidateIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateIdentificationDocument ADD CONSTRAINT FK_b8a0a3_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_b8a0a3_TeacherCandidate
ON tpdm.TeacherCandidateIdentificationDocument (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateIndicator ADD CONSTRAINT FK_ab19f4_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_ab19f4_TeacherCandidate
ON tpdm.TeacherCandidateIndicator (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateInternationalAddress ADD CONSTRAINT FK_d625c9_AddressTypeDescriptor FOREIGN KEY (AddressTypeDescriptorId)
REFERENCES edfi.AddressTypeDescriptor (AddressTypeDescriptorId)
;

CREATE INDEX FK_d625c9_AddressTypeDescriptor
ON tpdm.TeacherCandidateInternationalAddress (AddressTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateInternationalAddress ADD CONSTRAINT FK_d625c9_CountryDescriptor FOREIGN KEY (CountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_d625c9_CountryDescriptor
ON tpdm.TeacherCandidateInternationalAddress (CountryDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateInternationalAddress ADD CONSTRAINT FK_d625c9_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_d625c9_TeacherCandidate
ON tpdm.TeacherCandidateInternationalAddress (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateLanguage ADD CONSTRAINT FK_e2f84b_LanguageDescriptor FOREIGN KEY (LanguageDescriptorId)
REFERENCES edfi.LanguageDescriptor (LanguageDescriptorId)
;

CREATE INDEX FK_e2f84b_LanguageDescriptor
ON tpdm.TeacherCandidateLanguage (LanguageDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateLanguage ADD CONSTRAINT FK_e2f84b_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_e2f84b_TeacherCandidate
ON tpdm.TeacherCandidateLanguage (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateLanguageUse ADD CONSTRAINT FK_95cf0d_LanguageUseDescriptor FOREIGN KEY (LanguageUseDescriptorId)
REFERENCES edfi.LanguageUseDescriptor (LanguageUseDescriptorId)
;

CREATE INDEX FK_95cf0d_LanguageUseDescriptor
ON tpdm.TeacherCandidateLanguageUse (LanguageUseDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateLanguageUse ADD CONSTRAINT FK_95cf0d_TeacherCandidateLanguage FOREIGN KEY (LanguageDescriptorId, TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidateLanguage (LanguageDescriptorId, TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_95cf0d_TeacherCandidateLanguage
ON tpdm.TeacherCandidateLanguageUse (LanguageDescriptorId ASC, TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateOtherName ADD CONSTRAINT FK_c3040c_OtherNameTypeDescriptor FOREIGN KEY (OtherNameTypeDescriptorId)
REFERENCES edfi.OtherNameTypeDescriptor (OtherNameTypeDescriptorId)
;

CREATE INDEX FK_c3040c_OtherNameTypeDescriptor
ON tpdm.TeacherCandidateOtherName (OtherNameTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateOtherName ADD CONSTRAINT FK_c3040c_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_c3040c_TeacherCandidate
ON tpdm.TeacherCandidateOtherName (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidatePersonalIdentificationDocument ADD CONSTRAINT FK_9f2892_CountryDescriptor FOREIGN KEY (IssuerCountryDescriptorId)
REFERENCES edfi.CountryDescriptor (CountryDescriptorId)
;

CREATE INDEX FK_9f2892_CountryDescriptor
ON tpdm.TeacherCandidatePersonalIdentificationDocument (IssuerCountryDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidatePersonalIdentificationDocument ADD CONSTRAINT FK_9f2892_IdentificationDocumentUseDescriptor FOREIGN KEY (IdentificationDocumentUseDescriptorId)
REFERENCES edfi.IdentificationDocumentUseDescriptor (IdentificationDocumentUseDescriptorId)
;

CREATE INDEX FK_9f2892_IdentificationDocumentUseDescriptor
ON tpdm.TeacherCandidatePersonalIdentificationDocument (IdentificationDocumentUseDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidatePersonalIdentificationDocument ADD CONSTRAINT FK_9f2892_PersonalInformationVerificationDescriptor FOREIGN KEY (PersonalInformationVerificationDescriptorId)
REFERENCES edfi.PersonalInformationVerificationDescriptor (PersonalInformationVerificationDescriptorId)
;

CREATE INDEX FK_9f2892_PersonalInformationVerificationDescriptor
ON tpdm.TeacherCandidatePersonalIdentificationDocument (PersonalInformationVerificationDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidatePersonalIdentificationDocument ADD CONSTRAINT FK_9f2892_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_9f2892_TeacherCandidate
ON tpdm.TeacherCandidatePersonalIdentificationDocument (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateRace ADD CONSTRAINT FK_9c1586_RaceDescriptor FOREIGN KEY (RaceDescriptorId)
REFERENCES edfi.RaceDescriptor (RaceDescriptorId)
;

CREATE INDEX FK_9c1586_RaceDescriptor
ON tpdm.TeacherCandidateRace (RaceDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateRace ADD CONSTRAINT FK_9c1586_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_9c1586_TeacherCandidate
ON tpdm.TeacherCandidateRace (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateStaffAssociation ADD CONSTRAINT FK_3395e5_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_3395e5_Staff
ON tpdm.TeacherCandidateStaffAssociation (StaffUSI ASC);

ALTER TABLE tpdm.TeacherCandidateStaffAssociation ADD CONSTRAINT FK_3395e5_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_3395e5_TeacherCandidate
ON tpdm.TeacherCandidateStaffAssociation (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasure ADD CONSTRAINT FK_464a58_ResultDatatypeTypeDescriptor FOREIGN KEY (ResultDatatypeTypeDescriptorId)
REFERENCES edfi.ResultDatatypeTypeDescriptor (ResultDatatypeTypeDescriptorId)
;

CREATE INDEX FK_464a58_ResultDatatypeTypeDescriptor
ON tpdm.TeacherCandidateStudentGrowthMeasure (ResultDatatypeTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasure ADD CONSTRAINT FK_464a58_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_464a58_SchoolYearType
ON tpdm.TeacherCandidateStudentGrowthMeasure (SchoolYear ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasure ADD CONSTRAINT FK_464a58_StudentGrowthTypeDescriptor FOREIGN KEY (StudentGrowthTypeDescriptorId)
REFERENCES tpdm.StudentGrowthTypeDescriptor (StudentGrowthTypeDescriptorId)
;

CREATE INDEX FK_464a58_StudentGrowthTypeDescriptor
ON tpdm.TeacherCandidateStudentGrowthMeasure (StudentGrowthTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasure ADD CONSTRAINT FK_464a58_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_464a58_TeacherCandidate
ON tpdm.TeacherCandidateStudentGrowthMeasure (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject ADD CONSTRAINT FK_0ff099_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_0ff099_AcademicSubjectDescriptor
ON tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject ADD CONSTRAINT FK_0ff099_TeacherCandidateStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
REFERENCES tpdm.TeacherCandidateStudentGrowthMeasure (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_0ff099_TeacherCandidateStudentGrowthMeasure
ON tpdm.TeacherCandidateStudentGrowthMeasureAcademicSubject (FactAsOfDate ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TeacherCandidateStudentGrowthMeasureIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation ADD CONSTRAINT FK_512fab_Course FOREIGN KEY (CourseCode, EducationOrganizationId)
REFERENCES edfi.Course (CourseCode, EducationOrganizationId)
;

CREATE INDEX FK_512fab_Course
ON tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation (CourseCode ASC, EducationOrganizationId ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation ADD CONSTRAINT FK_512fab_TeacherCandidateStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
REFERENCES tpdm.TeacherCandidateStudentGrowthMeasure (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
;

CREATE INDEX FK_512fab_TeacherCandidateStudentGrowthMeasure
ON tpdm.TeacherCandidateStudentGrowthMeasureCourseAssociation (FactAsOfDate ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TeacherCandidateStudentGrowthMeasureIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 ADD CONSTRAINT FK_22b9a4_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_22b9a4_EducationOrganization
ON tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 (EducationOrganizationId ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 ADD CONSTRAINT FK_22b9a4_TeacherCandidateStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
REFERENCES tpdm.TeacherCandidateStudentGrowthMeasure (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
;

CREATE INDEX FK_22b9a4_TeacherCandidateStudentGrowthMeasure
ON tpdm.TeacherCandidateStudentGrowthMeasureEducationOrganizatio_22b9a4 (FactAsOfDate ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TeacherCandidateStudentGrowthMeasureIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel ADD CONSTRAINT FK_eaf52b_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_eaf52b_GradeLevelDescriptor
ON tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel ADD CONSTRAINT FK_eaf52b_TeacherCandidateStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
REFERENCES tpdm.TeacherCandidateStudentGrowthMeasure (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_eaf52b_TeacherCandidateStudentGrowthMeasure
ON tpdm.TeacherCandidateStudentGrowthMeasureGradeLevel (FactAsOfDate ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TeacherCandidateStudentGrowthMeasureIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation ADD CONSTRAINT FK_b8b1b0_Section FOREIGN KEY (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
REFERENCES edfi.Section (LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName)
ON UPDATE CASCADE
;

CREATE INDEX FK_b8b1b0_Section
ON tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation (LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC);

ALTER TABLE tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation ADD CONSTRAINT FK_b8b1b0_TeacherCandidateStudentGrowthMeasure FOREIGN KEY (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
REFERENCES tpdm.TeacherCandidateStudentGrowthMeasure (FactAsOfDate, SchoolYear, TeacherCandidateIdentifier, TeacherCandidateStudentGrowthMeasureIdentifier)
;

CREATE INDEX FK_b8b1b0_TeacherCandidateStudentGrowthMeasure
ON tpdm.TeacherCandidateStudentGrowthMeasureSectionAssociation (FactAsOfDate ASC, SchoolYear ASC, TeacherCandidateIdentifier ASC, TeacherCandidateStudentGrowthMeasureIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderAssociation ADD CONSTRAINT FK_0dff08_EntryTypeDescriptor FOREIGN KEY (EntryTypeDescriptorId)
REFERENCES edfi.EntryTypeDescriptor (EntryTypeDescriptorId)
;

CREATE INDEX FK_0dff08_EntryTypeDescriptor
ON tpdm.TeacherCandidateTeacherPreparationProviderAssociation (EntryTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderAssociation ADD CONSTRAINT FK_0dff08_ExitWithdrawTypeDescriptor FOREIGN KEY (ExitWithdrawTypeDescriptorId)
REFERENCES edfi.ExitWithdrawTypeDescriptor (ExitWithdrawTypeDescriptorId)
;

CREATE INDEX FK_0dff08_ExitWithdrawTypeDescriptor
ON tpdm.TeacherCandidateTeacherPreparationProviderAssociation (ExitWithdrawTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderAssociation ADD CONSTRAINT FK_0dff08_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_0dff08_SchoolYearType
ON tpdm.TeacherCandidateTeacherPreparationProviderAssociation (SchoolYear ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderAssociation ADD CONSTRAINT FK_0dff08_SchoolYearType1 FOREIGN KEY (ClassOfSchoolYear)
REFERENCES edfi.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_0dff08_SchoolYearType1
ON tpdm.TeacherCandidateTeacherPreparationProviderAssociation (ClassOfSchoolYear ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderAssociation ADD CONSTRAINT FK_0dff08_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_0dff08_TeacherCandidate
ON tpdm.TeacherCandidateTeacherPreparationProviderAssociation (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderAssociation ADD CONSTRAINT FK_0dff08_TeacherPreparationProvider FOREIGN KEY (TeacherPreparationProviderId)
REFERENCES tpdm.TeacherPreparationProvider (TeacherPreparationProviderId)
;

CREATE INDEX FK_0dff08_TeacherPreparationProvider
ON tpdm.TeacherCandidateTeacherPreparationProviderAssociation (TeacherPreparationProviderId ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation ADD CONSTRAINT FK_81475b_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_81475b_EducationOrganization
ON tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation (EducationOrganizationId ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation ADD CONSTRAINT FK_81475b_ReasonExitedDescriptor FOREIGN KEY (ReasonExitedDescriptorId)
REFERENCES edfi.ReasonExitedDescriptor (ReasonExitedDescriptorId)
;

CREATE INDEX FK_81475b_ReasonExitedDescriptor
ON tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation (ReasonExitedDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation ADD CONSTRAINT FK_81475b_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
;

CREATE INDEX FK_81475b_TeacherCandidate
ON tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation ADD CONSTRAINT FK_81475b_TeacherPreparationProviderProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.TeacherPreparationProviderProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_81475b_TeacherPreparationProviderProgram
ON tpdm.TeacherCandidateTeacherPreparationProviderProgramAssociation (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateTelephone ADD CONSTRAINT FK_1c8b27_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_1c8b27_TeacherCandidate
ON tpdm.TeacherCandidateTelephone (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateTelephone ADD CONSTRAINT FK_1c8b27_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_1c8b27_TelephoneNumberTypeDescriptor
ON tpdm.TeacherCandidateTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateTPPProgramDegree ADD CONSTRAINT FK_1b991e_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_1b991e_AcademicSubjectDescriptor
ON tpdm.TeacherCandidateTPPProgramDegree (AcademicSubjectDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateTPPProgramDegree ADD CONSTRAINT FK_1b991e_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_1b991e_GradeLevelDescriptor
ON tpdm.TeacherCandidateTPPProgramDegree (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateTPPProgramDegree ADD CONSTRAINT FK_1b991e_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_1b991e_TeacherCandidate
ON tpdm.TeacherCandidateTPPProgramDegree (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateTPPProgramDegree ADD CONSTRAINT FK_1b991e_TPPDegreeTypeDescriptor FOREIGN KEY (TPPDegreeTypeDescriptorId)
REFERENCES tpdm.TPPDegreeTypeDescriptor (TPPDegreeTypeDescriptorId)
;

CREATE INDEX FK_1b991e_TPPDegreeTypeDescriptor
ON tpdm.TeacherCandidateTPPProgramDegree (TPPDegreeTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherCandidateVisa ADD CONSTRAINT FK_d72a7b_TeacherCandidate FOREIGN KEY (TeacherCandidateIdentifier)
REFERENCES tpdm.TeacherCandidate (TeacherCandidateIdentifier)
ON DELETE CASCADE
;

CREATE INDEX FK_d72a7b_TeacherCandidate
ON tpdm.TeacherCandidateVisa (TeacherCandidateIdentifier ASC);

ALTER TABLE tpdm.TeacherCandidateVisa ADD CONSTRAINT FK_d72a7b_VisaDescriptor FOREIGN KEY (VisaDescriptorId)
REFERENCES edfi.VisaDescriptor (VisaDescriptorId)
;

CREATE INDEX FK_d72a7b_VisaDescriptor
ON tpdm.TeacherCandidateVisa (VisaDescriptorId ASC);

ALTER TABLE tpdm.TeacherPreparationProgramTypeDescriptor ADD CONSTRAINT FK_18e97d_Descriptor FOREIGN KEY (TeacherPreparationProgramTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.TeacherPreparationProvider ADD CONSTRAINT FK_ea8f5b_AccreditationStatusDescriptor FOREIGN KEY (AccreditationStatusDescriptorId)
REFERENCES tpdm.AccreditationStatusDescriptor (AccreditationStatusDescriptorId)
;

CREATE INDEX FK_ea8f5b_AccreditationStatusDescriptor
ON tpdm.TeacherPreparationProvider (AccreditationStatusDescriptorId ASC);

ALTER TABLE tpdm.TeacherPreparationProvider ADD CONSTRAINT FK_ea8f5b_EducationOrganization FOREIGN KEY (TeacherPreparationProviderId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.TeacherPreparationProvider ADD CONSTRAINT FK_ea8f5b_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_ea8f5b_FederalLocaleCodeDescriptor
ON tpdm.TeacherPreparationProvider (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.TeacherPreparationProvider ADD CONSTRAINT FK_ea8f5b_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_ea8f5b_School
ON tpdm.TeacherPreparationProvider (SchoolId ASC);

ALTER TABLE tpdm.TeacherPreparationProvider ADD CONSTRAINT FK_ea8f5b_University FOREIGN KEY (UniversityId)
REFERENCES tpdm.University (UniversityId)
;

CREATE INDEX FK_ea8f5b_University
ON tpdm.TeacherPreparationProvider (UniversityId ASC);

ALTER TABLE tpdm.TeacherPreparationProviderProgram ADD CONSTRAINT FK_aceeb9_EducationOrganization FOREIGN KEY (EducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
;

CREATE INDEX FK_aceeb9_EducationOrganization
ON tpdm.TeacherPreparationProviderProgram (EducationOrganizationId ASC);

ALTER TABLE tpdm.TeacherPreparationProviderProgram ADD CONSTRAINT FK_aceeb9_ProgramTypeDescriptor FOREIGN KEY (ProgramTypeDescriptorId)
REFERENCES edfi.ProgramTypeDescriptor (ProgramTypeDescriptorId)
;

CREATE INDEX FK_aceeb9_ProgramTypeDescriptor
ON tpdm.TeacherPreparationProviderProgram (ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherPreparationProviderProgram ADD CONSTRAINT FK_aceeb9_TeacherPreparationProgramTypeDescriptor FOREIGN KEY (TeacherPreparationProgramTypeDescriptorId)
REFERENCES tpdm.TeacherPreparationProgramTypeDescriptor (TeacherPreparationProgramTypeDescriptorId)
;

CREATE INDEX FK_aceeb9_TeacherPreparationProgramTypeDescriptor
ON tpdm.TeacherPreparationProviderProgram (TeacherPreparationProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.TeacherPreparationProviderProgram ADD CONSTRAINT FK_aceeb9_TPPProgramPathwayDescriptor FOREIGN KEY (TPPProgramPathwayDescriptorId)
REFERENCES tpdm.TPPProgramPathwayDescriptor (TPPProgramPathwayDescriptorId)
;

CREATE INDEX FK_aceeb9_TPPProgramPathwayDescriptor
ON tpdm.TeacherPreparationProviderProgram (TPPProgramPathwayDescriptorId ASC);

ALTER TABLE tpdm.TeacherPreparationProviderProgramGradeLevel ADD CONSTRAINT FK_f3e683_GradeLevelDescriptor FOREIGN KEY (GradeLevelDescriptorId)
REFERENCES edfi.GradeLevelDescriptor (GradeLevelDescriptorId)
;

CREATE INDEX FK_f3e683_GradeLevelDescriptor
ON tpdm.TeacherPreparationProviderProgramGradeLevel (GradeLevelDescriptorId ASC);

ALTER TABLE tpdm.TeacherPreparationProviderProgramGradeLevel ADD CONSTRAINT FK_f3e683_TeacherPreparationProviderProgram FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES tpdm.TeacherPreparationProviderProgram (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
ON DELETE CASCADE
;

CREATE INDEX FK_f3e683_TeacherPreparationProviderProgram
ON tpdm.TeacherPreparationProviderProgramGradeLevel (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE tpdm.TPPDegreeTypeDescriptor ADD CONSTRAINT FK_5d35e7_Descriptor FOREIGN KEY (TPPDegreeTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.TPPProgramPathwayDescriptor ADD CONSTRAINT FK_1807ea_Descriptor FOREIGN KEY (TPPProgramPathwayDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.University ADD CONSTRAINT FK_9d3844_EducationOrganization FOREIGN KEY (UniversityId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.University ADD CONSTRAINT FK_9d3844_FederalLocaleCodeDescriptor FOREIGN KEY (FederalLocaleCodeDescriptorId)
REFERENCES tpdm.FederalLocaleCodeDescriptor (FederalLocaleCodeDescriptorId)
;

CREATE INDEX FK_9d3844_FederalLocaleCodeDescriptor
ON tpdm.University (FederalLocaleCodeDescriptorId ASC);

ALTER TABLE tpdm.University ADD CONSTRAINT FK_9d3844_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_9d3844_School
ON tpdm.University (SchoolId ASC);

ALTER TABLE tpdm.ValueTypeDescriptor ADD CONSTRAINT FK_7111a6_Descriptor FOREIGN KEY (ValueTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE tpdm.WithdrawReasonDescriptor ADD CONSTRAINT FK_8936a1_Descriptor FOREIGN KEY (WithdrawReasonDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

