-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [sample].[ArtMediumDescriptor] WITH CHECK ADD CONSTRAINT [FK_ArtMediumDescriptor_Descriptor] FOREIGN KEY ([ArtMediumDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[BusRoute] WITH CHECK ADD CONSTRAINT [FK_BusRoute_DisabilityDescriptor] FOREIGN KEY ([DisabilityDescriptorId])
REFERENCES [edfi].[DisabilityDescriptor] ([DisabilityDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_BusRoute_DisabilityDescriptor]
ON [sample].[BusRoute] ([DisabilityDescriptorId] ASC)
GO

ALTER TABLE [sample].[BusRoute] WITH CHECK ADD CONSTRAINT [FK_BusRoute_StaffEducationOrganizationAssignmentAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [StaffClassificationDescriptorId], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationAssignmentAssociation] ([BeginDate], [EducationOrganizationId], [StaffClassificationDescriptorId], [StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_BusRoute_StaffEducationOrganizationAssignmentAssociation]
ON [sample].[BusRoute] ([BeginDate] ASC, [EducationOrganizationId] ASC, [StaffClassificationDescriptorId] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [sample].[BusRouteBusYear] WITH CHECK ADD CONSTRAINT [FK_BusRouteBusYear_BusRoute] FOREIGN KEY ([BusId], [BusRouteNumber])
REFERENCES [sample].[BusRoute] ([BusId], [BusRouteNumber])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_BusRouteBusYear_BusRoute]
ON [sample].[BusRouteBusYear] ([BusId] ASC, [BusRouteNumber] ASC)
GO

ALTER TABLE [sample].[BusRouteProgram] WITH CHECK ADD CONSTRAINT [FK_BusRouteProgram_BusRoute] FOREIGN KEY ([BusId], [BusRouteNumber])
REFERENCES [sample].[BusRoute] ([BusId], [BusRouteNumber])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_BusRouteProgram_BusRoute]
ON [sample].[BusRouteProgram] ([BusId] ASC, [BusRouteNumber] ASC)
GO

ALTER TABLE [sample].[BusRouteProgram] WITH CHECK ADD CONSTRAINT [FK_BusRouteProgram_Program] FOREIGN KEY ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
REFERENCES [edfi].[Program] ([EducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_BusRouteProgram_Program]
ON [sample].[BusRouteProgram] ([EducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC)
GO

ALTER TABLE [sample].[BusRouteServiceAreaPostalCode] WITH CHECK ADD CONSTRAINT [FK_BusRouteServiceAreaPostalCode_BusRoute] FOREIGN KEY ([BusId], [BusRouteNumber])
REFERENCES [sample].[BusRoute] ([BusId], [BusRouteNumber])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_BusRouteServiceAreaPostalCode_BusRoute]
ON [sample].[BusRouteServiceAreaPostalCode] ([BusId] ASC, [BusRouteNumber] ASC)
GO

ALTER TABLE [sample].[BusRouteStartTime] WITH CHECK ADD CONSTRAINT [FK_BusRouteStartTime_BusRoute] FOREIGN KEY ([BusId], [BusRouteNumber])
REFERENCES [sample].[BusRoute] ([BusId], [BusRouteNumber])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_BusRouteStartTime_BusRoute]
ON [sample].[BusRouteStartTime] ([BusId] ASC, [BusRouteNumber] ASC)
GO

ALTER TABLE [sample].[BusRouteTelephone] WITH CHECK ADD CONSTRAINT [FK_BusRouteTelephone_BusRoute] FOREIGN KEY ([BusId], [BusRouteNumber])
REFERENCES [sample].[BusRoute] ([BusId], [BusRouteNumber])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_BusRouteTelephone_BusRoute]
ON [sample].[BusRouteTelephone] ([BusId] ASC, [BusRouteNumber] ASC)
GO

ALTER TABLE [sample].[BusRouteTelephone] WITH CHECK ADD CONSTRAINT [FK_BusRouteTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_BusRouteTelephone_TelephoneNumberTypeDescriptor]
ON [sample].[BusRouteTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [sample].[FavoriteBookCategoryDescriptor] WITH CHECK ADD CONSTRAINT [FK_FavoriteBookCategoryDescriptor_Descriptor] FOREIGN KEY ([FavoriteBookCategoryDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[MembershipTypeDescriptor] WITH CHECK ADD CONSTRAINT [FK_MembershipTypeDescriptor_Descriptor] FOREIGN KEY ([MembershipTypeDescriptorId])
REFERENCES [edfi].[Descriptor] ([DescriptorId])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[ParentAddressExtension] WITH CHECK ADD CONSTRAINT [FK_ParentAddressExtension_ParentAddress] FOREIGN KEY ([AddressTypeDescriptorId], [City], [ParentUSI], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[ParentAddress] ([AddressTypeDescriptorId], [City], [ParentUSI], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[ParentAddressSchoolDistrict] WITH CHECK ADD CONSTRAINT [FK_ParentAddressSchoolDistrict_ParentAddress] FOREIGN KEY ([AddressTypeDescriptorId], [City], [ParentUSI], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[ParentAddress] ([AddressTypeDescriptorId], [City], [ParentUSI], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentAddressSchoolDistrict_ParentAddress]
ON [sample].[ParentAddressSchoolDistrict] ([AddressTypeDescriptorId] ASC, [City] ASC, [ParentUSI] ASC, [PostalCode] ASC, [StateAbbreviationDescriptorId] ASC, [StreetNumberName] ASC)
GO

ALTER TABLE [sample].[ParentAddressTerm] WITH CHECK ADD CONSTRAINT [FK_ParentAddressTerm_ParentAddress] FOREIGN KEY ([AddressTypeDescriptorId], [City], [ParentUSI], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
REFERENCES [edfi].[ParentAddress] ([AddressTypeDescriptorId], [City], [ParentUSI], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentAddressTerm_ParentAddress]
ON [sample].[ParentAddressTerm] ([AddressTypeDescriptorId] ASC, [City] ASC, [ParentUSI] ASC, [PostalCode] ASC, [StateAbbreviationDescriptorId] ASC, [StreetNumberName] ASC)
GO

ALTER TABLE [sample].[ParentAddressTerm] WITH CHECK ADD CONSTRAINT [FK_ParentAddressTerm_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ParentAddressTerm_TermDescriptor]
ON [sample].[ParentAddressTerm] ([TermDescriptorId] ASC)
GO

ALTER TABLE [sample].[ParentAuthor] WITH CHECK ADD CONSTRAINT [FK_ParentAuthor_Parent] FOREIGN KEY ([ParentUSI])
REFERENCES [edfi].[Parent] ([ParentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentAuthor_Parent]
ON [sample].[ParentAuthor] ([ParentUSI] ASC)
GO

ALTER TABLE [sample].[ParentCeilingHeight] WITH CHECK ADD CONSTRAINT [FK_ParentCeilingHeight_Parent] FOREIGN KEY ([ParentUSI])
REFERENCES [edfi].[Parent] ([ParentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentCeilingHeight_Parent]
ON [sample].[ParentCeilingHeight] ([ParentUSI] ASC)
GO

ALTER TABLE [sample].[ParentCTEProgram] WITH CHECK ADD CONSTRAINT [FK_ParentCTEProgram_CareerPathwayDescriptor] FOREIGN KEY ([CareerPathwayDescriptorId])
REFERENCES [edfi].[CareerPathwayDescriptor] ([CareerPathwayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ParentCTEProgram_CareerPathwayDescriptor]
ON [sample].[ParentCTEProgram] ([CareerPathwayDescriptorId] ASC)
GO

ALTER TABLE [sample].[ParentCTEProgram] WITH CHECK ADD CONSTRAINT [FK_ParentCTEProgram_Parent] FOREIGN KEY ([ParentUSI])
REFERENCES [edfi].[Parent] ([ParentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[ParentEducationContent] WITH CHECK ADD CONSTRAINT [FK_ParentEducationContent_EducationContent] FOREIGN KEY ([ContentIdentifier])
REFERENCES [edfi].[EducationContent] ([ContentIdentifier])
GO

CREATE NONCLUSTERED INDEX [FK_ParentEducationContent_EducationContent]
ON [sample].[ParentEducationContent] ([ContentIdentifier] ASC)
GO

ALTER TABLE [sample].[ParentEducationContent] WITH CHECK ADD CONSTRAINT [FK_ParentEducationContent_Parent] FOREIGN KEY ([ParentUSI])
REFERENCES [edfi].[Parent] ([ParentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentEducationContent_Parent]
ON [sample].[ParentEducationContent] ([ParentUSI] ASC)
GO

ALTER TABLE [sample].[ParentExtension] WITH CHECK ADD CONSTRAINT [FK_ParentExtension_CredentialFieldDescriptor] FOREIGN KEY ([CredentialFieldDescriptorId])
REFERENCES [edfi].[CredentialFieldDescriptor] ([CredentialFieldDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_ParentExtension_CredentialFieldDescriptor]
ON [sample].[ParentExtension] ([CredentialFieldDescriptorId] ASC)
GO

ALTER TABLE [sample].[ParentExtension] WITH CHECK ADD CONSTRAINT [FK_ParentExtension_Parent] FOREIGN KEY ([ParentUSI])
REFERENCES [edfi].[Parent] ([ParentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[ParentFavoriteBookTitle] WITH CHECK ADD CONSTRAINT [FK_ParentFavoriteBookTitle_Parent] FOREIGN KEY ([ParentUSI])
REFERENCES [edfi].[Parent] ([ParentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentFavoriteBookTitle_Parent]
ON [sample].[ParentFavoriteBookTitle] ([ParentUSI] ASC)
GO

ALTER TABLE [sample].[ParentStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_ParentStudentProgramAssociation_Parent] FOREIGN KEY ([ParentUSI])
REFERENCES [edfi].[Parent] ([ParentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentStudentProgramAssociation_Parent]
ON [sample].[ParentStudentProgramAssociation] ([ParentUSI] ASC)
GO

ALTER TABLE [sample].[ParentStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_ParentStudentProgramAssociation_StudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_ParentStudentProgramAssociation_StudentProgramAssociation]
ON [sample].[ParentStudentProgramAssociation] ([BeginDate] ASC, [EducationOrganizationId] ASC, [ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[ParentTeacherConference] WITH CHECK ADD CONSTRAINT [FK_ParentTeacherConference_Parent] FOREIGN KEY ([ParentUSI])
REFERENCES [edfi].[Parent] ([ParentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[SchoolCTEProgram] WITH CHECK ADD CONSTRAINT [FK_SchoolCTEProgram_CareerPathwayDescriptor] FOREIGN KEY ([CareerPathwayDescriptorId])
REFERENCES [edfi].[CareerPathwayDescriptor] ([CareerPathwayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolCTEProgram_CareerPathwayDescriptor]
ON [sample].[SchoolCTEProgram] ([CareerPathwayDescriptorId] ASC)
GO

ALTER TABLE [sample].[SchoolCTEProgram] WITH CHECK ADD CONSTRAINT [FK_SchoolCTEProgram_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[SchoolDirectlyOwnedBus] WITH CHECK ADD CONSTRAINT [FK_SchoolDirectlyOwnedBus_Bus] FOREIGN KEY ([DirectlyOwnedBusId])
REFERENCES [sample].[Bus] ([BusId])
GO

CREATE NONCLUSTERED INDEX [FK_SchoolDirectlyOwnedBus_Bus]
ON [sample].[SchoolDirectlyOwnedBus] ([DirectlyOwnedBusId] ASC)
GO

ALTER TABLE [sample].[SchoolDirectlyOwnedBus] WITH CHECK ADD CONSTRAINT [FK_SchoolDirectlyOwnedBus_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_SchoolDirectlyOwnedBus_School]
ON [sample].[SchoolDirectlyOwnedBus] ([SchoolId] ASC)
GO

ALTER TABLE [sample].[SchoolExtension] WITH CHECK ADD CONSTRAINT [FK_SchoolExtension_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StaffExtension] WITH CHECK ADD CONSTRAINT [FK_StaffExtension_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StaffPet] WITH CHECK ADD CONSTRAINT [FK_StaffPet_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffPet_Staff]
ON [sample].[StaffPet] ([StaffUSI] ASC)
GO

ALTER TABLE [sample].[StaffPetPreference] WITH CHECK ADD CONSTRAINT [FK_StaffPetPreference_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StudentAquaticPet] WITH CHECK ADD CONSTRAINT [FK_StudentAquaticPet_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentAquaticPet_Student]
ON [sample].[StudentAquaticPet] ([StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentArtProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentArtProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StudentArtProgramAssociationArtMedium] WITH CHECK ADD CONSTRAINT [FK_StudentArtProgramAssociationArtMedium_ArtMediumDescriptor] FOREIGN KEY ([ArtMediumDescriptorId])
REFERENCES [sample].[ArtMediumDescriptor] ([ArtMediumDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentArtProgramAssociationArtMedium_ArtMediumDescriptor]
ON [sample].[StudentArtProgramAssociationArtMedium] ([ArtMediumDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentArtProgramAssociationArtMedium] WITH CHECK ADD CONSTRAINT [FK_StudentArtProgramAssociationArtMedium_StudentArtProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [sample].[StudentArtProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentArtProgramAssociationArtMedium_StudentArtProgramAssociation]
ON [sample].[StudentArtProgramAssociationArtMedium] ([BeginDate] ASC, [EducationOrganizationId] ASC, [ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentArtProgramAssociationPortfolioYears] WITH CHECK ADD CONSTRAINT [FK_StudentArtProgramAssociationPortfolioYears_StudentArtProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [sample].[StudentArtProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentArtProgramAssociationPortfolioYears_StudentArtProgramAssociation]
ON [sample].[StudentArtProgramAssociationPortfolioYears] ([BeginDate] ASC, [EducationOrganizationId] ASC, [ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentArtProgramAssociationService] WITH CHECK ADD CONSTRAINT [FK_StudentArtProgramAssociationService_ServiceDescriptor] FOREIGN KEY ([ServiceDescriptorId])
REFERENCES [edfi].[ServiceDescriptor] ([ServiceDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentArtProgramAssociationService_ServiceDescriptor]
ON [sample].[StudentArtProgramAssociationService] ([ServiceDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentArtProgramAssociationService] WITH CHECK ADD CONSTRAINT [FK_StudentArtProgramAssociationService_StudentArtProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [sample].[StudentArtProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentArtProgramAssociationService_StudentArtProgramAssociation]
ON [sample].[StudentArtProgramAssociationService] ([BeginDate] ASC, [EducationOrganizationId] ASC, [ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentArtProgramAssociationStyle] WITH CHECK ADD CONSTRAINT [FK_StudentArtProgramAssociationStyle_StudentArtProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [sample].[StudentArtProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentArtProgramAssociationStyle_StudentArtProgramAssociation]
ON [sample].[StudentArtProgramAssociationStyle] ([BeginDate] ASC, [EducationOrganizationId] ASC, [ProgramEducationOrganizationId] ASC, [ProgramName] ASC, [ProgramTypeDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentCTEProgramAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StudentCTEProgramAssociationExtension_StudentCTEProgramAssociation] FOREIGN KEY ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentCTEProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StudentEducationOrganizationAssociationAddressExtension] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddressExtension_StudentEducationOrganizationAssociationAddress] FOREIGN KEY ([AddressTypeDescriptorId], [City], [EducationOrganizationId], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociationAddress] ([AddressTypeDescriptorId], [City], [EducationOrganizationId], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StudentEducationOrganizationAssociationAddressSchoolDistrict] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddressSchoolDistrict_StudentEducationOrganizationAssociationAddress] FOREIGN KEY ([AddressTypeDescriptorId], [City], [EducationOrganizationId], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociationAddress] ([AddressTypeDescriptorId], [City], [EducationOrganizationId], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationAddressSchoolDistrict_StudentEducationOrganizationAssociationAddress]
ON [sample].[StudentEducationOrganizationAssociationAddressSchoolDistrict] ([AddressTypeDescriptorId] ASC, [City] ASC, [EducationOrganizationId] ASC, [PostalCode] ASC, [StateAbbreviationDescriptorId] ASC, [StreetNumberName] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentEducationOrganizationAssociationAddressTerm] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddressTerm_StudentEducationOrganizationAssociationAddress] FOREIGN KEY ([AddressTypeDescriptorId], [City], [EducationOrganizationId], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociationAddress] ([AddressTypeDescriptorId], [City], [EducationOrganizationId], [PostalCode], [StateAbbreviationDescriptorId], [StreetNumberName], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationAddressTerm_StudentEducationOrganizationAssociationAddress]
ON [sample].[StudentEducationOrganizationAssociationAddressTerm] ([AddressTypeDescriptorId] ASC, [City] ASC, [EducationOrganizationId] ASC, [PostalCode] ASC, [StateAbbreviationDescriptorId] ASC, [StreetNumberName] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentEducationOrganizationAssociationAddressTerm] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationAddressTerm_TermDescriptor] FOREIGN KEY ([TermDescriptorId])
REFERENCES [edfi].[TermDescriptor] ([TermDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationAddressTerm_TermDescriptor]
ON [sample].[StudentEducationOrganizationAssociationAddressTerm] ([TermDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed] WITH CHECK ADD CONSTRAINT [FK_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed_StudentEducationOrganizationAssociationStudentCharact] FOREIGN KEY ([EducationOrganizationId], [StudentCharacteristicDescriptorId], [StudentUSI])
REFERENCES [edfi].[StudentEducationOrganizationAssociationStudentCharacteristic] ([EducationOrganizationId], [StudentCharacteristicDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed_StudentEducationOrganizationAssociationStudentCharact]
ON [sample].[StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed] ([EducationOrganizationId] ASC, [StudentCharacteristicDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentFavoriteBook] WITH CHECK ADD CONSTRAINT [FK_StudentFavoriteBook_FavoriteBookCategoryDescriptor] FOREIGN KEY ([FavoriteBookCategoryDescriptorId])
REFERENCES [sample].[FavoriteBookCategoryDescriptor] ([FavoriteBookCategoryDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentFavoriteBook_FavoriteBookCategoryDescriptor]
ON [sample].[StudentFavoriteBook] ([FavoriteBookCategoryDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentFavoriteBook] WITH CHECK ADD CONSTRAINT [FK_StudentFavoriteBook_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentFavoriteBook_Student]
ON [sample].[StudentFavoriteBook] ([StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentFavoriteBookArtMedium] WITH CHECK ADD CONSTRAINT [FK_StudentFavoriteBookArtMedium_ArtMediumDescriptor] FOREIGN KEY ([ArtMediumDescriptorId])
REFERENCES [sample].[ArtMediumDescriptor] ([ArtMediumDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentFavoriteBookArtMedium_ArtMediumDescriptor]
ON [sample].[StudentFavoriteBookArtMedium] ([ArtMediumDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentFavoriteBookArtMedium] WITH CHECK ADD CONSTRAINT [FK_StudentFavoriteBookArtMedium_StudentFavoriteBook] FOREIGN KEY ([FavoriteBookCategoryDescriptorId], [StudentUSI])
REFERENCES [sample].[StudentFavoriteBook] ([FavoriteBookCategoryDescriptorId], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentFavoriteBookArtMedium_StudentFavoriteBook]
ON [sample].[StudentFavoriteBookArtMedium] ([FavoriteBookCategoryDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociation_GraduationPlan] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
REFERENCES [edfi].[GraduationPlan] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociation_GraduationPlan]
ON [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociation_Staff] FOREIGN KEY ([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociation_Staff]
ON [sample].[StudentGraduationPlanAssociation] ([StaffUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociation_Student]
ON [sample].[StudentGraduationPlanAssociation] ([StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationAcademicSubject_AcademicSubjectDescriptor] FOREIGN KEY ([AcademicSubjectDescriptorId])
REFERENCES [edfi].[AcademicSubjectDescriptor] ([AcademicSubjectDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationAcademicSubject_AcademicSubjectDescriptor]
ON [sample].[StudentGraduationPlanAssociationAcademicSubject] ([AcademicSubjectDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationAcademicSubject] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationAcademicSubject_StudentGraduationPlanAssociation] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
REFERENCES [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationAcademicSubject_StudentGraduationPlanAssociation]
ON [sample].[StudentGraduationPlanAssociationAcademicSubject] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationCareerPathwayCode] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationCareerPathwayCode_StudentGraduationPlanAssociation] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
REFERENCES [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationCareerPathwayCode_StudentGraduationPlanAssociation]
ON [sample].[StudentGraduationPlanAssociationCareerPathwayCode] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationCTEProgram] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationCTEProgram_CareerPathwayDescriptor] FOREIGN KEY ([CareerPathwayDescriptorId])
REFERENCES [edfi].[CareerPathwayDescriptor] ([CareerPathwayDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationCTEProgram_CareerPathwayDescriptor]
ON [sample].[StudentGraduationPlanAssociationCTEProgram] ([CareerPathwayDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationCTEProgram] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationCTEProgram_StudentGraduationPlanAssociation] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
REFERENCES [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationDescription] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationDescription_StudentGraduationPlanAssociation] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
REFERENCES [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationDescription_StudentGraduationPlanAssociation]
ON [sample].[StudentGraduationPlanAssociationDescription] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationDesignatedBy] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationDesignatedBy_StudentGraduationPlanAssociation] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
REFERENCES [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationDesignatedBy_StudentGraduationPlanAssociation]
ON [sample].[StudentGraduationPlanAssociationDesignatedBy] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationIndustryCredential] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationIndustryCredential_StudentGraduationPlanAssociation] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
REFERENCES [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationIndustryCredential_StudentGraduationPlanAssociation]
ON [sample].[StudentGraduationPlanAssociationIndustryCredential] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationStudentParentAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationStudentParentAssociation_StudentGraduationPlanAssociation] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
REFERENCES [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationStudentParentAssociation_StudentGraduationPlanAssociation]
ON [sample].[StudentGraduationPlanAssociationStudentParentAssociation] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationStudentParentAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationStudentParentAssociation_StudentParentAssociation] FOREIGN KEY ([ParentUSI], [StudentUSI])
REFERENCES [edfi].[StudentParentAssociation] ([ParentUSI], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationStudentParentAssociation_StudentParentAssociation]
ON [sample].[StudentGraduationPlanAssociationStudentParentAssociation] ([ParentUSI] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentGraduationPlanAssociationYearsAttended] WITH CHECK ADD CONSTRAINT [FK_StudentGraduationPlanAssociationYearsAttended_StudentGraduationPlanAssociation] FOREIGN KEY ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
REFERENCES [sample].[StudentGraduationPlanAssociation] ([EducationOrganizationId], [GraduationPlanTypeDescriptorId], [GraduationSchoolYear], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentGraduationPlanAssociationYearsAttended_StudentGraduationPlanAssociation]
ON [sample].[StudentGraduationPlanAssociationYearsAttended] ([EducationOrganizationId] ASC, [GraduationPlanTypeDescriptorId] ASC, [GraduationSchoolYear] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationDiscipline] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationDiscipline_DisciplineDescriptor] FOREIGN KEY ([DisciplineDescriptorId])
REFERENCES [edfi].[DisciplineDescriptor] ([DisciplineDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationDiscipline_DisciplineDescriptor]
ON [sample].[StudentParentAssociationDiscipline] ([DisciplineDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationDiscipline] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationDiscipline_StudentParentAssociation] FOREIGN KEY ([ParentUSI], [StudentUSI])
REFERENCES [edfi].[StudentParentAssociation] ([ParentUSI], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationDiscipline_StudentParentAssociation]
ON [sample].[StudentParentAssociationDiscipline] ([ParentUSI] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationExtension_InterventionStudy] FOREIGN KEY ([EducationOrganizationId], [InterventionStudyIdentificationCode])
REFERENCES [edfi].[InterventionStudy] ([EducationOrganizationId], [InterventionStudyIdentificationCode])
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationExtension_InterventionStudy]
ON [sample].[StudentParentAssociationExtension] ([EducationOrganizationId] ASC, [InterventionStudyIdentificationCode] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationExtension_StudentParentAssociation] FOREIGN KEY ([ParentUSI], [StudentUSI])
REFERENCES [edfi].[StudentParentAssociation] ([ParentUSI], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StudentParentAssociationFavoriteBookTitle] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationFavoriteBookTitle_StudentParentAssociation] FOREIGN KEY ([ParentUSI], [StudentUSI])
REFERENCES [edfi].[StudentParentAssociation] ([ParentUSI], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationFavoriteBookTitle_StudentParentAssociation]
ON [sample].[StudentParentAssociationFavoriteBookTitle] ([ParentUSI] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationHoursPerWeek] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationHoursPerWeek_StudentParentAssociation] FOREIGN KEY ([ParentUSI], [StudentUSI])
REFERENCES [edfi].[StudentParentAssociation] ([ParentUSI], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationHoursPerWeek_StudentParentAssociation]
ON [sample].[StudentParentAssociationHoursPerWeek] ([ParentUSI] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationPagesRead] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationPagesRead_StudentParentAssociation] FOREIGN KEY ([ParentUSI], [StudentUSI])
REFERENCES [edfi].[StudentParentAssociation] ([ParentUSI], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationPagesRead_StudentParentAssociation]
ON [sample].[StudentParentAssociationPagesRead] ([ParentUSI] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationStaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_StaffEducationOrganizationEmploymentAssociation] FOREIGN KEY ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
REFERENCES [edfi].[StaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId], [EmploymentStatusDescriptorId], [HireDate], [StaffUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_StaffEducationOrganizationEmploymentAssociation]
ON [sample].[StudentParentAssociationStaffEducationOrganizationEmploymentAssociation] ([EducationOrganizationId] ASC, [EmploymentStatusDescriptorId] ASC, [HireDate] ASC, [StaffUSI] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationStaffEducationOrganizationEmploymentAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_StudentParentAssociation] FOREIGN KEY ([ParentUSI], [StudentUSI])
REFERENCES [edfi].[StudentParentAssociation] ([ParentUSI], [StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationStaffEducationOrganizationEmploymentAssociation_StudentParentAssociation]
ON [sample].[StudentParentAssociationStaffEducationOrganizationEmploymentAssociation] ([ParentUSI] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentParentAssociationTelephone] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationTelephone_StudentParentAssociation] FOREIGN KEY ([ParentUSI], [StudentUSI])
REFERENCES [edfi].[StudentParentAssociation] ([ParentUSI], [StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StudentParentAssociationTelephone] WITH CHECK ADD CONSTRAINT [FK_StudentParentAssociationTelephone_TelephoneNumberTypeDescriptor] FOREIGN KEY ([TelephoneNumberTypeDescriptorId])
REFERENCES [edfi].[TelephoneNumberTypeDescriptor] ([TelephoneNumberTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentParentAssociationTelephone_TelephoneNumberTypeDescriptor]
ON [sample].[StudentParentAssociationTelephone] ([TelephoneNumberTypeDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentPet] WITH CHECK ADD CONSTRAINT [FK_StudentPet_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentPet_Student]
ON [sample].[StudentPet] ([StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentPetPreference] WITH CHECK ADD CONSTRAINT [FK_StudentPetPreference_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
ON DELETE CASCADE
GO

ALTER TABLE [sample].[StudentSchoolAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationExtension_MembershipTypeDescriptor] FOREIGN KEY ([MembershipTypeDescriptorId])
REFERENCES [sample].[MembershipTypeDescriptor] ([MembershipTypeDescriptorId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociationExtension_MembershipTypeDescriptor]
ON [sample].[StudentSchoolAssociationExtension] ([MembershipTypeDescriptorId] ASC)
GO

ALTER TABLE [sample].[StudentSchoolAssociationExtension] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociationExtension_StudentSchoolAssociation] FOREIGN KEY ([EntryDate], [SchoolId], [StudentUSI])
REFERENCES [edfi].[StudentSchoolAssociation] ([EntryDate], [SchoolId], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

ALTER TABLE [sample].[StudentSectionAssociationRelatedGeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociationRelatedGeneralStudentProgramAssociation_GeneralStudentProgramAssociation] FOREIGN KEY ([RelatedBeginDate], [RelatedEducationOrganizationId], [RelatedProgramEducationOrganizationId], [RelatedProgramName], [RelatedProgramTypeDescriptorId], [StudentUSI])
REFERENCES [edfi].[GeneralStudentProgramAssociation] ([BeginDate], [EducationOrganizationId], [ProgramEducationOrganizationId], [ProgramName], [ProgramTypeDescriptorId], [StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociationRelatedGeneralStudentProgramAssociation_GeneralStudentProgramAssociation]
ON [sample].[StudentSectionAssociationRelatedGeneralStudentProgramAssociation] ([RelatedBeginDate] ASC, [RelatedEducationOrganizationId] ASC, [RelatedProgramEducationOrganizationId] ASC, [RelatedProgramName] ASC, [RelatedProgramTypeDescriptorId] ASC, [StudentUSI] ASC)
GO

ALTER TABLE [sample].[StudentSectionAssociationRelatedGeneralStudentProgramAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSectionAssociationRelatedGeneralStudentProgramAssociation_StudentSectionAssociation] FOREIGN KEY ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
REFERENCES [edfi].[StudentSectionAssociation] ([BeginDate], [LocalCourseCode], [SchoolId], [SchoolYear], [SectionIdentifier], [SessionName], [StudentUSI])
ON DELETE CASCADE
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StudentSectionAssociationRelatedGeneralStudentProgramAssociation_StudentSectionAssociation]
ON [sample].[StudentSectionAssociationRelatedGeneralStudentProgramAssociation] ([BeginDate] ASC, [LocalCourseCode] ASC, [SchoolId] ASC, [SchoolYear] ASC, [SectionIdentifier] ASC, [SessionName] ASC, [StudentUSI] ASC)
GO

