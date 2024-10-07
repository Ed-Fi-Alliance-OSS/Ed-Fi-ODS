-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/* Generated with SSMS using:
------------------------------------------------
    DECLARE @schema NVARCHAR(128) = 'sample'; 

	SELECT 'CREATE SEQUENCE [' + c.TABLE_SCHEMA + '].[' + c.TABLE_NAME + '_AggSeq] START WITH -2147483648 INCREMENT BY 1; ALTER TABLE [' + c.TABLE_SCHEMA + '].[' + c.TABLE_NAME + '] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [' + c.TABLE_SCHEMA + '].[' + c.TABLE_NAME + '_AggSeq]; CREATE INDEX [IX_' + c.TABLE_NAME + '_AggregateId] ON [' + c.TABLE_SCHEMA + '].[' + c.TABLE_NAME + '] (AggregateId);' AS SqlServer
	FROM INFORMATION_SCHEMA.COLUMNS c
	WHERE c.COLUMN_NAME = 'Id' and c.TABLE_SCHEMA = @schema
	ORDER BY c.TABLE_SCHEMA, c.TABLE_NAME
------------------------------------------------
*/

CREATE SEQUENCE [sample].[Bus_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [sample].[Bus] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [sample].[Bus_AggSeq];
GO
CREATE INDEX [IX_Bus_AggregateId] ON [sample].[Bus] (AggregateId);
GO

CREATE SEQUENCE [sample].[BusRoute_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [sample].[BusRoute] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [sample].[BusRoute_AggSeq];
GO
CREATE INDEX [IX_BusRoute_AggregateId] ON [sample].[BusRoute] (AggregateId);
GO

CREATE SEQUENCE [sample].[StudentGraduationPlanAssociation_AggSeq] START WITH -2147483648 INCREMENT BY 1;
GO
ALTER TABLE [sample].[StudentGraduationPlanAssociation] ADD AggregateId int NOT NULL DEFAULT NEXT VALUE FOR [sample].[StudentGraduationPlanAssociation_AggSeq];
GO
CREATE INDEX [IX_StudentGraduationPlanAssociation_AggregateId] ON [sample].[StudentGraduationPlanAssociation] (AggregateId);
GO
