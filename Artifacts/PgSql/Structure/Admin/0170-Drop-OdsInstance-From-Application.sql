-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE dbo.Applications
	DROP CONSTRAINT IF EXISTS FK_Applications_OdsInstances;
	
DROP INDEX IF EXISTS IX_OdsInstance_OdsInstanceId;

ALTER TABLE dbo.Applications
	DROP COLUMN IF EXISTS OdsInstance_OdsInstanceId;