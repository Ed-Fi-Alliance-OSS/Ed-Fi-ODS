CREATE TABLE tracked_deletes_samplestudenttransportation.StudentTransportation
(
       AMBusNumber VARCHAR(6) NOT NULL,
       PMBusNumber VARCHAR(6) NOT NULL,
       SchoolId INT NOT NULL,
       StudentUSI INT NOT NULL,
       Id UUID NOT NULL,
       ChangeVersion BIGINT NOT NULL,
       CONSTRAINT StudentTransportation_PK PRIMARY KEY (ChangeVersion)
);

