-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS c WHERE c.TABLE_NAME = 'ApplicationEducationOrganizations' and c.COLUMN_NAME = 'EducationOrganizationId' AND DATA_TYPE = 'int')
BEGIN
	ALTER TABLE dbo.ApplicationEducationOrganizations ALTER COLUMN EducationOrganizationId BIGINT NOT NULL
END
GO
