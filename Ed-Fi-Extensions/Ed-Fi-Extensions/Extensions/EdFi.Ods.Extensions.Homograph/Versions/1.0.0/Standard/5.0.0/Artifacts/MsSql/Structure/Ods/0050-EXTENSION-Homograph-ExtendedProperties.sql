-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [homograph].[Contact] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents an individual for whom instruction, services, and/or care are provided in an early childhood, elementary, or secondary educational program under the jurisdiction of a school, education agency or other institution or program. A student is a person who has been enrolled in a school or other educational institution.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Contact'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Contact', @level2type=N'COLUMN', @level2name=N'ContactFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Contact', @level2type=N'COLUMN', @level2name=N'ContactLastSurname'
GO

-- Extended Properties [homograph].[ContactAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactAddress', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactAddress', @level2type=N'COLUMN', @level2name=N'ContactFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactAddress', @level2type=N'COLUMN', @level2name=N'ContactLastSurname'
GO

-- Extended Properties [homograph].[ContactStudentSchoolAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The students association with the contact.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactStudentSchoolAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'ContactFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'ContactLastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the school.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'SchoolName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'StudentFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'ContactStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'StudentLastSurname'
GO

-- Extended Properties [homograph].[Name] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that comprise a person''s legal name.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Name', @level2type=N'COLUMN', @level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Name', @level2type=N'COLUMN', @level2name=N'LastSurname'
GO

-- Extended Properties [homograph].[School] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents an educational organization that includes staff and students who participate in classes and educational activity groups.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'School'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the school.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'School', @level2type=N'COLUMN', @level2name=N'SchoolName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A school year.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'School', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO

-- Extended Properties [homograph].[SchoolAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'SchoolAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the school.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'SchoolAddress', @level2type=N'COLUMN', @level2name=N'SchoolName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'SchoolAddress', @level2type=N'COLUMN', @level2name=N'City'
GO

-- Extended Properties [homograph].[SchoolYearType] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier for a school year.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'SchoolYearType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A school year.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'SchoolYearType', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO

-- Extended Properties [homograph].[Staff] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'same name as a core domain entity', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Staff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Staff', @level2type=N'COLUMN', @level2name=N'StaffFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Staff', @level2type=N'COLUMN', @level2name=N'StaffLastSurname'
GO

-- Extended Properties [homograph].[StaffAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffAddress', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffAddress', @level2type=N'COLUMN', @level2name=N'StaffFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffAddress', @level2type=N'COLUMN', @level2name=N'StaffLastSurname'
GO

-- Extended Properties [homograph].[StaffStudentSchoolAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The students under the instruction of the staff member', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffStudentSchoolAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the school.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'SchoolName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'StaffFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'StaffLastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'StudentFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StaffStudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'StudentLastSurname'
GO

-- Extended Properties [homograph].[Student] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This entity represents an individual for whom instruction, services, and/or care are provided in an early childhood, elementary, or secondary educational program under the jurisdiction of a school, education agency or other institution or program. A student is a person who has been enrolled in a school or other educational institution.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Student'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Student', @level2type=N'COLUMN', @level2name=N'StudentFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Student', @level2type=N'COLUMN', @level2name=N'StudentLastSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A school year.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'Student', @level2type=N'COLUMN', @level2name=N'SchoolYear'
GO

-- Extended Properties [homograph].[StudentAddress] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The set of elements that describes an address, including the street address, city, state, and ZIP code.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StudentAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city in which an address is located.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StudentAddress', @level2type=N'COLUMN', @level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StudentAddress', @level2type=N'COLUMN', @level2name=N'StudentFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StudentAddress', @level2type=N'COLUMN', @level2name=N'StudentLastSurname'
GO

-- Extended Properties [homograph].[StudentSchoolAssociation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This association represents the School in which a student is enrolled. The semantics of enrollment may differ slightly by state. Non-enrollment relationships between a student and an education organization may be described using the StudentEducationOrganizationAssociation.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the school.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'SchoolName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'StudentFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name borne in common by members of a family.', @level0type=N'SCHEMA', @level0name=N'homograph', @level1type=N'TABLE', @level1name=N'StudentSchoolAssociation', @level2type=N'COLUMN', @level2name=N'StudentLastSurname'
GO

