-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

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

