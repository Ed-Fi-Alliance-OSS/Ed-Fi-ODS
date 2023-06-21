-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1
    FROM   information_schema.columns
    WHERE  table_name = 'OdsInstances'
        AND column_name = 'Version'
        AND table_schema ='dbo')
  BEGIN
    ALTER TABLE dbo.OdsInstances
    DROP COLUMN Version
  END
GO

IF EXISTS (SELECT 1
    FROM   information_schema.columns
    WHERE  table_name = 'OdsInstances'
        AND column_name = 'Status'
        AND table_schema='dbo')
  BEGIN
      ALTER TABLE  dbo.OdsInstances
        DROP COLUMN Status
  END
GO

IF EXISTS (SELECT 1
    FROM   information_schema.columns
    WHERE  table_name = 'OdsInstances'
        AND column_name = 'IsExtended'
        AND table_schema='dbo')
  BEGIN
      ALTER TABLE dbo.OdsInstances
        DROP COLUMN IsExtended
  END
GO