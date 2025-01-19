-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = 'dbo'
      AND TABLE_NAME = 'ResourceClaims'
      AND COLUMN_NAME = 'DisplayName'
)
BEGIN
    ALTER TABLE dbo.ResourceClaims
    DROP COLUMN DisplayName;

    PRINT 'Column DisplayName dropped from dbo.ResourceClaims.';
END
ELSE
BEGIN
    PRINT 'Column DisplayName does not exist in dbo.ResourceClaims.';
END
GO
