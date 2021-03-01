CREATE TABLE [tracked_deletes_homograph].[Name]
(
       FirstName [NVARCHAR](75) NOT NULL,
       LastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Name PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_homograph].[Parent]
(
       ParentFirstName [NVARCHAR](75) NOT NULL,
       ParentLastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Parent PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_homograph].[School]
(
       SchoolName [NVARCHAR](100) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_School PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_homograph].[SchoolYearType]
(
       SchoolYear [NVARCHAR](20) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_SchoolYearType PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_homograph].[Staff]
(
       StaffFirstName [NVARCHAR](75) NOT NULL,
       StaffLastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Staff PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_homograph].[Student]
(
       StudentFirstName [NVARCHAR](75) NOT NULL,
       StudentLastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_Student PRIMARY KEY CLUSTERED (ChangeVersion)
)

CREATE TABLE [tracked_deletes_homograph].[StudentSchoolAssociation]
(
       SchoolName [NVARCHAR](100) NOT NULL,
       StudentFirstName [NVARCHAR](75) NOT NULL,
       StudentLastSurname [NVARCHAR](75) NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StudentSchoolAssociation PRIMARY KEY CLUSTERED (ChangeVersion)
)

