-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF OBJECT_ID('dbo.FK_Applications_OdsInstances', 'F') IS NOT NULL
BEGIN
    ALTER TABLE [dbo].[Applications] DROP CONSTRAINT [FK_Applications_OdsInstances]
END

IF EXISTS (SELECT 1
       FROM sys.indexes I               
       WHERE I.Name = 'IX_OdsInstance_OdsInstanceId' -- Index name
        AND I.object_id = OBJECT_ID('dbo.Applications'))
BEGIN
    DROP INDEX [IX_OdsInstance_OdsInstanceId] ON [dbo].[Applications]
END

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Applications' AND COLUMN_NAME = 'OdsInstance_OdsInstanceId')
BEGIN
    ALTER TABLE [dbo].[Applications] DROP COLUMN [OdsInstance_OdsInstanceId]
END