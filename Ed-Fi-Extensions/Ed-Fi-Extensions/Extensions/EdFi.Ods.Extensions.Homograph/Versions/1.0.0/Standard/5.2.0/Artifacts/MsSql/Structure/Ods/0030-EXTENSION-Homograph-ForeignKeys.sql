-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [homograph].[Contact] WITH CHECK ADD CONSTRAINT [FK_Contact_Name] FOREIGN KEY ([ContactFirstName], [ContactLastSurname])
REFERENCES [homograph].[Name] ([FirstName], [LastSurname])
GO

ALTER TABLE [homograph].[ContactAddress] WITH CHECK ADD CONSTRAINT [FK_ContactAddress_Contact] FOREIGN KEY ([ContactFirstName], [ContactLastSurname])
REFERENCES [homograph].[Contact] ([ContactFirstName], [ContactLastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [homograph].[ContactStudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_ContactStudentSchoolAssociation_Contact] FOREIGN KEY ([ContactFirstName], [ContactLastSurname])
REFERENCES [homograph].[Contact] ([ContactFirstName], [ContactLastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [homograph].[ContactStudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_ContactStudentSchoolAssociation_StudentSchoolAssociation] FOREIGN KEY ([SchoolName], [StudentFirstName], [StudentLastSurname])
REFERENCES [homograph].[StudentSchoolAssociation] ([SchoolName], [StudentFirstName], [StudentLastSurname])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ContactStudentSchoolAssociation_StudentSchoolAssociation]
ON [homograph].[ContactStudentSchoolAssociation] ([SchoolName] ASC, [StudentFirstName] ASC, [StudentLastSurname] ASC)
GO

ALTER TABLE [homograph].[School] WITH CHECK ADD CONSTRAINT [FK_School_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [homograph].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_School_SchoolYearType]
ON [homograph].[School] ([SchoolYear] ASC)
GO

ALTER TABLE [homograph].[SchoolAddress] WITH CHECK ADD CONSTRAINT [FK_SchoolAddress_School] FOREIGN KEY ([SchoolName])
REFERENCES [homograph].[School] ([SchoolName])
ON DELETE CASCADE
GO

ALTER TABLE [homograph].[Staff] WITH CHECK ADD CONSTRAINT [FK_Staff_Name] FOREIGN KEY ([StaffFirstName], [StaffLastSurname])
REFERENCES [homograph].[Name] ([FirstName], [LastSurname])
GO

ALTER TABLE [homograph].[StaffAddress] WITH CHECK ADD CONSTRAINT [FK_StaffAddress_Staff] FOREIGN KEY ([StaffFirstName], [StaffLastSurname])
REFERENCES [homograph].[Staff] ([StaffFirstName], [StaffLastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [homograph].[StaffStudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentSchoolAssociation_Staff] FOREIGN KEY ([StaffFirstName], [StaffLastSurname])
REFERENCES [homograph].[Staff] ([StaffFirstName], [StaffLastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [homograph].[StaffStudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentSchoolAssociation_StudentSchoolAssociation] FOREIGN KEY ([SchoolName], [StudentFirstName], [StudentLastSurname])
REFERENCES [homograph].[StudentSchoolAssociation] ([SchoolName], [StudentFirstName], [StudentLastSurname])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentSchoolAssociation_StudentSchoolAssociation]
ON [homograph].[StaffStudentSchoolAssociation] ([SchoolName] ASC, [StudentFirstName] ASC, [StudentLastSurname] ASC)
GO

ALTER TABLE [homograph].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_Name] FOREIGN KEY ([StudentFirstName], [StudentLastSurname])
REFERENCES [homograph].[Name] ([FirstName], [LastSurname])
GO

ALTER TABLE [homograph].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_SchoolYearType] FOREIGN KEY ([SchoolYear])
REFERENCES [homograph].[SchoolYearType] ([SchoolYear])
GO

CREATE NONCLUSTERED INDEX [FK_Student_SchoolYearType]
ON [homograph].[Student] ([SchoolYear] ASC)
GO

ALTER TABLE [homograph].[StudentAddress] WITH CHECK ADD CONSTRAINT [FK_StudentAddress_Student] FOREIGN KEY ([StudentFirstName], [StudentLastSurname])
REFERENCES [homograph].[Student] ([StudentFirstName], [StudentLastSurname])
ON DELETE CASCADE
GO

ALTER TABLE [homograph].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_School] FOREIGN KEY ([SchoolName])
REFERENCES [homograph].[School] ([SchoolName])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_School]
ON [homograph].[StudentSchoolAssociation] ([SchoolName] ASC)
GO

ALTER TABLE [homograph].[StudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StudentSchoolAssociation_Student] FOREIGN KEY ([StudentFirstName], [StudentLastSurname])
REFERENCES [homograph].[Student] ([StudentFirstName], [StudentLastSurname])
GO

CREATE NONCLUSTERED INDEX [FK_StudentSchoolAssociation_Student]
ON [homograph].[StudentSchoolAssociation] ([StudentFirstName] ASC, [StudentLastSurname] ASC)
GO

