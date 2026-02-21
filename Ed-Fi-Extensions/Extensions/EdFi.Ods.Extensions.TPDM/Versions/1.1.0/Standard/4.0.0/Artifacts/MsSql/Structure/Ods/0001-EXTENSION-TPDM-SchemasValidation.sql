-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'tpdm')
BEGIN
      ;THROW 50000, N'Upgrades are not supported at this time for database type ODS using the TPDM data model. This tool only supports feature scripts for this type.', 1
END
GO    