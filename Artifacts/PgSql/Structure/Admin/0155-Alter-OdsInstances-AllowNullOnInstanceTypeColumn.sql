-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Drop the index
DROP INDEX IF EXISTS dbo.UX_Name_InstanceType;
-- Alter the InstanceType column to allow NULL values
ALTER TABLE dbo.OdsInstances
ALTER COLUMN InstanceType DROP NOT NULL;

-- Recreate the index
CREATE UNIQUE INDEX UX_Name_InstanceType ON dbo.OdsInstances
(
	Name,
	InstanceType
);