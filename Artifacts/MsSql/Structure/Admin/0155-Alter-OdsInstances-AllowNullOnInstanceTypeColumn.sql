-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP INDEX [UX_Name_InstanceType] ON [dbo].[OdsInstances];
GO

IF EXISTS (SELECT 1
    FROM   information_schema.columns
    WHERE  table_name = 'OdsInstances'
        AND column_name = 'InstanceType'
        AND table_schema ='dbo')
BEGIN
    ALTER TABLE dbo.OdsInstances
    ALTER COLUMN InstanceType NVARCHAR(100) NULL;
END
GO

-- Index [UX_Name_InstanceType] --
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.OdsInstances') AND name = N'UX_Name_InstanceType')
	CREATE UNIQUE NONCLUSTERED INDEX [UX_Name_InstanceType] ON [dbo].[OdsInstances]
	(
		[Name] ASC,
		[InstanceType] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO