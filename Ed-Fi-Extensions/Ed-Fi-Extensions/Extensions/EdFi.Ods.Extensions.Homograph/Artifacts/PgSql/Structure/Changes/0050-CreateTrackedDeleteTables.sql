CREATE TABLE tracked_deletes_homograph.Name
(
       FirstName VARCHAR(75) NOT NULL,
       LastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Name_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.Parent
(
       ParentFirstName VARCHAR(75) NOT NULL,
       ParentLastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Parent_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.School
(
       SchoolName VARCHAR(100) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT School_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.SchoolYearType
(
       SchoolYear VARCHAR(20) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT SchoolYearType_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.Staff
(
       StaffFirstName VARCHAR(75) NOT NULL,
       StaffLastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Staff_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.Student
(
       StudentFirstName VARCHAR(75) NOT NULL,
       StudentLastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Student_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_homograph.StudentSchoolAssociation
(
       SchoolName VARCHAR(100) NOT NULL,
       StudentFirstName VARCHAR(75) NOT NULL,
       StudentLastSurname VARCHAR(75) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentSchoolAssociation_PK PRIMARY KEY (ChangeVersion)
);

