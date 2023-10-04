-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS c WHERE c.TABLE_NAME = 'OdsInstances' and c.COLUMN_NAME = 'ConnectionString' AND DATA_TYPE = 'NVARCHAR')
BEGIN

ALTER TABLE dbo.OdsInstances ALTER COLUMN ConnectionString NVARCHAR(1500);
END

GO
