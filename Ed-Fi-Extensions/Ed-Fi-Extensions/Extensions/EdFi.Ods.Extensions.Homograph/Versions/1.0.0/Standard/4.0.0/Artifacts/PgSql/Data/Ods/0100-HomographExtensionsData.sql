do $$
declare grandBendElementarySchoolId int;
declare student604854Usi int;
declare staffFirstName varchar(225) = 'StaffFirstName';
declare staffLastSurname varchar(225) = 'StaffLastSurname';
declare parentFirstName varchar(225) = 'ParentFirstName';
declare parentLastSurname varchar(225) = 'ParentLastSurname';
declare studentFirstName varchar(225) = 'StudentFirstName';
declare studentLastSurname varchar(225) = 'StudentLastSurname';
declare cityName varchar(225) = 'CityName';
declare schoolName varchar(225) = 'SchoolName';
declare schoolYear varchar(225) = 'SchoolYear';
begin

select SchoolId into grandBendElementarySchoolId
from edfi.School
where SchoolId = 255901107;

select StudentUSI into student604854Usi
from edfi.Student
where StudentUniqueId = '604854';

-- Sanity check to make sure some data exists, otherwise skip the script
if grandBendElementarySchoolId is null or student604854Usi is null then
	return;
end if;

INSERT INTO homograph.Name
    (FirstName, LastSurname)
VALUES
    (staffFirstName, staffLastSurname),
    (parentFirstName, parentLastSurname),
    (studentFirstName, studentLastSurname);

INSERT INTO homograph.SchoolYearType
    (SchoolYear)
VALUES
    (schoolYear);

INSERT INTO homograph.School
    (SchoolName, SchoolYear)
VALUES
    (schoolName, schoolYear);

INSERT INTO homograph.SchoolAddress
    (SchoolName, City)
VALUES
    (schoolName, cityName);

INSERT INTO homograph.Student
    (StudentFirstName, StudentLastSurname, SchoolYear)
VALUES
    (studentFirstName, studentLastSurname, schoolYear);

INSERT INTO homograph.StudentAddress
    (StudentFirstName, StudentLastSurname, City)
VALUES
    (studentFirstName, studentLastSurname, cityName);

INSERT INTO homograph.StudentSchoolAssociation
    (StudentFirstName, StudentLastSurname, SchoolName)
VALUES
    (studentFirstName, studentLastSurname, schoolName);

INSERT INTO homograph.Staff
    (StaffFirstName, StaffLastSurname)
VALUES
    (staffFirstName, staffLastSurname);

INSERT INTO homograph.StaffAddress
    (StaffFirstName, StaffLastSurname, City)
VALUES
    (staffFirstName, staffLastSurname, cityName);

INSERT INTO homograph.StaffStudentSchoolAssociation
    (StaffFirstName, StaffLastSurname, SchoolName, StudentFirstName, StudentLastSurname)
VALUES
    (staffFirstName, staffLastSurname, schoolName, studentFirstName, studentLastSurname);

INSERT INTO homograph.Parent
    (ParentFirstName, ParentLastSurname)
VALUES
    (parentFirstName, parentLastSurname);

INSERT INTO homograph.ParentAddress
    (ParentFirstName, ParentLastSurname, City)
VALUES
    (parentFirstName, parentLastSurname, cityName);

INSERT INTO homograph.ParentStudentSchoolAssociation
    (ParentFirstName, ParentLastSurname, SchoolName, StudentFirstName, StudentLastSurname)
VALUES
    (parentFirstName, parentLastSurname, schoolName, studentFirstName, studentLastSurname);


end $$