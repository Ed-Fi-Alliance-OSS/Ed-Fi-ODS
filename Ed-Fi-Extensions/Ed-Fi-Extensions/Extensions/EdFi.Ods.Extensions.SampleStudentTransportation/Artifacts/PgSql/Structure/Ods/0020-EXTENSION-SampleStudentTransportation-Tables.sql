-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table samplestudenttransportation.StudentTransportation --
CREATE TABLE samplestudenttransportation.StudentTransportation (
    AMBusNumber VARCHAR(6) NOT NULL,
    PMBusNumber VARCHAR(6) NOT NULL,
    SchoolId INT NOT NULL,
    StudentUSI INT NOT NULL,
    EstimatedMilesFromSchool DECIMAL(5, 2) NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT StudentTransportation_PK PRIMARY KEY (AMBusNumber, PMBusNumber, SchoolId, StudentUSI)
); 
ALTER TABLE samplestudenttransportation.StudentTransportation ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE samplestudenttransportation.StudentTransportation ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE samplestudenttransportation.StudentTransportation ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;

