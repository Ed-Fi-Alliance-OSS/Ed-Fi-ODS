-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'auth')
EXEC sys.sp_executesql N'CREATE SCHEMA [auth]'
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'edfi')
EXEC sys.sp_executesql N'CREATE SCHEMA [edfi]'
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'util')
EXEC sys.sp_executesql N'CREATE SCHEMA [util]'
GO
