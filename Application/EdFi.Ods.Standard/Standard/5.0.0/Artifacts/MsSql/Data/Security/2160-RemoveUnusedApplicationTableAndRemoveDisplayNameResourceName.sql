-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF OBJECT_ID(N'dbo.ResourceClaims', N'U') IS NOT NULL
BEGIN
    IF EXISTS (
        SELECT 1
        FROM sys.foreign_keys AS fk
        INNER JOIN sys.tables AS t ON fk.parent_object_id = t.object_id
        INNER JOIN sys.schemas AS s ON t.schema_id = s.schema_id
        INNER JOIN sys.columns AS c ON fk.parent_object_id = c.object_id 
        WHERE s.name = N'dbo'
            AND t.name = N'ResourceClaims'
            AND c.name = N'Application_ApplicationId'
            AND fk.name = N'FK_dbo.ResourceClaims_dbo.Applications_Application_ApplicationId'
    )
    BEGIN
        ALTER TABLE dbo.ResourceClaims
        DROP CONSTRAINT [FK_dbo.ResourceClaims_dbo.Applications_Application_ApplicationId];
        PRINT 'FK_dbo.ResourceClaims_dbo.Applications_Application_ApplicationId Constraint dropped.';
    END
    ELSE
    BEGIN
        PRINT 'FK_dbo.ResourceClaims_dbo.Applications_Application_ApplicationId Constraint does not exist.';
    END
END
GO

BEGIN
    IF EXISTS (
        SELECT 1
        FROM sys.foreign_keys AS fk
        INNER JOIN sys.tables AS t ON fk.parent_object_id = t.object_id
        INNER JOIN sys.schemas AS s ON t.schema_id = s.schema_id
        INNER JOIN sys.columns AS c ON fk.parent_object_id = c.object_id 
        WHERE s.name = N'dbo'
            AND t.name = N'ClaimSets'
            AND c.name = N'Application_ApplicationId'
            AND fk.name = N'FK_dbo.ClaimSets_dbo.Applications_Application_ApplicationId'
    )
    BEGIN
        ALTER TABLE dbo.ClaimSets
        DROP CONSTRAINT [FK_dbo.ClaimSets_dbo.Applications_Application_ApplicationId];
        PRINT 'FK_dbo.ClaimSets_dbo.Applications_Application_ApplicationId Constraint dropped.';
    END
    ELSE
    BEGIN
        PRINT 'FK_dbo.ClaimSets_dbo.Applications_Application_ApplicationId Constraint does not exist.';
    END
END
GO

IF OBJECT_ID(N'dbo.AuthorizationStrategies', N'U') IS NOT NULL
BEGIN
    IF EXISTS (
        SELECT 1
        FROM sys.foreign_keys AS fk
        INNER JOIN sys.tables AS t ON fk.parent_object_id = t.object_id
        INNER JOIN sys.schemas AS s ON t.schema_id = s.schema_id
        INNER JOIN sys.columns AS c ON fk.parent_object_id = c.object_id 
        WHERE s.name = N'dbo'
            AND t.name = N'AuthorizationStrategies'
            AND c.name = N'Application_ApplicationId'
            AND fk.name = N'FK_dbo.AuthorizationStrategies_dbo.Applications_Application_ApplicationId'
    )
    BEGIN
        ALTER TABLE dbo.AuthorizationStrategies
        DROP CONSTRAINT [FK_dbo.AuthorizationStrategies_dbo.Applications_Application_ApplicationId];
        PRINT 'FK_dbo.AuthorizationStrategies_dbo.Applications_Application_ApplicationId Constraint dropped.';
    END
    ELSE
    BEGIN
        PRINT 'FK_dbo.AuthorizationStrategies_dbo.Applications_Application_ApplicationId Constraint does not exist.';
    END
END
GO

IF OBJECT_ID(N'dbo.Applications', N'U') IS NOT NULL
BEGIN
    IF EXISTS (
     SELECT 1
        FROM sys.objects AS obj
        WHERE obj.parent_object_id = OBJECT_ID(N'dbo.Applications')
            AND obj.name = N'PK_dbo.Applications'
            AND obj.type_desc = 'PRIMARY_KEY_CONSTRAINT'
    )
    BEGIN
        ALTER TABLE dbo.Applications
        DROP CONSTRAINT [PK_dbo.Applications];
        PRINT 'PK_dbo.Applications Constraint dropped.';
    END
    ELSE
    BEGIN
        PRINT 'PK_dbo.Applications Constraint does not exist.';
    END
END
GO

IF OBJECT_ID(N'dbo.Applications', N'U') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Applications];
    PRINT 'Table dbo.Applications dropped.';
END
ELSE
BEGIN
    PRINT 'Table dbo.Applications does not exist.';
END
GO

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = 'dbo'
      AND TABLE_NAME = 'ResourceClaims'
      AND COLUMN_NAME IN ('DisplayName','Application_ApplicationId')
)
BEGIN

    IF EXISTS (SELECT * FROM sys.indexes WHERE name = N'IX_Application_ApplicationId' 
    AND object_id = OBJECT_ID(N'dbo.ResourceClaims'))
    DROP INDEX [IX_Application_ApplicationId] ON [dbo].[ResourceClaims];
    
    ALTER TABLE dbo.ResourceClaims
    DROP COLUMN DisplayName,
                Application_ApplicationId;

    PRINT 'Columns DisplayName and Application_ApplicationId  dropped from dbo.ResourceClaims.';
END
ELSE
BEGIN
    PRINT 'Columns DisplayName and Application_ApplicationId  do not exist in dbo.ResourceClaims.';
END
GO
