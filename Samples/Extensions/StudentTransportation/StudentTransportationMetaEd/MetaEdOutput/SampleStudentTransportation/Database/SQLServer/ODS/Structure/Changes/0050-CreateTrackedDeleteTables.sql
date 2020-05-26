-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE [tracked_deletes_samplestudenttransportation].[StudentTransportation]
(
       AMBusNumber [NVARCHAR](6) NOT NULL,
       PMBusNumber [NVARCHAR](6) NOT NULL,
       SchoolId [INT] NOT NULL,
       StudentUSI [INT] NOT NULL,
       Id uniqueidentifier NOT NULL,
       ChangeVersion bigint NOT NULL,
       CONSTRAINT PK_StudentTransportation PRIMARY KEY CLUSTERED (ChangeVersion)
)

