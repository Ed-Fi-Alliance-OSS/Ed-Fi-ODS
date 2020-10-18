-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE homograph.Parent ADD CONSTRAINT FK_5f7953_Name FOREIGN KEY (ParentFirstName, ParentLastSurname)
REFERENCES homograph.Name (FirstName, LastSurname)
;

ALTER TABLE homograph.ParentAddress ADD CONSTRAINT FK_cc3333_Parent FOREIGN KEY (ParentFirstName, ParentLastSurname)
REFERENCES homograph.Parent (ParentFirstName, ParentLastSurname)
ON DELETE CASCADE
;

CREATE INDEX FK_cc3333_Parent
ON homograph.ParentAddress (ParentFirstName ASC, ParentLastSurname ASC);

ALTER TABLE homograph.ParentStudentSchoolAssociation ADD CONSTRAINT FK_23ef78_Parent FOREIGN KEY (ParentFirstName, ParentLastSurname)
REFERENCES homograph.Parent (ParentFirstName, ParentLastSurname)
ON DELETE CASCADE
;

CREATE INDEX FK_23ef78_Parent
ON homograph.ParentStudentSchoolAssociation (ParentFirstName ASC, ParentLastSurname ASC);

ALTER TABLE homograph.ParentStudentSchoolAssociation ADD CONSTRAINT FK_23ef78_StudentSchoolAssociation FOREIGN KEY (SchoolName, StudentFirstName, StudentLastSurname)
REFERENCES homograph.StudentSchoolAssociation (SchoolName, StudentFirstName, StudentLastSurname)
ON UPDATE CASCADE
;

CREATE INDEX FK_23ef78_StudentSchoolAssociation
ON homograph.ParentStudentSchoolAssociation (SchoolName ASC, StudentFirstName ASC, StudentLastSurname ASC);

ALTER TABLE homograph.School ADD CONSTRAINT FK_6cd2e3_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES homograph.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_6cd2e3_SchoolYearType
ON homograph.School (SchoolYear ASC);

ALTER TABLE homograph.SchoolAddress ADD CONSTRAINT FK_a09d7e_School FOREIGN KEY (SchoolName)
REFERENCES homograph.School (SchoolName)
ON DELETE CASCADE
;

ALTER TABLE homograph.Staff ADD CONSTRAINT FK_681927_Name FOREIGN KEY (StaffFirstName, StaffLastSurname)
REFERENCES homograph.Name (FirstName, LastSurname)
;

ALTER TABLE homograph.StaffAddress ADD CONSTRAINT FK_c0e4a3_Staff FOREIGN KEY (StaffFirstName, StaffLastSurname)
REFERENCES homograph.Staff (StaffFirstName, StaffLastSurname)
ON DELETE CASCADE
;

CREATE INDEX FK_c0e4a3_Staff
ON homograph.StaffAddress (StaffFirstName ASC, StaffLastSurname ASC);

ALTER TABLE homograph.StaffStudentSchoolAssociation ADD CONSTRAINT FK_fec532_Staff FOREIGN KEY (StaffFirstName, StaffLastSurname)
REFERENCES homograph.Staff (StaffFirstName, StaffLastSurname)
ON DELETE CASCADE
;

CREATE INDEX FK_fec532_Staff
ON homograph.StaffStudentSchoolAssociation (StaffFirstName ASC, StaffLastSurname ASC);

ALTER TABLE homograph.StaffStudentSchoolAssociation ADD CONSTRAINT FK_fec532_StudentSchoolAssociation FOREIGN KEY (SchoolName, StudentFirstName, StudentLastSurname)
REFERENCES homograph.StudentSchoolAssociation (SchoolName, StudentFirstName, StudentLastSurname)
ON UPDATE CASCADE
;

CREATE INDEX FK_fec532_StudentSchoolAssociation
ON homograph.StaffStudentSchoolAssociation (SchoolName ASC, StudentFirstName ASC, StudentLastSurname ASC);

ALTER TABLE homograph.Student ADD CONSTRAINT FK_2a164d_Name FOREIGN KEY (StudentFirstName, StudentLastSurname)
REFERENCES homograph.Name (FirstName, LastSurname)
;

ALTER TABLE homograph.Student ADD CONSTRAINT FK_2a164d_SchoolYearType FOREIGN KEY (SchoolYear)
REFERENCES homograph.SchoolYearType (SchoolYear)
;

CREATE INDEX FK_2a164d_SchoolYearType
ON homograph.Student (SchoolYear ASC);

ALTER TABLE homograph.StudentAddress ADD CONSTRAINT FK_e70453_Student FOREIGN KEY (StudentFirstName, StudentLastSurname)
REFERENCES homograph.Student (StudentFirstName, StudentLastSurname)
ON DELETE CASCADE
;

CREATE INDEX FK_e70453_Student
ON homograph.StudentAddress (StudentFirstName ASC, StudentLastSurname ASC);

ALTER TABLE homograph.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_School FOREIGN KEY (SchoolName)
REFERENCES homograph.School (SchoolName)
;

CREATE INDEX FK_857b52_School
ON homograph.StudentSchoolAssociation (SchoolName ASC);

ALTER TABLE homograph.StudentSchoolAssociation ADD CONSTRAINT FK_857b52_Student FOREIGN KEY (StudentFirstName, StudentLastSurname)
REFERENCES homograph.Student (StudentFirstName, StudentLastSurname)
;

CREATE INDEX FK_857b52_Student
ON homograph.StudentSchoolAssociation (StudentFirstName ASC, StudentLastSurname ASC);

