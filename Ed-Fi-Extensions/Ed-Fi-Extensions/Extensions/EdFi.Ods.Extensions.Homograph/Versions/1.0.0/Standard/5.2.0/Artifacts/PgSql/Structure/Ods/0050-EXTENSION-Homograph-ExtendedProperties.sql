-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [homograph].[Contact] --
COMMENT ON TABLE homograph.Contact IS 'This entity represents an individual for whom instruction, services, and/or care are provided in an early childhood, elementary, or secondary educational program under the jurisdiction of a school, education agency or other institution or program. A student is a person who has been enrolled in a school or other educational institution.';
COMMENT ON COLUMN homograph.Contact.ContactFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.Contact.ContactLastSurname IS 'The name borne in common by members of a family.';

-- Extended Properties [homograph].[ContactAddress] --
COMMENT ON TABLE homograph.ContactAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN homograph.ContactAddress.ContactFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.ContactAddress.ContactLastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN homograph.ContactAddress.City IS 'The name of the city in which an address is located.';

-- Extended Properties [homograph].[ContactStudentSchoolAssociation] --
COMMENT ON TABLE homograph.ContactStudentSchoolAssociation IS 'The students association with the contact.';
COMMENT ON COLUMN homograph.ContactStudentSchoolAssociation.ContactFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.ContactStudentSchoolAssociation.ContactLastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN homograph.ContactStudentSchoolAssociation.SchoolName IS 'The name of the school.';
COMMENT ON COLUMN homograph.ContactStudentSchoolAssociation.StudentFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.ContactStudentSchoolAssociation.StudentLastSurname IS 'The name borne in common by members of a family.';

-- Extended Properties [homograph].[Name] --
COMMENT ON TABLE homograph.Name IS 'The set of elements that comprise a person''s legal name.';
COMMENT ON COLUMN homograph.Name.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.Name.LastSurname IS 'The name borne in common by members of a family.';

-- Extended Properties [homograph].[School] --
COMMENT ON TABLE homograph.School IS 'This entity represents an educational organization that includes staff and students who participate in classes and educational activity groups.';
COMMENT ON COLUMN homograph.School.SchoolName IS 'The name of the school.';
COMMENT ON COLUMN homograph.School.SchoolYear IS 'A school year.';

-- Extended Properties [homograph].[SchoolAddress] --
COMMENT ON TABLE homograph.SchoolAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN homograph.SchoolAddress.SchoolName IS 'The name of the school.';
COMMENT ON COLUMN homograph.SchoolAddress.City IS 'The name of the city in which an address is located.';

-- Extended Properties [homograph].[SchoolYearType] --
COMMENT ON TABLE homograph.SchoolYearType IS 'Identifier for a school year.';
COMMENT ON COLUMN homograph.SchoolYearType.SchoolYear IS 'A school year.';

-- Extended Properties [homograph].[Staff] --
COMMENT ON TABLE homograph.Staff IS 'same name as a core domain entity';
COMMENT ON COLUMN homograph.Staff.StaffFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.Staff.StaffLastSurname IS 'The name borne in common by members of a family.';

-- Extended Properties [homograph].[StaffAddress] --
COMMENT ON TABLE homograph.StaffAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN homograph.StaffAddress.StaffFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.StaffAddress.StaffLastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN homograph.StaffAddress.City IS 'The name of the city in which an address is located.';

-- Extended Properties [homograph].[StaffStudentSchoolAssociation] --
COMMENT ON TABLE homograph.StaffStudentSchoolAssociation IS 'The students under the instruction of the staff member';
COMMENT ON COLUMN homograph.StaffStudentSchoolAssociation.StaffFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.StaffStudentSchoolAssociation.StaffLastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN homograph.StaffStudentSchoolAssociation.SchoolName IS 'The name of the school.';
COMMENT ON COLUMN homograph.StaffStudentSchoolAssociation.StudentFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.StaffStudentSchoolAssociation.StudentLastSurname IS 'The name borne in common by members of a family.';

-- Extended Properties [homograph].[Student] --
COMMENT ON TABLE homograph.Student IS 'This entity represents an individual for whom instruction, services, and/or care are provided in an early childhood, elementary, or secondary educational program under the jurisdiction of a school, education agency or other institution or program. A student is a person who has been enrolled in a school or other educational institution.';
COMMENT ON COLUMN homograph.Student.StudentFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.Student.StudentLastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN homograph.Student.SchoolYear IS 'A school year.';

-- Extended Properties [homograph].[StudentAddress] --
COMMENT ON TABLE homograph.StudentAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN homograph.StudentAddress.StudentFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.StudentAddress.StudentLastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN homograph.StudentAddress.City IS 'The name of the city in which an address is located.';

-- Extended Properties [homograph].[StudentSchoolAssociation] --
COMMENT ON TABLE homograph.StudentSchoolAssociation IS 'This association represents the School in which a student is enrolled. The semantics of enrollment may differ slightly by state. Non-enrollment relationships between a student and an education organization may be described using the StudentEducationOrganizationAssociation.';
COMMENT ON COLUMN homograph.StudentSchoolAssociation.SchoolName IS 'The name of the school.';
COMMENT ON COLUMN homograph.StudentSchoolAssociation.StudentFirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN homograph.StudentSchoolAssociation.StudentLastSurname IS 'The name borne in common by members of a family.';

