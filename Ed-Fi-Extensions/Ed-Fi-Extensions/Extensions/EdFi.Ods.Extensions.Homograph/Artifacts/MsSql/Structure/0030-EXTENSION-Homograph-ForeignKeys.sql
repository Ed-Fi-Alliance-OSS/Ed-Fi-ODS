ALTER TABLE [homograph].[Parent] WITH CHECK ADD CONSTRAINT [FK_Parent_Name] FOREIGN KEY ([ParentFirstName], [ParentLastSurname])
REFERENCES [homograph].[Name] ([FirstName], [LastSurname])
GO

ALTER TABLE [homograph].[ParentAddress] WITH CHECK ADD CONSTRAINT [FK_ParentAddress_Parent] FOREIGN KEY ([ParentFirstName], [ParentLastSurname])
REFERENCES [homograph].[Parent] ([ParentFirstName], [ParentLastSurname])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentAddress_Parent]
ON [homograph].[ParentAddress] ([ParentFirstName] ASC, [ParentLastSurname] ASC)
GO

ALTER TABLE [homograph].[ParentStudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_ParentStudentSchoolAssociation_Parent] FOREIGN KEY ([ParentFirstName], [ParentLastSurname])
REFERENCES [homograph].[Parent] ([ParentFirstName], [ParentLastSurname])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentStudentSchoolAssociation_Parent]
ON [homograph].[ParentStudentSchoolAssociation] ([ParentFirstName] ASC, [ParentLastSurname] ASC)
GO

ALTER TABLE [homograph].[ParentStudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_ParentStudentSchoolAssociation_StudentSchoolAssociation] FOREIGN KEY ([SchoolName], [StudentFirstName], [StudentLastSurname])
REFERENCES [homograph].[StudentSchoolAssociation] ([SchoolName], [StudentFirstName], [StudentLastSurname])
ON UPDATE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_ParentStudentSchoolAssociation_StudentSchoolAssociation]
ON [homograph].[ParentStudentSchoolAssociation] ([SchoolName] ASC, [StudentFirstName] ASC, [StudentLastSurname] ASC)
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

CREATE NONCLUSTERED INDEX [FK_StaffAddress_Staff]
ON [homograph].[StaffAddress] ([StaffFirstName] ASC, [StaffLastSurname] ASC)
GO

ALTER TABLE [homograph].[StaffStudentSchoolAssociation] WITH CHECK ADD CONSTRAINT [FK_StaffStudentSchoolAssociation_Staff] FOREIGN KEY ([StaffFirstName], [StaffLastSurname])
REFERENCES [homograph].[Staff] ([StaffFirstName], [StaffLastSurname])
ON DELETE CASCADE
GO

CREATE NONCLUSTERED INDEX [FK_StaffStudentSchoolAssociation_Staff]
ON [homograph].[StaffStudentSchoolAssociation] ([StaffFirstName] ASC, [StaffLastSurname] ASC)
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

CREATE NONCLUSTERED INDEX [FK_StudentAddress_Student]
ON [homograph].[StudentAddress] ([StudentFirstName] ASC, [StudentLastSurname] ASC)
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

