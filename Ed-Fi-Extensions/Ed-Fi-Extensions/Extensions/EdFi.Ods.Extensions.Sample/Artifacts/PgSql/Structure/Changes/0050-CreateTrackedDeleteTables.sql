CREATE TABLE tracked_deletes_sample.ArtMediumDescriptor
(
       ArtMediumDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT ArtMediumDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_sample.Bus
(
       BusId VARCHAR(60) NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT Bus_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_sample.BusRoute
(
       BusId VARCHAR(60) NOT NULL,
       BusRouteNumber INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT BusRoute_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_sample.FavoriteBookCategoryDescriptor
(
       FavoriteBookCategoryDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT FavoriteBookCategoryDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_sample.MembershipTypeDescriptor
(
       MembershipTypeDescriptorId INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT MembershipTypeDescriptor_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_sample.StudentArtProgramAssociation
(
       BeginDate DATE NOT NULL,
       EducationOrganizationId INT NOT NULL,
       ProgramEducationOrganizationId INT NOT NULL,
       ProgramName VARCHAR(60) NOT NULL,
       ProgramTypeDescriptorId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentArtProgramAssociation_PK PRIMARY KEY (ChangeVersion)
);

CREATE TABLE tracked_deletes_sample.StudentGraduationPlanAssociation
(
       EducationOrganizationId INT NOT NULL,
       GraduationPlanTypeDescriptorId INT NOT NULL,
       GraduationSchoolYear SMALLINT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentGraduationPlanAssociation_PK PRIMARY KEY (ChangeVersion)
);

