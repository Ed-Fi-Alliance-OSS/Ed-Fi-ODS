ALTER TABLE sample.ArtMediumDescriptor ADD CONSTRAINT FK_a8902f_Descriptor FOREIGN KEY (ArtMediumDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE sample.BusRoute ADD CONSTRAINT FK_65385a_DisabilityDescriptor FOREIGN KEY (DisabilityDescriptorId)
REFERENCES edfi.DisabilityDescriptor (DisabilityDescriptorId)
;

CREATE INDEX FK_65385a_DisabilityDescriptor
ON sample.BusRoute (DisabilityDescriptorId ASC);

ALTER TABLE sample.BusRoute ADD CONSTRAINT FK_65385a_StaffEducationOrganizationAssignmentAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationAssignmentAssociation (BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI)
;

CREATE INDEX FK_65385a_StaffEducationOrganizationAssignmentAssociation
ON sample.BusRoute (BeginDate ASC, EducationOrganizationId ASC, StaffClassificationDescriptorId ASC, StaffUSI ASC);

ALTER TABLE sample.BusRouteBusYear ADD CONSTRAINT FK_61b709_BusRoute FOREIGN KEY (BusId, BusRouteNumber)
REFERENCES sample.BusRoute (BusId, BusRouteNumber)
ON DELETE CASCADE
;

CREATE INDEX FK_61b709_BusRoute
ON sample.BusRouteBusYear (BusId ASC, BusRouteNumber ASC);

ALTER TABLE sample.BusRouteProgram ADD CONSTRAINT FK_bcf259_BusRoute FOREIGN KEY (BusId, BusRouteNumber)
REFERENCES sample.BusRoute (BusId, BusRouteNumber)
ON DELETE CASCADE
;

CREATE INDEX FK_bcf259_BusRoute
ON sample.BusRouteProgram (BusId ASC, BusRouteNumber ASC);

ALTER TABLE sample.BusRouteProgram ADD CONSTRAINT FK_bcf259_Program FOREIGN KEY (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
REFERENCES edfi.Program (EducationOrganizationId, ProgramName, ProgramTypeDescriptorId)
;

CREATE INDEX FK_bcf259_Program
ON sample.BusRouteProgram (EducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC);

ALTER TABLE sample.BusRouteServiceAreaPostalCode ADD CONSTRAINT FK_71fc1e_BusRoute FOREIGN KEY (BusId, BusRouteNumber)
REFERENCES sample.BusRoute (BusId, BusRouteNumber)
ON DELETE CASCADE
;

CREATE INDEX FK_71fc1e_BusRoute
ON sample.BusRouteServiceAreaPostalCode (BusId ASC, BusRouteNumber ASC);

ALTER TABLE sample.BusRouteStartTime ADD CONSTRAINT FK_7c158e_BusRoute FOREIGN KEY (BusId, BusRouteNumber)
REFERENCES sample.BusRoute (BusId, BusRouteNumber)
ON DELETE CASCADE
;

CREATE INDEX FK_7c158e_BusRoute
ON sample.BusRouteStartTime (BusId ASC, BusRouteNumber ASC);

ALTER TABLE sample.BusRouteTelephone ADD CONSTRAINT FK_d9d35b_BusRoute FOREIGN KEY (BusId, BusRouteNumber)
REFERENCES sample.BusRoute (BusId, BusRouteNumber)
ON DELETE CASCADE
;

CREATE INDEX FK_d9d35b_BusRoute
ON sample.BusRouteTelephone (BusId ASC, BusRouteNumber ASC);

ALTER TABLE sample.BusRouteTelephone ADD CONSTRAINT FK_d9d35b_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_d9d35b_TelephoneNumberTypeDescriptor
ON sample.BusRouteTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE sample.FavoriteBookCategoryDescriptor ADD CONSTRAINT FK_42666e_Descriptor FOREIGN KEY (FavoriteBookCategoryDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE sample.MembershipTypeDescriptor ADD CONSTRAINT FK_2cdcc2_Descriptor FOREIGN KEY (MembershipTypeDescriptorId)
REFERENCES edfi.Descriptor (DescriptorId)
ON DELETE CASCADE
;

ALTER TABLE sample.ParentAddressExtension ADD CONSTRAINT FK_6737b9_ParentAddress FOREIGN KEY (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.ParentAddress (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

ALTER TABLE sample.ParentAddressSchoolDistrict ADD CONSTRAINT FK_11ca24_ParentAddress FOREIGN KEY (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.ParentAddress (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

CREATE INDEX FK_11ca24_ParentAddress
ON sample.ParentAddressSchoolDistrict (AddressTypeDescriptorId ASC, City ASC, ParentUSI ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC);

ALTER TABLE sample.ParentAddressTerm ADD CONSTRAINT FK_f63230_ParentAddress FOREIGN KEY (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
REFERENCES edfi.ParentAddress (AddressTypeDescriptorId, City, ParentUSI, PostalCode, StateAbbreviationDescriptorId, StreetNumberName)
ON DELETE CASCADE
;

CREATE INDEX FK_f63230_ParentAddress
ON sample.ParentAddressTerm (AddressTypeDescriptorId ASC, City ASC, ParentUSI ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC);

ALTER TABLE sample.ParentAddressTerm ADD CONSTRAINT FK_f63230_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_f63230_TermDescriptor
ON sample.ParentAddressTerm (TermDescriptorId ASC);

ALTER TABLE sample.ParentAuthor ADD CONSTRAINT FK_1a4f1a_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_1a4f1a_Parent
ON sample.ParentAuthor (ParentUSI ASC);

ALTER TABLE sample.ParentCeilingHeight ADD CONSTRAINT FK_a2d993_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a2d993_Parent
ON sample.ParentCeilingHeight (ParentUSI ASC);

ALTER TABLE sample.ParentCTEProgram ADD CONSTRAINT FK_98fa6d_CareerPathwayDescriptor FOREIGN KEY (CareerPathwayDescriptorId)
REFERENCES edfi.CareerPathwayDescriptor (CareerPathwayDescriptorId)
;

CREATE INDEX FK_98fa6d_CareerPathwayDescriptor
ON sample.ParentCTEProgram (CareerPathwayDescriptorId ASC);

ALTER TABLE sample.ParentCTEProgram ADD CONSTRAINT FK_98fa6d_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.ParentEducationContent ADD CONSTRAINT FK_542a1f_EducationContent FOREIGN KEY (ContentIdentifier)
REFERENCES edfi.EducationContent (ContentIdentifier)
;

CREATE INDEX FK_542a1f_EducationContent
ON sample.ParentEducationContent (ContentIdentifier ASC);

ALTER TABLE sample.ParentEducationContent ADD CONSTRAINT FK_542a1f_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_542a1f_Parent
ON sample.ParentEducationContent (ParentUSI ASC);

ALTER TABLE sample.ParentExtension ADD CONSTRAINT FK_32099d_CredentialFieldDescriptor FOREIGN KEY (CredentialFieldDescriptorId)
REFERENCES edfi.CredentialFieldDescriptor (CredentialFieldDescriptorId)
;

CREATE INDEX FK_32099d_CredentialFieldDescriptor
ON sample.ParentExtension (CredentialFieldDescriptorId ASC);

ALTER TABLE sample.ParentExtension ADD CONSTRAINT FK_32099d_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.ParentFavoriteBookTitle ADD CONSTRAINT FK_4157e1_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_4157e1_Parent
ON sample.ParentFavoriteBookTitle (ParentUSI ASC);

ALTER TABLE sample.ParentStudentProgramAssociation ADD CONSTRAINT FK_7e8704_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_7e8704_Parent
ON sample.ParentStudentProgramAssociation (ParentUSI ASC);

ALTER TABLE sample.ParentStudentProgramAssociation ADD CONSTRAINT FK_7e8704_StudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
;

CREATE INDEX FK_7e8704_StudentProgramAssociation
ON sample.ParentStudentProgramAssociation (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE sample.ParentTeacherConference ADD CONSTRAINT FK_bdba2a_Parent FOREIGN KEY (ParentUSI)
REFERENCES edfi.Parent (ParentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.SchoolCTEProgram ADD CONSTRAINT FK_7ba98a_CareerPathwayDescriptor FOREIGN KEY (CareerPathwayDescriptorId)
REFERENCES edfi.CareerPathwayDescriptor (CareerPathwayDescriptorId)
;

CREATE INDEX FK_7ba98a_CareerPathwayDescriptor
ON sample.SchoolCTEProgram (CareerPathwayDescriptorId ASC);

ALTER TABLE sample.SchoolCTEProgram ADD CONSTRAINT FK_7ba98a_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

ALTER TABLE sample.SchoolDirectlyOwnedBus ADD CONSTRAINT FK_4edefb_Bus FOREIGN KEY (DirectlyOwnedBusId)
REFERENCES sample.Bus (BusId)
;

CREATE INDEX FK_4edefb_Bus
ON sample.SchoolDirectlyOwnedBus (DirectlyOwnedBusId ASC);

ALTER TABLE sample.SchoolDirectlyOwnedBus ADD CONSTRAINT FK_4edefb_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

CREATE INDEX FK_4edefb_School
ON sample.SchoolDirectlyOwnedBus (SchoolId ASC);

ALTER TABLE sample.SchoolExtension ADD CONSTRAINT FK_2199be_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
ON DELETE CASCADE
;

ALTER TABLE sample.StaffExtension ADD CONSTRAINT FK_d7b81a_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StaffPet ADD CONSTRAINT FK_e40bbd_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_e40bbd_Staff
ON sample.StaffPet (StaffUSI ASC);

ALTER TABLE sample.StaffPetPreference ADD CONSTRAINT FK_c50bc3_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StudentAquaticPet ADD CONSTRAINT FK_094617_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_094617_Student
ON sample.StudentAquaticPet (StudentUSI ASC);

ALTER TABLE sample.StudentArtProgramAssociation ADD CONSTRAINT FK_c468eb_GeneralStudentProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StudentArtProgramAssociationArtMedium ADD CONSTRAINT FK_f6ca63_ArtMediumDescriptor FOREIGN KEY (ArtMediumDescriptorId)
REFERENCES sample.ArtMediumDescriptor (ArtMediumDescriptorId)
;

CREATE INDEX FK_f6ca63_ArtMediumDescriptor
ON sample.StudentArtProgramAssociationArtMedium (ArtMediumDescriptorId ASC);

ALTER TABLE sample.StudentArtProgramAssociationArtMedium ADD CONSTRAINT FK_f6ca63_StudentArtProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES sample.StudentArtProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_f6ca63_StudentArtProgramAssociation
ON sample.StudentArtProgramAssociationArtMedium (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE sample.StudentArtProgramAssociationPortfolioYears ADD CONSTRAINT FK_cb082b_StudentArtProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES sample.StudentArtProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_cb082b_StudentArtProgramAssociation
ON sample.StudentArtProgramAssociationPortfolioYears (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE sample.StudentArtProgramAssociationService ADD CONSTRAINT FK_8141ae_ServiceDescriptor FOREIGN KEY (ServiceDescriptorId)
REFERENCES edfi.ServiceDescriptor (ServiceDescriptorId)
;

CREATE INDEX FK_8141ae_ServiceDescriptor
ON sample.StudentArtProgramAssociationService (ServiceDescriptorId ASC);

ALTER TABLE sample.StudentArtProgramAssociationService ADD CONSTRAINT FK_8141ae_StudentArtProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES sample.StudentArtProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_8141ae_StudentArtProgramAssociation
ON sample.StudentArtProgramAssociationService (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE sample.StudentArtProgramAssociationStyle ADD CONSTRAINT FK_258568_StudentArtProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES sample.StudentArtProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_258568_StudentArtProgramAssociation
ON sample.StudentArtProgramAssociationStyle (BeginDate ASC, EducationOrganizationId ASC, ProgramEducationOrganizationId ASC, ProgramName ASC, ProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE sample.StudentCTEProgramAssociationExtension ADD CONSTRAINT FK_1020a1_StudentCTEProgramAssociation FOREIGN KEY (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.StudentCTEProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StudentEducationOrganizationAssociationAddressExtension ADD CONSTRAINT FK_c905b3_StudentEducationOrganizationAssociationAddress FOREIGN KEY (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationAddress (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StudentEducationOrganizationAssociationAddressSchoolDistrict ADD CONSTRAINT FK_450d64_StudentEducationOrganizationAssociationAddress FOREIGN KEY (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationAddress (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_450d64_StudentEducationOrganizationAssociationAddress
ON sample.StudentEducationOrganizationAssociationAddressSchoolDistrict (AddressTypeDescriptorId ASC, City ASC, EducationOrganizationId ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC, StudentUSI ASC);

ALTER TABLE sample.StudentEducationOrganizationAssociationAddressTerm ADD CONSTRAINT FK_98438b_StudentEducationOrganizationAssociationAddress FOREIGN KEY (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationAddress (AddressTypeDescriptorId, City, EducationOrganizationId, PostalCode, StateAbbreviationDescriptorId, StreetNumberName, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_98438b_StudentEducationOrganizationAssociationAddress
ON sample.StudentEducationOrganizationAssociationAddressTerm (AddressTypeDescriptorId ASC, City ASC, EducationOrganizationId ASC, PostalCode ASC, StateAbbreviationDescriptorId ASC, StreetNumberName ASC, StudentUSI ASC);

ALTER TABLE sample.StudentEducationOrganizationAssociationAddressTerm ADD CONSTRAINT FK_98438b_TermDescriptor FOREIGN KEY (TermDescriptorId)
REFERENCES edfi.TermDescriptor (TermDescriptorId)
;

CREATE INDEX FK_98438b_TermDescriptor
ON sample.StudentEducationOrganizationAssociationAddressTerm (TermDescriptorId ASC);

ALTER TABLE sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152 ADD CONSTRAINT FK_17d152_StudentEducationOrganizationAssociationStudentCharacteristic FOREIGN KEY (EducationOrganizationId, StudentCharacteristicDescriptorId, StudentUSI)
REFERENCES edfi.StudentEducationOrganizationAssociationStudentCharacteristic (EducationOrganizationId, StudentCharacteristicDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_17d152_StudentEducationOrganizationAssociationStudentCharacteristic
ON sample.StudentEducationOrganizationAssociationStudentCharacteri_17d152 (EducationOrganizationId ASC, StudentCharacteristicDescriptorId ASC, StudentUSI ASC);

ALTER TABLE sample.StudentFavoriteBook ADD CONSTRAINT FK_172e5d_FavoriteBookCategoryDescriptor FOREIGN KEY (FavoriteBookCategoryDescriptorId)
REFERENCES sample.FavoriteBookCategoryDescriptor (FavoriteBookCategoryDescriptorId)
;

CREATE INDEX FK_172e5d_FavoriteBookCategoryDescriptor
ON sample.StudentFavoriteBook (FavoriteBookCategoryDescriptorId ASC);

ALTER TABLE sample.StudentFavoriteBook ADD CONSTRAINT FK_172e5d_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_172e5d_Student
ON sample.StudentFavoriteBook (StudentUSI ASC);

ALTER TABLE sample.StudentFavoriteBookArtMedium ADD CONSTRAINT FK_458888_ArtMediumDescriptor FOREIGN KEY (ArtMediumDescriptorId)
REFERENCES sample.ArtMediumDescriptor (ArtMediumDescriptorId)
;

CREATE INDEX FK_458888_ArtMediumDescriptor
ON sample.StudentFavoriteBookArtMedium (ArtMediumDescriptorId ASC);

ALTER TABLE sample.StudentFavoriteBookArtMedium ADD CONSTRAINT FK_458888_StudentFavoriteBook FOREIGN KEY (FavoriteBookCategoryDescriptorId, StudentUSI)
REFERENCES sample.StudentFavoriteBook (FavoriteBookCategoryDescriptorId, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_458888_StudentFavoriteBook
ON sample.StudentFavoriteBookArtMedium (FavoriteBookCategoryDescriptorId ASC, StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociation ADD CONSTRAINT FK_5fe843_GraduationPlan FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
REFERENCES edfi.GraduationPlan (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear)
;

CREATE INDEX FK_5fe843_GraduationPlan
ON sample.StudentGraduationPlanAssociation (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC);

ALTER TABLE sample.StudentGraduationPlanAssociation ADD CONSTRAINT FK_5fe843_Staff FOREIGN KEY (StaffUSI)
REFERENCES edfi.Staff (StaffUSI)
;

CREATE INDEX FK_5fe843_Staff
ON sample.StudentGraduationPlanAssociation (StaffUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociation ADD CONSTRAINT FK_5fe843_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_5fe843_Student
ON sample.StudentGraduationPlanAssociation (StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationAcademicSubject ADD CONSTRAINT FK_7ec6d6_AcademicSubjectDescriptor FOREIGN KEY (AcademicSubjectDescriptorId)
REFERENCES edfi.AcademicSubjectDescriptor (AcademicSubjectDescriptorId)
;

CREATE INDEX FK_7ec6d6_AcademicSubjectDescriptor
ON sample.StudentGraduationPlanAssociationAcademicSubject (AcademicSubjectDescriptorId ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationAcademicSubject ADD CONSTRAINT FK_7ec6d6_StudentGraduationPlanAssociation FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
REFERENCES sample.StudentGraduationPlanAssociation (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_7ec6d6_StudentGraduationPlanAssociation
ON sample.StudentGraduationPlanAssociationAcademicSubject (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC, StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationCareerPathwayCode ADD CONSTRAINT FK_be4497_StudentGraduationPlanAssociation FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
REFERENCES sample.StudentGraduationPlanAssociation (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_be4497_StudentGraduationPlanAssociation
ON sample.StudentGraduationPlanAssociationCareerPathwayCode (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC, StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationCTEProgram ADD CONSTRAINT FK_4d6493_CareerPathwayDescriptor FOREIGN KEY (CareerPathwayDescriptorId)
REFERENCES edfi.CareerPathwayDescriptor (CareerPathwayDescriptorId)
;

CREATE INDEX FK_4d6493_CareerPathwayDescriptor
ON sample.StudentGraduationPlanAssociationCTEProgram (CareerPathwayDescriptorId ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationCTEProgram ADD CONSTRAINT FK_4d6493_StudentGraduationPlanAssociation FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
REFERENCES sample.StudentGraduationPlanAssociation (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StudentGraduationPlanAssociationDescription ADD CONSTRAINT FK_bd1aca_StudentGraduationPlanAssociation FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
REFERENCES sample.StudentGraduationPlanAssociation (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_bd1aca_StudentGraduationPlanAssociation
ON sample.StudentGraduationPlanAssociationDescription (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC, StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationDesignatedBy ADD CONSTRAINT FK_a608d1_StudentGraduationPlanAssociation FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
REFERENCES sample.StudentGraduationPlanAssociation (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_a608d1_StudentGraduationPlanAssociation
ON sample.StudentGraduationPlanAssociationDesignatedBy (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC, StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationIndustryCredential ADD CONSTRAINT FK_40e7ea_StudentGraduationPlanAssociation FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
REFERENCES sample.StudentGraduationPlanAssociation (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_40e7ea_StudentGraduationPlanAssociation
ON sample.StudentGraduationPlanAssociationIndustryCredential (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC, StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationStudentParentAssociation ADD CONSTRAINT FK_b25b8d_StudentGraduationPlanAssociation FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
REFERENCES sample.StudentGraduationPlanAssociation (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_b25b8d_StudentGraduationPlanAssociation
ON sample.StudentGraduationPlanAssociationStudentParentAssociation (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC, StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationStudentParentAssociation ADD CONSTRAINT FK_b25b8d_StudentParentAssociation FOREIGN KEY (ParentUSI, StudentUSI)
REFERENCES edfi.StudentParentAssociation (ParentUSI, StudentUSI)
;

CREATE INDEX FK_b25b8d_StudentParentAssociation
ON sample.StudentGraduationPlanAssociationStudentParentAssociation (ParentUSI ASC, StudentUSI ASC);

ALTER TABLE sample.StudentGraduationPlanAssociationYearsAttended ADD CONSTRAINT FK_0cf4e1_StudentGraduationPlanAssociation FOREIGN KEY (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
REFERENCES sample.StudentGraduationPlanAssociation (EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_0cf4e1_StudentGraduationPlanAssociation
ON sample.StudentGraduationPlanAssociationYearsAttended (EducationOrganizationId ASC, GraduationPlanTypeDescriptorId ASC, GraduationSchoolYear ASC, StudentUSI ASC);

ALTER TABLE sample.StudentParentAssociationDiscipline ADD CONSTRAINT FK_99264f_DisciplineDescriptor FOREIGN KEY (DisciplineDescriptorId)
REFERENCES edfi.DisciplineDescriptor (DisciplineDescriptorId)
;

CREATE INDEX FK_99264f_DisciplineDescriptor
ON sample.StudentParentAssociationDiscipline (DisciplineDescriptorId ASC);

ALTER TABLE sample.StudentParentAssociationDiscipline ADD CONSTRAINT FK_99264f_StudentParentAssociation FOREIGN KEY (ParentUSI, StudentUSI)
REFERENCES edfi.StudentParentAssociation (ParentUSI, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_99264f_StudentParentAssociation
ON sample.StudentParentAssociationDiscipline (ParentUSI ASC, StudentUSI ASC);

ALTER TABLE sample.StudentParentAssociationExtension ADD CONSTRAINT FK_676aa0_InterventionStudy FOREIGN KEY (EducationOrganizationId, InterventionStudyIdentificationCode)
REFERENCES edfi.InterventionStudy (EducationOrganizationId, InterventionStudyIdentificationCode)
;

CREATE INDEX FK_676aa0_InterventionStudy
ON sample.StudentParentAssociationExtension (EducationOrganizationId ASC, InterventionStudyIdentificationCode ASC);

ALTER TABLE sample.StudentParentAssociationExtension ADD CONSTRAINT FK_676aa0_StudentParentAssociation FOREIGN KEY (ParentUSI, StudentUSI)
REFERENCES edfi.StudentParentAssociation (ParentUSI, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StudentParentAssociationFavoriteBookTitle ADD CONSTRAINT FK_ff02b3_StudentParentAssociation FOREIGN KEY (ParentUSI, StudentUSI)
REFERENCES edfi.StudentParentAssociation (ParentUSI, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_ff02b3_StudentParentAssociation
ON sample.StudentParentAssociationFavoriteBookTitle (ParentUSI ASC, StudentUSI ASC);

ALTER TABLE sample.StudentParentAssociationHoursPerWeek ADD CONSTRAINT FK_fd1358_StudentParentAssociation FOREIGN KEY (ParentUSI, StudentUSI)
REFERENCES edfi.StudentParentAssociation (ParentUSI, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_fd1358_StudentParentAssociation
ON sample.StudentParentAssociationHoursPerWeek (ParentUSI ASC, StudentUSI ASC);

ALTER TABLE sample.StudentParentAssociationPagesRead ADD CONSTRAINT FK_9f4924_StudentParentAssociation FOREIGN KEY (ParentUSI, StudentUSI)
REFERENCES edfi.StudentParentAssociation (ParentUSI, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_9f4924_StudentParentAssociation
ON sample.StudentParentAssociationPagesRead (ParentUSI ASC, StudentUSI ASC);

ALTER TABLE sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c ADD CONSTRAINT FK_c4af0c_StaffEducationOrganizationEmploymentAssociation FOREIGN KEY (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
REFERENCES edfi.StaffEducationOrganizationEmploymentAssociation (EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI)
;

CREATE INDEX FK_c4af0c_StaffEducationOrganizationEmploymentAssociation
ON sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c (EducationOrganizationId ASC, EmploymentStatusDescriptorId ASC, HireDate ASC, StaffUSI ASC);

ALTER TABLE sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c ADD CONSTRAINT FK_c4af0c_StudentParentAssociation FOREIGN KEY (ParentUSI, StudentUSI)
REFERENCES edfi.StudentParentAssociation (ParentUSI, StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_c4af0c_StudentParentAssociation
ON sample.StudentParentAssociationStaffEducationOrganizationEmploy_c4af0c (ParentUSI ASC, StudentUSI ASC);

ALTER TABLE sample.StudentParentAssociationTelephone ADD CONSTRAINT FK_dbd162_StudentParentAssociation FOREIGN KEY (ParentUSI, StudentUSI)
REFERENCES edfi.StudentParentAssociation (ParentUSI, StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StudentParentAssociationTelephone ADD CONSTRAINT FK_dbd162_TelephoneNumberTypeDescriptor FOREIGN KEY (TelephoneNumberTypeDescriptorId)
REFERENCES edfi.TelephoneNumberTypeDescriptor (TelephoneNumberTypeDescriptorId)
;

CREATE INDEX FK_dbd162_TelephoneNumberTypeDescriptor
ON sample.StudentParentAssociationTelephone (TelephoneNumberTypeDescriptorId ASC);

ALTER TABLE sample.StudentPet ADD CONSTRAINT FK_21f4e6_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

CREATE INDEX FK_21f4e6_Student
ON sample.StudentPet (StudentUSI ASC);

ALTER TABLE sample.StudentPetPreference ADD CONSTRAINT FK_cf8624_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
ON DELETE CASCADE
;

ALTER TABLE sample.StudentSchoolAssociationExtension ADD CONSTRAINT FK_880cb1_MembershipTypeDescriptor FOREIGN KEY (MembershipTypeDescriptorId)
REFERENCES sample.MembershipTypeDescriptor (MembershipTypeDescriptorId)
;

CREATE INDEX FK_880cb1_MembershipTypeDescriptor
ON sample.StudentSchoolAssociationExtension (MembershipTypeDescriptorId ASC);

ALTER TABLE sample.StudentSchoolAssociationExtension ADD CONSTRAINT FK_880cb1_StudentSchoolAssociation FOREIGN KEY (EntryDate, SchoolId, StudentUSI)
REFERENCES edfi.StudentSchoolAssociation (EntryDate, SchoolId, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 ADD CONSTRAINT FK_c72e02_GeneralStudentProgramAssociation FOREIGN KEY (RelatedBeginDate, RelatedEducationOrganizationId, RelatedProgramEducationOrganizationId, RelatedProgramName, RelatedProgramTypeDescriptorId, StudentUSI)
REFERENCES edfi.GeneralStudentProgramAssociation (BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI)
;

CREATE INDEX FK_c72e02_GeneralStudentProgramAssociation
ON sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 (RelatedBeginDate ASC, RelatedEducationOrganizationId ASC, RelatedProgramEducationOrganizationId ASC, RelatedProgramName ASC, RelatedProgramTypeDescriptorId ASC, StudentUSI ASC);

ALTER TABLE sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 ADD CONSTRAINT FK_c72e02_StudentSectionAssociation FOREIGN KEY (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
REFERENCES edfi.StudentSectionAssociation (BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI)
ON DELETE CASCADE
ON UPDATE CASCADE
;

CREATE INDEX FK_c72e02_StudentSectionAssociation
ON sample.StudentSectionAssociationRelatedGeneralStudentProgramAss_c72e02 (BeginDate ASC, LocalCourseCode ASC, SchoolId ASC, SchoolYear ASC, SectionIdentifier ASC, SessionName ASC, StudentUSI ASC);

